using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using grproLib;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.MZDoc_BLL;

namespace HIS_MZDocManager.Action
{
    /// <summary>
    /// 医生模板控制类
    /// </summary>
    public class FrmMedicalManageController : BasePresController
    {
        private IFrmMedicalManageView _view;
        private DataTable _presCopy;   //处方复制拷贝

        public FrmMedicalManageController(IFrmMedicalManageView view)
        {
            _view = view;
            base.View = this._view;
            base.PresListType = HIS.MZDoc_BLL.Public.PresListType.病人处方明细;
            LoadBaseData();
            LoadPresList();
            _view.Initialize(_dataSet);
        }

        #region 方法
        /// <summary>
        /// 加载基础数据
        /// </summary>
        private new void LoadBaseData()
        {
            base.LoadBaseData();
            if (_dataSet.Tables.IndexOf("Item_Diagnosis") < 0)
            {
                DataTable tb = new CommonDiagnosis().LoadShowCardData();
                tb.TableName = "Item_Diagnosis";
                _dataSet.Tables.Add(tb);
            }
            if (_dataSet.Tables.IndexOf("Usage_Fee_Dictionary") < 0)
            {
                DataTable tb = HIS.MZDoc_BLL.OP_ReadBaseData.GetUsageFeeData();
                tb.TableName = "Usage_Fee_Dictionary";
                _dataSet.Tables.Add(tb);
            }
        }

        /// <summary>
        /// 加载处方
        /// </summary>
        public void LoadPresList()
        {
            _view.BindPresDataSource = _view.CurrentPatient.GetPrescription(_view.currentUser.EmployeeID);
            for (int index = 0; index < _view.BindPresDataSource.Rows.Count; index++)
            {
                SetCellColor(index, -1);
            }
            ShowItemMoneyStatus();
            _view.RefreshPres();
        }

        /// <summary>
        /// 显示状态栏金额提示值
        /// </summary>
        private void ShowItemMoneyStatus()
        {
            if (_view.BindPresDataSource == null)
                return;

            if (_view.BindPresDataSource.Rows.Count == 0)
            {
                _view.ItemMoneyStatus = "未保存：￥0.00元  保存未收费：￥0.00元  已收费：￥0.00元  总合计：￥0.00元";
            }
            else
            {
                decimal newMoney = CalculateMoney(HIS.MZDoc_BLL.Public.PresStatus.新建状态);
                decimal saveMoney = CalculateMoney(HIS.MZDoc_BLL.Public.PresStatus.保存状态);
                decimal chargeMoney = CalculateMoney(HIS.MZDoc_BLL.Public.PresStatus.收费状态);
                decimal tatolMoney = newMoney + saveMoney + chargeMoney;
                _view.ItemMoneyStatus = "未保存：￥" + newMoney.ToString("0.00") + "元  保存未收费：￥" + saveMoney.ToString("0.00") + "元  已收费：￥"
                    + chargeMoney.ToString("0.00") + "元  总合计：￥" + tatolMoney.ToString("0.00") + "元";
            }
        }

        private decimal CalculateMoney(HIS.MZDoc_BLL.Public.PresStatus status)
        {
            //2009-12-22 统一医生站和收费系统的处方费用合计
            //DataTable table = new DataTable();
            //table.Columns.Add("PresNo", Type.GetType("System.Int32"));
            //table.Columns.Add("StatItem_Code", Type.GetType("System.String"));
            //table.Columns.Add("Item_Money", Type.GetType("System.Decimal"));
            //for (int index = 0; index < rows.Length; index++)
            //{
            //    DataRow[] statItemRows = table.Select("StatItem_Code='" + rows[index]["StatItem_Code"].ToString() + "' and PresNo=" + rows[index]["PresNo"].ToString());
            //    if (statItemRows == null || statItemRows.Length <= 0)
            //    {
            //        DataRow row = table.NewRow();
            //        row["PresNo"] = rows[index]["PresNo"];
            //        row["StatItem_Code"] = rows[index]["StatItem_Code"];
            //        row["Item_Money"] = rows[index]["Item_Money"];
            //        table.Rows.Add(row);
            //    }
            //    else
            //    {
            //        statItemRows[0]["Item_Money"] = Convert.ToDecimal(statItemRows[0]["Item_Money"]) + Convert.ToDecimal(rows[index]["Item_Money"]);
            //    }
            //}

            //decimal item_money = 0;
            //for (int index = 0; index < table.Rows.Count; index++)
            //{
            //    //item_money += Decimal.Round(Convert.ToDecimal(table.Rows[index]["Item_Money"]) + (decimal)0.00000001, 1);
            //    item_money += HIS.MZDoc_BLL.Public.Function.ConvertToDoubleDigit(Convert.ToDecimal(table.Rows[index]["Item_Money"]));
            //}
            //return item_money;
            decimal itemMoney = 0;
            int maxPresNo = Convert.ToInt32(_view.BindPresDataSource.Compute("max(PresNo)", "Item_Id>0"));
            for (int index = 1; index <= maxPresNo; index++)
            {
                itemMoney += HIS.MZDoc_BLL.OP_Prescription.GetPresTotalFee(_view.BindPresDataSource.Select("Item_Id>0 and Status=" + status.GetHashCode() + " and PresNo=" + index));
            }
            return itemMoney;
        }

        /// <summary>
        /// 计算金额
        /// </summary>
        /// <param name="rowNo"></param>
        private decimal CalculateMoney(DataRow[] rows)
        {
            return HIS.MZDoc_BLL.OP_Prescription.GetPresTotalFee(rows);
        }

        /// <summary>
        /// 计算金额
        /// </summary>
        /// <param name="rowNo"></param>
        private void CalculateMoney(int rowNo)
        {
            if (_view.BindPresDataSource.Rows[rowNo]["Item_Name_S"].ToString().Trim() == "小计：")
            {
                _view.BindPresDataSource.Rows[rowNo]["Item_Money"] = CalculateMoney(_view.BindPresDataSource.Select("Item_Id>0 and PresNo=" + Convert.ToInt32(_view.BindPresDataSource.Rows[rowNo]["PresNo"])));
            }
            else
            {
                HIS.MZDoc_BLL.Prescription presList = (HIS.MZDoc_BLL.Prescription)HIS.MZDoc_BLL.Public.Function.DataRowToObject<HIS.MZDoc_BLL.Prescription>(_view.BindPresDataSource.Rows[rowNo]);
                presList.CalculateMoney();
                _view.BindPresDataSource.Rows[rowNo].ItemArray = HIS.MZDoc_BLL.Public.Function.ObjectToDataRow(presList).ItemArray;
                if (rowNo > 0 && _view.BindPresDataSource.Rows[rowNo - 1]["Item_Name_S"].ToString().Trim() == "小计：")
                {
                    CalculateMoney(rowNo - 1);
                }
                for (int index = rowNo + 1; index < _view.BindPresDataSource.Rows.Count; index++)
                {
                    if (_view.BindPresDataSource.Rows[index]["Item_Name_S"].ToString().Trim() == "小计：")
                    {
                        CalculateMoney(index);
                        break;
                    }
                }
                ShowItemMoneyStatus();
            }
        }

