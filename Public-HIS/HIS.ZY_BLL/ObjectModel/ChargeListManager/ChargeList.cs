using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.ZY_BLL.Dao;
using HIS.ZY_BLL.Dao.ChargeListManager;
using HIS.SYSTEM.Core;
using System.Data;
using HIS.ZY_BLL.ObjectModel.BaseData;

namespace HIS.ZY_BLL.DataModel
{
    partial class ZY_ChargeList:IbaseDao,ICloneable
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

        private string _ChargeType;
        private string _ChargeUserName;
        private string _AccountUserName;
        private DateTime _AccountDate;
        private string _DelType;
        private string _PatName;
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatName
        {
            get { return _PatName; }
            set { _PatName = value; }
        }
        /// <summary>
        /// 收费类型名称
        /// </summary>
        public string ChargeType
        {
            get { return _ChargeType; }
            set { _ChargeType = value; }
        }
        /// <summary>
        /// 收费人名称
        /// </summary>
        public string ChargeUserName
        {
            get { return _ChargeUserName; }
            set { _ChargeUserName = value; }
        }
        /// <summary>
        /// 交款人名称
        /// </summary>
        public string AccountUserName
        {
            get { return _AccountUserName; }
            set { _AccountUserName = value; }
        }
        /// <summary>
        /// 交款时间
        /// </summary>
        public DateTime AccountDate
        {
            set { _AccountDate = value; }
            get { return _AccountDate; }
        }
        /// <summary>
        /// 记录状态名称
        /// </summary>
        public string DelType
        {
            set { _DelType = value; }
            get { return _DelType; }
        }

        public ZY_ChargeList()
        {
            _oleDb = BaseBLL.oleDb;
        }

