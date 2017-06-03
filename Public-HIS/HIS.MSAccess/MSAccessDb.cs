using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using HIS.Model;
using HIS.BLL;

namespace HIS.MSAccess
{
    public class MSAccessDb 
    {
        /// <summary>
        /// 静态连接类，如果关闭，再打开
        /// </summary>
        private static OleDbConnection connect;
        private static OleDbTransaction trans;

        private static bool IsInTrans;
        
        public static DataTable GetDataTable(string strSql)
        {
            OpenConnection( );

            OleDbCommand cmd = connect.CreateCommand( );
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.CommandTimeout = 30;
            if ( trans != null && IsInTrans )
                cmd.Transaction = trans;

            OleDbDataAdapter adp = new OleDbDataAdapter( cmd );
            DataTable datatable = new DataTable( );
            try
            {
                adp.Fill( datatable );
                return datatable;
            }
            catch ( Exception err )
            {
                throw err;
            }
            finally
            {
                adp.Dispose( );
                cmd.Dispose( );
            }

        }

        public static DataTable GetDataTable( string TableName , string where )
        {
            string sql = "select * from " + TableName + " where " + where;
            return GetDataTable( sql );
        }

        public static int Execute( string sql )
        {
            OpenConnection( );

            OleDbCommand cmd = connect.CreateCommand( );
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            cmd.CommandTimeout = 30;
            if ( trans != null && IsInTrans )
                cmd.Transaction = trans;
            try
            {
                int effect = cmd.ExecuteNonQuery( );

                return effect;
            }
            catch(Exception err)
            {
                throw new Exception( "执行SQL语句失败！\r\n"+err.Message+"{"+cmd.CommandText+"}" );
            }
        }

        public static int GetMaxID( string TableName , string ColumnName )
        {
            OpenConnection( );

            OleDbCommand cmd = connect.CreateCommand( );
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select max("+ColumnName+")+1 from " + TableName;
            cmd.CommandTimeout = 30;
            if ( trans != null && IsInTrans )
                cmd.Transaction = trans;
            object obj = cmd.ExecuteScalar( );
            if ( Convert.IsDBNull( obj ) )
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32( obj );
            }
        }

        public static void BeginTrans()
        {
            trans = connect.BeginTransaction( );
            IsInTrans = true;
        }

        public static void CommitTrans()
        {
            if ( trans != null )
            {
                trans.Commit( );
            }
            trans.Dispose( );
            trans = null;
            IsInTrans = false;
        }

        public static void RollbackTrans()
        {
            if ( trans != null )
            {
                trans.Rollback( );
            }
            trans.Dispose( );
            trans = null;
            IsInTrans = false;
        }

        private static void OpenConnection()
        {
            if ( connect == null )
                connect = new OleDbConnection( );
            else
            {
                if ( connect.State == ConnectionState.Open )
                    return;
            }

            string dbPath = System.Windows.Forms.Application.StartupPath + "\\HIS.mdb";

            connect.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+dbPath+";User Id=;Password=;";
            try
            {
                connect.Open( );
            }
            catch
            {
                throw new Exception( "创建数据访问失败！" );
            }
        }

        public static int InsertRecord( object model ,string identityColumnName)
        {
            Type type = model.GetType( );

            if ( type == typeof( MZ_PresMaster ) )
            {
                return insert_mz_presmaster( ( MZ_PresMaster )model );
            }
            else if ( type == typeof( MZ_PresOrder ) )
            {
                return insert_mz_presorder( (MZ_PresOrder)model );
            }
            else if ( type == typeof( MZ_CostMaster ) )
            {
                return insert_mz_costmaster( (MZ_CostMaster)model );
            }
            else if ( type == typeof( MZ_CostOrder ) )
            {
                return insert_mz_costorder( (MZ_CostOrder)model );
            }
            else if ( type == typeof( MZ_PatList ) )
            {
                return insert_mz_patlist( (MZ_PatList)model );
            }
            else if ( type == typeof( MZ_Account ) )
            {
                return insert_mz_account( (MZ_Account)model );
            }
            else if ( type == typeof( MZ_INVOICE ) )
            {
                return insert_mz_invoice( (MZ_INVOICE)model );
            }
            else
            {
                return 0;
            }
        }

        public static void UpdateRecord( object model  )
        {
            Type type = model.GetType( );

            if ( type == typeof( MZ_PresMaster ) )
            {
                update_mz_presmaster( (MZ_PresMaster)model );
            }
            else if ( type == typeof( MZ_PresOrder ) )
            {
                update_mz_presorder( (MZ_PresOrder)model );
            }
            else if ( type == typeof( MZ_CostMaster ) )
            {
                update_mz_costmaster( (MZ_CostMaster)model );
            }
            else if ( type == typeof( MZ_CostOrder ) )
            {
                update_mz_costorder( (MZ_CostOrder)model );
            }
            else if ( type == typeof( MZ_PatList ) )
            {
                update_mz_patlist( (MZ_PatList)model );
            }
            else if ( type == typeof( MZ_INVOICE ) )
            {
                update_mz_invoice( (MZ_INVOICE)model );
            }
            else
            {
                return;
            }
        }

