using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.SYSTEM.BussinessLogicLayer.Classes;

namespace HIS.YP_BLL.PrintCenter
{
    /// <summary>
    /// 住院摆药单打印类
    /// </summary>
    class ZYSinglePrint:YP_Printer
    {
        /// <summary>
        /// 打印住院摆药单据
        /// </summary>
        /// <param name="billMaster">单据表头</param>
        /// <param name="billOrder">单据明细</param>
        /// <param name="path">报表文件路径</param>
        /// <param name="Printer">打印人员</param>
        public override void PrintBill(HIS.Model.BillMaster billMaster, System.Data.DataTable billOrder, string path, int Printer)
        {
            //if (billMaster == null)
            //{
            //    return;
            //}
            //HIS.Model.YP_DRMaster printMaster = (HIS.Model.YP_DRMaster)billMaster;
            //billOrder = BillFactory.GetQuery(ConfigManager.OP_YF_DISPENSE).LoadOrder(billMaster);
            //HIS.Interface.IZY_Data zyInterFace = new HIS.Interface.ZY_Data();
            //billOrder=zyInterFace
            //if (billOrder.Rows.Count > 0)
            //{
            //    _printOrder = billOrder;
            //    report = new grproLib.GridppReport();
            //    report.LoadFromFile(path);
            //    report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(report_FetchRecord);
            //    report.ParameterByName("CureNo").AsString = printMaster.InpatientID.ToString();
            //    report.ParameterByName("UserName").AsString = BaseData.GetUserName(printMaster.OPPeopleID);
            //    report.ParameterByName("ExeTime").AsDateTime = printMaster.OPTime;
            //    report.ParameterByName("PatientName").AsString = printMaster.PatientName;
            //    report.ParameterByName("HospitalName").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
            //    report.ParameterByName("PrintTime").AsDateTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
            //    report.ParameterByName("Printer").AsString = BaseData.GetUserName(Printer);
            //    report.PrintPreview(false);
            //}
            if (billMaster == null)
            {
                if (billOrder == null)
                {
                    return;
                }
                if (billOrder.Rows.Count > 0)
                {
                    HIS.Model.ZY_PatList patlist = HIS.SYSTEM.Core.BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).GetModel(Convert.ToInt32(billOrder.Rows[0]["patlistid"]));
                    _printOrder = billOrder;
                    //for (int i = 0; i < _printOrder.Rows.Count; i++)
                    //{
                    //    decimal presamount =( _printOrder.Rows[i]["presamount"] == null || _printOrder.Rows[i]["presamount"].ToString() == "0" ? 1 : Convert.ToDecimal(_printOrder.Rows[i]["presamount"].ToString()));
                    //    _printOrder.Rows[i]["amount"] = Convert.ToDecimal(_printOrder.Rows[i]["amount"].ToString()) / presamount;
                    //}
                    report = new grproLib.GridppReport();
                    report.LoadFromFile(path);
                    report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(report_FetchRecord);
                    report.ParameterByName("CureNo").AsString = patlist.CureNo;
                    report.ParameterByName("UserName").AsString = BaseData.GetUserName(Printer);
                    //report.ParameterByName("ExeTime").AsDateTime = printMaster.OPTime;
                    report.ParameterByName("PatientName").AsString = patlist.PatientInfo.PatName;
                    report.ParameterByName("HospitalName").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
                    report.ParameterByName("PrintTime").AsDateTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                    report.ParameterByName("Printer").AsString = BaseData.GetUserName(Printer);
                    report.ParameterByName("总金额").AsString =Convert.ToDecimal( _printOrder.Compute("sum(tolal_fee)","")).ToString("0.00")+" 元";
                    report.ParameterByName("病人科室").AsString =BaseData.GetDeptName( patlist.CurrDeptCode);
                    report.ParameterByName("开方医生").AsString=billOrder.Rows[0]["presdocname"].ToString();
                    report.PrintPreview(false);
                }
            }
            else
            {
                HIS.Model.YP_DRMaster printMaster = (HIS.Model.YP_DRMaster)billMaster;
                billOrder = BillFactory.GetQuery(ConfigManager.OP_YF_DISPENSE).LoadOrder(billMaster);             
                if (billOrder.Rows.Count > 0)
                {
                    _printOrder = billOrder;
                    for (int i = 0; i < _printOrder.Rows.Count; i++)
                    {
                        decimal presamount =( _printOrder.Rows[i]["recipenum"] == null || _printOrder.Rows[i]["recipenum"].ToString()=="0" ? 1 : Convert.ToDecimal(_printOrder.Rows[i]["recipenum"].ToString()));
                        _printOrder.Rows[i]["drugocnum"] =Convert.ToDecimal( _printOrder.Rows[i]["drugocnum"].ToString()) / presamount;
                    }
                        report = new grproLib.GridppReport();
                    report.LoadFromFile(path);
                    report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(report_FetchRecord);
                    report.ParameterByName("CureNo").AsString = printMaster.InpatientID.ToString();
                    report.ParameterByName("UserName").AsString = BaseData.GetUserName(printMaster.OPPeopleID);
                    report.ParameterByName("ExeTime").AsDateTime = printMaster.OPTime;
                    report.ParameterByName("PatientName").AsString = printMaster.PatientName;
                    report.ParameterByName("HospitalName").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
                    report.ParameterByName("PrintTime").AsDateTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                    report.ParameterByName("Printer").AsString = BaseData.GetUserName(Printer);
                    report.ParameterByName("总金额").AsString =Convert.ToDecimal( _printOrder.Compute("sum(retailfee)","")).ToString("0.00") + " 元";

                    report.PrintPreview(false);
                }
            }
        }

       
        /// <summary>
        /// 打印摆药单据
        /// </summary>
        /// <param name="printCondition">打印头信息</param>
        /// <param name="orderDt">打印明细</param>
        /// <param name="path">报表路径</param>
        public override void PrintReport(YP_PrintCondition printCondition, System.Data.DataTable orderDt, string path)
        {
            if (orderDt == null)
            {
                return;
            }
            if (orderDt.Rows.Count > 0)
            {
                HIS.Interface.IZY_Data zyInterFace = new HIS.Interface.ZY_Data();
                _printOrder = new DataTable();
                DateTime currentTime = XcDate.ServerDateTime;
                _printOrder.Columns.Add("OrderContents", Type.GetType("System.String"));
                _printOrder.Columns.Add("PatName", Type.GetType("System.String"));
                _printOrder.Columns.Add("PatAge", Type.GetType("System.String"));
                _printOrder.Columns.Add("BedNo", Type.GetType("System.String"));
                _printOrder.Columns.Add("OrderId", Type.GetType("System.Int32"));
                _printOrder.Columns.Add("ChargeDate", Type.GetType("System.DateTime"));
                _printOrder.Columns.Add("UnitName", Type.GetType("System.String"));
                _printOrder.Columns.Add("CureNo", Type.GetType("System.String"));
                _printOrder.Columns.Add("DrugNum", Type.GetType("System.Decimal"));
                _printOrder.Columns.Add("PresDeptName", Type.GetType("System.String"));
                _printOrder.Columns.Add("SortNum", Type.GetType("System.Int32"));
                _printOrder.PrimaryKey = new DataColumn[] { _printOrder.Columns["OrderId"], _printOrder.Columns["CureNo"] };
                //如果只打口服摆药单
                if (printCondition.drugType == "口服药")
                {
                    for (int index = 0; index < orderDt.Rows.Count; index++)
                    {
                        //按医嘱ID获取用法对应执行单表
                        DataTable useTypeDt = zyInterFace.GetUseType(Convert.ToInt32(orderDt.Rows[index]["docorderid"]));                        if (useTypeDt != null)
                        {
                            //如果是口服药
                            if (useTypeDt.Select("TYPE_NAME='服药单'").Count() == 0)
                            {
                                orderDt.Rows[index]["ISDISPENSE"] = 0;
                            }
                        }
                    }
                }
                for (int index = 0; index < orderDt.Rows.Count; index++)
                {
                    DataRow currentRow = orderDt.Rows[index];
                    if (currentRow["ISDISPENSE"] == DBNull.Value)
                    {
                        continue;
                    }
                    if (Convert.ToInt32(currentRow["ISDISPENSE"]) == 0)
                    {
                        continue;
                    }
                    DataRow findRow = _printOrder.Rows.Find(new object[] { currentRow["docorderid"], currentRow["cureno"] });
                    if (findRow != null)
                    {
                        findRow["DrugNum"] = Convert.ToDecimal(findRow["DrugNum"])
                            + Convert.ToDecimal(currentRow["DrugNum"]);
                    }
                    else
                    {
                        DataRow newRow = _printOrder.NewRow();
                        newRow["OrderContents"] = zyInterFace.GetDocOrderInfo(Convert.ToInt32(currentRow["docorderid"]));
                        newRow["PatName"] = currentRow["patname"];
                        string bedNo = currentRow["bedno"].ToString();
                        newRow["SortNum"] = Convert.ToInt32(bedNo.Replace("加", "100").ToString());
                        newRow["BedNo"] = bedNo;
                        newRow["OrderId"] = currentRow["docorderid"];
                        newRow["ChargeDate"] = currentRow["chargedate"];
                        newRow["UnitName"] = currentRow["unitname"];
                        newRow["CureNo"] = currentRow["cureno"];
                        newRow["DrugNum"] = currentRow["drugnum"];
                        newRow["PresDeptName"] = currentRow["presdeptname"];
                        newRow["PatAge"] = zyInterFace.GetPatAge(newRow["CureNo"].ToString(), currentTime);
                        _printOrder.Rows.Add(newRow);
                    }
                }
                DataRow[] dRows = _printOrder.Select("", "SortNum");
                DataTable newDt = _printOrder.Clone();
                foreach (DataRow dRow in dRows)
                {
                    newDt.Rows.Add(dRow.ItemArray);
                }
                _printOrder = newDt;
                if (_printOrder.Rows.Count > 0)
                {
                    report = new grproLib.GridppReport();
                    report.LoadFromFile(path);
                    report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(report_FetchRecord);
                    string type = "";
                    switch (printCondition.queyType)
                    {
                        case 0:
                            type = "长期";
                            break;
                        case 1:
                            type = "临时";
                            break;
                        default:
                            break;
                    }
                    report.ParameterByName("HospitalName").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName
                            + type + "住院药品摆药单";
                    report.ParameterByName("PrintTime").AsDateTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                    report.ParameterByName("Printer").AsString = BaseData.GetUserName(printCondition.userId);
                    report.PrintPreview(false);
                }
            }
        }
    }
}
