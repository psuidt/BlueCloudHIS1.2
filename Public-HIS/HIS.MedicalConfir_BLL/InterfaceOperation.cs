using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.DatabaseAccessLayer;
using Entity = HIS.Model;
using HIS.SYSTEM.Core;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;


namespace HIS.MedicalConfir_BLL
{
    public class InterfaceOperation : BaseBLL, MedicalInterface
    {
        #region 是否上了医技确费系统
        /// <summary>
        /// 是否上了医技确费系统
        /// </summary>
        /// <returns>true=上了  false=没有</returns>
        public bool HasMedical()
        {
            string strWhere = Tables.zy_doc_config.CODE + oleDb.EuqalTo() + "'006 '";
            object obj = BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_Doc_Config").GetFieldValue(Tables.zy_doc_config.VALUE, strWhere);
            if (obj == null || obj.ToString() == "0")
            {
                return false;
            }
            return true;
        }
        #endregion

        #region 由presorderid 判断这个项目是否已确费
        /// <summary>
        /// 由presorderid 判断这个项目是否已确费
        /// </summary>
        /// <param name="presorderid"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool IsConfirmed(int presorderid, ConfirType type)
        {
            string strWhere = Tables.medical_confir.PRESORDERID + oleDb.EuqalTo() + presorderid + oleDb.And() +
                            Tables.medical_confir.MARK_FLAG + oleDb.EuqalTo() + (int)type + oleDb.And() +
                            Tables.medical_confir.CANCEL_FLAG + oleDb.EuqalTo() + 0;
            if (BindEntity<HIS.Model.Medical_Confir>.CreateInstanceDAL(oleDb).Exists(strWhere))
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
