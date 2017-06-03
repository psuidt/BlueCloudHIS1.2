using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.MediInsInterface_BLL.MediInsInterface.matchInterface
{
    //[20100517.1.02]
    public class matchFactory
    {
        public static ImatchInterface Create(string type)
        {
            try
            {
                ImatchInterface imatch=null;
                switch (type)
                {
                    case "Nccm":
                        imatch = new matchNccmInterface();
                        break;
                    case "CxHn":
                        imatch = new matchCxNhInterface();
                        break;
                    case "Hygeia":
                        imatch = new matchHygeiaInterface();
                        break;
                }
                return imatch;
            }
            catch
            {
                throw new Exception("接口调用失败!");
            }
        }
    }
}
