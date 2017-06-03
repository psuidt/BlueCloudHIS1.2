using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的常规信息通过下列属性集
// 控制。更改这些属性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("HIS.ZYNurse_BLL")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("WwW.YlmF.CoM")]
[assembly: AssemblyProduct("HIS.ZYNurse_BLL")]
[assembly: AssemblyCopyright("Copyright © WwW.YlmF.CoM 2009")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 使此程序集中的类型
// 对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型，
// 则将该类型上的 ComVisible 属性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("07af884a-c3ff-4397-80d8-f1deb0efd55e")]

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
 * baoxinkai [20100520.1.01] 由住院护士站控制冲账，对原医嘱管理中的“冲正”按钮改为“费用查看”，对原费用冲正中
 * 的“冲正”“取消冲正”等按钮进行隐藏，实现护士只能查看费用情况，不能冲账。
 *
 * baoxinkai [20100520.0.01]
 * 账单补录中的账单发送键进行了屏蔽，账单发送键发送的账单不能实现记账功能，容易导致帐出错，先进行屏蔽，在账单
 * 补录后，在医嘱管理界中发送账单。
 * 
 * [需求]
 * 
 * [优化]
 * 20100520.2.01 参数统一修改 heyan
 * 物资修改 heyan
 * 
*/
