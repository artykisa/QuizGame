using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
namespace ClientBrain
{
    public partial class Form1 : Form
    {
        public static string ip = "";
        public static Socket socket;
        ~Form1()
        {
            SocketSend.socket.Disconnect(true);
            SocketRecieve.socket.Disconnect(true);
            this.Close();
            Application.Exit();
        }
        public Form1(string nick)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Random rand = new Random();
            Player.nick = nick;
            
            socket.Connect(ip, 905);
            SocketRecieve.socket = socket;
            SocketSend.socket = socket;
            InitializeComponent();
            butvarq1.Hide();
            butvarq2.Hide();
            butvarq3.Hide();
            butvarq4.Hide();
            butsend.Hide();
            numofquestion.Text = "Your nick:" + Player.nick;
            Thread myThread = new Thread(new ThreadStart(Connection));
            myThread.Start();
        }
        private void WriteTextSafe(string text)
        {
            question.Text = text;
        }
        private void WriteTextSafe(string text, ref Button but)
        {
            but.Text = text;
        }
        private void ChangeEnable(ref Button but, bool temp)
        {
            but.Enabled = temp;
        }
        delegate void SafeCallDelegateStr(string str);
        delegate void SafeCallDelegateStrObj(string text, ref Button but);
        delegate void SafeCallDelegateChangeEnable(ref Button but,bool temp);
        void Connection()
        {
            SocketSend.sendstart();
            while (true)  
            {
                string rec=SocketRecieve.Recieve("wait");
                if (rec[0] == 'W' && rec[1] == '8')
                {
                    var d = new SafeCallDelegateStr(WriteTextSafe);
                    question.Invoke(d, new object[] { "Ожидание игроков:"+rec[2] });
                    continue;
                }
                else if (rec[0] == 'S' && rec[1] == 't' && rec[2] == 'a' && rec[3] == 'r' && rec[4] == 't')
                {
                    break;
                }

            }
            while (true)
            {
                string rec = SocketRecieve.Recieve("question");
                var b = new SafeCallDelegateChangeEnable(ChangeEnable);
                butvarq1.Invoke(b, butvarq1, true);
                var b1 = new SafeCallDelegateChangeEnable(ChangeEnable);
                butvarq2.Invoke(b1, butvarq2, true);
                var b2 = new SafeCallDelegateChangeEnable(ChangeEnable);
                butvarq3.Invoke(b2, butvarq3, true);
                var b3 = new SafeCallDelegateChangeEnable(ChangeEnable);
                butvarq4.Invoke(b3, butvarq4, true);
                var b4 = new SafeCallDelegateChangeEnable(ChangeEnable);
                butsend.Invoke(b4, butsend, true);
                if (rec[0] == 'n')
                {
                    Question Question = new Question();
                    for(int i = 1; i<rec.Length; i++)
                    {
                        Question.question += rec[i];
                    }
                    fornum();
                    var d = new SafeCallDelegateStr(WriteTextSafe);
                    question.Invoke(d, new object[] { Question.question });
                    
                }
                else if (rec[0]=='v')
                {
                    Question Question = new Question();
                    int temp = 0;
                    int tempo = 0;
                    for (int i = 1; ; i++)
                    {
                        if (rec[i] == '!' || rec[i]=='?'||rec[i]=='.')
                            temp++;
                        if (temp == 2)
                            break;
                        if (rec[i] == ',' || rec[i]=='.')
                        {
                            tempo++;
                            continue;
                        }
                        else if (temp == 0)
                            Question.question += rec[i];
                        else if (temp == 1)
                        {
                            if (tempo == 0)
                                Question.variant1 += rec[i];
                            else if(tempo==1)
                                Question.variant2 += rec[i];
                            else if (tempo == 2)
                                Question.variant3 += rec[i];
                            else if (tempo == 3)
                                Question.variant4 += rec[i];
                        }
                    }

                    forvar();
                    var d = new SafeCallDelegateStr(WriteTextSafe);
                    question.Invoke(d, new object[] { Question.question });
                    var d2 = new SafeCallDelegateStrObj(WriteTextSafe);
                    question.Invoke(d2, Question.variant1 , butvarq1);
                    var d3 = new SafeCallDelegateStrObj(WriteTextSafe);
                    question.Invoke(d3, Question.variant2 , butvarq2);
                    var d4 = new SafeCallDelegateStrObj(WriteTextSafe);
                    question.Invoke(d4, Question.variant3, butvarq3);
                    var d5 = new SafeCallDelegateStrObj(WriteTextSafe);
                    question.Invoke(d5,Question.variant4 , butvarq4);
                }
                else if (rec[0] == 'r')
                {

                    var d = new SafeCallDelegateStr(WriteTextSafe);
                    question.Invoke(d, new object[] { "Result="+rec });
                    var d2 = new SafeCallDelegate(answertextbox.Hide);
                    answertextbox.Invoke(d2);
                    d2 = new SafeCallDelegate(butsend.Hide);

                    butsend.Invoke(d2);
                    d2 = new SafeCallDelegate(butvarq1.Hide);

                    butvarq1.Invoke(d2);
                    d2 = new SafeCallDelegate(butvarq2.Hide);

                    butvarq2.Invoke(d2);
                    d2 = new SafeCallDelegate(butvarq3.Hide);
                    butvarq3.Invoke(d2);
                    d2 = new SafeCallDelegate(butvarq4.Hide);
                    butvarq4.Invoke(d2);
                    break;
                }
            }

        }
      
