using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.BLL;

namespace HIS.MZDoc_BLL
{
    /// <summary>
    /// 门诊病人类
    /// </summary>
    public class Patient : BaseBLL
    {
        #region 自定义变量
        private HIS.Model.PatientInfo _patientInfo;
        private HIS.Model.MZ_PatList _patList;
        private string _feeTypeName;
        #endregion

        #region 属性
        /// <summary>
        /// 病人信息
        /// </summary>
        public HIS.Model.PatientInfo PatientInfo
        {
            get { return _patientInfo == null ? new HIS.Model.PatientInfo() : _patientInfo; }
            set { _patientInfo = value; }
        }
        /// <summary>
        /// 病人挂号信息
        /// </summary>
        public HIS.Model.MZ_PatList PatList
        {
            get { return _patList; }
            set { _patList = value; }
        }
        /// <summary>
        /// 费用类型
        /// </summary>
        public string FeeTypeName
        {
            get { return _feeTypeName; }
            set { _feeTypeName = value; }
        }
        #endregion

        #region 构造函数
        /// <summary>
        /// 门诊病人类构造函数
        /// </summary>
        public Patient()
        {
        }

        /// <summary>
        /// 门诊病人类构造函数
        /// </summary>
        /// <param name="visitNo">门诊号</param>
        public Patient(string visitNo)
        {
            _patList = BindEntity<Model.MZ_PatList>.CreateInstanceDAL(oleDb).GetModel(Tables.mz_patlist.VISITNO + "='" + CreateFormatVisitNo(visitNo) + "'");
            if (_patList == null)
            {
                _patList = new HIS.Model.MZ_PatList();
            }
            LoadPatientInfo();
        }

        /// <summary>
        /// 门诊病人类构造函数
        /// </summary>
        /// <param name="patListId">病人就诊Id</param>
        public Patient(long patListId)
        {
            _patList = BindEntity<Model.MZ_PatList>.CreateInstanceDAL(oleDb).GetModel(Tables.mz_patlist.PATLISTID + "=" + patListId);
            if (_patList == null)
            {
                _patList = new HIS.Model.MZ_PatList();
            }
            LoadPatientInfo();
        }

        /// <summary>
        /// 门诊病人类构造函数
        /// </summary>
        /// <param name="patList"></param>
        public Patient(HIS.Model.MZ_PatList patList)
        {
            this._patList = patList;
            LoadPatientInfo();
        }
        #endregion

        #region 病人操作
        /// <summary>
        /// 创建格式化的门诊号
        /// </summary>
        /// <param name="visitNo">门诊号</param>
        /// <returns></returns>
        private string CreateFormatVisitNo(string visitNo)
        {
            if ((visitNo.Length <= 4) && (visitNo.Length > 0))
            {
                while (visitNo.Length < 4)
                {
                    visitNo = "0" + visitNo;
                }
                visitNo = DateTime.Now.ToString("yyyyMMdd") + visitNo;
            }
            return visitNo;
        }

        /// <summary>
        /// 加载病人基本信息
        /// </summary>
        private void LoadPatientInfo()
        {
            _patientInfo = BindEntity<HIS.Model.PatientInfo>.CreateInstanceDAL(oleDb).GetModel((int)this.PatList.PatID);
            this._feeTypeName = HIS.MZDoc_BLL.OP_ReadBaseData.GetFeeTypeName(_patList.MediType);
        }

        /// <summary>
        /// 修改病人就诊状态
        /// </summary>
        /// <param name="status"></param>
        public void ChangeCureInfo(Public.PatCureStatus status)
        {
            string strwhere = Tables.mz_patlist.PATLISTID + oleDb.EuqalTo() + this._patList.PatListID + oleDb.And() + Tables.mz_patlist.CURESTATUS + oleDb.NotEqualTo() + Public.PatCureStatus.结束状态.GetHashCode();
            string[] strvalue = {Tables.mz_patlist.CUREEMPCODE+oleDb.EuqalTo()+"'"+Public.StaticConfig.CureDocCode+"'",
                                    Tables.mz_patlist.CUREDEPTCODE+oleDb.EuqalTo()+"'"+Public.StaticConfig.CureDeptCode+"'",
                                    Tables.mz_patlist.CURESTATUS+oleDb.EuqalTo()+status.GetHashCode()};
            BindEntity<Model.MZ_PatList>.CreateInstanceDAL(oleDb).Update(strwhere, strvalue);
        }

