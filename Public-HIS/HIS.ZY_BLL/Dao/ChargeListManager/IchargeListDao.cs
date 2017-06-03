using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.ZY_BLL.Dao.ChargeListManager
{
    public interface IchargeListDao:IbaseDao
    {
        /// <summary>
        /// 生成新的预交金票据号
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        string GetNewBillNo(DateTime date);
        decimal[] GetMenoyAndPosFee(string ChargeCode);
        DataTable GetDetailCharge(string ChargeCode, int feeType);
        void UpdateAccount(string ChargeCode, int ID);
        decimal GetNoCostAll_Fee(int patlistid);
        decimal GetNoCostAll_Fee(int patlistid, DateTime costdate);
    }
}
