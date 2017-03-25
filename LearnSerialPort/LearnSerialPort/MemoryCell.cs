using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnSerialPort
{
    /*
     * 存储单元，用于存储数据写进文件
     */
    [Serializable]
    class MemoryCell
    {
        private DateTime dt;
        private DataBits db;
        public LearnSerialPort.DataBits Db
        {
            get { return db; }
            set { db = value; }
        }
        public DateTime Dt
        {
            get { return dt; }
            set { dt = value; }
        }

        public MemoryCell(DateTime dt, DataBits db)
        {
            this.dt = dt;
            this.db = db;
        }
    }
}
