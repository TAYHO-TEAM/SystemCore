using System;
using System.IO;
using System.Collections.Generic;

namespace AppWFGenProject.FrameWork
{
    public class FileHelper
    {
        public bool ReplaceLine(string txtFile, Dictionary<string,string> dicGenOB)
        {

            //    StreamReader reader = new StreamReader(directory + fileName);
            //    string input = reader.ReadToEnd();

            //    using (StreamWriter writer = new StreamWriter(directory + saveFileName, true))
            //    {
            //        {
            //            string output = input.Replace(word, replacement);
            //            writer.Write(output);
            //        }
            //        writer.Close();
            //    }

            if (File.Exists(txtFile))
            {
                using (var sourceFile = File.OpenText(txtFile))
                {
                    // Open a stream for the temporary file
                    using (var tempFileStream = new StreamWriter(txtFile))
                    {
                        string line;
                        // read lines while the file has them
                        while ((line = sourceFile.ReadLine()) != null)
                        {
                            foreach(var item in dicGenOB)
                            {
                                // Do the word replacement
                                line = line.Replace(item.Key, item.Value); 
                            }
                            // Write the modified line to the new file
                            tempFileStream.WriteLine(line);
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CreateFileFrom(string txtFileOld,string txtFileNew, Dictionary<string, string> dicGenOB)
        {
            if (File.Exists(txtFileOld))
            {
                if (File.Exists(txtFileNew))
                {
                    File.Delete(txtFileNew);
                }
                using (var sourceFile = File.OpenText(txtFileOld))
                {
                    // Open a stream for the temporary file
                    using (var tempFileStream = new StreamWriter(txtFileNew))
                    {
                        string line;
                        // read lines while the file has them
                        while ((line = sourceFile.ReadLine()) != null)
                        {
                            foreach (var item in dicGenOB)
                            {
                                // Do the word replacement
                                line = line.Replace(item.Key, item.Value);
                            }
                            // Write the modified line to the new file
                            tempFileStream.WriteLine(line);
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ReplaceLine(string txtFile, string sourcetxt,string destxt)
        {
            if (File.Exists(txtFile))
            {
                using (var sourceFile = File.OpenText(txtFile))
                {
                    // Open a stream for the temporary file
                    using (var tempFileStream = new StreamWriter(txtFile))
                    {
                        string line;
                        // read lines while the file has them
                        while ((line = sourceFile.ReadLine()) != null)
                        {
                            // Do the word replacement
                            line = line.Replace(sourcetxt, destxt);
                            // Write the modified line to the new file
                            tempFileStream.WriteLine(line);
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
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
        public bool CompileFile(string txtFile, string sourceFile,string desfile)
        {
            Path.Combine(txtFile, txtFile.Replace(sourceFile, desfile));
            return true;
        }
        public bool CreateTxt(string txtFile,string content)
        {
            if (DestroyFile(txtFile))
            {
                //File.Create(txtFile);
                try
                {
                    // Create a FileInfo  
                    FileInfo fi = new FileInfo(txtFile);
                    // Check if file is there  
                    if (!fi.Exists)
                    {
                        using (StreamWriter sw = File.CreateText(txtFile))
                        {
                            sw.Write(content);
                        }
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
        public bool ImportLine(string[] Lines, string path)
        {
            if (DestroyFile(path))
            {
                try
                {
                    File.Create(path);
                    using (TextWriter tw = new StreamWriter(path))
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
        public void ChangeFileTemp(string pathOld , string pathNew)
        {
            if (File.Exists(pathOld))
            {
                File.Delete(pathOld);
            }

            File.Move(pathOld, pathNew);
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
