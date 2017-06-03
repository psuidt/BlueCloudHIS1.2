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


namespace HIS_SSManager
{
    public partial class FrmAfterSs : GWI.HIS.Windows.Controls.BaseForm
    {
        private HIS.Model.SS_APPLY ssApplyPat;
        private DataTable nurses = new DataTable();
        private HIS.Model.SS_ARRANGE arrange;
        private int employeeid;
        HIS.SS_BLL.SsArrange arrangeop = new HIS.SS_BLL.SsArrange();
        public FrmAfterSs(HIS.Model.SS_APPLY _ssapplypat,int _employeeid)
        {
            InitializeComponent();
            ssApplyPat = _ssapplypat;
            PatientControl patient = new PatientControl();
            employeeid = _employeeid;
            this.inPatientPanel1.InPaitent = patient.SetData(ssApplyPat.Zy_Patlist);
            GetData();
            InitData();
            
        }

        private void InitData()
        {
            DataSet dataset = HIS.SS_BLL.BaseInfo.GetDataset();
            this.txtDiag.SetSelectionCardDataSource(dataset.Tables["Diages"]);
            this.txtdiag1.SetSelectionCardDataSource(dataset.Tables["Diages"]);
            txtShDiag.SetSelectionCardDataSource(dataset.Tables["Diages"]);     
     
            this.txtActual_Anesth.SetSelectionCardDataSource(dataset.Tables["Anesth"]);
             txtActual_Anesth1.SetSelectionCardDataSource(dataset.Tables["Anesth"]);
            txtActual_opera.SetSelectionCardDataSource(dataset.Tables["Operation"]);
            this.txtOtherOpera.SetSelectionCardDataSource(dataset.Tables["Operation"]);
            this.txtOtherOpera1.SetSelectionCardDataSource(dataset.Tables["Operation"]);
            this.txtOtherOpera2.SetSelectionCardDataSource(dataset.Tables["Operation"]);
            this.txtOtherOpera3.SetSelectionCardDataSource(dataset.Tables["Operation"]);        
            this.txtOperaDoc.SetSelectionCardDataSource(dataset.Tables["DocName"]);
            this.txtAssist.SetSelectionCardDataSource(dataset.Tables["DocName"]);
            this.txtAssist1.SetSelectionCardDataSource(dataset.Tables["DocName"]);
            this.txtAssist2.SetSelectionCardDataSource(dataset.Tables["DocName"]);
            txtAnesthDoc.SetSelectionCardDataSource(dataset.Tables["DocName"]);
            txtAnesthDoc1.SetSelectionCardDataSource(dataset.Tables["DocName"]);
             DataTable  nurses = HIS.SS_BLL.BaseInfo.GetNurse();
            txtWash_Nurse.SetSelectionCardDataSource(nurses);
            txtWash_Nurse1.SetSelectionCardDataSource(nurses);
            txtWash_Nurse2.SetSelectionCardDataSource(nurses);
            txtTourNurse.SetSelectionCardDataSource(nurses);
            txtTourNurse1.SetSelectionCardDataSource(nurses);
            txtTourNurse2.SetSelectionCardDataSource(nurses);
            txtGrade.SetSelectionCardDataSource(dataset.Tables["SsGrade"]);
        }

