using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.BLL;
using System.Collections;
using HIS.Interface.Structs;

namespace HIS.MZ_BLL
{
    /// <summary>
    /// 公共数据读取类
    /// </summary>
    public class PublicDataReader : HIS.SYSTEM.Core.BaseBLL
    {


        public static DataTable GetBaseServiceItems()
        {

            HIS.DAL.MZ_DAL mz_dal = new HIS.DAL.MZ_DAL();
            mz_dal._OleDB = oleDb;
            return mz_dal.GetSeviceItems();
        }
        /// <summary>
        /// 获取门诊划价收费的项目选择卡数据源
        /// </summary>
        /// <param name="dataType">数据类型：0-划价 1-收费</param>
        /// <returns></returns>
        public static DataTable GetItemSelectedCardDataSource(int dataType)
        {
            HIS.DAL.MZ_DAL mz_dal = new HIS.DAL.MZ_DAL( );
            mz_dal._OleDB = oleDb;
            return mz_dal.GetItemSelectedCardDataSource(dataType);
        }
        /// <summary>
        /// 发票查询
        /// </summary>
        /// <param name="dateTimeFrom">开始时间</param>
        /// <param name="dateTimeTo">结束时间</param>
        /// <param name="OperatorId">操作员(EmployeeId)</param>
        /// <returns></returns>
        public static DataTable GetChargeInvoiceList( DateTime dateTimeFrom , DateTime dateTimeTo , int OperatorId )
        {
            HIS.DAL.MZ_DAL mz_dal = new HIS.DAL.MZ_DAL( );
            mz_dal._OleDB = oleDb;
            return mz_dal.GetChargeInvoiceList( dateTimeFrom , dateTimeTo , OperatorId );
        }
        /// <summary>
        /// 发票查询
        /// </summary>
        /// <param name="dateTimeFrom">开始时间</param>
        /// <param name="dateTimeTo">结束时间</param>
        /// <returns></returns>
        public static DataTable GetChargeInvoiceList( DateTime dateTimeFrom , DateTime dateTimeTo )
        {
            HIS.DAL.MZ_DAL mz_dal = new HIS.DAL.MZ_DAL( );
            mz_dal._OleDB = oleDb;
            return mz_dal.GetChargeInvoiceList( dateTimeFrom , dateTimeTo );
        }
        /// <summary>
        /// 获取项目的执行科室
        /// </summary>
        /// <param name="ItemID">项目ID</param>
        /// <returns></returns>
        public static DataTable GetItemExecDepartment( int ItemID )
        {
            HIS.DAL.MZ_DAL mz_dal = new HIS.DAL.MZ_DAL( );
            mz_dal._OleDB = oleDb;

            return mz_dal.GetItemExecDepartment( ItemID );
        }
        /// <summary>
        /// 通过发票号获取退药列表
        /// </summary>
        /// <param name="InvoiceNum"></param>
        /// <returns></returns>
        public static List<PrescriptionDetail> GetDrugReturnValueList( string InvoiceNum )
        {
            HIS.Interface.YP_Data yp_data = new HIS.Interface.YP_Data( );
            List<HIS.Interface.Structs.PrescriptionDetail> lstYP = yp_data.GetReturnDrugList( InvoiceNum );
            List<HIS.Interface.Structs.PrescriptionDetail> lstRetYP = new List<PrescriptionDetail>( );

            foreach ( HIS.Interface.Structs.PrescriptionDetail detail in lstYP )
            {
                PrescriptionDetail _detail = new PrescriptionDetail( );
                _detail.DetailId = detail.DetailId;
                _detail.Amount = detail.Amount;
                _detail.BigitemCode = detail.BigitemCode;
                _detail.Buy_price = detail.Buy_price;
                _detail.ItemId = detail.ItemId;
                _detail.PresctionId = detail.PresctionId;
                _detail.RelationNum = detail.RelationNum;
                _detail.Sell_price = detail.Sell_price;
                _detail.Tolal_Fee = detail.Tolal_Fee;

                lstRetYP.Add( _detail );
            }
            return lstRetYP;
        }
        /// <summary>
        /// 根据诊疗卡号获取已挂号的病人列表
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public static DataTable GetRegistedPatientListByCardNo(string cardNo)
        {
            HIS.DAL.MZ_DAL mz_dal = new HIS.DAL.MZ_DAL( );
            mz_dal._OleDB = oleDb;
            return mz_dal.GetRegPatientListByCardNo( cardNo );
        }
        /// <summary>
        /// 药品库存判断
        /// </summary>
        /// <param name="ItemId"></param>
        /// <param name="ExecDeptCode"></param>
        /// <param name="Amount">要判断的库存，如果传入0，则判断当前是否有库存，否则判断传入的库存是否大于当前库存</param>
        /// <returns></returns>
        public static bool StoreExists(int ItemId,string ExecDeptCode,decimal Amount,out decimal SellPrice,out decimal BuyPrice,out decimal StoreValue)
        {
            if ( ExecDeptCode.Trim()=="")
                ExecDeptCode = "0";

            HIS.Interface.YP_Data yp_data = new HIS.Interface.YP_Data( );
      
            bool ret = yp_data.GetDrugStorInfo( ItemId , Convert.ToInt32( ExecDeptCode ) , out SellPrice , out BuyPrice , out StoreValue );
            if ( ret == false )
            {
                return false;
            }
            else
            {
                if ( StoreValue == 0 )
                {
                    return false;
                }
                else
                {
                    if ( Amount > StoreValue )
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }

            }
        }
        /// <summary>
        /// 得到处方
        /// </summary>
        /// <param name="PatName"></param>
        /// <param name="InvoiceNo"></param>
        /// <param name="PresBeginDate"></param>
        /// <param name="PresEndDate"></param>
        /// <returns></returns>
        public static DataTable Get_Prescriptions(string PatName,string InvoiceNo,DateTime PresBeginDate,DateTime PresEndDate)
        {
            int workid = Convert.ToInt32( HIS.SYSTEM.Core.EntityConfig.WorkID );
            string beginDate = PresBeginDate.ToString( "yyyy-MM-dd" ) + " 00:00:00";
            string endDate = PresEndDate.ToString( "yyyy-MM-dd" ) + " 23:59:59";
            string sql = @"select  bb.patname,bb.visitno, aa.* 
                            from 
                            (
                                select a.presmasterid,b.presorderid,a.patlistid,a.ticketnum,a.presdoccode,a.presdate,a.total_fee as pres_total_fee,a.record_flag,a.drug_flag,a.charge_flag,a.docpresid,
                                b.itemname,b.bigitemcode,b.standard,b.sell_price,b.unit,b.relationnum,b.amount ,a.presamount,b.tolal_fee as order_total_fee,b.order_flag
                                from (select * from mz_presmaster where workid = " + workid + @") a ,
                                     (select * from mz_presorder where workid=" + workid + @") b 
                                where a.presmasterid = b.presmasterid 
                                and a.patlistid = b.patlistid 
                                and a.hand_flag=1 and a.record_flag in (0,1) 
                            ) aa left join (select * from mz_patlist where workid=" + workid + @") bb on aa.patlistid = bb.patlistid
                            where aa.presdate between '" + beginDate + "' and '" + endDate + @"'";
            if ( PatName.Trim( ) != "" )
                sql += " and bb.patname like '" + PatName + "%'";
            if ( InvoiceNo.Trim( ) != "" )
                sql += " and aa.ticketnum = '" + InvoiceNo + "'";

            sql += " order by presdate";
            DataTable table = oleDb.GetDataTable( sql );
            return table;
        }
        /// <summary>
        /// 获取对医生处方修改的权限设置的配置数据
        /// </summary>
        /// <returns></returns>
        public static DataTable Get_PresDoc_EditItem()
        {
            string strSql = @"SELECT CODE,ITEM_NAME,(CASE WHEN ALLOW_EDIT IS NULL THEN 0 ELSE ALLOW_EDIT END) AS ALLOW_EDIT,(CASE WHEN WORKID IS NULL THEN 0 ELSE WORKID END) AS WORKID FROM
                            (
                            SELECT A.CODE,A.ITEM_NAME,B.ALLOW_EDIT,B.WORKID 
                            FROM BASE_STAT_ITEM A LEFT JOIN (SELECT * FROM MZ_DOCPRES_EDITITEM WHERE WORKID = "+HIS.SYSTEM.Core.EntityConfig.WorkID.ToString() +@") B ON A.CODE = B.STATITEM_CODE
                            ) aa where code not in ('00','01','02','03')";

            return oleDb.GetDataTable( strSql );
        }
        
    }
}
