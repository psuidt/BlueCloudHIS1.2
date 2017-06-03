using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.BLL;
using HIS.Interface.Structs;
using grproLib;

namespace HIS.Interface
{
    public class MZ_Data : BaseBLL, IMZ_Data
    {

        /// <summary>
        /// 检索一个病人的所有处方头信息
        /// </summary>
        /// <param name="queryPat">门诊发药病人</param>
        /// <returns>处方头列表</returns>
        public DataTable GetPrescriptions(Structs.FY_MZ_Patient queryPat, int drFlag)
        {
            string invoiceNum;
            if (queryPat.InvoiceNum == "" || queryPat.InvoiceNum == null)
            {
                invoiceNum = "";
            }
            else
            {
                invoiceNum = Convert.ToInt32(queryPat.InvoiceNum.Trim()).ToString();
            }
            string sql = @"select 
                            Charge_Flag, 
                            ChargeCode ,
                            CostMasterID as ChargeID,
                            Drug_Flag,
                            ExecDeptCode,
                            ExecDocCode,
                            b.name as exeDocName, 
                            a.PatID as PatientID,
                            d.patname as PatientName,  
                            PresAmount ,
                            PresCostCode,  
                             PresMasterID as PrescriptionID,
                            PresType as PrescType  ,
                            PresDate,
                            PresDeptCode,
                            c.name as presDeptName, 
                            PresDocCode,
                            e.name as PresDocName,
                            Record_Flag ,
                            a.PatListID as RegisterID, 
                            TicketCode ,
                            TicketNum ,
                            Total_Fee 
                            from mz_presmaster a 
                            left join base_employee_property b on a.ExecdocCode = cast(b.employee_id as char(10)) and a.workid=b.workid
                            left join base_dept_property c on a.ExecDeptCode = cast(c.dept_id as char(10)) and a.workid=c.workid
                            left join mz_patlist d on a.patlistid=d.patlistid and a.workid=d.workid 
                            left join base_employee_property e on a.PresDocCode = cast(e.employee_id as char(10)) and a.workid=e.workid
                            where a.ticketnum='" + invoiceNum + "' and a.prestype in ('0','1','2','3') and a.charge_flag=1 and a.drug_flag="
                                                 +drFlag.ToString()+" and a.record_flag=0 and a.ExecDeptCode='"+queryPat.ExecDeptId.ToString()+"'";

            return oleDb.GetDataTable(sql);

        }

        GridppReport report;
        DataTable presTable;