        /// <summary>
        /// 修改病人就诊诊断
        /// </summary>
        public void ChangeDiagnosis()
        {
            BindEntity<Model.MZ_PatList>.CreateInstanceDAL(oleDb).Update(this._patList);
            new CommonDiagnosis(oleDb).Increase(this._patList.DiseaseName, Public.StaticConfig.CureDocCode);
        }

        /// <summary>
        /// 结束就诊
        /// </summary>
        public void EndCure()
        {
            ChangeCureInfo(HIS.MZDoc_BLL.Public.PatCureStatus.结束状态);
        }

        /// <summary>
        /// 新增门诊号
        /// </summary>
        /// <returns></returns>
        public bool SavePatientInfo()
        {
            string[] pywb = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.GetPyWbCode(_patientInfo.PatName);
            if (_patientInfo.PatID <= 0)
            {
                _patientInfo.PYM = pywb[0];
                _patientInfo.WBM = pywb[1];
                GetPatBirthday();
                BindEntity<Model.PatientInfo>.CreateInstanceDAL(oleDb).Add(_patientInfo);
            }
            _patList.PatID = _patientInfo.PatID;
            _patList.PatName = _patientInfo.PatName;
            _patList.PatSex = _patientInfo.PatSex;
            _patList.PYM = pywb[0];
            _patList.WBM = pywb[1];

            //事务控制，避免同时更新门诊号
            oleDb.BeginTransaction();
            try
            {
                GetCurrentVisitNo();
                BindEntity<Model.MZ_PatList>.CreateInstanceDAL(oleDb).Add(_patList);
                oleDb.CommitTransaction();
                return true;
            }
            catch (Exception e)
            {
                oleDb.RollbackTransaction();
                throw e;
            }
        }

        /// <summary>
        /// 修改病人信息
        /// </summary>
        /// <returns></returns>
        public void UpdatePatientInfo()
        {
            string[] pywb = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.GetPyWbCode(_patientInfo.PatName);

            _patientInfo.PYM = pywb[0];
            _patientInfo.WBM = pywb[1];
            GetPatBirthday();
            BindEntity<Model.PatientInfo>.CreateInstanceDAL(oleDb).Update(_patientInfo);

            _patList.PYM = pywb[0];
            _patList.WBM = pywb[1];
            BindEntity<Model.MZ_PatList>.CreateInstanceDAL(oleDb).Update(_patList);
        }

        /// <summary>
        /// 计算病人出生日期
        /// </summary>
        private void GetPatBirthday()
        {
            switch (_patList.HpGrade)
            {
                case "岁":
                    _patientInfo.PatBriDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime.AddYears(0 - _patList.Age);
                    break;
                case "月":
                    _patientInfo.PatBriDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime.AddMonths(0 - _patList.Age);
                    break;
                case "天":
                    _patientInfo.PatBriDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime.AddDays(0 - _patList.Age);
                    break;
                case "小时":
                    _patientInfo.PatBriDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime.AddHours(0 - _patList.Age);
                    break;
                default:
                    _patientInfo.PatBriDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime.AddYears(0 - _patList.Age);
                    break;
            }
        }

        /// <summary>
        /// 获得当前门诊号
        /// </summary>
        private void GetCurrentVisitNo()
        {
            //计算病人门诊号
            Model.MZ_SERIAL_NO mz_serial_no = BindEntity<Model.MZ_SERIAL_NO>.CreateInstanceDAL(oleDb).GetModel("");
            if (mz_serial_no == null)
            {
                mz_serial_no = new HIS.Model.MZ_SERIAL_NO();
                mz_serial_no.VISIT_NO = 1;
                BindEntity<Model.MZ_SERIAL_NO>.CreateInstanceDAL(oleDb).Add(mz_serial_no);
            }
            mz_serial_no.VISIT_NO = mz_serial_no.VISIT_NO + 1;
            BindEntity<Model.MZ_SERIAL_NO>.CreateInstanceDAL(oleDb).Update(mz_serial_no);
            string visit_no_s = mz_serial_no.VISIT_NO.ToString("0000");
            string visit_no = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime.ToString("yyyyMMdd") + visit_no_s.Substring(visit_no_s.Length - 4);

            _patList.VisitNo = visit_no;
        }
        #endregion

