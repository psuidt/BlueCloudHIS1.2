using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的常规信息通过下列属性集
// 控制。更改这些属性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle( "基础数据" )]
[assembly: AssemblyDescription( "最后修改日期2010-4-27" )]
[assembly: AssemblyConfiguration( "" )]
[assembly: AssemblyCompany( "" )]
[assembly: AssemblyProduct("基础数据")]
[assembly: AssemblyCopyright( "长城医疗" )]
[assembly: AssemblyTrademark( "" )]
[assembly: AssemblyCulture( "" )]

// 将 ComVisible 设置为 false 使此程序集中的类型
// 对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型，
// 则将该类型上的 ComVisible 属性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("160cf15a-5c53-443a-a00d-de5ca22d6f8d")]

// 程序集的版本信息由下面四个值组成:
//
//      主版本
//      次版本 
//      内部版本号
//      修订号
//
// 可以指定所有这些值，也可以使用“内部版本号”和“修订号”的默认值，
// 方法是按如下所示使用“*”:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.2.0.0")]
[assembly: AssemblyFileVersion("1.2.0.0")]
//修改历史记录标记在方法或类之上
//[20100506.0.01] 时间.类型.序号
//类型 [0 BUG] [1 需求] [2 优化] 
/*
 * [BUG]
 * 2010-05-24 门诊经管014参数备注，初始化设置相反了 修改了Parameters.xml

 * 2010-06-03 组合项目增加明细时，名称为空时，数据库里会增加一条空的记录 update by heyan
 * 
 * 
 * [需求]
 * 2010-04-26 增加参数021用于控制发票打印输出时需要使用到的格式,枚举定义增加InvoiceStyle枚举 update by heyan

 * 
 * [优化]
 * 20100517.2.01 住院医生站参数设置修改（科室和药房对应关系，增加006参数） update by heyan
 * 20100519.2.02 参加参数访问类 update by heyan
 * 20100604.2.03 组合项目应用到医嘱项目时，组合项目明细也自动应用。update by heyan
 * 20100604.2.04 组合项目保存时，项目自动刷新，update by heyan
*/


