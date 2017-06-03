using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HIS.SYSTEM.BussinessLogicLayer.Classes;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.ZYNurse_BLL;
using grproLib;
using System.Threading;



namespace HIS_ZYNurseManager
{
    public partial class FrmOrderManager : GWI.HIS.Windows.Controls.BaseMainForm
    {
        #region 属性
        private int patlistid;
        private int ordertype;
        private int[] tempdata;
        OP_Order op_order = new OP_Order();

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
        #endregion
        /// <summary>
        /// 构造函数及加载第一个病人的长嘱
        /// </summary>
        /// <param name="currentUserId"></param>
        /// <param name="currentDeptId"></param>
        /// <param name="chineseName"></param>
        public FrmOrderManager(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            this.Text = chineseName;
            MessagePromptManager.Messenger receiver = new MessagePromptManager.Messenger(currentUserId, -1, "");
            this.messageTimer1.MessageReceiver = receiver;
            dtgpatlist.DataSource = op_order.getPatList(Convert.ToInt32(_currentDept.DeptID));
            if (dtgpatlist.Rows.Count>0)
            {                
                patlistid = Convert.ToInt32(dtgpatlist[2, 0].Value.ToString());
                dtgrdVaildLongOrder.AutoGenerateColumns = false; 
                dtgrdVaildLongOrder.DataSource = op_order.getOrder(patlistid, 0);               
            }
            else
            {
                dtgrdVaildLongOrder.DataSource = null;
            }
            btncalaccount.Enabled = false;
            btnprint.Enabled = false;
            btnstopaccount.Enabled = false;
            if(OP_Config.GetValue("008")==1)
            {
                btnSingleSendTomorrowDrug.Visible=true;
                btnSendTomorrowDrug.Visible=true;
                btnSendAllDrug.Visible=false;
                btngetdrug.Visible=false;
            }

            UIStat1();
        }
        /// <summary>
        /// 获取病人列表ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgrdPatList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable patdt =(DataTable)dtgpatlist.DataSource;
            if (patdt.Rows.Count > 0)
            {
                patlistid = Convert.ToInt32(patdt.Rows[dtgpatlist.CurrentCell.RowIndex][1].ToString());
                if (pageselection.SelectedIndex == 0)
                {
                    ordertype = 0;                   
                    dtgrdVaildLongOrder.DataSource = op_order.getOrder(patlistid, ordertype);
                }
                else if(pageselection.SelectedIndex == 1)
                {
                    ordertype = 1;                 
                    dtgrdVaildTempOrder.DataSource = op_order.getValidOrder(patlistid, ordertype);
                }
                else if (pageselection.SelectedIndex == 2)
                {
                    ordertype = 2;            
                    dtgrdVaildLongAccount.DataSource = op_order.getOrder(patlistid, ordertype);
                }
                else if (pageselection.SelectedIndex == 3)
                {
                    ordertype = 3;                   
                    dtgrdValidTempAccount.DataSource = op_order.getOrder(patlistid, ordertype);
                }
                else if (pageselection.SelectedIndex == 4)
                {
                    ordertype = 0;                  
                    dataGridViewEx5.DataSource = op_order.getAllOrder(patlistid, ordertype);
                }
                else if (pageselection.SelectedIndex == 5)
                {
                    ordertype = 1;                   
                    dataGridViewEx6.DataSource = op_order.getAllTempOrder(patlistid, ordertype);
                }
                else if (pageselection.SelectedIndex == 6)
                {
                    ordertype = 2;                    
                    dataGridViewEx7.DataSource = op_order.getAllOrder(patlistid, ordertype);
                }
                else if (pageselection.SelectedIndex == 7)
                {
                    ordertype = 3;                
                    dataGridViewEx8.DataSource = op_order.getAllTempOrder(patlistid, ordertype);
                }
                else
                {
                    MessageBox.Show("超出范围，系统正在开发中,请稍后再试", "提示", MessageBoxButtons.OK);
                }
            }
            else
            {
                return;
            }
           
        }
        /// <summary>
        /// 选择选项卡，加载不同的数据源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pageselection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pageselection.SelectedIndex == 0)
            {
                ordertype = 0;
                btnZ.Visible = false;
                btnF.Visible =false;
                btnprint.Enabled = false;
                btngetdrug.Enabled = true;
                btnstopaccount.Enabled = false;
                btncalaccount.Enabled = false;
                btnsend.Enabled = true;      
                btnstoptrans.Enabled = true;
                dtgrdVaildLongOrder.AutoGenerateColumns = false;
                dtgrdVaildLongOrder.DataSource = op_order.getOrder(patlistid, ordertype);
            }
            else if (pageselection.SelectedIndex == 1)
            {
                btnZ.Visible = true;
                btnF.Visible = true;
                btngetdrug.Enabled = false;
                btnprint.Enabled = false;
                ordertype = 1;
                btnstopaccount.Enabled = false;
                btncalaccount.Enabled = false;
                btnsend.Enabled = true;    
                btnstoptrans.Enabled = true;
                dtgrdVaildTempOrder.AutoGenerateColumns = false;
                dtgrdVaildTempOrder.DataSource = op_order.getValidOrder(patlistid, ordertype);
            }
            else if (pageselection.SelectedIndex == 2)
            {
                ordertype = 2;
                btnZ.Visible = false;
                btnF.Visible = false;
                btnprint.Enabled = false;
                btngetdrug.Enabled = false;
                btnstopaccount.Enabled = true;
                btncalaccount.Enabled = false;
                btnsend.Enabled = true;  
                btnstoptrans.Enabled = false;
                dtgrdVaildLongAccount.AutoGenerateColumns = false;
                dtgrdVaildLongAccount.DataSource = op_order.getOrder(patlistid, ordertype);
            }
            else if (pageselection.SelectedIndex == 3)
            {
                ordertype = 3;
                btnZ.Visible = false;
                btnF.Visible = false;
                btnprint.Enabled = false;
                btngetdrug.Enabled = false;
                btnstopaccount.Enabled = false;
                btncalaccount.Enabled = false;
                btnsend.Enabled = true;   
                btnstoptrans.Enabled = false;
                dtgrdValidTempAccount.AutoGenerateColumns = false;
                dtgrdValidTempAccount.DataSource = op_order.getOrder(patlistid, ordertype);
            }
            else if (pageselection.SelectedIndex == 4)
            {
                ordertype = 0;
                btnZ.Visible = false;
                btnF.Visible = false;
                btnprint.Enabled = true;
                btngetdrug.Enabled = false;
                btnstopaccount.Enabled = false;
                btncalaccount.Enabled = true;
                btnsend.Enabled = false;      
                btnstoptrans.Enabled = false;
                dataGridViewEx5.AutoGenerateColumns = false;
                dataGridViewEx5.DataSource = op_order.getAllOrder(patlistid, ordertype);
            }
            else if (pageselection.SelectedIndex == 5)
            {
                ordertype = 1;
                btnZ.Visible = false;
                btnF.Visible = false;
                btnprint.Enabled = true;
                btngetdrug.Enabled= false;
                btnstopaccount.Enabled = false;
                btncalaccount.Enabled = true;
                btnsend.Enabled = false;
                btnstoptrans.Enabled = false;
                dataGridViewEx6.AutoGenerateColumns = false;
                dataGridViewEx6.DataSource = op_order.getAllTempOrder(patlistid, ordertype);
            }
            else if (pageselection.SelectedIndex == 6)
            {
                ordertype = 2;
                btnZ.Visible = false;
                btnF.Visible = false;
                btnprint.Enabled = true;
                btngetdrug.Enabled = false;
                btnstopaccount.Enabled = false;
                btncalaccount.Enabled = true;
                btnsend.Enabled = false;
                btnstoptrans.Enabled = false;
                dataGridViewEx7.AutoGenerateColumns = false;
                dataGridViewEx7.DataSource = op_order.getAllOrder(patlistid, ordertype);
            }
            else if (pageselection.SelectedIndex == 7)
            {
                ordertype = 3;
                btnZ.Visible = false;
                btnF.Visible = false;
                btnprint.Enabled = true;
                btngetdrug.Enabled = false;
                btnstopaccount.Enabled = false;
                btncalaccount.Enabled = true;
                btnsend.Enabled = false;
                btnstoptrans.Enabled = false;
                dataGridViewEx8.AutoGenerateColumns = false;
                dataGridViewEx8.DataSource = op_order.getAllTempOrder(patlistid, ordertype);
            }
        }
        /// <summary>
        /// 个人医嘱账单发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnsend_Click(object sender, EventArgs e)
        {
           
                int row;
                if (pageselection.SelectedIndex == 0)//长期医嘱处理
                {
                    try
                    {
                        List<int> list = new List<int>();
                        int orderid;
                        bool result;
                        ordertype = 0;
                        for (int i = 0; i < dtgrdVaildLongOrder.Rows.Count; i++)
                        {
                            if (Convert.ToBoolean(dtgrdVaildLongOrder[0, i].Value) == true)
                            {
                                orderid = Convert.ToInt32(dtgrdVaildLongOrder[1, i].Value.ToString());
                                list.Add(orderid);
                            }
                        }
                        if (list.Count == 0)
                        {
                            MessageBox.Show("您未选中要发送的长期医嘱项！", "提示", MessageBoxButtons.OK);
                            return;
                        }
                        else
                        {
                            Order order = new Order();
                            result = order.Send(list, Convert.ToInt32(_currentUser.EmployeeID), patlistid);
                        }
                        if (result == true)
                        {
                            MessageBox.Show("您的长期医嘱已成功发送！", "提示", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("您的长期医嘱发送失败，请稍候重新发送！", "提示", MessageBoxButtons.OK);
                        }
                        dtgrdVaildLongOrder.DataSource = op_order.getOrder(patlistid, ordertype);
                    }
                    catch(Exception err)
                    {
                        MessageBox.Show(err.Message);
                        dtgrdVaildLongOrder.DataSource = op_order.getOrder(patlistid, ordertype);
                    }
                }
                else if (pageselection.SelectedIndex == 1)//临时医嘱处理
                {
                    try
                    {
                        row = dtgrdVaildTempOrder.Rows.Count;
                        List<int> list = new List<int>();
                        int orderid;
                        bool result;
                        ordertype = 1;
                        for (int i = 0; i < row; i++)
                        {
                            if (Convert.ToBoolean(dtgrdVaildTempOrder[0, i].Value) == true)
                            {
                                orderid = Convert.ToInt32(dtgrdVaildTempOrder[Column13.Name, i].Value.ToString());
                                list.Add(orderid);
                            }
                        }
                        if (list.Count == 0)
                        {
                            MessageBox.Show("您未选中要发送的临时医嘱项！", "提示", MessageBoxButtons.OK);
                            return;
                        }
                        else
                        {
                            Order order = new Order();
                            result = order.Send(list, Convert.ToInt32(_currentUser.EmployeeID), patlistid);
                        }
                        if (result == true)
                        {
                            MessageBox.Show("您的临时医嘱已成功发送！", "提示", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("您的临时医嘱发送失败，请稍候重新发送！", "提示", MessageBoxButtons.OK);
                        }
                        dtgrdVaildTempOrder.DataSource = op_order.getValidOrder(patlistid, ordertype);
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                        dtgrdVaildTempOrder.DataSource = op_order.getValidOrder(patlistid, ordertype);
                    }
                }
                else if (pageselection.SelectedIndex == 2)///长期账单
                {
                    try
                    {
                        row = dtgrdVaildLongAccount.Rows.Count;
                        List<int> list = new List<int>();
                        int orderid;
                        bool result;
                        ordertype = 2;
                        for (int i = 0; i < row; i++)
                        {
                            if (Convert.ToBoolean(dtgrdVaildLongAccount[0, i].Value) == true)
                            {
                                orderid = Convert.ToInt32(dtgrdVaildLongAccount[Column14.Name, i].Value.ToString());
                                list.Add(orderid);
                            }
                        }
                        if (list.Count == 0)
                        {
                            MessageBox.Show("您未选中要发送的长期账单项！", "提示", MessageBoxButtons.OK);
                            return;
                        }
                        else
                        {
                            result = op_order.longvaildaccountsend(list, _currentUser.EmployeeID, patlistid);
                        }
                        if (result == true)
                        {
                            MessageBox.Show("您的长期账单已成功发送！", "提示", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("您的长期账单发送失败，请稍候重新发送！", "提示", MessageBoxButtons.OK);
                        }
                        dtgrdVaildLongAccount.DataSource = op_order.getOrder(patlistid, ordertype);
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                        dtgrdVaildLongAccount.DataSource = op_order.getOrder(patlistid, ordertype);
                    }
                }
                else///临时账单
                {
                    try
                    {
                        row = dtgrdValidTempAccount.Rows.Count;
                        List<int> list = new List<int>();
                        int orderid;
                        bool result;
                        ordertype = 3;
                        for (int i = 0; i < row; i++)
                        {
                            if (Convert.ToBoolean(dtgrdValidTempAccount[0, i].Value) == true)
                            {
                                orderid = Convert.ToInt32(dtgrdValidTempAccount[Column15.Name, i].Value.ToString());
                                list.Add(orderid);
                            }
                        }
                        if (list.Count == 0)
                        {
                            MessageBox.Show("您未选中要发送的临时账单项！", "提示", MessageBoxButtons.OK);
                            return;
                        }
                        else
                        {
                            result = op_order.tempvalidaccountsend(list, _currentUser.EmployeeID, patlistid);
                        }
                        if (result == true)
                        {
                            MessageBox.Show("您的临时账单已成功发送！", "提示", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("您的临时账单发送失败，请稍候重新发送！", "提示", MessageBoxButtons.OK);
                        }
                        dtgrdValidTempAccount.DataSource = op_order.getOrder(patlistid, ordertype);
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                        dtgrdValidTempAccount.DataSource = op_order.getOrder(patlistid, ordertype);
                    }
                }            
           
        }
        /// <summary>
        /// 全选操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAllSelect_Click(object sender, EventArgs e)
        {
            if (pageselection.SelectedIndex == 0)
            {
                for (int rownum = 0; rownum < dtgrdVaildLongOrder.Rows.Count; rownum++)
                {
                    dtgrdVaildLongOrder[0, rownum].Value = true;
                    for (int k = 0; k < dtgrdVaildLongOrder.Columns.Count; k++)
                    {
                        dtgrdVaildLongOrder.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                        dtgrdVaildLongOrder.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                    }
                }
            }
            else if (pageselection.SelectedIndex == 1)
            {
                for (int rownum = 0; rownum < dtgrdVaildTempOrder.Rows.Count; rownum++)
                {
                    dtgrdVaildTempOrder[0, rownum].Value = true;
                    for (int k = 0; k < dtgrdVaildTempOrder.Columns.Count; k++)
                    {
                        dtgrdVaildTempOrder.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                        dtgrdVaildTempOrder.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                    }
                }
            }
            else if (pageselection.SelectedIndex == 2)
            {
                for (int rownum = 0; rownum < dtgrdVaildLongAccount.Rows.Count; rownum++)
                {
                    dtgrdVaildLongAccount[0, rownum].Value = true;
                    for (int k = 0; k < dtgrdVaildLongAccount.Columns.Count; k++)
                    {
                        dtgrdVaildLongAccount.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                        dtgrdVaildLongAccount.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                    }
                }
            }
            else if (pageselection.SelectedIndex == 3)
            {
                for (int rownum = 0; rownum < dtgrdValidTempAccount.Rows.Count; rownum++)
                {
                    dtgrdValidTempAccount[0, rownum].Value = true;
                    for (int k = 0; k < dtgrdValidTempAccount.Columns.Count; k++)
                    {
                        dtgrdValidTempAccount.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                        dtgrdValidTempAccount.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                    }
                }
            }
            else if (pageselection.SelectedIndex == 4)
            {
                for (int rownum = 0; rownum < dataGridViewEx5.Rows.Count; rownum++)
                {
                    dataGridViewEx5[0, rownum].Value = true;
                    for (int k = 0; k < dataGridViewEx5.Columns.Count; k++)
                    {
                        dataGridViewEx5.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                        dataGridViewEx5.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                    }
                }
            }
            else if (pageselection.SelectedIndex == 5)
            {
                for (int rownum = 0; rownum < dataGridViewEx6.Rows.Count; rownum++)
                {
                    dataGridViewEx6[0, rownum].Value = true;
                    for (int k = 0; k < dataGridViewEx6.Columns.Count; k++)
                    {
                        dataGridViewEx6.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                        dataGridViewEx6.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                    }
                }
            }
            else if (pageselection.SelectedIndex == 6)
            {
                for (int rownum = 0; rownum < dataGridViewEx7.Rows.Count; rownum++)
                {
                    dataGridViewEx7[0, rownum].Value = true;
                    for (int k = 0; k < dataGridViewEx7.Columns.Count; k++)
                    {
                        dataGridViewEx7.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                        dataGridViewEx7.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                    }
                }
            }
            else if (pageselection.SelectedIndex == 7)
            {
                for (int rownum = 0; rownum < dataGridViewEx8.Rows.Count; rownum++)
                {
                    dataGridViewEx8[0, rownum].Value = true;
                    for (int k = 0; k < dataGridViewEx8.Columns.Count; k++)
                    {
                        dataGridViewEx8.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                        dataGridViewEx8.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                    }
                }
            }
        }
        /// <summary>
        /// 反选操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReverSelect_Click(object sender, EventArgs e)
        {
            if (pageselection.SelectedIndex == 0)
            {
                for (int rownum = 0; rownum < dtgrdVaildLongOrder.Rows.Count; rownum++)
                {
                    dtgrdVaildLongOrder[0, rownum].Value = !(Convert.ToBoolean(dtgrdVaildLongOrder[0, rownum].Value));
                    if (Convert.ToBoolean(dtgrdVaildLongOrder[0, rownum].Value) == true)
                    {
                        for (int k = 0; k < dtgrdVaildLongOrder.Columns.Count; k++)
                        {
                            dtgrdVaildLongOrder.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                            dtgrdVaildLongOrder.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }
                    }
                    else
                    {
                        for (int k = 0; k < dtgrdVaildLongOrder.Columns.Count; k++)
                        {
                            dtgrdVaildLongOrder.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
                            dtgrdVaildLongOrder.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.White;
                        }
                    }
                }
            }
            else if (pageselection.SelectedIndex == 1)
            {
                for (int rownum = 0; rownum < dtgrdVaildTempOrder.Rows.Count; rownum++)
                {
                    dtgrdVaildTempOrder[0, rownum].Value = !(Convert.ToBoolean(dtgrdVaildTempOrder[0, rownum].Value));
                    if (Convert.ToBoolean(dtgrdVaildTempOrder[0, rownum].Value) == true)
                    {
                        for (int k = 0; k < dtgrdVaildTempOrder.Columns.Count; k++)
                        {
                            dtgrdVaildTempOrder.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                            dtgrdVaildTempOrder.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }
                    }
                    else
                    {
                        for (int k = 0; k < dtgrdVaildTempOrder.Columns.Count; k++)
                        {
                            dtgrdVaildTempOrder.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
                            dtgrdVaildTempOrder.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.White;
                        }
                    }
                }
            }
            else if (pageselection.SelectedIndex == 2)
            {
                for (int rownum = 0; rownum < dtgrdVaildLongAccount.Rows.Count; rownum++)
                {
                    dtgrdVaildLongAccount[0, rownum].Value = !(Convert.ToBoolean(dtgrdVaildLongAccount[0, rownum].Value));
                    if (Convert.ToBoolean(dtgrdVaildLongAccount[0, rownum].Value) == true)
                    {
                        for (int k = 0; k < dtgrdVaildLongAccount.Columns.Count; k++)
                        {
                            dtgrdVaildLongAccount.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                            dtgrdVaildLongAccount.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }
                    }
                    else
                    {
                        for (int k = 0; k < dtgrdVaildLongAccount.Columns.Count; k++)
                        {
                            dtgrdVaildLongAccount.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
                            dtgrdVaildLongAccount.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.White;
                        }
                    }
                }
            }
            else if (pageselection.SelectedIndex == 3)
            {
                for (int rownum = 0; rownum < dtgrdValidTempAccount.Rows.Count; rownum++)
                {
                    dtgrdValidTempAccount[0, rownum].Value = !(Convert.ToBoolean(dtgrdValidTempAccount[0, rownum].Value));
                    if (Convert.ToBoolean(dtgrdValidTempAccount[0, rownum].Value) == true)
                    {
                        for (int k = 0; k < dtgrdValidTempAccount.Columns.Count; k++)
                        {
                            dtgrdValidTempAccount.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                            dtgrdValidTempAccount.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }
                    }
                    else
                    {
                        for (int k = 0; k < dtgrdValidTempAccount.Columns.Count; k++)
                        {
                            dtgrdValidTempAccount.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
                            dtgrdValidTempAccount.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.White;
                        }
                    }

                }
            }
            else if (pageselection.SelectedIndex == 4)
            {
                for (int rownum = 0; rownum < dataGridViewEx5.Rows.Count; rownum++)
                {
                    dataGridViewEx5[0, rownum].Value = !(Convert.ToBoolean(dataGridViewEx5[0, rownum].Value));
                    if (Convert.ToBoolean(dataGridViewEx5[0, rownum].Value) == true)
                    {
                        for (int k = 0; k < dataGridViewEx5.Columns.Count; k++)
                        {
                            dataGridViewEx5.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                            dataGridViewEx5.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }
                    }
                    else
                    {
                        for (int k = 0; k < dataGridViewEx5.Columns.Count; k++)
                        {
                            dataGridViewEx5.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
                            dataGridViewEx5.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.White;
                        }
                    }

                }
            }
            else if (pageselection.SelectedIndex == 5)
            {
                for (int rownum = 0; rownum < dataGridViewEx6.Rows.Count; rownum++)
                {
                    dataGridViewEx6[0, rownum].Value = !(Convert.ToBoolean(dataGridViewEx6[0, rownum].Value));
                    if (Convert.ToBoolean(dataGridViewEx6[0, rownum].Value) == true)
                    {
                        for (int k = 0; k < dataGridViewEx6.Columns.Count; k++)
                        {
                            dataGridViewEx6.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                            dataGridViewEx6.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }
                    }
                    else
                    {
                        for (int k = 0; k < dataGridViewEx6.Columns.Count; k++)
                        {
                            dataGridViewEx6.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
                            dataGridViewEx6.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.White;
                        }
                    }

                }
            }
            else if (pageselection.SelectedIndex == 6)
            {
                for (int rownum = 0; rownum < dataGridViewEx7.Rows.Count; rownum++)
                {
                    dataGridViewEx7[0, rownum].Value = !(Convert.ToBoolean(dataGridViewEx7[0, rownum].Value));
                    if (Convert.ToBoolean(dataGridViewEx7[0, rownum].Value) == true)
                    {
                        for (int k = 0; k < dataGridViewEx7.Columns.Count; k++)
                        {
                            dataGridViewEx7.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                            dataGridViewEx7.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }
                    }
                    else
                    {
                        for (int k = 0; k < dataGridViewEx7.Columns.Count; k++)
                        {
                            dataGridViewEx7.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
                            dataGridViewEx7.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.White;
                        }
                    }

                }
            }
            else
            {
                for (int rownum = 0; rownum < dataGridViewEx8.Rows.Count; rownum++)
                {
                    dataGridViewEx8[0, rownum].Value = !(Convert.ToBoolean(dataGridViewEx8[0, rownum].Value));
                    if (Convert.ToBoolean(dataGridViewEx8[0, rownum].Value) == true)
                    {
                        for (int k = 0; k < dataGridViewEx8.Columns.Count; k++)
                        {
                            dataGridViewEx8.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                            dataGridViewEx8.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }
                    }
                    else
                    {
                        for (int k = 0; k < dataGridViewEx8.Columns.Count; k++)
                        {
                            dataGridViewEx8.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
                            dataGridViewEx8.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.White;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 费用查看操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btncalaccount_Click(object sender, EventArgs e)
        {
            if (pageselection.SelectedIndex == 4)//长期医嘱冲正
            {
                int orderid;
                int groupid;
                List<int> orderlist = new List<int>();
                List<int> grouplist = new List<int>();
                int rownum = dataGridViewEx5.Rows.Count;
                for (int j = 0; j < dataGridViewEx5.Rows.Count; j++)
                {
                    if (Convert.ToBoolean(dataGridViewEx5[dataGridViewCheckBoxColumn4.Name, j].Value) == true)
                    {
                        orderid = Convert.ToInt32(dataGridViewEx5[dataGridViewTextBoxColumn8.Name, j].Value.ToString());
                        groupid = Convert.ToInt32(dataGridViewEx5[dataGridViewTextBoxColumn51.Name, j].Value.ToString());
                        orderlist.Add(orderid);
                        grouplist.Add(groupid);
                    }
                }
                if (orderlist.Count == 0)
                {
                    MessageBox.Show("您还未选择要查看费用的医嘱，请选择医嘱后再进行操作!", "提示", MessageBoxButtons.OK);
                    return;
                }
                for (int i = 1; i < grouplist.Count; i++)
                {
                    if (grouplist[0] != grouplist[i])
                    {
                        MessageBox.Show("您选择了多组医嘱，查看费用只能选择一组进行查看!", "提示", MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {
                        continue;
                    }
                }
                CanAccount frmcanaccount = new CanAccount(patlistid, orderlist);
                frmcanaccount.MdiParent = this.MdiParent;
                frmcanaccount.WindowState = FormWindowState.Maximized;
                ((GWMHIS.BussinessLogicLayer.Interfaces.IInvokForm)this.Parent.Parent.Parent).AddFormToTabPage(frmcanaccount);
                frmcanaccount.Show();
            }
            else if (pageselection.SelectedIndex == 5)//临时医嘱冲正
            {
                int orderid;
                int groupid;
                List<int> orderlist = new List<int>();
                List<int> grouplist = new List<int>();
                int rownum = dataGridViewEx6.Rows.Count;
                for (int j = 0; j < dataGridViewEx6.Rows.Count; j++)
                {
                    if (Convert.ToBoolean(dataGridViewEx6[dataGridViewCheckBoxColumn5.Name, j].Value) == true)
                    {
                        orderid = Convert.ToInt32(dataGridViewEx6[dataGridViewTextBoxColumn28.Name, j].Value.ToString());
                        groupid = Convert.ToInt32(dataGridViewEx6[dataGridViewTextBoxColumn55.Name, j].Value.ToString());
                        orderlist.Add(orderid);
                        grouplist.Add(groupid);
                    }
                }
                if (orderlist.Count == 0)
                {
                    MessageBox.Show("您还未选择要查看费用的医嘱，请选择医嘱后再进行操作!", "提示", MessageBoxButtons.OK);
                    return;
                }
                for (int i = 1; i < grouplist.Count; i++)
                {
                    if (grouplist[0] != grouplist[i])
                    {
                        MessageBox.Show("您选择了多组医嘱，查看费用只能选择一组进行查看!", "提示", MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {
                        continue;
                    }
                }              
                CanAccount frmcanaccount = new CanAccount(patlistid, orderlist);
                frmcanaccount.MdiParent = this.MdiParent;
                frmcanaccount.WindowState = FormWindowState.Maximized;
                ((GWMHIS.BussinessLogicLayer.Interfaces.IInvokForm)this.Parent.Parent.Parent).AddFormToTabPage(frmcanaccount);
                frmcanaccount.Show();
            }
            else if (pageselection.SelectedIndex == 6)//长期账单冲正
            {
                int orderid;
                List<int> orderlist = new List<int>();
                List<int> grouplist = new List<int>();
                int rownum = dataGridViewEx7.Rows.Count;
                for (int j = 0; j < dataGridViewEx7.Rows.Count; j++)
                {
                    if (Convert.ToBoolean(dataGridViewEx7[dataGridViewCheckBoxColumn6.Name, j].Value) == true)
                    {
                        orderid = Convert.ToInt32(dataGridViewEx7[dataGridViewTextBoxColumn36.Name, j].Value.ToString());
                        orderlist.Add(orderid);
                    }
                }
                if (orderlist.Count == 0)
                {
                    MessageBox.Show("您还未选择要查看费用的帐单项，请选择帐单项后再进行操作!", "提示", MessageBoxButtons.OK);
                    return;
                }
                if (orderlist.Count > 1)
                {
                    MessageBox.Show("您选择了多组帐单项，查看费用只能选择一组进行查看!", "提示", MessageBoxButtons.OK);
                    return;
                }               
                CanAccount frmcanaccount = new CanAccount(patlistid, orderlist);
                frmcanaccount.MdiParent = this.MdiParent;
                frmcanaccount.WindowState = FormWindowState.Maximized;
                ((GWMHIS.BussinessLogicLayer.Interfaces.IInvokForm)this.Parent.Parent.Parent).AddFormToTabPage(frmcanaccount);
                frmcanaccount.Show();
            }
            else if (pageselection.SelectedIndex == 7)//临时账单冲正
            {
                int orderid;
                List<int> orderlist = new List<int>();
                List<int> grouplist = new List<int>();
                int rownum = dataGridViewEx8.Rows.Count;
                for (int j = 0; j < dataGridViewEx8.Rows.Count; j++)
                {
                    if (Convert.ToBoolean(dataGridViewEx8[dataGridViewCheckBoxColumn7.Name, j].Value) == true)
                    {
                        orderid = Convert.ToInt32(dataGridViewEx8[dataGridViewTextBoxColumn43.Name, j].Value.ToString());
                        orderlist.Add(orderid);
                    }
                }
                if (orderlist.Count == 0)
                {
                    MessageBox.Show("您还未选择要查看费用的帐单项，请选择帐单项后再进行操作!", "提示", MessageBoxButtons.OK);
                    return;
                }
                if (orderlist.Count > 1)
                {
                    MessageBox.Show("您选择了多组帐单项，查看费用只能选择一组进行查看!", "提示", MessageBoxButtons.OK);
                    return;
                }             
                CanAccount frmcanaccount = new CanAccount(patlistid, orderlist);
                frmcanaccount.MdiParent = this.MdiParent;
                frmcanaccount.WindowState = FormWindowState.Maximized;
                ((GWMHIS.BussinessLogicLayer.Interfaces.IInvokForm)this.Parent.Parent.Parent).AddFormToTabPage(frmcanaccount);
                frmcanaccount.Show();
            }
        }                         
        /// <summary>
        /// 科室病人全选操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnselect_Click(object sender, EventArgs e)
        {
            for (int rownum = 0; rownum < dtgpatlist.Rows.Count; rownum++)
            {
                dtgpatlist[0, rownum].Value = true;
            }
        }
        /// <summary>
        /// 科室病人反选操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnreverse_Click(object sender, EventArgs e)
        {
            for (int rownum = 0; rownum < dtgpatlist.Rows.Count; rownum++)
            {
                dtgpatlist[0, rownum].Value = !(Convert.ToBoolean(dtgpatlist[0, rownum].Value));
            }
        }      
        /// <summary>
        /// 长期医嘱选中时医嘱分组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgrdVaildLongOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 0)
            {
                int i = e.RowIndex;
                int group_id = Convert.ToInt32(dtgrdVaildLongOrder[Column16.Name, i].Value.ToString());
                if (Convert.ToBoolean(dtgrdVaildLongOrder[Column3.Name, i].Value) == false)
                {
                    for (int j = 0; j < dtgrdVaildLongOrder.Rows.Count; j++)
                    {
                        int tempgroupid = Convert.ToInt32(dtgrdVaildLongOrder[Column16.Name, j].Value.ToString());
                        if (group_id == tempgroupid)
                        {
                            dtgrdVaildLongOrder[0, j].Value = true;
                            for (int k = 0; k < dtgrdVaildLongOrder.Columns.Count; k++)
                            {
                                dtgrdVaildLongOrder.Rows[j].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                                dtgrdVaildLongOrder.Rows[j].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
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
                    for (int j = 0; j < dtgrdVaildLongOrder.Rows.Count; j++)
                    {
                        int tempgroupid = Convert.ToInt32(dtgrdVaildLongOrder[Column16.Name, j].Value.ToString());
                        if (group_id == tempgroupid)
                        {
                            dtgrdVaildLongOrder[0, j].Value = false;
                            for (int k = 0; k < dtgrdVaildLongOrder.Columns.Count; k++)
                            {
                                dtgrdVaildLongOrder.Rows[j].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
                                dtgrdVaildLongOrder.Rows[j].Cells[k].Style.BackColor = System.Drawing.Color.White;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 临时医嘱选中时医嘱分组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgrdVaildTempOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 0)
            {
                int i = e.RowIndex;
                int group_id = Convert.ToInt32(dtgrdVaildTempOrder[dataGridViewTextBoxColumn7.Name, i].Value.ToString());
                if (Convert.ToBoolean(dtgrdVaildTempOrder[dataGridViewCheckBoxColumn3.Name, i].Value) == false)
                {
                    for (int j = 0; j < dtgrdVaildTempOrder.Rows.Count; j++)
                    {
                        int tempgroupid = Convert.ToInt32(dtgrdVaildTempOrder[dataGridViewTextBoxColumn7.Name, j].Value.ToString());
                        if (group_id == tempgroupid)
                        {
                            dtgrdVaildTempOrder[0, j].Value = true;
                            for (int k = 0; k < dtgrdVaildTempOrder.Columns.Count; k++)
                            {
                                dtgrdVaildTempOrder.Rows[j].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                                dtgrdVaildTempOrder.Rows[j].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
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
                    for (int j = 0; j < dtgrdVaildTempOrder.Rows.Count; j++)
                    {
                        int tempgroupid = Convert.ToInt32(dtgrdVaildTempOrder[dataGridViewTextBoxColumn7.Name, j].Value.ToString());
                        if (group_id == tempgroupid)
                        {
                            dtgrdVaildTempOrder[0, j].Value = false;
                            for (int k = 0; k < dtgrdVaildTempOrder.Columns.Count; k++)
                            {
                                dtgrdVaildTempOrder.Rows[j].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
                                dtgrdVaildTempOrder.Rows[j].Cells[k].Style.BackColor = System.Drawing.Color.White;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 长期账单选中项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgrdVaildLongAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 0)
            {
                int i = e.RowIndex;
                if (Convert.ToBoolean(dtgrdVaildLongAccount[0, i].Value) ==false)
                {
                    dtgrdVaildLongAccount[0, i].Value = true;
                    for (int k = 0; k < dtgrdVaildLongAccount.Columns.Count; k++)
                    {
                        dtgrdVaildLongAccount.Rows[i].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                        dtgrdVaildLongAccount.Rows[i].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                    }                    
                }
                else
                {
                    dtgrdVaildLongAccount[0, i].Value =false;
                    for (int k = 0; k < dtgrdVaildLongAccount.Columns.Count; k++)
                    {
                        dtgrdVaildLongAccount.Rows[i].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
                        dtgrdVaildLongAccount.Rows[i].Cells[k].Style.BackColor = System.Drawing.Color.White;
                    }                   
                }
            }
        }
        /// <summary>
        /// 临时账单选中项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgrdValidTempAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 0)
            {
                int i = e.RowIndex;
                if (Convert.ToBoolean(dtgrdValidTempAccount[0, i].Value) == false)
                {
                    dtgrdValidTempAccount[0, i].Value = true;
                    for (int k = 0; k < dtgrdValidTempAccount.Columns.Count; k++)
                    {
                        dtgrdValidTempAccount.Rows[i].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                        dtgrdValidTempAccount.Rows[i].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                    }
                }
                else
                {
                    dtgrdValidTempAccount[0, i].Value = false;
                    for (int k = 0; k < dtgrdValidTempAccount.Columns.Count; k++)
                    {
                        dtgrdValidTempAccount.Rows[i].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
                        dtgrdValidTempAccount.Rows[i].Cells[k].Style.BackColor = System.Drawing.Color.White;
                    }
                }
            }
        }
        /// <summary>
        /// 所有长期医嘱选中时医嘱分组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewEx5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 0)
            {
                int i = e.RowIndex;
                int group_id = Convert.ToInt32(dataGridViewEx5[dataGridViewTextBoxColumn51.Name, i].Value.ToString());
                if (Convert.ToBoolean(dataGridViewEx5[dataGridViewCheckBoxColumn4.Name, i].Value) == false)
                {
                    for (int j = 0; j < dataGridViewEx5.Rows.Count; j++)
                    {
                        int tempgroupid = Convert.ToInt32(dataGridViewEx5[dataGridViewTextBoxColumn51.Name, j].Value.ToString());
                        if (group_id == tempgroupid)
                        {
                            dataGridViewEx5[0, j].Value = true;
                            for (int k = 0; k < dataGridViewEx5.Columns.Count; k++)
                            {
                                dataGridViewEx5.Rows[j].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                                dataGridViewEx5.Rows[j].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;                               
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
                    for (int j = 0; j < dataGridViewEx5.Rows.Count; j++)
                    {
                        int tempgroupid = Convert.ToInt32(dataGridViewEx5[dataGridViewTextBoxColumn51.Name, j].Value.ToString());
                        if (group_id == tempgroupid)
                        {
                            dataGridViewEx5[0, j].Value = false;
                            for (int k = 0; k < dataGridViewEx5.Columns.Count; k++)
                            {
                                dataGridViewEx5.Rows[j].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
                                dataGridViewEx5.Rows[j].Cells[k].Style.BackColor = System.Drawing.Color.White;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 所有临时医嘱选中时医嘱分组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewEx6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 0)
            {
                int i = e.RowIndex;
                int group_id = Convert.ToInt32(dataGridViewEx6[dataGridViewTextBoxColumn55.Name, i].Value.ToString());
                if (Convert.ToBoolean(dataGridViewEx6[dataGridViewCheckBoxColumn5.Name, i].Value) == false)
                {
                    for (int j = 0; j < dataGridViewEx6.Rows.Count; j++)
                    {
                        int tempgroupid = Convert.ToInt32(dataGridViewEx6[dataGridViewTextBoxColumn55.Name, j].Value.ToString());
                        if (group_id == tempgroupid)
                        {
                            dataGridViewEx6[0, j].Value = true;
                            for (int k = 0; k < dataGridViewEx6.Columns.Count; k++)
                            {
                                dataGridViewEx6.Rows[j].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                                dataGridViewEx6.Rows[j].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
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
                    for (int j = 0; j < dataGridViewEx6.Rows.Count; j++)
                    {
                        int tempgroupid = Convert.ToInt32(dataGridViewEx6[dataGridViewTextBoxColumn55.Name, j].Value.ToString());
                        if (group_id == tempgroupid)
                        {
                            dataGridViewEx6[0, j].Value = false;
                            for (int k = 0; k < dataGridViewEx6.Columns.Count; k++)
                            {
                                dataGridViewEx6.Rows[j].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
                                dataGridViewEx6.Rows[j].Cells[k].Style.BackColor = System.Drawing.Color.White;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 所有长期账单选中操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewEx7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 0)
            {
                int i = e.RowIndex;
                if (Convert.ToBoolean(dataGridViewEx7[0, i].Value) == false)
                {
                    dataGridViewEx7[0, i].Value = true;
                    for (int k = 0; k < dataGridViewEx7.Columns.Count; k++)
                    {
                        dataGridViewEx7.Rows[i].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                        dataGridViewEx7.Rows[i].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                    }
                }
                else
                {
                    dataGridViewEx7[0, i].Value = false;
                    for (int k = 0; k < dataGridViewEx7.Columns.Count; k++)
                    {
                        dataGridViewEx7.Rows[i].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
                        dataGridViewEx7.Rows[i].Cells[k].Style.BackColor = System.Drawing.Color.White;
                    }
                }
            }
        }
        /// <summary>
        /// 所有临时账单选中操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewEx8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 0)
            {
                int i = e.RowIndex;
                if (Convert.ToBoolean(dataGridViewEx8[0, i].Value) == false)
                {
                    dataGridViewEx8[0, i].Value = true;
                    for (int k = 0; k < dataGridViewEx8.Columns.Count; k++)
                    {
                        dataGridViewEx8.Rows[i].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                        dataGridViewEx8.Rows[i].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                    }
                }
                else
                {
                    dataGridViewEx8[0, i].Value = false;
                    for (int k = 0; k < dataGridViewEx8.Columns.Count; k++)
                    {
                        dataGridViewEx8.Rows[i].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
                        dataGridViewEx8.Rows[i].Cells[k].Style.BackColor = System.Drawing.Color.White;
                    }
                }
            }
        }
        /// <summary>
        /// 停长期账单操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnstopaccount_Click(object sender, EventArgs e)
        {
            int orderid;
            List<int> orderlist = new List<int>();
            for(int i=0;i<dtgrdVaildLongAccount.Rows.Count;i++)
            {
              if(Convert.ToBoolean(dtgrdVaildLongAccount[dataGridViewCheckBoxColumn1.Name,i].Value)==true)
              {
                  orderid =Convert.ToInt32(dtgrdVaildLongAccount[Column14.Name,i].Value.ToString());
                  orderlist.Add(orderid);
              }
            }
            bool updateresult=op_order.updatelongaccountflag(orderlist);
            if (updateresult == true)
            {
                MessageBox.Show("您的长期账单已停止！", "提示", MessageBoxButtons.OK);
                ordertype = 2;
                dtgrdVaildLongAccount.DataSource = op_order.getOrder(patlistid, ordertype);
            }
            else
            {
                MessageBox.Show("您的停长期账单操作失败，请稍候重试！", "提示", MessageBoxButtons.OK);
            }
        }       
        /// <summary>
        /// 皮试结果置为阳性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnZ_Click(object sender, EventArgs e)
        {
            if (dtgrdVaildTempOrder.Rows.Count > 0)
            {
                int rownum = dtgrdVaildTempOrder.CurrentCell.RowIndex;                
                //int makedicid = Convert.ToInt32(dtgrdVaildTempOrder["makeid", rownum].Value.ToString());
                decimal psorderid = Convert.ToDecimal(dtgrdVaildTempOrder["psorderid", rownum].Value.ToString());
                //bool psresult = op_order.getPSresult(makedicid);
                //if (psresult == false)
                //{
                //    MessageBox.Show("该药不需要皮试！", "提示");
                //}
                //else
                //{
                    if (psorderid != Convert.ToDecimal(0))
                    {
                        string str = dtgrdVaildTempOrder[dataGridViewTextBoxColumn17.Name, rownum].Value.ToString();
                        DialogResult dr = MessageBox.Show("您确定将【" + str + "】的皮试结果标为(+)吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            bool result = op_order.setPSZresult(psorderid);
                            if (result == true)
                            {
                                MessageBox.Show("系统已成功修改皮试结果", "提示");
                                dtgrdVaildTempOrder.DataSource = op_order.getValidOrder(patlistid, ordertype);
                            }
                            else
                            {
                                MessageBox.Show("修改皮试结果失败，请稍后重试", "提示");
                            }                            
                            btnZ.Enabled = false;
                            btnF.Enabled = false;
                        }
                        else
                        {                            
                            btnF.Enabled = false;
                            btnZ.Enabled = false;
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("该条医嘱是皮试用药，您应该对皮试说明项置标记", "提示");                        
                        btnF.Enabled = false;
                        btnZ.Enabled = false;
                    }
                //}
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// 皮试结果置为阴性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF_Click(object sender, EventArgs e)
        {
            if (dtgrdVaildTempOrder.Rows.Count > 0)
            {
                int rownum = dtgrdVaildTempOrder.CurrentCell.RowIndex;
                //int orderid =Convert.ToInt32(dtgrdVaildLongOrder[Column12.Name, rownum].Value.ToString());
                //int makedicid = Convert.ToInt32(dtgrdVaildTempOrder["makeid", rownum].Value.ToString());
                decimal psorderid = Convert.ToDecimal(dtgrdVaildTempOrder["psorderid", rownum].Value.ToString());
                //bool psresult = op_order.getPSresult(makedicid);
                //if (psresult == false)
                //{
                //    MessageBox.Show("该药不需要皮试！", "提示");
                //}
                //else
                //{
                    if (psorderid != Convert.ToDecimal(0))
                    {
                        string str = dtgrdVaildTempOrder[dataGridViewTextBoxColumn17.Name, rownum].Value.ToString();
                        DialogResult dr = MessageBox.Show("您确定将【" + str + "】的皮试结果标为(-)吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            bool result = op_order.setPSFresult(psorderid);
                            if (result == true)
                            {
                                MessageBox.Show("系统已成功修改皮试结果", "提示");
                                dtgrdVaildTempOrder.DataSource = op_order.getValidOrder(patlistid, ordertype);
                            }
                            else
                            {
                                MessageBox.Show("修改皮试结果失败，请稍后重试", "提示");
                            }
                            //chkresult.Enabled = true;
                            //chkresult.Enabled = false;
                            btnZ.Enabled = false;
                            btnF.Enabled = false;
                        }
                        else
                        {
                            //chkresult.Enabled = true;
                            //chkresult.Enabled = false;
                            btnZ.Enabled = false;
                            btnF.Enabled = false;
                            return;
                        }
                    //}
                    //else
                    //{
                    //    MessageBox.Show("该条医嘱是皮试用药，您应该对皮试说明项置标记", "提示");
                    //    //chkresult.Enabled = true;
                    //    //chkresult.Checked = false;
                    //    btnF.Enabled = false;
                    //    btnZ.Enabled = false;
                    //}
                }
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnrefresh_Click(object sender, EventArgs e)
        {
            //dtgpatlist.DataSource = op_order.getPatList(Convert.ToInt32(_currentDept.DeptID));//2.24新增
            if (pageselection.SelectedIndex == 0)
            {
                ordertype = 0;
                btnstopaccount.Enabled = false;
                btncalaccount.Enabled = false;
                btnsend.Enabled = true;                
                dtgrdVaildLongOrder.AutoGenerateColumns = false;
                dtgrdVaildLongOrder.DataSource = op_order.getOrder(patlistid, ordertype);
            }
            else if (pageselection.SelectedIndex == 1)
            {
                ordertype = 1;
                btnstopaccount.Enabled = false;
                btncalaccount.Enabled = false;
                btnsend.Enabled = true;                
                dtgrdVaildTempOrder.AutoGenerateColumns = false;
                dtgrdVaildTempOrder.DataSource = op_order.getValidOrder(patlistid, ordertype);
            }
            else if (pageselection.SelectedIndex == 2)
            {
                ordertype = 2;
                btnstopaccount.Enabled = true;
                btncalaccount.Enabled = false;
                btnsend.Enabled = true;               
                dtgrdVaildLongAccount.AutoGenerateColumns = false;
                dtgrdVaildLongAccount.DataSource = op_order.getOrder(patlistid, ordertype);
            }
            else if (pageselection.SelectedIndex == 3)
            {
                ordertype = 3;
                btnstopaccount.Enabled = false;
                btncalaccount.Enabled = false;
                btnsend.Enabled = true;              
                dtgrdValidTempAccount.AutoGenerateColumns = false;
                dtgrdValidTempAccount.DataSource = op_order.getOrder(patlistid, ordertype);
            }
            else if (pageselection.SelectedIndex == 4)
            {
                ordertype = 0;
                btnstopaccount.Enabled = false;
                btncalaccount.Enabled = true;
                btnsend.Enabled = false;              
                dataGridViewEx5.AutoGenerateColumns = false;
                dataGridViewEx5.DataSource = op_order.getAllOrder(patlistid, ordertype);
            }
            else if (pageselection.SelectedIndex == 5)
            {
                ordertype = 1;
                btnstopaccount.Enabled = false;
                btncalaccount.Enabled = true;
                btnsend.Enabled = false;               
                dataGridViewEx6.AutoGenerateColumns = false;
                dataGridViewEx6.DataSource = op_order.getAllTempOrder(patlistid, ordertype);
            }
            else if (pageselection.SelectedIndex == 6)
            {
                ordertype = 2;
                btnstopaccount.Enabled = false;
                btncalaccount.Enabled = true;
                btnsend.Enabled = false;                
                dataGridViewEx7.AutoGenerateColumns = false;
                dataGridViewEx7.DataSource = op_order.getAllOrder(patlistid, ordertype);
            }
            else if (pageselection.SelectedIndex == 7)
            {
                ordertype = 3;
                btnstopaccount.Enabled = false;
                btncalaccount.Enabled = true;
                btnsend.Enabled = false;                
                dataGridViewEx8.AutoGenerateColumns = false;
                dataGridViewEx8.DataSource = op_order.getAllTempOrder(patlistid, ordertype);
            }
        }
        /// <summary>
        /// 个人明日非口服药品统领
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btngetdrug_Click(object sender, EventArgs e)
        {
            if (pageselection.SelectedIndex == 0)
            {
                List<int> list = new List<int>();
                int orderid;
                bool result;
                ordertype = 0;
                for (int i = 0; i < dtgrdVaildLongOrder.Rows.Count; i++)
                {
                    string useage = dtgrdVaildLongOrder[Column19.Name, i].Value.ToString();
                    if (Convert.ToInt32(dtgrdVaildLongOrder[Column29.Name, i].Value.ToString()) < 4 && !op_order.getUseage(useage))
                    {
                        orderid = Convert.ToInt32(dtgrdVaildLongOrder[1, i].Value.ToString());
                        list.Add(orderid);
                    }
                }
                TomorrowDrug tomorrowdrug = new TomorrowDrug();
                result = tomorrowdrug.Send(list, Convert.ToInt32(_currentUser.EmployeeID), patlistid);
                if (result == true)
                {
                    MessageBox.Show("明日非口服药已成功发送！", "提示", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("明日非口服药发送失败！", "提示", MessageBoxButtons.OK);
                }
                dtgrdVaildLongOrder.DataSource = op_order.getOrder(patlistid, ordertype);
            }
            else
            {
                MessageBox.Show("明日非口服药只适用于有效长嘱！", "提示", MessageBoxButtons.OK);
            }
        }
        /// <summary>
        /// 科室明日非口服药品统领
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendAllDrug_Click(object sender, EventArgs e)
        {
            int personid;        
            List<int> personlist = new List<int>();
            for (int personnum = 0; personnum < dtgpatlist.Rows.Count; personnum++)
            {
                if (Convert.ToBoolean(dtgpatlist[0, personnum].Value) == true)
                {
                    personid = Convert.ToInt32(dtgpatlist[Column11.Name, personnum].Value.ToString());
                    personlist.Add(personid);
                }
            }
            if (personlist.Count == 0)
            {
                MessageBox.Show("您还未选中要发送的病人，请选中后再发送！", "提示", MessageBoxButtons.OK);
                return;
            }
            else
            {
                if (MessageBox.Show("批量发送病人医嘱需要时间比较长，是否继续发送？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                UIStat2();
                this.progressBar1.Maximum = personlist.Count;
                thread = new Thread(new ThreadStart(SendAllDrug1));
                thread.Start();
                //SendAllDrug1();
            }
        }
        /// <summary>
        ///明日非口服药品
        /// </summary>
        private void SendAllDrug1()
        {
            int personid;
            List<int> personlist = new List<int>();
            for (int personnum = 0; personnum < dtgpatlist.Rows.Count; personnum++)
            {
                if (Convert.ToBoolean(dtgpatlist[0, personnum].Value) == true)
                {
                    personid = Convert.ToInt32(dtgpatlist[Column11.Name, personnum].Value.ToString());
                    personlist.Add(personid);
                }
            }
            //this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
            DataTable patdt = (DataTable)dtgpatlist.DataSource;
            //label1.Visible = true;
            //label2.Visible = true;
            //label3.Visible = true;
            //label4.Visible = true;
            
            for (int i = 0; i < personlist.Count; i++)
            {
                DataRow[] rows = patdt.Select("patlist_id=" + personlist[i]);
                //label2.Text = rows[0]["patname"].ToString();
                //label3.Text = "的明日非口服药";
                //label4.Text = "【" + (i + 1) + "/" + personlist.Count + "】";
                //label1.Refresh();
                //label2.Refresh();
                //label3.Refresh();
                //label4.Refresh();
                //this.progressBar1.Value = (i + 1) * 100 / personlist.Count;

                threadSend(rows[0]["patname"].ToString(), i, personlist.Count);// add zenghao

                DataTable dt1 = op_order.getOrder(personlist[i], 0);
                List<int> orderidlist1 = new List<int>();
                foreach (DataRow dr in dt1.Rows)
                {
                    int item_type = Convert.ToInt32(dr["item_type"].ToString());
                    if (item_type < 4)
                    {
                        string useage = dr["order_usage"].ToString();
                        if (!op_order.getUseage(useage))
                        {
                            int orderid = Convert.ToInt32(dr["ORDER_ID"].ToString());
                            orderidlist1.Add(orderid);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                TomorrowDrug tomorrowdrug = new TomorrowDrug();
                bool result = tomorrowdrug.Send(orderidlist1, Convert.ToInt32(_currentUser.EmployeeID), patlistid);
            }
            //dtgrdVaildLongOrder.DataSource = op_order.getOrder(patlistid, ordertype);
            //label1.Visible = false;
            //label2.Visible = false;
            //label3.Visible = false;
            //label4.Visible = false;
            //this.Cursor = System.Windows.Forms.Cursors.Default;
            //MessageBox.Show("科室明日非口服药已发送完毕！", "提示", MessageBoxButtons.OK);

            threadSendOver();// add zenghao
        }
        /// <summary>
        /// 科室病人全部医嘱发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAllSend_Click(object sender, EventArgs e)
        {           
            int personid;
            List<int> personlist = new List<int>();
            for(int personnum=0;personnum<dtgpatlist.Rows.Count;personnum++)
            {               
                if (Convert.ToBoolean(dtgpatlist[Column1.Name, personnum].Value) == true)
                {
                    personid = Convert.ToInt32(dtgpatlist[Column11.Name, personnum].Value.ToString());
                    personlist.Add(personid);  
                }
            }
            if (personlist.Count == 0)
            {
                MessageBox.Show("您还未选中要发送的病人，请选中后再发送！", "提示", MessageBoxButtons.OK);
                return;
            }
            else
            {
                if (MessageBox.Show("批量发送病人医嘱需要时间比较长，是否继续发送？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                UIStat2();
                this.progressBar1.Maximum = personlist.Count;
                thread = new Thread(new ThreadStart(SendAllDrug2));
                thread.Start();

            }
        }

        private void SendAllDrug2()
        {
            int personid;
            List<int> personlist = new List<int>();
            for (int personnum = 0; personnum < dtgpatlist.Rows.Count; personnum++)
            {
                if (Convert.ToBoolean(dtgpatlist[Column1.Name, personnum].Value) == true)
                {
                    personid = Convert.ToInt32(dtgpatlist[Column11.Name, personnum].Value.ToString());
                    personlist.Add(personid);
                }
            }
            //this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
            DataTable patdt = (DataTable)dtgpatlist.DataSource;
            //label1.Visible = true;
            //label2.Visible = true;
            //label3.Visible = true;
            //label4.Visible = true;

            for (int i = 0; i < personlist.Count; i++)
            {
                DataRow[] rows = patdt.Select("patlist_id=" + personlist[i]);
                //label2.Text = rows[0]["patname"].ToString();
                //label3.Text = "的今日医嘱";
                //label4.Text = "【" + (i + 1) + "/" + personlist.Count + "】";
                //label1.Refresh();
                //label2.Refresh();
                //label3.Refresh();
                //label4.Refresh();
                //this.progressBar1.Value = (i + 1) * 100 / personlist.Count;
                threadSend(rows[0]["patname"].ToString(), i, personlist.Count);// add zenghao

                //update by heyan 2011.5.10 医嘱当中有库存为0的停止发送，但账单要发送完。把账单发送的放在try的外面。
                DataTable dt3 = op_order.getOrder(personlist[i], 2);
                List<int> orderidlist3 = new List<int>();
                foreach (DataRow dr in dt3.Rows)
                {
                    int orderid = Convert.ToInt32(dr["order_id"].ToString());
                    orderidlist3.Add(orderid);
                }
                op_order.longvaildaccountsend(orderidlist3, _currentUser.EmployeeID, personlist[i]);

                DataTable dt4 = op_order.getOrder(personlist[i], 3);
                List<int> orderidlist4 = new List<int>();
                foreach (DataRow dr in dt4.Rows)
                {
                    int orderid = Convert.ToInt32(dr["order_id"].ToString());
                    orderidlist4.Add(orderid);
                }
                op_order.tempvalidaccountsend(orderidlist4, _currentUser.EmployeeID, personlist[i]);
                try
                {
                    DataTable dt1 = op_order.getOrder(personlist[i], 0);
                    List<int> orderidlist1 = new List<int>();
                    foreach (DataRow dr in dt1.Rows)
                    {
                        int orderid = Convert.ToInt32(dr["ORDER_ID"].ToString());
                        orderidlist1.Add(orderid);
                    }
                    Order Longorder = new Order();
                    Longorder.Send(orderidlist1, Convert.ToInt32(_currentUser.EmployeeID), patlistid);
                    //op_order.longvaildordersend(orderidlist1, _currentUser.EmployeeID, personlist[i]);

                    DataTable dt2 = op_order.getValidOrder(personlist[i], 1);
                    List<int> orderidlist2 = new List<int>();
                    foreach (DataRow dr in dt2.Rows)
                    {
                        int orderid = Convert.ToInt32(dr["order_id"].ToString());
                        orderidlist2.Add(orderid);
                    }
                    Order Temporder = new Order();
                    Temporder.Send(orderidlist2, Convert.ToInt32(_currentUser.EmployeeID), patlistid);
                    //op_order.tempvaildordersend(orderidlist2, _currentUser.EmployeeID, personlist[i]);
                }
                catch (Exception ex)
                {                  
                    continue;
                }
            }
            //label1.Visible = false;
            //label2.Visible = false;
            //label3.Visible = false;
            //label4.Visible = false;
            //this.Cursor = System.Windows.Forms.Cursors.Default;
            //MessageBox.Show("科室医嘱项目发送完毕！", "提示", MessageBoxButtons.OK);
            threadSendOver();// add zenghao
        }
        /// <summary>
        /// 判断临时医嘱点击项是否为皮试说明项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgrdVaildTempOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rownum = dtgrdVaildTempOrder.CurrentCell.RowIndex;           
            string useage = dtgrdVaildTempOrder[Column18.Name, rownum].Value.ToString();
            string ps = dtgrdVaildTempOrder["ps", rownum].Value.ToString();
            if(useage=="皮试")
            {            
                btnZ.Enabled = true;
                btnF.Enabled = true;
            }
            else
            {
                btnZ.Enabled = false;
                btnF.Enabled = false;
            }
        }
        /// <summary>
        /// 取消转抄医嘱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnstoptrans_Click(object sender, EventArgs e)
        {
            int row;
            if (op_order.IsCanTrans(patlistid))
            {
                return;
            }   
            if (pageselection.SelectedIndex == 0)
            {
                List<int> list = new List<int>();
                int orderid;
                bool result;
                ordertype = 0;
                for (int i = 0; i < dtgrdVaildLongOrder.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dtgrdVaildLongOrder[0, i].Value) == true)
                    {
                        orderid = Convert.ToInt32(dtgrdVaildLongOrder[1, i].Value.ToString());
                        list.Add(orderid);
                    }
                }
                if (list.Count == 0)
                {
                    MessageBox.Show("您未选中要取消转抄的长期医嘱项！", "提示", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    result = op_order.orderstoptrans(list, _currentUser.EmployeeID, patlistid);
                }
                if (result == true)
                {
                    MessageBox.Show("取消转抄长期医嘱成功！", "提示", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("取消转抄长期医嘱失败，请稍候重新发送！", "提示", MessageBoxButtons.OK);
                }
                dtgrdVaildLongOrder.DataSource = op_order.getOrder(patlistid, ordertype);
            }
            else if (pageselection.SelectedIndex == 1)
            {
                row = dtgrdVaildTempOrder.Rows.Count;
                List<int> list = new List<int>();
                int orderid;
                bool result;
                ordertype = 1;
                for (int i = 0; i < row; i++)
                {
                    if (Convert.ToBoolean(dtgrdVaildTempOrder[0, i].Value) == true)
                    {
                        orderid = Convert.ToInt32(dtgrdVaildTempOrder[Column13.Name, i].Value.ToString());
                        list.Add(orderid);
                    }
                }
                if (list.Count == 0)
                {
                    MessageBox.Show("您未选中要取消转抄的临时医嘱项！", "提示", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    result = op_order.orderstoptrans(list, _currentUser.EmployeeID, patlistid);
                }
                if (result == true)
                {
                    MessageBox.Show("取消转抄临时医嘱成功！", "提示", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("取消转抄临时医嘱发送失败，请稍候重新发送！", "提示", MessageBoxButtons.OK);
                }
                dtgrdVaildTempOrder.DataSource = op_order.getValidOrder(patlistid, ordertype);
            }
            else
            {
                return;
            }

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
        /// <summary>
        /// 医嘱打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnprint_Click(object sender, EventArgs e)
        {
            FrmOrderPrint frmorderprint = new FrmOrderPrint(patlistid, _currentUser.UserID, _currentDept.DeptID, "医嘱打印");
            frmorderprint.Show();
        }

        private void FrmOrderManager_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                btnsend.PerformClick();
            }
            else if(e.KeyCode == Keys.F3)
            {
                btncalaccount.PerformClick();
            }
            else if (e.KeyCode == Keys.F5)
            {
                btnprint.PerformClick();
            }
            else if (e.KeyCode == Keys.F6)
            {
                btnstoptrans.PerformClick();
            }
            else if (e.KeyCode == Keys.F7)
            {
                btnstopaccount.PerformClick();
            }
            else if (e.KeyCode == Keys.F8)
            {
                btngetdrug.PerformClick();
            }
        }

        private void btnfresh_Click(object sender, EventArgs e)
        {
            dtgpatlist.DataSource = op_order.getPatList(Convert.ToInt32(_currentDept.DeptID));//2.24新增
        }

        private void btnSingleSendTomorrowDrug_Click(object sender, EventArgs e)
        {
            if (pageselection.SelectedIndex == 0)
            {
                List<int> list = new List<int>();
                int orderid;
                bool result;
                ordertype = 0;
                for (int i = 0; i < dtgrdVaildLongOrder.Rows.Count; i++)
                {
                    string useage = dtgrdVaildLongOrder[Column19.Name, i].Value.ToString();
                    if (Convert.ToInt32(dtgrdVaildLongOrder[Column29.Name, i].Value.ToString()) < 4)//&& !op_order.getUseage(useage)
                    {
                        orderid = Convert.ToInt32(dtgrdVaildLongOrder[1, i].Value.ToString());
                        list.Add(orderid);
                    }
                }
                TomorrowDrug tomorrowdrug = new TomorrowDrug();
                result = tomorrowdrug.Send(list, Convert.ToInt32(_currentUser.EmployeeID), patlistid);
                if (result == true)
                {
                    MessageBox.Show("个人明日药品已成功发送！", "提示", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("个人明日药品发送失败！", "提示", MessageBoxButtons.OK);
                }
                dtgrdVaildLongOrder.DataSource = op_order.getOrder(patlistid, ordertype);
            }
        }
        /// <summary>
        /// 科室明日药品发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendTomorrowDrug_Click(object sender, EventArgs e)
        {
            int personid;
            //int orderid;
            List<int> personlist = new List<int>();
            for (int personnum = 0; personnum < dtgpatlist.Rows.Count; personnum++)
            {
                if (Convert.ToBoolean(dtgpatlist[0, personnum].Value) == true)
                {
                    personid = Convert.ToInt32(dtgpatlist[Column11.Name, personnum].Value.ToString());
                    personlist.Add(personid);
                }
            }
            if (personlist.Count == 0)
            {
                MessageBox.Show("您还未选中要发送的病人，请选中后再发送！", "提示", MessageBoxButtons.OK);
                return;
            }
            else
            {
                if (MessageBox.Show("批量发送病人医嘱需要时间比较长，是否继续发送？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                UIStat2();
                this.progressBar1.Maximum = personlist.Count;
                thread = new Thread(new ThreadStart(SendAllDrug3));
                thread.Start();
            }
        }

        private void SendAllDrug3()
        {
            int personid;
            int orderid;
            List<int> personlist = new List<int>();
            for (int personnum = 0; personnum < dtgpatlist.Rows.Count; personnum++)
            {
                if (Convert.ToBoolean(dtgpatlist[0, personnum].Value) == true)
                {
                    personid = Convert.ToInt32(dtgpatlist[Column11.Name, personnum].Value.ToString());
                    personlist.Add(personid);
                }
            }

            //this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
            DataTable patdt = (DataTable)dtgpatlist.DataSource;
            //label1.Visible = true;
            //label2.Visible = true;
            //label3.Visible = true;
            //label4.Visible = true;

            for (int i = 0; i < personlist.Count; i++)
            {
                DataRow[] rows = patdt.Select("patlist_id=" + personlist[i]);
                //label2.Text = rows[0]["patname"].ToString();
                //label3.Text = "的明日药品";
                //label4.Text = "【" + (i + 1) + "/" + personlist.Count + "】";
                //label1.Refresh();
                //label2.Refresh();
                //label3.Refresh();
                //label4.Refresh();
                //this.progressBar1.Value = (i + 1) * 100 / personlist.Count;
                threadSend(rows[0]["patname"].ToString(), i, personlist.Count);// add zenghao
                DataTable dt1 = op_order.getOrder(personlist[i], 0);
                List<int> orderidlist1 = new List<int>();
                foreach (DataRow dr in dt1.Rows)
                {
                    int item_type = Convert.ToInt32(dr["item_type"].ToString());
                    if (item_type < 4)
                    {
                        orderid = Convert.ToInt32(dr["ORDER_ID"].ToString());
                        orderidlist1.Add(orderid);
                    }
                    else
                    {
                        continue;
                    }
                }
                TomorrowDrug tomorrowdrug = new TomorrowDrug();
                bool result = tomorrowdrug.Send(orderidlist1, Convert.ToInt32(_currentUser.EmployeeID), patlistid);
            }
            //dtgrdVaildLongOrder.DataSource = op_order.getOrder(patlistid, ordertype);
            //label1.Visible = false;
            //label2.Visible = false;
            //label3.Visible = false;
            //label4.Visible = false;
            //this.Cursor = System.Windows.Forms.Cursors.Default;
            //MessageBox.Show("科室明日药品已发送完毕！", "提示", MessageBoxButtons.OK);
            threadSendOver();// add zenghao
        }

        private void dtgpatlist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 0)
            {
                int i = e.RowIndex;
                if (Convert.ToBoolean(dtgpatlist[Column1.Name, i].Value) == false)
                {
                    dtgpatlist[0, i].Value = true;
                    //for (int k = 0; k < dtgpatlist.Columns.Count; k++)
                    //{
                    //    dtgpatlist.Rows[i].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                    //    dtgpatlist.Rows[i].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                    //}                   
                }
                else
                {                 
                    dtgpatlist[0, i].Value = false;
                    //for (int k = 0; k < dtgpatlist.Columns.Count; k++)
                    //{
                    //    dtgpatlist.Rows[i].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
                    //    dtgpatlist.Rows[i].Cells[k].Style.BackColor = System.Drawing.Color.White;
                    //}                  
                }
            }
        }

        //线程外访问控件,更改控件值
        //delegate void SetToolCallback(ToolStrip ts, bool b, ToolStripItem tsb);
        //private void SetEnabled(ToolStrip ts, bool b, ToolStripItem tsb)
        //{
        //    // InvokeRequired required compares the thread ID of the
        //    // calling thread to the thread ID of the creating thread.
        //    // If these threads are different, it returns true.
        //    if (ts.InvokeRequired)
        //    {
        //        SetToolCallback d = new SetToolCallback(SetEnabled);
        //        this.Invoke(d, new object[] { ts, b, tsb });
        //    }
        //    else
        //    {
        //        ts.Enabled = b;
        //        //tsb.Enabled = b;
        //    }
        //}

        delegate void SetVisibleCallback(Control control, bool value);
        private void SetVisible(Control control, bool value)
        {
            if (control.InvokeRequired)
            {
                SetVisibleCallback sc = new SetVisibleCallback(SetVisible);
                this.Invoke(sc, new object[] { control, value });
            }
            else
            {
                control.Visible = value;
            }
        }
        delegate void SetEnabledCallback(Control control, bool value);
        private void SetEnabled(Control control, bool value)
        {
            if (control.InvokeRequired)
            {
                SetEnabledCallback sc = new SetEnabledCallback(SetEnabled);
                this.Invoke(sc, new object[] { control, value });
            }
            else
            {
                control.Enabled = value;
            }
        }
        
        delegate void SetLabCallback(Label rtb, string value);
        private void SetMessageText(Label rtb, string value)
        {
            if (rtb.InvokeRequired)
            {
                SetLabCallback sc = new SetLabCallback(SetMessageText);
                this.Invoke(sc, new object[] { rtb, value });
            }
            else
            {
                rtb.Text=value;
            }
        }

        delegate void SetBarCallback(ProgressBar bar, int value);
        private void SetBarValue(ProgressBar bar, int value)
        {
            if (bar.InvokeRequired)
            {
                SetBarCallback sc = new SetBarCallback(SetBarValue);
                this.Invoke(sc, new object[] { bar, value });
            }
            else
            {
                bar.Value = value;
            }
        }

        /// <summary>
        /// 待发送
        /// </summary>
        private void UIStat1()
        {
            this.label1.Visible = false;
            this.label2.Visible = false;
            this.label3.Visible = false;
            this.label4.Visible = false;
            this.btnStop.Visible = false;
            this.toolStrip2.Enabled = true;

            this.progressBar1.Value = 0;

            this.toolStrip1.Enabled = true;
        }

        /// <summary>
        /// 正在发送
        /// </summary>
        private void UIStat2()
        {
            this.label1.Visible = true;
            this.label2.Visible = true;
            this.label3.Visible = true;
            this.label4.Visible = true;
            this.btnStop.Visible = true;
            this.toolStrip2.Enabled = false;

            this.toolStrip1.Enabled = false;
        }

        /// <summary>
        /// 发送线程
        /// </summary>
        private Thread thread;
        /// <summary>
        /// 停止发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("当前界面正在发送医嘱，是否停止发送？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            thread.Abort();
            UIStat1();
        }

        /// <summary>
        /// 医嘱正在发送显示进度
        /// </summary>
        private void threadSend(string patname,int index,int allcount)
        {
            SetMessageText(label2, patname);
            SetMessageText(label3, "的医嘱");
            SetMessageText(label4, "【" + (index + 1) + "/" + allcount + "】");
            SetBarValue(progressBar1, index + 1);
        }

        /// <summary>
        /// 医嘱发送完成
        /// </summary>
        private void threadSendOver()
        {
            SetVisible(this.label1, false);
            SetVisible(this.label2, false);
            SetVisible(this.label3, false);
            SetVisible(this.label4, false);
            SetVisible(this.btnStop, false);
            SetEnabled(toolStrip2, true);
            SetBarValue(progressBar1, 0);

            SetEnabled(toolStrip1, true);
            MessageBox.Show("医嘱发送完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmOrderManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (thread.ThreadState == ThreadState.Running)
            //{
            //    if (MessageBox.Show("当前界面正在发送医嘱，是否继续关闭？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //    {
            //        return;
            //    }
            //    thread.Abort();
            //}
        }

        private void btclose_Click(object sender, EventArgs e)
        {
            if (thread == null)
            {
                this.Close();
            }
            else if (thread.ThreadState == ThreadState.Running)
            {
                if (MessageBox.Show("当前界面正在发送医嘱，是否继续关闭？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                thread.Abort();
                UIStat1();
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

    }
}
