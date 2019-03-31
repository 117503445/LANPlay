using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using Newtonsoft.Json;
namespace KeySend_Server
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            string path = "Users.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                User.Users = JsonConvert.DeserializeObject<List<User>>(json);
            }
            else
            {
                User.CreateTestData();
                string json = JsonConvert.SerializeObject(User.Users);
                File.WriteAllText(path, json);
            }
            Console.WriteLine(JsonConvert.SerializeObject(User.Users));
        }
    }
}
