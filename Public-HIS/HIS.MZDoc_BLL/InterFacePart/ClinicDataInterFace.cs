using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.SYSTEM.DatabaseAccessLayer;
using System.Collections;

namespace HIS.MZDoc_BLL.InterFace
{
    /// <summary>
    /// 门诊临床数据接口
    /// </summary>
    public class ClinicDataInterFace:BaseBLL,HIS.Interface.IMZ_ClinicData
    {
        /// <summary>
        /// 获取病人未收费处方明细
        /// </summary>
        /// <param name="patListId">门诊病人就诊Id</param>
        /// <returns>门诊收费处方结构体组</returns>
        public HIS.Interface.Structs.Prescription[] GetPrescriptions(int patListId)
        {
            int presNo = 0;
            string strsql = "";
            bool isControlSkinTest = OP_ReadBaseData.GetConfigValue("003").Trim() == "1";  //系统参数：是否控制未皮试和皮试阳性的药品不能收费
            //获取处方头列表信息 update 王志 2010-03-11 导致收完费的处方还能收费
            //List<PresHead> presHeads = new PresHead(patListId).GetNormalPresHeadList();
            List<PresHead> presHeads = new PresHead((long)patListId,0).GetNoChangePresHeadList();
            //定义收费处方结构体
            HIS.Interface.Structs.Prescription[] prescriptions = new HIS.Interface.Structs.Prescription[presHeads.Count];
            for (int i = 0; i < presHeads.Count; i++)
            {
                //获取处方明细信息
                if (presHeads[i].PresType.Trim() == "00")
                {
                    strsql = HIS.BLL.Tables.mz_doc_preslist.PRESHEADID + oleDb.EuqalTo() + presHeads[i].PresHeadId
                           + oleDb.And() + HIS.BLL.Tables.mz_doc_preslist.DELETE_BIT + oleDb.EuqalTo() + 0
                           + oleDb.OrderBy(HIS.BLL.Tables.mz_doc_preslist.ORDERNO);
                }
                else
                {
                    strsql = HIS.BLL.Tables.mz_doc_preslist.PRESHEADID + oleDb.EuqalTo() + presHeads[i].PresHeadId
                        + oleDb.And() + HIS.BLL.Tables.mz_doc_preslist.DELETE_BIT + oleDb.EuqalTo() + 0
                        + oleDb.And() + HIS.BLL.Tables.mz_doc_preslist.SELFDRUG_FLAG + oleDb.EuqalTo() + 0
                        + oleDb.OrderBy(HIS.BLL.Tables.mz_doc_preslist.ORDERNO);
                }
                List<HIS.Model.Mz_Doc_PresList> presList = BindEntity<HIS.Model.Mz_Doc_PresList>.CreateInstanceDAL(oleDb).GetListArray(strsql);
                if (presList.Count > 0)
                {
                    DataRow[] rows = null;
                    if (isControlSkinTest)
                    {
                        rows = Public.Function.ListToDataTable(presList, new HIS.Model.Mz_Doc_PresList()).Select("SkinTest_Flag = 1 or SkinTest_Flag = 3");
                    }
                    if (rows != null && rows.Length > 0)
                    {
                        continue;
                    }
                    #region 读取处方头
                    prescriptions[presNo] = new HIS.Interface.Structs.Prescription();
                    prescriptions[presNo].Charge_Flag = 0;
                    prescriptions[presNo].ChargeCode = "";
                    prescriptions[presNo].ChargeID = 0;
                    prescriptions[presNo].Drug_Flag = presHeads[i].PresType == "00" ? 0 : 1;
                    prescriptions[presNo].ExecDeptCode = presHeads[i].Pres_ExeDept.ToString();
                    prescriptions[presNo].ExecDocCode = "";
                    prescriptions[presNo].OldPresID = 0;
                    prescriptions[presNo].PresCostCode = presHeads[i].Pres_Doc.ToString();
                    prescriptions[presNo].PrescriptionID = presHeads[i].PresHeadId;
                    prescriptions[presNo].PrescType = presHeads[i].PresType == "00" ? "-1" : Convert.ToInt32(presHeads[i].PresType).ToString();
                    prescriptions[presNo].PresDeptCode = presHeads[i].Pres_Dept.ToString();
                    prescriptions[presNo].PresDocCode = presHeads[i].Pres_Doc.ToString();
                    prescriptions[presNo].Record_Flag = 0;
                    prescriptions[presNo].TicketCode = "";
                    prescriptions[presNo].TicketNum = "";
                    prescriptions[presNo].Total_Fee = 0;
                    //prescriptions[presNo].VisitNo = "";
                    #endregion

                    //定义收费处方明细结构体
                    HIS.Interface.Structs.PrescriptionDetail[] details = new HIS.Interface.Structs.PrescriptionDetail[presList.Count];
                    for (int j = 0; j < presList.Count; j++)
                    {
                        #region 读取处方明细
                        details[j] = new HIS.Interface.Structs.PrescriptionDetail();
                        details[j].Amount = presList[j].Item_Amount * presList[j].RelationNum / presList[j].Item_Rate;
                        details[j].BigitemCode = presList[j].StatItem_Code;
                        details[j].Buy_price = presList[j].Buy_Price;
                        details[j].ComplexId = presList[j].Tc_Flag == 1 ? presList[j].Service_Item_Id : 0;
                        details[j].DetailId = presList[j].PresListId;
                        details[j].ItemId = presList[j].Service_Item_Id;
                        details[j].Itemname = presList[j].Item_Name;
                        details[j].ItemType = (presList[j].StatItem_Code == "01" || presList[j].StatItem_Code == "02" || presList[j].StatItem_Code == "03") ? presList[j].StatItem_Code : "00";
                        details[j].Order_Flag = presList[j].OrderNo;
                        details[j].PassId = 0;
                        details[j].PresAmount = presList[j].Dosage;
                        details[j].PresctionId = presHeads[i].PresHeadId;
                        details[j].RelationNum = presList[j].RelationNum;
                        details[j].Sell_price = presList[j].Sell_Price;
                        details[j].Standard = presList[j].Standard;
                        details[j].Tolal_Fee = presList[j].Item_Amount * presList[j].Item_Price * presList[j].Dosage;
                        details[j].Unit = presList[j].Unit;
                        details[j].Drug_Flag = (presList[j].StatItem_Code == "01" || presList[j].StatItem_Code == "02" || presList[j].StatItem_Code == "03") ? 1 : 0;

                        prescriptions[presNo].Total_Fee += details[j].Tolal_Fee;
                        #endregion
                    }
                    prescriptions[presNo].PresDetails = details;

                    presNo++;
                }
            }
            //定义返回的处方结构体
            //取有效处方记录
            HIS.Interface.Structs.Prescription[] returnPres = new HIS.Interface.Structs.Prescription[presNo];
            {
                for (int i = 0; i < presNo; i++)
                {
                    returnPres[i] = prescriptions[i];
                }
            }
            return returnPres;
        }

