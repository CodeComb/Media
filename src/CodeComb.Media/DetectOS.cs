using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
#if DNXCORE50 || DNX451
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Dnx.Runtime;
using Microsoft.Dnx.Runtime.Infrastructure;
#endif

namespace CodeComb.Media
{
    public enum OS
    {
        Windows,
        OSX,
        Linux
    }

    public static class DetectOS
    {
        public static OS CurrentOS
        {
            get
            {
#if DNXCORE50
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    return OS.Windows;
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    return OS.OSX;
                else
                    return OS.Linux;
#elif DNX451
                var services = CallContextServiceLocator.Locator.ServiceProvider;
                var env = services.GetService<IRuntimeEnvironment>();
                if (env.OperatingSystem == "Windows")
                    return OS.Windows;
                else if (env.OperatingSystem == "Mac")
                    return OS.OSX;
                else
                    return OS.Linux;
#else
                if (Environment.OSVersion.Platform == PlatformID.Win32NT || Environment.OSVersion.Platform == PlatformID.Win32S || Environment.OSVersion.Platform == PlatformID.Win32Windows || Environment.OSVersion.Platform == PlatformID.WinCE)
                    return OS.Windows;
                else if (Environment.OSVersion.Platform == PlatformID.MacOSX)
                    return OS.OSX;
                else
                    return OS.Linux;
#endif
            }
        }
    }
}
