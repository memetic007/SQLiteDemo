using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLite;


namespace SQLiteDemo
{
    public partial class Form1 : Form
    {
        Random randObj = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dbLocation = "CloudQueueDB";
            File.Delete(dbLocation);
            var db = new SQLiteConnection(dbLocation);
            
            db.CreateTable<User>();
            db.CreateTable<Game>();
            
            db.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string dbLocation = "CloudQueueDB";
            var db = new SQLiteConnection(dbLocation);
            db.CreateTable<User>();
            db.CreateTable<Game>();
            db.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            User user;
            int usernum;          

            string dbLocation = "CloudQueueDB";
            var db = new SQLiteConnection(dbLocation);

            for (int j = 0; j < 10;j++ )
            {
                user = new User();
                usernum = randObj.Next(1000000000, 2000000000);

                user.userName = "USER" + usernum.ToString();
                user.totalGames = 0;
                user.lostGames = 0;
                user.totalGames = 0;
                user.wonGames = 0;
                user.incompleteGames = 0;
                
                db.Insert(user);
                Console.WriteLine("creating User: " + user.userName);


            }
            db.Close();

        }

        public void addGames(int howMany)
        {
            Game game;
            
            int winner;

            List<User> userList;
            

            string dbLocation = "CloudQueueDB";
            var db = new SQLiteConnection(dbLocation);

            userList = db.Query<User>("select * from User");

            foreach (User myUser in userList)
            {
                for (int k = 0; k < 5; k++)
                {


                    game = new Game();
                    game.gameID = Guid.NewGuid().ToString();

                    game.userName = myUser.userName;

                    winner = whoWon();
                    if (winner == 0)
                    {
                        myUser.wonGames++;
                    }
                    else
                    {
                        myUser.lostGames++;

                    }


                    game.turns = getTurns();
                    db.Insert(game);
                    Console.WriteLine("added game for " + myUser.userName + " GUID: " + game.gameID);


                }

                myUser.incompleteGames = myUser.incompleteGames + incompleteGames();
                myUser.totalGames = myUser.wonGames + myUser.lostGames + myUser.incompleteGames;
                db.Update(myUser);
            }

 
        }

        public int whoWon()
        {
            return randObj.Next(0, 5);

        }

        public int incompleteGames()
        {
            return randObj.Next(0, 4);
        }

        public int getTurns()
        {
            return randObj.Next(7, 20);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<User> userList;
            string ostring;

            string dbLocation = "CloudQueueDB";
            var db = new SQLiteConnection(dbLocation);

            userList = db.Query<User>("select * from User");

            foreach (User myUser in userList)
            {
                ostring = myUser.userName + " total games: " + myUser.totalGames.ToString()+ " won: " + myUser.wonGames.ToString() + " lost: " + myUser.lostGames.ToString() + " incomplete: " + myUser.incompleteGames.ToString();
                Console.WriteLine(ostring);

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            addGames(5);
        }
    }
}
