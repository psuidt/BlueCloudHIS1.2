using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.MZDoc_BLL;

namespace HIS.MZDoc_BLL
{
    /// <summary>
    /// 处方明细构造工厂
    /// </summary>
    public class PresListFactory
    {
        /// <summary>
        /// 构造处方明细对象实例
        /// </summary>
        /// <param name="presListType">处方明细类型</param>
        /// <param name="row">处方明细数据行</param>
        /// <returns></returns>
        public static IBasePresList CreatePresListObject(HIS.MZDoc_BLL.Public.PresListType presListType, DataRow row)
        {
            switch (presListType)
            {
                case HIS.MZDoc_BLL.Public.PresListType.病人处方明细:
                    return (HIS.MZDoc_BLL.Prescription)HIS.MZDoc_BLL.Public.Function.DataRowToObject<HIS.MZDoc_BLL.Prescription>(row);
                case HIS.MZDoc_BLL.Public.PresListType.处方模板明细:
                    return (HIS.MZDoc_BLL.PresMouldList)HIS.MZDoc_BLL.Public.Function.DataRowToObject<HIS.MZDoc_BLL.PresMouldList>(row);
                default:
                    return null;
            }
        }

        /// <summary>
        /// 构造处方明细对象实例
        /// </summary>
        /// <param name="presListType">处方明细类型</param>
        /// <returns></returns>
        public static IBasePresList CreatePresListObject(HIS.MZDoc_BLL.Public.PresListType presListType)
        {
            switch (presListType)
            {
                case HIS.MZDoc_BLL.Public.PresListType.病人处方明细:
                    return new HIS.MZDoc_BLL.Prescription();
                case HIS.MZDoc_BLL.Public.PresListType.处方模板明细:
                    return new HIS.MZDoc_BLL.PresMouldList();
                default:
                    return null;
            }
        }

        /// <summary>
        /// 构造处方明细对象实例
        /// </summary>
        /// <param name="presListType">处方明细类型</param>
        /// <param name="headId">处方头ID</param>
        /// <returns></returns>
        public static IBasePresList CreatePresListObject(HIS.MZDoc_BLL.Public.PresListType presListType,int headId)
        {
            switch (presListType)
            {
                case HIS.MZDoc_BLL.Public.PresListType.病人处方明细:
                    HIS.MZDoc_BLL.Prescription  prescription = new HIS.MZDoc_BLL.Prescription();
                    prescription.PresHeadId = headId;
                    return prescription;
                case HIS.MZDoc_BLL.Public.PresListType.处方模板明细:
                    HIS.MZDoc_BLL.PresMouldList presMouldList = new HIS.MZDoc_BLL.PresMouldList();
                    presMouldList.PresMouldHeadId = headId;
                    return presMouldList;
                default:
                    return null;
            }
        }
    }
}