        public static void UpdateRecord( string[] FieldAndValue,string strWhere ,Type type )
        {
            
            if ( type == typeof( MZ_PresMaster ) )
            {
                update_mz_presmaster( FieldAndValue,strWhere );
            }
            else if ( type == typeof( MZ_PresOrder ) )
            {
                update_mz_presorder( FieldAndValue , strWhere );
            }
            else if ( type == typeof( MZ_CostMaster ) )
            {
                update_mz_costmaster( FieldAndValue , strWhere );
            }
            else if ( type == typeof( MZ_CostOrder ) )
            {
                update_mz_costorder( FieldAndValue , strWhere );
            }
            else if ( type == typeof( MZ_PatList ) )
            {
                update_mz_patlist( FieldAndValue , strWhere );
            }
            else
            {
                return;
            }
        }

        public static bool Exists( string TableName,string strWhere )
        {
            string sql = "select * from " + TableName + " where " + strWhere;
            DataTable tb = GetDataTable( sql );
            if ( tb.Rows.Count == 0 )
                return false;
            else
                return true;
        }

        public static object GetModel( string TableName, string strWhere ,Type type)
        {
            string sql = "select * from " + TableName + " where " + strWhere;
            DataTable tb = GetDataTable( sql );
            if ( tb.Rows.Count == 0 )
                return null;
            object obj = type.Assembly.CreateInstance( type.FullName );
            System.Reflection.PropertyInfo[] ps = obj.GetType( ).GetProperties( );
            for ( int i = 0 ; i < tb.Columns.Count ; i++ )
            {
                object objValue = tb.Rows[0][tb.Columns[i].ColumnName];
                for ( int j = 0 ; j < ps.Length ; j++ )
                {
                    if ( ps[j].Name.ToUpper( ) == tb.Columns[i].ColumnName.ToUpper( ) )
                    {
                        if ( objValue.GetType( ) == typeof(System.Double) )
                            objValue = Convert.ToDecimal( objValue );

                        obj.GetType( ).GetProperty( ps[j].Name ).SetValue( obj , objValue , null );
                        break;
                    }
                }
            }
            return obj;
        }

        public static List<T> GetListArray<T>( string TableName, string where )
        {
            string sql = "select * from " + TableName;
            if ( where.Trim( ) != "" )
                sql += " where " + where;

            DataTable tb = MSAccessDb.GetDataTable( sql );            

            List<T> list = new List<T>( );
            Type type = typeof( T );

            for ( int row = 0 ; row < tb.Rows.Count ; row++ )
            {
                object obj = type.Assembly.CreateInstance( type.FullName );
                System.Reflection.PropertyInfo[] ps = obj.GetType( ).GetProperties( );
                for ( int i = 0 ; i < tb.Columns.Count ; i++ )
                {
                    object objValue = tb.Rows[row][tb.Columns[i].ColumnName];
                    for ( int j = 0 ; j < ps.Length ; j++ )
                    {
                        if ( ps[j].Name.ToUpper( ) == tb.Columns[i].ColumnName.ToUpper( ) )
                        {
                            if ( objValue.GetType( ) == typeof( System.Double ) )
                                objValue = Convert.ToDecimal( objValue );

                            obj.GetType( ).GetProperty( ps[j].Name ).SetValue( obj , objValue , null );
                            break;
                        }
                    }
                }
                list.Add( (T)obj );
            }
            return list;
        }

        private static int insert_mz_presmaster( MZ_PresMaster mz_presmaster )
        {
            string insert = "insert into mz_presmaster(" +
                                                        Tables.mz_presmaster.PRESMASTERID + "," +
                                                        Tables.mz_presmaster.CHARGE_FLAG + "," +
                                                        Tables.mz_presmaster.CHARGECODE + "," +
                                                        Tables.mz_presmaster.DRUG_FLAG + "," +
                                                        Tables.mz_presmaster.EXECDEPTCODE + "," +
                                                        Tables.mz_presmaster.EXECDOCCODE + "," +
                                                        Tables.mz_presmaster.HAND_FLAG + "," +
                                                        Tables.mz_presmaster.PATID + "," +
                                                        Tables.mz_presmaster.PATLISTID + "," +
                                                        Tables.mz_presmaster.PRESAMOUNT + "," +
                                                        Tables.mz_presmaster.PRESCOSTCODE + "," +
                                                        Tables.mz_presmaster.PRESDATE + "," +
                                                        Tables.mz_presmaster.PRESDEPTCODE + "," +
                                                        Tables.mz_presmaster.PRESDOCCODE + "," +
                                                        Tables.mz_presmaster.COSTMASTERID + "," +
                                                        Tables.mz_presmaster.PRESTYPE + "," +
                                                        Tables.mz_presmaster.RECORD_FLAG + "," +
                                                        Tables.mz_presmaster.REDEEMCOST + "," +
                                                        Tables.mz_presmaster.ROUNGINGMONEY + "," +
                                                        Tables.mz_presmaster.TICKETCODE + "," +
                                                        Tables.mz_presmaster.TICKETNUM + "," +
                                                        Tables.mz_presmaster.TOTAL_FEE + ")";

            string values = "values (" + mz_presmaster.PresMasterID + "," +
                                         "" + mz_presmaster.Charge_Flag + "," +
                                        "'" + mz_presmaster.ChargeCode + "'," +
                                        "" + mz_presmaster.Drug_Flag + "," +
                                        "'" + mz_presmaster.ExecDeptCode + "'," +
                                        "'" + mz_presmaster.ExecDocCode + "'," +
                                        "" + mz_presmaster.Hand_Flag + "," +
                                        "" + mz_presmaster.PatID + "," +
                                        "" + mz_presmaster.PatListID + "," +
                                        "" + mz_presmaster.PresAmount + "," +
                                        "'" + mz_presmaster.PresCostCode + "'," +
                                        "#" + mz_presmaster.PresDate + "#," +
                                        "'" + mz_presmaster.PresDeptCode + "'," +
                                        "'" + mz_presmaster.PresDocCode + "'," +
                                        "" + mz_presmaster.CostMasterID + "," +
                                        "'" + mz_presmaster.PresType + "'," +
                                        "" + mz_presmaster.Record_Flag + "," +
                                        "" + mz_presmaster.RedeemCost + "," +
                                        "" + mz_presmaster.RoungingMoney + "," +
                                        "'" + mz_presmaster.TicketCode + "'," +
                                        "'" + mz_presmaster.TicketNum + "'," +
                                        "" + mz_presmaster.Total_Fee + ")";

            int effectrow = Execute( insert + " " + values  );
            
            return mz_presmaster.PresMasterID;
        }

