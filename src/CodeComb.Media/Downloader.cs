using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.IO;
using System.IO.Compression;

namespace CodeComb.Media
{
    public static class Downloader
    {
        public async static Task DownloadAndExtract(
            string uri,
            params Tuple<string, string>[] files)
        {
            var tmpFile = Path.GetTempPath() + "codecomb_" + Guid.NewGuid().ToString() + ".zip";
            if (!File.Exists(tmpFile))
            {
                Console.WriteLine("Downloading from " + uri);
                using (var webClient = new HttpClient() { Timeout = new TimeSpan(1, 0, 0), MaxResponseContentBufferSize = 1024 * 1024 * 50 })
                {
                    var bytes = await webClient.GetByteArrayAsync(uri);
                    File.WriteAllBytes(tmpFile, bytes);
                    Console.WriteLine("Downloaded");
                }
            }
            using (var fileStream = new FileStream(tmpFile, FileMode.Open))
            using (var archive = new ZipArchive(fileStream))
            {
                foreach (var file in files)
                {
                    var entry = archive.GetEntry(file.Item1);
                    if (entry == null)
                        throw new Exception("Could not find file '" + file.Item1 + "'.");

                    Directory.CreateDirectory(Path.GetDirectoryName(file.Item2));

                    using (var entryStream = entry.Open())
                    using (var dllStream = File.OpenWrite(file.Item2))
                    {
                        entryStream.CopyTo(dllStream);
                    }
                }
            }
            File.Delete(tmpFile);
        }
    }
}
