using System.IO;

namespace AppWFGenProject.FrameWork
{
    public class ReadTemplate
    {
        public string[] ReadTxt(string files)
        {
            //string text = File.ReadAllText(@"files");
            return  File.ReadAllLines(@"files");

            //// Display the file contents by using a foreach loop.
            //System.Console.WriteLine("Contents of WriteLines2.txt = ");
            //foreach (string line in lines)
            //{
            //    // Use a tab to indent each line of the file.

            //}
        }
    }
}
