using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.b
{
    internal class suv : z
    {
        private int _suv_id;
        private string _suv_name;
        private string _suv_phone;
        private string _nat_id;
        private byte[] _suv_pic;
        private string _nation;
        private string _tassk;
        private string _yea;
        private string _sao1;
        private string _sao2;
        private string _sao3;

        #region Properties
        public int suv_id
        {
            get { return _suv_id; }
            set { _suv_id = value; }
        }

        public string suv_name
        {
            get { return _suv_name; }
            set { _suv_name = value; }
        }

        public string suv_phone
        {
            get { return _suv_phone; }
            set { _suv_phone = value; }
        }

        public string nat_id
        {
            get { return _nat_id; }
            set { _nat_id = value; }
        }

        public byte[] suv_pic
        {
            get { return _suv_pic; }
            set { _suv_pic = value; }
        }

        public string nation
        {
            get { return _nation; }
            set { _nation = value; }
        }

        public string tassk
        {
            get { return _tassk; }
            set { _tassk = value; }
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
            SL.Add("suv_id", suv_id);
            SL.Add("suv_name", suv_name);
            SL.Add("suv_phone", suv_phone);
            SL.Add("nat_id", nat_id);
            SL.Add("suv_pic", suv_pic);
            SL.Add("nation", nation);
            SL.Add("tassk", tassk);
            SL.Add("yea", yea);
            SL.Add("sao1", sao1);
            SL.Add("sao2", sao2);
            SL.Add("sao3", sao3);

            if (DB.RunProcrduer("Pro_suv", SL) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public string add_SUV( string suv_name, string suv_phone,
                     string nat_id, byte[] suv_pic, string nation,
                     string tassk, string yea, string sao1, string sao2, string sao3)
        {
            this.suv_id = 0;
            this.suv_name = suv_name;
            this.suv_phone = suv_phone;
            this.nat_id = nat_id;
            this.suv_pic = suv_pic;
            this.nation = nation;
            this.tassk = tassk;
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

        public string update_SUV(int suv_id, string suv_name, string suv_phone,
                                string nat_id, byte[] suv_pic, string nation,
                                string tassk, string yea, string sao1, string sao2, string sao3)
        {
            this.suv_id = suv_id;
            this.suv_name = suv_name;
            this.suv_phone = suv_phone;
            this.nat_id = nat_id;
            this.suv_pic = suv_pic;
            this.nation = nation;
            this.tassk = tassk;
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

        public bool del_SUV(int suv_id)
        {
            this.suv_id = suv_id;
            return q();
        }
    }
}
