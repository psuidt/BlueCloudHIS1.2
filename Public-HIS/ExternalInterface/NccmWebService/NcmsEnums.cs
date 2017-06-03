using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NccmWebService.Enums
{
    /// <summary>
    /// 下载项目类型
    /// </summary>
    public enum DownLoadItemType
    {
        ALL = 1,
        DRUG = 2,
        THERAPY = 3
    }
    /// <summary>
    /// 新农合项目类型定义
    /// </summary>
    public enum NcmsItemType
    {
        DRUG = 1,
        THERAPY = 2
    }
    /// <summary>
    /// 业务数据类型
    /// </summary>
    public enum NcmsDataType
    {
        收费项目 = 1,
        门诊数据 = 2
    }
    public enum NcmsDataClass
    {
        新农合数据 = 1
    }

    public enum NcmsOperType
    {
        查询 = 4
    }
}
