using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.ZY_BLL.DataModel;
using HIS.MediInsInterface_BLL.MediInsInterface.zyInterface;
using HIS.MediInsInterface_BLL.MediInsBLL.Dao.zyUpload.Daointerface;
using HIS.MediInsInterface_BLL.MediInsBLL.Dao;
using HIS.MediInsInterface_BLL.MediInsBLL.Dao.zyUpload.DaoClass;
using HIS.SYSTEM.Core;
using System.Data;
using System.Collections;
using HIS.ZY_BLL.ObjectModel.BaseData;

namespace HIS.MediInsInterface_BLL.MediInsBLL.Domain.zyUpload
{
    public class PatPresOrderUpload:IbaseDao,IDisposable
    {
    
        /// <summary>
        /// Dao接口
        /// </summary>
        private IpatDao ipatdao = null;
        /// <summary>
        /// 外部接口
        /// </summary>
        private IzyInterface zy_sys = null;

        private ZY_PatList _zyPatlist;

        public ZY_PatList ZyPatlist
        {
            get { return _zyPatlist; }
            set { _zyPatlist = value; }
        }

        private string _errMessage;

        public string ErrMessage
        {
            get { return _errMessage; }
            set { _errMessage = value; }
        }

        private string _EmpID;
        /// <summary>
        /// 操作员ID
        /// </summary>
        public string EmpID
        {
            get { return _EmpID; }
            set { _EmpID = value; }
        }
        private string _Name;
        /// <summary>
        /// 操作员姓名
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string getgrbm()
        {
            return ZyPatlist.patientInfo.FamilyCode.Split(new char[] { '-' })[0].Trim();
        }

        private string getywlb()
        {
            return ZyPatlist.patientInfo.FamilyCode.Split(new char[] { '-' })[1].Trim();
        }

        private string getywid()
        {
            return ZyPatlist.Nccm_NO.Split(new char[] { '-' })[0].Trim();
        }

        private string getid()
        {
            return ZyPatlist.Nccm_NO.Split(new char[] { '-' })[1].Trim().Replace("&","");
        }

        /// <summary>
        /// 病人入院登记
        /// </summary>
        public string PatRegister()
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("GRBM", getgrbm());
            hashtable.Add("Ywlb", getywlb());
            hashtable.Add("Zyfs", "0");
            hashtable.Add("Djsj", DateTime.Now.ToString("yyyy-MM-dd"));
            hashtable.Add("Zyksbh", ZyPatlist.CureDeptCode);
            hashtable.Add("Zyksmc", BaseNameFactory.GetName(baseNameType.科室名称, ZyPatlist.CureDeptCode));
            hashtable.Add("Zybqbh", "");
            hashtable.Add("Zybqmc", "");
            hashtable.Add("Zybcbh", ZyPatlist.BedCode);
            hashtable.Add("Cwlb", "0");
            hashtable.Add("Zyh", ZyPatlist.CureNo);
            hashtable.Add("ICD_RY", ZyPatlist.DiseaseCode);
            hashtable.Add("RYZT_ID", ZyPatlist.CureState);
            hashtable.Add("DJRDM", EmpID);
            hashtable.Add("DJRMC", Name);
            hashtable.Add("YWID", getywid());
            hashtable.Add("YLZH", ZyPatlist.patientInfo.MediCard);
            hashtable.Add("RYSJ", ZyPatlist.CureDate.ToString("yyyy-MM-dd"));
            hashtable.Add("YSDM", ZyPatlist.CureDocCode);
            hashtable.Add("YSMC", BaseNameFactory.GetName(baseNameType.用户名称, ZyPatlist.CureDocCode));
            string id = zy_sys.Register(hashtable).ToString();
            ZyPatlist.Nccm_NO += id;
            ErrMessage = zy_sys.ErrMessage;
            //[20100621.1.06]
            ipatdao.UpdatePatinfo(ZyPatlist.PatID.ToString(), ZyPatlist.PatListID.ToString(), ZyPatlist.patientInfo.PatName, getgrbm(), getywlb(), getywid(), id, ZyPatlist.DiseaseCode, ZyPatlist.DiseaseName);

