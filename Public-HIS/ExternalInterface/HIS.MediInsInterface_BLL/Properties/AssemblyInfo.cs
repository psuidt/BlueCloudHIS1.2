using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的常规信息通过下列属性集
// 控制。更改这些属性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("医疗保险接口程序")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("长城医疗")]
[assembly: AssemblyProduct("医疗保险接口程序")]
[assembly: AssemblyCopyright("Copyright © 长城医疗 2010")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 使此程序集中的类型
// 对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型，
// 则将该类型上的 ComVisible 属性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("70271af9-ecb1-4c2e-abd5-218494374f45")]

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

/*
 * 创建人：曾浩
 * 创建时间：2010-05-19
 * 项目简介：
 * MediInsBLL           接口的逻辑目录
 *     DataMatch        目录匹配业务
 *     
 * MediInsInterface     系统接口目录（底层封装）
 *     CxNhSystem       长信农合系统接口
 *     NccmSystem       长城医疗农合系统接口
 *     matchInterface   目录匹配接口
 *     mzInterface      门诊接口
 *     zyInterface      住院接口
 * 
 * 
 * [BUG]
 * [20100617.0.01]
 * 住院费用上传的单价改为由金额除以数量得到
 * 
 * 
 * [需求]
 * [20100517.1.01] 
 * 新增内容：调试连通长信农合接口，并编写核心接口文件
 * [20100518.1.02]
 * 新增内容：编写匹配目录的接口文件
 * [20100519.1.03]
 * 新增内容：编写药品匹配目录下载的业务文件
 * [20100520.1.04]
 * 新增内容：编写了项目匹配和药品匹配的功能
 * [20100617.1.05]
 * 修改病人检索的方式、费用排序
 * 
 * [优化]
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */
