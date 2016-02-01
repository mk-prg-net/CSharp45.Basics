using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCounter
{
    public class ImageFilesCounter : DMS.DirTree
    {

        public int GifFilesCount { get; set; }

        public int JpegFilesCount { get; set; }

        public void ResetCounters()
        {
            GifFilesCount = 0;
            JpegFilesCount = 0;
        }


        protected override bool TouchFile(string path)
        {
            if (System.IO.Path.GetExtension(path).ToLower() == ".gif")
                GifFilesCount++;

            if (System.IO.Path.GetExtension(path).ToLower() == ".jpg")
                JpegFilesCount++;

            return true;
        }

    }
}
