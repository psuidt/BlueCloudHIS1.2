using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.ZY_BLL.Dao;
using HIS.SYSTEM.Core;

namespace HIS.ZY_BLL.ObjectModel.CostManager
{
    public class Invoice_HN : AbstractInvoice, IbaseDao, ICloneable
    {
        private string _总费用大写;
        private string _预交金大写;

        public string 总费用大写
        {
            get { return _总费用大写; }
            set { _总费用大写 = value; }
        }
        public string 预交金大写
        {
            get { return _预交金大写; }
            set { _预交金大写 = value; }
        }

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

        #region ICloneable 成员

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion

        public Invoice_HN()
        {
            _oleDb = BaseBLL.oleDb;
        }

        public Invoice_HN(HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase _OleDb)
        {
            _oleDb = _OleDb;
        }

        public Invoice_HN GetTicketInfo(int CostMasterID)
        {
            Invoice_HN invoice = new Invoice_HN();
            try
            {
                base.GetInvoiceInfo(invoice, CostMasterID);
                invoice._预交金大写 = invoice.预交金;
                invoice._总费用大写 = invoice.总费用;
                return invoice;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
