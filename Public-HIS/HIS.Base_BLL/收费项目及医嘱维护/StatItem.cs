using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS;
using HIS.SYSTEM.Core;
namespace HIS.Base_BLL
{
    public class StatItem : BaseBLL
    {
        /// <summary>
        /// 基本统计分类对象,可扩展出不同的统计分类
        /// </summary>
        private HIS.Model.BASE_STAT_ITEM dbFields;
        
        /// <summary>
        /// 构造函数
        /// </summary>
        public StatItem() 
        { 
            dbFields = new HIS.Model.BASE_STAT_ITEM( );
        }
        /// <summary>
        /// 构造函数重载
        /// </summary>
        /// <param name="Code">基本分类代码</param>
        public StatItem( string Code )
        {
            dbFields = BindEntity<Model.BASE_STAT_ITEM>.CreateInstanceDAL(oleDb).GetModel( BLL.Tables.base_stat_item.CODE + oleDb.EuqalTo() + "'"+ Code + "'" );    
        }
        /// <summary>
        /// 字段属性
        /// </summary>
        public HIS.Model.BASE_STAT_ITEM DBFields
        {
            get
            {
                return dbFields;
            }
            set
            {
                dbFields = value;
            }
        }
        /// <summary>
        /// 新增 
        /// </summary>
        /// <returns></returns>
        public bool Add()
        {
            
            try
            {
                //2010-03-24 增加了保存前代码重复性验证 by-wangzhi
                if ( !BindEntity<Model.BASE_STAT_ITEM>.CreateInstanceDAL( oleDb ).Exists( "CODE='" + dbFields.CODE + "'" ) )
                {
                    BindEntity<Model.BASE_STAT_ITEM>.CreateInstanceDAL( oleDb ).Add( dbFields );
                    return true;
                }

                else
                {
                    throw new Exception( "代码【" + dbFields.CODE + "】已经存在" );
                }

                
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
            
            try
            {

                BindEntity<Model.BASE_STAT_ITEM>.CreateInstanceDAL( oleDb ).Update( HIS.BLL.Tables.base_stat_item.CODE + oleDb.EuqalTo() + "'" + dbFields.CODE + "'", 
                    HIS.BLL.Tables.base_stat_item.BA_CODE + "='" + dbFields.BA_CODE + "'",
                    HIS.BLL.Tables.base_stat_item.CFLX_CODE + "='" + dbFields.CFLX_CODE + "'",
                    HIS.BLL.Tables.base_stat_item.HS_CODE + "='" + dbFields.HS_CODE + "'",
                    HIS.BLL.Tables.base_stat_item.ITEM_NAME + "='" + dbFields.ITEM_NAME + "'",
                    HIS.BLL.Tables.base_stat_item.ITEM_TYPE + "=" + dbFields.ITEM_TYPE + "",
                    HIS.BLL.Tables.base_stat_item.MZFP_CODE + "='" + dbFields.MZFP_CODE + "'",
                    HIS.BLL.Tables.base_stat_item.MZKJ_CODE + "='" + dbFields.MZKJ_CODE + "'",
                    HIS.BLL.Tables.base_stat_item.MZYB_CODE + "='" + dbFields.MZYB_CODE + "'",
                    HIS.BLL.Tables.base_stat_item.PY_CODE + "='" + dbFields.PY_CODE + "'",
                    HIS.BLL.Tables.base_stat_item.WB_CODE + "='" + dbFields.WB_CODE + "'",
                    HIS.BLL.Tables.base_stat_item.ZYFP_CODE + "='" + dbFields.ZYFP_CODE + "'",
                    HIS.BLL.Tables.base_stat_item.ZYKJ_CODE + "='" + dbFields.ZYKJ_CODE + "'",
                    HIS.BLL.Tables.base_stat_item.ZYYB_CODE + "='" + dbFields.ZYYB_CODE + "'" );
                return true;
            }
            catch ( Exception err )
            {
                throw err;
            }
           
        }
    } 
}
