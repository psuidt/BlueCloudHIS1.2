using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.YZCX_BLL;


namespace HIS_YZCXManager
{
    public partial class FrmManagerDiary : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private ManagerDiary _managerDiary;

        public FrmManagerDiary()
        {
            InitializeComponent();
        }

        private void lblBuildReport_MouseEnter(object sender, EventArgs e)
        {
            this.lblBuildReport.ForeColor = SystemColors.ActiveCaption;
        }

        private void lblBuildReport_MouseLeave(object sender, EventArgs e)
        {
            this.lblBuildReport.ForeColor = SystemColors.ControlText;
        }

        private void lblQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblQuit_MouseEnter(object sender, EventArgs e)
        {
            this.lblQuit.ForeColor = SystemColors.ActiveCaption;
        }

        private void lblQuit_MouseLeave(object sender, EventArgs e)
        {
            this.lblQuit.ForeColor = SystemColors.ControlText;
        }

        private void lblBuildReport_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                _managerDiary = new ManagerDiary();
                LoadData();
                ShowManagerDiary();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                this.Cursor = DefaultCursor;
            }
        }

        private void LoadData()
        {
            try
            {
                MZ_Loader.SetManagerDiary(_managerDiary, cobBeginDate.Value, cobEndDate.Value);
                ZY_Loader.SetManagerDiary(_managerDiary, cobBeginDate.Value, cobEndDate.Value);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void ShowManagerDiary()
        {
            if (_managerDiary != null)
            {
                lblTotalFee.Text = _managerDiary.TotalFee.ToString("0.00") + "元";
                lblTotalFee_MZ.Text = _managerDiary.TotalFee_MZ.ToString("0.00") + "元";
                lblDrugFee_MZ.Text = _managerDiary.TotalFee_MZ_YP.ToString("0.00") + "元";
                if (_managerDiary.TotalFee_MZ != 0)
                {
                    lblDrugInverse_MZ.Text = (_managerDiary.TotalFee_MZ_YP / _managerDiary.TotalFee_MZ * 100).ToString("0.00") + "%";
                }
                if (_managerDiary.TotalFee_ZY != 0)
                {
                    lblDrugInverse_ZY.Text = (_managerDiary.TotalFee_ZY_YP / _managerDiary.TotalFee_ZY * 100).ToString("0.00") + "%";
                }
                lblTotalFee_ZY.Text = _managerDiary.TotalFee_ZY.ToString("0.00") + "元";
                lblDrugFee_ZY.Text = _managerDiary.TotalFee_ZY_YP.ToString("0.00") + "元";
                lblPopula_MZ.Text = _managerDiary.Mz_Population.ToString() + "人";
                lblPresFee.Text = _managerDiary.AveragePresFee_MZ.ToString("0.00") + "元";
                lblBillFee.Text = _managerDiary.AverageFee_MZ.ToString("0.00") + "元";
                lblAdmitNum.Text = _managerDiary.AdminNum_ZY.ToString() + "人";
                lblLeaveNum.Text = _managerDiary.LeaveNum_ZY.ToString() + "人";
                lblAtNum.Text = _managerDiary.AtNum_ZY.ToString() + "人";
                lblTotalDays.Text = _managerDiary.TatalDays_ZY.ToString() + "天";
                ShowGraph();
            }
        }

        private void ShowGraph()
        {
            if (_managerDiary.HSFee == null)
                return;

            DataTable tbData = _managerDiary.HSFee;
            TableColumn[] columns = new TableColumn[1];
            columns[0].ColumnName = "金额";
            columns[0].ColumnField = "TOTALFEE";
            GraphControl gc;
            DataTableStruct datatablestruct = DataTableStruct.Rows;
            Color[] colors = new Color[tbData.Rows.Count];
            Random random = new Random();
            for (int index = 0; index < tbData.Rows.Count; index++)
            {
                int red = random.Next(255);
                int blue = random.Next(255);
                int green = random.Next(255);
                colors[index] = Color.FromArgb(red, green, blue);
            }
            gc = new CakyGraphControl(this.pnlPictrue, datatablestruct, columns, colors, tbData, "ITEM_NAME", 0);
            string title = "医院收入示意图";
            gc.GraphTitle = title;
            gc.DrawGraph();
        } 


    }
}
