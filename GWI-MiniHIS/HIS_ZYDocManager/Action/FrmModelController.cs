using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using HIS.SYSTEM.BussinessLogicLayer.Classes;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.ZYDoc_BLL;
using GWI.HIS.Windows.Controls;

namespace HIS_ZYDocManager.Action
{
    public class FrmModelController : PublicController
    {
        private IFrmDocModelView view;
        private DataSet _dataSet;
        private User user;
        private Deptment dept;
        private HIS.ZYDoc_BLL.ModelInfo.IModelOP modelop;
        private HIS.ZYDoc_BLL.BaseInfo.ShowCardBase showcardbase;
        public FrmModelController(IFrmDocModelView _view)
        {
            view = _view;
            _dataSet = new DataSet();
            user = view.currentUser;
            dept = view.currentDept;
            modelop = new HIS.ZYDoc_BLL.ModelInfo.ModelOperation();
            showcardbase = new HIS.ZYDoc_BLL.BaseInfo.ShowCardBase();
            LoadINFO();
        }

        #region 加载数据
        public void LoadINFO()
        {           
            _dataSet = showcardbase.LoadBaseINFO();            
            view.Initialize(_dataSet);
        }
        #endregion

        #region 根据ID获得药品单位信息
        public void GetDwType(int itemid, int itemtype)
        {           
            _dataSet =showcardbase.GetDwType(itemid, itemtype);
        }
        #endregion

        #region  通过输入的医嘱筛选数据
        /// <summary>
        /// 根据医嘱类型加载数据
        /// </summary>
        /// <param name="sign"></param>
        /// <returns></returns>
        public void getData(ItemType itemtype)
        {
            _dataSet = showcardbase.getData(itemtype, OrderType.临时医嘱);
        }
        #endregion

        public void YfSelect()
        {
            _dataSet = showcardbase.YfSelect(1, view.GetYfIds);
        }

        #region 模板主表操作
        #region 模板主表保存
        /// <summary>
        /// 保存模板主表
        /// </summary>
        public int  SaveModel(HIS.Model.ZY_DOC_ORDERMODEL model)
        {
          return  modelop.SaveModeltype(model);
        }
        #endregion
     
        #region 删除模板结点
        /// <summary>
        ///  删除树节点
        /// </summary>
        public bool DelNode()
        {
            if (modelop.DelNode(view.tag))
            {
                return true;
            }
            else //要先删除该类别的所有处方
            {
                MessageBox.Show("请先删除该类别的所有医嘱");
                return false;
            }
        }
        #endregion

        #region 修改结点名称
        /// <summary>
        /// 修改树结点名称
        /// </summary>
        /// <param name="name"></param>
        public void UpDateNode(string name)
        {
           modelop.UpdateNode(view.tag, name);
        }
        #endregion
        #endregion

        #region 网格操作