        /// <summary>
        /// 修改病人处方状态
        /// </summary>
        /// <param name="presHeadId">处方头ID</param>
        /// <param name="status">处方状态 1:收费，2:退费</param>
        /// <returns></returns>
        public bool ChangePresStatus(int presHeadId, int status)
        {

            string strwhere = HIS.BLL.Tables.mz_doc_preshead.PRESHEADID + oleDb.EuqalTo() + presHeadId;
            switch (status)
            {
                case 1:
                    strwhere = strwhere + oleDb.And() + HIS.BLL.Tables.mz_doc_preshead.PRES_FLAG + oleDb.EuqalTo() + Public.PresStatus.保存状态.GetHashCode();
                    break;
                case 2:
                    strwhere = strwhere + oleDb.And() + HIS.BLL.Tables.mz_doc_preshead.PRES_FLAG + oleDb.EuqalTo() + Public.PresStatus.收费状态.GetHashCode();
                    break;
                default:
                    return false;
            }
            string[] strvalue = { HIS.BLL.Tables.mz_doc_preshead.PRES_FLAG + oleDb.EuqalTo() + status };
            BindEntity<Model.Mz_Doc_PresHead>.CreateInstanceDAL(oleDb).Update(strwhere, strvalue);
            return true;
        }

        /// <summary>
        /// 检查处方状态
        /// </summary>
        /// <param name="presHeadId">处方头Id</param>
        /// <returns></returns>
        public bool CheckPresStatus(int presHeadId)
        {
            return new PresHead(presHeadId).GetPresStatus()==Public.PresStatus.保存状态;
        }

