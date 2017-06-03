using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.Model;
using HIS.DAL;
using HIS.SYSTEM;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.SYSTEM.BussinessLogicLayer.Classes;
using HIS.SYSTEM.Core;

namespace HIS.YP_BLL
{
    class YF_StoreQuery : StoreQuery
    {
        public override DataTable GetDrugForValidity(string drugType, int validityDay, int deptId)
        {
            throw new NotImplementedException();
        }

        public override DataTable  GetSupportInfo(DateTime ? bTime,DateTime ? eTime)
        {
            try
            {
                YP_Dal dal=new YP_Dal ();
                dal._oleDb=oleDb;
                return dal.GetSupportIOQuery(bTime, eTime);
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        public override DataTable GetDrugForStoreLimit(string queryCode, bool isUpperLimt, int deptId, int typeDicId)
        {
            try
            {
                YP_Dal dal = new YP_Dal();
                dal._oleDb = oleDb;
                string strWhere = "";
                
                if (isUpperLimt)
                {
                    strWhere += "CURRENTNUM" + oleDb.GreaterThan() + "UPPERLIMIT";
                }
                else
                {
                    strWhere += "CURRENTNUM" + oleDb.LessThan() + "LOWERLIMIT";
                }
                if (typeDicId != 0)
                {
                    strWhere += oleDb.And() + "TYPEDICID" + oleDb.EuqalTo() + typeDicId.ToString();
                }
                if (queryCode != "")
                {
                    strWhere += (oleDb.And() + "(PYM like '%" + queryCode.ToString() + "%'"
                                 + oleDb.Or() + "WBM like '%" + queryCode.ToString() + "%'"
                                 + oleDb.Or() + "BYNAME like '%" + queryCode.ToString() + "%')");
                }
                return dal.YF_Storage_GetList(strWhere, deptId);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public override DataTable GetCheckDrug(int deptId)
        {
            try
            {
                HIS.DAL.YP_Dal drugDao = new YP_Dal();
                drugDao._oleDb = oleDb;
                return drugDao.YF_GetCheckDrug("", deptId);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public override decimal QueryNum(int makerDicId, int deptId)
        {
            IBaseDAL<YP_Storage> storeDao = BindEntity<YP_Storage>.CreateInstanceDAL(oleDb, BLL.Tables.YF_STORAGE);
            YP_Storage currentStore = storeDao.GetModel("MakerDicID=" + makerDicId.ToString() +
                        " AND DeptId=" + deptId.ToString());
            if (currentStore != null)
            {
                return currentStore.CurrentNum;
            }
            else
            {
                return -1;
            }
        }

        public override DataTable LoadDrugInfo(int deptId)
        {
            try
            {
                HIS.DAL.YP_Dal drugDao = new YP_Dal();
                drugDao._oleDb = oleDb;
                return drugDao.YF_GetDrugInfo("", deptId);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public override DataTable LoadDrugInfo(int doseId, int typeId, int deptId)
        {
            try
            {
                string strWhere = "";
                if (typeId != 0)
                {
                    strWhere += "TypeDicID=" + typeId.ToString();
                }
                if (doseId != -1)
                {
                    if (typeId == 0)
                    {
                        strWhere += "DoseDicID=" + doseId.ToString();
                    }
                    else
                    {
                        strWhere += " AND DoseDicID=" + doseId.ToString();
                    }
                }
                HIS.DAL.YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                return ypDal.YF_GetDrugInfo(strWhere, deptId);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public override DataTable LoadDrugInfo(int ykDeptId, int yfDeptId)
        {
            throw new NotImplementedException();
        }

        public override DataTable LoadStoreInfo(int deptId)
        {
            try
            {
                HIS.DAL.YP_Dal dal = new YP_Dal();
                dal._oleDb = oleDb;
                return dal.YF_Storage_GetList("", deptId);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public override DataTable QueryStoreInfo(int drugType, int drugDose, int deptId, string queryCode)
        {
            try
            {
                HIS.DAL.YP_Dal dal = new YP_Dal();
                dal._oleDb = oleDb;
                string str = "(F.PYM like '%" + queryCode.ToString() + "%'"
                + oleDb.Or() + "F.WBM like '%" + queryCode.ToString() + "%'"
                + oleDb.Or() + "F.BYNAME like '%" + queryCode.ToString() + "%')";
                if (drugType != 0)
                {
                    str += oleDb.And() + "TYPEDICID" + oleDb.EuqalTo() + drugType;
                }
                if (drugDose != 0)
                {
                    str += oleDb.And() + "DOSEDICID" + oleDb.EuqalTo() + drugDose;
                }
                return dal.YF_Storage_GetList(str, deptId);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public override decimal QueryStoreFee(int deptId, int drugType)
        {
            try
            {
                HIS.DAL.YP_Dal dal = new YP_Dal();
                dal._oleDb = oleDb;
                decimal storeFee = dal.YF_Storage_GetTotalFee(deptId, drugType);
                if (storeFee < 0)
                {
                    return 0;
                }
                else
                {
                    return storeFee;
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public override decimal QueryTradeFee(int deptId, int drugType)
        {
            try
            {
                HIS.DAL.YP_Dal dal = new YP_Dal();
                dal._oleDb = oleDb;
                decimal storeFee = dal.YF_Storage_GetTradeFee(deptId, drugType);
                if (storeFee < 0)
                {
                    return 0;
                }
                else
                {
                    return storeFee;
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
