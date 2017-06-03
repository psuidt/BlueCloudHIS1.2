using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.MSAccess;
using System.Data;
using HIS.BLL;
using HIS.Model;
using HIS.SYSTEM.Core;
using System.Reflection;
using System.IO;

namespace HIS.DownUpLoadData
{
    public delegate void OnUpLoadingEventHandle(string message);
    /// <summary>
    /// 数据上传控制类
    /// </summary>
    public class UploadController
    {
        /// <summary>
        ///当前操作人 
        /// </summary>
        private int _employeeId;
        /// <summary>
        /// 数据上传处理中的事件
        /// </summary>
        public event OnUpLoadingEventHandle UpLoadingEvent;
        /// <summary>
        /// 数据上传控制器
        /// </summary>
        /// <param name="EmployeeId"></param>
        public UploadController(int EmployeeId)
        {
            _employeeId = EmployeeId;
        }
        /// <summary>
        /// 远程数据访问对象
        /// </summary>
        private HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase _oleDb = null ;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objValue"></param>
        /// <param name="type">0-字符 ，1-数字 2-日期</param>
        /// <returns></returns>
        private object getValue( object objValue )
        {
            if ( Convert.IsDBNull( objValue ) )
            {
                return DBNull.Value;
            }
            else
            {
                if ( objValue is Double )
                {
                    return Convert.ToDecimal( objValue );
                }
                else
                    return objValue;
            }
        }
        /// <summary>
        /// 数据绑定对象
        /// </summary>
        /// <typeparam name="T">表对象类型</typeparam>
        /// <param name="dataRow">数据</param>
        /// <param name="obj">表对象</param>
        private void DataBind<T>(DataRow dataRow,T obj)
        {
            string typeName = obj.GetType( ).FullName;
            Assembly assembly = Assembly.GetAssembly( obj.GetType( ) );
            PropertyInfo[] propertyInfo = obj.GetType( ).GetProperties( );

            for ( int i = 0 ; i < dataRow.Table.Columns.Count ; i++ )
            {
                string columnName = dataRow.Table.Columns[i].ColumnName;
                for ( int index = 0 ; index < propertyInfo.Length ; index++ )
                {
                    if ( propertyInfo[index].Name.ToUpper( ) == columnName.ToUpper( ) )
                    {
                        object objValue = dataRow[columnName];
                        propertyInfo[index].SetValue( obj , getValue(objValue) , null );
                    }
                }
            }
        }
        /// <summary>
        /// 连接到远程数据库
        /// </summary>
        private void ConnectToRemoteDB()
        {
            try
            {
                _oleDb = BaseBLL.oleDb;
                          
                if ( UpLoadingEvent != null )
                    UpLoadingEvent( "连接网络数据库成功\r\n" );
            }
            catch
            {
                throw new Exception( "连接网络数据库失败！\r\n" );
            }
        }
        /// <summary>
        /// 开始事务
        /// </summary>
        private void BeginTrans()
        {
            _oleDb.BeginTransaction( );
            MSAccessDb.BeginTrans();
        }
        /// <summary>
        /// 提交事务
        /// </summary>
        private void CommitTrans()
        {
            _oleDb.CommitTransaction( );
            MSAccessDb.CommitTrans();
        }
        /// <summary>
        /// 回滚事务
        /// </summary>
        private void RollbackTrans()
        {
            _oleDb.RollbackTransaction( );
            MSAccessDb.RollbackTrans();
        }
        /// <summary>
        /// 得到未上传的病人列表
        /// </summary>
        /// <returns></returns>
        public List<int> GetUnUploadPatientList()
        {
            string sql = @"select distinct a.patlistid 
                            from mz_patlist a ,mz_costmaster b 
                            where a.patlistid=b.patlistid 
                            and  (b.upload_flag=0 or b.upload_flag is null )
                            and b.record_flag in (0,1,2)";
            DataTable tb = MSAccessDb.GetDataTable( sql );
            List<int> patList = new List<int>( );
            for ( int i = 0 ; i < tb.Rows.Count ; i++ )
                patList.Add( Convert.ToInt32( tb.Rows[i]["patlistid"] ) );

            return patList;

        }
        /// <summary>
        /// 上传单个病人费用信息
        /// </summary>
        /// <param name="PatlistId"></param>
        public void UploadDataWithSinglePatient(int PatlistId)
        {
            if ( _oleDb == null )
                ConnectToRemoteDB( );
            
            DataTable tbPatList = MSAccessDb.GetDataTable( "select * from mz_patlist where patlistid=" + PatlistId );
            DataTable tbPresMaster = MSAccessDb.GetDataTable( "select * from mz_presmaster where upload_flag=0 and patlistid = " + PatlistId + " and record_flag in (0,1,2) and prescostcode='" + _employeeId + "'");
            DataTable tbPresOrder = MSAccessDb.GetDataTable( "select * from mz_presorder where upload_flag=0 and presmasterid in (select presmasterid from mz_presmaster where patlistid = " + PatlistId + " and record_flag in (0,1,2) and prescostcode='" + _employeeId + "')" );
            DataTable tbCostMaster = MSAccessDb.GetDataTable( "select * from mz_costmaster where upload_flag=0 and patlistid = " + PatlistId + " and record_flag in (0,1,2) and chargecode='" + _employeeId + "'" );
            DataTable tbCostOrder = MSAccessDb.GetDataTable( "select * from mz_costorder where upload_flag=0 and costid in (select costmasterid from mz_costmaster where patlistid = " + PatlistId + " and record_flag in (0,1,2) and chargecode='" + _employeeId + "')" );
            DataTable tbAccount = MSAccessDb.GetDataTable( "select * from mz_account where accountcode='" + _employeeId + "' and upload_flag = 0 " );
            string patName = tbPatList.Rows[0]["patname"].ToString( );
            int presMasterCount = tbPresMaster.Rows.Count;
            int presOrderCount = tbPresOrder.Rows.Count;
            int costMasterCount = tbCostMaster.Rows.Count;
            int costOrderCount = tbCostOrder.Rows.Count;
            int accountCount = tbAccount.Rows.Count;

            if ( UpLoadingEvent != null )
                UpLoadingEvent( DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "开始上传病人【"+patName+"】的数据！\r\n" );
            if ( presMasterCount == 0 && presOrderCount == 0 && costMasterCount == 0 && costOrderCount == 0 && accountCount == 0 )
            {
                if ( UpLoadingEvent != null )
                    UpLoadingEvent( "病人【" + patName + "】没有需要上传的数据！\r\n" );
                return;
            }
            try
            {
                BeginTrans( );

                MZ_PatList mz_patlist = new MZ_PatList( );
                DataBind<MZ_PatList>( tbPatList.Rows[0] , mz_patlist );
                BindEntity<MZ_PatList>.CreateInstanceDAL( _oleDb ).Add( mz_patlist );
                int serverPatlistId = mz_patlist.PatListID;
                MSAccessDb.Execute( "update mz_patlist set upload_flag =1 where patlistid=" + PatlistId );
                for ( int accountIndex = 0 ; accountIndex < tbAccount.Rows.Count ; accountIndex++ )
                {
                    //上传交款记录
                    int localAccountId = Convert.ToInt32( tbAccount.Rows[accountIndex][Tables.mz_account.ACCOUNTID] );
                    MZ_Account mz_account = new MZ_Account( );
                    DataBind<MZ_Account>( tbAccount.Rows[accountIndex] , mz_account );
                    BindEntity<MZ_Account>.CreateInstanceDAL( _oleDb ).Add( mz_account );
                    MSAccessDb.Execute( "update mz_account set upload_flag = 1 where accountid=" +localAccountId );
                    //上传已交款的结算记录、结算明细，处方记录和处方明细(传完后从tbCostMaster中移除，剩下未交账的记录)
                    #region .....
                    DataRow[] drsCostMaster = tbCostMaster.Select( Tables.mz_costmaster.ACCOUNTID + "=" + localAccountId );
                    for ( int costmasterIndex = 0 ; costmasterIndex < drsCostMaster.Length ; costmasterIndex++ )
                    {
                        //结算记录
                        int localCostMasterId = Convert.ToInt32( drsCostMaster[costmasterIndex][Tables.mz_costmaster.COSTMASTERID] );
                        MZ_CostMaster mz_costmaster = new MZ_CostMaster( );
                        DataBind<MZ_CostMaster>( drsCostMaster[costmasterIndex] , mz_costmaster );
                        mz_costmaster.AccountID = mz_account.AccountID;
                        mz_costmaster.PatListID = serverPatlistId;
                        BindEntity<MZ_CostMaster>.CreateInstanceDAL( _oleDb ).Add( mz_costmaster );
                        MSAccessDb.Execute( "update mz_costmaster set upload_flag =1 where costmasterid=" + localCostMasterId );
                        //结算明细
                        DataRow[] drsCostOrder = tbCostOrder.Select( Tables.mz_costorder.COSTID + "=" + localCostMasterId );
                        for ( int costorderIndex = 0 ; costorderIndex < drsCostOrder.Length ; costorderIndex++ )
                        {
                            int loaclCostorderId = Convert.ToInt32( drsCostOrder[costorderIndex][Tables.mz_costorder.COSTORDERID] );
                            MZ_CostOrder mz_costorder = new MZ_CostOrder( );
                            DataBind<MZ_CostOrder>( drsCostOrder[costorderIndex] , mz_costorder );
                            mz_costorder.CostID = mz_costmaster.CostMasterID;
                            BindEntity<MZ_CostOrder>.CreateInstanceDAL( _oleDb ).Add( mz_costorder );
                            MSAccessDb.Execute( "update mz_costorder set upload_flag =1 where costorderid=" + loaclCostorderId );
                        }
                        //处方记录
                        DataRow[] drsPresMaster = tbPresMaster.Select( Tables.mz_presmaster.COSTMASTERID + "=" + localCostMasterId );
                        for ( int presMasterIndex = 0 ; presMasterIndex < drsPresMaster.Length ; presMasterIndex++ )
                        {
                            int localPresMasterId = Convert.ToInt32( drsPresMaster[presMasterIndex][Tables.mz_presmaster.PRESMASTERID] );
                            MZ_PresMaster mz_presmaster = new MZ_PresMaster( );
                            DataBind<MZ_PresMaster>( drsPresMaster[presMasterIndex] , mz_presmaster );
                            mz_presmaster.CostMasterID = mz_costmaster.CostMasterID;
                            mz_presmaster.PatListID = serverPatlistId;
                            BindEntity<MZ_PresMaster>.CreateInstanceDAL( _oleDb ).Add( mz_presmaster );
                            MSAccessDb.Execute( "update mz_presmaster set upload_flag =1 where presmasterid=" + localPresMasterId );
                            //处方明细
                            DataRow[] drsPresOrder = tbPresOrder.Select( Tables.mz_presorder.PRESMASTERID + "=" + localPresMasterId );
                            for ( int presorderIndex = 0 ; presorderIndex < drsPresOrder.Length ; presorderIndex++ )
                            {
                                int localPresOrderId = Convert.ToInt32( drsPresOrder[presorderIndex][Tables.mz_presorder.PRESORDERID] );
                                MZ_PresOrder mz_presorder = new MZ_PresOrder( );
                                DataBind<MZ_PresOrder>( drsPresOrder[presorderIndex] , mz_presorder );
                                mz_presorder.PresMasterID = mz_presmaster.PresMasterID;
                                BindEntity<MZ_PresOrder>.CreateInstanceDAL( _oleDb ).Add( mz_presorder );
                                MSAccessDb.Execute( "update mz_presorder set upload_flag =1 where presorderid=" + localPresOrderId );
                            }
                        }
                        tbCostMaster.Rows.Remove( drsCostMaster[costmasterIndex] );
                    }
                    #endregion
                }
                //上传未交账的结算记录
                for ( int costMasterIndex = 0 ; costMasterIndex < tbCostMaster.Rows.Count ; costMasterIndex++ )
                {
                    #region ...
                    //结算记录
                    int localCostMasterId = Convert.ToInt32( tbCostMaster.Rows[costMasterIndex][Tables.mz_costmaster.COSTMASTERID] );
                    MZ_CostMaster mz_costmaster = new MZ_CostMaster( );
                    DataBind<MZ_CostMaster>( tbCostMaster.Rows[costMasterIndex] , mz_costmaster );
                    mz_costmaster.PatListID = serverPatlistId;
                    BindEntity<MZ_CostMaster>.CreateInstanceDAL( _oleDb ).Add( mz_costmaster );
                    MSAccessDb.Execute( "update mz_costmaster set upload_flag =1 where costmasterid=" +localCostMasterId );
                    //结算明细
                    DataRow[] drsCostOrder = tbCostOrder.Select( Tables.mz_costorder.COSTID + "=" + localCostMasterId );
                    for ( int costorderIndex = 0 ; costorderIndex < drsCostOrder.Length ; costorderIndex++ )
                    {
                        int loaclCostorderId = Convert.ToInt32( drsCostOrder[costorderIndex][Tables.mz_costorder.COSTORDERID] );
                        MZ_CostOrder mz_costorder = new MZ_CostOrder( );
                        DataBind<MZ_CostOrder>( drsCostOrder[costorderIndex] , mz_costorder );
                        mz_costorder.CostID = mz_costmaster.CostMasterID;
                        BindEntity<MZ_CostOrder>.CreateInstanceDAL( _oleDb ).Add( mz_costorder );
                        MSAccessDb.Execute( "update mz_costorder set upload_flag=1 where costorderid=" + loaclCostorderId );
                    }
                    //处方记录
                    DataRow[] drsPresMaster = tbPresMaster.Select( Tables.mz_presmaster.COSTMASTERID + "=" + localCostMasterId );
                    for ( int presMasterIndex = 0 ; presMasterIndex < drsPresMaster.Length ; presMasterIndex++ )
                    {
                        int localPresMasterId = Convert.ToInt32( drsPresMaster[presMasterIndex][Tables.mz_presmaster.PRESMASTERID] );
                        MZ_PresMaster mz_presmaster = new MZ_PresMaster( );
                        DataBind<MZ_PresMaster>( drsPresMaster[presMasterIndex] , mz_presmaster );
                        mz_presmaster.CostMasterID = mz_costmaster.CostMasterID;
                        mz_presmaster.PatListID = serverPatlistId;
                        BindEntity<MZ_PresMaster>.CreateInstanceDAL( _oleDb ).Add( mz_presmaster );
                        MSAccessDb.Execute( "update mz_presmaster set upload_flag=1 where presmasterid=" +localPresMasterId );
                        //处方明细
                        DataRow[] drsPresOrder = tbPresOrder.Select( Tables.mz_presorder.PRESMASTERID + "=" + localPresMasterId );
                        for ( int presorderIndex = 0 ; presorderIndex < drsPresOrder.Length ; presorderIndex++ )
                        {
                            int localPresOrderId = Convert.ToInt32( drsPresOrder[presorderIndex][Tables.mz_presorder.PRESORDERID] );
                            MZ_PresOrder mz_presorder = new MZ_PresOrder( );
                            DataBind<MZ_PresOrder>( drsPresOrder[presorderIndex] , mz_presorder );
                            mz_presorder.PresMasterID = mz_presmaster.PresMasterID;
                            BindEntity<MZ_PresOrder>.CreateInstanceDAL( _oleDb ).Add( mz_presorder );
                            MSAccessDb.Execute( "update mz_presorder set upload_flag =1 where presorderid=" + localPresOrderId );
                        }
                    }
                    #endregion
                }

                //提交事务
                CommitTrans( );

                if ( UpLoadingEvent != null )
                    UpLoadingEvent( DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss" ) + "上传成功！\r\n处方记录" + presMasterCount + "条,处方明细" + presOrderCount + "条,结算记录" + costMasterCount + "条,结算明细" + costOrderCount + "条,个人交款记录" + accountCount + "条\r\n\r\n" );
            }
            catch(Exception err)
            {
                RollbackTrans( );
                throw err;
            }
        }
        /// <summary>
        /// 上传发票信息
        /// </summary>
        public void UploadDataWithInvoiceInfo()
        {
            if ( _oleDb == null )
                ConnectToRemoteDB( );

            DataTable tbInvoice = MSAccessDb.GetDataTable( "select * from mz_invoice where upload_flag=0 and employee_id=" + _employeeId );
            int invoiceCount = tbInvoice.Rows.Count;
            if ( invoiceCount == 0 )
            {
                if ( UpLoadingEvent != null )
                    UpLoadingEvent( "没有需要上传的发票使用信息！\r\n" );
                return;
            }

            if ( UpLoadingEvent != null )
                UpLoadingEvent( DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss" ) + "开始上传个人发票使用记录！\r\n" );
            try
            {
                BeginTrans( );

                for ( int invoiceIndex = 0 ; invoiceIndex < tbInvoice.Rows.Count ; invoiceIndex++ )
                {
                    int localInvoiceId = Convert.ToInt32( tbInvoice.Rows[invoiceIndex][Tables.mz_invoice.ID] );
                    MZ_INVOICE mz_invoice = new MZ_INVOICE( );
                    DataBind<MZ_INVOICE>( tbInvoice.Rows[invoiceIndex] , mz_invoice );
                    string strWhere = Tables.mz_invoice.ID + _oleDb.EuqalTo( ) + localInvoiceId;
                    if ( BindEntity<MZ_INVOICE>.CreateInstanceDAL( _oleDb ).Exists( strWhere ) )
                    {
                        BindEntity<MZ_INVOICE>.CreateInstanceDAL( _oleDb ).Update( mz_invoice );
                        MSAccessDb.Execute( "update mz_invoice set upload_flag = 1 where id = " + localInvoiceId );
                    }
                    else
                    {
                        BindEntity<MZ_INVOICE>.CreateInstanceDAL( _oleDb ).Add( mz_invoice );
                        int serverInvoiceId = mz_invoice.ID;
                        MSAccessDb.Execute( "update mz_invoice set upload_flag = 1,id = " + serverInvoiceId + " where id = " + localInvoiceId );
                    }
                    
                }
                CommitTrans( );
                if ( UpLoadingEvent != null )
                    UpLoadingEvent( DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss" ) + "上传个人发票使用记录成功！\r\n发票使用记录" + invoiceCount + "条\r\n\r\n" );
            }
            catch ( Exception err )
            {
                RollbackTrans( );
                throw err;
            }

        }
        /// <summary>
        /// 上传结束
        /// </summary>
        public void UploadFinished()
        {
            if ( UpLoadingEvent != null )
                UpLoadingEvent( "本次上传操作结束！\r\n\r\n" );   
        }
        /// <summary>
        /// 保存日志
        /// </summary>
        /// <param name="Message"></param>
        public void WriteLog( string Message )
        {
            string logFileName = "UPLOAD" + DateTime.Now.ToString( "yyyyMMdd" ) + ".log";
            string fullFilePath = System.Windows.Forms.Application.StartupPath + "\\log\\";
            string fullFileName = fullFilePath + logFileName;
            try
            {
                if ( !Directory.Exists( fullFilePath ) )
                    Directory.CreateDirectory( fullFilePath );

                if ( File.Exists( fullFileName ) )
                {
                    using ( StreamWriter sw = File.AppendText( fullFileName ) )
                    {
                        
                        sw.WriteLine( Message );
                        sw.Flush( );
                        sw.Close( );
                    }
                }
                else
                {
                    using ( StreamWriter sw = File.CreateText( fullFileName ) )
                    {
                        sw.WriteLine( Message );
                        sw.Flush( );
                        sw.Close( );
                    }
                }
            }
            catch
            {
                return;
            }
        }

    }
}