        #region 处方操作
        /// <summary>
        /// 获得病人皮试处方
        /// </summary>
        /// <returns></returns>
        public DataTable GetSkinTestPres()
        {
            int presNo = 0;
            bool isControlSkinTest = OP_ReadBaseData.GetConfigValue("003").Trim() == "1";  //系统参数：是否控制未皮试和皮试阳性的药品不能收费
            //获取处方头列表信息
            List<Prescription> prescriptions = new List<Prescription>();
            List<PresHead> presHeads = isControlSkinTest ? 
                new PresHead(this._patList.PatListID,0).GetNoChangePresHeadList() : 
                new PresHead(this._patList.PatListID,0).GetNormalPresHeadList();
            foreach (PresHead presHead in presHeads)
            {
                //获取处方明细信息
                List<PresDetail> presLists = new PresDetail(presHead.PresHeadId).GetSkinTestPresDetailList();
                if (presLists.Count > 0)
                {
                    presNo++;
                    foreach (PresDetail presList in presLists)
                    {
                        Prescription prescription = new Prescription();
                        prescription = (Prescription)HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjectToObj(presList, prescription);
                        prescription.Dept_Id = presHead.Pres_ExeDept;
                        prescription.LoadData();
                        prescription.PresNo = presNo;
                        prescription.Status = (HIS.MZDoc_BLL.Public.PresStatus)presHead.Pres_Flag;
                        prescriptions.Add(prescription);
                    }
                }
            }
            return HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(prescriptions);
        }

        /// <summary>
        /// 获得病人输液处方
        /// </summary>
        /// <returns></returns>
        public DataTable GetTransfusionPres()
        {
            int presNo = 0;
            //获取处方头列表信息
            List<Prescription> prescriptions = new List<Prescription>();
            List<PresHead> presHeads = new PresHead(this._patList.PatListID,0).GetNormalPresHeadList();
            foreach (PresHead presHead in presHeads)
            {
                //获取处方明细信息
                List<PresDetail> presLists = new PresDetail(presHead.PresHeadId).GetTransPresDetailList();
                if (presLists.Count > 0)
                {
                    presNo++;
                    for (int i = 0; i < presLists.Count; i++)
                    {
                        Prescription prescription = new Prescription();
                        prescription = (Prescription)HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjectToObj(presLists[i], prescription);
                        prescription.Dept_Id = presHead.Pres_ExeDept;
                        prescription.OrderNo = i + 1;
                        prescription.LoadData();
                        prescription.PresNo = presNo;
                        prescription.Status = (HIS.MZDoc_BLL.Public.PresStatus)presHead.Pres_Flag;
                        prescription.Selected = true;
                        prescriptions.Add(prescription);
                    }
                }
            }
            return HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(prescriptions);
        }

