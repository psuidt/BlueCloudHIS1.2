using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.ZY_BLL.DataModel;
using HIS.ZY_BLL.ObjectModel;
using HIS.ZY_BLL.ObjectModel.CostManager;
using HIS.ZY_BLL.ObjectModel.BaseData;
using HIS.ZY_BLL;

namespace HIS_ZYManager.Action
{
    public class FrmPresManagerController
    {
        private IFrmPresManagerView view;
        private DataSet _dataSet;
        private ZY_PatList zy_Patlist;
        private ZY_PresOrder zyPresOrder;
        private IcostManager icM;
        private User user;
        private Deptment dept;

        public FrmPresManagerController(IFrmPresManagerView _view)
        {
            view = _view;
            _dataSet = new DataSet();
            zy_Patlist = new ZY_PatList();
            zyPresOrder = new ZY_PresOrder();

            user = view.currentUser;
            dept = view.currentDept;
            //导入基础数据
            LoadINFO();

            BrushPatList(false);

            
            
            view.cbDept_set = _dataSet.Tables["Dept"];

            zyPresOrder.PatListID = zy_Patlist.PatListID;
            icM = ObjectFactory.GetObject<IcostManager>(typeof(ZY_CostMaster));
            
        }
        //[20100513.1.02] 传入收入病人
        public FrmPresManagerController(IFrmPresManagerView _view,bool IsOper)
        {
            view = _view;
            _dataSet = new DataSet();
            zy_Patlist = new ZY_PatList();
            zyPresOrder = new ZY_PresOrder();

            user = view.currentUser;
            dept = view.currentDept;
            //导入基础数据
            LoadINFO();

            BrushPatList(IsOper);



            view.cbDept_set = _dataSet.Tables["Dept"];

            zyPresOrder.PatListID = zy_Patlist.PatListID;
            icM = ObjectFactory.GetObject<IcostManager>(typeof(ZY_CostMaster));

        }
        //[20100513.1.02] 单个病人划价
        public FrmPresManagerController(IFrmPresManagerView _view,string CureNo)
        {
            view = _view;
            _dataSet = new DataSet();
            zy_Patlist = new ZY_PatList();
            zyPresOrder = new ZY_PresOrder();

            user = view.currentUser;
            dept = view.currentDept;
            //导入基础数据
            LoadINFO();

            BrushPatList(true);

            view.cbDept_set = _dataSet.Tables["Dept"];

            zyPresOrder.PatListID = zy_Patlist.PatListID;
            icM = ObjectFactory.GetObject<IcostManager>(typeof(ZY_CostMaster));

            InPatKeyDown();
            GetPresData(0);
            GetPresData(1);

        }

