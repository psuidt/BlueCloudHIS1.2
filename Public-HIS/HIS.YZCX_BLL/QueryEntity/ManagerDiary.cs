using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.YZCX_BLL
{
    public class ManagerDiary
    {
        public ManagerDiary()
        { 
        }
        private decimal totalFee;

        /// <summary>
        /// 医院总收入
        /// </summary>
        public decimal TotalFee
        {
            get { return totalFee; }
            set { totalFee = value; }
        }
        private decimal totalFee_MZ;

        /// <summary>
        /// 门诊总收入
        /// </summary>
        public decimal TotalFee_MZ
        {
            get { return totalFee_MZ; }
            set { totalFee_MZ = value; }
        }
        private decimal totalFee_ZY;

        /// <summary>
        /// 住院总收入
        /// </summary>
        public decimal TotalFee_ZY
        {
            get { return totalFee_ZY; }
            set { totalFee_ZY = value; }
        }
        private decimal totalFee_MZ_YP;

        /// <summary>
        /// 门诊药品收入
        /// </summary>
        public decimal TotalFee_MZ_YP
        {
            get { return totalFee_MZ_YP; }
            set { totalFee_MZ_YP = value; }
        }
        private decimal totalFee_ZY_YP;

        /// <summary>
        /// 住院药品收入
        /// </summary>
        public decimal TotalFee_ZY_YP
        {
            get { return totalFee_ZY_YP; }
            set { totalFee_ZY_YP = value; }
        }
        private int mz_Population;

        /// <summary>
        /// 门诊人次
        /// </summary>
        public int Mz_Population
        {
            get { return mz_Population; }
            set { mz_Population = value; }
        }
        private decimal _averageFee_MZ;

        /// <summary>
        /// 门诊平均费用
        /// </summary>
        public decimal AverageFee_MZ
        {
            get { return _averageFee_MZ; }
            set { _averageFee_MZ = value; }
        }
        private decimal _averagePresFee_MZ;

        /// <summary>
        /// 门诊平均处方费用
        /// </summary>
        public decimal AveragePresFee_MZ
        {
            get { return _averagePresFee_MZ; }
            set { _averagePresFee_MZ = value; }
        }
        private int _adminNum_ZY;

        /// <summary>
        /// 入院人次
        /// </summary>
        public int AdminNum_ZY
        {
            get { return _adminNum_ZY; }
            set { _adminNum_ZY = value; }
        }
        private int _leaveNum_ZY;

        /// <summary>
        /// 出院人次
        /// </summary>
        public int LeaveNum_ZY
        {
            get { return _leaveNum_ZY; }
            set { _leaveNum_ZY = value; }
        }
        private int _totalDays_ZY;

        private int _atNum_ZY;
        public int AtNum_ZY
        {
            get { return _atNum_ZY; }
            set { _atNum_ZY = value; }
        }
        /// <summary>
        /// 总住院天数
        /// </summary>
        public int TatalDays_ZY
        {
            get { return _totalDays_ZY; }
            set { _totalDays_ZY = value;}
        }
        
        /// <summary>
        /// 经管核算项目表
        /// </summary>
        private DataTable _hsFee;

        public DataTable HSFee
        {
            get { return _hsFee; }
            set { _hsFee = value; }
        }
    }
}
