using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.MediInsInterface_BLL.MediInsBLL.Dao.DataMatch.Daointerface
{
    public interface Ibasematch
    {
        /// <summary>
        /// 读取医院药品列表
        /// </summary>
        /// <returns></returns>
        DataTable Get_HIS_DrugList(bool b);
        /// <summary>
        /// 读取医院服务项目列表
        /// </summary>
        /// <returns></returns>
        DataTable Get_HIS_ItemList(bool b);
    }
}