        /// <summary>
        /// 获得病人处方
        /// </summary>
        /// <returns></returns>
        public DataTable GetPrescription(long presDocId)
        {
            int presNo = 0;
            InterFace.PrescMoneyCalculateInterFace PrescMoneyCalculateInterFace  = new InterFace.PrescMoneyCalculateInterFace();

            //获取处方头列表信息
            List<Prescription> prescriptions = new List<Prescription>();
            string strsql = HIS.BLL.Tables.mz_doc_preshead.PATLISTID + oleDb.EuqalTo() + this.PatList.PatListID
                + oleDb.And() + HIS.BLL.Tables.mz_doc_preshead.PRES_FLAG + oleDb.LessThan() + 3
                + oleDb.And() + HIS.BLL.Tables.mz_doc_preshead.PRES_DOC + oleDb.EuqalTo() + presDocId
                + oleDb.OrderBy(HIS.BLL.Tables.mz_doc_preshead.PRESHEADID);
            List<HIS.Model.Mz_Doc_PresHead> presHead = BindEntity<HIS.Model.Mz_Doc_PresHead>.CreateInstanceDAL(oleDb).GetListArray(strsql);
            for (int index = 0; index < presHead.Count; index++)
            {
                //获取处方明细信息
                List<PresDetail> presLists = new PresDetail(presHead[index].PresHeadId).GetAllPresDetailList();
                if (presLists.Count > 0)
                {
                    presNo++;
                    List<Prescription> presTemp = new List<Prescription>();
                    for (int i = 0; i < presLists.Count; i++)
                    {
                        Prescription prescription = new Prescription();
                        prescription = (Prescription)HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjectToObj(presLists[i], prescription);
                        prescription.Dept_Id = presHead[index].Pres_ExeDept;
                        prescription.LoadData();
                        prescription.PresNo = presNo;
                        prescription.Status = (HIS.MZDoc_BLL.Public.PresStatus)presHead[index].Pres_Flag;
                        prescription.Pres_Date = presHead[index].Pres_Date;
                        prescriptions.Add(prescription);
                        if (prescription.SelfDrug_Flag == 0 || !prescription.IsDrug)
                        {
                            presTemp.Add(prescription);
                        }
                    }
                    //插入小记
                    Prescription prescription0 = new Prescription();
                    prescription0.PresHeadId = presHead[index].PresHeadId;
                    prescription0.Dept_Id = presHead[index].Pres_ExeDept;
                    prescription0.Item_Name = "小计：";
                    prescription0.PresNo = presNo;
                    prescription0.OrderNo = presLists.Count + 1;
                    //2009-12-22 统一医生站和收费系统的处方费用合计
                    prescription0.Item_Money = (presTemp.Count <= 0) ? "0.0" : (PrescMoneyCalculateInterFace.GetPrescriptionTotalMoney(presTemp).ToString());//itemMoney.ToString();
                    prescription0.Status = (HIS.MZDoc_BLL.Public.PresStatus)presHead[index].Pres_Flag;
                    prescriptions.Add(prescription0);
                }
            }
            return HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(prescriptions);
        }

