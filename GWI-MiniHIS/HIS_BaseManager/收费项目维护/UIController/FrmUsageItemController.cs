using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.Base_BLL;

namespace HIS_BaseManager.收费项目维护.UIController
{
    public class FrmUsageItemController
    {
        private IFrmUsageItem formView;

        private DataTable tbUsagediction;
        private DataTable tbServiceItems;
        private DataTable tbUsageFee;

        public DataTable UsageDiction
        {
            get
            {
                return tbUsagediction;
            }
            
        }
        public DataTable ServiceItems
        {
            get
            {
                return tbServiceItems;
            }
        }

        public FrmUsageItemController( IFrmUsageItem FormView )
        {
            formView = FormView;
        }
        /// <summary>
        /// 新增用法
        /// </summary>
        public void SaveUsageItem()
        {
            try
            {
                UsageItem item = new UsageItem( );
                item.Name = formView.UsageName;
                item.Unit = formView.UsageUnit;
                item.Py_Code = formView.UsagePyCode;
                item.Wb_Code = formView.UsageWbCode;
                item.PrintLongOrder = formView.PrintLong;
                item.PrintTempOrder = formView.PrintTemp;
                item.DeleteBit = formView.DeleteBit;
                item.AssociatedItems = formView.AssociatedItems;

                ServiceItemController controller = new ServiceItemController( );
                if ( controller.ItemNameExists( item ) )
                {
                    throw new Exception( "用法名称【" + item.Name + "】已经存在" );
                }

                controller.AddUsageItem( item );
                tbUsagediction = BaseDataReader.GetUsageDictionList( );
            }
            catch ( Exception err )
            {
                throw err;
            }
        }
        /// <summary>
        /// 更新用法
        /// </summary>
        public void UpdateUsageItem()
        {
            try
            {
                UsageItem item = new UsageItem( );
                item.ID = formView.CurrentSelectedUsageID;
                item.Name = formView.UsageName;
                item.Unit = formView.UsageUnit;
                item.Py_Code = formView.UsagePyCode;
                item.Wb_Code = formView.UsageWbCode;
                item.PrintLongOrder = formView.PrintLong;
                item.PrintTempOrder = formView.PrintTemp;
                item.DeleteBit = formView.DeleteBit;
                item.AssociatedItems = formView.AssociatedItems;

                ServiceItemController controller = new ServiceItemController( );
                if ( controller.ItemNameExists( item ) )
                {
                    throw new Exception( "用法名称【" + item.Name + "】已经存在" );
                }
                controller.UpdateUsageItem( item );
                DataRow[] drs = BaseDataReader.GetUsageDictionList( ).Select( "ID=" + formView.CurrentSelectedUsageID );
                if ( drs.Length > 0 )
                {
                    DataRow[] drs2 = tbUsagediction.Select( "ID=" + formView.CurrentSelectedUsageID );
                    if ( drs2.Length > 0 )
                    {
                        drs2[0].ItemArray = drs[0].ItemArray;
                    }
                }
                tbUsageFee = BaseDataReader.GetUsageFee( );
            }
            catch ( Exception err )
            {
                throw err;
            }
        }

        public void ShowUsageItem()
        {
            int usageId = formView.CurrentSelectedUsageID;
            DataRow[] drs = tbUsagediction.Select( "ID=" + usageId );
            if ( drs.Length > 0 )
            {
                formView.UsageName = drs[0]["NAME"].ToString( ).Trim();
                formView.UsagePyCode = drs[0]["PY_CODE"].ToString( ).Trim( );
                formView.UsageWbCode = drs[0]["WB_CODE"].ToString( ).Trim( );
                formView.UsageUnit = drs[0]["UNIT"].ToString( ).Trim( );
                formView.PrintLong = Convert.ToInt32( drs[0]["PRINT_LONG"] ) == 1 ? true:false;
                formView.PrintTemp = Convert.ToInt32( drs[0]["PRINT_TEMP"] ) == 1 ? true : false;
                formView.DeleteBit = Convert.ToInt32( drs[0]["DELETE_BIT"] ) == 1 ? true : false;

                string usageName = drs[0]["NAME"].ToString( ).Trim( );
                DataRow[] drItems = tbUsageFee.Select( "USE_NAME='" + usageName + "'" );
                List<LinkageItem> lstItem = new List<LinkageItem>( );
                for ( int i = 0 ; i < drItems.Length ; i++ )
                {
                    LinkageItem item = new LinkageItem( );
                    item.ITEM_ID = Convert.ToInt32( drItems[i]["HSITEM_ID"] );
                    item.Num = Convert.ToInt32( drItems[i]["NUM"] );
                    DataRow[] drTemp = tbServiceItems.Select( "ITEM_ID=" + item.ITEM_ID + " and COMPLEX_ID=0" );
                    string item_name = "";
                    string item_unit = "";
                    decimal item_price = 0M;
                    if ( drTemp.Length > 0 )
                    {
                        item_name = drTemp[0]["ITEM_NAME"].ToString( ).Trim( );
                        item_unit = drTemp[0]["ITEM_UNIT"].ToString( ).Trim( );
                        item_price = Convert.ToDecimal( drTemp[0]["PRICE"] );
                    }
                    if ( item_name == "" )
                    {
                        item_name = "<错误：项目已经被移除或者被置无效>";
                        item.ITEM_ID = 0;
                    }
                    item.ITEM_NAME = item_name;
                    item.ITEM_UNIT = item_unit;
                    item.PRICE = item_price;
                    lstItem.Add( item );
                }
                formView.AssociatedItems = lstItem;
            }
        }

        public void Initialize()
        {
            tbUsagediction = BaseDataReader.GetUsageDictionList( );

            tbServiceItems = BaseDataReader.Get_Hospital_Service_Items( );

            tbUsageFee = BaseDataReader.GetUsageFee( );
        }
    }
}
