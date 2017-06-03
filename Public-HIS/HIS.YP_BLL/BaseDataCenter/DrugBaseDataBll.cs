using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.DAL;
using HIS.Model;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.SYSTEM.Core;
using HIS.BLL;


//版本：1.0.0.0
//创建时间：2008年2月1日
//修改人：谭亚奇
//最近修改时间：2008年3月20日
namespace HIS.YP_BLL
{
    /// <summary>
    /// 药品系统基础数据维护业务对象
    /// </summary>
    public class DrugBaseDataBll : BaseBLL
    {


        #region buyaode
        /// <summary>
        /// 将生产厂家对象添加到与其对应的数据表中
        /// </summary>
        /// <param name="productDt">目标数据表</param>
        /// <param name="product">生产厂家对象</param>
        public static void AddProduct(DataTable productDt, YP_ProductDic product)
        {
            try
            {
                if (product != null && productDt != null)
                {
                    DataRow newRow = productDt.NewRow();
                    newRow["Address"] = product.Address;
                    newRow["Del_Flag"] = product.Del_Flag;
                    newRow["LinkName"] = product.LinkName;
                    newRow["ProductName"] = product.ProductName;
                    newRow["LinkPhone"] = product.LinkPhone;
                    newRow["PY_CODE"] = product.PYM;
                    newRow["ProductID"] = product.ProductID;
                    newRow["WB_CODE"] = product.WMB;
                    productDt.Rows.Add(newRow);
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 更新生产厂家对象对应到数据表中某行的记录
        /// </summary>
        /// <param name="product">生产厂家对象</param>
        /// <param name="productDt">生产厂家数据表</param>
        /// <param name="index">对应记录的索引值</param>
        public static void UpdateProduct(YP_ProductDic product, DataTable productDt, int index)
        {
            try
            {
                if (productDt != null && product != null)
                {
                    DataRow currentRow = productDt.Rows[index];
                    currentRow["Address"] = product.Address;
                    currentRow["Del_Flag"] = product.Del_Flag;
                    currentRow["LinkName"] = product.LinkName;
                    currentRow["ProductName"] = product.ProductName;
                    currentRow["LinkPhone"] = product.LinkPhone;
                    currentRow["PY_CODE"] = product.PYM;
                    currentRow["WB_CODE"] = product.WMB;
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 从生产厂家数据表中特定行获取记录值并转成生产厂家对象
        /// </summary>
        /// <param name="dtTable">生产厂家数据表</param>
        /// <param name="index">记录对应的索引值</param>
        /// <returns>生产厂家对象</returns>
        public static YP_ProductDic GetProductFormDt(DataTable dtTable, int index)
        {
            try
            {
                if (dtTable.Rows.Count < index + 1 || dtTable.Rows.Count == 0)
                {
                    return null;
                }
                YP_ProductDic currentProduct = new YP_ProductDic();
                ApiFunction.DataTableToObject(dtTable, index, currentProduct);
                return currentProduct;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 添加供应商对象到特定的供应商数据表中
        /// </summary>
        /// <param name="supportDt">目标数据表</param>
        /// <param name="support">供应商对象</param>
        public static void AddSupport(DataTable supportDt, YP_SupportDic support)
        {
            try
            {
                if (support != null && supportDt != null)
                {
                    DataRow newRow = supportDt.NewRow();
                    newRow["Address"] = support.Address;
                    newRow["Del_Flag"] = support.Del_Flag;
                    newRow["LinkMan"] = support.LinkMan;
                    newRow["Name"] = support.Name;
                    newRow["Phone"] = support.Phone;
                    newRow["PY_CODE"] = support.PYM;
                    newRow["SupportDicID"] = support.SupportDicID;
                    newRow["WB_CODE"] = support.WBM;
                    supportDt.Rows.Add(newRow);
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }



        /// <summary>
        /// 按照供应商对象信息更新供应商数据表中的指定记录
        /// </summary>
        /// <param name="support">供应商对象</param>
        /// <param name="supportDt">供应商数据表</param>
        /// <param name="index">记录索引值</param>
        public static void UpdateSupport(YP_SupportDic support, DataTable supportDt, int index)
        {
            try
            {
                if (supportDt != null && support != null)
                {
                    DataRow currentRow = supportDt.Rows[index];
                    currentRow["Address"] = support.Address;
                    currentRow["Del_Flag"] = support.Del_Flag;
                    currentRow["LinkMan"] = support.LinkMan;
                    currentRow["Name"] = support.Name;
                    currentRow["Phone"] = support.Phone;
                    currentRow["PY_CODE"] = support.PYM;
                    currentRow["WB_CODE"] = support.WBM;
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 将供应商数据表中指定行记录转成供应商对象
        /// </summary>
        /// <param name="dtTable">数据表</param>
        /// <param name="index">索引值</param>
        /// <returns>供应商对象</returns>
        public static YP_SupportDic GetSupportFormDt(DataTable dtTable, int index)
        {
            try
            {
                if (dtTable.Rows.Count < index + 1 || dtTable.Rows.Count == 0)
                {
                    return null;
                }
                YP_SupportDic currentSupport = new YP_SupportDic();
                ApiFunction.DataTableToObject(dtTable, index, currentSupport);
                return currentSupport;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 将药剂科室数据表中特定行记录转成药剂科室对象
        /// </summary>
        /// <param name="drugDeptDt">药剂科室数据表</param>
        /// <param name="index">记录索引</param>
        /// <param name="drugDept">药剂科室对象</param>
        public static void GetDrugDeptFromDt(DataTable drugDeptDt, int index, YP_DeptDic drugDept)
        {
            ApiFunction.DataTableToObject(drugDeptDt, index, drugDept);
        }

        /// <summary>
        /// 将特定数据表记录转换成药品库存对象
        /// </summary>
        /// <param name="dR">数据表记录</param>
        /// <param name="storeOrder">药品库存对象</param>
        public static void DataRowToStoreOrder(DataRow dR, YP_Storage storeOrder)
        {
            try
            {
                if (storeOrder == null)
                {
                    storeOrder = new YP_Storage();
                }
                if (storeOrder.LeastUnitEntity == null)
                {
                    storeOrder.LeastUnitEntity = new YP_UnitDic();
                }
                if (storeOrder.MakerDic == null)
                {
                    storeOrder.MakerDic = new YP_MakerDic();
                }
                //if (storeOrder.MakerDic.SpecDic == null)
                //{
                //    storeOrder.MakerDic.SpecDic = new YP_SpecDic();

                //}
                //if (storeOrder.MakerDic.Product == null)
                //{
                //    storeOrder.MakerDic.Product = new YP_ProductDic();

                //}
                storeOrder.CurrentNum = Convert.ToDecimal(dR["CURRENTNUM"]);//当前数量
                storeOrder.Del_Flag = 0;
                storeOrder.DeptID = Convert.ToInt32(dR["DEPTID"]);//部门ID
                storeOrder.LeastUnit = Convert.ToInt32(dR["LEASTUNIT"]);//单位ID               
                storeOrder.LeastUnitEntity.UnitName = dR["UNITNAME"].ToString();//单位名称
                storeOrder.LowerLimit = Convert.ToDecimal(dR["LOWERLIMIT"]);//库存下限
                storeOrder.LStockPrice = Convert.ToDecimal(dR["LSTOCKPRICE"]);//上次进价
                storeOrder.MakerDicID = Convert.ToInt32(dR["MAKERDICID"]);//厂家典标识ID
                storeOrder.Place = dR["PLACE"].ToString();//存放位置
                storeOrder.RegTime = Convert.ToDateTime(dR["REGTIME"]);//注册时间
                storeOrder.StorageID = Convert.ToInt32(dR["STORAGEID"]);//库存表ID
                storeOrder.UnitNum = Convert.ToInt32(dR["UNITNUM"]);//单位比例
                storeOrder.UpperLimit = Convert.ToDecimal(dR["UPPERLIMIT"]);//库存上限               
                storeOrder.MakerDic.RetailPrice = Convert.ToDecimal(dR["RETAILPRICE"]);//零售价格
                storeOrder.MakerDic.TradePrice = Convert.ToDecimal(dR["TRADEPRICE"]);//批发价格               
                storeOrder.MakerDic.DrugInfo.chemname = dR["CHEMNAME"].ToString();//商品名称
                storeOrder.MakerDic.DrugInfo.spec = dR["SPEC"].ToString();//药品规格                
                storeOrder.MakerDic.DrugInfo.productname = dR["PRODUCTNAME"].ToString();//生产厂家名称
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        #endregion

        #region 加载数据

        /// <summary>
        /// 获取指定药剂科室可采购入库的药品信息
        /// </summary>
        /// <param name="deptId">部门ID</param>
        /// <returns>药品信息表</returns>
        public static DataTable YD_LoadDrugInfo(int deptId)
        {
            try
            {
                HIS.DAL.YP_Dal drugDao = new YP_Dal();
                drugDao._oleDb = oleDb;

                string strWhere_2 = Tables.yp_dept_yptype.DEPTID + oleDb.EuqalTo() + deptId.ToString().Trim();
                string strsql = oleDb.Table(Tables.YP_DEPT_YPTYPE, "", strWhere_2,
                           Views.vi_drug_dic.TYPEDICID);
                string drugTypeSql = "A." + Views.vi_drug_dic.TYPEDICID + oleDb.In() + "(" + strsql + ")";
                return drugDao.YD_GetDrugInfo(drugTypeSql);
            }
            catch (Exception error)
            {
                throw error;
            }
        }


        /// <summary>
        /// 获取药品字典中药品信息
        /// </summary>
        /// <param name="doseId">药品剂型ID</param>
        /// <param name="typeId">药品类型ID</param>
        /// <returns>
        /// 药品信息表
        /// </returns>
        public static DataTable YD_LoadDrugInfo(int doseId, int typeId)
        {
            try
            {
                string strWhere = "";
                if (typeId != 0)
                {
                    strWhere += "TypeDicID=" + typeId.ToString();
                }
                if (doseId != 0)
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
                HIS.DAL.YP_Dal drugDao = new YP_Dal();
                drugDao._oleDb = oleDb;
                return drugDao.YD_GetDrugInfo(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 获取可进行指定业务类型的所有药库部门
        /// </summary>
        /// <param name="opType">业务类型</param>
        /// <returns></returns>
        public static DataTable YK_DeptGet(string opType)
        {
            try
            {
                HIS.DAL.YP_Dal dal = new YP_Dal();
                dal._oleDb = oleDb;
                return dal.GetYK_Dept(opType);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 获取供应商信息
        /// </summary>
        /// <returns>供应商数据表</returns>
        public static DataTable LoadSupportInfo()
        {
            try
            {
                HIS.DAL.YP_Dal dal = new YP_Dal();
                dal._oleDb = oleDb;
                string str = Tables.yp_supportdic.DEL_FLAG + oleDb.EuqalTo() + "0";
                return dal.Support_GetList(str);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 按拼音码模糊查询供应商信息
        /// </summary>
        /// <param name="queryPYM">供应商拼音码</param>
        /// <returns>供应商数据表</returns>
        public static DataTable LoadSupportInfo(string queryPYM)
        {
            try
            {
                HIS.DAL.YP_Dal dal = new YP_Dal();
                dal._oleDb = oleDb;
                string str = Tables.yp_supportdic.DEL_FLAG + oleDb.EuqalTo() + "0" + oleDb.And() +
                    Tables.yp_supportdic.PYM + oleDb.Like() + "'%" + queryPYM + "%'";
                return dal.Support_GetList(str);

            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 判断指定科室是否是药剂科室
        /// </summary>
        /// <param name="deptId">指定科室</param>
        /// <returns>true：是；false：否</returns>
        public static bool ExistDrugDept(int deptId)
        {
            try
            {
                HIS.DAL.YP_Dal dal = new YP_Dal();
                dal._oleDb = oleDb;
                string strWhere = Tables.yp_deptdic.DEPTID + oleDb.EuqalTo() + deptId.ToString();
                return BindEntity<HIS.Model.YP_DeptDic>.CreateInstanceDAL(oleDb).Exists(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 根据科室ID号查询药剂科室
        /// </summary>
        /// <param name="deptId">科室ID号</param>
        /// <returns>药剂科室对象</returns>
        public static YP_DeptDic FindDrugDept(int deptId)
        {
            try
            {
                string str = Tables.yp_deptdic.DEPTID + oleDb.EuqalTo() + deptId;
                return BindEntity<HIS.Model.YP_DeptDic>.CreateInstanceDAL(oleDb).GetModel(str);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 查询药剂科室的业务
        /// </summary>
        /// <param name="drugDept">药剂科室对象</param>
        /// <returns>药剂科室业务数据表</returns>
        public static DataTable QueryDeptBussiness(YP_DeptDic drugDept)
        {
            try
            {
                HIS.DAL.YP_Dal dal = new YP_Dal();
                dal._oleDb = oleDb;
                return dal.YP_Bill_GetListForDrugDept(drugDept.DeptID);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 读取所有的药剂科室信息
        /// </summary>
        /// <returns>药剂科室数据表</returns>
        public static DataTable LoadAllDrugDept()
        {
            try
            {
                return BindEntity<HIS.Model.YP_DeptDic>.CreateInstanceDAL(oleDb).GetList("");
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        /// <summary>
        /// 读取所有药品类型的科室（并非等于药剂科室）
        /// </summary>
        /// <returns>科室数据表</returns>
        public static DataTable LoadDrugTypeDept()
        {
            try
            {
                string strsql = oleDb.Table(oleDb.TableNameBM(Tables.BASE_DEPT_PROPERTY, "A"), "", "A." +
                    Tables.base_dept_property.TYPE_CODE + oleDb.EuqalTo() + "'002'",
                                           oleDb.FiledNameBM("0", "ROWNO"),
                                           "A." + Tables.base_dept_property.NAME,
                                           "A." + Tables.base_dept_property.PY_CODE,
                                           "A." + Tables.base_dept_property.WB_CODE,
                                           "A." + Tables.base_dept_property.D_CODE,
                                           "A." + Tables.base_dept_property.DEPT_ID
                                           );
                return oleDb.GetDataTable(strsql);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 加载生产厂家信息
        /// </summary>
        /// <returns>生产厂家信息表</returns>
        public static DataTable LoadProductInfo()
        {
            try
            {

                HIS.DAL.YP_Dal dal = new YP_Dal();
                dal._oleDb = oleDb;
                string str = Tables.yp_productdic.DEL_FLAG + oleDb.EuqalTo() + "0";
                return dal.Product_GetList(str);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 查询生产厂家信息
        /// </summary>
        /// <param name="queryPYM">厂家拼音码</param>
        /// <returns>与该拼音码相匹配的模糊查询结果集</returns>
        public static DataTable LoadProductInfo(string queryPYM)
        {
            try
            {
                HIS.DAL.YP_Dal dal = new YP_Dal();
                dal._oleDb = oleDb;
                string str = Tables.yp_productdic.DEL_FLAG + oleDb.EuqalTo() + "0" +
                    oleDb.And() + "(" + Tables.yp_productdic.PYM + oleDb.Like() + "'%" + queryPYM + "%'" +
                    oleDb.Or() + Tables.yp_productdic.WMB + oleDb.Like() + "'%" + queryPYM + "%'" + ")";
                return dal.Product_GetList(str);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 加载药品剂型
        /// </summary>
        /// <param name="typedicId"></param>
        /// <returns></returns>
        public static List<YP_DoseDic> GetDoseType(int typedicId)
        {
            try
            {
                return BindEntity<HIS.Model.YP_DoseDic>.CreateInstanceDAL(oleDb).GetListArray("TYPEDICID=" + typedicId);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 读取所有药品类型对象
        /// </summary>
        /// <returns>药品类型对象链表</returns>
        public static List<YP_TypeDic> GetAllType()
        {
            try
            {
                return BindEntity<HIS.Model.YP_TypeDic>.CreateInstanceDAL(oleDb).GetListArray("1=1 order by TypeDicId");
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 加载药品剂型数据
        /// </summary>
        /// <returns>
        /// 返回所有剂型内容的表格
        /// </returns>
        public static DataTable LoadDrugDose()
        {
            try
            {
                HIS.DAL.YP_Dal dal = new YP_Dal();
                dal._oleDb = oleDb;
                return dal.Dose_GetList("");

            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 加载待选剂型
        /// </summary>
        /// <returns>剂型列表</returns>
        public static DataTable LoadDoseWithSelect()
        {
            try
            {
                DataTable doseDt = BindEntity<YP_DoseDic>.CreateInstanceDAL(oleDb).GetList("",
                    BLL.Tables.yp_dosedic.TYPEDICID,
                    BLL.Tables.yp_dosedic.DOSEDICID,
                    BLL.Tables.yp_dosedic.DOSENAME);
                DataRow newRow = doseDt.NewRow();
                newRow["DOSEDICID"] = 0;
                newRow["DOSENAME"] = "全部剂型";
                doseDt.Rows.InsertAt(newRow, 0);
                return doseDt;

            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 获取药品剂型名
        /// </summary>
        /// <param name="doseId"></param>
        /// <returns></returns>
        public static string GetDoseName(int doseId)
        {
            try
            {
                YP_DoseDic doseDic = BindEntity<YP_DoseDic>.CreateInstanceDAL(oleDb).GetModel(doseId);
                if (doseDic != null)
                {
                    return doseDic.DoseName;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }


        /// <summary>
        /// 加载药品类型数据
        /// </summary>
        /// <returns>
        /// 返回药品类型内容的表格
        /// </returns>
        public static DataTable LoadDrugType()
        {
            try
            {
                HIS.DAL.YP_Dal dal = new YP_Dal();
                dal._oleDb = oleDb;
                return dal.YPType_GetList("");
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        /// <summary>
        /// 加载待选药品类型
        /// </summary>
        /// <returns></returns>
        public static DataTable LoadTypeWithSelect()
        {
            try
            {
                DataTable typeDt = BindEntity<YP_TypeDic>.CreateInstanceDAL(oleDb).GetList("",
                    BLL.Tables.yp_typedic.TYPEDICID,
                    BLL.Tables.yp_typedic.TYPENAME);
                DataRow newRow = typeDt.NewRow();
                newRow["TYPEDICID"] = 0;
                newRow["TYPENAME"] = "全部类型";
                typeDt.Rows.InsertAt(newRow, 0);
                return typeDt;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 获取药品类型名
        /// </summary>
        /// <param name="typeId">药品类型ＩＤ</param>
        /// <returns></returns>
        public static string GetTypeName(int typeId)
        {
            try
            {
                YP_TypeDic typeDic = BindEntity<YP_TypeDic>.CreateInstanceDAL(oleDb).GetModel(typeId);
                if (typeDic != null)
                {
                    return typeDic.TypeName;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }


        /// <summary>
        /// 根据规格对象读取厂家信息表
        /// </summary>
        /// <param name="specDic">
        /// 规格对象
        /// </param>
        /// <returns></returns>
        public static DataTable LoadMakerDic(YP_SpecDic specDic)
        {
            try
            {
                string strWhere = Tables.yp_makerdic.SPECDICID + oleDb.EuqalTo() + specDic.SpecDicID.ToString();
                HIS.DAL.YP_Dal dal = new YP_Dal();
                dal._oleDb = oleDb;
                return dal.Maker_GetList(strWhere);

            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 读取医保类型信息表
        /// </summary>
        /// <returns>
        /// 医保类型信息表
        /// </returns>
        public static DataTable LoadMedicareDic()
        {
            try
            {
                HIS.DAL.YP_Dal dal = new YP_Dal();
                dal._oleDb = oleDb;
                return dal.Medicare_GetList("");

            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 读取生产厂家信息表
        /// </summary>
        /// <returns>
        /// 生产厂家信息表
        /// </returns>
        public static DataTable LoadProductDic()
        {
            try
            {
                HIS.DAL.YP_Dal dal = new YP_Dal();
                dal._oleDb = oleDb;
                return dal.Product_GetList("DEL_FLAG=0");
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 读取药品规格信息表
        /// </summary>
        /// <returns>
        /// 药品规格信息表
        /// </returns>
        public static DataTable LoadSpecDic()
        {
            try
            {
                HIS.DAL.YP_Dal dal = new YP_Dal();
                dal._oleDb = oleDb;
                return dal.Spec_GetList("");
            }
            catch (Exception error)
            {
                throw error;
            }
        }



        /// <summary>
        /// 查询本院启用药品
        /// </summary>
        /// <returns></returns>
        public static DataTable LoadUseSpec(string strWhere)
        {
            try
            {
                HIS.DAL.YP_Dal dal = new YP_Dal();
                dal._oleDb = oleDb;
                return dal.UseSpec_GetList(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 导出本院启用药品
        /// </summary>
        /// <returns></returns>
        public static DataTable LoadExpotSpec()
        {
            try
            {
                HIS.DAL.YP_Dal dal = new YP_Dal();
                dal._oleDb = oleDb;
                return dal.GetUseSpecExportData();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 获取药品化学名
        /// </summary>
        /// <param name="makerdicId">药品厂家典ID</param>
        /// <returns></returns>
        public static string GetDurgName(int makerdicId)
        {
            try
            {
                string strWhere_1 = "b.makerdicid" + oleDb.EuqalTo() + makerdicId;
                string strsql = oleDb.Table(oleDb.TableNameBM(Tables.YP_SPECDIC, "a") + oleDb.LeftOuterJoin() +
                    oleDb.TableNameBM(Tables.YP_MAKERDIC, "b") + oleDb.ON("a.specdicid", "b.specdicid"), "",
                    strWhere_1, Tables.yp_specdic.CHEMNAME);
                object obj = oleDb.GetDataResult(strsql);
                if (obj == null || obj == DBNull.Value)
                {
                    return "";
                }
                else
                {
                    return obj.ToString();
                }

            }
            catch (Exception error)
            {
                throw error;
            }
        }


        /// <summary>
        /// 查询本院期初盘点药品
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable LoadFirstCheckDrug(string strWhere)
        {
            try
            {
                HIS.DAL.YP_Dal dal = new YP_Dal();
                dal._oleDb = oleDb;
                return dal.FirstIn_GetList(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }



        /// <summary>
        /// 读取药品规格信息
        /// </summary>
        /// <param name="strWhere">
        /// 指定筛选条件
        /// </param>
        /// <returns>
        /// 药品规格信息表
        /// </returns>
        public static DataTable LoadSpecDic(string strWhere)
        {
            try
            {
                HIS.DAL.YP_Dal dal = new YP_Dal();
                dal._oleDb = oleDb;
                return dal.Spec_GetList(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 读取药品单位信息
        /// </summary>
        /// <returns>
        /// 药品单位信息表
        /// </returns>
        public static DataTable LoadDrugUnit()
        {
            try
            {
                HIS.DAL.YP_Dal dal = new YP_Dal();
                dal._oleDb = oleDb;
                return dal.Unit_GetList("");
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 读取药品别名信息
        /// </summary>
        /// <param name="specDic">
        /// 对应药品规格对象
        /// </param>
        /// <returns>
        /// 药品别名信息表
        /// </returns>
        public static DataTable LoadDrugByName(YP_SpecDic specDic)
        {
            try
            {
                string strWhere = Tables.yp_bynamedic.SPECDICID + oleDb.EuqalTo() + specDic.SpecDicID.ToString();
                return BindEntity<HIS.Model.YP_BynameDic>.CreateInstanceDAL(oleDb).GetList(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 读取药理分类信息
        /// </summary>
        /// <returns>药理分类信息列表</returns>
        public static DataTable LoadPharmacology()
        {
            try
            {
                string[] str = new string[8];
                str[0] = oleDb.FiledNameBM("0", "rowno");
                str[1] = Tables.yp_pharmacology.ID;
                str[2] = Tables.yp_pharmacology.FID;
                str[3] = Tables.yp_pharmacology.DEL_FLAG;
                str[4] = Tables.yp_pharmacology.NAME;
                str[5] = oleDb.FiledNameBM("PYM", "PY_CODE");
                str[6] = oleDb.FiledNameBM("WBM", "WB_CODE");
                str[7] = oleDb.FiledNameBM("''", "D_CODE");
                return BindEntity<YP_Pharmacology>.CreateInstanceDAL(oleDb).GetList("", str);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        #endregion

        #region 基本业务



        /// <summary>
        /// 添加生产厂家
        /// </summary>
        /// <param name="product">生产厂家对象</param>
        public static void AddProduct(YP_ProductDic product)
        {
            try
            {
                BindEntity<HIS.Model.YP_ProductDic>.CreateInstanceDAL(oleDb).Add(product);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 删除生产厂家
        /// </summary>
        /// <param name="product">生产厂家对象</param>
        public static void DelProduct(YP_ProductDic product)
        {
            try
            {
                YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                ypDal.Product_Delete(product.ProductID);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 更新生产厂家
        /// </summary>
        /// <param name="product">生产厂家对象</param>
        public static void UpdateProduct(YP_ProductDic product)
        {
            try
            {
                BindEntity<HIS.Model.YP_ProductDic>.CreateInstanceDAL(oleDb).Update(product);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 添加供应商信息到数据库
        /// </summary>
        /// <param name="support">供应商对象</param>
        public static void AddSupport(YP_SupportDic support)
        {
            try
            {
                BindEntity<HIS.Model.YP_SupportDic>.CreateInstanceDAL(oleDb).Add(support);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 从数据库中删除供应商信息
        /// </summary>
        /// <param name="support">供应商对象</param>
        public static void DelSupport(YP_SupportDic support)
        {
            try
            {
                BindEntity<HIS.Model.YP_SupportDic>.CreateInstanceDAL(oleDb).Delete(support.SupportDicID);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 更新供应商信息到数据库
        /// </summary>
        /// <param name="support">供应商对象</param>
        public static void UpdateSupport(YP_SupportDic support)
        {
            try
            {

                BindEntity<HIS.Model.YP_SupportDic>.CreateInstanceDAL(oleDb).Update(support);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 添加药剂科室到数据库中
        /// </summary>
        /// <param name="drugDept">药剂科室对象</param>
        public static void AddDrugDept(YP_DeptDic drugDept)
        {
            try
            {
                BindEntity<HIS.Model.YP_DeptDic>.CreateInstanceDAL(oleDb).Add(drugDept);
                drugDept.Use_Flag = 1;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 从数据库中删除药剂科室
        /// </summary>
        /// <param name="drugDept">药剂科室对象</param>
        public static void DelDrugDept(YP_DeptDic drugDept)
        {
            try
            {

                BindEntity<HIS.Model.YP_DeptDic>.CreateInstanceDAL(oleDb).Delete(drugDept.DeptDicID);

            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 启用药剂科室
        /// </summary>
        /// <param name="drugDept">药剂科室对象</param>
        public static void UseDrugDept(YP_DeptDic drugDept)
        {
            try
            {
                oleDb.BeginTransaction();
                YP_BillNumDic bill = new YP_BillNumDic();
                bill.BillNum = 1;
                bill.DeptID = drugDept.DeptID;
                IBaseDAL<YP_BillNumDic> billDao = BindEntity<YP_BillNumDic>.CreateInstanceDAL(oleDb, Tables.YP_BILLNUMDIC);
                if (drugDept.DeptType1 == "药房")
                {
                    bill.OpType = ConfigManager.OP_YF_ADJPRICE;
                    billDao.Add(bill);
                    bill.OpType = ConfigManager.OP_YF_APPLYIN;
                    billDao.Add(bill);
                    bill.OpType = ConfigManager.OP_YF_AUDITCHECK;
                    billDao.Add(bill);
                    bill.OpType = ConfigManager.OP_YF_CHECK;
                    billDao.Add(bill);
                    bill.OpType = ConfigManager.OP_YF_DEPTDRAW;
                    billDao.Add(bill);
                    bill.OpType = ConfigManager.OP_YF_INSTORE;
                    billDao.Add(bill);
                    bill.OpType = ConfigManager.OP_YF_MONTHACCOUNT;
                    billDao.Add(bill);
                    bill.OpType = ConfigManager.OP_YF_REPORTLOSS;
                    billDao.Add(bill);
                    bill.OpType = ConfigManager.OP_YF_DISPENSE;
                    billDao.Add(bill);
                    bill.OpType = ConfigManager.OP_YF_REFUND;
                    billDao.Add(bill);
                }
                else
                {
                    bill.OpType = ConfigManager.OP_YK_ADJPRICE;
                    billDao.Add(bill);
                    bill.OpType = ConfigManager.OP_YK_AUDITCHECK;
                    billDao.Add(bill);
                    bill.OpType = ConfigManager.OP_YK_CHECK;
                    billDao.Add(bill);
                    bill.OpType = ConfigManager.OP_YK_DEPTDRAW;
                    billDao.Add(bill);
                    bill.OpType = ConfigManager.OP_YK_INOPTYPE;
                    billDao.Add(bill);
                    bill.OpType = ConfigManager.OP_YK_MONTHACCOUNT;
                    billDao.Add(bill);
                    if (drugDept.DeptType1 == "药库")
                    {
                        bill.OpType = ConfigManager.OP_YK_OUTTOYF;
                        billDao.Add(bill);
                    }
                    bill.OpType = ConfigManager.OP_YK_REPORTLOSS;
                    billDao.Add(bill);
                    bill.OpType = ConfigManager.OP_YK_FIRSTIN;
                    billDao.Add(bill);
                    //添加药房系统是否管理批发价
                    string strWhere = BLL.Tables.yp_config.CODE + oleDb.EuqalTo() + "'009'";
                    if (!BindEntity<YP_CONFIG>.CreateInstanceDAL(oleDb).Exists(strWhere))
                    {
                        YP_CONFIG tradePriceConfig = new YP_CONFIG ();
                        tradePriceConfig.BZ = "0不管,1管理 ";
                        tradePriceConfig.CODE = "009";
                        tradePriceConfig.DEPTID = 0;
                        tradePriceConfig.NAME = "MANAGETRADEPRICEYF";
                        tradePriceConfig.VALUE = "1";
                        BindEntity<YP_CONFIG >.CreateInstanceDAL(oleDb).Add(tradePriceConfig);
                    }
                }
                IBaseDAL<YP_CONFIG> configDao = BindEntity<YP_CONFIG>.CreateInstanceDAL(oleDb, Tables.YP_CONFIG);
                YP_CONFIG  checkConfig = new YP_CONFIG();
                checkConfig.BZ = "0正常,1开始";
                checkConfig.CODE = "006";
                checkConfig.DEPTID = drugDept.DeptID;
                checkConfig.NAME = "ISCHECKING";
                checkConfig.VALUE = "0";
                configDao.Add(checkConfig);
                checkConfig = new YP_CONFIG();
                checkConfig.BZ = "月结时间";
                checkConfig.CODE = "008";
                checkConfig.DEPTID = drugDept.DeptID;
                checkConfig.NAME = "ACCOUNTDAY";
                checkConfig.VALUE = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime.Day.ToString();
                configDao.Add(checkConfig);
                drugDept.Use_Flag = 1;
                BindEntity<HIS.Model.YP_DeptDic>.CreateInstanceDAL(oleDb).Update(drugDept);
                oleDb.CommitTransaction();
            }
            catch (Exception error)
            {
                oleDb.RollbackTransaction();
                throw error;
            }
        }

        /// <summary>
        /// 禁用药剂科室
        /// </summary>
        /// <param name="drugDept">药剂科室对象</param>
        public static void StopUseDrugDept(YP_DeptDic drugDept)
        {

            try
            {
                HIS.DAL.YP_Dal dal = new YP_Dal();
                dal._oleDb = oleDb;
                oleDb.BeginTransaction();
                if (drugDept.DeptType1 == "药房")
                {
                    if (dal.YF_Storage_ExistsStore(drugDept.DeptID))
                    {
                        throw new Exception("该药房已有库存，无法被禁用");
                    }
                }
                else if (drugDept.DeptType1 == "药库")
                {
                    if (dal.YK_Store_ExistsStore(drugDept.DeptID))
                    {
                        throw new Exception("该药库已有库存，无法被禁用");
                    }
                }
                dal.YP_Bill_DeleteByDept(drugDept.DeptID);
                dal.DeptType_DeleteByDept(drugDept.DeptID);
                drugDept.Use_Flag = 0;
                BindEntity<HIS.Model.YP_DeptDic>.CreateInstanceDAL(oleDb).Update(drugDept);
                string strWhere = "CODE='006' AND DEPTID=" + drugDept.DeptID.ToString();
                BindEntity<YP_CONFIG>.CreateInstanceDAL(oleDb).Delete(strWhere);
                strWhere = "CODE='008' AND DEPTID=" + drugDept.DeptID.ToString();
                BindEntity<YP_CONFIG >.CreateInstanceDAL(oleDb).Delete(strWhere);
                oleDb.CommitTransaction();
            }
            catch (Exception error)
            {
                oleDb.RollbackTransaction();
                throw error;
            }
        }

        /// <summary>
        /// 判断登陆仓库和所属系统是否是药剂科室
        /// </summary>
        /// <param name="belongSystem">登陆系统（药房、药库）</param>
        /// <param name="deptId">科室ID</param>
        /// <returns>登陆科室正确：true；错误：false；</returns>
        public static bool CheckRegDept(string belongSystem, long deptId)
        {
            try
            {
                string strWhere = BLL.Tables.yp_deptdic.DEPTID + oleDb.EuqalTo() + deptId;
                if (belongSystem == ConfigManager.YF_SYSTEM)
                {
                    strWhere += oleDb.And() + BLL.Tables.yp_deptdic.DEPTTYPE1 + oleDb.EuqalTo() + "'药房'";
                }
                else
                {
                    strWhere += oleDb.And() + "(" + BLL.Tables.yp_deptdic.DEPTTYPE1 + oleDb.EuqalTo() + "'药库'"
                        + oleDb.Or() + BLL.Tables.yp_deptdic.DEPTTYPE1 + oleDb.EuqalTo() + "'物资'" + ")";
                }
                return BindEntity<YP_DeptDic>.CreateInstanceDAL(oleDb).Exists(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 给指定药剂科室添加管理的药品类型
        /// </summary>
        /// <param name="dept">药剂科室</param>
        /// <param name="drugtypeList">药品类型链表</param>
        public static void AddManageType(YP_DeptDic dept, List<int> drugtypeList)
        {
            try
            {
                oleDb.BeginTransaction();
                foreach (int drugType in drugtypeList)
                {
                    YP_Dept_Yptype deptType = new YP_Dept_Yptype();
                    deptType.DeptId = dept.DeptID;
                    deptType.TypeDicId = drugType;
                    deptType.DeptDicId = dept.DeptDicID;
                    BindEntity<HIS.Model.YP_Dept_Yptype>.CreateInstanceDAL(oleDb).Add(deptType);
                }
                oleDb.CommitTransaction();
            }
            catch (Exception error)
            {
                oleDb.RollbackTransaction();
                throw error;
            }
        }


        /// <summary>
        /// 添加药品规格
        /// </summary>
        /// <param name="specDic">药品规格对象</param>
        ///  <param name="pywbcodeName">药品商品名拼音五笔码</param>
        ///  <param name="pywbcodeChemName">药品化学名拼音五笔码</param>
        public static void AddDgSpec(YP_SpecDic specDic, string[] pywbcodeName, string[] pywbcodeChemName)
        {
            try
            {
                string strWhere = Tables.yp_specdic.CHEMNAME + oleDb.EuqalTo() + "'" + specDic.ChemName + "'" + oleDb.And()
                    + Tables.yp_specdic.UNIT + oleDb.EuqalTo() + specDic.Unit + oleDb.And()
                    + Tables.yp_specdic.TYPEDICID + oleDb.EuqalTo() + specDic.TypeDicID + oleDb.And()
                    + Tables.yp_specdic.PACKUNIT + oleDb.EuqalTo() + specDic.PackUnit + oleDb.And()
                    + Tables.yp_specdic.PACKNUM + oleDb.EuqalTo() + specDic.PackNum + oleDb.And()
                    + Tables.yp_specdic.DOSEDICID + oleDb.EuqalTo() + specDic.DoseDicID + oleDb.And()
                    + Tables.yp_specdic.DOSENUM + oleDb.EuqalTo() + specDic.DoseNum;
                if (BindEntity<HIS.Model.YP_SpecDic>.CreateInstanceDAL(oleDb).Exists(strWhere))
                {
                    throw new Exception("该规格药品已经存在，请重新输入");
                }
                oleDb.BeginTransaction();
                BindEntity<HIS.Model.YP_SpecDic>.CreateInstanceDAL(oleDb).Add(specDic);
                YP_BynameDic byChemName = new YP_BynameDic();
                byChemName.Byname = specDic.ChemName;
                byChemName.SpecDicID = specDic.SpecDicID;
                byChemName.PYM = pywbcodeChemName[0].ToString();
                byChemName.WBM = pywbcodeChemName[1].ToString();
                BindEntity<HIS.Model.YP_BynameDic>.CreateInstanceDAL(oleDb).Add(byChemName);
                if (specDic.Name != specDic.ChemName)
                {
                    YP_BynameDic byName = new YP_BynameDic();
                    byName.Byname = specDic.Name;
                    byName.SpecDicID = specDic.SpecDicID;
                    byName.PYM = pywbcodeName[0].ToString();
                    byName.WBM = pywbcodeName[1].ToString();
                    BindEntity<HIS.Model.YP_BynameDic>.CreateInstanceDAL(oleDb).Add(byName);
                }
                oleDb.CommitTransaction();
            }
            catch (HIS.SYSTEM.DatabaseAccessLayer.DALException error)
            {
                if (oleDb.IsInTransaction)
                {
                    oleDb.RollbackTransaction();
                }
                throw error;
            }
        }

        /// <summary>
        /// 删除药品规格
        /// </summary>
        /// <param name="specID">
        /// 药品规格ＩＤ
        /// </param>
        public static void DeleteDgSpec(int specID)
        {
            try
            {
                oleDb.BeginTransaction();
                HIS.DAL.YP_Dal dal = new YP_Dal();
                dal._oleDb = oleDb;
                dal.Spec_Delete(specID);
                string str = Tables.yp_makerdic.SPECDICID + oleDb.EuqalTo() + specID.ToString();
                dal.Maker_Delete(str);
                oleDb.CommitTransaction();
            }
            catch (Exception error)
            {
                oleDb.RollbackTransaction();
                throw error;
            }
        }

        /// <summary>
        /// 重新启用药品规格
        /// </summary>
        /// <param name="specID">规格ID</param>
        public static void CancelDelteDgSpec(int specID)
        {
            try
            {
                oleDb.BeginTransaction();
                string strWhereSpec = Tables.yp_specdic.SPECDICID + oleDb.EuqalTo() + specID.ToString();
                BindEntity<YP_SpecDic>.CreateInstanceDAL(oleDb).Update(strWhereSpec, "DEL_FLAG=0");
                string strWhereMaker = Tables.yp_makerdic.SPECDICID + oleDb.EuqalTo() + specID.ToString();
                BindEntity<YP_MakerDic>.CreateInstanceDAL(oleDb).Update(strWhereMaker, "DEL_FLAG=0");
                oleDb.CommitTransaction();
            }
            catch (Exception error)
            {
                oleDb.RollbackTransaction();
                throw error;
            }
        }
        /// <summary>
        /// 重新启用药品厂家
        /// </summary>
        /// <param name="makerdicID">厂家ID</param>
        public static void CancelDelteDgMaker(int makerdicID)
        {
            try
            {
                string strWhereMaker = Tables.yp_makerdic.MAKERDICID + oleDb.EuqalTo() + makerdicID.ToString();
                BindEntity<YP_MakerDic>.CreateInstanceDAL(oleDb).Update(strWhereMaker, "DEL_FLAG=0");
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        /// <summary>
        /// 修改药品规格
        /// </summary>
        /// <param name="dgSpec">
        /// 规格对象
        /// </param>
        public static void UpdateDgSpec(YP_SpecDic dgSpec)
        {
            try
            {
                BindEntity<HIS.Model.YP_SpecDic>.CreateInstanceDAL(oleDb).Update(dgSpec);
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        /// <summary>
        /// 判断某种规格的药品是否存在库存数量
        /// </summary>
        /// <param name="dgSpec">药品规格</param>
        /// <returns>true：存在；false：不存在。</returns>
        public static bool IsHaveStoreNum(YP_SpecDic dgSpec)
        {
            try
            {
                bool rtn = false;
                List<YP_MakerDic> makerList = BindEntity<HIS.Model.YP_MakerDic>.CreateInstanceDAL(oleDb).GetListArray("SpecDicID=" + dgSpec.SpecDicID);
                foreach (YP_MakerDic makerDic in makerList)
                {
                    string strWhere = "MAKERDICID" + oleDb.EuqalTo() + makerDic.MakerDicID.ToString();
                    List<YP_Storage> yfStoreList = BindEntity<YP_Storage>.CreateInstanceDAL(oleDb, Tables.YF_STORAGE).GetListArray(strWhere);
                    List<YP_Storage> ykStoreList = BindEntity<YP_Storage>.CreateInstanceDAL(oleDb, Tables.YK_STORAGE).GetListArray(strWhere);
                    foreach (YP_Storage yfStore in yfStoreList)
                    {
                        if (yfStore.CurrentNum > 0)
                        {
                            rtn = true;
                            break;
                        }
                    }
                    foreach (YP_Storage ykStore in ykStoreList)
                    {
                        if (ykStore.CurrentNum > 0)
                        {
                            rtn = true;
                            break;
                        }
                    }
                }
                return rtn;
            }
            catch (Exception error)
            {
                throw error;
            }
        }


        /// <summary>
        /// 判断是否有库存记录
        /// </summary>
        /// <param name="dgSpec">药品规格</param>
        /// <returns></returns>
        public static bool IsHaveStoreRecord(YP_SpecDic dgSpec)
        {
            try
            {
                bool rtn = false;
                List<YP_MakerDic> makerList = BindEntity<HIS.Model.YP_MakerDic>.CreateInstanceDAL(oleDb).GetListArray("SpecDicID=" + dgSpec.SpecDicID);
                foreach (YP_MakerDic makerDic in makerList)
                {
                    string strWhere = "MAKERDICID" + oleDb.EuqalTo() + makerDic.MakerDicID.ToString();
                    if (BindEntity<YP_Storage>.CreateInstanceDAL(oleDb, Tables.YF_STORAGE).Exists(strWhere))
                    {
                        rtn = true;
                    }
                    if (BindEntity<YP_Storage>.CreateInstanceDAL(oleDb, Tables.YK_STORAGE).Exists(strWhere))
                    {
                        rtn = true;
                    }
                }
                return rtn;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 判断是否有库存记录
        /// </summary>
        /// <param name="makerDic">药品厂家</param>
        /// <returns></returns>
        public static bool IsHaveStoreRecord(YP_MakerDic makerDic)
        {
            try
            {
                string strWhere = BLL.Tables.yp_makerdic.MAKERDICID + oleDb.EuqalTo() + makerDic.MakerDicID.ToString();
                if (BindEntity<HIS.Model.YP_Storage>.CreateInstanceDAL(oleDb, Tables.YF_STORAGE).Exists(strWhere))
                {
                    return true;
                }
                else if (BindEntity<HIS.Model.YP_Storage>.CreateInstanceDAL(oleDb, Tables.YK_STORAGE).Exists(strWhere))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 判断是否有库存数量
        /// </summary>
        /// <param name="makerDic"></param>
        /// <returns></returns>
        public static bool IsHaveStoreNum(YP_MakerDic makerDic)
        {
            try
            {
                bool rtn = false;
                string strWhere = BLL.Tables.yp_makerdic.MAKERDICID + oleDb.EuqalTo() + makerDic.MakerDicID.ToString();
                List<YP_Storage> yfStoreList = BindEntity<YP_Storage>.CreateInstanceDAL(oleDb, Tables.YF_STORAGE).GetListArray(strWhere);
                List<YP_Storage> ykStoreList = BindEntity<YP_Storage>.CreateInstanceDAL(oleDb, Tables.YK_STORAGE).GetListArray(strWhere);
                foreach (YP_Storage yfStore in yfStoreList)
                {
                    if (yfStore.CurrentNum > 0)
                    {
                        rtn = true;
                        break;
                    }
                }
                foreach (YP_Storage ykStore in ykStoreList)
                {
                    if (ykStore.CurrentNum > 0)
                    {
                        rtn = true;
                        break;
                    }
                }
                return rtn;
            }
            catch (Exception error)
            {
                throw error;
            }
        }


        /// <summary>
        /// 添加厂家信息（启用药品）
        /// </summary>
        /// <param name="dgMaker">
        /// 厂家典对象
        /// </param>
        /// <param name="dgSpec">
        /// 规格典对象
        /// </param>
        public static void AddDgMaker(YP_MakerDic dgMaker, YP_SpecDic dgSpec)
        {
            try
            {
                oleDb.BeginTransaction();
                dgMaker.RegTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                BindEntity<HIS.Model.YP_MakerDic>.CreateInstanceDAL(oleDb).Add(dgMaker);
                oleDb.CommitTransaction();
            }
            catch (Exception error)
            {
                oleDb.RollbackTransaction();
                throw error;
            }
        }

        /// <summary>
        /// 修改厂家典信息
        /// </summary>
        /// <param name="dgMaker">
        /// 厂家典对象
        /// </param>
        public static void UpdateDgMaker(YP_MakerDic dgMaker)
        {
            try
            {
                BindEntity<HIS.Model.YP_MakerDic>.CreateInstanceDAL(oleDb).Update(dgMaker);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 删除厂家典信息
        /// </summary>
        /// <param name="dgMaker">
        /// 厂家典对象
        /// </param>
        public static void DeleteDgMaker(YP_MakerDic dgMaker)
        {
            try
            {
                oleDb.BeginTransaction();
                string strSet = Tables.yp_makerdic.DEL_FLAG + oleDb.EuqalTo() + "1";
                string strWhere = BLL.Tables.yp_makerdic.MAKERDICID + oleDb.EuqalTo() + dgMaker.MakerDicID.ToString();
                if (!IsHaveStoreNum(dgMaker))
                {
                    BindEntity<YP_MakerDic>.CreateInstanceDAL(oleDb).Update(strWhere, strSet);
                }
                else
                {
                    throw new Exception("该厂家药品在库房中还有库存，请将库存表中数量冲零后再进行删除");
                }
                oleDb.CommitTransaction();
            }
            catch (Exception error)
            {
                oleDb.RollbackTransaction();
                throw error;
            }
        }

        /// <summary>
        /// 添加药品别名
        /// </summary>
        /// <param name="dgByname">
        /// 药品别名对象
        /// </param>
        public static void AddDgByname(YP_BynameDic dgByname)
        {
            try
            {
                BindEntity<HIS.Model.YP_BynameDic>.CreateInstanceDAL(oleDb).Add(dgByname);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 删除药品别名
        /// </summary>
        /// <param name="dgByname">
        /// 药品别名对象
        /// </param>
        public static void DeleteByname(YP_BynameDic dgByname)
        {
            try
            {
                IBaseDAL<YP_BynameDic> byNameDao = BindEntity<YP_BynameDic>.CreateInstanceDAL(oleDb);
                if (byNameDao.GetList("SPECDICID=" + dgByname.SpecDicID).Rows.Count > 1)
                {
                    byNameDao.Delete(dgByname.BynameDicID);
                }
                else
                {
                    throw new Exception("该规格药品起码要保留一个别名，不允许删除");
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 修改药品别名信息
        /// </summary>
        /// <param name="dgByname">
        /// 药品别名
        /// </param>
        public static void UpdateByname(YP_BynameDic dgByname)
        {

            try
            {
                BindEntity<HIS.Model.YP_BynameDic>.CreateInstanceDAL(oleDb).Update(dgByname);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 组合规格
        /// </summary>
        /// <param name="specDic">
        /// 规格对象
        /// </param>
        /// <param name="unitDt">
        /// 单位对象表
        /// </param>
        public static void CombineSpec(YP_SpecDic specDic, DataTable unitDt)
        {
            StringBuilder specStr = new StringBuilder();
            specStr.Append(Convert.ToDouble(specDic.DoseNum).ToString());
            specStr.Append(GetName(specDic.DoseUnit, unitDt, "UnitDicID", "UnitName"));
            specStr.Append("*");
            specStr.Append(specDic.PackNum.ToString());
            specStr.Append(GetName(specDic.Unit, unitDt, "UnitDicID", "UnitName"));
            specStr.Append("*1");
            specStr.Append(GetName(specDic.PackUnit, unitDt, "UnitDicID", "UnitName"));
            specDic.Spec = specStr.ToString();
        }

        /// <summary>
        /// 从datatable中获取特定行的名称
        /// </summary>
        /// <param name="FindId">
        /// 指定行索引
        /// </param>
        /// <param name="FindDt">
        /// 信息表
        /// </param>
        /// <param name="strId">
        /// 指定行对应ID
        /// </param>
        /// <param name="strName">
        /// 列名
        /// </param>
        /// <returns></returns>
        public static string GetName(int FindId, DataTable FindDt, string strId, string strName)
        {
            if (FindId == 0 || strId == null || strName == null)
            {
                return "";
            }
            else
            {
                FindDt.PrimaryKey = new DataColumn[] { FindDt.Columns[strId] };
                DataRow unitRow = FindDt.Rows.Find(FindId.ToString());
                if (unitRow == null)
                {
                    return "";
                }
                string rtn = unitRow[strName].ToString();
                return rtn;
            }
        }

        #endregion
    }
}
