using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.Base_BLL;
using HIS.BLL;

namespace HIS_BaseManager.收费项目维护.UIController
{
    /// <summary>
    /// 医嘱项目维护控制器
    /// </summary>
    public class FrmOrderItemController
    {
        private IFrmOrderItem formView;
        /// <summary>
        /// 医嘱类型
        /// </summary>
        public DataTable OrderType;
        /// <summary>
        /// 医技类型
        /// </summary>
        public DataTable MedicalClass;
        /// <summary>
        /// 医疗服务项目
        /// </summary>
        public DataTable ServiceItems;
        /// <summary>
        /// 默认用法
        /// </summary>
        public DataTable DefaultUsage;
        /// <summary>
        /// 医嘱列表
        /// </summary>
        public DataTable OrderList;
        

        public FrmOrderItemController(IFrmOrderItem FormView)
        {
            formView = FormView;
        }
        /// <summary>
        /// 初始化控制器数据
        /// </summary>
        public void Initiazle()
        {
            OrderList = BaseDataReader.GetOrderList();
            OrderType = BaseDataReader.GetBaseTableData(Tables.BASE_ORDER_TYPE, "");
            MedicalClass = BaseDataReader.GetBaseTableData(Tables.BASE_MEDICAL_CLASS, "");
            ServiceItems = BaseDataReader.Get_Hospital_Service_Items();
            DefaultUsage = BaseDataReader.GetBaseTableData(Tables.BASE_USAGEDICTION, Tables.base_usagediction.DELETE_BIT + " = 0");
        }
        /// <summary>
        /// 保存医嘱项目
        /// </summary>
        public void SaveOrderItem()
        {
            OrderItem order = GetOrderItemFormUI(false);
            try
            {
                ServiceItemController controller = new ServiceItemController();
                
                controller.AddOrderItem(order);
            }
            catch(Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// 更新医嘱内容
        /// </summary>
        public void UpdateOrderItem()
        {
            OrderItem order = GetOrderItemFormUI(true);
            try
            {
                ServiceItemController controller = new ServiceItemController();
                controller.UpdateOrderItem(order);
                DataRow[] drs = BaseDataReader.GetOrderList( ).Select( "ORDER_ID=" + order.ORDER_ID );
                if ( drs.Length > 0 )
                {
                    DataRow[] drs2 = OrderList.Select( "ORDER_ID=" + order.ORDER_ID );
                    if ( drs2.Length > 0 )
                        drs2[0].ItemArray = drs[0].ItemArray;
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void ClearInfo()
        {
            formView.D_CODE = "";
            formView.DEFAULT_USAGE = "";
            formView.DELETE_BIT = 0;
            formView.ITEM_ID = 0;
            formView.MEDICAL_CLASS = 0;
            formView.ORDER_NAME = "";
            formView.ORDER_TYPE = 0;
            formView.ORDER_UNIT = "";
            formView.OrderBZ = "";
            formView.PY_CODE = "";
            formView.TC_FLAG = 0;
            formView.WB_CODE = "";
        }
        /// <summary>
        /// 显示医嘱明细
        /// </summary>
        public void ShowOrderDetail()
        {
            DataRow[] drs = OrderList.Select(Tables.base_order_items.ORDER_ID + " = " + formView.SelectedOrderId);
            ClearInfo();
            if (drs.Length != 0)
            {
                formView.D_CODE = drs[0][Tables.base_order_items.D_CODE].ToString().Trim();
                formView.DEFAULT_USAGE = drs[0][Tables.base_order_items.DEFAULT_USAGE].ToString().Trim();
                formView.DELETE_BIT = Convert.ToInt32(drs[0][Tables.base_order_items.DELETE_BIT]);
                formView.ITEM_ID = Convert.ToInt32( drs[0][Tables.base_order_items.ITEM_ID] );
                formView.MEDICAL_CLASS = Convert.ToInt32( drs[0][Tables.base_order_items.MEDICAL_CLASS] );
                formView.ORDER_NAME = drs[0][Tables.base_order_items.ORDER_NAME].ToString().Trim();
                formView.ORDER_TYPE = Convert.ToInt32( drs[0][Tables.base_order_items.ORDER_TYPE] );
                formView.ORDER_UNIT = drs[0][Tables.base_order_items.ORDER_UNIT].ToString().Trim();
                formView.OrderBZ = drs[0][Tables.base_order_items.BZ].ToString().Trim();
                formView.PY_CODE = drs[0][Tables.base_order_items.PY_CODE].ToString().Trim();
                formView.TC_FLAG = Convert.ToInt32(drs[0][Tables.base_order_items.TC_FLAG]);
                formView.WB_CODE = drs[0][Tables.base_order_items.WB_CODE].ToString().Trim();
            }
        }
        /// <summary>
        /// 获取当前编辑的对象
        /// </summary>
        /// <param name="IsUpdate"></param>
        /// <returns></returns>
        private OrderItem GetOrderItemFormUI(bool IsUpdate)
        {
            OrderItem order = new OrderItem();
            if (IsUpdate)
            {
                order.ORDER_ID = formView.SelectedOrderId;
            }
            order.BZ = formView.OrderBZ;
            order.D_CODE = formView.D_CODE;
            order.DEFAULT_USAGE = formView.DEFAULT_USAGE;
            order.DELETE_BIT = formView.DELETE_BIT;
            order.ITEM_ID = formView.ITEM_ID;
            order.MEDICAL_CLASS = formView.MEDICAL_CLASS;
            order.ORDER_NAME = formView.ORDER_NAME;
            order.ORDER_TYPE = formView.ORDER_TYPE;
            order.ORDER_UNIT = formView.ORDER_UNIT;
            order.PY_CODE = formView.PY_CODE;
            order.TC_FLAG = formView.TC_FLAG;
            order.WB_CODE = formView.WB_CODE;

            return order;
        }
        /// <summary>
        /// 数据检查
        /// </summary>
        /// <param name="IsUpdate"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool CheckData(bool IsUpdate,out string message)
        {
            OrderItem order = GetOrderItemFormUI(IsUpdate);
            ServiceItemController controller = new ServiceItemController();
            return controller.DataCheckBeforeSave(order, out message);
        }
        /// <summary>
        /// 刷新基本服务项目
        /// </summary>
        public void RefreshServiceItems()
        {
            ServiceItems = BaseDataReader.Get_Hospital_Service_Items( );
        }
    }
}
