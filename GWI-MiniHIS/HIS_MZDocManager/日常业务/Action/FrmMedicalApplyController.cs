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
using grproLib;

namespace HIS_MZDocManager.Action
{
    /// <summary>
    /// 医生模板控制类
    /// </summary>
    public class FrmMedicalApplyController
    {
        private IFrmMedicalApplyView _view;
        private DataSet _dataSet = new DataSet();

        public FrmMedicalApplyController(IFrmMedicalApplyView view)
        {
            _view = view;
            LoadBaseData();
        }

        public void LoadBaseData()
        {
            DataTable tb = HIS.MZDoc_BLL.OP_ReadBaseData.GetSampleData();
            tb.TableName = "Sample_Dictionary";
            _dataSet.Tables.Add(tb);

            tb = HIS.MZDoc_BLL.OP_ReadBaseData.GetParamData();
            tb.TableName = "Param_Dictionary";
            _dataSet.Tables.Add(tb);

            tb = HIS.MZDoc_BLL.OP_ReadBaseData.GetPlaceData();
            tb.TableName = "Place_Dictionary";
            _dataSet.Tables.Add(tb);

            _view.InitializeApply(_dataSet);
        }

        public void RefreshMedicalItemData()
        {
            HIS.MZDoc_BLL.BaseMedical medical = HIS.MZDoc_BLL.MedicalApplyFactory.CreateMedicalApplyObject(_view.CurrentApplyType);
            medical.LoadMedicalItem(_dataSet);
            //DataRow[] rows = dataSource.Select("DRUG_FLAG=0");
            //_dataSet.Tables["MedicalItem"].Rows.Clear();
            //foreach (DataRow row in rows)
            //{
            //    _dataSet.Tables["MedicalItem"].Rows.Add(row.ItemArray);
            //}
        }

        /// <summary>
        /// 计算金额
        /// </summary>
        /// <param name="rowNo"></param>
        private decimal CalculateMoney(DataRow[] rows)
        {
            decimal item_money = 0;
            for (int index = 0; index < rows.Length; index++)
            {
                item_money = item_money + Convert.ToDecimal(rows[index]["Price"]) * Convert.ToInt32(rows[index]["Num"]);
            }
            return item_money;
        }

        /// <summary>
        /// 显示状态栏金额提示值
        /// </summary>
        private void ShowItemMoneyStatus()
        {
            if (_view.SelecedMecicalItems == null)
                return;

            if (_view.SelecedMecicalItems.Rows.Count == 0)
            {
                _view.ItemMoneyStatus = "未保存：￥0.00元  保存未收费：￥0.00元  已收费：￥0.00元  总合计：￥0.00元";
            }
            else
            {
                decimal newMoney = CalculateMoney(_view.SelecedMecicalItems.Select("Item_Id>0 and Status=" + HIS.MZDoc_BLL.Public.PresStatus.新建状态.GetHashCode()));
                decimal saveMoney = CalculateMoney(_view.SelecedMecicalItems.Select("Item_Id>0 and Status=" + HIS.MZDoc_BLL.Public.PresStatus.保存状态.GetHashCode()));
                decimal chargeMoney = CalculateMoney(_view.SelecedMecicalItems.Select("Item_Id>0 and Status=" + HIS.MZDoc_BLL.Public.PresStatus.收费状态.GetHashCode()));
                decimal tatolMoney = CalculateMoney(_view.SelecedMecicalItems.Select("Item_Id>0"));
                _view.ItemMoneyStatus = "未保存：￥" + newMoney.ToString("0.00") + "元  保存未收费：￥" + saveMoney.ToString("0.00") + "元  已收费：￥"
                    + chargeMoney.ToString("0.00") + "元  总合计：￥" + tatolMoney.ToString("0.00") + "元";
            }
        }

        /// <summary>
        /// 加载医技申请列表
        /// </summary>
        public void LoadApplyList()
        {
            _view.SelecedMecicalItems = _view.CurrentPatient.GetCurrentMedicalApplyList(_view.CurrentApplyType);
            for (int index = 0; index < _view.SelecedMecicalItems.Rows.Count; index++)
            {
                SetCellColor(index, -1);
            }
            ShowItemMoneyStatus();
        }

        /// <summary>
        /// 加载科室数据
        /// </summary>
        public void LoadMedicalDept()
        {
            HIS.MZDoc_BLL.BaseMedical medical = HIS.MZDoc_BLL.MedicalApplyFactory.CreateMedicalApplyObject(_view.CurrentApplyType);
            _view.MecicalDept = medical.LoadMedicalDept(_dataSet);
            //LoadApplyList();
        }