        private void GetData()
        {
            
            txtHeight.Text = ssApplyPat.PAT_HEIGHT.ToString();
            txtWeight.Text = ssApplyPat.PAT_WEIGHT.ToString();
            txtAllergy.Text = ssApplyPat.DRUG_ALLERGY.ToString();           
            txtSqDiag.Text = ssApplyPat.Zy_Patlist.DiseaseName;
            txtTendOpera.Text = ssApplyPat.TEND_OPERA.ToString();
            txtTend_Anesth.Text = ssApplyPat.TEND_ANESTH.ToString();
            dtOperaTime.Text = ssApplyPat.TEND_OPERADATE.ToString();
            txtDiag.Text = ssApplyPat.SS_DIAG.ToString();
            txtdiag1.Text = ssApplyPat.SS_DIAG2.ToString();
            txtDiag2.Text = ssApplyPat.SS_DIAG2.ToString();
            txtOtherOpera.Text = ssApplyPat.OTHER_OPERA.ToString();
            txtOtherOpera1.Text = ssApplyPat.OTHER_OPERA1.ToString();
            txtOtherOpera2.Text = ssApplyPat.OTHER_OPERA2.ToString();
            txtOtherOpera3.Text = ssApplyPat.OTHER_OPERA3.ToString();
            txtOperaDoc.Text = BaseData.GetUserName(ssApplyPat.OPERA_DOC.ToString());
            txtAssist.Text = BaseData.GetUserName(ssApplyPat.OPERA_ASSIST1.ToString());
            txtAssist1.Text = BaseData.GetUserName(ssApplyPat.OPERA_ASSIST2.ToString());
            txtAssist2.Text = BaseData.GetUserName(ssApplyPat.OPERA_ASSIST3.ToString());
             arrange = arrangeop.getArrange(ssApplyPat.APPLY_ID);
            txtWash_Nurse.Text = BaseData.GetUserName(arrange.WASH_NURSE.ToString());
            txtWash_Nurse1.Text = BaseData.GetUserName(arrange.WASH_NURSE1.ToString());
            txtWash_Nurse2.Text = BaseData.GetUserName(arrange.WASH_NURSE2.ToString());
            txtTourNurse.Text = BaseData.GetUserName(arrange.TOUR_NURSE.ToString());
            txtTourNurse1.Text = BaseData.GetUserName(arrange.TOUR_NURSE1.ToString());
            txtTourNurse2.Text = BaseData.GetUserName(arrange.TOUR_NURSE2.ToString());
            txtBed.Text = arrange.OPERA_ROOMBED.ToString();
            if (ssApplyPat.HBSAG.ToString() == "阳性")
            {
                radHbsag.Checked = true;
            }
            if (ssApplyPat.HBSAG.ToString() == "阴性")
            {
                radHbsag1.Checked = true;
            }
            if (ssApplyPat.HCV.ToString() == "阳性")
            {
                radHcv.Checked = true;
            }
            if (ssApplyPat.HCV.ToString() == "阴性")
            {
                radHcv1.Checked = true;
            }
            if (ssApplyPat.HIV.ToString() == "阳性")
            {
                radHiv.Checked = true;
            }
            if (ssApplyPat.HIV.ToString() == "阴性")
            {
                radHiv1.Checked = true;
            }
            if (ssApplyPat.TP.ToString() == "阳性")
            {
                radTp.Checked = true;
            }
            if (ssApplyPat.TP.ToString() == "阴性")
            {
                radTp1.Checked = true;
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            arrange.ACTUAL_OPERA = txtActual_opera.Text;
            arrange.ACTUAL_ANESTH = txtActual_Anesth.Text; 
            arrange.ACTUAL_ANESTH1 = txtActual_Anesth1.Text;
            arrange.FINISH_FLAG = 1;
            arrange.WASH_NURSE = Convert.ToInt32(XcConvert.IsNull(txtWash_Nurse.MemberValue, "0"));
            arrange.WASH_NURSE1 = Convert.ToInt32(XcConvert.IsNull(txtWash_Nurse1.MemberValue, "0"));
            arrange.WASH_NURSE2 = Convert.ToInt32(XcConvert.IsNull(txtWash_Nurse2.MemberValue, "0"));
            arrange.TOUR_NURSE = Convert.ToInt32(XcConvert.IsNull(txtTourNurse.MemberValue, "0"));
            arrange.TOUR_NURSE1 = Convert.ToInt32(XcConvert.IsNull(txtTourNurse1.MemberValue, "0"));
            arrange.TOUR_NURSE2 = Convert.ToInt32(XcConvert.IsNull(txtTourNurse2.MemberValue, "0"));
            arrange.OPERA_BEGINTIME = dtBegin.Value;
            arrange.OPERA_ENDTIME = dtEnd.Value;
            arrange.OPERA_GRADE = txtGrade.Text;
            arrange.ANESTH_DOC = Convert.ToInt32(XcConvert.IsNull(txtAnesthDoc.MemberValue, "0"));
            arrange.ANESTH_DOC1 = Convert.ToInt32(XcConvert.IsNull(txtAnesthDoc1.MemberValue, "0"));
            arrange.OPERA_FINISHDOC = employeeid;


            ssApplyPat.SS_DIAG = txtDiag.Text;
            ssApplyPat.SS_DIAG1 = txtdiag1.Text;
            ssApplyPat.SS_DIAG2 = txtDiag2.Text;
            ssApplyPat.AFTERSS_DIAG = txtShDiag.Text;
            ssApplyPat.OTHER_OPERA = txtOtherOpera.Text;
            ssApplyPat.OTHER_OPERA1 = txtOtherOpera1.Text;
            ssApplyPat.OTHER_OPERA2 = txtOtherOpera2.Text;
            ssApplyPat.OTHER_OPERA3 = txtOtherOpera3.Text;
            if (txtOperaDoc.Text == "")
            {
                MessageBox.Show("请选择主刀医生");
                txtOperaDoc.Focus();
                return;
            }
            ssApplyPat.OPERA_DOC = Convert.ToInt32(XcConvert.IsNull(txtOperaDoc.MemberValue, "0"));
            ssApplyPat.OPERA_ASSIST1 = Convert.ToInt32(XcConvert.IsNull(txtAssist.MemberValue, "0"));
            ssApplyPat.OPERA_ASSIST2 = Convert.ToInt32(XcConvert.IsNull(txtAssist1.MemberValue, "0"));
            ssApplyPat.OPERA_ASSIST3 = Convert.ToInt32(XcConvert.IsNull(txtAssist2.MemberValue, "0"));
            if (arrangeop.AfterSsInfo(ssApplyPat, arrange))
            {
                MessageBox.Show("术后补录成功");
                btnSave.Enabled = false;
            }
        }

        private void txtDiag2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtOtherOpera.Focus();
            }
        }

       
      
    }
}
