using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using GWMHIS.BussinessLogicLayer.Classes;
using HIS.ZY_BLL.DataModel;
using HIS.ZY_BLL.ObjectModel.BaseData;
using HIS.ZY_BLL.ObjectModel.NccmManager;
using HIS.Interface;

namespace HIS_ZYManager.Action
{
    /// <summary>
    /// 控制器
    /// </summary>
    public class FrmRegisterController
    {
        private IFrmRegisterView view;
        private DataSet _dataSet;
        private ZY_PatList zy_Patlist;
        private User user;
        private Deptment dept;
        private int zyConfig008;

        private IFrmSearchPatView _ifrmSearchPatView;
        /// <summary>
        /// 读卡病人窗体接口
        /// </summary>
        public IFrmSearchPatView ifrmSearchPatView
        {
            get
            {
                return _ifrmSearchPatView;
            }
            set
            {
                _ifrmSearchPatView = value;
            }
        }

        public FrmRegisterController(IFrmRegisterView _view)
        {
            view = _view;
            _dataSet = new DataSet();
            zy_Patlist = new ZY_PatList();


            LoadINFO();

            user = view.currentUser;
            dept = view.currentDept;

            view.Initialize(_dataSet);
            view.cbDept_set = _dataSet.Tables["Dept"];

            zyConfig008 = HIS.ZY_BLL.OP_ZYConfigSetting.GetConfigValue("008");

            BrushPatList();
        }

        /// <summary>
        /// 刷新病人信息
        /// </summary>
        public void BrushPatList()
        {
            view.zyPatLists = BindLvPatList();
        }

        /// <summary>
        /// 新证
        /// </summary>
        public void NewPat()
        {
            zy_Patlist = new ZY_PatList();
            view.zyPatList = zy_Patlist;
        }

        /// <summary>
        /// 入院
        /// </summary>
        /// <returns></returns>
        public bool RegPat()
        {
            zy_Patlist = view.zyPatList;

            view.InpatNo = zy_Patlist.GetPatNo();//系统自动产生住院号  注释掉就手工产生

            ZY_PatList zyp= zy_Patlist.GetPatInfo(view.InpatNo);
            //判断住院号是否存在
            if (zyp != null && (zyp.PatType == "1" || zyp.PatType == "2"))
            {
                throw new Exception("您输入的住院号是在院病人，请核对正确！");
            }

            zy_Patlist.CureNo = view.InpatNo;
            zy_Patlist.patientInfo.CureNo = zy_Patlist.CureNo;
            zy_Patlist.CurrDeptCode = "";
            //经管直接跳到在床状态
            //if (zyConfig008 == 0)
            //{
            //    zy_Patlist.PatType = "1";
            //}
            //else
            //{
            //    zy_Patlist.PatType = "2";
            //}
            zy_Patlist.PatType = "1";//update zenghao 091013
            //没和农合做接口 暂时不用
            //HIS.ZY_BLL.OP_PatientObject.NccmCheck_SavePatientInfo(zy_Patlist);
            zy_Patlist.Add();//HIS.ZY_BLL.OP_PatientObject.SavePatientInfo(zy_Patlist.PatientInfo, zy_Patlist);

            view.zyPatList = zy_Patlist;
            //界面显示住院号
            
            //刷新病人列表
            BrushPatList();
            return true;
        }

        /// <summary>
        /// 取消病人入院
        /// </summary>
        public bool DelPat()
        {
            zy_Patlist = view.zyPatList;
            if (HIS.ZY_BLL.OP_ZYConfigSetting.GetConfigValue("008") == 0)
            {
                if (zy_Patlist.PatType == "1"|| (zy_Patlist.PatType == "2" && zy_Patlist.BedCode.Trim()=="")) //临床分配床位后不能取消入院
                {
                    zy_Patlist.Delete();
                }
                else
                {
                    throw new Exception("该病人不能取消！");
                }
            }
            else
            {
                if (zy_Patlist.PatType == "1" || zy_Patlist.PatType == "2")//临床分配床位后不能取消入院
                {
                    zy_Patlist.Delete();
                }
                else
                {
                    throw new Exception("该病人不能取消！");
                }
            }
            //刷新病人列表
            BrushPatList();
            return true;
        }