        #region 网格赋值
        /// <summary>
        /// 赋值
        /// </summary>
        /// <param name="rowid">行号</param>
        /// <param name="dr">列</param>
        /// <returns>列号</returns>
        public void SelectCardBindData(int rowid, int columnid, DataRow dr, out int colid)
        {
            DataTable dt = null;
            dt = view.BindDocModelData;
            switch (columnid)
            {
                case 2:
                    if (Convert.ToInt32(dr["tc_flag"]) == 1)
                    {
                        dt.Rows[rowid]["tc_id"] = dr["server_item_id"];
                    }
                    else
                    {
                        dt.Rows[rowid]["tc_id"] = 0;
                    }
                    view.XDEnabled = false;
                    dt.Rows[rowid]["item_id"] = XcConvert.IsNull(dr["itemid"], "");
                    dt.Rows[rowid]["item_name"] = XcConvert.IsNull(dr["ITEMNAME"], "");
                    if (dr["EXECDEPTCODE"].ToString() == this.dept.DeptID.ToString())
                    {
                        dt.Rows[rowid]["ExecDept"] = "";
                        dt.Rows[rowid]["exec_dept"] = 0;
                    }
                    else
                    {
                        dt.Rows[rowid]["ExecDept"] = XcConvert.IsNull(dr["execdeptname"], "");
                        dt.Rows[rowid]["exec_dept"] = XcConvert.IsNull(dr["EXECDEPTCODE"], "0");
                    }
                    dt.Rows[rowid]["unit"] = XcConvert.IsNull(dr["doseunit"], "");
                    dt.Rows[rowid]["unittype"] = 0;
                    dt.Rows[rowid]["doseunit"] = XcConvert.IsNull(dr["doseunit"], "");
                    dt.Rows[rowid]["item_type"] = XcConvert.IsNull(dr["order_type"], "");
                    dt.Rows[rowid]["presamount"] = 1;
                    dt.Rows[rowid]["severs_id"] = dr["server_item_id"];
                    dt.Rows[rowid]["amount"] = dr["dosenum"];
                    dt.Rows[rowid]["item_code"] = XcConvert.IsNull(dr["statitem_code"], "");
                    if (Convert.ToInt16(dr["order_type"]) == 3)
                    {
                        view.PresAmountReadOnly = false;
                        dt.Rows[rowid]["presamount"] = 1;
                    }
                    if (!IsGroupFirstRow(dt, rowid))
                    {
                        dt.Rows[rowid]["order_frenquecy"] = dt.Rows[rowid - 1]["order_frenquecy"].ToString();
                        dt.Rows[rowid]["order_usage"] = dt.Rows[rowid - 1]["order_usage"].ToString();
                        dt.Rows[rowid]["frist_times"] = dt.Rows[rowid - 1]["frist_times"].ToString();
                        dt.Rows[rowid]["presamount"] = dt.Rows[rowid - 1]["presamount"].ToString();
                    }
                    colid = 3;
                    break;
                case 10:
                    dt.Rows[rowid]["order_struc"] = XcConvert.IsNull(dr["NAME"], "");
                    colid = -1;
                    break;
                case 5:
                    dt.Rows[rowid]["order_usage"] = XcConvert.IsNull(dr["name"], "");
                    this.ChangeValue(dt, rowid, "order_usage");
                    colid = 6;
                    break;
                case 6:
                    dt.Rows[rowid]["order_frenquecy"] = XcConvert.IsNull(dr["name"], "");
                    dt.Rows[rowid]["frist_times"] = base.GetExectime(dt.Rows[rowid]["order_frenquecy"].ToString());
                    this.ChangeValue(dt, rowid, "order_frenquecy");
                    colid = 7;
                    break;
                case 4:
                    dt.Rows[rowid]["unit"] = XcConvert.IsNull(dr["name"], "");
                    dt.Rows[rowid]["unittype"] = XcConvert.IsNull(dr["dwlx"], "");
                    colid = 5;
                    break;
                default: colid = -1; return;
            }
        }
        #endregion

        #region 只读控制
        /// <summary>
        /// 设置列的只读
        /// </summary>
        public void SettingReadOnly(int colid, int rowid)
        {
            try
            {
                DataTable dt = view.BindDocModelData;
                if (Convert.ToInt32(dt.Rows[rowid]["flag"]) == 1)
                {
                    view.AmountReadOnly = true;
                    view.DropSperReadOnly = true;
                    view.FirstTimeReadOnly = true;
                    view.FrenQuencyReadOnly = true;
                    view.ItemNameReadOnly = true;
                    view.UnitReadOnly = true;
                    view.PresAmountReadOnly = true;
                    view.StrucReadOnly = true;
                    view.UsageReadOnly = true;
                }
                else
                {
                    if (!this.IsGroupFirstRow(dt, rowid))
                    {
                        view.FirstTimeReadOnly = true;
                        view.FrenQuencyReadOnly = true;
                        view.PresAmountReadOnly = true;
                        view.UsageReadOnly = true;
                        view.ItemNameReadOnly = false;
                        view.DropSperReadOnly = false;
                        view.AmountReadOnly = false;
                        if (Convert.ToInt32(dt.Rows[rowid]["item_type"]) >= 3)//中草药可输付数，不能选单位　
                        {
                            view.UnitReadOnly = true;
                        }
                        else
                        {
                            view.UnitReadOnly = false;
                        }
                    }
                    else
                    {
                        view.AmountReadOnly = false;
                        view.DropSperReadOnly = false;
                        view.FirstTimeReadOnly = false;
                        view.FrenQuencyReadOnly = false;
                        view.ItemNameReadOnly = false;
                        view.StrucReadOnly = false;
                        view.UsageReadOnly = false;
                        if (Convert.ToInt32(dt.Rows[rowid]["item_type"]) == 3)//中草药可输付数，不能选单位　
                        {
                            view.PresAmountReadOnly = false;
                        }
                        else
                        {
                            view.PresAmountReadOnly = true;
                        }
                        if (Convert.ToInt32(dt.Rows[rowid]["item_type"]) >= 3) //中草药单位都是含量单位
                        {
                            view.UnitReadOnly = true;
                        }
                        else
                        {
                            view.UnitReadOnly = false;
                        }
                    }
                }
            }
            catch
            {
            }
        }
        #endregion

