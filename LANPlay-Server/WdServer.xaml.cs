using System;
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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var udp = new UdpClient(800);
            Task.Run(async () =>
            {
                while (true)
                {
                    var result = await udp.ReceiveAsync();
                    Key sendKey = (Key)result.Buffer[2];
                    if (result.Buffer[1] == 0)
                    {
                        KeyboardSimulation.Press(sendKey);
                        Console.WriteLine(sendKey);
                    }
                    else
                    {
                        KeyboardSimulation.Release(sendKey);
                    }
                }
            });
        }
    }
}
