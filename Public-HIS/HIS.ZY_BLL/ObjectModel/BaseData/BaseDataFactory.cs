using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.ZY_BLL.ObjectModel.BaseData
{
    public enum baseDataType
    {
        诊断,
        病人类型,
        民族,
        所有用户,
        医生,
        所有科室,
        住院临床科室,
        全院临床科室,
        住院发票项目,
        记账单位,
        医疗机构,
        药房科室
    }

    public enum baseNameType
    {
        用户名称,
        科室名称
    }

    public class BaseDataFactory
    {
        public static DataTable GetData(baseDataType type)
        {
            BaseData bd = new BaseData();
            switch (type)
            {
                case baseDataType.诊断:
                    return bd.GetDiseaseData();

                case baseDataType.病人类型:
                    return bd.GetPatientTypeData();

                case baseDataType.民族:
                    return bd.GetNationcoData();

                case baseDataType.所有用户:
                    return bd.GetAllUserData();

                case baseDataType.医生:
                    return bd.GetUserDocData();
                case baseDataType.所有科室:
                    return bd.GetAllDeptData();
                case baseDataType.医疗机构:
                    return bd.GetWorkers();
                case baseDataType.住院临床科室:
                    return bd.GetClilinDeptData();

                case baseDataType.全院临床科室:
                    return bd.GetAllClilinDeptData();
                case baseDataType.住院发票项目:
                    return bd.GetInvoiceItemData();
                case baseDataType.记账单位:
                    return bd.GetWorkUnit();
                case baseDataType.药房科室:
                    return bd.GetYfName();
            }
            return null;
        }
    }

    public class BaseNameFactory
    {
        public static string GetName(baseNameType type,string code)
        {
            BaseName bn = new BaseName();
            switch (type)
            {
                case baseNameType.用户名称:
                    return bn.GetEmpName(code);
                case baseNameType.科室名称:
                    return bn.GetDeptName(code);
            }
            return null;
        }
    }
}