        /// <summary>
        /// 获取住院证信息
        /// </summary>
        /// <param name="regId">住院证ID</param>
        /// <returns>住院证信息数据表</returns>
        public DataTable GetInpatRegInfo(int regId)
        {
            return new ZyInpatRegist((long)regId).GetValueTable();
        }


        //add by heyan 2011.4.12 门诊收费与门诊医生站处方金额不一致的问题
        public decimal GetMzDocPresTotalMoney(int presheadid)
        {

            InterFace.PrescMoneyCalculateInterFace PrescMoneyCalculateInterFace = new InterFace.PrescMoneyCalculateInterFace();          
            DataTable dt = BindEntity<Model.Mz_Doc_PresList>.CreateInstanceDAL(oleDb).GetList("presheadid=" + presheadid + "");
            List<HIS.MZDoc_BLL.Prescription> presList = (List<HIS.MZDoc_BLL.Prescription>)HIS.MZDoc_BLL.Public.Function.DataTableToList<HIS.MZDoc_BLL.Prescription>(dt);
            List<Prescription> presTemp = new List<Prescription>();
            for (int i = 0; i < presList.Count; i++)
            {
                presList[i].LoadData();               
            }
            return PrescMoneyCalculateInterFace.GetPrescriptionTotalMoney(presList);
        }
        #region 输液卡
        /// <summary>
        /// 组织输液卡打印数据
        /// </summary>
        /// <param name="presTable"></param>
        /// <returns></returns>
        private DataTable CreateTransfuCardData(DataTable presTable)
        {
            int skinTestUsageId = Convert.ToInt32(OP_ReadBaseData.GetConfigValue("002"));
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
            return printTable;
        }

        /// <summary>
        /// 获取门诊输液卡打印数据
        /// </summary>
        /// <param name="invoiceNo"></param>
        /// <param name="printer"></param>
        /// <returns></returns>
        public HIS.Interface.Structs.PrintInfo GetTransfuCardPrintInfo(string invoiceNo, string printer)
        {
            HIS.Interface.Structs.PrintInfo printInfo = new HIS.Interface.Structs.PrintInfo();
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

            DataTable presTable = oleDb.GetDataTable(sql);
            if (presTable != null && presTable.Rows.Count > 0)
            {
                printInfo.PrintFileName = HIS.SYSTEM.PubicBaseClasses.Constant.ApplicationDirectory + "\\report\\门诊输液卡.grf";
                Hashtable parameters = new Hashtable();
                parameters.Add("医院名称", HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName);
                parameters.Add("开方科室", presTable.Rows[0]["dept_name"].ToString());
                parameters.Add("开方医师", presTable.Rows[0]["doc_name"].ToString());
                parameters.Add("门诊号", presTable.Rows[0]["visitno"].ToString());
                parameters.Add("病人姓名", presTable.Rows[0]["patname"].ToString());
                parameters.Add("性别", presTable.Rows[0]["patsex"].ToString());
                parameters.Add("年龄", presTable.Rows[0]["patage"].ToString());
                parameters.Add("打印人", printer);
                parameters.Add("诊断", presTable.Rows[0]["DiseaseName"].ToString());
                printInfo.PrintParameters = parameters;
                printInfo.PrintData = CreateTransfuCardData(presTable);
            }
            return printInfo;
        }
        #endregion

        #region 处方
        /// <summary>
        /// 组织中药处方打印数据
        /// </summary>
        /// <param name="presTable"></param>
        /// <returns></returns>
        private DataTable CreateDocHerbPresData(DataTable presTable)
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
            return printTable;
        }

