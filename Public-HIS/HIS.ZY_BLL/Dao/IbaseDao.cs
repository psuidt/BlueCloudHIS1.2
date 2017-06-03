/// Company: 长城医疗有限公司
/// Designer: 曾浩
/// Coder: 曾浩
/// Version: 1.0
/// History:
///	2009-01-01  曾浩 [创建]
/// 2009-02-15  曾浩 [编码]
/// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.DatabaseAccessLayer;

namespace HIS.ZY_BLL.Dao
{
    public interface IbaseDao
    {
        RelationalDatabase oleDb { get;set; }
    }
}
