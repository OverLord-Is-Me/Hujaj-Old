using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.b
{
    internal class bus_info : z
    {
        private int _info_idd;
        private int _bus_id;
        private int _dri_id;
        private int _mov_id;
        private int _suv_id;
        private string _city;
        private string _locatio;
        private string _line_details;
        private string _sao1;
        private string _sao2;
        private string _sao3;

        #region Properties
        public int info_idd
        {
            get { return _info_idd; }
            set { _info_idd = value; }
        }

        public int  bus_id
        {
            get { return _bus_id; }
            set { _bus_id = value; }
        }

        public int  dri_id
        {
            get { return _dri_id; }
            set { _dri_id = value; }
        }

        public int  mov_id
        {
            get { return _mov_id; }
            set { _mov_id = value; }
        }

        public int  suv_id
        {
            get { return _suv_id; }
            set { _suv_id = value; }
        }

        public string city
        {
            get { return _city; }
            set { _city = value; }
        }

        public string locatio
        {
            get { return _locatio; }
            set { _locatio = value; }
        }

        public string line_details
        {
            get { return _line_details; }
            set { _line_details = value; }
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
            SL.Add("info_idd", info_idd);
            SL.Add("bus_id", bus_id);
            SL.Add("dri_id", dri_id);
            SL.Add("mov_id", mov_id);
            SL.Add("suv_id", suv_id);
            SL.Add("city", city);
            SL.Add("locatio", locatio);
            SL.Add("line_details", line_details);
            SL.Add("sao1", sao1);
            SL.Add("sao2", sao2);
            SL.Add("sao3", sao3);

            if (DB.RunProcrduer("Pro_bus_info", SL) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string add_bus_info( int bus_id, int dri_id,
                                  int mov_id, int suv_id, string city,
                                  string locatio, string line_details, string sao1,
                                  string sao2, string sao3)
        {
            this.info_idd = 0;
            this.bus_id = bus_id;
            this.dri_id = dri_id;
            this.mov_id = mov_id;
            this.suv_id = suv_id;
            this.city = city;
            this.locatio = locatio;
            this.line_details = line_details;
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

        public string update_bus_info(int info_idd, int bus_id, int dri_id,
                                  int mov_id, int suv_id, string city,
                                  string locatio, string line_details, string sao1,
                                  string sao2, string sao3)
        {
            this.info_idd       =info_idd       ;
            this.bus_id         =bus_id         ;
            this.dri_id         =dri_id         ;
            this.mov_id         =mov_id         ;
            this.suv_id         =suv_id         ;
            this.city           =city           ;
            this.locatio        =locatio        ;
            this.line_details   =line_details   ;
            this.sao1           =sao1           ;
            this.sao2           =sao2           ;
            this.sao3           =sao3           ;


            if (u())
            {
                return "T";
            }
            else
            {
                return "F";
            }
        }

        public bool del_bus_info(int info_idd)
        {
            this.info_idd = info_idd;
            return q();
        }

    }
}