        #region 颜色显示
        /// <summary>
        /// 设置网格显示颜色
        /// </summary>
        /// <param name="zyPS"></param>
        /// <param name="rowid"></param>
        /// <param name="colid"></param>
        public void ShowRowColor(HIS.Model.ZY_DOC_ORDERMODELLIST_E zyOder, int rowid, int colid)
        {
            if (zyOder.FLAG == 2)
            {
                view.presColor = new PresColor(rowid, -1, System.Drawing.Color.Orange, System.Drawing.Color.White);
            }
            if (zyOder.FLAG == 1)
            {
                view.presColor = new PresColor(rowid, -1, System.Drawing.Color.RoyalBlue, System.Drawing.Color.White);
            }
        }
        #endregion

        #region 第一组数据改变时，同组数据同时改变
        public void ChangeValue(DataTable dt, int rowindex, string colname)
        {
            for (int i = rowindex + 1; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["GroupID"].ToString().Trim() == "")
                {
                    dt.Rows[i][colname] = dt.Rows[rowindex][colname];
                }
                if (dt.Rows[i]["GroupID"].ToString().Trim() != "")
                {
                    break;
                }
            }
        }
        #endregion
        #endregion

        #region 模板明细操作

        #region 新增一行 0=按新开按钮 1=回车新开
        /// <summary>
        /// 新开
        /// </summary>  
        /// <returns>行号</returns>
        public int AddRow(int sign)
        {
            DataTable dt = null;
            dt = view.BindDocModelData;
            if (sign == 1)
            {
                _dataSet = showcardbase.AddRows(1, sign, Convert.ToInt16(dt.Rows[dt.Rows.Count - 1]["item_type"]));//  HIS.ZYDoc_BLL.OP_Base.AddRows(1, sign, Convert.ToInt16(dt.Rows[dt.Rows.Count - 1]["item_type"]));
            }
            else
            {
                _dataSet = showcardbase.AddRows(1, sign,0);
            }
            int rowid;
            if (dt != null && dt.Rows.Count > 0)
            {
                rowid = dt.Rows.Count - 1;
                if (dt.Rows[rowid]["item_name"].ToString().Trim() == "")	//最后一行不为空才允许新增一行
                {
                    return rowid;
                }
                else
                {
                    List<HIS.Model.ZY_DOC_ORDERMODELLIST_E> _zyDcoModel = new List<HIS.Model.ZY_DOC_ORDERMODELLIST_E>();
                    HIS.Model.ZY_DOC_ORDERMODELLIST_E zyDocModel = new HIS.Model.ZY_DOC_ORDERMODELLIST_E();
                    zyDocModel.XD = false;
                    _zyDcoModel.Add(zyDocModel);
                    DataTable ddt = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(_zyDcoModel);
                    dt.Rows.Add(ddt.Rows[0].ItemArray);
                    rowid = dt.Rows.Count - 1;
                    return rowid;
                }
            }
            else
            {
                List<HIS.Model.ZY_DOC_ORDERMODELLIST_E> _zyDcoModel = new List<HIS.Model.ZY_DOC_ORDERMODELLIST_E>();
                HIS.Model.ZY_DOC_ORDERMODELLIST_E zyDocModel = new HIS.Model.ZY_DOC_ORDERMODELLIST_E();
                zyDocModel.XD = false;
                _zyDcoModel.Add(zyDocModel);
                view.BindDocModelData = null;
                view.BindDocModelData = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(_zyDcoModel);
                dt = view.BindDocModelData;
            }
            rowid = dt.Rows.Count - 1;
            return rowid;
        }
        #endregion

