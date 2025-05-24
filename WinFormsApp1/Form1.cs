using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WinFormsApp1.b;
using Excel = Microsoft.Office.Interop.Excel;
using System.Globalization;
using MaterialSkin.Controls;
using MaterialSkin;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using DataTable = System.Data.DataTable;
using Font = System.Drawing.Font;
using System.Drawing;
using Microsoft.VisualBasic.ApplicationServices;
using OfficeOpenXml;
using Rectangle = System.Drawing.Rectangle;
using ToolTip = System.Windows.Forms.ToolTip;
using Application = System.Windows.Forms.Application;

namespace WinFormsApp1
{
    public partial class Form1 : Form /*: MaterialForm*/
    {
        haj hajj = new haj();
        haj_bus hajj_Buss = new haj_bus();
        buus buuss = new buus();
        camp cam = new camp();
        haj_camp_bed hcb = new haj_camp_bed();



        public Form1()
        {
            InitializeComponent();
            //var materialSkinManager = MaterialSkinManager.Instance;
            //materialSkinManager.AddFormToManage(this);
            //materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            //materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            //materialComboBox1.DataSource = buuss.all_data();
            //materialComboBox1.ValueMember = "bus_id";
            //materialComboBox1.DisplayMember = "bus_num";
            //materialComboBox1.SelectedIndex = -1;

            //DataGridView_style(dataGridView1);
            //DataGridView_style(dataGridView2);
            //DataGridView_style(dataGridView4);

            //materialCheckbox1.RightToLeft = RightToLeft.No;
            //this.RightToLeft = RightToLeft.No;


            // Set TabControl appearance
            tabControl1.Appearance = TabAppearance.Buttons;
            tabControl1.ItemSize = new System.Drawing.Size(120, 30);
            tabControl1.Alignment = TabAlignment.Top;

            // Add custom tab headers with images
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.DrawItem += TabControl1_DrawItem;
            //imageList1.Images.Add("tab1", MaterialSkin.Properties.Resources.Tab1Image);
            //imageList1.Images.Add("tab2", MaterialSkin.Properties.Resources.Tab2Image);
            tabControl1.ImageList = imageList1;
            tabPage1.ImageKey = "tab1";
            tabPage3.ImageKey = "tab2";
            tabPage4.ImageKey = "tab2";
            // Enable tab scrolling
            tabControl1.Multiline = true;

            // Customize tab selection appearance
            tabPage1.BackColor = System.Drawing.Color.LightBlue;
            tabPage1.ForeColor = System.Drawing.Color.White;
            tabPage1.Font = new System.Drawing.Font(tabPage1.Font, System.Drawing.FontStyle.Bold);

            // Add tooltips to tabs
            ToolTip toolTip1 = new ToolTip();
            toolTip1.SetToolTip(tabPage1, "Tab 1 Tooltip");
            toolTip1.SetToolTip(tabPage3, "Tab 2 Tooltip");
            toolTip1.SetToolTip(tabPage4, "Tab 2 Tooltip");
        }
        private void TabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            TabPage tabPage = tabControl.TabPages[e.Index];

