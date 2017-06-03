using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.MedicalConfir_BLL
{
    public enum ConfirType
    {
        门诊,
        住院
    }

    partial class ConfirFactory
    {       
    
        private static ConfirCenter ConfirCenter;
        public static ConfirCenter GetConfirType(ConfirType Confirtype)
        {
            switch (Confirtype)
            {
                case ConfirType.门诊:
                    ConfirCenter = new MzConfir(); break;
                case ConfirType.住院:
                    ConfirCenter = new ZyConfir(); break;
                default: return null;
            }
            return ConfirCenter;
        }
    }
}
