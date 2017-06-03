using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.ZY_BLL.Dao;
using HIS.SYSTEM.Core;

namespace HIS.ZY_BLL.DataModel
{
    partial class ZY_CostOrder : IbaseDao, ICloneable
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

        #region ICloneable 成员

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion

        public ZY_CostOrder()
        {
            _oleDb = BaseBLL.oleDb;
        }

        public ZY_CostOrder(HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase _OleDb)
        {
            _oleDb = _OleDb;
        }
    }
}