        /// <summary>
        /// 组织输液卡打印数据
        /// </summary>
        /// <param name="Eof"></param>
        private void TransfuCardReport_FetchRecord(ref bool Eof)
        {
            int skinTestUsageId = -1;
            try
            {
                DataTable configTable = oleDb.GetDataTable("select value from mz_doc_config where code='002'");
                if (configTable != null && configTable.Rows.Count>0)
                {
                    skinTestUsageId = Convert.ToInt32(configTable.Rows[0]["value"]);
                }
            }
            catch
            { }
            int groupId = 0;
            DataTable printTable = new DataTable();
            printTable.Columns.Add("Item_Name", Type.GetType("System.String"));
            printTable.Columns.Add("Item_Usage_Amount", Type.GetType("System.String"));
            printTable.Columns.Add("Item_Usage_Name", Type.GetType("System.String"));
            printTable.Columns.Add("Item_Days", Type.GetType("System.String"));
            printTable.Columns.Add("Entrust", Type.GetType("System.String"));
            printTable.Columns.Add("Group_Id", Type.GetType("System.Int32"));
            printTable.Columns.Add("Group_Flag", Type.GetType("System.String"));

            for (int index = 0; index < presTable.Rows.Count; index++)
            {
                DataRow row = printTable.NewRow();
                row["Item_Name"] = presTable.Rows[index]["Item_Name"].ToString().Trim() + "[" + presTable.Rows[index]["Standard"].ToString().Trim() + "]";
                row["Item_Days"] = presTable.Rows[index]["Days"].ToString().Trim() + "天";
                row["Entrust"] = presTable.Rows[index]["Entrust"].ToString().Trim();
                if (Convert.ToInt32(presTable.Rows[index]["SkinTest_Flag"]) > 0 && Convert.ToInt32(presTable.Rows[index]["SkinTest_Flag"]) < 4)
                {
                    row["Item_Name"] = row["Item_Name"].ToString() + " 皮试(  )";
                }
                else if (Convert.ToInt32(presTable.Rows[index]["SkinTest_Flag"]) == 4 && Convert.ToInt32(presTable.Rows[index]["Usage_Id"]) != skinTestUsageId)
                {
                    row["Item_Name"] = row["Item_Name"].ToString() + "(免试)";
                }
                row["Item_Usage_Amount"] = Convert.ToDecimal(presTable.Rows[index]["Usage_Amount"]).ToString().TrimEnd('0').TrimEnd('.') + "" + presTable.Rows[index]["Usage_Unit"].ToString();
                int group_id = Convert.ToInt32(presTable.Rows[index]["Group_Id"]);
                if (group_id < 2)
                {
                    if (index > 0)
                    {
                        decimal execNum = Convert.ToInt32(presTable.Rows[index - 1]["Frequency_ExecNum"]) / Convert.ToInt32(presTable.Rows[index - 1]["Frequency_CycleDay"]);
                        if (execNum > 1)
                        {
                            DataRow[] grouprows = printTable.Select("Group_Id=" + groupId.ToString());
                            for (decimal i = execNum; i > 1; i--)
                            {
                                groupId++;
                                for (int j = 0; j < grouprows.Length; j++)
                                {
                                    printTable.Rows.Add(grouprows[j].ItemArray);
                                    printTable.Rows[printTable.Rows.Count - 1]["Group_Id"] = groupId;
                                }
                            }
                        }
                    }
                    groupId++;
                    row["Group_Id"] = groupId;
                    row["Item_Usage_Name"] = presTable.Rows[index]["Usage_Name"];
                    row["Group_Flag"] = "";
                    if (group_id == 1)
                    {
                        row["Group_Flag"] = "│";
                    }
                }
                else
                {
                    row["Group_Id"] = groupId;
                    row["Item_Usage_Name"] = "";
                    row["Group_Flag"] = "│";
                }

                printTable.Rows.Add(row);
            }
            if (presTable.Rows.Count > 0)
            {
                decimal execNum = Convert.ToInt32(presTable.Rows[presTable.Rows.Count - 1]["Frequency_ExecNum"]) / Convert.ToInt32(presTable.Rows[presTable.Rows.Count - 1]["Frequency_CycleDay"]);
                if (execNum > 1)
                {
                    DataRow[] grouprows = printTable.Select("Group_Id=" + groupId.ToString());
                    for (decimal i = execNum; i > 1; i--)
                    {
                        groupId++;
                        for (int j = 0; j < grouprows.Length; j++)
                        {
                            printTable.Rows.Add(grouprows[j].ItemArray);
                            printTable.Rows[printTable.Rows.Count - 1]["Group_Id"] = groupId;
                        }
                    }
                }
            }
            GWI_DesReport.HisReport.FillRecordToReport(report, printTable);
        }

