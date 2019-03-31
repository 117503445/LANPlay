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

            var udp = new UdpClient(800);
            Task.Run(async () =>
            {
                while (true)
                {
                    var result = await udp.ReceiveAsync();
                    string ip = result.RemoteEndPoint.Address.ToString();
                    Key sendKey = (Key)result.Buffer[1];
                    Key? k = User.MapKey(ip, sendKey);
                    if (k != null && User.IsAllowKey(ip, sendKey))
                    {
                        if (result.Buffer[0] == 0)
                        {
                            KeyboardSimulation.Press((Key)k);
                        }
                        else
                        {
                            KeyboardSimulation.Release((Key)k);
                        }
                    }
                }
            });
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var i = MessageBox.Show("Exit ?", "Exiting", MessageBoxButton.OKCancel);
            if (i == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
