using System;
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
    /// 医生模板控制类
    /// </summary>
    public class FrmPreMouldController : BasePresController
    {
        private IFrmPreMouldView _view;

        public FrmPreMouldController(IFrmPreMouldView view)
        {
            _view = view;
            base.View = this._view;
            base.PresListType = HIS.MZDoc_BLL.Public.PresListType.处方模板明细;
            LoadBaseData();
            _view.Initialize(_dataSet);
        }

        #region 模板头操作
        /// <summary>
        /// 加载模板列表
        /// </summary>
        public void LoadMouldList()
        {
            _view.MouldList = new HIS.MZDoc_BLL.PresMouldHead().GetMouldHeadList(_view.MouldLevel, _view.currentDept.DeptID, _view.currentUser.EmployeeID);
        }

        /// <summary>
        /// 新增模板
        /// </summary>
        public void AddMould()
        {
            if (_view.CurrentMould.Mould_Type != 0)
            {
                throw new Exception("模板下面不能再添加任何节点！");
            }
            FrmEditMould form = new FrmEditMould();
            form.OperateType = HIS.MZDoc_BLL.Public.CurrentStatus.新建状态;
            form.ShowDialog();
            if (form.IsSure)
            {
                HIS.MZDoc_BLL.PresMouldHead mould = new HIS.MZDoc_BLL.PresMouldHead();
                mould.P_Id = _view.CurrentMould.PresMouldHeadId;
                mould.Mould_Level = _view.MouldLevel;
                mould.Mould_Name = form.MouldName;
                mould.Mould_Type = form.MouldType;
                mould.Create_Dept = (int)_view.currentDept.DeptID;
                mould.Create_Doc = (int)_view.currentUser.EmployeeID;
                mould.Create_Date = XcDate.ServerDateTime;
                _view.SelectNodeTag = mould.Add();
                LoadMouldList();
            }
        }

        /// <summary>
        /// 修改模板
        /// </summary>
        public void UpdateMould()
        {
            if (_view.CurrentMould.PresMouldHeadId == -1)
            {
                return;
            }
            FrmEditMould form = new FrmEditMould();
            form.OperateType = HIS.MZDoc_BLL.Public.CurrentStatus.修改状态;
            form.MouldName = _view.CurrentMould.Mould_Name;
            form.ShowDialog();
            if (form.IsSure)
            {
                _view.CurrentMould.Mould_Name = form.MouldName;
                _view.CurrentMould.Update();
                _view.SelectNodeTag = _view.CurrentMould.PresMouldHeadId;
                LoadMouldList();
            }
        }

        /// <summary>
        /// 删除模板
        /// </summary>
        public void DeleteMould()
        {
            _view.CurrentMould.Delete();
            LoadMouldList();
        }

        /// <summary>
        /// 加载模板明细
        /// </summary>
        public void LoadMouldContents()
        {
            base.PresHeadId = _view.CurrentMould.PresMouldHeadId;
            _view.BindPresDataSource = _view.CurrentMould.GetMouldContents();
            for (int index = 0; index < _view.BindPresDataSource.Rows.Count; index++)
            {
                HIS.MZDoc_BLL.Public.PresColor presColor = new HIS.MZDoc_BLL.Public.PresColor();
                presColor.rowIndex = index;
                presColor.colIndex = -1;
                presColor.ForeColor = System.Drawing.Color.Black;
                presColor.BackColor = Convert.ToInt32(_view.BindPresDataSource.Rows[index]["Item_Id"]) > 0 ? Color.White : Color.Ivory;
                _view.CellColor = presColor;
            }
            _view.RefreshPres();
        }
        #endregion

        #region 工具栏操作
        /// <summary>
        /// 保存模板明细
        /// </summary>
        public void SaveMouldList()
        {
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
            List<HIS.MZDoc_BLL.PresMouldList> _mouldLists
                = (List<HIS.MZDoc_BLL.PresMouldList>)HIS.MZDoc_BLL.Public.Function.DataRowsToList<HIS.MZDoc_BLL.PresMouldList>(dt.Select("Item_Id>0", "presno,orderno"));
            CheckPres(_mouldLists);
            new HIS.MZDoc_BLL.PresMouldList().Save(_mouldLists);
            LoadMouldContents();
        }

        /// <summary>
        /// 删除模板明细
        /// </summary>
        public void DeleteMouldList()
        {
            List<HIS.MZDoc_BLL.PresMouldList> _mouldLists
                = (List<HIS.MZDoc_BLL.PresMouldList>)HIS.MZDoc_BLL.Public.Function.DataRowsToList<HIS.MZDoc_BLL.PresMouldList>(_view.BindPresDataSource.Select("Item_Id>0", "presno,orderno"));
            new HIS.MZDoc_BLL.PresMouldList().Delete(_mouldLists);
            LoadMouldContents();
        }

        /// <summary>
        /// 全选
        /// </summary>
        public void CheckAll()
        {
            for (int index = 0; index < _view.BindPresDataSource.Rows.Count; index++)
            {
                _view.BindPresDataSource.Rows[index]["Selected"] = true;
            }
        }

        /// <summary>
        /// 反选
        /// </summary>
        public void CheckOther()
        {
            for (int index = 0; index < _view.BindPresDataSource.Rows.Count; index++)
            {
                _view.BindPresDataSource.Rows[index]["Selected"] = !(bool)_view.BindPresDataSource.Rows[index]["Selected"];
            }
        }
        #endregion

        #region 右键菜单操作
        /// <summary>
        /// 删除整张
        /// </summary>
        public void DeletePres()
        {
            this.CheckUnSavePres();
            int presNo = Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex]["PresNo"]);
            for (int index = 0; index < _view.BindPresDataSource.Rows.Count; index++)
            {
                _view.BindPresDataSource.Rows[index]["Selected"] = Convert.ToInt32(_view.BindPresDataSource.Rows[index]["PresNo"]) == presNo;
            }
            DeleteMouldList();
            LoadMouldContents();
        }     
       
        #endregion

        #region 网格操作
        /// <summary>
        /// 写行记录
        /// </summary>
        /// <param name="row"></param>
        private void WriteRowValue(DataRow row)
        {
            #region 对于项目，当上一个行的执行科室是它的可执行科室，则沿用上一行的执行科室
            if (XcConvert.IsNull(row["DRUG_FLAG"], "0") == "0" && _view.RowIndex > 0
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
            // 换方判断
            if (!CheckPresType(Convert.ToInt32(XcConvert.IsNull(row["EXECDEPTCODE"], "-1")), XcConvert.IsNull(row["STATITEM_CODE"], "")))
            {
                return;
            }

            #region 赋值
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
            _view.BindPresDataSource.Rows[_view.RowIndex]["Price"] = Convert.ToDecimal(XcConvert.IsNull(row["sell_price"], "0")) / Convert.ToInt32(XcConvert.IsNull(row["UNPICKNUM"], ""));
            _view.BindPresDataSource.Rows[_view.RowIndex]["RelationNum"] = Convert.ToInt32(XcConvert.IsNull(row["PACKNUM"], "1"));
            _view.BindPresDataSource.Rows[_view.RowIndex]["Unit"] = XcConvert.IsNull(row["PACKUNIT"], "");
            _view.BindPresDataSource.Rows[_view.RowIndex]["Service_Item_Id"] = Convert.ToInt32(XcConvert.IsNull(row["Service_Item_Id"], "-1"));
            _view.BindPresDataSource.Rows[_view.RowIndex]["Tc_Flag"] = Convert.ToInt32(XcConvert.IsNull(row["TC_FLAG"], "0"));
            _view.BindPresDataSource.Rows[_view.RowIndex]["IsDrug"] = XcConvert.IsNull(row["DRUG_FLAG"], "0") == "1";
            _view.BindPresDataSource.Rows[_view.RowIndex]["IsHerb"] = XcConvert.IsNull(row["STATITEM_CODE"], "") == "03";
            _view.BindPresDataSource.Rows[_view.RowIndex]["IsFloat"] = XcConvert.IsNull(row["FLOAT_FLAG"], "0") == "1";

            //设置部分默认值
            _view.BindPresDataSource.Rows[_view.RowIndex]["Usage_Amount_S"] = "1";
            _view.BindPresDataSource.Rows[_view.RowIndex]["Usage_Unit"] = XcConvert.IsNull(row["LEASTUNIT"], "");
            _view.BindPresDataSource.Rows[_view.RowIndex]["Usage_Rate"] = 1;
            _view.BindPresDataSource.Rows[_view.RowIndex]["Dosage_S"] = "1";
            _view.BindPresDataSource.Rows[_view.RowIndex]["Days_S"] = "1";
            _view.BindPresDataSource.Rows[_view.RowIndex]["Item_Amount_S"] = "1";
            _view.BindPresDataSource.Rows[_view.RowIndex]["Item_Unit"] = XcConvert.IsNull(row["UNPICKUNIT"], "");
            _view.BindPresDataSource.Rows[_view.RowIndex]["Item_Rate"] = Convert.ToInt32(XcConvert.IsNull(row["UNPICKNUM"], "1"));
            #endregion

            SetCellColor(_view.RowIndex, -1);
            SettingReadOnly(_view.RowIndex);

            this.CalculateAmount(_view.RowIndex);
            if (Convert.ToBoolean(_view.BindPresDataSource.Rows[_view.RowIndex]["IsHerb"]))
            {
                if (_view.RowIndex>0 && Convert.ToBoolean(_view.BindPresDataSource.Rows[_view.RowIndex - 1]["IsHerb"]))
                {
                    this.UniteHerbValue(_view.RowIndex - 1);
                    _view.BindPresDataSource.Rows[_view.RowIndex]["Dosage"] = _view.BindPresDataSource.Rows[_view.RowIndex - 1]["Dosage"];
                    _view.BindPresDataSource.Rows[_view.RowIndex]["Dosage_S"] = _view.BindPresDataSource.Rows[_view.RowIndex - 1]["Dosage_S"];
                    _view.BindPresDataSource.Rows[_view.RowIndex]["Frequency_Id"] = _view.BindPresDataSource.Rows[_view.RowIndex - 1]["Frequency_Id"];
                    _view.BindPresDataSource.Rows[_view.RowIndex]["Frequency_Name"] = _view.BindPresDataSource.Rows[_view.RowIndex - 1]["Frequency_Name"];
                    _view.BindPresDataSource.Rows[_view.RowIndex]["Usage_Id"] = _view.BindPresDataSource.Rows[_view.RowIndex - 1]["Usage_Id"];
                    _view.BindPresDataSource.Rows[_view.RowIndex]["Usage_Name"] = _view.BindPresDataSource.Rows[_view.RowIndex - 1]["Usage_Name"];
                }
                else if (_view.RowIndex<_view.BindPresDataSource.Rows.Count-1 && Convert.ToBoolean(_view.BindPresDataSource.Rows[_view.RowIndex + 1]["IsHerb"]))
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
        /// 修改选中状态
        /// </summary>
        public void ChangeSelected()
        {
            _view.BindPresDataSource.Rows[_view.RowIndex]["Selected"] = !(bool)_view.BindPresDataSource.Rows[_view.RowIndex]["Selected"];
            if (Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex]["Group_Id"]) > 0)
            {
                if (Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex]["Group_Id"]) > 1)
                {
                    for (int index = _view.RowIndex - 1; index > -1; index--)
                    {
                        if (Convert.ToInt32(_view.BindPresDataSource.Rows[index]["Group_Id"]) >= 1)
                        {
                            _view.BindPresDataSource.Rows[index]["Selected"] = _view.BindPresDataSource.Rows[_view.RowIndex]["Selected"];
                        }
                        if (Convert.ToInt32(_view.BindPresDataSource.Rows[index]["Group_Id"]) == 1)
                        {
                            break;
                        }
                    }
                }
                for (int index = _view.RowIndex + 1; index < _view.BindPresDataSource.Rows.Count; index++)
                {
                    if (Convert.ToInt32(_view.BindPresDataSource.Rows[index]["Group_Id"]) > 1)
                    {
                        _view.BindPresDataSource.Rows[index]["Selected"] = _view.BindPresDataSource.Rows[_view.RowIndex]["Selected"];
                    }
                    else if (Convert.ToInt32(_view.BindPresDataSource.Rows[index]["Group_Id"]) == 1)
                    {
                        break;
                    }
                }
            }
            if (_view.CheckPres)
            {
                for (int index = 0; index < _view.BindPresDataSource.Rows.Count; index++)
                {
                    if (Convert.ToInt32(_view.BindPresDataSource.Rows[index]["PresNo"]) == Convert.ToInt32(_view.BindPresDataSource.Rows[_view.RowIndex]["PresNo"]))
                    {
                        _view.BindPresDataSource.Rows[index]["Selected"] = _view.BindPresDataSource.Rows[_view.RowIndex]["Selected"];
                    }
                }
            }
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
                    || _view.RowIndex < _view.BindPresDataSource.Rows.Count-1
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
                this.MouldProcess(colid);
            }
            if (colid == _view.ColumnIndex.UsageIndex)       //用法
            {
                dt.Rows[_view.RowIndex]["Usage_Id"] = XcConvert.IsNull(row["Id"], "-1");
                dt.Rows[_view.RowIndex]["Usage_Name"] = XcConvert.IsNull(row["Name"], "");
                this.MouldProcess(colid);
            }
            if (colid == _view.ColumnIndex.FrequencyIndex)   //频次
            {
                dt.Rows[_view.RowIndex]["Frequency_Id"] = XcConvert.IsNull(row["Id"], "-1");
                dt.Rows[_view.RowIndex]["Frequency_Name"] = XcConvert.IsNull(row["Name"], "");
                dt.Rows[_view.RowIndex]["Frequency_ExecNum"] = XcConvert.IsNull(row["ExecNum"], "1");
                dt.Rows[_view.RowIndex]["Frequency_CycleDay"] = XcConvert.IsNull(row["CycleDay"], "");
                this.MouldProcess(colid);
            }
            if (colid == _view.ColumnIndex.ItemUnitIndex)    //开药单位
            {
                dt.Rows[_view.RowIndex]["Item_Unit"] = XcConvert.IsNull(row["UNITNAME"], "");
                dt.Rows[_view.RowIndex]["Item_Unit_S"] = XcConvert.IsNull(row["UNITNAME"], "");
                dt.Rows[_view.RowIndex]["Price"] = (Convert.ToDecimal(dt.Rows[_view.RowIndex]["Price"]) * Convert.ToInt32(dt.Rows[_view.RowIndex]["Item_Rate"])) / Convert.ToInt32(XcConvert.IsNull(row["Rate"], "1"));
                dt.Rows[_view.RowIndex]["Item_Rate"] = XcConvert.IsNull(row["Rate"], "1");
            }
            if (colid == _view.ColumnIndex.EntrustIndex)     //嘱托
            {
                dt.Rows[_view.RowIndex]["Entrust"] = XcConvert.IsNull(row["Name"], "");
            }
        }
        #endregion
    }
}
