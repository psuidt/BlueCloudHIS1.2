using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.BussinessLogicLayer.Classes;
using HIS.ZY_BLL.DataModel;
using HIS.SYSTEM.Core;
using HIS.ZY_BLL.Dao;
using HIS.ZY_BLL.Dao.PatientManager;
using HIS.MediInsInterface_BLL.MediInsInterface.NccmSystem;
using HIS.MediInsInterface_BLL.MediInsInterface.NccmSystem.Core;
using HIS.MediInsInterface_BLL.MediInsInterface.NccmSystem.Enums;

namespace HIS.MediInsInterface_BLL.MediInsInterface.zyInterface
{
    //[20100518.2.05]
    /// <summary>
    /// 住院农合接口
    /// </summary>
    public class zyNccmInterface : IzyInterface
    {
        private ZY_PatList hisOutPatient;
        private object hospitalInfo;

        private string JOIN_AREA_CODE = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.JOIN_AREA_CODE;
        private string JOIN_AREA_NAME = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.JOIN_AREA_NAME;
        private string MED_ORG_CODE = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.MED_ORG_CODE;

        /// <summary>
        /// 住院农合接口
        /// </summary>
        public zyNccmInterface()
        {
            HisData hisData = new HisData();
            hisData.uploadorg = MED_ORG_CODE;
            hisData.uploadTime = DateTime.Now.ToString( "yyyy-MM-dd" );

            DataClass dataClass = new DataClass();
            DataType dataType = new DataType();
            dataType.dataTypeName = "";
            dataType.dataTypeValue = "1";
            JoinArea joinArea = new JoinArea();
            joinArea.code = JOIN_AREA_CODE;
            joinArea.name = JOIN_AREA_NAME;

            hisData.joinArea = joinArea;
            hisData.dataClass = dataClass;
            hisData.dataType = dataType;

            hospitalInfo = NccmInterfaces.DownLoadHospitalInfo( hisData );
        }

