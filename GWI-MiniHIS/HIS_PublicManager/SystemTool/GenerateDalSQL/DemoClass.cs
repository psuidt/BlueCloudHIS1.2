using System;
using HIS.BLL;
using HIS.SYSTEM.Core;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.SYSTEM.PubicBaseClasses;


public class ClassDal:IDalSQL
{

    

    public string GetDebugSQL()
    {

        RelationalDatabase oleDb = null;
        RelationalDatabase _OleDB = null;
        EntityConfig.BindConfig_DAL();
        oleDb = new OleDB();
        _OleDB = oleDb;


        string strWhere_1 = "a.zyfp_code" + oleDb.EuqalTo() + "b.code";
        string childtable_1 = oleDb.ChildTable(oleDb.TableNameBM(Tables.BASE_STAT_ITEM, "a") + "," + oleDb.TableNameBM(Tables.BASE_STAT_ZYFP, "b"), "aa", strWhere_1,
                                    "a.code",
                                    oleDb.FiledNameBM("b.item_name", "itemname"));
        string sum_2 = oleDb.Sum(Tables.zy_presorder.TOLAL_FEE, "");
        string _gs_1_3 = oleDb.DBConvert("aa." + Tables.base_stat_item.CODE, "int");
        string _gs_1_4 = oleDb.DBConvert(Tables.zy_presorder.ITEMTYPE, "int");

        string strWhere_5 = _gs_1_3 + oleDb.EuqalTo() + _gs_1_4;
        string childtable_2 = oleDb.ChildTable(childtable_1, "itemname", strWhere_5,
                    " itemname ");
        string strWhere_6 = Tables.zy_presorder.PATLISTID + oleDb.EuqalTo() + 1 + oleDb.And() + Tables.zy_presorder.COSTMASTERID + oleDb.EuqalTo() + "0" + oleDb.And() + Tables.zy_presorder.CHARGE_FLAG + oleDb.EuqalTo() + "1";
        string childtable_3 = oleDb.ChildTable(Tables.ZY_PRESORDER, "a", strWhere_6,
                    childtable_2,
                       "tolal_fee");
        string strsql = oleDb.Table(childtable_3, "group by a.itemname", "",
                    "itemname",
                      oleDb.FiledNameBM(sum_2, "tolal_fee"));

        return strsql;
    }

    public string GetReleaseSQL()
    {
        RelationalDatabase oleDb = null;
        RelationalDatabase _OleDB = null;

        EntityConfig.BindConfig();
        oleDb = new OleDB();
        _OleDB = oleDb;

        string strWhere_1 = "a.zyfp_code" + oleDb.EuqalTo() + "b.code";
        string childtable_1 = oleDb.ChildTable(oleDb.TableNameBM(Tables.BASE_STAT_ITEM, "a") + "," + oleDb.TableNameBM(Tables.BASE_STAT_ZYFP, "b"), "aa", strWhere_1,
                                    "a.code",
                                    oleDb.FiledNameBM("b.item_name", "itemname"));
        string sum_2 = oleDb.Sum(Tables.zy_presorder.TOLAL_FEE, "");
        string _gs_1_3 = oleDb.DBConvert("aa." + Tables.base_stat_item.CODE, "int");
        string _gs_1_4 = oleDb.DBConvert(Tables.zy_presorder.ITEMTYPE, "int");

        string strWhere_5 = _gs_1_3 + oleDb.EuqalTo() + _gs_1_4;
        string childtable_2 = oleDb.ChildTable(childtable_1, "itemname", strWhere_5,
                    " itemname ");
        string strWhere_6 = Tables.zy_presorder.PATLISTID + oleDb.EuqalTo() + 1 + oleDb.And() + Tables.zy_presorder.COSTMASTERID + oleDb.EuqalTo() + "0" + oleDb.And() + Tables.zy_presorder.CHARGE_FLAG + oleDb.EuqalTo() + "1";
        string childtable_3 = oleDb.ChildTable(Tables.ZY_PRESORDER, "a", strWhere_6,
                    childtable_2,
                       "tolal_fee");
        string strsql = oleDb.Table(childtable_3, "group by a.itemname", "",
                    "itemname",
                      oleDb.FiledNameBM(sum_2, "tolal_fee"));

        return strsql;
    }
}

