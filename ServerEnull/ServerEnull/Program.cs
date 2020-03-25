using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Net;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
namespace ServerEnull
{
    class Program
    {  
        static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);   
        static void Main(string[] args)
            {
            string connStr = "server=localhost;user=root;database=server;password=kisurin;";
            // создаём объект для подключения к БД
            MySqlConnection conn = new MySqlConnection(connStr);
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = "SELECT login, password, nick FROM logins WHERE login='1' AND password='2'";
            // объект для выполнения SQL-запроса    
            MySqlCommand command = new MySqlCommand(sql, conn);
            // выполняем запрос и получаем ответ

     
           // string name = command.ExecuteScalar().ToString();
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString()+" "+ reader[2].ToString());
            }
            reader.Close(); // закрываем reader
            socket.Bind(new IPEndPoint(IPAddress.Any, 904));
            socket.Listen(5);
            while (true)
            {
                Socket client = socket.Accept();
                button3_Click(client);
                Console.WriteLine("Новое подключение\n");
            }           
            }
        private static async void button3_Click(Socket client)
        {
            var progress = new Progress<string>(s => Console.WriteLine(s));
            string result = await Task.Factory.StartNew<string>(
                                                     () => updateGC(progress, client),
                                                     TaskCreationOptions.LongRunning);
        }
        public static string updateGC(IProgress<string> progress, Socket client)
        {
            byte[] bytes = new byte[1024];
            while (true)
            {
                bool ifno = false;
                byte[] buffer = new byte[1024];
                try
                {
                    client.Receive(buffer);
                }
                catch { break;
                }
                string buf = Encoding.ASCII.GetString(buffer);
                Console.WriteLine(buf + "1");
                try
                {
                    byte[] msgno = Encoding.ASCII.GetBytes("0");
                    byte[] msgyeartur = Encoding.ASCII.GetBytes("artyom kisurin" +
                        "\r\nvlad sakovich");


                    byte[] msgyeartyom = Encoding.ASCII.GetBytes("artur matsuk\r\nvlad sakovich");
                    string login = "";
                    string password ="";
                    int space = 0;
                    for (int i = 0; ; i++)
                    {
                        if (buf[i] == ' ') space++;
                        else if (buf[i] == '.') { break; }
                        else if (space == 0) login += buf[i];
                        else if (space == 1) password += buf[i];
                    }
                    string connStr = "server=localhost;user=root;database=server;password=kisurin;";
                    // создаём объект для подключения к БД
                    MySqlConnection conn = new MySqlConnection(connStr);
                    // устанавливаем соединение с БД
                    conn.Open();
                    // запрос
                    string sql="";
                    try
                    {
                         sql = "SELECT login, password, nick FROM logins WHERE login='" + login + "' AND password='" + password + "'";
                    }
                    catch { }
                    
                    // объект для выполнения SQL-запроса
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    // выполняем запрос и получаем ответ


                    // string name = command.ExecuteScalar().ToString();
                    MySqlDataReader reader = command.ExecuteReader();
                    // читаем результат
                    string nick="";
                    while (reader.Read())
                    {
                        // элементы массива [] - это значения столбцов из запроса SELECT
                        nick= reader[2].ToString();
                    }
                    if (nick == "") { client.Send(msgno); ifno = true; continue; }
                    reader.Close(); // закрываем reader
                    byte[] msg= Encoding.ASCII.GetBytes(nick);
                    
                        client.Send(msg);
                   
                }
                catch { }
                if (!ifno)
                {
                    client.Shutdown(SocketShutdown.Both);
                    // client.Disconnect(true);
                    client.Close();
                    Console.WriteLine("Разрыв соединения\n");
                }
            }
            return "";

        }
    }
    }


