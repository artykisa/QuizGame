using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Net;
using System.Threading;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
namespace GameServer
{

    public class Player
    {
       public Player()
        {
            points = 0;
            nick = "";
            answer = "";
        }
        internal int points=0;
        public string nick="";
        internal string answer="";
    }
    public class Game : Questions
    {
        ArrayList questionList = new ArrayList();
        internal bool game = true;
        internal int player;
        internal string result="";
        internal string send="";
         public int answerplayers;
        internal Player[] players=new Player[4];
        public string answer="";
        public Game()
        {
            for (int i = 0; i < 4; i++)
                players[i] = new Player();
        }
        override internal void StartGame()
        {
            int qu = 0;
            Console.WriteLine("Игра начинается");
            while (qu<3)
            {
                answerplayers = 0;
                send = "";
                Console.WriteLine("Вопрос номер " + qu);
                string curquest = getQuestion();
                Console.WriteLine("Вопрос номер" + qu + " получен");
                send += curquest[0];
                Console.WriteLine("Current question=" + curquest);
                if (curquest[0] == 'n')
                {
                    int temp = 0;
                    for (int i = 2; temp != 2; i++)
                    {
                        if (curquest[i] == '!')
                        {
                            temp++;
                        }
                        else if (temp == 0)
                            send += curquest[i];
                        else if (temp == 1)
                            answer += curquest[i];
                    }
                    send += '!';
                }
                else
                {
                    int temp = 0;
                    for (int i = 2; temp != 3; i++)
                    {
                        if (curquest[i] == '!')
                        {
                            temp++;
                        }
                        else if (temp == 0 || temp == 1)
                            send += curquest[i];
                        else if (temp == 2)
                            answer += curquest[i];
                    }
                    send += '!';
                }
                questionList.Add(curquest);
                Console.WriteLine("Send=" + send);
                Console.WriteLine("answer="+answer);
                Console.WriteLine("answerplayers<4");
                while (answerplayers < 4)
                {
                  
                    
                }
                
                Console.WriteLine("Check answers...");
                CheckAnswer();
                Console.WriteLine("Answers were checked");
                qu++;
            }
            EndGame();
        }
        internal void CheckAnswer()
        {
          if (this.send[0] == 'v')
          {
                Console.WriteLine("Check var");
                for(int i = 0; i < 4; i++)
                {
                    if (this.players[i].answer == this.answer)
                    {
                        this.players[i].points += 100;
                    }
                }
                Console.WriteLine("var was chcked");
            }
          else
          {
                Console.WriteLine("num check"); 

                for(int i = 0; i < 4; i++)
                {
                this.players[i].answer = Math.Abs(Convert.ToInt32(this.players[i].answer)-Convert.ToInt32(this.answer)).ToString();
                }
                int[] array =new int[] { Convert.ToInt32(this.players[0].answer), Convert.ToInt32(this.players[1].answer), Convert.ToInt32(this.players[2].answer), Convert.ToInt32(this.players[3].answer) };
                Array.Sort(array);
                for(int i = 0; i < 4; i++)
                {         
                    if(array[0]== Convert.ToInt32(this.players[i].answer))
                    {
                        players[i].points += 100;
                    }
                    else if(array[1] == Convert.ToInt32(this.players[i].answer))
                    {
                        players[i].points += 70;
                    }
                    else if (array[2] == Convert.ToInt32(this.players[i].answer))
                    {
                        players[i].points += 40;
                    }
                    else if (array[3] == Convert.ToInt32(this.players[i].answer))
                    {
                        players[i].points += 10;
                    }
                }
                
                Console.WriteLine("num check was completed");
                
            }
        }
        internal void CheckThread()
        {
            while (true)
            {
                Thread.Sleep(500);
                if (player != 4)
                {
                    EndGame();
                    break;
                }
            }
        }
        void EndGame()
        {
            game = false;
            player = 0;
            for(int i = 0; i < 4; i++)
            {
                result += players[i].nick + "," + players[i].points + ".";
            }
            Console.WriteLine("questionList.Count=" + questionList.Count);
            result += "\n\rQuestions:";
            for (int i = 0; i < questionList.Count; i++)
                result += questionList[i]+"\n\r";
            result += ".";
            Console.WriteLine("result=" + result);
        }
    }
    public class Questions
    {
        internal virtual void StartGame()
        {

        }
        internal void Threadforadd()
        {
            Console.WriteLine("/help - for list of commands");
            while (true)
            {
                string command = Console.ReadLine();
                switch (command)
                {
                    case "/add":
                        Console.WriteLine("/add command/");
                        Console.WriteLine("Введите тип вопроса n/v");
                        string quest = Console.ReadLine();
                        Console.WriteLine("Введите вопрос");
                        string question = Console.ReadLine();
                        string variants = "";
                        if (quest[0] == 'v')
                        {
                            Console.WriteLine("Введите варианты ответа");
                            variants = Console.ReadLine();
                        }
                        Console.WriteLine("Введите правильный ответ");
                        string answer = Console.ReadLine();
                        addQuestion(quest, question, variants, answer);
                        break;

                    case "/get":

                        Console.WriteLine("/get command/");
                        Console.WriteLine(getQuestion());
                        break;
                    case "/help":
                        Console.WriteLine("/add - add question\n/get - get random question");
                        break;
                    case "/points":
                        for (int i = 0; i < 4; i++)
                            Console.WriteLine(Program.Game.players[i].points);
                        break;
                    case "/haha 1":
                        Program.Game.players[0].points += 100;
                        break;
                    case "/haha 2":
                        Program.Game.players[1].points += 100;
                        break;
                    case "/haha 3":
                        Program.Game.players[2].points += 100;
                        break;
                    case "/haha 4":
                        Program.Game.players[3].points += 100;
                        break;
                }
            }
        }
        void addQuestion(string newquestion, string question, string variants, string answer)
        {
            string connStr = "server=localhost;user=root;database=server;password=kisurin;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            if (newquestion[0] == 'v')
            {
                string sql = "";
                sql = "SELECT id FROM varquestions WHERE id=(SELECT MAX(id) FROM varquestions);";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                int id = 0;
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader[0]);
                }
                reader.Close();
                id++;
                sql = "INSERT INTO varquestions VALUES(" + id + ",'" + question + "','" + variants + "','" + answer + "');";
                MySqlCommand command2 = new MySqlCommand(sql, conn);
                MySqlDataReader reader2 = command2.ExecuteReader();
                reader2.Close();
            }
            else
            {
                string sql = "";
                sql = "SELECT id FROM numquestions WHERE id=(SELECT MAX(id) FROM numquestions);";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                int id = 0;
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader[0]);
                }
                reader.Close();
                id++;
                sql = "INSERT INTO numquestions VALUES(" + id + ",'" + question + "','" + answer + "');";
                Console.WriteLine(sql);
                MySqlCommand command2 = new MySqlCommand(sql, conn);
                MySqlDataReader reader2 = command2.ExecuteReader();
                reader2.Close();
            }
        }
        internal string getQuestion()
        {
            string connStr = "server=localhost;user=root;database=server;password=kisurin;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Random rand = new Random();
            bool typeofquest = Convert.ToBoolean(rand.Next(-1, 2));

            string strtypeofquest = typeofquest ? "numquestions" : "varquestions";
            string sql = "";
            int id = 0;
            if (strtypeofquest == "numquestions")
            {
                sql = "SELECT id FROM numquestions WHERE id=(SELECT MAX(id) FROM numquestions);";
                MySqlCommand command2 = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command2.ExecuteReader();
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader[0]);
                }
                reader.Close();
            }
            else
            {
                sql = "SELECT id FROM varquestions WHERE id=(SELECT MAX(id) FROM varquestions);";
                MySqlCommand command2 = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command2.ExecuteReader();
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader[0]);
                }
                reader.Close();
            }

            int numofquest = rand.Next(1, id + 1);
            Console.WriteLine("Я вытянул id=" + id + "   numofquest=" + numofquest);
            if (strtypeofquest[0] == 'n')
                sql = "SELECT id,question,RightAnswer FROM " + strtypeofquest + " WHERE id=" + numofquest + ";";
            else
                sql = "SELECT id,question,answers,RightAnswer FROM " + strtypeofquest + " WHERE id=" + numofquest + ";";
            MySqlCommand command = new MySqlCommand(sql, conn);
            string question = "";
            string answer = "";
            string variants = "";
            if (strtypeofquest[0] == 'n')
            {
                MySqlDataReader reader2 = command.ExecuteReader();
                while (reader2.Read())
                {
                    question = reader2[1].ToString();
                    answer = reader2[2].ToString();
                }

                reader2.Close();
            }
            else
            {
                MySqlDataReader reader2 = command.ExecuteReader();
                while (reader2.Read())
                {
                    question = reader2[1].ToString();
                    variants = reader2[2].ToString();
                    answer = reader2[3].ToString();
                }
                reader2.Close();
            }

            string returnstring = typeofquest ? strtypeofquest[0] + "!" + question + "!" + answer + "!" : strtypeofquest[0] + "!" + question + "!" + variants + "!" + answer + "!";
            return returnstring;
        }
    }
    class Program
    {
        static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public static int numofplayers = 0;
      public static  Game Game = new Game();
        static void Main(string[] args)
        {         
            Questions questions = new Questions();
            Console.WriteLine(questions.getQuestion());
            Console.WriteLine("////////Game Server///////\n");
            socket.Bind(new IPEndPoint(IPAddress.Any, 905));
            socket.Listen(5);
            Thread addThread = new Thread(new ThreadStart(questions.Threadforadd));
            addThread.Start(); // запускаем поток
            byte[] message = new byte[1024];
            while (true)
            {
                try
                {
                    if (numofplayers != 4)
                    {
                        Socket client = socket.Accept();
                        Thread myThread = new Thread(new ParameterizedThreadStart(Connection));
                        myThread.Start(client); // запускаем поток
                        Thread.Sleep(500);
                        numofplayers++;
                        Game.player++;
                        Console.WriteLine("Новое подключение к серверу с " + client.RemoteEndPoint + "\nКоличество игроков: " + numofplayers);
                    }
                    else
                    {
 
                        Game.player = numofplayers;
                        numofplayers = 0;
                        Game.StartGame();
                        Thread check = new Thread(new ThreadStart(Game.CheckThread));
                        check.Start();
                    }
                }
                catch { }
            }
        }
        static void Connection(object clientobj)
        {
            Socket client = (Socket)clientobj;
            byte[] buff = new byte[1024];
            client.Receive(buff);
            int numofplayer = Game.player;
            bool first = true;
            string sbuf = Encoding.Unicode.GetString(buff);
            string tempnick="";
            for (int i = 0; sbuf[i] != '.'; i++)
            {
                tempnick += sbuf[i];
            }
            if (numofplayer == 4)
            {
                numofplayer--;
            }
            if(numofplayer!=4)
            Game.players[numofplayer].nick = tempnick;
            else
                Game.players[3].nick = tempnick;
            while (Game.game)
            {
                if (Game.player == 4)
                {
                    if (first)
                    {
                        byte[] msg = Encoding.Unicode.GetBytes("Start!");
                        Console.WriteLine("Send:Start!");
                        client.Send(msg);
                        first = false;
                    }
                    Thread.Sleep(500);
                    byte[] buffer = new byte[1024];
                    try
                    {
                        while (Game.send == "")
                        {
                            Console.WriteLine("Game.send=null");
                            continue;
                        }
                        byte[] msg = Encoding.Unicode.GetBytes(Game.send);
                        Console.WriteLine("Отправляю:"+Game.send);
                        client.Send(msg);
                        Console.WriteLine("Send this to"+Game.players[numofplayer].nick+" :" + Game.send);
                        byte[] recmes = new byte[1024];
                        client.Receive(recmes);
                        string buf = Encoding.Unicode.GetString(recmes);
                        string rec = "";
                        Console.WriteLine("Get this from" + Game.players[numofplayer].nick + " :" + buf);
                        for (int i = 0; buf[i] != '.'; i++)
                            rec += buf[i];
                        
                        Game.players[numofplayer].answer = rec;
                        Game.answerplayers++;
                        while (Game.answerplayers != 4)
                        {

                        }
                        Thread.Sleep(2500);
                    }
                   catch
                    {
                        Game.player--;
                        break;
                    }
                    
                }
                else
                {
                    Thread.Sleep(1000);//eto uberi eli ne rabotaet
                    Console.WriteLine("Отправляю:W8!");
                    client.Send(Encoding.Unicode.GetBytes("W8"+Game.player+"!"));
                }
                Thread.Sleep(500);
            }
            
            byte[] tempo = Encoding.Unicode.GetBytes("r!"+Game.result);
            Console.WriteLine("Отправляю результаты игры:"+"r!"+Game.result);
            client.Send(tempo);
        }
    }
}
/*byte[] tempo = new byte[1024];
 *  byte[] msgno0 = Encoding.ASCII.GetBytes("0");
string jopa = Encoding.Unicode.GetString(tempo);
Console.WriteLine("Отправляю это: " + jopa);
client.Send(tempo);*/
