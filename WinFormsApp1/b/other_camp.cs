using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.b
{
    internal class other_camp : z
    {
        private int _other_camp_id;
        private int  _camp_id;
        private string _camp_num;
        private int  _bed_id;
        private string _bed_num;
        private int  _suv_id;
        private string _suv_num;
        private int  _mov_id;
        private string _mov_num;
        private int  _dri_id;
        private string _dri_num;
        #region Properties
        public int other_camp_id
        {
            get { return _other_camp_id; }
            set { _other_camp_id = value; }
        }

        public int  camp_id
        {
            get { return _camp_id; }
            set { _camp_id = value; }
        }

        public string camp_num
        {
            get { return _camp_num; }
            set { _camp_num = value; }
        }

        public int  bed_id
        {
            get { return _bed_id; }
            set { _bed_id = value; }
        }

        public string bed_num
        {
            get { return _bed_num; }
            set { _bed_num = value; }
        }

        public int  suv_id
        {
            get { return _suv_id; }
            set { _suv_id = value; }
        }

        public string suv_num
        {
            get { return _suv_num; }
            set { _suv_num = value; }
        }

        public int  mov_id
        {
            get { return _mov_id; }
            set { _mov_id = value; }
        }

        public string mov_num
        {
            get { return _mov_num; }
            set { _mov_num = value; }
        }

        public int  dri_id
        {
            get { return _dri_id; }
            set { _dri_id = value; }
        }

        public string dri_num
        {
            get { return _dri_num; }
            set { _dri_num = value; }
        }
        #endregion


        protected override bool lsl(char op)
        {
            SortedList SL = new SortedList();
            SL.Add("Check", op);
            SL.Add("other_camp_id", other_camp_id);
            SL.Add("camp_id", camp_id);
            SL.Add("camp_num", camp_num);
            SL.Add("bed_id", bed_id);
            SL.Add("bed_num", bed_num);
            SL.Add("suv_id", suv_id);
            SL.Add("suv_num", suv_num);
            SL.Add("mov_id", mov_id);
            SL.Add("mov_num", mov_num);
            SL.Add("dri_id", dri_id);
            SL.Add("dri_num", dri_num);

            if (DB.RunProcrduer("Pro_other_camp", SL) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string add_OtherCamp( int camp_id, string camp_num,
                           int bed_id, string bed_num, int suv_id, string suv_num,
                           int mov_id, string mov_num, int dri_id, string dri_num)
        {
            this.other_camp_id = 0;
            this.camp_id = camp_id;
            this.camp_num = camp_num;
            this.bed_id = bed_id;
            this.bed_num = bed_num;
            this.suv_id = suv_id;
            this.suv_num = suv_num;
            this.mov_id = mov_id;
            this.mov_num = mov_num;
            this.dri_id = dri_id;
            this.dri_num = dri_num;

            if (a())
            {
                return "T";
            }
            else
            {
                return "F";
            }
        }

        public string updateOtherCamp(int other_camp_id, int camp_id, string camp_num,
                                      int bed_id, string bed_num, int suv_id, string suv_num,
                                      int mov_id, string mov_num, int dri_id, string dri_num)
        {
            this.other_camp_id = other_camp_id;
            this.camp_id = camp_id;
            this.camp_num = camp_num;
            this.bed_id = bed_id;
            this.bed_num = bed_num;
            this.suv_id = suv_id;
            this.suv_num = suv_num;
            this.mov_id = mov_id;
            this.mov_num = mov_num;
            this.dri_id = dri_id;
            this.dri_num = dri_num;

            if (u())
            {
                return "T";
            }
            else
            {
                return "F";
            }
        }

        public bool delOtherCamp(int other_camp_id)
        {
            this.other_camp_id = other_camp_id;
            return q();
        }

    }
}
