using System;

namespace HIS.ZY_BLL.ObjectModel.AOP
{
    /// <summary>
    /// MethodAopSwitcherAttribute 用于决定一个被AopProxyAttribute修饰的class的某个特定方法是否启用截获 。
    /// 创建原因：绝大多数时候我们只希望对某个类的一部分Method而不是所有Method使用截获。
    /// 使用方法：如果一个方法没有使用MethodAopSwitcherAttribute特性或使用MethodAopSwitcherAttribute(false)修饰，
    ///     都不会对其进行截获。只对使用了MethodAopSwitcherAttribute(true)启用截获。
    /// 2005.05.11
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class MethodAopSwitcherAttribute : Attribute
    {
        /// <summary>
        /// 设置方法的功能
        /// </summary>
        /// <param name="useAop">是否开启面向切面</param>
        public MethodAopSwitcherAttribute(bool useAop)
        {
            this.useAspect = useAop;
        }

        private bool useAspect = false;
        public bool UseAspect
        {
            get
            {
                return this.useAspect;
            }
        }

    }
}