        /// <summary>
        /// 删除整张处方
        /// </summary>
        /// <param name="presHeadId">处方头ID</param>
        /// <returns></returns>
        public int DeletePres(int presHeadId)
        {
            try
            {
                HIS.Model.Mz_Doc_PresHead presHead = BindEntity<HIS.Model.Mz_Doc_PresHead>.CreateInstanceDAL(oleDb).GetModel(presHeadId);
                if (presHead.Pres_Flag > 0)
                {
                    return presHead.Pres_Flag;
                }
                presHead.Pres_Flag = 3;
                BindEntity<HIS.Model.Mz_Doc_PresHead>.CreateInstanceDAL(oleDb).Update(presHead);
                return presHead.Pres_Flag;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 保存处方
        /// </summary>
        /// <param name="prescriptions">处方明细列表</param>
        /// <returns></returns>
        public bool SavePrescription(List<Prescription> prescriptions)
        {
            oleDb.BeginTransaction();
            try
            {
                int presNo = 0;
                int presHeadNo = 0;
                foreach (Prescription prescription in prescriptions)
                {
                    if (prescription.PresHeadId > 0)
                    {
                        Model.Mz_Doc_PresHead presHead = BindEntity<Model.Mz_Doc_PresHead>.CreateInstanceDAL(oleDb).GetModel(prescription.PresHeadId);
                        if (presHead.Pres_Flag > 0)
                        {
                            continue;
                        }
                    }
                    prescription.SetRealValue();
                    if (prescription.IsDrug)
                    {
                        HIS.Interface.YP_Data ypdata=new HIS.Interface.YP_Data ();
                        decimal sell_price=0;
                        decimal buy_price=0;
                        decimal currentstorenum=0;
                        ypdata.GetDrugStorInfo(prescription.Item_Id, prescription.Dept_Id, out sell_price, out buy_price,out  currentstorenum);
                        if (Convert.ToDecimal(prescription.Item_Amount) > currentstorenum)
                        {
                            throw new Exception("" + prescription.Item_Name + "开药总数量大于当前库存，请重开");
                        }
                    }
                    if (prescription.Status == HIS.MZDoc_BLL.Public.PresStatus.新建状态)
                    {
                        if (prescription.PresHeadId == 0)
                        {
                            if (prescription.PresNo != presNo)
                            {
                                presNo = prescription.PresNo;
                                HIS.Model.Mz_Doc_PresHead presHead = new HIS.Model.Mz_Doc_PresHead();
                                presHead.PatId = (int)this.PatList.PatID;
                                presHead.PatListId = this.PatList.PatListID;
                                presHead.PresType = prescription.IsDrug ? prescription.StatItem_Code : "00";
                                presHead.Pres_Doc = Public.StaticConfig.CureDocCode;
                                presHead.Pres_Dept = Public.StaticConfig.CureDeptCode;
                                presHead.Pres_ExeDept = prescription.Dept_Id;
                                presHead.Pres_Date = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                                presHeadNo = BindEntity<Model.Mz_Doc_PresHead>.CreateInstanceDAL(oleDb).Add(presHead);
                            }
                            prescription.PresHeadId = presHeadNo;
                        }
                        BindEntity<Model.Mz_Doc_PresList>.CreateInstanceDAL(oleDb).Add(prescription);

                        // 累计常用项
                        if (prescription.IsDrug)
                        {
                            new CommonDrug(oleDb).Increase(prescription.Item_Id, Public.StaticConfig.CureDocCode);
                        }
                        else
                        {
                            new CommonItem(oleDb).Increase(prescription.Item_Id, Public.StaticConfig.CureDocCode);
                        }
                    }
                    else if (prescription.Status == HIS.MZDoc_BLL.Public.PresStatus.修改状态)
                    {
                        BindEntity<Model.Mz_Doc_PresList>.CreateInstanceDAL(oleDb).Update(prescription);
                    }
                }
                oleDb.CommitTransaction();
                this.ChangeCureInfo(HIS.MZDoc_BLL.Public.PatCureStatus.候诊状态);
                return true;
            }
            catch (Exception e)
            {
                oleDb.RollbackTransaction();
                throw e;
            }
        }
        #endregion

        #region 医技申请操作
        /// <summary>
        /// 保存医技申请
        /// </summary>
        /// <param name="medicalApplyList">医技申请列表</param>
        /// <returns></returns>
        public bool SaveMedicalApply(IList medicalApplyList)
        {
            if (medicalApplyList != null && medicalApplyList.Count > 0)
            {
                CommonItem commonItem = new CommonItem(oleDb);
                oleDb.BeginTransaction();
                try
                {
                    int presHeadNo = AddNewPresHead(medicalApplyList);

                    int index = 0;
                    foreach (BaseMedical medicalApply in medicalApplyList)
                    {
                        if (medicalApply.Status == HIS.MZDoc_BLL.Public.PresStatus.新建状态)
                        {
                            if (medicalApply.PresListId <= 0)
                            {
                                index++;
                                medicalApply.PresListId = AddNewPresList(presHeadNo, index, medicalApply);

                                // 累计常用项
                                commonItem.Increase(medicalApply.Item_Id, Public.StaticConfig.CureDocCode);
                            }
                            medicalApply.PatId = (int)this.PatList.PatID;
                            medicalApply.PatListId = this.PatList.PatListID;
                            medicalApply.Apply_Doc = Public.StaticConfig.CureDocCode;
                            medicalApply.Apply_Dept = Public.StaticConfig.CureDeptCode;
                            BindEntity<Model.Mz_Doc_Medical_Apply>.CreateInstanceDAL(oleDb).Add(medicalApply);
                        }
                        else if (medicalApply.Status == HIS.MZDoc_BLL.Public.PresStatus.修改状态)
                        {
                            medicalApply.Apply_Date = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                            BindEntity<Model.Mz_Doc_Medical_Apply>.CreateInstanceDAL(oleDb).Update(medicalApply);
                        }
                    }
                    oleDb.CommitTransaction();
                    return true;
                }
                catch (Exception e)
                {
                    oleDb.RollbackTransaction();
                    throw e;
                }
            }
            return false;
        }

        /// <summary>
        /// 添加新处方头
        /// </summary>
        /// <param name="medicalApplyList"></param>
        /// <returns></returns>
        private int AddNewPresHead(IList medicalApplyList)
        {
            HIS.Model.Mz_Doc_PresHead presHead = new HIS.Model.Mz_Doc_PresHead();
            presHead.PatId = (int)this.PatList.PatID;
            presHead.PatListId = this.PatList.PatListID;
            presHead.PresType = "00";
            presHead.Pres_Doc = Public.StaticConfig.CureDocCode;
            presHead.Pres_Dept = Public.StaticConfig.CureDeptCode;
            presHead.Pres_ExeDept = ((BaseMedical)medicalApplyList[0]).Dept_Id;
            presHead.Pres_Date = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
            return BindEntity<Model.Mz_Doc_PresHead>.CreateInstanceDAL(oleDb).Add(presHead);
        }

        /// <summary>
        /// 添加新处方明细
        /// </summary>
        /// <param name="presHeadNo"></param>
        /// <param name="index"></param>
        /// <param name="medicalApply"></param>
        /// <returns></returns>
        private int AddNewPresList(int presHeadNo, int index, BaseMedical medicalApply)
        {
            Model.Mz_Doc_PresList presList = new HIS.Model.Mz_Doc_PresList();
            presList.PresHeadId = presHeadNo;
            presList.OrderNo = index;
            presList.StatItem_Code = medicalApply.StatItem_Code;
            presList.Item_Id = medicalApply.Item_Id;
            presList.Item_Name = medicalApply.Item_Name;
            presList.Item_Price = medicalApply.Price;
            presList.Buy_Price = medicalApply.Price;
            presList.Sell_Price = medicalApply.Price;
            presList.Usage_Amount = medicalApply.Num;
            presList.Usage_Unit = medicalApply.Unit;
            presList.Usage_Rate = 1;
            presList.Dosage = 1;
            presList.Usage_Id = 0;
            presList.Frequency_Id = 0;
            presList.Days = 1;
            presList.Item_Amount = medicalApply.Num;
            presList.Item_Unit = medicalApply.Unit;
            presList.Item_Rate = 1;
            presList.RelationNum = 1;
            presList.Unit = medicalApply.Unit;
            presList.Tc_Flag = medicalApply.Tc_Flag;
            presList.Service_Item_Id = medicalApply.Service_Item_Id;

            return BindEntity<Model.Mz_Doc_PresList>.CreateInstanceDAL(oleDb).Add(presList);
        }

        /// <summary>
        /// 获得病人本次就诊的医技申请列表
        /// </summary>
        /// <param name="medicalApplyType"></param>
        /// <returns></returns>
        public DataTable GetCurrentMedicalApplyList(Public.MedicalApplyType medicalApplyType)
        {
            string strsql = Views.vi_mz_medical_apply.PATID + oleDb.EuqalTo() + this.PatList.PatID
                + oleDb.And() + Views.vi_mz_medical_apply.PATLISTID + oleDb.EuqalTo() + this.PatList.PatListID
                + oleDb.And() + Views.vi_mz_medical_apply.APPLY_DOC + oleDb.EuqalTo() + Public.StaticConfig.CureDocCode
                + oleDb.And() + Views.vi_mz_medical_apply.APPLY_TYPE + oleDb.EuqalTo() + medicalApplyType.GetHashCode();
            DataTable table = BindEntity<object>.CreateInstanceDAL(oleDb, HIS.BLL.Views.VI_MZ_MEDICAL_APPLY).GetList(strsql);
            IList medicalApplyList = MedicalApplyFactory.CreateMedicalApplyObject(medicalApplyType, table);
            return Public.Function.ListToDataTable(medicalApplyList, MedicalApplyFactory.CreateMedicalApplyObject(medicalApplyType));
        }

        /// <summary>
        /// 获得已产生报告的医技申请列表
        /// </summary>
        /// <param name="bDate">开始时间</param>
        /// <param name="eDate">结束时间</param>
        /// <returns></returns>
        public DataTable GetMedicalApplyReportList(DateTime bDate, DateTime eDate)
        {
            DAL.MZDoc_DAL mzdoc_dal = new HIS.DAL.MZDoc_DAL(oleDb);
            return mzdoc_dal.Load_MedicalApplyList(Convert.ToInt64(this._patList.PatID), bDate, eDate);
        }
        #endregion
    }
}
