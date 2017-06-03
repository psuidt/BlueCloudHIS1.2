using System.Collections;
using System.Data;

namespace HIS.Base_BLL
{
    public class DataCollection
    {
        private Hashtable htDatas;

        public DataCollection()
        {
            htDatas = new Hashtable();
        }

        public int Count
        {
            get
            {
                if ( htDatas == null )
                    return 0;
                else
                    return htDatas.Count;
            }
        }

        public Data this[DataEnum dataClass]
        {
            get
            {
                if ( htDatas.ContainsKey( dataClass ) )
                {
                    object objData = htDatas[dataClass];
                    return (Data)objData;
                }
                else
                {
                    DataTable table = BaseDal.GetDataTable( dataClass );
                    Data data = new Data( table );
                    htDatas.Add( dataClass , data );
                    return data;
                }
            }
        }

        public void ReLoad( DataEnum dataClass )
        {
            //重新读取数据
            DataTable table = BaseDal.GetDataTable( dataClass );
            Data data = new Data( table );
            if ( htDatas.ContainsKey( dataClass ) )
            {
                htDatas.Remove( dataClass );
            }
            htDatas.Add( dataClass , data );
        }
    }
}
