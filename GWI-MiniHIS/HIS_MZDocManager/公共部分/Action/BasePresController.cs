using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.MZDoc_BLL;

namespace HIS_MZDocManager.Action
{
    /// <summary>
    /// 处方控制类
    /// </summary>
    public class BasePresController
    {
        private IBasePresView _view;
        protected static DataSet _dataSet;
        protected HIS.MZDoc_BLL.Public.PresListType PresListType;
        protected int PresHeadId;

        public BasePresController()
        {
        }
        public BasePresController(IBasePresView view)
        {
            _view = view;
            LoadBaseData();
            _view.Initialize(_dataSet);
        }

        /// <summary>
        /// 处方界面
        /// </summary>
        protected IBasePresView View
        {
            get { return _view; }
            set { _view = value; }
        }

        /// <summary>
        /// 基础数据源
        /// </summary>
        public DataSet BaseDataSet
        {
            get
            {
                return _dataSet;
            }
            set
            {
                _dataSet = value;
            }
        }

        #region 方法
        /// <summary>
        /// 加载基础数据
        /// </summary>
        protected void LoadBaseData()
        {
            _view.DrugDeptDic = HIS.MZDoc_BLL.OP_ReadBaseData.GetDeptStore(_view.currentDept.DeptID);
            if (_dataSet == null)
            {
                _dataSet = new DataSet();
                //DataTable tb = HIS.MZDoc_BLL.OP_ReadBaseData.GetBaseItemData();
                //tb.TableName = "Item_Dictionary_All";
                //_dataSet.Tables.Add(tb);

                DataTable tb = HIS.MZDoc_BLL.OP_ReadBaseData.GetAllBaseItemData();
                tb.TableName = "All_Item_Dictionary_All";
                _dataSet.Tables.Add(tb);

                tb = HIS.MZDoc_BLL.OP_ReadBaseData.GetFrequencyData();
                tb.TableName = "Frequency_Dictionary";
                _dataSet.Tables.Add(tb);

                tb = HIS.MZDoc_BLL.OP_ReadBaseData.GetUnitData();
                tb.TableName = "Unit_Dictionary";
                _dataSet.Tables.Add(tb);

                tb = _dataSet.Tables["Unit_Dictionary"].Clone();
                tb.TableName = "Usage_Unit_Dictionary";
                tb.Columns.Add("Rate", Type.GetType("System.Decimal"));
                _dataSet.Tables.Add(tb);

                tb = _dataSet.Tables["Unit_Dictionary"].Clone();
                tb.TableName = "Item_Unit_Dictionary";
                tb.Columns.Add("Rate", Type.GetType("System.Decimal"));
                _dataSet.Tables.Add(tb);

                tb = HIS.MZDoc_BLL.OP_ReadBaseData.GetUsageData();
                tb.TableName = "Usage_Dictionary";
                _dataSet.Tables.Add(tb);

                tb = HIS.MZDoc_BLL.OP_ReadBaseData.GetEntrustData();
                tb.TableName = "Entrust_Dictionary";
                _dataSet.Tables.Add(tb);

                tb = HIS.MZDoc_BLL.OP_ReadBaseData.GetDeptData();
                tb.TableName = "Dept_Dictionary";
                _dataSet.Tables.Add(tb);

                tb = _dataSet.Tables["Dept_Dictionary"].Clone();
                tb.TableName = "ExeDept_Dictionary";
                _dataSet.Tables.Add(tb);

                tb = HIS.MZDoc_BLL.OP_ReadBaseData.GetItemExeDeptData();
                tb.TableName = "ItemExeDept_Dictionary";
                _dataSet.Tables.Add(tb);

                tb = _dataSet.Tables["All_Item_Dictionary_All"].Clone();
                tb.TableName = "Item_Dictionary";
                _dataSet.Tables.Add(tb);

                tb = _dataSet.Tables["All_Item_Dictionary_All"].Clone();
                tb.TableName = "All_Item_Dictionary";
                _dataSet.Tables.Add(tb);
            }

            FilterDeptDrug();
        }

        /// <summary>
        /// 统一行数据值
        /// </summary>
        /// <param name="modelRow">模板行</param>
        /// <param name="currentRow">当前行</param>
        protected void UniteRowValue(int modelRow, int currentRow)
        {
            _view.BindPresDataSource.Rows[currentRow]["Dosage_S"] = _view.BindPresDataSource.Rows[modelRow]["Dosage_S"];
            _view.BindPresDataSource.Rows[currentRow]["Usage_Id"] = _view.BindPresDataSource.Rows[modelRow]["Usage_Id"];
            _view.BindPresDataSource.Rows[currentRow]["Usage_Name"] = _view.BindPresDataSource.Rows[modelRow]["Usage_Name"];
            _view.BindPresDataSource.Rows[currentRow]["Frequency_Id"] = _view.BindPresDataSource.Rows[modelRow]["Frequency_Id"];
            _view.BindPresDataSource.Rows[currentRow]["Frequency_Name"] = _view.BindPresDataSource.Rows[modelRow]["Frequency_Name"];
            _view.BindPresDataSource.Rows[currentRow]["Frequency_ExecNum"] = _view.BindPresDataSource.Rows[modelRow]["Frequency_ExecNum"];
            _view.BindPresDataSource.Rows[currentRow]["Frequency_CycleDay"] = _view.BindPresDataSource.Rows[modelRow]["Frequency_CycleDay"];
            _view.BindPresDataSource.Rows[currentRow]["Days_S"] = _view.BindPresDataSource.Rows[modelRow]["Days_S"];

            CalculateAmount(currentRow);
        }

