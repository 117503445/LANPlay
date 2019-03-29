using AxRDPCOMAPILib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenShare_Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
            int sort = 900;
            UdpClient client = new UdpClient(sort);
           
            Task.Run(async () =>
            {
                while (true)
                {
                    var result = await client.ReceiveAsync();
                    Console.WriteLine(result.RemoteEndPoint.Address);
                    var s = Encoding.Default.GetString(result.Buffer);
                    AxRDPViewer.Connect(s, Environment.UserName, "");
                    AxRDPViewer.SmartSizing = true;
                }
            });
        }
    }
}
