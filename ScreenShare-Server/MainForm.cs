using RDPCOMAPILib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenShare_Server
{
    public partial class MainForm : Form
    {
        private readonly IRDPSRAPIInvitation invitation;
        private readonly Resolution reso;
        public MainForm()
        {
            InitializeComponent();

            reso = new Resolution();

            var rdp = new RDPSession();
            rdp.OnAttendeeConnected += Rdp_OnAttendeeConnected;
            rdp.Open();
            invitation = rdp.Invitations.CreateInvitation("117503445", "CastGroup", "", 64);

            string path = "Ips.txt";
            if (File.Exists(path))
            {
                Program.Ips = File.ReadAllLines(path).ToList();
            }
            else
            {
                File.Create(path).Dispose();
            }

            foreach (var ip in Program.Ips)
            {
                if (ip[0] != '#')
                {
                    LbIP.Items.Add(" " + ip);
                }
            }
        }

        private readonly UdpClient Udp = new UdpClient(901);

        private void Rdp_OnAttendeeConnected(object pObjAttendee)
        {
            IRDPSRAPIAttendee pAttendee = pObjAttendee as IRDPSRAPIAttendee;
            pAttendee.ControlLevel = CTRL_LEVEL.CTRL_LEVEL_VIEW;
            Console.WriteLine("Attendee Connected: " + pAttendee.RemoteName);
        }

        private void BtnCast_Click(object sender, EventArgs e)
        {

            foreach (var ip in Program.Ips)
            {
                if (ip[0] == '#')
                {
                    continue;
                }
                byte[] b = Encoding.Default.GetBytes(invitation.ConnectionString);
                Udp.Send(b, b.Length, ip, 900);
            }
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            if (Screen.PrimaryScreen.Bounds.Width != 1280)
            {
                reso.ChangeResolution(1280, 720);
            }
            else
            {
                reso.ChangeResolution(reso.autoWidth, reso.autoHeight);
            }
        }
    }
}
