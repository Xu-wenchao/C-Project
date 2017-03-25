using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQIS
{
    public class DataModel
    {
        private int start1;
        private int start2;
        private int pm25;
        private int pm10;
        private int temperature;
        private int humidity;
        private byte[] bs;
        private bool tag = false;
        public bool Tag
        {
            get { return tag; }
            set { tag = value; }
        }
        public DataModel(byte[] bs)
        {
            try
            {
                this.bs = bs;
                start1 = bs[0] * 10 + bs[1];
                start2 = bs[2] * 10 + bs[3];
                pm25 = bs[4] * 10 + bs[5];
                pm10 = bs[6] * 10 + bs[7];
                temperature = bs[8] * 10 + bs[9];
                humidity = bs[10] * 10 + bs[11];
                if (start1 == (136 * 10 + 102) && start2 == (19 * 10 + 20))
                { 
                    tag = true;
                }
            }
            catch (Exception)
            {
                tag = false;
            }
        }
        public byte[] Bs
        {
            get { return bs; }
            set { bs = value; }
        }
        public int Start1
        {
            get { return start1; }
            set { start1 = value; }
        }
        public int Start2
        {
            get { return start2; }
            set { start2 = value; }
        }
        public int Pm25
        {
            get { return pm25; }
            set { pm25 = value; }
        }
        public int Pm10
        {
            get { return pm10; }
            set { pm10 = value; }
        }
        public int Temperature
        {
            get { return temperature; }
            set { temperature = value; }
        }
        public int Humidity
        {
            get { return humidity; }
            set { humidity = value; }
        }
        public override string ToString()
        {
            return "pm2.5" + pm25 + " pm10" + pm10 + " temperature" + temperature + " humidity" + humidity;
        }

    }
}
