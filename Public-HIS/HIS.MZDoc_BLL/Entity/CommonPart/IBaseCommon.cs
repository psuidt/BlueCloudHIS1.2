using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS;
using HIS.SYSTEM.Core;

namespace HIS.MZDoc_BLL
{
    /// <summary>
    /// 常用数据基础类
    /// </summary>
    public interface IBaseCommon
    {
        /// <summary>
        /// 加载常用数据
        /// </summary>
        /// <param name="employeeid">所属医生Id</param>
        /// <returns>常用数据表</returns>
        DataTable LoadCommonData(long employeeid);
        /// <summary>
        /// 加载检索数据
        /// </summary>
        /// <returns>基础数据表</returns>
        DataTable LoadShowCardData();
        /// <summary>
        /// 新增常用数据
        /// </summary>
        /// <returns></returns>
        bool Add();
        /// <summary>
        /// 修改常用数据
        /// </summary>
        /// <returns></returns>
        bool Update();
        /// <summary>
        /// 删除常用数据
        /// </summary>
        /// <returns></returns>
        bool Delete();
    }
}