            return id;
        }

        public DataTable GetPatYWLB()
        {
            return (DataTable)((object[])hosdata)[0];
        }

        public string GetPatYWID()
        {
            return (((object[])zy_sys.HospitalInfo)[1]).ToString();
        }

        public DataTable GetPatInfo()
        {

            ipatdao.SavePatYlzh(ZyPatlist.PatID.ToString(), ZyPatlist.patientInfo.MediCard);

            Hashtable hashtable=new Hashtable();
            hashtable.Add("MEDICARD",ZyPatlist.patientInfo.MediCard);
            DataTable dt= (DataTable)zy_sys.GetPatientInfo(hashtable);
            ErrMessage = zy_sys.ErrMessage;
            return dt;
        }

        /// <summary>
        /// 重新入院登记
        /// </summary>
        public bool RestPatRegister()
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("YWID", getywid());
            hashtable.Add("id", getid());
            hashtable.Add("Ywlb", getywlb());
            hashtable.Add("GRBM", getgrbm());
            hashtable.Add("DJRDM", EmpID);
            hashtable.Add("DJRMC", Name);
            hashtable.Add("RYSJ", ZyPatlist.CureDate.ToString("yyyy-MM-dd"));
            hashtable.Add("Zyksbh", ZyPatlist.CureDeptCode);
            hashtable.Add("Zyksmc", BaseNameFactory.GetName(baseNameType.科室名称, ZyPatlist.CureDeptCode));
            hashtable.Add("Zybqbh", "");
            hashtable.Add("Zybqmc", "");
            hashtable.Add("Zybcbh", ZyPatlist.BedCode);
            hashtable.Add("Cwlb", "0");
            hashtable.Add("Zyh", ZyPatlist.CureNo);
            hashtable.Add("ICD_RY", ZyPatlist.DiseaseCode);
            hashtable.Add("RYZT_ID", ZyPatlist.CureState);
            hashtable.Add("Bz", "");
            hashtable.Add("Icd_zy", ZyPatlist.OutDiagnName);
            hashtable.Add("Cyrq", ZyPatlist.OutDate.ToString("yyyy-MM-dd"));
            hashtable.Add("Zyfs", "0");
            hashtable.Add("Jssj", DateTime.Now.ToString("yyyy-MM-dd"));
            hashtable.Add("Jsr", EmpID);
            hashtable.Add("Jsrxm", Name);
            hashtable.Add("OPERATION_CODE", "");
            hashtable.Add("Cyzt", ZyPatlist.Out_Flag);
            hashtable.Add("Jsdh", "");
            hashtable.Add("YSDM", ZyPatlist.CureDocCode);
            hashtable.Add("YSMC", BaseNameFactory.GetName(baseNameType.用户名称, ZyPatlist.CureDocCode));

