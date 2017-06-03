using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.Base_BLL;
using HIS_BaseManager.收费项目维护.UIController;

namespace HIS_BaseManager.UIController
{
    


    /// <summary>
    /// 界面控制器
    /// </summary>
    public class FrmHospitalItemsController
    {
        private IFrmHospitalItems view;
        private HIS.Base_BLL.ServiceItemController itemController;

        /// <summary>
        /// 本院使用的基本医疗服务项目
        /// </summary>
        public DataTable HospitalBaseServiceItem;
        /// <summary>
        /// 基本医疗服务项目
        /// </summary>
        public DataTable BaseSeriveItems;
        /// <summary>
        /// 界面视图
        /// </summary>
        /// <param name="View"></param>
        public FrmHospitalItemsController(IFrmHospitalItems View)
        {
            view = View;

            itemController = new ServiceItemController( );

        }
        /// <summary>
        /// 初始化
        /// </summary>
        public void Initalize()
        {
            //加载基本医疗服务项目
            BaseSeriveItems = BaseDataReader.Base_Service_Items.Copy( );
            //加载本院所有医疗服务项目（包括组合项目）
            DataTable HospitalServiceItemsAndComplexItems = HIS.Base_BLL.BaseDataReader.Get_Hospital_Service_Items( );
            //分开基本项目和组合项目
            DataRow[] drs = null;
            //获得本院的基本服务项目
            HospitalBaseServiceItem = HospitalServiceItemsAndComplexItems.Clone( );
            HospitalBaseServiceItem.Rows.Clear( );
            drs = HospitalServiceItemsAndComplexItems.Select( "COMPLEX_ID=0" );
            for ( int i = 0 ; i < drs.Length ; i++ )
                HospitalBaseServiceItem.Rows.Add( drs[i].ItemArray );

            view.Stat_Items = BaseDataReader.Base_Stat_Item;
        }
        /// <summary>
        /// 
        /// </summary>
        public bool AddSelectedServiceItems()
        {
            DataTable tbSelectedItems = view.GetSelectBaseServiceItemsForm( );
            if ( tbSelectedItems != null )
            {
                //保存选择的标准项目
                for ( int i = 0 ; i < tbSelectedItems.Rows.Count ; i++ )
                {
                    ServiceItem item = new ServiceItem( );
                    item.ITEM_ID = Convert.ToInt32( tbSelectedItems.Rows[i]["ITEM_ID"] );
                    itemController.AddServiceItemToHospital( item );
                }
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// 移除一个项目
        /// </summary>
        /// <param name="ItemId"></param>
        public void RemoveServiceItems(int ItemId)
        {
            ServiceItem item = itemController.GetServiceItemById(ItemId);
            string message;
            if (itemController.CheckServiceItemReferencedBeforeRemove(item, out message))
            {
                itemController.RemoveServiceItemFromHospital(item);
            }
            else
            {
                throw new CustomException(message);
            }

        }
        
    }
}