        /// <summary>
        /// 修改病人
        /// </summary>
        /// <returns></returns>
        public bool AlterPat()
        {
            try
            {
                zy_Patlist = view.zyPatList;
                zy_Patlist.Update();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 住院号搜索病人
        /// </summary>
        public void KeyDownCureNo()
        {
            ZY_PatList zyP = zy_Patlist.GetPatInfo(view.InpatNo);
            view.zyPatList = zyP;
        }

        /// <summary>
        /// 召回病人
        /// </summary>
        public bool BackPat()
        {
            zy_Patlist = view.zyPatList;
            zy_Patlist.PatType = zy_Patlist.getPatType();
            if (zy_Patlist.PatType == "3")
            {
                zy_Patlist.updatePatType("2");

            }
            else if (zy_Patlist.PatType == "4" || zy_Patlist.PatType == "5")
            {
                throw new Exception("请先取消结算再召回！");
            }
            else
            {
                throw new Exception("不能召回！");
            }

            //刷新病人列表
            BrushPatList();
            return true;
        }

        /// <summary>
        /// 根据病人代码得到住院号
        /// </summary>
        /// <param name="PatCode"></param>
        /// <returns></returns>
        public string GetCureNo(string PatCode)
        {
            return zy_Patlist.patientInfo.GetCureNo(PatCode);
        }

        /// <summary>
        /// 加载ShowCard数据
        /// </summary>
        private void LoadINFO()
        {
            //加载病人诊断
            DataTable dt = BaseDataFactory.GetData(baseDataType.诊断);
            dt.TableName = "Disease";
            _dataSet.Tables.Add(dt);

            //加载病人类型
            dt = BaseDataFactory.GetData(baseDataType.病人类型);
            dt.TableName = "PatientType";
            _dataSet.Tables.Add(dt);

            //加载民族信息
            dt = BaseDataFactory.GetData(baseDataType.民族);
            dt.TableName = "Nationco";
            _dataSet.Tables.Add(dt);

            //加载全院所有用户
            dt = BaseDataFactory.GetData(baseDataType.所有用户);
            dt.TableName = "User";
            _dataSet.Tables.Add(dt);

            //加载医生
            dt = BaseDataFactory.GetData(baseDataType.医生);
            dt.TableName = "UserDoc";
            _dataSet.Tables.Add(dt);

            //加载住院临床科室
            dt = BaseDataFactory.GetData(baseDataType.住院临床科室);
            DataTable dtBk = dt;
            dt.TableName = "Dept";
            _dataSet.Tables.Add(dt);

            //加载全院的临床科室
            dt = BaseDataFactory.GetData(baseDataType.全院临床科室);
            dt.TableName = "LCDept";
            _dataSet.Tables.Add(dt);

        }

        /// <summary>
        /// 绑定病人列表
        /// </summary>
        /// <returns></returns>
        private List<ZY_PatList> BindLvPatList()
        {
            BindPatListVal bplv = new BindPatListVal();
            bplv.IsIn=view.searchPatList.rbIn;
            bplv.DeptCode=view.searchPatList.DeptCode;
            bplv.Bdate=view.searchPatList.Bdate;
            bplv.Edate= view.searchPatList.Edate;
            zy_Patlist.bindPatListVal = bplv;
            return zy_Patlist.BindPatList();
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        //读卡界面操作方法
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////

        private DataTable dtPatlist;
        /// <summary>
        /// 读卡查询病人
        /// </summary>
        public void SearchPat()
        {
            string values = ifrmSearchPatView.searchValue;
            if (values == null || values == "")
                throw new Exception("不能输入空字符！");

            switch (ifrmSearchPatView.SelectIndex)
            {
                case 0:
                    dtPatlist = zy_Patlist.patientInfo.GetNccmPat_LH(SearchNccmPatType.医疗卡号, values);
                    break;
                case 1:
                    dtPatlist = zy_Patlist.patientInfo.GetNccmPat_LH(SearchNccmPatType.身份证号, values);
                    break;
                case 2:
                    dtPatlist = zy_Patlist.patientInfo.GetNccmPat_LH(SearchNccmPatType.家庭编码, values);
                    break;
                case 3:
                    dtPatlist = zy_Patlist.patientInfo.GetNccmPat_LH(SearchNccmPatType.病人姓名, values);
                    break;
                case 4:
                    #region 根据住院编号查询
                    int regId;
                    try
                    {
                        regId = Convert.ToInt32(values.Trim());
                    }
                    catch (Exception err)
                    {
                        throw new Exception("住院编号只能输入数字");
                    }
                    IMZ_ClinicData imz_clinic = InstanceFactory.CreatMZ_ClinicDataInstance();
                    DataTable dt = imz_clinic.GetInpatRegInfo(regId);
                    if (dt.Rows.Count > 0)
                    {
                        try
                        {                          
                            zy_Patlist.patientInfo.CureNo = dt.Select("name='住院号'").Length > 0 ? dt.Select("name='住院号'")[0][1].ToString().Trim() : "";
                            if (zy_Patlist.patientInfo.CureNo != null && zy_Patlist.patientInfo.CureNo != "")
                            {
                                zy_Patlist = zy_Patlist.GetPatInfo(zy_Patlist.patientInfo.CureNo);
                            }
                            zy_Patlist.patientInfo.ACCOUNTTYPE = dt.Select("name='病人类型'").Length > 0 ? dt.Select("name='病人类型'")[0][1].ToString() : "";
                            zy_Patlist.patientInfo.LinkAddress = dt.Select("name='户口位置'").Length > 0 ? dt.Select("name='户口位置'")[0][1].ToString() : "";
                            zy_Patlist.patientInfo.PatAddress = dt.Select("name='户口位置'").Length > 0 ? dt.Select("name='户口位置'")[0][1].ToString() : "";
                            zy_Patlist.patientInfo.LinkMan = dt.Select("name='联系人'").Length > 0 ? dt.Select("name='联系人'")[0][1].ToString() : "";
                            zy_Patlist.patientInfo.LinkTel = dt.Select("name='联系电话'").Length > 0 ? dt.Select("name='联系电话'")[0][1].ToString() : "";
                            //patinfo.PatBriDate = //dt.Select("name='联系电话'").Length > 0 ? dt.Select("name='联系电话'")[0][1].ToString() : "";
                            zy_Patlist.patientInfo.PATJOB = dt.Select("name='职业'").Length > 0 ? dt.Select("name='职业'")[0][1].ToString() : "";
                            zy_Patlist.patientInfo.PatName = dt.Select("name='姓名'").Length > 0 ? dt.Select("name='姓名'")[0][1].ToString() : "";
                            zy_Patlist.patientInfo.PatSex = dt.Select("name='性别'").Length > 0 ? dt.Select("name='性别'")[0][1].ToString().Replace("性", "") : "";
                            zy_Patlist.patientInfo.PatTEL = dt.Select("name='联系电话'").Length > 0 ? dt.Select("name='联系电话'")[0][1].ToString() : "";
                            zy_Patlist.DiseaseName = dt.Select("name='西医诊断'").Length > 0 ? dt.Select("name='西医诊断'")[0][1].ToString() : "";
                            zy_Patlist.PatType = dt.Select("name='病人类型'").Length > 0 ? dt.Select("name='病人类型'")[0][1].ToString() : "";
                            zy_Patlist.CureDeptCode = dt.Select("name='入院科室ID'").Length > 0 ? dt.Select("name='入院科室ID'")[0][1].ToString() : "";
                            zy_Patlist.CureState = dt.Select("name='病情状况'").Length > 0 ? dt.Select("name='病情状况'")[0][1].ToString() : "";

                            zy_Patlist.OriginDocCode = dt.Select("name='签证医生ID'").Length > 0 ? dt.Select("name='签证医生ID'")[0][1].ToString() : "";
                            zy_Patlist.OriginDeptCode = dt.Select("name='签证科室ID'").Length > 0 ? dt.Select("name='签证科室ID'")[0][1].ToString() : "";

                            string Ages = dt.Select("name='年龄'").Length > 0 ? dt.Select("name='年龄'")[0][1].ToString() : "";
                            if (Ages != "")
                            {
                                string DAge = Ages.Trim();
                                if (DAge.IndexOf("岁") != -1)
                                {
                                    zy_Patlist.patientInfo.PatBriDate = DateTime.Now.AddYears(0 - Convert.ToInt32(DAge.Replace("岁", "").Trim()));
                                }
                                if (DAge.IndexOf("月") != -1)
                                {
                                    zy_Patlist.patientInfo.PatBriDate = DateTime.Now.AddMonths(0 - Convert.ToInt32(DAge.Replace("月", "").Trim()));
                                }
                                if (DAge.IndexOf("天") != -1)
                                {
                                    zy_Patlist.patientInfo.PatBriDate = DateTime.Now.AddDays(0 - Convert.ToInt32(DAge.Replace("天", "").Trim()));
                                }
                                if (DAge.IndexOf("小时") != -1)
                                {
                                    zy_Patlist.patientInfo.PatBriDate = DateTime.Now.AddHours(0 - Convert.ToInt32(DAge.Replace("小时", "").Trim()));
                                }
                            }
                            //传送到界面
                            view.zyPatList = zy_Patlist;

                        }
                        catch { }
                    }
                    else
                    {
                        throw new Exception("该住院编号没有找到任何数据！");
                    }
                    #endregion
                    break;
            }

            ifrmSearchPatView.patListInfo = dtPatlist;
        }
        /// <summary>
        /// 选择指定病人
        /// </summary>
        public void ChoosePat()
        {
            PatientInfo patinfo=new PatientInfo();
            ZY_PatList zyP=null;
            if (dtPatlist == null)
            {
                throw new Exception("找不到任何病人数据！");
            }
            if (dtPatlist.Rows.Count != 0)
            {
                patinfo = (PatientInfo)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dtPatlist, ifrmSearchPatView.RowIndex, patinfo);
            }
            if (patinfo.CureNo != null && patinfo.CureNo != "")
            {
                zyP = zy_Patlist.GetPatInfo(patinfo.CureNo);
            }
            zyP.patientInfo = patinfo;
            view.zyPatList = zyP;
        }
    }
}
