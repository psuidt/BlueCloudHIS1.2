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
    /// 科室分类
    /// </summary>
    public class DepartmentLayer  : BaseBLL
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
            Model.BASE_DEPT_LAYER model = BindEntity<Model.BASE_DEPT_LAYER>.CreateInstanceDAL( oleDb ).GetModel( LayerID );
            
            if ( model != null )
            {
                SetID( model.LAYER_ID );
                parentLayerId = model.P_LAYER_ID;
                layerName = model.NAME;
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
            return BindEntity<object>.CreateInstanceDAL( oleDb,BLL.Tables.BASE_DEPT_LAYER ).GetList("" );
        }
        /// <summary>
        /// 获得该层次下的所有科室
        /// </summary>
        /// <returns></returns>
        public Department[] GetDepartment()
        {
            
            List<Model.BASE_DEPT_PROPERTY> list = BindEntity<Model.BASE_DEPT_PROPERTY>.CreateInstanceDAL( oleDb ).GetListArray( BLL.Tables.base_dept_property.P_DEPT_ID + oleDb.EuqalTo( ) + LayerID );
            Department[] deptments = new Department[list.Count];
            for ( int i = 0 ; i < list.Count ; i++ )
            {
                deptments[i] = new Department(list[i]);
            }
            return deptments;
        }
        /// <summary>
        /// 增加
        /// </summary>
        /// <returns></returns>
        public bool Add()
        {
            Model.BASE_DEPT_LAYER model = new HIS.Model.BASE_DEPT_LAYER( );
            model.P_LAYER_ID = parentLayerId;
            model.NAME = layerName;
            try
            {
                BindEntity<Model.BASE_DEPT_LAYER>.CreateInstanceDAL( oleDb ).Add( model );
                layerId = model.LAYER_ID;
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            Model.BASE_DEPT_LAYER model = new HIS.Model.BASE_DEPT_LAYER( );
            model.LAYER_ID = layerId;
            model.P_LAYER_ID = parentLayerId;
            model.NAME = layerName;

            try
            {
                BindEntity<Model.BASE_DEPT_LAYER>.CreateInstanceDAL( oleDb ).Update( model );
                return true;
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
            try
            {
                BindEntity<Model.BASE_DEPT_PROPERTY>.CreateInstanceDAL( oleDb ).Update( BLL.Tables.base_dept_property.P_DEPT_ID + oleDb.EuqalTo( ) + layerId , BLL.Tables.base_dept_property.P_DEPT_ID + oleDb.EuqalTo( ) + "0" );
                BindEntity<Model.BASE_DEPT_LAYER>.CreateInstanceDAL( oleDb ).Delete( layerId );
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 名称是否存在
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        public static bool NameExists( DepartmentLayer layer )
        {

            Model.BASE_DEPT_LAYER model = null;
            if ( layer.LayerID > 0 )
                model = BindEntity<Model.BASE_DEPT_LAYER>.CreateInstanceDAL( oleDb ).GetModel( BLL.Tables.base_dept_layer.NAME + oleDb.EuqalTo( ) + "'" + layer.LayerName + "'" + oleDb.And( ) + BLL.Tables.base_dept_layer.LAYER_ID + oleDb.NotEqualTo( ) + layer.LayerID );
            else
                model = BindEntity<Model.BASE_DEPT_LAYER>.CreateInstanceDAL( oleDb ).GetModel( BLL.Tables.base_dept_layer.NAME + oleDb.EuqalTo( ) + "'" + layer.LayerName  + "'");

            return model == null ? false : true;
        }
        /// <summary>
        /// 判断是否有子层
        /// </summary>
        /// <returns></returns>
        public bool HasChild()
        {
            int count = BindEntity<Model.BASE_DEPT_LAYER>.CreateInstanceDAL( oleDb ).GetListArray( BLL.Tables.base_dept_layer.P_LAYER_ID + oleDb.EuqalTo( ) + layerId ).Count;           

            if ( count>0 )
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
           
            int count = BindEntity<Model.BASE_DEPT_PROPERTY>.CreateInstanceDAL( oleDb ).GetListArray( BLL.Tables.base_dept_property.P_DEPT_ID+ oleDb.EuqalTo( ) + layerId ).Count;

            if ( count > 0 )
                return true;
            else
                return false;
        }
        /// <summary>
        /// 获取没有指定分层的科室
        /// </summary>
        /// <returns></returns>
        public Department[] GetNoLayerDepartment()
        {
            List<Model.BASE_DEPT_PROPERTY> list = BindEntity<Model.BASE_DEPT_PROPERTY>.CreateInstanceDAL( oleDb ).GetListArray( BLL.Tables.base_dept_property.P_DEPT_ID + oleDb.EuqalTo() + "0" );
            Department[] deptments = new Department[list.Count];
            for ( int i = 0; i < list.Count; i++ )
            {
                deptments[i] = new Department( list[i] );
            }
            return deptments;
        }
    }
}
