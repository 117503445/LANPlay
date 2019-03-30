using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TLib.Windows;

namespace KeySend_Server
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Dictionary<Key, Key> d = new Dictionary<Key, Key>();
            d.Add(Key.W,Key.Q);
            User.Users.Add(new User() { IP="hello",});
            foreach (var user in User.Users)
            {
                Console.WriteLine(user);
            }


            var udp = new UdpClient(804);
            Task.Run(async () =>
            {
                while (true)
                {
                    var result = await udp.ReceiveAsync();
                    string ip = result.RemoteEndPoint.Address.ToString();
                    Key sendKey = (Key)result.Buffer[1];
                    if (result.Buffer[0] == 0)
                    {
                        KeyboardSimulation.Press(sendKey);
                    }
                    else
                    {
                        KeyboardSimulation.Release(sendKey);
                    }
                    //Console.WriteLine(sendKey);
                    Console.WriteLine(ip);
                }
            });
        }
    }
}