        #region IzyInterface 成员
        /// <summary>
        /// 医院病人信息
        /// </summary>
        public ZY_PatList zyPatlist
        {
            get
            {
                return hisOutPatient;
            }
            set
            {
                hisOutPatient = value;
            }
        }
        /// <summary>
        /// 医院信息，实例化该类的时候调用接口赋值该类
        /// </summary>
        public object HospitalInfo
        {
            get
            {
                return hospitalInfo;
            }
            set
            {
                hospitalInfo = value;
            }
        }
        /// <summary>
        /// 读取病人信息
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        public object GetPatientInfo(System.Collections.Hashtable hashtable)
        {
            //获取参数
            //SearchNccmPatType snpt = (SearchNccmPatType)hashtable["SearchNccmPatType"];
            //string cardNo = hashtable["parameters"].ToString().Trim();

            //List<PatientInfo> patInfos = new List<PatientInfo>();
            //PatientInfo patInfo = null;
            
            //if (snpt == SearchNccmPatType.医疗卡号)
            //{
            //    FindPatientCompInfo hisData = new FindPatientCompInfo();

            //    JoinArea joinArea = new JoinArea();
            //    joinArea.code = JOIN_AREA_CODE;
            //    joinArea.name = JOIN_AREA_NAME;

            //    DataClass dataClass = new DataClass();
            //    dataClass.dataClassName = NcmsDataClass.新农合数据.ToString();
            //    dataClass.dataClassValue = ((int)NcmsDataClass.新农合数据).ToString();

            //    DataType dataType = new DataType();
            //    dataType.dataTypeName = "参合信息";
            //    dataType.dataTypeValue = "2";

            //    OperType operType = new OperType();
            //    operType.operTypeName = "查询";
            //    operType.operTypeValue = "4";

            //    Condition AREA = new Condition();		//参合地区
            //    AREA.condition_displayname = "参合地区";
            //    AREA.condition_name = "JOIN_AREA";
            //    AREA.condition_value = JOIN_AREA_CODE;

            //    Condition CARD_ID = new Condition();	//合作医疗证号			
            //    CARD_ID.condition_displayname = "合作医疗证号";
            //    CARD_ID.condition_name = "MED_CARD_ID";
            //    CARD_ID.condition_value = cardNo;     //"20090408" ;           

            //    Condition[] cond = new Condition[] { AREA, CARD_ID };
            //    hisData.joinArea = joinArea;
            //    hisData.dataClass = dataClass;
            //    hisData.dataType = dataType;
            //    hisData.operType = operType;
            //    hisData.conditions = cond;
            //    hisData.uploadorg = MED_ORG_CODE;

            //    FindPatientCompInfoResult result = NccmInterfaces.FindPatientCompInfo(hisData);
            //    if (result.resultId)
            //    {
            //        for (int i = 0; i < result.compPatBaseData.Length; i++)
            //        {
            //            patInfo = new PatientInfo();
            //            patInfo.FamilyCode = result.compPatBaseData[i].family_code;

            //            patInfo.MediCard = cardNo;//result.compPatBaseData.medcard_id;
            //            patInfo.PatBriDate = Convert.ToDateTime(result.compPatBaseData[i].birthdate);
            //            patInfo.PatCode = result.compPatBaseData[i].person_code;
            //            patInfo.PatNumber = result.compPatBaseData[i].idCard;
            //            patInfo.PatName = result.compPatBaseData[i].name;
            //            patInfo.PatSex = result.compPatBaseData[i].sex == "1" ? "男" : "女";
            //            patInfos.Add(patInfo);
            //        }
            //    }
            //    else
            //        throw new Exception("农合接口调用失败:" + result.resultString);
            //}
            //return patInfos;
            return null;
        }
        /// <summary>
        /// 农合入院
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        public bool Register(System.Collections.Hashtable hashtable)
        {
            PatientSignInfo retMsg = null;

            PatientSign ps = new PatientSign();
            ZyPatBaseData zyPs = new ZyPatBaseData();
            JoinArea joinArea = new JoinArea();
            joinArea.code = JOIN_AREA_CODE;
            joinArea.name = JOIN_AREA_NAME;

            zyPs.hisID = zyPatlist.Nccm_NO;//zyPatlist.CureNo + zyPatlist.PatListID.ToString();
            zyPs.medorg_code = MED_ORG_CODE;
            zyPs.area_id = JOIN_AREA_CODE;
            zyPs.inpat_no = zyPatlist.CureNo.ToString();

            zyPs.person_code = zyPatlist.patientInfo.PatCode;
            zyPs.name = zyPatlist.patientInfo.PatName;
            zyPs.sex = zyPatlist.patientInfo.PatSex == "男" ? "1" : "2";
            zyPs.idCard = zyPatlist.patientInfo.PatNumber;//?
            zyPs.family_code = zyPatlist.patientInfo.FamilyCode;
            zyPs.medcard_id = zyPatlist.patientInfo.MediCard;
            zyPs.medorg_level = "2";
            zyPs.visit_type = "2";
            zyPs.adm_date = zyPatlist.CureDate.ToString("yyyy-MM-dd");
            zyPs.adm_state = "1";//?zyPatlist.CureState?
            zyPs.comp_classs = "2";//?

            ps.joinArea = joinArea;
            ps.zyPat = zyPs;
            ps.uploadorg = MED_ORG_CODE;
            retMsg = NccmInterfaces.InpatientRegister(ps);
            if (retMsg.resultId)
                return retMsg.resultId;
            else
                throw new Exception("农合接口调用失败:" + retMsg.resultString);
        }
        /// <summary>
        /// 修改入院
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        public bool AlterRegister(System.Collections.Hashtable hashtable)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 取消入院
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        public bool CancelRegister(System.Collections.Hashtable hashtable)
        {

            PatBaseInfo hisData = new PatBaseInfo();


            JoinArea joinArea = new JoinArea();
            joinArea.code = JOIN_AREA_CODE;
            joinArea.name = JOIN_AREA_NAME;


            DataClass dataClass = new DataClass();
            dataClass.dataClassName = "新农合数据";
            dataClass.dataClassValue = "1";

            DataType dataType = new DataType();
            dataType.dataTypeName = "住院数据";
            dataType.dataTypeValue = "2";

            OperType operType = new OperType();
            operType.operTypeName = "取消登记";
            operType.operTypeValue = "7";

            PatBaseData patBaseData = new PatBaseData();
            patBaseData.hisID = zyPatlist.Nccm_NO;//病人的唯一ID，住院则对应的是住院号，门诊则对应的是门诊号
            patBaseData.area_id = JOIN_AREA_CODE;
            patBaseData.person_code = zyPatlist.patientInfo.PatCode;
            patBaseData.name = zyPatlist.patientInfo.PatName;
            patBaseData.idCard = zyPatlist.patientInfo.PatNumber;//?(身份证)
            patBaseData.medcard_id = zyPatlist.patientInfo.MediCard;//?
            patBaseData.visit_type = "2";//住院

            hisData.joinArea = joinArea;
            hisData.dataClass = dataClass;
            hisData.dataType = dataType;
            hisData.operType = operType;
            hisData.baseData = patBaseData;
            hisData.uploadorg = MED_ORG_CODE;
            NcmsResult retMsg = NccmInterfaces.CanInpatientRegister(hisData);
            if (retMsg.resultId)
                return true;
            else
                throw new Exception("农合接口调用失败:" + retMsg.resultString);
        }
        /// <summary>
        /// 出院预算
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        public object PreviewCharge(System.Collections.Hashtable hashtable)
        {
            FeeDetail[] prescriptions =(FeeDetail[])hashtable["FeeDetail"];
            string Is_midWay = hashtable["midWay"].ToString();

            PatientComp patComp = new PatientComp();
            patComp.uploadorg = "1";

            DataClass dataClass = new DataClass();
            dataClass.dataClassValue = "2";
            patComp.dataClass = dataClass;

            JoinArea joinArea = new JoinArea();
            joinArea.code = JOIN_AREA_CODE;
            joinArea.name = JOIN_AREA_NAME;
            patComp.joinArea = joinArea;

            DataType dataType = new DataType();
            dataType.dataTypeName = "住院数据";
            dataType.dataTypeValue = "2";
            patComp.dataType = dataType;

            ZyPatBaseData zyPat = new ZyPatBaseData();
            zyPat.hisID = zyPatlist.Nccm_NO;
            zyPat.area_id = JOIN_AREA_CODE;
            zyPat.medorg_code = MED_ORG_CODE;

            zyPat.person_code = zyPatlist.patientInfo.PatCode;
            zyPat.name = zyPatlist.patientInfo.PatName;
            zyPat.sex = zyPatlist.patientInfo.PatSex == "男" ? "1" : "2";

            zyPat.idCard = zyPatlist.patientInfo.PatNumber;
            zyPat.family_code = zyPatlist.patientInfo.FamilyCode;
            zyPat.medcard_id = zyPatlist.patientInfo.MediCard;

            zyPat.medorg_level = ((HospitalInfo)hospitalInfo).hos_level;

            zyPat.visit_type = "2";
            zyPat.comp_classs = "2";//?住院2
            zyPat.adm_date = zyPatlist.CureDate.ToString();//入院日期
            zyPat.status = "1";//(未补)//zyPatlist.CureState;//?

            zyPat.maindiag_code = zyPatlist.DiseaseCode;
            zyPat.dis_date = DateTime.Now.ToString();
            zyPat.is_midway = "1";//1,中途结算.2,出院结算



            patComp.zyPat = zyPat;


            patComp.zyDetail = prescriptions;
            patComp.uploadorg = MED_ORG_CODE;
            //调用接口预算功能

            CompResult compresult = NccmInterfaces.OutZYPatientBudegt(patComp);
            if (compresult.resultId)
                return Convert.ToDecimal(compresult.compData[0].comp_money);
            else
                throw new Exception("农合接口调用失败:" + compresult.resultString);

        }
        /// <summary>
        /// 出院结算
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        public object Charge(System.Collections.Hashtable hashtable)
        {
            FeeDetail[] prescriptions = (FeeDetail[])hashtable["FeeDetail"];
            string Is_midWay=hashtable["midWay"].ToString();
            string Nccm_NO = hashtable["Nccm_NO"].ToString();

            ZY_PresOrder zypo = new ZY_PresOrder();

            int[] presID = new int[prescriptions.Length];
            for (int i = 0; i < prescriptions.Length; i++)
            {
                presID[i] = Convert.ToInt32(prescriptions[i].item_sn);
            }
            zypo.UpdateComp(presID);//更新为上传标识



            PatientComp patComp = new PatientComp();
            patComp.uploadorg = "1";

            DataClass dataClass = new DataClass();
            dataClass.dataClassValue = "2";//门诊是1，住院是2
            patComp.dataClass = dataClass;

            JoinArea joinArea = new JoinArea();
            joinArea.code = JOIN_AREA_CODE;
            joinArea.name = JOIN_AREA_NAME;
            patComp.joinArea = joinArea;

            DataType dataType = new DataType();
            dataType.dataTypeName = "门诊数据";
            dataType.dataTypeValue = "2";
            patComp.dataType = dataType;


            ZyPatBaseData zyPat = new ZyPatBaseData();


            zyPat.area_id = JOIN_AREA_CODE;
            zyPat.medorg_code = MED_ORG_CODE;
            zyPat.hisID = zyPatlist.Nccm_NO;//zyPatlist.CureNo + zyPatlist.PatListID.ToString();
            zyPat.his_billno = Nccm_NO;
            zyPat.person_code = zyPatlist.patientInfo.PatCode;
            zyPat.name = zyPatlist.patientInfo.PatName;
            zyPat.sex = zyPatlist.patientInfo.PatSex == "男" ? "1" : "2";

            zyPat.idCard = zyPatlist.patientInfo.PatNumber;
            zyPat.family_code = zyPatlist.patientInfo.FamilyCode;
            zyPat.medcard_id = zyPatlist.patientInfo.MediCard;

            zyPat.medorg_level = ((HospitalInfo)hospitalInfo).hos_level;
            zyPat.is_midway = Is_midWay;//1,中途2出院
            zyPat.visit_type = "2";
            zyPat.comp_classs = "2";//?
            zyPat.adm_date = zyPatlist.CureDate.ToString();//入院日期
            zyPat.status = zyPatlist.CureState;//?
            zyPat.maindiag_code = zyPatlist.DiseaseCode;
            zyPat.dis_date = zyPatlist.OutDate.ToString();

            patComp.zyPat = zyPat;
            patComp.zyDetail = prescriptions;
            patComp.uploadorg = MED_ORG_CODE;

            CompResult CR = NccmInterfaces.OutZYPatientCharge(patComp);
            if (CR.resultId)
            {
                prescriptions = CR.feeDetail;
                presID = new int[prescriptions.Length];

                for (int i = 0; i < prescriptions.Length; i++)
                {
                    presID[i] = Convert.ToInt32(prescriptions[i].item_sn);
                }
                zypo.DelComp(presID);//更新上传失败的项目

                return Convert.ToDecimal(CR.compData[0].comp_money);
            }
            else
                throw new Exception("农合接口调用失败:" + CR.resultString);

        }
        /// <summary>
        /// 取消出院结算
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        public bool CancelCharge(System.Collections.Hashtable hashtable)
        {
            string Nccm_NO = hashtable["Nccm_NO"].ToString();

            BudgetFee hisData = new BudgetFee();


            JoinArea joinArea = new JoinArea();
            joinArea.code = JOIN_AREA_CODE;
            joinArea.name = JOIN_AREA_NAME;


            DataClass dataClass = new DataClass();
            dataClass.dataClassName = "新农合数据";
            dataClass.dataClassValue = "1";

            DataType dataType = new DataType();
            dataType.dataTypeName = "住院数据";
            dataType.dataTypeValue = "2";

            OperType operType = new OperType();
            operType.operTypeName = "取消登记";
            operType.operTypeValue = "7";

            ZyPatBaseData patBaseData = new ZyPatBaseData();
            patBaseData.hisID = zyPatlist.Nccm_NO;//zyPatlist.CureNo + zyPatlist.PatListID.ToString();
            patBaseData.area_id = JOIN_AREA_CODE;
            patBaseData.person_code = zyPatlist.patientInfo.PatCode;
            patBaseData.name = zyPatlist.patientInfo.PatName;
            patBaseData.idCard = zyPatlist.patientInfo.PatNumber;//?
            patBaseData.medcard_id = zyPatlist.patientInfo.MediCard;//?
            patBaseData.visit_type = "2";
            patBaseData.medorg_code = MED_ORG_CODE;

            patBaseData.his_billno = Nccm_NO;

            hisData.uploadPerson = ((HospitalInfo)hospitalInfo).userCode;

            hisData.joinArea = joinArea;
            hisData.dataClass = dataClass;
            hisData.dataType = dataType;
            hisData.operType = operType;
            hisData.zyPat = patBaseData;
            hisData.uploadorg = MED_ORG_CODE;
            NcmsResult retMsg = NccmInterfaces.CanOutPatZYCharge(hisData);
            if (retMsg.resultId)
                return true;
            else
            {
                throw new Exception("农合接口调用失败:" + retMsg.resultString);
            }
        }
        /// <summary>
        /// 住院病人费用上传
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        public bool UploadzyPatFee(System.Collections.Hashtable hashtable)
        {
            FeeDetail[] prescriptions = (FeeDetail[])hashtable["FeeDetail"];

            ZY_PresOrder zypo = new ZY_PresOrder();

            int[] presID = new int[prescriptions.Length];
            for (int i = 0; i < prescriptions.Length; i++)
            {
                presID[i] = Convert.ToInt32(prescriptions[i].item_sn);
            }
            zypo.UpdateComp(presID);//更新为上传标识

            BudgetFee hisData = new BudgetFee();
            JoinArea joinArea = new JoinArea();
            joinArea.code = JOIN_AREA_CODE;
            joinArea.name = JOIN_AREA_NAME;

            DataType dataType = new DataType();
            dataType.dataTypeName = "住院数据";
            dataType.dataTypeValue = "2";

            ZyPatBaseData zyPat = new ZyPatBaseData();
            zyPat.idCard = zyPatlist.patientInfo.PatNumber;//?
            zyPat.person_code = zyPatlist.patientInfo.PatCode;
            zyPat.hisID = zyPatlist.Nccm_NO;
            zyPat.area_id = JOIN_AREA_CODE;
            zyPat.medorg_code = MED_ORG_CODE;//?

            hisData.zyPat = zyPat;
            hisData.feeDetail = prescriptions;
            hisData.uploadorg = MED_ORG_CODE;//"40086695143010101A2201";//?
            hisData.dataType = dataType;
            hisData.joinArea = joinArea;

            RecieveDetailFeeResult result = NccmInterfaces.UploadZYPatFee(hisData);
            if (result.resultId)
            {
                prescriptions = result.feeDetail;
                presID = new int[prescriptions.Length];

                for (int i = 0; i < prescriptions.Length; i++)
                {
                    presID[i] = Convert.ToInt32(prescriptions[i].item_sn);
                }
                zypo.DelComp(presID);//更新上传失败的项目
                return true;
            }
            else
            {
                throw new Exception("农合接口调用失败:" + result.resultString);
            }
        }
        /// <summary>
        /// 下载病人费用
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        public object DownloadzyPatFee(System.Collections.Hashtable hashtable)
        {
            DownLoadItem hisData = new DownLoadItem();

            JoinArea joinArea = new JoinArea();
            joinArea.code = JOIN_AREA_CODE;
            joinArea.name = JOIN_AREA_NAME;

            DataType dataType = new DataType();
            dataType.dataTypeName = "住院数据";
            dataType.dataTypeValue = "2";


            Condition CARD_ID = new Condition();	//合作医疗证号			
            CARD_ID.condition_displayname = "合作医疗证号";
            CARD_ID.condition_name = "SN";
            CARD_ID.condition_value = zyPatlist.Nccm_NO;     //"20090408" ;   
            Condition[] conditions = new Condition[] { CARD_ID };

            hisData.uploadorg = MED_ORG_CODE;
            hisData.dataType = dataType;
            hisData.joinArea = joinArea;
            hisData.conditions = conditions;
            RecieveDetailFeeResult rdf = NccmInterfaces.DownLoadDetailFee(hisData);

            if (rdf.resultId)
            {
                return ConvertDT(rdf.feeDetail);
            }
            else
            {
                throw new Exception("农合接口调用失败:" + rdf.resultString);
            }
        }


