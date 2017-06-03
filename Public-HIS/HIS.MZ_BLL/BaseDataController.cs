using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
using System.Data;
using HIS.MZ_BLL.Exceptions;
using HIS.BLL;
using HIS.Model;
using System.Collections;
namespace HIS.MZ_BLL
{
    public class BaseDataController : BaseBLL
    {
        private static BaseDataSet baseDataset;
        /// <summary>
        /// 基础数据集
        /// </summary>
        public static BaseDataSet BaseDataSet
        {
            get
            {
                if ( baseDataset == null )
                {
                    baseDataset = new BaseDataSet();
                }
                return baseDataset;
            }
        }
        /// <summary>
        /// 在指定的数据集中根据标识符查找名称
        /// </summary>
        /// <param name="catalog">数据集目录</param>
        /// <param name="identifier">标识符</param>
        /// <returns></returns>
        public static string GetName( BaseDataCatalog catalog, object identifier )
        {
            string idColumn = "";
            string nameColumn = "";
            switch ( catalog )
            {
                case BaseDataCatalog.人员列表:
                    idColumn = "Employee_Id";
                    nameColumn = "Name";
                    break;
                case BaseDataCatalog.科室列表:
                    idColumn = "Dept_Id";
                    nameColumn = "Name";
                    break;
                case BaseDataCatalog.基本分类科目:
                case BaseDataCatalog.门诊发票科目:
                case BaseDataCatalog.经管核算科目:
                    idColumn = "CODE";
                    nameColumn = "ITEM_NAME";
                    break;
                case BaseDataCatalog.病人类型列表:
                    idColumn = "PATTYPECODE";
                    nameColumn = "NAME";
                    break;
                case BaseDataCatalog.疾病诊断列表:
                    idColumn = "CODING";
                    nameColumn = "NAME";
                    break;
                case BaseDataCatalog.医生列表:
                    idColumn = "Employee_Id";
                    nameColumn = "Emp_Name";
                    break;
                case BaseDataCatalog.医生类别列表:
                    idColumn = "type_id";
                    nameColumn = "type_name";
                    break;
                default:
                    throw new NotImplementedException( catalog.ToString() + "获取名称的方法还未实现" );
            }

            string selectString = "";
            string quotChar = "";
            if ( identifier is string )
                quotChar = "'";
            selectString = idColumn + " = " + quotChar + identifier.ToString() + quotChar;

            DataRow[] drs = BaseDataSet[catalog].Select( selectString );
            if ( drs.Length == 0 )
                return "";
            else
                return drs[0][nameColumn].ToString().Trim();
            
        }
        /// <summary>
        /// 刷新所有数据
        /// </summary>
        public static void Reload()
        {
            foreach ( object obj in Enum.GetValues( typeof( BaseDataCatalog ) ) )
                baseDataset.Reload( (BaseDataCatalog)obj );
        }
        /// <summary>
        /// 刷新指定的数据
        /// </summary>
        /// <param name="catalog"></param>
        public static void Reload( BaseDataCatalog catalog )
        {
            baseDataset.Reload( catalog );
        }
    }
}
