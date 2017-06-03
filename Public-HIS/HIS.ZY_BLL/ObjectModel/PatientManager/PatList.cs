using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using HIS.SYSTEM.Core;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.ZY_BLL.ObjectModel.PatientManager;
using HIS.ZY_BLL.ObjectModel.AOP;
//using HIS.ZY_BLL.ObjectModel.NccmManager;
using HIS.ZY_BLL.Dao.PatientManager;
using HIS.ZY_BLL.Dao;
using HIS.ZY_BLL.ObjectModel.CostManager;
using HIS.ZY_BLL.ObjectModel;
using HIS.ZY_BLL.ObjectModel.BaseData;

namespace HIS.ZY_BLL.DataModel
{
    /// <summary>
    /// 获取住院病人列表的类型
    /// </summary>
    public enum BindPatListType
    {
        住院病人列表,
        费用清单病人列表
        //费用结算病人列表,
        //住院医生病人列表,
        //住院护士病人列表,
        //统领发药病人列表
    }
    //[20100513.1.02]
    /// <summary>
    /// 获取住院病人列表的参数
    /// </summary>
    public struct BindPatListVal
    {
        /// <summary>
        /// 是否在院
        /// </summary>
        public bool IsIn;
        /// <summary>
        /// 病人当前科室
        /// </summary>
        public string DeptCode;
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? Bdate;
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? Edate;
        /// <summary>
        /// 住院号
        /// </summary>
        public string CureNo;
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatName;
        /// <summary>
        /// 是否为手术病人
        /// </summary>
        public bool IsOperation;
        /// <summary>
        /// 结算（出院未结算）
        /// </summary>
        public bool IsCost;
    }

    /// <summary>
    /// 病人类
    /// </summary>
    //[AopProxy(typeof(NccmProxyFactory))]
    partial class ZY_PatList : Iilinic,IbaseDao
    {

        private PatientInfo _patientInfo;
        /// <summary>
        /// 病人信息
        /// </summary>
        public PatientInfo patientInfo
        {
            set { _patientInfo = value; }
            get
            {
                //_patientInfo=null 并且 ZY_PatList.PatID !=0
                //ZY_PatList.PatID !=0 并且 _patientInfo.PatID == 0 也就是说 _patientInfo!=null  从数据库里找出该病人数据
                if ((_patientInfo == null && PatID != 0) || (PatID != 0 && _patientInfo.PatID == 0))
                {
                    _patientInfo = HIS.SYSTEM.Core.BindEntity<PatientInfo>.CreateInstanceDAL(oleDb).GetModel(PatID);
                }
                //_patientInfo=null 并且 ZY_PatList.PatID ==0 就创建空实例
                else if (_patientInfo == null && PatID == 0)
                {
                    _patientInfo = new PatientInfo();
                }
                return _patientInfo;
            }
        }

        private string _MarkEmpName;

        //[20100610.1.08]
        /// <summary>
        /// 登记人名称
        /// </summary>
        public string MarkEmpName
        {
            get
            {
                _MarkEmpName = BaseNameFactory.GetName(baseNameType.用户名称, this.MarkEmpCode);
                return _MarkEmpName;
            }
        }

        #region IbaseDao 成员
        private RelationalDatabase _OleDb;
        /// <summary>
        /// 数据库操作对象
        /// </summary>
        public RelationalDatabase oleDb
        {
            get
            {
                if (_OleDb == null)
                    _OleDb = BaseBLL.oleDb;
                return _OleDb;
            }
            set
            {
                _OleDb = value;
            }
        }
        #endregion


        private BindPatListType _bindPatListType = BindPatListType.住院病人列表;
        /// <summary>
        /// 获取病人列表类型
        /// </summary>
        public BindPatListType bindPatListType
        {
            get
            {
                return _bindPatListType;
            }
            set
            {
                _bindPatListType = value;
            }
        }

        private BindPatListVal _bindPatListVal;
        /// <summary>
        /// 获取病人列表参数
        /// </summary>
        public BindPatListVal bindPatListVal
        {
            get
            {
                return _bindPatListVal;
            }
            set
            {
                _bindPatListVal = value;
            }
        }