        private static int insert_mz_presorder( MZ_PresOrder mz_presorder )
        {
            string insert = "insert into MZ_PRESORDER (" +
                                "" + Tables.mz_presorder.PRESORDERID + "," +
                                "" + Tables.mz_presorder.AMOUNT + "," +
                                "" + Tables.mz_presorder.BIGITEMCODE + "," +
                                "" + Tables.mz_presorder.BUY_PRICE + "," +
                                "" + Tables.mz_presorder.CASEID + "," +
                                "" + Tables.mz_presorder.COMP_MONEY + "," +
                                "" + Tables.mz_presorder.ITEMID + "," +
                                "" + Tables.mz_presorder.ITEMNAME + "," +
                                "" + Tables.mz_presorder.ITEMTYPE + "," +
                                "" + Tables.mz_presorder.ORDER_FLAG + "," +
                                "" + Tables.mz_presorder.PASSID + "," +
                                "" + Tables.mz_presorder.PATID + "," +
                                "" + Tables.mz_presorder.PATLISTID + "," +
                                "" + Tables.mz_presorder.PRESAMOUNT + "," +
                                "" + Tables.mz_presorder.PRESMASTERID + "," +
                                "" + Tables.mz_presorder.RELATIONNUM + "," +
                                "" + Tables.mz_presorder.SELL_PRICE + "," +
                                "" + Tables.mz_presorder.STANDARD + "," +
                                "" + Tables.mz_presorder.TOLAL_FEE + "," +
                                "" + Tables.mz_presorder.UNIT + ")";
            string values = "values (" +
                                "" + mz_presorder.PresOrderID + "," +
                                "" + mz_presorder.Amount + "," +
                                "'" + mz_presorder.BigItemCode + "'," +
                                "" + mz_presorder.Buy_Price + "," +
                                "" + mz_presorder.CaseID + "," +
                                "" + mz_presorder.Comp_Money + "," +
                                "" + mz_presorder.ItemID + "," +
                                "'" + mz_presorder.ItemName + "'," +
                                "'" + mz_presorder.ItemType + "'," +
                                "" + mz_presorder.Order_Flag + "," +
                                "" + mz_presorder.PassID + "," +
                                "" + mz_presorder.PatID + "," +
                                "" + mz_presorder.PatListID + "," +
                                "" + mz_presorder.PresAmount + "," +
                                "" + mz_presorder.PresMasterID + "," +
                                "" + mz_presorder.RelationNum + "," +
                                "" + mz_presorder.Sell_Price + "," +
                                "'" + mz_presorder.Standard + "'," +
                                "" + mz_presorder.Tolal_Fee + "," +
                                "'" + mz_presorder.Unit + "')";

            int effectrow = Execute( insert + " " + values  );
           
            return mz_presorder.PresOrderID;
        }

