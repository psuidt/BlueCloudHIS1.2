using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
using HIS.ZY_BLL.Dao;
using System.Data;

//zenghao [20100506.1.01]
namespace HIS.ZY_BLL.ObjectModel.AccountManager
{
    /// <summary>
    /// 预交金交款表汇总显示的文本数据
    /// </summary>
    public struct ChargeAllText
    {
        public string OrderAllFee;
        public string OrderAllNum;
        public string BackAllFee;
        public string BackAllNum;
        public string AllFee;
        public string Menoy;
        public string POS;
    }
    /// <summary>
    /// 预交金交款表汇总显示的数据集
    /// </summary>
    public struct ChargeAllData
    {
        public DataTable GoodChargeList;
        public DataTable BadChargeList;
        public DataTable ChargeData;
    }
    /// <summary>
    /// 结算交款表汇总显示的文本数据
    /// </summary>
    public struct CostAllText
    {
        public string receiveFee;
        public string receiveNum;
        public string retreatFee;
        public string retreatNum;

        public string AllFee;
        public string Menoy;
        public string POS;

        public string costFee;
        public string faoverFee;

        public string deptosit_fee;
        public string lbAllFee;
        public string lbRoundFee;
    }
    /// <summary>
    /// 结算交款表汇总显示的数据集
    /// </summary>
    public struct CostAllData
    {
        public DataTable TypeCostData;
        public DataTable GoodCostList;
        public DataTable BadCostList;
        public DataTable ChargeList;
        public DataTable CostData;
    }
    /// <summary>
    /// 交款表汇总的交款人信息
    /// </summary>
    public struct CostEmp
    {
        public string EmpID;
        public string EmpName;
        public DateTime[] Chargedates;
        public DateTime[] Costdates;
        public int[] ChargeAccountIDs;
        public int[] CostAccountIDs;
    }

    public abstract class AbstractAllAccount : IbaseDao
    {
        #region 自定义属性
        private ChargeAllText _ChargeAllText;

        public ChargeAllText ChargeAllText
        {
            get { return _ChargeAllText; }
            set { _ChargeAllText = value; }
        }
        private ChargeAllData _ChargeAllData;

        public ChargeAllData ChargeAllData
        {
            get { return _ChargeAllData; }
            set { _ChargeAllData = value; }
        }
        private CostAllText _CostAllText;

        public CostAllText CostAllText
        {
            get { return _CostAllText; }
            set { _CostAllText = value; }
        }
        private CostAllData _CostAllData;

        public CostAllData CostAllData
        {
            get { return _CostAllData; }
            set { _CostAllData = value; }
        }

        private CostEmp[] _CostEmps;

        public CostEmp[] CostEmps
        {
            get { return _CostEmps; }
            set { _CostEmps = value; }
        }
        #endregion

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

        public AbstractAllAccount()
        {
            _oleDb = BaseBLL.oleDb;
        }

        public AbstractAllAccount(HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase _OleDb)
        {
            _oleDb = _OleDb;
        }
        #endregion

        public abstract void SearchData(DateTime BeginDate, DateTime EndDate);
        public abstract void SearchData(DateTime BeginDate, DateTime EndDate,string[] EmpIDs);
        public abstract void SearchData(DateTime BeginDate, DateTime EndDate,int[] AccountIDs);
    }
}
