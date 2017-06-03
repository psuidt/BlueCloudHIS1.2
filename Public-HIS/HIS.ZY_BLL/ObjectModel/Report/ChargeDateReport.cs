using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
using HIS.ZY_BLL.DataModel;
using System.Data;
using HIS.ZY_BLL.Dao.Report;
using HIS.ZY_BLL.Dao;

namespace HIS.ZY_BLL.Report
{
    //zenghao [20100507.2.01]
    /// <summary>
    /// 时间
    /// </summary>
    public class ChargeDateReport : DataReport
    {
        /// <summary>
        /// 记账
        /// </summary>
        /// <param name="Bdate"></param>
        /// <param name="Edate"></param>
        public void CLoadOperationData(DateTime Bdate, DateTime Edate)
        {
            Ireport repD = DaoFactory.GetObject<Ireport>(typeof(ReportDao));
            repD.oleDb = oleDb;
            operationList.PresDT = repD.CLoadOperationData(Bdate,Edate);
        }
        /// <summary>
        /// 结算
        /// </summary>
        /// <param name="Bdate"></param>
        /// <param name="Edate"></param>
        public void TLoadOperationData(DateTime Bdate, DateTime Edate)
        {
            Ireport repD = DaoFactory.GetObject<Ireport>(typeof(ReportDao));
            repD.oleDb = oleDb;
            operationList.PresDT = repD.TLoadOperationData(Bdate,Edate);
        }
        /// <summary>
        /// 交款
        /// </summary>
        /// <param name="Bdate"></param>
        /// <param name="Edate"></param>
        public void GLoadOperationData(DateTime Bdate, DateTime Edate)
        {

            Ireport repD = DaoFactory.GetObject<Ireport>(typeof(ReportDao));
            repD.oleDb = oleDb;
            operationList.PresDT = repD.GLoadOperationData(Bdate,Edate);
        }
        /// <summary>
        /// 获取主管医生名称
        /// </summary>
        /// <param name="patListID"></param>
        /// <returns></returns>
        protected string GetChargeDocCode(int patListID)
        {
            ZY_PatList zyPL= operationList.zyPatList.Find(
                delegate(ZY_PatList x) 
                { return x.PatListID == patListID; }
                );
            if (zyPL != null)
            {
                return base.GetName("BASE_EMPLOYEE_PROPERTY", zyPL.CureDocCode);
            }
            return "";
        }
    }
}
