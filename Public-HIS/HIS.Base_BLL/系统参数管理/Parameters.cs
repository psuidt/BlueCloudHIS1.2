using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace HIS.Base_BLL
{
    public class Parameters : IEnumerable
    {
        private List<Parameter> lstParameter;

        public Parameters( List<Parameter> parameters )
        {
            lstParameter = parameters;
        }

        public Parameter this[string code]
        {
            get
            {
                Parameter parameter = lstParameter.Find( delegate( Parameter p )
                {
                    if ( p.Code.Trim().ToUpper() == code )
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                } );

                if ( parameter != null )
                    return parameter;
                else
                    throw new Exception( "参数" + code + "不存在，请初始化后再试！" );
            }
        } 

        public List<Parameter> ToList()
        {
            return lstParameter;
        }

        #region IEnumerable 成员

        public IEnumerator GetEnumerator()
        {
            return new ParametersEnum( lstParameter );
        }

        #endregion
    }

    
}
