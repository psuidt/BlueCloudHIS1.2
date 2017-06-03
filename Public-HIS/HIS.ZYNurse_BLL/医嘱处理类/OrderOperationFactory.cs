using System;
using System.Collections.Generic;
using System.Text;
using HIS.SYSTEM.Core;
using HIS.Model;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;


namespace HIS.ZYNurse_BLL
{
    public class OrderOperationFactory
    {
        public static AbstractOrderOperation CreateConcreteOrder(ZY_DOC_ORDERRECORD zy_doc_orderrecord)
        {
          AbstractOrderOperation orderOperation=null;
          
          if (zy_doc_orderrecord.ITEM_TYPE < 4)
          {
            if (zy_doc_orderrecord.ORDER_TYPE == 0 && zy_doc_orderrecord.EXEC_DEPT == -1)//长期自备药 
            {
                orderOperation = new SelfPrepareDrug();
            }
            else if (zy_doc_orderrecord.ORDER_TYPE==0 && zy_doc_orderrecord.STATUS_FALG==4)//长期停药品
            {
                orderOperation = new NormalStopDrug();
            }
            else if(zy_doc_orderrecord.ORDER_TYPE==0)//长期正常药
            {
                orderOperation = new NormalDrug();
            }
            else if (zy_doc_orderrecord.ORDER_TYPE == 7)//出院带药
            {
                orderOperation = new OutHospitalDrug();
            }
            else if (zy_doc_orderrecord.ORDER_TYPE == 1 && zy_doc_orderrecord.EXEC_DEPT == -1)//临嘱自备药
            {
                orderOperation = new SelfPrepareTempDrug();
            }
            else if (zy_doc_orderrecord.ORDER_TYPE == 1 && zy_doc_orderrecord.PS_ORDERID != 0 && zy_doc_orderrecord.ITEM_CODE == "")//皮试医嘱 update by heyan  皮试说明数量医生可以修改，不能以数量判断
            {
                orderOperation = new PsStatementOrder();
            }
            else if (zy_doc_orderrecord.ORDER_TYPE ==5)//交病人
            {
                orderOperation = new NormalTempDrug();
            }
            else if (zy_doc_orderrecord.ORDER_TYPE == 1)//临时正常药品
            {
                orderOperation = new NormalTempDrug();
            }
          }
          else if (zy_doc_orderrecord.ITEM_TYPE == 7 || zy_doc_orderrecord.ITEM_TYPE == 10)
          {
              if (zy_doc_orderrecord.ITEM_TYPE == 7 && zy_doc_orderrecord.ORDER_TYPE == 0)//长期说明性
              {
                  orderOperation = new LongStateOrder();
              }
              else if (zy_doc_orderrecord.ITEM_TYPE == 7 && zy_doc_orderrecord.ORDER_TYPE == 1)//临时说明性
              {
                  orderOperation = new TempStateOrder();
              }
              else if (zy_doc_orderrecord.ITEM_TYPE == 10 && zy_doc_orderrecord.ORDER_TYPE == 0)//产后术后
              {
                  orderOperation = new PregOrder();
              }
              else if (zy_doc_orderrecord.ITEM_TYPE == 10 && zy_doc_orderrecord.ORDER_TYPE == 1)//出院死亡转科
              {
                  orderOperation = new OutDeathOrder();
              }
          } 
          else 
          {
              if (zy_doc_orderrecord.ORDER_TYPE == 0 && zy_doc_orderrecord.TC_ID == 0&&zy_doc_orderrecord.STATUS_FALG==4)//长期停项目
              {
                  orderOperation = new LongStopItem();
              }
              else if (zy_doc_orderrecord.ORDER_TYPE == 0 && zy_doc_orderrecord.TC_ID == 0)//长期单条医嘱
              {
                  orderOperation = new LongSingleItem();
              }
              else if (zy_doc_orderrecord.ORDER_TYPE==0 && zy_doc_orderrecord.TC_ID!=0)//长期组合项目
              {
                  orderOperation=new LongComponentItem();
              }
              else if (zy_doc_orderrecord.ORDER_TYPE == 1 && zy_doc_orderrecord.TC_ID == 0)//临时单条医嘱
              {
                  orderOperation = new TempSingleItem();
              }
              else if (zy_doc_orderrecord.ORDER_TYPE==1 && zy_doc_orderrecord.TC_ID != 0)//临时组合医嘱
              {
                  orderOperation = new TempComponentItem();
              }
          }          
          return orderOperation;
        }
    }
}
