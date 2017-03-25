using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.HSSF.UserModel;
using System.IO;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.SS.UserModel;

namespace TestNOPI
{
    class Program
    {
        static void Main(string[] args)
        {
            //write();
            read();
            Console.ReadKey();
        }
        public static void read()
        {
            HSSFWorkbook hssfworkbook;
            using (FileStream file = new FileStream(@"test.xls", FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new HSSFWorkbook(file);
                ISheet sheet = hssfworkbook.GetSheetAt(0);
                System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

                while (rows.MoveNext())
                {
                    HSSFRow row = (HSSFRow)rows.Current;

                    for (int i = 0; i < row.LastCellNum; i++)
                    {
                        ICell cell = row.GetCell(i);
                        //TODO::set cell value to the cell of DataTables
                        
                        Console.WriteLine(cell.CellType + "*" + cell.NumericCellValue);
                    }
                }
            }
        }

        public static void write()
        {
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            hssfworkbook.DocumentSummaryInformation = dsi;
            hssfworkbook.SummaryInformation = si;

            ISheet sheet1 = hssfworkbook.CreateSheet("Sheet1");
            hssfworkbook.CreateSheet("Sheet2");
            hssfworkbook.CreateSheet("Sheet3");
            IRow row1 = sheet1.CreateRow(0);
            row1.CreateCell(0).SetCellValue("1");
            FileStream file = new FileStream(@"test.xls", FileMode.Create);
            hssfworkbook.Write(file);
            file.Close();
        }
    }
}