        /// <summary>
        /// 打印门诊输液卡
        /// </summary>
        /// <param name="invoiceNo"></param>
        /// <param name="printer"></param>
        public void PrintTransfuCard(string invoiceNo, string printer)
        {
            string sql = @"select distinct 
                           e.visitno,
                           e.patname, 
                           e.patsex, 
                           e.DiseaseName,
                           rtrim(char(e.age))||e.hpgrade as patage, 
                           f.name as dept_name, 
                           g.name as doc_name, 
                           c.*,
                           h.EXECNUM as Frequency_ExecNum,
                           h.CYCLEDAY as Frequency_CycleDay,
                           i.NAME as Usage_Name
                           from mz_presmaster a
                           left join mz_doc_preshead b on a.docpresid=b.presheadid
                           left join mz_doc_preslist c on b.presheadid=c.presheadid
                           right join Base_Usage_UseType_Role d on c.usage_id=d.usage_id
                           left join mz_patlist e on a.patlistid=e.patlistid
                           left join base_dept_property f on b.pres_dept=f.dept_id
                           left join base_employee_property g on b.pres_doc=g.employee_id
                           left join BASE_FREQUENCY h on c.FREQUENCY_ID=h.ID
                           left join BASE_USAGEDICTION i on c.USAGE_ID=i.ID
                           where a.ticketnum='" + invoiceNo + "' and d.type_name='输液卡' and c.delete_bit=0 order by presheadid,orderno";

            presTable =  oleDb.GetDataTable(sql);
            if (presTable == null || presTable.Rows.Count <= 0)
            {
                return;
            }
            report = new GridppReport();
            report.LoadFromFile(HIS.SYSTEM.PubicBaseClasses.Constant.ApplicationDirectory + "\\report\\门诊输液卡.grf");

            report.ParameterByName("医院名称").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
            report.ParameterByName("开方科室").AsString = presTable.Rows[0]["dept_name"].ToString();
            report.ParameterByName("开方医师").AsString = presTable.Rows[0]["doc_name"].ToString();
            report.ParameterByName("门诊号").AsString = presTable.Rows[0]["visitno"].ToString();
            report.ParameterByName("病人姓名").AsString = presTable.Rows[0]["patname"].ToString();
            report.ParameterByName("性别").AsString = presTable.Rows[0]["patsex"].ToString();
            report.ParameterByName("年龄").AsString = presTable.Rows[0]["patage"].ToString();
            report.ParameterByName("打印人").AsString = printer;
            report.ParameterByName("诊断").AsString = presTable.Rows[0]["DiseaseName"].ToString();

            report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(TransfuCardReport_FetchRecord);
            report.PrintPreview(false);
        }

        /// <summary>
        /// 组织中药处方打印数据
        /// </summary>
        /// <param name="Eof"></param>
        private void DocHerbPresReport_FetchRecord(ref bool Eof)
        {
            DataTable printTable = new DataTable();
            printTable.Columns.Add("Item_Name_Left", Type.GetType("System.String"));
            printTable.Columns.Add("Usage_Amount_Left", Type.GetType("System.String"));
            printTable.Columns.Add("Item_Name_Right", Type.GetType("System.String"));
            printTable.Columns.Add("Usage_Amount_Right", Type.GetType("System.String"));
            DataRow row = printTable.NewRow();
            for (int index = 0; index < presTable.Rows.Count; index++)
            {
                if (index % 2 == 0)
                {
                    row["Item_Name_Left"] = presTable.Rows[index]["printname"].ToString().Trim();
                    //添加脚注
                    row["Item_Name_Left"] = row["Item_Name_Left"] + ((presTable.Rows[index]["FootNote"].ToString().Trim() == "") ? "" : ("【" + presTable.Rows[index]["FootNote"].ToString().Trim() + "】"));
                    //添加自备标志
                    row["Item_Name_Left"] = row["Item_Name_Left"] + ((presTable.Rows[index]["SelfDrug_Flag"].ToString().Trim() == "0") ? "" : ("【自备】"));

                    row["Usage_Amount_Left"] = Convert.ToDecimal(presTable.Rows[index]["Usage_Amount"]).ToString("0.00") + Convert.ToString(presTable.Rows[index]["Usage_Unit"]);
                    printTable.Rows.Add(row.ItemArray);
                }
                else
                {
                    printTable.Rows[printTable.Rows.Count - 1]["Item_Name_Right"] = presTable.Rows[index]["printname"].ToString().Trim();
                    //添加脚注
                    printTable.Rows[printTable.Rows.Count - 1]["Item_Name_Right"] = 
                        printTable.Rows[printTable.Rows.Count - 1]["Item_Name_Right"] + 
                        ((presTable.Rows[index]["FootNote"].ToString().Trim() == "") ? "" : ("【" + presTable.Rows[index]["FootNote"].ToString().Trim() + "】"));
                    //添加自备标志
                    printTable.Rows[printTable.Rows.Count - 1]["Item_Name_Right"] = 
                        printTable.Rows[printTable.Rows.Count - 1]["Item_Name_Right"] + 
                        ((presTable.Rows[index]["SelfDrug_Flag"].ToString().Trim() == "0") ? "" : ("【自备】"));

                    printTable.Rows[printTable.Rows.Count - 1]["Usage_Amount_Right"] = Convert.ToDecimal(presTable.Rows[index]["Usage_Amount"]).ToString("0.00") + Convert.ToString(presTable.Rows[index]["Usage_Unit"]);
                }
            }
            GWI_DesReport.HisReport.FillRecordToReport(report, printTable);
        }

