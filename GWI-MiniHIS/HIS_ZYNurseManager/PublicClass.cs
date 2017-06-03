using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS_ZYNurseManager
{
    class PublicClass:GWI.HIS.Windows.Controls.IInPatient
    {
        private decimal balancefee;
        private string bedno;
        private DateTime bordday;
        private GWI.HIS.Windows.Controls.BindValue? curedoctor;
        private GWI.HIS.Windows.Controls.BindValue? currentdepartment;
        private GWI.HIS.Windows.Controls.BindValue? economydoctor;
        private DateTime? indate;
        private GWI.HIS.Windows.Controls.BindValue? indepartment;
        private GWI.HIS.Windows.Controls.BindValue? indisease;
        private string inpitentno;
        private GWI.HIS.Windows.Controls.BindValue? nurse;
        private string patientname;
        private GWI.HIS.Windows.Controls.BindValue? patienttype;
        private decimal prepayfee;
        private string sex;
        private string tendinfo;

        public decimal BalanceFee
        {
            get
            {
                return balancefee;
            }
            set
            {
                balancefee = value;
            }
        }

        public string BedNo
        {
            get
            {
                return bedno;
            }
            set
            {
                bedno = value;
            }
        }

        public DateTime BordDay
        {
            get
            {
                return bordday;
            }
            set
            {
                bordday = value;
            }
        }

        public GWI.HIS.Windows.Controls.BindValue? CureDoctor
        {
            get
            {
                return curedoctor;
            }
            set
            {
                curedoctor = value;
            }
        }

        public GWI.HIS.Windows.Controls.BindValue? CurrentDepartment
        {
            get
            {
                return currentdepartment;
            }
            set
            {
                currentdepartment = value;
            }
        }

        public GWI.HIS.Windows.Controls.BindValue? EconomyDoctor
        {
            get
            {
                return economydoctor;
            }
            set
            {
                economydoctor = value;
            }
        }

        public DateTime? InDate
        {
            get
            {
                return indate;
            }
            set
            {
                indate = value;
            }
        }

        public GWI.HIS.Windows.Controls.BindValue? InDepartment
        {
            get
            {
                return indepartment;
            }
            set
            {
                indepartment = value;
            }
        }

        public GWI.HIS.Windows.Controls.BindValue? InDisease
        {
            get
            {
                return indisease;
            }
            set
            {
                indisease = value;
            }
        }

        public string InpitentNo
        {
            get
            {
                return inpitentno;
            }
            set
            {
                inpitentno = value;
            }
        }

        public GWI.HIS.Windows.Controls.BindValue? Nurse
        {
            get
            {
                return nurse;
            }
            set
            {
                nurse = value;
            }
        }

        public string PatientName
        {
            get
            {
                return patientname;
            }
            set
            {
                patientname = value;
            }
        }

        public GWI.HIS.Windows.Controls.BindValue? PatientType
        {
            get
            {
                return patienttype;
            }
            set
            {
                patienttype = value;
            }
        }

        public decimal PrePayFee
        {
            get
            {
                return prepayfee;
            }
            set
            {
                prepayfee = value;
            }
        }

        public string Sex
        {
            get
            {
                return sex;
            }
            set
            {
                sex = value;
            }
        }

        public string TendInfo
        {
            get
            {
                return tendinfo;
            }
            set
            {
                tendinfo = value;
            }
        }

    }
}
