using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;

namespace HIS.Base_BLL
{
    public class RegTypeItemController : BaseBLL
    {
        /// <summary>
        /// 增加一个挂号类型
        /// </summary>
        /// <param name="regtype"></param>
        public void AddNewType( RegTypeItem regtype )
        {
            try
            {
                oleDb.BeginTransaction();
                Model.MZ_REG_TYPE mz_reg_type = null;
                mz_reg_type = BindEntity<Model.MZ_REG_TYPE>.CreateInstanceDAL( oleDb ).GetModel( "TYPE_CODE='" + regtype.TypeCode.Trim() + "'" );
                if ( mz_reg_type == null )
                {
                    mz_reg_type = new HIS.Model.MZ_REG_TYPE();
                    mz_reg_type.TYPE_CODE = regtype.TypeCode;
                    mz_reg_type.TYPE_NAME = regtype.TypeName;
                    mz_reg_type.PY_CODE = regtype.PyCode;
                    mz_reg_type.WB_CODE = regtype.WbCode;
                    mz_reg_type.VALID_FLAG = regtype.ValidFlag;
                    BindEntity<Model.MZ_REG_TYPE>.CreateInstanceDAL( oleDb ).Add( mz_reg_type );

                    foreach ( int itemid in regtype.Items )
                    {
                        Model.MZ_REG_ITEM_FEE mz_reg_item_fee = new HIS.Model.MZ_REG_ITEM_FEE();
                        mz_reg_item_fee.TYPE_CODE = mz_reg_type.TYPE_CODE;
                        mz_reg_item_fee.ITEM_ID = itemid;
                        BindEntity<Model.MZ_REG_ITEM_FEE>.CreateInstanceDAL( oleDb ).Add( mz_reg_item_fee );
                    }
                }
                else
                {
                    throw new Exception( "类型代码重复！" );
                }
                oleDb.CommitTransaction();
            }
            catch ( Exception err )
            {
                oleDb.RollbackTransaction();
                throw new Exception( "保存失败!\r\n" + err.Message );
            }
        }
        /// <summary>
        /// 保存挂号类型
        /// </summary>
        /// <param name="regtype"></param>
        public void SaveRegType( RegTypeItem regtype )
        {
            try
            {
                oleDb.BeginTransaction();
                Model.MZ_REG_TYPE mz_reg_type = new HIS.Model.MZ_REG_TYPE();
                mz_reg_type.TYPE_CODE = regtype.TypeCode;
                mz_reg_type.TYPE_NAME = regtype.TypeName;
                mz_reg_type.PY_CODE = regtype.PyCode;
                mz_reg_type.WB_CODE = regtype.WbCode;
                mz_reg_type.VALID_FLAG = regtype.ValidFlag;

                BindEntity<Model.MZ_REG_TYPE>.CreateInstanceDAL( oleDb ).Update( "TYPE_CODE='" + mz_reg_type.TYPE_CODE + "'",
                    BLL.Tables.mz_reg_type.TYPE_NAME + oleDb.EuqalTo() + "'" + mz_reg_type.TYPE_NAME + "'",
                    BLL.Tables.mz_reg_type.PY_CODE + oleDb.EuqalTo() + "'" + mz_reg_type.PY_CODE + "'",
                    BLL.Tables.mz_reg_type.WB_CODE + oleDb.EuqalTo() + "'" + mz_reg_type.WB_CODE + "'",
                    BLL.Tables.mz_reg_type.VALID_FLAG + oleDb.EuqalTo() + mz_reg_type.VALID_FLAG
                    );

                BindEntity<Model.MZ_REG_ITEM_FEE>.CreateInstanceDAL( oleDb ).Delete( "TYPE_CODE='" + mz_reg_type.TYPE_CODE + "'" );

                foreach ( int itemid in regtype.Items )
                {
                    Model.MZ_REG_ITEM_FEE mz_reg_item_fee = new HIS.Model.MZ_REG_ITEM_FEE();
                    mz_reg_item_fee.TYPE_CODE = mz_reg_type.TYPE_CODE;
                    mz_reg_item_fee.ITEM_ID = itemid;
                    BindEntity<Model.MZ_REG_ITEM_FEE>.CreateInstanceDAL( oleDb ).Add( mz_reg_item_fee );
                }
                oleDb.CommitTransaction();
            }
            catch
            {
                oleDb.RollbackTransaction();
                throw new Exception( "保存失败" );
            }
        }
    }
}
