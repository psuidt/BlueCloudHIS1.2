using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.MediInsInterface_BLL.MediInsInterface.zyInterface;

namespace HIS.ZY_BLL.ObjectModel.NccmManager
{
    /// <summary>
    /// 农合接口创建对象类
    /// </summary>
    public class NccmFactory
    {
        /// <summary>
        /// 创建农合接口对象
        /// </summary>
        /// <returns></returns>
        public static IzyInterface Create()
        {
            try
            {
                if (HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.Nccm_Flag)
                {
                    zyNccmInterface zy_nccm = new zyNccmInterface();
                    return (IzyInterface)zy_nccm;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                throw new Exception("农合接口调用失败!");
            }
        }
    }
}