        #region  得到模板数据
        /// <summary>
        /// 得到模板数据
        /// </summary>
        public void GetModelData()
        {           
            DataTable myTbBk = base.GetModelData(view.tag);
            if (myTbBk == null || myTbBk.Rows.Count == 0)
            {
                view.BindDocModelData = null;
                return;
            }            
            view.BindDocModelData = myTbBk;
            DataTable dt = view.BindDocModelData;          
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                HIS.Model.ZY_DOC_ORDERMODELLIST_E zyoc = new HIS.Model.ZY_DOC_ORDERMODELLIST_E();
                zyoc = (HIS.Model.ZY_DOC_ORDERMODELLIST_E)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dt, i, zyoc);
                ShowRowColor(zyoc, i, 1);
            }
        }
        #endregion       

        #region 保存模板明细
        /// <summary>
        /// 保存模板明细
        /// </summary>
        public WrongDecline SaveModelList()
        {
            DataTable dt = null;
            dt = view.BindDocModelData;         
            List<HIS.Model.ZY_DOC_ORDERMODELLIST_E> doc_modellist = new List<HIS.Model.ZY_DOC_ORDERMODELLIST_E>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["item_name"].ToString().Trim() != "")
                {
                    HIS.Model.ZY_DOC_ORDERMODELLIST_E modellist = new HIS.Model.ZY_DOC_ORDERMODELLIST_E();
                    modellist = (HIS.Model.ZY_DOC_ORDERMODELLIST_E)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dt, i, modellist);
                    doc_modellist.Add(modellist);
                }
            }
            return  modelop.SaveModelList(doc_modellist, view.tag);          
        }
        #endregion

        #region 删除模板明细
        /// <summary>
        ///  删除模板明细
        /// </summary>
        /// <param name="sign">0=点删除按钮　1=右键删除一行</param>
        /// <param name="rowindex"></param>
        public void  OrderDelelte(int sign,int rowindex)
        {
            DataTable dtCopy = null;
            dtCopy = view.BindDocModelData;
            DataTable dt = dtCopy.Clone();
            dt.Clear();
            for (int i = 0; i < dtCopy.Rows.Count; i++)
            {
                dt.Rows.Add(dtCopy.Rows[i].ItemArray);
            }
            List<HIS.Model.ZY_DOC_ORDERMODELLIST> models = new List<HIS.Model.ZY_DOC_ORDERMODELLIST>();
            if (sign == 0)//可能有多行
            {
                dtCopy.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if ((bool)dt.Rows[i]["XD"] == true)
                    {
                        if (Convert.ToInt32(dt.Rows[i]["flag"]) == 1)
                        {
                            HIS.Model.ZY_DOC_ORDERMODELLIST model = new HIS.Model.ZY_DOC_ORDERMODELLIST();
                            dt.Rows[i]["MODELLIST_A2"] = 1;// 删除标志
                            model = (HIS.Model.ZY_DOC_ORDERMODELLIST)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dt, i, model);
                            model.MODELLIST_A2 = 1;// 删除标志
                            models.Add(model);
                        }
                        //dtCopy.Rows.RemoveAt(i);  //* 20100526.0.05  住院医生模板删除未保存的一条时会把未保存的全部删除
                    }
                    else
                    {
                        dtCopy.Rows.Add(dt.Rows[i].ItemArray); //20100603.0.06  模板维护删除最后一组时报错
                    }
                }
                
            }
            if (sign == 1) //右键删除当前行
            {
                if (Convert.ToInt32(dt.Rows[rowindex]["flag"]) == 1)
                {
                    dt.Rows[rowindex]["MODELLIST_A2"] = 1;// 删除标志
                    HIS.Model.ZY_DOC_ORDERMODELLIST model = new HIS.Model.ZY_DOC_ORDERMODELLIST();
                    model = (HIS.Model.ZY_DOC_ORDERMODELLIST)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dt, rowindex, model);
                    model.MODELLIST_A2 = 1;// 删除标志
                    models.Add(model);                   
                }
                dtCopy.Rows.RemoveAt(rowindex);
            }
            if (models.Count > 0)
            {
               modelop.DelOrder(models);
            }
            view.BindDocModelData = null; //* 20100526.0.05  住院医生模板删除未保存的一条时会把未保存的全部删除
            view.BindDocModelData = dtCopy;
            for (int i = 0; i < dtCopy.Rows.Count; i++)
            {
                HIS.Model.ZY_DOC_ORDERMODELLIST_E zyoc = new HIS.Model.ZY_DOC_ORDERMODELLIST_E();
                zyoc = (HIS.Model.ZY_DOC_ORDERMODELLIST_E)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dtCopy, i, zyoc);
                ShowRowColor(zyoc, i, 1);
            }
        }
        #endregion

        #region 增加脚注
        /// <summary>
        /// 增加脚注
        /// </summary>
        /// <param name="tb">表</param>
        /// <param name="nrow">表行号</param>
        /// <param name="note">脚注名称</param>
        public void AddJz(int nrow, string note)
        {
            DataTable tb = view.BindDocModelData;
            string str = tb.Rows[nrow]["item_name"].ToString().Trim() + " ";
            if (str.IndexOf("【") > 0)
            {
                str = str.Substring(0, str.IndexOf("【"));
            }
            tb.Rows[nrow]["item_name"] = str + " 【" + note + "】";  
        }
        #endregion
        #endregion

        #region 方法
        #region 判断是否是一组的第一行
        public bool IsGroupFirstRow(DataTable myTb, int nrow)
        {
            if (nrow == 0) return true;
            if (myTb.Rows[nrow]["GroupID"].ToString().Trim() != "")
            {
                return true;//上一列无内容
            }
            return false;
        }
        #endregion

        #region 判断一组的最后行索引 
        private int GetGroupBeginRow(DataTable myTb, int nrow)
        {
            int i;
            for (i = nrow + 1; i < myTb.Rows.Count; i++)
            {
                if (myTb.Rows[i]["GroupID"].ToString().Trim() != "")
                {
                    return i;
                }
            }
            if (i == myTb.Rows.Count)
            {
                return i;
            }
            return -1;
        }
        #endregion      
       
        #endregion
    }
}
