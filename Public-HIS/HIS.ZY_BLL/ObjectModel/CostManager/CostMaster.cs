using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


using HIS.ZY_BLL.Dao;
using HIS.ZY_BLL.Dao.ChargeListManager;
using HIS.ZY_BLL.Dao.PresManager;
using HIS.ZY_BLL.Dao.CostManager;
using HIS.SYSTEM.Core;
using HIS.ZY_BLL.Dao.PatientManager;
using HIS.ZY_BLL.ObjectModel.AOP;
using HIS.ZY_BLL.ObjectModel.CostManager;
using HIS.ZY_BLL.ObjectModel.BaseData;

namespace HIS.ZY_BLL.DataModel
{
    //[AopProxy(typeof(NccmProxyFactory))]
    partial class ZY_CostMaster : IbaseDao, ICloneable, IcostManager
    {
        #region IbaseDao 成员
        private HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase _oleDb;
        public HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase oleDb
        {
            get
            {
                return _oleDb;
            }
            set
            {
                _oleDb = value;
            }
        }

        #endregion

        private string _UserName;
        /// <summary>
        /// 结算人
        /// </summary>
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        private string _CureNo;
        /// <summary>
        /// 住院号
        /// </summary>
        public string CureNo
        {
            get { return _CureNo; }
            set { _CureNo = value; }
        }

        private string _PatName;
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatName
        {
            get { return _PatName; }
            set { _PatName = value; }
        }
        private string _DeptName;
        /// <summary>
        /// 病人科室
        /// </summary>       
        public string DeptName
        {
            get { return _DeptName; }
            set { _DeptName = value; }
        }

        private string _CostType;
        /// <summary>
        /// 结算类型名称
        /// </summary>
        public string CostType
        {
            get { return _CostType; }
            set { _CostType = value; }
        }


        /// <summary>
        /// 加载上面数据
        /// </summary>
        public void LoadData()
        {
            this.UserName = BaseNameFactory.GetName(baseNameType.用户名称, this.ChargeCode);//HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserName(this.ChargeCode);
            this.CureNo = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetCureNo(this.PatListID);
            this.PatName = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetPatName(this.PatID);
           // this.DeptName = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetPatDept(this.PatListID);
            IcostDao costdao = DaoFactory.GetObject<IcostDao>(typeof(CostDao)); //显示病人当前在院科室
            costdao.oleDb = oleDb;
            this.DeptName = costdao.GetDeptName(this.PatListID);
            if (this.Ntype == 1)
            {
                this.CostType = "中途";
            }
            else if (this.Ntype == 2)
            {
                this.CostType = "出院";
            }
            else
            {
                this.CostType = "欠费";
            }
        }

        #region ICloneable 成员

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion

        public ZY_CostMaster()
        {
            _oleDb = BaseBLL.oleDb;
        }

        public ZY_CostMaster(HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase _OleDb)
        {
            _oleDb = _OleDb;
        }


