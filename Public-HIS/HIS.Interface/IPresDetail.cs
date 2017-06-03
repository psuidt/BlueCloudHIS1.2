using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.Interface
{
    public interface IPresDetail
    {
        string BigItemCode
        {
            get;
            set;
        }
        decimal Money
        {
            get;
            set;
        }
    }
}
