using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Windows;
using TLib.Software;
using TLib.Windows;
namespace LANPlay_Client
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class WdMain : Window
    {
        public WdMain()
        {
            InitializeComponent();
            Serializer serializer = new Serializer(this, "WdClient.xml", new List<string>() { "IPstr", "IsHoldKey" });
        }

        public string IPstr { get; set; } = "127.0.0.1";
        public bool IsHoldKey { get; set; } = false;


        UdpClient udp = new UdpClient(801);
        IPEndPoint iP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 800);
        KeyboardHook keyboardHook;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            keyboardHook = new KeyboardHook();
            keyboardHook.KeyUp += KeyboardHook_OnKeyUp;
            keyboardHook.KeyDown += KeyboardHook_OnKeyDown;

            TbIP.Text = IPstr;
            iP = new IPEndPoint(IPAddress.Parse(IPstr), 800);

            CkbHook.IsChecked = IsHoldKey;
            keyboardHook.IsHoldKey = IsHoldKey;


        }

        private void KeyboardHook_OnKeyDown(object sender, KeyboardHookEventArgs e)
        {
            return;
            udp.Send(new byte[] { 0, (byte)Convert.ToInt32(e.key) }, 2, iP);
        }
        private void KeyboardHook_OnKeyUp(object sender, KeyboardHookEventArgs e)
        {
            return;
            udp.Send(new byte[] { 1, (byte)Convert.ToInt32(e.key) }, 2, iP);
            Console.WriteLine(e.key);
        }

        private void TbIP_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (TbIP.Text != "127.0.0.1")
            {
                try
                {
                    iP = new IPEndPoint((IPAddress.Parse(TbIP.Text)), 800);
                    IPstr = TbIP.Text;
                }
                catch (Exception)
                {
                    //throw;
                }

            }
        }

        private void BtnBlack_Click(object sender, RoutedEventArgs e)
        {
            WdBlack wdBlack = new WdBlack();
            wdBlack.Show();
        }

        private void CkbHook_Click(object sender, RoutedEventArgs e)
        {
            if (keyboardHook != null)
            {
                IsHoldKey = (bool)CkbHook.IsChecked;
                keyboardHook.IsHoldKey = (bool)CkbHook.IsChecked;
            }
        }
    }
}
