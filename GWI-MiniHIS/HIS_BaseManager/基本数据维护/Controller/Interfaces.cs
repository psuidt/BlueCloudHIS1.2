using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.Base_BLL;

namespace HIS_BaseManager.基本数据维护.Controller
{
    /// <summary>
    /// 
    /// </summary>
    public interface IFrmBaseDataVindicatorView
    {
        /// <summary>
        /// 
        /// </summary>
        TableConfig SelectedTable
        {
            get;
        }
        string FilterKeyWord
        {
            get;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public interface IFrmVindicatorConfig
    {
        string TABLE_DB_NAME
        {
            get;
            set;
        }
        string TABLE_CN_NAME
        {
            get;
            set;
        }
        string FIELD_DB_NAME
        {
            get;
            set;
        }
        string FIELD_CN_NAME
        {
            get;
            set;
        }
        int FIELD_DB_TYPE
        {
            get;
            set;
        }
        int IS_PRIMARY_KEY
        {
            get;
            set;
        }
        int AUTO_INCREASE
        {
            get;
            set;
        }
        int ALLOW_EMPTY
        {
            get;
            set;
        }
        int MAXLENGTH
        {
            get;
            set;
        }
        int IS_FOREIGNER_KEY
        {
            get;
            set;
        }
        string FOREIGNER_TABLE
        {
            get;
            set;
        }
        string FOREIGNER_FIELD_DB_NAME
        {
            get;
            set;
        }
        string FOREIGNER_FIELD_CN_NAME
        {
            get;
            set;
        }
        string FOREIGNER_FILTER_SQL
        {
            get;
            set;
        }
        int UIC_TYPE
        {
            get;
            set;
        }
        int LOCATION_X
        {
            get;
            set;
        }
        int LOCATION_Y
        {
            get;
            set;
        }
        int WIDTH
        {
            get;
            set;
        }
        int HEIGHT
        {
            get;
            set;
        }
        int GRID_COL_WIDTH
        {
            get;
            set;
        }
        int TABINDEX
        {
            get;
            set;
        }
        int ALLOW_EDIT
        {
            get;
            set;
        }
        int FIELD_MARK_TYPE
        {
            get;
            set;
        }

        string SelectedField
        {
            get;
            
        }
        
    }
    /// <summary>
    /// 
    /// </summary>
    public interface IFrmTableConfig
    {
        string TABLE_DB_NAME
        {
            get;
            set;
        }
        string TABLE_CN_NAME
        {
            get;
            set;
        }
        int ALLOW_USER_EDIT
        {
            get;
            set;
        }
        int ALLOW_PHYSIC_DELETE
        {
            get;
            set;
        }
    }
}
