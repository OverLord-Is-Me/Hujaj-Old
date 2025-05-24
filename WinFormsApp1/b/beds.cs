using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.b
{
    internal class beds : z
    {
        #region MyRegion
        private int _bed_id;
        private int _camp_id;
        private string _bed_num;
        private string _sao1;
        private string _sao2;
        private string _sao3; 
        #endregion
        #region Properties
        public int bed_id
        {
            get { return _bed_id; }
            set { _bed_id = value; }
        }
        public int camp_id
        {
            get { return _camp_id; }
            set { _camp_id = value; }
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
            SL.Add("bed_id", bed_id);
            SL.Add("camp_id", camp_id);
            SL.Add("bed_num", bed_num);
            SL.Add("sao1", sao1);
            SL.Add("sao2", sao2);
            SL.Add("sao3", sao3);

            if (DB.RunProcrduer("Pro_beds", SL) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string addbeds( int camp_id, string bed_num, 
                      string sao1, string sao2, string sao3)
        {
            this.bed_id = 0;
            this.camp_id = camp_id;
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

        public string update_beds(int bed_id, int camp_id, string bed_num, 
                                  string sao1, string sao2, string sao3)
        {
            this.bed_id = bed_id;
            this.camp_id = camp_id;
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

        public bool del_beds(int bed_id)
        {
            this.bed_id = bed_id;
            return q();
        }


    }
}
