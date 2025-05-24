using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.b
{
    internal class mof : z
    {
        private int _mof_id;
        private string _mof_name;
        private string _nat_id;
        private byte[] _mof_pic;
        private string _nation;
        private string _yea;
        private string _sao1;
        private string _sao2;
        private string _sao3;
        #region Properties
        public int mof_id
        {
            get { return _mof_id; }
            set { _mof_id = value; }
        }

        public string mof_name
        {
            get { return _mof_name; }
            set { _mof_name = value; }
        }

        public string nat_id
        {
            get { return _nat_id; }
            set { _nat_id = value; }
        }

        public byte[] mof_pic
        {
            get { return _mof_pic; }
            set { _mof_pic = value; }
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
            SL.Add("mof_id", mof_id);
            SL.Add("mof_name", mof_name);
            SL.Add("nat_id", nat_id);
            SL.Add("mof_pic", mof_pic);
            SL.Add("nation", nation);
            SL.Add("yea", yea);
            SL.Add("sao1", sao1);
            SL.Add("sao2", sao2);
            SL.Add("sao3", sao3);

            if (DB.RunProcrduer("Pro_mof", SL) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string add_mof( string mof_name, string nat_id, byte[] mof_pic,
                     string nation, string yea, string sao1, string sao2, string sao3)
        {
            this.mof_id = 0;
            this.mof_name = mof_name;
            this.nat_id = nat_id;
            this.mof_pic = mof_pic;
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

        public string update_mof(int mof_id, string mof_name, string nat_id, byte[] mof_pic,
                                 string nation, string yea, string sao1, string sao2, string sao3)
        {
            this.mof_id = mof_id;
            this.mof_name = mof_name;
            this.nat_id = nat_id;
            this.mof_pic = mof_pic;
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

        public bool del_mof(int mof_id)
        {
            this.mof_id = mof_id;
            return q();
        }
    }
}