        private static int insert_mz_costmaster( MZ_CostMaster mz_costmaster )
        {
            string insert = "insert into MZ_COSTMASTER (" +
                                "" + Tables.mz_costmaster.COSTMASTERID + "," +
                                "" + Tables.mz_costmaster.ACCOUNTID + "," +
                                "" + Tables.mz_costmaster.CHARGECODE + "," +
                                "" + Tables.mz_costmaster.CHARGENAME + "," +
                                "" + Tables.mz_costmaster.COSTDATE + "," +
                                "" + Tables.mz_costmaster.FAVOR_FEE + "," +
                                "" + Tables.mz_costmaster.HANG_FLAG + "," +
                                "" + Tables.mz_costmaster.HURRIED_FLAG + "," +
                                "" + Tables.mz_costmaster.MONEY_FEE + "," +
                                "" + Tables.mz_costmaster.OLDID + "," +
                                "" + Tables.mz_costmaster.PATID + "," +
                                "" + Tables.mz_costmaster.PATLISTID + "," +
                                "" + Tables.mz_costmaster.POS_FEE + "," +
                                "" + Tables.mz_costmaster.PRESMASTERID + "," +
                                "" + Tables.mz_costmaster.RECORD_FLAG + "," +
                                "" + Tables.mz_costmaster.SELF_FEE + "," +
                                "" + Tables.mz_costmaster.SELF_TALLY + "," +
                                "" + Tables.mz_costmaster.TICKET_FLAG + "," +
                                "" + Tables.mz_costmaster.TICKETCODE + "," +
                                "" + Tables.mz_costmaster.TICKETNUM + "," +
                                "" + Tables.mz_costmaster.TOTAL_FEE + "," +
                                "" + Tables.mz_costmaster.VILLAGE_FEE + ")";

            string values = "values (" +
                                "" + mz_costmaster.CostMasterID + "," +
                                "" + mz_costmaster.AccountID + "," +
                                "'" + mz_costmaster.ChargeCode + "'," +
                                "'" + mz_costmaster.ChargeName + "'," +
                                "#" + mz_costmaster.CostDate + "#," +
                                "" + mz_costmaster.Favor_Fee + "," +
                                "" + mz_costmaster.Hang_Flag + "," +
                                "" + mz_costmaster.Hurried_Flag + "," +
                                "" + mz_costmaster.Money_Fee + "," +
                                "" + mz_costmaster.OldID + "," +
                                "" + mz_costmaster.PatID + "," +
                                "" + mz_costmaster.PatListID + "," +
                                "" + mz_costmaster.Pos_Fee + "," +
                                "" + mz_costmaster.PresMasterID + "," +
                                "" + mz_costmaster.Record_Flag + "," +
                                "" + mz_costmaster.Self_Fee + "," +
                                "" + mz_costmaster.Self_Tally + "," +
                                "" + mz_costmaster.Ticket_Flag + "," +
                                "'" + mz_costmaster.TicketCode + "'," +
                                "'" + mz_costmaster.TicketNum + "'," +
                                "" + mz_costmaster.Total_Fee + "," +
                                "" + mz_costmaster.Village_Fee + ")";
   
            int effectrow = Execute( insert + " " + values );
   
            return mz_costmaster.CostMasterID;
        }

        private static int insert_mz_costorder( MZ_CostOrder mz_costorder )
        {
            string insert = "insert into  MZ_COSTORDER (" +
                            "" + Tables.mz_costorder.COSTORDERID + "" + "," +
                            "" + Tables.mz_costorder.COSTID + "" + "," +
                            "" + Tables.mz_costorder.ITEMTYPE + "" + "," +
                            "" + Tables.mz_costorder.TICKETCODE + "" + "," +
                            "" + Tables.mz_costorder.TICKETNUM + "" + "," +
                            "" + Tables.mz_costorder.TOTAL_FEE + "" + ")";
            string values = " values (" +
                            "" + mz_costorder.CostOrderID + "" + "," +
                            "" + mz_costorder.CostID + "" + "," +
                            "'" + mz_costorder.ItemType + "'" + "," +
                            "'" + mz_costorder.TicketCode + "'" + "," +
                            "'" + mz_costorder.TicketNum + "'" + "," +
                            "" + mz_costorder.Total_Fee + "" + ")";
        
            int effectrow = Execute( insert + " " + values  );
            
            return mz_costorder.CostOrderID;
        }

