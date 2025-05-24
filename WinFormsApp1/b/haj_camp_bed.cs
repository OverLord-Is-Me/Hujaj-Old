using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.b
{
    internal class haj_camp_bed : z
    {
        private int _haj_camp_bed_id;
        private int _haj_id;
        private string _haj_name;
        private int _camp_id;
        private string _camp_num;
        private int _bed_id;
        private string _bed_num;
        private string _sao1;
        private string _sao2;
        private string _sao3;
        #region Properties
        public int haj_camp_bed_id
        {
            get { return _haj_camp_bed_id; }
            set { _haj_camp_bed_id = value; }
        }

        public int haj_id
        {
            get { return _haj_id; }
            set { _haj_id = value; }
        }

        public string haj_name
        {
            get { return _haj_name; }
            set { _haj_name = value; }
        }

        public int camp_id
        {
            get { return _camp_id; }
            set { _camp_id = value; }
        }

        public string camp_num
        {
            get { return _camp_num; }
            set { _camp_num = value; }
        }

        public int bed_id
        {
            get { return _bed_id; }
            set { _bed_id = value; }
        }

        public string bed_num
        {
            get { return _bed_num; }
            set { _bed_num = value; }
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
            SL.Add("haj_camp_bed_id", haj_camp_bed_id);
            SL.Add("haj_id", haj_id);
            SL.Add("haj_name", haj_name);
            SL.Add("camp_id", camp_id);
            SL.Add("camp_num", camp_num);
            SL.Add("bed_id", bed_id);
            SL.Add("bed_num", bed_num);
            SL.Add("sao1", sao1);
            SL.Add("sao2", sao2);
            SL.Add("sao3", sao3);
            if (DB.RunProcrduer("Pro_haj_camp_bed", SL) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string add_hajcampbed( int haj_id, string haj_name, int camp_id,
                            string camp_num, int bed_id, string bed_num, string sao1, string sao2, string sao3)
        {
            this.haj_camp_bed_id = 0;
            this.haj_id = haj_id;
            this.haj_name = haj_name;
            this.camp_id = camp_id;
            this.camp_num = camp_num;
            this.bed_id = bed_id;
            this.bed_num = bed_num;
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
        public string update_hajcampbed(int haj_camp_bed_id, int haj_id, string haj_name, int camp_id,
                                       string camp_num, int bed_id, string bed_num, string sao1, string sao2, string sao3)
        {
            this.haj_camp_bed_id = haj_camp_bed_id;
            this.haj_id = haj_id;
            this.haj_name = haj_name;
            this.camp_id = camp_id;
            this.camp_num = camp_num;
            this.bed_id = bed_id;
            this.bed_num = bed_num;
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
        public bool del_hajcampbed(int haj_camp_bed_id)
        {
            this.haj_camp_bed_id = haj_camp_bed_id;
            return q();
        }
        public DataTable AssignBeds()
        {
            DataTable campsBeds = new DataTable("camps_beds");
            campsBeds.Columns.Add("passenger_id", typeof(int));
            campsBeds.Columns.Add("camp_id", typeof(int));
            campsBeds.Columns.Add("bed_id", typeof(int));


            string query = "select * From haj where gender = 'ذكر'";
            DataTable passengers = ss(query);

            string yea = "2023";
            string buuss = "select * From buus where year ='" + yea + "'";
            DataTable buses = ss(buuss);

            //مخيمات الرجال
            string cam_m = "select * From camp where yea ='" + yea + "' and sao1 ='m'";
            DataTable camps = ss(cam_m);

            // لتسجيل الرجال والنساء مع بعض 
            #region MyRegion
            // لتسجيل الرجال مع بعض 
            DataTable busPassengers = new DataTable();
            busPassengers.Columns.Add("haj_id");
            busPassengers.Columns.Add("haj_name");
            busPassengers.Columns.Add("camp_id");
            busPassengers.Columns.Add("camp_num");
            busPassengers.Columns.Add("bed_id");
            busPassengers.Columns.Add("bed_num");
            busPassengers.Columns.Add("res_num");
            busPassengers.Columns.Add("phone");
            busPassengers.Columns.Add("city");
            busPassengers.Columns.Add("nationality");
            busPassengers.Columns.Add("bus_id");
            busPassengers.Columns.Add("bus_name");

            // لتسجيل النساء مع بعض 
            DataTable hajjj_buss_by_id_f = busPassengers.Clone();
            #endregion
            //فصل الرجال والنساء الى جدولين
            for (int i = 0; i < buses.Rows.Count; i++)
            {
                string haj_buss = "select * From haj_bus where bus_id ='" + Convert.ToInt32(buses.Rows[i][0].ToString()) + "'";
                DataTable hajjj_buss_by_id = ss(haj_buss);
                DataRow dr = null;
                foreach (DataRow row in hajjj_buss_by_id.Rows)
                {
                    int ac = Convert.ToInt32(row["haj_id"]);
                    string query2 = "select * From haj where haj_id ='" + Convert.ToInt32(row["haj_id"]) + "'";
                    DataTable search = ss(query2);
                    //if haj
                    if (search.Rows.Count > 0 && ac != -1)
                    {
                        string sdv = search.Rows[0][6].ToString();
                        if (search.Rows[0][6].ToString() == "ذكر" || search.Rows[0][6].ToString() == "male"
                            || search.Rows[0][6].ToString() == "رجل" || search.Rows[0][6].ToString() == "m")
                        {
                            dr = busPassengers.NewRow();
                            dr["haj_id"] = search.Rows[0]["haj_id"].ToString();
                            dr["haj_name"] = search.Rows[0]["first_n"].ToString();
                            dr["camp_id"] = "";
                            dr["camp_num"] = "";
                            dr["bed_id"] = "";
                            dr["bed_num"] = "";
                            dr["res_num"] = search.Rows[0]["res_num"].ToString(); ;
                            dr["phone"] = search.Rows[0]["phone"].ToString();
                            dr["city"] = search.Rows[0]["city"].ToString();
                            dr["nationality"] = search.Rows[0]["nationality"].ToString();
                            dr["bus_id"] = buses.Rows[i]["bus_id"].ToString();
                            dr["bus_name"] = buses.Rows[i]["bus_num"].ToString();
                            busPassengers.Rows.Add(dr);
                        }
                        else
                        {
                            dr = hajjj_buss_by_id_f.NewRow();
                            dr["haj_id"] = search.Rows[0]["haj_id"].ToString();
                            dr["haj_name"] = search.Rows[0]["first_n"].ToString();
                            dr["camp_id"] = "";
                            dr["camp_num"] = "";
                            dr["bed_id"] = "";
                            dr["bed_num"] = "";
                            dr["res_num"] = search.Rows[0]["res_num"].ToString(); ;
                            dr["phone"] = search.Rows[0]["phone"].ToString();
                            dr["city"] = search.Rows[0]["city"].ToString();
                            dr["nationality"] = search.Rows[0]["nationality"].ToString();
                            dr["bus_id"] = buses.Rows[i]["bus_id"].ToString();
                            dr["bus_name"] = buses.Rows[i]["bus_num"].ToString();
                            hajjj_buss_by_id_f.Rows.Add(dr);
                        }
                    }
                    //if suv and mof
                    else if (false/*ac == -1*/)
                    {
                        string dsv = row["sao2"].ToString();
                        if (row["sao2"].ToString() == "ذكر" || row["sao2"].ToString() == "male" || row["sao2"].ToString() == "رجل" || row["sao2"].ToString() == "m")
                        {
                            dr = busPassengers.NewRow();
                            dr["haj_id"] = row["sao3"].ToString();
                            dr["haj_name"] = row["sao1"].ToString();
                            dr["camp_id"] = "";
                            dr["camp_num"] = "";
                            dr["bed_id"] = "";
                            dr["bed_num"] = "";
                            dr["res_num"] = "";
                            dr["phone"] = "";
                            dr["city"] = "";
                            dr["nationality"] = "";
                            dr["bus_id"] = buses.Rows[i]["bus_id"].ToString();
                            dr["bus_name"] = buses.Rows[i]["bus_num"].ToString();
                            busPassengers.Rows.Add(dr);
                        }
                        else
                        {
                            dr = hajjj_buss_by_id_f.NewRow();
                            dr["haj_id"] = row["sao3"].ToString();
                            dr["haj_name"] = row["sao1"].ToString();
                            dr["camp_id"] = "";
                            dr["camp_num"] = "";
                            dr["bed_id"] = "";
                            dr["bed_num"] = "";
                            dr["res_num"] = "";
                            dr["phone"] = "";
                            dr["city"] = "";
                            dr["nationality"] = "";
                            dr["bus_id"] = buses.Rows[i]["bus_id"].ToString();
                            dr["bus_name"] = buses.Rows[i]["bus_num"].ToString();
                            hajjj_buss_by_id_f.Rows.Add(dr);
                        }
                    }
                }

            }
            // Sort bus_passengers by res_num (nulls first) and then by bus_id
            DataView sortedPassengersView = busPassengers.DefaultView;
            sortedPassengersView.Sort = "res_num ASC, bus_id ASC";
            DataTable sortedPassengers = sortedPassengersView.ToTable();

            // Initialize variables
            int currentCampId = 1;
            int bedCount = 1;
            int previousBusId = -1;

            // Iterate through each passenger
            foreach (DataRow passengerRow in sortedPassengers.Rows)
            {
                int passengerId = Convert.ToInt32((string)passengerRow["haj_id"]);
                int busId = Convert.ToInt32((string)passengerRow["bus_id"]);
                string passengerType = "" /*(string)passengerRow["passenger_type"]*/;
                string reservationNumber = passengerRow.IsNull("res_num") ? null : (string)passengerRow["res_num"];

                // Check if it's a team leader
                if (passengerType == "suv")
                {
                    // Assign the team leader to the current camp
                    campsBeds.Rows.Add(passengerId, currentCampId, bedCount);
                    bedCount++;
                }
                else
                {
                    // Check if it's a new bus
                    if (busId != previousBusId)
                    {
                        // Move to the next camp
                        currentCampId++;
                        bedCount = 1;
                        previousBusId = busId;

                        // Check if the next camp is available
                        if (!IsCampAvailable(currentCampId, camps))
                        {
                            //throw new Exception("There are not enough available camps for all passengers.");
                        }
                    }

                    // Find the reservation camp (if any)
                    int? reservationCampId = GetReservationCampId(reservationNumber, campsBeds);

                    // Check if a reservation camp is found and has available beds
                    if (reservationCampId != null && IsCampAvailable((int)reservationCampId, camps))
                    {
                        // Assign the passenger to the reservation camp
                        campsBeds.Rows.Add(passengerId, reservationCampId, GetNextAvailableBed((int)reservationCampId, campsBeds));
                    }
                    else
                    {
                        // Check if the current camp has available beds
                        if (IsCampAvailable(currentCampId, camps))
                        {
                            // Assign the passenger to the current camp
                            campsBeds.Rows.Add(passengerId, currentCampId, GetNextAvailableBed(currentCampId, campsBeds));
                        }
                        else
                        {
                            // Move to the next camp
                            currentCampId++;
                            bedCount = 1;

                            // Check if the next camp is available
                            if (!IsCampAvailable(currentCampId, camps))
                            {
                                //throw new Exception("There are not enough available camps for all passengers.");
                            }

                            // Assign the passenger to the next camp
                            campsBeds.Rows.Add(passengerId, currentCampId, bedCount);
                        }
                    }

                    bedCount++;
                }

                // Check if all beds in the current camp are filled
                if (currentCampId >= 1 && currentCampId <= camps.Rows.Count)
                {
                    if (bedCount > Convert.ToInt32((string)camps.Rows[currentCampId - 1]["sao3"]))
                    {
                        // Move to the next camp
                        currentCampId++;
                        bedCount = 1;
                    }
                }
                else
                {
                    // Handle the case when currentCampId is out of range
                    //throw new Exception("Invalid currentCampId: " + currentCampId);
                }
            }

            return campsBeds;
        }
        public static int? GetReservationCampId(string reservationNumber, DataTable campsBeds)
        {
            if (reservationNumber == null)
                return null;

            foreach (DataRow row in campsBeds.Rows)
            {
                //if (!row.IsNull("res_num") && (string)row["res_num"] == reservationNumber)
                //{
                //    return (int)row["camp_id"];
                //}
            }

            return null;
        }
        public static bool IsCampAvailable(int campId, DataTable camps)
        {
            if (campId >= 1 && campId <= camps.Rows.Count)
            {
                int bedsAvailable = Convert.ToInt32((string)camps.Rows[campId - 1]["sao3"]);
                return bedsAvailable > 0;
            }

            return false;
        }
        public static int GetNextAvailableBed(int campId, DataTable campsBeds)
        {
            int maxBedId = 0;
            foreach (DataRow row in campsBeds.Rows)
            {
                if ((int)row["camp_id"] == campId && (int)row["bed_id"] > maxBedId)
                {
                    maxBedId = (int)row["bed_id"];
                }
            }

            return maxBedId + 1;
        }





    }
}
