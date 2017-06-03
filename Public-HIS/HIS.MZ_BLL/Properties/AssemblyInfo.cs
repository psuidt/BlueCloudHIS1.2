using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的常规信息通过下列属性集
// 控制。更改这些属性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("02门诊经管")]
[assembly: AssemblyDescription("最后修改日期2010-4-27")]
[assembly: AssemblyConfiguration( "" )]
[assembly: AssemblyCompany("长城医疗")]
[assembly: AssemblyProduct("02门诊经管")]
[assembly: AssemblyCopyright("Copyright © 长城医疗 2008")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
 
// 将 ComVisible 设置为 false 使此程序集中的类型
// 对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型，
// 则将该类型上的 ComVisible 属性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("3ec5b132-c660-4674-96bf-55e7aef267cc")]

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
[assembly: AssemblyVersion("1.2.0.3")]
[assembly: AssemblyFileVersion("1.2.0.3")]
//修改记录
//修改时间：2010-4-19
//发布版本：1.0.0.2
//修改内容：门诊病人费用查询增加医生、科室、收费员查询条件
//          主要修改文件:PatientFeeReport.cs
//                       FrmPatientFeeReport.cs


//修改时间：2010-4-27
//发布版本：1.0.0.3
//修改内容：门诊收费发票打印增加参数控制选择格式，增加了湖南省发票格式
//          主要修改文件:Enum.cs


//修改时间：2010-5-20
//发布版本：1.0.0.4
//修改内容：参数统一修改，实体改动。主要修改文件：OPDParamter by heyan
//           
//修改时间：2010-5-24 20100524.1.01 检验费打印明细
//发布版本：1.0.0.5
//修改内容：门诊收费发票打印，检验费打印明细 主要修改文件：mz_dal Invoice by heyan

//修改时间：2010-5-28 20100528.1.01 门诊票据查询
//发布版本：1.0.0.6
//修改内容：由于修改了mz_dal Invoice ，导致会出现相同的费用项 主要修改文件FrmInvoiceQuery by heyan
