using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnSerialPort
{
    [Serializable]
    class LocationData
    {
        private bool isValid;
        private String local;
        private DateTime sDt;
        private DateTime eDt;
        public bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }
        public DateTime Sdt
        {
            get { return sDt; }
            set { sDt = value; }
        }
        public System.DateTime Edt
        {
            get { return eDt; }
            set { eDt = value; }
        }
        public System.String Local
        {
            get { return local; }
            set { local = value; }
        }

        public LocationData()
        {
            isValid = false;
        }

        public String toString()
        {
            return "地点：" + local + " 开始时间：" + sDt + " 结束时间：" + eDt + "\n";
        }
    }
}
