using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTable = System.Data.DataTable;

namespace WinFormsApp1.b
{
    internal class camp : z
    {
        private int _camp_id;
        private string _camp_bed_num;
        private string _yea;
        private string _sao1;//male or female
        private string _sao2;//beds ava
        private string _sao3;

        #region Properties
        public int camp_id
        {
            get { return _camp_id; }
            set { _camp_id = value; }
        }

        public string camp_bed_num
        {
            get { return _camp_bed_num; }
            set { _camp_bed_num = value; }
        }

        public string yea
        {
            get { return _yea; }
            set { _yea = value; }
        }

        public string sao1
        {
            get { return _sao1; }
            set { _sao1 = value; }
        }

        public string sao2
        {
            get { return _sao2; }
            set { _sao2 = value; }
        }

        public string sao3
        {
            get { return _sao3; }
            set { _sao3 = value; }
        }
        #endregion

        protected override bool lsl(char op)
        {
            SortedList SL = new SortedList();
            SL.Add("Check", op);
            SL.Add("camp_id", camp_id);
            SL.Add("camp_bed_num", camp_bed_num);
            SL.Add("yea", yea);
            SL.Add("sao1", sao1);
            SL.Add("sao2", sao2);
            SL.Add("sao3", sao3);

            if (DB.RunProcrduer("Pro_camp", SL) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string add_camp( string camp_bed_num, string yea, string sao1, string sao2, string sao3)
        {
            this.camp_id = 0;
            this.camp_bed_num = camp_bed_num;
            this.yea = yea;
            this.sao1 = sao1;
            this.sao2 = sao2;
            this.sao3 = sao3;

            if (a())
            {
                return "T";
            }
            else
            {
                return "F";
            }
        }
        public string update_camp(int camp_id, string camp_bed_num, string yea, string sao1, string sao2, string sao3)
        {
            this.camp_id = camp_id;
            this.camp_bed_num = camp_bed_num;
            this.yea = yea;
            this.sao1 = sao1;
            this.sao2 = sao2;
            this.sao3 = sao3;

            if (u())
            {
                return "T";
            }
            else
            {
                return "F";
            }
        }
        public bool del_camp(int camp_id)
        {
            this.camp_id = camp_id;
            return q();
        }
        public DataTable[] AllocatePersonsToCamps(string yea)
        {
            DataTable[] results = null;
            #region MyRegion
            //مخيمات النساء
            string cam_f = "select * From camp where yea ='" + yea + "' and sao1 ='f'";
            DataTable campp_f = ss(cam_f);

            //مخيمات الكل
            string cam_al = "select * From camp where yea ='" + yea + "'";
            DataTable cam_all = ss(cam_al);



            //مخيمات بيانات الحافلات الاسم والرقم
            string buuss = "select * From buus where year ='" + yea + "'";
            DataTable buss = ss(buuss);

            //مخيمات الرجال
            string cam_m = "select * From camp where yea ='" + yea + "' and sao1 ='m'";
            DataTable campp_m = ss(cam_m);

            #region MyRegion
            // لتسجيل الرجال مع بعض 
            DataTable hajjj_buss_by_id_m = new DataTable();
            hajjj_buss_by_id_m.Columns.Add("haj_id");
            hajjj_buss_by_id_m.Columns.Add("haj_name");
            hajjj_buss_by_id_m.Columns.Add("camp_id");
            hajjj_buss_by_id_m.Columns.Add("camp_bed_num");
            hajjj_buss_by_id_m.Columns.Add("bed_id");
            hajjj_buss_by_id_m.Columns.Add("bed_num");
            hajjj_buss_by_id_m.Columns.Add("res_num");
            hajjj_buss_by_id_m.Columns.Add("phone");
            hajjj_buss_by_id_m.Columns.Add("city");
            hajjj_buss_by_id_m.Columns.Add("nationality");
            hajjj_buss_by_id_m.Columns.Add("bus_id");
            hajjj_buss_by_id_m.Columns.Add("bus_name");

            // لتسجيل النساء مع بعض 
            DataTable hajjj_buss_by_id_f = hajjj_buss_by_id_m.Clone();
            #endregion
            //فصل الرجال والنساء الى جدولين
            for (int i = 0; i < buss.Rows.Count; i++)
            {
                string haj_buss = "select * From haj_bus where bus_id ='" + Convert.ToInt32(buss.Rows[i][0].ToString()) + "'";
                DataTable hajjj_buss_by_id = ss(haj_buss);
                DataRow dr = null;
                foreach (DataRow row in hajjj_buss_by_id.Rows)
                {
                    int ac = Convert.ToInt32(row["haj_id"]);
                    string query = "select * From haj where haj_id ='" + Convert.ToInt32(row["haj_id"]) + "'";
                    DataTable search = ss(query);
                    //if haj
                    if (search.Rows.Count > 0 && ac != -1)
                    {
                        string sdv = search.Rows[0][6].ToString();
                        if (search.Rows[0][6].ToString() == "ذكر" || search.Rows[0][6].ToString() == "male"
                            || search.Rows[0][6].ToString() == "رجل" || search.Rows[0][6].ToString() == "m")
                        {
                            dr = hajjj_buss_by_id_m.NewRow();
                            dr["haj_id"] = search.Rows[0]["haj_id"].ToString();
                            dr["haj_name"] = search.Rows[0]["first_n"].ToString();
                            dr["camp_id"] = "";
                            dr["camp_bed_num"] = "";
                            dr["bed_id"] = "";
                            dr["bed_num"] = "";
                            dr["res_num"] = search.Rows[0]["res_num"].ToString(); ;
                            dr["phone"] = search.Rows[0]["phone"].ToString();
                            dr["city"] = search.Rows[0]["city"].ToString();
                            dr["nationality"] = search.Rows[0]["nationality"].ToString();
                            dr["bus_id"] = buss.Rows[i]["bus_id"].ToString();
                            dr["bus_name"] = buss.Rows[i]["bus_num"].ToString();
                            hajjj_buss_by_id_m.Rows.Add(dr);
                        }
                        else
                        {
                            dr = hajjj_buss_by_id_f.NewRow();
                            dr["haj_id"] = search.Rows[0]["haj_id"].ToString();
                            dr["haj_name"] = search.Rows[0]["first_n"].ToString();
                            dr["camp_id"] = "";
                            dr["camp_bed_num"] = "";
                            dr["bed_id"] = "";
                            dr["bed_num"] = "";
                            dr["res_num"] = search.Rows[0]["res_num"].ToString(); ;
                            dr["phone"] = search.Rows[0]["phone"].ToString();
                            dr["city"] = search.Rows[0]["city"].ToString();
                            dr["nationality"] = search.Rows[0]["nationality"].ToString();
                            dr["bus_id"] = buss.Rows[i]["bus_id"].ToString();
                            dr["bus_name"] = buss.Rows[i]["bus_num"].ToString();
                            hajjj_buss_by_id_f.Rows.Add(dr);
                        }
                    }
                    //if suv and mof
                    else if (false/*ac == -1*/)
                    {
                        string dsv = row["sao2"].ToString();
                        if (row["sao2"].ToString() == "ذكر" || row["sao2"].ToString() == "male" || row["sao2"].ToString() == "رجل" || row["sao2"].ToString() == "m")
                        {
                            dr = hajjj_buss_by_id_m.NewRow();
                            dr["haj_id"] = row["sao3"].ToString();
                            dr["haj_name"] = row["sao1"].ToString();
                            dr["camp_id"] = "";
                            dr["camp_bed_num"] = "";
                            dr["bed_id"] = "";
                            dr["bed_num"] = "";
                            dr["res_num"] = "";
                            dr["phone"] = "";
                            dr["city"] = "";
                            dr["nationality"] = "";
                            dr["bus_id"] = buss.Rows[i]["bus_id"].ToString();
                            dr["bus_name"] = buss.Rows[i]["bus_num"].ToString();
                            hajjj_buss_by_id_m.Rows.Add(dr);
                        }
                        else
                        {
                            dr = hajjj_buss_by_id_f.NewRow();
                            dr["haj_id"] = row["sao3"].ToString();
                            dr["haj_name"] = row["sao1"].ToString();
                            dr["camp_id"] = "";
                            dr["camp_bed_num"] = "";
                            dr["bed_id"] = "";
                            dr["bed_num"] = "";
                            dr["res_num"] = "";
                            dr["phone"] = "";
                            dr["city"] = "";
                            dr["nationality"] = "";
                            dr["bus_id"] = buss.Rows[i]["bus_id"].ToString();
                            dr["bus_name"] = buss.Rows[i]["bus_num"].ToString();
                            hajjj_buss_by_id_f.Rows.Add(dr);
                        }
                    }
                }
            }
            #endregion


            //v1
            if (results == null)
            {
                results = new DataTable[1];
                results[0] = taskeen_bus_res(campp_m, hajjj_buss_by_id_m);
                results[0] = swapRows(results[0]);
            }
            else
            {
                // If results is not null, resize the array to accommodate the new DataTable
                Array.Resize(ref results, results.Length + 1);
                results[results.Length - 1] = taskeen_bus_res(campp_m, hajjj_buss_by_id_m);
                results[results.Length - 1] = swapRows(results[results.Length - 1]);
            }


            if (results == null)
            {
                results = new DataTable[1];
                results[0] = taskeen_bus_res(campp_f, hajjj_buss_by_id_f);
               // results[0] = swapRows(results[0]);
            }
            else
            {
                // If results is not null, resize the array to accommodate the new DataTable
                Array.Resize(ref results, results.Length + 1);
                results[results.Length - 1] = taskeen_bus_res(campp_f, hajjj_buss_by_id_f);
               // results[results.Length - 1] = swapRows(results[results.Length - 1]);
            }



            //v2
            if (results == null)
            {
                results = new DataTable[1];
                results[0] = taskeen_bus_phone(campp_m, hajjj_buss_by_id_m);
               // results[0] = swapRows(results[0]);
            }
            else
            {
                // If results is not null, resize the array to accommodate the new DataTable
                Array.Resize(ref results, results.Length + 1);
                results[results.Length - 1] = taskeen_bus_phone(campp_m, hajjj_buss_by_id_m);
                //results[results.Length - 1] = swapRows(results[results.Length - 1]);
            }

            if (results == null)
            {
                results = new DataTable[1];
                results[0] = taskeen_bus_phone(campp_f, hajjj_buss_by_id_f);
                //results[0] = swapRows(results[0]);
            }
            else
            {
                // If results is not null, resize the array to accommodate the new DataTable
                Array.Resize(ref results, results.Length + 1);
                results[results.Length - 1] = taskeen_bus_phone(campp_f, hajjj_buss_by_id_f);
                //results[results.Length - 1] = swapRows(results[results.Length - 1]);
            }
            return results;// RearrangeRows(outputTable);
            #region MyRegion

            //// لتسجيل الرجال في الخيام 
            //DataTable[] campp_m_Tables = new DataTable[campp_m.Rows.Count];
            //for (int i = 0; i < campp_m_Tables.Length; i++)
            //{
            //    DataTable dataTable = new DataTable();
            //    dataTable = hajjj_buss_by_id_m.Clone();

            //    DataRow dr = dataTable.NewRow();
            //    dr["haj_id"] = "";
            //    dr["haj_name"] = "";
            //    dr["camp_id"] = "";
            //    dr["camp_num"] = "";
            //    dr["bed_id"] = "";
            //    dr["bed_num"] = "";
            //    dr["res_num"] = "";
            //    dr["phone"] = "";
            //    dr["city"] = "";
            //    dr["nationality"] = "";
            //    dr["bus_id"] = buss.Rows[i]["bus_id"].ToString();
            //    dr["bus_name"] = buss.Rows[i]["bus_num"].ToString();
            //    dataTable.Rows.Add(dr);



            //    campp_m_Tables[i] = dataTable;
            //}





            //// Sort the buses based on the number of males and females
            //List<DataRow> sortedBuses = buss.AsEnumerable()
            //    .OrderBy(bus => Convert.ToInt32(bus["Males"]) + Convert.ToInt32(bus["Females"]))
            //    .ToList();

            //// Iterate over the sorted buses and assign them to camps
            //foreach (DataRow bus in sortedBuses)
            //{
            //    int busMales = Convert.ToInt32(bus["Males"]);
            //    int busFemales = Convert.ToInt32(bus["Females"]);

            //    foreach (DataRow camp in cam_all.Rows)
            //    {
            //        int campBeds = Convert.ToInt32(camp["Beds"]);
            //        string campGender = camp["Gender"].ToString();

            //        if ((campGender == "Males" && busFemales == 0) ||
            //            (campGender == "Females" && busMales == 0) ||
            //            (campGender == "Both" && busMales > 0 && busFemales > 0))
            //        {
            //            if (campBeds > 0)
            //            {
            //                // Assign the bus to the camp and decrease the available bed count
            //                bus["Camp"] = camp["CampName"];
            //                camp["Beds"] = campBeds - 1;
            //                break;
            //            }
            //        }
            //    }
            //}

            #endregion
            //return hajjj_buss_by_id_m;
        }
        public DataTable swapRows(DataTable inputTable)
        {
            if (!inputTable.Columns.Contains("isChecked"))
            {
                inputTable.Columns.Add("isChecked", typeof(string));
            }

            if (!inputTable.Columns.Contains("caount"))
            {
                inputTable.Columns.Add("caount", typeof(int));
            }
            foreach (DataRow row in inputTable.Rows)
            {
                string resNum = row["res_num"].ToString();
                string phone = row["phone"].ToString();
                string campId = row.Field<string>("camp_id");

                // Check if any other rows have the same res_num or phone
                bool hasDuplicate = inputTable.AsEnumerable().Any(r =>
                    r.Field<string>("res_num") == resNum && r != row ||
                    r.Field<string>("phone") == phone && r != row);

                // Count the number of rows with the same res_num or phone but different camp_id
                int rowCount = inputTable.AsEnumerable().Count(r =>
                    r.Field<string>("res_num") == resNum && r.Field<string>("camp_id") != campId ||
                    r.Field<string>("phone") == phone && r.Field<string>("camp_id") != campId);



                // Set the "isChecked" column value based on the result
                row["isChecked"] = hasDuplicate ? "has" : "alone";
                
                // Set the "count" column value
                row["caount"] = rowCount;
            }

            return inputTable;
        }
        public DataTable taskeen_bus_res(DataTable campp_m, DataTable hajjj_buss_by_id_m)
        {
            
            // Create a new column to store the converted bus_id values as integers
            hajjj_buss_by_id_m.Columns.Add("bus_id_int", typeof(int));

            // Convert the bus_id values to integers and store them in the new column
            foreach (DataRow row in hajjj_buss_by_id_m.Rows)
            {
                row["bus_id_int"] = Convert.ToInt32(row["bus_id"]);
            }

            // Create a new datatable to store the output
            DataTable hajjj_buss_by_id_m_v_1 = hajjj_buss_by_id_m.Clone();

            // Sort the datatable by bus_id_int so that persons with the same bus_id are grouped together
            // Add "res_num ASC" to sort by res_num after sorting by bus_id_int
            DataView sortedView = hajjj_buss_by_id_m.DefaultView;
            sortedView.Sort = "bus_id_int ASC, res_num ASC";
            DataTable sortedTable = sortedView.ToTable();

            // Remove the temporary column
            hajjj_buss_by_id_m.Columns.Remove("bus_id_int");

            int personCount = sortedTable.Rows.Count;
            int campCount = campp_m.Rows.Count;

            // Initialize the camp index and beds available in each camp
            int[] availableBeds = new int[campCount];
            for (int i = 0; i < campCount; i++)
            {
                availableBeds[i] = Convert.ToInt32(campp_m.Rows[i]["sao2"]);
            }

            // Initialize the camp index for each bus_id
            Dictionary<int, int> busCampMapping = new Dictionary<int, int>();

            // Initialize the current camp index
            int currentCampIndex = 0;

            // Iterate through each person in the sorted table
            for (int i = 0; i < personCount; i++)
            {
                DataRow row = sortedTable.Rows[i];
                int busId = Convert.ToInt32(row["bus_id"]);

                // Check if the bus_id has been assigned a camp
                if (busCampMapping.ContainsKey(busId))
                {
                    // Assign the person to the existing camp
                    int campIndex = busCampMapping[busId];
                    row["camp_id"] = Convert.ToInt32(campp_m.Rows[campIndex]["camp_bed_num"]);

                    // Check if there are beds available in the current camp
                    if (availableBeds[campIndex] > 0)
                    {
                        int bedId = Convert.ToInt32(campp_m.Rows[campIndex]["sao2"]) - availableBeds[campIndex] + 1;
                        row["bed_id"] = bedId;
                        availableBeds[campIndex]--;
                    }
                    else
                    {
                        // No beds available in the current camp, find the next camp with available beds
                        int nextCampIndex = (campIndex + 1) % campCount;
                        while (nextCampIndex != campIndex)
                        {
                            if (availableBeds[nextCampIndex] > 0)
                            {
                                row["camp_id"] = Convert.ToInt32(campp_m.Rows[nextCampIndex]["camp_bed_num"]);
                                int bedId = Convert.ToInt32(campp_m.Rows[nextCampIndex]["sao2"]) - availableBeds[nextCampIndex] + 1;
                                row["bed_id"] = bedId;
                                availableBeds[nextCampIndex]--;
                                break;
                            }
                            nextCampIndex = (nextCampIndex + 1) % campCount;
                        }
                    }
                }
                else
                {
                    // Assign the person to the first available camp
                    for (int j = 0; j < campCount; j++)
                    {
                        if (availableBeds[j] > 0)
                        {
                            row["camp_id"] = Convert.ToInt32(campp_m.Rows[j]["camp_bed_num"]);
                            int sac = Convert.ToInt32(campp_m.Rows[j]["sao2"]);
                            int sacsd = availableBeds[j];
                            int bedId = sac - sacsd + 1;
                            row["bed_id"] = bedId;
                            availableBeds[j]--;
                            busCampMapping.Add(busId, j);
                            break;
                        }
                    }
                }

                // Update the current camp index
                if (busCampMapping.ContainsKey(busId))
                {
                    currentCampIndex = busCampMapping[busId];
                }
                else
                {
                    // Handle the case when the busId is not present in the dictionary
                    // You can assign a default value or handle the error in a way that fits your scenario
                    // For example:
                    currentCampIndex = -1; // Assign a default value of -1
                                           // Or throw an exception:
                                           //throw new Exception("BusId not found in busCampMapping dictionary");
                }

                // Add the row to the output table
                hajjj_buss_by_id_m_v_1.ImportRow(row);
                #region MyRegion
                //// Find the records with the same res_num and insert them after the current person
                //string resNum = row["res_num"].ToString();
                //string currentCampId;
                //if (int.TryParse(row["camp_id"].ToString(), out int campId))
                //{
                //    currentCampId = campId.ToString();
                //}
                //else
                //{
                //    // Handle the case when the value cannot be parsed as an integer
                //    // You can assign a default value or handle the error in a way that fits your scenario
                //    currentCampId = "DefaultCampId";
                //}
                //DataRow[] sameResNumRows = sortedTable.Select("res_num = '" + resNum + "' AND camp_id <> '" + currentCampId + "'");
                //DataTable search_temp = sortedTable.Clone();

                //foreach (DataRow sameResNumRow in sameResNumRows)
                //{
                //    // Check if the row already exists in search_temp
                //    DataRow[] existingRows = search_temp.Select("res_num = '" + sameResNumRow["res_num"] + "' AND phone = '" + sameResNumRow["phone"] + "'");
                //    if (existingRows.Length == 0)
                //    {
                //        search_temp.ImportRow(sameResNumRow);
                //    }
                //}

                //// Find the records with the same phone and insert them after the current person
                //string phone = row["phone"].ToString();
                //DataRow[] samePhoneRows = sortedTable.Select("phone = '" + phone + "' AND camp_id <> '" + currentCampId + "'");

                //foreach (DataRow samePhoneRow in samePhoneRows)
                //{
                //    // Check if the row already exists in search_temp
                //    DataRow[] existingRows = search_temp.Select("res_num = '" + samePhoneRow["res_num"] + "' AND phone = '" + samePhoneRow["phone"] + "'");
                //    if (existingRows.Length == 0)
                //    {
                //        search_temp.ImportRow(samePhoneRow);
                //    }
                //}
                #endregion
            }
            return hajjj_buss_by_id_m_v_1;
        }

        public DataTable taskeen_bus_phone(DataTable campp_m, DataTable hajjj_buss_by_id_m)
        {

            // Create a new column to store the converted bus_id values as integers
            //hajjj_buss_by_id_m.Columns.Add("bus_id_int", typeof(int));

            //string ds = "";
            //foreach (DataColumn Column in hajjj_buss_by_id_m.Columns)
            //{
            //    ds = ds + " /// " + Column.ColumnName;
            //}
            //int asas = hajjj_buss_by_id_m.Rows.Count;
            //// Convert the bus_id values to integers and store them in the new column
            //foreach (DataRow row in hajjj_buss_by_id_m.Rows)
            //{
            //    int asd = Convert.ToInt32(row["bus_id"]);
            //    string sdv = row["bus_id_int"].ToString();

            //    if (row.IsNull("bus_id_int"))
            //    {
            //        row["bus_id_int"] = asd;
            //        sdv = row["bus_id_int"].ToString();
            //    }
            //}

            // Create a new datatable to store the output
            DataTable hajjj_buss_by_id_m_v_1 = hajjj_buss_by_id_m.Clone();

            // Sort the datatable by bus_id_int so that persons with the same bus_id are grouped together
            // Add "res_num ASC" to sort by res_num after sorting by bus_id_int
            //DataView sortedView = hajjj_buss_by_id_m.DefaultView;
            //sortedView.Sort = "bus_id ASC, phone ASC";
            //DataTable sortedTable = sortedView.ToTable();

            // Add a new calculated column with the sorted "bus_id" values as integers
            DataColumn busIdIntColumn = new DataColumn("bus_id_int", typeof(int));
            busIdIntColumn.Expression = "CONVERT(bus_id, 'System.Int32')";
            hajjj_buss_by_id_m.Columns.Add(busIdIntColumn);

            // Create a DataView based on the DataTable
            DataView sortedView = new DataView(hajjj_buss_by_id_m);

            // Sort the DataView by the "bus_id_int" and "phone" columns
            sortedView.Sort = "bus_id_int ASC, phone ASC";

            // Create a new DataTable with the sorted data
            DataTable sortedTable = sortedView.ToTable();


            // Remove the temporary column
            //hajjj_buss_by_id_m.Columns.Remove("bus_id");

            int personCount = sortedTable.Rows.Count;
            int campCount = campp_m.Rows.Count;

            // Initialize the camp index and beds available in each camp
            int[] availableBeds = new int[campCount];
            for (int i = 0; i < campCount; i++)
            {
                availableBeds[i] = Convert.ToInt32(campp_m.Rows[i]["sao2"]);
            }

            // Initialize the camp index for each bus_id
            Dictionary<int, int> busCampMapping = new Dictionary<int, int>();

            // Initialize the current camp index
            int currentCampIndex = 0;

            // Iterate through each person in the sorted table
            for (int i = 0; i < personCount; i++)
            {
                DataRow row = sortedTable.Rows[i];
                int busId = Convert.ToInt32(row["bus_id"]);

                // Check if the bus_id has been assigned a camp
                if (busCampMapping.ContainsKey(busId))
                {
                    // Assign the person to the existing camp
                    int campIndex = busCampMapping[busId];
                    row["camp_id"] = Convert.ToInt32(campp_m.Rows[campIndex]["camp_id"]);  //id
                    row["camp_bed_num"] = Convert.ToInt32(campp_m.Rows[campIndex]["camp_bed_num"]); //name
                    row["bed_num"] = campp_m.Rows[campIndex]["sao2"]; // count
                    // Check if there are beds available in the current camp
                    if (availableBeds[campIndex] > 0)
                    {
                        int bedId = Convert.ToInt32(campp_m.Rows[campIndex]["sao2"]) - availableBeds[campIndex] + 1;
                        row["bed_id"] = bedId;
                        availableBeds[campIndex]--;
                    }
                    else
                    {
                        // No beds available in the current camp, find the next camp with available beds
                        int nextCampIndex = (campIndex + 1) % campCount;
                        while (nextCampIndex != campIndex)
                        {
                            if (availableBeds[nextCampIndex] > 0)
                            {
                                row["camp_id"] = Convert.ToInt32(campp_m.Rows[nextCampIndex]["camp_id"]);
                                row["camp_bed_num"] = Convert.ToInt32(campp_m.Rows[nextCampIndex]["camp_bed_num"]);
                                row["bed_num"] = campp_m.Rows[campIndex]["sao2"];
                                int bedId = Convert.ToInt32(campp_m.Rows[nextCampIndex]["sao2"]) - availableBeds[nextCampIndex] + 1;
                                row["bed_id"] = bedId;
                                availableBeds[nextCampIndex]--;
                                break;
                            }
                            nextCampIndex = (nextCampIndex + 1) % campCount;
                        }
                    }
                }
                else
                {
                    // Assign the person to the first available camp
                    for (int j = 0; j < campCount; j++)
                    {
                        if (availableBeds[j] > 0)
                        {
                            row["camp_bed_num"] = campp_m.Rows[j]["camp_bed_num"];
                            row["bed_num"] = campp_m.Rows[j]["sao2"];
                            row["camp_id"] = Convert.ToInt32(campp_m.Rows[j]["camp_id"]);
                            int sac = Convert.ToInt32(campp_m.Rows[j]["sao2"]);
                            int sacsd = availableBeds[j];
                            int bedId = sac - sacsd + 1;
                            row["bed_id"] = bedId;
                            availableBeds[j]--;
                            busCampMapping.Add(busId, j);
                            break;
                        }
                    }
                }

                // Update the current camp index
                if (busCampMapping.ContainsKey(busId))
                {
                    currentCampIndex = busCampMapping[busId];
                }
                else
                {
                    // Handle the case when the busId is not present in the dictionary
                    // You can assign a default value or handle the error in a way that fits your scenario
                    // For example:
                    currentCampIndex = -1; // Assign a default value of -1
                                           // Or throw an exception:
                                           //throw new Exception("BusId not found in busCampMapping dictionary");
                }

                // Add the row to the output table
                hajjj_buss_by_id_m_v_1.ImportRow(row);
                #region MyRegion
                //// Find the records with the same res_num and insert them after the current person
                //string resNum = row["res_num"].ToString();
                //string currentCampId;
                //if (int.TryParse(row["camp_id"].ToString(), out int campId))
                //{
                //    currentCampId = campId.ToString();
                //}
                //else
                //{
                //    // Handle the case when the value cannot be parsed as an integer
                //    // You can assign a default value or handle the error in a way that fits your scenario
                //    currentCampId = "DefaultCampId";
                //}
                //DataRow[] sameResNumRows = sortedTable.Select("res_num = '" + resNum + "' AND camp_id <> '" + currentCampId + "'");
                //DataTable search_temp = sortedTable.Clone();

                //foreach (DataRow sameResNumRow in sameResNumRows)
                //{
                //    // Check if the row already exists in search_temp
                //    DataRow[] existingRows = search_temp.Select("res_num = '" + sameResNumRow["res_num"] + "' AND phone = '" + sameResNumRow["phone"] + "'");
                //    if (existingRows.Length == 0)
                //    {
                //        search_temp.ImportRow(sameResNumRow);
                //    }
                //}

                //// Find the records with the same phone and insert them after the current person
                //string phone = row["phone"].ToString();
                //DataRow[] samePhoneRows = sortedTable.Select("phone = '" + phone + "' AND camp_id <> '" + currentCampId + "'");

                //foreach (DataRow samePhoneRow in samePhoneRows)
                //{
                //    // Check if the row already exists in search_temp
                //    DataRow[] existingRows = search_temp.Select("res_num = '" + samePhoneRow["res_num"] + "' AND phone = '" + samePhoneRow["phone"] + "'");
                //    if (existingRows.Length == 0)
                //    {
                //        search_temp.ImportRow(samePhoneRow);
                //    }
                //}
                #endregion
            }
            return hajjj_buss_by_id_m_v_1;
        }
        public DataTable RearrangeRows(DataTable inputTable)
        {
            DataTable outputTable = inputTable.Clone();
            outputTable.Columns.Add("isChecked", typeof(bool));
            inputTable.Columns.Add("isChecked", typeof(bool));
            foreach (DataRow inputRow in inputTable.Rows)
            {
                string currentResNum = inputRow.Field<string>("res_num");
                string currentPhone = inputRow.Field<string>("phone");
                int currentCampId = Convert.ToInt32(inputRow.Field<string>("camp_id"));

                bool hasOtherMatches = inputTable.AsEnumerable()
                    .Any(row => (row.Field<string>("res_num") == currentResNum || row.Field<string>("phone") == currentPhone) && row != inputRow);

                inputRow.SetField("isChecked", !hasOtherMatches);

                if (!hasOtherMatches && inputRow.Field<bool>("isChecked"))
                {
                    if (currentCampId != Convert.ToInt32(inputTable.Rows[0].Field<string>("camp_id")))
                    {
                        DataRow swapRow = outputTable.Select("camp_id = " + currentCampId.ToString() + " AND isChecked = true").FirstOrDefault();
                        if (swapRow != null)
                        {
                            DataRow newRow = outputTable.NewRow();
                            newRow.ItemArray = inputRow.ItemArray;
                            outputTable.Rows.Add(newRow);

                            swapRow.SetField("isChecked", false);
                        }
                        else
                        {
                            DataRow newRow = outputTable.NewRow();
                            newRow.ItemArray = inputRow.ItemArray;
                            outputTable.Rows.Add(newRow);
                        }
                    }
                    else
                    {
                        DataRow newRow = outputTable.NewRow();
                        newRow.ItemArray = inputRow.ItemArray;
                        outputTable.Rows.Add(newRow);
                    }
                }
            }
            return outputTable;
        }


    }
}