        /// <summary>
        /// 加载项目类型
        /// </summary>
        public void LoadMedicalClass()
        {
            HIS.MZDoc_BLL.BaseMedical medical = HIS.MZDoc_BLL.MedicalApplyFactory.CreateMedicalApplyObject(_view.CurrentApplyType);
            _view.MecicalClass = medical.LoadMedicalClass(_dataSet,_view.CurrentMecicalDept);
            //LoadApplyList();
        }

        /// <summary>
        /// 加载医技项目列表
        /// </summary>
        public void LoadMedicalItem()
        {
            HIS.MZDoc_BLL.BaseMedical medical = HIS.MZDoc_BLL.MedicalApplyFactory.CreateMedicalApplyObject(_view.CurrentApplyType);
            _view.MecicalItem = (List<HIS.MZDoc_BLL.Medical_Order_Item>)HIS.MZDoc_BLL.Public.Function.DataTableToList<HIS.MZDoc_BLL.Medical_Order_Item>(medical.LoadMedicalItem(_dataSet, _view.CurrentMecicalDept, _view.CurrentMecicalClass));
            LoadApplyList();
        }

        /// <summary>
        /// 显示已选项目列表
        /// </summary>
        public void SelectMedicalItem()
        {
            DataTable table = _view.SelecedMecicalItems.Copy();
            for (int index = 0; index < table.Rows.Count; index++)
            {
                if ((HIS.MZDoc_BLL.Public.PresStatus)table.Rows[index]["Status"] == HIS.MZDoc_BLL.Public.PresStatus.新建状态)
                {
                    bool isExsit = false;
                    foreach (HIS.MZDoc_BLL.Medical_Order_Item item in _view.CurrentMecicalItems)
                    {
                        if (Convert.ToInt32(table.Rows[index]["Item_Id"]) == item.Order_Id)
                        {
                            isExsit = true;
                            break;
                        }
                    }
                    if (!isExsit)
                    {
                        table.Rows[index]["Status"] = HIS.MZDoc_BLL.Public.PresStatus.删除状态;
                    }
                }
            } 
            foreach (HIS.MZDoc_BLL.Medical_Order_Item item in _view.CurrentMecicalItems)
            {
                bool isExsit = false;
                for (int index = 0; index < table.Rows.Count; index++)
                {
                    if ((HIS.MZDoc_BLL.Public.PresStatus)table.Rows[index]["Status"] == HIS.MZDoc_BLL.Public.PresStatus.新建状态)
                    {
                        if (Convert.ToInt32(table.Rows[index]["Item_Id"]) == item.Order_Id)
                        {
                            isExsit = true;
                            break;
                        }
                    }
                }
                if (!isExsit)
                {
                    BaseMedical medical = MedicalApplyFactory.CreateMedicalApplyObject(_view.CurrentApplyType);
                    medical.CreateApply(item);
                    DataRow row = HIS.MZDoc_BLL.Public.Function.ObjectToDataRow(medical);
                    table.Rows.Add(row.ItemArray);
                }
            }
            int i = 0;
            while (i < table.Rows.Count)
            {
                if ((HIS.MZDoc_BLL.Public.PresStatus)table.Rows[i]["Status"] == HIS.MZDoc_BLL.Public.PresStatus.删除状态)
                {
                    table.Rows.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
            _view.SelecedMecicalItems = table;
            if (table.Rows.Count > 0)
            {
                _view.ApplyRowIndex = table.Rows.Count - 1;
            }
            for (int index = 0; index < _view.SelecedMecicalItems.Rows.Count; index++)
            {
                SetCellColor(index, -1);
            }
            ShowItemMoneyStatus();
    }

        /// <summary>
        /// 显示所选项目信息
        /// </summary>
        public void ViewMedicalItem()
        {
            if (_view.ApplyRowIndex >= 0)
            {
                _view.CurrentMedicalApply = HIS.MZDoc_BLL.MedicalApplyFactory.CreateMedicalApplyObject(
                    _view.CurrentApplyType, _view.SelecedMecicalItems.Rows[_view.ApplyRowIndex]);
            }        
        }

        /// <summary>
        /// 修改所选项目信息
        /// </summary>
        public void ChangeMedicalItem()
        {
            BaseMedical medicalApply = _view.CurrentMedicalApply; 
            if (medicalApply.Status == HIS.MZDoc_BLL.Public.PresStatus.保存状态)
            {
                medicalApply.Status = HIS.MZDoc_BLL.Public.PresStatus.修改状态;
            }
            if (_view.ApplyRowIndex >= 0 && (medicalApply.Status == HIS.MZDoc_BLL.Public.PresStatus.新建状态 || medicalApply.Status == HIS.MZDoc_BLL.Public.PresStatus.修改状态))
            {
                SetCellColor(_view.ApplyRowIndex, -1);
                _view.SelecedMecicalItems.Rows[_view.ApplyRowIndex].ItemArray = HIS.MZDoc_BLL.Public.Function.ObjectToDataRow(medicalApply).ItemArray;
            }
        }

        /// <summary>
        /// 保存医技申请
        /// </summary>
        /// <returns></returns>
        public bool SaveMedicalApply()
        {
            DataRow[] rows = _view.SelecedMecicalItems.Select("Status=" + HIS.MZDoc_BLL.Public.PresStatus.新建状态.GetHashCode() + " or Status=" + HIS.MZDoc_BLL.Public.PresStatus.修改状态.GetHashCode());
            if (rows != null && rows.Length > 0 && _view.CurrentPatient.SaveMedicalApply(HIS.MZDoc_BLL.MedicalApplyFactory.CreateMedicalApplyObject(_view.CurrentApplyType, rows)))
            {
                MessageBox.Show("保存成功！", "提示");
                LoadApplyList();
                return true;
            }
            return false;
        }

        /// <summary>
        /// 设置网格单元格颜色
        /// </summary>
        /// <param name="status"></param>
        /// <param name="rowid"></param>
        /// <param name="colid"></param>
        private void SetCellColor(int rowid, int colid)
        {
            HIS.MZDoc_BLL.Public.PresStatus status = (HIS.MZDoc_BLL.Public.PresStatus)_view.SelecedMecicalItems.Rows[rowid]["Status"];
            HIS.MZDoc_BLL.Public.PresColor presColor = new HIS.MZDoc_BLL.Public.PresColor();
            presColor.rowIndex = rowid;
            presColor.colIndex = colid;
            presColor.ForeColor = HIS.MZDoc_BLL.Public.Function.GetPresForeColor(status);
            presColor.BackColor = HIS.MZDoc_BLL.Public.Function.GetPresBackColor(1, status);
            _view.ApplyCellColor = presColor;
        }

        /// <summary>
        /// 修改选中状态
        /// </summary>
        public void ChangeSelected()
        {
            _view.SelecedMecicalItems.Rows[_view.ApplyRowIndex]["Selected"] 
                = !(bool)_view.SelecedMecicalItems.Rows[_view.ApplyRowIndex]["Selected"]&&(_view.CurrentMedicalApply.Status == HIS.MZDoc_BLL.Public.PresStatus.新建状态 
                || _view.CurrentMedicalApply.Status== HIS.MZDoc_BLL.Public.PresStatus.保存状态);
        }

        /// <summary>
        /// 获得打印参数
        /// </summary>
        /// <param name="apply"></param>
        /// <returns></returns>
        private List<FormSite.PrintParameter> GetPrintParameter(HIS.MZDoc_BLL.BaseMedical apply)
        {
            FormSite.FormatPanel control = new FormSite.FormatPanel(apply.Apply_Content);
            if (control.Controls.Count == 0)
            {
                control = new FormSite.FormatPanel(HIS.MZDoc_BLL.OP_ReadBaseData.GetMedicalApplyXmlDocument(apply.Medical_Class));
            }
            switch (apply.Apply_Type)
            {
                case 0:
                    control.SetElementValue("Purpose", apply.Item_Name);
                    break;
                case 2:
                    control.SetElementValue("Num", apply.Num.ToString());
                    break;
                default:
                    break;
            }
            return control.PrintParameters;
        }

        /// <summary>
        /// 单个类型的医技申请打印
        /// </summary>
        /// <param name="applys">申请列表</param>
        public void ApplyPrint(List<HIS.MZDoc_BLL.BaseMedical> applys)
        {
            try
            {
                GridppReport report = new GridppReport();
                report.LoadFromFile(Constant.ApplicationDirectory + "\\report\\门诊_" + HIS.MZDoc_BLL.OP_ReadBaseData.GetMedicalClassName(applys[0].Medical_Class) + "申请单.grf");

                report.ParameterByName("医院名称").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
                report.ParameterByName("申请科室").AsString = _view.currentDept.Name;
                report.ParameterByName("申请医生").AsString = _view.currentUser.Name;
                report.ParameterByName("申请时间").AsString = _view.CurrentMedicalApply.Apply_Date.ToLongDateString() + " " + _view.CurrentMedicalApply.Apply_Date.ToLongTimeString();
                report.ParameterByName("病人姓名").AsString = _view.CurrentPatient.PatList.PatName;
                report.ParameterByName("病人年龄").AsString = _view.CurrentPatient.PatList.Age.ToString() + _view.CurrentPatient.PatList.HpGrade;
                report.ParameterByName("病人性别").AsString = _view.CurrentPatient.PatList.PatSex;
                report.ParameterByName("门诊号").AsString = _view.CurrentPatient.PatList.VisitNo;
                report.ParameterByName("诊断").AsString = _view.CurrentPatient.PatList.DiseaseName;

                string itemNames = "";
                List<HIS.MZDoc_BLL.Prescription> presDetails = new List<HIS.MZDoc_BLL.Prescription>();
                List<FormSite.PrintParameter> printParameter = GetPrintParameter(applys[0]);
                for (int index = 0; index < applys.Count; index++)
                {
                    itemNames += applys[index].Item_Name + ",";
                    HIS.MZDoc_BLL.Prescription pres = new Prescription();
                    pres.StatItem_Code = applys[index].StatItem_Code;
                    pres.Item_Money = (applys[index].Price * applys[index].Num).ToString("0.0000");
                    presDetails.Add(pres);

                    List<FormSite.PrintParameter> subPrintParameter = GetPrintParameter(applys[index]);
                    foreach (FormSite.PrintParameter parameter in printParameter)
                    {
                        foreach (FormSite.PrintParameter subParameter in subPrintParameter)
                        {
                            if (parameter.Name == subParameter.Name)
                            {
                                if (parameter.Value.IndexOf(subParameter.Value.Trim())<0)
                                {
                                    if (parameter.Value.Trim().Length == 0)
                                    {
                                        parameter.Value = subParameter.Value.Trim();
                                    }
                                    else
                                    {
                                        parameter.Value = parameter.Value.Trim()+","+subParameter.Value.Trim();
                                    }
                                }
                            }
                        }
                    }
                }
                if (itemNames.Trim() != "")
                {
                    itemNames = itemNames.Substring(0, itemNames.Length - 1);
                }
                report.ParameterByName("项目名称").AsString = itemNames;
                report.ParameterByName("项目金额").AsString = new HIS.MZDoc_BLL.InterFace.PrescMoneyCalculateInterFace().GetPrescriptionTotalMoney(presDetails).ToString("0.00");//itemMoney.ToString("0.00");

                for (int index = 0; index < printParameter.Count; index++)
                {
                    report.ParameterByName(printParameter[index].Name).AsString = printParameter[index].Value;
                }
                report.PrintPreview(false);
            }
            catch
            {
                MessageBox.Show("申请单打印模板文件设置出错！", "提示");
            }
        }

        /// <summary>
        /// 医技申请打印
        /// </summary>
        public void ApplyPrint()
        {
            if (_view.SelecedMecicalItems == null || _view.SelecedMecicalItems.Rows.Count <= 0 || _view.CurrentMedicalApply == null)
            {
                return;
            }

            DataRow[] rows = _view.SelecedMecicalItems.Select("Status<>"+(int)HIS.MZDoc_BLL.Public.PresStatus.新建状态+" and Selected=" + true);
            if (rows != null && rows.Length > 0)
            {
                IList applys = HIS.MZDoc_BLL.MedicalApplyFactory.CreateMedicalApplyObject(_view.CurrentApplyType, rows);

                int index = 0;
                List<HIS.MZDoc_BLL.BaseMedical> subApplys = new List<BaseMedical>();
                while (applys.Count > 0)
                {
                    if (subApplys.Count == 0)
                    {
                        subApplys = new List<BaseMedical>();
                        subApplys.Add((BaseMedical)applys[index]);
                        applys.RemoveAt(index);
                    }
                    else if (subApplys[subApplys.Count - 1].Medical_Class == ((BaseMedical)applys[index]).Medical_Class)
                    {
                        subApplys.Add((BaseMedical)applys[index]);
                        applys.RemoveAt(index);
                    }
                    else
                    {
                        index++;
                    }
                    if (index >= applys.Count)
                    {
                        if (subApplys != null && subApplys.Count > 0)
                        {
                            ApplyPrint(subApplys);
                        }
                        index = 0;
                        subApplys = new List<BaseMedical>();
                    }
                }
            }
            else
            {
                throw new Exception("没有可以打印的申请！");
            }
        }

        /// <summary>
        /// 加载医技申请列表
        /// </summary>
        /// <param name="bDate">开始时间</param>
        /// <param name="eDate">结束时间</param>
        public void LoadMedicalApplyList(DateTime bDate,DateTime eDate)
        {
            _view.MedicalApplyList = _view.CurrentPatient.GetMedicalApplyReportList(bDate.Date, eDate.Date.AddDays(1));
        }
    }
}