        private static int insert_mz_patlist( MZ_PatList mz_patlist )
        {
            string insert = "insert into MZ_PATLIST (" +
                            "" + Tables.mz_patlist.PATLISTID + "" + "," +
                            "" + Tables.mz_patlist.AGE + "" + "," +
                            "" + Tables.mz_patlist.CUREDATE + "" + "," +
                            "" + Tables.mz_patlist.CUREDEPTCODE + "" + "," +
                            "" + Tables.mz_patlist.CUREEMPCODE + "" + "," +
                            "" + Tables.mz_patlist.DISEASECODE + "" + "," +
                            "" + Tables.mz_patlist.DISEASENAME + "" + "," +
                            "" + Tables.mz_patlist.HPCODE + "" + "," +
                            "" + Tables.mz_patlist.HPGRADE + "" + "," +
                            "" + Tables.mz_patlist.MEDICARD + "" + "," +
                            "" + Tables.mz_patlist.MEDITYPE + "" + "," +
                            "" + Tables.mz_patlist.PATCODE + "" + "," +
                            "" + Tables.mz_patlist.PATID + "" + "," +
                            "" + Tables.mz_patlist.PATNAME + "" + "," +
                            "" + Tables.mz_patlist.PATSEX + "" + "," +
                            "" + Tables.mz_patlist.PYM + "" + "," +
                            "" + Tables.mz_patlist.REG_DEPT_CODE + "" + "," +
                            "" + Tables.mz_patlist.REG_DEPT_NAME + "" + "," +
                            "" + Tables.mz_patlist.REG_DOC_CODE + "" + "," +
                            "" + Tables.mz_patlist.REG_DOC_NAME + "" + "," +
                            "" + Tables.mz_patlist.REGCODE + "" + "," +
                            "" + Tables.mz_patlist.REGNAME + "" + "," +
                            "" + Tables.mz_patlist.WBM + "" + "," +
                            "" + Tables.mz_patlist.VISITNO + ")";

            string values = " values (" +
                            "" + mz_patlist.PatListID + "" + "," +
                            "" + mz_patlist.Age + "" + "," +
                            "#" + mz_patlist.CureDate + "#" + "," +
                            "'" + mz_patlist.CureDeptCode + "'" + "," +
                            "'" + mz_patlist.CureEmpCode + "'" + "," +
                            "'" + mz_patlist.DiseaseCode + "'" + "," +
                            "'" + mz_patlist.DiseaseName + "'" + "," +
                            "'" + mz_patlist.HpCode + "'" + "," +
                            "'" + mz_patlist.HpGrade + "'" + "," +
                            "'" + mz_patlist.MediCard + "'" + "," +
                            "'" + mz_patlist.MediType + "'" + "," +
                            "'" + mz_patlist.PatCode + "'" + "," +
                            "" + mz_patlist.PatID + "" + "," +
                            "'" + mz_patlist.PatName + "'" + "," +
                            "'" + mz_patlist.PatSex + "'" + "," +
                            "'" + mz_patlist.PYM + "'" + "," +
                            "'" + mz_patlist.REG_DEPT_CODE + "'" + "," +
                            "'" + mz_patlist.REG_DEPT_NAME + "'" + "," +
                            "'" + mz_patlist.REG_DOC_CODE + "'" + "," +
                            "'" + mz_patlist.REG_DOC_NAME + "'" + "," +
                            "'" + mz_patlist.RegCode + "'" + "," +
                            "'" + mz_patlist.RegName + "'" + "," +
                            "'" + mz_patlist.WBM + "'" + "," +
                            "'" + mz_patlist.VisitNo + "')";
            
            int effectrow = Execute( insert + " " + values  );

            return mz_patlist.PatListID;
        }

        private static int insert_mz_account( MZ_Account mz_account )
        {
            string insert = "insert into MZ_ACCOUNT (" +
                            "" + Tables.mz_account.ACCOUNTCODE + "" + "," +
                            "" + Tables.mz_account.ACCOUNTDATE + "" + "," +
                            "" + Tables.mz_account.ACCOUNTID + "" + "," +
                            "" + Tables.mz_account.BLANKOUT + "" + "," +
                            "" + Tables.mz_account.CASH_FEE + "" + "," +
                            "" + Tables.mz_account.LASTDATE + "" + "," +
                            "" + Tables.mz_account.POS_FEE + "" + "," +
                            "" + Tables.mz_account.TOTAL_FEE + "" + ")";
            string values = " values (" +
                            "'" + mz_account.AccountCode + "'" + "," +
                            "#" + mz_account.AccountDate + "#" + "," +
                            "" + mz_account.AccountID + "" + "," +
                            "'" + mz_account.BlankOut + "'" + "," +
                            "" + mz_account.Cash_Fee + "" + "," +
                            "#" + mz_account.LastDate + "#" + "," +
                            "" + mz_account.POS_Fee + "" + "," +
                            "" + mz_account.Total_Fee + "" + ")";

            int effectrow = Execute( insert + " " + values );

            return mz_account.AccountID;
        }

        private static int insert_mz_invoice( MZ_INVOICE mz_invoice )
        {
            string insert = "insert into " + "MZ_INVOICE" + "(" +
                            "" + Tables.mz_invoice.CURRENT_NO + "" + "," +
                            "" + Tables.mz_invoice.EMPLOYEE_ID + "" + "," +
                            "" + Tables.mz_invoice.END_NO + "" + "," +
                            "" + Tables.mz_invoice.ID + "" + "," +
                            "" + Tables.mz_invoice.INVOICE_TYPE + "" + "," +
                            "" + Tables.mz_invoice.PERFCHAR + "" + "," +
                            "" + Tables.mz_invoice.START_NO + "" + "," +
                            "" + Tables.mz_invoice.STATUS + "" + ")";
            string values = " values (" +
                            "" + mz_invoice.CURRENT_NO + "" + "," +
                            "" + mz_invoice.EMPLOYEE_ID + "" + "," +
                            "" + mz_invoice.END_NO + "" + "," +
                            "'" + mz_invoice.ID + "'" + "," +
                            "" + mz_invoice.INVOICE_TYPE + "" + "," +
                            "'" + mz_invoice.PerfChar + "'" + "," +
                            "" + mz_invoice.START_NO + "" + "," +
                            "" + mz_invoice.STATUS + "" + ")";

            int effectrow = Execute( insert + " " + values );

            return mz_invoice.ID;
        }

