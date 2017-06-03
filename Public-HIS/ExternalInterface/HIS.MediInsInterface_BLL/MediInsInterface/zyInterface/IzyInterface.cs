using System;
using System.Data;
using HIS.ZY_BLL.DataModel;
using System.Collections.Generic;
using System.Collections;

namespace HIS.MediInsInterface_BLL.MediInsInterface.zyInterface
{
    //[20100518.2.05]
    /// <summary>
    /// 住院外部接口
    /// </summary>
    public interface IzyInterface : IDisposable
    {
        string ErrMessage { get; set; }
        /// <summary>
        /// 医疗机构信息
        /// </summary>
        object HospitalInfo { get; set; }
        /// <summary>
        /// 得到病人信息数据
        /// </summary>
        /// <param name="snpt"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        object GetPatientInfo(Hashtable hashtable);
        /// <summary>
        /// 入院
        /// </summary>
        /// <returns></returns>
        object Register(Hashtable hashtable);
        /// <summary>
        /// 修改入院信息
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        bool AlterRegister(Hashtable hashtable);
        /// <summary>
        /// 取消入院
        /// </summary>
        /// <returns></returns>
        bool CancelRegister(Hashtable hashtable);
        /// <summary>
        /// 预算
        /// </summary>
        /// <returns></returns>
        object PreviewCharge(Hashtable hashtable);
        /// <summary>
        /// 结算
        /// </summary>
        /// <returns></returns>
        object Charge(Hashtable hashtable);
        /// <summary>
        /// 取消出院结算
        /// </summary>
        /// <returns></returns>
        bool CancelCharge(Hashtable hashtable);
        /// <summary>
        /// 上传病人费用
        /// </summary>
        /// <returns></returns>
        bool UploadzyPatFee(Hashtable hashtable);
        /// <summary>
        /// 下载病人费用数据
        /// </summary>
        /// <returns></returns>
        object DownloadzyPatFee(Hashtable hashtable);
        
    }
}