        public ZY_ChargeList(HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase _OleDb)
        {
            _oleDb = _OleDb;
        }
        /// <summary>
        /// 得到新预交金票据号
        /// </summary>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public string GetBillNo(DateTime date)
        {

            try
            {

                IchargeListDao icLD= DaoFactory.GetObject<IchargeListDao>(typeof(ChargeListDao));
                icLD.oleDb = oleDb;
                string datestr = date.ToString("yyyyMMdd");
                string datestr2 = icLD.GetNewBillNo(date);
                if (datestr2.Length == 1) datestr2 = "00" + datestr2;
                else if (datestr2.Length == 2) datestr2 = "0" + datestr2;
                return datestr + datestr2;

            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //[20100617.0.06]
        public void Add()
        {
            try
            {
                object value = BindEntity<ZY_PatList>.CreateInstanceDAL(oleDb).GetFieldValue("pattype", "patlistid=" + this.PatListID);
                if (value != null && value.ToString() != "3" && value.ToString() != "4" && value.ToString() != "5" && value.ToString() != "6")
                {
                    BindEntity<ZY_ChargeList>.CreateInstanceDAL(oleDb).Add(this);
                }
                else
                    throw new Exception("此病人已经不是在院病人，请刷新在院病人列表！");
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 得到病人的全部预交金
        /// </summary>
        /// <returns></returns>
        public DataTable GetPatChargeList()
        {
            try
            {

                //Dal.ZY_DAL zy_ChargeList = new HIS.DAL.ZY_DAL();
                //zy_ChargeList._OleDB = oleDb;
                string str ="PATLISTID ="+ this.PatListID;
                List<ZY_ChargeList> zyChargeList = BindEntity<ZY_ChargeList>.CreateInstanceDAL(oleDb).GetListArray(str);
                //List<ZY_ChargeList_Son> zyChargeListSon = new List<ZY_ChargeList_Son>();


                for (int i = 0; i < zyChargeList.Count; i++)
                {
                    // ZY_ChargeList_Son _zyChargeSon = new ZY_ChargeList_Son();
                    // _zyChargeSon = (ZY_ChargeList_Son)HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjectToObj(zyChargeList[i], _zyChargeSon);
                    if (zyChargeList[i].FeeType == 0)
                    {
                        zyChargeList[i].ChargeType = "现金";
                    }
                    else if (zyChargeList[i].FeeType == 1)
                    {
                        zyChargeList[i].ChargeType = "POS";
                    }

                    if (zyChargeList[i].Record_Flag == 0)
                    {
                        if (zyChargeList[i].Delete_Flag == 0)
                        {
                            zyChargeList[i].DelType = "正常";
                        }
                        else
                        {
                            zyChargeList[i].DelType = "正常  【已结算】";
                        }
                    }
                    else if (zyChargeList[i].Record_Flag == 1)
                    {
                        if (zyChargeList[i].Total_Fee < 0)
                        {
                            if (zyChargeList[i].Delete_Flag == 0)
                            {
                                zyChargeList[i].DelType = "作废";
                            }
                            else
                            {
                                zyChargeList[i].DelType = "作废  【已结算】";
                            }
                        }
                        else
                        {
                            if (zyChargeList[i].Delete_Flag == 0)
                            {
                                zyChargeList[i].DelType = "被作废";
                            }
                            else
                            {
                                zyChargeList[i].DelType = "被作废【已结算】";
                            }
                        }
                    }
                    else if (zyChargeList[i].Record_Flag == 2)
                    {
                        if (zyChargeList[i].Total_Fee < 0)
                        {
                            if (zyChargeList[i].Delete_Flag == 0)
                            {
                                zyChargeList[i].DelType = "退费";
                            }
                            else
                            {
                                zyChargeList[i].DelType = "退费  【已结算】";
                            }
                        }
                        else
                        {
                            if (zyChargeList[i].Delete_Flag == 0)
                            {
                                zyChargeList[i].DelType = "被退费";
                            }
                            else
                            {
                                zyChargeList[i].DelType = "被退费【已结算】";
                            }
                        }
                    }
                    //else if (zyChargeList[i].Record_Flag == 3)
                    //{
                    //    zyChargeList[i].DelType = "中结";
                    //}
                    zyChargeList[i].ChargeUserName = BaseNameFactory.GetName(baseNameType.用户名称, zyChargeList[i].ChargeCode);//HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserName(zyChargeList[i].ChargeCode);//? //(new GWMHIS.BussinessLogicLayer.Classes.User(Convert.ToInt64(zyChargeList[i].ChargeCode))).Name;

                    if (zyChargeList[i].AccountID == 0)
                    {
                        zyChargeList[i].AccountUserName = "";
                    }
                    else
                    {
                        ZY_Account zyAccount = BindEntity<ZY_Account>.CreateInstanceDAL(oleDb).GetModel(zyChargeList[i].AccountID);
                        //zyChargeList[i].AccountUserName = //HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserName(zyAccount.AccountCode);
                        zyChargeList[i].AccountUserName = BaseNameFactory.GetName(baseNameType.用户名称, zyAccount.AccountCode);//HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserName(zyAccount.AccountCode);
                        zyChargeList[i].AccountDate = zyAccount.AccountDate;
                    }
                    //zyChargeListSon.Add(_zyChargeSon);
                }
                return HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(zyChargeList);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 作废
        /// </summary>
        public void DelChargeList(string EmpID)
        {
            
            ZY_ChargeList zyChargeList = BindEntity<ZY_ChargeList>.CreateInstanceDAL(oleDb).GetModel(this.ChargeListID);

            ZY_ChargeList _zyChargeList = (ZY_ChargeList)zyChargeList.Clone();


            _zyChargeList.BillNo = zyChargeList.BillNo;//HIS.ZY_BLL.OP_ChargeList.GetBillNo(XcDate.ServerDateTime); add zenghao
            _zyChargeList.OldBillNo = zyChargeList.BillNo;
            _zyChargeList.ChargeCode = EmpID;//?
            _zyChargeList.CostDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
            //_zyChargeList.Delete_Flag = 1; add zenghao

            _zyChargeList.Total_Fee = 0 - zyChargeList.Total_Fee;
            _zyChargeList.AccountID = 0;//add zenghao

            zyChargeList.Record_Flag = 1;
            _zyChargeList.Record_Flag = 1;
            try
            {
                oleDb.BeginTransaction();

                BindEntity<ZY_ChargeList>.CreateInstanceDAL(oleDb).Update(zyChargeList);
                BindEntity<ZY_ChargeList>.CreateInstanceDAL(oleDb).Add(_zyChargeList);

                oleDb.CommitTransaction();
            }
            catch (Exception err)
            {
                oleDb.RollbackTransaction();
                throw new Exception(err.Message);
            }
        }

        /// <summary>
        /// 退费
        /// </summary>
        public void BackChargeList(string EmpID)
        {
            ZY_ChargeList zyChargeList = BindEntity<ZY_ChargeList>.CreateInstanceDAL(oleDb).GetModel(this.ChargeListID);

            ZY_ChargeList _zyChargeList = (ZY_ChargeList)zyChargeList.Clone();

            _zyChargeList.BillNo = zyChargeList.BillNo;//HIS.ZY_BLL.OP_ChargeList.GetBillNo(XcDate.ServerDateTime); add zenghao
            _zyChargeList.OldBillNo = zyChargeList.BillNo;
            _zyChargeList.ChargeCode = EmpID;//?
            _zyChargeList.CostDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
            //_zyChargeList.Delete_Flag = 1; add zenghao

            _zyChargeList.Total_Fee = 0 - zyChargeList.Total_Fee;
            _zyChargeList.AccountID = 0;//add zenghao

            zyChargeList.Record_Flag = 2;
            _zyChargeList.Record_Flag = 2;
            try
            {
                oleDb.BeginTransaction();

                BindEntity<ZY_ChargeList>.CreateInstanceDAL(oleDb).Update(zyChargeList);
                BindEntity<ZY_ChargeList>.CreateInstanceDAL(oleDb).Add(_zyChargeList);

                oleDb.CommitTransaction();
            }
            catch (Exception err)
            {
                oleDb.RollbackTransaction();
                throw new Exception(err.Message);
            }

        }

        #region ICloneable 成员

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
    }
}
