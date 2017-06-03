using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace HIS.LocalDb
{
    public class DBManager
    {
        private static readonly string dbPath = System.Windows.Forms.Application.StartupPath + "\\HIS.mdb";

        public static bool LocalDbFileExists()
        {
            string dbPath = System.Windows.Forms.Application.StartupPath + "\\HIS.mdb";
            return File.Exists( dbPath );
        }

        public static void CreateLocalDbFile()
        {
            ADOX.CatalogClass catalog = new ADOX.CatalogClass( );
            try
            {
                catalog.Create( "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbPath + ";Jet OLEDB:Engine Type=5" );
                CreateTable( );
            }
            catch ( Exception err )
            {
                throw err;
            }
            finally
            {
                if ( catalog.ActiveConnection != null )
                {
                    catalog.ActiveConnection = null;
                }
            }
            
        }

        private static void CreateTable()
        {
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection( );
            conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbPath + ";user id=;password=;";
            conn.Open( );

            System.Data.OleDb.OleDbCommand cmd = conn.CreateCommand( );
            try
            {
                Create_BASEDOCTOR( cmd );
                Create_BASE_MZFP_ITEM( cmd );
                Create_BASE_PATIENTTYPE( cmd );
                Create_BASE_STAT_ITEM( cmd );
                Create_BASE_TEMPLATE_DETAIL( cmd );
                Create_BASE_EMPLOYEE_PROPERTY( cmd );
                Create_BASE_DEPT_PROPERTY( cmd );
                Create_BASE_USER( cmd );
                Create_BASE_PATIENTTYPE_COST( cmd );
                Create_BASE_ITEM_FAVORABLE( cmd );
                Create_BASE_ITEMMX_FAVORABLE( cmd );
                Create_BASE_WORK_UNIT( cmd );

                Create_MZ_INVOICE( cmd );
                Create_VI_MZ_SHOWCARD( cmd );
                Create_MZ_PRESMASTER( cmd );
                Create_MZ_PRESORDER( cmd );
                Create_MZ_COSTMASTER( cmd );
                Create_MZ_COSTORDER( cmd );
                Create_MZ_PATLIST( cmd );
                Create_MZ_ACCOUNT( cmd );
            }
            catch ( Exception err )
            {
                throw err;
            }
            finally
            {
                conn.Close( );
            }
            cmd.Dispose( );
            conn.Dispose( );
        }

        
        #region 表

        private static void Create_BASEDOCTOR(System.Data.OleDb.OleDbCommand cmd)
        {
            cmd.CommandText = @"create table BASE_DOCTOR(EMPLOYEE_ID    integer,
                                                        EMP_NAME        string,
                                                        PY_CODE         string,
                                                        WB_CODE         string,
                                                        DEPT_ID         integer,
                                                        DEPT_NAME       string)";
            cmd.ExecuteNonQuery( );
        }

        private static void Create_BASE_MZFP_ITEM( System.Data.OleDb.OleDbCommand cmd )
        {
            cmd.CommandText = @"create table BASE_MZFP_ITEM(CODE    string,
                                                         NAME    string)";
            cmd.ExecuteNonQuery( );
        }

        private static void Create_BASE_PATIENTTYPE( System.Data.OleDb.OleDbCommand cmd )
        {
            cmd.CommandText = @"create table BASE_PATIENTTYPE(CODE    string,
                                                         NAME    string)";
            cmd.ExecuteNonQuery( );
        }

        private static void Create_BASE_PATIENTTYPE_COST( System.Data.OleDb.OleDbCommand cmd )
        {
            cmd.CommandText = @"CREATE TABLE BASE_PATIENTTYPE_COST
                                 (PATTYPECODE      string,
                                  NAME             string,
                                  FAVORABLE_SCALE  DOUBLE                    DEFAULT 1,
                                  FAVORABLE_TYPE   INTEGER                  DEFAULT 0,
                                  MZ_FLAG          INTEGER                  DEFAULT 1,
                                  ZY_FLAG          INTEGER                  DEFAULT 1,
                                  MEDSAFECODE      STRING,
                                  DEL_FLAG         INTEGER                  DEFAULT 0
                                 )";
            cmd.ExecuteNonQuery( );
        }

        private static void Create_BASE_ITEM_FAVORABLE( System.Data.OleDb.OleDbCommand cmd )
        {
            cmd.CommandText = @"CREATE TABLE BASE_ITEM_FAVORABLE
                                     (PATTYPECODE      string,
                                      ITEMCODE         string,
                                      ITEMTYPE_FLAG    integer,
                                      FAVORABLE_SCALE  DOUBLE          NOT NULL  DEFAULT 1
                                     )";
            cmd.ExecuteNonQuery( );
        }

        private static void Create_BASE_ITEMMX_FAVORABLE( System.Data.OleDb.OleDbCommand cmd )
        {
            cmd.CommandText = @"CREATE TABLE BASE_ITEMMX_FAVORABLE
                                 (PATTYPECODE      string,
                                  ITEMID           string,
                                  ITEMTYPE         integer        NOT NULL,
                                  FAVORABLE_SCALE  DOUBLE          NOT NULL  DEFAULT 1
                                 )";
            cmd.ExecuteNonQuery( );
        }

        private static void Create_BASE_STAT_ITEM( System.Data.OleDb.OleDbCommand cmd )
        {
            cmd.CommandText = @"create table BASE_STAT_ITEM(CODE        string,
                                                            ITEM_NAME   string,
                                                            MZFP_NAME   string,
                                                            MZFP_CODE   string)";
            cmd.ExecuteNonQuery( );
        }

        private static void Create_BASE_TEMPLATE_DETAIL( System.Data.OleDb.OleDbCommand cmd )
        {
            cmd.CommandText = @"create table BASE_TEMPLATE_DETAIL(TEMPLATE_ID   integer,
                                                            ITEM_ID      integer,
                                                            COMPLEX_ID   integer,
                                                            ITEM_NAME   string,
                                                            STANDARD    string,
                                                            UNIT        string,
                                                            BIGITEMCODE string,
                                                            AMOUNT       integer)";
            cmd.ExecuteNonQuery( );
        }

        private static void Create_BASE_USER( System.Data.OleDb.OleDbCommand cmd )
        {
            cmd.CommandText = @"create table BASE_USER(employee_id  integer,
                                                            NAME   string,
                                                            USERCODE   string,
                                                            [PASSWORD]   string,
                                                            WORKID integer)";
            cmd.ExecuteNonQuery( );
        }

        private static void Create_BASE_EMPLOYEE_PROPERTY( System.Data.OleDb.OleDbCommand cmd )
        {
            cmd.CommandText = @"CREATE TABLE BASE_EMPLOYEE_PROPERTY(EMPLOYEE_ID integer,
                                                                    NAME string,
                                                                    PY_CODE string,
                                                                    WB_CODE string
                                                                    )";
            cmd.ExecuteNonQuery( );
        }

        private static void Create_BASE_DEPT_PROPERTY( System.Data.OleDb.OleDbCommand cmd )
        {
            cmd.CommandText = @"CREATE TABLE BASE_DEPT_PROPERTY(DEPT_ID integer,
                                                                    NAME string,
                                                                    PY_CODE string,
                                                                    WB_CODE string
                                                                    )";
            cmd.ExecuteNonQuery( );
        }

        private static void Create_BASE_WORK_UNIT( System.Data.OleDb.OleDbCommand cmd )
        {
            cmd.CommandText = @"CREATE TABLE BASE_WORK_UNIT(CODE string,
                                                            NAME string,
                                                            PY_CODE string,
                                                            WB_CODE string
                                                            )";
            cmd.ExecuteNonQuery( );

        }

        private static void Create_VI_MZ_SHOWCARD( System.Data.OleDb.OleDbCommand cmd )
        {
            cmd.CommandText = @"create table VI_MZ_SHOWCARD(    ITEM_ID         integer,
                                                            CODE            string,
                                                            ITEM_NAME       string,
                                                            CHEM_NAME       string,
                                                            PY_CODE         string,
                                                            WB_CODE         string,
                                                            STANDARD        string,
                                                            ITEM_UNIT       string,
                                                            BASE_UNIT       string,
                                                            PRICE           double,
                                                            COMPLEX_ID      integer,
                                                            ADDRESS         string,
                                                            ISDRUG          integer,
                                                            STATITEM_CODE   string,
                                                            HJXS            integer,
                                                            EXEC_DEPT_NAME  string,
                                                            EXEC_DEPT_CODE  string,
                                                            AMOUNT          double,
                                                            NCMS_COMP_RATE  double,
                                                            INSUR_TYPE      string,
                                                            ISTEMPLATE      integer
                                                        )";
            cmd.ExecuteNonQuery( );
        }

        private static void Create_MZ_INVOICE( System.Data.OleDb.OleDbCommand cmd )
        {
            cmd.CommandText = @"create table MZ_INVOICE(    ID integer primary key,
                                                            PERFCHAR string default """+@""",
                                                            EMPLOYEE_ID  integer,
                                                            INVOICE_TYPE integer,
                                                            START_NO   integer,
                                                            END_NO   integer,
                                                            CURRENT_NO   integer,
                                                            STATUS  integer,
                                                            UPLOAD_FLAG integer)";
            cmd.ExecuteNonQuery( );
        }

        private static void Create_MZ_COSTMASTER( System.Data.OleDb.OleDbCommand cmd )
        {
            cmd.CommandText = @"CREATE TABLE MZ_COSTMASTER
                             (COSTMASTERID  integer primary key,
                              PATID         double,
                              PATLISTID     integer,
                              PRESMASTERID  integer,
                              TICKETNUM     string,
                              TICKETCODE    string  default """ + @""",
                              CHARGECODE    string  default """ + @""",
                              CHARGENAME    string  default """ + @""",
                              TOTAL_FEE     double default 0,
                              SELF_FEE      double default 0,
                              VILLAGE_FEE   double default 0,
                              FAVOR_FEE     double default 0,
                              POS_FEE       double default 0,
                              MONEY_FEE     double default 0,
                              TICKET_FLAG   integer,
                              COSTDATE      date,
                              RECORD_FLAG   integer,
                              OLDID         integer default 0,
                              ACCOUNTID     integer default 0,
                              HANG_FLAG     integer default 1,
                              HURRIED_FLAG  integer,
                              SELF_TALLY    double default 0,
                              UPLOAD_FLAG   integer default 0
                             )";

            cmd.ExecuteNonQuery( );
        }

        private static void Create_MZ_COSTORDER( System.Data.OleDb.OleDbCommand cmd )
        {
            cmd.CommandText = @"CREATE TABLE MZ_COSTORDER
                             (COSTORDERID  integer primary key,
                              COSTID       integer,
                              TICKETNUM    string,
                              TICKETCODE   string,
                              ITEMTYPE     string,
                              TOTAL_FEE    double default 0,
                              UPLOAD_FLAG   integer default 0
                             )";
            cmd.ExecuteNonQuery( );
        }

        private static void Create_MZ_PRESMASTER( System.Data.OleDb.OleDbCommand cmd )
        {
            cmd.CommandText = @"CREATE TABLE MZ_PRESMASTER
                                 (PRESMASTERID  integer primary key,
                                  PATID         double default 0,
                                  PATLISTID     integer,
                                  PRESTYPE      string,
                                  PRESDOCCODE   string,
                                  PRESDEPTCODE  string,
                                  EXECDOCCODE   string,
                                  EXECDEPTCODE  string,
                                  PRESCOSTCODE  string,
                                  CHARGECODE    string,
                                  PRESAMOUNT    integer,
                                  TOTAL_FEE     double default 0,
                                  REDEEMCOST    double default 0,
                                  COSTMASTERID  integer default 0,
                                  OLDID         integer default 0,
                                  TICKETNUM     string,
                                  TICKETCODE    string,
                                  RECORD_FLAG   integer,
                                  CHARGE_FLAG   integer default 0,
                                  DRUG_FLAG     integer default 0,
                                  PRESDATE      Date ,
                                  HAND_FLAG     integer default 0,
                                  ROUNGINGMONEY double default 0,
                                  UPLOAD_FLAG   integer default 0
                                )";
            cmd.ExecuteNonQuery( );
        }

        private static void Create_MZ_PRESORDER( System.Data.OleDb.OleDbCommand cmd )
        {
            cmd.CommandText = @"CREATE TABLE MZ_PRESORDER
                                 (PRESORDERID  integer primary key,
                                  PATID        double default 0,
                                  PATLISTID    integer,
                                  PRESMASTERID integer,
                                  ITEMID       integer,
                                  ITEMTYPE     string,
                                  BIGITEMCODE  string,
                                  ITEMNAME     string,
                                  STANDARD     string,
                                  UNIT         string,
                                  RELATIONNUM  double default 0,
                                  BUY_PRICE    double default 0,
                                  SELL_PRICE   double default 0,
                                  AMOUNT       double default 0,
                                  PRESAMOUNT   integer default 0,
                                  TOLAL_FEE    double default 0,
                                  COMP_MONEY   double default 0,
                                  ORDER_FLAG   integer default 0,
                                  PASSID       integer default 0,
                                  CASEID       integer default 0,
                                  UPLOAD_FLAG   integer default 0
                                 )";
            cmd.ExecuteNonQuery( );
        }     

        private static void Create_MZ_PATLIST( System.Data.OleDb.OleDbCommand cmd )
        {
            cmd.CommandText = @"CREATE TABLE MZ_PATLIST
                                 (PATLISTID      integer primary key,
                                  PATID          double,
                                  PATCODE        string,
                                  VISITNO        string,
                                  REGCODE        string,
                                  REGNAME        string,
                                  REG_DEPT_CODE  string,
                                  REG_DOC_CODE   string,
                                  REG_DOC_NAME   string,
                                  REG_DEPT_NAME  string,
                                  PATNAME        string,
                                  PATSEX         string,
                                  AGE            integer,
                                  PYM            string,
                                  WBM            string,
                                  MEDICARD       string,
                                  MEDITYPE       string,
                                  HPCODE         string,
                                  HPGRADE        string,
                                  CUREDEPTCODE   string,
                                  CUREEMPCODE    string,
                                  DISEASECODE    string,
                                  DISEASENAME    string,
                                  CUREDATE       date,
                                  UPLOAD_FLAG    integer
                                 )";
            cmd.ExecuteNonQuery( );
        }

        private static void Create_MZ_ACCOUNT( System.Data.OleDb.OleDbCommand cmd )
        {
            cmd.CommandText = @"CREATE TABLE MZ_ACCOUNT
                             (ACCOUNTID    integer,          
                              LASTDATE     Date,
                              TOTAL_FEE    double default 0,
                              CASH_FEE     double default 0,
                              POS_FEE      double default 0,
                              ACCOUNTCODE  string not null,
                              ACCOUNTDATE  date,
                              BLANKOUT     string default """",
                              UPLOAD_FLAG  integer default 0  )";
            cmd.ExecuteNonQuery( );
        }
        
        #endregion
    }
}
