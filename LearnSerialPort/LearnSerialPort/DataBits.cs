using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnSerialPort
{
    [Serializable]
    class DataBits
    {
        private static int bits = 32;
        private static int start1 = 66;
        private static int start2 = 77;
        private byte[] items;
        
        //PM浓度（CF=1，标准颗粒物）
        private int pM1_0CF1;
        private int pM2_5CF1;
        private int pM10CF1;

        //PM浓度（大气环境下）
        private int pM1_0;
        private int pM2_5;
        private int pM10_0;

        //0.1升空气中直径在？以上的颗粒物个数
        private int p0_3;
        private int p0_5;
        private int p1_0;
        private int p2_5;
        private int p5_0;
        private int p10;
        private bool tag;

        public DataBits(byte[] buffer)
        {
            try
            { 
                //items[i] = Convert.ToInt32(vars[i], 16);
                items = buffer;
                int b = 16 * 16;
                pM1_0CF1 = items[4] * b + items[5];
                pM2_5CF1 = items[6] * b + items[7];
                pM10CF1 = items[8] * b + items[9];

                pM1_0 = items[10] * b + items[11];
                pM2_5 = items[12] * b + items[13];
                pM10_0 = items[14] * b + items[15];

                p0_3 = items[16] * b + items[17];
                p0_5 = items[18] * b + items[19];
                p1_0 = items[20] * b + items[21];
                p2_5 = items[22] * b + items[23];
                p5_0 = items[24] * b + items[25];
                p10 = items[26] * b + items[27];
                tag = true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                tag = false;
            }

        }
        public bool isValid()
        {
            //初始化失败
            if(!tag)
            {
                return false;
            }
            //数据不满足32个
            if (items.Count() != bits)
            {
                return false;
            }
            //判断起始符1和起始符2
            if (items[0] != start1 || items[1] != start2)
            {
                return false;
            }
            //if不符合校验码return false；
            return true;
        }
        public int M1_0CF1{ get { return pM1_0CF1; }    set { pM1_0CF1 = value; }}
        public int M2_5CF1{ get { return pM2_5CF1; }    set { pM2_5CF1 = value; }}
        public int M10CF1{  get { return pM10CF1; }   set { pM10CF1 = value; }}
        public int M1_0{    get { return pM1_0; }   set { pM1_0 = value; }}
        public int M2_5{    get { return pM2_5; }   set { pM2_5 = value; }}
        public int M10_0{   get { return pM10_0; }  set { pM10_0 = value; }}
        public int P0_3{    get { return p0_3; }    set { p0_3 = value; }}
        public int P0_5{    get { return p0_5; }    set { p0_5 = value; }}
        public int P1_0{    get { return p1_0; }    set { p1_0 = value; }}
        public int P2_5{    get { return p2_5; }    set { p2_5 = value; }}
        public int P5_0{    get { return p5_0; }    set { p5_0 = value; }}
        public int P10{     get { return p10; } set { p10 = value; }}

        public override string ToString()
        {
            return " PM1.0(CF = 1):" + M1_0CF1 + "; PM2.5(CF = 1):" + M2_5CF1 + "; PM10(CF = 1):" + M10CF1 +
                "; PM1.0:" + M1_0 + "; PM2.5:" + M2_5 + "; PM10:" + M10_0 +
                "; 0.3um颗粒物:" + P0_3 + "; 0.5um颗粒物:" + p0_5 + "; 1.0um颗粒物:" + p1_0 + "; 2.5um颗粒物:" + p2_5 +
                "; 5.0um颗粒物:" + p5_0 + "; 10um颗粒物:" + p10 + "\n";
        }
    }
}
