using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.ZY_BLL.Dao.SendDrugMessage
{
    public class SendDrugMessageDao:IsendDrugMessage
    {

        #region IsendDrugMessage 成员

        public System.Data.DataTable GetYfData()
        {
            string strsql = @"SELECT A.MakerDicID,C.SPECDICID, C.Unit, B.ProductName, G.DOSENAME
                              FROM  {yp_makerdic as A}      
                              LEFT OUTER JOIN {yp_productdic as B }
                              ON A.ProductID=B.ProductID
                              LEFT OUTER JOIN {yp_specdic as C }
                              ON A.SpecDicID=C.SpecDicID       
                              LEFT OUTER JOIN {yp_dosedic as G }
                              ON C.DOSEDICID=G.DOSEDICID WHERE A.DEL_FLAG=0";
            return oleDb.GetDataTable(strsql);
        }

        public System.Data.DataTable GetUsageName()
        {
            string sql = " select name from {base_usagediction} where id in (select usage_id from {base_usage_usetype_role} where type_name='服药单')";
            return oleDb.GetDataTable(sql);
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

        #endregion

        #region IsendDrugMessage 成员


        public System.Data.DataTable GetPatInfoData(List<int> patlistIds)
        {
            string sqlstr = @"select a.cureno,a.bedcode,a.patlistid,b.patname from {zy_patlist as a} left join {PATIENTINFO as b} on a.patid=b.patid where a.patlistid in (";
            for (int i = 0; i < patlistIds.Count; i++)
            {
                if (i == patlistIds.Count - 1)
                    sqlstr += patlistIds[i].ToString() + ")";
                else
                    sqlstr += patlistIds[i].ToString() + ",";
            }

            return oleDb.GetDataTable(sqlstr);
        }

        #endregion
    }
}
