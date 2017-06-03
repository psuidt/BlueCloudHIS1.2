using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.MZ_BLL.Query
{
    public class PrescriptionQuery : BaseQuery
    {
        public PrescriptionQuery()
        {}

        public DataTable GetItemFee(int type, string strWhere)
        {

            DAL.MZ_DAL dal = new HIS.DAL.MZ_DAL();
            dal._OleDB = oleDb;

            return dal.GetItemFee(type, strWhere);
        }

       
     
    }
}
