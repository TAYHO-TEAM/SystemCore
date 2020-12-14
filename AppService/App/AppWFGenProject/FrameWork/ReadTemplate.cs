using System.IO;
using System.Reflection;

namespace AppWFGenProject.FrameWork
{
    public class ReadTemplate
    {
        public string[] ReadTxt(string files)
        {
            //string text = File.ReadAllText(files);
            return  File.ReadAllLines(files);

            //// Display the file contents by using a foreach loop.
            //System.Console.WriteLine("Contents of WriteLines2.txt = ");
            //foreach (string line in lines)
            //{
            //    // Use a tab to indent each line of the file.

            //}
        }
        public string ReadTxtAll(string files)
        {
            return File.ReadAllText(files);
        }
        public string ReadTxtFromResource(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetName().Name + "." + fileName;
            using (Stream stream = this.GetType().Assembly.GetManifestResourceStream("*.*"))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
                return result;
            }

        }
    }
}
