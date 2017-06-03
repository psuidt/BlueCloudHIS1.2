using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.MedicalConfir_BLL
{
    public interface MedicalInterface
    {
        /// <summary>
        /// 是否上了医技确费系统
        /// </summary>
        /// <returns>true=上了  false=没有</returns>
        bool HasMedical();

        /// <summary>
        /// 由presorderid 判断这个项目是否已确费
        /// </summary>
        /// <param name="presorderid"></param>
        /// <returns>true=已确费 false=没确费</returns>
        bool IsConfirmed(int presorderid,ConfirType type);
       
    }
}
