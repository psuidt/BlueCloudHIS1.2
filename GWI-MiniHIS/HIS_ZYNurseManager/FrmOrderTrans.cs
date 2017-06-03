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
    public partial class FrmOrderTrans :GWI.HIS.Windows.Controls.BaseMainForm
    {
        private bool _isInitialize = true;
        private DataTable dt;
        private int rownum;
        private int[] a;
        OP_Order op_order = new OP_Order();
        OP_Bed op_bed = new OP_Bed();
        HIS.ZY_BLL.ObjectModel.CostManager.IcostManager IcM = null;
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
        public FrmOrderTrans(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            this.Text = chineseName;
            IcM = HIS.ZY_BLL.ObjectModel.ObjectFactory.GetObject<HIS.ZY_BLL.ObjectModel.CostManager.IcostManager>(typeof(HIS.ZY_BLL.DataModel.ZY_CostMaster));
        }
        /// <summary>
        /// 加载医嘱数据及区分医嘱颜色
        /// </summary>
        private void RefreshSource()
        {
            
            dtgrdOrderTrans.AutoGenerateColumns = false;
            DataTable dt=op_order.getOrderList(_currentDept.DeptID);
            if (dt==null )
            {
                dtgrdOrderTrans.DataSource = null;
                return;
            }
            else
            {
                dtgrdOrderTrans.DataSource = dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dtgrdOrderTrans[1, i].Value == null)
                    {
                        dtgrdOrderTrans[1, i].Value = false;
                    }
                    if (dt.Rows[i]["order_type"].ToString() == "长嘱")
                    {
                        for (int j = 0; j < dtgrdOrderTrans.Columns.Count; j++)
                        {
                            dtgrdOrderTrans.Rows[i].Cells[j].Style.ForeColor = System.Drawing.Color.Red;
                        }
                        continue;
                    }
                    else if (dt.Rows[i]["order_type"].ToString() == "临嘱")
                    {
                        for (int j = 0; j < dtgrdOrderTrans.Columns.Count; j++)
                        {
                            dtgrdOrderTrans.Rows[i].Cells[j].Style.ForeColor = System.Drawing.Color.Blue;
                        }
                        continue;
                    }
                    else
                    {
                        for (int j = 0; j < dtgrdOrderTrans.Columns.Count; j++)
                        {
                            dtgrdOrderTrans.Rows[i].Cells[j].Style.ForeColor = System.Drawing.Color.Yellow;
                        }
                        continue;
                    }
                   
                }
            }
        }        
        /// <summary>
        /// 医嘱转抄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btOrderTrans_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("您真的要转抄选定的医嘱吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr==DialogResult.Yes)
            {
                int orderid;
                //int groupid;
                //int patlistid;
                List<int> orderlist = new List<int>();
                //List<int> grouplist=new List<int>();
                //List<int> patidlist=new List<int>();
                for (int i = 0; i < dtgrdOrderTrans.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dtgrdOrderTrans[1, i].Value) == true)
                    {
                        //patlistid=Convert.ToInt32(dtgrdOrderTrans[Column11.Name, i].Value.ToString());
                        orderid = Convert.ToInt32(dtgrdOrderTrans[Column3.Name, i].Value.ToString());
                        //groupid=Convert.ToInt32(dtgrdOrderTrans[Column12.Name, i].Value.ToString());
                        orderlist.Add(orderid);
                        //patidlist.Add(patlistid);
                        //grouplist.Add(groupid);             
                     }
                }
                if (orderlist.Count == 0)
                {
                    MessageBox.Show("您还未选择医嘱，请选择医嘱后再进行转抄!", "提示", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    op_order.getTransResult(orderlist);
                    bool transresult=op_order.setTransFlag(orderlist,_currentUser.EmployeeID);
                    if (transresult == true)
                    {
                        MessageBox.Show("医嘱已经成功转抄", "提示", MessageBoxButtons.OK);
                        RefreshSource();
                    }
                    else
                    {
                        MessageBox.Show("医嘱转抄失败，请稍后重试", "提示", MessageBoxButtons.OK);
                        RefreshSource();
                    }                    
                }
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// 选中相应的医嘱项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgrdOrderTrans_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 1)
            {
                #region 备份
                /*
                int i = e.RowIndex;
               int group_id = Convert.ToInt32(dtgrdOrderTrans[Column12.Name, i].Value.ToString());
               int patlistid = Convert.ToInt32(dtgrdOrderTrans[Column11.Name, i].Value.ToString());
               string ordertype = dtgrdOrderTrans[Column6.Name, i].Value.ToString();
               if (Convert.ToBoolean(dtgrdOrderTrans[Column10.Name,i].Value) == false)
               {
                    dtgrdOrderTrans[Column10.Name, i].Value = true;
                    for (int j = 0; j < dtgrdOrderTrans.Rows.Count; j++)
                    {
                        int tempgroupid = Convert.ToInt32(dtgrdOrderTrans[Column12.Name, j].Value.ToString());
                        int temppatlistid = Convert.ToInt32(dtgrdOrderTrans[Column11.Name, j].Value.ToString());
                        string tempordertype = dtgrdOrderTrans[Column6.Name, j].Value.ToString();
                        if (group_id == tempgroupid && ordertype == tempordertype && patlistid == temppatlistid)
                        {
                            dtgrdOrderTrans[1, j].Value = true;
                            for (int k = 0; k < dtgrdOrderTrans.Columns.Count; k++)
                            {
                                dtgrdOrderTrans.Rows[j].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                                dtgrdOrderTrans.Rows[j].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
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
                    dtgrdOrderTrans[Column10.Name, i].Value =false;
                    for (int j = 0; j < dtgrdOrderTrans.Rows.Count; j++)
                    {
                        int tempgroupid = Convert.ToInt32(dtgrdOrderTrans[Column12.Name, j].Value.ToString());
                        int temppatlistid = Convert.ToInt32(dtgrdOrderTrans[Column11.Name, j].Value.ToString());
                        string tempordertype = dtgrdOrderTrans[Column6.Name, j].Value.ToString();
                        if (group_id == tempgroupid && ordertype == tempordertype && patlistid == temppatlistid)
                        {
                            dtgrdOrderTrans[1, j].Value = false;
                            for (int k = 0; k < dtgrdOrderTrans.Columns.Count; k++)
                            {
                                dtgrdOrderTrans.Rows[j].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
                                dtgrdOrderTrans.Rows[j].Cells[k].Style.BackColor = System.Drawing.Color.White;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                 */
                #endregion

                int rowindex = e.RowIndex;
                bool Checked = (bool)dtgrdOrderTrans[1, rowindex].Value;
                string ordertype = dtgrdOrderTrans[Column6.Name, rowindex].Value.ToString();
                if (chkpat.Checked)//按病人
                {
                    int patlistid = Convert.ToInt32(dtgrdOrderTrans[Column11.Name, rowindex].Value.ToString());

                    if (chklong.Checked)
                    {
                        //CheckGroup(rowindex, Checked);
                        CheckXD(patlistid, "长嘱", Checked);
                    }
                    else
                    {
                        CheckGroup(rowindex, Checked);
                    }
                    if (chktemp.Checked)
                    {
                        CheckXD(patlistid, "临嘱", Checked);
                    }
                    else
                    {
                        CheckGroup(rowindex, Checked);
                    }
                }
                else
                {

                    if (chklong.Checked)
                    {
                        CheckXD("长嘱", Checked);
                    }
                    else
                    {
                        CheckGroup(rowindex, Checked);
                    }
                    if (chktemp.Checked)
                    {
                        CheckXD("临嘱", Checked);
                    }
                    else
                    {
                        CheckGroup(rowindex, Checked);
                    }
                }
            }

        }

        //分组勾选
        private void CheckGroup(int rowindex, bool Checked)
        {
            int group_id = Convert.ToInt32(dtgrdOrderTrans[Column12.Name, rowindex].Value.ToString());
            int patlistid = Convert.ToInt32(dtgrdOrderTrans[Column11.Name, rowindex].Value.ToString());
            string ordertype = dtgrdOrderTrans[Column6.Name, rowindex].Value.ToString();

            //dtgrdOrderTrans[Column10.Name, i].Value = false;
            for (int j = 0; j < dtgrdOrderTrans.Rows.Count; j++)
            {
                int tempgroupid = Convert.ToInt32(dtgrdOrderTrans[Column12.Name, j].Value.ToString());
                int temppatlistid = Convert.ToInt32(dtgrdOrderTrans[Column11.Name, j].Value.ToString());
                string tempordertype = dtgrdOrderTrans[Column6.Name, j].Value.ToString();
                if (group_id == tempgroupid && ordertype == tempordertype && patlistid == temppatlistid)
                {
                    dtgrdOrderTrans[1, j].Value = Checked == true ? false : true;
                    for (int k = 0; k < dtgrdOrderTrans.Columns.Count; k++)
                    {
                        dtgrdOrderTrans.Rows[j].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                        dtgrdOrderTrans.Rows[j].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                    }

                    if (!Checked)
                    {
                        for (int k = 0; k < dtgrdOrderTrans.Columns.Count; k++)
                        {
                            dtgrdOrderTrans.Rows[j].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                            dtgrdOrderTrans.Rows[j].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }
                    }
                    else
                    {
                        for (int k = 0; k < dtgrdOrderTrans.Columns.Count; k++)
                        {
                            dtgrdOrderTrans.Rows[j].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
                            dtgrdOrderTrans.Rows[j].Cells[k].Style.BackColor = System.Drawing.Color.White;
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
        }

        private void CheckXD(int patlistId, string ordernum, bool Checked)
        {
            for (int i = 0; i < dtgrdOrderTrans.Rows.Count; i++)
            {
                int temppatlistid = Convert.ToInt32(dtgrdOrderTrans[Column11.Name, i].Value.ToString());
                string tempordertype = dtgrdOrderTrans[Column6.Name, i].Value.ToString();
                if (patlistId == temppatlistid && tempordertype == ordernum)
                {
                    dtgrdOrderTrans[1, i].Value = Checked == true ? false : true;
                    if (!Checked)
                    {
                        for (int k = 0; k < dtgrdOrderTrans.Columns.Count; k++)
                        {
                            dtgrdOrderTrans.Rows[i].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                            dtgrdOrderTrans.Rows[i].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }
                    }
                    else
                    {
                        for (int k = 0; k < dtgrdOrderTrans.Columns.Count; k++)
                        {
                            dtgrdOrderTrans.Rows[i].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
                            dtgrdOrderTrans.Rows[i].Cells[k].Style.BackColor = System.Drawing.Color.White;
                        }
                    }

                }

                 
            }
        }

        private void CheckXD(string ordernum, bool Checked)
        {
            for (int i = 0; i < dtgrdOrderTrans.Rows.Count; i++)
            {
                int temppatlistid = Convert.ToInt32(dtgrdOrderTrans[Column11.Name, i].Value.ToString());
                string tempordertype = dtgrdOrderTrans[Column6.Name, i].Value.ToString();
                if (tempordertype == ordernum)
                {
                    dtgrdOrderTrans[1, i].Value = Checked == true ? false : true;
                    if (!Checked)
                    {
                        for (int k = 0; k < dtgrdOrderTrans.Columns.Count; k++)
                        {
                            dtgrdOrderTrans.Rows[i].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                            dtgrdOrderTrans.Rows[i].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }
                    }
                    else
                    {
                        for (int k = 0; k < dtgrdOrderTrans.Columns.Count; k++)
                        {
                            dtgrdOrderTrans.Rows[i].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
                            dtgrdOrderTrans.Rows[i].Cells[k].Style.BackColor = System.Drawing.Color.White;
                        }
                    }
                }
                
            }
        }

        /// <summary>
        /// 刷新数据源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btRefresh_Click(object sender, EventArgs e)
        {
            RefreshSource();
        }

        private void dtgrdOrderTrans_Paint(object sender, PaintEventArgs e)
        {
            if (_isInitialize)
            {
                RefreshSource();
                this.panel1.Height = this.inPatientPanel1.Height;
                _isInitialize = false;
            }
            Pen pen = new Pen(Color.Black, 2);//组线画笔
            int x1, y1, x2, y2, y3, y4;//y1为组头横线位置，y2为组线底位置，y3为组线顶位置，y4为组尾横线位置
            x1 = y1 = x2 = y2 = 0;
            for (int i = 0; i < dtgrdOrderTrans.Rows.Count; i++)
            {
                x1 = dtgrdOrderTrans.GetCellDisplayRectangle(dtgrdOrderTrans.Columns["GroupLines"].Index, i, false).Left + dtgrdOrderTrans.GetCellDisplayRectangle(dtgrdOrderTrans.Columns["GroupLines"].Index, i, false).Width * 2 / 3;
                x2 = dtgrdOrderTrans.GetCellDisplayRectangle(dtgrdOrderTrans.Columns["GroupLines"].Index, i, false).Right;
                y1 = dtgrdOrderTrans.GetCellDisplayRectangle(dtgrdOrderTrans.Columns["GroupLines"].Index, i, false).Top + dtgrdOrderTrans.GetCellDisplayRectangle(dtgrdOrderTrans.Columns["GroupLines"].Index, i, false).Height * 1 / 5;
                y2 = dtgrdOrderTrans.GetCellDisplayRectangle(dtgrdOrderTrans.Columns["GroupLines"].Index, i, false).Bottom;
                y3 = dtgrdOrderTrans.GetCellDisplayRectangle(dtgrdOrderTrans.Columns["GroupLines"].Index, i, false).Top;
                y4 = dtgrdOrderTrans.GetCellDisplayRectangle(dtgrdOrderTrans.Columns["GroupLines"].Index, i, false).Bottom - dtgrdOrderTrans.GetCellDisplayRectangle(dtgrdOrderTrans.Columns["GroupLines"].Index, i, false).Height * 1 / 5;
                if (dtgrdOrderTrans.Rows[i].Cells["GroupFlag"].Value.ToString() == "1")
                {
                    e.Graphics.DrawLine(pen, x1, y1, x2, y1);
                    e.Graphics.DrawLine(pen, x1, y1, x1, y2);
                }
                else if (dtgrdOrderTrans.Rows[i].Cells["GroupFlag"].Value.ToString() == "2")
                    e.Graphics.DrawLine(pen, x1, y3, x1, y2);
                else if (dtgrdOrderTrans.Rows[i].Cells["GroupFlag"].Value.ToString() == "3")
                {
                    e.Graphics.DrawLine(pen, x1, y3, x1, y4);
                    e.Graphics.DrawLine(pen, x1, y4, x2, y4);
                }
            }
        }
        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAllSelect_Click(object sender, EventArgs e)
        {
            //int patlistid=0;
            //if (chkpat.Checked == false)
            //{
                for (int rownum = 0; rownum < dtgrdOrderTrans.Rows.Count; rownum++)
                {
                    dtgrdOrderTrans[1, rownum].Value = true;
                    for (int k = 0; k < dtgrdOrderTrans.Columns.Count; k++)
                    {
                        dtgrdOrderTrans.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                        dtgrdOrderTrans.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                    }
                }
            //}
            //else
            //{
            //    for (int rownum = 0; rownum < dtgrdOrderTrans.Rows.Count; rownum++)
            //    {
            //        if (Convert.ToBoolean(dtgrdOrderTrans[Column10.Name, rownum].Value) == true)
            //        {
            //            patlistid = Convert.ToInt32(dtgrdOrderTrans[Column11.Name, rownum].Value.ToString());
            //            break;
            //        }
            //        else
            //        {
            //            continue;
            //        }                    
            //    }
            //    for (int rownum = 0; rownum < dtgrdOrderTrans.Rows.Count; rownum++)
            //    {
            //        if(Convert.ToInt32(dtgrdOrderTrans[Column11.Name, rownum].Value.ToString())==patlistid)
            //        {
            //            dtgrdOrderTrans[1, rownum].Value = true;
            //            for (int k = 0; k < dtgrdOrderTrans.Columns.Count; k++)
            //            {
            //                dtgrdOrderTrans.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
            //                dtgrdOrderTrans.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
            //            }
            //        }
            //    }

            //}

        }
        /// <summary>
        /// 反选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReverSelect_Click(object sender, EventArgs e)
        {
            //int patlistid = 0;
            //if (chkpat.Checked == false)
            //{
                for (int rownum = 0; rownum < dtgrdOrderTrans.Rows.Count; rownum++)
                {
                    dtgrdOrderTrans[1, rownum].Value = !(Convert.ToBoolean(dtgrdOrderTrans[1, rownum].Value));
                    if (Convert.ToBoolean(dtgrdOrderTrans[1, rownum].Value) == true)
                    {
                        for (int k = 0; k < dtgrdOrderTrans.Columns.Count; k++)
                        {
                            dtgrdOrderTrans.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                            dtgrdOrderTrans.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }
                    }
                    else
                    {
                        for (int k = 0; k < dtgrdOrderTrans.Columns.Count; k++)
                        {
                            dtgrdOrderTrans.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
                            dtgrdOrderTrans.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.White;
                        }
                    }
                }
            //}
            //else
            //{
            //    for (int rownum = 0; rownum < dtgrdOrderTrans.Rows.Count; rownum++)
            //    {
            //        if (Convert.ToBoolean(dtgrdOrderTrans[Column10.Name, rownum].Value) == true)
            //        {
            //            patlistid = Convert.ToInt32(dtgrdOrderTrans[Column11.Name, rownum].Value.ToString());
            //            break;
            //        }
            //        else
            //        {
            //            continue;
            //        }   
            //    }
            //    for (int rownum = 0; rownum < dtgrdOrderTrans.Rows.Count; rownum++)
            //    {
            //        if (Convert.ToInt32(dtgrdOrderTrans[Column11.Name, rownum].Value.ToString()) == patlistid)
            //        {
            //            dtgrdOrderTrans[1, rownum].Value = !(Convert.ToBoolean(dtgrdOrderTrans[1, rownum].Value));
            //            if (Convert.ToBoolean(dtgrdOrderTrans[1, rownum].Value) == true)
            //            {
            //                for (int k = 0; k < dtgrdOrderTrans.Columns.Count; k++)
            //                {
            //                    dtgrdOrderTrans.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
            //                    dtgrdOrderTrans.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
            //                }
            //            }
            //            else
            //            {
            //                for (int k = 0; k < dtgrdOrderTrans.Columns.Count; k++)
            //                {
            //                    dtgrdOrderTrans.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
            //                    dtgrdOrderTrans.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.White;
            //                }
            //            }
            //        }
            //    }

            //}
        }
        /// <summary>
        /// 加载病人相关信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgrdOrderTrans_Click(object sender, EventArgs e)
        {
            if (dtgrdOrderTrans.CurrentCell != null)
            {
                int patlistid = Convert.ToInt32(dtgrdOrderTrans[Column11.Name, dtgrdOrderTrans.CurrentCell.RowIndex].Value.ToString());
                //PublicClass patient = new PublicClass();
                //DataTable patdt = op_bed.getPatInfo(patlistid);
                //patient.InpitentNo = patdt.Rows[0][0].ToString();
                //patient.InDate = Convert.ToDateTime(patdt.Rows[0][1].ToString());
                //patient.InDisease = new BindValue("", patdt.Rows[0][2].ToString());
                //patient.CurrentDepartment = new BindValue("", patdt.Rows[0][3].ToString());
                //patient.InDepartment = new BindValue("", patdt.Rows[0][4].ToString());
                //patient.PatientName = patdt.Rows[0][5].ToString();
                //patient.Sex = patdt.Rows[0][6].ToString();
                //patient.PatientType = new BindValue("", patdt.Rows[0][7].ToString());
                //patient.BedNo = patdt.Rows[0][8].ToString();
                //patient.EconomyDoctor = new GWI.HIS.Windows.Controls.BindValue("", patdt.Rows[0][9].ToString());
                //patient.TendInfo = "";
                //patient.CureDoctor = new GWI.HIS.Windows.Controls.BindValue(null, ""); ;
                //patient.Nurse = new GWI.HIS.Windows.Controls.BindValue(null, "");
                //patient.BordDay = Convert.ToDateTime(patdt.Rows[0]["patbridate"].ToString());
                //IcM.PatListID = patlistid;
                //patient.BalanceFee = IcM.GetPatFee().surplusFee;
                //patient.PrePayFee = IcM.GetPatFee().chargeFee;
                inPatientPanel1.InPatientExtDB = new ApplyIInPatient(patlistid);

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
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkpat_CheckedChanged(object sender, EventArgs e)
        {
            if (chkpat.Checked == true)
            {
                chktemp.Checked = true;
                chklong.Checked = true;
            }
            else
            {
                chktemp.Checked = false;
                chklong.Checked = false;
            }
        }      
       
    }
}