        /// <summary>
        /// 刷新病人列表
        /// </summary>
        public void BrushPatList(bool IsOper)
        {
            view.lvPatList_set = BindLvPatList(IsOper);
        }
        /// <summary>
        /// 双击病人列表
        /// </summary>
        public void GetPatlist()
        {
            zy_Patlist = view.zy_patlist_get;
            if (zy_Patlist != null)
            {
                zyPresOrder.PatID = zy_Patlist.PatID;
                zyPresOrder.PatListID = zy_Patlist.PatListID;

                view.BindPatControlData = zy_Patlist;
                icM.PatListID = zy_Patlist.PatListID;
                PatFee patFee = icM.GetPatFee();
                view.BindPatFeeControlData = patFee;
                view.PresDocCode = zy_Patlist.OriginDocCode;
            }
        }
        /// <summary>
        /// 根据住院号查询病人
        /// </summary>
        /// <returns></returns>
        public bool InPatKeyDown()
        {
            zy_Patlist = zy_Patlist.GetPatInfo(view.InpatNo);
            if (zy_Patlist != null)
            {
                if (zy_Patlist.PatType == "1" || zy_Patlist.PatType == "2")
                {
                    view.BindPatControlData = zy_Patlist;
                    icM.PatListID = zy_Patlist.PatListID;
                    view.BindPatFeeControlData = icM.GetPatFee();
                    return true;
                }
                return false;
            }
            else
            {
                view.InpatNo = "0";
                throw new Exception("您输入的住院号病人不存在！");
            }
        }
        /// <summary>
        /// 设置网格显示颜色
        /// </summary>
        /// <param name="zyPS"></param>
        /// <param name="rowid"></param>
        /// <param name="colid"></param>
        private void ShowRowColor(ZY_PresOrder zyPS,int rowid,int colid)
        {
            switch (zyPS.Record_Flag)
            {
                case -1:
                    view.presColor = new PresColor(rowid, -1, System.Drawing.Color.Black, System.Drawing.Color.White);
                    break;
                case 0:
                    System.Drawing.Color _forecolor = System.Drawing.Color.Blue;
                    System.Drawing.Color _color = System.Drawing.Color.WhiteSmoke;
                    if (zyPS.Charge_Flag == 0 && zyPS.Drug_Flag == 0)
                    {
                        _color = System.Drawing.Color.White;
                    }
                    else if (zyPS.Charge_Flag == 1 && zyPS.Drug_Flag == 0)
                    {
                        _forecolor = System.Drawing.Color.Orange;
                    }
                    else if (zyPS.Charge_Flag == 1 && zyPS.Drug_Flag == 1)
                    {
                        //_color = System.Drawing.Color.WhiteSmoke;
                        _forecolor = System.Drawing.Color.OrangeRed;
                    }
                    view.presColor = new PresColor(rowid, -1, _forecolor, _color);
                    break;
                case 1:
                    view.presColor = new PresColor(rowid, -1, System.Drawing.Color.Purple, System.Drawing.Color.WhiteSmoke);
                    break;
                case 2:
                    view.presColor = new PresColor(rowid, -1, System.Drawing.Color.Purple, System.Drawing.Color.WhiteSmoke);
                    break;
            }
        }
        /// <summary>
        /// 得到处方数据
        /// </summary>
        /// <param name="presType"></param>
        public void GetPresData(int presType)
        {
            if (presType == 0)
            {
                GetLongPresData();
            }
            else
            {
                GetShortPresData();
            }
        }
        /// <summary>
        /// 得到长期账单
        /// </summary>
        private void GetLongPresData()
        {
            if (zy_Patlist != null)
            {
                view.BindLongPresControlData =  zyPresOrder.GetPresDataTable(view.PresDate, 0);
                view.lblongFee = zyPresOrder.GetPresAllFee(view.PresDate,0).ToString();

                DataTable dt = view.BindLongPresControlData;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ZY_PresOrder zyPS=new ZY_PresOrder();
                    zyPS=(ZY_PresOrder)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dt,i,zyPS);
                    ShowRowColor(zyPS, i, -1);
                }
                if (dt.Rows.Count > 0)
                {
                    view.PresDocCode = dt.Rows[dt.Rows.Count - 1]["PRESDOCCODE"].ToString();
                }
            }
        }
        /// <summary>
        /// 得到临时账单
        /// </summary>
        private void GetShortPresData()
        {
            if (zy_Patlist != null)
            {
                view.BindShortPresControlData = zyPresOrder.GetPresDataTable(view.PresDate, 1);
                view.lbshortFee = zyPresOrder.GetPresAllFee(view.PresDate, 1).ToString();

                DataTable dt = view.BindShortPresControlData;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ZY_PresOrder zyPS = new ZY_PresOrder();
                    zyPS = (ZY_PresOrder)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dt, i, zyPS);
                    ShowRowColor(zyPS, i, -1);
                }
                if (dt.Rows.Count > 0)
                {
                    view.PresDocCode = dt.Rows[dt.Rows.Count - 1]["PRESDOCCODE"].ToString();
                }
            }
        }
        /// <summary>
        /// 新开
        /// </summary>
        /// <param name="PresType">0长期,1临时</param>
        /// <returns>行号</returns>
        public int AddRow(int PresType)
        {
            DataTable dt = null;
            if (PresType == 0)
            {
                dt = view.BindLongPresControlData;
            }
            else
            {
                dt = view.BindShortPresControlData;
            }
            int rowid;
            if (dt.Rows.Count > 0)
            {
                rowid = dt.Rows.Count - 1;
                if (dt.Rows[rowid]["ITEMNAME"].ToString().Trim() == "")	//最后一行不为空才允许新增一行
                {     
                    return rowid;
                }
                else
                {
                    List<ZY_PresOrder> _zyPresOrderSon = new List<ZY_PresOrder>();
                    ZY_PresOrder zyPresSon1 = new ZY_PresOrder();
                    zyPresSon1.XD = false;
                    zyPresSon1.Record_Flag = -1;
                    _zyPresOrderSon.Add(zyPresSon1);
                    DataTable ddt = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(_zyPresOrderSon);
                    dt.Rows.Add(ddt.Rows[0].ItemArray);
                    rowid= dt.Rows.Count-1;
                    return rowid;
                }
            }
            else
            {
                List<ZY_PresOrder> _zyPresOrderSon = new List<ZY_PresOrder>();
                ZY_PresOrder zyPresSon1 = new ZY_PresOrder();
                zyPresSon1.XD = false;
                zyPresSon1.Record_Flag = -1;
                _zyPresOrderSon.Add(zyPresSon1);

                if (PresType == 0)
                {
                    view.BindLongPresControlData = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(_zyPresOrderSon);
                    dt = view.BindLongPresControlData;
                }
                else
                {
                    view.BindShortPresControlData = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(_zyPresOrderSon);
                    dt = view.BindShortPresControlData;
                }
            }

            rowid = dt.Rows.Count - 1;
            return rowid;
        }
        /// <summary>
        /// 赋值
        /// </summary>
        /// <param name="PresType">0长期,1临时</param>
        /// <param name="rowid">行号</param>
        /// <param name="dr">列</param>
        /// <returns>列号</returns>
        public int SelectCardBindData(int PresType, int rowid, DataRow dr)
        {
            DataTable dt = null;
            if (PresType == 0)
            {
                dt = view.BindLongPresControlData;
            }
            else
            {
                dt = view.BindShortPresControlData;
            }
            string presType = XcConvert.IsNull(dr["PresType"], "-1").Trim();
            //模板
            if (presType == "6")
            {
                int feeType = Convert.ToInt32(dr["ITEMTYPE"]);//0 药品模板 ；1项目模板
                DataTable tempDt = zyPresOrder.GetPresTemplateData(Convert.ToInt32(dr["ITEMID"]));
                //循环模板
                for (int i = 0; i < tempDt.Rows.Count; i++)
                {
                    dr["ITEMID"] = tempDt.Rows[i]["ITEM_ID"];
                    presType = Convert.ToInt32(tempDt.Rows[i]["COMPLEX_ID"]) == 0 ? "4" : "5";
                    for (int k = 0; k < _dataSet.Tables["ITEM_DICTIONARY"].Rows.Count; k++)
                    {
                        //ITEMID && feeType == 0   PresType(1,2,3)
                        //ITEMID && feeType == 0   PresType(4,5)
                        if (_dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["ITEMID"].ToString().Trim() == tempDt.Rows[i]["ITEM_ID"].ToString().Trim() 
                            && ((feeType == 0 && (_dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["PresType"].ToString().Trim() == "1" 
                            || _dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["PresType"].ToString().Trim() == "2" 
                            || _dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["PresType"].ToString().Trim() == "3")) 
                            || (feeType == 1 
                            && _dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["PresType"].ToString().Trim() == presType)))
                        {
                            dr["ITEMTYPE"] = _dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["ITEMTYPE"];
                            dr["ITEMNAME"] = _dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["ITEMNAME"];
                            dr["STANDARD"] = _dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["STANDARD"];
                            dr["SELL_PRICE"] = _dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["SELL_PRICE"];
                            dr["PACKUNIT"] = _dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["PACKUNIT"];
                            dr["UNIT"] = _dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["UNIT"];
                            dr["EXECDEPTCODE"] = _dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["EXECDEPTCODE"];
                            dr["EXECDEPTNAME"] = _dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["EXECDEPTNAME"];
                            dr["PresType"] = _dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["PresType"];
                            dr["Buy_Price"] = _dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["Buy_Price"];
                            dr["RELATIONNUM"] = _dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["RELATIONNUM"];
                            dr["scale"] = _dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["scale"];
                            dr["STORENUM"] = _dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["STORENUM"];
                            break;
                        }
                    }
                    this.SelectCardEqualsData(dt,rowid, dr, Convert.ToDecimal(tempDt.Rows[i]["AMOUNT"]));
                    rowid = this.AddRow(PresType);
                }

            }//其他费用项目
            else
            {
                if (Convert.ToInt32(dr["STORENUM"]) > 0)
                    this.SelectCardEqualsData(dt, rowid, dr, 0);
                else
                    throw new Exception("该药品[" + dr["ITEMNAME"].ToString() + "]无库存！");
            }
            ZY_PresOrder zyPS = new ZY_PresOrder();
            zyPS = (ZY_PresOrder)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dt, rowid, zyPS);
            ShowRowColor(zyPS, rowid, -1);
            return rowid;
        }
        /// <summary>
        /// 计算金额
        /// </summary>
        /// <param name="presType">0长期,1临时</param>
        /// <param name="colid">列号</param>
        /// <param name="rowid">行号</param>
        public void CalculateFee(int presType, int colid, int rowid)
        {
            DataTable dt = null;
            if (presType == 0)
            {
                dt = view.BindLongPresControlData;
            }
            else
            {
                dt = view.BindShortPresControlData;
            }
            if (XcConvert.IsNull(dt.Rows[rowid]["ItemName"], "").ToString().Trim() != "")
            {
                decimal price = Convert.ToDecimal(dt.Rows[rowid]["Sell_PRICE"]);
                decimal RelationNum = Convert.ToDecimal(dt.Rows[rowid]["RelationNum"]);
                decimal binnum = Convert.ToDecimal(XcConvert.IsNull(dt.Rows[rowid]["BigNum"], "0"));
                decimal smallnum = Convert.ToDecimal(XcConvert.IsNull(dt.Rows[rowid]["SmallNum"], "0"));
                dt.Rows[rowid]["Amount"] = Convert.ToDecimal(binnum * RelationNum + smallnum).ToString("0.000");
                dt.Rows[rowid]["Tolal_Fee"] = zyPresOrder.CalculateAllFee(binnum, smallnum, RelationNum, price); //Convert.ToDecimal((binnum * price) + (smallnum * price / RelationNum)).ToString("0.0000");//Convert.ToDecimal((binnum * RelationNum + smallnum) * price).ToString("0.0000");

                dt.Rows[rowid]["PresAmount"] = 0;
                dt.Rows[rowid]["Record_Flag"] = -1;

                ZY_PresOrder zyPS = new ZY_PresOrder();
                zyPS = (ZY_PresOrder)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dt, rowid, zyPS);
                ShowRowColor(zyPS, rowid, -1);
            }
        }
        /// <summary>
        /// 设置列的只读
        /// </summary>
        /// <param name="presType">0长期,1临时</param>
        /// <param name="colid">列号</param>
        /// <param name="rowid">行号</param>
        public void SettingReadOnly(int presType, int colid, int rowid)
        {
            try
            {
                view.XDEnabled = FlatStyle.System;
                DataTable dt = null;
                if (presType == 0)
                {
                    dt = view.BindLongPresControlData;
                }
                else
                {
                    dt = view.BindShortPresControlData;
                }

                if (
                    /*Convert.ToInt32(XcConvert.IsNull(CurTable.Rows[dtgrdPresc.CurrentRowIndex]["DRUG_FLAG"], "0")) == 1 ||*/
                   Convert.ToInt32(XcConvert.IsNull(dt.Rows[rowid]["Record_Flag"], "0")) == 1 ||
                   Convert.ToInt32(XcConvert.IsNull(dt.Rows[rowid]["Record_Flag"], "0")) == 2
                   )
                {
                    view.XDEnabled = FlatStyle.Flat;
                    view.ItemIDReadOnly = true;
                    view.BigNumReadOnly = true;
                    view.SmallNumReadOnly = true;
                    return;
                }

                if (Convert.ToInt32(XcConvert.IsNull(dt.Rows[rowid]["charge_flag"], "0")) == 1)
                {
                    view.XDEnabled = FlatStyle.Flat;
                    view.ItemIDReadOnly = true;
                    view.BigNumReadOnly = true;
                    view.SmallNumReadOnly = true;
                    return;
                }

                if (Convert.ToInt32(XcConvert.IsNull(dt.Rows[rowid]["PresType"], "0")) >= 4
                    || Convert.ToInt32(XcConvert.IsNull(dt.Rows[rowid]["PresType"], "0")) == 3)
                {
                    view.ItemIDReadOnly = false;
                    view.BigNumReadOnly = true;
                    view.SmallNumReadOnly = false;
                }
                else
                {
                    view.ItemIDReadOnly = false;
                    view.BigNumReadOnly = false;
                    view.SmallNumReadOnly = false;
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 保存时检查处方的有效性
        /// </summary>
        /// <param name="presType"></param>
        /// <param name="colid"></param>
        /// <param name="rowid"></param>
        /// <param name="itemname">错误费用名称</param>
        /// <returns></returns>
        public bool CheckPresData(int presType , out int colid,out int rowid,out string itemname)
        {
            DataTable dt = null;
            if (presType == 0)
            {
                dt = view.BindLongPresControlData;
            }
            else
            {
                dt = view.BindShortPresControlData;
            }

            #region 数据合理性判断

            if (dt.Rows.Count == 0)
            {
                //MessageBox.Show("没有需要保存的处方记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                colid = 0;
                rowid = 0;
                itemname = null;
                return false;
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToDecimal(dt.Rows[i]["Amount"]) <= 0
                    && Convert.ToInt32(dt.Rows[i]["Record_Flag"]) == -1
                    && XcConvert.IsNull(dt.Rows[i]["ItemName"], "").ToString().Trim() != "")
                {
                    //MessageBox.Show(tb.Rows[i]["ItemName"].ToString() + "数量等于或者小于零！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);       
                    if (Convert.ToInt32(dt.Rows[i]["PresType"]) >= 4 || Convert.ToInt32(dt.Rows[i]["PresType"]) == 3)
                    {
                        rowid = i;
                        colid = 10;
                        itemname = XcConvert.IsNull(dt.Rows[i]["ItemName"], "").ToString();
                    }
                    else
                    {
                        rowid = i;
                        colid = 8;
                        itemname = XcConvert.IsNull(dt.Rows[i]["ItemName"], "").ToString();
                    }
                    return false;
                }
            }
            colid = 0;
            rowid = 0;
            itemname = null;
            return true;

            #endregion
        }
        /// <summary>
        /// 保存处方
        /// </summary>
        /// <param name="presType"></param>
        public void SavePresData(int presType)
        {
            DataTable dt = null;
            if (presType == 0)
            {
                dt = view.BindLongPresControlData;
            }
            else
            {
                dt = view.BindShortPresControlData;
            }


            List<ZY_PresOrder> zy_PresOrderList = new List<ZY_PresOrder>();
            bool b = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToInt32(XcConvert.IsNull(dt.Rows[i]["charge_flag"], "0")) == 1)
                    continue;
                if (Convert.ToInt32(dt.Rows[i]["Record_Flag"]) == -1
                    && XcConvert.IsNull(dt.Rows[i]["ItemName"], "").ToString().Trim() != "")
                {
                    ZY_PresOrder zypresorder = new ZY_PresOrder();
                    zypresorder = (ZY_PresOrder)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dt, i, zypresorder);
                    if (i == 0 || Convert.ToInt32(dt.Rows[i]["Record_Flag"]) == -1)
                    {
                        zypresorder.Order_Flag = i;
                    }
                    else
                    {
                        zypresorder.Order_Flag = Convert.ToInt32(dt.Rows[i - 1]["order_flag"]) + 1;
                        dt.Rows[i]["order_flag"] = zypresorder.Order_Flag;
                    }
                    zypresorder.PatID = zy_Patlist.PatID;
                    zypresorder.PatListID = zy_Patlist.PatListID;
                    //[20100526.0.02]
                    zypresorder.PresDeptCode = dept.DeptID.ToString();
                    //zypresorder.PresDocCode = this.tbPresDoc.Text;
                    zypresorder.Record_Flag = 0;
                    zypresorder.PresDate = view.PresDate;
                    //把插入的数据位数改为界面一样
                    zypresorder.Tolal_Fee = Convert.ToDecimal(zypresorder.Tolal_Fee.ToString("0.00"));
                    zypresorder.order_type = presType;
                    zy_PresOrderList.Add(zypresorder);
                    b = true;
                }
            }
            if (b)
            {
                zyPresOrder.SavePres(zy_PresOrderList);
            }
        }
        /// <summary>
        /// 选定对应的行
        /// </summary>
        /// <param name="presType"></param>
        /// <param name="rowid">行号</param>
        /// <param name="b">是否全选</param>
        public void CellXD(int presType, int rowid, bool b)
        {
            if (rowid > -1)
            {
                DataTable dt = null;
                if (presType == 0)
                {
                    dt = view.BindLongPresControlData;
                }
                else
                {
                    dt = view.BindShortPresControlData;
                }
                if ((bool)dt.Rows[rowid]["XD"] == true)
                {
                    if (b)
                        dt.Rows[rowid]["XD"] = false;
                }
                else
                {
                    if (Convert.ToInt32(dt.Rows[rowid]["Charge_Flag"]) != 1)
                        dt.Rows[rowid]["XD"] = true;
                }
            }
        }
        /// <summary>
        /// 删除网格数据
        /// </summary>
        /// <param name="presType"></param>
        public void PresDel(int presType)
        {
            DataTable dt = null;
            if (presType == 0)
            {
                dt = view.BindLongPresControlData;
            }
            else
            {
                dt = view.BindShortPresControlData;
            }
            List<DataRow> rows= new List<DataRow>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if ((bool)dt.Rows[i]["XD"] == true)
                {
                    if (Convert.ToInt32(dt.Rows[i]["Charge_Flag"]) != 1
                        && Convert.ToInt32(dt.Rows[i]["RECORD_FLAG"]) != -1)
                    {
                        zyPresOrder.PresOrderID=Convert.ToInt32(dt.Rows[i]["PRESORDERID"]);
                        zyPresOrder.DelPres();
                        rows.Add(dt.Rows[i]);
                    }
                    else if (Convert.ToInt32(dt.Rows[i]["RECORD_FLAG"]) == -1)
                    {
                        rows.Add(dt.Rows[i]);
                    }
                }
            }
            for (int i = 0; i < rows.Count; i++)
            {
                dt.Rows.Remove(rows[i]);
            }
        }
        /// <summary>
        /// 删除网格数据
        /// </summary>
        /// <param name="presType"></param>
        /// <param name="rowid"></param>
        public void PresDel(int presType, int rowid)
        {
            if (rowid > -1)
            {
                DataTable dt = null;
                if (presType == 0)
                {
                    dt = view.BindLongPresControlData;
                }
                else
                {
                    dt = view.BindShortPresControlData;
                }
                DataRow rows = null;
                if (Convert.ToInt32(dt.Rows[rowid]["Charge_Flag"]) != 1
                    && Convert.ToInt32(dt.Rows[rowid]["RECORD_FLAG"]) != -1)
                {
                    zyPresOrder.PresOrderID = Convert.ToInt32(dt.Rows[rowid]["PRESORDERID"]);
                    zyPresOrder.DelPres();
                    rows = dt.Rows[rowid];
                }
                else if (Convert.ToInt32(dt.Rows[rowid]["RECORD_FLAG"]) == -1)
                {
                    rows = dt.Rows[rowid];
                }
                if (rows != null)
                    dt.Rows.Remove(rows);
            }
        }
        /// <summary>
        /// 记账时判断库存是否足够
        /// </summary>
        /// <param name="presType"></param>
        /// <param name="Message"></param>
        /// <returns></returns>
        public bool CheckPresMark(int presType, out string Message)
        {
            Message = "";
            DataTable dt = null;
            if (presType == 0)
            {
                dt = view.BindLongPresControlData;
            }
            else
            {
                dt = view.BindShortPresControlData;
            }

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    if (Convert.ToInt32(dt.Rows[i]["PresOrderID"]) != 0)
                    {
                        if ((bool)dt.Rows[i]["XD"] == true && Convert.ToInt32(dt.Rows[i]["Charge_Flag"]) != 1)
                        {
                            DataRow[] drs=_dataSet.Tables["ITEM_DICTIONARY"].Select(" PRESTYPE<4 and ITEMID = " + dt.Rows[i]["itemid"].ToString());
                            if (drs.Length > 0)
                            {
                                decimal amount = Convert.ToDecimal(drs[0]["STORENUM"]);
                                if (Convert.ToDecimal(dt.Rows[i]["Amount"]) > amount)
                                {
                                    Message += "[" + dt.Rows[i]["itemname"].ToString() + "]当前库存数量：" + amount.ToString("0.00") + "  实际记账数量：" + Convert.ToDecimal(dt.Rows[i]["Amount"]).ToString("0.00") + "！\n";
                                }
                            }
                        }
                    }
                }
            }
            if (Message != "") return false;
            return true;
        }
        public bool CheckPresMark(int presType, int rowid, out string Message)
        {
            Message = "";
            DataTable dt = null;
            if (presType == 0)
            {
                dt = view.BindLongPresControlData;
            }
            else
            {
                dt = view.BindShortPresControlData;
            }

            if (dt.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt.Rows[rowid]["PresOrderID"]) != 0)
                {
                    if ((bool)dt.Rows[rowid]["XD"] == true && Convert.ToInt32(dt.Rows[rowid]["Charge_Flag"]) != 1)
                    {
                        DataRow[] drs = _dataSet.Tables["ITEM_DICTIONARY"].Select(" PRESTYPE<4 and ITEMID = " + dt.Rows[rowid]["itemid"].ToString());
                        if (drs.Length > 0)
                        {
                            decimal amount = Convert.ToDecimal(drs[0]["STORENUM"]);
                            if (Convert.ToDecimal(dt.Rows[rowid]["Amount"]) > amount)
                            {
                                Message += "[" + dt.Rows[rowid]["itemname"].ToString() + "]当前库存数量：" + amount.ToString("0.00") + "  实际记账数量：" + Convert.ToDecimal(dt.Rows[rowid]["Amount"]).ToString("0.00") + "！\n";
                            }
                        }
                    }
                }
            }
            if (Message != "") return false;
            return true;
        }
        /// <summary>
        /// 检查该病人是否已经结算
        /// </summary>
        /// <returns></returns>
        public bool CheckPatCost()
        {
            if (zy_Patlist.getPatType() != zy_Patlist.PatType)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 记账
        /// </summary>
        /// <param name="presType"></param>
        public void PresMark(int presType)
        {
            DataTable dt = null;
            if (presType == 0)
            {
                dt = view.BindLongPresControlData;
            }
            else
            {
                dt = view.BindShortPresControlData;
            }

            if (dt.Rows.Count > 0)
            {
                List<int> intlist = new List<int>();
                List<string> prestype = new List<string>();
                List<string> ChargeCodeL = new List<string>();
                List<DateTime> CostDateL = new List<DateTime>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt.Rows[i]["PresOrderID"]) != 0)
                    {
                        if ((bool)dt.Rows[i]["XD"]==true && Convert.ToInt32(dt.Rows[i]["Charge_Flag"]) != 1)
                        {
                            dt.Rows[i]["ChargeCode"] = user.EmployeeID.ToString();
                            dt.Rows[i]["CostDate"] = XcDate.ServerDateTime;

                            intlist.Add(Convert.ToInt32(dt.Rows[i]["PresOrderID"]));
                            prestype.Add(dt.Rows[i]["PRESTYPE"].ToString());
                            ChargeCodeL.Add(user.EmployeeID.ToString());
                            CostDateL.Add(XcDate.ServerDateTime);
                            dt.Rows[i]["Charge_Flag"] = 1;
                            dt.Rows[i]["Drug_Flag"] = 0;
                        }
                    }
                }
                if (intlist.Count > 0)
                {
                    //2009-4-8 zy update 执行成功后提示
                    zyPresOrder.ChargePres(intlist, prestype, ChargeCodeL, CostDateL);

                    GetPresData(presType);
                    icM.PatListID = zy_Patlist.PatListID;
                    view.BindPatFeeControlData = icM.GetPatFee();
                    //Nccm_UploadFee();//农合记账

                }
            }
           
        }
        /// <summary>
        /// 记账
        /// </summary>
        /// <param name="presType"></param>
        /// <param name="rowid"></param>
        public void PresMark(int presType, int rowid)
        {
            if (rowid > -1)
            {
                DataTable dt = null;
                if (presType == 0)
                {
                    dt = view.BindLongPresControlData;
                }
                else
                {
                    dt = view.BindShortPresControlData;
                }

                List<int> intlist = new List<int>();
                List<string> prestype = new List<string>();
                List<string> ChargeCodeL = new List<string>();
                List<DateTime> CostDateL = new List<DateTime>();
                if (Convert.ToInt32(dt.Rows[rowid]["PresOrderID"]) != 0)
                {
                    if (Convert.ToInt32(dt.Rows[rowid]["Charge_Flag"]) != 1)
                    {
                        dt.Rows[rowid]["ChargeCode"] = user.EmployeeID.ToString();
                        dt.Rows[rowid]["CostDate"] = XcDate.ServerDateTime;

                        intlist.Add(Convert.ToInt32(dt.Rows[rowid]["PresOrderID"]));
                        prestype.Add(dt.Rows[rowid]["PRESTYPE"].ToString());
                        ChargeCodeL.Add(user.EmployeeID.ToString());
                        CostDateL.Add(XcDate.ServerDateTime);
                        dt.Rows[rowid]["Charge_Flag"] = 1;
                        if (Convert.ToInt32(dt.Rows[rowid]["PRESTYPE"])>= 4)
                        {
                            dt.Rows[rowid]["Drug_Flag"] = 1;
                        }
                        else
                        {
                            dt.Rows[rowid]["Drug_Flag"] = 0;
                        }
                        ZY_PresOrder zyPS = new ZY_PresOrder();
                        zyPS = (ZY_PresOrder)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dt, rowid, zyPS);
                        ShowRowColor(zyPS, rowid, -1);
                        //2009-4-8 zy update 执行成功后提示
                        zyPresOrder.ChargePres(intlist, prestype, ChargeCodeL, CostDateL);
                        icM.PatListID = zy_Patlist.PatListID;
                        view.BindPatFeeControlData = icM.GetPatFee();
                    }
                }    
            }
        }
        /// <summary>
        /// 长期导入医嘱
        /// </summary>
        /// <param name="presType"></param>
        public string PresLoad(int presType)
        {
            string loadMessage = null;
            DataTable dt = zyPresOrder.GetPresDataTable(view.PresDate.AddDays(-1));

            DataTable CurData = null;
            if (presType == 0)
            {
                CurData = view.BindLongPresControlData;
            }
            else
            {
                CurData = view.BindShortPresControlData;
            }
            if (CurData.Rows.Count <= 0)
            {
                List<ZY_PresOrder> _zyPresOrderSon = new List<ZY_PresOrder>();
                ZY_PresOrder zyPresSon1 = new ZY_PresOrder();
                zyPresSon1.XD = false;
                zyPresSon1.Record_Flag = -1;
                _zyPresOrderSon.Add(zyPresSon1);
                if (presType == 0)
                {
                    view.BindLongPresControlData = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(_zyPresOrderSon);
                    CurData = view.BindLongPresControlData;
                }
                else
                {
                    view.BindShortPresControlData = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(_zyPresOrderSon);
                    CurData = view.BindShortPresControlData;
                }
                CurData.Rows.Clear();
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["PresOrderID"] = 0;

                dt.Rows[i]["PatID"] = 0;
                dt.Rows[i]["PatListID"] = 0;
                if (CurData.Rows.Count > 0)
                {
                    dt.Rows[i]["PresMasterID"] = CurData.Rows[CurData.Rows.Count - 1]["PresMasterID"];
                }
                else
                {
                    dt.Rows[i]["PresMasterID"] = 0;
                }
                dt.Rows[i]["PresDate"] = DBNull.Value;
                dt.Rows[i]["MarkDate"] = DBNull.Value;
                dt.Rows[i]["CostDate"] = DBNull.Value;
                dt.Rows[i]["Charge_Flag"] = 0;
                dt.Rows[i]["Drug_Flag"] = 0;
                dt.Rows[i]["Delete_Flag"] = 0;
                dt.Rows[i]["OldID"] = 0;
                dt.Rows[i]["CostMasterID"] = 0;
                dt.Rows[i]["Cost_Flag"] = 0;
                dt.Rows[i]["PassID"] = 0;

                dt.Rows[i]["ROWNO"] = CurData.Rows.Count + 1;
                dt.Rows[i]["RECORD_FLAG"] = -1;

                for (int k = 0; k < _dataSet.Tables["ITEM_DICTIONARY"].Rows.Count; k++)
                {
                    //if (_dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["ITEMID"].ToString().Trim() == dt.Rows[i]["ITEMID"].ToString().Trim() 
                    //    && _dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["EXECDEPTCODE"].ToString().Trim() == dt.Rows[i]["EXECDEPTCODE"].ToString().Trim())
                    //{
                    if (_dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["ITEMID"].ToString().Trim() == dt.Rows[i]["ITEMID"].ToString().Trim()
                        && ((Convert.ToInt32(dt.Rows[i]["PRESTYPE"]) < 4 && (_dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["PresType"].ToString().Trim() == "1"
                        || _dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["PresType"].ToString().Trim() == "2"
                        || _dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["PresType"].ToString().Trim() == "3"))
                        || (Convert.ToInt32(dt.Rows[i]["PRESTYPE"]) == 4
                        && _dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["PresType"].ToString().Trim() == "4")
                        || (Convert.ToInt32(dt.Rows[i]["PRESTYPE"]) == 5
                        && _dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["PresType"].ToString().Trim() == "5")

                        ))
                    {
                        dt.Rows[i]["ITEMTYPE"] = _dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["ITEMTYPE"];
                        dt.Rows[i]["PRESTYPE"] = _dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["PRESTYPE"];
                        dt.Rows[i]["ITEMNAME"] = _dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["ITEMNAME"];
                        dt.Rows[i]["STANDARD"] = _dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["STANDARD"];
                        dt.Rows[i]["UNIT"] = _dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["UNIT"];
                        dt.Rows[i]["RELATIONNUM"] = _dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["RELATIONNUM"];
                        dt.Rows[i]["BUY_PRICE"] = _dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["BUY_PRICE"];
                        dt.Rows[i]["SELL_PRICE"] = _dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["SELL_PRICE"];
                        dt.Rows[i]["PACKUNIT"] = _dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["PACKUNIT"];
                        decimal binnum = Convert.ToDecimal(XcConvert.IsNull(dt.Rows[i]["BigNum"], "0"));
                        decimal price = Convert.ToDecimal(dt.Rows[i]["Sell_PRICE"]);
                        decimal smallnum = Convert.ToDecimal(XcConvert.IsNull(dt.Rows[i]["SmallNum"], "0"));
                        decimal RelationNum = Convert.ToDecimal(dt.Rows[i]["RelationNum"]);

                        decimal _amount = Convert.ToDecimal(_dataSet.Tables["ITEM_DICTIONARY"].Rows[k]["STORENUM"]);
                        decimal amount = binnum * RelationNum + smallnum;
                        if (_amount < amount)//导入时库存量不足时
                        {
                            //binnum = (_amount - (_amount % RelationNum)) / RelationNum;
                            //smallnum = _amount % RelationNum;
                            //loadMessage += "[" + dt.Rows[i]["ITEMNAME"] + "]" + "库存已经不足，由原来的" + dt.Rows[i]["BigNum"].ToString() + dt.Rows[i]["PACKUNIT"].ToString() + dt.Rows[i]["SmallNum"].ToString() + dt.Rows[i]["UNIT"].ToString() + "更改为" + binnum.ToString() + dt.Rows[i]["PACKUNIT"].ToString() + smallnum.ToString() + dt.Rows[i]["UNIT"].ToString() + "\n";
                            //dt.Rows[i]["BigNum"] = Convert.ToInt32(binnum);
                            //dt.Rows[i]["SmallNum"] = Convert.ToInt32(smallnum);
                            loadMessage += "[" + dt.Rows[i]["ITEMNAME"] + "]" + "\t库存已经不足\n";
                        }

                        dt.Rows[i]["TOLAL_FEE"] = Convert.ToDecimal((binnum * price) + (smallnum * price / RelationNum)).ToString("0.0000");

                        break;
                    }
                    if (k == _dataSet.Tables["ITEM_DICTIONARY"].Rows.Count - 1)
                    {
                        loadMessage += "[" + dt.Rows[i]["ITEMNAME"] + "]\t已经停止使用或没有库存\n";
                        //dt.Rows[i]["BigNum"] = 0;
                        //dt.Rows[i]["SmallNum"] = 0;
                        //dt.Rows[i]["Amount"] = 0;
                        //dt.Rows[i]["TOLAL_FEE"] = 0;
                    }
                }

                CurData.Rows.Add(dt.Rows[i].ItemArray);
            }
            //2009-4-8 zh update 执行成功后提示
            if (dt.Rows.Count <= 0)
            {
                throw new Exception("没有可以导入的医嘱！");
            }
            return loadMessage;

        }

        /// <summary>
        /// 更改处方医生
        /// </summary>
        public void ChangePresDoc(int presType, int rowid)
        {

            if (rowid > -1)
            {
                DataTable dt = null;
                if (presType == 0)
                {
                    dt = view.BindLongPresControlData;
                }
                else
                {
                    dt = view.BindShortPresControlData;
                }
                if (view.PresDocCode != null)
                {
                    dt.Rows[rowid]["PRESDOCCODE"] = view.PresDocCode;
                    dt.Rows[rowid]["DocName"] = HIS.SYSTEM.PubicBaseClasses.GWIString.FilterSpecial(view.PresDocName);
                }
                if (Convert.ToInt32(dt.Rows[rowid]["Record_Flag"]) != -1)
                {
                    int presOrderID=Convert.ToInt32(dt.Rows[rowid]["PresOrderID"]);
                    zyPresOrder.ChangePresDoc(presOrderID, view.PresDocCode);
                }
            }
        }
        /// <summary>
        /// 加载基本数据
        /// </summary>
        public void LoadINFO()
        {
            DataTable tb = null;
            if (view.PresType == PresType.划价)
            {
                tb = zyPresOrder.LoadDrugData(dept.DeptID.ToString());
            }
            else if (view.PresType == PresType.记账)
            {
                tb = zyPresOrder.LoadAllData(view.yfDeptID.ToString());
            }

            tb.TableName = "ITEM_DICTIONARY";
            if (_dataSet.Tables.Contains("ITEM_DICTIONARY"))
            {
                _dataSet.Tables.Remove("ITEM_DICTIONARY");
            }
            _dataSet.Tables.Add(tb);

            tb = BaseDataFactory.GetData(baseDataType.医生);
            tb.TableName = "User";
            if (_dataSet.Tables.Contains("User"))
            {
                _dataSet.Tables.Remove("User");
            }
            _dataSet.Tables.Add(tb);

            tb = BaseDataFactory.GetData(baseDataType.住院临床科室);
            tb.TableName = "Dept";
            if (_dataSet.Tables.Contains("Dept"))
            {
                _dataSet.Tables.Remove("Dept");
            }
            _dataSet.Tables.Add(tb);

            if (_dataSet.Tables.Contains("yfDept"))
            {
                _dataSet.Tables.Remove("yfDept");
            }

            tb=BaseDataFactory.GetData(baseDataType.药房科室);
            tb.TableName = "yfDept";
            DataRow dr = tb.NewRow();
            dr["deptname"] = "全部药房";
            dr["deptid"] = -1;
            tb.Rows.Add(dr);
            _dataSet.Tables.Add(tb);

            view.Initialize(_dataSet);
        }

        public void ReLoadDurgData()
        {
            DataTable tb = null;
            if (view.PresType == PresType.划价)
            {
                tb = zyPresOrder.LoadDrugData(dept.DeptID.ToString());
            }
            else if (view.PresType == PresType.记账)
            {
                tb = zyPresOrder.LoadAllData(view.yfDeptID.ToString());
            }

            tb.TableName = "ITEM_DICTIONARY";
            if (_dataSet.Tables.Contains("ITEM_DICTIONARY"))
            {
                _dataSet.Tables.Remove("ITEM_DICTIONARY");
            }
            _dataSet.Tables.Add(tb);
            view.ReLoadDurgData(tb);
        }

        private List<ZY_PatList> BindLvPatList(bool IsOper)
        {
            BindPatListVal bplv = new BindPatListVal();
            bplv.IsIn = view.searchPatList.rbIn;
            bplv.DeptCode = view.searchPatList.DeptCode;
            bplv.Bdate = view.searchPatList.Bdate;
            bplv.Edate = view.searchPatList.Edate;
            bplv.IsOperation = IsOper;
            zy_Patlist.bindPatListVal = bplv;
            return zy_Patlist.BindPatList();
        }

        private void SelectCardEqualsData(DataTable dt,int rowid, DataRow dr, decimal Amount)
        {
            dt.Rows[rowid]["ITEMID"] = XcConvert.IsNull(dr["ITEMID"], "");
            dt.Rows[rowid]["ITEMTYPE"] = XcConvert.IsNull(dr["ITEMTYPE"], "-1");
            dt.Rows[rowid]["ITEMNAME"] = XcConvert.IsNull(dr["ITEMNAME"], "");
            dt.Rows[rowid]["STANDARD"] = XcConvert.IsNull(dr["STANDARD"], "");
            dt.Rows[rowid]["Sell_PRICE"] = Convert.ToDecimal(XcConvert.IsNull(dr["Sell_PRICE"], "0")).ToString("0.0000");
            dt.Rows[rowid]["PACKUNIT"] = XcConvert.IsNull(dr["PACKUNIT"], "");
            dt.Rows[rowid]["UNIT"] = XcConvert.IsNull(dr["UNIT"], "");
            string execDeptCode = XcConvert.IsNull(dr["EXECDEPTCODE"], "-1");
            if (execDeptCode == "-1")
            {
                dt.Rows[rowid]["ExecDept"] = dept.Name;
                dt.Rows[rowid]["ExecDeptCode"] = dept.DeptID.ToString();
            }
            else
            {
                dt.Rows[rowid]["ExecDept"] = XcConvert.IsNull(dr["EXECDEPTNAME"], ""); ;
                dt.Rows[rowid]["ExecDeptCode"] = execDeptCode;
            }
            dt.Rows[rowid]["PresType"] = XcConvert.IsNull(dr["PresType"], "-1");
            dt.Rows[rowid]["Buy_Price"] = Convert.ToDecimal(XcConvert.IsNull(dr["Buy_Price"], "0.00")).ToString("0.0000");
            dt.Rows[rowid]["RelationNum"] = Convert.ToDecimal(XcConvert.IsNull(dr["RelationNum"], "0.00")).ToString("0.000");
            dt.Rows[rowid]["Comp_Money"] = Convert.ToDecimal(XcConvert.IsNull(dr["scale"], "0.00")).ToString("0.00");

          

            if (dr["PresType"].ToString().Trim() != "1" && dr["PresType"].ToString().Trim() != "2")
            {
                dt.Rows[rowid]["BigNum"] = 0;
                dt.Rows[rowid]["SmallNum"] = Amount;
            }
            else
            {
                dt.Rows[rowid]["BigNum"] = Convert.ToInt32((Amount - (Amount % Convert.ToDecimal(dr["RelationNum"]))) / Convert.ToDecimal(dr["RelationNum"]));
                dt.Rows[rowid]["SmallNum"] = Amount % Convert.ToDecimal(dr["RelationNum"]);
            }
            decimal binnum = Convert.ToDecimal(dt.Rows[rowid]["BigNum"]);
            decimal price = Convert.ToDecimal(dt.Rows[rowid]["Sell_PRICE"]);
            decimal smallnum = Convert.ToDecimal(dt.Rows[rowid]["SmallNum"]);
            decimal RelationNum = Convert.ToDecimal(dt.Rows[rowid]["RelationNum"]);

            dt.Rows[rowid]["Amount"] = Convert.ToDecimal(Amount).ToString("0.00");
            dt.Rows[rowid]["Tolal_Fee"] = Convert.ToDecimal((binnum * price) + (smallnum * price / RelationNum)).ToString("0.00");

            if (rowid > 0)
            {
                dt.Rows[rowid]["PresMasterID"] = dt.Rows[rowid - 1]["PresMasterID"];
            }
            dt.Rows[rowid]["Record_Flag"] = -1;
            if (view.PresDocCode != null)
            {
                dt.Rows[rowid]["PRESDOCCODE"] = view.PresDocCode;
                dt.Rows[rowid]["DocName"] = HIS.SYSTEM.PubicBaseClasses.GWIString.FilterSpecial(view.PresDocName);
            }
            dt.Rows[rowid]["presdate"] = view.PresDate;
            //如果为项目则不输包装数
            if (Convert.ToInt32(XcConvert.IsNull(dt.Rows[rowid]["PresType"], "0")) >= 4 || Convert.ToInt32(XcConvert.IsNull(dt.Rows[rowid]["PresType"], "0")) == 3)
            {
                view.BigNumReadOnly = true;//基本数
            }

        }

        //记账、冲账农合费用上传
        //private void Nccm_UploadFee()
        //{
        //    try
        //    {
        //        if (zy_Patlist.PatientInfo.ACCOUNTTYPE.Trim() == "农合")
        //        {
        //            if (zy_Patlist.PatientInfo.MediCard != null && zy_Patlist.PatientInfo.MediCard.Trim() != "")
        //            {
        //                IZY_NccmInterface nccmInterface = NccmFactory.Create();
        //                if (nccmInterface != null)
        //                {
        //                    nccmInterface.zy_Patlist = zy_Patlist;
        //                    DataTable dt = HIS.ZY_BLL.OP_PresManage.GetPresDataTable(zy_Patlist.PatListID);
        //                    nccmInterface.UploadZYPatFee(nccmInterface.ConvertFeeDetail(dt));
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}
    }
}
