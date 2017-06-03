using System;

namespace HIS.Model
{
    public struct PlanOrderRemark
    {
        public string _chemName;
        public string _drugSpe;
        public string _productName;
    }
    public class YP_PlanOrder:BillOrder
    {
        public PlanOrderRemark _orderRemark;

        private int _planorderid;
        /// <summary>
        ///
        /// </summary>
        public int PlanOrderId
        {
            get { return _planorderid; }
            set { _planorderid = value; }

        }
        private int _planmasterid;
        /// <summary>
        ///
        /// </summary>
        public int PlanMasterId
        {
            get { return _planmasterid; }
            set { _planmasterid = value; }

        }
        private int _makerdicid;
        /// <summary>
        ///
        /// </summary>
        public int MakerDicId
        {
            get { return _makerdicid; }
            set { _makerdicid = value; }

        }
        private decimal _retailprice;
        /// <summary>
        ///
        /// </summary>
        public decimal RetailPrice
        {
            get { return _retailprice; }
            set { _retailprice = value; }

        }
        private decimal _tradeprice;
        /// <summary>
        ///
        /// </summary>
        public decimal TradePrice
        {
            get { return _tradeprice; }
            set { _tradeprice = value; }

        }
        private decimal _tradefee;
        /// <summary>
        ///
        /// </summary>
        public decimal TradeFee
        {
            get { return _tradefee; }
            set { _tradefee = value; }

        }
        private decimal _retailfee;
        /// <summary>
        ///
        /// </summary>
        public decimal RetailFee
        {
            get { return _retailfee; }
            set { _retailfee = value; }

        }
        private int _unit;
        /// <summary>
        ///
        /// </summary>
        public int Unit
        {
            get { return _unit; }
            set { _unit = value; }

        }
        private decimal _stocknum;
        /// <summary>
        ///
        /// </summary>
        public decimal StockNum
        {
            get { return _stocknum; }
            set { _stocknum = value; }

        }
        private string _unitname;
        /// <summary>
        ///
        /// </summary>
        public string UnitName
        {
            get { return _unitname; }
            set { _unitname = value; }

        }
    }
}
