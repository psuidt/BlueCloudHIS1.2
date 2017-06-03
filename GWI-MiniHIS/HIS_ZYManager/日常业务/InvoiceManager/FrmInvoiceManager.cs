using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.SYSTEM.BussinessLogicLayer.Classes;

namespace HIS_ZYManager.InvoiceManager
{
    public partial class FrmInvoiceManager : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private GWMHIS.BussinessLogicLayer.Classes.User user;
        /// <summary>
        /// 设置发票停用状态
        /// </summary>
        private void SetInvoiceStatsu()
        {
            try
            {
                if ( MessageBox.Show( "确定要停用该卷发票吗？" , "" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.No )
                    return;

                if ( dgvInvoiceList.Rows.Count == 0 )
                    return;

                int id = Convert.ToInt32( dgvInvoiceList["ID" , dgvInvoiceList.CurrentCell.RowIndex].Value );

                HIS.ZY_BLL.InvoiceManager.InvoiceManager.SetInvoiceNoUsed( id );

                ShowGridList(GetStatusFilterString());
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
        }

        public FrmInvoiceManager(string FormText, long _currentUserId)
        {
            InitializeComponent();

            this.Text = FormText;
            this.FormTitle = FormText;
            user = new GWMHIS.BussinessLogicLayer.Classes.User(_currentUserId);
        }

        
        private void FrmInvoiceManager_Load( object sender , EventArgs e )
        {
            cboAllotUser.DisplayField = "NAME";
            
            //cboAllotUser.SearchKeyFiled = new string[] { "PY_CODE" , "WB_CODE" };
            cboAllotUser.SetSelectionCardDataSource( BaseData.GetUserData() );

            if ( chkAllotDate.Checked )
            {
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
            }
            else
            {
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
            }
            if ( chkAllotUser.Checked )
            {
                cboAllotUser.Enabled = true;
            }
            else
                cboAllotUser.Enabled = false;

            //ShowGridList();

            chkInuse.CheckedChanged += new EventHandler( chkStatusCheckBox_CheckedChanged );
            chkReadyUse.CheckedChanged += new EventHandler( chkStatusCheckBox_CheckedChanged );
            chkUseEnd.CheckedChanged += new EventHandler( chkStatusCheckBox_CheckedChanged );
            chkUnUsed.CheckedChanged += new EventHandler( chkStatusCheckBox_CheckedChanged );

            //btnFind_Click( null , null );
            //panel1.Font = new Font( "宋体", 9F );
            //panel2.Font = new Font( "宋体", 9F );
            //this.plBaseWorkArea.Font = new Font( "宋体", 9F );
        }

        
        private void chkAllotDate_CheckedChanged( object sender , EventArgs e )
        {
            if ( chkAllotDate.Checked )
            {
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
            }
            else
            {
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
            }
        }

        private void chkAllotUser_CheckedChanged( object sender , EventArgs e )
        {
            if ( chkAllotUser.Checked )
            {
                cboAllotUser.Enabled = true;
            }
            else
                cboAllotUser.Enabled = false;

        }

        private void btnFind_Click( object sender , EventArgs e )
        {
            string filter = GetStatusFilterString();
            if ( chkAllotDate.Checked )
            {
                if ( filter!= "")
                    filter += " and allot_date >='" + dtpFrom.Value.ToString( "yyyy-MM-dd HH:mm:ss" ) + "' and allot_date<='" + dtpTo.Value.ToString( "yyyy-MM-dd HH:mm:ss" ) + "'";
                else
                    filter += " allot_date >='" + dtpFrom.Value.ToString( "yyyy-MM-dd HH:mm:ss" ) + "' and allot_date<='" + dtpTo.Value.ToString( "yyyy-MM-dd HH:mm:ss" ) + "'";
            }
            if ( chkAllotUser.Checked && cboAllotUser.Text.Trim() != "" )
            {
                if ( filter != "" )
                {
                    filter += " and USERNAME ='" + cboAllotUser.Text + "'";
                }
                else
                {
                    filter += " USERNAME ='" + cboAllotUser.Text + "'";
                }
            }
            try
            {
                ShowGridList( filter );
            }
            catch
            {
            }
        }

        private void ShowGridList(string filter)
        {
            dgvInvoiceList.DataSource = HIS.ZY_BLL.InvoiceManager.InvoiceManager.GetInvoiceRecord().DefaultView;
            ((DataView)dgvInvoiceList.DataSource).RowFilter = filter;
            SetGridColor();
        }

        private void SetGridColor()
        {
            foreach ( DataGridViewRow row in dgvInvoiceList.Rows )
            {
                short status_flag = Convert.ToInt16( row.Cells["status_flag"].Value );
                foreach ( DataGridViewCell cell in row.Cells )
                {
                    Color foreColor = Color.Blue;
                    switch ( status_flag )
                    {
                        case 0:
                            foreColor = Color.Blue;
                            break;
                        case 1:
                            foreColor = Color.Gray;
                            break;
                        case 2:
                            foreColor = Color.DarkGreen;
                            break;
                        case 3:
                            foreColor = Color.DarkRed;
                            break;
                    }
                    cell.Style.ForeColor = foreColor;
                }
            }
        }

        private string GetStatusFilterString()
        {
            string status = "";
            if ( chkInuse.Checked )
            {
                status += "status_flag = 0 or ";
            }
            if ( chkReadyUse.Checked )
            {
                status += "status_flag = 2 or ";
            }
            if ( chkUseEnd.Checked )
            {
                status += "status_flag = 1 or ";
            }
            if ( chkUnUsed.Checked )
            {
                status += "status_flag = 3 or ";
            }
            if ( status != "" )
            {
                status = status.Remove( status.Length - 3 , 2 );
                return "(" + status + ")";
            }
            else
                return "";
        }

        private void chkStatusCheckBox_CheckedChanged( object sender , EventArgs e )
        {
            ShowGridList( GetStatusFilterString() );   
        }

        private void btnClose_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        private void btnDelete_Click( object sender, EventArgs e )
        {
            if ( dgvInvoiceList.Rows.Count == 0 )
                return;

            if ( MessageBox.Show( "确定要删除该卷发票记录吗？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.No )
                return;

            try
            {

                int volId = Convert.ToInt32( dgvInvoiceList["ID", dgvInvoiceList.CurrentRow.Index].Value );
                if ( HIS.ZY_BLL.InvoiceManager.InvoiceManager.DeleteInvoiceVolumn( volId ) )
                {
                    ShowGridList( GetStatusFilterString() );
                }
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private void btnRefresh_Click( object sender, EventArgs e )
        {
            ShowGridList( GetStatusFilterString() );
        }

        private void btnCallOf_Click( object sender, EventArgs e )
        {
            if ( dgvInvoiceList.Rows.Count == 0 )
                return;

            SetInvoiceStatsu();
        }

        private void btnNewAllot_Click( object sender, EventArgs e )
        {
            FrmAllotInvoice frm = new FrmAllotInvoice( user );
            frm.ShowDialog();
            ShowGridList( GetStatusFilterString() );
        }

        private void dgvInvoiceList_CurrentCellChanged( object sender , EventArgs e )
        {
            if (dgvInvoiceList.CurrentCell == null)
                return;
            if (dgvInvoiceList.Rows.Count == 0)
                return;
            int row = dgvInvoiceList.CurrentCell.RowIndex;
            string startNo = dgvInvoiceList[START_NO.Name, row].Value.ToString().Trim();
            string endNo = dgvInvoiceList[END_NO.Name, row].Value.ToString().Trim();
            string perfChar = dgvInvoiceList[PERFCHAR.Name, row].Value.ToString().Trim();
            string indexNo = dgvInvoiceList[Column7.Name, row].Value.ToString().Trim();

            txtStart.Text = startNo;
            txtEnd.Text = endNo;
            txtAllCount.Text = (Convert.ToInt64(endNo) - Convert.ToInt64(startNo) + 1).ToString();

            decimal totalMoney = 0;
            int totalCount = 0;
            decimal refundMoney = 0;
            int refundCount = 0;
            try
            {
                HIS.ZY_BLL.InvoiceManager.InvoiceManager.GetInvoiceListInfo(perfChar, startNo, indexNo, out totalMoney, out totalCount, out refundMoney, out refundCount);

                txtTotalMoney.Text = totalMoney.ToString();
                txtCount.Text = totalCount.ToString();
                txtRefundCount.Text = refundCount.ToString();
                txtRefundMoney.Text = refundMoney.ToString();
                //txtAllCount.Text = (Convert.ToInt64(endNo) - Convert.ToInt64(startNo) + 1).ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {

        }
    }
}
