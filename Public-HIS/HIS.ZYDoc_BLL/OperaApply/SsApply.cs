using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.DatabaseAccessLayer;
using Entity = HIS.Model;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS.ZYDoc_BLL.OperaApply
{
    public class SsApply : BaseBLL
    {      

        public bool SaveApply(HIS.Model.ZY_PatList patlist, HIS.Model.SS_APPLY ssapply)
        {
            try
            {
                ssapply.CURENO = patlist.CureNo;
                ssapply.PATLISTID = patlist.PatListID;
                ssapply.PAT_DEPT = Convert.ToInt32(patlist.CurrDeptCode);
                ssapply.APPLY_DATE = XcDate.ServerDateTime;
                if (BindEntity<HIS.Model.SS_APPLY>.CreateInstanceDAL(oleDb).Exists(ssapply.APPLY_ID))
                {
                    BindEntity<HIS.Model.SS_APPLY>.CreateInstanceDAL(oleDb).Update(ssapply);
                }
                else
                {
                    BindEntity<HIS.Model.SS_APPLY>.CreateInstanceDAL(oleDb).Add(ssapply);
                }
                return true;
            }
            catch (System.Exception err)
            {
                throw err;
            }
        }

        public bool CancelApply(string applyid)
        {
            try
            {
                string strWhere = Tables.ss_apply.APPLY_ID + oleDb.EuqalTo() + Convert.ToInt32(applyid)+ oleDb.And()+ Tables.ss_apply.DELETE_FLAG+oleDb.EuqalTo()+0;
                string strSet=Tables.ss_apply.DELETE_FLAG+oleDb.EuqalTo()+1;
                BindEntity<HIS.Model.SS_APPLY>.CreateInstanceDAL(oleDb).Update(strWhere, strSet);
                return true;
            }
            catch (System.Exception err)
            {
                throw err;
            }
        }

        public HIS.Model.SS_APPLY GetNotArrangeApply(int patlistid)
        {
            string strWhere = Tables.ss_apply.PATLISTID + oleDb.EuqalTo() + patlistid + oleDb.And() + Tables.ss_apply.ARRANGE_FLAG + oleDb.EuqalTo() + 0
                + oleDb.And() + Tables.ss_apply.DELETE_FLAG + oleDb.EuqalTo() + 0;
            return BindEntity<HIS.Model.SS_APPLY>.CreateInstanceDAL(oleDb).GetModel(strWhere);             
        }

    }
}
