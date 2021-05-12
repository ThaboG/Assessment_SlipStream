using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_SlipStream.Common.Helper
{
    public class FileSys
    {
        public static async Task<string> CreateFolder(string FullFolderPath)
        {
            System.IO.Directory.CreateDirectory(FullFolderPath);

            while (!System.IO.Directory.Exists(FullFolderPath))
            {
                await Task.Delay(1000);
            }

            return FullFolderPath;
        }
    }
}
