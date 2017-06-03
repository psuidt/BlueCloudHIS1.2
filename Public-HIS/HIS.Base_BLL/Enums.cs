namespace HIS.Base_BLL.Enums
{
    /// <summary>
    /// 匹配种类
    /// </summary>
    public enum MatchClass
    {
        药品匹配 = 0,
        项目匹配 = 1,
        疾病匹配 = 2
    }

    public enum ControlType
    {
        TextBox = 0,
        ComboBox = 1,
        CheckBox =2
    }

    public enum FIELD_DB_TYPE
    {
        字符 = 0,
        数字 = 1,
        日期 = 2
        
    }
    /// <summary>
    /// 字段标记类型
    /// </summary>
    public enum FIELD_MARK_TYPE
    {
        无 = 0,
        名称 = 1,
        拼音码 = 2,
        五笔码 = 3
    }

    public enum ParameterCatalog
    {
        门诊经管,
        门诊医生站,
        住院经管,
        住院医生站,
        住院护士站,
        药品管理
    }

    /// <summary>
    /// 舍入方式
    /// </summary>
    public enum RoundType
    {
        四舍五入 = 0,
        逢分进位 = 1
    }
    /// <summary>
    /// 结算方式
    /// </summary>
    public enum ChargeType
    {
        一张处方一次结算 = 0,
        多张处方一次结算 = 1
    }

    /// <summary>
    /// 发票格式
    /// </summary>
    public enum InvoiceStyle
    {
        广东省,
        湖南省
    }
}