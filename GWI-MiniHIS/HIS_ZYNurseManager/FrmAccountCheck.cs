using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HIS.ZYNurse_BLL;
using GWI.HIS.Windows.Controls;
using HIS.SYSTEM.Core;
using HIS.Model;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.SYSTEM.BussinessLogicLayer.Classes;
using GWMHIS.BussinessLogicLayer.Classes;

namespace HIS_ZYNurseManager
{
    public partial class FrmAccountCheck : GWI.HIS.Windows.Controls.BaseMainForm
    {
        #region 属性及构造函数      
        private User _currentUser;
        public User currentUser
        {
            get
            {
                return _currentUser;
            }
        }
        private Deptment _currentDept;
        public Deptment currentDept
        {
            get
            {
                return _currentDept;
            }
        }
        
        OP_Order op_order = new OP_Order();
        List<int> presorderidlist = new List<int>();
        private int ordertype;
        private int patlistid;
        private int groupid;
        decimal amount;
     
        public FrmAccountCheck(long currentUserId, long currreentDeptId, string chineseName)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currreentDeptId);
            this.Text = chineseName;
            dtgpatlist.AutoGenerateColumns = false;
            dtgpatlist.DataSource = op_order.getPatList(Convert.ToInt32(_currentDept.DeptID));
            if (dtgpatlist.Rows.Count > 0)
            {
                patlistid = Convert.ToInt32(dtgpatlist[2, 0].Value.ToString());               
                dtgrdorder.AutoGenerateColumns = false;
                dtgrdorder.DataSource = op_order.getOrder(patlistid, 0);
            }
            else
            {
                dtgrdorder.DataSource = null;
            }
        }
        #endregion       
        /// <summary>
        /// 选中病人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgpatlist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable patdt = (DataTable)dtgpatlist.DataSource;
            patlistid = Convert.ToInt32(patdt.Rows[dtgpatlist.CurrentCell.RowIndex][1].ToString());
            if (radiobtnlong.Checked == true)
            {
                ordertype = 0;
                dtgrdorder.AutoGenerateColumns = false;
                radiobtnamount.Enabled = true;
                btnfeeinput.Enabled = true;
                dtgrdorder.DataSource = op_order.getAllOrder(patlistid, ordertype);
                dtgrdaccount.DataSource = null;
            }
            else if (radiobtntemp.Checked == true)
            {
                ordertype = 1;
                dtgrdorder.AutoGenerateColumns = false;
                radiobtnamount.Enabled = true;
                btnfeeinput.Enabled = true;
                dtgrdorder.DataSource = op_order.getAllTempOrder(patlistid, ordertype);
                dtgrdaccount.DataSource = null;
            }
            else if (radiobtnlongaccout.Checked == true)
            {
                ordertype = 2;
                dtgrdorder.AutoGenerateColumns = false;
                radiobtnamount.Enabled = false;
                btnfeeinput.Enabled = false;
                dtgrdorder.DataSource = op_order.getAllOrder(patlistid, ordertype);
                dtgrdaccount.DataSource = null;
            }
            else if (radiobtntempaccount.Checked == true)
            {
                ordertype = 3;
                dtgrdorder.AutoGenerateColumns = false;
                radiobtnamount.Enabled = false;
                btnfeeinput.Enabled = false;
                dtgrdorder.DataSource = op_order.getAllTempOrder(patlistid, ordertype);
                dtgrdaccount.DataSource = null;
            }
        }        
        /// <summary>
        /// 所有长期医嘱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radiobtnlong_Click(object sender, EventArgs e)
        {
            ordertype = 0;
            radiobtnamount.Enabled = true;
            btnfeeinput.Enabled = true;
            dtgrdorder.DataSource = op_order.getAllOrder(patlistid, ordertype);
            dtgrdaccount.DataSource = null;
        }
        /// <summary>
        /// 所有临时医嘱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radiobtntemp_Click(object sender, EventArgs e)
        {
            ordertype = 1;
            radiobtnamount.Enabled = true;
            btnfeeinput.Enabled = true;
            dtgrdorder.DataSource = op_order.getAllTempOrder(patlistid, ordertype);
            dtgrdaccount.DataSource = null;
        }
        /// <summary>
        /// 所有长期账单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radiobtnlongaccout_CheckedChanged(object sender, EventArgs e)
        {
            ordertype = 2;
            dtgrdorder.AutoGenerateColumns = false;
            radiobtnamount.Enabled = false;
            btnfeeinput.Enabled = false;
            dtgrdorder.DataSource = op_order.getAllOrder(patlistid, ordertype);
            dtgrdaccount.DataSource = null;
        }
        /// <summary>
        /// 所有临时账单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radiobtntempaccount_CheckedChanged(object sender, EventArgs e)
        {
            ordertype = 3;
            dtgrdorder.AutoGenerateColumns = false;
            radiobtnamount.Enabled = false;
            btnfeeinput.Enabled = false;
            dtgrdorder.DataSource = op_order.getAllTempOrder(patlistid, ordertype);
            dtgrdaccount.DataSource = null;
        }
        /// <summary>
        /// 医嘱选中分组及加载费用数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgrdorder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 0 && (radiobtnlong.Checked == true || radiobtntemp.Checked == true))
            {
                for (int rownum = 0; rownum < dtgrdorder.Rows.Count; rownum++)
                {
                    dtgrdorder[Column3.Name, rownum].Value = false;
                    for (int k = 0; k < dtgrdorder.Columns.Count; k++)
                    {
                        dtgrdorder.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
                        dtgrdorder.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.White;
                    }
                }
                int i = e.RowIndex;
                int group_id = Convert.ToInt32(dtgrdorder[Column16.Name, i].Value.ToString());
                if (Convert.ToBoolean(dtgrdorder[Column3.Name, i].Value) == false)//选中某一组医嘱项
                {
                    for (int j = 0; j < dtgrdorder.Rows.Count; j++)//成组选中
                    {
                        int tempgroupid = Convert.ToInt32(dtgrdorder[Column16.Name, j].Value.ToString());
                        if (group_id == tempgroupid)
                        {
                            dtgrdorder[Column3.Name, j].Value = true;
                            for (int k = 0; k < dtgrdorder.Columns.Count; k++)
                            {
                                dtgrdorder.Rows[j].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                                dtgrdorder.Rows[j].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    int orderid;

                    presorderidlist.Clear();
                    List<int> orderlist = new List<int>();
                    List<int> grouplist = new List<int>();
                    int rownum = dtgrdorder.Rows.Count;
                    for (int j = 0; j < dtgrdorder.Rows.Count; j++)
                    {
                        if (Convert.ToBoolean(dtgrdorder[Column3.Name, j].Value) == true)
                        {
                            orderid = Convert.ToInt32(dtgrdorder[Column12.Name, j].Value.ToString());
                            groupid = Convert.ToInt32(dtgrdorder[Column16.Name, j].Value.ToString());
                            orderlist.Add(orderid);
                            grouplist.Add(groupid);
                        }
                    }
                    dtgrdaccount.AutoGenerateColumns = false;
                    dtgrdaccount.DataSource = op_order.getCancelFeeInfo(orderlist);
                    DataTable dt = op_order.getPresorder(orderlist);
                    for (int k = 0; k < dt.Rows.Count; k++)
                    {
                        int presorderid = Convert.ToInt32(dt.Rows[k][0].ToString());
                        presorderidlist.Add(presorderid);
                    }
                }
                else//去掉成组选择
                {
                    for (int j = 0; j < dtgrdorder.Rows.Count; j++)
                    {
                        int tempgroupid = Convert.ToInt32(dtgrdorder[Column16.Name, j].Value.ToString());
                        if (group_id == tempgroupid)
                        {
                            dtgrdorder[0, j].Value = false;
                            for (int k = 0; k < dtgrdorder.Columns.Count; k++)
                            {
                                dtgrdorder.Rows[j].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
                                dtgrdorder.Rows[j].Cells[k].Style.BackColor = System.Drawing.Color.White;
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
                for (int rownum = 0; rownum < dtgrdorder.Rows.Count; rownum++)
                {
                    dtgrdorder[Column3.Name, rownum].Value = false;
                    for (int k = 0; k < dtgrdorder.Columns.Count; k++)
                    {
                        dtgrdorder.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
                        dtgrdorder.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.White;
                    }
                }
                int i = e.RowIndex;
                dtgrdorder[Column3.Name, i].Value = true;
                for (int k = 0; k < dtgrdorder.Columns.Count; k++)
                {
                    dtgrdorder.Rows[i].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                    dtgrdorder.Rows[i].Cells[k].Style.BackColor = System.Drawing.Color.White;
                }
                int orderid = Convert.ToInt32(dtgrdorder[Column12.Name, i].Value.ToString());
                List<int> orderlist = new List<int>();
                orderlist.Add(orderid);
                presorderidlist.Clear();
                dtgrdaccount.AutoGenerateColumns = false;
                dtgrdaccount.DataSource = op_order.getCancelFeeInfo(orderlist);
                DataTable dt = op_order.getPresorder(orderlist);
                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    int presorderid = Convert.ToInt32(dt.Rows[k][0].ToString());
                    presorderidlist.Add(presorderid);
                }
            }
        }
        /// <summary>
        /// 选择冲正项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgrdaccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 0 || dtgrdaccount["prestype",e.RowIndex].Value.ToString().Trim()=="3")
            {
                if (dtgrdaccount["prestype", e.RowIndex].Value.ToString().Trim() == "3")
                {
                    radiobtnall.Checked = true;
                }
                if (radiobtnall.Checked==true )
                {
                    int rownum = e.RowIndex;
                    DateTime datetime = Convert.ToDateTime(dtgrdaccount[dataGridViewTextBoxColumn4.Name, rownum].Value.ToString());
                    if (Convert.ToBoolean(dtgrdaccount[dataGridViewCheckBoxColumn1.Name, rownum].Value) == false)
                    {
                        for (int i = 0; i < dtgrdaccount.Rows.Count; i++)
                        {
                            DateTime tempdatetime = Convert.ToDateTime(dtgrdaccount[dataGridViewTextBoxColumn4.Name, i].Value.ToString());
                            if (datetime == tempdatetime)
                            {
                                dtgrdaccount[dataGridViewCheckBoxColumn1.Name, i].Value = true;
                                for (int k = 0; k < dtgrdaccount.Columns.Count; k++)
                                {
                                    dtgrdaccount.Rows[i].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                                    dtgrdaccount.Rows[i].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
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
                        for (int i = 0; i < dtgrdaccount.Rows.Count; i++)
                        {
                            DateTime tempdatetime = Convert.ToDateTime(dtgrdaccount[dataGridViewTextBoxColumn4.Name, i].Value.ToString());
                            if (datetime == tempdatetime)
                            {
                                dtgrdaccount[dataGridViewCheckBoxColumn1.Name, i].Value = false;
                                for (int k = 0; k < dtgrdaccount.Columns.Count; k++)
                                {
                                    dtgrdaccount.Rows[i].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
                                    dtgrdaccount.Rows[i].Cells[k].Style.BackColor = System.Drawing.Color.White;
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
                    if (Convert.ToBoolean(dtgrdaccount[dataGridViewCheckBoxColumn1.Name, rownum].Value) == false)
                    {
                        dtgrdaccount[dataGridViewCheckBoxColumn1.Name, rownum].Value = true;
                        for (int k = 0; k < dtgrdaccount.Columns.Count; k++)
                        {
                            dtgrdaccount.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                            dtgrdaccount.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }
                    }
                    else
                    {
                        dtgrdaccount[dataGridViewCheckBoxColumn1.Name, rownum].Value = false;
                        {
                            for (int k = 0; k < dtgrdaccount.Columns.Count; k++)
                            {
                                dtgrdaccount.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
                                dtgrdaccount.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.White;
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 成组冲正
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btncanfee_Click(object sender, EventArgs e)
        {
            if (op_order.IsPatOut(patlistid))
            {
                MessageBox.Show("该病人已结算，不能冲正");
                return;
            }
            if (radiobtnsingle.Checked == false && radiobtnamount.Checked==false)
            {
                int preorderid;
                DateTime datetime;              
                List<DateTime> datelist = new List<DateTime>();
                List<int> canorderlist = new List<int>();
                for (int rownum = 0; rownum < dtgrdaccount.Rows.Count; rownum++)
                {
                    if (Convert.ToBoolean(dtgrdaccount[dataGridViewCheckBoxColumn1.Name, rownum].Value) == true)
                    {
                        int flag = Convert.ToInt32(dtgrdaccount[dataGridViewTextBoxColumn10.Name, rownum].Value.ToString());
                        if (flag == 0)
                        {
                            datetime = Convert.ToDateTime(dtgrdaccount[dataGridViewTextBoxColumn4.Name, rownum].Value.ToString());
                            int presorderid = Convert.ToInt32(dtgrdaccount[dataGridViewTextBoxColumn3.Name, rownum].Value.ToString());
                            datelist.Add(datetime);
                            canorderlist.Add(presorderid);
                        }
                        else
                        {
                            MessageBox.Show("该组费用不能进行冲正操作!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                        int type = Convert.ToInt32(dtgrdaccount["prestype", rownum].Value.ToString());
                        if (type > 3)
                        {
                            HIS.MedicalConfir_BLL.MedicalInterface iConfir = new HIS.MedicalConfir_BLL.InterfaceOperation();
                            if (iConfir.HasMedical() && iConfir.IsConfirmed(Convert.ToInt32(dtgrdaccount[dataGridViewTextBoxColumn3.Name, rownum].Value.ToString()), HIS.MedicalConfir_BLL.ConfirType.住院))
                            {
                                MessageBox.Show("该费用已确费，不能冲正");
                                return;
                            }
                        }
                    }
                }
                if (datelist.Count == 0)
                {
                    MessageBox.Show("您还未选择冲正医嘱，请选择医嘱后再进行冲正操作!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    bool result = op_order.IsGroupCancelFee(canorderlist,Convert.ToInt32(_currentDept.DeptID));
                    if (result)
                    {
                        if (op_order.canaccount(patlistid, canorderlist, datelist))
                        {
                            MessageBox.Show("您的医嘱费用已成功冲正", "提示", MessageBoxButtons.OK);
                            DataTable dt = op_order.getCanaccount(presorderidlist);
                            dtgrdaccount.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("您的费用冲正操作失败", "提示", MessageBoxButtons.OK);
                        }

                    }
                    else
                    {
                        MessageBox.Show("该组医嘱不能进行成组冲正操作!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                }
            }
            else
            {
                btnsinglecanfee();
            }
        }
        /// <summary>
        /// 医嘱冲正(单条冲正及数量冲正）
        /// </summary>
        private void btnsinglecanfee()
        {
            int preorderid;
            DateTime datetime;
            bool cancelresult;
            List<DateTime> datelist = new List<DateTime>();
            List<int> canorderlist = new List<int>();
            if (radiobtnsingle.Checked == true)
            {
                for (int rownum = 0; rownum < dtgrdaccount.Rows.Count; rownum++)
                {
                    if (Convert.ToBoolean(dtgrdaccount[dataGridViewCheckBoxColumn1.Name, rownum].Value) == true)
                    {
                        int flag = Convert.ToInt32(dtgrdaccount[dataGridViewTextBoxColumn10.Name, rownum].Value.ToString());
                        if (flag == 0)
                        {
                            datetime = Convert.ToDateTime(dtgrdaccount[dataGridViewTextBoxColumn4.Name, rownum].Value.ToString());
                            int presorderid = Convert.ToInt32(dtgrdaccount[dataGridViewTextBoxColumn3.Name, rownum].Value.ToString());
                            datelist.Add(datetime);
                            canorderlist.Add(presorderid);
                        }
                        else
                        {
                            MessageBox.Show("该条费用不能进行冲正操作!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        HIS.MedicalConfir_BLL.MedicalInterface iConfir = new HIS.MedicalConfir_BLL.InterfaceOperation();
                        int type =Convert.ToInt32( dtgrdaccount["prestype", rownum].Value.ToString());
                        if (type > 3)
                        {
                            if (iConfir.HasMedical() && iConfir.IsConfirmed(Convert.ToInt32(dtgrdaccount[dataGridViewTextBoxColumn3.Name, rownum].Value.ToString()), HIS.MedicalConfir_BLL.ConfirType.住院))
                            {
                                MessageBox.Show("该费用已确费，不能冲正");
                                return;
                            }
                        }
                    }
                }
                if (canorderlist.Count == 0 || canorderlist.Count > 1)
                {
                    MessageBox.Show("请选择一条医嘱项目进行冲正操作!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    decimal amount = op_order.getspecsingleresult(canorderlist,Convert.ToInt32(_currentDept.DeptID));
                    if (amount>0)
                    {
                        cancelresult = op_order.canamountaccount(patlistid, canorderlist, datelist,amount);
                    }
                    else
                    {
                        MessageBox.Show("该条医嘱不能再次进行冲正操作!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    if (cancelresult == true)
                    {
                        MessageBox.Show("您的医嘱费用已成功冲正", "提示", MessageBoxButtons.OK);
                        DataTable dt = op_order.getCanaccount(presorderidlist);
                        dtgrdaccount.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("您的费用冲正操作失败", "提示", MessageBoxButtons.OK);
                    }
                }
            }
            else//数量冲正
            {
                for (int rownum = 0; rownum < dtgrdaccount.Rows.Count; rownum++)
                {
                    if (Convert.ToBoolean(dtgrdaccount[dataGridViewCheckBoxColumn1.Name, rownum].Value) == true)
                    {
                        int flag = Convert.ToInt32(dtgrdaccount[dataGridViewTextBoxColumn10.Name, rownum].Value.ToString());
                        if (flag == 0)
                        {
                            datetime = Convert.ToDateTime(dtgrdaccount[dataGridViewTextBoxColumn4.Name, rownum].Value.ToString());
                            int presorderid = Convert.ToInt32(dtgrdaccount[dataGridViewTextBoxColumn3.Name, rownum].Value.ToString());
                            datelist.Add(datetime);
                            canorderlist.Add(presorderid);
                        }
                        else
                        {
                            MessageBox.Show("该条费用不能进行冲正操作!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                }
                if (canorderlist.Count == 0 || canorderlist.Count > 1)
                {
                    MessageBox.Show("请选择一条医嘱项目进行冲正操作!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    loadfrmamount();                  
                    bool result = op_order.getspecamountresult(canorderlist, amount, Convert.ToInt32(_currentDept.DeptID));
                    if (result)
                    {
                        if (amount == 0)
                        return;
                        cancelresult = op_order.canamountaccount(patlistid, canorderlist, datelist, amount);
                    }
                    else
                    {
                        MessageBox.Show("该条医嘱冲正数量总和已超出冲正范围!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    if (cancelresult == true)
                    {
                        MessageBox.Show("您的医嘱费用已成功冲正", "提示", MessageBoxButtons.OK);
                        DataTable dt = op_order.getCanaccount(presorderidlist);
                        dtgrdaccount.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("您的费用冲正操作失败", "提示", MessageBoxButtons.OK);
                    }
                }
            }
        }
        /// <summary>
        /// 成组取消冲正
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnexitfee_Click(object sender, EventArgs e)
        {
            if (op_order.IsPatOut(patlistid)) // add by heyan 2011.5.10 .住院结算以后，护士站费用核对界面没有关闭，导致数据结算后还进行了冲账，导致费用清单的总金额与发票总费用不对
            {
                MessageBox.Show("该病人已结算，不能取消冲正");
                return;
            }
            if (radiobtnall.Checked == true)
            {
                int preorderid;
                DateTime datetime;                
                List<int> list = new List<int>();
                List<DateTime> datelist = new List<DateTime>();

                for (int rownum = 0; rownum < dtgrdaccount.Rows.Count; rownum++)
                {
                    if (Convert.ToBoolean(dtgrdaccount[dataGridViewCheckBoxColumn1.Name, rownum].Value) == true)
                    {
                        int flag = Convert.ToInt32(dtgrdaccount[dataGridViewTextBoxColumn10.Name, rownum].Value.ToString());
                        if (flag == 1)
                        {
                            preorderid = Convert.ToInt32(dtgrdaccount[dataGridViewTextBoxColumn3.Name, rownum].Value.ToString());
                            datetime = Convert.ToDateTime(dtgrdaccount[dataGridViewTextBoxColumn4.Name, rownum].Value.ToString());
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
                    bool result = op_order.getspecexitresultlist(list, Convert.ToInt32(_currentDept.DeptID));
                    if (result)
                    {
                        if (op_order.exitcanaccount(patlistid, list, datelist))
                        {
                            MessageBox.Show("您的取消冲正操作成功！", "提示", MessageBoxButtons.OK);
                            DataTable dt = op_order.getCanaccount(presorderidlist);
                            dtgrdaccount.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("您的取消冲正操作失败", "提示", MessageBoxButtons.OK);
                        }
                    }
                }
            }
            else
            {
                btnsingleexitfee();
            }
        }
        /// <summary>
        /// 取消冲正操作（单条医嘱）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnsingleexitfee()
        {
            int preorderid;
            DateTime datetime;           
            List<int> list = new List<int>();
            List<DateTime> datelist = new List<DateTime>();
            if (radiobtnsingle.Checked == true)
            {
                for (int rownum = 0; rownum < dtgrdaccount.Rows.Count; rownum++)
                {
                    if (Convert.ToBoolean(dtgrdaccount[dataGridViewCheckBoxColumn1.Name, rownum].Value) == true)
                    {
                        int flag = Convert.ToInt32(dtgrdaccount[dataGridViewTextBoxColumn10.Name, rownum].Value.ToString());
                        if (flag == 1)
                        {
                            preorderid = Convert.ToInt32(dtgrdaccount[dataGridViewTextBoxColumn3.Name, rownum].Value.ToString());
                            datetime = Convert.ToDateTime(dtgrdaccount[dataGridViewTextBoxColumn4.Name, rownum].Value.ToString());
                            list.Add(preorderid);
                            datelist.Add(datetime);
                        }
                        else
                        {
                            MessageBox.Show("该条费用不能进行取消冲正操作!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                }
                if (list.Count != 1)
                {
                    MessageBox.Show("请选择一条冲正项再进行操作!", "提示", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    bool result = op_order.getspecexitresult(list, Convert.ToInt32(_currentDept.DeptID));
                    if (result)
                    {
                        if (op_order.exitcanaccount(patlistid, list, datelist))
                        {
                            MessageBox.Show("您的单条医嘱取消冲正操作成功！", "提示", MessageBoxButtons.OK);
                            DataTable dt = op_order.getCanaccount(presorderidlist);
                            dtgrdaccount.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("您的费用冲正操作失败！", "提示", MessageBoxButtons.OK);
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("不允许进行数量取消冲正，请选择单条取消冲正后重新进行数量冲正操作！", "提示", MessageBoxButtons.OK);
            }
        }       
        /// <summary>
        /// 账单补录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnfeeinput_Click(object sender, EventArgs e)
        {
            if (dtgrdorder.Rows.Count==0)
            {
                MessageBox.Show("请先单击要补录医嘱的病人", "提示", MessageBoxButtons.OK);
                return;
            }
            int orderid =Convert.ToInt32(dtgrdorder[Column12.Name, dtgrdorder.CurrentCell.RowIndex].Value.ToString());
            FrmFeeInput frmfeeinput = new FrmFeeInput(_currentUser.UserID, _currentDept.DeptID, "账单录入",patlistid,orderid,ordertype,groupid);
            frmfeeinput.MdiParent = this.MdiParent;
            frmfeeinput.WindowState = FormWindowState.Maximized;
            ((GWMHIS.BussinessLogicLayer.Interfaces.IInvokForm)this.Parent.Parent.Parent).AddFormToTabPage(frmfeeinput);
            frmfeeinput.Show();
        }
        /// <summary>
        /// 输入冲正数量
        /// </summary>
        private void loadfrmamount()
        {
            Frmcanaccount frmamount = new Frmcanaccount();
            frmamount.MdiParent = this.MdiParent;
            frmamount.WindowState = FormWindowState.Normal;
            frmamount.ShowDialog();
            amount = frmamount.Amount;
        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