        public ZY_PatList()
        {
            oleDb = BaseBLL.oleDb;
        }

        public ZY_PatList(RelationalDatabase _oledb)
        {
            oleDb = _oledb;
        }
        /// <summary>
        /// 得到新病人的住院号
        /// </summary>
        /// <returns>住院号</returns>
        public string GetPatNo()
        {
            try
            {
                IpatListDao patlistDao = DaoFactory.GetObject<IpatListDao>(typeof(PatListDao));
                patlistDao.oleDb = oleDb;
                return patlistDao.GetNewCureNo().ToString();
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message+"获取住院号失败！");
            }
        }

        /// <summary>
        /// 入院，保存病人信息
        /// </summary>
        /// <returns></returns>
        [MethodAopSwitcher(true)]
        public void Add()
        {
            try
            {
                oleDb.BeginTransaction();
                patientInfo.oleDb = oleDb;
                patientInfo.Add();

                this.PatID = this.patientInfo.PatID;
                this.PatType = "1";//update zenghao 091013
                this.OutDate = new DateTime();
                BindEntity<ZY_PatList>.CreateInstanceDAL(oleDb).Add(this);
                oleDb.CommitTransaction();
            }
            catch (System.Exception e)
            {
                oleDb.RollbackTransaction();
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 取消病人入院
        /// </summary>
        /// <param name="zypatlist"></param>
        /// <returns></returns>
        [MethodAopSwitcher(true)]
        public void Delete()
        {
            if (BindEntity<HIS.Model.ZY_NURSE_BED>.CreateInstanceDAL(oleDb).Exists("patlist_id=" + this.PatListID + ""))
            {
                throw new Exception("该病人已有床位分配，请先取消床位分配再取消入院!");
            }
            try
            {

                //NccmCheck_CancelPatient(zypatlist);
                //?判断病人费用是否为0
                IcostManager icM = ObjectFactory.GetObject<IcostManager>(typeof(ZY_CostMaster));
                icM.PatListID = this.PatListID;
                PatFee patFee = icM.GetPatFee();
                if (patFee.chargeFee != 0 || patFee.costFee != 0)
                {
                    throw new Exception("该病人产生了费用，不允许取消入院！");
                }

                this.PatType = "6";
                BindEntity<ZY_PatList>.CreateInstanceDAL(oleDb).Update(this);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 修改病人信息
        /// </summary>
        /// <returns></returns>
        [MethodAopSwitcher(true)]
        public void Update()
        {
            try
            {

                if (getPatType() == this.PatType)
                {
                    try
                    {
                        oleDb.BeginTransaction();
                        patientInfo.oleDb = oleDb;
                        patientInfo.Update();
                        BindEntity<ZY_PatList>.CreateInstanceDAL(oleDb).Update(this);
                        oleDb.CommitTransaction();
                    }
                    catch (System.Exception e)
                    {
                        oleDb.RollbackTransaction();
                        throw new Exception(e.Message);
                    }
                }
                else
                {
                    throw new Exception("病人类型已经发生更改请先刷新病人列表！");
                }

            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        //[20100513.1.02]
        /// <summary>
        /// 得到在院病人
        /// </summary>
        /// <returns></returns>
        private string InBindPatList()
        {
            string strwhere="";

            if (bindPatListVal.Bdate != null && bindPatListVal.Edate != null)
            {
                strwhere += "   date(CUREDATE)>='" + bindPatListVal.Bdate + "' and date(CUREDATE)<='" + bindPatListVal.Edate + "' and ";
            }

            if (bindPatListVal.DeptCode != null && bindPatListVal.IsOperation==false)
            {
                strwhere += "   (case when CURRDEPTCODE='' then  CUREDEPTCODE  else CURRDEPTCODE  end)='" + bindPatListVal.DeptCode + "' and ";
            }

            if (bindPatListVal.CureNo != null)
            {
                strwhere += "  cureno = '" + bindPatListVal.CureNo + "' and ";
            }

            if (bindPatListVal.PatName != null)
            {
                string str = " (PATNAME like '%" + bindPatListVal.PatName + "%' or PYM like '%" + bindPatListVal.PatName + "%' ) and cureno<>''";
                DataTable dt = BindEntity<PatientInfo>.CreateInstanceDAL(oleDb).GetList(str, "PATID");
                str = GetPatStrWhere(dt, str);
                if (str == null)
                    strwhere += "  patid = -1 and ";
                else
                    strwhere += "  patid in " + str + " and ";
            }
            if (bindPatListVal.IsOperation == true)
            {
                string str = " DELETE_FLAG=0 and FINISH_FLAG=0 ";
                DataTable dt = BindEntity<object>.CreateInstanceDAL(oleDb, "SS_ARRANGE").GetList(str, "patlistid");
                str = GetPatStrWhere(dt, str);
                if (str == null)
                    strwhere += "  patlistid = -1 and ";
                else
                    strwhere += "  patlistid in " + str + " and ";
            }

            switch (bindPatListType)
            {
                case BindPatListType.住院病人列表://
                    strwhere += " (PATTYPE='1' or PATTYPE ='2' or PATTYPE ='7')";
                    strwhere += " order by CureNo,patlistid  ";
                    break;
                case BindPatListType.费用清单病人列表:
                    strwhere += "  (PATTYPE ='2' or PatTYPE='7') and bedcode<>'' ";
                    strwhere += " order by cast(Replace(bedcode,'加','100') as integer),CureNo,patlistid";
                    break;
            }

         
            return strwhere;
        }
        //[20100513.1.02]
        /// <summary>
        /// 得到出院病人
        /// </summary>
        /// <returns></returns>
        private string OutBindPatList()
        {
            string strwhere="";

            if (bindPatListVal.Bdate != null && bindPatListVal.Edate != null)
            {
                strwhere += " date(OUTDATE)>='" + bindPatListVal.Bdate + "' and date(OUTDATE)<='" + bindPatListVal.Edate + "' and ";
            }

            if (bindPatListVal.DeptCode != null)
            {
                strwhere += " (case when CURRDEPTCODE='' then  CUREDEPTCODE  else CURRDEPTCODE  end)='" + bindPatListVal.DeptCode + "' and ";
            }

            if (bindPatListVal.CureNo != null)
            {
                strwhere += "  cureno = '" + bindPatListVal.CureNo + "' and ";
            }

            if (bindPatListVal.PatName != null)
            {
                string str = " (PATNAME like '%" + bindPatListVal.PatName + "%' or PYM like '%" + bindPatListVal.PatName + "%' ) and cureno<>''";
                DataTable dt = BindEntity<PatientInfo>.CreateInstanceDAL(oleDb).GetList(str, "PATID");
                str = GetPatStrWhere(dt,str);
                if (str == null)
                    strwhere += "  patid = -1 and ";
                else
                    strwhere += "  patid in " + str + " and ";
            }

           

            switch (bindPatListType)
            {
                case BindPatListType.住院病人列表://
                    if (bindPatListVal.IsCost == true)
                    {
                        strwhere += " (PATTYPE='3') ";
                    }
                    else
                    {
                        strwhere += " (PATTYPE ='4' or PATTYPE ='5') ";
                    }
                    strwhere += " order by CureNo,patlistid ";
                    break;
                case BindPatListType.费用清单病人列表:
                    if (bindPatListVal.IsCost == true)
                    {
                        strwhere += " (PATTYPE='3') ";
                    }
                    else
                    {
                        strwhere += " (PATTYPE ='4' or PATTYPE ='5') ";
                    }
                    strwhere += "   and bedcode<>'' ";
                    strwhere += " order by cast(Replace(bedcode,'加','100') as integer),CureNo,patlistid";
                    break;
            }
           
            return strwhere;
        }

        /// <summary>
        /// 得到全部在院病人列表
        /// </summary>
        /// <returns></returns>
        public List<ZY_PatList> BindPatList()
        {
            try
            {
                string strwhere;
                if (bindPatListVal.IsIn)
                {
                    strwhere = InBindPatList();
                }
                else
                {
                    strwhere = OutBindPatList();
                }
                return BindEntity<ZY_PatList>.CreateInstanceDAL(oleDb).GetListArray(strwhere);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        

        private string GetPatStrWhere(DataTable dt,string strWhere)
        {
            string str = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("(");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i != dt.Rows.Count - 1)
                        sb.Append(dt.Rows[i][0].ToString() + ",");
                    else
                        sb.Append(dt.Rows[i][0].ToString() + ")");
                }
                str = sb.ToString();
            }
            return str;
        }

        #region Iilinic 成员
        /// <summary>
        /// 根据住院号得到病人信息
        /// </summary>
        /// <param name="CureNo">住院号</param>
        /// <returns></returns>
        public ZY_PatList GetPatInfo(string CureNo)
        {
            try
            {
                //[20100628.0.07]
                string strWhere = "CURENO ='" + CureNo + "' and PATTYPE<>'6' order by PATLISTID desc " + oleDb.FETCH();
                return BindEntity<ZY_PatList>.CreateInstanceDAL(oleDb).GetModel(strWhere);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 根据住院号得到病人信息
        /// </summary>
        /// <param name="CureNo">病人列表ID</param>
        /// <returns></returns>
        public ZY_PatList GetPatInfo(int patlistid)
        {
            try
            {
                string strWhere =" PATLISTID =" + patlistid;
                return BindEntity<ZY_PatList>.CreateInstanceDAL(oleDb).GetModel(strWhere);

            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 更新经治医生
        /// </summary>
        /// <param name="EmpID"></param>
        public void updateCureDoc(string EmpID)
        {
            BindEntity<ZY_PatList>.CreateInstanceDAL(oleDb).Update(" patlistid=" + this.PatListID, "CUREDOCCODE='" + EmpID + "'");
        }
        /// <summary>
        /// 更新病人类型
        /// </summary>
        /// <param name="pattype"></param>
        public void updatePatType(string pattype)
        {
            BindEntity<ZY_PatList>.CreateInstanceDAL(oleDb).Update(" patlistid=" + this.PatListID, "PATTYPE='" + pattype + "'");
        }
        /// <summary>
        /// 更新当前科室
        /// </summary>
        /// <param name="DeptID"></param>
        public void updateCurrDept(string DeptID)
        {
            BindEntity<ZY_PatList>.CreateInstanceDAL(oleDb).Update(" patlistid=" + this.PatListID, "CURRDEPTCODE='" + DeptID + "'");
        }
        /// <summary>
        /// 更新床位号
        /// </summary>
        /// <param name="bedcode"></param>
        public void updateBedCode(string bedcode)
        {
            BindEntity<ZY_PatList>.CreateInstanceDAL(oleDb).Update(" patlistid=" + this.PatListID, "bedcode='"+bedcode+"'");
        }
        /// <summary>
        /// 病人定义出院修改
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="diagncode"></param>
        /// <param name="diagnname"></param>
        /// <param name="outdate"></param>
        public void updatePatOut(int flag, string diagncode, string diagnname, DateTime outdate)
        {
            string strWhere = " patlistid=" + this.PatListID;
            string[] FieldNameAndValues = new string[4];
            FieldNameAndValues[0] = "out_flag=" + flag;
            FieldNameAndValues[1] = "OUTDIAGNCODE='" + diagncode + "'";
            FieldNameAndValues[2] = "OUTDIAGNNAME='" + diagnname + "'";
            FieldNameAndValues[3] = "OUTDATE='" + outdate + "'";
            BindEntity<ZY_PatList>.CreateInstanceDAL(oleDb).Update(strWhere, FieldNameAndValues);
        }
        /// <summary>
        /// 得到病人类型
        /// </summary>
        /// <returns></returns>
        public string getPatType()
        {
             object obj = BindEntity<ZY_PatList>.CreateInstanceDAL(oleDb).GetFieldValue("PATTYPE", "patlistid=" + this.PatListID);
             if (obj != null)
             {
                 return obj.ToString();
             }
            return "";
        }

        #endregion
    }
}