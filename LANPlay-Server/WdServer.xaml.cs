using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TLib.Software;
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
            Serializer serializer = new Serializer(this, "WdServer.xml", new List<string>() { "Clients" });
        }
        public List<Client> Clients { get; set; } = new List<Client>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var udp = new UdpClient(800);
            Task.Run(async () =>
            {
                while (true)
                {
                    var result = await udp.ReceiveAsync();
                    foreach (var Client in Clients)
                    {
                        if (Client.ID == result.Buffer[0])
                        {
                            foreach (var key in Client.Keys)
                            {
                                if (key == result.Buffer[2])
                                {
                                    Key sendKey = (Key)result.Buffer[2];
                                    if (result.Buffer[1] == 0)
                                    {
                                        KeyboardSimulation.Press(sendKey);
                                    }
                                    else
                                    {
                                        KeyboardSimulation.Release(sendKey);
                                    }
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
            });
        }
    }
}
