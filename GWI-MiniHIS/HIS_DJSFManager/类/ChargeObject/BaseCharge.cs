using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 

namespace HIS_DJSFManager.类
{
    /// <summary>
    /// 基本结算对象
    /// </summary>
    public abstract class BaseCharge 
    {
        private OutPatient _patient;
        private int _operatorId;
        /// <summary>
        /// 收费基类
        /// </summary>
        /// <param name="Patient"></param>
        /// <param name="OperatorId"></param>
        public BaseCharge( OutPatient Patient, int OperatorId,ChargeType _ChargeType )
        {
            _patient = Patient;
            _operatorId = OperatorId;
            chargeType = _ChargeType;
        }
        /// <summary>
        /// 操作的病人对象
        /// </summary>
        public OutPatient Patient
        {
            get
            {
                return _patient;
            }
        }
        /// <summary>
        /// 当前操作员
        /// </summary>
        public int OperatorId
        {
            get
            {
                return _operatorId;
            }
        }
        protected ChargeType chargeType;
        /// <summary>
        /// 系统结算方式
        /// </summary>
        public ChargeType ChargeType
        {
            get
            {
                return chargeType;
            }
        }
        /// <summary>
        /// 预算
        /// </summary>
        /// <param name="prescriptions">需要预算的处方</param>
        /// <returns>结算的预算信息</returns>
        public abstract ChargeInfo[] Budget( Prescription[] prescriptions );
        /// <summary>
        /// 正式结算
        /// </summary>
        /// <param name="BudgetaryChargeInfos">Budget方法返回的预算信息</param>
        /// <param name="prescriptions">处方信息</param>
        /// <returns></returns>
        public abstract bool Charge( ChargeInfo[] BudgetaryChargeInfos, Prescription[] prescriptions,out BaseInvoice[] ChargeInvoicies );
        /// <summary>
        /// 取消预结算
        /// </summary>
        /// <returns></returns>
        /// <remarks>取消预算后不会再做正式结算，并且删除掉预算信息</remarks>
        public abstract bool AbortBudget();
        /// <summary>
        /// 退费
        /// </summary>
        /// <param name="invoice">需要退费的发票对象</param>
        /// <param name="ReblancePrescriptions">重新结算的处方，若为null,则为全退</param>
        /// <returns></returns>
        public abstract bool Refundment( Invoice invoice ,Prescription[] ReblancePrescriptions );
        
    }
}
