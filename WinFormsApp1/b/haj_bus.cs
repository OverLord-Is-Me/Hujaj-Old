using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.b
{
    internal class haj_bus : z
    {
        private int _haj_info_id;
        private int _haj_id;
        private string _haj_name;
        private int _bus_id;
        private string _bus_name;
        private string _sao1; //suv or mof
        private string _sao2; //male or female
        private string _sao3; // suv or mof iddddd
        #region Properties
        public int haj_info_id
        {
            get { return _haj_info_id; }
            set { _haj_info_id = value; }
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

        public int bus_id
        {
            get { return _bus_id; }
            set { _bus_id = value; }
        }

        public string bus_name
        {
            get { return _bus_name; }
            set { _bus_name = value; }
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
            SL.Add("haj_info_id", haj_info_id);
            SL.Add("haj_id", haj_id);
            SL.Add("haj_name", haj_name);
            SL.Add("bus_id", bus_id);
            SL.Add("bus_name", bus_name);
            SL.Add("sao1", sao1);
            SL.Add("sao2", sao2);
            SL.Add("sao3", sao3);

            if (DB.RunProcrduer("Pro_haj_bus", SL) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public string add_hajinfo( int haj_id, string haj_name, int bus_id,
                         string bus_name, string sao1, string sao2, string sao3)
        {
            this.haj_info_id = 0;
            this.haj_id = haj_id;
            this.haj_name = haj_name;
            this.bus_id = bus_id;
            this.bus_name = bus_name;
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

        public string update_hajinfo(int haj_info_id, int haj_id, string haj_name, int bus_id,
                                     string bus_name, string sao1, string sao2, string sao3)
        {
            this.haj_info_id = haj_info_id;
            this.haj_id = haj_id;
            this.haj_name = haj_name;
            this.bus_id = bus_id;
            this.bus_name = bus_name;
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
        public bool del_all()
        {
            return p();
        }
        public bool del_hajinfo(int haj_info_id)
        {
            this.haj_info_id = haj_info_id;
            return q();
        }
        public string all_data()
        {
            string query = "select haj_info_id From haj_bus";
            DataTable casaa = ss(query);
            return casaa.Rows.Count.ToString();
        }

        public string get_bus_id(int haj_id)
        {
            string query = "select bus_id,bus_name From haj_bus where haj_id ='" + haj_id + "'";
            DataTable dt = ss(query);
            this.bus_name = dt.Rows[0][1].ToString();
            return dt.Rows[0][0].ToString(); ;
        }

    }
}
