using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS_MZManager.HJSF
{
    public class UIOutPatient:GWI.HIS.Windows.Controls.IOutPatient
    {
        private string outPatientNo;

        private string cardNo;

        private string patientName;

        private string sex;

        private DateTime bordDay;

        private GWI.HIS.Windows.Controls.BindValue? patientType;

        private DateTime? regDate;

        private GWI.HIS.Windows.Controls.BindValue? regDepartment;

        private GWI.HIS.Windows.Controls.BindValue? cureDepartment;

        private GWI.HIS.Windows.Controls.BindValue? cureDoctor;

        private GWI.HIS.Windows.Controls.BindValue? disease;

        private GWI.HIS.Windows.Controls.BindValue? workUnit;

        private int patId;

        private int patListId;

        #region IOutPatient 成员

        public string OutPatientNo
        {
            get
            {
                return outPatientNo;
            }
            set
            {
                outPatientNo = value;
            }
        }

        public string CardNo
        {
            get
            {
                return cardNo;
            }
            set
            {
                cardNo = value;
            }
        }

        public string PatientName
        {
            get
            {
                return patientName;
            }
            set
            {
                patientName = value;
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

        public DateTime BordDay
        {
            get
            {
                return bordDay;
            }
            set
            {
                bordDay = value;
            }
        }

        public GWI.HIS.Windows.Controls.BindValue? PatientType
        {
            get
            {
                return patientType;
            }
            set
            {
                patientType = value;
            }
        }

        public DateTime? RegDate
        {
            get
            {
                return regDate;
            }
            set
            {
                regDate = value;
            }
        }

        public GWI.HIS.Windows.Controls.BindValue? RegDepartment
        {
            get
            {
                return regDepartment;
            }
            set
            {
                regDepartment = value;
            }
        }

        public GWI.HIS.Windows.Controls.BindValue? CureDepartment
        {
            get
            {
                return cureDepartment;
            }
            set
            {
                cureDepartment = value;
            }
        }

        public GWI.HIS.Windows.Controls.BindValue? CureDoctor
        {
            get
            {
                return cureDoctor;
            }
            set
            {
                cureDoctor = value;
            }
        }

        public GWI.HIS.Windows.Controls.BindValue? Disease
        {
            get
            {
                return disease;
            }
            set
            {
                disease = value;
            }
        }

        public GWI.HIS.Windows.Controls.BindValue? WorkUnit
        {
            get
            {
                return workUnit;
            }
            set
            {
                workUnit = value;
            }
        }


        public int PatId
        {
            get
            {
                return patId;
            }
            set
            {
                patId = value;
            }
        }
       
        public int PatListId
        {
            get
            {
                return patListId;
            }
            set
            {
                patListId = value;
            }
        }

        #endregion

        #region IOutPatient 成员

        public string Allergic
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
