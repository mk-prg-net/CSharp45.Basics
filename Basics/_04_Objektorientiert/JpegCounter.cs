using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._04_Objektorientiert
{
    public class JpegCounter : DMS.DirTree
    {

        public long Count { get; set; }

        protected override bool BeginScanDir(string path)
        {
            Count = 0;
            return true;
        }

        protected override bool TouchFile(string path)
        {
            string ext = System.IO.Path.GetExtension(path).ToLower();
            if (ext == ".jpg")
                Count++;
            return true;
        }

    }


}