            // Draw custom tab headers
            e.Graphics.FillRectangle(SystemBrushes.Control, e.Bounds);
            Rectangle rect = e.Bounds;
            rect.Offset(2, 2);
            if (tabPage.ImageKey != null && imageList1.Images.ContainsKey(tabPage.ImageKey))
            {
                Image image = imageList1.Images[tabPage.ImageKey];
                e.Graphics.DrawImage(image, rect.Left, rect.Top, 24, 24);
                rect.Offset(26, 0);
            }
            TextRenderer.DrawText(e.Graphics, tabPage.Text, e.Font, rect, e.ForeColor, TextFormatFlags.Left);
        }
        private void DataGridView_style(DataGridView DataGridViews)
        {
            // Set the background color of the DataGridView
            DataGridViews.BackgroundColor = Color.FromArgb(41, 53, 65);
            // Set the foreground color of the DataGridView cells
            DataGridViews.ForeColor = Color.White;
            // Set the selection background color of the DataGridView cells
            DataGridViews.DefaultCellStyle.SelectionBackColor = Color.FromArgb(78, 184, 206);
            // Set the selection foreground color of the DataGridView cells
            DataGridViews.DefaultCellStyle.SelectionForeColor = Color.Black;
            // Set the border color of the DataGridView
            DataGridViews.GridColor = Color.FromArgb(44, 46, 64);
            // Set the font style of the DataGridView headers
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            DataGridViews.ColumnHeadersDefaultCellStyle.Font = headerFont;
            DataGridViews.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            // Set the style of the DataGridView headers
            DataGridViews.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(29, 31, 43);
            DataGridViews.EnableHeadersVisualStyles = false;
            // Set the style of the DataGridView row headers
            DataGridViews.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(29, 31, 43);
            // Set the style of the DataGridView scrollbar
            DataGridViews.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            // Set the font color of the DataGridView cells
            DataGridViews.DefaultCellStyle.ForeColor = Color.Black;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = hajj_Buss.all_data();
            #region MyRegion
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";

            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    string filePath = openFileDialog.FileName;

            //    // Create a new DataTable to hold the Excel data
            //    DataTable dt = new DataTable();
            //    dt.Columns.Add("Sheet Name"); // Add column to store sheet name

            //    using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
            //    {
            //        foreach (ExcelWorksheet worksheet in package.Workbook.Worksheets)
            //        {
            //            // Extract column headers from the first row of each worksheet
            //            int startRow = worksheet.Dimension.Start.Row;
            //            int endRow = worksheet.Dimension.End.Row;
            //            int startCol = worksheet.Dimension.Start.Column;
            //            int endCol = worksheet.Dimension.End.Column;

            //            // Create a dictionary to map column names from Excel to DataTable
            //            Dictionary<string, string> columnMapping = new Dictionary<string, string>();

            //            // If this is the first worksheet, create columns in the DataTable and populate the column mapping
            //            if (worksheet.Index == 1)
            //            {
            //                for (int col = startCol; col <= endCol; col++)
            //                {
            //                    string excelColumnName = worksheet.Cells[startRow, col].Text;
            //                    string dataTableColumnName = !string.IsNullOrEmpty(excelColumnName) ? excelColumnName : $"Column{col - startCol + 1}";

            //                    if (!columnMapping.ContainsKey(excelColumnName))
            //                    {
            //                        int counter = 1;
            //                        string uniqueColumnName = dataTableColumnName;
            //                        while (columnMapping.ContainsValue(uniqueColumnName))
            //                        {
            //                            uniqueColumnName = $"{dataTableColumnName}_{counter}";
            //                            counter++;
            //                        }

            //                        dt.Columns.Add(uniqueColumnName);
            //                        columnMapping.Add(excelColumnName, uniqueColumnName);
            //                    }
            //                }
            //            }

            //            // Extract data from the remaining rows
            //            for (int row = startRow + 1; row <= endRow; row++)
            //            {
            //                string reservationNumber = worksheet.Cells[row, startCol].Value?.ToString(); // Assuming "—ﬁ„ «·ÕÃ“" column is the first column (startCol)

            //                if (!string.IsNullOrEmpty(reservationNumber))
            //                {
            //                    DataRow dataRow = dt.Rows.Add();
            //                    dataRow["Sheet Name"] = worksheet.Name; // Store sheet name in the first column

            //                    for (int col = startCol + 1; col <= endCol; col++) // Start from startCol + 1 to skip the "—ﬁ„ «·ÕÃ“" column
            //                    {
            //                        string excelColumnName = worksheet.Cells[startRow, col].Text;
            //                        string dataTableColumnName = columnMapping.ContainsKey(excelColumnName) ? columnMapping[excelColumnName] : null;

            //                        if (!string.IsNullOrEmpty(dataTableColumnName) && dt.Columns.Contains(dataTableColumnName))
            //                        {
            //                            dataRow[dataTableColumnName] = worksheet.Cells[row, col].Value?.ToString();
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }

