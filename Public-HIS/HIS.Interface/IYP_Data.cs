using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.Interface
{
    /// <summary>
    /// 药品数据接口
    /// </summary>
    public interface IYP_Data
    {
        /// <summary>
        /// 按发票获取退药明细列表
        /// </summary>
        /// <param name="InvoiceNum">发票号</param>
        /// <returns></returns>
        List<Structs.PrescriptionDetail> GetReturnDrugList(string InvoiceNum);
        /// <summary>
        /// 按处方ID获取退药明细列表
        /// </summary>
        /// <param name="PrescriptionId"></param>
        /// <returns></returns>
        List<Structs.PrescriptionDetail> GetReturnDrugList( int PrescriptionId );
        /// <summary>
        /// 获取指定药品的所在的库房的库存信息
        /// </summary>
        /// <param name="DrugId">药品ID</param>
        /// <param name="DeptId">药房ID</param>
        /// <param name="SellPrice">返回的零售价</param>
        /// <param name="BuyPrice">返回的进价</param>
        /// <param name="CurrentStoreValue">返回的当前库存（按基本单位）</param>
        /// <returns>如果没有药品或者药品被禁用停用，返回false,否则返回true</returns>
        bool GetDrugStorInfo(int DrugId,int DeptId,out decimal SellPrice,out decimal BuyPrice,out decimal CurrentStoreValue);
    }
}
