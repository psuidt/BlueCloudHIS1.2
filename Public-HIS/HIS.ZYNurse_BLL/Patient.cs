using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using HIS.SYSTEM.Core;

namespace HIS.ZYNurse_BLL
{
    public class Patient:BaseBLL
    {
        #region 变量
        int _patlistid;//患者住院ID，每次住院产生
        int _patid;//患者ID，
        string _cureno;//住院号
        string _bedcode;//床号
        string _patname;//姓名
        string _patsex;//性别
        DateTime _patbirthday;//出生时间
        string _deptid;//当前科室ID
        string _deptname;//当前科室名称
        #endregion

        #region 属性
        /// <summary>
        /// 患者住院ID
        /// </summary>
        public int patlistid
        {
            get { return _patlistid; }
        }

        /// <summary>
        /// 患者ID
        /// </summary>
        public int patid
        {
            get { return _patid; }
        }

        /// <summary>
        /// 住院号
        /// </summary>
        public string cureno
        {
            get { return _cureno; }
        }

        /// <summary>
        /// 获取患者床号
        /// </summary>
        public string bedcode
        {
            get { return _bedcode; }
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string patname
        {
            get { return _patname; }
        }

        /// <summary>
        /// 性别
        /// </summary>
        public string patsex
        {
            get { return _patsex; }
        }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime patbirthday
        {
            get { return _patbirthday; }
        }

        /// <summary>
        /// 当前科室ID
        /// </summary>
        public string deptid
        {
            get { return _deptid; }
        }

        /// <summary>
        /// 当前科室名称
        /// </summary>
        public string deptname
        {
            get { return _deptname; }
        }

        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="PatListID">患者patlistid</param>
        public Patient(int PatListID)
        {
            _patlistid = PatListID;
            string str = @"select a.PATID PatID, a.CURENO CureNO, a.BEDCODE BedCode, b.PATNAME PatName, b.PATSEX PatSex, b.PATBRIDATE  PatBirthDay, a.CURRDEPTCODE DeptID, c.NAME DeptName" +
                " from ZY_PATLIST a " +
                " left join PATIENTINFO b on b.PATID=a.PATID" +
                " left join BASE_DEPT_PROPERTY c on cast(c. DEPT_ID as char(20))=a.CURRDEPTCODE" +
                " where a.PATLISTID=" + PatListID;
            DataRow dr = oleDb.GetDataRow(str);
            if (dr == null)
            {
                return;
            }
            _patid = Convert.ToInt32(dr["PatID"].ToString());
            _cureno = dr["CureNO"].ToString();
            _bedcode = dr["BedCode"].ToString();
            _patname = dr["PatName"].ToString();
            _patsex = dr["PatSex"].ToString();
            _patbirthday = Convert.ToDateTime(dr["PatBirthDay"].ToString());
            _deptid = dr["DeptID"].ToString();
            _deptname = dr["DeptName"].ToString();
        }
        #endregion
    }
}
