using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using HIS.ZY_BLL.Dao;
using HIS.SYSTEM.Core;
using HIS.SYSTEM.DatabaseAccessLayer;

using HIS.ZY_BLL.Dao.PresManager;
using HIS.ZY_BLL.ObjectModel.AOP;
//using HIS.ZY_BLL.ObjectModel.NccmManager;
using HIS.ZY_BLL.ObjectModel.PresOrderManager;
using HIS.ZY_BLL.ObjectModel.BaseData;

namespace HIS.ZY_BLL.DataModel
{
    //[AopProxy(typeof(NccmProxyFactory))]
    partial class ZY_PresOrder : IbaseDao, ICloneable, IpresOrderManager
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


        #region 属性
        private bool _xd;
        /// <summary>
        /// 是否勾选
        /// </summary>
        public bool XD
        {
            get { return _xd; }
            set { _xd = value; }
        }

        private int _rowno;
        /// <summary>
        /// 行号
        /// </summary>
        public int rowno
        {
            get { return _rowno; }
            set { _rowno = value; }
        }

        private long _PRESCNO;
        /// <summary>
        /// 处方号
        /// </summary>
        public long PRESCNO
        {
            get { return _PRESCNO; }
            set { _PRESCNO = value; }
        }

        private long _PRESCDETAILNO;
        /// <summary>
        /// 
        /// </summary>
        public long PRESCDETAILNO
        {
            get { return _PRESCDETAILNO; }
            set { _PRESCDETAILNO = value; }
        }

        private string _DeptName;
        /// <summary>
        /// 科室名称
        /// </summary>
        public string DeptName
        {
            get { return _DeptName; }
            set { _DeptName = value; }
        }

        private string _DocName;
        /// <summary>
        /// 医生名称
        /// </summary>
        public string DocName
        {
            get { return _DocName; }
            set { _DocName = value; }
        }

        private string _ExecDept;
        /// <summary>
        /// 执行科室名称
        /// </summary>
        public string ExecDept
        {
            get { return _ExecDept; }
            set { _ExecDept = value; }
        }

        private string _CostName;
        /// <summary>
        /// 记账人
        /// </summary>
        public string CostName
        {
            get { return _CostName; }
            set { _CostName = value; }
        }

        private int _BigNum;
        /// <summary>
        /// 包装数
        /// </summary>
        public int BigNum
        {
            get { return _BigNum; }
            set { _BigNum = value; }
        }

        private decimal _SmallNum;
        /// <summary>
        /// 基本数
        /// </summary>
        public decimal SmallNum
        {
            get { return Convert.ToDecimal(_SmallNum.ToString("0")); }
            set { _SmallNum = value; }
        }
        private int _BackChargeNum;
        /// <summary>
        /// 冲包装数
        /// </summary>
        public int BackChargeNum
        {
            get
            {
                return _BackChargeNum;
            }
            set
            {
                _BackChargeNum = value;
            }
        }
        private int _BackChargeNum1;
        /// <summary>
        /// 冲基本数
        /// </summary>
        public int BackChargeNum1
        {
            get { return _BackChargeNum1; }
            set { _BackChargeNum1 = value; }
        }

        private string _NCMS_CODE;
        /// <summary>
        /// 农和中心编码
        /// </summary>
        public string NCMS_CODE
        {
            get { return _NCMS_CODE; }
            set { _NCMS_CODE = value; }
        }

        #endregion

        #region 操作

        public ZY_PresOrder()
        {
            oleDb = BaseBLL.oleDb;
        }

        public ZY_PresOrder(RelationalDatabase _oledb)
        {
            oleDb = _oledb;
        }
        /// <summary>
        /// 加载属性数据
        /// </summary>
        public void LoadData()//
        {
            this.rowno = 0;
            this.DeptName = BaseNameFactory.GetName(baseNameType.科室名称,this.PresDeptCode);//HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptName(this.PresDeptCode);
            this.DocName = BaseNameFactory.GetName(baseNameType.用户名称,this.PresDocCode);//HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserName(this.PresDocCode);
            this.ExecDept = BaseNameFactory.GetName(baseNameType.科室名称,this.ExecDeptCode);//HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptName(this.ExecDeptCode);
            this.CostName = BaseNameFactory.GetName(baseNameType.用户名称, this.ChargeCode);//HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserName(this.ChargeCode);
            if (this.PresType.Trim() != "1" && this.PresType.Trim() != "2")
            {
                this.SmallNum = Amount;
                this.BigNum = 0;
            }
            else
            {
                this.SmallNum = this.Amount % this.RelationNum;
                this.BigNum = Convert.ToInt32((this.Amount - this.SmallNum) / this.RelationNum);
            }
            this.NCMS_CODE = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetNCMS_CODE(this.ItemID, Convert.ToInt32(this.PresType) >= 4 ? "2" : "1");
        }
        #endregion

