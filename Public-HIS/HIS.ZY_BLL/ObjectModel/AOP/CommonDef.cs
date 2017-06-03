using System;
using System.Runtime.Remoting.Messaging;

namespace HIS.ZY_BLL.ObjectModel.AOP
{
    /// <summary>
    /// IAopOperator AOP操作符接口，包括前处理和后处理
    /// 2005.04.12
    /// </summary>
    public interface IAopOperator
    {
        void PreProcess(IMessage requestMsg);
        void PostProcess(IMessage requestMsg, IMessage Respond);
    }

    /// <summary>
    /// IAopProxyFactory 用于创建特定的Aop代理的实例，IAopProxyFactory的作用是使AopProxyAttribute独立于具体的AOP代理类。
    /// </summary>
    public interface IAopProxyFactory
    {
        AopProxyBase CreateAopProxyInstance(MarshalByRefObject obj, Type type);
    }
}
