using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.DatabaseAccessLayer;
using Entity = HIS.Model;
using HIS.SYSTEM.Core;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.Base_BLL.Enums;
using System.Data;

namespace HIS.Base_BLL
{
    // * 20100519.2.02 参加参数访问类
    public class ReadConfig : BaseBLL
    {
        /// <summary>
        /// 门诊经管参数集合
        /// </summary>
        private static System.Collections.Hashtable _mzjgparameters;
        private static System.Collections.Hashtable _mzdocjgparameters;
        private static System.Collections.Hashtable _zyjgparameters;
        private static System.Collections.Hashtable _zydocparameters;
        private static System.Collections.Hashtable _zynurseparameters;
        private static System.Collections.Hashtable _ypjgparameters;

        /// <summary>
        /// 门诊经管参数集合
        /// </summary>
        public static System.Collections.Hashtable MzjgParameters
        {
            get
            {
                if (_mzjgparameters==null)
                {
                    List<Model.MZ_CONFIG> configs = BindEntity<Model.MZ_CONFIG>.CreateInstanceDAL(oleDb).GetListArray("");
                    if (configs.Count == 0)
                    {
                        throw new Exception("当前医院的门诊系统参数未初始化！");
                    }
                    _mzjgparameters = new System.Collections.Hashtable();
                    for (int i = 0; i < configs.Count; i++)
                    {
                        _mzjgparameters.Add(configs[i].CODE, configs[i].VALUE);
                    }
                    return _mzjgparameters;
                }
                else
                {
                    return _mzjgparameters;
                }               
            }
        }
        /// <summary>
        /// 门诊医生站参数集合
        /// </summary>
        public static System.Collections.Hashtable MzdocParameters
        {
            get
            {
                if (_mzdocjgparameters == null )
                {
                    List<Model.MZ_DOC_CONFIG> configs = BindEntity<Model.MZ_DOC_CONFIG>.CreateInstanceDAL(oleDb).GetListArray("");
                    if (configs.Count == 0)
                    {
                        throw new Exception("当前医院的门诊医生系统参数未初始化！");
                    }
                    _mzdocjgparameters = new System.Collections.Hashtable();
                    for (int i = 0; i < configs.Count; i++)
                    {
                        _mzdocjgparameters.Add(configs[i].CODE, configs[i].VALUE);
                    }
                    return _mzdocjgparameters;
                }
                else
                {
                    return _mzdocjgparameters;
                }
            }
        }

        /// <summary>
        /// 住院经管参数集合
        /// </summary>
        public static System.Collections.Hashtable ZyjgParameters
        {
            get
            {
                if (_zyjgparameters == null )
                {
                    List<Model.ZY_CONFIG> configs = BindEntity<Model.ZY_CONFIG>.CreateInstanceDAL(oleDb).GetListArray("");
                    if (configs.Count == 0)
                    {
                        throw new Exception("当前医院的住院经管系统参数未初始化！");
                    }
                    _zyjgparameters = new System.Collections.Hashtable();
                    for (int i = 0; i < configs.Count; i++)
                    {
                        _zyjgparameters.Add(configs[i].CODE, configs[i].VALUE);
                    }
                    return _zyjgparameters;
                }
                else
                {
                    return _zyjgparameters;
                }
            }
        }

        /// <summary>
        /// 住院医生站参集合
        /// </summary>
        public static System.Collections.Hashtable ZydocParameters
        {
            get
            {
                if (_zydocparameters == null )
                {
                    List<Model.ZY_DOC_CONFIG> configs = BindEntity<Model.ZY_DOC_CONFIG>.CreateInstanceDAL(oleDb).GetListArray("");
                    if (configs.Count == 0)
                    {
                        throw new Exception("当前医院的住院医生站系统参数未初始化！");
                    }
                    _zydocparameters = new System.Collections.Hashtable();
                    for (int i = 0; i < configs.Count; i++)
                    {
                        _zydocparameters.Add(configs[i].CODE, configs[i].VALUE);
                    }
                    return _zydocparameters;
                }
                else
                {
                    return _zydocparameters;
                }
            }
        }

        /// <summary>
        /// 住院护士站参数集合
        /// </summary>
        public static System.Collections.Hashtable ZynurseParameters
        {
            get
            {
                if (_zynurseparameters == null )
                {
                    List<Model.ZY_NURSE_CONFIG> configs = BindEntity<Model.ZY_NURSE_CONFIG>.CreateInstanceDAL(oleDb).GetListArray("");
                    if (configs.Count == 0)
                    {
                        throw new Exception("当前医院的住院护士站系统参数未初始化！");
                    }
                    _zynurseparameters = new System.Collections.Hashtable();
                    for (int i = 0; i < configs.Count; i++)
                    {
                        _zynurseparameters.Add(configs[i].CODE, configs[i].VALUE);
                    }
                    return _zynurseparameters;
                }
                else
                {
                    return _zynurseparameters;
                }
            }
        }

        /// <summary>
        /// 药品经管参数集合
        /// </summary>
        public static System.Collections.Hashtable YpjgParameters
        {
            get
            {
                if (_ypjgparameters == null )
                {
                    List<Model.YP_CONFIG> configs = BindEntity<Model.YP_CONFIG>.CreateInstanceDAL(oleDb).GetListArray("");
                    if (configs.Count == 0)
                    {
                        throw new Exception("当前医院的药品管理系统参数未初始化！");
                    }
                    _ypjgparameters = new System.Collections.Hashtable();
                    for (int i = 0; i < configs.Count; i++)
                    {
                        _ypjgparameters.Add(configs[i].CODE, configs[i].VALUE);
                    }
                    return _ypjgparameters;
                }
                else
                {
                    return _ypjgparameters;
                }
            }
        }
        
        public static void Reload(ParameterCatalog catalog)
        {
            switch (catalog)
            {
                case ParameterCatalog.门诊经管:
                    _mzjgparameters = null;
                    break;
                case ParameterCatalog.住院经管:
                    _zyjgparameters = null;
                    break;
                case ParameterCatalog.门诊医生站:
                    _mzdocjgparameters = null;
                    break;
                case ParameterCatalog.住院医生站:
                    _zydocparameters = null;
                    break;
                case ParameterCatalog.住院护士站:
                    _zynurseparameters = null;
                    break;
                case ParameterCatalog.药品管理:
                    _ypjgparameters = null;
                    break;
            }          
        }
       
    }
}