            //    // Bind the DataTable to the DataGridView
            //    dataGridView1.DataSource = dt;
            //} 
            #endregion
            #region MyRegion
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
            openFileDialog.Title = "Select Excel File";
            // Show the OpenFileDialog and get the selected file
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Open(filePath);
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Sheet Name");
                dataTable.Columns.Add("„");
                dataTable.Columns.Add("Õ«·… «·Õ«Ã");
                dataTable.Columns.Add("«·„œÌ‰…");
                dataTable.Columns.Add("«”„ «·Õ«Ã");
                dataTable.Columns.Add("—ﬁ„ «·ÃÊ«·");
                dataTable.Columns.Add("—ﬁ„ «·ÂÊÌ…");
                dataTable.Columns.Add("—ﬁ„ «·ÕÃ“");
                try
                {
                    int asc = workbook.Sheets.Count;
                    foreach (Excel.Worksheet sheet in workbook.Sheets)
                    {
                        Excel.Range range = sheet.UsedRange;
                        object[,] values = range.Value;
                        if (values != null)
                        {
                            int rowCount = values.GetLength(0);
                            int columnCount = values.GetLength(1);

                            //// Create columns in the DataTable based on the number of columns in the sheet
                            //if (dataTable.Columns.Count == 0)
                            //{
                            //    // Add a new column for sheet name
                            //    dataTable.Columns.Add("Sheet Name");

                            //    for (int c = 1; c <= columnCount; c++)
                            //    {
                            //        // Get the column name from Excel and add it to the DataTable
                            //        object columnValue = values[1, c];
                            //        string columnName = columnValue != null && columnValue != DBNull.Value ? columnValue.ToString() : "Column" + c;
                            //        dataTable.Columns.Add(columnName);
                            //    }
                            //}

                            // Populate the DataTable with data from the sheet
                            for (int r = 2; r <= rowCount; r++) //row 1 is header
                            {
                                bool isRowEmpty = true; // Flag to track if the row is empty

                                // Check if all values in the row are null or empty strings
                                for (int c = 1; c <= columnCount; c++)
                                {
                                    if (values[r, c] != null && values[r, c] != DBNull.Value && !string.IsNullOrEmpty(values[r, c].ToString()))
                                    {
                                        isRowEmpty = false;
                                        break;
                                    }
                                }

                                if (!isRowEmpty)
                                {
                                    DataRow dr = dataTable.NewRow();
                                    // Set the sheet name in the first column
                                    dr["Sheet Name"] = sheet.Name;
                                    dr["„"] = values[r, 1];
                                    dr["Õ«·… «·Õ«Ã"] = values[r, 2];
                                    dr["«·„œÌ‰…"] = values[r, 4];
                                    dr["«”„ «·Õ«Ã"] = values[r, 11];
                                    dr["—ﬁ„ «·ÃÊ«·"] = values[r, 12];
                                    dr["—ﬁ„ «·ÂÊÌ…"] = values[r, 13];
                                    dr["—ﬁ„ «·ÕÃ“"] = values[r, 14];
                                    //dr["‰Ê⁄ «·›« Ê—…"] = tb2.Rows[0][1].ToString();
                                    //string[] type1 = System.Text.RegularExpressions.Regex.Split(tb2.Rows[0][6].ToString(), "<#>");
                                    //dr[" ﬂ·›… «·›« Ê—…"] = type1[0];
                                    //dr["Œ’„ »‰”»…"] = tb2.Rows[0][2].ToString();
                                    //dr["Œ’„ „»·€"] = tb2.Rows[0][3].ToString();
                                    //dr["„»·€ «÷«›Ì"] = tb2.Rows[0][5].ToString();
                                    //dr[" «—ÌŒ «·›« Ê—…"] = tb2.Rows[0][4].ToString();
                                    //for (int c = 1; c <= columnCount; c++)
                                    //{
                                    //    try
                                    //    {
                                    //        dr[c] = values[r, c];
                                    //    }
                                    //    catch { }
                                    //}
                                    dataTable.Rows.Add(dr);
                                }
                            }
                            Marshal.ReleaseComObject(range);
                            Marshal.ReleaseComObject(sheet);
                        }
                    }
                    // Close the Excel file
                    workbook.Close(false);
                    excelApp.Quit();
                }
                finally
                {
                    // Release Excel objects
                    Marshal.ReleaseComObject(workbook);
                    Marshal.ReleaseComObject(excelApp);

                    // Garbage collect to ensure Excel process is fully closed
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }

