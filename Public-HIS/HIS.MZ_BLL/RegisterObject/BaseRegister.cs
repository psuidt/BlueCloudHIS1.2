using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
namespace HIS.MZ_BLL.RegisterObject
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseRegister : HIS.SYSTEM.Core.BaseBLL
    {
        private int operatorId;
        private string operatorName;

        public int OperatorId
        {
            get
            {
                return operatorId;
            }
            set
            {
                operatorId = value;
            }
        }
        public string OperatorName
        {
            get
            {
                return operatorName;
            }
            set
            {
                operatorName = value;
            }
        }
        /// <summary>
        /// 挂号预算
        /// </summary>
        /// <param name="Patient"></param>
        /// <returns></returns>
        public abstract ChargeInfo Budget( RegPatient Patient );
        /// <summary>
        /// 挂号处理
        /// </summary>
        /// <param name="Patient"></param>
        /// <param name="budgetInfo"></param>
        /// <returns></returns>
        public abstract bool Register( RegPatient Patient, ChargeInfo budgetInfo );
        /// <summary>
        /// 退号处理
        /// </summary>
        /// <param name="RegInvoiceNo"></param>
        /// <param name="PerfChar"></param>
        /// <returns></returns>
        public abstract bool CancelRegister( string RegInvoiceNo,string PerfChar );

        
    }
}