        delegate void SafeCallDelegate();
        private void fornum()
        {
            var d = new SafeCallDelegate(answertextbox.Show);
            answertextbox.Invoke(d);
            d = new SafeCallDelegate(butsend.Show);

            butsend.Invoke(d);
            d = new SafeCallDelegate(butvarq1.Hide);
            
            butvarq1.Invoke(d);
            d = new SafeCallDelegate(butvarq2.Hide);
          
            butvarq2.Invoke(d);
            d = new SafeCallDelegate(butvarq3.Hide);       
            butvarq3.Invoke(d);
            d = new SafeCallDelegate(butvarq4.Hide);           
            butvarq4.Invoke(d);
        }
        private void forvar()
        {
            var d = new SafeCallDelegate(answertextbox.Hide);
            answertextbox.Invoke(d);
            d = new SafeCallDelegate(butsend.Hide);

            butsend.Invoke(d);
            d = new SafeCallDelegate(butvarq1.Show);

            butvarq1.Invoke(d);
            d = new SafeCallDelegate(butvarq2.Show);

            butvarq2.Invoke(d);
            d = new SafeCallDelegate(butvarq3.Show);
            butvarq3.Invoke(d);
            d = new SafeCallDelegate(butvarq4.Show);
            butvarq4.Invoke(d);
           
        }

        private void butsend_Click(object sender, EventArgs e)
        {
            var b4 = new SafeCallDelegateChangeEnable(ChangeEnable);
            butsend.Invoke(b4, butsend, false);
            SocketSend.sendanswer(answertextbox.Text);
        }

        private void butvarq4_Click(object sender, EventArgs e)
        {
            var b = new SafeCallDelegateChangeEnable(ChangeEnable);
            butvarq1.Invoke(b, butvarq1, false);
            var b1 = new SafeCallDelegateChangeEnable(ChangeEnable);
            butvarq2.Invoke(b1, butvarq2, false);
            var b2 = new SafeCallDelegateChangeEnable(ChangeEnable);
            butvarq3.Invoke(b2, butvarq3, false);
            var b3 = new SafeCallDelegateChangeEnable(ChangeEnable);
            butvarq4.Invoke(b3, butvarq4, false);
            SocketSend.sendanswer("4");
        }

        private void butvarq3_Click(object sender, EventArgs e)
        {
            var b = new SafeCallDelegateChangeEnable(ChangeEnable);
            butvarq1.Invoke(b, butvarq1, false);
            var b1 = new SafeCallDelegateChangeEnable(ChangeEnable);
            butvarq2.Invoke(b1, butvarq2, false);
            var b2 = new SafeCallDelegateChangeEnable(ChangeEnable);
            butvarq3.Invoke(b2, butvarq3, false);
            var b3 = new SafeCallDelegateChangeEnable(ChangeEnable);
            butvarq4.Invoke(b3, butvarq4, false);
            SocketSend.sendanswer("3");
        }

        private void butvarq2_Click(object sender, EventArgs e)
        {
            var b = new SafeCallDelegateChangeEnable(ChangeEnable);
            butvarq1.Invoke(b, butvarq1, false);
            var b1 = new SafeCallDelegateChangeEnable(ChangeEnable);
            butvarq2.Invoke(b1, butvarq2, false);
            var b2 = new SafeCallDelegateChangeEnable(ChangeEnable);
            butvarq3.Invoke(b2, butvarq3, false);
            var b3 = new SafeCallDelegateChangeEnable(ChangeEnable);
            butvarq4.Invoke(b3, butvarq4, false);
            SocketSend.sendanswer("2");
        }

        private void butvarq1_Click(object sender, EventArgs e)
        {
            var b = new SafeCallDelegateChangeEnable(ChangeEnable);
            butvarq1.Invoke(b, butvarq1, false);
            var b1 = new SafeCallDelegateChangeEnable(ChangeEnable);
            butvarq2.Invoke(b1, butvarq2, false);
            var b2 = new SafeCallDelegateChangeEnable(ChangeEnable);
            butvarq3.Invoke(b2, butvarq3, false);
            var b3 = new SafeCallDelegateChangeEnable(ChangeEnable);
            butvarq4.Invoke(b3, butvarq4, false);
            SocketSend.sendanswer("1");
        }
        private void disablevarqbut()
        {
          
            var d = new SafeCallDelegate(butvarq1.Show);

            butvarq1.Invoke(d);
            d = new SafeCallDelegate(butvarq2.Show);

            butvarq2.Invoke(d);
            d = new SafeCallDelegate(butvarq3.Show);
            butvarq3.Invoke(d);
            d = new SafeCallDelegate(butvarq4.Show);
            butvarq4.Invoke(d);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
