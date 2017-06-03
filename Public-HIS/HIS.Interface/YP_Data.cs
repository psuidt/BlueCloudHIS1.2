using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
using HIS.Model;
using HIS.Interface.Structs;

namespace HIS.Interface
{
    /// <summary>
    /// 药品数据接口
    /// </summary>
    public class YP_Data :BaseBLL ,IYP_Data
    {
        #region IYP_Data 成员
        /// <summary>
        /// 按发票获取退药明细列表
        /// </summary>
        /// <param name="InvoiceNum">发票号</param>
        /// <returns></returns>
        public List<HIS.Interface.Structs.PrescriptionDetail> GetReturnDrugList( string InvoiceNum )
        {
            try
            {
                string strWhere = "";
                strWhere += BLL.Tables.yf_drorder.INVOICENUM + oleDb.EuqalTo() + InvoiceNum
                    +oleDb.And()+BLL.Tables.yf_drorder.DRUGOC_FLAG + oleDb.EuqalTo()+0;
                List<YP_DROrder> orderList = BindEntity<HIS.Model.YP_DROrder>.CreateInstanceDAL(oleDb,
                    BLL.Tables.YF_DRORDER).GetListArray(strWhere);
                List<PrescriptionDetail> presOrderList = new List<PrescriptionDetail>();
                foreach (YP_DROrder order in orderList)
                {
                    PrescriptionDetail presOrder = new PrescriptionDetail();
                    presOrder.Amount = order.DrugOCNum;
                    presOrder.Buy_price = order.TradePrice;
                    presOrder.DetailId = order.OrderRecipeID;
                    presOrder.ItemId = order.MakerDicID;
                    presOrder.Tolal_Fee = order.RetailFee;
                    presOrder.Sell_price = order.RetailPrice;
                    presOrder.RelationNum = order.UnitNum;
                    presOrderList.Add(presOrder);
                }
                return presOrderList;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        /// <summary>
        /// 按处方ID获取退药明细列表
        /// </summary>
        /// <param name="PrescriptionId">处方头ID</param>
        /// <returns></returns>
        public List<HIS.Interface.Structs.PrescriptionDetail> GetReturnDrugList( int PrescriptionId )
        {
            throw new NotImplementedException( );
        }

        /// <summary>
        /// 获取药品库存信息
        /// </summary>
        /// <param name="DrugId">药品厂家典ID</param>
        /// <param name="DeptId">药剂科室ID</param>
        /// <param name="SellPrice">零售价</param>
        /// <param name="BuyPrice">批发价</param>
        /// <param name="CurrentStoreValue">当前库存量</param>
        /// <returns>返回状态</returns>
        public bool GetDrugStorInfo(int DrugId, int DeptId, out decimal SellPrice,
            out decimal BuyPrice, out decimal CurrentStoreValue)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select currentnum,tradeprice,retailprice from YF_STORAGE A");
                strSql.Append(" left outer join yp_makerdic B");
                strSql.Append(" on A.makerdicid=B.makerdicid and A.workid=B.workid");
                strSql.Append(" where A.makerdicid=" + DrugId.ToString() + " and A.deptid=" + DeptId.ToString());
                strSql.Append( " and a.workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID.ToString() );
                System.Data.DataRow dRow = oleDb.GetDataRow(strSql.ToString());
                if (dRow != null)
                {
                    SellPrice = Convert.ToDecimal(dRow["RETAILPRICE"]);
                    BuyPrice = Convert.ToDecimal(dRow["TRADEPRICE"]);
                    CurrentStoreValue = Convert.ToDecimal(dRow["CURRENTNUM"]);
                    return true;
                }
                else
                {
                    SellPrice = 0;
                    BuyPrice = 0;
                    CurrentStoreValue = 0;
                    return false;
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        #endregion
    }
}
