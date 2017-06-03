using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.Base_BLL.Enums;
using HIS.BLL;
using System.Xml;
using System.Collections;

namespace HIS.Base_BLL
{
    /// <summary>
    /// 参数管理器
    /// </summary>
    public class ParameterController : BaseBLL
    {
        private ParameterSet parameterCollection;

        private Hashtable htStandardParameters;

        private DataTable dtAllowEditDocPresItems;

        public DataTable AllowEditDocPresItems
        {
            get
            {
                return dtAllowEditDocPresItems;
            }
            
        }

        
        public ParameterController()
        {
            parameterCollection = new ParameterSet();

            LoadParameterTemplate();

            dtAllowEditDocPresItems = BaseDataReader.Get_PresDoc_EditItem();
        }
        /// <summary>
        /// 参数集合
        /// </summary>
        public ParameterSet ParameterCollect
        {
            get
            {
                return parameterCollection;
            }
            
        }
        /// <summary>
        /// 更新参数
        /// </summary>
        public void UpdateConfig()
        {
            try
            {
                oleDb.BeginTransaction();
                foreach ( object obj in Enum.GetValues( typeof( ParameterCatalog ) ) )
                    _updateConfig( (ParameterCatalog)obj );
                oleDb.CommitTransaction();
            }
            catch ( Exception err )
            {
                oleDb.RollbackTransaction();
                throw err;
            }
        }
        /// <summary>
        /// 更新指定的分类参数
        /// </summary>
        /// <param name="catalog"></param>
        public void UpdateConfig( ParameterCatalog catalog )
        {
            try
            {
                oleDb.BeginTransaction();
                _updateConfig( catalog );
                oleDb.CommitTransaction();
            }
            catch(Exception err)
            {
                oleDb.RollbackTransaction();
                throw err;
            }
        }
        /// <summary>
        /// 初始化所有参数
        /// </summary>
        public void Initialize()
        {
            try
            {
                oleDb.BeginTransaction();

                foreach ( object obj in Enum.GetValues( typeof( ParameterCatalog ) ) )
                    CheckParameters( (ParameterCatalog)obj );

                oleDb.CommitTransaction();
            }
            catch(Exception err)
            {
                oleDb.RollbackTransaction();
                throw err;
            }
        }
        /// <summary>
        /// 初始化指定模块的参数
        /// </summary>
        /// <param name="catalog"></param>
        public void Initialize( ParameterCatalog catalog )
        {
            oleDb.BeginTransaction();
            try
            {
                CheckParameters( catalog );
                oleDb.CommitTransaction();
            }
            catch(Exception err)
            {
                oleDb.RollbackTransaction();
                throw err;
            }
        }
        /// <summary>
        /// 用标准参数对比现有参数并增加没有的参数
        /// </summary>
        /// <param name="catalog"></param>
        private void CheckParameters( ParameterCatalog catalog )
        {
            List<Parameter> lstStdParameter = (List<Parameter>)htStandardParameters[catalog];
            List<Parameter> lstCurParameter = GetCurrentParameterList( catalog );
            if ( catalog != ParameterCatalog.药品管理 )
            {
                DoChecking( catalog, lstStdParameter, lstCurParameter );
            }
            else
            {
                //药房参数需要特殊处理
                //1、比较公共部分
                List<Parameter> lstStdParameter_Common = lstStdParameter.FindAll( delegate( Parameter p )
                {
                    return p.DeptId == 0 ? true : false;
                } );
                DoChecking( catalog, lstStdParameter_Common, lstCurParameter );
                //2、比较各个药剂科
                List<Parameter> lstStdParameter_Speci = lstStdParameter.FindAll( delegate( Parameter p )
                {
                    return p.DeptId == -1 ? true : false; //得到标志模板关于具体科室的参数
                } );
                DataTable dtDrugroom = BaseDataReader.GetDrugRoomList();
                foreach ( DataRow dr in dtDrugroom.Rows )
                {
                    int deptId = Convert.ToInt32( dr["DEPTID"] );
                    List<Parameter> lstDrugRoomParameter = lstCurParameter.FindAll( delegate( Parameter p )
                    {
                        return p.DeptId == deptId ? true : false; //取出每个科室的参数
                    } );
                    DoChecking( catalog, lstStdParameter_Speci, lstDrugRoomParameter, deptId );
                }
            }
        }
        /// <summary>
        /// 用标准参数对比现有参数并增加没有的参数
        /// </summary>
        /// <param name="catalog">分类</param>
        /// <param name="lstStdParameter">标准参数</param>
        /// <param name="lstCurParameter">现有参数</param>
        private void DoChecking( ParameterCatalog catalog, List<Parameter> lstStdParameter, List<Parameter> lstCurParameter )
        {
            foreach ( Parameter stdParameter in lstStdParameter )
            {
                Parameter curParameter = lstCurParameter.Find( delegate( Parameter p )
                {
                    if ( p.Code == stdParameter.Code )
                        return true;
                    else
                        return false;
                } );
                if ( curParameter == null )
                {
                    AddParameter( stdParameter, catalog );
                }
            }
        }
        /// <summary>
        /// 用标准参数对比现有参数并增加没有的参数
        /// </summary>
        /// <param name="catalog">分类</param>
        /// <param name="lstStdParameter">标准参数</param>
        /// <param name="lstCurParameter">现有参数</param>
        /// <param name="DeptId">科室ID</param>
        private void DoChecking( ParameterCatalog catalog, List<Parameter> lstStdParameter, List<Parameter> lstCurParameter,int DeptId )
        {
            foreach ( Parameter stdParameter in lstStdParameter )
            {
                Parameter curParameter = lstCurParameter.Find( delegate( Parameter p )
                {
                    if ( p.Code == stdParameter.Code )
                        return true;
                    else
                        return false;
                } );
                if ( curParameter == null )
                {
                    Parameter newParameter = (Parameter)stdParameter.Clone();
                    newParameter.DeptId = DeptId;
                    AddParameter( newParameter, catalog );
                }
            }
        }
        /// <summary>
        /// 增加参数
        /// </summary>
        private void AddParameter(Parameter p,ParameterCatalog catalog)
        {
            switch ( catalog )
            {
                case ParameterCatalog.门诊经管:
                    BindEntity<Model.MZ_CONFIG>.CreateInstanceDAL(oleDb).Add(new string[] { "code", "name", "value", "bz", "deptid" },
                                                                                    new string[] { p.Code, FormatString(p.Name), FormatString(p.Value.ToString()), FormatString(p.Notes), p.DeptId.ToString() },
                                                                                    new bool[] { true, true, true, true, false });
                    break;
                case ParameterCatalog.住院护士站:
                    BindEntity<Model.ZY_NURSE_CONFIG>.CreateInstanceDAL(oleDb).Add(new string[] { "code", "name", "value", "bz", "deptid" },
                                                                                    new string[] { p.Code, FormatString(p.Name), FormatString(p.Value.ToString()), FormatString(p.Notes), p.DeptId.ToString() },
                                                                                    new bool[] { true, true, true, true, false });
                    break;
                case ParameterCatalog.住院经管:
                    BindEntity<Model.ZY_CONFIG>.CreateInstanceDAL(oleDb, Tables.ZY_CONFIG).Add(new string[] { "code", "name", "value", "bz", "deptid" },
                                                                                    new string[] { p.Code, FormatString(p.Name), FormatString(p.Value.ToString()), FormatString(p.Notes), p.DeptId.ToString() },
                                                                                    new bool[] { true, true, true, true, false });
                    break;
                case ParameterCatalog.住院医生站:
                    BindEntity<Model.ZY_DOC_CONFIG>.CreateInstanceDAL( oleDb ).Add( new string[] { "code", "name", "value", "bz", "deptid" },
                                                                                    new string[] { p.Code, FormatString( p.Name ), FormatString( p.Value.ToString() ), FormatString( p.Notes ),p.DeptId.ToString() },
                                                                                    new bool[] { true, true, true, true, false });
                    break;
                case ParameterCatalog.门诊医生站:
                    BindEntity<Model.MZ_DOC_CONFIG>.CreateInstanceDAL(oleDb).Add(new string[] { "code", "name", "value", "bz", "deptid" },
                                                                                    new string[] { p.Code, FormatString(p.Name), FormatString(p.Value.ToString()), FormatString(p.Notes), p.DeptId.ToString() },
                                                                                    new bool[] { true, true, true, true, false });
                    break;
                case ParameterCatalog.药品管理:
                    BindEntity<Model.YP_CONFIG>.CreateInstanceDAL(oleDb).Add(new string[] { "code", "name", "value", "bz", "deptid" },
                                                                                    new string[] { p.Code, FormatString(p.Name), FormatString(p.Value.ToString()), FormatString(p.Notes), p.DeptId.ToString() },
                                                                                    new bool[] { true, true, true, true, false });
                    break;
            }
        }
        /// <summary>
        /// 更新指定的参数
        /// </summary>
        /// <param name="catalog"></param>
        private void _updateConfig( ParameterCatalog catalog )
        {
            switch ( catalog )
            {
                case ParameterCatalog.门诊经管:
                    UpdateMZJGConfig();
                    break;
                case ParameterCatalog.门诊医生站:
                    UpdateMZYSConfig();
                    break;
                case ParameterCatalog.住院护士站:
                    UpdateZYHSConfig();
                    break;
                case ParameterCatalog.住院经管:
                    UpdateZYJGConfig();
                    break;
                case ParameterCatalog.住院医生站:
                    UpdateZYYSConfig();
                    break;
                case ParameterCatalog.药品管理:
                    UpdateYPGLConfig();
                    break;
            }
        }
        /// <summary>
        /// 更新门诊经管参数
        /// </summary>
        private void UpdateMZJGConfig()
        {
            Parameters ps = parameterCollection[ParameterCatalog.门诊经管];

            foreach ( Parameter p in ps )
            {
                string strWhere = "Code='" + p.Code + "'";
                BindEntity<Model.MZ_CONFIG>.CreateInstanceDAL( oleDb ).Update( strWhere,
                    Tables.mz_config.VALUE + oleDb.EuqalTo() + "'" + FormatString(p.Value.ToString()) + "'",
                    Tables.mz_config.BZ + oleDb.EuqalTo() + "'" + FormatString(p.Notes.Trim()) + "'",
                    Tables.mz_config.NAME + oleDb.EuqalTo() + "'" + FormatString( p.Name.Trim() ) + "'",
                    Tables.mz_config.DEPTID + oleDb.EuqalTo() + p.DeptId.ToString() );
                    
            }
            //保存可修改医生站处方范围
            oleDb.DoCommand( "delete from MZ_DOCPRES_EDITITEM where workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID );
            foreach ( DataRow dr in dtAllowEditDocPresItems.Rows )
            {
                int allowEdit = Convert.ToInt32( dr["Allow_Edit"]);
                if ( allowEdit == 1 )
                {
                    string code = dr["CODE"].ToString().Trim();
                     string sql = "insert into MZ_DOCPRES_EDITITEM values('" + code + "',1," + HIS.SYSTEM.Core.EntityConfig.WorkID + ")";
                    oleDb.DoCommand( sql );
                }
            }
        }
        /// <summary>
        /// 更新住院经管参数
        /// </summary>
        private void UpdateZYJGConfig()
        {
            Parameters ps = parameterCollection[ParameterCatalog.住院经管];

            foreach ( Parameter p in ps )
            {
                string strWhere = "Code='" + p.Code + "'";
                BindEntity<object>.CreateInstanceDAL( oleDb,Tables.ZY_CONFIG ).Update( strWhere,
                    Tables.zy_config.VALUE + oleDb.EuqalTo() + "'" + FormatString(p.Value.ToString()) + "'",
                    Tables.zy_config.BZ + oleDb.EuqalTo() + "'" + FormatString( p.Notes.Trim() ) + "'",
                    Tables.zy_config.NAME + oleDb.EuqalTo() + "'" + FormatString( p.Name.Trim() ) + "'",
                    Tables.zy_config.DEPTID + oleDb.EuqalTo() + p.DeptId.ToString() );

            }
        }
        /// <summary>
        /// 更新门诊医生参数
        /// </summary>
        private void UpdateMZYSConfig()
        {
            Parameters ps = parameterCollection[ParameterCatalog.门诊医生站];

            foreach ( Parameter p in ps )
            {
                string strWhere = "Code='" + p.Code + "'";
                BindEntity<Model.MZ_DOC_CONFIG>.CreateInstanceDAL( oleDb ).Update( strWhere,
                    Tables.mz_config.VALUE + oleDb.EuqalTo() + "'" + FormatString( p.Value.ToString() ) + "'",
                    Tables.mz_config.BZ + oleDb.EuqalTo() + "'" + FormatString( p.Notes.Trim() ) + "'",
                    Tables.mz_config.NAME + oleDb.EuqalTo() + "'" + FormatString( p.Name.Trim() ) + "'" );

            }
        }
        /// <summary>
        /// 更新住院医生参数
        /// </summary>
        private void UpdateZYYSConfig()
        {
            Parameters ps = parameterCollection[ParameterCatalog.住院医生站];
           // 20100517.2.01
            foreach ( Parameter p in ps )
            {
                string strWhere = "Code='" + p.Code + "'";
                BindEntity<Model.ZY_DOC_CONFIG >.CreateInstanceDAL( oleDb).Update( strWhere,
                    Tables.zy_doc_config.VALUE + oleDb.EuqalTo() + "'" + FormatString(p.Value.ToString()) + "'",
                    Tables.zy_doc_config.BZ + oleDb.EuqalTo() + "'" + FormatString( p.Notes.Trim() ) + "'",
                    Tables.zy_doc_config.NAME + oleDb.EuqalTo() + "'" + FormatString( p.Name.Trim() ) + "'",
                    Tables.zy_doc_config.DEPTID + oleDb.EuqalTo() + p.DeptId.ToString() );

            }
        }
        /// <summary>
        /// 更新住院护士参数
        /// </summary>
        private void UpdateZYHSConfig()
        {
            Parameters ps = parameterCollection[ParameterCatalog.住院护士站];

            foreach ( Parameter p in ps )
            {
                string strWhere = "Code='" + p.Code + "'";
                BindEntity<Model.ZY_NURSE_CONFIG>.CreateInstanceDAL(oleDb).Update(strWhere,
                  Tables.zy_doc_config.VALUE + oleDb.EuqalTo() + "'" + FormatString(p.Value.ToString()) + "'",
                  Tables.zy_doc_config.BZ + oleDb.EuqalTo() + "'" + FormatString(p.Notes.Trim()) + "'",
                  Tables.zy_doc_config.NAME + oleDb.EuqalTo() + "'" + FormatString(p.Name.Trim()) + "'",
                  Tables.zy_doc_config.DEPTID + oleDb.EuqalTo() + p.DeptId.ToString());
            }
        }
        /// <summary>
        /// 更新药品参数
        /// </summary>
        private void UpdateYPGLConfig()
        {
            /*药品参数更新必须带DEPTID条件*/
            Parameters ps = parameterCollection[ParameterCatalog.药品管理];
            foreach ( Parameter p in ps )
            {
                string strWhere = "Code='" + p.Code + "' AND DEPTID=" + p.DeptId;
                BindEntity<Model.YP_CONFIG>.CreateInstanceDAL(oleDb).Update(strWhere,
                    Tables.zy_doc_config.VALUE + oleDb.EuqalTo() + "'" + FormatString(p.Value.ToString()) + "'",
                    Tables.zy_doc_config.BZ + oleDb.EuqalTo() + "'" + FormatString(p.Notes.Trim()) + "'",
                    Tables.zy_doc_config.NAME + oleDb.EuqalTo() + "'" + FormatString(p.Name.Trim()) + "'"
                    );
            }
        }
        /// <summary>
        /// 格式化字符串，处理SQL语句中的单引号
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string FormatString( string str )
        {
            string temp = str.Replace( "'", "''" );
            return temp;
        }
        /// <summary>
        /// 加载参数模板
        /// </summary>
        private void LoadParameterTemplate()
        {
            string xmlText = Properties.Resources.Parameters;
            XmlDocument xd = new XmlDocument();
            xd.LoadXml( xmlText );
            htStandardParameters = new Hashtable();
            foreach ( object obj in Enum.GetValues( typeof( ParameterCatalog ) ) )
            {
                ParameterCatalog catalog = (ParameterCatalog)obj;

                XmlNodeList xnl = xd.GetElementsByTagName( catalog.ToString() );
                if ( xnl.Count == 0 )
                    throw new Exception( "Xml file error!" );

                if ( catalog != ParameterCatalog.药品管理 )
                {
                    List<Parameter> lstParameter = GetStandardParameterList( xnl[0] );
                    htStandardParameters.Add( catalog, lstParameter );
                }
                else
                {
                    List<Parameter> lstParameter = new List<Parameter>();
                    
                    foreach ( XmlNode nd in xnl[0].ChildNodes )
                    {
                        List<Parameter> lstTemp = GetStandardParameterList( nd );
                        lstParameter.AddRange( lstTemp );
                    }
                    htStandardParameters.Add( catalog, lstParameter );
                }
            }
        }
        /// <summary>
        /// 从模板获取标准参数列表
        /// </summary>
        /// <param name="xn"></param>
        /// <returns></returns>
        private List<Parameter> GetStandardParameterList( XmlNode xn )
        {
            List<Parameter> lstParameter = new List<Parameter>();

            foreach ( XmlNode nd in xn.ChildNodes )
            {
                Parameter p = new Parameter();
                p.Code = nd.Attributes["code"].Value;
                p.Name = nd.Attributes["name"].Value;
                p.Notes = nd.Attributes["notes"].Value;
                p.DeptId = nd.Attributes["deptid"].Value == "" ? 0 : Convert.ToInt32( nd.Attributes["deptid"].Value );
                p.Value = nd.InnerText;

                lstParameter.Add( p );
            }

            return lstParameter;
        }
        /// <summary>
        /// 从当前数据库读取现有参数
        /// </summary>
        /// <param name="catalog"></param>
        /// <returns></returns>
        private List<Parameter> GetCurrentParameterList( ParameterCatalog catalog )
        {
            List<Parameter> lst = parameterCollection[catalog].ToList();
            return lst;
        }

        
    }
}
