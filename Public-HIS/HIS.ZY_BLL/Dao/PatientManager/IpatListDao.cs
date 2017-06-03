using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.ZY_BLL.Dao.PatientManager
{
    public interface IpatListDao:IbaseDao
    {
        /// <summary>
        /// 生成新的住院号
        /// </summary>
        /// <returns></returns>
        int GetNewCureNo();
        /// <summary>
        /// 生成新的编码
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        string GetNewNccmNo(DateTime date);
        void AlterPatType(int patlistid, int patType);
    }
}
