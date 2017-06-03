using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.MZDoc_BLL.Public
{
    /// <summary>
    /// 当前状态
    /// </summary>
    public enum CurrentStatus
    {
        /// <summary>
        /// 查询状态
        /// </summary>
        查询状态 = 0,
        /// <summary>
        /// 新建状态
        /// </summary>
        新建状态 = 1,
        /// <summary>
        /// 修改状态
        /// </summary>
        修改状态 = 2
    };

    /// <summary>
    /// 处方状态
    /// </summary>
    public enum PresStatus
    {
        /// <summary>
        /// 保存状态
        /// </summary>
        保存状态 = 0,
        /// <summary>
        /// 收费状态
        /// </summary>
        收费状态 = 1,
        /// <summary>
        /// 退费状态
        /// </summary>
        退费状态 = 2,
        /// <summary>
        /// 删除状态
        /// </summary>
        删除状态 = 3,
        /// <summary>
        /// 新建状态
        /// </summary>
        新建状态 = 4,
        /// <summary>
        /// 修改状态
        /// </summary>
        修改状态 = 5
    };

    /// <summary>
    /// 处方明细类型
    /// </summary>
    public enum PresListType
    {
        /// <summary>
        /// 处方模板明细
        /// </summary>
        处方模板明细,
        /// <summary>
        /// 病人处方明细
        /// </summary>
        病人处方明细
    };

    /// <summary>
    /// 医技申请类型
    /// </summary>
    public enum MedicalApplyType
    {
        /// <summary>
        /// 医技化验申请
        /// </summary>
        医技化验申请 = 0,
        /// <summary>
        /// 医技检查申请
        /// </summary>
        医技检查申请 = 1,
        /// <summary>
        /// 医技治疗申请
        /// </summary>
        医技治疗申请 = 2
    };

    /// <summary>
    /// 病人就诊状态
    /// </summary>
    public enum PatCureStatus
    {
        /// <summary>
        /// 候诊状态
        /// </summary>
        候诊状态 = 0,
        /// <summary>
        /// 就诊状态
        /// </summary>
        就诊状态 = 1,
        /// <summary>
        /// 结束状态
        /// </summary>
        结束状态 = 2
    };

    /// <summary>
    /// 处方皮试状态
    /// </summary>
    public enum SkinTestStatus
    {
        /// <summary>
        /// 不需要皮试
        /// </summary>
        不需要皮试 = 0,
        /// <summary>
        /// 需要皮试
        /// </summary>
        需要皮试 = 1,
        /// <summary>
        /// 皮试阴性
        /// </summary>
        皮试阴性 = 2,
        /// <summary>
        /// 皮试阳性
        /// </summary>
        皮试阳性 = 3,
        /// <summary>
        /// 免试
        /// </summary>
        免试 = 4
    };

    /// <summary>
    /// 医技结果返回类型
    /// </summary>
    public enum MedicalReportFormat
    { 
        /// <summary>
        /// 返回图片文件
        /// </summary>
        图片,
        /// <summary>
        /// 不返回任何数据
        /// </summary>
        无返回
    }
}