            bool b = zy_sys.AlterRegister(hashtable);
            if (b == false)
                ErrMessage = zy_sys.ErrMessage;
            return b;
        }
        /// <summary>
        /// 取消入院登记
        /// </summary>
        public bool CancelPatRegister()
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("Ywid", getywid());
            hashtable.Add("Id", getid());
            hashtable.Add("Grbm", getgrbm());
            hashtable.Add("Djrdm", EmpID);
            hashtable.Add("Djrmc", Name);
            bool b= zy_sys.CancelRegister(hashtable);
            if (b)
            {
                ipatdao.DeleteYwid(ZyPatlist.PatListID);
            }
            else
            {
                ErrMessage = zy_sys.ErrMessage;
            }
            return b;
        }

        public DataTable GetPresOrderNoPass()
        {
            DataTable dt = ipatdao.GetPresOrderNoPass(ZyPatlist.PatListID);
            return dt;
        }

        /// <summary>
        /// 上传费用
        /// </summary>
        public bool UploadPresOrder()
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("Ywid", getywid());
            hashtable.Add("Id", getid());
            hashtable.Add("Grbm", getgrbm());
            hashtable.Add("Ywlb", getywlb());
            hashtable.Add("Lrrdm", EmpID);
            hashtable.Add("Lrrxm", Name);
            hashtable.Add("Lrsj", DateTime.Now.ToString("yyyy-MM-dd"));
            hashtable.Add("Cfh", ZyPatlist.PatListID.ToString());

            hashtable.Add("zyh", ZyPatlist.CureNo);
            hashtable.Add("jzks", BaseNameFactory.GetName(baseNameType.科室名称, ZyPatlist.CurrDeptCode));

            hashtable.Add("empid", EmpID);
            hashtable.Add("name", Name);

            DataTable dt = GetPresOrderNoPass();
            hashtable.Add("dt", dt);

            bool b= zy_sys.UploadzyPatFee(hashtable);
            if (b)
            {
                ipatdao.UpdatePresOrderPassID(dt);
            }
            else
            {
                ErrMessage = zy_sys.ErrMessage;
            }
            return b;
         
        }
        /// <summary>
        /// 病人结算
        /// </summary>
        public DataSet PatCost()
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("Ywid", getywid());
            hashtable.Add("Id", getid());
            hashtable.Add("Ywlb", getywlb());
            //hashtable.Add("Grbm", getgrbm());
            hashtable.Add("DJRDM", EmpID);
            hashtable.Add("DJRMC", Name);
            hashtable.Add("RYSJ", ZyPatlist.CureDate.ToString("yyyy-MM-dd"));
            hashtable.Add("Zyksbh", ZyPatlist.CureDeptCode);
            hashtable.Add("Zyksmc", BaseNameFactory.GetName(baseNameType.科室名称, ZyPatlist.CureDeptCode));
            hashtable.Add("Zybqbh", "");
            hashtable.Add("Zybqmc", "");
            hashtable.Add("Zybcbh", ZyPatlist.BedCode);
            hashtable.Add("Cwlb", "0");
            hashtable.Add("Zyh", ZyPatlist.CureNo);
            hashtable.Add("ICD_RY", ZyPatlist.DiseaseCode);
            hashtable.Add("RYZT_ID", ZyPatlist.CureState);

            hashtable.Add("Icd_zy", ZyPatlist.OutDiagnCode);
            hashtable.Add("Cyrq", ZyPatlist.OutDate.ToString("yyyy-MM-dd") == "0001-01-01" ? DateTime.Now.ToString("yyyy-MM-dd") : ZyPatlist.OutDate.ToString("yyyy-MM-dd"));
            hashtable.Add("Zyfs", "0");
            hashtable.Add("Jssj", DateTime.Now.ToString("yyyy-MM-dd"));
            hashtable.Add("Jsr", EmpID);
            hashtable.Add("Jsrxm", Name);
            hashtable.Add("OPERATION_CODE", "");
            hashtable.Add("Cyzt", ZyPatlist.Out_Flag);
            hashtable.Add("Jsdh", ZyPatlist.PatListID.ToString());
            hashtable.Add("YSDM", ZyPatlist.CureDocCode);
            hashtable.Add("YSMC", BaseNameFactory.GetName(baseNameType.用户名称, ZyPatlist.CureDocCode));
            hashtable.Add("Zfy", ipatdao.GetPatAllFee(ZyPatlist.PatListID).ToString("0.00"));
            hashtable.Add("Ylzh", ZyPatlist.patientInfo.MediCard);
            hashtable.Add("JSBZ", "0");
            hashtable.Add("QTBCFS", "1");

            DataSet ds = (DataSet)zy_sys.Charge(hashtable);
            ErrMessage = zy_sys.ErrMessage;
            return ds;
        }
        /// <summary>
        /// 取消结算
        /// </summary>
        public bool CancelPatCost()
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("Ywid", getywid());
            hashtable.Add("Id", getid());
            hashtable.Add("Ywlb", getywlb());
            //hashtable.Add("Grbm", getgrbm());
            hashtable.Add("DJRDM", EmpID);
            hashtable.Add("DJRMC", Name);
            hashtable.Add("RYSJ", ZyPatlist.CureDate.ToString("yyyy-MM-dd"));
            hashtable.Add("Zyksbh", ZyPatlist.CureDeptCode);
            hashtable.Add("Zyksmc", BaseNameFactory.GetName(baseNameType.科室名称, ZyPatlist.CureDeptCode));
            hashtable.Add("Zybqbh", "");
            hashtable.Add("Zybqmc", "");
            hashtable.Add("Zybcbh", ZyPatlist.BedCode);
            hashtable.Add("Cwlb", "0");
            hashtable.Add("Zyh", ZyPatlist.CureNo);
            hashtable.Add("ICD_RY", ZyPatlist.DiseaseCode);
            hashtable.Add("RYZT_ID", ZyPatlist.CureState);

            hashtable.Add("Icd_zy", ZyPatlist.OutDiagnCode);
            hashtable.Add("Cyrq", ZyPatlist.OutDate.ToString("yyyy-MM-dd"));
            hashtable.Add("Zyfs", "0");
            hashtable.Add("Jssj", DateTime.Now.ToString("yyyy-MM-dd"));
            hashtable.Add("Jsr", EmpID);
            hashtable.Add("Jsrxm", Name);
            hashtable.Add("OPERATION_CODE", "");
            hashtable.Add("Cyzt", ZyPatlist.Out_Flag);
            hashtable.Add("Jsdh", ZyPatlist.PatListID.ToString());
            hashtable.Add("YSDM", ZyPatlist.CureDocCode);
            hashtable.Add("YSMC", BaseNameFactory.GetName(baseNameType.用户名称, ZyPatlist.CureDocCode));
            bool b= zy_sys.CancelCharge(hashtable);
            ErrMessage = zy_sys.ErrMessage;
            return b;
        }
        /// <summary>
        /// 显示已上传费用
        /// </summary>
        public DataSet BrushUploadFee()
        {
            DataSet ds = new DataSet();
            DataTable dt1= ipatdao.GetPresOrderPass(ZyPatlist.PatListID);
            dt1.TableName = "dt1";
            ds.Tables.Add(dt1);
            Hashtable hashtable = new Hashtable();
            hashtable.Add("Ywid", getywid());
            hashtable.Add("Id", getid());
            DataTable dt2= (DataTable)zy_sys.DownloadzyPatFee(hashtable);
            dt2.TableName = "dt2";
            ds.Tables.Add(dt2.Copy());

            return ds;
        }

        #region IbaseDao 成员

       private HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase _oleDb;
        public HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase oleDb
        {
            get
            {
                return _oleDb;
            }
            set
            {
                _oleDb = value;
            }
        }

        private object hosdata;

        public PatPresOrderUpload()
        {
            _oleDb = BaseBLL.oleDb;

            ipatdao = DaoFactory.GetObject<IpatDao>(typeof(PatDao));
            ipatdao.oleDb = oleDb;
            zy_sys = zyFactory.Create("CxHn");
            hosdata = zy_sys.HospitalInfo;
        }

        public PatPresOrderUpload(HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase _OleDb)
        {
            _oleDb = _OleDb;

            ipatdao = DaoFactory.GetObject<IpatDao>(typeof(PatDao));
            ipatdao.oleDb = oleDb;
            zy_sys = zyFactory.Create("CxHn");
            hosdata = zy_sys.HospitalInfo;
        }

        #endregion

        #region IDisposable 成员

        public void Dispose()
        {
            ((IDisposable)zy_sys).Dispose();
        }

        #endregion
    }
}
