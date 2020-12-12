using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;


namespace AppWFGenProject.Extensions
{
    public class Extension
    {
        public string GetPool(int type)
        {
            string pool = "";
            switch (type)
            {
                case 0:
                    pool = "0123456789";
                    break;
                case 1:
                    pool = "ABCDEFGHIJKLMNOPQRSTUVWYZ";
                    break;
                case 2:
                    pool = "abcdefghijklmnopqrstuvwxyz";
                    break;
                case 3:
                    pool = "0123456789ABCDEFGHIJKLMNOPQRSTUVWYZ";
                    break;
                case 4:
                    pool = "0123456789abcdefghijklmnopqrstuvwxyz";
                    break;
                case 5:
                    pool = "ABCDEFGHIJKLMNOPQRSTUVWYZabcdefghijklmnopqrstuvwxyz";
                    break;
                case 6:
                    pool = "ABCDEFGHIJKLMNOPQRSTUVWYZabcdefghijklmnopqrstuvwxyz0123456789";
                    break;
                default:
                    pool = "0123456789";
                    break;
            }
            return pool;
        }
        //public Excel.Worksheet CreateCell(Excel.Worksheet worksheet, List<string> list, int index = 0)
        //{
        //    if (index < list.Count)
        //    {
        //        worksheet.Cells[index + 1, 1] = list[index];
        //        CreateCell(worksheet, list, index + 1);
        //    }
        //    return worksheet;
        //}
        //public void SaveExcel(string path, List<string> list)
        //{
        //    int x = list.Count / 1000;
        //    if ((list.Count % 1000) > 0)
        //    {
        //        x++;
        //    }

        //    for (int i = 0; i < x; i++)
        //    {
        //        WriteExcel(path, list.Skip(i * 1000).Take(1000).ToList(), (i * 1000));
        //    }

        //}
        //public void WriteExcel(string path, List<string> list, int index)
        //{
        //    Excel.Application excelApp = new Excel.Application();
        //    Excel.Workbook workBook = excelApp.Workbooks.Open(path);
        //    Excel.Worksheet workSheet = (Excel.Worksheet)workBook.Worksheets[1];
        //    //workSheet = ext.CreateCell(workSheet, lbxListGen.Items.Cast<String>().ToList(), 0);
        //    //Excel.Range range = (Excel.Range)workSheet.Range[1000, 1];
        //    //range = range.get_Resize(lbxListGen.Items.Count, 1);
        //    //range.Value = list;
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        workSheet.Cells[index + i + 1, 1] = list[i].ToString();
        //    }
        //    // Do your work here inbetween the declaration of your workbook/worksheet  
        //    // and the save action below.
        //    //workBook.SaveAs(path, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        //    workBook.Save();
        //    workBook.Close();
        //    excelApp.Quit();
        //}
        public void WriteExcelEPPlus(string path, List<string> list, int index)
        {
            using (ExcelPackage pck = new ExcelPackage())
            {
                var workSheet = pck.Workbook.Worksheets.Add("Sheet1");
                workSheet.TabColor = System.Drawing.Color.Black;
                workSheet.DefaultRowHeight = 12;
                for (int i = 0; i < list.Count; i++)
                {
                    workSheet.Cells[index + i + 1, 1].Value = list[i].ToString();
                }
                workSheet.Column(1).AutoFit();
                pck.Save();
                if (File.Exists(path))
                    File.Delete(path);

                // Create excel file on physical disk  
                FileStream objFileStrm = File.Create(path);
                objFileStrm.Close();
                File.WriteAllBytes(path, pck.GetAsByteArray());
            }
        }
    }
}