        /// <summary>
        /// 病人显示费用
        /// </summary>
        /// <returns></returns>
        public PatFee GetPatFee()
        {

            try
            {
                PatFee patFee = new PatFee();

                IchargeListDao icLD = DaoFactory.GetObject<IchargeListDao>(typeof(ChargeListDao));
                icLD.oleDb = oleDb;
                IpresDao ipD = DaoFactory.GetObject<IpresDao>(typeof(PresDao));
                ipD.oleDb = oleDb;
                IcostDao icD = DaoFactory.GetObject<IcostDao>(typeof(CostDao));
                icD.oleDb = oleDb;

                //得到中结后的累计预交金
                patFee.chargeFee = Convert.ToDecimal(icLD.GetNoCostAll_Fee(this.PatListID).ToString("0.00"));

                //得到所有记账处方未结算的费用
                patFee.costFee = Convert.ToDecimal(ipD.GetNoCostAll_Fee(this.PatListID).ToString("0.00"));

                //string patientCode = OP_PatientObject.GetPatInfo(patlistid).PatientCode;
                //优惠
                patFee.faoverFee = 0;//Convert.ToDecimal(zy_chargelist.ZY_PresMaster_GetfaoverAll_Fee(patlistid, patientCode, patFee.costFee).ToString("0.00"));
                //农合
                patFee.villageFee = Convert.ToDecimal(icD.GetvillageAll_Fee(this.PatListID).ToString("0.00"));
                //自付
                patFee.selfFee = patFee.costFee - (patFee.faoverFee + patFee.villageFee);
                //余额
                patFee.surplusFee = patFee.chargeFee - patFee.selfFee;
                //补收
                patFee.receiveFee = patFee.surplusFee < 0 ? (0 - patFee.surplusFee) : 0;
                //应退
                patFee.retreatFee = patFee.surplusFee >= 0 ? patFee.surplusFee : 0;


                patFee.surplusFee = Convert.ToDecimal(patFee.surplusFee.ToString("0.00"));
                patFee.receiveFee = Convert.ToDecimal(patFee.receiveFee.ToString("0.00"));
                patFee.retreatFee = Convert.ToDecimal(patFee.retreatFee.ToString("0.00"));
                return patFee;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //[20100603.0.04]
        /// <summary>
        /// 病人显示费用
        /// </summary>
        /// <param name="costdate">记账时间</param>
        /// <returns></returns>
        public PatFee GetPatFee(DateTime costdate)
        {

            try
            {
                PatFee patFee = new PatFee();

                IchargeListDao icLD = DaoFactory.GetObject<IchargeListDao>(typeof(ChargeListDao));
                icLD.oleDb = oleDb;
                IpresDao ipD = DaoFactory.GetObject<IpresDao>(typeof(PresDao));
                ipD.oleDb = oleDb;
                IcostDao icD = DaoFactory.GetObject<IcostDao>(typeof(CostDao));
                icD.oleDb = oleDb;

                //得到中结后的累计预交金
                patFee.chargeFee = Convert.ToDecimal(icLD.GetNoCostAll_Fee(this.PatListID,costdate).ToString("0.00"));

                //得到所有记账处方未结算的费用
                patFee.costFee = Convert.ToDecimal(ipD.GetNoCostAll_Fee(this.PatListID,costdate).ToString("0.00"));

                //string patientCode = OP_PatientObject.GetPatInfo(patlistid).PatientCode;
                //优惠
                patFee.faoverFee = 0;//Convert.ToDecimal(zy_chargelist.ZY_PresMaster_GetfaoverAll_Fee(patlistid, patientCode, patFee.costFee).ToString("0.00"));
                //农合
                patFee.villageFee = Convert.ToDecimal(icD.GetvillageAll_Fee(this.PatListID,costdate).ToString("0.00"));
                //自付
                patFee.selfFee = patFee.costFee - (patFee.faoverFee + patFee.villageFee);
                //余额
                patFee.surplusFee = patFee.chargeFee - patFee.selfFee;
                //补收
                patFee.receiveFee = patFee.surplusFee < 0 ? (0 - patFee.surplusFee) : 0;
                //应退
                patFee.retreatFee = patFee.surplusFee >= 0 ? patFee.surplusFee : 0;


                patFee.surplusFee = Convert.ToDecimal(patFee.surplusFee.ToString("0.00"));
                patFee.receiveFee = Convert.ToDecimal(patFee.receiveFee.ToString("0.00"));
                patFee.retreatFee = Convert.ToDecimal(patFee.retreatFee.ToString("0.00"));
                return patFee;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 病人结算费用
        /// </summary>
        /// <param name="patlistid"></param>
        /// <returns></returns>
        public PatFee GetPatCostFee()
        {

            try
            {
                PatFee patFee = new PatFee();

                IchargeListDao icLD = DaoFactory.GetObject<IchargeListDao>(typeof(ChargeListDao));
                icLD.oleDb = oleDb;
                IpresDao ipD = DaoFactory.GetObject<IpresDao>(typeof(PresDao));
                ipD.oleDb = oleDb;
                IcostDao icD = DaoFactory.GetObject<IcostDao>(typeof(CostDao));
                icD.oleDb = oleDb;

                //得到中结后的累计预交金
                patFee.chargeFee = Convert.ToDecimal(icLD.GetNoCostAll_Fee(this.PatListID).ToString("0.00"));

                //得到所有记账处方未结算的费用
                patFee.costFee = Convert.ToDecimal(ipD.GetNoCostAll_Fee(this.PatListID).ToString("0.00"));

                //string patientCode = OP_PatientObject.GetPatInfo(patlistid).PatientCode;
                //优惠
                patFee.faoverFee = 0;//Convert.ToDecimal(zy_chargelist.ZY_PresMaster_GetfaoverAll_Fee(patlistid, patientCode, patFee.costFee).ToString("0.00"));
                //农合
                patFee.villageFee = Convert.ToDecimal(icD.GetvillageAll_Fee(this.PatListID).ToString("0.00"));
                //自付
                patFee.selfFee = patFee.costFee - (patFee.faoverFee + patFee.villageFee);
                //余额
                patFee.surplusFee = patFee.chargeFee - patFee.selfFee;
                //补收
                patFee.receiveFee = patFee.surplusFee < 0 ? (0 - patFee.surplusFee) : 0;
                //应退
                patFee.retreatFee = patFee.surplusFee >= 0 ? patFee.surplusFee : 0;


                patFee.surplusFee = Convert.ToDecimal(patFee.surplusFee.ToString("0.00"));
                patFee.receiveFee = Convert.ToDecimal(patFee.receiveFee.ToString("0.00"));
                patFee.retreatFee = Convert.ToDecimal(patFee.retreatFee.ToString("0.00"));
                return patFee;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 得到病人的收费分类项目费用
        /// </summary>
        /// <param name="patlistid">病人入院ID</param>
        /// <returns></returns>
        public DataTable GetPatOrderFee()
        {

            try
            {


                IcostDao icD = DaoFactory.GetObject<IcostDao>(typeof(CostDao));
                icD.oleDb = oleDb;
                return icD.GetPatOrderFee(PatListID);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        /// <summary>
        /// 得到病人的大项目分类项目费用
        /// </summary>
        /// <param name="patlistid">病人入院ID</param>
        /// <returns></returns>
        public DataTable GetPatBigItemOrderFee()
        {

            try
            {
                IcostDao icD = DaoFactory.GetObject<IcostDao>(typeof(CostDao));
                icD.oleDb = oleDb;
                return icD.GetPatBigItemOrderFee(PatListID);

            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        /// <summary>
        /// 得到病人已记账未结算的处方
        /// </summary>
        /// <param name="patlistid">病人ID</param>
        /// <returns></returns>
        public List<ZY_PresOrder> GetPatPresData(int patlistid)
        {
            string strWhere = "PATLISTID =" + this.PatListID + " and CHARGE_FLAG = 1 and COSTMASTERID = 0 ";
            return BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
        }
        
        /// <summary>
        /// 结算病人
        /// </summary>
        /// <param name="zyCostM">结算主表</param>
        /// <param name="zyCostOList">结算汇总记录</param>
        /// <param name="zyPatL">病人类表对象</param>
        /// <returns></returns>
        public void CostPat(ZY_CostMaster zyCostM, List<ZY_CostOrder> zyCostOList, ZY_PatList zyPatL)
        {

            try
            {
                if (OP_ZYConfigSetting.GetConfigValue("005") == 0)
                {
                    string perfCode = "";
                    string strticketno = InvoiceManager.InvoiceManager.GetBillNumber(Convert.ToInt32(zyCostM.ChargeCode), false, out perfCode);
                    zyCostM.TicketCode = perfCode + strticketno;
                }

                oleDb.BeginTransaction();
                //中结处理预交金（以前所有正常预交金全识为中结状态，新增一条新的预交金）                               

                //添加一条结算信息

                BindEntity<ZY_CostMaster>.CreateInstanceDAL(oleDb).Add(zyCostM);
                //添加结算汇总表



                for (int i = 0; i < zyCostOList.Count; i++)
                {
                    zyCostOList[i].CostID = zyCostM.CostMasterID;

                    BindEntity<ZY_CostOrder>.CreateInstanceDAL(oleDb).Add(zyCostOList[i]);
                }
                //更新所有处方记录的结算ID

                IpresDao ipD = DaoFactory.GetObject<IpresDao>(typeof(PresDao));
                ipD.oleDb = oleDb;
                ipD.AlterCostID(zyCostM.PatListID, zyCostM.CostMasterID, zyCostM.Ntype);

                if (zyCostM.Ntype != 1)//add zenghao
                {
                    //更改住院病人登记表病人类型为4,5 出院结算 出院欠费结算

                    BindEntity<ZY_PatList>.CreateInstanceDAL(oleDb).Update(zyPatL);
                }

                //一起更新标识
                string strWhere = "DELETE_FLAG = 0 and PATLISTID =" + zyPatL.PatListID;
                //string str1 = Tables.zy_chargelist.RECORD_FLAG + oleDb.EuqalTo() + "3";//不修改记录状态
                string str2 = "DELETE_FLAG ="+ zyCostM.CostMasterID;
                BindEntity<ZY_ChargeList>.CreateInstanceDAL(oleDb).Update(strWhere, str2);


                oleDb.CommitTransaction();
            }
            catch (System.Exception e)
            {
                oleDb.RollbackTransaction();
                throw new Exception(e.Message);
            }

        }
        /// <summary>
        /// 验证取消病人的结算记录是否符合逻辑(作了出院结算的不能对其中途结算取消)
        /// </summary>
        /// <param name="patlistid"></param>
        /// <returns></returns>
        public bool CheckCanelCost(int patlistid, int costID)
        {
            string strWhere = "PATLISTID =" + patlistid + " and RECORD_FLAG = 0 ";
            if (BindEntity<ZY_CostMaster>.CreateInstanceDAL(oleDb).GetMaxId("COSTMASTERID", strWhere) == costID)
            {
                return true;
            }
            return false;
        }
        
        /// <summary>
        /// 取消结算
        /// </summary>
        /// <param name="zyCostM"></param>
        /// <returns></returns>
        public void CanelCostPat(ZY_CostMaster zyCostM)
        {

            try
            {

                oleDb.BeginTransaction();
                //更改处方结算标志
                IpresDao ipD = DaoFactory.GetObject<IpresDao>(typeof(PresDao));
                ipD.oleDb = oleDb;
                IcostDao icD = DaoFactory.GetObject<IcostDao>(typeof(CostDao));
                icD.oleDb = oleDb;
                IpatListDao ipLD = DaoFactory.GetObject<IpatListDao>(typeof(PatListDao));
                ipLD.oleDb = oleDb;


                ipD.AlterCostID(zyCostM.CostMasterID, 0);

                //修改结算表的记录标识1,为被退(外面添加收费人代码和取消结算时间)


                icD.UpdateRecord_Flag(zyCostM.CostMasterID, 1);
                //删除所有结算汇总表的记录||update 新增对应多的付记录，不然在交款表按发票项目分类金额不对
                string strWhere = "COSTID =" + zyCostM.CostMasterID;
                //BindEntity<ZY_CostOrder>.CreateInstanceDAL(oleDb).Delete(strWhere); update zenghao 20090826
                List<ZY_CostOrder> zy_coList = BindEntity<ZY_CostOrder>.CreateInstanceDAL(oleDb).GetListArray(strWhere);


                //如果为取消中途结算，预交金的处理
                //if (zyCostM.Ntype == 1)//?  出院结算取消也把ID修改回去
                //{
                strWhere = "DELETE_FLAG =" + zyCostM.CostMasterID;
                //string str1 = Tables.zy_chargelist.RECORD_FLAG + oleDb.EuqalTo() + "3";
                string str2 = "DELETE_FLAG = 0";
                BindEntity<ZY_ChargeList>.CreateInstanceDAL(oleDb).Update(strWhere, str2);
                //}

                //添加一条红冲记录,记录标识为2，红冲


                zyCostM.Total_Fee = 0 - zyCostM.Total_Fee;
                zyCostM.Deptosit_Fee = 0 - zyCostM.Deptosit_Fee;
                zyCostM.Self_Fee = 0 - zyCostM.Self_Fee;
                zyCostM.Village_Fee = 0 - zyCostM.Village_Fee;
                zyCostM.Favor_Fee = 0 - zyCostM.Favor_Fee;
                zyCostM.Reality_Fee = 0 - zyCostM.Reality_Fee;
                zyCostM.Pos_Fee = 0 - zyCostM.Pos_Fee;
                zyCostM.Money_Fee = 0 - zyCostM.Money_Fee;
                zyCostM.WorkUnit_Fee = 0 - zyCostM.WorkUnit_Fee;
                zyCostM.NotWorkUnit_Fee = 0 - zyCostM.NotWorkUnit_Fee;
                zyCostM.Record_Flag = 2;
                zyCostM.OldID = zyCostM.CostMasterID;
                zyCostM.AccountID = 0; //add zenghao 
                zyCostM.CostDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;

                BindEntity<ZY_CostMaster>.CreateInstanceDAL(oleDb).Add(zyCostM);

                //取消结算，结算明细表插付记录
                for (int i = 0; i < zy_coList.Count; i++)
                {
                    zy_coList[i].CostID = zyCostM.CostMasterID;
                    zy_coList[i].Total_Fee = 0 - zy_coList[i].Total_Fee;
                    BindEntity<ZY_CostOrder>.CreateInstanceDAL(oleDb).Add(zy_coList[i]);
                }

                //更改住院病人登记表病人类型为3，出院未结算

                if (zyCostM.Ntype == 1)//如果是中途结算
                {
                    ipLD.AlterPatType(zyCostM.PatListID, 2);
                }
                else
                {
                    ipLD.AlterPatType(zyCostM.PatListID, 3);
                }

                oleDb.CommitTransaction();
            }
            catch (System.Exception e)
            {
                oleDb.RollbackTransaction();
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 检测是否可以取消结算
        /// </summary>
        /// <param name="zyCostM"></param>
        /// <returns></returns>
        public bool Check_CanelCostPat(ZY_CostMaster zyCostM)
        {
            //如果已经交款，（不允许取消中途结算、出院结算可以取消但不能再交预交金，必须马上重新结清费用办出院，
            //如果病人还需要继续住院，则必须重新办入院）
            if (zyCostM.Ntype == 1 && zyCostM.AccountID != 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 得到新的发票流水号
        /// </summary>
        /// <param name="date">当前服务器时间</param>
        /// <returns></returns>
        public string GetNewTicketNO(DateTime date)
        {

            try
            {

                IcostDao icD = DaoFactory.GetObject<IcostDao>(typeof(CostDao));
                icD.oleDb = oleDb;

                string datestr = date.ToString("yyyyMMdd");
                string datestr2 = icD.GetNewTicketNo(date);
                if (datestr2.Length == 1) datestr2 = "00" + datestr2;
                else if (datestr2.Length == 2) datestr2 = "0" + datestr2;
                return datestr + datestr2;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        /// <summary>
        /// 重打发票
        /// </summary>
        /// <param name="CostMasterID">结算ID</param>
        /// <param name="TicketNO">发票号</param>
        /// <param name="CostCode">结算人代码</param>
        /// <param name="CostDate">结算日期</param>
        /// <returns></returns>
        public int Again_Ticket(int CostMasterID, string TicketNO, string CostCode, DateTime CostDate)
        {

            IcostDao icD = DaoFactory.GetObject<IcostDao>(typeof(CostDao));
            icD.oleDb = oleDb;
            IpresDao ipD = DaoFactory.GetObject<IpresDao>(typeof(PresDao));
            ipD.oleDb = oleDb;

            try
            {

                oleDb.BeginTransaction();

                ZY_CostMaster zyCostM = BindEntity<ZY_CostMaster>.CreateInstanceDAL(oleDb).GetModel(CostMasterID);

                ZY_CostMaster zyCostMM = new ZY_CostMaster();
                //1Copy
                zyCostMM = (ZY_CostMaster)zyCostM.Clone();

                //zy_CostM.Update(zyCostM.CostMasterID, 1);
                string strwhere = "COSTMASTERID =" + CostMasterID;
                string fieldvalue ="RECORD_FLAG = 1";
                BindEntity<ZY_CostMaster>.CreateInstanceDAL(oleDb).Update(strwhere, fieldvalue);

                //3add冲帐记录
                zyCostM.Total_Fee = 0 - zyCostM.Total_Fee;
                zyCostM.Deptosit_Fee = 0 - zyCostM.Deptosit_Fee;
                zyCostM.Self_Fee = 0 - zyCostM.Self_Fee;
                zyCostM.Village_Fee = 0 - zyCostM.Village_Fee;
                zyCostM.Village_Fee = 0 - zyCostM.Village_Fee;
                zyCostM.Reality_Fee = 0 - zyCostM.Reality_Fee;
                zyCostM.Pos_Fee = 0 - zyCostM.Pos_Fee;
                zyCostM.Money_Fee = 0 - zyCostM.Money_Fee;
                zyCostM.Record_Flag = 2;
                zyCostM.OldID = zyCostM.CostMasterID;
                zyCostM.AccountID = 0;//add zenghao

                //zy_CostM.Add(zyCostM);
                BindEntity<ZY_CostMaster>.CreateInstanceDAL(oleDb).Add(zyCostM);
                //4add新的重打记录
                zyCostMM.TicketNum = GetNewTicketNO(CostDate);
                zyCostMM.TicketCode = TicketNO;
                zyCostMM.ChargeCode = CostCode;
                zyCostMM.CostDate = CostDate;
                zyCostMM.AccountID = 0;//add zenghao
                BindEntity<ZY_CostMaster>.CreateInstanceDAL(oleDb).Add(zyCostMM);

                //更改处方结算标志
                ipD.AlterCostID(CostMasterID, zyCostMM.CostMasterID);

                //5update 结算汇总记录

                icD.UpdateCostMID(CostMasterID, zyCostMM.CostMasterID);

                oleDb.CommitTransaction();
                return zyCostMM.CostMasterID;
            }
            catch (System.Exception e)
            {
                oleDb.RollbackTransaction();
                return 0;
                throw new Exception(e.Message);
            }

        }
        /// <summary>
        /// 补打发票
        /// </summary>
        /// <param name="CostMasterID">结算ID</param>
        /// <param name="TicketNO">发票号</param>
        /// <returns></returns>
        public int Again_Ticket(int CostMasterID, string TicketNO)
        {

            try
            {

                string strWhere = "COSTMASTERID =" + CostMasterID;
                string str = "TICKETCODE ='" + TicketNO + "'";
                BindEntity<ZY_CostMaster>.CreateInstanceDAL(oleDb).Update(strWhere, str);

                return CostMasterID;
            }
            catch (System.Exception e)
            {

                return 0;
                throw new Exception(e.Message);
            }

        }

        /// <summary>
        /// 根据住院号查询
        /// </summary>
        /// <param name="CureNo">住院号</param>
        /// <returns></returns>
        public DataTable GetCostData(string CureNo)
        {
            try
            {

                DataTable dt = null;

                List<ZY_CostMaster> zyCostML = null;


                //zyCostML = zy_CostM.GetListArray(" PatListID=" + PatlistID + " order by CostDate");
                string strWhere = "PATLISTID in (select patlistid from zy_patlist where cureno='" + CureNo + "') order by patlistid";
                zyCostML = BindEntity<ZY_CostMaster>.CreateInstanceDAL(oleDb).GetListArray(strWhere);

                if (zyCostML != null)
                {

                    for (int i = 0; i < zyCostML.Count; i++)
                    {
                        zyCostML[i].LoadData();
                    }
                    dt = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(zyCostML);
                }
                return dt;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 得到结算的记录
        /// </summary>
        /// <param name="PatlistID"></param>
        /// <param name="Bdate"></param>
        /// <param name="Edate"></param>
        /// <returns></returns>
        public DataTable GetCostData(int PatlistID, DateTime? Bdate, DateTime? Edate, string TicketNo)
        {

            try
            {

                DataTable dt = null;

                List<ZY_CostMaster> zyCostML = null;
                if (TicketNo != null && TicketNo != "")//根据发票号查询
                {
                    string strWhere = "TICKETCODE ='" + TicketNo.Trim() + "'" + oleDb.OrderBy("COSTDATE");
                    zyCostML = BindEntity<ZY_CostMaster>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
                }
                else if (PatlistID != 0)//指定病人
                {
                    //zyCostML = zy_CostM.GetListArray(" PatListID=" + PatlistID + " order by CostDate");
                    string strWhere = "PATLISTID =" + PatlistID + oleDb.OrderBy("COSTDATE");
                    zyCostML = BindEntity<ZY_CostMaster>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
                }
                else if (Bdate == null && Edate == null)//全部病人
                {
                    // zyCostML = zy_CostM.GetListArray(" order by CostDate");
                    zyCostML = BindEntity<ZY_CostMaster>.CreateInstanceDAL(oleDb).GetListArray(" 1=1 " + oleDb.OrderBy("COSTDATE"));
                }
                else//指定时间赛选票据
                {
                    string str = oleDb.Date("COSTDATE") + oleDb.GreaterThanAndEqualTo() + "'" + Bdate.Value.Date + "'" + oleDb.And() + oleDb.Date("COSTDATE") + oleDb.LessThanAndEqualTo()
                     + "'" + Edate.Value.Date + "'" + oleDb.OrderBy("COSTDATE");
                    zyCostML = BindEntity<ZY_CostMaster>.CreateInstanceDAL(oleDb).GetListArray(str);
                    // zyCostML = zy_CostM.GetListArray(" date(CostDate) >= '" + Bdate.Value.Date + "' and date(CostDate)<='" + Edate.Value.Date + "'  order by CostDate");

                }
                if (zyCostML != null)
                {

                    for (int i = 0; i < zyCostML.Count; i++)
                    {
                        zyCostML[i].LoadData();
                    }
                    dt = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(zyCostML);
                }
                return dt;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        /// <summary>
        /// 得到病人甲类乙类的费用（试算需要）
        /// </summary>
        /// <param name="patlistid"></param>
        /// <returns></returns>
        public decimal GetPatSelfFee(int patlistid)
        {
            List<ZY_PresOrder> zy_presOrderList = GetPatPresData(patlistid);
            decimal dec = 0;
            try
            {
                string strsql = oleDb.Table("VI_ITEM_ZY_DRUG", "", "", "itemid", "d_code", "insur_type");
                DataTable drugData = oleDb.GetDataTable(strsql);

                strsql = oleDb.Table("VI_ITEM_PROJECT", "", "", "itemid", "d_code", "insur_type");
                DataTable projectData = oleDb.GetDataTable(strsql);


                if (zy_presOrderList != null && zy_presOrderList.Count > 0)
                {
                    for (int i = 0; i < zy_presOrderList.Count; i++)
                    {
                        if (Convert.ToInt32(zy_presOrderList[i].PresType) < 4)
                        {
                            DataRow[] drs = drugData.Select("itemid=" + zy_presOrderList[i].ItemID);
                            if (drs.Length != 0)
                            {
                                DataRow dr = drs[0];
                                if (dr != null)
                                {
                                    if (HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNull(dr["insur_type"], "").ToString().Trim() == "甲" || HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNull(dr["insur_type"], "").ToString().Trim() == "乙")
                                    {
                                        dec += zy_presOrderList[i].Tolal_Fee;
                                    }
                                }
                            }
                        }
                        else
                        {
                            DataRow[] drs = projectData.Select("itemid=" + zy_presOrderList[i].ItemID);
                            if (drs.Length != 0)
                            {
                                DataRow dr = drs[0];
                                if (dr != null)
                                {
                                    if (HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNull(dr["insur_type"], "").ToString().Trim() == "甲" || HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNull(dr["insur_type"], "").ToString().Trim() == "乙")
                                    {
                                        dec += zy_presOrderList[i].Tolal_Fee;
                                    }
                                }
                            }
                        }
                    }

                }
                return dec;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }
        /// <summary>
        /// 得到作废发票
        /// </summary>
        /// <param name="IsHistroy">是否搜索历史发票</param>
        /// <param name="EmpCode">用户代码</param>
        /// <param name="bDate">开始日期</param>
        /// <param name="eDate">结束日期</param>
        /// <returns></returns>
        public DataTable GetBadTicket(bool IsHistroy, string EmpCode, DateTime? bDate, DateTime? eDate)
        {
            try
            {
                string strWhere;

                if (!IsHistroy)
                {
                    strWhere = "ACCOUNTID =0 and EMPCODE ='" + EmpCode + "'";
                }
                else
                {
                    strWhere = "ACCOUNTID <> 0  and EMPCODE = '" + EmpCode + "'";
                    if (bDate != null && eDate != null)
                    {
                        strWhere += oleDb.And() + oleDb.Date("BADDATE") + oleDb.GreaterThanAndEqualTo() + "'" + bDate.Value.Date + "'"
                            + oleDb.And() + oleDb.Date("BADDATE") + oleDb.LessThanAndEqualTo() + "'" + eDate.Value.Date + "'";
                    }
                }

                return BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_BADTICKET").GetList(strWhere);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 添加作废发票
        /// </summary>
        /// <param name="TicketNo">发票号</param>
        /// <param name="EmpCode">用户代码</param>
        public void AddBadTicket(string TicketNo, string EmpCode)
        {
            if (CheckTicket(TicketNo))
            {
                string[] filedNames = { "TICKETNO", "EMPCODE", "BADDATE", "ACCOUNTID" };
                string[] filedVales = { TicketNo, EmpCode, DateTime.Now.ToString(), "0" };
                bool[] Isq = { true, true, true, false };
                BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_BADTICKET").Add(filedNames, filedVales, Isq);
            }
            else
                throw new Exception("此发票号已经使用或作废，不能再作废");
        }
        /// <summary>
        /// 检查添加的发票号是否存在
        /// </summary>
        /// <param name="TicketNo">发票号</param>
        /// <returns></returns>
        private bool CheckTicket(string TicketNo)
        {
            int count = 0;
            string strWhere ="TICKETNO ='" + TicketNo + "'";

            count = Convert.ToInt32(BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_BADTICKET").GetFieldValue("COUNT(*)", strWhere));
            if (count > 0)
            {
                return false;
            }
            strWhere = "TICKETCODE ='" + TicketNo + "'";
            count = Convert.ToInt32(BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_COSTMASTER").GetFieldValue("COUNT(*)", strWhere));
            if (count > 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 删除作废发票
        /// </summary>
        /// <param name="TicketNo"></param>
        public void DelBadTicket(string TicketNo)
        {
            string strWhere = "TICKETNO = '" + TicketNo + "' and ACCOUNTID <> 1 ";
            BindEntity<Object>.CreateInstanceDAL(oleDb, "ZY_BADTICKET").Delete(strWhere);
        }
        /// <summary>
        /// 作废发票已交款，变为历史记录
        /// </summary>
        /// <param name="Account"></param>
        public void UpdateBadTicketAccount(int Account)
        {
            string strWhere = "ACCOUNTID = 0 ";
            string[] SetValues = new string[1];
            SetValues[0] = "ACCOUNTID = 1 ";
            BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_BADTICKET").Update(strWhere, SetValues);
        }

        /// <summary>
        /// 判断该病人是否做了结算
        /// </summary>
        /// <param name="PatListID">病人列表ID</param>
        /// <returns>true有false无</returns>
        public bool CheckPatCost(int PatListID)
        {
            string strWhere = "PATLISTID ="+ PatListID;
            return BindEntity<ZY_CostMaster>.CreateInstanceDAL(oleDb).Exists(strWhere);
        }
        /// <summary>
        /// 清零病人操作
        /// </summary>
        /// <param name="PatListID">病人列表ID</param>
        /// <returns>true成功false失败</returns>
        public bool ClearPatData(int PatListID)
        {
            if (!CheckPatCost(PatListID))
            {
                try
                {
                    ZY_PresOrder zyP = new ZY_PresOrder(oleDb);
                    zyP.ClearPatPresData(PatListID);
                }
                catch
                {
                    return false;
                }
                return true;
            }
            else
                throw new Exception("该病人已经做了结算操作，不能再清零！");
        }

        /// <summary>
        /// 得到出院病人的记账金额
        /// </summary>
        /// <param name="PatListID">病人ID</param>
        /// <returns></returns>
        public decimal GetSumVillage_Fee(int PatListID)
        {
            string strWhere = "PATLISTID =" + PatListID;
            object obj = BindEntity<ZY_CostMaster>.CreateInstanceDAL(oleDb).GetSum("VILLAGE_FEE", strWhere);
            if (obj != null)
                return Convert.ToDecimal(obj);
            return 0;
        }

        public ZY_CostMaster GetCostMaster(int patlistid)
        {
            return BindEntity<ZY_CostMaster>.CreateInstanceDAL(oleDb).GetModel(" patlistid= " + patlistid + " and RECORD_FLAG=0 order by costmasterid desc " + oleDb.FETCH());
        }
    }
}
