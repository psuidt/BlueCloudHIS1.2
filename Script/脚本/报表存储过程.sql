-- Start of generated script for 220.128.5.3-DB2-LLZYDB (db2inst2)
--  Oct-30-2010 at 12:00:47

SET SCHEMA DB2INST2;

SET CURRENT PATH = "SYSIBM","SYSFUN","SYSPROC","SYSIBMADM","DB2INST2";

CREATE PROCEDURE "DB2INST2"."SP_MZ_DAYREPORT"
 (IN "V_BTIME" TIMESTAMP, 
  IN "V_ETIME" TIMESTAMP
 ) 
  SPECIFIC "DB2INST2"."SQL100813141037300"
  LANGUAGE SQL
  NOT DETERMINISTIC
  CALLED ON NULL INPUT
  EXTERNAL ACTION
  OLD SAVEPOINT LEVEL
  MODIFIES SQL DATA
  INHERIT SPECIAL REGISTERS
  begin 

 declare cur_item cursor with hold  with return for 	 						   
select M.item_name,B.total_fee,B.ticketnum from BASE_STAT_MZKJ M 
   left outer join 
     (
         select   code,sum(total_fee) as total_fee,sum(ticketnum) as ticketnum from
                                        (
                                        select  c.mzkj_code as code,sum(b.total_fee) as total_fee,count(a.ticketnum) as ticketnum from  
                                                   (select ticketnum,costmasterid,chargecode,costdate,record_flag,accountid from mz_costmaster) a, 
                                                   (select costid,itemtype as bigitemcode,total_fee from mz_costorder) b ,  base_stat_item c   
                                         where a.costmasterid=b.costid and b.bigitemcode=c.code and a.costdate
                                         between V_BTIME  and V_ETIME   and a.record_flag in (0,1,2)   
                                        group by c.mzkj_code,total_fee,ticketnum
							            )A group by code
	)B   on M.code =B.code;
open cur_item;       
  
  
  
end;

SET SCHEMA DB2INST2;

SET CURRENT PATH = "SYSIBM","SYSFUN","SYSPROC","SYSIBMADM","DB2INST2";

CREATE PROCEDURE "DB2INST2"."SP_MZ_FEERPT"
 (IN "V_BTIME" TIMESTAMP, 
  IN "V_ETIME" TIMESTAMP, 
  IN "V_TYPE" INTEGER, 
  IN "V_MZDEPT" INTEGER, 
  OUT "ERR_CODE" INTEGER, 
  OUT "ERR_TEXT" CHARACTER(100)
 ) 
  SPECIFIC "DB2INST2"."SQL100903175053600"
  LANGUAGE SQL
  NOT DETERMINISTIC
  CALLED ON NULL INPUT
  EXTERNAL ACTION
  OLD SAVEPOINT LEVEL
  MODIFIES SQL DATA
  INHERIT SPECIAL REGISTERS
  p1: begin  
	 
	declare v_presdept varchar(20);
	declare v_presdoc varchar(20);
	declare v_itemtype varchar(20); 
	declare v_count int;
	Declare   sSQL   varchar(1000);  
	 