        /// <summary>
        /// 统一组数据值
        /// </summary>
        /// <param name="rowNo">行号</param>
        protected void UniteGroupValue(int rowNo)
        {
            if (Convert.ToInt32(_view.BindPresDataSource.Rows[rowNo]["Group_Id"]) > 1)
            {
                for (int index = rowNo - 1; index > -1; index--)
                {
                    if (Convert.ToInt32(_view.BindPresDataSource.Rows[index]["Group_Id"]) >= 1)
                    {
                        this.UniteRowValue(rowNo, index);
                        if ((HIS.MZDoc_BLL.Public.PresStatus)_view.BindPresDataSource.Rows[index]["Status"] == HIS.MZDoc_BLL.Public.PresStatus.保存状态)
                        {
                            _view.BindPresDataSource.Rows[index]["Status"] = HIS.MZDoc_BLL.Public.PresStatus.修改状态;
                        }
                    }
                    if (Convert.ToInt32(_view.BindPresDataSource.Rows[index]["Group_Id"]) == 1)
                    {
                        break;
                    }
                }
            }
            for (int index = rowNo + 1; index < _view.BindPresDataSource.Rows.Count; index++)
            {
                if (Convert.ToInt32(_view.BindPresDataSource.Rows[index]["Group_Id"]) > 1)
                {
                    this.UniteRowValue(rowNo, index);
                    if ((HIS.MZDoc_BLL.Public.PresStatus)_view.BindPresDataSource.Rows[index]["Status"] == HIS.MZDoc_BLL.Public.PresStatus.保存状态)
                    {
                        _view.BindPresDataSource.Rows[index]["Status"] = HIS.MZDoc_BLL.Public.PresStatus.修改状态;
                    }
                }
                else if (Convert.ToInt32(_view.BindPresDataSource.Rows[index]["Group_Id"]) == 1)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// 统一中药处方数据值
        /// </summary>
        /// <param name="rowNo"></param>
        protected void UniteHerbValue(int rowNo)
        {
            int presNo = Convert.ToInt32(_view.BindPresDataSource.Rows[rowNo]["PresNo"]);
            for (int index = rowNo - 1; index > -1; index--)
            {
                if (Convert.ToInt32(_view.BindPresDataSource.Rows[index]["PresNo"]) == presNo)
                {
                    this.UniteRowValue(rowNo, index);
                    if ((HIS.MZDoc_BLL.Public.PresStatus)_view.BindPresDataSource.Rows[index]["Status"] == HIS.MZDoc_BLL.Public.PresStatus.保存状态)
                    {
                        _view.BindPresDataSource.Rows[index]["Status"] = HIS.MZDoc_BLL.Public.PresStatus.修改状态;
                    }
                }
                else
                {
                    break;
                }
            }
            for (int index = rowNo + 1; index < _view.BindPresDataSource.Rows.Count; index++)
            {
                if (Convert.ToInt32(_view.BindPresDataSource.Rows[index]["PresNo"]) == presNo && Convert.ToInt32(_view.BindPresDataSource.Rows[index]["Item_Id"]) > 1)
                {
                    this.UniteRowValue(rowNo, index);
                    if ((HIS.MZDoc_BLL.Public.PresStatus)_view.BindPresDataSource.Rows[index]["Status"] == HIS.MZDoc_BLL.Public.PresStatus.保存状态)
                    {
                        _view.BindPresDataSource.Rows[index]["Status"] = HIS.MZDoc_BLL.Public.PresStatus.修改状态;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// 统一数据值
        /// </summary>
        /// <param name="rowNo"></param>
        protected void UniteValue(int rowNo)
        {
            if (Convert.ToBoolean(_view.BindPresDataSource.Rows[rowNo]["IsDrug"]))
            {
                if (Convert.ToBoolean(_view.BindPresDataSource.Rows[rowNo]["IsHerb"]))
                {
                    this.UniteHerbValue(rowNo);
                }
                else if (Convert.ToInt32(_view.BindPresDataSource.Rows[rowNo]["Group_Id"]) > 0)
                {
                    this.UniteGroupValue(rowNo);
                }
            }
        }

        /// <summary>
        /// 绘制删除线
        /// </summary>
        /// <param name="graphics">绘图对象</param>
        /// <param name="pen">画笔</param>
        private void PaintDelLine(Graphics graphics, System.Drawing.Pen pen)
        {
            //定义坐标变量
            int startPointX, startPointY, endPointX, endPointY;

            startPointX = _view.GridCellBounds.Left;
            startPointY = _view.GridCellBounds.Top + _view.GridCellBounds.Height / 2;
            endPointX = _view.GridCellBounds.Right;
            endPointY = startPointY;
            graphics.DrawLine(pen, startPointX, startPointY, endPointX, endPointY);
        }

        /// <summary>
        /// 绘制组线
        /// </summary>
        /// <param name="groupFlag">组号</param>
        /// <param name="graphics">绘图对象</param>
        /// <param name="pen">画笔</param>
        protected void PaintGroupLine(int groupFlag, Graphics graphics, System.Drawing.Pen pen)
        {
            //定义坐标变量
            int startPointX, startPointY, endPointX, endPointY;
            int firstLineWidth = 6;
            int firstLineHeight = _view.GridCellBounds.Height / 2;
            switch (groupFlag)
            {
                case 1:
                    //小横线
                    startPointX = _view.GridCellBounds.Left - firstLineWidth;
                    startPointY = _view.GridCellBounds.Bottom - firstLineHeight;
                    endPointX = _view.GridCellBounds.Left;
                    endPointY = _view.GridCellBounds.Bottom - firstLineHeight;
                    graphics.DrawLine(pen, startPointX, startPointY, endPointX, endPointY);
                    //小竖线
                    startPointX = _view.GridCellBounds.Left - firstLineWidth;
                    startPointY = _view.GridCellBounds.Bottom - firstLineHeight;
                    endPointX = _view.GridCellBounds.Left - firstLineWidth;
                    endPointY = _view.GridCellBounds.Bottom;
                    graphics.DrawLine(pen, startPointX, startPointY, endPointX, endPointY);
                    break;
                case 2:
                    startPointX = _view.GridCellBounds.Left - firstLineWidth;
                    startPointY = _view.GridCellBounds.Top;
                    endPointX = _view.GridCellBounds.Left - firstLineWidth;
                    endPointY = _view.GridCellBounds.Bottom;
                    graphics.DrawLine(pen, startPointX, startPointY, endPointX, endPointY);
                    break;
                case 3:
                    //小竖线
                    startPointX = _view.GridCellBounds.Left - firstLineWidth;
                    startPointY = _view.GridCellBounds.Top;
                    endPointX = _view.GridCellBounds.Left - firstLineWidth;
                    endPointY = _view.GridCellBounds.Top + firstLineHeight;
                    graphics.DrawLine(pen, startPointX, startPointY, endPointX, endPointY);
                    //小横线
                    startPointX = _view.GridCellBounds.Left - firstLineWidth;
                    startPointY = _view.GridCellBounds.Top + firstLineHeight;
                    endPointX = _view.GridCellBounds.Left;
                    endPointY = _view.GridCellBounds.Top + firstLineHeight;
                    graphics.DrawLine(pen, startPointX, startPointY, endPointX, endPointY);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 计算开药数量
        /// </summary>
        /// <param name="rowNo"></param>
        protected void CalculateAmount(int rowNo)
        {
            HIS.MZDoc_BLL.IBasePresList _presList = PresListFactory.CreatePresListObject(this.PresListType, _view.BindPresDataSource.Rows[rowNo]);
            _presList.CalculateAmount();
            _view.BindPresDataSource.Rows[rowNo].ItemArray = HIS.MZDoc_BLL.Public.Function.ObjectToDataRow(_presList).ItemArray;
        }

        public void FilterDeptDrug()
        {
            DataRow[] rows = null;
            switch (PresListType)
            {
                case HIS.MZDoc_BLL.Public.PresListType.病人处方明细:
                    _dataSet.Tables["Item_Dictionary"].Rows.Clear();
                    rows = _dataSet.Tables["All_Item_Dictionary_All"].Select("(drug_flag=0 or EXECDEPTCODE in (" + _view.SelectedDrugDeptId + ") or '" + _view.SelectedDrugDeptId + "'='-1') and STORENUM>0");
                    if (rows == null)
                    {
                        return;
                    }
                    for (int index = 0; index < rows.Length; index++)
                    {
                        _dataSet.Tables["Item_Dictionary"].Rows.Add(rows[index].ItemArray);
                    }
                    break;
                case HIS.MZDoc_BLL.Public.PresListType.处方模板明细:
                    _dataSet.Tables["All_Item_Dictionary"].Rows.Clear();
                    rows = _dataSet.Tables["All_Item_Dictionary_All"].Select("drug_flag=0 or EXECDEPTCODE in (" + _view.SelectedDrugDeptId + ") or '" + _view.SelectedDrugDeptId + "'='-1'");
                    if (rows == null)
                    {
                        return;
                    }
                    for (int index = 0; index < rows.Length; index++)
                    {
                        _dataSet.Tables["All_Item_Dictionary"].Rows.Add(rows[index].ItemArray);
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 工具栏操作
        /// <summary>
        /// 新增一行
        /// </summary>
        public void AddRow()
        {
            DataTable dt = _view.BindPresDataSource;
            int rowid;
            if (dt.Rows.Count > 0)
            {
                rowid = dt.Rows.Count - 1;
                if (dt.Rows[rowid]["Item_Name"].ToString().Trim() == "")	//最后一行不为空才允许新增一行
                {
                    _view.RowIndex = dt.Rows.Count - 1;
                    return;
                }

                int maxPresNo = Convert.ToInt32(dt.Compute("max(PresNo)", ""));
                if (dt.Rows[rowid]["Item_Name"].ToString().Trim() == "小计：")
                {
                    maxPresNo++;
                }
                int maxOrderNO = Convert.ToInt32(XcConvert.IsNull(dt.Compute("max(OrderNO)", "PresNo=" + maxPresNo), "0")) + 1;
                int groupId = 0;
                if (_view.GroupStartRowIndex >= 0 && _view.GroupStartRowIndex < _view.BindPresDataSource.Rows.Count && Convert.ToInt32(_view.BindPresDataSource.Rows[_view.GroupStartRowIndex]["PresNo"]) == maxPresNo)
                {
                    int lastGroupId = Convert.ToInt32(_view.BindPresDataSource.Rows[dt.Rows.Count - 1]["OrderNO"]);
                    if (lastGroupId == dt.Rows.Count - _view.GroupStartRowIndex)
                    {
                        groupId = lastGroupId + 1;
                    }
                }
                List<HIS.MZDoc_BLL.IBasePresList> _presLists = new List<HIS.MZDoc_BLL.IBasePresList>();
                HIS.MZDoc_BLL.IBasePresList _presList = PresListFactory.CreatePresListObject(this.PresListType, PresHeadId);
                _presList.PresNo = maxPresNo;
                _presList.OrderNo = maxOrderNO;
                _presList.Group_Id = groupId;
                _presLists.Add(_presList);
                DataTable dtnew = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(_presLists);
                dt.Rows.Add(dtnew.Rows[0].ItemArray);
                _view.RowIndex = dt.Rows.Count - 1;
                return;
            }
            else
            {
                List<HIS.MZDoc_BLL.IBasePresList> _presLists = new List<HIS.MZDoc_BLL.IBasePresList>();
                HIS.MZDoc_BLL.IBasePresList _presList = PresListFactory.CreatePresListObject(this.PresListType, PresHeadId);
                _presList.PresNo = 1;
                _presList.OrderNo = 1;
                _presLists.Add(_presList);

                _view.BindPresDataSource = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(_presLists);
                dt = _view.BindPresDataSource;
            }

            _view.RowIndex = dt.Rows.Count - 1;
        }

        /// <summary>
        /// 修改一行
        /// </summary>
        public void UpdateRow()
        {
            if (_view.RowIndex < 0)
            {
                return;
            }
            if ((HIS.MZDoc_BLL.Public.PresStatus)_view.BindPresDataSource.Rows[_view.RowIndex]["Status"] == HIS.MZDoc_BLL.Public.PresStatus.保存状态)
            {
                _view.BindPresDataSource.Rows[_view.RowIndex]["Status"] = HIS.MZDoc_BLL.Public.PresStatus.修改状态;
                SetCellColor(_view.RowIndex, -1);
                SettingReadOnly(_view.RowIndex);
            }
        }
        #endregion

        #region 右键菜单操作
        /// <summary>
        /// 插入一行
        /// </summary>
        public void InsertRow()
        {
            if (_view.BindPresDataSource.Rows.Count <= 0)
                return;

            DataTable tmpTable = _view.BindPresDataSource.Clone();
            int currentIndex = _view.RowIndex;

            #region 复制该条记录前面所有的行
            for (int i = 0; i < _view.RowIndex; i++)
            {
                tmpTable.Rows.Add(_view.BindPresDataSource.Rows[i].ItemArray);
            }
            #endregion

            #region 添加新行
            int presNo = Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex]["PresNo"]);
            int orderNo = Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex]["OrderNo"]);
            int group_Id = Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex]["Group_Id"]);

            List<HIS.MZDoc_BLL.IBasePresList> _presLists = new List<HIS.MZDoc_BLL.IBasePresList>();
            HIS.MZDoc_BLL.IBasePresList _presList = PresListFactory.CreatePresListObject(this.PresListType, PresHeadId);
            _presList.PresNo = presNo;
            _presList.OrderNo = orderNo;
            if (group_Id > 1)
            {
                _presList.Group_Id = group_Id;
            }
            _presLists.Add(_presList);
            DataTable dtnew = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(_presLists);
            tmpTable.Rows.Add(dtnew.Rows[0].ItemArray);
            #endregion

            #region 复制该条记录后面所有的行
            //更新开始分组号                        
            if (_view.GroupStartRowIndex >= _view.RowIndex)
            {
                _view.GroupStartRowIndex += 1;
            }
            for (int i = _view.RowIndex; i < _view.BindPresDataSource.Rows.Count; i++)
            {
                if (Convert.ToInt32(_view.BindPresDataSource.Rows[i]["PresNo"]) == presNo)
                {
                    //更新组号
                    if (group_Id > 1 && Convert.ToInt32(_view.BindPresDataSource.Rows[i]["group_Id"]) >= group_Id)
                    {
                        _view.BindPresDataSource.Rows[i]["group_Id"] = Convert.ToInt32(_view.BindPresDataSource.Rows[i]["group_Id"]) + 1;
                    }
                    else
                    {
                        group_Id = 0;
                    }
                    //更新处方内序号
                    _view.BindPresDataSource.Rows[i]["orderNo"] = Convert.ToInt32(_view.BindPresDataSource.Rows[i]["orderNo"]) + 1;
                    if (Convert.ToInt32(_view.BindPresDataSource.Rows[i]["orderNo"]) == 1)
                    {
                        _view.BindPresDataSource.Rows[i]["TmpNo"] = _view.BindPresDataSource.Rows[i]["PresNo"];
                    }
                    else
                    {
                        _view.BindPresDataSource.Rows[i]["TmpNo"] = "";
                    }
                    //修改处方序号
                    if ((HIS.MZDoc_BLL.Public.PresStatus)_view.BindPresDataSource.Rows[i]["Status"] == HIS.MZDoc_BLL.Public.PresStatus.保存状态)
                    {
                        _view.BindPresDataSource.Rows[i]["Status"] = HIS.MZDoc_BLL.Public.PresStatus.修改状态;
                    }
                }
                tmpTable.Rows.Add(_view.BindPresDataSource.Rows[i].ItemArray);
            }
            #endregion

            _view.BindPresDataSource = tmpTable;
            _view.RowIndex = currentIndex;
            for (int i = 0; i < _view.BindPresDataSource.Rows.Count; i++)
            {
                SetCellColor(i, -1);
            }
        }

        /// <summary>
        /// 删除一行
        /// </summary>
        public bool DeleteRow()
        {
            if (Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex]["Item_Id"]) > 0)
            {
                if (MessageBox.Show("确定要删除该行吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    return false;
                }
            }
            return DeleteRow(_view.RowIndex);
        }

        public bool DeleteRow(int rowIndex)
        {//Convert.ToInt32(_view.BindPresDataSource.Rows[rowIndex]["Item_Id"]) <= 0 &&
            if (_view.BindPresDataSource.Rows[rowIndex]["Item_Name"].ToString().Trim() == "小计：")
            {
                if (rowIndex == _view.BindPresDataSource.Rows.Count - 1)
                {
                    _view.BindPresDataSource.Rows.RemoveAt(rowIndex);
                }
                return false;
            }
            //更新开始分组号
            if (_view.GroupStartRowIndex == rowIndex)
            {
                _view.GroupStartRowIndex = -1;
            }
            //删除该行
            if ((HIS.MZDoc_BLL.Public.PresStatus)_view.BindPresDataSource.Rows[rowIndex]["Status"] != HIS.MZDoc_BLL.Public.PresStatus.新建状态)
            {
                HIS.MZDoc_BLL.IBasePresList _presList = PresListFactory.CreatePresListObject(this.PresListType, _view.BindPresDataSource.Rows[rowIndex]);
                switch ((HIS.MZDoc_BLL.Public.PresStatus)_presList.Delete())
                {
                    case HIS.MZDoc_BLL.Public.PresStatus.收费状态:
                        throw new Exception("该张处方已经收费，无法删除该行，请刷新处方！");
                    case HIS.MZDoc_BLL.Public.PresStatus.退费状态:
                        throw new Exception("该张处方已退费，无法删除该行，请刷新处方！");
                    case HIS.MZDoc_BLL.Public.PresStatus.删除状态:
                        throw new Exception("该张处方已经删除，无法删除该行，请刷新处方！");
                }
            }

            #region 重新组织数据源表
            DataTable tmpTable = _view.BindPresDataSource.Clone();
            int currentIndex = rowIndex;

            // 复制该条记录前面所有的行
            for (int i = 0; i < rowIndex; i++)
            {
                tmpTable.Rows.Add(_view.BindPresDataSource.Rows[i].ItemArray);
            }

            //记录改行数据ll
            int presNo = Convert.ToInt32(_view.BindPresDataSource.Rows[rowIndex]["PresNo"]);
            int orderNo = Convert.ToInt32(_view.BindPresDataSource.Rows[rowIndex]["OrderNo"]);
            int group_Id = Convert.ToInt32(_view.BindPresDataSource.Rows[rowIndex]["Group_Id"]);
            int group_num = Convert.ToInt32(_view.BindPresDataSource.Rows[rowIndex]["Group_Id"]);

            //复制该条记录后面所有的行
            bool onlyOneRow = false;
            //更新开始分组号                        
            if (_view.GroupStartRowIndex >= _view.RowIndex + 1)
            {
                _view.GroupStartRowIndex -= 1;
            }
            for (int i = rowIndex + 1; i < _view.BindPresDataSource.Rows.Count; i++)
            {
                if (Convert.ToInt32(_view.BindPresDataSource.Rows[i]["PresNo"]) == presNo)
                {
                    if (orderNo == 1 && i == rowIndex + 1 && Convert.ToInt32(_view.BindPresDataSource.Rows[i]["Item_Id"]) <= 0)
                    {
                        onlyOneRow = true;
                        continue;
                    }
                    //移动组号
                    if (group_Id > 0 && Convert.ToInt32(_view.BindPresDataSource.Rows[i]["Group_Id"]) > group_Id)
                    {
                        group_num = Convert.ToInt32(_view.BindPresDataSource.Rows[i]["Group_Id"]);
                        _view.BindPresDataSource.Rows[i]["Group_Id"] = Convert.ToInt32(_view.BindPresDataSource.Rows[i]["Group_Id"]) - 1;
                    }
                    else
                    {
                        if (group_num == 2)
                        {
                            tmpTable.Rows[tmpTable.Rows.Count - 1]["Group_Id"] = 0;
                        }
                        group_Id = 0;
                    }
                    //移动行号
                    _view.BindPresDataSource.Rows[i]["orderNo"] = Convert.ToInt32(_view.BindPresDataSource.Rows[i]["orderNo"]) - 1;
                    if (Convert.ToInt32(_view.BindPresDataSource.Rows[i]["orderNo"]) == 1)
                    {
                        _view.BindPresDataSource.Rows[i]["TmpNo"] = _view.BindPresDataSource.Rows[i]["PresNo"];
                    }
                    else
                    {
                        _view.BindPresDataSource.Rows[i]["TmpNo"] = "";
                    }
                }
                //移动处方号
                if (onlyOneRow)
                {
                    _view.BindPresDataSource.Rows[i]["PresNo"] = Convert.ToInt32(_view.BindPresDataSource.Rows[i]["PresNo"]) - 1;
                    if (_view.BindPresDataSource.Rows[i]["TmpNo"].ToString() != "")
                    {
                        _view.BindPresDataSource.Rows[i]["TmpNo"] = _view.BindPresDataSource.Rows[i]["PresNo"];
                    }
                }
                tmpTable.Rows.Add(_view.BindPresDataSource.Rows[i].ItemArray);
            }

            _view.BindPresDataSource = tmpTable;
            _view.RowIndex = currentIndex;
            for (int i = 0; i < _view.BindPresDataSource.Rows.Count; i++)
            {
                SetCellColor(i, -1);
            }
            #endregion
            return true;
        }

        /// <summary>
        /// 上移一行
        /// </summary>
        public void UpRow()
        {
            if (Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex]["Item_Id"]) <= 0)
            {
                return;
            }
            int orderNo = Convert.ToInt32(XcConvert.IsNull(_view.BindPresDataSource.Rows[_view.RowIndex]["OrderNO"], "-1"));
            int group_Id = Convert.ToInt32(XcConvert.IsNull(_view.BindPresDataSource.Rows[_view.RowIndex]["Group_Id"], "0"));
            if (orderNo <= 1)
            {
                return;
            }
            //更新开始分组号
            if (_view.GroupStartRowIndex == _view.RowIndex)
            {
                _view.GroupStartRowIndex -= 1;
            }
            //更新开始分组号
            if (_view.GroupStartRowIndex == _view.RowIndex - 1)
            {
                _view.GroupStartRowIndex += 1;
            }
            //更换分组号
            if (group_Id == 1)
            {
                throw new Exception("该行为药品分组的第一行，不允许上移！");
            }
            else if (group_Id > 1)
            {
                _view.BindPresDataSource.Rows[_view.RowIndex]["Group_Id"] = group_Id - 1;
                _view.BindPresDataSource.Rows[_view.RowIndex - 1]["Group_Id"] = group_Id;
            }
            else if (Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex - 1]["Group_Id"]) > 0)
            {
                //update by zengyan 2009-9-19 不让改变分组的组成
                return;
                //_view.BindPresDataSource.Rows[_view.RowIndex]["Group_Id"] = Convert.ToInt32(XcConvert.IsNull(_view.BindPresDataSource.Rows[_view.RowIndex - 1]["Group_Id"], "0"));
                //_view.BindPresDataSource.Rows[_view.RowIndex - 1]["Group_Id"] = Convert.ToInt32(XcConvert.IsNull(_view.BindPresDataSource.Rows[_view.RowIndex - 1]["Group_Id"], "0")) + 1;
            }
            //更换行头
            _view.BindPresDataSource.Rows[_view.RowIndex]["TmpNo"] = _view.BindPresDataSource.Rows[_view.RowIndex - 1]["TmpNo"];
            _view.BindPresDataSource.Rows[_view.RowIndex - 1]["TmpNo"] = "";

            //更换序号
            _view.BindPresDataSource.Rows[_view.RowIndex - 1]["OrderNo"] = orderNo;
            _view.BindPresDataSource.Rows[_view.RowIndex]["OrderNo"] = orderNo - 1;


            List<HIS.MZDoc_BLL.IBasePresList> presList = new List<IBasePresList>();
            if ((HIS.MZDoc_BLL.Public.PresStatus)_view.BindPresDataSource.Rows[_view.RowIndex - 1]["Status"] != HIS.MZDoc_BLL.Public.PresStatus.新建状态)
            {
                HIS.MZDoc_BLL.IBasePresList pres = PresListFactory.CreatePresListObject(this.PresListType, _view.BindPresDataSource.Rows[_view.RowIndex - 1]);
                pres.Status = HIS.MZDoc_BLL.Public.PresStatus.修改状态;
                presList.Add(pres);
            }
            if ((HIS.MZDoc_BLL.Public.PresStatus)_view.BindPresDataSource.Rows[_view.RowIndex]["Status"] != HIS.MZDoc_BLL.Public.PresStatus.新建状态)
            {
                HIS.MZDoc_BLL.IBasePresList pres = PresListFactory.CreatePresListObject(this.PresListType, _view.BindPresDataSource.Rows[_view.RowIndex]);
                pres.Status = HIS.MZDoc_BLL.Public.PresStatus.修改状态;
                presList.Add(pres);
            }
            if (presList.Count > 0)
            {
                PresListFactory.CreatePresListObject(this.PresListType).Save(presList);
            }

            #region 重新组织数据源表
            DataTable tmpTable = _view.BindPresDataSource.Clone();
            int currentIndex = _view.RowIndex;

            // 复制该条记录前面所有的行
            for (int i = 0; i < _view.RowIndex - 1; i++)
            {
                tmpTable.Rows.Add(_view.BindPresDataSource.Rows[i].ItemArray);
            }

            //复制当前行和上一行

            tmpTable.Rows.Add(_view.BindPresDataSource.Rows[_view.RowIndex].ItemArray);
            tmpTable.Rows.Add(_view.BindPresDataSource.Rows[_view.RowIndex - 1].ItemArray);

            //复制该条记录后面所有的行
            for (int i = _view.RowIndex + 1; i < _view.BindPresDataSource.Rows.Count; i++)
            {
                tmpTable.Rows.Add(_view.BindPresDataSource.Rows[i].ItemArray);
            }

            _view.BindPresDataSource = tmpTable;
            _view.RowIndex = currentIndex;
            for (int i = 0; i < _view.BindPresDataSource.Rows.Count; i++)
            {
                SetCellColor(i, -1);
            }
            #endregion
        }

