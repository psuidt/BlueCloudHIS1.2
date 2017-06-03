using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace HIS.MediInsInterface_BLL.MediInsInterface.matchInterface
{
    //[20100517.1.02]
    public interface ImatchInterface:IDisposable
    {
        /// <summary>
        /// 下载中心药品目录
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        DataTable DownLoadDrugContent(Hashtable hashtable);
        /// <summary>
        /// 下载中心项目目录
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        DataTable DownLoadItemContent(Hashtable hashtable);
        /// <summary>
        /// 判断单条目录是否已匹配
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        string JudgeSingleContentMatch(Hashtable hashtable);
        /// <summary>
        /// 上传匹配的目录
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        string UploadMatchContent(Hashtable hashtable);
        /// <summary>
        /// 重置匹配目录
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        bool ResetMatchContent(Hashtable hashtable);
        /// <summary>
        /// 删除匹配目录
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        bool DeleteMatchContent(Hashtable hashtable);
        /// <summary>
        /// 下载医院匹配项目信息
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        DataTable DownLoadHospContent(Hashtable hashtable);
    }
}
