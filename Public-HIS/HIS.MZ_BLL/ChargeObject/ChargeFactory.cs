using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using HIS.MZ_BLL.Exceptions;
namespace HIS.MZ_BLL
{
    /// <summary>
    /// 收费对象构造工厂
    /// </summary>
    public class ChargeFactory
    {
        /// <summary>
        /// 构造收费对象实例
        /// </summary>
        /// <param name="Patient">病人对象</param>
        /// <param name="OperatorId">操作员ID,取EmployeeId</param>
        /// <returns></returns>
        public static BaseCharge CreateChargeObject( OutPatient Patient, int OperatorId  ,ChargeType chargeType)
        {
            
            if ( chargeType == ChargeType.一张处方一次结算 )
            {
                return new GeneralCharge( Patient , OperatorId , chargeType );
            }
            else
            {
                return new GeneralChargeEx( Patient , OperatorId , chargeType );
            }
            
        }
        
    }
}
