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
    public partial class Profile : Form
    {
        string nickname;
        public Profile(string nick)
        {
            InitializeComponent();
            nickname = nick;
        }
        private System.Windows.Forms.OpenFileDialog openFile;
        private void UpdateBut_Click(object sender, EventArgs e)
        {
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            openFile.DefaultExt = "jpg";
            openFile.CheckFileExists = true;
            openFile.ShowDialog();
            string filename = openFile.FileName;
            statTextBox.Text = filename;
        }
    }
}
