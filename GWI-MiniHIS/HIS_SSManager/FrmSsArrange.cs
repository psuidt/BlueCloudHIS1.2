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
    public partial class FrmSsArrange : GWI.HIS.Windows.Controls.BaseForm
    {
        private HIS.Model.SS_APPLY ssApplyPat;
        private DataTable nurses = new DataTable();
        private DataTable beds = new DataTable();
        private int userid;
        HIS.Model.SS_ARRANGE arrange;
        HIS.SS_BLL.SsArrange arrangeop;
        public FrmSsArrange(HIS.Model.SS_APPLY _ssapplypat,int _userid)
        {
            InitializeComponent();
            ssApplyPat = _ssapplypat;
            userid = _userid;
            arrangeop = new HIS.SS_BLL.SsArrange();
           PatientControl patient = new PatientControl();
            this.inPatientPanel1.InPaitent = patient.SetData(ssApplyPat.Zy_Patlist);
            GetData();
            nurses = HIS.SS_BLL.BaseInfo.GetNurse();
            beds = HIS.SS_BLL.BaseInfo.GetSsRoom();
            txtWash_Nurse.SetSelectionCardDataSource(nurses);
            txtWash_Nurse1.SetSelectionCardDataSource(nurses);
            txtWash_Nurse2.SetSelectionCardDataSource(nurses);
            txtTourNurse.SetSelectionCardDataSource(nurses);
            txtTourNurse1.SetSelectionCardDataSource(nurses);
            txtTourNurse2.SetSelectionCardDataSource(nurses);
            txtRoom.SetSelectionCardDataSource(beds);
        }
        //手术申请信息赋值
        private void GetData()
        {
            txtHeight.Text = ssApplyPat.PAT_HEIGHT.ToString();
            txtWeight.Text = ssApplyPat.PAT_WEIGHT.ToString();
            txtAllergy.Text = ssApplyPat.DRUG_ALLERGY.ToString();
            txtDiag.Text = ssApplyPat.SS_DIAG.ToString();
            txtdiag1.Text = ssApplyPat.SS_DIAG1.ToString();
            txtDiag2.Text = ssApplyPat.SS_DIAG2.ToString();
            txtTendOpera.Text = ssApplyPat.TEND_OPERA.ToString();
            txtTend_Anesth.Text = ssApplyPat.TEND_ANESTH.ToString();
            txtBody.Text = ssApplyPat.OPERA_BODY.ToString();
            txtOtherOpera.Text = ssApplyPat.OTHER_OPERA.ToString();
            txtOtherOpera1.Text = ssApplyPat.OTHER_OPERA1.ToString();
            txtOtherOpera2.Text = ssApplyPat.OTHER_OPERA2.ToString();
            txtOtherOpera3.Text = ssApplyPat.OTHER_OPERA3.ToString();
            txtAppliance.Text = ssApplyPat.OPERA_APPLIANCE.ToString();
            txtAppliance1.Text = ssApplyPat.OPERA_APPLIANCE1.ToString();
            txtAppliance2.Text = ssApplyPat.OPERA_APPLIANCE2.ToString();
            txtAppliance3.Text = ssApplyPat.OPERA_APPLIANCE3.ToString();
            txttendDrug.Text = ssApplyPat.TEND_OPERADRUG.ToString();
            txttendDrug1.Text = ssApplyPat.TEND_OPERADRUG1.ToString();
            txttendDrug2.Text = ssApplyPat.TEND_OPERADRUG2.ToString();
            txttendDrug3.Text = ssApplyPat.TEND_OPERADRUG3.ToString();
            txtOperaDoc.Text = BaseData.GetUserName(ssApplyPat.OPERA_DOC.ToString());
            txtAssist.Text = BaseData.GetUserName(ssApplyPat.OPERA_ASSIST1.ToString());
            txtAssist1.Text = BaseData.GetUserName(ssApplyPat.OPERA_ASSIST2.ToString());
            txtAssist2.Text = BaseData.GetUserName(ssApplyPat.OPERA_ASSIST3.ToString());
            dtTendData.Text = ssApplyPat.TEND_OPERADATE.ToString();
            txtMemo.Text = ssApplyPat.OPERA_MEMO.ToString();
            txtOperaDept.Text = BaseData.GetDeptName(ssApplyPat.OPERA_DEPT.ToString());
            txtVisit.Text=BaseData.GetUserName(ssApplyPat.OPERA_VISIT.ToString());
            txtVisit1.Text=BaseData.GetUserName(ssApplyPat.OPERA_VISIT1.ToString());     
            if(ssApplyPat.HBSAG.ToString()=="阳性")
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
            if (ssApplyPat.EMERGENCY_OPERA == 1)
            {
                chkEmergency.Checked = true;
            }
            if (ssApplyPat.OPERA_CONSENT == 1)
            {
                chkOpeConsent.Checked = true;
            }
            if (ssApplyPat.ANESTH_CONSENT == 1)
            {
                chkAnesConsent.Checked = true;
            }
            arrange=arrangeop.GetNotFinishApply(ssApplyPat.APPLY_ID) ;
            if (arrange != null)
            {
                txtWash_Nurse.Text = BaseData.GetUserName(arrange.WASH_NURSE.ToString());
                txtWash_Nurse.MemberValue = arrange.WASH_NURSE.ToString();
                txtWash_Nurse1.Text = BaseData.GetUserName(arrange.WASH_NURSE1.ToString());
                txtWash_Nurse1.MemberValue = arrange.WASH_NURSE1.ToString();
                txtWash_Nurse2.Text = BaseData.GetUserName(arrange.WASH_NURSE2.ToString());
                txtWash_Nurse2.MemberValue = arrange.WASH_NURSE2.ToString();
                txtTourNurse.Text = BaseData.GetUserName(arrange.TOUR_NURSE.ToString());
                txtTourNurse.MemberValue = arrange.TOUR_NURSE.ToString();
                txtTourNurse1.Text = BaseData.GetUserName(arrange.TOUR_NURSE1.ToString());
                txtTourNurse1.MemberValue = arrange.TOUR_NURSE1.ToString();
                txtTourNurse2.Text = BaseData.GetUserName(arrange.TOUR_NURSE2.ToString());
                txtTourNurse2.MemberValue = arrange.TOUR_NURSE2.ToString();
                txtRoom.Text = arrange.OPERA_ROOMBED.ToString();
                dtOperaTime.Text = arrange.OPERA_DATE.ToString();
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //保存手术安排信息
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (arrange == null)
            {
                arrange = new HIS.Model.SS_ARRANGE();
            }
            arrange.WASH_NURSE = Convert.ToInt32(XcConvert.IsNull(txtWash_Nurse.MemberValue, "0"));
            arrange.WASH_NURSE1 = Convert.ToInt32(XcConvert.IsNull(txtWash_Nurse1.MemberValue, "0"));
            arrange.WASH_NURSE2 = Convert.ToInt32(XcConvert.IsNull(txtWash_Nurse2.MemberValue, "0"));
            if (txtRoom.Text == "")
            {
                MessageBox.Show("请选择手术台次");  //* 20100521.2.02 手术安排时没有填手术台次时，光标定位到手术台次框中
                txtRoom.Focus();
                return;
            }
            arrange.OPERA_ROOMBED = txtRoom.Text;
            arrange.OPERA_DOC = userid;
            arrange.PATLISTID = ssApplyPat.PATLISTID;
            arrange.APPLY_ID = ssApplyPat.APPLY_ID;
            arrange.ARRAGE_TIME = XcDate.ServerDateTime;
            arrange.FINISH_FLAG = 0;
            arrange.DELETE_FLAG = 0;
            arrange.OPERA_DATE = dtOperaTime.Value;
            arrange.TOUR_NURSE = Convert.ToInt32(XcConvert.IsNull(txtTourNurse.MemberValue, "0"));
            arrange.TOUR_NURSE1 = Convert.ToInt32(XcConvert.IsNull(txtTourNurse1.MemberValue, "0"));
            arrange.TOUR_NURSE2 = Convert.ToInt32(XcConvert.IsNull(txtTourNurse2.MemberValue, "0"));            
            int emropera=0;
            int anesth=0;
            int opera=0;
            if (chkEmergency.Checked)
            {
                emropera = 1;
            }
            else
            {
                emropera = 0;
            }
            if (chkAnesConsent.Checked)
            {
                anesth = 1;
            }
            else
            {
                anesth= 0;
            }
            if (chkOpeConsent.Checked)
            {
                opera = 1;
            }
            else
            {
                opera= 0;
            }
            if (arrangeop.SaveArrange(arrange, txtRoom.Text, emropera, anesth, opera))
            {
                MessageBox.Show("手术安排完成");
                btnSave.Enabled = false;
                this.Close();
            }         
        }    

    }
}
