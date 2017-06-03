using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.Base_BLL;
using HIS.Base_BLL.收费项目及医嘱维护;

namespace HIS_BaseManager.收费项目维护.UIController
{
    /// <summary>
    /// 医嘱维护界面接口
    /// </summary>
    public interface IFrmOrderItem
    {
        int SelectedOrderId
        {
            get;
        }
        string ORDER_NAME
        {
            get;
            set;
        }
        string ORDER_UNIT
        {
            get;
            set;
        }
        int ORDER_TYPE
        {
            get;
            set;
        }
        int MEDICAL_CLASS
        {
            get;
            set;
        }
        string DEFAULT_USAGE
        {
            get;
            set;
        }
        string PY_CODE
        {
            get;
            set;
        }
        string WB_CODE
        {
            get;
            set;
        }
        string D_CODE
        {
            get;
            set;
        }
        int ITEM_ID
        {
            get;
            set;
        }
        int TC_FLAG
        {
            get;
            set;
        }
        int DELETE_BIT
        {
            get;
            set;
        }
        //DateTime BOOK_DATE;
        //DateTime DEL_DATE;
        string OrderBZ
        {
            get;
            set;
        }
    }

    public interface IFrmItemExecDept
    {
        List<BaseItem> SelectedItems{get;}
        List<Department> SelectedDepts
        {
            get;
            
        }
    }
    
    public interface IFrmHospitalItems
    {
        DataTable ServiceItems
        {
            get;
            set;
        }

        DataTable Stat_Items
        {
            get;
            set;
        }
        
        DataTable GetSelectBaseServiceItemsForm();


    }

    public interface IFrmComplexItem
    {
        int SelectedComplexId
        {
            get;
        }
        string Complex_Code
        {
            get;
            set;
        }
        string Complex_Name
        {
            get;
            set;
        }
        string Complex_Item_Unit
        {
            get;
            set;
        }
        decimal Complex_Price
        {
            get;
            set;
        }
        string Complex_Statitem_Code
        {
            get;
            set;
        }
        string Complex_Py_Code
        {
            get;
            set;
        }
        string Complex_Wb_Code
        {
            get;
            set;
        }
        int Complex_Valid_Flag
        {
            get;
            set;
        }
        List<ComplexDetailItem> ComplexDetail{get;}
    }


    public interface IFrmUsageItem
    {
        int CurrentSelectedUsageID
        {
            get;
        }
        string UsageName
        {
            get;
            set;
        }
        string UsageUnit
        {
            get;
            set;
        }
        string UsagePyCode
        {
            get;
            set;
        }
        string UsageWbCode
        {
            get;
            set;
        }
        bool PrintLong
        {
            get;
            set;
        }
        bool PrintTemp
        {
            get;
            set;
        }
        bool DeleteBit
        {
            get;
            set;
        }
        List<LinkageItem> AssociatedItems
        {
            get;
            set;
        }
        
    }
}
