using OfficeOpenXml;
using System;
using System.Data;
using System.IO;

namespace WinFormsApp1.b
{
    internal class excel : z
    {
        public static DataTable parse(string filePath, string sheetName, bool hasHeader = true)
        {
            var dt = new DataTable();
            var fi = new FileInfo(filePath);
            // Check if the file exists
            if (!fi.Exists)
                throw new Exception("File " + filePath + " Does Not Exists");

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var xlPackage = new ExcelPackage(fi);
            // get the first worksheet in the workbook
            var worksheet = xlPackage.Workbook.Worksheets[sheetName];

            dt = worksheet.Cells[1, 1, worksheet.Dimension.End.Row, worksheet.Dimension.End.Column].ToDataTable(c =>
            {
                c.FirstRowIsColumnNames = true;
            });

            return dt;
        }



    }
}
