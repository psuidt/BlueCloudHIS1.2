using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS;
using HIS.SYSTEM.Core;
namespace HIS.Base_BLL
{
    /// <summary>
    /// 医疗服务项目
    /// </summary>
    public class ServiceItem : BaseBLL
    {
        /// <summary>
        /// 获取所有医疗服务项目
        /// </summary>
        /// <returns></returns>
        public static DataTable GetItemList()
        {
            return Base_BLL.BaseDataReader.Base_Service_Items;
        }

        private HIS.Model.BASE_SERVICE_ITEMS model_base_service_item;
        private Department[] execDepts;   
        private int default_exec_dept;
        #region Properties
        /// <summary>
        /// ID
        /// </summary>
        public int ITEM_ID
        {
            get{
                return model_base_service_item.ITEM_ID;
            }
            set
            {
                model_base_service_item.ITEM_ID = value;
            }
        }
        /// <summary>
        /// 国标码
        /// </summary>
        public string STD_CODE
        {
            get
            {
                return model_base_service_item.STD_CODE == null ? "" : model_base_service_item.STD_CODE;
            }
            set
            {
                model_base_service_item.STD_CODE = value;
            }
        }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ITEM_NAME
        {
            get
            {
                return model_base_service_item.ITEM_NAME.Trim( );
            }
            set
            {
                model_base_service_item.ITEM_NAME = value;
            }
        }
        /// <summary>
        /// 代码
        /// </summary>
        public string ITEM_CODE
        {
            get
            {
                return model_base_service_item.ITEM_CODE.Trim( );
            }
            set
            {
                model_base_service_item.ITEM_CODE = value;
            }
        }
        /// <summary>
        /// 拼音
        /// </summary>
        public string PY_CODE
        {
            get
            {
                return model_base_service_item.PY_CODE.Trim( );
            }
            set
            {
                model_base_service_item.PY_CODE = value;
            }
        }
        /// <summary>
        /// 五笔
        /// </summary>
        public string WB_CODE
        {
            get
            {
                return model_base_service_item.WB_CODE.Trim( );
            }
            set
            {
                model_base_service_item.WB_CODE = value;
            }
        }
        /// <summary>
        /// 单位
        /// </summary>
        public string ITEM_UNIT
        {
            get
            {
                return model_base_service_item.ITEM_UNIT.Trim( );
            }
            set
            {
                model_base_service_item.ITEM_UNIT = value;
            }
        }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal PRICE
        {
            get
            {
                return model_base_service_item.PRICE;
            }
            set
            {
                model_base_service_item.PRICE = value;
            }
        }
        /// <summary>
        /// 有效标志
        /// </summary>
        public int VALID_FLAG
        {
            get
            {
                return model_base_service_item.VALID_FLAG;
            }
            set
            {
                model_base_service_item.VALID_FLAG = value;
            }
        }
        /// <summary>
        /// 统计分类代码
        /// </summary>
        public string STATITEM_CODE
        {
            get
            {
                if ( model_base_service_item.STATITEM_CODE != null )
                    return model_base_service_item.STATITEM_CODE.Trim( );
                else
                    return "";
            }
            set
            {
                model_base_service_item.STATITEM_CODE = value;
            }
        }
        /// <summary>
        /// 默认执行科室
        /// </summary>
        public int DEFAULT_EXEC_DEPT
        {
            get
            {
                return default_exec_dept;
            }
            set
            {
                default_exec_dept = value;
            }
        }
        /// <summary>
        /// 农合报销比例
        /// </summary>
        public decimal NCMS_COMP_RATE
        {
            get
            {
                return model_base_service_item.NCMS_COMP_RATE;
            }
            set
            {
                model_base_service_item.NCMS_COMP_RATE = value;
            }
        }
        /// <summary>
        /// 医保分类
        /// </summary>
        public string INSUR_TYPE
        {
            get
            {
                return model_base_service_item.INSUR_TYPE;
            }
            set
            {
                model_base_service_item.INSUR_TYPE = value;
            }
        }

        /// <summary>
        /// 执行科室
        /// </summary>
        public Department[] ExecDepts
        {
            get
            {
                return execDepts;
            }
            set
            {
                execDepts = value;
            }
        }
        #endregion
        /// <summary>
        /// 实体对象
        /// </summary>
        public HIS.Model.BASE_SERVICE_ITEMS EntityModel
        {
            get
            {
                return model_base_service_item;
            }
        }
        public ServiceItem()
        {
            model_base_service_item = new HIS.Model.BASE_SERVICE_ITEMS( );
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ItemID">项目ID</param>
        public ServiceItem(int ItemID)
        {
            
            try
            {
                model_base_service_item = BindEntity<Model.BASE_SERVICE_ITEMS>.CreateInstanceDAL( oleDb ).GetModel( ItemID );
                
            }
            catch
            {
            }
        }
    }
}
