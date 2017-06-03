using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HIS.BLL;
using HIS.SYSTEM.BussinessLogicLayer.Classes;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.ZYNurse_BLL;
using GWI.HIS.Windows.Controls;

namespace HIS_ZYNurseManager
{
    public partial class AccountCheck : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private bool _isInitialize = true;
        int patlistid;
        int ordertype;
        int groupid;
        List<int> presorderidlist = new List<int>();

        OP_Bed op_bed = new OP_Bed();
        OP_Order op_order = new OP_Order();       

        #region 构造函数
        public AccountCheck(int order_id,int patlist_id,int order_tyep,int group_id)
        {
            InitializeComponent();
            int orderid = order_id;
            this.patlistid = patlist_id;
            this.ordertype = order_tyep;
            this.groupid = group_id;
            dtgcanfee.AutoGenerateColumns = false;
            loadpatinfo(patlistid);
            dtgcanfee.DataSource = op_order.getCancelAccountInfo(orderid);
        }
        public AccountCheck(int patlist_id,List<int> order_list)
        {
            InitializeComponent();
            this.patlistid = patlist_id;
            List<int> orderlist = order_list;
            loadpatinfo(patlistid);
            dtgcanfee.AutoGenerateColumns = false;           
            dtgcanfee.DataSource = op_order.getCancelFeeInfo(orderlist);
            DataTable dt = op_order.getPresorder(orderlist);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int presorderid = Convert.ToInt32(dt.Rows[i][0].ToString());
                presorderidlist.Add(presorderid);
            }
        }
        #endregion 
        /// <summary>
        /// 加载病人相关信息
        /// </summary>
        /// <param name="patlistid"></param>
        private void loadpatinfo(int patlistid)
        {
            if (patlistid != 0)
            {
                inPatientPanel1.InPaitent = new ApplyIInPatient(patlistid);
            }
            //    PublicClass patient = new PublicClass();
            //    DataTable patdt = op_bed.getPatInfo(patlistid);
            //    patient.InpitentNo = patdt.Rows[0][0].ToString();
            //    patient.InDate = Convert.ToDateTime(patdt.Rows[0][1].ToString()) ;
            //    patient.InDisease = new BindValue("", patdt.Rows[0][2].ToString());
            //    patient.CurrentDepartment = new BindValue("",patdt.Rows[0][3].ToString());
            //    patient.InDepartment =new BindValue("", patdt.Rows[0][4].ToString());
            //    patient.PatientName = patdt.Rows[0][5].ToString();
            //    patient.Sex = patdt.Rows[0][6].ToString();
            //    patient.PatientType = new BindValue("",patdt.Rows[0][7].ToString());
            //    patient.BedNo = patdt.Rows[0][8].ToString();
            //    patient.EconomyDoctor = new GWI.HIS.Windows.Controls.BindValue("",patdt.Rows[0][9].ToString());
            //    patient.TendInfo = "";                    
            //    patient.CureDoctor=new GWI.HIS.Windows.Controls.BindValue(null,"");;
            //    patient.Nurse=new GWI.HIS.Windows.Controls.BindValue(null, "");
            //    patient.BordDay=Convert.ToDateTime(patdt.Rows[0]["patbridate"].ToString());
            //    HIS.ZY_BLL.ObjectModel.CostManager.IcostManager IcM = HIS.ZY_BLL.ObjectModel.ObjectFactory.GetObject<HIS.ZY_BLL.ObjectModel.CostManager.IcostManager>(typeof(HIS.ZY_BLL.DataModel.ZY_CostMaster));
            //    IcM.PatListID = patlistid;
            //    patient.BalanceFee = IcM.GetPatFee().surplusFee;
            //    patient.PrePayFee = IcM.GetPatFee().chargeFee;
            //    inPatientPanel1.InPaitent =patient;
            //}
            //else
            //{
            //    PublicClass patient = new PublicClass();
            //    patient.InpitentNo = "";
            //    patient.InDate = Convert.ToDateTime(null);
            //    patient.InDisease = new GWI.HIS.Windows.Controls.BindValue(null, "");
            //    patient.CurrentDepartment = new GWI.HIS.Windows.Controls.BindValue(null, "");
            //    patient.InDepartment = new GWI.HIS.Windows.Controls.BindValue(null, "");
            //    patient.PatientName = "";
            //    patient.Sex ="";
            //    patient.PatientType = new GWI.HIS.Windows.Controls.BindValue(null, "");
            //    patient.BedNo = "";
            //    patient.EconomyDoctor = new GWI.HIS.Windows.Controls.BindValue(null, "");
            //    patient.TendInfo ="";
            //    patient.CureDoctor = new GWI.HIS.Windows.Controls.BindValue(null, ""); ;
            //    patient.Nurse = new GWI.HIS.Windows.Controls.BindValue(null, "");
            //    patient.BordDay = Convert.ToDateTime(null);
            //    patient.BalanceFee =Convert.ToDecimal(null);
            //    patient.PrePayFee = Convert.ToDecimal(null);
            //    inPatientPanel1.InPaitent = patient;
            //}
        }
        /// <summary>
        /// 输入冲正数量
        /// </summary>
        private void loadfrmamount()
        {         
            FrmCanAmount frmamount = new FrmCanAmount();
            frmamount.MdiParent = this.MdiParent;
            frmamount.WindowState = FormWindowState.Normal;
            frmamount.ShowDialog();
            decimal amount = frmamount.Amount;
        }
       /// <summary>
       /// 选择冲正项(冲正项分组)
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void dtgcanfee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 0)
            {
                if (chkcanfeetype.Checked == false)
                {
                    int rownum = e.RowIndex;
                    DateTime datetime = Convert.ToDateTime(dtgcanfee[Column3.Name, rownum].Value.ToString());
                    if (Convert.ToBoolean(dtgcanfee[Column1.Name, rownum].Value) == false)
                    {
                        for (int i = 0; i < dtgcanfee.Rows.Count; i++)
                        {
                            DateTime tempdatetime = Convert.ToDateTime(dtgcanfee[Column3.Name, i].Value.ToString());
                            if (datetime == tempdatetime)
                            {
                                dtgcanfee[Column1.Name, i].Value = true;
                                for (int k = 0; k < dtgcanfee.Columns.Count; k++)
                                {
                                    dtgcanfee.Rows[i].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                                    dtgcanfee.Rows[i].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }                       
                    }
                    else
                    {
                        for (int i = 0; i < dtgcanfee.Rows.Count; i++)
                        {
                            DateTime tempdatetime = Convert.ToDateTime(dtgcanfee[Column3.Name, i].Value.ToString());
                            if (datetime == tempdatetime)
                            {
                                dtgcanfee[Column1.Name, i].Value = false;
                                for (int k = 0; k < dtgcanfee.Columns.Count; k++)
                                {
                                    dtgcanfee.Rows[i].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
                                    dtgcanfee.Rows[i].Cells[k].Style.BackColor = System.Drawing.Color.White;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }                       
                    }
                }
                else
                {
                    int rownum = e.RowIndex;
                    if (Convert.ToBoolean(dtgcanfee[Column1.Name, rownum].Value) == false)
                    {                       
                        dtgcanfee[Column1.Name, rownum].Value = true;
                        for (int k = 0; k < dtgcanfee.Columns.Count; k++)
                        {
                            dtgcanfee.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                            dtgcanfee.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }                       
                    }
                    else
                    {
                        dtgcanfee[Column1.Name, rownum].Value = false;
                        {
                            for (int k = 0; k < dtgcanfee.Columns.Count; k++)
                            {
                                dtgcanfee.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
                                dtgcanfee.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.White;
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 成组费用冲正操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btncanfee_Click(object sender, EventArgs e)
        {           
            int preorderid;
            DateTime datetime;
            bool cancelresult;
            List<DateTime> datelist = new List<DateTime>();
            List<int> canorderlist = new List<int>();
            for (int rownum = 0; rownum< dtgcanfee.Rows.Count; rownum++)
            {
                if (Convert.ToBoolean(dtgcanfee[Column1.Name, rownum].Value) == true)
                {
                    int flag = Convert.ToInt32(dtgcanfee[Column9.Name, rownum].Value.ToString());
                    if (flag == 0)
                    {
                        datetime = Convert.ToDateTime(dtgcanfee[Column3.Name, rownum].Value.ToString());
                        int presorderid = Convert.ToInt32(dtgcanfee[Column12.Name, rownum].Value.ToString());
                        datelist.Add(datetime);
                        canorderlist.Add(presorderid);
                    }
                    else
                    {
                        MessageBox.Show("该组费用不能进行冲正操作!", "提示", MessageBoxButtons.OK,MessageBoxIcon.Stop);
                        return;
                    }
                }
            }
            if (datelist.Count == 0)
            {
                MessageBox.Show("您还未选择冲正医嘱，请选择医嘱后再进行冲正操作!", "提示", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else
            {
                //loadfrmamount();
                int patlistid=Convert.ToInt32(dtgcanfee[Column11.Name,0].Value.ToString());
                bool result = op_order.getresult(canorderlist);
                if(result)
                {
                    cancelresult = op_order.canaccount(patlistid,canorderlist , datelist);
                }
                else
                {
                    MessageBox.Show("该组医嘱不能再次进行冲正操作!", "提示", MessageBoxButtons.OK,MessageBoxIcon.Stop);
                    return;
                }
                if (cancelresult == true)
                {
                    MessageBox.Show("您的医嘱费用已成功冲正", "提示", MessageBoxButtons.OK);
                    DataTable dt = op_order.getCanaccount(presorderidlist);
                    dtgcanfee.DataSource = dt;                    
                }
                else
                {
                    MessageBox.Show("您的费用冲正操作失败", "提示", MessageBoxButtons.OK);
                }
           }
        }        
        /// <summary>
        /// 成组取消冲正操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnexitfee_Click(object sender, EventArgs e)
        {
            int preorderid;
            DateTime datetime;
            bool cancelresult;
            List<int> list= new List<int>();
            List<DateTime> datelist = new List<DateTime>();

            for (int rownum = 0; rownum < dtgcanfee.Rows.Count; rownum++)
            {
                if (Convert.ToBoolean(dtgcanfee[Column1.Name, rownum].Value) == true)
                {
                    int flag = Convert.ToInt32(dtgcanfee[Column9.Name, rownum].Value.ToString());
                    if (flag == 1)
                    {
                        preorderid = Convert.ToInt32(dtgcanfee[Column10.Name, rownum].Value.ToString());
                        datetime = Convert.ToDateTime(dtgcanfee[Column3.Name, rownum].Value.ToString());
                        list.Add(preorderid);
                        datelist.Add(datetime);
                    }
                    else
                    {
                        MessageBox.Show("该组费用不能进行取消冲正操作!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }
            }
            if (datelist.Count == 0)
            {
                MessageBox.Show("您还未选择取消冲正项，请选择冲正项后再进行操作!", "提示", MessageBoxButtons.OK);
                return;
            }
            else
            {
                int patlistid = Convert.ToInt32(dtgcanfee[Column11.Name, 0].Value.ToString());
                bool result = op_order.getexitresult(presorderidlist);
                if (result)
                {
                    cancelresult = op_order.exitcanaccount(patlistid,list, datelist);
                }
                else
                {
                    MessageBox.Show("您该组医嘱已经取消冲正过，不能再次进行冲正操作!", "提示", MessageBoxButtons.OK);
                    return;
                }
                if (cancelresult == true)
                {
                    
                    MessageBox.Show("您的取消冲正操作成功！", "提示", MessageBoxButtons.OK);
                    DataTable dt = op_order.getCanaccount(presorderidlist);
                    dtgcanfee.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("您的费用冲正操作失败", "提示", MessageBoxButtons.OK);
                }
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            if (_isInitialize)
            {
                this.panel3.Height = this.inPatientPanel1.Height;
                _isInitialize = false;
            }
        }

        ///// <summary>
        ///// 单条费用冲正操作
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btncanfee_Click(object sender, EventArgs e)
        //{
        //    int preorderid;
        //    DateTime datetime;
        //    bool cancelresult;
        //    List<DateTime> datelist = new List<DateTime>();
        //    List<int> singleprelist = new List<int>();
        //    for (int rownum = 0; rownum < dtgcanfee.Rows.Count; rownum++)
        //    {
        //        if (Convert.ToBoolean(dtgcanfee[Column1.Name, rownum].Value) == true)
        //        {
        //            int flag = Convert.ToInt32(dtgcanfee[Column9.Name, rownum].Value.ToString());
        //            if (flag == 0)
        //            {
        //                datetime = Convert.ToDateTime(dtgcanfee[Column3.Name, rownum].Value.ToString());
        //                int presorderid = Convert.ToInt32(dtgcanfee[Column12.Name, rownum].Value.ToString());
        //                datelist.Add(datetime);
        //                singleprelist.Add(presorderid);
        //            }
        //            else
        //            {
        //                MessageBox.Show("该条医嘱不能进行冲正操作!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //                return;
        //            }
        //        }
        //    }
        //    if (datelist.Count == 0)
        //    {
        //        MessageBox.Show("您还未选择冲正医嘱，请选择医嘱后再进行冲正操作!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }
        //    else
        //    {
        //    //    //loadfrmamount();
        //    int patlistid = Convert.ToInt32(dtgcanfee[Column11.Name, 0].Value.ToString());
        //    bool result = op_order.getresult(singleprelist);
        //    if (result)
        //    {
        //        cancelresult = op_order.canaccount(patlistid, presorderidlist, datelist);
        //    }
        //    else
        //    {
        //        MessageBox.Show("该条医嘱不能再次进行冲正操作!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //        return;
        //    }
        //        if (cancelresult == true)
        //        {
        //            MessageBox.Show("您的医嘱费用已成功冲正", "提示", MessageBoxButtons.OK);
        //            DataTable dt = op_order.getCanaccount(presorderidlist);
        //            dtgcanfee.DataSource = dt;
        //        }
        //        else
        //        {
        //            MessageBox.Show("您的费用冲正操作失败", "提示", MessageBoxButtons.OK);
        //        }
        //    }
        //}
        ///// <summary>
        ///// 单条取消冲正操作
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnexitfee_Click(object sender, EventArgs e)
        //{
        //    int preorderid;
        //    DateTime datetime;
        //    bool cancelresult;
        //    List<int> list = new List<int>();
        //    List<DateTime> datelist = new List<DateTime>();

        //    for (int rownum = 0; rownum < dtgcanfee.Rows.Count; rownum++)
        //    {
        //        if (Convert.ToBoolean(dtgcanfee[Column1.Name, rownum].Value) == true)
        //        {
        //            int flag = Convert.ToInt32(dtgcanfee[Column9.Name, rownum].Value.ToString());
        //            if (flag == 1)
        //            {
        //                preorderid = Convert.ToInt32(dtgcanfee[Column10.Name, rownum].Value.ToString());
        //                datetime = Convert.ToDateTime(dtgcanfee[Column3.Name, rownum].Value.ToString());
        //                list.Add(preorderid);
        //                datelist.Add(datetime);
        //            }
        //            else
        //            {
        //                MessageBox.Show("该组费用不能进行取消冲正操作!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //                return;
        //            }
        //        }
        //    }
        //    if (datelist.Count == 0)
        //    {
        //        MessageBox.Show("您还未选择取消冲正项，请选择冲正项后再进行操作!", "提示", MessageBoxButtons.OK);
        //        return;
        //    }
        //    else
        //    {
        //        int patlistid = Convert.ToInt32(dtgcanfee[Column11.Name, 0].Value.ToString());
        //        bool result = op_order.getexitresult(presorderidlist);
        //        if (result)
        //        {
        //            cancelresult = op_order.exitcanaccount(patlistid, list, datelist);
        //        }
        //        else
        //        {
        //            MessageBox.Show("您该组医嘱已经取消冲正过，不能再次进行冲正操作!", "提示", MessageBoxButtons.OK);
        //            return;
        //        }
        //        if (cancelresult == true)
        //        {

        //            MessageBox.Show("您的取消冲正操作成功！", "提示", MessageBoxButtons.OK);
        //            DataTable dt = op_order.getCanaccount(presorderidlist);
        //            dtgcanfee.DataSource = dt;
        //        }
        //        else
        //        {
        //            MessageBox.Show("您的费用冲正操作失败", "提示", MessageBoxButtons.OK);
        //        }
        //    }
        //}

    }
}