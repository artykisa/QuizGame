using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientBrain
{
    public partial class Menu : Form
    {
        string nickname;
        public Menu(string ip,string nick)
        {
            InitializeComponent();
            ProfileBut.Hide();//OPA TUT PRYACHEM
            nickname = nick;
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void ConnectToGame_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1(nickname);
            f1.Show();
            this.Hide();
        }

        private void ProfileBut_Click(object sender, EventArgs e)
        {
            Profile proform = new Profile(nickname);
            proform.Show();
            this.Hide();
        }
    }
}
