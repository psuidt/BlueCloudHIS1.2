using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS_SSManager
{
   
        public class PatientControl : GWI.HIS.Windows.Controls.IInPatient
        {
            #region 属性
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
            #endregion


            #region 赋值
            public PatientControl SetData(HIS.Model.ZY_PatList patlist)
            {
                string[] doc = new string[3];
                doc = HIS.ZYDoc_BLL.PatInfo.PatOperation.GetDoc(patlist.PatListID);
                HIS.ZY_BLL.ObjectModel.CostManager.IcostManager IcM = HIS.ZY_BLL.ObjectModel.ObjectFactory.GetObject<HIS.ZY_BLL.ObjectModel.CostManager.IcostManager>(typeof(HIS.ZY_BLL.DataModel.ZY_CostMaster));
                IcM.PatListID = patlist.PatListID;
                this.BalanceFee = IcM.GetPatFee().surplusFee;
                this.BedNo = patlist.BedCode;
                this.BordDay = patlist.PatientInfo.PatBriDate;
                this.CureDoctor = new GWI.HIS.Windows.Controls.BindValue(null, doc[0]);
                this.CurrentDepartment = new GWI.HIS.Windows.Controls.BindValue(null, HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptName(patlist.CurrDeptCode));
                this.EconomyDoctor = new GWI.HIS.Windows.Controls.BindValue(null, doc[1]);
                this.InDepartment = new GWI.HIS.Windows.Controls.BindValue(null, HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptName(patlist.CureDeptCode));
                string[] strdiag = patlist.DiseaseName.Split(new char[] { '|' });
                if (strdiag[0] == "")
                {
                    this.InDisease = new GWI.HIS.Windows.Controls.BindValue(null, strdiag[1].Replace("\r\n", ""));
                }
                else
                {
                    this.InDisease = new GWI.HIS.Windows.Controls.BindValue(null, strdiag[0].Replace("\r\n", ""));
                }
                this.InpitentNo = patlist.CureNo;
                this.Nurse = new GWI.HIS.Windows.Controls.BindValue(null, doc[2]);
                this.PatientName = patlist.PatientInfo.PatName;
                this.PatientType = new GWI.HIS.Windows.Controls.BindValue(null, patlist.PatientInfo.ACCOUNTTYPE);
                this.PrePayFee = IcM.GetPatFee().chargeFee;
                this.Sex = patlist.PatientInfo.PatSex;
                this.InDate = patlist.CureDate;
                this.TendInfo = "";
                return this;
            }
            #endregion
        }    
}