        private static void update_mz_presmaster( MZ_PresMaster mz_presmaster )
        {
            string update = "update " + "MZ_PRESMASTER" + " set " +
                                Tables.mz_presmaster.CHARGE_FLAG + "=" + "" + mz_presmaster.Charge_Flag + "" + "," +
                                Tables.mz_presmaster.CHARGECODE + "=" + "'" + mz_presmaster.ChargeCode + "'" + "," +
                                Tables.mz_presmaster.COSTMASTERID + "=" + "" + mz_presmaster.CostMasterID + "" + "," +
                                Tables.mz_presmaster.DRUG_FLAG + "=" + "" + mz_presmaster.Drug_Flag + "" + "," +
                                Tables.mz_presmaster.EXECDEPTCODE + "=" + "'" + mz_presmaster.ExecDeptCode + "'" + "," +
                                Tables.mz_presmaster.EXECDOCCODE + "=" + "'" + mz_presmaster.ExecDocCode + "'" + "," +
                                Tables.mz_presmaster.HAND_FLAG + "=" + "" + mz_presmaster.Hand_Flag + "" + "," +
                                Tables.mz_presmaster.OLDID + "=" + "" + mz_presmaster.OldID + "" + "," +
                                Tables.mz_presmaster.PATID + "=" + "" + mz_presmaster.PatID + "" + "," +
                                Tables.mz_presmaster.PATLISTID + "=" + "" + mz_presmaster.PatListID + "" + "," +
                                Tables.mz_presmaster.PRESAMOUNT + "=" + "" + mz_presmaster.PresAmount + "" + "," +
                                Tables.mz_presmaster.PRESCOSTCODE + "=" + "'" + mz_presmaster.PresCostCode + "'" + "," +
                                Tables.mz_presmaster.PRESDATE + "=" + "#" + mz_presmaster.PresDate + "#" + "," +
                                Tables.mz_presmaster.PRESDEPTCODE + "=" + "'" + mz_presmaster.PresDeptCode + "'" + "," +
                                Tables.mz_presmaster.PRESDOCCODE + "=" + "'" + mz_presmaster.PresDocCode + "'" + "," +
                                Tables.mz_presmaster.PRESTYPE + "=" + "'" + mz_presmaster.PresType + "'" + "," +
                                Tables.mz_presmaster.RECORD_FLAG + "=" + "" + mz_presmaster.Record_Flag + "" + "," +
                                Tables.mz_presmaster.REDEEMCOST + "=" + "" + mz_presmaster.RedeemCost + "" + "," +
                                Tables.mz_presmaster.ROUNGINGMONEY + "=" + "" + mz_presmaster.RoungingMoney + "" + "," +
                                Tables.mz_presmaster.TICKETCODE + "=" + "'" + mz_presmaster.TicketCode + "'" + "," +
                                Tables.mz_presmaster.TICKETNUM + "=" + "'" + mz_presmaster.TicketNum + "'" + "," +
                                Tables.mz_presmaster.TOTAL_FEE + "=" + "" + mz_presmaster.Total_Fee + "" + 
                                " where " + Tables.mz_presmaster.PRESMASTERID + "=" + mz_presmaster.PresMasterID;
            Execute( update );
                            
        }

        private static void update_mz_presorder( MZ_PresOrder mz_presorder )
        {
            string update = "update " + "MZ_PRESORDER" + " set " +
                                Tables.mz_presorder.AMOUNT + "=" + "" + mz_presorder.Amount + "" + "," +
                                Tables.mz_presorder.BIGITEMCODE + "=" + "'" + mz_presorder.BigItemCode + "'" + "," +
                                Tables.mz_presorder.BUY_PRICE + "=" + "" + mz_presorder.Buy_Price + "" + "," +
                                Tables.mz_presorder.CASEID + "=" + "" + mz_presorder.CaseID + "" + "," +
                                Tables.mz_presorder.COMP_MONEY + "=" + "" + mz_presorder.Comp_Money + "" + "," +
                                Tables.mz_presorder.ITEMID + "=" + "" + mz_presorder.ItemID + "" + "," +
                                Tables.mz_presorder.ITEMNAME + "=" + "'" + mz_presorder.ItemName + "'" + "," +
                                Tables.mz_presorder.ITEMTYPE + "=" + "'" + mz_presorder.ItemType + "'" + "," +
                                Tables.mz_presorder.ORDER_FLAG + "=" + "" + mz_presorder.Order_Flag + "" + "," +
                                Tables.mz_presorder.PASSID + "=" + "" + mz_presorder.PassID + "" + "," +
                                Tables.mz_presorder.PATID + "=" + "" + mz_presorder.PatID + "" + "," +
                                Tables.mz_presorder.PATLISTID + "=" + "" + mz_presorder.PatListID + "" + "," +
                                Tables.mz_presorder.PRESAMOUNT + "=" + "" + mz_presorder.PresAmount + "" + "," +
                                Tables.mz_presorder.PRESMASTERID + "=" + "" + mz_presorder.PresMasterID + "" + "," +
                                Tables.mz_presorder.RELATIONNUM + "=" + "" + mz_presorder.RelationNum + "" + "," +
                                Tables.mz_presorder.SELL_PRICE + "=" + "" + mz_presorder.Sell_Price + "" + "," +
                                Tables.mz_presorder.STANDARD + "=" + "'" + mz_presorder.Standard + "'" + "," +
                                Tables.mz_presorder.TOLAL_FEE + "=" + "" + mz_presorder.Tolal_Fee + "" + "," +
                                Tables.mz_presorder.UNIT + "=" + "'" + mz_presorder.Unit + "'" +
                                " where " + Tables.mz_presorder.PRESORDERID + "=" + mz_presorder.PresOrderID;
            Execute( update );
        }