        #region GetPresDataTable
        /// <summary>
        /// 得到未上传农合的费用
        /// </summary>
        /// <returns></returns>
        public DataTable GetPresDataTable()
        {
            try
            {

                string strWhere = null;
                strWhere = "PATLISTID =" + this.PatListID + " and CHARGE_FLAG = 1 and PASSID = 0";

                List<ZY_PresOrder> zyPres = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetListArray(strWhere);

                for (int i = 0; i < zyPres.Count; i++)
                {
                    zyPres[i].Sell_Price = Convert.ToDecimal(zyPres[i].Sell_Price.ToString("0.00"));
                    zyPres[i].Tolal_Fee = Convert.ToDecimal(zyPres[i].Tolal_Fee.ToString("0.00"));
                    zyPres[i].LoadData();
                }
                return HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(zyPres);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 导入长期医嘱获取上一天的处方
        /// </summary>
        /// <param name="patlistid">病人ID</param>
        /// <param name="date">处方日期</param>
        /// <returns></returns>
        public DataTable GetPresDataTable(DateTime date)
        {
            try
            {
                //条件语句
                string str3 = "PATLISTID =" + this.PatListID + " and RECORD_FLAG = 0 and ORDER_TYPE=0 and PRESDATE ='" + date + "' order by ORDER_FLAG,PRESORDERID ";

                List<ZY_PresOrder> zyPres = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetListArray(str3);
                for (int i = 0; i < zyPres.Count; i++)
                {
                    zyPres[i].Sell_Price = Convert.ToDecimal(zyPres[i].Sell_Price.ToString("0.00"));
                    zyPres[i].Tolal_Fee = Convert.ToDecimal(zyPres[i].Tolal_Fee.ToString("0.00"));
                    zyPres[i].LoadData();
                }
                return HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(zyPres);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 得到病人的处方
        /// </summary>
        /// <param name="date">处方日期</param>
        /// <param name="prestype">处方类型（长期、临时）</param>
        /// <returns></returns>
        public DataTable GetPresDataTable(DateTime date, int prestype)
        {
            try
            {
                //条件语句
                string str3 = "PATLISTID =" + this.PatListID + " and ORDER_TYPE=" + prestype + " and PRESDATE ='" + date + "' order by ORDER_FLAG,PRESORDERID";
                List<ZY_PresOrder> zyPres = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetListArray(str3);

                for (int i = 0; i < zyPres.Count; i++)
                {
                    zyPres[i].Sell_Price = Convert.ToDecimal(zyPres[i].Sell_Price.ToString("0.00"));
                    zyPres[i].Tolal_Fee = Convert.ToDecimal(zyPres[i].Tolal_Fee.ToString("0.00"));
                    zyPres[i].LoadData();
                }

                return HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(zyPres);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 得到病人费用清单（已记账的）
        /// </summary>
        /// <param name="patlistid">病人ID</param>
        /// <param name="Bdate">开始日期</param>
        /// <param name="Edate">结束日期</param>
        /// <returns></returns>
        public DataTable GetPresDataTable(DateTime? Bdate, DateTime? Edate, string DrugName)
        {
            try
            {

                string strWhere = null;
                strWhere = "PATLISTID =" + this.PatListID + "and CHARGE_FLAG = 1 ";

                if (Bdate != null && Edate != null)
                {
                    strWhere += " and date(COSTDATE) >='" + Bdate.Value.Date + "' and date(COSTDATE)<='" + Edate.Value.Date + "' ";
                }
                if (DrugName != null && DrugName != "")
                {
                    strWhere += " and ITEMID ="+ DrugName+"";
                }

                List<ZY_PresOrder> zyPres = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
                
                for (int i = 0; i < zyPres.Count; i++)
                {
                    zyPres[i].Sell_Price = Convert.ToDecimal(zyPres[i].Sell_Price.ToString("0.00"));
                    zyPres[i].Tolal_Fee = Convert.ToDecimal(zyPres[i].Tolal_Fee.ToString("0.00"));
                    zyPres[i].LoadData();
                }
                return HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(zyPres);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 得到病人费用清单（已记账的）
        /// </summary>
        /// <param name="patlistid">病人ID</param>
        /// <param name="Bdate">开始日期</param>
        /// <param name="Edate">结束日期</param>
        /// <param name="presType">处方类型</param>
        /// <param name="DrugName">费用名称</param>
        /// <returns></returns>
        public DataTable GetPresDataTable(DateTime? Bdate, DateTime? Edate, string presType, string DrugName)
        {
            try
            {
                string strWhere = null;
                strWhere = "PATLISTID =" + this.PatListID + " and CHARGE_FLAG = 1 ";

                if (Bdate != null && Edate != null)
                {
                    strWhere += " and date(COSTDATE) >='" + Bdate.Value.Date + "' and date(COSTDATE)<='" + Edate.Value.Date + "' ";
                }

                if (DrugName != null && DrugName != "")
                {
                    strWhere += " and ITEMID =" + DrugName + "";
                }

                if (presType != null && presType != "" )
                {
                    //通过划价记账里的手术室记账
                    if (presType == "2")
                    {
                        strWhere += " and ORDER_ID= 0";
                    }
                    else
                    {
                        strWhere += " and ORDER_TYPE= " + presType + "";
                    }
                }

                List<ZY_PresOrder> zyPres = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
               
                for (int i = 0; i < zyPres.Count; i++)
                {
                    zyPres[i].Sell_Price = Convert.ToDecimal(zyPres[i].Sell_Price.ToString("0.00"));
                    zyPres[i].Tolal_Fee = Convert.ToDecimal(zyPres[i].Tolal_Fee.ToString("0.00"));
                    zyPres[i].LoadData();
                }
                return HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(zyPres);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion

        /// <summary>
        /// 返回未发药的处方
        /// </summary>
        /// <param name="patlistid">病人列表ID</param>
        /// <returns></returns>
        public DataTable GetNotSendDurgPresDataTable()
        {
            try
            {

                IpresDao ipD = DaoFactory.GetObject<IpresDao>(typeof(PresDao));
                ipD.oleDb = oleDb;
                DataTable dt = ipD.GetNotSendDurgPresDataTable(this.PatListID);

                List<ZY_PresOrder> zyPres = new List<ZY_PresOrder>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ZY_PresOrder zyp1 = new ZY_PresOrder();
                    zyp1 = (ZY_PresOrder)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dt, i, zyp1);
                    zyp1.Sell_Price = Convert.ToDecimal(zyp1.Sell_Price.ToString("0.00"));
                    zyp1.Tolal_Fee = Convert.ToDecimal(zyp1.Tolal_Fee.ToString("0.00"));
                    zyp1.LoadData();
                    zyPres.Add(zyp1);
                }
                return HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(zyPres);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 得到已上传农合的费用
        /// </summary>
        /// <returns></returns>
        public DataTable GetPresDataTableOld()
        {
            try
            {

                string strWhere = null;
                strWhere = "PATLISTID =" + this.PatListID + " and CHARGE_FLAG = 1 and PASSID = 1";

                List<ZY_PresOrder> zyPres = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
                for (int i = 0; i < zyPres.Count; i++)
                {
                    zyPres[i].Sell_Price = Convert.ToDecimal(zyPres[i].Sell_Price.ToString("0.00"));
                    zyPres[i].Tolal_Fee = Convert.ToDecimal(zyPres[i].Tolal_Fee.ToString("0.00"));
                    zyPres[i].LoadData();
                    zyPres[i].Amount = Convert.ToDecimal(Convert.ToDecimal(zyPres[i].Tolal_Fee / zyPres[i].Sell_Price).ToString("0.00"));
                }
                return HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(zyPres);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 加载药品数据
        /// </summary>
        /// <returns></returns>
        public DataTable LoadDrugData()
        {
            try
            {
                string[] str = new string[22];
                str[0] = oleDb.FiledNameBM("0", "rowno");
                str[20] = "BYNAME";
                str[1] = "ITEMNAME";
                str[2] = "PY_CODE";
                str[3] = "WB_CODE";
                str[4] = "D_CODE";
                str[5] = "SPECDICID";
                str[6] = "ITEMID";
                str[7] = "PRESTYPE";
                str[8] = "ITEMTYPE";
                str[9] = "EXECDEPTNAME";
                str[10] = "EXECDEPTCODE";
                str[11] = "ADDRESS";
                str[12] = "STANDARD";
                str[13] = "PACKUNIT";
                str[14] = "UNIT";
                str[15] = "RELATIONNUM";
                str[16] = "BUY_PRICE";
                str[17] = "SELL_PRICE";
                str[18] = "scale";
                str[19] = "insur_type";
                str[21] = "STORENUM";
                string strWhere = "";
                if (ZY_BLL.OP_ZYConfigSetting.GetConfigValue("002") == 0)//不显示
                {
                    strWhere = "STORENUM > 0";
                }
                return BindEntity<object>.CreateInstanceDAL(oleDb, "VI_ITEM_DRUG").GetList(strWhere, str);

            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 加载药品数据
        /// </summary>
        /// <param name="deptcode">根据执行科室加载药品</param>
        /// <returns></returns>
        public DataTable LoadDrugData(string deptcode)
        {
            try
            {
                string[] str = new string[22];
                str[0] = oleDb.FiledNameBM("0", "rowno");
                str[20] = "BYNAME";
                str[1] = "ITEMNAME";
                str[2] = "PY_CODE";
                str[3] = "WB_CODE";
                str[4] = "D_CODE";
                str[5] = "SPECDICID";
                str[6] = "ITEMID";
                str[7] = "PRESTYPE";
                str[8] = "ITEMTYPE";
                str[9] = "EXECDEPTNAME";
                str[10] = "EXECDEPTCODE";
                str[11] = "ADDRESS";
                str[12] = "STANDARD";
                str[13] = "PACKUNIT";
                str[14] = "UNIT";
                str[15] = "RELATIONNUM";
                str[16] = "BUY_PRICE";
                str[17] = "SELL_PRICE";
                str[18] = "scale";
                str[19] = "insur_type";
                str[21] = "STORENUM";
                string strWhere = "EXECDEPTCODE ='" + deptcode + "'";
                if (ZY_BLL.OP_ZYConfigSetting.GetConfigValue("002") == 0)//不显示
                {
                    strWhere = strWhere + oleDb.And() + " STORENUM > 0";
                }
                return BindEntity<object>.CreateInstanceDAL(oleDb, "VI_ITEM_DRUG").GetList(strWhere, str);

            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 加载项目数据
        /// </summary>
        /// <returns></returns>
        public DataTable LoadItemData()
        {
            try
            {
                string[] str = new string[22];
                str[0] = oleDb.FiledNameBM("0", "rowno");
                str[20] = "BYNAME";
                str[1] = "ITEMNAME";
                str[2] = "PY_CODE";
                str[3] = "WB_CODE";
                str[4] = "D_CODE";
                str[5] = "SPECDICID";
                str[6] = "ITEMID";
                str[7] = "PRESTYPE";
                str[8] = "ITEMTYPE";
                str[9] = "EXECDEPTNAME";
                str[10] = "EXECDEPTCODE";
                str[11] = "ADDRESS";
                str[12] = "STANDARD";
                str[13] = "PACKUNIT";
                str[14] = "UNIT";
                str[15] = "RELATIONNUM";
                str[16] = "BUY_PRICE";
                str[17] = "SELL_PRICE";
                str[18] = "scale";
                str[19] = "insur_type";
                str[21] = "9999 as STORENUM";
                return BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb, "VI_ITEM_PROJECT").GetList("", str);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 加载所有数据
        /// </summary>
        /// <returns></returns>
        public DataTable LoadAllData()
        {
            DataTable dt1 = LoadDrugData();
            DataTable dt2 = LoadItemData();
            DataRow[] drs = dt1.Select();
            for (int i = 0; i < drs.Length; i++)
            {
                dt2.Rows.Add(drs[i].ItemArray);
            }
            return dt2;
        }

        /// <summary>
        /// 加载所有数据
        /// </summary>
        /// <returns></returns>
        public DataTable LoadAllData(string deptcode)
        {
            DataTable dt1 = null;
            if (deptcode == "-1" || deptcode == "0")
                dt1 = LoadDrugData();
            else
                dt1 = LoadDrugData(deptcode);

            DataTable dt2 = LoadItemData();
            DataRow[] drs = dt1.Select();
            for (int i = 0; i < drs.Length; i++)
            {
                dt2.Rows.Add(drs[i].ItemArray);
            }
            return dt2;
        }

        /// <summary>
        /// 保存单张处方
        /// </summary>
        /// <param name="zyPresOrderList">项目列表</param>
        /// <param name="zyPatlist">病人信息</param>
        /// <returns></returns>
        public void SavePres(List<ZY_PresOrder> zyPresOrderList)
        {
            try
            {
                oleDb.BeginTransaction();

                //添加处方明细记录
                for (int i = 0; i < zyPresOrderList.Count; i++)
                {

                    zyPresOrderList[i].PresMasterID = 0;

                    if (zyPresOrderList[i].PresOrderID == 0)//处方头存在，处方记录不存在
                    {
                        BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Add(zyPresOrderList[i]);
                    }
                    else//处方头和处方记录都存在
                    {
                        BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Update(zyPresOrderList[i]);
                    }

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
        /// 得到某天长期医嘱或临时医嘱的总费用
        /// </summary>
        /// <param name="PresDate"></param>
        /// <param name="PresType"></param>
        /// <returns></returns>
        public decimal GetPresAllFee(DateTime PresDate, int PresType)
        {
            try
            {
                IpresDao ipD = DaoFactory.GetObject<IpresDao>(typeof(PresDao));
                ipD.oleDb = oleDb;
                decimal dec = ipD.GetPresAllFee(PresDate, PresType,PatListID);
                return Convert.ToDecimal(dec.ToString("0.00"));
            }
            catch (System.Exception e)
            {
                return 0;
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 删除指定处方
        /// </summary>
        /// <returns></returns>
        public void DelPres()
        {
            try
            {
                oleDb.BeginTransaction();

                BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Delete(this.PresOrderID);

                oleDb.CommitTransaction();
            }
            catch (System.Exception e)
            {
                oleDb.RollbackTransaction();
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 处方记账
        /// </summary>
        /// <param name="zyPresOrderList"></param>
        /// <returns></returns>
        [MethodAopSwitcher(true)]
        public void ChargePres(List<int> zyPresOrderList, List<string> prestype, List<string> ChargeCodeL, List<DateTime> CoatdateL)
        {
            try
            {
                oleDb.BeginTransaction();
                for (int i = 0; i < zyPresOrderList.Count; i++)
                {

                    string strwhere = "PRESORDERID =" + zyPresOrderList[i];

                    string strFieldvalue1 = "CHARGE_FLAG =1";
                    string strFieldvalue2 = "COSTDATE = '" + CoatdateL[i] + "'";
                    string strFieldvalue3 = "CHARGECODE = '" + ChargeCodeL[i] + "'";

                    string strFieldvalue4 = "DRUG_FLAG = 1 ";
                    if (Convert.ToInt32(prestype[i].Trim()) >= 4)
                    {
                        BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Update(strwhere, strFieldvalue1, strFieldvalue2, strFieldvalue3, strFieldvalue4);
                    }
                    else
                    {
                        BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Update(strwhere, strFieldvalue1, strFieldvalue2, strFieldvalue3);
                    }
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
        /// 检查冲帐的处方是否合理
        /// </summary>
        /// <param name="zyo"></param>
        /// <returns></returns>
        public bool CheckBackPres(out decimal resultfee, out decimal arithmetical_compliment)
        {
            try
            {
                 decimal allfee;
                 decimal minusfee;
                //找出最初费用的数量
                string strWhere = "PRESORDERID =" + this.OldID;
                object obj = null;
                decimal dec = 0;
                obj = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetSum("AMOUNT", strWhere);
                if (obj == null || obj == DBNull.Value)
                {
                    dec = 0;
                }
                else
                {
                    dec = Convert.ToDecimal(obj);
                }

                //找出总金额
                strWhere = "PRESORDERID =" + this.OldID;
                //object obj = null;
                obj = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetSum("TOLAL_FEE", strWhere);
                if (obj == null || obj == DBNull.Value)
                {
                    allfee = 0;
                }
                else
                {
                    allfee = Convert.ToDecimal(obj);
                }

                //找出所有以前冲账的费用数量（这个数量是负数）
                strWhere = "RECORD_FLAG = 1 and OLDID ="+ this.OldID;
                obj = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetSum("AMOUNT", strWhere);
                decimal dec1 = 0;
                if (obj == null || obj == DBNull.Value)
                {
                    dec1 = 0;
                }
                else
                {
                    dec1 = Convert.ToDecimal(obj);
                }

                //找出所有以前冲账的总费用（这个数量是负数）
                strWhere = "RECORD_FLAG = 1 and OLDID =" + this.OldID;
                obj = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetSum("TOLAL_FEE", strWhere);
                if (obj == null || obj == DBNull.Value)
                {
                    minusfee = 0;
                }
                else
                {
                    minusfee = Convert.ToDecimal(obj);
                }

                resultfee = 0 - minusfee - allfee;

                //相加得到最后剩余的数量+冲账的数量(这个数量是负数)
                dec=dec + dec1 + this.Amount;
                arithmetical_compliment = dec;

                if (dec >= 0)
                {
                    return true;
                }
                return false;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 写入要冲帐的处方
        /// </summary>
        /// <returns></returns>
        [MethodAopSwitcher(true)]
        public void BackPres(List<ZY_PresOrder> zyPresOrderList)
        {
            try
            {
                oleDb.BeginTransaction();
                for (int i = 0; i < zyPresOrderList.Count; i++)
                {
                    BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Add(zyPresOrderList[i]);
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
        /// 写入要取消冲帐的处方
        /// </summary>
        /// <returns></returns>
        [MethodAopSwitcher(true)]
        public void BackPres(int zypresorderid, ZY_PresOrder zyPresOrder)
        {
            try
            {
                oleDb.BeginTransaction();

                string strWhere = "PRESORDERID ="+ zypresorderid;
                string filedvalue = "RECORD_FLAG = 2";
                BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Update(strWhere, filedvalue);
                BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Add(zyPresOrder);

                oleDb.CommitTransaction();
            }
            catch (System.Exception e)
            {
                oleDb.RollbackTransaction();
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 得到病人发药处方
        /// </summary>
        /// <param name="patlistid">病人ID</param>
        /// <returns></returns>
        public DataTable GetSendGrugPres(int patlistid, string deptcode)
        {
            try
            {
                IpresDao ipD = DaoFactory.GetObject<IpresDao>(typeof(PresDao));
                ipD.oleDb = oleDb;

                if (deptcode == null || deptcode.Trim() == "")
                {
                    return ipD.GetSendGrugPres(patlistid);
                }
                else
                    return ipD.GetSendGrugPres(patlistid, deptcode);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 得到病人发药总金额
        /// </summary>
        /// <param name="patlistid">病人ID</param>
        /// <returns></returns>
        public decimal GetSendGrugPresTotalFee(int patlistid, string deptcode)
        {
            try
            {
                IpresDao ipD = DaoFactory.GetObject<IpresDao>(typeof(PresDao));
                ipD.oleDb = oleDb;
                return ipD.GetSendGrugPresTotalFee(patlistid, deptcode);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 得到病人发药处方
        /// </summary>
        /// <param name="CureNo">住院号</param>
        /// <returns></returns>
        public DataTable GetSendGrugPres(string CureNo, string deptcode)
        {
            try
            {
                IpresDao ipD = DaoFactory.GetObject<IpresDao>(typeof(PresDao));
                ipD.oleDb = oleDb;
                return ipD.GetSendGrugPres(CureNo, deptcode);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 正式结算更新报销农合上传标识
        /// </summary>
        /// <param name="PRESORDERID">明细ID</param>
        public void UpdateComp(int[] PRESORDERID)
        {
            try
            {
                oleDb.BeginTransaction();

                string strWhere = "PRESORDERID ={0}";
                string filedValue = "PASSID = 1";
                for (int i = 0; i < PRESORDERID.Length; i++)
                {
                    BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Update(string.Format(strWhere, PRESORDERID[i]), filedValue);
                }
                oleDb.CommitTransaction();
            }
            catch (Exception e)
            {
                oleDb.RollbackTransaction();
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 取消农合上传标识
        /// </summary>
        /// <param name="PRESORDERID">明细ID</param>
        public void DelComp(int[] PRESORDERID)
        {
            try
            {
                oleDb.BeginTransaction();
                string strWhere = "PRESORDERID ={0}";
                string filedValue1 = "PASSID = 0";
                
                for (int i = 0; i < PRESORDERID.Length; i++)
                {
                    BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Update(string.Format(strWhere, PRESORDERID[i]), filedValue1);
                }
                oleDb.CommitTransaction();
            }
            catch (Exception e)
            {
                oleDb.RollbackTransaction();
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 得到发票项目代码（农合接口用）
        /// </summary>
        /// <returns></returns>
        public string GetFPXM_Code(string itemType)
        {
            try
            {
                string strWhere = "CODE ='" + itemType + "'";
                return BindEntity<object>.CreateInstanceDAL(oleDb, "BASE_STAT_ITEM").GetFieldValue("ZYFP_CODE", strWhere).ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 得到模板里的数据
        /// </summary>
        /// <param name="Template_ID">模板ID</param>
        /// <returns></returns>
        public DataTable GetPresTemplateData(int Template_ID)
        {
            try
            {
                string strWhere = "TEMPLATE_ID = " + Template_ID;
                return BindEntity<object>.CreateInstanceDAL(oleDb, "BASE_TEMPLATE_DETAIL").GetList(strWhere);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 清零病人的所有费用数据
        /// </summary>
        /// <param name="patListID">病人列表ID</param>
        public void ClearPatPresData(int patListID)
        {
            string strWhere = "PATLISTID =" + patListID +" and CHARGE_FLAG = 1";
            List<ZY_PresOrder> zy_polist = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetListArray(strWhere);

            List<ZY_PresOrder> zy_polist_x = zy_polist.FindAll(delegate(ZY_PresOrder x) { return x.OldID == 0; });
            List<ZY_PresOrder> zy_polist_y = zy_polist.FindAll(delegate(ZY_PresOrder x) { return x.OldID > 0; });


            List<ZY_PresOrder> zy_polist_z = new List<ZY_PresOrder>();


            for (int x = 0; x < zy_polist_x.Count; x++)
            {
                for (int y = 0; y < zy_polist_y.Count; y++)
                {
                    if (zy_polist_x[x].PresOrderID == zy_polist_y[y].OldID)
                    {
                        zy_polist_x[x].Amount = zy_polist_x[x].Amount + zy_polist_y[y].Amount;
                        zy_polist_x[x].Tolal_Fee = zy_polist_x[x].Tolal_Fee + zy_polist_y[y].Tolal_Fee;

                    }
                }
                ZY_PresOrder zypresorder = new ZY_PresOrder();
                zypresorder = zy_polist_x[x];
                zypresorder.OldID = zy_polist_x[x].PresOrderID;
                zypresorder.PresOrderID = 0;
                zypresorder.Amount = 0 - zy_polist_x[x].Amount;
                zypresorder.Tolal_Fee = 0 - zy_polist_x[x].Tolal_Fee;
                zypresorder.Record_Flag = 1;
                zypresorder.PassID = 0;
                zypresorder.CostDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                if (zypresorder.Amount != 0 && zypresorder.Tolal_Fee != 0)
                    zy_polist_z.Add(zypresorder);
            }

            BackPres(zy_polist_z);
        }

        /// <summary>
        /// 更改处方医生
        /// </summary>
        /// <param name="PresOrderID">处方ID</param>
        /// <param name="PresDocCode">医生代码</param>
        public void ChangePresDoc(int PresOrderID, string PresDocCode)
        {
            try
            {
                string[] fieldvalue = new string[1];
                string strWhere = "PRESORDERID =" + PresOrderID;
                fieldvalue[0] = "PRESDOCCODE ='" + PresDocCode + "'";
                BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Update(strWhere, fieldvalue);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 计算总金额
        /// </summary>
        /// <param name="binnum"></param>
        /// <param name="smallnum"></param>
        /// <param name="RelationNum"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public decimal CalculateAllFee(decimal binnum, decimal smallnum, decimal RelationNum, decimal price)
        {
            decimal singlePrice = Convert.ToDecimal(Convert.ToDecimal(price / RelationNum).ToString("0.000"));
            decimal Allnum = binnum * RelationNum + smallnum;
            decimal dec = Convert.ToDecimal(Convert.ToDecimal(singlePrice * Allnum).ToString("0.00"));
            return dec;
        }

        /// <summary>
        /// 计算总金额
        /// </summary>
        /// <param name="binnum"></param>
        /// <param name="smallnum"></param>
        /// <param name="RelationNum"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public decimal CalculateAllFee(decimal Allnum, decimal RelationNum, decimal price)
        {
            decimal singlePrice = Convert.ToDecimal(Convert.ToDecimal(price / RelationNum).ToString("0.000"));
            decimal dec = Convert.ToDecimal(Convert.ToDecimal(singlePrice * Allnum).ToString("0.00"));
            return dec;
        }

        #region ICloneable 成员

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
    }
}
