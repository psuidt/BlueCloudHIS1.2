using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
using HIS.SYSTEM.PubicBaseClasses;

namespace TownShipHIS
{
    public class TownShipHIS
    {
        
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                switch (args[0].Trim())
                {
                    case "1":
                        EntityConfig.DbType = DatabaseType.MsAccess;
                        break;
                    case "2":
                        break;
                    default:
                        break;
                }
            }
            else
            {
                EntityConfig.DbType = DatabaseType.IbmDb2;
            }
            GWMHISFrame.FrmMdiMain.Main();
        }
    }
}
