using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GWMHIS.BussinessLogicLayer;
using GWMHIS.BussinessLogicLayer.Classes;
using GWMHIS.PubicBaseClasses;
namespace HIS_BaseManager
{
    public class DepartmentLayer 
    {
        private int layerId;
        private int parentLayerId;
        private string layerName;
        /// <summary>
        /// 科室编号
        /// </summary>
        public int LayerID
        {
            get
            {
                return layerId;
            }
        }
        /// <summary>
        /// 父级科室
        /// </summary>
        public int ParentLayerId
        {
            get
            {
                return parentLayerId;
            }
            set
            {
                parentLayerId = value;
            }
        }
        /// <summary>
        /// 科室名称
        /// </summary>
        public string LayerName
        {
            get
            {
                return layerName;
            }
            set
            {
                layerName = value;
            }
        }
        /// <summary>
        /// 强制注入ID
        /// </summary>
        /// <param name="ID"></param>
        public void SetID( int ID )
        {
            layerId = ID;
        }
        public DepartmentLayer()
        {
            layerId = 0;
            parentLayerId = 0;
            layerName = "";
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="LayerID"></param>
        public DepartmentLayer(int LayerID)
        {
            string sql = "SELECT * FROM BASE_DEPT_LAYER WHERE LAYER_ID=" + LayerID;
            DataTable tb = HIS.Base_BLL.BaseDataReader.GetDataTable( sql );
            if ( tb.Rows.Count > 0 )
            {
                DataRow dr = tb.Rows[0];
                if ( dr != null )
                {
                    SetID( Convert.ToInt32( dr["LAYER_ID"] ) );
                    parentLayerId = Convert.ToInt32( dr["P_LAYER_ID"] );
                    layerName = dr["NAME"].ToString( ).Trim( );
                }
            }
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="drData"></param>
        public DepartmentLayer( DataRow drData )
        {
            if ( drData != null )
            {
                SetID ( Convert.ToInt32( drData["LAYER_ID"] ));
                parentLayerId = Convert.ToInt32( drData["P_LAYER_ID"] );
                layerName = drData["NAME"].ToString( ).Trim( );
            }
        }
        /// <summary>
        /// 获取所有科室层次
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllLayer()
        {
            string sql = "SELECT * FROM BASE_DEPT_LAYER";
            return DatabaseAccess.GetDataTable( DatabaseType.IbmDb2 , sql );
        }
        /// <summary>
        /// 获得该层次下的所有科室
        /// </summary>
        /// <returns></returns>
        public Deptment[] GetDepartment()
        {
            string sql = "SELECT DEPT_ID FROM BASE_DEPT_PROPERTY WHERE P_DEPT_ID = " + LayerID;
            DataTable tbDepartments = DatabaseAccess.GetDataTable( DatabaseType.IbmDb2, sql );
            Deptment[] deptments = new Deptment[tbDepartments.Rows.Count];
            for ( int i = 0 ; i < tbDepartments.Rows.Count ; i++ )
            {
                int deptId = Convert.ToInt32( tbDepartments.Rows[i]["DEPT_ID"] );
                deptments[i] = new Deptment( deptId );
            }
            return deptments;
        }
        /// <summary>
        /// 增加
        /// </summary>
        /// <returns></returns>
        public bool Add()
        {
            StringBuilder sb = new StringBuilder( );
            sb.Append( "INSERT INTO BASE_DEPT_LAYER(P_LAYER_ID,NAME) VALUES (" );
            sb.Append( parentLayerId.ToString() + "," );
            sb.Append( "'" + layerName.ToString() + "'" );
            sb.Append( ")" );

            try
            {
                DatabaseAccess.DoCommand( DatabaseType.IbmDb2 , sb.ToString( ) );
                DataRow dr = DatabaseAccess.GetDataRow( DatabaseType.IbmDb2 , "SELECT LAYER_ID FROM BASE_DEPT_LAYER WHERE NAME='" + layerName + "'" );
                if ( dr != null )
                {
                    layerId = Convert.ToInt32( dr["LAYER_ID"] );
                }
                else
                    throw new Exception( "保存成功，但没有读取到标识，需要重新刷新" );
                return true;
            }
            catch(Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            StringBuilder sb = new StringBuilder( );
            sb.Append( "UPDATE BASE_DEPT_LAYER SET" );
            sb.Append( " P_LAYER_ID=" + parentLayerId + "," );
            sb.Append( " NAME = '" + layerName + "' " );
            sb.Append( " WHERE LAYER_ID = " + layerId );

            try
            {
                int ret = DatabaseAccess.DoCommand( DatabaseType.IbmDb2 , sb.ToString( ) );
                if ( ret > 0 )
                    return true;
                else
                    throw new Exception( "没有更新到数据" );
            }
            catch ( Exception err )
            {
                throw err;
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            string[] sqls = new string[2];

            sqls[0] = "DELETE FROM BASE_DEPT_LAYER WHERE LAYER_ID=" + layerId;
            sqls[1] = "UPDATE BASE_DEPT_PROPERTY SET P_DEPT_ID = 0 WHERE P_DEPT_ID=" +layerId ;
            try
            {
                DatabaseAccess.DoCommand( DatabaseType.IbmDb2 ,null,null,null,sqls);
                return true;
            }
            catch ( Exception err )
            {
                throw err;
            }
            
        }
        /// <summary>
        /// 名称是否存在
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        public static bool NameExists( DepartmentLayer layer )
        {
            string sql = "SELECT * FROM BASE_DEPT_LAYER WHERE NAME = '" + layer + "'";
            if ( layer.LayerID > 0 )
                sql = sql + " AND LAYER_ID<>" + layer.LayerID;
            DataRow dr = DatabaseAccess.GetDataRow( DatabaseType.IbmDb2 , sql );
            if ( dr == null )
                return false;
            else
                return true;
        }
        /// <summary>
        /// 判断是否有子层
        /// </summary>
        /// <returns></returns>
        public bool HasChild()
        {
            string sql = "SELECT * FROM BASE_DEPT_LAYER WHERE P_LAYER_ID=" + layerId;
            DataTable tb = DatabaseAccess.GetDataTable( DatabaseType.IbmDb2 , sql );
            if ( tb.Rows.Count > 0 )
                return true;
            else
                return false;
        }
        /// <summary>
        /// 判断是否有科室
        /// </summary>
        /// <returns></returns>
        public bool HasDepartments()
        {
            string sql = "SELECT * FROM BASE_DEPT_PROPERTY WHERE P_DEPT_ID = " + layerId;
            DataTable tb = DatabaseAccess.GetDataTable( DatabaseType.IbmDb2 , sql );
            if ( tb.Rows.Count > 0 )
                return true;
            else
                return false;
        }
    }
}
