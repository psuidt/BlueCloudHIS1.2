using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.MediInsInterface_BLL.MediInsInterface.zyInterface
{
    /// <summary>
    /// 农合接口创建对象类
    /// </summary>
    public class zyFactory
    {
        /// <summary>
        /// 创建农合接口对象
        /// </summary>
        /// <returns></returns>
        public static IzyInterface Create(string type)
        {
            try
            {
                IzyInterface izyInter=null;
                switch (type)
                {
                    case "Nccm":
                        //izyInter = new zyNccmInterface();
                        break;
                    case "CxHn":
                        izyInter = new zyCxNhInterface();
                        break;
                }
                return izyInter;
            }
            catch
            {
                throw new Exception("接口调用失败!");
            }
        }
    }
}