        #endregion


        /// <summary>
        /// 处方明细信息转化为接口明细
        /// </summary>
        /// <param name="dt">处方信息</param>
        /// <returns></returns>
        public static FeeDetail[] ConvertFeeDetail(DataTable dt)
        {
            try
            {
                ZY_PresOrder zypo = new ZY_PresOrder();

                List<FeeDetail> fees = new List<FeeDetail>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    FeeDetail feeDetail = new FeeDetail();
                    feeDetail.his_billno = dt.Rows[i]["CostMasterID"].ToString();//结算ID
                    feeDetail.item_sn = dt.Rows[i]["PRESORDERID"].ToString();
                    feeDetail.item_code = dt.Rows[i]["ITEMID"].ToString();

                    feeDetail.item_class = Convert.ToInt32(dt.Rows[i]["PRESTYPE"].ToString().Trim()) >= 4 ? "2" : "1";
                    feeDetail.item_equal = "0";
                    feeDetail.item_name = dt.Rows[i]["ITEMNAME"].ToString();
                    feeDetail.item_use_time = DateTime.Now.ToString("yyyy-MM-dd");
                    feeDetail.amount = Convert.ToDouble(dt.Rows[i]["TOLAL_FEE"]) / Convert.ToDouble(dt.Rows[i]["SELL_PRICE"]);//Convert.ToDouble(dt.Rows[i]["AMOUNT"]);
                    feeDetail.drugform = "";
                    feeDetail.doctorTitle = dt.Rows[i]["PresDocCode"].ToString();
                    feeDetail.doctor = dt.Rows[i]["DocName"].ToString();
                    feeDetail.money = Convert.ToDouble(dt.Rows[i]["TOLAL_FEE"]);
                    feeDetail.price = Convert.ToDouble(dt.Rows[i]["SELL_PRICE"]);
                    feeDetail.center_item_code = dt.Rows[i]["NCMS_CODE"].ToString();
                    feeDetail.comp_ratio = Convert.ToDouble(dt.Rows[i]["Comp_Money"]) / 100;
                    feeDetail.specs = dt.Rows[i]["STANDARD"].ToString();
                    feeDetail.unit = dt.Rows[i]["PACKUNIT"].ToString();
                    feeDetail.nccm_comp_status = "0";
                    feeDetail.feeType = zypo.GetFPXM_Code(dt.Rows[i]["ITEMTYPE"].ToString());//费用类型
                    feeDetail.reverse_sn = dt.Rows[i]["OLDID"].ToString() == "0" ? "" : dt.Rows[i]["OLDID"].ToString();
                    feeDetail.reverse_status = feeDetail.reverse_sn == "" ? "0" : "2";
                    feeDetail.reverse_date = DateTime.Now.ToString("yyyy-MM-dd");

                    fees.Add(feeDetail);

                }
                return fees.ToArray();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 接口明细转化为处方明细
        /// </summary>
        /// <param name="feeDetail">接口明细</param>
        /// <returns></returns>
        public static DataTable ConvertDT(FeeDetail[] feeDetail)
        {
            try
            {
                List<ZY_PresOrder> list = new List<ZY_PresOrder>();
                for (int i = 0; i < feeDetail.Length; i++)
                {
                    ZY_PresOrder zypresorder = new ZY_PresOrder();

                    //feeDetail.his_billno = dt.Rows[i]["CostMasterID"].ToString();//结算ID
                    zypresorder.CostMasterID = Convert.ToInt32(feeDetail[i].his_billno == "" ? "0" : feeDetail[i].his_billno);
                    //feeDetail.item_sn = dt.Rows[i]["PRESORDERID"].ToString();
                    zypresorder.PresOrderID = Convert.ToInt32(feeDetail[i].item_sn == "" ? "0" : feeDetail[i].item_sn);
                    //feeDetail.item_code = dt.Rows[i]["ITEMID"].ToString();
                    zypresorder.ItemID = Convert.ToInt32(feeDetail[i].item_code == "" ? "0" : feeDetail[i].item_code);
                    //feeDetail.item_class = dt.Rows[i]["PRESTYPE"].ToString().Trim() == "4" ? "2" : "1";
                    zypresorder.PresType = feeDetail[i].item_class;
                    //feeDetail.item_equal = "0";
                    //feeDetail.item_name = dt.Rows[i]["ITEMNAME"].ToString();
                    zypresorder.ItemName = feeDetail[i].item_name;
                    //feeDetail.item_use_time = DateTime.Now.ToString("yyyy-MM-dd");
                    //feeDetail.amount = Convert.ToDouble(dt.Rows[i]["TOLAL_FEE"]) / Convert.ToDouble(dt.Rows[i]["SELL_PRICE"]);//Convert.ToDouble(dt.Rows[i]["AMOUNT"]);
                    zypresorder.Amount = Convert.ToDecimal(feeDetail[i].amount);
                    //feeDetail.drugform = "";
                    //feeDetail.doctorTitle = dt.Rows[i]["PresDocCode"].ToString();
                    zypresorder.PresDocCode = feeDetail[i].doctorTitle;
                    //feeDetail.doctor = dt.Rows[i]["DocName"].ToString();
                    zypresorder.DocName = feeDetail[i].doctor;
                    //feeDetail.money = Convert.ToDouble(dt.Rows[i]["TOLAL_FEE"]);
                    zypresorder.Tolal_Fee = Convert.ToDecimal(feeDetail[i].money);
                    //feeDetail.price = Convert.ToDouble(dt.Rows[i]["SELL_PRICE"]);
                    zypresorder.Sell_Price = Convert.ToDecimal(feeDetail[i].price);
                    //feeDetail.center_item_code = dt.Rows[i]["NCMS_CODE"].ToString();
                    //feeDetail.comp_ratio = Convert.ToDouble(dt.Rows[i]["Comp_Money"]) / 100;
                    zypresorder.Comp_Money = Convert.ToDecimal(feeDetail[i].comp_ratio);
                    //feeDetail.specs = dt.Rows[i]["STANDARD"].ToString();
                    zypresorder.Standard = feeDetail[i].specs;
                    //feeDetail.unit = dt.Rows[i]["PACKUNIT"].ToString();
                    zypresorder.PackUnit = feeDetail[i].unit;
                    //feeDetail.nccm_comp_status = "0";
                    zypresorder.CostDate = Convert.ToDateTime(feeDetail[i].item_use_time);

                    list.Add(zypresorder);
                }
                return HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(list);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 得到农合产生的编码
        /// </summary>
        /// <returns></returns>
        public static string GetNccmNo()
        {

            try
            {
                DateTime date = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;

                string datestr = date.ToString("yyyyMMdd");
                IpatListDao patlistDao = DaoFactory.GetObject<IpatListDao>(typeof(PatListDao));
                patlistDao.oleDb = BaseBLL.oleDb;
                string datestr2 = patlistDao.GetNewNccmNo(date);
                if (datestr2.Length == 1) datestr2 = "00" + datestr2;
                else if (datestr2.Length == 2) datestr2 = "0" + datestr2;
                return datestr + datestr2;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
