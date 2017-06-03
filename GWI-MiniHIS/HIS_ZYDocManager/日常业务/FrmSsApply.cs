using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWMHIS.BussinessLogicLayer.Forms;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.SYSTEM.BussinessLogicLayer.Classes;

namespace HIS_ZYDocManager.日常业务
{
    public partial class FrmSsApply : GWI.HIS.Windows.Controls.BaseForm
    {
        HIS.Model.ZY_PatList patlist;
        private User user;
        private Deptment dept;
        HIS.ZYDoc_BLL.OperaApply.SsApply applyop;
        HIS.Model.SS_APPLY apply;
        public FrmSsApply(HIS.Model.ZY_PatList _patlist, long _userid, long _deptid)
        {
            InitializeComponent();
            patlist = _patlist;
            user = new User(_userid);
            dept = new Deptment(_deptid);
            HIS_ZYDocManager.PatientControl patient = new PatientControl();
            this.inPatientPanel1.InPaitent = patient.SetData(patlist);
            applyop = new HIS.ZYDoc_BLL.OperaApply.SsApply();
            apply = new HIS.Model.SS_APPLY();
            InitData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetData()
        {
            if (apply == null)
            {
                apply = new HIS.Model.SS_APPLY();
            }
            apply.PAT_WEIGHT = Convert.ToDecimal(XcConvert.IsNull(txtWeight.Text.Trim(), "0"));
            apply.PAT_HEIGHT =Convert.ToDecimal( XcConvert.IsNull(txtHeight.Text.Trim(),"0"));           
            apply.DRUG_ALLERGY = txtAllergy.Text;
            apply.SS_DIAG = txtDiag.Text;
            apply.SS_DIAG1 = txtdiag1.Text;
            apply.SS_DIAG2 = txtDiag2.Text;
            apply.TEND_OPERA = txtTendOpera.Text;
            apply.TEND_ANESTH = txtTend_Anesth.Text;
            apply.OPERA_BODY = txtBody.Text;
            apply.OTHER_OPERA = txtOtherOpera.Text;
            apply.OTHER_OPERA1 = txtOtherOpera1.Text;
            apply.OTHER_OPERA2 = txtOtherOpera2.Text;
            apply.OTHER_OPERA3 = txtOtherOpera3.Text;
            apply.OPERA_APPLIANCE = txtAppliance.Text;
            apply.OPERA_APPLIANCE1 = txtAppliance1.Text;
            apply.OPERA_APPLIANCE2 = txtAppliance2.Text;
            apply.OPERA_APPLIANCE3 = txtAppliance3.Text;
            apply.TEND_OPERADRUG = txtDrug.Text;
            apply.TEND_OPERADRUG1 = txtDrug1.Text;
            apply.TEND_OPERADRUG2 = txtDrug2.Text;
            apply.TEND_OPERADRUG3 = txtDrug3.Text;
            apply.APPLY_DOC =Convert.ToInt32(user.EmployeeID);
            //if (txtOperaDoc.Text == "")
            //{
            //    MessageBox.Show("请选择手术医生");
            //    return;
            //}
            apply.OPERA_DOC =Convert.ToInt32( XcConvert.IsNull(txtOperaDoc.MemberValue,"0"));
            apply.OPERA_ASSIST1 = Convert.ToInt32(XcConvert.IsNull( txtAssist.MemberValue,"0"));
            apply.OPERA_ASSIST2 = Convert.ToInt32(XcConvert.IsNull( txtAssist1.MemberValue,"0"));
            apply.OPERA_ASSIST3 = Convert.ToInt32(XcConvert.IsNull( txtAssist2.MemberValue,"0"));
            apply.TEND_OPERADATE = dtTenddate.Value;
            apply.OPERA_MEMO = txtMemo.Text;
            if (txtOperaDept.Text == "")
            {
                MessageBox.Show("请选择手术地点");
                txtOperaDept.Focus();
                return;
            }
            apply.OPERA_DEPT =Convert.ToInt32(XcConvert.IsNull( txtOperaDept.MemberValue,"0"));
            apply.OPERA_VISIT =Convert.ToInt32(XcConvert.IsNull( txtVisit.MemberValue,"0"));
            apply.OPERA_VISIT1 = Convert.ToInt32(XcConvert.IsNull( txtVisit1.MemberValue,"0"));
            if (chkEmergency.Checked)
            {
                apply.EMERGENCY_OPERA = 1;
            }
            else
            {
                apply.EMERGENCY_OPERA = 0;
            }
            if (chkAnesConsent.Checked)
            {
                apply.ANESTH_CONSENT = 1;
            }
            else
            {
                apply.ANESTH_CONSENT = 0;
            }
            if (chkOpeConsent.Checked)
            {
                apply.OPERA_CONSENT = 1;
            }
            else
            {
                apply.OPERA_CONSENT = 0;
            }
            if (radHbsag.Checked)
            {
                apply.HBSAG = "阳性";
            }
            if(radHbsag1.Checked)
            {
                apply.HBSAG = "阴性";
            }
            if (radHcv.Checked)
            {
                apply.HCV = "阳性";
            }
            if(radHcv1.Checked)
            {
                apply.HCV = "阴性";
            }
            if (radHiv.Checked)
            {
                apply.HIV = "阳性";
            }
            if(radHiv1.Checked)
            {
                apply.HIV = "阴性";
            }
            if (radTp.Checked)
            {
                apply.TP = "阳性";
            }
            if(radTp1.Checked)
            {
                apply.TP = "阴性";
            }
            if (applyop.SaveApply(patlist,apply))
            {
                MessageBox.Show("保存成功");
                btnSave.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void InitData()
        {
            HIS.ZYDoc_BLL.BaseInfo.SsBase ssbase=new HIS.ZYDoc_BLL.BaseInfo.SsBase ();
            DataSet dataset = ssbase.GetSsDataSet();
            this.txtDiag.SetSelectionCardDataSource(dataset.Tables["Diages"]);
            this.txtdiag1.SetSelectionCardDataSource(dataset.Tables["Diages"]);          
            this.txtTendOpera.SetSelectionCardDataSource(dataset.Tables["Operation"]);
            this.txtTend_Anesth.SetSelectionCardDataSource(dataset.Tables["Anesth"]);
            this.txtBody.SetSelectionCardDataSource(dataset.Tables["Body"]);
            this.txtOtherOpera.SetSelectionCardDataSource(dataset.Tables["Operation"]);
            this.txtOtherOpera1.SetSelectionCardDataSource(dataset.Tables["Operation"]);
            this.txtOtherOpera2.SetSelectionCardDataSource(dataset.Tables["Operation"]);
            this.txtOtherOpera3.SetSelectionCardDataSource(dataset.Tables["Operation"]);
            this.txtAppliance.SetSelectionCardDataSource(dataset.Tables["Applice"]);
            this.txtAppliance1.SetSelectionCardDataSource(dataset.Tables["Applice"]);
            this.txtAppliance2.SetSelectionCardDataSource(dataset.Tables["Applice"]);
            this.txtAppliance3.SetSelectionCardDataSource(dataset.Tables["Applice"]);
            this.txtOperaDoc.SetSelectionCardDataSource(dataset.Tables["DocName"]);
            this.txtAssist.SetSelectionCardDataSource(dataset.Tables["DocName"]);
            this.txtAssist1.SetSelectionCardDataSource(dataset.Tables["DocName"]);
            this.txtAssist2.SetSelectionCardDataSource(dataset.Tables["DocName"]);
            this.txtVisit.SetSelectionCardDataSource(dataset.Tables["DocName"]);
            this.txtVisit1.SetSelectionCardDataSource(dataset.Tables["DocName"]);
            this.txtOperaDept.SetSelectionCardDataSource(dataset.Tables["Dept"]);
            apply = applyop.GetNotArrangeApply(patlist.PatListID);
            if (apply != null)
            {
                txtHeight.Text = apply.PAT_HEIGHT.ToString();
                txtWeight.Text = apply.PAT_WEIGHT.ToString();
                txtAllergy.Text = apply.DRUG_ALLERGY.ToString();
                txtDiag.Text = apply.SS_DIAG.ToString();
                txtdiag1.Text = apply.SS_DIAG1.ToString();
                txtDiag2.Text = apply.SS_DIAG2.ToString();
                txtTendOpera.Text = apply.TEND_OPERA.ToString();
                txtTend_Anesth.Text = apply.TEND_ANESTH.ToString();
                txtBody.Text = apply.OPERA_BODY.ToString();
                txtOtherOpera.Text = apply.OTHER_OPERA.ToString();
                txtOtherOpera1.Text = apply.OTHER_OPERA1.ToString();
                txtOtherOpera2.Text = apply.OTHER_OPERA2.ToString();
                txtOtherOpera3.Text = apply.OTHER_OPERA3.ToString();
                txtAppliance.Text = apply.OPERA_APPLIANCE.ToString();
                txtAppliance1.Text = apply.OPERA_APPLIANCE1.ToString();
                txtAppliance2.Text = apply.OPERA_APPLIANCE2.ToString();
                txtAppliance3.Text = apply.OPERA_APPLIANCE3.ToString();
                txtDrug.Text = apply.TEND_OPERADRUG.ToString();
                txtDrug1.Text = apply.TEND_OPERADRUG1.ToString();
                txtDrug2.Text = apply.TEND_OPERADRUG2.ToString();
                txtDrug3.Text = apply.TEND_OPERADRUG3.ToString();
                txtOperaDoc.Text = BaseData.GetUserName(apply.OPERA_DOC.ToString());
                txtOperaDoc.MemberValue = apply.OPERA_DOC.ToString();
                txtAssist.Text = BaseData.GetUserName(apply.OPERA_ASSIST1.ToString());
                txtAssist.MemberValue = apply.OPERA_ASSIST1.ToString();
                txtAssist1.Text = BaseData.GetUserName(apply.OPERA_ASSIST2.ToString());
                txtAssist1.MemberValue = apply.OPERA_ASSIST2.ToString();
                txtAssist2.Text = BaseData.GetUserName(apply.OPERA_ASSIST3.ToString());
                txtAssist2.MemberValue = apply.OPERA_ASSIST3.ToString();
                dtTenddate.Text = apply.TEND_OPERADATE.ToString();
                txtMemo.Text = apply.OPERA_MEMO.ToString();
                txtOperaDept.Text = BaseData.GetDeptName(apply.OPERA_DEPT.ToString());
                txtOperaDept.MemberValue = apply.OPERA_DEPT.ToString();
                txtVisit.Text = BaseData.GetUserName(apply.OPERA_VISIT.ToString());
                txtVisit.MemberValue = apply.OPERA_VISIT.ToString();
                txtVisit1.Text = BaseData.GetUserName(apply.OPERA_VISIT1.ToString());
                txtVisit1.MemberValue = apply.OPERA_VISIT1.ToString();
                if (apply.HBSAG.ToString() == "阳性")
                {
                    radHbsag.Checked = true;
                }
                if (apply.HBSAG.ToString() == "阴性")
                {
                    radHbsag1.Checked = true;
                }
                if (apply.HCV.ToString() == "阳性")
                {
                    radHcv.Checked = true;
                }
                if (apply.HCV.ToString() == "阴性")
                {
                    radHcv1.Checked = true;
                }
                if (apply.HIV.ToString() == "阳性")
                {
                    radHiv.Checked = true;
                }
                if (apply.HIV.ToString() == "阴性")
                {
                    radHiv1.Checked = true;
                }
                if (apply.TP.ToString() == "阳性")
                {
                    radTp.Checked = true;
                }
                if (apply.TP.ToString() == "阴性")
                {
                    radTp1.Checked = true;
                }
                if (apply.EMERGENCY_OPERA == 1)
                {
                    chkEmergency.Checked = true;
                }
                if (apply.OPERA_CONSENT == 1)
                {
                    chkOpeConsent.Checked = true;
                }
                if (apply.ANESTH_CONSENT == 1)
                {
                    chkAnesConsent.Checked = true;
                }
            }
        }

        private void txtWeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAllergy.Focus();
            }
        }

        private void txtAllergy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDiag.Focus();
            }            
        }

        private void txtHeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWeight.Focus();
            }
        }

        private void txtDiag2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTendOpera.Focus();
            }
        }

        private void txtDrug_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDrug1.Focus();
            }
        }

        private void txtDrug1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDrug2.Focus();
            }
        }

        private void txtDrug2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDrug3.Focus();
            }
        }

        private void txtDrug3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtOperaDoc.Focus();
            }
        }

        private void txtMemo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtOperaDept.Focus();
            }
        }
          
    }
}
