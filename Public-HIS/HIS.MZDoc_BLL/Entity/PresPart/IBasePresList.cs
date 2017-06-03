using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS;
using HIS.SYSTEM.Core;

namespace HIS.MZDoc_BLL
{
    /// <summary>
    /// 处方明细基础类
    /// </summary>
    public interface IBasePresList
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        string Item_Name { get; set; }

        string StatItem_Code { get; set; }
        /// <summary>
        /// 处方序号
        /// </summary>
        int PresNo { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        int OrderNo { get; set; }
        /// <summary>
        /// 处方状态
        /// </summary>
        HIS.MZDoc_BLL.Public.PresStatus Status { get; set; }
        /// <summary>
        /// 用法ID
        /// </summary>
        int Usage_Id { get; set; }
        /// <summary>
        /// 频次ID
        /// </summary>
        int Frequency_Id { get; set; }
        /// <summary>
        /// 分组标志
        /// </summary>
        int Group_Id { get; set; }
        /// <summary>
        /// 药品标志
        /// </summary>
        bool IsDrug { get; set; }
        /// <summary>
        /// 计算开药总量
        /// </summary>
        void CalculateAmount();
        /// <summary>
        /// 加载属性
        /// </summary>
        void LoadData();
        /// <summary>
        /// 删除单条处方明细记录
        /// </summary>
        int Delete();
        /// <summary>
        /// 保存处方明细
        /// </summary>
        /// <param name="presList">处方明细列表</param>
        int Save(IList presList);
    }
}