        private static void update_mz_costmaster( MZ_CostMaster mz_costmaster )
        {
            string update = "update " + "MZ_COSTMASTER" + " set " +
                                Tables.mz_costmaster.ACCOUNTID + "=" + "" + mz_costmaster.AccountID + "" + "," +
                                Tables.mz_costmaster.CHARGECODE + "=" + "'" + mz_costmaster.ChargeCode + "'" + "," +
                                Tables.mz_costmaster.CHARGENAME + "=" + "'" + mz_costmaster.ChargeName + "'" + "," +
                                Tables.mz_costmaster.COSTDATE + "=" + "#" + mz_costmaster.CostDate + "#" + "," +
                                Tables.mz_costmaster.FAVOR_FEE + "=" + "" + mz_costmaster.Favor_Fee + "" + "," +
                                Tables.mz_costmaster.HANG_FLAG + "=" + "" + mz_costmaster.Hang_Flag + "" + "," +
                                Tables.mz_costmaster.HURRIED_FLAG + "=" + "" + mz_costmaster.Hurried_Flag + "" + "," +
                                Tables.mz_costmaster.MONEY_FEE + "=" + "" + mz_costmaster.Money_Fee + "" + "," +
                                Tables.mz_costmaster.OLDID + "=" + "" + mz_costmaster.OldID + "" + "," +
                                Tables.mz_costmaster.PATID + "=" + "" + mz_costmaster.PatID + "" + "," +
                                Tables.mz_costmaster.PATLISTID + "=" + "" + mz_costmaster.PatListID + "" + "," +
                                Tables.mz_costmaster.POS_FEE + "=" + "" + mz_costmaster.Pos_Fee + "" + "," +
                                Tables.mz_costmaster.PRESMASTERID + "=" + "" + mz_costmaster.PresMasterID + "" + "," +
                                Tables.mz_costmaster.RECORD_FLAG + "=" + "" + mz_costmaster.Record_Flag + "" + "," +
                                Tables.mz_costmaster.SELF_FEE + "=" + "" + mz_costmaster.Self_Fee + "" + "," +
                                Tables.mz_costmaster.SELF_TALLY + "=" + "" + mz_costmaster.Self_Tally + "" + "," +
                                Tables.mz_costmaster.TICKET_FLAG + "=" + "" + mz_costmaster.Ticket_Flag + "" + "," +
                                Tables.mz_costmaster.TICKETCODE + "=" + "'" + mz_costmaster.TicketCode + "'" + "," +
                                Tables.mz_costmaster.TICKETNUM + "=" + "'" + mz_costmaster.TicketNum + "'" + "," +
                                Tables.mz_costmaster.TOTAL_FEE + "=" + "" + mz_costmaster.Total_Fee + "" + "," +
                                Tables.mz_costmaster.VILLAGE_FEE + "=" + "" + mz_costmaster.Village_Fee + "" + "" +
                                " where " + Tables.mz_costmaster.COSTMASTERID + "=" + "" + mz_costmaster.CostMasterID;
            Execute( update );
        }

        private static void update_mz_costorder( MZ_CostOrder mz_costorder )
        {
            string update = "update MZ_COSTORDER  set " +
                                Tables.mz_costorder.COSTID + "=" + "" + mz_costorder.CostID + "" + "," +
                                Tables.mz_costorder.ITEMTYPE + "=" + "'" + mz_costorder.ItemType + "'" + "," +
                                Tables.mz_costorder.TICKETCODE + "=" + "'" + mz_costorder.TicketCode + "'" + "," +
                                Tables.mz_costorder.TICKETNUM + "=" + "'" + mz_costorder.TicketNum + "'" + "," +
                                Tables.mz_costorder.TOTAL_FEE + "=" + "" + mz_costorder.Total_Fee +
                                " where " + Tables.mz_costorder.COSTORDERID + "=" + "" + mz_costorder.CostID;
            Execute( update );
        }

