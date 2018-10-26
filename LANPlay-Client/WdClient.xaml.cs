using System;
using System.Collections.Generic;
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
            Serializer serializer = new Serializer(this, "WdClient.xml", new List<string>() { nameof(IP), nameof(ID), nameof(IsHoldKey) });
        }
        public string IP { get; set; } = "127.0.0.1";
        public byte ID { get; set; } = 0;
        public bool IsHoldKey { get; set; } = false;


        UdpClient udp = new UdpClient(801);
        KeyboardHook keyboardHook;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            keyboardHook = new KeyboardHook();
            keyboardHook.KeyUp += KeyboardHook_OnKeyUp;
            keyboardHook.KeyDown += KeyboardHook_OnKeyDown;

            TbIP.Text = IP;
            TbID.Text = ID.ToString();

            CkbHook.IsChecked = IsHoldKey;
            keyboardHook.IsHoldKey = IsHoldKey;


        }

        private void KeyboardHook_OnKeyDown(object sender, KeyboardHookEventArgs e)
        {
            byte[] bytes = new byte[] { ID, 0, (byte)Convert.ToInt32(e.key) };
            udp.Send(bytes, bytes.Length, IP, 800);
            Console.WriteLine($"Send{bytes[0]}{bytes[1]}{bytes[2]}");
        }
        private void KeyboardHook_OnKeyUp(object sender, KeyboardHookEventArgs e)
        {
            byte[] bytes = new byte[] { ID, 1, (byte)Convert.ToInt32(e.key) };
            udp.Send(bytes, bytes.Length, IP, 800);
        }

        private void TbIP_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (TbIP.Text != "127.0.0.1")
            {
                IP = TbIP.Text;
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

        private void TbID_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (TbID.Text != "0")
            {
                try
                {
                    ID = byte.Parse(TbID.Text);
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
