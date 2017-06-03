using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace HIS.MediInsInterface_BLL.MediInsInterface.HygeiaSystem
{
    /// <summary>
    /// 创智医保接口函数原型
    /// </summary>
    public class Hygeia
    {
        #region ...新版接口函数原型....

        #region 新版
        /// <summary>
        /// 建立一个新的接口实例。
        /// 但这个函数没有初始化接口，必须再调用init函数初始化接口此函数返回接口指针p_inter，
        /// 它将作为其他函数入口参数。
        /// </summary>
        /// <returns></returns>
        [DllImport("InterfaceHN.dll", EntryPoint = "newinterface")]
        public static extern int NewInterface();

        /// <summary>
        /// 该函数建立一个新的接口实例并将接口初始化。
        /// 不需要再调用init函数。
        /// 参数Addr为应用服务器IP地址，
        /// Port为应用服务器端口号，
        /// Servlet为应用服务器入口Servlet的名称，
        /// 此函数返回接口指针p_inter，它将作为其他函数入口参数。
        /// </summary>
        /// <param name="Addr">应用服务器IP地址</param>
        /// <param name="Port">应用服务器端口号</param>
        /// <param name="Servlet">应用服务器入口Servlet的名称</param>
        /// <returns></returns>
        [DllImport("InterfaceHN.dll", EntryPoint = "newinterfacewithinit", CharSet = CharSet.Ansi)]
        public static extern int NewInterfaceWithInit(string Addr, int Port, string Servlet);

        /// <summary>
        /// 初始化接口。
        /// 返回-1表示没有Start成功，返回1表示调用成功。
        /// </summary>
        /// <param name="hInterface">函数newinterface()或者newinterfacewithinit的返回值</param>
        /// <param name="Addr">应用服务器IP地址</param>
        /// <param name="Port">应用服务器端口号</param>
        /// <param name="Servlet">应用服务器入口Servlet的名称</param>
        /// <returns>返回-1表示没有Start成功，返回1表示调用成功</returns>
        [DllImport("InterfaceHN.dll", EntryPoint = "init", CharSet = CharSet.Ansi)]
        public static extern int Init(int hInterface, string Addr, int Port, string Servlet);


        /// <summary>
        /// 从内存中释放接口的实例
        /// </summary>
        /// <param name="hInterface"></param>
        /// <returns></returns>
        [DllImport("InterfaceHN.dll", EntryPoint = "destoryinterface")]
        public static extern int DestoryInterface(int hInterface);


        /// <summary>
        /// 该函数为一次接口调用的开始，
        /// 入口参数p_inter为函数newinterface()或者newinterfacewithinit的返回值，
        /// 参数FUNC_ID为要进行的业务的功能号，
        /// 在上一次Start的业务没有进行完之前不能进行下一次Start。
        /// 返回-1表示没有Start成功，返回1表示调用成功。
        /// </summary>
        /// <param name="hInterface">函数newinterface()或者newinterfacewithinit的返回值</param>
        /// <param name="FUNC_ID">业务的功能号</param>
        /// <returns>返回-1表示没有Start成功，返回1表示调用成功。</returns>
        [DllImport("InterfaceHN.dll", EntryPoint = "start")]
        public static extern int Start(int hInterface, string FUNC_ID);

        /// <summary>
        /// 该函数用来在一次接口调用中传入业务所需的参数，
        /// 参数p_inter为函数newinterface()或者newinterfacewithinit的返回值，
        /// row为多行参数的行号，
        /// p_name为参数名称，以字符串小写表示，
        /// p_value为参数值，可以是字符串和数值型。
        /// 返回-1表示没有Put成功，返回大于零表示Put成功 ，此值同时为当前的行号。
        /// 如果入参有多个记录集，可用setresultset函数设置要传参数的记录集。
        /// </summary>
        /// <param name="hInterface">函数newinterface()或者newinterfacewithinit的返回值</param>
        /// <param name="row">多行参数的行号</param>
        /// <param name="p_name">参数名称，以字符串小写表示</param>
        /// <param name="p_value">参数值，可以是字符串和数值型</param>
        /// <returns>返回-1表示没有Put成功，返回大于零表示Put成功</returns>
        [DllImport("InterfaceHN.dll", EntryPoint = "put")]
        public static extern int Put(int hInterface, int row, string p_name, string p_value);

        /// <summary>
        /// 该函数用来在一次接口调用中传入业务所需的参数，
        /// 参数p_inter为函数newinterface()或者newinterfacewithinit的返回值，
        /// 返回-1表示没有Put成功，返回大于零表示Put成功，此值同时为当前的行号。
        /// </summary>
        /// <param name="hInterface">函数newinterface()或者newinterfacewithinit的返回值</param>
        /// <param name="p_name">参数名称，以字符串小写表示</param>
        /// <param name="p_value">参数值，可以是字符串和数值型</param>
        /// <returns></returns>
        [DllImport("InterfaceHN.dll", EntryPoint = "putcol")]
        public static extern int Putcol(int hInterface, string p_name, string p_value);

        /// <summary>
        /// 该函数开始一次接口运行，直接将参数打包成送往Servlet，如果出错，将返回一个错误。
        /// 返回-1表示没有Run成功，返回大于零的值为返回参数的记录条数。
        /// </summary>
        /// <param name="hInterface">函数newinterface()或者newinterfacewithinit的返回值</param>
        /// <returns>返回-1表示没有Run成功，返回大于零的值为返回参数的记录条数。</returns>
        [DllImport("InterfaceHN.dll", EntryPoint = "run")]
        public static extern int Run(int hInterface);

        /// <summary>
        ///当取结果时：
        ///将当前记录集设置为由result_name指定的记录集，
        ///如果指的记录集不存在，则不会改变当前记录集。
        ///返回－1表示不成功，返回大于等于零的值为记录集记录数。
        ///当设置入参时：
        ///将当前记录集设置为由result_name指定的记录集，
        ///如果指的记录集存在，则改变当前记录集为存在的记录集，
        ///其中有个特殊的记录集Parameters, 它是个参数集，没有记录行，其他都有记录行，通过nextrow, prevrow, firstrow, lastrow。
        ///返回－1表示不成功，返回大于等于零的值为记录集记录数。
        /// </summary>
        /// <param name="hInterface">函数newinterface()或者newinterfacewithinit的返回值</param>
        /// <param name="result_name"></param>
        /// <returns></returns>
        [DllImport("InterfaceHN.dll", EntryPoint = "setresultset")]
        public static extern int SetResultset(int hInterface, StringBuilder result_name);

        /// <summary>
        /// 跳到结果集后一行记录，返回－1表示调用不成功，返回大于零表示调用成功，同时此值为当前的行号。
        /// 参数p_inter为函数newinterface()或者newinterfacewithinit的返回值。
        /// </summary>
        /// <param name="hInterface">参数p_inter为函数newinterface()或者newinterfacewithinit的返回值</param>
        /// <returns></returns>
        [DllImport("InterfaceHN.dll", EntryPoint = "nextrow")]
        public static extern int NextRow(int hInterface);

        /// <summary>
        /// 跳到结果集前一行记录，同时此值为当前的行号。
        /// </summary>
        /// <param name="hInterface">函数newinterface()或者newinterfacewithinit的返回值</param>
        /// <returns>返回－1表示调用不成功，返回大于零表示调用成功</returns>
        [DllImport("InterfaceHN.dll", EntryPoint = "prevrow")]
        public static extern int PrevRow(int hInterface);

        /// <summary>
        /// 跳到结果集第一行记录，返回－1表示调用不成功，返回1表示调 用成功。
        /// </summary>
        /// <param name="hInterface">函数newinterface()或者newinterfacewithinit的返回值</param>
        /// <returns></returns>
        [DllImport("InterfaceHN.dll", EntryPoint = "firstrow")]
        public static extern int FirstRow(int hInterface);

        /// <summary>
        /// 跳到结果集最后一行记录，返回－1表示调用不成功，返回大于零表示为当前记录集记录数。
        /// </summary>
        /// <param name="hInterface">函数newinterface()或者newinterfacewithinit的返回值</param>
        /// <returns></returns>
        [DllImport("InterfaceHN.dll", EntryPoint = "lastrow")]
        public static extern int LastRow(int hInterface);

        /// <summary>
        /// 该函数用来从接口取得返回的参数值。
        /// 返回值小于零, 表示没有Get成功，返回大于零表示为当前记录集的第几条记录。
        /// 用getmessage可以取得最近一次出错的错误信息。
        /// </summary>
        /// <param name="hInterface">函数newinterface()或者newinterfacewithinit的返回值</param>
        /// <param name="p_name">需要接口返回的字段名，需要用小写表示</param>
        /// <param name="p_value">接口返回的数值，必须在客户端分配足够大的内存，长度单位为sizeof(char)。</param>
        /// <returns></returns>
        [DllImport("InterfaceHN.dll", EntryPoint = "getbyname")]
        public static extern int GetbyName(int hInterface, string p_name, StringBuilder p_value);

        /// <summary>
        /// 该函数用来从接口取得返回的参数值。
        /// 返回值小于零, 表示没有调用成功，返回值大于零, 表示调用成功。
        /// 用getmessage可以取得最近一次出错的错误信息
        /// </summary>
        /// <param name="hInterface">函数newinterface()或者newinterfacewithinit的返回值。</param>
        /// <param name="index">需要接口返回的字段名的索引值。</param>
        /// <param name="p_name"></param>
        /// <param name="p_value">接口返回的数值，必须在客户端分配足够大的内存，长度单位为sizeof(char)。</param>
        /// <returns></returns>
        [DllImport("InterfaceHN.dll", EntryPoint = "getbyindex")]
        public static extern int GetbyIndex(int hInterface, int index, StringBuilder p_name, StringBuilder p_value);

        /// <summary>
        /// 该函数在所有函数出错时，调用它，将得到一个错误信息，错误信息存放在err指向的一片内存空间中，
        /// 当入参err为空指针(NULL)时，将返回message的长度。
        /// 调用此函数应保证err指向的内存有足够的长度存放返回的错误信息。函数返回值小于零时，函数执行不成功。
        /// </summary>
        /// <param name="hInterface">函数newinterface()或者newinterfacewithinit的返回值。</param>
        /// <param name="err"></param>
        /// <returns></returns>
        [DllImport("InterfaceHN.dll", EntryPoint = "getmessage")]
        public static extern int GetMessage(int hInterface, StringBuilder err);

        /// <summary>
        /// 该函数在所有函数出错时，调用它，将得到一个详细的错误信息，通过exception串返回，
        /// 当exception为NULL时，将返回message的长度。函数返回值小于零时，函数执行不成功。
        /// </summary>
        /// <param name="hInterface">函数newinterface()或者newinterfacewithinit的返回值。</param>
        /// <param name="exception"></param>
        /// <returns></returns>
        [DllImport("InterfaceHN.dll", EntryPoint = "getexception")]
        public static extern int GetException(int hInterface, StringBuilder exception);

        /// <summary>
        /// 该函数用来从接口取得第index的记录集名。返回值小于零, 表示没有成功，返回值大于零, 表示调用成功。
        /// 用getmessage可以取得最近一次出错的错误信息。
        /// </summary>
        /// <param name="hInterface">函数newinterface()或者newinterfacewithinit的返回值。</param>
        /// <param name="index"></param>
        /// <param name="resultname"></param>
        /// <returns></returns>
        [DllImport("InterfaceHN.dll", EntryPoint = "getresultnamebyindex")]
        public static extern int GetResultNamebyIndex(int hInterface, int index, StringBuilder resultname);

        /// <summary>
        /// 该函数用来从接口取得返回的当前记录集的记录行数。返回值小于零, 表示没有Get成功，返回值大于零, 表示当前记录集的记录行数。
        /// </summary>
        /// <param name="hInterface">函数newinterface()或者newinterfacewithinit的返回值。</param>
        /// <returns></returns>
        [DllImport("InterfaceHN.dll", EntryPoint = "getrowcount")]
        public static extern int GetRowCount(int hInterface);

        /// <summary>
        /// 该函数用来设置IC卡设备的串口号。返回值小于零, 表示没有成功，返回值大于等于零, 表示调用成功。
        /// </summary>
        /// <param name="hInterface">函数newinterface()或者newinterfacewithinit的返回值。</param>
        /// <param name="comm">与IC卡连接的串口号，com1表示1，com2表示2…。</param>
        /// <returns></returns>
        [DllImport("InterfaceHN.dll", EntryPoint = "set_ic_commport")]
        public static extern int Set_IC_Commport(int hInterface, int comm);

        /// <summary>
        /// 该函数用来将数据按base64格式编码；返回值小于零, 表示没有成功，返回值大于等于零, 表示为编码后的字节数。
        /// </summary>
        /// <param name="pSrc">源数据</param>
        /// <param name="nSize">源数据长度</param>
        /// <param name="pDest">编码后的数据</param>
        /// <returns></returns>
        [DllImport("InterfaceHN.dll", EntryPoint = "Encode64")]
        public static extern int encode64(string pSrc, int nSize, StringBuilder pDest);

        /// <summary>
        /// 该函数用来将数据按base64格式解码；返回值小于零, 表示没有成功，返回值大于等于零, 表示为解码后的字节数。
        /// </summary>
        /// <param name="pSrc">源数据</param>
        /// <param name="nSize">源数据长度</param>
        /// <param name="pDest">解码后的数据</param>
        /// <returns></returns>
        [DllImport("InterfaceHN.dll", EntryPoint = "Decode64")]
        public static extern int decode64(string pSrc, int nSize, StringBuilder pDest);

        /// <summary>
        /// 该函数用来将数据按base64格式编码时，用源数据长度来获得编码后的数据长度；
        /// 返回值小于零, 表示没有成功，返回值大于等于零, 表示为编码后的字节数。
        /// </summary>
        /// <param name="nSize">参数nSize为源数据长度。</param>
        /// <returns></returns>
        [DllImport("InterfaceHN.dll", EntryPoint = "encodesize")]
        public static extern int EncodeSize(int nSize);

        /// <summary>
        /// 该函数用来将数据按base64格式解码时，用源数据长度来获得解码后的数据长度；
        /// 返回值小于零, 表示没有成功，返回值大于等于零, 表示为解码后的字节数。参数nSize为源数据长度。
        /// </summary>
        /// <param name="nSize">参数nSize为源数据长度。</param>
        /// <returns></returns>
        [DllImport("InterfaceHN.dll", EntryPoint = "decodesize")]
        public static extern int DecodeSize(int nSize);

        /// <summary>
        /// 该函数用来将数据按base64格式解码，并将解码后的数据存到filename文件里；
        /// 返回值小于零, 表示没有成功，返回值大于等于零, 表示为解码后的字节数。
        /// </summary>
        /// <param name="pSrc">源数据</param>
        /// <param name="nSize">源数据长度</param>
        /// <param name="filename">解码后的数据要保存的文件名</param>
        /// <returns></returns>
        [DllImport("InterfaceHN.dll", EntryPoint = "decode64_tofile")]
        public static extern int Decode64_ToFile(string pSrc, int nSize, StringBuilder filename);

        /// <summary>
        /// 该函数用来设置接口的运行模式，当flag为1时将产生调试信息并且写入指定目录direct下的日志文件中。
        /// 返回值小于零, 表示没有成功，返回值大于等于零, 表示成功。
        /// </summary>
        /// <param name="hInterface">函数newinterface()或者newinterfacewithinit的返回值。</param>
        /// <param name="flag">调试标志，0表示不作调试，其它为可调试</param>
        /// <param name="direct">存放调试信息日志文件的目录，注意此目录必须是存在的</param>
        /// <returns></returns>
        [DllImport("InterfaceHN.dll", EntryPoint = "setdebug")]
        public static extern int SetDebug(int hInterface, int flag, string direct);

        [DllImport("InterfaceHN.dll", EntryPoint = "getinputparam")]
        public static extern int getinputparam(int hInterface, StringBuilder xml);

        #endregion 新版

        #endregion ...新版接口函数原型....
    }
}
