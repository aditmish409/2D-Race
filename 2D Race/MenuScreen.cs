using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2D_Race
{
    public partial class MenuScreen : UserControl
    {
        public MenuScreen()
        {
            InitializeComponent();
        }

        //go to game screen on easy mode when clicked easy button
        private void easyButton_Click(object sender, EventArgs e)
        {
            GameScreen.gameDifficulty = "easy";
            Form1.ChangeScreen(this, new GameScreen());
        }

        //go to game screen on medium mode when clicked medium button
        private void mediumButton_Click(object sender, EventArgs e)
        {
            GameScreen.gameDifficulty = "medium";
            Form1.ChangeScreen(this, new GameScreen());
        }

        //go to game screen on hard mode when clicked hard button
        private void hardButton_Click(object sender, EventArgs e)
        {
            GameScreen.gameDifficulty = "hard";
            Form1.ChangeScreen(this, new GameScreen());
        }

        //exit game when clicked exit button
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
