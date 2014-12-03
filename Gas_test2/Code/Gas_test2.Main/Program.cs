using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Gas_test2.Main
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

            //1.启动升级。
            EAS.Windows.Application.Upgrade();
            //2.启动平台。
            EAS.WinClient.Application.ConfigResource(new Gas_test2.Res.Resources());
            EAS.WinClient.Application.Start();
        }
    }
}