        private HIS.MZDoc_BLL.Public.SkinTestStatus CheckSkinTestDrug(DataRow row)
        {
            if (MessageBox.Show("【" + row["ITEMNAME"].ToString() + "】是需要皮试的药品，您需要开皮试医嘱吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return HIS.MZDoc_BLL.Public.SkinTestStatus.免试;
            }
            DataTable backTable = _view.BindPresDataSource.Copy();
            _view.BindPresDataSource = backTable.Clone();
            int currentIndex = _view.RowIndex;
            int rowNo = 0;
            bool isInsertRow = Convert.ToInt32(XcConvert.IsNull(backTable.Rows[_view.RowIndex]["PresHeadId"], "0")) > 0;
            int presNo = Convert.ToInt32(backTable.Rows[_view.RowIndex]["PresNo"]);

            #region 复制该条记录前面所有的行
            //如果是皮试药品在已保存处方中插入的新行 则在第一张新开处方前插入皮试项目处方
            //否则在当前处方前插入皮试项目处方
            while (rowNo < backTable.Rows.Count
                && (isInsertRow && Convert.ToInt32(backTable.Rows[rowNo]["PresHeadId"]) > 0
                || Convert.ToInt32(backTable.Rows[rowNo]["PresNo"]) < presNo))
            {
                _view.BindPresDataSource.Rows.Add(backTable.Rows[rowNo].ItemArray);
                rowNo++;
            }
            #endregion

            _view.RowIndex = rowNo - 1;
            #region 添加皮试项目
            string[] orderIds = HIS.MZDoc_BLL.OP_ReadBaseData.GetConfigValue("001").Split(',');
            foreach (string orderId in orderIds)
            {
                AddRow();
                DataRow[] rows = _dataSet.Tables["Item_Dictionary"].Select("ITEMID=" + orderId + " and DRUG_FLAG=0");
                if (rows != null && rows.Length > 0)
                {
                    SelectCardBindData(_view.ColumnIndex.ItemIdIndex, rows[0]);
                }
            }

            AddRow();
            ChangePres();
            CalculateMoney(_view.RowIndex - 1);
            int addRowNum = orderIds.Length + 1;
            #endregion
            _view.BindPresDataSource.Rows.RemoveAt(_view.BindPresDataSource.Rows.Count - 1);

            #region 复制该条记录后面所有的行
            //更新开始分组号                        
            if (_view.GroupStartRowIndex >= rowNo)
            {
                _view.GroupStartRowIndex += addRowNum;
            }
            for (int index = rowNo; index < backTable.Rows.Count; index++)
            {
                backTable.Rows[index]["PresNo"] = Convert.ToInt32(backTable.Rows[index]["PresNo"]) + 1;
                if (backTable.Rows[index]["TmpNo"].ToString() != "")
                {
                    backTable.Rows[index]["TmpNo"] = backTable.Rows[index]["PresNo"].ToString();
                }
                _view.BindPresDataSource.Rows.Add(backTable.Rows[index].ItemArray);
            }
            #endregion

            if (isInsertRow)
            {
                _view.RowIndex = currentIndex;
            }
            else
            {
                _view.RowIndex = currentIndex + addRowNum;
            }
            for (int i = 0; i < _view.BindPresDataSource.Rows.Count; i++)
            {
                SetCellColor(i, -1);
            }
            return HIS.MZDoc_BLL.Public.SkinTestStatus.需要皮试;
        }

        /// <summary>
        /// 是否打印费用清单
        /// </summary>
        /// <returns></returns>
        public bool IsPrintFeeList()
        {
            if (HIS.MZDoc_BLL.OP_ReadBaseData.GetConfigValue("010").Trim() == "")
            {
                return false;
            }
            return true;
        }
        #endregion

        #region 助手操作
        /// <summary>
        /// 写常用项记录
        /// </summary>
        /// <param name="itemId">常用项ID</param>
        /// <param name="type">常用项类型</param>
        public void WriteCommonItem(int itemId, int type)
        {
            if (_view.RowIndex < 0 || _view.RowIndex >= _view.BindPresDataSource.Rows.Count ||
                _view.RowIndex < _view.BindPresDataSource.Rows.Count && _view.BindPresDataSource.Rows[_view.RowIndex]["Item_Name"].ToString().Trim() != "")
            {
                AddRow();
            }
            DataRow[] rows = _dataSet.Tables["Item_Dictionary"].Select("ITEMID=" + itemId + " and DRUG_FLAG=" + type);
            if (rows != null && rows.Length > 0)
            {
                SelectCardBindData(_view.ColumnIndex.ItemIdIndex, rows[0]);
            }
            else
            {
                throw new Exception(type==1?"该药品已禁用或没有库存，不能使用！":"该项目已禁用！");
            }
        }

        /// <summary>
        /// 选择模板
        /// </summary>
        /// <param name="rows">已选行</param>
        public void SelectedMould(DataRow[] rows)
        {
            int removeindex = -1;
            int removegroupid = -1;
            if (rows == null || rows.Length <= 0)
            {
                return;
            }
            int curepresno = Convert.ToInt32(rows[0]["PresNo"]);
            for (int index = 0; index < rows.Length; index++)
            {
                this.AddRow();
                //遇到小计换方
                if (rows[index]["Item_Name"].ToString() == "小计：")
                {
                    continue;
                }
                //更换处方号换方
                if (Convert.ToInt32(rows[index]["PresNo"]) != curepresno)
                {
                    ChangePres();
                    CalculateMoney(_view.RowIndex - 1);
                }
                curepresno = Convert.ToInt32(rows[index]["PresNo"]);

                int itemId = Convert.ToInt32(rows[index]["Item_Id"]);
                bool isDrug = Convert.ToBoolean(rows[index]["IsDrug"]);
                DataRow[] row = _dataSet.Tables["Item_Dictionary"].Select("ITEMID=" + itemId + " and DRUG_FLAG=" + (isDrug ? 1 : 0));
                if (row != null && row.Length > 0)
                {
                    if (removegroupid < 0 || Convert.ToInt32(rows[index]["Group_Id"]) - removegroupid != index - removeindex)
                    {
                        removeindex = -1;
                        removegroupid = -1;
                        if (Convert.ToInt32(rows[index]["Item_Rate"]) != 1 && Convert.ToInt32(rows[index]["Item_Rate"]) != Convert.ToInt32(row[0]["PACKNUM"]))
                        {
                            MessageBox.Show("药品【" + rows[index]["Item_Name"].ToString() + "】的规格发生改变，请更新模板！", "提示");
                            continue;
                        }
                        // 换方判断
                        if (!CheckPresType(Convert.ToInt32(XcConvert.IsNull(rows[index]["Dept_Id"], "-1")), XcConvert.IsNull(rows[index]["StatItem_Code"], "")))
                        {
                            return;
                        }

                        if (Convert.ToBoolean(rows[index]["IsDrug"]) == true && Convert.ToBoolean(rows[index]["IsHerb"]) == false && Convert.ToInt32(rows[index]["Group_Id"]) < 2)// && Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex]["OrderNo"]) > 10)
                        {
                            //DataRow[] tempRows = _view.BindPresDataSource.Select("PresNo=" + _view.BindPresDataSource.Rows[_view.RowIndex]["PresNo"].ToString() + " and item_id>0 and Group_Id<2");
                            //if (tempRows.Length >= 5)
                            DataRow[] tempRows = _view.BindPresDataSource.Select("PresNo=" + _view.BindPresDataSource.Rows[_view.RowIndex]["PresNo"].ToString() + " and item_id>0");
                            if (tempRows.Length >= 10)
                                this.ChangePres();
                        }

                        string tmpNo = Convert.ToString(_view.BindPresDataSource.Rows[_view.RowIndex]["TmpNo"]);
                        int presNo = Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex]["PresNo"]);
                        int orderNo = Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex]["OrderNo"]);
                        _view.BindPresDataSource.Rows[_view.RowIndex].ItemArray = HIS.MZDoc_BLL.Public.Function.TransformRow(rows[index], _view.BindPresDataSource.Rows[_view.RowIndex]).ItemArray;
                        _view.BindPresDataSource.Rows[_view.RowIndex]["TmpNo"] = tmpNo;
                        _view.BindPresDataSource.Rows[_view.RowIndex]["PresNo"] = presNo;
                        _view.BindPresDataSource.Rows[_view.RowIndex]["OrderNo"] = orderNo;
                        _view.BindPresDataSource.Rows[_view.RowIndex]["Status"] = HIS.MZDoc_BLL.Public.PresStatus.新建状态;
                        _view.BindPresDataSource.Rows[_view.RowIndex]["Item_Price"] = Convert.ToDecimal(XcConvert.IsNull(row[0]["SELL_PRICE"], "0")) / Convert.ToInt32(XcConvert.IsNull(rows[index]["Item_Rate"], ""));
                        _view.BindPresDataSource.Rows[_view.RowIndex]["Item_Price_S"] = Convert.ToDecimal(XcConvert.IsNull(row[0]["SELL_PRICE"], "0")) / Convert.ToInt32(XcConvert.IsNull(rows[index]["Item_Rate"], ""));
                        _view.BindPresDataSource.Rows[_view.RowIndex]["Buy_Price"] = Convert.ToDecimal(XcConvert.IsNull(row[0]["BUY_PRICE"], "0"));
                        _view.BindPresDataSource.Rows[_view.RowIndex]["Sell_Price"] = Convert.ToDecimal(XcConvert.IsNull(row[0]["SELL_PRICE"], "0"));
                        if (Convert.ToInt32(row[0]["SKINTEST_FLAG"]) == 1)
                        {
                            int skinTest_Flag = CheckSkinTestDrug(row[0]).GetHashCode();
                            _view.BindPresDataSource.Rows[_view.RowIndex]["SkinTest_Flag"] = skinTest_Flag;
                        }
                        this.CalculateMoney(_view.RowIndex);
                        SetCellColor(_view.RowIndex, -1);
                        UniteValue(_view.RowIndex);
                    }
                }
                else
                {
                    if (isDrug)
                    {
                        MessageBox.Show("药品【" + rows[index]["Item_Name"].ToString() + "】库存不足！", "提示");
                    }
                    else
                    {
                        MessageBox.Show("项目【" + rows[index]["Item_Name"].ToString() + "】已禁用！", "提示");
                    }
                    removeindex = index;
                    removegroupid = Convert.ToInt32(rows[index]["Group_Id"]);
                }
            }
        }
        #endregion

        #region 工具栏操作
        /// <summary>
        /// 新增一行
        /// </summary>
        public new void AddRow()
        {
            base.PresHeadId = 0;
            base.AddRow();
        }

        /// <summary>
        /// 保存处方
        /// </summary>
        public void SavePrescription()
        {
            if (_view.BindPresDataSource == null || _view.BindPresDataSource.Rows.Count <= 0)
            {
                throw new Exception("没有需要保存的处方");
            }
            //去掉空白行
            int row = 0;
            while (row < _view.BindPresDataSource.Rows.Count)
            {
                if (_view.BindPresDataSource.Rows[row]["Item_Name"].ToString().Trim() == "")
                {
                    DeleteRow(row);
                }
                else
                {
                    row++;
                }
            }
            DataTable dt = _view.BindPresDataSource;
            List<HIS.MZDoc_BLL.Prescription> _presLists
                = (List<HIS.MZDoc_BLL.Prescription>)HIS.MZDoc_BLL.Public.Function.DataRowsToList<HIS.MZDoc_BLL.Prescription>(dt.Select("Item_Id>0", "presno,orderno"));
            if (this.CheckPres(_presLists))
            {
                //自动生成用法联动费用
                bool hasUsageFee = AutoProduceUsageFee(_presLists);

                if (_view.CurrentPatient.SavePrescription(_presLists))
                {
                    if (hasUsageFee)
                    {
                        MessageBox.Show("处方保存成功！\n已自动生成用法联动费用，请核对确认！", "提示");
                    }
                    else
                    {
                        MessageBox.Show("保存成功", "提示");
                    }
                    LoadPresList();
                }
            }
        }

        /// <summary>
        /// 自动生成用法联动费用
        /// </summary>
        /// <param name="_presLists">处方列表</param>
        /// <returns></returns>
        private bool AutoProduceUsageFee(List<HIS.MZDoc_BLL.Prescription> _presLists)
        {
            bool hasUsageFee = false;
            if (HIS.MZDoc_BLL.OP_ReadBaseData.GetConfigValue("008").Trim() == "1")
            {
                DataTable usageFeePresTable = _view.BindPresDataSource.Clone();
                //获得最大处方号
                int maxPresNo = Convert.ToInt32(_view.BindPresDataSource.Compute("max(PresNo)", "")) + 1;
                int maxOrderNO = 1;
                int lastGroupId = 1;
                foreach (HIS.MZDoc_BLL.Prescription prescription in _presLists)
                {
                    //只有新增的处方才生成用法费用
                    if (prescription.Status == HIS.MZDoc_BLL.Public.PresStatus.新建状态)
                    {
                        if (prescription.Group_Id == lastGroupId + 1)
                        {
                            lastGroupId++;
                            continue;
                        }
                        else
                        {
                            lastGroupId = 1;
                        }
                        //获取联动的收费项目
                        DataRow[] rowsUsageFee = _dataSet.Tables["Usage_Fee_Dictionary"].Select("use_name='" + prescription.Usage_Name.Trim() + "'");
                        if (rowsUsageFee != null && rowsUsageFee.Length > 0)
                        {
                            foreach (DataRow rowUsageFee in rowsUsageFee)
                            {
                                //获取收费项目对应的医嘱项目
                                DataRow[] rowsOrderItem = _dataSet.Tables["Item_Dictionary"].Select("Service_Item_Id=" + rowUsageFee["HsItem_Id"]);
                                if (rowsOrderItem != null && rowsOrderItem.Length > 0)
                                {
                                    //如果该项目已经被联动产生，则在已有记录上面累加数量，没有则产生一条新的处方记录
                                    DataRow[] rowsUsageFeePres = usageFeePresTable.Select("Item_Id=" + rowsOrderItem[0]["ITEMID"]);
                                    if (rowsUsageFeePres != null && rowsUsageFeePres.Length > 0)
                                    {
                                        rowsUsageFeePres[0]["Usage_Amount_S"] = Convert.ToInt32(rowsUsageFeePres[0]["Usage_Amount_S"])
                                            + prescription.Frequency_ExecNum / prescription.Frequency_CycleDay * prescription.Days * Convert.ToInt32(rowUsageFee["Num"]);
                                        rowsUsageFeePres[0]["Item_Amount_S"] = rowsUsageFeePres[0]["Usage_Amount_S"];
                                    }
                                    else
                                    {
                                        #region 赋值
                                        DataRow newNow = usageFeePresTable.NewRow();
                                        newNow["PresNo"] = maxPresNo;
                                        newNow["OrderNo"] = maxOrderNO;
                                        newNow["StatItem_Code"] = XcConvert.IsNull(rowsOrderItem[0]["STATITEM_CODE"], "");
                                        newNow["Item_Id"] = Convert.ToInt32(XcConvert.IsNull(rowsOrderItem[0]["ITEMID"], "-1"));
                                        newNow["Item_Id_S"] = XcConvert.IsNull(rowsOrderItem[0]["ITEMID"], "");
                                        newNow["Item_Name"] = XcConvert.IsNull(rowsOrderItem[0]["ITEMNAME"], "");
                                        newNow["Item_Name_S"] = XcConvert.IsNull(rowsOrderItem[0]["ITEMNAME"], "");

                                        newNow["Dept_Id"] = _view.currentDept.DeptID;
                                        newNow["Dept_Name"] = _view.currentDept.Name;

                                        newNow["Standard"] = XcConvert.IsNull(rowsOrderItem[0]["STANDARD"], "");
                                        newNow["Item_Price"] = Convert.ToDecimal(XcConvert.IsNull(rowsOrderItem[0]["SELL_PRICE"], "0"));
                                        newNow["Item_Price_S"] = Convert.ToDecimal(XcConvert.IsNull(rowsOrderItem[0]["SELL_PRICE"], "0"));
                                        newNow["Buy_Price"] = Convert.ToDecimal(XcConvert.IsNull(rowsOrderItem[0]["BUY_PRICE"], "0"));
                                        newNow["Sell_Price"] = Convert.ToDecimal(XcConvert.IsNull(rowsOrderItem[0]["SELL_PRICE"], "0"));
                                        newNow["RelationNum"] = Convert.ToInt32(XcConvert.IsNull(rowsOrderItem[0]["PACKNUM"], "1"));
                                        newNow["Unit"] = XcConvert.IsNull(rowsOrderItem[0]["PACKUNIT"], "");
                                        newNow["Service_Item_Id"] = Convert.ToInt32(XcConvert.IsNull(rowsOrderItem[0]["Service_Item_Id"], "-1"));
                                        newNow["Tc_Flag"] = Convert.ToInt32(XcConvert.IsNull(rowsOrderItem[0]["TC_FLAG"], "0"));
                                        newNow["IsDrug"] = XcConvert.IsNull(rowsOrderItem[0]["DRUG_FLAG"], "0") == "1";
                                        newNow["IsHerb"] = XcConvert.IsNull(rowsOrderItem[0]["STATITEM_CODE"], "") == "03";
                                        newNow["IsFloat"] = XcConvert.IsNull(rowsOrderItem[0]["FLOAT_FLAG"], "0") == "1";
                                        newNow["SkinTest_Flag"] = 0;

                                        //设置部分默认值
                                        newNow["Usage_Amount_S"] = prescription.Frequency_ExecNum / prescription.Frequency_CycleDay * prescription.Days * Convert.ToInt32(rowUsageFee["Num"]);
                                        newNow["Usage_Unit"] = XcConvert.IsNull(rowsOrderItem[0]["LEASTUNIT"], "");
                                        newNow["Usage_Rate"] = 1;
                                        newNow["Dosage_S"] = "1";
                                        newNow["Days_S"] = "1";
                                        newNow["Item_Amount_S"] = newNow["Usage_Amount_S"];
                                        newNow["Item_Unit"] = XcConvert.IsNull(rowsOrderItem[0]["UNPICKUNIT"], "");
                                        newNow["Item_Rate"] = Convert.ToInt32(XcConvert.IsNull(rowsOrderItem[0]["UNPICKNUM"], "1"));
                                        newNow["Status"] = HIS.MZDoc_BLL.Public.PresStatus.新建状态;
                                        usageFeePresTable.Rows.Add(newNow);
                                        #endregion
                                        hasUsageFee = true;
                                    }
                                    maxOrderNO++;
                                }
                            }
                        }
                    }
                }
                List<HIS.MZDoc_BLL.Prescription> _usageFeePresLists
               = (List<HIS.MZDoc_BLL.Prescription>)HIS.MZDoc_BLL.Public.Function.DataTableToList<HIS.MZDoc_BLL.Prescription>(usageFeePresTable);
                foreach (HIS.MZDoc_BLL.Prescription _usageFeePres in _usageFeePresLists)
                {
                    _presLists.Add(_usageFeePres);
                }
            }
            return hasUsageFee;
        }

        /// <summary>
        /// 刷新项目药品数据词典
        /// </summary>
        /// <returns></returns>
        public DataSet RefreshAllItems()
        {
            if (_dataSet == null)
            {
                _dataSet = new DataSet();
            }
            if (_dataSet.Tables.IndexOf("All_Item_Dictionary_All") >= 0)
            {
                _dataSet.Tables.Remove("All_Item_Dictionary_All");
            }
            DataTable tb = HIS.MZDoc_BLL.OP_ReadBaseData.GetAllBaseItemData();
            tb.TableName = "All_Item_Dictionary_All";
            _dataSet.Tables.Add(tb);

            FilterDeptDrug();
            return _dataSet;
        }

        /// <summary>
        /// 结束就诊
        /// </summary>
        public void EndCure()
        {
            if (_view.BindPresDataSource != null && _view.BindPresDataSource.Rows.Count > 0)
            {
                DataRow[] rows = _view.BindPresDataSource.Select(
                    "Item_Id>0 and (Status=" + HIS.MZDoc_BLL.Public.PresStatus.新建状态.GetHashCode() + " or Status=" + HIS.MZDoc_BLL.Public.PresStatus.修改状态.GetHashCode() + ")");
                if (rows != null && rows.Length > 0)
                {
                    throw new Exception("该病人还有未保存的处方，不能结束就诊，请先保存处方！");
                }
            }
            _view.CurrentPatient.EndCure();
        }
        #endregion

        #region 右键菜单操作
        /// <summary>
        /// 插入一行
        /// </summary>
        public new void InsertRow()
        {
            base.PresHeadId = Convert.ToInt32(XcConvert.IsNull(_view.BindPresDataSource.Rows[_view.RowIndex]["PresHeadId"], "0"));
            base.InsertRow();
        }

        /// <summary>
        /// 删除整张
        /// </summary>
        public void DeletePres()
        {
            int presHeadId = Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex]["PresHeadId"]);
            int presNo = Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex]["PresNo"]);

            if (presHeadId > 0)
            {
                switch ((HIS.MZDoc_BLL.Public.PresStatus)_view.CurrentPatient.DeletePres(presHeadId))
                {
                    case HIS.MZDoc_BLL.Public.PresStatus.收费状态:
                        throw new Exception("该张处方已经收费，无法删除，请刷新处方！");
                    case HIS.MZDoc_BLL.Public.PresStatus.退费状态:
                        throw new Exception("该张处方已退费，无法删除，请刷新处方！");
                    case HIS.MZDoc_BLL.Public.PresStatus.删除状态:
                        break;
                    default:
                        return;
                }
            }

            #region 重新组织数据源表
            DataTable tmpTable = _view.BindPresDataSource.Clone();

            // 复制剩余的处方记录
            for (int i = 0; i < _view.BindPresDataSource.Rows.Count; i++)
            {
                if (Convert.ToInt32(_view.BindPresDataSource.Rows[i]["PresNo"]) != presNo)
                {
                    //更新处方号
                    if (Convert.ToInt32(_view.BindPresDataSource.Rows[i]["PresNo"]) > presNo)
                    {
                        _view.BindPresDataSource.Rows[i]["PresNo"] = Convert.ToInt32(_view.BindPresDataSource.Rows[i]["PresNo"]) - 1;
                        if (_view.BindPresDataSource.Rows[i]["TmpNo"].ToString() != "")
                        {
                            _view.BindPresDataSource.Rows[i]["TmpNo"] = _view.BindPresDataSource.Rows[i]["PresNo"];
                        }
                    }
                    tmpTable.Rows.Add(_view.BindPresDataSource.Rows[i].ItemArray);
                }
            }

            //重新绘制处方颜色
            _view.BindPresDataSource = tmpTable;
            for (int i = 0; i < _view.BindPresDataSource.Rows.Count; i++)
            {
                SetCellColor(i, -1);
            }
            #endregion
        }

        private GridppReport report = null;  //报表打印对象
        private DataTable printTable = null;  //需要打印的数据表
        private string presType = "";  //需要打印的处方类型

        /// <summary>
        /// 处方打印
        /// </summary>
        /// <param name="Eof"></param>
        private void Report_FetchRecord(ref bool Eof)
        {
            GWI_DesReport.HisReport.FillRecordToReport(report, printTable);
        }

        #region 处方打印相关方法
        /// <summary>
        /// 打印处方前先刷新处方
        /// </summary>
        /// <returns></returns>
        private bool RefreshPresBeforePrint()
        {
            DataRow[] rows = _view.BindPresDataSource.Select("Item_Id>0 and Status=" + HIS.MZDoc_BLL.Public.PresStatus.新建状态.GetHashCode());
            int rowIndex = _view.RowIndex;
            if (rows != null && rows.Length > 0)
            {
                throw new Exception("存在未保存的处方，在打印处方之前请先保存这些处方！");
            }
            LoadPresList();
            _view.RowIndex = rowIndex;

            if (_view.BindPresDataSource == null || _view.BindPresDataSource.Rows.Count <= _view.RowIndex || _view.RowIndex < 0
                || ((HIS.MZDoc_BLL.Public.PresStatus)_view.BindPresDataSource.Rows[_view.RowIndex]["Status"]) != HIS.MZDoc_BLL.Public.PresStatus.保存状态
                && ((HIS.MZDoc_BLL.Public.PresStatus)_view.BindPresDataSource.Rows[_view.RowIndex]["Status"]) != HIS.MZDoc_BLL.Public.PresStatus.收费状态)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 按病人就诊时间划分处方类型
        /// </summary>
        /// <returns></returns>
        private string GetCurePresType()
        {
            string presType = "普通";
            string[] timestr = OP_ReadBaseData.GetConfigValue("004").Split(',');
            DateTime cureDate = _view.CurrentPatient.PatList.CureDate;
            for (int index = 0; index < timestr.Length; index++)
            {
                if (cureDate > DateTime.Parse(cureDate.ToShortDateString() + ' ' + timestr[index].Substring(0, timestr[index].IndexOf('-')))
                    && cureDate <= DateTime.Parse(cureDate.ToShortDateString() + ' ' + timestr[index].Substring(timestr[index].IndexOf('-') + 1)))
                {
                    presType = "急诊";
                }
            }
            return presType;
        }

        /// <summary>
        /// 按发票项目分类汇总费用
        /// </summary>
        /// <returns></returns>
        private void GetStatMzfpFeeTable(ref DataTable statMzfpTable, string condition)
        {
            //获取大项目分类代码表
            DataTable statItemTable = HIS.MZDoc_BLL.OP_ReadBaseData.GetStatItemTable();
            //定义大项目分类汇总费用临时表
            DataTable table = new DataTable();
            table.Columns.Add("StatItem_Code", Type.GetType("System.String"));
            table.Columns.Add("Mzfp_Code", Type.GetType("System.String"));
            table.Columns.Add("Item_Money", Type.GetType("System.Decimal"));

            int maxPresNo = Convert.ToInt32(XcConvert.IsNull(_view.BindPresDataSource.Compute("max(PresNo)", "Status=" + HIS.MZDoc_BLL.Public.PresStatus.保存状态.GetHashCode()), "-1"));
            for (int presNo = 1; presNo <= maxPresNo; presNo++)
            {
                DataRow[] rows = _view.BindPresDataSource.Select(condition + " and Item_Id>0 and PresNo=" + presNo);
                if (rows != null && rows.Length > 0)
                {
                    Hashtable feeTable = HIS.MZDoc_BLL.OP_Prescription.GetPresStatItemFeeTable(rows);
                    //先按大项目分类汇总费用
                    foreach (DictionaryEntry de in feeTable)
                    {
                        //如果存在该大项目代码的行，则累加费用，否则，新增一行
                        DataRow[] statItemRows = table.Select("StatItem_Code='" + de.Key + "'");
                        if (statItemRows == null || statItemRows.Length <= 0)
                        {
                            DataRow row = table.NewRow();
                            row["StatItem_Code"] = de.Key;
                            row["Mzfp_Code"] = "";
                            DataRow[] mzfpRows = statItemTable.Select("code='" + de.Key + "'");
                            if (mzfpRows != null && mzfpRows.Length > 0)
                            {
                                row["Mzfp_Code"] = mzfpRows[0]["MZFP_CODE"];
                            }
                            row["Item_Money"] = de.Value;
                            table.Rows.Add(row);
                        }
                        else
                        {
                            statItemRows[0]["Item_Money"] = Convert.ToDecimal(statItemRows[0]["Item_Money"]) + Convert.ToDecimal(de.Value);
                        }
                    }
                }
            }
            //在按大项目代码汇总的费用基础上进行四舍五入到一位小数，然后累加到相应的发票项目中
            for (int index = 0; index < table.Rows.Count; index++)
            {
                DataRow[] statMzfpRows = statMzfpTable.Select("Code='" + table.Rows[index]["Mzfp_Code"].ToString() + "'");
                if (statMzfpRows != null && statMzfpRows.Length > 0)
                {
                    statMzfpRows[0]["Item_Money"] = Convert.ToDecimal(statMzfpRows[0]["Item_Money"]) + Convert.ToDecimal(table.Rows[index]["Item_Money"]);
                }
            }
        }

        /// <summary>
        /// 按发票项目分类汇总非药品未收费处方费用
        /// </summary>
        /// <returns></returns>
        private DataTable GetStatMzfpUnDrugFeeTable()
        {
            //获取发票项目分类代码表
            DataTable statMzfpTable = HIS.MZDoc_BLL.OP_ReadBaseData.GetStatMzfpTable();
            //初始化费用为0
            statMzfpTable.Columns.Add("Item_Money", Type.GetType("System.Decimal"));
            for (int index = 0; index < statMzfpTable.Rows.Count; index++)
            {
                statMzfpTable.Rows[index]["Item_Money"] = 0;
            }
            //如果是非药品处方，或是最后一张药品处方（参数006控制），则打印出非药品非医技类处方的费用汇总
            int maxDrugPresNo = Convert.ToInt32(XcConvert.IsNull(_view.BindPresDataSource.Compute("max(PresNo)", "IsDrug=" + true + " and Status=" + HIS.MZDoc_BLL.Public.PresStatus.保存状态.GetHashCode()), "-1"));
            if (maxDrugPresNo <= 0 || Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex]["PresNo"]) == maxDrugPresNo)
            {
                GetStatMzfpFeeTable(ref statMzfpTable, "IsDrug=" + false + " and Status=" + HIS.MZDoc_BLL.Public.PresStatus.保存状态.GetHashCode());
            }
            return statMzfpTable;
        }

        /// <summary>
        /// 按发票项目分类汇总所有未收费处方费用
        /// </summary>
        /// <returns></returns>
        private DataTable GetStatMzfpAllPresFeeTable()
        {
            //获取发票项目分类代码表
            DataTable statMzfpTable = HIS.MZDoc_BLL.OP_ReadBaseData.GetStatMzfpTable();
            //初始化费用为0
            statMzfpTable.Columns.Add("Item_Money", Type.GetType("System.Decimal"));
            for (int index = 0; index < statMzfpTable.Rows.Count; index++)
            {
                statMzfpTable.Rows[index]["Item_Money"] = 0;
            }
            GetStatMzfpFeeTable(ref statMzfpTable, "Status=" + HIS.MZDoc_BLL.Public.PresStatus.保存状态.GetHashCode());
            return statMzfpTable;
        }

        /// <summary>
        /// 找出处方中的非药品非医技项目并且未收费的处方明细
        /// </summary>
        /// <returns></returns>
        private DataTable GetUnDrugPres()
        {
            DataTable unDrugPres = _view.BindPresDataSource.Clone();
            int maxDrugPresNo = Convert.ToInt32(XcConvert.IsNull(_view.BindPresDataSource.Compute("max(PresNo)", "IsDrug=" + true + " and Status=" + HIS.MZDoc_BLL.Public.PresStatus.保存状态.GetHashCode()), "-1"));

            if (!Convert.ToBoolean(_view.BindPresDataSource.Rows[_view.RowIndex]["IsDrug"])
                || Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex]["PresNo"]) == maxDrugPresNo)
            {
                #region 找出处方中的非药品非医技项目并且未收费的处方明细
                DataRow[] rows = _view.BindPresDataSource.Select("IsDrug=" + false + " and Status=" + HIS.MZDoc_BLL.Public.PresStatus.保存状态.GetHashCode() + " and Item_Id>0", "presNo,orderNo");
                bool isExcludeMedical = HIS.MZDoc_BLL.OP_ReadBaseData.GetConfigValue("006").Trim() == "1";
                for (int index = 0; index < rows.Length; index++)
                {
                    //过滤掉医技项目
                    DataRow[] rowOrder = _dataSet.Tables["Item_Dictionary"].Select(
                "ITEMID=" + rows[index]["Item_Id"] + " and STATITEM_CODE='" + rows[index]["StatItem_Code"] + "' and TC_FLAG=" + rows[index]["Tc_Flag"]);
                    if (rowOrder != null && rowOrder.Length > 0 && (XcConvert.IsNull(rowOrder[0]["Order_Type"], "0").Trim() != "5" || isExcludeMedical))
                    {
                        unDrugPres.Rows.Add(rows[index].ItemArray);
                        unDrugPres.Rows[unDrugPres.Rows.Count - 1]["Item_Name"] = rowOrder[0]["printname"];
                    }
                }
                #endregion
            }
            return unDrugPres;
        }

        /// <summary>
        /// 准备处方打印的数据，并返回处方金额
        /// </summary>
        /// <returns></returns>
        private decimal PreparePresPrintData()
        {
            if (Convert.ToBoolean(_view.BindPresDataSource.Rows[_view.RowIndex]["IsDrug"]) && Convert.ToBoolean(_view.BindPresDataSource.Rows[_view.RowIndex]["IsHerb"]))
            {
                //处理中药处方
                return PrepareHerbDrugPrintData();
            }
            else if (Convert.ToBoolean(_view.BindPresDataSource.Rows[_view.RowIndex]["IsDrug"]) && !Convert.ToBoolean(_view.BindPresDataSource.Rows[_view.RowIndex]["IsHerb"]))
            {
                //处理西成药处方
                return PrepareUnHerbDrugPrintData();
            }
            else
            {
                //处理非药品处方
                return PrepareUnDrugPrintData();
            }
        }

        /// <summary>
        /// 准备非药品处方的打印数据
        /// </summary>
        /// <param name="drugFee"></param>
        /// <param name="printTable"></param>
        /// <returns></returns>
        private decimal PrepareUnDrugPrintData()
        {
            report.LoadFromFile(Constant.ApplicationDirectory + "\\report\\门诊医生非药品处方.grf");
            printTable = _view.BindPresDataSource.Clone();

            //找出处方中的非药品非医技项目并且未收费的处方明细
            DataRow[] rows = _view.BindPresDataSource.Select("IsDrug=" + false + " and Status=" + HIS.MZDoc_BLL.Public.PresStatus.保存状态.GetHashCode() + " and Item_Id>0", "presNo,orderNo");
            if (rows == null || rows.Length <= 0)
            {
                throw new Exception("没有需要打印的处方！");
            }
            bool isExcludeMedical = HIS.MZDoc_BLL.OP_ReadBaseData.GetConfigValue("006").Trim() == "1";
            for (int index = 0; index < rows.Length; index++)
            {
                //过滤掉医技项目
                DataRow[] rowOrder = _dataSet.Tables["Item_Dictionary"].Select(
            "ITEMID=" + rows[index]["Item_Id"] + " and STATITEM_CODE='" + rows[index]["StatItem_Code"] + "' and TC_FLAG=" + rows[index]["Tc_Flag"]);
                if (rowOrder != null && rowOrder.Length > 0 && (XcConvert.IsNull(rowOrder[0]["Order_Type"], "0").Trim() != "5" || isExcludeMedical))
                {
                    printTable.Rows.Add(rows[index].ItemArray);
                    printTable.Rows[printTable.Rows.Count - 1]["Item_Name"] = rowOrder[0]["printname"];
                }
            }
            return 0;
        }

        /// <summary>
        /// 准备西成药处方的打印数据，并返回处方金额
        /// </summary>
        /// <returns></returns>
        private decimal PrepareUnHerbDrugPrintData()
        {
            DataRow[] rows = _view.BindPresDataSource.Select("PresNo=" + _view.BindPresDataSource.Rows[_view.RowIndex]["PresNo"] + " and Item_Id>0", "orderNo");
            report.LoadFromFile(Constant.ApplicationDirectory + "\\report\\门诊医生西成药处方.grf");

            printTable = _view.BindPresDataSource.Clone();
            for (int index = 0; index < rows.Length; index++)
            {
                string drugName = "";
                //获取药品拉丁名称
                DataRow[] rowDrug = _dataSet.Tables["Item_Dictionary"].Select("ITEMID=" + rows[index]["Item_Id"] + " and Drug_Flag=" + Convert.ToInt32(rows[index]["IsDrug"]));
                if (rowDrug != null && rowDrug.Length > 0)
                {
                    drugName = rowDrug[0]["printname"].ToString().Trim();
                }
                else
                {
                    drugName = rows[index]["Item_Name"].ToString();
                }
                //添加自备标志
                drugName = drugName + ((rows[index]["SelfDrug_Flag"].ToString().Trim() == "0") ? "" : ("【自备】"));

                //判断精二类处方
                DataRow[] drugrows = _dataSet.Tables["Item_Dictionary"].Select("ITEMID=" + rows[index]["Item_Id"].ToString() + " and DRUG_FLAG=1");
                if (drugrows != null && drugrows.Length > 0 && Convert.ToInt32(drugrows[0]["lunacy_flag"]) == 1)
                {
                    presType = "精二";
                }
                printTable.Rows.Add(rows[index].ItemArray);
                printTable.Rows[index]["Item_Name"] = drugName;
            }

            //加入组线
            printTable.Columns.Add("GroupLineUp", Type.GetType("System.String"));
            printTable.Columns.Add("GroupLineDown", Type.GetType("System.String"));
            printTable.Columns.Add("SkinTestStatus", Type.GetType("System.String"));
            for (int index = 0; index < printTable.Rows.Count; index++)
            {
                int skinTestFlag = Convert.ToInt32(printTable.Rows[index]["SkinTest_Flag"]);
                if (skinTestFlag == 4)
                {
                    printTable.Rows[index]["SkinTestStatus"] = "[免试]";
                }
                else if (skinTestFlag == 0)
                {
                    printTable.Rows[index]["SkinTestStatus"] = "";
                }
                else
                {
                    printTable.Rows[index]["SkinTestStatus"] = "[皮试](  )";
                }

                if (Convert.ToInt32(printTable.Rows[index]["Group_Id"]) == 0)
                {
                    printTable.Rows[index]["GroupLineUp"] = "";
                    printTable.Rows[index]["GroupLineDown"] = "";
                }
                else if (Convert.ToInt32(printTable.Rows[index]["Group_Id"]) == 1)
                {
                    printTable.Rows[index]["GroupLineUp"] = "┍";
                    printTable.Rows[index]["GroupLineDown"] = "│";
                }
                else if (index < printTable.Rows.Count - 1 && Convert.ToInt32(printTable.Rows[index]["Group_Id"]) > Convert.ToInt32(printTable.Rows[index + 1]["Group_Id"]) || index == printTable.Rows.Count - 1)
                {
                    printTable.Rows[index]["GroupLineUp"] = "│";
                    printTable.Rows[index]["GroupLineDown"] = "┕";
                }
                else
                {
                    printTable.Rows[index]["GroupLineUp"] = "│";
                    printTable.Rows[index]["GroupLineDown"] = "│";
                }
            }
            return CalculateMoney(rows);
        }

        /// <summary>
        /// 准备中药处方的打印数据，并返回处方金额
        /// </summary>
        /// <returns></returns>
        private decimal PrepareHerbDrugPrintData()
        {
            DataRow[] rows = _view.BindPresDataSource.Select("PresNo=" + _view.BindPresDataSource.Rows[_view.RowIndex]["PresNo"] + " and Item_Id>0", "orderNo");
            report.LoadFromFile(Constant.ApplicationDirectory + "\\report\\门诊医生中药处方.grf");
            printTable = new DataTable();
            printTable.Columns.Add("Item_Name_Left", Type.GetType("System.String"));
            printTable.Columns.Add("Usage_Amount_Left", Type.GetType("System.String"));
            printTable.Columns.Add("Item_Name_Right", Type.GetType("System.String"));
            printTable.Columns.Add("Usage_Amount_Right", Type.GetType("System.String"));
            DataRow row = printTable.NewRow();
            for (int index = 0; index < rows.Length; index++)
            {
                string drugName = "";
                //获取药品拉丁名称
                DataRow[] rowDrug = _dataSet.Tables["Item_Dictionary"].Select("ITEMID=" + rows[index]["Item_Id"] + " and Drug_Flag=" + Convert.ToInt32(rows[index]["IsDrug"]));
                if (rowDrug != null && rowDrug.Length > 0)
                {
                    drugName = rowDrug[0]["printname"].ToString().Trim();
                }
                else
                {
                    drugName = rows[index]["Item_Name"].ToString();
                }
                //添加脚注
                drugName = drugName + ((rows[index]["FootNote"].ToString().Trim() == "") ? "" : ("【" + rows[index]["FootNote"].ToString().Trim() + "】"));
                //添加自备标志
                drugName = drugName + ((rows[index]["SelfDrug_Flag"].ToString().Trim() == "0") ? "" : ("【自备】"));

                //判断精二类处方
                DataRow[] drugrows = _dataSet.Tables["Item_Dictionary"].Select("ITEMID=" + rows[index]["Item_Id"].ToString() + " and DRUG_FLAG=1");
                if (drugrows != null && drugrows.Length > 0 && Convert.ToInt32(drugrows[0]["lunacy_flag"]) == 1)
                {
                    presType = "精二";
                }
                if (index % 2 == 0)
                {
                    row["Item_Name_Left"] = drugName;
                    row["Usage_Amount_Left"] = Convert.ToDecimal(rows[index]["Usage_Amount"]).ToString("0.00") + Convert.ToString(rows[index]["Usage_Unit"]);
                    printTable.Rows.Add(row.ItemArray);
                }
                else
                {
                    printTable.Rows[printTable.Rows.Count - 1]["Item_Name_Right"] = drugName;
                    printTable.Rows[printTable.Rows.Count - 1]["Usage_Amount_Right"] = Convert.ToDecimal(rows[index]["Usage_Amount"]).ToString("0.00") + Convert.ToString(rows[index]["Usage_Unit"]);
                }
            }
            return CalculateMoney(rows);
        }
        #endregion

        /// <summary>
        /// 处方打印
        /// </summary>
        public void PresPrint()
        {
            if (!RefreshPresBeforePrint())
            {
                return;
            }
            report = new GridppReport();
            presType = GetCurePresType();                 //按病人就诊时间划分处方类型
            decimal drugFee = PreparePresPrintData();              //计算当前药品处方金额，并准备处方打印的数据，如果打印的是非药品处方，处方金额为0

            DataRow[] rows = _view.BindPresDataSource.Select("PresNo=" + _view.BindPresDataSource.Rows[_view.RowIndex]["PresNo"] + " and Item_Id>0", "orderNo");
            //添加常规参数
            HIS.MZDoc_BLL.Prescription prescription = (HIS.MZDoc_BLL.Prescription)HIS.MZDoc_BLL.Public.Function.DataRowToObject<HIS.MZDoc_BLL.Prescription>(rows[0]);
            report.ParameterByName("医院名称").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
            report.ParameterByName("处方类型").AsString = presType;
            report.ParameterByName("开方科室").AsString = _view.currentDept.Name;
            report.ParameterByName("开方医生").AsString = _view.currentUser.Name;
            report.ParameterByName("门诊号").AsString = _view.CurrentPatient.PatList.VisitNo;
            report.ParameterByName("开方时间").AsString = prescription.Pres_Date.ToString("yyyy年MM月dd日") + " " + prescription.Pres_Date.ToString("HH:mm:ss");
            report.ParameterByName("病人姓名").AsString = _view.CurrentPatient.PatList.PatName;
            report.ParameterByName("病人年龄").AsString = _view.CurrentPatient.PatList.Age.ToString() + _view.CurrentPatient.PatList.HpGrade;
            report.ParameterByName("病人性别").AsString = _view.CurrentPatient.PatList.PatSex;
            report.ParameterByName("病人费别").AsString = _view.CurrentPatient.FeeTypeName;
            report.ParameterByName("诊断").AsString = _view.CurrentPatient.PatList.DiseaseName;
            report.ParameterByName("电话").AsString = _view.CurrentPatient.PatientInfo.PatTEL;
            report.ParameterByName("联系地址").AsString = _view.CurrentPatient.PatientInfo.PatAddress;
            report.ParameterByName("处方号").AsString = Convert.ToString(rows[0]["PresHeadId"]).PadLeft(7, '0');
            //中药处方需要显示用法和剂数
            if (Convert.ToBoolean(_view.BindPresDataSource.Rows[_view.RowIndex]["IsHerb"]))
            {
                report.ParameterByName("用法").AsString = Convert.ToString(rows[0]["Usage_Name"]);
                report.ParameterByName("剂数").AsString = Convert.ToString(rows[0]["Dosage_S"]) + "剂";
            }

            //设置处方金额金额
            report.ParameterByName("处方金额").AsString = drugFee.ToString("0.00") + "元";

            #region 按发票项目分类添加打印参数
            //按发票项目分类汇总费用
            DataTable statMzfpTable = GetStatMzfpUnDrugFeeTable();
            //添加合计行
            DataRow statMzfpRow = statMzfpTable.NewRow();
            statMzfpRow["Item_Name"] = "合计";
            statMzfpRow["Item_Money"] = Convert.ToDecimal(XcConvert.IsNull(statMzfpTable.Compute("sum(Item_Money)", ""), "0")) + drugFee;
            statMzfpTable.Rows.Add(statMzfpRow);
            //按发票项目添加打印参数
            foreach (DataRow row in statMzfpTable.Rows)
            {
                try
                {
                    report.ParameterByName(row["Item_Name"].ToString()).AsString = Convert.ToDecimal(row["Item_Money"]).ToString("0.00") + "元";
                }
                catch { }
            }
            #endregion

            report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(Report_FetchRecord);
            report.PrintPreview(false);
        }

        /// <summary>
        /// 处方费用打印
        /// </summary>
        public void PresFeePrint()
        {
            report = new GridppReport();
            if (!RefreshPresBeforePrint())
            {
                return;
            }

            //找出处方中的未收费的处方明细
            DataRow[] rows = _view.BindPresDataSource.Select("Status=" + HIS.MZDoc_BLL.Public.PresStatus.保存状态.GetHashCode() + " and Item_Id>0", "presNo,orderNo");
            if (rows == null || rows.Length <= 0)
            {
                throw new Exception("没有需要打印的处方！");
            }
            printTable = _view.BindPresDataSource.Clone();
            string printOrderType = HIS.MZDoc_BLL.OP_ReadBaseData.GetConfigValue("010").Trim();
            for (int index = 0; index < rows.Length; index++)
            {
                DataRow[] rowOrder = _dataSet.Tables["Item_Dictionary"].Select(
                "ITEMID=" + rows[index]["Item_Id"] + " and STATITEM_CODE='" + rows[index]["StatItem_Code"] + "' and TC_FLAG=" + rows[index]["Tc_Flag"]);
                if (rowOrder != null && rowOrder.Length > 0 && printOrderType.IndexOf(rowOrder[0]["Order_Type"].ToString().Trim()) > -1)
                {
                    printTable.Rows.Add(rows[index].ItemArray);
                }
            }

            report.LoadFromFile(Constant.ApplicationDirectory + "\\report\\门诊医生处方费用明细.grf");

            //添加常规参数
            report.ParameterByName("医院名称").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
            report.ParameterByName("开方科室").AsString = _view.currentDept.Name;
            report.ParameterByName("开方医生").AsString = _view.currentUser.Name;
            report.ParameterByName("门诊号").AsString = _view.CurrentPatient.PatList.VisitNo;
            report.ParameterByName("病人姓名").AsString = _view.CurrentPatient.PatList.PatName;
            report.ParameterByName("病人年龄").AsString = _view.CurrentPatient.PatList.Age.ToString() + _view.CurrentPatient.PatList.HpGrade;
            report.ParameterByName("病人性别").AsString = _view.CurrentPatient.PatList.PatSex;
            report.ParameterByName("病人费别").AsString = _view.CurrentPatient.FeeTypeName;
            report.ParameterByName("诊断").AsString = _view.CurrentPatient.PatList.DiseaseName;

            #region 按发票项目分类汇总费用
            DataTable statMzfpTable = GetStatMzfpAllPresFeeTable();

            //添加合计行
            DataRow statMzfpRow = statMzfpTable.NewRow();
            statMzfpRow["Item_Name"] = "合计";
            statMzfpRow["Item_Money"] = Convert.ToDecimal(XcConvert.IsNull(statMzfpTable.Compute("sum(Item_Money)", ""), "0"));
            statMzfpTable.Rows.Add(statMzfpRow);
            //按发票项目添加打印参数
            for (int index = 0; index < statMzfpTable.Rows.Count; index++)
            {
                try
                {
                    report.ParameterByName(statMzfpTable.Rows[index]["Item_Name"].ToString()).AsString = Convert.ToDecimal(statMzfpTable.Rows[index]["Item_Money"]).ToString("0.00") + "元";
                }
                catch
                {
                    continue;
                }
            }
            #endregion

            report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(Report_FetchRecord);
            report.PrintPreview(false);
        }

        /// <summary>
        /// 复制处方
        /// </summary>
        public void PresCopy()
        {
            if (_view.RowIndex < 0)
            {
                return;
            }
            _presCopy = _view.BindPresDataSource.Clone();
            DataRow[] rows = _view.BindPresDataSource.Select("PresNo=" + _view.BindPresDataSource.Rows[_view.RowIndex]["PresNo"].ToString());
            if (rows != null && rows.Length > 0)
            {
                for (int index = 0; index < rows.Length; index++)
                {
                    _presCopy.Rows.Add(rows[index].ItemArray);
                    _presCopy.Rows[index]["PresHeadId"] = 0;
                }
            }
        }

        /// <summary>
        /// 粘贴处方
        /// </summary>
        public void PresPaste()
        {
            if (_presCopy != null && _presCopy.Rows.Count > 0)
            {
                for (int index = 0; index < _presCopy.Rows.Count; index++)
                {
                    this.AddRow();
                    if (_presCopy.Rows[index]["Item_Name"].ToString() == "小计：")
                    {
                        return;
                    }

                    int itemId = Convert.ToInt32(_presCopy.Rows[index]["Item_Id"]);
                    bool isDrug = Convert.ToBoolean(_presCopy.Rows[index]["IsDrug"]);
                    DataRow[] row = _dataSet.Tables["Item_Dictionary"].Select("ITEMID=" + itemId + " and DRUG_FLAG=" + (isDrug ? 1 : 0));
                    if (row != null && row.Length > 0)
                    {
                        if (Convert.ToInt32(_presCopy.Rows[index]["Item_Rate"]) != 1 && Convert.ToInt32(_presCopy.Rows[index]["Item_Rate"]) != Convert.ToInt32(row[0]["PACKNUM"]))
                        {
                            MessageBox.Show("药品【" + _presCopy.Rows[index]["Item_Name"].ToString() + "】的规格发生改变，无法复制！", "提示");
                            continue;
                        }
                        if (!CheckPresType(Convert.ToInt32(XcConvert.IsNull(_presCopy.Rows[index]["Dept_Id"], "-1")), XcConvert.IsNull(_presCopy.Rows[index]["StatItem_Code"], "")))
                        {
                            return;
                        }
                        if (Convert.ToBoolean(_presCopy.Rows[index]["IsDrug"]) == true && Convert.ToBoolean(_presCopy.Rows[index]["IsHerb"]) == false && Convert.ToInt32(_presCopy.Rows[index]["Group_Id"]) < 2)// && Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex]["OrderNo"]) > 10)
                        {
                            //DataRow[] tempRows = _view.BindPresDataSource.Select("PresNo=" + _view.BindPresDataSource.Rows[_view.RowIndex]["PresNo"].ToString() + " and item_id>0 and Group_Id<2");
                            //if (tempRows.Length >= 5)
                            DataRow[] tempRows = _view.BindPresDataSource.Select("PresNo=" + _view.BindPresDataSource.Rows[_view.RowIndex]["PresNo"].ToString() + " and item_id>0");
                            if (tempRows.Length >= 10)
                                this.ChangePres();
                        }
                        string tmpNo = Convert.ToString(_view.BindPresDataSource.Rows[_view.RowIndex]["TmpNo"]);
                        int presNo = Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex]["PresNo"]);
                        int orderNo = Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex]["OrderNo"]);
                        _view.BindPresDataSource.Rows[_view.RowIndex].ItemArray = HIS.MZDoc_BLL.Public.Function.TransformRow(_presCopy.Rows[index], _view.BindPresDataSource.Rows[_view.RowIndex]).ItemArray;
                        _view.BindPresDataSource.Rows[_view.RowIndex]["TmpNo"] = tmpNo;
                        _view.BindPresDataSource.Rows[_view.RowIndex]["PresNo"] = presNo;
                        _view.BindPresDataSource.Rows[_view.RowIndex]["OrderNo"] = orderNo;
                        _view.BindPresDataSource.Rows[_view.RowIndex]["Status"] = HIS.MZDoc_BLL.Public.PresStatus.新建状态;
                        _view.BindPresDataSource.Rows[_view.RowIndex]["Item_Price"] = Convert.ToDecimal(XcConvert.IsNull(row[0]["SELL_PRICE"], "0")) / Convert.ToInt32(XcConvert.IsNull(_presCopy.Rows[index]["Item_Rate"], ""));
                        _view.BindPresDataSource.Rows[_view.RowIndex]["Item_Price_S"] = Convert.ToDecimal(XcConvert.IsNull(row[0]["SELL_PRICE"], "0")) / Convert.ToInt32(XcConvert.IsNull(_presCopy.Rows[index]["Item_Rate"], ""));
                        _view.BindPresDataSource.Rows[_view.RowIndex]["Buy_Price"] = Convert.ToDecimal(XcConvert.IsNull(row[0]["BUY_PRICE"], "0"));
                        _view.BindPresDataSource.Rows[_view.RowIndex]["Sell_Price"] = Convert.ToDecimal(XcConvert.IsNull(row[0]["SELL_PRICE"], "0"));
                        if (Convert.ToInt32(row[0]["SKINTEST_FLAG"]) == 1)
                        {
                            int skinTest_Flag = CheckSkinTestDrug(row[0]).GetHashCode();
                            _view.BindPresDataSource.Rows[_view.RowIndex]["SkinTest_Flag"] = skinTest_Flag;
                        }
                        this.CalculateMoney(_view.RowIndex);
                        SetCellColor(_view.RowIndex, -1);
                        UniteValue(_view.RowIndex);
                    }
                }
            }
        }

        /// <summary>
        /// 标志自备药
        /// </summary>
        public void SetSelfDrug()
        {
            if ((HIS.MZDoc_BLL.Public.PresStatus)_view.BindPresDataSource.Rows[_view.RowIndex]["Status"] == HIS.MZDoc_BLL.Public.PresStatus.保存状态)
            {
                _view.BindPresDataSource.Rows[_view.RowIndex]["Status"] = HIS.MZDoc_BLL.Public.PresStatus.修改状态;
            }
            if ((HIS.MZDoc_BLL.Public.PresStatus)_view.BindPresDataSource.Rows[_view.RowIndex]["Status"] == HIS.MZDoc_BLL.Public.PresStatus.收费状态 ||
                (HIS.MZDoc_BLL.Public.PresStatus)_view.BindPresDataSource.Rows[_view.RowIndex]["Status"] == HIS.MZDoc_BLL.Public.PresStatus.退费状态)
            {
                throw new Exception("已收费药品不能作为自备药品！");
            }
            _view.BindPresDataSource.Rows[_view.RowIndex]["SelfDrug_Flag"] = 1;
            _view.BindPresDataSource.Rows[_view.RowIndex]["Item_Name_S"]
                = _view.BindPresDataSource.Rows[_view.RowIndex]["Item_Name_S"].ToString() + "【自备】";
        }
        #endregion

        #region 网格操作
        /// <summary>
        /// 检查处方
        /// </summary>
        /// <param name="presList">处方明细列表</param>
        /// <returns></returns>
        private new bool CheckPres(IList presList)
        {
            if (XcConvert.IsNull(_view.CurrentPatient.PatList.DiseaseName, "").Trim() == "")
            {
                throw new Exception("您还没有为病人下诊断，不允许保存处方！");
            }
            int lastPresNo = 0;
            foreach (HIS.MZDoc_BLL.Prescription prescription in presList)
            {
                if ((prescription.Status == HIS.MZDoc_BLL.Public.PresStatus.新建状态
                || prescription.Status == HIS.MZDoc_BLL.Public.PresStatus.修改状态))
                {
                    if (prescription.PresHeadId > 0 && lastPresNo != prescription.PresHeadId)
                    {
                        lastPresNo = prescription.PresHeadId;
                        switch ((HIS.MZDoc_BLL.Public.PresStatus)prescription.CurrentPresStatus())
                        {
                            case HIS.MZDoc_BLL.Public.PresStatus.收费状态:
                                MessageBox.Show("第" + prescription.PresNo + "张处方已经收费，您所做的修改将无法保存！", "警告");
                                continue;
                            case HIS.MZDoc_BLL.Public.PresStatus.退费状态:
                                MessageBox.Show("第" + prescription.PresNo + "张处方已退费，您所做的修改将无法保存！", "警告");
                                continue;
                            case HIS.MZDoc_BLL.Public.PresStatus.删除状态:
                                MessageBox.Show("第" + prescription.PresNo + "张处方已经被删除，您所做的修改将无法保存！", "警告");
                                continue;
                        }
                    }
                    else
                    {
                        lastPresNo = prescription.PresHeadId;
                    }
                    if (!prescription.CheckDrugStoreNum())
                    {
                        if (MessageBox.Show("药品【" + prescription.Item_Name + "】库存不足！是否继续保存？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            return false;
                        }
                    }
                }
            }
            base.CheckPres(presList);
            return true;
        }

        /// <summary>
        /// 设置网格列只读状态
        /// </summary>
        /// <param name="rowid"></param>
        public new void SettingReadOnly(int rowid)
        {
            base.SettingReadOnly(rowid);
            _view.MenuEnabled = ((HIS.MZDoc_BLL.Public.PresStatus)(_view.BindPresDataSource.Rows[rowid]["Status"]) == HIS.MZDoc_BLL.Public.PresStatus.新建状态
                || (HIS.MZDoc_BLL.Public.PresStatus)(_view.BindPresDataSource.Rows[rowid]["Status"]) == HIS.MZDoc_BLL.Public.PresStatus.修改状态
                || (HIS.MZDoc_BLL.Public.PresStatus)(_view.BindPresDataSource.Rows[rowid]["Status"]) == HIS.MZDoc_BLL.Public.PresStatus.保存状态);
        }

        /// <summary>
        /// 写行记录
        /// </summary>
        /// <param name="row"></param>
        private void WriteRowValue(DataRow row)
        {
            #region 对于项目，当上一个行的执行科室是它的可执行科室，则沿用上一行的执行科室
            if (XcConvert.IsNull(row["DRUG_FLAG"], "0").Trim() == "0" && _view.RowIndex > 0
                && Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex - 1]["Item_Id"]) > 0
                && XcConvert.IsNull(_view.BindPresDataSource.Rows[_view.RowIndex - 1]["IsDrug"], "false").ToLower() == "false"
                && Convert.ToInt32(XcConvert.IsNull(row["EXECDEPTCODE"], _view.currentDept.DeptID.ToString())) != Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex - 1]["Dept_Id"]))
            {
                RefreshExeDeptDic(row);
                DataRow[] exeDeptRow = _dataSet.Tables["ExeDept_Dictionary"].Select("Dept_Id=" + _view.BindPresDataSource.Rows[_view.RowIndex - 1]["Dept_Id"].ToString());
                if (exeDeptRow != null && exeDeptRow.Length > 0)
                {
                    row["EXECDEPTCODE"] = _view.BindPresDataSource.Rows[_view.RowIndex - 1]["Dept_Id"];
                    row["EXECDEPTNAME"] = _view.BindPresDataSource.Rows[_view.RowIndex - 1]["Dept_Name"];
                }
            }
            #endregion

            if (!CheckPresType(Convert.ToInt32(XcConvert.IsNull(row["EXECDEPTCODE"], "-1")), XcConvert.IsNull(row["STATITEM_CODE"], "")))
            {
                _view.BindPresDataSource.Rows[_view.RowIndex]["Item_Id_S"] = _view.BindPresDataSource.Rows[_view.RowIndex]["Item_Id_S"];
                return;
            }
            if (XcConvert.IsNull(row["DRUG_FLAG"], "0").Trim() == "1" && XcConvert.IsNull(row["STATITEM_CODE"], "00").Trim() != "03")// && Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex]["OrderNo"]) > 10)
            {
                //DataRow[] rows = _view.BindPresDataSource.Select("PresNo=" + _view.BindPresDataSource.Rows[_view.RowIndex]["PresNo"].ToString() + " and item_id>0 and Group_Id<2");
                //if (rows.Length>=5)
                DataRow[] rows = _view.BindPresDataSource.Select("PresNo=" + _view.BindPresDataSource.Rows[_view.RowIndex]["PresNo"].ToString() + " and item_id>0");
                if (rows.Length >= 10)
                this.ChangePres();
            }

            //赋值
            WritePresRowValue(row);

            SetCellColor(_view.RowIndex, -1);
            SettingReadOnly(_view.RowIndex);

            this.CalculateAmount(_view.RowIndex);
            if (Convert.ToBoolean(_view.BindPresDataSource.Rows[_view.RowIndex]["IsHerb"]))
            {
                if (_view.RowIndex > 0 && Convert.ToBoolean(_view.BindPresDataSource.Rows[_view.RowIndex - 1]["IsHerb"]))
                {
                    this.UniteHerbValue(_view.RowIndex - 1);
                    _view.BindPresDataSource.Rows[_view.RowIndex]["Dosage"] = _view.BindPresDataSource.Rows[_view.RowIndex - 1]["Dosage"];
                    _view.BindPresDataSource.Rows[_view.RowIndex]["Dosage_S"] = _view.BindPresDataSource.Rows[_view.RowIndex - 1]["Dosage_S"];
                    _view.BindPresDataSource.Rows[_view.RowIndex]["Frequency_Id"] = _view.BindPresDataSource.Rows[_view.RowIndex - 1]["Frequency_Id"];
                    _view.BindPresDataSource.Rows[_view.RowIndex]["Frequency_Name"] = _view.BindPresDataSource.Rows[_view.RowIndex - 1]["Frequency_Name"];
                    _view.BindPresDataSource.Rows[_view.RowIndex]["Usage_Id"] = _view.BindPresDataSource.Rows[_view.RowIndex - 1]["Usage_Id"];
                    _view.BindPresDataSource.Rows[_view.RowIndex]["Usage_Name"] = _view.BindPresDataSource.Rows[_view.RowIndex - 1]["Usage_Name"];
                }
                else if (_view.RowIndex < _view.BindPresDataSource.Rows.Count - 1 && Convert.ToBoolean(_view.BindPresDataSource.Rows[_view.RowIndex + 1]["IsHerb"]))
                {
                    this.UniteHerbValue(_view.RowIndex + 1);
                }
            }
            else if (Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex]["Group_Id"]) > 0)
            {
                if (_view.RowIndex > 0 && Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex]["Group_Id"]) > 0)
                {
                    this.UniteGroupValue(_view.RowIndex - 1);
                }
                else if (_view.RowIndex < _view.BindPresDataSource.Rows.Count - 1 && Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex]["Group_Id"]) > 0)
                {
                    this.UniteGroupValue(_view.RowIndex + 1);
                }
            }
        }

        /// <summary>
        /// 为处方行赋值
        /// </summary>
        /// <param name="row"></param>
        private void WritePresRowValue(DataRow row)
        {
            //赋初值
            _view.BindPresDataSource.Rows[_view.RowIndex]["SkinTest_Flag"] = (int)HIS.MZDoc_BLL.Public.SkinTestStatus.不需要皮试;
            _view.BindPresDataSource.Rows[_view.RowIndex]["Entrust"] = "";

            //赋值
            _view.BindPresDataSource.Rows[_view.RowIndex]["StatItem_Code"] = XcConvert.IsNull(row["STATITEM_CODE"], "");
            _view.BindPresDataSource.Rows[_view.RowIndex]["Item_Id"] = Convert.ToInt32(XcConvert.IsNull(row["ITEMID"], "-1"));
            _view.BindPresDataSource.Rows[_view.RowIndex]["Item_Id_S"] = XcConvert.IsNull(row["ITEMID"], "");
            _view.BindPresDataSource.Rows[_view.RowIndex]["Item_Name"] = XcConvert.IsNull(row["ITEMNAME"], "");
            _view.BindPresDataSource.Rows[_view.RowIndex]["Item_Name_S"] = XcConvert.IsNull(row["ITEMNAME"], "");

            _view.BindPresDataSource.Rows[_view.RowIndex]["Dept_Id"] = Convert.ToInt32(XcConvert.IsNull(row["EXECDEPTCODE"], "-1"));
            _view.BindPresDataSource.Rows[_view.RowIndex]["Dept_Name"] = XcConvert.IsNull(row["EXECDEPTNAME"], "");

            if (Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex]["Dept_Id"]) <= 0)
            {
                _view.BindPresDataSource.Rows[_view.RowIndex]["Dept_Id"] = _view.currentDept.DeptID;
                _view.BindPresDataSource.Rows[_view.RowIndex]["Dept_Name"] = _view.currentDept.Name;
            }
            _view.BindPresDataSource.Rows[_view.RowIndex]["Standard"] = XcConvert.IsNull(row["STANDARD"], "");
            _view.BindPresDataSource.Rows[_view.RowIndex]["Item_Price"] = Convert.ToDecimal(XcConvert.IsNull(row["SELL_PRICE"], "0")) / Convert.ToInt32(XcConvert.IsNull(row["UNPICKNUM"], ""));
            _view.BindPresDataSource.Rows[_view.RowIndex]["Item_Price_S"] = Convert.ToDecimal(XcConvert.IsNull(row["SELL_PRICE"], "0")) / Convert.ToInt32(XcConvert.IsNull(row["UNPICKNUM"], ""));
            _view.BindPresDataSource.Rows[_view.RowIndex]["Buy_Price"] = Convert.ToDecimal(XcConvert.IsNull(row["BUY_PRICE"], "0"));
            _view.BindPresDataSource.Rows[_view.RowIndex]["Sell_Price"] = Convert.ToDecimal(XcConvert.IsNull(row["SELL_PRICE"], "0"));
            _view.BindPresDataSource.Rows[_view.RowIndex]["RelationNum"] = Convert.ToInt32(XcConvert.IsNull(row["PACKNUM"], "1"));
            _view.BindPresDataSource.Rows[_view.RowIndex]["Unit"] = XcConvert.IsNull(row["PACKUNIT"], "");
            _view.BindPresDataSource.Rows[_view.RowIndex]["Service_Item_Id"] = Convert.ToInt32(XcConvert.IsNull(row["Service_Item_Id"], "-1"));
            _view.BindPresDataSource.Rows[_view.RowIndex]["Tc_Flag"] = Convert.ToInt32(XcConvert.IsNull(row["TC_FLAG"], "0"));
            _view.BindPresDataSource.Rows[_view.RowIndex]["IsDrug"] = XcConvert.IsNull(row["DRUG_FLAG"], "0") == "1";
            _view.BindPresDataSource.Rows[_view.RowIndex]["IsHerb"] = XcConvert.IsNull(row["STATITEM_CODE"], "") == "03";
            _view.BindPresDataSource.Rows[_view.RowIndex]["IsFloat"] = XcConvert.IsNull(row["FLOAT_FLAG"], "0") == "1";
            if (Convert.ToInt32(row["SKINTEST_FLAG"]) == 1)
            {
                int skinTest_Flag = CheckSkinTestDrug(row).GetHashCode();
                _view.BindPresDataSource.Rows[_view.RowIndex]["SkinTest_Flag"] = skinTest_Flag;
            }

            //设置部分默认值
            _view.BindPresDataSource.Rows[_view.RowIndex]["Usage_Amount_S"] = "1";
            _view.BindPresDataSource.Rows[_view.RowIndex]["Usage_Unit"] = XcConvert.IsNull(row["LEASTUNIT"], "");
            _view.BindPresDataSource.Rows[_view.RowIndex]["Usage_Rate"] = 1;
            _view.BindPresDataSource.Rows[_view.RowIndex]["Dosage_S"] = "1";
            _view.BindPresDataSource.Rows[_view.RowIndex]["Days_S"] = "1";
            _view.BindPresDataSource.Rows[_view.RowIndex]["Item_Amount_S"] = "1";
            _view.BindPresDataSource.Rows[_view.RowIndex]["Item_Unit"] = XcConvert.IsNull(row["UNPICKUNIT"], "");
            _view.BindPresDataSource.Rows[_view.RowIndex]["Item_Rate"] = Convert.ToInt32(XcConvert.IsNull(row["UNPICKNUM"], "1"));
        }

        /// <summary>
        /// ShowCard赋值
        /// </summary>
        /// <param name="rowid"></param>
        /// <param name="colid"></param>
        /// <param name="row"></param>
        public void SelectCardBindData(int colid, DataRow row)
        {
            if (row == null) return;
            DataTable dt = _view.BindPresDataSource;
            if (colid == _view.ColumnIndex.ItemIdIndex)      //项目编码
            {
                WriteRowValue(row);
            }
            if (colid == _view.ColumnIndex.DeptNameIndex)   //执行科室
            {
                if (_view.RowIndex > 0
                       && Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex - 1]["Item_Id"]) > 0
                       && Convert.ToInt32(XcConvert.IsNull(row["Dept_Id"], "-1")) != Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex - 1]["Dept_Id"])
                    || _view.RowIndex < _view.BindPresDataSource.Rows.Count - 1
                       && Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex + 1]["Item_Id"]) > 0
                       && Convert.ToInt32(XcConvert.IsNull(row["Dept_Id"], "-1")) != Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex + 1]["Dept_Id"]))
                {
                    throw new Exception("处方执行科室发生改变，请保存后换方再开！");
                }
                dt.Rows[_view.RowIndex]["Dept_Id"] = XcConvert.IsNull(row["Dept_Id"], "-1");
                dt.Rows[_view.RowIndex]["Dept_Name"] = XcConvert.IsNull(row["Name"], "");
            }
            if (colid == _view.ColumnIndex.UsageUnitIndex)   //用量单位
            {
                dt.Rows[_view.RowIndex]["Usage_Unit"] = XcConvert.IsNull(row["UNITNAME"], "");
                dt.Rows[_view.RowIndex]["Usage_Unit_S"] = XcConvert.IsNull(row["UNITNAME"], "");
                dt.Rows[_view.RowIndex]["Usage_Rate"] = XcConvert.IsNull(row["Rate"], "1");
            }
            if (colid == _view.ColumnIndex.UsageIndex)       //用法
            {
                dt.Rows[_view.RowIndex]["Usage_Id"] = XcConvert.IsNull(row["Id"], "-1");
                dt.Rows[_view.RowIndex]["Usage_Name"] = XcConvert.IsNull(row["Name"], "");
            }
            if (colid == _view.ColumnIndex.FrequencyIndex)   //频次
            {
                dt.Rows[_view.RowIndex]["Frequency_Id"] = XcConvert.IsNull(row["Id"], "-1");
                dt.Rows[_view.RowIndex]["Frequency_Name"] = XcConvert.IsNull(row["Name"], "");
                dt.Rows[_view.RowIndex]["Frequency_ExecNum"] = XcConvert.IsNull(row["ExecNum"], "1");
                dt.Rows[_view.RowIndex]["Frequency_CycleDay"] = XcConvert.IsNull(row["CycleDay"], "");
            }
            if (colid == _view.ColumnIndex.ItemUnitIndex)    //开药单位
            {
                dt.Rows[_view.RowIndex]["Item_Unit"] = XcConvert.IsNull(row["UNITNAME"], "");
                dt.Rows[_view.RowIndex]["Item_Unit_S"] = XcConvert.IsNull(row["UNITNAME"], "");
                dt.Rows[_view.RowIndex]["Item_Price"] = Convert.ToDecimal(dt.Rows[_view.RowIndex]["Sell_Price"]) / Convert.ToInt32(XcConvert.IsNull(row["Rate"], "1"));
                dt.Rows[_view.RowIndex]["Item_Price_S"] = Convert.ToDecimal(dt.Rows[_view.RowIndex]["Sell_Price"]) / Convert.ToInt32(XcConvert.IsNull(row["Rate"], "1"));
                dt.Rows[_view.RowIndex]["Item_Rate"] = XcConvert.IsNull(row["Rate"], "1");
            }
            if (colid == _view.ColumnIndex.EntrustIndex)     //嘱托
            {
                dt.Rows[_view.RowIndex]["Entrust"] = XcConvert.IsNull(row["Name"], "");
            }
            this.MouldProcess(colid);
        }

        /// <summary>
        /// 模板明细信息处理
        /// </summary>
        /// <param name="colid"></param>
        public new void MouldProcess(int colid)
        {
            base.MouldProcess(colid);

            if (colid == _view.ColumnIndex.ItemAmountIndex   //开药数量
                || colid == _view.ColumnIndex.ItemUnitIndex) //开药单位
            {
                this.CalculateMoney(_view.RowIndex);
            }
        }
        #endregion

        #region 病人操作
        /// <summary>
        /// 检索病人
        /// </summary>
        /// <param name="searchValue"></param>
        /// <param name="type"></param>
        public void SearchPatient(string searchValue, int type)
        {
            switch (type)
            {
                case 1:
                    if (searchValue != "")
                    {
                        _view.CurrentPatient = new Patient(searchValue);
                        _view.CurrentPatient.ChangeCureInfo(HIS.MZDoc_BLL.Public.PatCureStatus.就诊状态);
                        if (_view.CurrentPatient.PatList.PatListID == 0)
                        {
                            throw new Exception("找不到与该门诊号对应的病人信息！");
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 更改病人就诊诊断
        /// </summary>
        /// <param name="Diagnosis"></param>
        public void ChangeDiagnosis(string Diagnosis)
        {
            if (_view.CurrentPatientDiagnosis.Trim() == "" || _view.CurrentPatientDiagnosis.Trim() == "|")
            {
                _view.CurrentPatientDiagnosis = Diagnosis;
            }
            else
            {
                _view.CurrentPatientDiagnosis = _view.CurrentPatientDiagnosis + "," + Diagnosis;
            }

            _view.CurrentPatient.PatList.DiseaseName = _view.CurrentPatientDiagnosis;
            _view.CurrentPatient.ChangeDiagnosis();
        }

        /// <summary>
        /// 诊断ShowCard赋值
        /// </summary>
        /// <param name="rowid"></param>
        /// <param name="colid"></param>
        /// <param name="row"></param>
        public void SelectedDiagnosisRow(object SelectedValue)
        {
            if (SelectedValue != null)
            {
                ChangeDiagnosis(((DataRow)SelectedValue)["Diagnosis_Name"].ToString());
            }
        }

        /// <summary>
        /// 自动生成门诊诊疗费用
        /// </summary>
        public void AutoProduceCureFee()
        {
            try
            {
                string[] orderIds = HIS.MZDoc_BLL.OP_ReadBaseData.GetConfigValue("007").Split(',');
                foreach (string orderId in orderIds)
                {
                    AddRow();
                    DataRow[] rows = _dataSet.Tables["Item_Dictionary"].Select("ITEMID=" + orderId + " and DRUG_FLAG=0");
                    if (rows != null && rows.Length > 0)
                    {
                        SelectCardBindData(_view.ColumnIndex.ItemIdIndex, rows[0]);
                        _view.BindPresDataSource.Rows[_view.RowIndex]["Dept_Id"] = _view.currentDept.DeptID;
                        _view.BindPresDataSource.Rows[_view.RowIndex]["Dept_Name"] = _view.currentDept.Name;
                    }
                }
                AddRow();
            }
            catch
            {
            }
        }
        #endregion

        /// <summary>
        /// 加载电子病历记录
        /// </summary>
        public void LoadEMRRecord()
        {
            HIS_EMRManager.Public.EMRRecordInfo emrInfo = new HIS_EMRManager.Public.EMRRecordInfo();
            emrInfo.Patid = Convert.ToInt64(_view.CurrentPatient.PatList.PatID);
            emrInfo.PatListid = _view.CurrentPatient.PatList.PatListID;
            emrInfo.RecordType = HIS_EMRManager.Public.EMRType.门诊病历;
            emrInfo.CreateEmpId = _view.currentUser.EmployeeID;
            emrInfo.CreateDeptId = _view.currentDept.DeptID;
            emrInfo.MediCard = _view.CurrentPatient.PatientInfo.MediCard;
            emrInfo.PatName = _view.CurrentPatient.PatientInfo.PatName;
            _view.EMRControl = HIS_EMRManager.Public.ExternalInterFace.GetEMRRecord(emrInfo);
        }

    }
}
