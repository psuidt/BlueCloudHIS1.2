using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS;
using HIS.SYSTEM.Core;

namespace HIS.Base_BLL
{
    /// <summary>
    /// 扩展的统计分类名称枚举
    /// </summary>
    public enum SubStatItemName
    {
        门诊发票项目,

        住院发票项目,

        门诊会计项目,

        住院会计项目,
         
        门诊医保项目,
         
        住院医保项目,

        经管核算项目,

        病案统计项目
                   
    }
    /// <summary>
    /// 统计子类
    /// </summary>
    public class SubStatItem : BaseBLL
    {
        private string code;
        private string name;
        private int valid;
        private SubStatItemName subitemName;
        private string tbName = "";
        private object model;

        public SubStatItem( string Code , string ItemName , int Valid_Flag,SubStatItemName SubitemName )
        {
            code = Code;
            name = ItemName;
            valid = Valid_Flag;
            subitemName = SubitemName;

            
            switch ( subitemName )
            {
                case SubStatItemName.病案统计项目:
                    tbName = "base_stat_ba";
                    model = new Model.BASE_STAT_BA( );
                    ( (Model.BASE_STAT_BA)model ).CODE = code;
                    ( (Model.BASE_STAT_BA)model ).ITEM_NAME = name ;
                    ( (Model.BASE_STAT_BA)model ).VALID_FLAG = valid ;
                    break;
                case SubStatItemName.经管核算项目:
                    tbName = "base_stat_hs";
                    model = new Model.BASE_STAT_HS( );
                    ( (Model.BASE_STAT_HS)model ).CODE = code;
                    ( (Model.BASE_STAT_HS)model ).ITEM_NAME = name;
                    ( (Model.BASE_STAT_HS)model ).VALID_FLAG = valid;
                    break;
                case SubStatItemName.门诊发票项目:
                    tbName = "base_stat_mzfp";
                    model = new Model.BASE_STAT_MZFP( );
                    ( (Model.BASE_STAT_MZFP)model ).CODE = code;
                    ( (Model.BASE_STAT_MZFP)model ).ITEM_NAME = name;
                    ( (Model.BASE_STAT_MZFP)model ).VALID_FLAG = valid;
                    break;
                case SubStatItemName.门诊会计项目:
                    tbName = "base_stat_mzkj";
                    model = new Model.BASE_STAT_MZKJ( );
                    ( (Model.BASE_STAT_MZKJ)model ).CODE = code;
                    ( (Model.BASE_STAT_MZKJ)model ).ITEM_NAME = name;
                    ( (Model.BASE_STAT_MZKJ)model ).VALID_FLAG = valid;
                    break;
                case SubStatItemName.门诊医保项目:
                    tbName = "base_stat_mzyb";
                    model = new Model.BASE_STAT_MZYB( );
                    ( (Model.BASE_STAT_MZYB)model ).CODE = code;
                    ( (Model.BASE_STAT_MZYB)model ).ITEM_NAME = name;
                    ( (Model.BASE_STAT_MZYB)model ).VALID_FLAG = valid;
                    break;
                case SubStatItemName.住院发票项目:
                    tbName = "base_stat_zyfp";
                    model = new Model.BASE_STAT_ZYFP( );
                    ( (Model.BASE_STAT_ZYFP)model ).CODE = code;
                    ( (Model.BASE_STAT_ZYFP)model ).ITEM_NAME = name;
                    ( (Model.BASE_STAT_ZYFP)model ).VALID_FLAG = valid;
                    break;
                case SubStatItemName.住院会计项目:
                    tbName = "base_stat_zykj";
                    model = new Model.BASE_STAT_ZYKJ( );
                    ( (Model.BASE_STAT_ZYKJ)model ).CODE = code;
                    ( (Model.BASE_STAT_ZYKJ)model ).ITEM_NAME = name;
                    ( (Model.BASE_STAT_ZYKJ)model ).VALID_FLAG = valid;
                    break;
                case SubStatItemName.住院医保项目:
                    tbName = "base_stat_zyyb";
                    model = new Model.BASE_STAT_ZYYB( );
                    ( (Model.BASE_STAT_ZYYB)model ).CODE = code;
                    ( (Model.BASE_STAT_ZYYB)model ).ITEM_NAME = name;
                    ( (Model.BASE_STAT_ZYYB)model ).VALID_FLAG = valid;
                    break;
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
            
            switch ( subitemName )
            {
                case SubStatItemName.病案统计项目:
                    if ( !Exists( ) )
                        BindEntity<Model.BASE_STAT_BA>.CreateInstanceDAL( oleDb ).Add( (Model.BASE_STAT_BA)model );
                    else
                        BindEntity<Model.BASE_STAT_BA>.CreateInstanceDAL( oleDb ).Update( HIS.BLL.Tables.base_stat_ba.CODE + "='" + ((Model.BASE_STAT_BA)model).CODE + " '",
                                                                                           HIS.BLL.Tables.base_stat_ba.ITEM_NAME + "='" + ( (Model.BASE_STAT_BA)model ).ITEM_NAME + "'",
                                                                                           HIS.BLL.Tables.base_stat_ba.VALID_FLAG + "=" + ( (Model.BASE_STAT_BA)model ).VALID_FLAG + "" );
                    break;
                case SubStatItemName.经管核算项目:
                    if ( !Exists( ) )
                        BindEntity<Model.BASE_STAT_HS>.CreateInstanceDAL( oleDb ).Add( (Model.BASE_STAT_HS)model );
                    else
                        BindEntity<Model.BASE_STAT_HS>.CreateInstanceDAL( oleDb ).Update( HIS.BLL.Tables.base_stat_hs.CODE + "='" + ( (Model.BASE_STAT_HS)model ).CODE + " '",
                                                                                           HIS.BLL.Tables.base_stat_hs.ITEM_NAME + "='" + ( (Model.BASE_STAT_HS)model ).ITEM_NAME + "'",
                                                                                           HIS.BLL.Tables.base_stat_hs.VALID_FLAG + "=" + ( (Model.BASE_STAT_HS)model ).VALID_FLAG + "" );
                    break;
                case SubStatItemName.门诊发票项目:
                    if ( !Exists( ) )
                        BindEntity<Model.BASE_STAT_MZFP>.CreateInstanceDAL( oleDb ).Add( (Model.BASE_STAT_MZFP)model );
                    else
                        BindEntity<Model.BASE_STAT_MZFP>.CreateInstanceDAL( oleDb ).Update( HIS.BLL.Tables.base_stat_mzfp.CODE + "='" + ( (Model.BASE_STAT_MZFP)model ).CODE + " '",
                                                                                           HIS.BLL.Tables.base_stat_mzfp.ITEM_NAME + "='" + ( (Model.BASE_STAT_MZFP)model ).ITEM_NAME + "'",
                                                                                           HIS.BLL.Tables.base_stat_mzfp.VALID_FLAG + "=" + ( (Model.BASE_STAT_MZFP)model ).VALID_FLAG + "" );
                    break;
                case SubStatItemName.门诊会计项目:
                    if ( !Exists( ) )
                        BindEntity<Model.BASE_STAT_MZKJ>.CreateInstanceDAL( oleDb ).Add( (Model.BASE_STAT_MZKJ)model );
                    else
                        BindEntity<Model.BASE_STAT_MZKJ>.CreateInstanceDAL( oleDb ).Update( HIS.BLL.Tables.base_stat_mzkj.CODE + "='" + ( (Model.BASE_STAT_MZKJ)model ).CODE + " '",
                                                                                           HIS.BLL.Tables.base_stat_mzkj.ITEM_NAME + "='" + ( (Model.BASE_STAT_MZKJ)model ).ITEM_NAME + "'",
                                                                                           HIS.BLL.Tables.base_stat_mzkj.VALID_FLAG + "=" + ( (Model.BASE_STAT_MZKJ)model ).VALID_FLAG + "" );
                    break;
                case SubStatItemName.门诊医保项目:
                    if ( !Exists( ) )
                        BindEntity<Model.BASE_STAT_MZYB>.CreateInstanceDAL( oleDb ).Add( (Model.BASE_STAT_MZYB)model );
                    else
                        BindEntity<Model.BASE_STAT_MZYB>.CreateInstanceDAL( oleDb ).Update( HIS.BLL.Tables.base_stat_mzyb.CODE + "='" + ( (Model.BASE_STAT_MZYB)model ).CODE + " '",
                                                                                           HIS.BLL.Tables.base_stat_mzyb.ITEM_NAME + "='" + ( (Model.BASE_STAT_MZYB)model ).ITEM_NAME + "'",
                                                                                           HIS.BLL.Tables.base_stat_mzyb.VALID_FLAG + "=" + ( (Model.BASE_STAT_MZYB)model ).VALID_FLAG + "" );
                    break;
                case SubStatItemName.住院发票项目:
                    if ( !Exists( ) )
                        BindEntity<Model.BASE_STAT_ZYFP>.CreateInstanceDAL( oleDb ).Add( (Model.BASE_STAT_ZYFP)model );
                    else
                        BindEntity<Model.BASE_STAT_ZYFP>.CreateInstanceDAL( oleDb ).Update( HIS.BLL.Tables.base_stat_zyfp.CODE + "='" + ( (Model.BASE_STAT_ZYFP)model ).CODE + " '",
                                                                                           HIS.BLL.Tables.base_stat_zyfp.ITEM_NAME + "='" + ( (Model.BASE_STAT_ZYFP)model ).ITEM_NAME + "'",
                                                                                           HIS.BLL.Tables.base_stat_zyfp.VALID_FLAG + "=" + ( (Model.BASE_STAT_ZYFP)model ).VALID_FLAG + "" );
                    break;
                case SubStatItemName.住院会计项目:
                    if ( !Exists( ) )
                        BindEntity<Model.BASE_STAT_ZYKJ>.CreateInstanceDAL( oleDb ).Add( (Model.BASE_STAT_ZYKJ)model );
                    else
                        BindEntity<Model.BASE_STAT_ZYKJ>.CreateInstanceDAL( oleDb ).Update( HIS.BLL.Tables.base_stat_zykj.CODE + "='" + ( (Model.BASE_STAT_ZYKJ)model ).CODE + " '",
                                                                                           HIS.BLL.Tables.base_stat_zykj.ITEM_NAME + "='" + ( (Model.BASE_STAT_ZYKJ)model ).ITEM_NAME + "'",
                                                                                           HIS.BLL.Tables.base_stat_zykj.VALID_FLAG + "=" + ( (Model.BASE_STAT_ZYKJ)model ).VALID_FLAG + "" );
                    break;
                case SubStatItemName.住院医保项目:
                    if ( !Exists( ) )
                        BindEntity<Model.BASE_STAT_ZYYB>.CreateInstanceDAL( oleDb ).Add( (Model.BASE_STAT_ZYYB)model );
                    else
                        BindEntity<Model.BASE_STAT_ZYYB>.CreateInstanceDAL( oleDb ).Update( HIS.BLL.Tables.base_stat_zyyb.CODE + "='" + ( (Model.BASE_STAT_ZYYB)model ).CODE + " '",
                                                                                           HIS.BLL.Tables.base_stat_zyyb.ITEM_NAME + "='" + ( (Model.BASE_STAT_ZYYB)model ).ITEM_NAME + "'",
                                                                                           HIS.BLL.Tables.base_stat_zyyb.VALID_FLAG + "=" + ( (Model.BASE_STAT_ZYYB)model ).VALID_FLAG + "" );
                    break;
            }
        }
         /// <summary>
         /// 判断是否有效
         /// </summary>
         /// <returns></returns>
        private bool Exists()
        {
            object obj = null;
            switch ( subitemName )
            {
                case SubStatItemName.病案统计项目:
                    obj = BindEntity<Model.BASE_STAT_BA>.CreateInstanceDAL( oleDb ).GetModel( BLL.Tables.base_stat_ba.CODE + oleDb.EuqalTo() + "'" + code + "'" );
                    break;
                case SubStatItemName.经管核算项目:
                    obj = BindEntity<Model.BASE_STAT_HS>.CreateInstanceDAL( oleDb ).GetModel( BLL.Tables.base_stat_hs.CODE + oleDb.EuqalTo() + "'" + code + "'" );
                    break;
                case SubStatItemName.门诊发票项目:
                    obj = BindEntity<Model.BASE_STAT_MZFP>.CreateInstanceDAL( oleDb ).GetModel( BLL.Tables.base_stat_mzfp.CODE + oleDb.EuqalTo() + "'" + code + "'" );
                    break;
                case SubStatItemName.门诊会计项目:
                    obj = BindEntity<Model.BASE_STAT_MZKJ>.CreateInstanceDAL( oleDb ).GetModel( BLL.Tables.base_stat_mzkj.CODE + oleDb.EuqalTo() + "'" + code + "'" );
                    break;
                case SubStatItemName.门诊医保项目:
                    obj = BindEntity<Model.BASE_STAT_MZYB>.CreateInstanceDAL( oleDb ).GetModel( BLL.Tables.base_stat_mzyb.CODE + oleDb.EuqalTo() + "'" + code + "'" );
                    break;
                case SubStatItemName.住院发票项目:
                    obj = BindEntity<Model.BASE_STAT_ZYFP>.CreateInstanceDAL( oleDb ).GetModel( BLL.Tables.base_stat_zyfp.CODE + oleDb.EuqalTo() + "'" + code + "'" );
                    break;
                case SubStatItemName.住院会计项目:
                    obj = BindEntity<Model.BASE_STAT_ZYKJ>.CreateInstanceDAL( oleDb ).GetModel( BLL.Tables.base_stat_zykj.CODE + oleDb.EuqalTo() + "'" + code + "'" );
                    break;
                case SubStatItemName.住院医保项目:
                    obj = BindEntity<Model.BASE_STAT_ZYYB>.CreateInstanceDAL( oleDb ).GetModel( BLL.Tables.base_stat_zyyb.CODE + oleDb.EuqalTo() + "'" + code + "'" );
                    break;
            }
            return obj == null ? false : true;
        }
    }
}
