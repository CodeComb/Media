using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeComb.Media.Sample
{
    public class Program
    {
        public void Main(string[] args)
        {
            var media = new Video("C:\\test\\test.flv");
            media.Convert(".mp4", Quality.Smallest).SaveAs(@"C:\\test\\csh.mp4");
        }
    }
}
