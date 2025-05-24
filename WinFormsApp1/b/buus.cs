using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.b
{
    internal class buus : z
    {
        private int _bus_id;
        private string _bus_num;
        private string _bus_plate;
        private string _chairs_ava;
        private string _chairs_left;
        private string _year;
        private string _sao1;
        private string _sao2;
        private string _sao3;
        #region Properties
        public int bus_id
        {
            get { return _bus_id; }
            set { _bus_id = value; }
        }

        public string bus_num
        {
            get { return _bus_num; }
            set { _bus_num = value; }
        }

        public string bus_plate
        {
            get { return _bus_plate; }
            set { _bus_plate = value; }
        }

        public string chairs_ava
        {
            get { return _chairs_ava; }
            set { _chairs_ava = value; }
        }

        public string chairs_left
        {
            get { return _chairs_left; }
            set { _chairs_left = value; }
        }

        public string year
        {
            get { return _year; }
            set { _year = value; }
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
            SL.Add("bus_id", bus_id);
            SL.Add("bus_num", bus_num);
            SL.Add("bus_plate", bus_plate);
            SL.Add("chairs_ava", chairs_ava);
            SL.Add("chairs_left", chairs_left);
            SL.Add("year", year);
            SL.Add("sao1", sao1);
            SL.Add("sao2", sao2);
            SL.Add("sao3", sao3);

            if (DB.RunProcrduer("Pro_buus", SL) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string add_bus( string bus_num, string bus_plate,
                     string chairs_ava, string chairs_left, string year,
                     string sao1, string sao2, string sao3)
        {
            this.bus_id = 0;
            this.bus_num = bus_num;
            this.bus_plate = bus_plate;
            this.chairs_ava = chairs_ava;
            this.chairs_left = chairs_left;
            this.year = year;
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

        public string update_bus(int bus_id, string bus_num, string bus_plate,
                                 string chairs_ava, string chairs_left, string year,
                                 string sao1, string sao2, string sao3)
        {
            this.bus_id = bus_id;
            this.bus_num = bus_num;
            this.bus_plate = bus_plate;
            this.chairs_ava = chairs_ava;
            this.chairs_left = chairs_left;
            this.year = year;
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

        public bool del_bus(int bus_id)
        {
            this.bus_id = bus_id;
            return q();
        }

        public DataTable all_data()
        {
            string query = "select * From buus";
            return ss(query);
        }
    }
}
