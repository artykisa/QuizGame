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
namespace ClientBrain
{
   
    public static class Player
    {
        public static string nick="123";
        
    }
    public class Question
    {
        public string question="";
        public string variant1="";
        public string variant2 = "";
        public string variant3 = "";
        public string variant4 = "";
    }
   
    public static class SocketSend
    {
        public static Socket socket;
        public static void  sendanswer(string answer)
        {
            socket.Send(forsend(answer));
        }
        public static void sendstart()
        {
            socket.Send(forsend(Player.nick));
        }
        public static byte[] forsend(string whattosend, string whattosend2)
        {
            return Encoding.Unicode.GetBytes(whattosend + "," + whattosend2 + ".");
        }
        public static byte[] forsend(string whattosend)
        {
            return Encoding.Unicode.GetBytes(whattosend + ".");
        }
    }
    public static class SocketRecieve
    {
        public static Socket socket;
        public static string ip;
        public static string Recieve(string type)
        {
            byte[] get = new byte[1024];
            socket.Receive(get);
            string rec = Encoding.Unicode.GetString(get);
            string truerec="";
            switch (type)
            {
                case "wait":
                    for(int i = 0; rec[i] != '!';i++)
                    {
                        truerec += rec[i];
                    }
                    return truerec;
                   /* while (true)
                    {
                        
                        if(rec[0]=='W' && rec[1]=='8' && rec[2] == '!') {
                            continue;
                        }
                        else if(rec[0] == 'S' && rec[1] == 't' && rec[2] == 'a' && rec[3] == 'r' && rec[4] == 't' && rec[5] == '!')
                        {
                            break;
                        }
                        
                    }*/
                case "question":
                    truerec += rec[0];
                    if (rec[0] == 'n')
                    {
                        for (int i = 1; rec[i] != '!'; i++)
                        {
                            truerec += rec[i];
                        }
                    }
                    else if(rec[0]=='v')
                    {
                        for (int i = 1;; i++)
                        {
                            
                            if (rec[i] == '!')
                            {
                                break;
                            }
                            truerec += rec[i];
                        }
                    }
                    else if (rec[0] == 'r')
                    {
                        int temp = 0;
                        for(int i=0;temp<8 ; i++)
                        {
                            if (rec[i] == '.')
                                temp++;
                            truerec += rec[i];
                        }
                    }
                    return truerec;
            }
            return "";
        }
    }
}
/*
  socket= new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ip, 955);
             string data = nick + "/" + comboBox1.Text + "/" + nick + ":" + textBox2.Text + "~";
                byte[] mess = Encoding.Unicode.GetBytes(data);
                socket.Send(mess);
 */
