using System;

namespace HIS.Model
{
    public class BASE_DEPT_LAYER
    {
        private int layer_id;
        private int p_layer_id;
        private string name;
        public BASE_DEPT_LAYER()
        {
        }

        public int LAYER_ID
        {
            get
            {
                return layer_id;
            }
            set
            {
                layer_id = value;
            }
        }
        public int P_LAYER_ID
        {
            get
            {
                return p_layer_id;
            }
            set
            {
                p_layer_id = value;
            }
        }
        public string NAME
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
    }
}