        /// <summary>
        /// 组织西成药处方打印数据
        /// </summary>
        /// <param name="Eof"></param>
        private void DocNoHerbPresReport_FetchRecord(ref bool Eof)
        {
            DataTable printTable = presTable.Clone();
            for (int index = 0; index < presTable.Rows.Count; index++)
            {
                printTable.Rows.Add(presTable.Rows[index].ItemArray);
                printTable.Rows[index]["Item_Name"] = presTable.Rows[index]["printname"];
            }

            //加入组线
            printTable.Columns.Add("GroupLineUp", Type.GetType("System.String"));
            printTable.Columns.Add("GroupLineDown", Type.GetType("System.String"));
            printTable.Columns.Add("SkinTestStatus", Type.GetType("System.String"));
            for (int index = 0; index < printTable.Rows.Count; index++)
            {
                //添加自备标志
                printTable.Rows[index]["Item_Name"] = printTable.Rows[index]["Item_Name"].ToString() + ((printTable.Rows[index]["SelfDrug_Flag"].ToString().Trim() == "0") ? "" : ("【自备】"));

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
            GWI_DesReport.HisReport.FillRecordToReport(report, printTable);
        }

        /// <summary>
        /// 打印门诊医生处方
        /// </summary>
        /// <param name="presHeadId">门诊收费处方头ID</param>
        public void PrintDocPres(long presHeadId)
        {
            #region 查询sql
            string sql = @"select distinct 
                           e.visitno,
                           e.patname, 
                           e.patsex, 
                           e.DiseaseName,
                           e.CureDate,
                           rtrim(char(e.age))||e.hpgrade as patage, 
                           f.name as dept_name, 
                           g.name as doc_name, 
                           c.*,
                           h.ExecNum as Frequency_ExecNum,
                           h.CycleDay as Frequency_CycleDay,
                           h.Caption as Frequency_Caption,
                           i.NAME as Usage_Name,
                           j.printname,
                           j.lunacy_flag,
                           b.pres_date,
                           b.prestype,
                           k.NAME as FeeTypeName,
                           l.PatTEL,
                           l.PatAddress
                           from mz_presmaster a
                           left join mz_doc_preshead b on a.docpresid=b.presheadid
                           left join mz_doc_preslist c on b.presheadid=c.presheadid
                           left join mz_patlist e on b.patlistid=e.patlistid
                           left join base_dept_property f on b.pres_dept=f.dept_id
                           left join base_employee_property g on b.pres_doc=g.employee_id
                           left join BASE_FREQUENCY h on c.FREQUENCY_ID=h.ID
                           left join BASE_USAGEDICTION i on c.USAGE_ID=i.ID
                           left join VI_CLINICAL_ALL_ITEMS j on c.ITEM_ID=j.ITEMID
                           left join BASE_PATIENTTYPE k on e.MEDITYPE=k.code
                           left join PatientInfo l on e.patid=l.patid
                           where a.PRESMASTERID=" + presHeadId + " and c.delete_bit=0 order by presheadid,orderno";

            presTable = oleDb.GetDataTable(sql);
            if (presTable == null || presTable.Rows.Count <= 0)
            {
                throw new Exception("处方无法打印，请确认：1.该张处方是由医生站开出的处方。2.该张处方已收费");
            }
            #endregion

            report = new GridppReport();

            List<IPresDetail> presDetails = new List<IPresDetail>();
            foreach (DataRow row in presTable.Rows)
            {

                if (row["printname"] == null || row["printname"] == DBNull.Value)
                {
                    throw new Exception(row["ITEM_NAME"].ToString()+"：可能该药已经停用！");
                }

                if (row["SelfDrug_Flag"].ToString().Trim() == "0" || row["prestype"].ToString().Trim() == "00")
                {
                    HIS.Interface.Structs.PrescriptionDetail presDetail = new PrescriptionDetail();
                    presDetail.BigItemCode = row["StatItem_Code"].ToString();
                    presDetail.Money = Convert.ToDecimal(row["Item_Price"]) * Convert.ToDecimal(row["Dosage"]) * Convert.ToDecimal(row["Item_Amount"]);
                    presDetails.Add(presDetail);
                }
            }
            //decimal drugFee = HIS.MZ_PublicFun.PrescMoneyProcessor.GetPrescriptionTotalMoney(presDetails);
            decimal drugFee = InstanceFactory.CreatPrescMoneyCalculate().GetPrescriptionTotalMoney( presDetails );

            #region 划分处方类型
            string presType = "普通";
            //按病人就诊时间划分处方类型
            string[] timestr = {""};
            DataTable configTable = oleDb.GetDataTable("select value from mz_doc_config where code='004'");
            if (configTable != null && configTable.Rows.Count > 0)
            {
                timestr = configTable.Rows[0]["value"].ToString().Trim().Split(',');
            }
            DateTime cureDate = Convert.ToDateTime(presTable.Rows[0]["CureDate"]);
            for (int index = 0; index < timestr.Length; index++)
            {
                if (cureDate > DateTime.Parse(cureDate.ToShortDateString() + ' ' + timestr[index].Substring(0, timestr[index].IndexOf('-')))
                    && cureDate <= DateTime.Parse(cureDate.ToShortDateString() + ' ' + timestr[index].Substring(timestr[index].IndexOf('-') + 1)))
                {
                    presType = "急诊";
                }
            }

            for (int index = 0; index < presTable.Rows.Count; index++)
            {
                //判断精二类处方
                if (Convert.ToInt32(presTable.Rows[index]["lunacy_flag"]) == 1)
                {
                    presType = "精二";
                }
            }
            #endregion

            if (presTable.Rows[0]["StatItem_Code"].ToString().Trim() == "03")
            {
                #region 处理中药处方
                report.LoadFromFile(HIS.SYSTEM.PubicBaseClasses.Constant.ApplicationDirectory + "\\report\\门诊医生中药处方.grf");
                report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(DocHerbPresReport_FetchRecord);

                //中药处方需要显示用法和剂数
                report.ParameterByName("用法").AsString = Convert.ToString(presTable.Rows[0]["Usage_Name"]);
                report.ParameterByName("剂数").AsString = Convert.ToString(presTable.Rows[0]["Dosage"]) + "剂";
                #endregion
            }
                // update by heyan 2010.12.2 物资大项目代码00，也要在处方中打印出来
            else if (presTable.Rows[0]["StatItem_Code"].ToString().Trim() == "00" || presTable.Rows[0]["StatItem_Code"].ToString().Trim() == "01" || presTable.Rows[0]["StatItem_Code"].ToString().Trim() == "02")
            {
                #region 处理西成药处方
                report.LoadFromFile(HIS.SYSTEM.PubicBaseClasses.Constant.ApplicationDirectory + "\\report\\门诊医生西成药处方.grf");
                report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(DocNoHerbPresReport_FetchRecord);               
                #endregion
            }
            else
            {
                return;
            }

            #region 添加参数
            report.ParameterByName("医院名称").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
            report.ParameterByName("处方类型").AsString = presType;
            report.ParameterByName("开方科室").AsString = presTable.Rows[0]["dept_name"].ToString();
            report.ParameterByName("开方医生").AsString = presTable.Rows[0]["doc_name"].ToString();
            report.ParameterByName("门诊号").AsString = presTable.Rows[0]["visitno"].ToString();
            report.ParameterByName("开方时间").AsString = Convert.ToDateTime(presTable.Rows[0]["pres_date"]).ToString("yyyy年MM月dd日") + " " + 
                                                          Convert.ToDateTime(presTable.Rows[0]["pres_date"]).ToString("HH:mm:ss");
            report.ParameterByName("病人姓名").AsString = presTable.Rows[0]["patname"].ToString();
            report.ParameterByName("病人年龄").AsString = presTable.Rows[0]["patage"].ToString();
            report.ParameterByName("病人性别").AsString = presTable.Rows[0]["patsex"].ToString();
            report.ParameterByName("病人费别").AsString = presTable.Rows[0]["FeeTypeName"].ToString();
            report.ParameterByName("诊断").AsString = presTable.Rows[0]["DiseaseName"].ToString();
            report.ParameterByName("电话").AsString = presTable.Rows[0]["PatTEL"].ToString();
            report.ParameterByName("联系地址").AsString = presTable.Rows[0]["PatAddress"].ToString();
            report.ParameterByName("处方号").AsString = Convert.ToString(presTable.Rows[0]["PresHeadId"]).PadLeft(7, '0');

            //设置处方金额金额
            report.ParameterByName("处方金额").AsString = drugFee.ToString("0.00") + "元";
            #endregion

            report.PrintPreview(false);
        }

        /// <summary>
        /// 按处方头检索处方明细信息
        /// </summary>
        /// <param name="queryPrescription">处方头</param>
        /// <returns>处方明细列表</returns>
        /// 处方明细表字段数据
        /// 药品化学名 string  ---
        /// 厂家典ID int ---
        /// 规格典ID int ---
        /// 药品单位ID int ---
        /// 单位数量（划价系数） int ---
        /// 发药数量 int ---
        /// 发药剂量 int ---
        /// 药品零售价 decimal ---
        /// 药品批发价 decimal ---
        /// 药品零售金额 decimal ---
        /// 药品单位名 string ---
        /// 药品生产厂家名称 string ---
        /// 药品规格 string ---
        public DataTable GetPrescriptionDetails(Structs.Prescription queryPrescription)
        {
            if (queryPrescription == null)
            {
                return null;
            }
            string childtable_1 = oleDb.ChildTable(oleDb.TableNameBM(Tables.YP_MAKERDIC, "a") +
                                        oleDb.LeftOuterJoin() + oleDb.TableNameBM(Tables.YP_SPECDIC, "b") + oleDb.ON("a.specdicid", "b.specdicid") +
                                        oleDb.LeftOuterJoin() + oleDb.TableNameBM("yp_unitdic", "c") + oleDb.ON("b.unit", "c.unitdicid") +
                                        oleDb.LeftOuterJoin() + oleDb.TableNameBM("yp_productdic", "d") + oleDb.ON("a.productid", "d.productid"), "b", "",
            "b.chemname",
            "a.makerdicid",
             "a.specdicid",
            "b.unit",
            "b.dosenum",
             "c.unitname",
            "d.productname"
            );

            string in_1_1 = oleDb.In("'00', '01','02','03'");
            string strWhere_2 = Tables.mz_presorder.ITEMTYPE + in_1_1 + oleDb.And() + Tables.mz_presorder.PRESMASTERID + oleDb.EuqalTo() + queryPrescription.PrescriptionID;
            string childtable_2 = oleDb.ChildTable(oleDb.TableNameBM(Tables.MZ_PRESORDER, "a1") +
                oleDb.LeftOuterJoin() + oleDb.TableNameBM(Tables.MZ_DOC_PRESLIST, "a2")+oleDb.ON("a1.passid", "a2.preslistid")+
                oleDb.LeftOuterJoin() + oleDb.TableNameBM(Tables.BASE_USAGEDICTION, "a3")+oleDb.ON("a2.usage_id", "a3.id")+
                oleDb.LeftOuterJoin() + oleDb.TableNameBM(Tables.BASE_FREQUENCY, "a4")+oleDb.ON("a2.frequency_id", "a4.id"),
                "a", strWhere_2,
                "a1."+Tables.mz_presorder.ORDER_FLAG,
                "a1." + Tables.mz_presorder.PRESORDERID,
                "a1." + Tables.mz_presorder.ITEMID,
                "a1." + Tables.mz_presorder.RELATIONNUM,
                "a1." + Tables.mz_presorder.AMOUNT,
                "a1." + Tables.mz_presorder.SELL_PRICE,
                "a1." + Tables.mz_presorder.BUY_PRICE,
                "a1." + Tables.mz_presorder.TOLAL_FEE,
                "a1." + Tables.mz_presorder.STANDARD,
                "a1." + Tables.mz_presorder.PRESAMOUNT,
                queryPrescription.PresDeptCode + " as PresDeptCode",
                "a2." + Tables.mz_doc_preslist.ENTRUST + " as EntrustName",
                "a3." + Tables.base_usagediction.NAME + " as UseWayName",
                "a4." + Tables.base_frequency.NAME + " as FreQuencyName",
                "a2." + Tables.mz_doc_preslist.USAGE_AMOUNT,
                "a2." + Tables.mz_doc_preslist.USAGE_UNIT);
            string strWhere_3 = "a.itemid" + oleDb.EuqalTo() + "b.makerdicid";
            string strsql = oleDb.Table(childtable_2 + "," + childtable_1, "", strWhere_3, "*");
            strsql += oleDb.OrderBy(Tables.mz_presorder.ORDER_FLAG);
            DataTable rtnDt = oleDb.GetDataTable(strsql);
            rtnDt.Columns.Add("RETAILFEE", Type.GetType("System.Decimal"));
            for (int index = 0; index < rtnDt.Rows.Count; index++)
            {
                DataRow currentRow = rtnDt.Rows[index];
                currentRow["RETAILFEE"] = Convert.ToDecimal(currentRow["TOLAL_FEE"])
                    / Convert.ToDecimal(currentRow["PRESAMOUNT"]);
            }
            return rtnDt;
        }


        #region IMZ_Data 成员
        /// <summary>
        /// 按发票号检索门诊待发药病人
        /// </summary>
        /// <param name="inVoiceNum">发票号</param>
        /// <returns>门诊发药病人</returns>
        public HIS.Interface.Structs.FY_MZ_Patient GetPatient( string PerfChar, string inVoiceNum , int deptId, int drFlag )
        {
            HIS.Interface.Structs.FY_MZ_Patient patient = new HIS.Interface.Structs.FY_MZ_Patient( );

            string strWhere = "a." + Tables.mz_presmaster.PATLISTID + oleDb.EuqalTo( ) + "b." + Tables.mz_patlist.PATLISTID;
            strWhere += oleDb.And( ) + Tables.mz_presmaster.TICKETNUM + oleDb.EuqalTo( ) + "'" + Convert.ToInt64( inVoiceNum ).ToString( ) + "'";
            strWhere += oleDb.And( ) + Tables.mz_presmaster.TICKETCODE + oleDb.EuqalTo( ) + "'" + PerfChar.Trim() + "'";
            strWhere += oleDb.And( ) + Tables.mz_presmaster.RECORD_FLAG + oleDb.EuqalTo( ) + "0";
            strWhere += oleDb.And( ) + Tables.mz_presmaster.PRESTYPE + oleDb.In( ) + "('0','1','2','3')";
            strWhere += oleDb.And( ) + Tables.mz_presmaster.CHARGE_FLAG + oleDb.EuqalTo( ) + "1";
            strWhere += oleDb.And( ) + Tables.mz_presmaster.DRUG_FLAG + oleDb.EuqalTo( ) + drFlag;
            strWhere += oleDb.And() + Tables.mz_presmaster.EXECDEPTCODE + oleDb.EuqalTo() + "'" + deptId.ToString() + "'";

            string table1 = oleDb.TableName( oleDb.TableNameBM( Tables.MZ_PRESMASTER , "a" ) , oleDb.TableNameBM( Tables.MZ_PATLIST , "b" ) );

            string sql = oleDb.Table( table1 , "" , strWhere ,
                                      "a." + Tables.mz_presmaster.TICKETNUM ,
                                      "a." + Tables.mz_presmaster.TICKETCODE ,
                                      "b." + Tables.mz_patlist.PATNAME ,
                                      "b." + Tables.mz_patlist.PATSEX ,
                                      "b." + Tables.mz_patlist.AGE );
            DataTable tb = oleDb.GetDataTable( sql );
            if ( tb.Rows.Count == 0 )
                throw new Exception( "没有找到病人信息！" );

            patient.InvoiceNum = inVoiceNum;
            patient.PerfChar = tb.Rows[0]["TICKETCODE"].ToString( );
            patient.PatAge = tb.Rows[0]["AGE"].ToString( );
            patient.PatName = tb.Rows[0]["PatName"].ToString( );
            patient.PatSex = tb.Rows[0]["PATSEX"].ToString( );
            patient.ExecDeptId = deptId;
            return patient;
        }
        /// <summary>
        /// 按执行科室ID检索待发药病人
        /// </summary>
        /// <param name="deptId">执行科室ID</param>
        /// <returns>门诊待发药病人</returns>
        public List<Structs.FY_MZ_Patient> GetPatient(int deptId, DateTime? beginTime, DateTime endDateTime, int drFlag)
        {
            string strWhere = "a." + Tables.mz_presmaster.PRESTYPE + oleDb.In( "'0', '1','2','3'" );
            strWhere += oleDb.And( ) + Tables.mz_presmaster.DRUG_FLAG + oleDb.EuqalTo( ) + drFlag.ToString();
            strWhere += oleDb.And() + Tables.mz_presmaster.CHARGE_FLAG + oleDb.EuqalTo() + "1";
            strWhere += oleDb.And( ) + Tables.mz_presmaster.RECORD_FLAG + oleDb.EuqalTo( ) + "0";
            strWhere += oleDb.And( ) + Tables.mz_presmaster.EXECDEPTCODE + oleDb.EuqalTo( ) + "'" + deptId + "'";
            if (drFlag == 0)
            {
                strWhere += oleDb.And() + Tables.mz_presmaster.PRESDATE + oleDb.LessThan() + "'" + endDateTime.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }
            else
            {
                strWhere += oleDb.And() + Tables.mz_presmaster.PRESDATE + oleDb.Between() + "'" + ((DateTime)beginTime).ToString("yyyy-MM-dd HH:mm:ss") + "'"
                    + oleDb.And() + "'" + endDateTime.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }
            strWhere += oleDb.And( ) + " a.patlistid=b.patlistid";

            string table1 = oleDb.TableNameBM( Tables.MZ_PRESMASTER , "a" );
            string table2 = oleDb.TableNameBM( Tables.MZ_PATLIST , "b" );
            string table = oleDb.TableName( table1,table2);
            string strsql = oleDb.Table( table , "" , strWhere ,
                "a."+Tables.mz_presmaster.TICKETNUM ,
                "a." + Tables.mz_presmaster.TICKETCODE ,
                "b." + Tables.mz_patlist.PATNAME ,
                "b." + Tables.mz_patlist.PATSEX ,
                "b." + Tables.mz_patlist.AGE );
            strsql += oleDb.GroupBy( "a." + Tables.mz_presmaster.TICKETNUM ,
                "a." + Tables.mz_presmaster.TICKETCODE,
                "b." + Tables.mz_patlist.PATNAME ,
                "b." + Tables.mz_patlist.PATSEX ,
                "b." + Tables.mz_patlist.AGE );

            DataTable tb = oleDb.GetDataTable( strsql );
            List<FY_MZ_Patient> lstPatient = new List<FY_MZ_Patient>( );
            for ( int i = 0 ; i < tb.Rows.Count ; i++ )
            {
                FY_MZ_Patient patient = new FY_MZ_Patient( );
                patient.PerfChar = tb.Rows[i]["ticketcode"].ToString( );
                patient.InvoiceNum = tb.Rows[i]["TICKETNUM"].ToString( );
                patient.PatAge = tb.Rows[i]["AGE"].ToString( );
                patient.PatName = tb.Rows[i]["PATNAME"].ToString( );
                patient.PatSex = tb.Rows[i]["PATSEX"].ToString( );
                patient.ExecDeptId = deptId;
                lstPatient.Add( patient );
            }
            return lstPatient;
        }

        #endregion

        
    }
}
