using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.MZ_BLL;
using HIS.Interface.Structs;

namespace HIS_MZManager.HJSF
{
    public abstract class BaseHandleEvent : EventArgs
    {
        string message = "";
        bool cancel = false;
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }
        public bool Cancel
        {
            get
            {
                return cancel;
            }
            set
            {
                cancel = value;
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class AfterReadPatientPrescriptionArgs : BaseHandleEvent
    {
        public AfterReadPatientPrescriptionArgs() : base( )
        {
        }
        private int prescCount;
        private bool hasDoctorPresc;
        private bool afterBalance;
        public bool AfterBalance
        {
            get
            {
                return afterBalance;
            }
            set
            {
                afterBalance = value;
            }
        }
        public int PrescCount
        {
            get
            {
                return prescCount;
            }
            set
            {
                prescCount = value;
            }
        }

        public bool HasDoctorPresc
        {
            get
            {
                return hasDoctorPresc;
            }
            set
            {
                hasDoctorPresc = value;
            }
        }
    }
    /// <summary>
    /// 执行删除操作前的事件参数
    /// </summary>
    public class BeforeDeleteEventArgs : BaseHandleEvent
    {
        public BeforeDeleteEventArgs()
            : base( )
        {
        }
    }
    /// <summary>
    /// 删除事件后的事件消息参数
    /// </summary>
    public class AfterDeleteEventArgs : BaseHandleEvent
    {
        public AfterDeleteEventArgs() : base( )
        {
        }
    }
    /// <summary>
    /// 保存处方前引发的事件的事件参数
    /// </summary>
    public class BeforeSaveEventArgs : BaseHandleEvent
    {
        public BeforeSaveEventArgs()
            : base( )
        {
        }
    }
    /// <summary>
    /// 保存处方后引发的事件的事件参数
    /// </summary>
    public class AfterSavedEventArgs : BaseHandleEvent
    {
        public AfterSavedEventArgs()
            :base()
        {
        }
    }
    /// <summary>
    /// 在插入空行后的事件消息参数
    /// </summary>
    public class BeforeInsertRowArgs : BaseHandleEvent
    {
        public BeforeInsertRowArgs() : base( )
        {
        }
    }
    /// <summary>
    /// 控制器初始化完成后的事件消息参数
    /// </summary>
    public class ControllerInitalizeEndArgs : BaseHandleEvent
    {
        public ControllerInitalizeEndArgs() : base( )
        {
        }
    }
    /// <summary>
    /// 在预算完成后的消息参数
    /// </summary>
    public class AfterBudgetEndArgs : BaseHandleEvent
    {
        public AfterBudgetEndArgs() : base( )
        {
        }
        bool success = false;
        ChargeInfo totalBugetInfo;
        ChargeInfo[] budgetChargeInfo;
        ChargeControl chargeController;
        Prescription[] prescriptions;
        /// <summary>
        /// 预算成功标志
        /// </summary>
        public bool Success
        {
            get
            {
                return success;
            }
            set
            {
                success = value;
            }
        }
        /// <summary>
        /// 预算汇总信息
        /// </summary>
        public ChargeInfo TotalBugetInfo
        {
            get
            {
                return totalBugetInfo;
            }
            set
            {
                totalBugetInfo = value;
            }
        }
        /// <summary>
        /// 预算详细信息
        /// </summary>
        public ChargeInfo[] BudgetInfos
        {
            get
            {
                return budgetChargeInfo;
            }
            set
            {
                budgetChargeInfo = value;
            }
        }
        /// <summary>
        /// 结算对象
        /// </summary>
        public ChargeControl ChargeController
        {
            get
            {
                return chargeController;
            }
            set
            {
                chargeController = value;
            }
        }
        /// <summary>
        /// 结算的处方
        /// </summary>
        public Prescription[] Prescriptions
        {
            get
            {
                return prescriptions;
            }
            set
            {
                prescriptions = value;
            }
        }

    }
    /// <summary>
    /// 在正式结算完成后的事件参数
    /// </summary>
    public class AfterBalanceEndArgs : BaseHandleEvent
    {
        public AfterBalanceEndArgs() : base( )
        {
        }
        
        private bool success;
        private ChargeInfo balanceInfo;
        private Invoice[] invoices;
        
        /// <summary>
        /// 是否结算成功标志
        /// </summary>
        public bool Success
        {
            get
            {
                return success;
            }
            set
            {
                success = value;
            }
        }
        /// <summary>
        /// 需要打印的发票
        /// </summary>
        public Invoice[] Invoices
        {
            get
            {
                return invoices;
            }
            set
            {
                invoices = value;
            }
        }
        /// <summary>
        /// 结算信息
        /// </summary>
        public ChargeInfo BalanceInfo
        {
            get
            {
                return balanceInfo;
            }
            set
            {
                balanceInfo = value;
            }
        }
        
    }
}


namespace HIS_MZManager.HJSF
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void OnAfterReadPatientPrescriptionHandler(object sender,AfterReadPatientPrescriptionArgs e);
    /// <summary>
    /// 执行删除操作前的事件的委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void OnBeforeDeleteEventHandle( object sender , BeforeDeleteEventArgs e );
    /// <summary>
    /// 发生在删除操作后的事件委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void OnAfterDeleteEventHandle(object sender,AfterDeleteEventArgs e);
    /// <summary>
    /// 在保存操作执行后的事件委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void OnAfterSavedEventHandle(object sender,AfterSavedEventArgs e );
    /// <summary>
    /// 在保存处方前引发的事件的委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void OnBeforeSaveEventHandle(object sender ,BeforeSaveEventArgs e );
    /// <summary>
    /// 在插入行前的事件委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void OnBeforeInsertRowEventHandle(object sender ,BeforeInsertRowArgs e);
    /// <summary>
    /// 控制器初始化完成后的事件委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void OnControllerInitalizeEndEnvenHandle( object sender , ControllerInitalizeEndArgs e );
    /// <summary>
    /// 在预算结束后的事件委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void OnAfterBudgetEndEventHandle(object sender,AfterBudgetEndArgs e );
    /// <summary>
    /// 在正式结算完成后的事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void OnAfterBalanceEndEventHandle(object sender,AfterBalanceEndArgs e );
}