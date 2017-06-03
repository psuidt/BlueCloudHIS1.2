using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.DAL;

namespace HIS.MZ_BLL
{
    /// <summary>
    /// 基础数据集,所有的基础数据全部通过枚举值返回相应的数据
    /// </summary>
    public class BaseDataSet : HIS.SYSTEM.Core.BaseBLL
    {
        private DataSet _dataSet;
        private MZ_DAL _dal;

        public BaseDataSet()
        {
            _dal = new MZ_DAL();
            _dal._OleDB = oleDb;
        }

        public DataTable this[BaseDataCatalog catalog]
        {
            get
            {
                if ( _dataSet == null )
                {
                    _dataSet = new DataSet();
                }
                if ( !_dataSet.Tables.Contains( catalog.ToString() ) )
                {
                    DataTable dtData = LoadBaseData( catalog );
                    dtData.TableName = catalog.ToString();
                    _dataSet.Tables.Add( dtData );
                }
                //返回副本，防止因引用而被修改
                return _dataSet.Tables[catalog.ToString()].Copy();
            }
        }
        /// <summary>
        /// 读取指定的基础数据并为数据表指定名称
        /// </summary>
        /// <param name="catalog"></param>
        /// <returns></returns>
        private DataTable LoadBaseData(BaseDataCatalog catalog)
        {
            
            switch ( catalog )
            {
                case BaseDataCatalog.人员列表:
                    return _dal.GetEmployeeList();
                case BaseDataCatalog.科室列表:
                    return _dal.GetDepartmentList();
                case BaseDataCatalog.基本分类与各分类对应表:
                    return _dal.GetBaseStatClassAndAllStatClassRelation();
                case BaseDataCatalog.基本分类科目:
                    return _dal.GetBaseStatItemList();
                case BaseDataCatalog.门诊发票科目:
                    return _dal.GetMzfpItemList();
                case BaseDataCatalog.经管核算科目:
                    return _dal.GetHsItemList();
                case BaseDataCatalog.病人类型列表:
                    return _dal.GetPatientType();
                case BaseDataCatalog.疾病诊断列表:
                    return _dal.GetDiseaseList();
                case BaseDataCatalog.医生列表:
                    return _dal.GetDoctorDetailList();
                case BaseDataCatalog.名族列表:
                    return _dal.GetFolkList();
                case BaseDataCatalog.医生类别列表:
                    return _dal.GetDoctorTypeList();
                case BaseDataCatalog.挂号类型定义列表:
                    return _dal.GetRegisterTypeList();
                case BaseDataCatalog.挂号类型与收费项目对应表:
                    return _dal.GetRegisterTypeAndServiceItemRelation();
                case BaseDataCatalog.划价模板列表:
                    return _dal.GetTemplateList();
                case BaseDataCatalog.划价模板明细列表:
                    return _dal.GetTemplateDetailList();
                case BaseDataCatalog.工作单位列表:
                    return _dal.GetWorkUnitList();
                case BaseDataCatalog.基本医疗服务项目列表:
                    return _dal.GetBaseServiceItems();
                default:
                    throw new NotImplementedException( catalog.ToString() + "还未实现数据访问" );
            }
        }
        /// <summary>
        /// 重新加载数据
        /// </summary>
        /// <param name="catalog"></param>
        public void Reload( BaseDataCatalog catalog )
        {
            DataTable dtData = LoadBaseData( catalog );

            if ( _dataSet != null )
            {
                if ( _dataSet.Tables.Contains( catalog.ToString() ) )
                {
                    _dataSet.Tables.Remove( catalog.ToString() );
                    dtData.TableName = catalog.ToString();
                    _dataSet.Tables.Add( dtData );   
                }
            }
        }
    }
    
}
