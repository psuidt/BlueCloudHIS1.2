using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.MZ_BLL
{
    /// <summary>
    /// 门诊医生站接口实现
    /// </summary>
    public class MZClinicInterface 
    {
        private HIS.Interface.IMZ_ClinicData instance;

        public MZClinicInterface()
        {
            //获取接口实例
            instance = HIS.Interface.InstanceFactory.CreatMZ_ClinicDataInstance();
        }
        /// <summary>
        /// 更改医生处方状态
        /// </summary>
        /// <param name="presHeadId">处方头ID</param>
        /// <param name="status">状态（0-未收费，1-已收费）</param>
        /// <returns></returns>
        public bool ChangePresStatus( int presHeadId, int status )
        {
            return instance.ChangePresStatus( presHeadId, status );
        }
        /// <summary>
        /// 得到指定病人的医生处方
        /// </summary>
        /// <param name="patListId">病人就诊ID</param>
        /// <returns></returns>
        public HIS.Interface.Structs.Prescription[] GetPrescriptions( int patListId )
        {
            return instance.GetPrescriptions( patListId );
        }


        /// <summary>
        /// 得到处方总金额
        /// </summary>
        /// <param name="mzdocpresheadid">门诊处方头ID</param>
        /// <returns></returns>
        public decimal GetDocPresMoney(int mzdocpresheadid)
        {
            return instance.GetMzDocPresTotalMoney(mzdocpresheadid);
        }
      
    }

    
}
