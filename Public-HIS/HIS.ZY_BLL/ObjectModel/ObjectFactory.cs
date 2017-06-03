using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.ZY_BLL.ObjectModel
{
    public class ObjectFactory
    {
        public static T GetObject<T>(Type t)
        {
            return (T)Activator.CreateInstance(t);
        }
    }
}