declare global temporary table tmp_kjxmFee(
	科室 varchar(20),
	医生 varchar(20),
	合计 decimal(18,2) DEFAULT 0,
    中草药 decimal(18,2) DEFAULT 0,
	中成药 decimal(18,2) DEFAULT 0,
	西药 decimal(18,2) DEFAULT 0,
	药品收入小计 decimal(18,2) DEFAULT 0,
	放射收入 decimal(18,2) DEFAULT 0,
	CT收入 decimal(18,2) DEFAULT 0,
	化验费 decimal(18,2) DEFAULT 0,
	心电图 decimal(18,2) DEFAULT 0,
	B超 decimal(18,2) DEFAULT 0,
	彩色B超 decimal(18,2) DEFAULT 0,
	胃镜 decimal(18,2) DEFAULT 0,
	多普勒 decimal(18,2) DEFAULT 0,
	特检收入小计 decimal(18,2) DEFAULT 0,
	诊查费 decimal(18,2) DEFAULT 0,
	手术费 decimal(18,2) DEFAULT 0,
	门诊注射 decimal(18,2) DEFAULT 0,
    急诊注射 decimal(18,2) DEFAULT 0,
	床位费 decimal(18,2) DEFAULT 0,
    车费 decimal(18,2) DEFAULT 0,
	碎石费 decimal(18,2) DEFAULT 0,
	煎药费 decimal(18,2) DEFAULT 0,
	妇科治疗 decimal(18,2) DEFAULT 0,
	理疗治疗 decimal(18,2) DEFAULT 0,
	口腔治疗 decimal(18,2) DEFAULT 0,
	五官治疗 decimal(18,2) DEFAULT 0,
	草药治疗 decimal(18,2) DEFAULT 0,
	肛肠治疗 decimal(18,2) DEFAULT 0,
	普外治疗 decimal(18,2) DEFAULT 0,
	骨伤治疗 decimal(18,2) DEFAULT 0,
	儿科治疗 decimal(18,2) DEFAULT 0,
	急诊费 decimal(18,2) DEFAULT 0,
	材料费 decimal(18,2) DEFAULT 0,
	吸氧 decimal(18,2) DEFAULT 0,
	高压氧 decimal(18,2) DEFAULT 0,
	挂号费 decimal(18,2) DEFAULT 0,
	体检费 decimal(18,2) DEFAULT 0,
	其他 decimal(18,2) DEFAULT 0,
	医疗收入小计 decimal(18,2) DEFAULT 0
	      )
     not logged on commit preserve rows with replace in usertemp1;
	 
	  
	 
	
	
	p2: begin
	   if(V_TYPE=1)
	   then
	     FOR each_record AS 
			 select
			   c.presdeptcode,c.presdoccode,itemtype,sum(b.total_fee) fee,date(a.costdate) as costdate
		       from mz_costmaster a left outer join mz_costorder b  on  a.costmasterid=b.costid  
			              left outer join mz_presmaster c on a.presmasterid=c.presmasterid
			   where  a.costdate between V_BTIME  and V_ETIME   and a.record_flag in (0,1,2)  
		       group by presdeptcode,presdoccode,itemtype,date(a.costdate)
			   order by  presdeptcode,presdoccode
          do
		   select name into v_presdept from BASE_DEPT_PROPERTY where dept_id=int(presdeptcode);
		   if( presdoccode='' or presdoccode='0')
		   then		  
		   set v_presdoc='未指定';
		   else
		   select name into v_presdoc from BASE_EMPLOYEE_PROPERTY where EMPLOYEE_ID=int(presdoccode);
		   
		  end if;
		 
		   select item_name into v_itemtype from base_stat_mzkj where code=(select mzkj_code from base_stat_item where code=itemtype);
		   
		   select count(*) into v_count from session.tmp_kjxmFee where 科室=v_presdept and 医生=v_presdoc;
		   
		   if(v_count>0) then
		      set sSQL='update session.tmp_kjxmFee set ' || v_itemtype || ' = ' || v_itemtype || '+ ' || char(fee) || ' where  科室 = ''' || v_presdept || ''' and 医生= ''' || v_presdoc || ''' ';		  
			    
		   else
		      set sSQL='insert into session.tmp_kjxmFee(科室,医生,' || v_itemtype || ') values('''|| v_presdept ||''','''|| v_presdoc ||''','|| char(fee) ||')';
		   end if;
		   
		      prepare   s1   from   sSql;   
              execute   s1;
		  end for;
		 else
		   FOR each_record AS 
			 select
			   c.presdeptcode,c.presdoccode,itemtype,sum(b.total_fee) fee,date(a.costdate) as costdate
		       from mz_costmaster a left outer join mz_costorder b  on  a.costmasterid=b.costid  
			              left outer join mz_presmaster c on a.presmasterid=c.presmasterid
			   where  a.costdate between V_BTIME  and V_ETIME   and a.record_flag in (0,1,2)   and int(presdeptcode)=V_MZDEPT 
		       group by presdeptcode,presdoccode,itemtype,date(a.costdate)
			   order by  presdeptcode,presdoccode
          do
		   select name into v_presdept from BASE_DEPT_PROPERTY where dept_id=int(presdeptcode);
		   if( presdoccode='' or presdoccode='0' )
		   then		  
		   set v_presdoc='未指定';
		   else
		   select name into v_presdoc from BASE_EMPLOYEE_PROPERTY where EMPLOYEE_ID=int(presdoccode);
		   
		  end if;
		 
		   select item_name into v_itemtype from base_stat_mzkj where code=(select mzkj_code from base_stat_item where code=itemtype);
		   
		   select count(*) into v_count from session.tmp_kjxmFee where 科室=v_presdept and 医生=v_presdoc;
		   
		   if(v_count>0) then
		      set sSQL='update session.tmp_kjxmFee set ' || v_itemtype || ' = ' || v_itemtype || '+ ' || char(fee) || ' where  科室 = ''' || v_presdept || ''' and 医生= ''' || v_presdoc || ''' ';		  
			    
		   else
		      set sSQL='insert into session.tmp_kjxmFee(科室,医生,' || v_itemtype || ') values('''|| v_presdept ||''','''|| v_presdoc ||''','|| char(fee) ||')';
		   end if;
		   
		      prepare   s1   from   sSql;   
              execute   s1;
		  end for;
		  end if;
	    update session.tmp_kjxmFee set 
		药品收入小计=(中草药 + 中成药 + 西药),
		特检收入小计=(放射收入 + CT收入 + 化验费 + 心电图  + B超 + 彩色B超  + 胃镜 + 多普勒),
		医疗收入小计=(诊查费 +手术费+ 门诊注射+  急诊注射 +床位费 +   车费 + 碎石费 + 煎药费  + 妇科治疗 + 理疗治疗 + 口腔治疗+五官治疗+ 草药治疗 + 肛肠治疗 
		              + 普外治疗 + 骨伤治疗 + 儿科治疗+急诊费+材料费+吸氧+高压氧+挂号费+体检费+其他);
		
		update session.tmp_kjxmFee set 合计=(药品收入小计 + 特检收入小计 + 医疗收入小计);
		
   
   
   
  end p2;
  
  begin
   declare cur_01 cursor with return for
     select * from session.tmp_kjxmFee;
   open cur_01;
  end;
end p1;

SET SCHEMA DB2INST2;

SET CURRENT PATH = "SYSIBM","SYSFUN","SYSPROC","SYSIBMADM","DB2INST2";

CREATE PROCEDURE "DB2INST2"."SP_ZY_COSTFEEDETAILE"
 (IN "V_BTIME" TIMESTAMP, 
  IN "V_ETIME" TIMESTAMP, 
  IN "V_TYPE" INTEGER, 
  IN "V_ALLCHARGER" INTEGER
 ) 
  SPECIFIC "DB2INST2"."SQL100906103932700"
  LANGUAGE SQL
  NOT DETERMINISTIC
  CALLED ON NULL INPUT
  EXTERNAL ACTION
  OLD SAVEPOINT LEVEL
  MODIFIES SQL DATA
  INHERIT SPECIAL REGISTERS
  p1: begin 
	  
	 
	Declare   sSQL   varchar(1000);   
	
 
declare global temporary table tmp_Fee(
	科室 varchar(20),
	姓名 varchar(20),
	费用总额 decimal(18,2) DEFAULT 0,
    预交金 decimal(18,2) DEFAULT 0,
	现金补收补退款 decimal(18,2) DEFAULT 0,
	往来欠费 decimal(18,2) DEFAULT 0,
	自费 decimal(18,2) DEFAULT 0, 
	公费 decimal(18,2) DEFAULT 0,
	职工医保 decimal(18,2) DEFAULT 0,
	居民医保 decimal(18,2) DEFAULT 0,
	农合 decimal(18,2) DEFAULT 0,
	本院职工 decimal(18,2) DEFAULT 0,
	其他 decimal(18,2) DEFAULT 0,
	收费员 varchar(20),
	备注 varchar(100)	
	      )
     not logged on commit preserve rows with replace in usertemp1; 
	
	
	p2: begin
	   if(V_TYPE =1)
	    then
	     FOR each_record AS 
		 select e.name as 科室,c.patname as 姓名, sum(a.total_fee) as 费用总额,
         sum(deptosit_fee) as 预交金,sum(reality_fee) as 现金补收补退款,sum(village_fee) as 记账金额,
		 sum(self_fee+FAVOR_FEE-deptosit_fee-reality_fee) as 往来欠费 ,f.name as 收费员,d.name as 记账类型
         from zy_costmaster a  left outer join  zy_patlist b
         on a.patlistid=b.patlistid  
		 left outer join patientinfo c on b.patid=c.patid		 
		 left outer join BASE_PATIENTTYPE d on a.pattype=d.code
		 left outer join BASE_DEPT_PROPERTY e on b.currdeptcode=char(e.dept_id)
         left outer join BASE_EMPLOYEE_PROPERTY f on a.chargecode=char(f.EMPLOYEE_ID)
		 where costdate>=V_BTIME  and costdate<=V_ETIME  
         group by e.name,a.patlistid,c.patname,f.name,d.name
			
          do		 
		      set sSQL='insert into session.tmp_Fee(科室, 姓名,费用总额,  预交金,现金补收补退款,往来欠费,' || 记账类型 || ',收费员) 
			    values('''|| 科室 ||''','''|| 姓名||''',' || char(费用总额) || ',
				      ' || char( 预交金) || ',' || char(现金补收补退款) || ',' || char(往来欠费) || ',' || char(记账金额) || ','''|| 收费员 ||''')';		 
		      prepare   s1   from   sSql;   
              execute   s1;
		  end for;	
		  
		
		  
		else
			FOR each_record AS 
		 select e.name as 科室,c.patname as 姓名, sum(a.total_fee) as 费用总额,
         sum(deptosit_fee) as 预交金,sum(reality_fee) as 现金补收补退款,sum(village_fee) as 记账金额,
		 sum(self_fee+FAVOR_FEE-deptosit_fee-reality_fee) as 往来欠费 ,f.name as 收费员,d.name as 记账类型
         from zy_costmaster a  left outer join  zy_patlist b
         on a.patlistid=b.patlistid  
		 left outer join patientinfo c on b.patid=c.patid		 
		 left outer join BASE_PATIENTTYPE d on a.pattype=d.code
		 left outer join BASE_DEPT_PROPERTY e on b.currdeptcode=char(e.dept_id)
         left outer join BASE_EMPLOYEE_PROPERTY f on a.chargecode=char(f.EMPLOYEE_ID)
		 where costdate>=V_BTIME  and costdate<=V_ETIME  and a.chargecode=char(V_ALLCHARGER)
         group by e.name,a.patlistid,c.patname,f.name,d.name
			
          do		 
		      set sSQL='insert into session.tmp_Fee(科室, 姓名,费用总额,  预交金,现金补收补退款,往来欠费,' || 记账类型 || ',收费员) 
			    values('''|| 科室 ||''','''|| 姓名||''',' || char(费用总额) || ',
				      ' || char( 预交金) || ',' || char(现金补收补退款) || ',' || char(往来欠费) || ',' || char(记账金额) || ','''|| 收费员 ||''')';		 
		      prepare   s1   from   sSql;   
              execute   s1;
		  end for;	
   end if;
   
     insert into session.tmp_Fee 
		  select '合计' as 科室,'' as  姓名,sum(费用总额) as 费用总额, sum(预交金) as 预交金, sum(现金补收补退款) as 现金补收补退款, sum(往来欠费) as 往来欠费,
		  sum(自费) as 自费,sum(公费) as 公费,sum(职工医保) as 职工医保,sum(居民医保) as 居民医保,sum(农合) as 农合,sum(本院职工) as 本院职工,sum(其他) as 其他,'' as 收费员,'' as 备注
		  from session.tmp_Fee;
   
  end p2;
  begin
   declare cur_01 cursor with return for
     select * from session.tmp_Fee;
   open cur_01;
  end;
end p1;

SET SCHEMA DB2INST2;

SET CURRENT PATH = "SYSIBM","SYSFUN","SYSPROC","SYSIBMADM","DB2INST2";

CREATE PROCEDURE "DB2INST2"."SP_ZY_DAYREPORT"
 (IN "V_BTIME" TIMESTAMP, 
  IN "V_ETIME" TIMESTAMP, 
  IN "V_ALLCHARGER" BIGINT, 
  IN "V_TYPE" SMALLINT, 
  OUT "ERR_CODE" INTEGER, 
  OUT "ERR_TEXT" CHARACTER(100)
 ) 
  SPECIFIC "DB2INST2"."SQL100906112815600"
  LANGUAGE SQL
  NOT DETERMINISTIC
  CALLED ON NULL INPUT
  EXTERNAL ACTION
  OLD SAVEPOINT LEVEL
  MODIFIES SQL DATA
  INHERIT SPECIAL REGISTERS
  p1: begin  
    
      
	
	declare v_chargecode varchar(20);
	declare v_count int;
	Declare   sSQL   varchar(1000);   
	
	
	

	
 
declare global temporary table tmp_DayFee(
	收费员 varchar(20),
	预交款 decimal(18,2) DEFAULT 0,
	预交人次 INTEGER DEFAULT 0,
    出院医疗费用总额 decimal(18,2) DEFAULT 0,
	出院预交金 decimal(18,2) DEFAULT 0,
	出院现金补收或补退款 decimal(18,2) DEFAULT 0,
	出院往来欠费 decimal(18,2) DEFAULT 0,
	出院人次 decimal(18,2) DEFAULT 0,
	合计 decimal(18,2) DEFAULT 0
	      )
     not logged on commit preserve rows with replace in usertemp1;
	 
	  
	
	
	
	p2: begin
	     if(V_TYPE=0) then  --单个收费员
	    --插入预交款
	     FOR each_record AS 
			 select
			  chargecode,sum(total_fee) fee, count(*) num from zy_chargelist where costdate >=V_BTIME  and costdate<=V_ETIME  and chargecode=char(V_ALLCHARGER)
			  group by chargecode
          do
		   
		   select name into v_chargecode from DB2INST2.BASE_EMPLOYEE_PROPERTY where EMPLOYEE_ID=int(chargecode);
		   
		   select count(*) into v_count from session.tmp_DayFee where 收费员=v_chargecode;
		   
		   if(v_count>0) then
		      set sSQL='update session.tmp_DayFee set 预交款 = 预交款 + ' || char(fee) || ', 预交人次=预交人次+'|| char(num) ||' where  收费员= ''' || v_chargecode || ''' ';		  
			    
		   else
		      set sSQL='insert into session.tmp_DayFee(收费员,预交款,预交人次) values('''|| v_chargecode ||''','|| char(fee) ||','|| char(num) ||')';
		   end if;
		   set ERR_TEXT=sSQL;
		      prepare   s1   from   sSql;   
              execute   s1;
		  end for;
		  --插入出院结算费用
		   FOR each_record1 AS 
			 select
			   chargecode,sum(total_fee) fee,sum(DEPTOSIT_FEE) fee1, sum(REALITY_FEE) fee2, sum(SELF_FEE+village_fee+FAVOR_FEE-DEPTOSIT_FEE-REALITY_FEE) fee3, count(*) num from zy_costmaster
			   where  costdate >=V_BTIME  and costdate<=V_ETIME  and chargecode=char(V_ALLCHARGER)
			   group by chargecode
          do
		   
		   select name into v_chargecode from DB2INST2.BASE_EMPLOYEE_PROPERTY where EMPLOYEE_ID=int(chargecode);
		   
		   select count(*) into v_count from session.tmp_DayFee where 收费员=v_chargecode;
		   
		   if(v_count>0) then
		      set sSQL='update session.tmp_DayFee set 出院医疗费用总额 = 出院医疗费用总额 + ' || char(fee) || ',
			      			   					  	  出院预交金=出院预交金+'|| char(fee1) ||',
													  出院现金补收或补退款=出院现金补收或补退款+'|| char(fee2) ||',
													  出院往来欠费=出院往来欠费+'|| char(fee3) ||',
													  出院人次=出院人次+'|| char(num) ||'
						where  收费员= ''' || v_chargecode || ''' ';		  
			    
		   else
		      set sSQL='insert into session.tmp_DayFee(收费员,出院医疗费用总额,出院预交金,出院现金补收或补退款,出院往来欠费,出院人次) values('''|| v_chargecode ||''','|| char(fee) ||','|| char(fee1) ||','|| char(fee2) ||','|| char(fee3) ||','|| char(num) ||')';
		   end if;
		   set ERR_TEXT=sSQL;
		      prepare   s1   from   sSql;   
              execute   s1;
		  end for;
		
		else--所有收费员
		
		--插入预交款
	     FOR each_record AS 
			 select
			  chargecode,sum(total_fee) fee, count(*) num from zy_chargelist where  costdate >=V_BTIME  and costdate<=V_ETIME 
			  group by chargecode
          do
		   
		  select name into v_chargecode from DB2INST2.BASE_EMPLOYEE_PROPERTY where EMPLOYEE_ID=int(chargecode);
		   
		   select count(*) into v_count from session.tmp_DayFee where 收费员=v_chargecode;
		   
		   if(v_count>0) then
		      set sSQL='update session.tmp_DayFee set 预交款 = 预交款 + ' || char(fee) || ', 预交人次=预交人次+'|| char(num) ||' where  收费员= ''' || v_chargecode || ''' ';		  
		   else
		      set sSQL='insert into session.tmp_DayFee(收费员,预交款,预交人次) values('''|| v_chargecode ||''','|| char(fee) ||','|| char(num) ||')';
		   end if;
		   
		   set ERR_TEXT=sSQL;
		   
		      prepare   s1   from   sSql;   
              execute   s1;
		  end for;
		  --插入出院结算费用
		   FOR each_record1 AS 
			 select
			   chargecode,sum(total_fee) fee,sum(DEPTOSIT_FEE) fee1, sum(REALITY_FEE) fee2, sum(SELF_FEE+village_fee+FAVOR_FEE-DEPTOSIT_FEE-REALITY_FEE) fee3, count(*) num from zy_costmaster
			   where  costdate >=V_BTIME  and costdate<=V_ETIME 
			   group by chargecode
          do
		   
		  select name into v_chargecode from DB2INST2.BASE_EMPLOYEE_PROPERTY where EMPLOYEE_ID=int(chargecode);
		   
		   select count(*) into v_count from session.tmp_DayFee where 收费员=v_chargecode;
		   
		   if(v_count>0) then
		      set sSQL='update session.tmp_DayFee set 出院医疗费用总额 = 出院医疗费用总额 + ' || char(fee) || ',
			      			   					  	  出院预交金=出院预交金+'|| char(fee1) ||',
													  出院现金补收或补退款=出院现金补收或补退款+'|| char(fee2) ||',
													  出院往来欠费=出院往来欠费+'|| char(fee3) ||',
													  出院人次=出院人次+'|| char(num) ||'
						where  收费员= ''' || v_chargecode || ''' ';		  
			    
		   else
		      set sSQL='insert into session.tmp_DayFee(收费员,出院医疗费用总额,出院预交金,出院现金补收或补退款,出院往来欠费,出院人次) values('''|| v_chargecode ||''','|| char(fee) ||','|| char(fee1) ||','|| char(fee2) ||','|| char(fee3) ||','|| char(num) ||')';
		   end if;
		   set ERR_TEXT=sSQL;
		      prepare   s1   from   sSql;   
              execute   s1;
		  end for;
		  
		end if;
		
		
		  
		  
		--更新合计
	    update session.tmp_DayFee set 
		合计=(预交款 + 出院现金补收或补退款);
        
		insert into session.tmp_DayFee(收费员,预交款,预交人次,出院医疗费用总额,出院预交金,出院现金补收或补退款,出院往来欠费,出院人次,合计) 
			   		select '合计' as 收费员,sum(预交款) as 预交款,sum(预交人次) as 预交人次,sum(出院医疗费用总额) as 出院医疗费用总额,
					sum(出院预交金) as 出院预交金,sum(出院现金补收或补退款) as 出院现金补收或补退款,sum(出院往来欠费) as 出院往来欠费,sum(出院人次) as 出院人次,sum(合计) as 合计
				    from session.tmp_DayFee;
   
  end p2;
  begin
   declare cur_01 cursor with return for
     select * from session.tmp_DayFee;
   open cur_01;
  end;
end p1;

SET SCHEMA DB2INST2;

SET CURRENT PATH = "SYSIBM","SYSFUN","SYSPROC","SYSIBMADM","DB2INST2";

CREATE PROCEDURE "DB2INST2"."SP_ZY_FEEMXRPT"
 (IN "V_BTIME" TIMESTAMP, 
  IN "V_ETIME" TIMESTAMP, 
  IN "V_TYPE" INTEGER, 
  IN "V_ZYDEPT" INTEGER, 
  OUT "ERR_CODE" INTEGER, 
  OUT "ERR_TEXT" CHARACTER(100)
 ) 
  SPECIFIC "DB2INST2"."SQL100906163424000"
  LANGUAGE SQL
  NOT DETERMINISTIC
  CALLED ON NULL INPUT
  EXTERNAL ACTION
  OLD SAVEPOINT LEVEL
  MODIFIES SQL DATA
  INHERIT SPECIAL REGISTERS
  p1: begin  
	 
	declare v_patname varchar(20);--new 
	declare v_presdept varchar(20);
	declare v_presdoc varchar(20);
	declare v_itemtype varchar(20);
	declare v_count int;
	Declare   sSQL   varchar(1000);  
	 
 
declare global temporary table tmp_kjxmFee(
	科室 varchar(20),
	医生 varchar(20),
	病人姓名 varchar(20),--new 
	patlist_id integer DEFAULT 0,--new 
	合计 decimal(18,2) DEFAULT 0,
    中药 decimal(18,2) DEFAULT 0,
	中成药 decimal(18,2) DEFAULT 0, 
	西药 decimal(18,2) DEFAULT 0, 
	药品收入小计 decimal(18,2) DEFAULT 0,
	放射 decimal(18,2) DEFAULT 0,
	CT decimal(18,2) DEFAULT 0,
	检验 decimal(18,2) DEFAULT 0,
	A超 decimal(18,2) DEFAULT 0,
	B超 decimal(18,2) DEFAULT 0,
	彩超 decimal(18,2) DEFAULT 0,
	胃镜 decimal(18,2) DEFAULT 0,
	多普勒 decimal(18,2) DEFAULT 0,
	特检收入小计 decimal(18,2) DEFAULT 0,
	床日 INTEGER DEFAULT 0,--new 
	床位 decimal(18,2) DEFAULT 0,
	护理 decimal(18,2) DEFAULT 0,
	诊查 decimal(18,2) DEFAULT 0,
	治疗 decimal(18,2) DEFAULT 0,
	输血 decimal(18,2) DEFAULT 0,
	输氧 decimal(18,2) DEFAULT 0,
	材料 decimal(18,2) DEFAULT 0,
	煎药 decimal(18,2) DEFAULT 0,
	车费 decimal(18,2) DEFAULT 0,
	理疗 decimal(18,2) DEFAULT 0,
	手术 decimal(18,2) DEFAULT 0,
	麻醉 decimal(18,2) DEFAULT 0,
	高压氧 decimal(18,2) DEFAULT 0,
	碎石 decimal(18,2) DEFAULT 0,
	水电 decimal(18,2) DEFAULT 0,
	急出诊 decimal(18,2) DEFAULT 0,
	核磁共振 decimal(18,2) DEFAULT 0,
	其他 decimal(18,2) DEFAULT 0,
	医疗收入小计 decimal(18,2) DEFAULT 0
	      )
     not logged on commit preserve rows with replace in usertemp1;
	 
	  
	 
	
	
	p2: begin
	 if(V_TYPE=1) then
	
	     FOR each_record AS 
			 select
			  patid,patlistid, presdeptcode,presdoccode,itemtype,sum(tolal_fee) fee,date(costdate) costdate
		       from DB2INST2.ZY_PRESORDER where charge_flag=1 and costdate>=V_BTIME  and costdate<=V_ETIME 
		       group by presdeptcode,presdoccode,patid,patlistid,itemtype,date(costdate)
			   order by presdeptcode,presdoccode,patid,patlistid
          do
		  
		   select a.patname into v_patname from patientinfo a where a.patid=each_record.patid;
           --set		   v_patname='aa'; 
		  
		   if(presdeptcode='' or presdeptcode='0') then
		   set v_presdept='未指定';
		   else
		   select name into v_presdept from BASE_DEPT_PROPERTY where dept_id=int(presdeptcode);
		   end if;
		   if(presdoccode='' or presdoccode='0') then
		   set v_presdoc='未指定';
		   else
		   select name into v_presdoc from BASE_EMPLOYEE_PROPERTY where EMPLOYEE_ID=int(presdoccode);
		   end if;
		   
		   select item_name into v_itemtype from base_stat_zykj where code=(select zykj_code from base_stat_item where code=itemtype);
		   
		   select count(*) into v_count from session.tmp_kjxmFee where 科室=v_presdept and 医生=v_presdoc and patlist_id=patlistid;
		   
		   if(v_count>0) then
		      set sSQL='update session.tmp_kjxmFee set ' || v_itemtype || ' = ' || v_itemtype || '+ ' || char(fee) || ' where  科室 = ''' || v_presdept || ''' and 医生= ''' || v_presdoc || ''' and patlist_id= '||char(patlistid)||' ';		  
			    
		   else
		      set sSQL='insert into session.tmp_kjxmFee(科室,医生,病人姓名,patlist_id,' || v_itemtype || ') values('''|| v_presdept ||''','''|| v_presdoc ||''','''||v_patname||''','||char(patlistid)||','|| char(fee) ||')';
		   end if;
		   
		      prepare   s1   from   sSql;   
              execute   s1;
		  end for;
		  
    else
	
	FOR each_record AS 
			 select
			  patid,patlistid, presdeptcode,presdoccode,itemtype,sum(tolal_fee) fee,date(costdate) costdate
		       from DB2INST2.ZY_PRESORDER where charge_flag=1 and costdate>=V_BTIME  and costdate<=V_ETIME  and presdeptcode =char(V_ZYDEPT)
		       group by presdeptcode,presdoccode,patid,patlistid,itemtype,date(costdate)
			   order by presdeptcode,presdoccode,patid,patlistid
          do
		  
		   select a.patname into v_patname from patientinfo a where a.patid=each_record.patid;
           --set		   v_patname='aa'; 
		  
		   if(presdeptcode='' or presdeptcode='0') then
		   set v_presdept='未指定';
		   else
		   select name into v_presdept from BASE_DEPT_PROPERTY where dept_id=int(presdeptcode);
		   end if;
		   if(presdoccode='' or presdoccode='0') then
		   set v_presdoc='未指定';
		   else
		   select name into v_presdoc from BASE_EMPLOYEE_PROPERTY where EMPLOYEE_ID=int(presdoccode);
		   end if;
		   
		   select item_name into v_itemtype from base_stat_zykj where code=(select zykj_code from base_stat_item where code=itemtype);
		   
		   select count(*) into v_count from session.tmp_kjxmFee where 科室=v_presdept and 医生=v_presdoc and patlist_id=patlistid;
		   
		   if(v_count>0) then
		      set sSQL='update session.tmp_kjxmFee set ' || v_itemtype || ' = ' || v_itemtype || '+ ' || char(fee) || ' where  科室 = ''' || v_presdept || ''' and 医生= ''' || v_presdoc || ''' and patlist_id= '||char(patlistid)||' ';		  
			    
		   else
		      set sSQL='insert into session.tmp_kjxmFee(科室,医生,病人姓名,patlist_id,' || v_itemtype || ') values('''|| v_presdept ||''','''|| v_presdoc ||''','''||v_patname||''','||char(patlistid)||','|| char(fee) ||')';
		   end if;
		   
		      prepare   s1   from   sSql;   
              execute   s1;
		  end for;
	
	end if;
		  
		 -- 床日
		 update session.tmp_kjxmFee  set 
		 床日=(select 
					 case 
						when pattype in ('1','2') then  
						current date - curedate
						when pattype in('3','4','5') then
						outdate-curedate
						else 0 end 
						from zy_patlist where zy_patlist.patlistid= patlist_id) ;
		 
		  
	    update session.tmp_kjxmFee set 
		药品收入小计=(中药 + 中成药 + 西药),
		特检收入小计=(放射 + CT + 检验 + A超 + B超 + 彩超 + 胃镜 + 多普勒),
		医疗收入小计=(床位 + 护理 + 诊查 + 治疗 + 输血 + 输氧 + 材料 + 煎药 + 车费 + 理疗 + 手术 + 麻醉 + 高压氧 + 碎石 + 水电 + 急出诊 + 核磁共振 + 其他);
		
		update session.tmp_kjxmFee set 合计=(药品收入小计 + 特检收入小计 + 医疗收入小计);
		
		insert into session.tmp_kjxmFee
		 select '合计' as 科室,'' as 医生,'' as 病人姓名, 0 as patlist_id, sum(合计) as 合计,sum(中药) as 中药,sum(中成药) as 中成药,sum(西药) as 西药, sum(药品收入小计) as 药品收入小计,
		 sum(放射) as 放射, sum(CT) as CT ,sum(检验) as 检验, sum(A超) as A超,sum(B超) as B超,sum(彩超) as 彩超,sum(胃镜) as 胃镜,sum(多普勒) as 多普勒,sum(特检收入小计) as 特检收入小计,
		 sum(床日) as 床日,
		 sum(床位) as 床位, sum(护理) as 护理, sum(诊查) as 诊查,sum(治疗) as 治疗,sum(输血) as 输血,sum(输氧) as 输氧,sum(材料) as 材料, sum(煎药) as 煎药, sum(车费) as 车费,sum(理疗) as 理疗,sum(手术) as 手术,sum(麻醉) as 麻醉,sum(高压氧) as 高压氧,sum(碎石) as 碎石,sum(水电) as 水电,sum(急出诊) as 急出诊,sum(核磁共振) as 核磁共振,sum(其他) as 其他 ,sum(医疗收入小计) as 医疗收入小计
		 from session.tmp_kjxmFee;
   
   
   
  end p2;
  begin
   declare cur_01 cursor with return for
     select * from session.tmp_kjxmFee;
   open cur_01;
  end;
end p1;

SET SCHEMA DB2INST2;

SET CURRENT PATH = "SYSIBM","SYSFUN","SYSPROC","SYSIBMADM","DB2INST2";

CREATE PROCEDURE "DB2INST2"."SP_ZY_FEERPT"
 (IN "V_BTIME" TIMESTAMP, 
  IN "V_ETIME" TIMESTAMP, 
  IN "V_TYPE" INTEGER, 
  IN "V_ZYDEPT" INTEGER, 
  OUT "ERR_CODE" INTEGER, 
  OUT "ERR_TEXT" CHARACTER(100)
 ) 
  SPECIFIC "DB2INST2"."SQL100903162820700"
  LANGUAGE SQL
  NOT DETERMINISTIC
  CALLED ON NULL INPUT
  EXTERNAL ACTION
  OLD SAVEPOINT LEVEL
  MODIFIES SQL DATA
  INHERIT SPECIAL REGISTERS
  p1: begin     
	
	declare v_presdept varchar(20);
	declare v_presdoc varchar(20); 
	declare v_itemtype varchar(20);
	declare v_count int; 
	Declare   sSQL   varchar(1000);   
	
 
declare global temporary table tmp_kjxmFee(
	科室 varchar(20),
	医生 varchar(20),
	合计 decimal(18,2) DEFAULT 0,
    中药 decimal(18,2) DEFAULT 0,
	中成药 decimal(18,2) DEFAULT 0, 
	西药 decimal(18,2) DEFAULT 0,
	药品收入小计 decimal(18,2) DEFAULT 0,
	放射 decimal(18,2) DEFAULT 0,
	CT decimal(18,2) DEFAULT 0,
	检验 decimal(18,2) DEFAULT 0,
	A超 decimal(18,2) DEFAULT 0,
	B超 decimal(18,2) DEFAULT 0,
	彩超 decimal(18,2) DEFAULT 0,
	胃镜 decimal(18,2) DEFAULT 0,
	多普勒 decimal(18,2) DEFAULT 0,
	特检收入小计 decimal(18,2) DEFAULT 0,
	床位 decimal(18,2) DEFAULT 0,
	护理 decimal(18,2) DEFAULT 0,
	诊查 decimal(18,2) DEFAULT 0,
	治疗 decimal(18,2) DEFAULT 0,
	输血 decimal(18,2) DEFAULT 0,
	输氧 decimal(18,2) DEFAULT 0,
	材料 decimal(18,2) DEFAULT 0,
	煎药 decimal(18,2) DEFAULT 0,
	车费 decimal(18,2) DEFAULT 0,
	理疗 decimal(18,2) DEFAULT 0, 
	手术 decimal(18,2) DEFAULT 0,
	麻醉 decimal(18,2) DEFAULT 0,
	高压氧 decimal(18,2) DEFAULT 0,
	碎石 decimal(18,2) DEFAULT 0,
	水电 decimal(18,2) DEFAULT 0,
	急出诊 decimal(18,2) DEFAULT 0,
	核磁共振 decimal(18,2) DEFAULT 0,
	其他 decimal(18,2) DEFAULT 0,
	医疗收入小计 decimal(18,2) DEFAULT 0
	      )
     not logged on commit preserve rows with replace in usertemp1;
	 
	  
	 
	
	
	p2: begin
	    if(V_TYPE=1)
		then
	     FOR each_record AS 
			 select
			   presdeptcode,presdoccode,itemtype,sum(tolal_fee) fee,date(costdate) costdate
		       from DB2INST2.ZY_PRESORDER where charge_flag=1 and costdate>=V_BTIME  and costdate<=V_ETIME 
		       group by presdeptcode,presdoccode,itemtype,date(costdate)
			   order by  presdeptcode,presdoccode		
          do
		   if(presdeptcode='' or presdeptcode='0') then
		   set v_presdept='未指定';		
		   else
		   select name into v_presdept from BASE_DEPT_PROPERTY where dept_id=int(presdeptcode);
		   end if;
		   if(presdoccode='' or presdoccode='0') then
		   set v_presdoc='未指定';		
		   else
		   select name into v_presdoc from BASE_EMPLOYEE_PROPERTY where EMPLOYEE_ID=int(presdoccode);
		   end if;
		   
		   select item_name into v_itemtype from base_stat_zykj where code=(select zykj_code from base_stat_item where code=itemtype);
		   
		   select count(*) into v_count from session.tmp_kjxmFee where 科室=v_presdept and 医生=v_presdoc;
		   
		   if(v_count>0) then
		      set sSQL='update session.tmp_kjxmFee set ' || v_itemtype || ' = ' || v_itemtype || '+ ' || char(fee) || ' where  科室 = ''' || v_presdept || ''' and 医生= ''' || v_presdoc || ''' ';		  
			    
		   else
		      set sSQL='insert into session.tmp_kjxmFee(科室,医生,' || v_itemtype || ') values('''|| v_presdept ||''','''|| v_presdoc ||''','|| char(fee) ||')';
		   end if;
		   
		      prepare   s1   from   sSql;   
              execute   s1;
		  end for;
		 else
		   FOR each_record AS 
			 select
			   presdeptcode,presdoccode,itemtype,sum(tolal_fee) fee,date(costdate) costdate
		       from DB2INST2.ZY_PRESORDER where charge_flag=1 and costdate>=V_BTIME  and costdate<=V_ETIME  and int(presdeptcode)=V_ZYDEPT  
		       group by presdeptcode,presdoccode,itemtype,date(costdate)
			   order by  presdeptcode,presdoccode		
          do
		   if(presdeptcode='' or presdeptcode='0' ) then
		   set v_presdept='未指定';
		   else
		   select name into v_presdept from BASE_DEPT_PROPERTY where dept_id=int(presdeptcode);
		   end if;
		   if(presdoccode='' or presdoccode='0') then
		   set v_presdoc='未指定';
		   else
		   select name into v_presdoc from BASE_EMPLOYEE_PROPERTY where EMPLOYEE_ID=int(presdoccode);
		   end if;
		   
		   select item_name into v_itemtype from base_stat_zykj where code=(select zykj_code from base_stat_item where code=itemtype);
		   
		   select count(*) into v_count from session.tmp_kjxmFee where 科室=v_presdept and 医生=v_presdoc;
		   
		   if(v_count>0) then
		      set sSQL='update session.tmp_kjxmFee set ' || v_itemtype || ' = ' || v_itemtype || '+ ' || char(fee) || ' where  科室 = ''' || v_presdept || ''' and 医生= ''' || v_presdoc || ''' ';		  
			    
		   else
		      set sSQL='insert into session.tmp_kjxmFee(科室,医生,' || v_itemtype || ') values('''|| v_presdept ||''','''|| v_presdoc ||''','|| char(fee) ||')';
		   end if;
		   
		      prepare   s1   from   sSql;   
              execute   s1;
		  end for;
		  end if;
	    update session.tmp_kjxmFee set 
		药品收入小计=(中药 + 中成药 + 西药),
		特检收入小计=(放射 + CT + 检验 + A超 + B超 + 彩超 + 胃镜 + 多普勒),
		医疗收入小计=(床位 + 护理 + 诊查 + 治疗 + 输血 + 输氧 + 材料 + 煎药 + 车费 + 理疗 + 手术 + 麻醉 + 高压氧 + 碎石 + 水电 + 急出诊 + 核磁共振+其他);
		
		update session.tmp_kjxmFee set 合计=(药品收入小计 + 特检收入小计 + 医疗收入小计);
		
   insert into session.tmp_kjxmFee
		 select '合计' as 科室,'' as 医生, sum(合计) as 合计,sum(中药) as 中药,sum(中成药) as 中成药,sum(西药) as 西药, sum(药品收入小计) as 药品收入小计,
		 sum(放射) as 放射, sum(CT) as CT ,sum(检验) as 检验, sum(A超) as A超,sum(B超) as B超,sum(彩超) as 彩超,sum(胃镜) as 胃镜,sum(多普勒) as 多普勒,sum(特检收入小计) as 特检收入小计,
		 sum(床位) as 床位, sum(护理) as 护理, sum(诊查) as 诊查,sum(治疗) as 治疗,sum(输血) as 输血,sum(输氧) as 输氧,sum(材料) as 材料, sum(煎药) as 煎药, sum(车费) as 车费,sum(理疗) as 理疗,sum(手术) as 手术,sum(麻醉) as 麻醉,sum(高压氧) as 高压氧,sum(碎石) as 碎石,sum(水电) as 水电,sum(急出诊) as 急出诊,sum(核磁共振) as 核磁共振,sum(其他) as 其他 ,sum(医疗收入小计) as 医疗收入小计
		 from session.tmp_kjxmFee;
   
   
   
  end p2;
  begin
   declare cur_01 cursor with return for
     select * from session.tmp_kjxmFee;
   open cur_01;
  end;
end p1;



-- End of generated script for 220.128.5.3-DB2-LLZYDB (db2inst2)