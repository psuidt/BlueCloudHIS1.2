using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace HIS.Base_BLL
{
    /// <summary>
    /// 枚举实现
    /// </summary>
    public class ParametersEnum : IEnumerator
    {
        List<Parameter> _ps;

        int position = -1;

        public ParametersEnum( List<Parameter> ps )
        {
            _ps = ps;
        }

        #region IEnumerator 成员

        public object Current
        {
            get
            {
                try
                {
                    return _ps[position];
                }
                catch ( IndexOutOfRangeException )
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public bool MoveNext()
        {
            position++;
            return ( position < _ps.Count );

        }

        public void Reset()
        {
            position = -1;
        }

        #endregion
    }
}
