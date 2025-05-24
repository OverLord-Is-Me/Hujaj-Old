using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.b
{
    internal class haj : z
    {
        private int _haj_id;
        private string _first_n;
        private string _middle_n;
        private string _last_n;
        private string _phone;
        private string _res_num;
        private string _gender;
        private string _nat_id;
        private string _nationality;
        private string _city;
        private string _yea;
        private string _sao1; //حالة الحجز نفسه
        private string _sao2;
        private string _sao3;

        #region Properties
        public int haj_id
        {
            get { return _haj_id; }
            set { _haj_id = value; }
        }

        public string first_n
        {
            get { return _first_n; }
            set { _first_n = value; }
        }

        public string middle_n
        {
            get { return _middle_n; }
            set { _middle_n = value; }
        }

        public string last_n
        {
            get { return _last_n; }
            set { _last_n = value; }
        }

        public string phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public string res_num
        {
            get { return _res_num; }
            set { _res_num = value; }
        }

        public string gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public string nat_id
        {
            get { return _nat_id; }
            set { _nat_id = value; }
        }

        public string nationality
        {
            get { return _nationality; }
            set { _nationality = value; }
        }

        public string city
        {
            get { return _city; }
            set { _city = value; }
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
            SL.Add("haj_id", haj_id);
            SL.Add("first_n", first_n);
            SL.Add("middle_n", middle_n);
            SL.Add("last_n", last_n);
            SL.Add("phone", phone);
            SL.Add("res_num", res_num);
            SL.Add("gender", gender);
            SL.Add("nat_id", nat_id);
            SL.Add("nationality", nationality);
            SL.Add("city", city);
            SL.Add("yea", yea);
            SL.Add("sao1", sao1);
            SL.Add("sao2", sao2);
            SL.Add("sao3", sao3);

            if (DB.RunProcrduer("Pro_haj", SL) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public string addhaj(string first_n, string middle_n, string last_n,
                     string phone, string res_num, string gender, string nat_id,
                     string nationality, string city,  string yea,
                     string sao1, string sao2, string sao3)
        {
            this.haj_id = 0;
            this.first_n = first_n;
            this.middle_n = middle_n;
            this.last_n = last_n;
            this.phone = phone;
            this.res_num = res_num;
            this.gender = gender;
            this.nat_id = nat_id;
            this.nationality = nationality;
            this.city = city;
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

        public string update_haj(int haj_id, string first_n, string middle_n, string last_n,
                                 string phone, string res_num, string gender, string nat_id,
                                 string nationality, string city,  string yea,
                                 string sao1, string sao2, string sao3)
        {
            this.haj_id = haj_id;
            this.first_n = first_n;
            this.middle_n = middle_n;
            this.last_n = last_n;
            this.phone = phone;
            this.res_num = res_num;
            this.gender = gender;
            this.nat_id = nat_id;
            this.nationality = nationality;
            this.city = city;
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
        public string get_name(int haj_id)
        {
            string query = "select first_n,res_num From haj where haj_id ='" + haj_id + "'";
            DataTable dt = ss(query);
            this.res_num = dt.Rows[0][1].ToString();
            return dt.Rows[0][0].ToString(); ;
        }


        public bool del_haj_nat(string nat_id)
        {
            string query = "select haj_id From haj where nat_id ='" + nat_id + "'";
            DataTable dt = ss(query);
            this.haj_id = Convert.ToInt32(dt.Rows[0][0].ToString());
            return q();
        }
        public bool del_haj_id(int haj_id)
        {
            this.haj_id = haj_id;
            return q();
        }

        public DataTable bring_data_nat(string nat_id)
        {
            string query = "select * From haj where nat_id ='" + nat_id + "'";
            return ss(query);
        }
        public string search_if_nat_id_exist(string nat_id)
        {
            string query = "select haj_id From haj where nat_id ='" + nat_id + "'";
            DataTable dt = ss(query);
            if(dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            else
            {
                return "-1";
            }
        }

        public string get_all_num()
        {
            string query = "select haj_id From haj";
            DataTable dt = ss(query);
            return dt.Rows.Count.ToString();
        }

        public DataTable get_all_data()
        {
            string query = "select * From haj";
            return ss(query);
        }
    }
}
