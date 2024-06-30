using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sSandovalS5.Utils
{
    public class FileAccessHelper
    {
        public static string GetLocalFilePanth(string filename)
        {
            return Path.Combine(FileSystem.AppDataDirectory, filename);
        }
    }
}
