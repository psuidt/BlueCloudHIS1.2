using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.ZYDoc_BLL.MediApply
{
    partial class ApplyFactory
    {
        private static MediCenter medicenter;       
        public static  MediCenter GetApply(MediType meditype)
        {
            switch (meditype)
            {
                case MediType.检查:
                    medicenter = new CheckApply(); break;
                case MediType.检验:
                    medicenter = new TestApply(); break;
                case MediType.治疗:
                    medicenter=new CureApply(); break;
                default: return null;
            }
            return medicenter;
        }
    }
}
