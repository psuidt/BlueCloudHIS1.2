using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace HIS.Interface
{
    /// <summary>
    /// 创建实例工场,用于创建各个接口的实现对象。
    /// </summary>
    public class InstanceFactory
    {
        /// <summary>
        /// 创建一个处方金额计算类
        /// </summary>
        /// <returns></returns>
        public static IPrescMoneyCalculate CreatPrescMoneyCalculate()
        {
            string dllPath = System.Windows.Forms.Application.StartupPath + "\\HIS.MZ_BLL.dll";

            Assembly assembly = Assembly.LoadFile( dllPath );

            string typeFullName = "HIS.MZ_BLL.PrescMoneyCalculate";

            object obj = assembly.CreateInstance( typeFullName );

            try
            {
                return (IPrescMoneyCalculate)obj;
            }
            catch
            {
                throw new Exception( "创建处方金额计算对象发生错误！" );
            }
        }
        /// <summary>
        /// 创建门诊数据访问对象
        /// </summary>
        /// <returns></returns>
        public static IMZ_Data CreatMZ_Data()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 创建药品数据访问对象
        /// </summary>
        /// <returns></returns>
        public static IYP_Data CreatYP_Data()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 创建住院数据访问对象
        /// </summary>
        /// <returns></returns>
        public static IZY_Data CreatZY_Data()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 创建门诊临床数据访问对象
        /// </summary>
        /// <returns></returns>
        public static IMZ_ClinicData CreatMZ_ClinicDataInstance()
        {
            string dllPath = System.Windows.Forms.Application.StartupPath + "\\HIS.MZDoc_BLL.dll";

            Assembly assembly = Assembly.LoadFile(dllPath);

            string typeFullName = "HIS.MZDoc_BLL.InterFace.ClinicDataInterFace";

            object obj = assembly.CreateInstance(typeFullName);

            try
            {
                return (IMZ_ClinicData)obj;
            }
            catch
            {
                throw new Exception("创建门诊临床数据访问对象发生错误！");
            }
        }
    }
}
