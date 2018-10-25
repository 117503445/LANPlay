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
            Serializer serializer = new Serializer(this, "WdServer", new List<string>() { "Clients" });
        }

        public List<Client> Clients { get; set; }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Clients.Add(new Client());
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
