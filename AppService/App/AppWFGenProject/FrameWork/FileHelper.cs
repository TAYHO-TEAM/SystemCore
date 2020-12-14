using System;
using System.IO;

namespace AppWFGenProject.FrameWork
{
    public class FileHelper
    {
        public bool ChangeTxtToCS(string txtFile)
        {
            if (File.Exists(txtFile))
            {
                try
                {
                    // Create a FileInfo  
                    FileInfo fi = new FileInfo(txtFile);
                    // Check if file is there  
                    if (fi.Exists)
                    {

                        // Move file with a new name. Hence renamed.  
                        fi.MoveTo(fi.FullName.Replace(".txt", ".cs"));
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
