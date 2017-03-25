using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializableAndDeserialize
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            for (int i = 0; i < 100000; i++ )
            {
                dic.Add("key" + i, "value1");
            }

            using (FileStream fs = new FileStream("txt/test.data", FileMode.OpenOrCreate))
            {

                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, dic);
                fs.Close();
            }

            using (FileStream fs = new FileStream("txt/test.data", FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                dic = (Dictionary<string, string>)formatter.Deserialize(fs);
                fs.Close();
            }
            foreach(string key in dic.Keys)
            {
                Console.WriteLine("keys:" + key + " value:" + dic[key]);
            }

            Console.ReadKey();
        }
    }
}