                dataGridView1.DataSource = dataTable;
                MessageBox.Show(dataTable.Rows.Count.ToString());
            }
            #endregion
        }


        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Create a new DataTable to hold the Excel data
                DataTable dt = new DataTable();

                using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Assuming the data is in the first sheet

                    // Extract column headers from the first row of the worksheet
                    foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                    {
                        dt.Columns.Add(firstRowCell.Text);
                    }

                    // Extract data from the remaining rows
                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                    {
                        DataRow dataRow = dt.Rows.Add();
                        for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                        {
                            dataRow[col - 1] = worksheet.Cells[row, col].Text;
                        }
                    }
                }

                // Bind the DataTable to the DataGridView
                dataGridView2.DataSource = dt;
            }
            #region MyRegion
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
            //openFileDialog.Title = "Select Excel File";
            //// Show the OpenFileDialog and get the selected file
            //DialogResult dialogResult = openFileDialog.ShowDialog();
            //if (dialogResult == DialogResult.OK)
            //{
            //    string filePath = openFileDialog.FileName;
            //    Excel.Application excelApp = new Excel.Application();
            //    Excel.Workbook workbook = excelApp.Workbooks.Open(filePath);
            //    System.Data.DataTable dataTable = new System.Data.DataTable();
            //    try
            //    {
            //        foreach (Excel.Worksheet sheet in workbook.Sheets)
            //        {
            //            Excel.Range range = sheet.UsedRange;
            //            object[,] values = range.Value;
            //            if (values != null)
            //            {
            //                int rowCount = values.GetLength(0);
            //                int columnCount = values.GetLength(1);
            //                if (dataTable.Columns.Count == 0)
            //                {
            //                    for (int c = 1; c <= columnCount; c++)
            //                    {
            //                        object columnValue = values[1, c];
            //                        string columnName = columnValue != null && columnValue != DBNull.Value ? columnValue.ToString() : "Column" + c;
            //                        dataTable.Columns.Add(columnName);
            //                    }
            //                }
            //                // Populate the DataTable with data from the sheet
            //                for (int r = 2; r <= rowCount; r++) // Assuming header row is excluded
            //                {
            //                    DataRow row = dataTable.NewRow();
            //                    for (int c = 1; c <= columnCount; c++)
            //                    {
            //                        try
            //                        {
            //                            row[c - 1] = values[r, c];
            //                        }
            //                        catch { }
            //                    }
            //                    dataTable.Rows.Add(row);
            //                }
            //                Marshal.ReleaseComObject(range);
            //                Marshal.ReleaseComObject(sheet);
            //            }
            //        }
            //        // Close the Excel file
            //        workbook.Close(false);
            //        excelApp.Quit();
            //    }
            //    finally
            //    {
            //        // Release Excel objects
            //        Marshal.ReleaseComObject(workbook);
            //        Marshal.ReleaseComObject(excelApp);
            //        // Garbage collect to ensure Excel process is fully closed
            //        GC.Collect();
            //        GC.WaitForPendingFinalizers();
            //    }
            //    System.Data.DataTable casaa = hajj.get_all_data();
            //    dataGridView2.DataSource = dataTable;
            //    if (false /*dataTable.Rows.Count > 0*/)
            //    {
            //        List<string> list = new List<string>();
            //        string message = "";
            //        for (int i = 0; i < dataTable.Rows.Count; i++)
            //        {
            //            string foun = hajj.search_if_nat_id_exist(dataTable.Rows[i][11].ToString());
            //            if (foun != "-1")
            //            {
            //                hajj.update_haj(Convert.ToInt32(foun), dataTable.Rows[i][9].ToString()
            //                , "", ""
            //                , dataTable.Rows[i][10].ToString(), dataTable.Rows[i][12].ToString()
            //                , dataTable.Rows[i][7].ToString(), dataTable.Rows[i][11].ToString()
            //                , dataTable.Rows[i][6].ToString(), dataTable.Rows[i][2].ToString()
            //                , DateTime.Now.ToString("yyyy", CultureInfo.CreateSpecificCulture("en-US"))
            //                , dataTable.Rows[i][0].ToString()
            //                , "",
            //                  "");
            //            }
            //            else
            //            {
            //                list.Add(dataTable.Rows[i][11].ToString());
            //                // Concatenate the list items into a single string
            //                message = string.Join(Environment.NewLine, list);

            //                string cv = hajj.addhaj(dataTable.Rows[i][9].ToString()
            //                , "", ""
            //                , dataTable.Rows[i][10].ToString(), dataTable.Rows[i][12].ToString()
            //                , dataTable.Rows[i][7].ToString(), dataTable.Rows[i][11].ToString()
            //                , dataTable.Rows[i][6].ToString(), dataTable.Rows[i][2].ToString()
            //                , DateTime.Now.ToString("yyyy", CultureInfo.CreateSpecificCulture("en-US"))
            //                , dataTable.Rows[i][0].ToString()
            //                , "",
            //                  "");
            //            }

            //        }
            //        // Show the message box if Not empty
            //        if (message != "")
            //        {
            //            MessageBox.Show(message);
            //        }
            //    }
            //    MessageBox.Show(hajj.get_all_num());
            //} 
            #endregion
        }
        private void button3_Click(object sender, EventArgs e)
        {
            System.Data.DataTable tableA = GetDataGridViewData(dataGridView1);
            System.Data.DataTable tableB = GetDataGridViewData(dataGridView2);
            var unmatchedRows = from rowB in tableB.AsEnumerable()
                                where !tableA.AsEnumerable().Any(rowA => rowA.Field<string>("—ﬁ„ «·ÂÊÌ…") == rowB.Field<string>("—ﬁ„ «·ÂÊÌ…") && rowA.Field<string>("Õ«·… «·Õ«Ã") == rowB.Field<string>("Õ«·… «·Õ«Ã"))
                                select rowB;
            var unmatchedRows2 = from rowA in tableA.AsEnumerable()
                                 where !tableB.AsEnumerable().Any(rowB => rowB.Field<string>("—ﬁ„ «·ÂÊÌ…") == rowA.Field<string>("—ﬁ„ «·ÂÊÌ…") && rowB.Field<string>("Õ«·… «·Õ«Ã") == rowA.Field<string>("Õ«·… «·Õ«Ã"))
                                 select rowA;
            // Create Table C with the same columns as Table B
            System.Data.DataTable tableC = tableB.Clone();
            System.Data.DataTable tableD = tableA.Clone();
            // Add unmatched rows to Table C
            foreach (var row in unmatchedRows)
            {
                tableC.ImportRow(row);
            }
            foreach (var row in unmatchedRows2)
            {
                tableD.ImportRow(row);
            }
            dataGridView1.DataSource = tableD;
            dataGridView2.DataSource = tableC;
        }
        static System.Data.DataTable GetDataGridViewData(DataGridView dataGridView)
        {
            System.Data.DataTable dataTable = new System.Data.DataTable();
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                dataTable.Columns.Add(column.Name);
            }
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                DataRow dataRow = dataTable.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dataRow[cell.ColumnIndex] = cell.Value;
                }
                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
            //openFileDialog.Title = "Select Excel File";
            //// Show the OpenFileDialog and get the selected file
            //DialogResult dialogResult = openFileDialog.ShowDialog();

            //if (dialogResult == DialogResult.OK)
            //{
            //    string filePath = openFileDialog.FileName;
            //    Excel.Application excelApp = new Excel.Application();
            //    Excel.Workbook workbook = excelApp.Workbooks.Open(filePath);
            //    System.Data.DataTable dataTable = new System.Data.DataTable();
            //    try
            //    {
            //        foreach (Excel.Worksheet sheet in workbook.Sheets)
            //        {
            //            Excel.Range range = sheet.UsedRange;
            //            object[,] values = range.Value;
            //            if (values != null)
            //            {
            //                int rowCount = values.GetLength(0);
            //                int columnCount = values.GetLength(1);
            //                if (dataTable.Columns.Count == 0)
            //                {
            //                    for (int c = 1; c <= columnCount; c++)
            //                    {
            //                        object columnValue = values[1, c];
            //                        string columnName = columnValue != null && columnValue != DBNull.Value ? columnValue.ToString() : "Column" + c;
            //                        dataTable.Columns.Add(columnName);
            //                    }
            //                }
            //                // Populate the DataTable with data from the sheet
            //                for (int r = 2; r <= rowCount; r++) // Assuming header row is excluded
            //                {
            //                    DataRow row = dataTable.NewRow();
            //                    for (int c = 1; c <= columnCount; c++)
            //                    {
            //                        try
            //                        {
            //                            row[c - 1] = values[r, c];
            //                        }
            //                        catch { }
            //                    }
            //                    dataTable.Rows.Add(row);
            //                }
            //                Marshal.ReleaseComObject(range);
            //                Marshal.ReleaseComObject(sheet);
            //            }
            //        }
            //        // Close the Excel file
            //        workbook.Close(false);
            //        excelApp.Quit();
            //    }
            //    finally
            //    {
            //        // Release Excel objects
            //        Marshal.ReleaseComObject(workbook);
            //        Marshal.ReleaseComObject(excelApp);
            //        // Garbage collect to ensure Excel process is fully closed
            //        GC.Collect();
            //        GC.WaitForPendingFinalizers();
            //    }
            //    System.Data.DataTable casaa = hajj.get_all_data();
            //    dataGridView2.DataSource = dataTable;
            //    if (dataTable.Rows.Count > 0)
            //    {
            //        string message = "";
            //        for (int i = 0; i < dataTable.Rows.Count; i++)
            //        {
            //            string foun = hajj.search_if_nat_id_exist(dataTable.Rows[i][11].ToString());
            //            if (foun != "-1")
            //            {
            //                hajj_Buss.add_hajinfo(Convert.ToInt32(foun), dataTable.Rows[i][9].ToString()
            //                , Convert.ToInt32(materialComboBox1.SelectedValue), materialComboBox1.Text, "", "", "");
            //            }
            //            else
            //            {
            //                //list.Add(dataTable.Rows[i][11].ToString());
            //                //// Concatenate the list items into a single string
            //                //message = string.Join(Environment.NewLine, list);

            //                //string cv = hajj.addhaj(dataTable.Rows[i][9].ToString()
            //                //, "", ""
            //                //, dataTable.Rows[i][10].ToString(), dataTable.Rows[i][12].ToString()
            //                //, dataTable.Rows[i][7].ToString(), dataTable.Rows[i][11].ToString()
            //                //, dataTable.Rows[i][6].ToString(), dataTable.Rows[i][2].ToString()
            //                //, DateTime.Now.ToString("yyyy", CultureInfo.CreateSpecificCulture("en-US"))
            //                //, dataTable.Rows[i][0].ToString()
            //                //, "",
            //                //  "");
            //            }

            //        }
            //        // Show the message box if Not empty
            //        if (message != "")
            //        {
            //            MessageBox.Show(message);
            //        }
            //        //MessageBox.Show(hajj.get_all_num());
            //    }
            //}

        }
        private void materialButton1_Click(object sender, EventArgs e)
        {


        }
        private void materialButton2_Click(object sender, EventArgs e)
        {
            //string filePath = "";
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
            //openFileDialog.Title = "Select Excel File";
            //// Show the OpenFileDialog and get the selected file
            //DialogResult dialogResult = openFileDialog.ShowDialog();
            //if (dialogResult == DialogResult.OK)
            //{
            //     filePath = openFileDialog.FileName;


            //    excel asd = new excel();
            //DataSet dataSet = asd.Parse(filePath);
            //// Fill the DataSet with data

            //if (dataSet.Tables.Count == 1)
            //{
            //    // If there is only one table, cast it to a DataTable and assign it as the DataSource
            //    dataGridView1.DataSource = dataSet.Tables[0];
            //}
            //else if (dataSet.Tables.Count > 1)
            //{
            //    // If there are multiple tables, create a new DataTable and merge all the tables into it
            //    DataTable mergedTable = new DataTable();
            //    foreach (DataTable table in dataSet.Tables)
            //    {
            //        mergedTable.Merge(table);
            //    }

            //    // Assign the merged DataTable as the DataSource
            //    dataGridView1.DataSource = mergedTable;
            //}
            //}
            //MessageBox.Show(hajj.get_all_num());
            //MessageBox.Show(hajj_Buss.all_data());
            //hajj_Buss.del_all();
            //for (int i = 0; i < dataGridView1.Rows.Count -1; i++)
            //{
            //    string asc = dataGridView1.Rows[i].Cells[13].Value.ToString();
            //    string foun = hajj.search_if_nat_id_exist(asc);
            //    if (foun != "-1")
            //    {
            //        string name = dataGridView1.Rows[i].Cells[11].Value.ToString();
            //        int idd = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString());
            //        string iddd = dataGridView1.Rows[i].Cells[0].Value.ToString();
            //        hajj_Buss.add_hajinfo(Convert.ToInt32(foun), name
            //        , idd, iddd
            //        , ""
            //        , "",
            //          "");
            //    }
            //    else
            //    {

            //    }
            //}

            //for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            //{
            //    string nat_id = dataGridView1.Rows[i].Cells[12].Value.ToString();
            //    System.Data.DataTable foun = hajj.bring_data_nat(nat_id);
            //    if (foun.Rows.Count > 0)
            //    {
            //        string name = foun.Rows[0][1].ToString();
            //        string res = foun.Rows[0][11].ToString();
            //        if (dataGridView1.Rows[i].Cells[10].Value.ToString() != name ||
            //       dataGridView1.Rows[i].Cells[1].Value.ToString() != res)
            //        {
            //            MessageBox.Show("error");
            //            //string name = dataGridView1.Rows[i].Cells[11].Value.ToString();
            //            //int idd = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString());
            //            //string iddd = dataGridView1.Rows[i].Cells[0].Value.ToString();
            //            //hajj_Buss.add_hajinfo(Convert.ToInt32(foun), name
            //            //, idd, iddd
            //            //, ""
            //            //, "",
            //            //  "");
            //        }

            //    }
            //    else
            //    {

            //    }
            //}





        }
        private void materialButton3_Click(object sender, EventArgs e)
        {



        }

        private void materialButton4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable[] results = cam.AllocatePersonsToCamps("2023");
            dataGridView4.DataSource = cam.swapRows(results[0]);



            // DataTable[] results = cam.AllocatePersonsToCamps("2023");
            DataTable wdsc = hajj.get_all_data();
            //DataTable[] results = new DataTable[wdsc.Rows.Count];
            results[0] = wdsc;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Save Excel File";
                saveFileDialog.ShowDialog();

                if (!string.IsNullOrWhiteSpace(saveFileDialog.FileName))
                {
                    string filePath = saveFileDialog.FileName;
                    // Set the license context to NonCommercial

                    using (ExcelPackage excelPackage = new ExcelPackage())
                    {
                        // Iterate over each DataTable in the results array
                        for (int i = 0; i < results.Length; i++)
                        {
                            DataTable dataTable = results[i];

                            if (dataTable != null)
                            {
                                // Create a new worksheet for the DataTable
                                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add($"Sheet{i + 1}");
                                // Populate the worksheet with the DataTable data
                                worksheet.Cells["A1"].LoadFromDataTable(dataTable, true);
                            }
                        }

                        // Save the Excel package to the specified file path
                        excelPackage.SaveAs(new FileInfo(filePath));
                        MessageBox.Show("Data exported successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            try
            {
                //// Create a new Excel application
                //Excel.Application excelApp = new Excel.Application();
                //excelApp.Visible = true;

                //// Create a new workbook
                //Excel.Workbook workbook = excelApp.Workbooks.Add();

                //// Get the first worksheet in the workbook
                //Excel.Worksheet worksheet = workbook.Sheets[1];

                //// Set the column headers
                //for (int i = 0; i < dataGridView4.Columns.Count; i++)
                //{
                //    worksheet.Cells[1, i + 1] = dataGridView4.Columns[i].HeaderText;
                //}

                //// Set the row values
                //for (int i = 0; i < dataGridView4.Rows.Count; i++)
                //{
                //    for (int j = 0; j < dataGridView4.Columns.Count; j++)
                //    {
                //        worksheet.Cells[i + 2, j + 1] = dataGridView4.Rows[i].Cells[j].Value.ToString();
                //    }
                //}

                //// Save the workbook
                //workbook.SaveAs("C:\\Users\\OverLord\\Desktop\\File.xlsx");

                //// Clean up resources
                //workbook.Close();
                //excelApp.Quit();

                //MessageBox.Show("Data exported successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //DataTable sds = cam.camp_from_bus("2023");
            //dataGridView4.DataSource = sds;
            //MessageBox.Show(sds.Rows.Count.ToString());
        }

        private void materialButton3_Click_1(object sender, EventArgs e)
        {

        }
    }
}


