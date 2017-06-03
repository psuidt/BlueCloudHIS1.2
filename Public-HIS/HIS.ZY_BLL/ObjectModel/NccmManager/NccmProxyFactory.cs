using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.ZY_BLL.ObjectModel.AOP;

namespace HIS.ZY_BLL.ObjectModel.NccmManager
{
    public class NccmProxyFactory : IAopProxyFactory
    {
        #region IAopProxyFactory 成员

        public AopProxyBase CreateAopProxyInstance(MarshalByRefObject obj, Type type)
        {
            return new NccmProxy(obj, type);
        }

        #endregion
    }
}
