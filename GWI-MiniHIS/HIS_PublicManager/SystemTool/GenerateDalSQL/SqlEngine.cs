using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace HIS_PublicManager.SystemTool.SyntaxEngineClass
{
    /// <summary>   
    /// 
    /// 语法分析引擎基类 
    /// 
    /// ZswangY37 wjhu111#21cn.com 2007-03-17 尊重作者，转贴请注明出处  
    /// /// 日期:2007-03-17  
    /// /// 设计:ZswangY37  
    /// /// 支持:wjhu111#21cn.com  
    /// /// 感谢CSDN中的kissknife、chinnel提供改进意见 
    /// /// http://community.csdn.net/Expert/TopicView.asp?id=5400165    
    /// </summary>  
    class SyntaxEngine
    {
        /// <summary>      
        /// /// 语法项    
        /// /// </summary>    
        public class SyntaxItem
        {
            private string FPattern; // 正则表达式        
            private RegexOptions FOptions; // 正则表达式附加选项        
            private string FName; // 语法名称      
            private int FIndex; // 序号          
            public string Pattern
            {
                get
                {
                    return FPattern;
                }
            } // 正则表达式   
            public RegexOptions Options
            {
                get
                {
                    return FOptions;
                }
            } // 正则表达式附加选项   
            public string Name
            {
                get
                {
                    return FName;
                }
            } // 名称     
            public int Index
            {
                get
                {
                    return FIndex;
                }
            } // 序号       
            public SyntaxItem(string APattern, RegexOptions AOptions,
                string AName, int AIndex)
            {
                FPattern = APattern;
                FOptions = AOptions;
                FName = AName;
                FIndex = AIndex;
            }
        }
        /// <summary>        /// 语法分析返回项        /// </summary>    
        public class AnalyzeReslut
        {
            private SyntaxItem FItem; // 所属语法项          
            private string FBlock; // 文字块           
            public SyntaxItem Item { get { return FItem; } }
            public string Block { get { return FBlock; } }
            public AnalyzeReslut(SyntaxItem AItem, string ABlock)
            {
                FItem = AItem;
                FBlock = ABlock;
            }
        }
        public class AnalyzeResultSqlStruct
        {
            private string _TableName;
            public string TableName
            {
                get
                {
                    return _TableName;
                }
                set
                {
                    _TableName = value;
                }
            }
            private string _TableWhere;
            public string TableWhere
            {
                get
                {
                    return _TableWhere;
                }
                set
                {
                    _TableWhere = value;
                }
            } private List<string> _TableColumns = new List<string>();
            public List<string> TableColumns
            {
                get
                {
                    return _TableColumns;
                }
                set { _TableColumns = value; }
            }
        }
        private List<SyntaxItem> FSyntaxItems = new List<SyntaxItem>();
        private List<AnalyzeReslut> FAnalyzeResluts = new List<AnalyzeReslut>();
        public List<SyntaxItem> SyntaxItems
        {
            get
            {
                return FSyntaxItems;
            }
        }
        public List<AnalyzeReslut> AnalyzeResluts
        {
            get
            {
                return FAnalyzeResluts;
            }
        }
        /// <summary>  
        /// /// 进行语法分析 
        /// /// </summary>   
        /// /// <param name="ACode">所分析的代码</param>    
        /// /// <returns>返回分析是否成功</returns>       
        public virtual bool Analyze(string ACode)
        {
            if (FSyntaxItems.Count <= 0)
                return false;
            if (ACode == null)
                return false;
            AnalyzeResluts.Clear();
            string vCode = ACode;
            bool vFind = true;
            while (vFind && (vCode.Length > 0))
            {
                vFind = false;
                foreach (SyntaxItem vSyntaxItem in FSyntaxItems)
                {
                    if (Regex.IsMatch(vCode, vSyntaxItem.Pattern, vSyntaxItem.Options))
                    {
                        AnalyzeResluts.Add(new AnalyzeReslut(vSyntaxItem, Regex.Match(vCode, vSyntaxItem.Pattern, vSyntaxItem.Options).Value));
                        vCode = Regex.Replace(vCode, vSyntaxItem.Pattern, "", vSyntaxItem.Options);
                        vFind = true;
                        break;
                    }
                }
            }
            return true;
        }
    }

    class TSqlEngine : SyntaxEngine
    {
        public List<SyntaxEngine.AnalyzeResultSqlStruct> AnalyzeTSql(string TSqlCode)
        {
            List<AnalyzeResultSqlStruct> retSql = new List<AnalyzeResultSqlStruct>();
            if (this.Analyze(TSqlCode) == false) return null;
            List<AnalyzeReslut> ar = this.AnalyzeResluts;
            for (int i = 0; i < ar.Count; i++)
            {
                if (ar[i].Item.Name == "关键字" && ar[i].Block == "select")
                {
                    if (CheckSelectInSegment(ar, i) == true) continue;
                    for (int j = i; j < ar.Count; j++)
                    {
                        if (ar[j].Item.Name == "关键字" && ar[j].Block == "from")
                        {
                            if (CheckSelectIsLet(ar, i, j))
                            {
                                i = j + 1;
                                break;
                            } int wordIndex = LetTableInfo(ref retSql, ar, i, j);
                            if
                                (wordIndex >= j)
                            {
                                i = wordIndex;
                                break;
                            }
                        }
                    }
                }
            } return retSql;
        }
        private int LetTableInfo(ref List<AnalyzeResultSqlStruct> retSql, List<AnalyzeReslut> aResult, int SelectIndex, int FromIndex)
        {
            AnalyzeResultSqlStruct sqlStu = new AnalyzeResultSqlStruct();
            int endIndex = FromIndex;
            for (int k = FromIndex + 1; k < aResult.Count; k++)
            {
                if (aResult[k].Item.Name == "标识符" && string.IsNullOrEmpty(sqlStu.TableName))
                {
                    sqlStu.TableName = aResult[k].Block;
                }
                else if (aResult[k].Item.Name == "关键字")
                {
                    if (aResult[k].Block.ToLower() == "where")
                    {
                        for (int i = k + 1; i < aResult.Count; i++)
                        {
                            if ((aResult[i].Item.Name == "关键字") && aResult[i].Block.ToLower() != "and" && aResult[i].Block != "group")
                            {
                                endIndex = i - 1;
                                break;
                            }
                            else
                            {
                                sqlStu.TableWhere += aResult[i].Block;
                            }
                        }
                    }
                    else
                    {
                        endIndex = FromIndex + 1;
                    }
                }
                if (endIndex > FromIndex)
                    break;
            }
            string strCol = "";
            for (int i = SelectIndex + 1; i <= FromIndex; i++)
            {
                if (i == FromIndex)
                {
                    sqlStu.TableColumns.Add(strCol);
                    break;
                } if (aResult[i].Item.Name == "标点符号" && aResult[i].Block == ",")
                {
                    sqlStu.TableColumns.Add(strCol);
                    strCol = "";
                }
                else
                {
                    strCol += aResult[i].Block;
                }
            }
            retSql.Add(sqlStu);
            return endIndex;
        }
        private bool CheckSelectIsLet(List<AnalyzeReslut> aResult, int SelectIndex, int FromIndex)
        {
            for (int i = SelectIndex; i < FromIndex; i++)
            {
                if (aResult[i].Item.Name == "标点符号" && aResult[i].Block == "=")
                {
                    return true;
                }
            } return false;
        }
        private bool CheckSelectInSegment(List<AnalyzeReslut> aResult, int i)
        {
            return false;
        }
        public TSqlEngine()
        {
            SyntaxItems.Add(new SyntaxItem(@"^\s+", RegexOptions.None, "空白", SyntaxItems.Count));
            SyntaxItems.Add(new SyntaxItem(@"^--[^\n]*[\n]?", RegexOptions.None, "单行注释", SyntaxItems.Count));
            SyntaxItems.Add(new SyntaxItem(@"^\/\*.*?\*\/", RegexOptions.None, "多行注释", SyntaxItems.Count));
            SyntaxItems.Add(new SyntaxItem(@"^(ABSOLUTE|ACTION|ADA|ADD|ADMIN|AFTER|AGGREGATE|ALIAS|ALL|ALLOCATE|ALTER|AND|ANY|ARE|ARRAY|AS|ASC|ASSERTION|AT|AUTHORIZATION|AVG|BACKUP|BEFORE|BEGIN|BETWEEN|BINARY|BIT|BIT_LENGTH|BLOB|BOOLEAN|BOTH|BREADTH|BREAK|BROWSE|BULK|BY|CALL|CASCADE|CASCADED|CASE|CAST|CATALOG|CHAR|CHAR_LENGTH|CHARACTER|CHARACTER_LENGTH|CHECK|CHECKPOINT|CLASS|CLOB|CLOSE|CLUSTERED|COALESCE|COLLATE|COLLATION|COLUMN|COMMIT|COMPLETION|COMPUTE|CONNECT|CONNECTION|CONSTRAINT|CONSTRAINTS|CONSTRUCTOR|CONTAINS|CONTAINSTABLE|CONTINUE|CONVERT|CORRESPONDING|COUNT|CREATE|CROSS|CUBE|CURRENT|CURRENT_DATE|CURRENT_PATH|CURRENT_ROLE|CURRENT_TIME|CURRENT_TIMESTAMP|CURRENT_USER|CURSOR|CYCLE|DATA|DATABASE|DATE|DAY|DBCC|DEALLOCATE|DEC|DECIMAL|DECLARE|DEFAULT|DEFERRABLE|DEFERRED|DELETE|DENY|DEPTH|DEREF|DESC|DESCRIBE|DESCRIPTOR|DESTROY|DESTRUCTOR|DETERMINISTIC|DIAGNOSTICS|DICTIONARY|ISCONNECT|DISK|DISTINCT|DISTRIBUTED|DOMAIN|DOUBLE|DROP|DUMMY|DUMP|DYNAMIC|EACH|ELSE|END|END-EXEC|EQUALS|ERRLVL|ESCAPE|EVERY|EXCEPT|EXCEPTION|EXEC|EXECUTE|EXISTS|EXIT|EXTERNAL|EXTRACT|FALSE|FETCH|FILE|FILLFACTOR|FIRST|FLOAT|FOR|FOREIGN|FORTRAN|FOUND|FREE|FREETEXT|FREETEXTTABLE|FROM|FULL|FULLTEXTTABLE|FUNCTION|GENERAL|GET|GLOBAL|GO|GOTO|GRANT|GROUP|GROUPING|HAVING|HOLDLOCK|HOST|HOUR|IDENTITY|IDENTITY_INSERT|IDENTITYCOL|IF|IGNORE|IMMEDIATE|IN|INCLUDE|INDEX|INDICATOR|INITIALIZE|INITIALLY|INNER|INOUT|INPUT|INSENSITIVE|INSERT|INT|INTEGER|INTERSECT|INTERVAL|INTO|IS|ISOLATION|ITERATE|JOIN|KEY|KILL|LANGUAGE|LARGE|LAST|LATERAL|LEADING|LEFT|LESS|LEVEL|LIKE|LIMIT|LINENO|LOAD|LOCAL|LOCALTIME|LOCALTIMESTAMP|LOCATOR|LOWER|MAP|MATCH|MAX|MIN|MINUTE|MODIFIES|MODIFY|MODULE|MONTH|NAMES|NATIONAL|NATURAL|NCHAR|NCLOB|W|NEXT|NO|NOCHECK|NONCLUSTERED|NONE|NOT|NULL|NULLIF|NUMERIC|OBJECT|OCTET_LENGTH|OF|OFF|OFFSETS|OLD|ON|ONLY|OPEN|OPENDATASOURCE|OPENQUERY|OPENROWSET|OPENXML|OPERATION|OPTION|OR|ORDER|ORDINALITY|OUT|OUTER|OUTPUT|OVER|OVERLAPS|PAD|PARAMETER|PARAMETERS|PARTIAL|PASCAL|PATH|PERCENT|PLAN|POSITION|POSTFIX|PRECISION|PREFIX|PREORDER|PREPARE|PRESERVE|PRIMARY|PRINT|PRIOR|PRIVILEGES|PROC|PROCEDURE|PUBLIC|RAISERROR|READ|READS|READTEXT|REAL|RECONFIGURE|RECURSIVE|REF|REFERENCES|REFERENCING|RELATIVE|REPLICATION|RESTORE|RESTRICT|RESULT|RETURN|RETURNS|REVOKE|RIGHT|ROLE|ROLLBACK|ROLLUP|ROUTINE|ROW|ROWCOUNT|ROWGUIDCOL|ROWS|RULE|SAVE|SAVEPOINT|SCHEMA|SCOPE|SCROLL|SEARCH|SECOND|SECTION|SELECT|SEQUENCE|SESSION|SESSION_USER|SET|SETS|SETUSER|SHUTDOWN|SIZE|SMALLINT|SOME|SPACE|SPECIFIC|SPECIFICTYPE|SQL|SQLCA|SQLCODE|SQLERROR|SQLEXCEPTION|SQLSTATE|SQLWARNING|START|STATE|STATEMENT|STATIC|STATISTICS|STRUCTURE|SUBSTRING|UM|SYSTEM_USER|TABLE|TEMPORARY|TERMINATE|TEXTSIZE|THAN|THEN|TIME|TIMESTAMP|TIMEZONE_HOUR|TIMEZONE_MINUTE|TO|TOP|TRAILING|TRAN|TRANSACTION|TRANSLATE|TRANSLATION|TREAT|TRIGGER|TRIM|TRUE|TRUNCATE|TSEQUAL|UNDER|UNION|UNIQUE|UNKNOWN|UNNEST|UPDATE|UPDATETEXT|UPPER|USAGE|USE|USER|USING|VALUE|VALUES|VARCHAR|VARIABLE|VARYING|VIEW|WAITFOR|WHEN|WHENEVER|WHERE|WHILE|WITH|WITHOUT|WORK|WRITE|WRITETEXT|YEAR|ZONE)\b", RegexOptions.IgnoreCase, "关键字", SyntaxItems.Count));
            SyntaxItems.Add(new SyntaxItem(@"^(\+\=|\-\=|\&\&|\|\||\/\=|\&\=|\%\=|\~|\!|\+\+|\-\-|" + @"\$|\%|\^|\&|\*|\(|\)|\+|\-|\=|\{|\}|\[|\]|\\|\;|\:|\<|\>|\?|\,|\.|\/)+", RegexOptions.None, "标点符号", SyntaxItems.Count));
            SyntaxItems.Add(new SyntaxItem(@"^(\d+(?!\.|x|e|d|m)u?)|^0x([\da-f]+(?!\.|x|m)u?)", RegexOptions.IgnoreCase, "整数", SyntaxItems.Count));
            SyntaxItems.Add(new SyntaxItem(@"^(\d+)?\.\d+((\+|\-)?e\d+)?(m|d|f)?|^\d+((\+|\-)?e\d+)?(m|d|f)", RegexOptions.IgnoreCase, "浮点数", SyntaxItems.Count));
            SyntaxItems.Add(new SyntaxItem(@"^'(('')*([^'])*)*'?", RegexOptions.None, "字符串", SyntaxItems.Count));
            SyntaxItems.Add(new SyntaxItem(@"^""([^""])*""|^\[([^\[^\]])*\]|^[^""^\[]\w*|^@@*\w+|^#\w+", RegexOptions.None, "标识符", SyntaxItems.Count));
        }
    }
    /// <summary>  
    /// /// C#语法分析引擎 
    /// /// ZswangY37 wjhu111#21cn.com 2007-03-17 尊重作者，转贴请注明出处    
    /// </summary>   
    class CSharpEngine : SyntaxEngine
    {
        public CSharpEngine() { SyntaxItems.Add(new SyntaxItem(@"^\s+", RegexOptions.None, "空白", SyntaxItems.Count)); SyntaxItems.Add(new SyntaxItem(@"^\/\/[^\n]*[\n]?", RegexOptions.None, "单行注释", SyntaxItems.Count)); SyntaxItems.Add(new SyntaxItem(@"^\/\*.*?\*\/", RegexOptions.None, "多行注释", SyntaxItems.Count)); SyntaxItems.Add(new SyntaxItem(@"^#\s*(define|elif|else|endif|endregion|" + @"error|if|line|pragma|region|undef|using|warning)\b[^\n]*[\n]?", RegexOptions.None, "指令", SyntaxItems.Count)); SyntaxItems.Add(new SyntaxItem(@"^(abstract|event|new|struct|as|explicit|" + @"null|switch|base|extern|object|this|bool|false|operator|throw|break|" + @"finally|out|true|byte|fixed|override|try|case|float|params|typeof|" + @"catch|for|private|uint|char|foreach|protected|ulong|checked|goto|" + @"public|unchecked|class|if|readonly|unsafe|const|implicit|ref|ushort|" + @"continue|in|return|using|decimal|int|sbyte|virtual|default|interface|" + @"sealed|volatile|delegate|internal|short|void|do|is|sizeof|while|" + @"double|lock|stackalloc|else|long|static|enum|namespace|string)\b", RegexOptions.None, "关键字", SyntaxItems.Count)); SyntaxItems.Add(new SyntaxItem(@"^(get|partial|set|value|where|yield)\b", RegexOptions.None, "上下文关键字", SyntaxItems.Count)); SyntaxItems.Add(new SyntaxItem(@"^(\+\=|\-\=|\&\&|\|\||\/\=|\&\=|\%\=|\~|\!|\+\+|\-\-|" + @"\#|\$|\%|\^|\&|\*|\(|\)|\+|\-|\=|\{|\}|\[|\]|\\|\;|\:|\<|\>|\?|\,|\.|\/)+", RegexOptions.None, "标点符号", SyntaxItems.Count)); SyntaxItems.Add(new SyntaxItem(@"^(\d+(?!\.|x|e|d|m)u?)|^0x([\da-f]+(?!\.|x|m)u?)", RegexOptions.IgnoreCase, "整数", SyntaxItems.Count)); SyntaxItems.Add(new SyntaxItem(@"^(\d+)?\.\d+((\+|\-)?e\d+)?(m|d|f)?|^\d+((\+|\-)?e\d+)?(m|d|f)", RegexOptions.IgnoreCase, "浮点数", SyntaxItems.Count)); SyntaxItems.Add(new SyntaxItem(@"^@""(("""")*([^""])*)*""|^""((\\\\)*(\\"")*(\\[a-z])*[^""^\\]*)*""", RegexOptions.None, "字符串", SyntaxItems.Count)); SyntaxItems.Add(new SyntaxItem(@"^\'(\\\')*[^\']*\'", RegexOptions.None, "字符", SyntaxItems.Count)); SyntaxItems.Add(new SyntaxItem(@"^\w*", RegexOptions.None, "标识符", SyntaxItems.Count)); }
        /// <summary>        /// 语法高亮引擎        /// ZswangY37 wjhu111#21cn.com 2007-03-17 尊重作者，转贴请注明出处        /// </summary>      
        class SyntaxHighlight
        {
            public class HighlightItem
            {
                private Color FForeColor; // 前景色            
                private bool FBold; // 是否加粗          
                private bool FItalic; // 是否斜体           
                private bool FUnderline; // 是否下划线          
                public Color ForeColor
                {
                    get
                    {
                        return FForeColor;
                    }
                } // 前景色       
                public bool Bold
                {
                    get
                    {
                        return FBold;
                    }
                } // 是否加粗          
                public bool Italic
                {
                    get
                    {
                        return FItalic;
                    }
                } // 是否斜体         
                public bool Underline
                {
                    get
                    {
                        return FUnderline;
                    }
                } // 是否下划线       
                public HighlightItem(Color AForeColor, bool ABold, bool AItalic, bool AUnderline)
                {
                    FForeColor = AForeColor; FBold = ABold; FItalic = AItalic; FUnderline = AUnderline;
                }
            }
            private List<SyntaxEngine.AnalyzeReslut> FAnalyzeResluts;
            private Font FDefaultFont;
            private List<HighlightItem> FHighlightItems = new List<HighlightItem>();
            public List<HighlightItem> HighlightItems
            {
                get
                {
                    return FHighlightItems;
                }
            }
            public SyntaxHighlight(SyntaxEngine ASyntaxEngine, Font ADefaultFont)
            {
                FAnalyzeResluts = ASyntaxEngine.AnalyzeResluts;
                FDefaultFont = ADefaultFont;
            }
            /// <summary>     
            /// /// 将文本中的RTF元素处理掉  
            /// /// </summary>        
            /// /// <param name="AText">输入的文本</param>      
            /// /// <returns>返回处理后的RTF文本</returns>      
            public string TextToRtf(string AText)
            {
                string Result = "";
                foreach (char vChar in AText)
                {
                    switch (vChar)
                    {
                        case '\\':
                            Result += @"\\";
                            break;
                        case '{':
                            Result += @"\{";
                            break;
                        case '}':
                            Result += @"\}";
                            break;
                        default:
                            if (vChar > (char)127)
                                Result += @"\u" + ((int)vChar).ToString() + "?";
                            else
                                Result += vChar; break;
                    }
                }
                return Result;
            }
            [DllImport("user32.dll")]
            private static extern uint GetKBCodePage();
            [DllImport("kernel32.dll")]
            private static extern ushort GetSystemDefaultLangID();
            /// <summary>        
            /// /// 将代码处理成RTF格式       
            /// /// </summary>        
            /// /// <returns>返回处理后的RTF文本</returns>  
            public string MakeRtf()
            {
                if (HighlightItems.Count <= 0)
                    return "";
                string Result = @"{\rtf1\ansi\ansicpg" + GetKBCodePage().ToString() + @"\deff0\deflang1033\deflangfe" + GetSystemDefaultLangID().ToString() + @"{\fonttbl{\f0\fmodern " + FDefaultFont.Name + ";}}\r\n";
                Result += @"{\colortbl ;";
                foreach (HighlightItem vHighlightItem in HighlightItems)
                    Result += string.Format(@"\red{0}\green{1}\blue{2};", vHighlightItem.ForeColor.R, vHighlightItem.ForeColor.G, vHighlightItem.ForeColor.B);
                Result += "}\r\n"; Result += @"\viewkind4\uc1\pard\f0\fs20" + "\r\n";
                bool vBold = false, vItalic = false, vUnderline = false;
                foreach (SyntaxEngine.AnalyzeReslut vAnalyzeReslut in FAnalyzeResluts)
                {
                    int i = vAnalyzeReslut.Item.Index;
                    if (i >= HighlightItems.Count)
                        i = 0;
                    if (vBold != HighlightItems[i].Bold)
                    {
                        if (HighlightItems[i].Bold)
                            Result += @"\b1";
                        else
                            Result += @"\b0";
                    } if (vItalic != HighlightItems[i].Italic)
                    {
                        if (HighlightItems[i].Italic)
                            Result += @"\i1";
                        else
                            Result += @"\i0";
                    } if (vItalic != HighlightItems[i].Underline)
                    {
                        if (HighlightItems[i].Underline)
                            Result += @"\ul1";
                        else
                            Result += @"\ul0";
                    }
                    Result += string.Format(@"\cf{0} ", i + 1);
                    vBold = HighlightItems[i].Bold;
                    vItalic = HighlightItems[i].Italic;
                    vUnderline = HighlightItems[i].Underline;
                    Result += TextToRtf(vAnalyzeReslut.Block).Replace("\r\n", "\r\n" + @"\par");
                }
                return Result + "}";
            }
            /// <summary>           
            /// /// 将文本中的HTML元素处理掉     
            /// /// </summary>            
            /// <param name="AText">输入的文本</param>      
            /// /// <returns>返回处理后的HTML文本</returns>       
            private string TextToHtml(string AText)
            {
                string Result = ""; foreach (char vChar in AText)
                {
                    switch (vChar)
                    {
                        case '&': Result += @"&amp;"; break;
                        case ' ': Result += @"&nbsp;"; break;
                        case '<': Result += @"&lt;"; break;
                        case '>': Result += @"&gt;"; break;
                        case '"': Result += @"&quot;"; break;
                        //case '\n':                 
                        //    Result += @"<br>";                    
                        //    break;         
                        default:
                            if (vChar > (char)127) Result += @"&#" + ((int)vChar).ToString() + ";"; else Result += vChar; break;
                    }
                } return Result;
            }
            /// <summary>          
            /// /// 将颜色处理为HTML表达的方式          
            /// /// </summary>         
            /// 
            /// /// <param name="AColor">输入的颜色</param>     
            /// /// <returns>返回HTML颜色表达式</returns>     
            private string ColorToHtml(Color AColor)
            {
                return string.Format("#{0:X2}{1:X2}{2:X2}", AColor.R, AColor.G, AColor.B);
            }
            /// <summary>        
            /// /// 将代码处理为HTML文本            /// </summary>       
            /// /// <returns>返回处理后的HTML文本</returns>          
            public string MakeHtml()
            {
                string Result = @"<code><pre style=""font-size:" + FDefaultFont.Size + @"pt;font-family:" + FDefaultFont.Name + @""">";
                foreach (SyntaxEngine.AnalyzeReslut vAnalyzeReslut in FAnalyzeResluts)
                {
                    int i = vAnalyzeReslut.Item.Index;
                    if (i >= HighlightItems.Count) i = 0;
                    string vLeft = string.Format(@"<span style=""color={0}"">", ColorToHtml(HighlightItems[i].ForeColor));
                    string vRight = "</span>";
                    if (HighlightItems[i].Bold)
                    {
                        vLeft += "<b>"; vRight = "</b>" + vRight;
                    }
                    if (HighlightItems[i].Italic)
                    {
                        vLeft += "<i>"; vRight = "</i>" + vRight;
                    }
                    if (HighlightItems[i].Underline)
                    {
                        vLeft += "<u>"; vRight = "</u>" + vRight;
                    }
                    Result += vLeft + TextToHtml(vAnalyzeReslut.Block) + vRight;
                }
                return Result + "</pre></code>";
            }
        }
        /// <summary>
        /// C#语法高亮引擎
        /// </summary>
        class CSharpHighlight : SyntaxHighlight
        {
            public CSharpHighlight(SyntaxEngine ASyntaxEngine, Font ADefaultFont)
                : base(ASyntaxEngine, ADefaultFont)
            {
                //空白              
                HighlightItems.Add(new HighlightItem(Color.White, false, false, false));                //单行注释        
                HighlightItems.Add(new HighlightItem(Color.Green, false, false, false));                //多行注释      
                HighlightItems.Add(new HighlightItem(Color.Green, false, false, false));                //指令         
                HighlightItems.Add(new HighlightItem(Color.Blue, false, false, false));                //关键字     
                HighlightItems.Add(new HighlightItem(Color.Black, true, false, false));                //上下文关键字      
                HighlightItems.Add(new HighlightItem(Color.Black, true, false, false));                //标点符号      
                HighlightItems.Add(new HighlightItem(Color.BlueViolet, false, false, false));                //整数     
                HighlightItems.Add(new HighlightItem(Color.Red, true, false, false));                //浮点数         
                HighlightItems.Add(new HighlightItem(Color.Red, true, false, false));                //字符串         
                HighlightItems.Add(new HighlightItem(Color.Maroon, false, false, false));                //字符           
                HighlightItems.Add(new HighlightItem(Color.Maroon, false, false, false));                //标识符        
                HighlightItems.Add(new HighlightItem(Color.Black, false, false, false));
            }
        }
    }
}

