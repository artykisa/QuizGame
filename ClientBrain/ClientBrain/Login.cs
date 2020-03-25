using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;


namespace ClientBrain
{
    public partial class Login : Form
    {
        string ip = "";
        public static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public Login()
        {
            InitializeComponent();
            noacc.Hide();
            socket.Connect(ip, 904);
            this.AcceptButton = button1;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string temp = "";
            string data = textBoxlogin.Text + " " + textBoxpassword.Text + ".";
            byte[] buffer;

            buffer = Encoding.ASCII.GetBytes(data);
            socket.Send(buffer);

            byte[] bytes = new byte[1024];

            int bytesRec = socket.Receive(bytes);




            temp = Encoding.ASCII.GetString(bytes, 0, bytesRec);
            // socket.Shutdown(SocketShutdown.Both);
            if (temp != "0" && temp != "")
            {
                Menu menu = new Menu(ip, temp);
                menu.Show();
                this.Hide();
                //this.Enabled = false;
            }
            else
            {
                label3.Show();
                textBoxpassword.Text = "";
            }

        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void noacc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration f3 = new Registration();
            f3.ShowDialog();
        }
    }
}
