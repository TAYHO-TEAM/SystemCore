using System;
using System.IO;

namespace AppWFGenProject.FrameWork
{
    public class CreateTxt
    {
        public bool ImportLine(string[] Lines, string path)
        {
            if (DestroyFile(path))
            {
                try
                {
                    File.Create(path);
                    using (TextWriter tw = new StreamWriter("path"))
                    {
                        foreach (string line in Lines)
                            tw.WriteLine(tw);
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private static bool DestroyFile(string path)
        {
            try
            {

                if (File.Exists(path))
                {
                    // no error
                    File.Delete(path);

                }
                // but still exists
                if (File.Exists(path))
                {
                    return false;
                    //throw new IOException(string.Format("Failed to delete file: '{0}'.", path));
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
                //throw ex;
            }
        }
        

    }
}
