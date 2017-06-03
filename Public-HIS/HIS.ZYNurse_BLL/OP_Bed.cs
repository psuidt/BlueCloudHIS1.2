using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using HIS.SYSTEM.Core;
using HIS.Model;
using HIS.BLL;

using HIS.SYSTEM.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.ZYNurse_BLL;

namespace HIS.ZYNurse_BLL
{
    /// <summary>
    /// 床位操作类
    /// </summary>
    public class OP_Bed:BaseBLL
    {
        /// <summary>
        /// 获取所有床位信息
        /// </summary>
        /// <param name="deptid"></param>
        /// <returns></returns>
        public DataTable getAllBedInfo(long dept_id)
        {
            int deptid =Convert.ToInt32(dept_id);
            try
            {
                DataTable dtbedinfo = new DataTable();
                string strWhere = @"select b.name ,a.bed_no,a.dept_id,(case when a.patlist_id<>0 then '已分配' else '' end) as Used,a.bed_sex from ZY_NURSE_BED a,BASE_DEPT_PROPERTY b where a.dept_id=b.dept_id and a.dept_id=" + deptid + " order by a.dept_id ,cast( replace(bed_no,'加','100') as integer)" /*and a.dept_id + deptid + " order by cast( replace(bed_no,'加','100') as integer)"*/;
                dtbedinfo = oleDb.GetDataTable(strWhere);
                return dtbedinfo;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 获取病人信息
        /// </summary>
        /// <param name="patlist_id"></param>
        /// <returns></returns>
        public DataTable getPatInfo(int patlist_id)
        {
            int patlistid = patlist_id;
            DataTable patinfo = new DataTable();
            string strWhere = @"select a.cureno,a.markdate,a.diseasename,b.name as currdeptcode,c.name as curedeptcode,d.patname,d.patsex,d.accounttype,e.bed_no,f.name,d.patbridate"
                            + " from zy_patlist a"
                            + " left join BASE_DEPT_PROPERTY b on  a.currdeptcode=char(b.dept_id)"
                            + " left join BASE_DEPT_PROPERTY c on  a.curedeptcode=char(c.dept_id)"
                            + " left join PATIENTINFO d on a.patid=d.patid"
                            + " left join ZY_NURSE_BED e on a.patlistid=e.patlist_id"
                            + " left join BASE_EMPLOYEE_PROPERTY f on e.zy_doc=f.employee_id"
                            + " where a.patlistid="+patlistid;
            patinfo=oleDb.GetDataTable(strWhere);
            return patinfo;

        }
        /// <summary>
        /// 获取科室
        /// </summary>
        /// <returns></returns>
        public DataTable getdept()
        {
            DataTable dtbedinfo = new DataTable();
            dtbedinfo = BaseData.GetDeptData(BaseData.DeptType.住院, BaseData.DeptType2.临床);
            return dtbedinfo;
        }        
        /// <summary>
        /// 根据登录人的科室加载该科室的病人相关信息
        /// </summary>
        /// <param name="dept_id"></param>
        /// <returns></returns>
        public DataTable getPatience(int dept_id)
        {
            try
            {
                int deptid = dept_id;
                DataTable dt = new DataTable();               
                string strWhere = @"select b.dept_id,b.bed_no,b.patlist_id,c.patname,c.patsex,c.accounttype,a.patid,b.workid"
                                + " from zy_nurse_bed b left join zy_patlist a on b.patlist_id=a.patlistid left join patientinfo c on a.patid=c.patid where  b.dept_id=" + deptid + " order by cast( replace(bed_no,'加','100') as integer)";               
                dt = oleDb.GetDataTable(strWhere);
                return dt;
            }            
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 转床
        /// </summary>
        /// <param name="bed_id"></param>
        /// <param name="bed_no"></param>
        /// <param name="dept_id"></param>
        /// <returns></returns>
        public bool setTransbed(int bed_id, string bed_no,long dept_id,int patlist_id)
        {
            string strWhere5 = "patlistid=" + patlist_id;
            object obj2 = BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).GetFieldValue("pattype", strWhere5);
            int pattype = int.Parse(obj2.ToString());
            if (pattype == 6)
            {
                return false;
            }
            try
            {
                
                int oldbedid = bed_id;
                string bedno = bed_no;
                int deptid = Convert.ToInt32(dept_id);
                int patlistid = patlist_id;

                string strWhere = "bed_no='" + bedno + "' and dept_id=" + deptid;
                object objpatlistid = BindEntity<ZY_NURSE_BED>.CreateInstanceDAL(oleDb).GetFieldValue("patlist_id", strWhere);
                if (Convert.ToInt32(objpatlistid) != 0)
                {
                    return false;
                }
                else
                {
                    string str1 = "dept_id=" + deptid + " and  bed_no =" + "'" + bedno + "'";
                    object objbedid = BindEntity<ZY_NURSE_BED>.CreateInstanceDAL(oleDb).GetFieldValue("bed_id", str1);
                    int newbedid = int.Parse(objbedid.ToString());

                    string str2 = "bed_id=" + oldbedid;
                    object obj = BindEntity<ZY_NURSE_BED>.CreateInstanceDAL(oleDb).GetFieldValue("bed_no", str2);
                    string tempbedno = obj.ToString();
                    try
                    {
                        oleDb.BeginTransaction();

                        string str3 = "bed_no=" + "'" + bedno + "'";
                        BindEntity<ZY_NURSE_BED>.CreateInstanceDAL(oleDb).Update(str2, str3);

                        string str4 = "bed_id=" + newbedid;
                        string str5 = "bed_no=" + "'" + tempbedno + "'";
                        BindEntity<ZY_NURSE_BED>.CreateInstanceDAL(oleDb).Update(str4, str5);

                        string strWhere1 = " patlistid=" + patlistid;
                        string str = "bedcode='" + bedno + "'";
                        BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).Update(strWhere1, str);
                        oleDb.CommitTransaction();
                    }
                    catch (Exception e)
                    {
                        oleDb.RollbackTransaction();
                        throw new Exception(e.Message);
                    }
                    return true;
                    
                }
                
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 获取未分配床位的病人列表
        /// </summary>
        /// <param name="dept_id"></param>
        /// <returns></returns>
        public DataTable getPatNotAssignBed(int dept_id)
        {
            try
            {
                DataTable beddt = new DataTable();
                 //string strWhere = @"select a.curedate,a.cureno,a.patlistid,b.patname,b.patsex,c.name,case a.pattype when '1' then '新入院' when  '3' then'召回' end as pattype"
                 //                 + " from zy_patlist a,patientinfo b,base_dept_property c"
                 //                 + " where a.patid=b.patid and (case when (a.currdeptcode is null) or (a.currdeptcode='') then a.curedeptcode else a.currdeptcode end)=char(c.dept_id) and (case when (a.currdeptcode is null) or (a.currdeptcode='') then a.curedeptcode else a.currdeptcode end)=char(" + dept_id + ") and a.pattype=char(1)";
                string strWhere = @"select A.*,c.name from
                                    (
                                        select a.curedate,a.cureno,a.patlistid,b.patname,b.patsex,
                                        case  
                                         when a.pattype='1'  then '新入院'                                       
                                         when  a.pattype='2' and  a.patlistid not in (select patlist_id from zy_nurse_bed) then  '病人转科'
                                         end as pattype ,
                                         case 
                                         when a.currdeptcode='' then a.curedeptcode
                                         else a.currdeptcode 
                                        end as deptid
                                        from 
                                        zy_patlist a  left outer join patientinfo b on a.patid=b.patid
                                    )A
                                left outer join base_dept_property c 
                                on A.deptid=char(c.dept_id)
                                where A.pattype is not null and A.deptid=char("+dept_id+@")
                                order by A.curedate";
                beddt=oleDb.GetDataTable(strWhere);
                return beddt;                
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }            
        }
        /// <summary>
        /// 获取未分配床位的病人列表和出院召回病人列表
        /// </summary>
        /// <param name="dept_id"></param>
        /// <returns></returns>
        public DataTable getPatNotAssignBedRecall(int dept_id)
        {
            try
            {
                DataTable beddt = new DataTable();
                //string strWhere = @"select a.curedate,a.cureno,a.patlistid,b.patname,b.patsex,c.name,case a.pattype when '1' then '新入院' when  '3' then'召回' end as pattype"
                //                  + " from zy_patlist a,patientinfo b,base_dept_property c"
                //                  + " where a.patid=b.patid and (case when (a.currdeptcode is null) or (a.currdeptcode='') then a.curedeptcode else a.currdeptcode end)=char(c.dept_id) and (case when (a.currdeptcode is null) or (a.currdeptcode='') then a.curedeptcode else a.currdeptcode end)=char(" + dept_id + ") and (a.pattype=char(1) or a.pattype=char(3)) order by curedate";

                string strWhere = @"select A.*,c.name from
                                    (
                                        select a.curedate,a.cureno,a.patlistid,b.patname,b.patsex,
                                        case                                       
                                         when  a.pattype='3' and  a.patlistid not in (select patlist_id from zy_nurse_bed) then '出院召回'                                        
                                         end as pattype ,
                                         case 
                                         when a.currdeptcode='' then a.curedeptcode
                                         else a.currdeptcode 
                                        end as deptid
                                        from 
                                        zy_patlist a  left outer join patientinfo b on a.patid=b.patid where a.pattype='3'
                                    )A
                                left outer join base_dept_property c 
                                on A.deptid=char(c.dept_id)
                                where A.pattype is not null and A.deptid=char(" + dept_id + @")
                                order by A.curedate";
                beddt = oleDb.GetDataTable(strWhere);
                return beddt;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 获取科室所有未被分配的床位列表
        /// </summary>
        /// <param name="dept_id"></param>
        /// <returns></returns>
        public DataTable getBedNotAssign(int dept_id)
        {
            try
            {
                DataTable nobeddt = new DataTable();
                string strWhere = @"select aa.room_no,aa.bed_no,aa.name1,aa.name2,aa.name3 from ( select a.dept_id,a.room_no,a.bed_no,a.patlist_id,b.name as name1,c.name as name2,d.name as name3" 
                                  +" from zy_nurse_bed a left join base_dept_property b on a.dept_id = b.dept_id"
                                  +" left join base_employee_property c on a.zz_doc=c.employee_id "
                                  +" left join base_employee_property d on a.zy_doc=c.employee_id) aa "
                                  + " where aa.dept_id=" + dept_id + " and patlist_id=0 order by cast( replace(bed_no,'加','100') as integer) ";                           
                nobeddt = oleDb.GetDataTable(strWhere);
                return nobeddt;
            }
            catch (Exception e)
            {
                throw new Exception (e.Message);
            }
        }
       /// <summary>
       /// 判断该病人是否分床
       /// </summary>
       /// <param name="patlistid"></param>
       /// <returns></returns>
        public bool getexitresult(int patlistid)
        {
            string string1 = "patlist_id=" + patlistid;
            bool result = BindEntity<ZY_NURSE_BED>.CreateInstanceDAL(oleDb).Exists(string1);
            if (result == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 床位分配时对应后台床位表的操作
        /// </summary>
        /// <param name="bedinfo"></param>
        /// <returns></returns>
        public bool bedAssign(HIS.Model.ZY_NURSE_BED bedinfo,long dept_id)
        {
            int deptid = Convert.ToInt32(dept_id);
            string strWhere2=Tables.zy_nurse_bed.BED_NO+oleDb.EuqalTo()+"'"+bedinfo.BED_NO.ToString()+"'"+oleDb.And()+Tables.zy_nurse_bed.DEPT_ID+oleDb.EuqalTo()+bedinfo.DEPT_ID+oleDb.And()+Tables.zy_nurse_bed.PATLIST_ID+oleDb.EuqalTo()+0;
            bool assignresult=BindEntity<ZY_NURSE_BED>.CreateInstanceDAL(oleDb).Exists(strWhere2);
            if (assignresult == true)
            {
                try
                {
                    //3月9日修改，出院召回的病人的要删除相应的病人出院标志
                    string strWhere5 = "patlistid=" + bedinfo.PATLIST_ID;
                    object obj2 = BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).GetFieldValue("pattype", strWhere5);
                    int pattype = int.Parse(obj2.ToString());
                    if (pattype == 6)
                    {
                        return false;
                    }
                    oleDb.BeginTransaction();
                    
                    if (pattype == 3)
                    {
                        string strWhere4 = "order_content like '%今日病人出院%' and delete_flag=0 and  patid=" + bedinfo.PATLIST_ID;
                        string str4 ="delete_flag=1";
                        BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(strWhere4, str4);

                        string strWhere = "bed_no='" + bedinfo.BED_NO.ToString() + "' and dept_id=" + bedinfo.DEPT_ID;
                        string string1 = "patlist_id=" + bedinfo.PATLIST_ID.ToString();
                        string string2 = "bed_sex='" + bedinfo.BED_SEX.ToString() + "'";
                        string string3 = "zz_doc=" + bedinfo.ZZ_DOC.ToString();
                        string string4 = "zy_doc=" + bedinfo.ZY_DOC.ToString();
                        BindEntity<HIS.Model.ZY_NURSE_BED>.CreateInstanceDAL(oleDb).Update(strWhere, string1, string2, string3, string4);

                        string strWhere1 = "patlistid=" + bedinfo.PATLIST_ID;
                        string[] str = new string[4];
                        str[0] = "pattype='2'";
                        str[1] = "curedoccode='" + bedinfo.ZY_DOC + "'";
                        str[2] = "bedcode='" + bedinfo.BED_NO + "'";
                        str[3] = "currdeptcode='" + deptid + "'";
                        BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).Update(strWhere1, str);
                    }
                    //以上是3月9日修改
                    else
                    {
                        string strWhere = "bed_no='" + bedinfo.BED_NO.ToString() + "' and dept_id=" + bedinfo.DEPT_ID;
                        string string1 = "patlist_id=" + bedinfo.PATLIST_ID.ToString();
                        string string2 = "bed_sex='" + bedinfo.BED_SEX.ToString() + "'";
                        string string3 = "zz_doc=" + bedinfo.ZZ_DOC.ToString();
                        string string4 = "zy_doc=" + bedinfo.ZY_DOC.ToString();
                        BindEntity<HIS.Model.ZY_NURSE_BED>.CreateInstanceDAL(oleDb).Update(strWhere, string1, string2, string3, string4);

                        string strWhere1 ="patlistid=" + bedinfo.PATLIST_ID;
                        string[] str = new string[4];
                        str[0] = "pattype='2'";
                        str[1] = "curedoccode='" + bedinfo.ZY_DOC + "'";
                        str[2] = "bedcode='" + bedinfo.BED_NO + "'";
                        str[3] = "currdeptcode='" + deptid + "'";
                        BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).Update(strWhere1, str);
                    }
                    oleDb.CommitTransaction();
                    return true;
                }
                catch (Exception e)
                {
                    oleDb.RollbackTransaction();
                    return false;
                    throw new Exception(e.Message);
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 取消床位分配
        /// </summary>
        /// <param name="cancelbedinfo"></param>
        /// <returns></returns>
        public bool cancelAssign(long patlist_id)
        {
            long patlistid=patlist_id;            
            string strWhere1 = "select * from ZY_DOC_ORDERRECORD  where status_falg in (0,1,2,3,4) and delete_flag=0 and patid=" + patlistid;
            DataTable dt =oleDb.GetDataTable(strWhere1);
            if (dt.Rows.Count > 0)
            {
                return false;
            }
            string strWhere5 = "patlistid=" + patlist_id;
            object obj2 = BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).GetFieldValue("pattype", strWhere5);
            int pattype = int.Parse(obj2.ToString());
            if (pattype == 6)
            {
                return false;
            }
            else
            {
                try
                {
                    oleDb.BeginTransaction();
                    string strWhere = "patlist_id=" + patlistid;
                    string[] str = new string[10];
                    str[0] = Tables.zy_nurse_bed.BED_FEE + oleDb.EuqalTo() + 0;
                    str[1] = Tables.zy_nurse_bed.ZZ_DOC + oleDb.EuqalTo() + 0;
                    str[2] = Tables.zy_nurse_bed.ZY_DOC + oleDb.EuqalTo() + 0;
                    str[3] = Tables.zy_nurse_bed.IS_PLUS + oleDb.EuqalTo() + 0;
                    str[4] = Tables.zy_nurse_bed.CHARGE_NURSE + oleDb.EuqalTo() + 0;
                    str[5] = Tables.zy_nurse_bed.PATLIST_ID + oleDb.EuqalTo() + 0;
                    str[6] = Tables.zy_nurse_bed.BABY_ID + oleDb.EuqalTo() + 0;
                    str[7] = Tables.zy_nurse_bed.INPATIENT_DEPT + oleDb.EuqalTo() + 0;
                    str[8] = Tables.zy_nurse_bed.BED_SEX + oleDb.EuqalTo() + "''";
                    str[9] = Tables.zy_nurse_bed.IS_USE + oleDb.EuqalTo() + 0;                  
                    BindEntity<HIS.Model.ZY_NURSE_BED>.CreateInstanceDAL(oleDb).Update(strWhere, str);
                    string strWhere2 = "patlistid=" + patlistid+" ";                    
                    string[] str2 = new string[4];
                    str2[0] = Tables.zy_patlist.CURRDEPTCODE + oleDb.EuqalTo() + "''";
                    str2[1] = Tables.zy_patlist.BEDCODE + oleDb.EuqalTo() + "''";
                    str2[2] = Tables.zy_patlist.PATTYPE + oleDb.EuqalTo() + "'1'";
                    str2[3] = Tables.zy_patlist.CUREDOCCODE+oleDb.EuqalTo() + "''";
                    BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).Update(strWhere2, str2);
                    oleDb.CommitTransaction();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                    throw new Exception(e.Message);
                }
            }      
        }
        /// <summary>
        /// 科室床位维护，增加一张新床位
        /// </summary>
        /// <param name="bedlist"></param>
        /// <returns></returns>
        public bool insertNewBed(HIS.Model.ZY_NURSE_BED bedlist)
        {
            try
            {
                IBaseDAL<HIS.Model.ZY_NURSE_BED> s = BindEntity<HIS.Model.ZY_NURSE_BED>.CreateInstanceDAL(oleDb);
                string string1 = Tables.zy_nurse_bed.BED_NO + oleDb.EuqalTo() + "'" + bedlist.BED_NO + "' and " + Tables.zy_nurse_bed.DEPT_ID + oleDb.EuqalTo() + bedlist.DEPT_ID;

                if (!BindEntity<HIS.Model.ZY_NURSE_BED>.CreateInstanceDAL(oleDb).Exists(string1))
                {
                    BindEntity<HIS.Model.ZY_NURSE_BED>.CreateInstanceDAL(oleDb).Add(bedlist);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }               
       /// <summary>
       /// 获取科室床位分配信息
       /// </summary>
       /// <param name="dept_id"></param>
       /// <returns></returns>
        public DataTable getBedAssignInfo(int dept_id)
        {
            try
            {
                DataTable bedinfodt = new DataTable();
                string strWhere = @"select a.patlist_id,a.bed_id,a.dept_id,a.room_no,a.bed_no,b.cureno,b.patname,a.bed_sex,c.name"
                                + " from zy_nurse_bed a,patientinfo b,BASE_DEPT_PROPERTY c,zy_patlist d"
                                + " where a.patlist_id=d.patlistid and d.patid=b.patid and a.dept_id=c.dept_id and a.dept_id=" + dept_id
                                + " order by cast( replace(bed_no,'加','100') as integer)";
                bedinfodt = oleDb.GetDataTable(strWhere);
                return bedinfodt;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
 
        }
        /// <summary>
        /// 删除床位操作
        /// </summary>
        /// <param name="patid"></param>
        public bool cancelbedassign(string deptid,string bedno)
        {
            try
            {
                string strWhere =Tables.zy_nurse_bed.DEPT_ID+oleDb.EuqalTo()+deptid+oleDb.And()+Tables.zy_nurse_bed.BED_NO+oleDb.EuqalTo()+"'"+bedno+"'"+oleDb.And()+Tables.zy_nurse_bed.PATLIST_ID+oleDb.EuqalTo()+0;
                bool cancelresult=BindEntity<HIS.Model.ZY_NURSE_BED>.CreateInstanceDAL(oleDb).Exists(strWhere);          
                if (cancelresult==true)
                {
                    BindEntity<HIS.Model.ZY_NURSE_BED>.CreateInstanceDAL(oleDb).Delete(strWhere);
                    return true;
                }
                else
                {
                    return false;
                }                
            }
            catch (Exception e)
            {
                return false;
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 对入院病人分配床位后修改入院状态
        /// </summary>
        /// <param name="patid"></param>
        public void updateBedFlag(int patid)
        {
            try
            {
                string strWhere = "patlistid=" + patid;
                string string1 =  "pattype='1'";
                BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).Update(strWhere, string1);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }  
        /// <summary>
        /// 修改主管医生
        /// </summary>
        /// <param name="bed_id"></param>
        public bool updatejzdoc(int bed_id,int jz_doc,int patlist_id)
        {
            int bedid = bed_id;
            int jzdoc = jz_doc;
            int patlistid = patlist_id;
            try
            {
                string strWhere = "bed_id=" + bedid;
                string string1="zy_doc="+jzdoc;
                BindEntity<HIS.Model.ZY_NURSE_BED>.CreateInstanceDAL(oleDb).Update(strWhere, string1);

                string strWhere1 = "patlistid=" + patlistid;
                string string2 = "curedoccode='" + jzdoc+"'";
                BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).Update(strWhere1, string2);
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw new Exception(e.Message);
            }
        }
         /// <summary>
        /// 修改主治医生
        /// </summary>
        /// <param name="bed_id"></param>
        public bool updatezzdoc(int bed_id,int zz_doc)
        {
            int bedid = bed_id;
            int zzdoc = zz_doc;
            try
            {
                string strWhere = "bed_id=" + bedid;
                 string string1="zz_doc="+zzdoc;
                BindEntity<HIS.Model.ZY_NURSE_BED>.CreateInstanceDAL(oleDb).Update(strWhere, string1);
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 转科操作
        /// </summary>
        /// <param name="patlist"></param>
        /// <param name="currdeptcode"></param>
        /// <returns></returns>
        public bool TranDept(HIS.Model.ZY_PatList patlist,string currdeptcode)
        {
            try
            {
                oleDb.BeginTransaction();
                string strWhere = "patlist_id=" + patlist.PatListID;
                string[] str = new string[10];
                str[0] = Tables.zy_nurse_bed.BED_FEE + oleDb.EuqalTo() + 0;
                str[1] = Tables.zy_nurse_bed.ZZ_DOC + oleDb.EuqalTo() + 0;
                str[2] = Tables.zy_nurse_bed.ZY_DOC + oleDb.EuqalTo() + 0;
                str[3] = Tables.zy_nurse_bed.IS_PLUS + oleDb.EuqalTo() + 0;
                str[4] = Tables.zy_nurse_bed.CHARGE_NURSE + oleDb.EuqalTo() + 0;
                str[5] = Tables.zy_nurse_bed.PATLIST_ID + oleDb.EuqalTo() + 0;
                str[6] = Tables.zy_nurse_bed.BABY_ID + oleDb.EuqalTo() + 0;
                str[7] = Tables.zy_nurse_bed.INPATIENT_DEPT + oleDb.EuqalTo() + 0;
                str[8] = Tables.zy_nurse_bed.BED_SEX + oleDb.EuqalTo() + "''";
                str[9] = Tables.zy_nurse_bed.IS_USE + oleDb.EuqalTo() + 0;
                BindEntity<HIS.Model.ZY_NURSE_BED>.CreateInstanceDAL(oleDb).Update(strWhere, str);//清空床位表信息
                patlist.CurrDeptCode = currdeptcode;
                patlist.CureDocCode = "0";
                BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).Update(patlist);//修改病人当前科室
                oleDb.CommitTransaction();
                return true;
            }
            catch (Exception e)
            {
                oleDb.RollbackTransaction();
                throw new Exception(e.Message);
            }
           
        }


        public bool OpPatout(HIS.Model.ZY_PatList patlist)
        {
            try
            {
                oleDb.BeginTransaction();
                string strWhere = "patlist_id=" + patlist.PatListID;
                string[] str = new string[10];
                str[0] = Tables.zy_nurse_bed.BED_FEE + oleDb.EuqalTo() + 0;
                str[1] = Tables.zy_nurse_bed.ZZ_DOC + oleDb.EuqalTo() + 0;
                str[2] = Tables.zy_nurse_bed.ZY_DOC + oleDb.EuqalTo() + 0;
                str[3] = Tables.zy_nurse_bed.IS_PLUS + oleDb.EuqalTo() + 0;
                str[4] = Tables.zy_nurse_bed.CHARGE_NURSE + oleDb.EuqalTo() + 0;
                str[5] = Tables.zy_nurse_bed.PATLIST_ID + oleDb.EuqalTo() + 0;
                str[6] = Tables.zy_nurse_bed.BABY_ID + oleDb.EuqalTo() + 0;
                str[7] = Tables.zy_nurse_bed.INPATIENT_DEPT + oleDb.EuqalTo() + 0;
                str[8] = Tables.zy_nurse_bed.BED_SEX + oleDb.EuqalTo() + "''";
                str[9] = Tables.zy_nurse_bed.IS_USE + oleDb.EuqalTo() + 0;
                BindEntity<HIS.Model.ZY_NURSE_BED>.CreateInstanceDAL(oleDb).Update(strWhere, str);//清空床位表信息
                patlist.PatType = "3";
                patlist.OutDate = XcDate.ServerDateTime;
                BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).Update(patlist);//修改病人状态
                oleDb.CommitTransaction();
                return true;
 
            }
            catch (Exception e)
            {
                oleDb.RollbackTransaction();
                throw new Exception(e.Message);
            }

        }

        public DataTable GetIndeptDoc(int deptid)
        {
            string strsql = @"select * from BASE_EMPLOYEE_PROPERTY where EMPLOYEE_ID in 
                                    (select EMPLOYEE_ID from BASE_EMP_DEPT_ROLE 
                                         where dept_id=" + deptid + " and EMPLOYEE_ID in (select EMPLOYEE_ID from BASE_ROLE_DOCTOR))";
            return oleDb.GetDataTable(strsql);

        }



        public bool IsOut(int patlistid)
        {
            HIS.Model.ZY_PatList plist = BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).GetModel(patlistid);
            if (plist.PatType.Trim() == "4" || plist.PatType.Trim() == "5")
            {
                return true;
            }
            return false;
        }

      
    }
}
