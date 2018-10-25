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

namespace LANPlay_Server
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class WdServer : Window
    {
        public WdServer()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var udp = new UdpClient(800);
            Task.Run(async () =>
            {
                while (true)
                {
                    var result = await udp.ReceiveAsync();
                    Key key = (Key)result.Buffer[1];
                    if (result.Buffer[0] == 0)
                    {
                        KeyboardSimulation.Press(key);
                    }
                    else
                    {
                        KeyboardSimulation.Release(key);
                    }
                }
            });
        }
    }
}