        private static void update_mz_patlist( MZ_PatList mz_patlist )
        {
            string update = "update MZ_PATLIST  set " +
                                Tables.mz_patlist.AGE + "=" + mz_patlist.Age + "" + "," +
                                Tables.mz_patlist.CUREDATE + "=#" + mz_patlist.CureDate + "#" + "," +
                                Tables.mz_patlist.CUREDEPTCODE + "='" + mz_patlist.CureDeptCode + "'" + "," +
                                Tables.mz_patlist.CUREEMPCODE + "='" + mz_patlist.CureEmpCode + "'" + "," +
                                Tables.mz_patlist.DISEASECODE + "='" + mz_patlist.DiseaseCode + "'" + "," +
                                Tables.mz_patlist.DISEASENAME + "='" + mz_patlist.DiseaseName + "'" + "," +
                                Tables.mz_patlist.HPCODE + "='" + mz_patlist.HpCode + "'" + "," +
                                Tables.mz_patlist.HPGRADE + "='" + mz_patlist.HpGrade + "'" + "," +
                                Tables.mz_patlist.MEDICARD + "='" + mz_patlist.MediCard + "'" + "," +
                                Tables.mz_patlist.MEDITYPE + "='" + mz_patlist.MediType + "'" + "," +
                                Tables.mz_patlist.PATCODE + "='" + mz_patlist.PatCode + "'" + "," +
                                Tables.mz_patlist.PATID + "=" + mz_patlist.PatID + "" + "," +
                                Tables.mz_patlist.PATNAME + "='" + mz_patlist.PatName + "'" + "," +
                                Tables.mz_patlist.PATSEX + "='" + mz_patlist.PatSex + "'" + "," +
                                Tables.mz_patlist.PYM + "='" + mz_patlist.PYM + "'" + "," +
                                Tables.mz_patlist.REG_DEPT_CODE + "='" + mz_patlist.REG_DEPT_CODE + "'" + "," +
                                Tables.mz_patlist.REG_DEPT_NAME + "='" + mz_patlist.REG_DEPT_NAME + "'" + "," +
                                Tables.mz_patlist.REG_DOC_CODE + "='" + mz_patlist.REG_DOC_CODE + "'" + "," +
                                Tables.mz_patlist.REG_DOC_NAME + "='" + mz_patlist.REG_DOC_NAME + "'" + "," +
                                Tables.mz_patlist.REGCODE + "='" + mz_patlist.RegCode + "'" + "," +
                                Tables.mz_patlist.REGNAME + "='" + mz_patlist.RegName + "'" + "," +
                                Tables.mz_patlist.VISITNO + "='" + mz_patlist.VisitNo + "'" + "," +
                                Tables.mz_patlist.WBM + "='" + mz_patlist.WBM + "'" + "" +
                            " where " + Tables.mz_patlist.PATLISTID + "=" + mz_patlist.PatListID;
            Execute( update );
        }

        private static void update_mz_invoice( MZ_INVOICE mz_invoice )
        {
            string update = "update MZ_INVOICE set " +
                                Tables.mz_invoice.CURRENT_NO + "=" + mz_invoice.CURRENT_NO + "" + "," +
                                Tables.mz_invoice.STATUS + "=" + mz_invoice.STATUS + "" + " " +
                               ", upload_flag = 0 where " + Tables.mz_invoice.ID + "=" + mz_invoice.ID + " and " + Tables.mz_invoice.EMPLOYEE_ID + "=" + mz_invoice.EMPLOYEE_ID;
            Execute( update );
        }

        private static void update_mz_presmaster( string[] FieldAndValue,string strWhere )
        {
            string updateFileds = "";
            for ( int i = 0 ; i < FieldAndValue.Length-1 ; i++ )
                updateFileds += FieldAndValue[i] + ",";
            updateFileds += FieldAndValue[FieldAndValue.Length - 1];

            string update = "update MZ_PRESMASTER  set " + updateFileds + " where " + strWhere;
                                
            Execute( update );

        }

        private static void update_mz_presorder( string[] FieldAndValue , string strWhere )
        {
            string updateFileds = "";
            for ( int i = 0 ; i < FieldAndValue.Length - 1 ; i++ )
                updateFileds += FieldAndValue[i] + ",";
            updateFileds += FieldAndValue[FieldAndValue.Length - 1];

            string update = "update MZ_PRESORDER set " + updateFileds + " where " + strWhere;
                                
            Execute( update );
        }

        private static void update_mz_costmaster( string[] FieldAndValue , string strWhere )
        {
            string updateFileds = "";
            for ( int i = 0 ; i < FieldAndValue.Length - 1 ; i++ )
                updateFileds += FieldAndValue[i] + ",";
            updateFileds += FieldAndValue[FieldAndValue.Length - 1];

            string update = "update MZ_COSTMASTER  set " + updateFileds + " where " + strWhere;
                                
            Execute( update );
        }

        private static void update_mz_costorder( string[] FieldAndValue , string strWhere )
        {
            string updateFileds = "";
            for ( int i = 0 ; i < FieldAndValue.Length - 1 ; i++ )
                updateFileds += FieldAndValue[i] + ",";
            updateFileds += FieldAndValue[FieldAndValue.Length - 1];

            string update = "update MZ_COSTORDER  set " + updateFileds + " where " + strWhere;
            Execute( update );
        }

        private static void update_mz_patlist( string[] FieldAndValue , string strWhere )
        {
            string updateFileds = "";
            for ( int i = 0 ; i < FieldAndValue.Length - 1 ; i++ )
                updateFileds += FieldAndValue[i] + ",";
            updateFileds += FieldAndValue[FieldAndValue.Length - 1];

            string update = "update  MZ_PATLIST set " + updateFileds + " where " + strWhere;
            Execute( update );
        }

        
    }
}
