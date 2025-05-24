using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.b
{
    internal class driv : z
    {
        private int _dri_id;
        private string _dri_name;
        private string _dri_phone;
        private string _nat_id;
        private byte[] _nat_pic;
        private string _nation;
        private string _yea;
        private string _sao1;
        private string _sao2;
        private string _sao3;
       
        #region Properties
        public int dri_id
        {
            get { return _dri_id; }
            set { _dri_id = value; }
        }

        public string dri_name
        {
            get { return _dri_name; }
            set { _dri_name = value; }
        }

        public string dri_phone
        {
            get { return _dri_phone; }
            set { _dri_phone = value; }
        }

        public string nat_id
        {
            get { return _nat_id; }
            set { _nat_id = value; }
        }

        public byte[] nat_pic
        {
            get { return _nat_pic; }
            set { _nat_pic = value; }
        }

        public string nation
        {
            get { return _nation; }
            set { _nation = value; }
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
            SL.Add("dri_id", dri_id);
            SL.Add("dri_name", dri_name);
            SL.Add("dri_phone", dri_phone);
            SL.Add("nat_id", nat_id);
            SL.Add("nat_pic", nat_pic);
            SL.Add("nation", nation);
            SL.Add("yea", yea);
            SL.Add("sao1", sao1);
            SL.Add("sao2", sao2);
            SL.Add("sao3", sao3);

            if (DB.RunProcrduer("Pro_driv", SL) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public string add_driver( string dri_name, string dri_phone,
                        string nat_id, byte[] nat_pic, string nation,
                        string yea, string sao1, string sao2, string sao3)
        {
            this.dri_id = 0;
            this.dri_name = dri_name;
            this.dri_phone = dri_phone;
            this.nat_id = nat_id;
            this.nat_pic = nat_pic;
            this.nation = nation;
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

        public string update_driver(int dri_id, string dri_name, string dri_phone,
                                    string nat_id, byte[] nat_pic, string nation,
                                    string yea, string sao1, string sao2, string sao3)
        {
            this.dri_id = dri_id;
            this.dri_name = dri_name;
            this.dri_phone = dri_phone;
            this.nat_id = nat_id;
            this.nat_pic = nat_pic;
            this.nation = nation;
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

        public bool del_driver(int dri_id)
        {
            this.dri_id = dri_id;
            return q();
        }
    }
}
