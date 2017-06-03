using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;


namespace HIS.MediInsInterface_BLL.MediInsInterface.CxNhSystem
{
    //[20100517.1.01]
    public class CxNhInterface
    {
        /// <summary>
        /// 该函数建立一个新的接口实例，并与服务器建立连接。
        /// </summary>
        /// <returns>返回值=0表示成功，返回值 小于0表示失败。</returns>
        [DllImport("nh_interface.dll")]
        public static extern int NewInterface();
        /// <summary>
        /// 从内存中释放接口的实例。
        /// </summary>
        /// <returns></returns>
        [DllImport("nh_interface.dll")]
        public static extern int DestoryInterface();
        /// <summary>
        /// 该函数用来在一次接口调用中传入业务所需的参数，
        /// Name为参数名称，以字符串表示；Value为参数值，也用字符串表示。
        /// 如果传入的参数值是数值或者日期，必须先转换成字符串。
        /// 返回值=0表示成功，返回值小于0表示失败，
        /// 调用 GetMessage可以得到出错的详细信息。
        /// </summary>
        /// <param name="Name">参数名称</param>
        /// <param name="Value">参数值</param>
        /// <returns>返回值=0表示成功，返回值小于0表示失败</returns>
        [DllImport("nh_interface.dll")]
        public static extern int PutParamByName(string Name, string Value);
        /// <summary>
        /// 该函数用来在一次接口调用中传入业务所需的记录集的一个域值，
        /// Recset 为记录集的序号，1小于等于 Recset，数值型；
        /// Row为记录集的行号，数值型，1 小于等于 Row 小于等于 调用Start的MaxRecNo参数；
        /// ColName为域名称，以字符串表示；
        /// Value为域值，也用字符串表示。
        /// 如果传入的域值是数值或者日期，必须先转换成字符串。
        /// 返回值=0表示成功，返回值小于0表示失败，
        /// 调用 GetMessage可以得到出错的详细信息。
        /// </summary>
        /// <param name="recset">Recset 为记录集的序号，1小于等于 Recset，数值型；</param>
        /// <param name="Row">Row为记录集的行号，数值型，1 小于等于 Row 小于等于 调用Start的MaxRecNo参数；</param>
        /// <param name="ColName">ColName为域名称，以字符串表示；</param>
        /// <param name="Value">域值</param>
        /// <returns></returns>
        [DllImport("nh_interface.dll")]
        public static extern int PutRecByName(int recset, int Row, string ColName, string Value);
        /// <summary>
        /// 该函数开始一次接口运行，直接将参数打包成送往中间层服务器，如果出错，将返回一个错误。
        /// 返回值 小于 0 表示没有Run成功，调用 GetMessage可以得到出错的详细信息。
        /// 返回值>=0为返回记录集的记录数，
        /// 如果有多个记录集返回，返回的是最后一个记录集的记录数，可以用调用GetRecCount得到其它记录集的记录数。
        /// </summary>
        /// <returns></returns>
        [DllImport("nh_interface.dll")]
        public static extern int Run();
        /// <summary>
        /// 该函数用来从接口取得返回参数的值。
        /// Name为返回参数的名称，用字符串表示。
        /// 如果调用成功，返回参数值的字符串形式，如果是数值型或者日期，可以在取得字符串以后再做相应转换。
        /// 返回“&n”的字符串形式（“&1”、“&2”等），
        /// 调用 GetMessage可以得到出错的详细信息。
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        [DllImport("nh_interface.dll")]
        public static extern string GetParamByName(string Name);
        /// <summary>
        /// 该函数用来从接口取得返回记录集的记录数。
        /// RecSet为记录集的序号，数值型，1小于等于 RecSet小于等于 返回记录集的个数。
        /// 返回值=0表示成功，返回值 小于 0表示失败，
        /// 调用 GetMessage可以得到出错的详细信息。
        /// </summary>
        /// <param name="RecSet"></param>
        /// <returns></returns>
        [DllImport("nh_interface.dll")]
        public static extern int GetRecCount(int RecSet);
        /// <summary>
        /// 在所有函数出错时，调用该函数，将返回一个错误信息。
        /// </summary>
        /// <param name="RecSet"></param>
        /// <returns></returns>
        [DllImport("nh_interface.dll")]
        public static extern string GetMessage();
        /// <summary>
        /// 该函数用来从接口取得返回记录集的域值。
        /// Row为记录集的行号，数值型，1 小于等于 Row  小于等于 记录集的记录数；ColName为域名称，用字符串表示；
        /// RecSet为返回记录集的序号，数值型，1 小于等于 RecSet 小于等于 返回记录集的个数。
        /// 如果调用成功，返回域值的字符串形式，如果是数值型或者日期，可以在取得字符串以后再做相应转换。
        /// 如果调用不成功，返回“&n”的字符串形式（“&1”、“&2”等），
        /// 调用 GetMessage可以得到出错的详细信息。
        /// </summary>
        /// <param name="Row"></param>
        /// <param name="ColName"></param>
        /// <param name="RecSet"></param>
        /// <returns></returns>
        [DllImport("nh_interface.dll")]
        public static extern string GetRecByName(int Row, string ColName, int RecSet);
        /// <summary>
        /// 该函数为一次接口调用的开始，FuncID为要进行的业务的功能号；
        /// MaxRecNo为需要传入记录集的记录数，如果没有需要传入的记录集，MaxRecNo＝0。
        /// 在上一次Start的业务没有进行完之前不能进行下一次Start。
        /// 返回值=0表示成功，返回值 小于 0表示失败，
        /// 调用 GetMessage可以得到出错的详细信息。
        /// </summary>
        /// <param name="PChar"></param>
        /// <param name="MaxRecNO"></param>
        /// <returns></returns>
        [DllImport("nh_interface.dll")]
        public static extern int Start(string PChar, int MaxRecNO);
        /// <summary>
        /// 记录集的域值
        /// </summary>
        /// <param name="recset"></param>
        /// <returns></returns>
        [DllImport("nh_interface.dll")]
        public static extern string GetRecString(int recset);
    }
}
