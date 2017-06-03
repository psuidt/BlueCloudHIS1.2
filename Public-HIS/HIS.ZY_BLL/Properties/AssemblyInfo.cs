using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的常规信息通过下列属性集
// 控制。更改这些属性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("03住院经管")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("长城医疗")]
[assembly: AssemblyProduct("03住院经管")]
[assembly: AssemblyCopyright("Copyright © 长城医疗 2008")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 使此程序集中的类型
// 对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型，
// 则将该类型上的 ComVisible 属性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("4e58be2e-40c0-4b86-9921-5f37c0453cda")]

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
[assembly: AssemblyVersion("1.2.0.14")]
[assembly: AssemblyFileVersion("1.2.0.14")]

//修改历史记录标记在方法或类之上
//[20100506.0.01] 时间.类型.序号
//类型 [0 BUG] [1 需求] [2 优化] 
/*
 * [BUG]
 * zenghao [20100506.0.01] 输入一个错误住院号后，输入正确住院号也提示“未将对象引用到实例”
 * zenghao [20100526.0.02] 划价记账开发科室改为当前登陆科室ID
 * zenghao [20100531.0.03]   MESSAGETYPE IS '消息类型(0.长期，1.临时)',
                             STATTYPE IS '0非口服或退药1口服2手术'
 *                          手术室统领药品不显示，过滤条件错误
 * zenghao [20100603.0.04] 费用清单打昨天显示昨天的余额,不显示当前余额
 * 
 * zenghao [20100611.0.05] 取消入院在取消床位后能通过
 *                         预交金打印与发票打印显示的科室都改为当前科室
 *                         
 * zenghao [20100617.0.06] 预交金列表没有及时刷新，导致出院病人也能收取预交金
 * 修改思路：在逻辑层保存的时候再一次判断是否已经出院。
 * 
 * zenghao [20100628.0.07] 根据住院号检索病人列表除开取消入院的病人（pattype<>'6'）
 * 
 * 
 * [需求]
 * zenghao [20100506.1.01] 交款表汇总需要指定到单个交款员。
 * 
 * zenhgao [20100513.1.02] 划价记账修改为手术费用补录的功能。
 * 修改思路：添加了一手术室使用菜单
 * 
 * zenghao [20100514.1.03] 冲账界面的修改，手术室只能冲自己的费用
 * 
 * zenghao [20100514.1.04] 药品统领，手术室统领特殊处理,通过构造函数
 * 修改思路：添加了一手术室使用菜单
 * 
 * 
 * zenghao [20100518.1.05] 茶陵医院长信农合接口
 * 
 * zenghao [20100525.1.06] 药品统领禁用修改科室
 * 
 * zenghao [20100608.1.07] 药品统领界面单个药品显示明细
 * 
 * zenghao [20100610.1.08] 入院登记显示办理人名称
 * 
 * zenghao [20100610.1.09] 茶陵医院不需要提示重名病人历史信息，住院号不重用
 * 
 * zenghao [20100624.1.10] 费用清单只显示欠费病人
 * 
 * zenghao [20100624.1.11] 增加了一个药品请领的功能
 * 
 * zenghao [20100713.1.12] 交款表汇总打印功能
 * 
 * zenghao [20100714.1.13] 划价记账药品根据选择药房过滤
 * 
 * [优化]
 * zenghao [20100507.2.01] 住院收入统计报表的速度问题？
 * 原因：operationList.zyPresorderList = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetListArray(strWhere); 有十几万条记录转换为List对象很慢。
 * 改进思路：用DataTable代替list
 * 
 * zenghao [20100508.2.02] 把住院结算界面改为控制器形式。
 * 原因：维护起来不清晰
 * 改进思路：
 * 1.添加控制器接口文件IFrmCostView.cs ,控制器文件FrmCostController.cs
 * 2.把界面FrmCost里面展示的数据都作为属性写入IFrmCostView，比如界面上显示病人的累计交费、累计记账等，我们可以在IFrmCostView建两个string类型的属性，
 *   当由于这几个值的展示都是统一一起变化的，所以我们用一个结构把它们封装起来的化思路就会更清晰，所以我们就建立了属性PatFee patFee { set; }，
 *   属性的化应该既有set还有get，我们这只是使用了set，因为我们只需要对界面上的值进行赋值展示而以，值并不会在界面上更改再传入后台，所以我们只需要set赋值就行。
 *   接口文件封装界面和控制器交互的数据和把界面上的某些功能方法传递给控制器。
 * 3.在FrmCostController控制器里添加一个公共的变量类型为IFrmCostView 接口，控制器调用逻辑层的对象给IFrmCostView接口属性赋值。
 *   控制器整合逻辑层对象的调用关系，响应界面的事件。
 *   
 * zenghao [20100510.2.03] 优化费用上传界面,采用控制器
 * 
 * zenghao [20100511.2.04] 优化入院登记控制器的对象管理
 * 原因：对象的创建很混乱，操作多了容易糊涂。
 * 改进思路：所有有控制器的功能模块，界面层代码不能出现new实例化对象，全放在控制器中创建。
 * 
 * zenghao [20100518.2.05] 农合接口统一
 * 
 * zenghao [20100611.2.06] 优化所有的数据访问的sql语句写法 全部移植到Dao层
 *
 * heyan 药品统领可以统领物资
 * heyan 住院发药接口，要根据发药科室过滤
 * heyan  费用清单显示和打印上病人当前科室显示不对
 * heyan 药品请领提示不对
 * 
 * zenghao [20101014.1.14] 添加担保需求
 * 
 * 
*/
