using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Media;

//Adit Mishra
//March 21, 2025
//2D Race
namespace _2D_Race
{
    public partial class GameScreen : UserControl
    {
        //used for movement
        bool upArrowDown;
        bool downArrowDown;

        //used for changing difficulty
        public static string gameDifficulty;

        //defining the screen height and width for all the screens andm classes
        public static int screenWidth;
        public static int screenHeight;

        //used to move only once per key press
        public static bool keyPressed = false;

        //defining player class on game screen
        Player hero;

        //defining ball class on game screen
        List<Ball> balls = new List<Ball>();

        //yellow power up rectangle on screen
        Rectangle powerUp = new Rectangle(180, 250, 10, 10);

        Random randGen = new Random();
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);

        public GameScreen()
        {
            InitializeComponent();
            InitializeGame();

            screenWidth = this.Width;
            screenHeight = this.Height;
        }

        //what shows up when game screen is opened
        public void InitializeGame()
        {
            hero = new Player();

            //easy mode - 20 balls
            if (gameDifficulty == "easy")
            {
                for (int i = 0; i < 20; i++)
                {
                    CreateBall();
                }
            }

            //medium mode - 25 balls
            else if (gameDifficulty == "medium")
            {
                for (int i = 0; i < 25; i++)
                {
                    CreateBall();
                }
            }

            //hard mode - 30 balls
            else if (gameDifficulty == "hard")
            {
                for (int i = 0; i < 30; i++)
                {
                    CreateBall();
                }
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (upArrowDown == true)
            {
                hero.Move("up");
                keyPressed = true;
            }

            else if (downArrowDown == true)
            {
                hero.Move("down");
                keyPressed = true;
            }
            
            //make the balls move
            foreach (Ball b in balls)
            {
                b.Move();
            }

            //when hero collides with a ball, restart
            foreach (Ball b in balls)
            {
                if (hero.Collision(b))
                {
                    hero.x = 180;
                    hero.y = 350;
                }
            }

            //when hero collides with yellow block, travel more blocks every jump
            if (hero.powerUpCollision(powerUp))
            {
                hero.speed++;
            }

            //restricting where the balls spawn
            foreach (Ball b in balls)
            {
                if (b.x > this.Width)
                {
                    b.x = -10;
                }
            }

            //when hero crosses the top of the screen, end game
            if ((hero.y - hero.width) < 0)
            {
                SoundPlayer player = new SoundPlayer(Properties.Resources.GameOver);
                player.Play();

                gameTimer.Stop();
                Form1.ChangeScreen(this, new EndScreen());
            }

            Refresh();
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upArrowDown = false;
                    keyPressed = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    keyPressed = false;
                    break;
            }
            
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        upArrowDown = true;
                        break;
                    case Keys.Down:
                        downArrowDown= true;
                        break;
                }
         
        }

        //create the balls
        private void CreateBall()
        {
            int x = randGen.Next(20, this.Width - 50);
            int y = randGen.Next(40, this.Height - 75);

            Ball b = new Ball(x, y, 8, 8);
            balls.Add(b);
        }

        //paint all the players and objects on to the screen
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //drawing hero
            e.Graphics.FillRectangle(greenBrush, hero.x, hero.y, hero.width, hero.height);

            //drawing yellow power up block
            e.Graphics.FillRectangle(yellowBrush, powerUp);
            
            //drawing balls
            foreach (Ball b in balls)
            {
                e.Graphics.FillEllipse(redBrush, b.x, b.y, b.size, b.size);
            }
        }
    }
}
