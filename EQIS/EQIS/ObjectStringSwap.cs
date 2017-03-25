using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;

namespace EQIS
{
    class ObjectStringSwap
    {
        //序列化
        public static String bytes2String(byte[] bs)
        {
            return System.Text.UTF8Encoding.Default.GetString(bs);
        }
        //反序列化
        public static byte[] string2Bytes(String str)
        {
            return System.Text.UTF8Encoding.Default.GetBytes(str);
        }
    }
}
