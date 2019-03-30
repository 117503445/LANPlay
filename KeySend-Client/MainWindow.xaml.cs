using System;
using System.Collections.Generic;
using System.Linq;
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
using TLib.Software;
using System.Net.Sockets;

namespace KeySend_Client
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

        private readonly UdpClient udp = new UdpClient(801);
        KeyboardHook keyboardHook;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            keyboardHook = new KeyboardHook();
            keyboardHook.KeyUp += KeyboardHook_OnKeyUp;
            keyboardHook.KeyDown += KeyboardHook_OnKeyDown;

            Title += $" {App.IP}";
        }

        private void KeyboardHook_OnKeyDown(object sender, KeyboardHookEventArgs e)
        {
            byte[] bytes = new byte[] { 0, (byte)Convert.ToInt32(e.key) };
            udp.Send(bytes, bytes.Length, App.IP, 800);
            Console.WriteLine($"Send {bytes[0]} {bytes[1]}");
        }

        private void KeyboardHook_OnKeyUp(object sender, KeyboardHookEventArgs e)
        {
            byte[] bytes = new byte[] { 1, (byte)Convert.ToInt32(e.key) };
            udp.Send(bytes, bytes.Length, App.IP, 800);
            Console.WriteLine($"Send {bytes[0]} {bytes[1]}");
        }

        private void CkbHook_Click(object sender, RoutedEventArgs e)
        {
            if (keyboardHook != null)
            {
                keyboardHook.IsHoldKey = (bool)CkbHook.IsChecked;
            }
        }
    }
}
