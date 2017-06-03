using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS_ZYDocManager.Action
{
    public class PublicController
    {
        HIS.ZYDoc_BLL.ModelInfo.IModelOP modelop = new HIS.ZYDoc_BLL.ModelInfo.ModelOperation();
        public  HIS.ZYDoc_BLL.BaseInfo.DrugBase drugbase = new HIS.ZYDoc_BLL.BaseInfo.DrugBase();

        #region 医生站模板管理和医嘱管理界面模板应用共用控制代码
        #region 选定对应的行
        /// <summary>
        /// 选定对应的行
        /// </summary>
        public void CellXD(int rowid, bool b, DataTable dt)
        {
            if (rowid > -1)
            {
                if ((bool)dt.Rows[rowid]["XD"] == true)
                {
                    if (b)
                    {
                        dt.Rows[rowid]["XD"] = false;
                    }
                }
                else
                {
                    dt.Rows[rowid]["XD"] = true;
                }
            }
        }
        #endregion

        #region 选定控制
        /// <summary>
        /// 选定控制
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="rowid"></param>
        public void XdControl(DataTable dt, int rowid)
        {
            string groupid = dt.Rows[rowid]["group_id"].ToString().Trim();
            int beginNum = 0;
            int endNum = 0;
            this.FindModelBeginEnd(rowid, dt, ref  beginNum, ref  endNum);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["group_id"].ToString().Trim() == groupid)
                {
                    this.CellXD(i, true, dt);
                }
            }
        }
        #endregion

        #region 得到模板数据
        /// <summary>
        /// 得到模板数据
        /// </summary>
        public DataTable GetModelData(int modellistid)
        {
            DataTable mytb;
            DataTable mytable = modelop.GetModelList(modellistid);
            if (mytable.Rows.Count == 0 || mytable == null)
            {
                return null;
            }
            DataView tempDataView = new DataView(mytable, "", "group_id", DataViewRowState.CurrentRows);
            mytb = insertRow(tempDataView, mytable);
            tempDataView.Dispose();
            DataTable myTbBk = mytb.Copy();
            myTbBk.Rows[0]["groupid"] = myTbBk.Rows[0]["group_id"].ToString().Trim();
            for (int i = 1; i < myTbBk.Rows.Count; i++)
            {

                if (myTbBk.Rows[i]["group_id"].ToString().Trim() != myTbBk.Rows[i - 1]["group_id"].ToString().Trim())
                {
                    myTbBk.Rows[i]["groupid"] = myTbBk.Rows[i]["group_id"].ToString().Trim();

                }
                else
                {
                    myTbBk.Rows[i]["groupid"] = DBNull.Value;
                }
            }
            return myTbBk;
        }
        #endregion

        #region 数据视图→表
        public  DataTable insertRow(DataView myView, DataTable dt)
        {
            DataTable myTb = dt.Copy(); ;
            myTb.Rows.Clear();
            foreach (DataRowView myDRV in myView)
            {
                DataRow newDR = myTb.NewRow();
                for (int i = 0; i < myView.Table.Columns.Count; i++)
                {
                    newDR[i] = myDRV[i];
                }
                myTb.Rows.Add(newDR);
            }
            return myTb;
        }
        #endregion

        #region 构造模板类型树型结构
        /// <summary>
        ///  构造模板类型树型结构
        /// </summary>
        public TreeNode Bind_tvtype(int level, int employeeid, int deptid)
        {
            TreeNode ppnode = new TreeNode();
            ppnode.Text = "全部类型";
            ppnode.Tag = -1;
            ppnode.ImageIndex = 14;
            DataTable dttype = null;
            DataTable dtname = null;
            dttype = modelop.GetModelType(level, employeeid, deptid);
            for (int i = 0; i < dttype.Rows.Count; i++)
            {
                TreeNode pnode = new TreeNode();
                pnode.Text = dttype.Rows[i]["model_name"].ToString();
                pnode.Tag = dttype.Rows[i]["model_id"];
                if (dttype.Rows[i]["model_type"].ToString() == "0")
                {
                    pnode.ImageIndex = 14;
                }
                else
                {
                    pnode.ImageIndex = 15;
                }
                dtname = modelop.GetModelName(Convert.ToInt32(dttype.Rows[i]["model_id"]));
                for (int j = 0; j < dtname.Rows.Count; j++)
                {
                    TreeNode node = new TreeNode();
                    node.Text = dtname.Rows[j]["model_name"].ToString();
                    node.Tag = dtname.Rows[j]["model_id"];
                    node.ImageIndex = 15;
                    pnode.Nodes.Add(node);
                }              
                ppnode.Nodes.Add(pnode);
            }
            return ppnode;
        }
        #endregion

        #region 模板应用时模板选择的内容
        /// <summary>
        /// 模板应用时模板选择的内容
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="bindex">开始行</param>
        /// <param name="eindex">结束行</param>
        /// <returns></returns>
        public List<HIS.Model.ZY_DOC_ORDERMODELLIST> ModelApply(DataTable dt, int bindex, int eindex)
        {

            DataTable dt_model = new DataTable();
            string itemDel = "";
            string itemStore = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                dt_model = dt.Clone();
                dt_model.Clear();
                for (int i = bindex; i < eindex; i++)
                {
                    if ((bool)dt.Rows[i]["XD"] == true)
                    {
                        if (dt.Rows[i]["item_type"].ToString() != "7" &&  drugbase.IsDel(Convert.ToInt32(dt.Rows[i]["item_id"].ToString()), Convert.ToInt32(dt.Rows[i]["item_type"].ToString())))
                        {
                            itemDel = itemDel + dt.Rows[i]["item_name"].ToString() + ",";
                            continue;
                        }
                        if (Convert.ToInt32(dt.Rows[i]["item_type"].ToString()) < 4)
                        {
                            if (drugbase.GetStoreNum(Convert.ToInt32(dt.Rows[i]["item_id"].ToString()), Convert.ToInt32(dt.Rows[i]["item_type"].ToString()), Convert.ToInt32(dt.Rows[i]["EXEC_DEPT"])) <= 0)
                            {
                                itemStore = itemStore + dt.Rows[i]["item_name"].ToString() + ",";
                                continue;
                            }
                        }
                        dt_model.Rows.Add(dt.Rows[i].ItemArray);
                    }
                }
                if (itemDel != "")
                {
                    MessageBox.Show("'" + itemDel + "'已被药房禁用或停用，不能应用");
                }
                if (itemStore != "")
                {
                    MessageBox.Show("'" + itemStore + "'的库存为0，不能应用");
                }
            }
            List<HIS.Model.ZY_DOC_ORDERMODELLIST> lists = new List<HIS.Model.ZY_DOC_ORDERMODELLIST>();
            lists = new List<HIS.Model.ZY_DOC_ORDERMODELLIST>();
            for (int i = 0; i < dt_model.Rows.Count; i++)
            {
                HIS.Model.ZY_DOC_ORDERMODELLIST list = new HIS.Model.ZY_DOC_ORDERMODELLIST();
                list = (HIS.Model.ZY_DOC_ORDERMODELLIST)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dt_model, i, list);
                lists.Add(list);
            }
            return lists;
        }
        #endregion

        #region 模板中获得一组医嘱的起始点和终点
        public void FindModelBeginEnd(int nrow, DataTable myTb, ref int beginNum, ref int endNum)
        {
            int i = 0;
            beginNum = nrow;
            endNum = nrow;
            if (myTb.Rows[nrow]["flag"].ToString() != "1")
            {
                return;
            }
            string groupid = myTb.Rows[nrow]["group_id"].ToString();
            for (i = nrow; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["group_id"].ToString() == groupid)
                    endNum = i;
                else
                    break;
                if (i + 1 == myTb.Rows.Count)
                    break;
            }
            for (i = nrow - 1; i >= 0; i--)
            {
                if (i == 0 && myTb.Rows[i]["group_id"].ToString() == groupid)
                {
                    beginNum = 0;
                    break;
                }
                if (myTb.Rows[i]["group_id"].ToString() == groupid)
                    beginNum = i;
                else break;
            }
        }
        #endregion
        #endregion

        #region 模板管理组线绘制，医嘱管理界面组线绘制
        /// <summary>
        /// 模板管理组线绘制，医嘱管理界面组线绘制
        /// </summary>
        /// <param name="dataGridViewEx1"></param>
        /// <param name="dt"></param>
        /// <param name="e"></param>
        /// <param name="sign">0=模板画线　1＝医嘱管理画线</param>
        public void PaintView(GWI.HIS.Windows.Controls.DataGridViewEx dataGridViewEx1, DataTable dt, PaintEventArgs e,int sign)
        {
            Pen pen = new Pen(Color.Black, 1);//组线画笔
            int x1, y1, x2, y2, y3, y4;//y1为组头横线位置，y2为组线底位置，y3为组线顶位置，y4为组尾横线位置
            x1 = y1 = x2 = y2 = 0;
            for (int i = 0; i < dataGridViewEx1.Rows.Count; i++)
            {
                int beginNum = 0;
                int endNum = 0;
                if (sign == 0)
                {
                    this.FindModelBeginEnd(i, dt, ref beginNum, ref endNum);
                }
                else
                {
                    this.FindBeginEnd(i, dt,ref  beginNum,ref  endNum);
                }
                if (beginNum != endNum)
                {
                    for (int j = beginNum; j < endNum + 1; j++)
                    {
                        x1 = dataGridViewEx1.GetCellDisplayRectangle(1, j, false).Left + dataGridViewEx1.GetCellDisplayRectangle(1, j, false).Width * 2 / 3;
                        x2 = dataGridViewEx1.GetCellDisplayRectangle(1, j, false).Right;
                        y1 = dataGridViewEx1.GetCellDisplayRectangle(1, j, false).Top + dataGridViewEx1.GetCellDisplayRectangle(1, j, false).Height * 1 / 5;
                        y2 = dataGridViewEx1.GetCellDisplayRectangle(1, j, false).Bottom;
                        y3 = dataGridViewEx1.GetCellDisplayRectangle(1, j, false).Top;
                        y4 = dataGridViewEx1.GetCellDisplayRectangle(1, j, false).Bottom - dataGridViewEx1.GetCellDisplayRectangle(1, j, false).Height * 1 / 5;
                        if (j == beginNum)
                        {
                            e.Graphics.DrawLine(pen, x1, y1, x2, y1);
                            e.Graphics.DrawLine(pen, x1, y1, x1, y2);
                        }
                        else if (j == endNum)
                        {
                            e.Graphics.DrawLine(pen, x1, y3, x1, y4);
                            e.Graphics.DrawLine(pen, x1, y4, x2, y4);
                        }
                        else
                        {
                            e.Graphics.DrawLine(pen, x1, y3, x1, y2);
                        }
                    }
                }
                i = endNum;
            }
        }
        #endregion     

        #region 医嘱管理界面中获得一组医嘱的起始点和终点
        /// <summary>
        /// 医嘱管理界面中获得一组医嘱的起始点和终点  
        /// </summary>
        /// <param name="nrow"></param>
        /// <param name="myTb"></param>
        /// <param name="beginNum"></param>
        /// <param name="endNum"></param>
        public void FindBeginEnd(int nrow, DataTable myTb, ref int beginNum, ref int endNum)
        {
            DateTime timeformat = Convert.ToDateTime(Convert.ToDateTime("0001-1-1 0:00:00").ToShortDateString() + " " + Convert.ToDateTime("0001-1-1 0:00:00").ToLongTimeString());
            int i = 0;
            beginNum = nrow;
            endNum = nrow;
            for (i = nrow; i <= myTb.Rows.Count - 1; i++)
            {
                if (i + 1 == myTb.Rows.Count)
                {
                    endNum = i;
                    break;
                }
                if (myTb.Rows[i + 1]["begintime"].ToString() == timeformat.ToString())
                {
                    endNum = i + 1;
                }
                else break;
            }
            for (i = nrow; i >= 0; i--)
            {
                if (i == 0)
                {
                    break;
                }
                if (myTb.Rows[i]["begintime"].ToString() == timeformat.ToString())
                {
                    beginNum = i - 1;
                }
                else break;
            }
        }
        #endregion      

        #region 根据时间点计算默认频率次数
        /// <summary>
        /// 根据时间点计算默认频率次数
        /// </summary>
        /// <param name="frenqucy"></param>
        /// <returns></returns>
        public int  GetExectime(string frenqucy)
        {         
            return drugbase.getExecTimes(frenqucy, XcDate.ServerDateTime, 0);
        }
        #endregion        

        #region 数字和小数输入合法的控制
        /// <summary>
        /// 数字和小数输入合法的控制
        /// </summary>
        /// <param name="keychar">键盘值</param>
        /// <param name="sign">0=整数输入控制　1＝小数输入控制</param>
        /// <returns></returns>
        public bool  NumInputControl(int keychar,int sign)
        {
            if (sign == 0)
            {
                if ((keychar >= 48 && keychar <= 57) || (keychar >= 96 && keychar < 110) || keychar == 13 || (keychar >= 37 && keychar <= 40) || keychar == 8 || keychar == 46)
                {
                    return false;
                }
                return true;
            }
            else
            {
                if ((keychar >= 48 && keychar <= 57) || (keychar >= 96 && keychar <= 110) || keychar == 13 || (keychar >= 37 && keychar <= 40) || keychar == 229 || keychar == 190 || keychar == 8 || keychar == 46)
                {
                    return false;
                }
                return true;
            }
        }
        #endregion 

        #region 获得所有药房名称
        /// <summary>
        /// 获得所有药房名称
        /// </summary>
        /// <returns></returns>
        public DataTable GetYfName()
        {
            return drugbase.GetYfName();
        }
        #endregion

        #region 获得与科室对应的药房名称
        /// <summary>
        /// 获得与科室对应的药房名称
        /// </summary>
        /// <param name="deptid"></param>
        /// <returns></returns>
        public DataTable  Get_dept_yfName(int deptid)
        {
            return drugbase.Get_dept_yfName(deptid);
        }
        #endregion

        #region 获得药品详细信息
        /// <summary>
        /// 获得药品详细信息
        /// </summary>
        /// <param name="itemid"></param>
        /// <param name="itemtype"></param>
        /// <returns></returns>
        public DataRow GetDrugInfo(int itemid,int itemtype)
        {
            return drugbase.GetDrugInfo(itemid, itemtype);
        }
        #endregion
    }
}
