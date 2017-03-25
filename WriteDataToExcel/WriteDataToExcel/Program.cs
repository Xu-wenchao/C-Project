using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;

namespace WriteDataToExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            //p.OpenExcel("E:\\CShape\\WriteDataToExcel\\标签、分类、食材整合.xls");
            p.OpenExcelGaofu("E:\\test.xlsx");
        }
        private void writeToExcel()
        {
            object Nothing = System.Reflection.Missing.Value;
            var app = new Excel.Application();
            app.Visible = false;
            Excel.Workbook workBook = app.Workbooks.Add(Nothing);
            Excel.Worksheet worksheet = (Excel.Worksheet)workBook.Sheets[1];
            worksheet.Name = "Work";
            //headline  
            worksheet.Cells[1, 1] = "FileName";
            worksheet.Cells[1, 2] = "FindString";
            worksheet.Cells[1, 3] = "ReplaceString";

            worksheet.SaveAs("Text.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
                                         Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing);

            workBook.Close(false, Type.Missing, Type.Missing);
            app.Quit(); 
        }
		private void WriteToExcel(string excelName,string filename,string findString,string replaceString)  
        {  
            //open  
            object Nothing = System.Reflection.Missing.Value;  
            var app = new Excel.Application();  
            app.Visible = false;  
            Excel.Workbook mybook = app.Workbooks.Open(excelName, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing);  
            Excel.Worksheet mysheet = (Excel.Worksheet)mybook.Worksheets[1];  
            mysheet.Activate();       
            //get activate sheet max row count  
            int maxrow = mysheet.UsedRange.Rows.Count + 1;  
            mysheet.Cells[maxrow, 1] = filename;  
            mysheet.Cells[maxrow, 2] = findString;  
            mysheet.Cells[maxrow, 3] = replaceString;  
            mybook.Save();  
            mybook.Close(false, Type.Missing, Type.Missing);  
            mybook = null;  
            //quit excel app  
            app.Quit();  
        }


        //读取EXCEL的方法   (用范围区域读取数据)
        private void OpenExcelGaofu(string strFileName)
        {
            Excel.Application excel = new Excel.Application();//lauch excel application
            try 
            {
                object missing = System.Reflection.Missing.Value;
                excel.Visible = false; excel.UserControl = true;
                // 以只读的形式打开EXCEL文件
                //Excel.Workbook wb = excel.Application.Workbooks.Open(strFileName, missing, true, missing, missing, missing,
                //    missing, missing, missing, true, missing, missing, missing, missing, missing);
                Excel.Workbook wb = excel.Application.Workbooks.Open(strFileName);
                //取得第一个工作薄
                Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets.get_Item(1);
                //取得总记录行数   (包括标题列)
                int rowsint = ws.UsedRange.Cells.Rows.Count; //得到行数
                int colsint = ws.UsedRange.Cells.Columns.Count;
                //Console.WriteLine(ws.Cells[1, 'A']);
                //////取得数据范围区域 (不包括标题列) 
                Excel.Range rng1 = ws.Cells.get_Range("A1", "A256");   //item
                //Excel.Range rng1 = ws.Cells;   //item
                object[,] arryItem = (object[,])rng1.Value2;   //get range's value
                for (int i = 1; i <= 256; i++)
                {
                    Console.WriteLine(arryItem[i, 1] + ",");
                }
      
            }
            catch { }
            finally
            {
                excel.Quit();
            }
            Console.Read();
        }

        //读取EXCEL的方法   (用范围区域读取数据)
        private void OpenExcel(string strFileName)
        {
            object missing = System.Reflection.Missing.Value;
            Excel.Application excel = new Excel.Application();//lauch excel application
            excel.Visible = false; excel.UserControl = true;
            // 以只读的形式打开EXCEL文件
            Excel.Workbook wb = excel.Application.Workbooks.Open(strFileName, missing, true, missing, missing, missing,
                missing, missing, missing, true, missing, missing, missing, missing, missing);
            //取得第一个工作薄
            Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets.get_Item(1);
            //取得总记录行数   (包括标题列)
            int rowsint = ws.UsedRange.Cells.Rows.Count; //得到行数
            int colsint = ws.UsedRange.Cells.Columns.Count;
            //取得数据范围区域 (不包括标题列) 
            //Excel.Range rng1 = ws.Cells.get_Range("A2", "A" + rowsint);   //item
            Excel.Range rng1 = ws.Cells;   //item
            object[,] arryItem = (object[,])rng1.Value2;   //get range's value
            //Console.WriteLine(arryItem[1, 2]);//输出第一行第二列

            for (int col = 1; col <= colsint; col++)
            {
                for(int row = 2; row <= rowsint; row++)
                {
                    if (arryItem[row, col] != null)
                    {
                        Console.WriteLine("insert into ec_labelsortcode(typeid, typename, detailname) values(" + col + ",'" + arryItem[1, col] + "','" + arryItem[row, col] + "');\\");
                    }
                }
            }
            excel.Quit();
            Console.Read();
        }
        private void OpenExcel2(string strFileName)
        {
            object missing = System.Reflection.Missing.Value;
            Excel.Application excel = new Excel.Application();//lauch excel application
            excel.Visible = false; excel.UserControl = true;
            // 以只读的形式打开EXCEL文件
            Excel.Workbook wb = excel.Application.Workbooks.Open(strFileName, missing, true, missing, missing, missing,
                missing, missing, missing, true, missing, missing, missing, missing, missing);
            //取得第一个工作薄
            Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets.get_Item(2);
            //取得总记录行数   (包括标题列)
            int rowsint = ws.UsedRange.Cells.Rows.Count; //得到行数
            int colsint = ws.UsedRange.Cells.Columns.Count;
            Excel.Range rng1 = ws.Cells;   //item
            object[,] arryItem = (object[,])rng1.Value2;   //get range's value
            int mainsortid = 1;
            int detailsortid = 1;
            object mainsort = arryItem[1, 2];
            for (int col = 2; col <= colsint; col++)
            {
                if (arryItem[1, col] == null)
                {
                    arryItem[1, col] = mainsort;
                }
                else
                {
                    ++mainsortid;
                    mainsort = arryItem[1, col];
                    detailsortid = 1;
                }
                for (int row = 4; row <= rowsint; row += 2)
                {
                    if (arryItem[row, col] != null)
                    {
                        Console.WriteLine("insert into ec_ingredient(mainsortid, mainsort, detailsortid, detailsort, detailname) values(" + mainsortid + ",'" + arryItem[1, col] + "'," + detailsortid + ",'" + arryItem[2, col] + "','" + arryItem[row, col] + "');\\");
                    }
                }
                ++detailsortid;
            }
            excel.Quit();
            Console.Read();
        }
    }
}
