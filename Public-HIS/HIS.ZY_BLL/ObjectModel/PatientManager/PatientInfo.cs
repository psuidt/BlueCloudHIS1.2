using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using HIS.SYSTEM.Core;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.ZY_BLL.ObjectModel.PatientManager;
//using HIS.ZY_BLL.ObjectModel.NccmManager;
using HIS.ZY_BLL.Dao;
using HIS.ZY_BLL.ObjectModel.NccmManager;

namespace HIS.ZY_BLL.DataModel
{
    /// <summary>
    /// 病人类
    /// </summary>
    partial class PatientInfo :ImzPatInfo,IbaseDao
    {
        #region IbaseDao 成员
        private RelationalDatabase _OleDb;
        /// <summary>
        /// 数据库操作对象
        /// </summary>
        public RelationalDatabase oleDb
        {
            get
            {
                return _OleDb;
            }
            set
            {
                _OleDb = value;
            }
        }
        #endregion
        public PatientInfo()
        {
            oleDb = BaseBLL.oleDb;
        }

        public PatientInfo(RelationalDatabase _oledb)
        {
            oleDb = _oledb;
        }

        /// <summary>
        /// 根据农合病人代码查询病人住院号
        /// </summary>
        /// <param name="PatCode">农合病人代码</param>
        /// <returns></returns>
        public string GetCureNo(string PatCode)
        {
            try
            {
                string strWhere = "PATCODE='" + PatCode + "'";
                object obj = BindEntity<PatientInfo>.CreateInstanceDAL(oleDb).GetFieldValue("CURENO", strWhere);
                if (obj == null)
                {
                    return null;
                }
                else
                {
                    return obj.ToString();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #region ImzPatInfo 成员

        public void Add()
        {
            if (!BindEntity<PatientInfo>.CreateInstanceDAL(oleDb).Exists(this.PatID))
            {
                this.CureNum = 1;
                BindEntity<PatientInfo>.CreateInstanceDAL(oleDb).Add(this);
            }
            else
            {
                this.CureNum = this.CureNum + 1;
                BindEntity<PatientInfo>.CreateInstanceDAL(oleDb).Update(this);
            }
        }

        public void Update()
        {
            BindEntity<PatientInfo>.CreateInstanceDAL(oleDb).Update(this);
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        #endregion

        /// <summary>
        /// 读卡,得到病人信息
        /// </summary>
        /// <param name="snpt">查询类型</param>
        /// <returns></returns>
        public DataTable GetNccmPat_LH(SearchNccmPatType snpt, string values)
        {
            try
            {
                string strWhere;

                if (snpt == SearchNccmPatType.病人姓名)
                {
                    strWhere = "PATNAME like '%" + values + "%'";
                    return BindEntity<PatientInfo>.CreateInstanceDAL(oleDb).GetList(strWhere);
                }
                else if (snpt == SearchNccmPatType.家庭编码)
                {
                    strWhere = "PATCODE ='" + values + "'";
                    return BindEntity<PatientInfo>.CreateInstanceDAL(oleDb).GetList(strWhere);
                }
                else if (snpt == SearchNccmPatType.身份证号)
                {
                    strWhere = "PATNUMBER ='" + values + "'";
                    return BindEntity<PatientInfo>.CreateInstanceDAL(oleDb).GetList(strWhere);
                }
                else if (snpt == SearchNccmPatType.医疗卡号)
                {
                    strWhere = "MEDICARD ='" + values + "'";
                    return BindEntity<PatientInfo>.CreateInstanceDAL(oleDb).GetList(strWhere);
                }
                return null;

            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}