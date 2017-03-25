using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EQIS
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Dictionary<String, String> user = new Dictionary<string, string>();
            //测试查询功能
            //user.Add("id", "2");
            //Application.Run(new Query(user));
            Application.Run(new WelcomeForm());
        }
    }
}