        /// <summary>
        /// 组织西成药处方打印数据
        /// </summary>
        /// <param name="presTable"></param>
        /// <returns></returns>
        private DataTable CreateDocNoHerbPresData(DataTable presTable)
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
            return printTable;
        }

        /// <summary>
        /// 获取门诊处方打印数据
        /// </summary>
        /// <param name="presHeadId">门诊收费处方头ID</param>
        public HIS.Interface.Structs.PrintInfo GetDocPresPrintInfo(long presHeadId)
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

            DataTable presTable = oleDb.GetDataTable(sql);
            if (presTable == null || presTable.Rows.Count <= 0)
            {
                throw new Exception("处方无法打印，请确认：1.该张处方是由医生站开出的处方。2.该张处方已收费");
            }
            #endregion

            HIS.Interface.Structs.PrintInfo printInfo = new HIS.Interface.Structs.PrintInfo();
            Hashtable parameters = new Hashtable();

            List<Prescription> presDetails = new List<Prescription>();
            foreach (DataRow row in presTable.Rows)
            {
                if (row["SelfDrug_Flag"].ToString().Trim() == "0" || row["prestype"].ToString().Trim() == "00")
                {
                    Prescription presDetail = new Prescription();
                    presDetail.BigItemCode = row["StatItem_Code"].ToString();
                    presDetail.Money = Convert.ToDecimal(row["Item_Price"]) * Convert.ToDecimal(row["Dosage"]) * Convert.ToDecimal(row["Item_Amount"]);
                    presDetails.Add(presDetail);
                }
            }
            decimal drugFee = new PrescMoneyCalculateInterFace().GetPrescriptionTotalMoney(presDetails);

            #region 划分处方类型
            string presType = "普通";
            //按病人就诊时间划分处方类型
            string[] timestr = { "" };
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
                printInfo.PrintFileName = HIS.SYSTEM.PubicBaseClasses.Constant.ApplicationDirectory + "\\report\\门诊医生中药处方.grf";

                //中药处方需要显示用法和剂数
                parameters.Add("用法", Convert.ToString(presTable.Rows[0]["Usage_Name"]));
                parameters.Add("剂数", Convert.ToString(presTable.Rows[0]["Dosage"]) + "剂");

                printInfo.PrintData = CreateDocHerbPresData(presTable);
                #endregion
            }
            else if (presTable.Rows[0]["StatItem_Code"].ToString().Trim() == "01" || presTable.Rows[0]["StatItem_Code"].ToString().Trim() == "02")
            {
                #region 处理西成药处方
                printInfo.PrintFileName = HIS.SYSTEM.PubicBaseClasses.Constant.ApplicationDirectory + "\\report\\门诊医生西成药处方.grf";

                printInfo.PrintData = CreateDocNoHerbPresData(presTable);
                #endregion
            }
            else
            {
                return printInfo;
            }

            #region 添加参数
            parameters.Add("医院名称",HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName);
            parameters.Add("处方类型",presType);
            parameters.Add("开方科室",presTable.Rows[0]["dept_name"].ToString());
            parameters.Add("开方医生",presTable.Rows[0]["doc_name"].ToString());
            parameters.Add("门诊号",presTable.Rows[0]["visitno"].ToString());
            parameters.Add("开方时间",Convert.ToDateTime(presTable.Rows[0]["pres_date"]).ToString("yyyy年MM月dd日") + " " +
                                                          Convert.ToDateTime(presTable.Rows[0]["pres_date"]).ToString("HH:mm:ss"));
            parameters.Add("病人姓名", presTable.Rows[0]["patname"].ToString());
            parameters.Add("病人年龄",presTable.Rows[0]["patage"].ToString());
            parameters.Add("病人性别",presTable.Rows[0]["patsex"].ToString());
            parameters.Add("病人费别",presTable.Rows[0]["FeeTypeName"].ToString());
            parameters.Add("诊断",presTable.Rows[0]["DiseaseName"].ToString());
            parameters.Add("电话",presTable.Rows[0]["PatTEL"].ToString());
            parameters.Add("联系地址",presTable.Rows[0]["PatAddress"].ToString());
            parameters.Add("处方号",Convert.ToString(presTable.Rows[0]["PresHeadId"]).PadLeft(7, '0'));

            //设置处方金额金额
            parameters.Add("处方金额",drugFee.ToString("0.00") + "元");
            printInfo.PrintParameters = parameters;
            #endregion

            return printInfo;
        }

        #endregion
    }
}
