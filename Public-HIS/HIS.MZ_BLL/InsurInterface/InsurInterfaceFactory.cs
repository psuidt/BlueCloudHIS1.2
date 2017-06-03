using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.MZ_BLL.InsurInterface
{
    /// <summary>
    /// 医保接口创建对象
    /// </summary>
    public class InsurInterfaceFactory
    {
        /// <summary>
        /// 创建接口对象
        /// </summary>
        /// <param name="insurType">医保类型，目前暂时为农合或普通病人</param>
        /// <returns></returns>
        public static IInsureCharge CreateInsurInstance(InsurType insurType)
        {
            IInsureCharge insurInstance = null ;
            if ( insurType == InsurType.新农合 )
            {
                insurInstance = new HIS.MZ_BLL.InsurInterface.MZ_NccmInterface( );
            }

            return insurInstance;
        }
    }
}
