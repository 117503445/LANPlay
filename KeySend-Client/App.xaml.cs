using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace KeySend_Client
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public static string IP = "";

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            string path = "ip.txt";
            if (File.Exists(path))
            {
                IP = File.ReadAllText(path);
            }
            else
            {
                File.Create(path).Dispose();
            }
        }
    }
}