        /// <summary>
        /// 下移一行
        /// </summary>
        public void DownRow()
        {
            if (Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex]["Item_Id"]) <= 0)
            {
                return;
            }
            int orderNo = Convert.ToInt32(XcConvert.IsNull(_view.BindPresDataSource.Rows[_view.RowIndex]["OrderNO"], "-1"));
            int group_Id = Convert.ToInt32(XcConvert.IsNull(_view.BindPresDataSource.Rows[_view.RowIndex]["Group_Id"], "0"));
            int next_group_Id = Convert.ToInt32(XcConvert.IsNull(_view.BindPresDataSource.Rows[_view.RowIndex + 1]["Group_Id"], "0"));
            if (_view.RowIndex == _view.BindPresDataSource.Rows.Count - 1 || Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex + 1]["Item_Id"]) <= 0)
            {
                return;
            }
            //更新开始分组号
            if (_view.GroupStartRowIndex == _view.RowIndex)
            {
                _view.GroupStartRowIndex += 1;
            }
            //更新开始分组号
            if (_view.GroupStartRowIndex == _view.RowIndex + 1)
            {
                _view.GroupStartRowIndex -= 1;
            }
            //更换分组号
            if (next_group_Id == 1)
            {
                throw new Exception("下一行为药品分组的第一行，不允许下移");
            }
            else if (group_Id > 0)
            {
                if (next_group_Id == 0)
                {
                    //update by zengyan 2009-9-19 不让改变分组的组成
                    return;
                }
                _view.BindPresDataSource.Rows[_view.RowIndex]["Group_Id"] = group_Id + 1;
                _view.BindPresDataSource.Rows[_view.RowIndex + 1]["Group_Id"] = group_Id;
            }
            //更换行头
            _view.BindPresDataSource.Rows[_view.RowIndex + 1]["TmpNo"] = _view.BindPresDataSource.Rows[_view.RowIndex]["TmpNo"];
            _view.BindPresDataSource.Rows[_view.RowIndex]["TmpNo"] = "";

            //更换序号
            _view.BindPresDataSource.Rows[_view.RowIndex + 1]["OrderNo"] = orderNo;
            _view.BindPresDataSource.Rows[_view.RowIndex]["OrderNo"] = orderNo + 1;

            List<HIS.MZDoc_BLL.IBasePresList> presList = new List<IBasePresList>();
            if ((HIS.MZDoc_BLL.Public.PresStatus)_view.BindPresDataSource.Rows[_view.RowIndex + 1]["Status"] != HIS.MZDoc_BLL.Public.PresStatus.新建状态)
            {
                HIS.MZDoc_BLL.IBasePresList pres = PresListFactory.CreatePresListObject(this.PresListType, _view.BindPresDataSource.Rows[_view.RowIndex + 1]);
                pres.Status = HIS.MZDoc_BLL.Public.PresStatus.修改状态;
                presList.Add(pres);
            }
            if ((HIS.MZDoc_BLL.Public.PresStatus)_view.BindPresDataSource.Rows[_view.RowIndex]["Status"] != HIS.MZDoc_BLL.Public.PresStatus.新建状态)
            {
                HIS.MZDoc_BLL.IBasePresList pres = PresListFactory.CreatePresListObject(this.PresListType, _view.BindPresDataSource.Rows[_view.RowIndex]);
                pres.Status = HIS.MZDoc_BLL.Public.PresStatus.修改状态;
                presList.Add(pres);
            }
            if (presList.Count > 0)
            {
                PresListFactory.CreatePresListObject(this.PresListType).Save(presList);
            }

            #region 重新组织数据源表
            DataTable tmpTable = _view.BindPresDataSource.Clone();
            int currentIndex = _view.RowIndex;

            // 复制该条记录前面所有的行
            for (int i = 0; i < _view.RowIndex; i++)
            {
                tmpTable.Rows.Add(_view.BindPresDataSource.Rows[i].ItemArray);
            }

            //复制当前行和上一行
            tmpTable.Rows.Add(_view.BindPresDataSource.Rows[_view.RowIndex + 1].ItemArray);
            tmpTable.Rows.Add(_view.BindPresDataSource.Rows[_view.RowIndex].ItemArray);

            //复制该条记录后面所有的行
            for (int i = _view.RowIndex + 2; i < _view.BindPresDataSource.Rows.Count; i++)
            {
                tmpTable.Rows.Add(_view.BindPresDataSource.Rows[i].ItemArray);
            }

            _view.BindPresDataSource = tmpTable;
            _view.RowIndex = currentIndex;
            for (int i = 0; i < _view.BindPresDataSource.Rows.Count; i++)
            {
                SetCellColor(i, -1);
            }
            #endregion
        }

        /// <summary>
        /// 开始分组
        /// </summary>
        protected void BeginGroup()
        {
            if (Convert.ToBoolean(_view.BindPresDataSource.Rows[_view.RowIndex]["IsHerb"]) || !Convert.ToBoolean(_view.BindPresDataSource.Rows[_view.RowIndex]["IsDrug"]))
            {
                throw new Exception("对不起，只有西成药才可以进行分组！");
            }

            if (Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex]["Group_Id"]) > 0)
            {
                throw new Exception("对不起，该记录已属于其他分组，如果需要重新分组，请先取消原分组！");
            }

            _view.BindPresDataSource.Rows[_view.RowIndex]["Group_Id"] = 1;
            _view.GroupStartRowIndex = _view.RowIndex;
        }

        /// <summary>
        /// 结束分组
        /// </summary>
        protected void EndGroup()
        {
            if (_view.RowIndex <= _view.GroupStartRowIndex)	//结束分组的序号不能小于开始分组的序号
            {
                throw new Exception("结束分组的序号不能小于开始分组的序号！");
            }
            if (Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex]["Item_Id"]) <= 0)
            {
                throw new Exception("结束行无内容,请重新点击结束分组的行号！");
            }
            if (Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex]["PresNo"]) != Convert.ToInt32(_view.BindPresDataSource.Rows[_view.GroupStartRowIndex]["PresNo"]))
            {
                throw new Exception("不允许跨处方分组,请重新点击开始分组的行号！");
            }
            if (Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex]["Group_Id"]) > 0 && _view.RowIndex - _view.GroupStartRowIndex + 1 != Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex]["Group_Id"]))
            {
                throw new Exception("对不起，该记录已属于其他分组，如果需要重新分组，请先取消原分组！");
            }

            int group_id = 1;
            for (int index = _view.GroupStartRowIndex; index <= _view.RowIndex; index++)
            {
                _view.BindPresDataSource.Rows[index]["Group_Id"] = group_id;
                this.UniteRowValue(_view.GroupStartRowIndex, index);
                if ((HIS.MZDoc_BLL.Public.PresStatus)_view.BindPresDataSource.Rows[index]["Status"] == HIS.MZDoc_BLL.Public.PresStatus.保存状态)
                {
                    _view.BindPresDataSource.Rows[index]["Status"] = HIS.MZDoc_BLL.Public.PresStatus.修改状态;
                }
                group_id++;
            }
            _view.GroupStartRowIndex = -1;
        }

        /// <summary>
        /// 分组
        /// </summary>
        public void Grouping()
        {
            if (_view.GroupStartRowIndex == -1)
            {
                this.BeginGroup();
            }
            else
            {
                this.EndGroup();
            }
        }

        /// <summary>
        /// 取消分组
        /// </summary>
        public void CancelGroup()
        {
            for (int index = _view.RowIndex; index > -1; index--)
            {
                if (Convert.ToInt32(_view.BindPresDataSource.Rows[index]["Group_Id"]) > 1)
                {
                    _view.BindPresDataSource.Rows[index]["Group_Id"] = 0;
                    if ((HIS.MZDoc_BLL.Public.PresStatus)_view.BindPresDataSource.Rows[index]["Status"] == HIS.MZDoc_BLL.Public.PresStatus.保存状态)
                    {
                        _view.BindPresDataSource.Rows[index]["Status"] = HIS.MZDoc_BLL.Public.PresStatus.修改状态;
                    }
                }
                else if (Convert.ToInt32(_view.BindPresDataSource.Rows[index]["Group_Id"]) == 1)
                {
                    _view.BindPresDataSource.Rows[index]["Group_Id"] = 0;
                    if ((HIS.MZDoc_BLL.Public.PresStatus)_view.BindPresDataSource.Rows[index]["Status"] == HIS.MZDoc_BLL.Public.PresStatus.保存状态)
                    {
                        _view.BindPresDataSource.Rows[index]["Status"] = HIS.MZDoc_BLL.Public.PresStatus.修改状态;
                    }
                    break;
                }
            }
            for (int index = _view.RowIndex + 1; index < _view.BindPresDataSource.Rows.Count; index++)
            {
                if (Convert.ToInt32(_view.BindPresDataSource.Rows[index]["Group_Id"]) > 1)
                {
                    _view.BindPresDataSource.Rows[index]["Group_Id"] = 0;
                    if ((HIS.MZDoc_BLL.Public.PresStatus)_view.BindPresDataSource.Rows[index]["Status"] == HIS.MZDoc_BLL.Public.PresStatus.保存状态)
                    {
                        _view.BindPresDataSource.Rows[index]["Status"] = HIS.MZDoc_BLL.Public.PresStatus.修改状态;
                    }
                }
                else if (Convert.ToInt32(_view.BindPresDataSource.Rows[index]["Group_Id"]) == 1)
                {
                    break;
                }
            }
            if (_view.GroupStartRowIndex == _view.RowIndex)
            {
                _view.GroupStartRowIndex = -1;
            }
        }

        /// <summary>
        /// 中药脚注
        /// </summary>
        public void AddFootNote()
        {
            if (Convert.ToBoolean(_view.BindPresDataSource.Rows[_view.RowIndex]["IsHerb"]))
            {
                HIS_MZDocManager.FrmEditFootNote frmEditFootNote = new HIS_MZDocManager.FrmEditFootNote(_view.BindPresDataSource.Rows[_view.RowIndex]["FootNote"].ToString());
                frmEditFootNote.ShowDialog();
                if (frmEditFootNote.IsSure)
                {
                    if ((HIS.MZDoc_BLL.Public.PresStatus)_view.BindPresDataSource.Rows[_view.RowIndex]["Status"] == HIS.MZDoc_BLL.Public.PresStatus.保存状态)
                    {
                        _view.BindPresDataSource.Rows[_view.RowIndex]["Status"] = HIS.MZDoc_BLL.Public.PresStatus.修改状态;
                    }
                    _view.BindPresDataSource.Rows[_view.RowIndex]["FootNote"] = frmEditFootNote.FootNote;
                    _view.BindPresDataSource.Rows[_view.RowIndex]["Item_Name_S"]
                        = _view.BindPresDataSource.Rows[_view.RowIndex]["Item_Name"].ToString()
                        + (frmEditFootNote.FootNote == "" ? "" : "【" + frmEditFootNote.FootNote + "】");
                }
            }
        }
        #endregion

        #region 网格操作
        /// <summary>
        /// 检查处方
        /// </summary>
        /// <param name="presList">处方明细列表</param>
        /// <returns></returns>
        protected void CheckPres(IList presList)
        {
            DataRow[] rows = _view.BindPresDataSource.Select("Item_id>0 and (status=" + HIS.MZDoc_BLL.Public.PresStatus.新建状态.GetHashCode() + " or status=" + HIS.MZDoc_BLL.Public.PresStatus.修改状态.GetHashCode() + ")");
            if (rows == null || rows.Length <= 0)
            {
                throw new Exception("没有需要保存的记录！");
            }
            if (_view.GroupStartRowIndex > -1)
            {
                throw new Exception("存在未结束的分组，请先结束或取消该分组！");
            }
            foreach (HIS.MZDoc_BLL.IBasePresList pres in presList)
            {
                if (pres.Status != HIS.MZDoc_BLL.Public.PresStatus.保存状态)
                {
                    if (pres.IsDrug && pres.StatItem_Code.Trim()!="00") //update by heyan 材料不要判断用法和频次 2010.10.26
                    {
                        if (pres.Usage_Id <= 0)
                        {
                            throw new Exception("药品【" + pres.Item_Name + "】的用法不能为空！");
                        }
                        if (pres.Frequency_Id <= 0)
                        {
                            throw new Exception("药品【" + pres.Item_Name + "】的频次不能为空！");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 检查是否有未保存的处方
        /// </summary>
        /// <returns></returns>
        protected void CheckUnSavePres()
        {
            DataTable dt = _view.BindPresDataSource;
            DataRow[] rows = dt.Select("Item_Id>0 and Status=" + HIS.MZDoc_BLL.Public.PresStatus.新建状态.GetHashCode() + " or Status=" + HIS.MZDoc_BLL.Public.PresStatus.修改状态.GetHashCode());
            if (rows != null && rows.Length > 0)
            {
                throw new Exception("您还有未保存的处方，请先保存！");
            }
        }

        /// <summary>
        /// 设置网格单元格颜色
        /// </summary>
        /// <param name="status"></param>
        /// <param name="rowid"></param>
        /// <param name="colid"></param>
        protected void SetCellColor(int rowid, int colid)
        {
            HIS.MZDoc_BLL.Public.PresStatus status = (HIS.MZDoc_BLL.Public.PresStatus)_view.BindPresDataSource.Rows[rowid]["Status"];
            HIS.MZDoc_BLL.Public.PresColor presColor = new HIS.MZDoc_BLL.Public.PresColor();
            presColor.rowIndex = rowid;
            presColor.colIndex = colid;
            presColor.ForeColor = HIS.MZDoc_BLL.Public.Function.GetPresForeColor(status);
            presColor.BackColor = HIS.MZDoc_BLL.Public.Function.GetPresBackColor(Convert.ToInt32(_view.BindPresDataSource.Rows[rowid]["Item_Id"]), status); 
            _view.CellColor = presColor;
        }

        /// <summary>
        /// 设置网格列只读状态
        /// </summary>
        /// <param name="rowid"></param>
        public void SettingReadOnly(int rowid)
        {
            HIS.MZDoc_BLL.Public.PresCellReadOnly presCellReadOnly = new HIS.MZDoc_BLL.Public.PresCellReadOnly();
            presCellReadOnly.ItemIdReadOnly = true;
            presCellReadOnly.DeptNameReadOnly = true;
            presCellReadOnly.UsageAmountReadOnly = true;
            presCellReadOnly.UsageUnitReadOnly = true;
            presCellReadOnly.DosageReadOnly = true;
            presCellReadOnly.UsageReadOnly = true;
            presCellReadOnly.FrequencyReadOnly = true;
            presCellReadOnly.DaysReadOnly = true;
            presCellReadOnly.ItemAmountReadOnly = true;
            presCellReadOnly.ItemUnitReadOnly = true;
            presCellReadOnly.EntrustReadOnly = true;
            if ((HIS.MZDoc_BLL.Public.PresStatus)(_view.BindPresDataSource.Rows[rowid]["Status"]) != HIS.MZDoc_BLL.Public.PresStatus.新建状态
                && (HIS.MZDoc_BLL.Public.PresStatus)(_view.BindPresDataSource.Rows[rowid]["Status"]) != HIS.MZDoc_BLL.Public.PresStatus.修改状态
                || _view.BindPresDataSource.Rows[rowid]["Item_Name"].ToString() == "小计：")
            {
                //全部设为只读
                _view.CellReadOnly = presCellReadOnly;

            }
            else if (Convert.ToBoolean(_view.BindPresDataSource.Rows[rowid]["IsHerb"]) == true)
            {
                //中药处方
                presCellReadOnly.ItemIdReadOnly = false;
                presCellReadOnly.UsageAmountReadOnly = false;
                presCellReadOnly.UsageUnitReadOnly = false;
                presCellReadOnly.DosageReadOnly = false;
                presCellReadOnly.UsageReadOnly = false;
                presCellReadOnly.FrequencyReadOnly = false;
                presCellReadOnly.EntrustReadOnly = false;
            }
            else if (Convert.ToBoolean(_view.BindPresDataSource.Rows[rowid]["IsDrug"]))
            {
                //药品处方
                presCellReadOnly.ItemIdReadOnly = false;
                presCellReadOnly.UsageAmountReadOnly = false;
                presCellReadOnly.UsageUnitReadOnly = false;
                //presCellReadOnly.DosageReadOnly = false;
                presCellReadOnly.UsageReadOnly = false;
                presCellReadOnly.FrequencyReadOnly = false;
                presCellReadOnly.DaysReadOnly = false;
                presCellReadOnly.ItemAmountReadOnly = false;
                presCellReadOnly.ItemUnitReadOnly = false;
                presCellReadOnly.EntrustReadOnly = false;
            }
            else if (Convert.ToInt32(_view.BindPresDataSource.Rows[rowid]["Item_Id"]) <= 0)
            {
                //新行
                presCellReadOnly.ItemIdReadOnly = false;
                RefreshExeDeptDic(_view.BindPresDataSource.Rows[rowid]);
            }
            else
            {
                //项目
                presCellReadOnly.ItemIdReadOnly = false;
                presCellReadOnly.UsageAmountReadOnly = false;
                presCellReadOnly.UsageUnitReadOnly = false;
                RefreshExeDeptDic(_view.BindPresDataSource.Rows[rowid]);
            }
            _view.CellReadOnly = presCellReadOnly;
            DataRow[] rows = _dataSet.Tables["All_Item_Dictionary_All"].Select(
                    "ITEMID=" + _view.BindPresDataSource.Rows[_view.RowIndex]["Item_Id"] +
                    " and STATITEM_CODE='" + _view.BindPresDataSource.Rows[_view.RowIndex]["StatItem_Code"] +
                    "' and TC_FLAG=" + _view.BindPresDataSource.Rows[_view.RowIndex]["Tc_Flag"]);

            if (rows != null && rows.Length > 0)
            {
                _view.BindPresDataSource.Rows[_view.RowIndex]["IsFloat"] = XcConvert.IsNull(rows[0]["FLOAT_FLAG"], "0") == "1";
                RefreshUnitDic(rows[0]);
            }
        }

        /// <summary>
        /// 更新单位表
        /// </summary>
        /// <param name="row"></param>
        protected void RefreshUnitDic(DataRow row)
        {
            //清空用量单位表
            _dataSet.Tables["Usage_Unit_Dictionary"].Rows.Clear();
            //清空开药单位表
            _dataSet.Tables["Item_Unit_Dictionary"].Rows.Clear();

            //查找单位完整信息
            DataRow[] packRow = _dataSet.Tables["Unit_Dictionary"].Select(HIS.BLL.Tables.yp_unitdic.UNITNAME + "='" + XcConvert.IsNull(row["PACKUNIT"], "") + "'");
            DataRow[] unpickRow = _dataSet.Tables["Unit_Dictionary"].Select(HIS.BLL.Tables.yp_unitdic.UNITNAME + "='" + XcConvert.IsNull(row["UNPICKUNIT"], "") + "'");
            DataRow[] leastRow = _dataSet.Tables["Unit_Dictionary"].Select(HIS.BLL.Tables.yp_unitdic.UNITNAME + "='" + XcConvert.IsNull(row["LEASTUNIT"], "") + "'");
            DataRow[] doseRow = _dataSet.Tables["Unit_Dictionary"].Select(HIS.BLL.Tables.yp_unitdic.UNITNAME + "='" + XcConvert.IsNull(row["DOSEUNIT"], "") + "'");

            //添加用量单位记录
            if (doseRow != null && doseRow.Length > 0 && XcConvert.IsNull(row["STATITEM_CODE"], "01") != "03")
            {
                DataRow usageRow = _dataSet.Tables["Usage_Unit_Dictionary"].NewRow();
                usageRow = HIS.MZDoc_BLL.Public.Function.TransformRow(doseRow[0], usageRow);
                usageRow["Rate"] = Convert.ToDecimal(XcConvert.IsNull(row["DOSENUM"], "1"));
                _dataSet.Tables["Usage_Unit_Dictionary"].Rows.Add(usageRow);
            }

            if (leastRow != null && leastRow.Length > 0)
            {
                DataRow usageRow = _dataSet.Tables["Usage_Unit_Dictionary"].NewRow();
                usageRow = HIS.MZDoc_BLL.Public.Function.TransformRow(leastRow[0], usageRow);
                usageRow["Rate"] = 1;
                _dataSet.Tables["Usage_Unit_Dictionary"].Rows.Add(usageRow);
            }

            //添加开药单位记录
            if (Convert.ToInt32(XcConvert.IsNull(row["UNPICK_FLAG"], "0")) == 1 && unpickRow != null && unpickRow.Length > 0)
            {
                DataRow itemRow = _dataSet.Tables["Item_Unit_Dictionary"].NewRow();
                itemRow = HIS.MZDoc_BLL.Public.Function.TransformRow(unpickRow[0], itemRow);
                itemRow["Rate"] = Convert.ToDecimal(XcConvert.IsNull(row["UNPICKNUM"], "1"));
                _dataSet.Tables["Item_Unit_Dictionary"].Rows.Add(itemRow);
            }

            if (packRow != null && packRow.Length > 0)
            {
                DataRow itemRow = _dataSet.Tables["Item_Unit_Dictionary"].NewRow();
                itemRow = HIS.MZDoc_BLL.Public.Function.TransformRow(packRow[0], itemRow);
                _dataSet.Tables["Item_Unit_Dictionary"].Rows.Add(itemRow);
                itemRow["Rate"] = 1;
            }
        }

        /// <summary>
        /// 更新项目执行科室表
        /// </summary>
        /// <param name="row"></param>
        protected void RefreshExeDeptDic(DataRow row)
        {
            //清空项目执行科室表
            _dataSet.Tables["ExeDept_Dictionary"].Rows.Clear();

            //查找单位完整信息
            DataRow[] rows = null;
            if (Convert.ToInt32(XcConvert.IsNull(row["Tc_Flag"], "0")) == 1)
            {
                rows = _dataSet.Tables["ItemExeDept_Dictionary"].Select(HIS.BLL.Tables.base_item_dept.COMPLEX_ID + "=" + XcConvert.IsNull(row["Service_Item_Id"], "0"));
            }
            else
            {
                rows = _dataSet.Tables["ItemExeDept_Dictionary"].Select(HIS.BLL.Tables.base_item_dept.ITEM_ID + "=" + XcConvert.IsNull(row["Service_Item_Id"], "0"));
            }

            string itemids = "";
            if (rows != null && rows.Length > 0)
            {
                for (int index = 0; index < rows.Length; index++)
                {
                    itemids += rows[index]["Dept_Id"].ToString() + ",";
                }
            }
            if (itemids.Trim() == "")
            {
                itemids += _view.currentDept.DeptID.ToString();
            }

            DataRow[] rowsTemp = _dataSet.Tables["Dept_Dictionary"].Select("Dept_id in(" + itemids + ")");
            if (rowsTemp != null && rowsTemp.Length > 0)
            {
                foreach (DataRow rowTemp in rowsTemp)
                {
                    _dataSet.Tables["ExeDept_Dictionary"].Rows.Add(rowTemp.ItemArray);
                }
            }
        }

        /// <summary>
        /// 换方
        /// </summary>
        protected void ChangePres()
        {
            HIS.MZDoc_BLL.IBasePresList _presList = PresListFactory.CreatePresListObject(this.PresListType, PresHeadId);
            _presList.Item_Name = "小计：";
            _presList.PresNo = Convert.ToInt32(XcConvert.IsNull(_view.BindPresDataSource.Rows[_view.RowIndex]["PresNo"], "1"));
            _presList.OrderNo = Convert.ToInt32(XcConvert.IsNull(_view.BindPresDataSource.Rows[_view.RowIndex]["OrderNo"], "1"));
            _presList.Status = HIS.MZDoc_BLL.Public.PresStatus.新建状态;

            _view.BindPresDataSource.Rows[_view.RowIndex].ItemArray = HIS.MZDoc_BLL.Public.Function.ObjectToDataRow(_presList).ItemArray;
            SetCellColor(_view.RowIndex, -1);
            this.AddRow();
        }

        /// <summary>
        /// 检查处方类型
        /// </summary>
        /// <param name="deptId">执行科室</param>
        /// <param name="statItemCode">大项目代码</param>
        /// <returns></returns>
        protected bool CheckPresType(int deptId, string statItemCode)
        {
            bool currentIsHerb = statItemCode == "03";
            DataRow[] rows = _view.BindPresDataSource.Select("PresNo=" + _view.BindPresDataSource.Rows[_view.RowIndex]["PresNo"] + " and Dept_Id>0 and Dept_Id<>" + deptId);
            if (deptId > 0 && rows != null && rows.Length > 0)
            {
                if (_view.RowIndex < _view.BindPresDataSource.Rows.Count - 1)	//当前行不是最后一行
                {
                    throw new Exception("不允许在非末行更换执行科室！");
                }
                if (MessageBox.Show("执行科室发生变更，是否更换处方？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    return false;
                }
                ChangePres();
            }
            rows = _view.BindPresDataSource.Select("PresNo=" + _view.BindPresDataSource.Rows[_view.RowIndex]["PresNo"] + " and Dept_Id=" + deptId);
            if (rows != null && rows.Length > 0)
            {
                rows = _view.BindPresDataSource.Select("PresNo=" + _view.BindPresDataSource.Rows[_view.RowIndex]["PresNo"] + " and IsHerb=" + true);
                if ((rows != null && rows.Length > 0) != currentIsHerb && _view.RowIndex < _view.BindPresDataSource.Rows.Count - 1)
                {
                    throw new Exception("不允许在非末行更换处方类型！");
                }
            }
            if (_view.RowIndex > 0 && Convert.ToInt32(XcConvert.IsNull(_view.BindPresDataSource.Rows[_view.RowIndex - 1]["Item_Id"], "-1")) > 0)
            {
                int lastDept = Convert.ToInt32(XcConvert.IsNull(_view.BindPresDataSource.Rows[_view.RowIndex - 1]["Dept_Id"], "-1"));

                if (!(lastDept == deptId || lastDept == _view.currentDept.DeptID && deptId <= 0 || lastDept <= 0 && deptId == _view.currentDept.DeptID))
                {
                    if (_view.RowIndex < _view.BindPresDataSource.Rows.Count - 1)	//当前行不是最后一行
                    {
                        throw new Exception("不允许在非末行更换执行科室！");
                    }
                    if (MessageBox.Show("执行科室发生变更，是否更换处方？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        return false;
                    }
                    ChangePres();
                }
                else
                {
                    bool lastIsHerb = Convert.ToBoolean(_view.BindPresDataSource.Rows[_view.RowIndex - 1]["IsHerb"]);

                    if (lastIsHerb != currentIsHerb)
                    {
                        if (_view.RowIndex < _view.BindPresDataSource.Rows.Count - 1)	//当前行不是最后一行
                        {
                            throw new Exception("不允许在非末行更换处方类型！");
                        }
                        if (MessageBox.Show("处方类型发生变更，是否更换处方？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        {
                            return false;
                        }
                        ChangePres();
                    }
                }
            }

            if (_view.RowIndex < _view.BindPresDataSource.Rows.Count - 1 && Convert.ToInt32(XcConvert.IsNull(_view.BindPresDataSource.Rows[_view.RowIndex + 1]["Item_Id"], "-1")) > 0)
            {
                int nextDept = Convert.ToInt32(XcConvert.IsNull(_view.BindPresDataSource.Rows[_view.RowIndex + 1]["Dept_Id"], "-1"));

                if (!(nextDept == deptId || nextDept == _view.currentDept.DeptID && deptId <= 0 || nextDept <= 0 && deptId == _view.currentDept.DeptID))
                {
                    throw new Exception("不允许在非末行更换执行科室！");
                }
                else
                {
                    bool nextIsHerb = Convert.ToBoolean(_view.BindPresDataSource.Rows[_view.RowIndex + 1]["IsHerb"]);
                    if (nextIsHerb != currentIsHerb)
                    {
                        throw new Exception("不允许在非末行更换处方类型！");
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 模板明细信息处理
        /// </summary>
        /// <param name="colid"></param>
        public void MouldProcess(int colid)
        {
            if (colid == _view.ColumnIndex.UsageAmountIndex   //用量
                || colid == _view.ColumnIndex.UsageUnitIndex  //用量单位
                || colid == _view.ColumnIndex.DosageIndex     //剂数
                || colid == _view.ColumnIndex.FrequencyIndex  //频次
                || colid == _view.ColumnIndex.DaysIndex)      //天数
            {
                this.CalculateAmount(_view.RowIndex);
            }

            if (colid == _view.ColumnIndex.DosageIndex        //剂数
                || colid == _view.ColumnIndex.UsageIndex      //用法
                || colid == _view.ColumnIndex.FrequencyIndex  //频次
                || colid == _view.ColumnIndex.DaysIndex)      //天数
            {
                this.UniteValue(_view.RowIndex);
            }
        }

        /// <summary>
        /// 绘制组线
        /// </summary>
        /// <param name="graphics"></param>
        public void PaintGroup(Graphics graphics)
        {
            int penWidth = 2;

            //循环遍历所有记录
            for (int index = 0; index < _view.BindPresDataSource.Rows.Count; index++)
            {
                Color penColer = Color.Black;
                _view.PaintRowIndex = index;
                switch ((HIS.MZDoc_BLL.Public.PresStatus)_view.BindPresDataSource.Rows[index]["Status"])
                {
                    case HIS.MZDoc_BLL.Public.PresStatus.新建状态:
                        penColer = Color.Blue;
                        break;
                    case HIS.MZDoc_BLL.Public.PresStatus.收费状态:
                        penColer = Color.Orange;
                        break;
                    case HIS.MZDoc_BLL.Public.PresStatus.退费状态:
                        penColer = Color.Fuchsia;
                        PaintDelLine(graphics, new Pen(penColer, 1));
                        break;
                    default:
                        break;
                }

                int groupFlag = Convert.ToInt32(_view.BindPresDataSource.Rows[index]["Group_Id"]);
                int nextGroupFlag = index == _view.BindPresDataSource.Rows.Count - 1 ? 0 : Convert.ToInt32(_view.BindPresDataSource.Rows[index + 1]["Group_Id"]);
                if (groupFlag == 1)
                {
                    PaintGroupLine(1, graphics, new Pen(penColer, penWidth));
                }
                else if (groupFlag > 1 && (nextGroupFlag > groupFlag || _view.GroupStartRowIndex >= 0 && index - _view.GroupStartRowIndex + 1 == groupFlag))
                {
                    PaintGroupLine(2, graphics, new Pen(penColer, penWidth));
                }
                else if (groupFlag > 1)
                {
                    PaintGroupLine(3, graphics, new Pen(penColer, penWidth));
                }
            }
        }
        #endregion
    }
}
