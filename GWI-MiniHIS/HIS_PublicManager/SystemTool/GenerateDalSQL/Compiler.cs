using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Diagnostics;

namespace HIS_PublicManager.SystemTool.GenerateDalSQL
{
    public class Compiler
    {

        public static string CpDll = null;
        public static List<string> cplist = new List<string>();

        public static void CompilerCode(string Code)
        {
            StringBuilder DalCode = new StringBuilder();

            DalCode.Append("using System;");
            DalCode.Append("using HIS.BLL;");
            DalCode.Append("using HIS.SYSTEM.Core;");
            DalCode.Append("using HIS.SYSTEM.DatabaseAccessLayer;");
            DalCode.Append("using HIS.SYSTEM.PubicBaseClasses;");
            DalCode.Append("public class ClassDal:IDalSQL{");
           

            DalCode.Append("public string GetDebugSQL(){");
            DalCode.Append("RelationalDatabase oleDb = null;");
            DalCode.Append("RelationalDatabase _OleDB = null;");
            DalCode.Append("EntityConfig.BindConfig_DAL();");
            DalCode.Append("oleDb = new OleDB();");
            DalCode.Append("_OleDB = oleDb;");
            DalCode.Append(Code);

            DalCode.Append("return strsql;}");
            DalCode.Append("public string GetReleaseSQL(){");
            DalCode.Append("RelationalDatabase oleDb = null;");
            DalCode.Append("RelationalDatabase _OleDB = null;");
            DalCode.Append("EntityConfig.BindConfig();");
            DalCode.Append("oleDb = new OleDB();");

            DalCode.Append(" _OleDB = oleDb;");
            DalCode.Append(Code);
            DalCode.Append("return strsql;}}");
            

            #region 编译

            CSharpCodeProvider codeProvider = new CSharpCodeProvider();

            // For Visual Basic Compiler try this :
            //Microsoft.VisualBasic.VBCodeProvider

            ICodeCompiler compiler = codeProvider.CreateCompiler();
            CompilerParameters parameters = new CompilerParameters();

            parameters.GenerateExecutable = false;

            CpDll= "DalSQL" + Guid.NewGuid().ToString();

            parameters.OutputAssembly = CpDll+".dll";

            cplist.Add(CpDll + ".dll");


            //parameters.MainClass = mainClass.Text.ToString();

            parameters.IncludeDebugInformation = false;

            // Add available assemblies - this should be enough for the simplest
            // applications.
            foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                parameters.ReferencedAssemblies.Add(asm.Location);
            }
            //parameters.ReferencedAssemblies.Add(@"c:\windows\assembly\gac\system\1.0.5000.0__b77a5c561934e089\System.Data.dll");
            parameters.ReferencedAssemblies.Add("HIS.System.dll");

            parameters.ReferencedAssemblies.Add("HIS.Entity.dll");
            //parameters.ReferencedAssemblies.Add("System.Xml.dll");
            //parameters.ReferencedAssemblies.Add("System.Drawing.dll");

            //String code = textBox1.Text.ToString();
            //System.Windows.Forms.MessageBox.Show(this, code);

            CompilerResults results = compiler.CompileAssemblyFromSource(parameters, DalCode.ToString());
            //string[] str = { "DataDeCode.cs", "ChangeDataXML.cs", "PublicClass.cs", "AssemblyInfo.cs" };

            //CompilerResults results = compiler.CompileAssemblyFromFileBatch(parameters, str);
            //rtb.Text = rtb.Text + "正在生成文件 DDC.dll ....\n";
            if (results.Errors.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < results.Errors.Count; i++)
                {
                    sb.Append(results.Errors[i].ErrorText+"\n");
                }

                throw new Exception("编译出错！\n" + sb.ToString());
            }
           
            #endregion
        }
    }
}
