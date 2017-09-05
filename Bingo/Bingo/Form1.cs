using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace Bingo
{
    public partial class Bingo : Form
    {
        //Our 25 button variable
        Button[] btn = new Button[24];
        //Our possible 75 balls
        int[] ball = new int[75];
        //counter for how many balls we've pulled
        int BallCounter = 0;
        //The current ball we have pulled
        int currentBall;
        //GameMode, 0 = normal, 1 = blackout
        int GameMode = 0;

        public Bingo()
        {
            InitializeComponent();
            //B Buttons
            btn[0] = btnB1; btn[1] = btnB2; btn[2] = btnB3; btn[3] = btnB4; btn[4] = btnB5;
            //I buttons
            btn[5] = btnI1; btn[6] = btnI2; btn[7] = btnI3; btn[8] = btnI4; btn[9] = btnI5;
            //N Buttons
            btn[10] = btnN1; btn[11] = btnN2; btn[12] = btnN4; btn[13] = btnN5;
            //G buttons
            btn[14] = btnG1; btn[15] = btnG2; btn[16] = btnG3; btn[17] = btnG4; btn[18] = btnG5;
            //O Buttons
            btn[19] = btnO1; btn[20] = btnO2; btn[21] = btnO3; btn[22] = btnO4; btn[23] = btnO5;

            StartNewGame();
        }

        private void StartNewGame()
        {
            RandomizeBoard();
            ClearCounter();
            ResetButtons();
        }
        //Randomizes the 25 buttons on the board
        private void RandomizeBoard()
        {
            //Each letter can be one of 15 numbers. The numbers are exclusive.
            //In the number array we will update to the current range of 15 numbers.
            //Our random target will be set to one of these, when it is pulled that index gets set to 0.
            //If a number is pulled and it is 0 we look for a new number.
            Random r = new Random();
            int target = 0;
            //B = 1-15
            int[] number = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            //Setting up B
            target = r.Next(1, 15);
            //B1 will always be able to be any number 1-15
            btn[0].Text = Convert.ToString(target);
            number[target] = 0;
            //B2 to B4
            for (int i = 1; i < 5; i++)
            {
                target = r.Next(1, 15);
                //If any of the indexs of number pulled are 0 then they are taken, we draw until we have a fresh one
                while  (number[target] == 0)
                {
                    target = r.Next(1, 15);
                }
                //The button is set to that number and we set its index to 0 so it can't be available
                btn[i].Text = Convert.ToString(target);
                number[target] = 0;
            }

            //Randomizing I
            //Reusing number for 16-30, indexs 0-14 are reused and assigned the corresponding number
            for (int i = 0; i < 15; i++)
            {
                number[i] = 16 + i;
            }
            target = r.Next(16, 30);
            //I1 will always be able to be any number 16-30
            btn[5].Text = Convert.ToString(target);
            number[target - 15] = 0;
            //If any of the indexs of number pulled are 0 then they are taken, we draw until we have a fresh one
            for (int i = 6; i < 10; i++)
            {
                target = r.Next(16, 30);
                while (number[target-15] == 0)
                {
                    target = r.Next(16, 30);
                }
                //The button is set to that number and we set its index to 0 so it can't be available
                btn[i].Text = Convert.ToString(target);
                number[target-15] = 0;
            }

            //Randomizing N
            //Reusing number for 31-45, indexs 0-14 are reused and assigned the corresponding number
            for (int i = 0; i < 15; i++)
            {
                number[i] = 31 + i;
            }
            target = r.Next(31, 45);
            //N1 will always be able to be any number 31-45
            btn[10].Text = Convert.ToString(target);
            number[target - 30] = 0;
            for (int i = 11; i < 14; i++)
            {
                target = r.Next(31, 45);
                //If any of the indexs of number pulled are 0 then they are taken, we draw until we have a fresh one
                while (number[target - 30] == 0)
                {
                    target = r.Next(31, 45);
                }
                //The button is set to that number and we set its index to 0 so it can't be available
                btn[i].Text = Convert.ToString(target);
                number[target - 30] = 0;
            }

            //Randomizing G
            //Reusing number for 46-60, indexs 0-14 are reused and assigned the corresponding number
            for (int i = 0; i < 15; i++)
            {
                number[i] = 46 + i;
            }
            target = r.Next(46, 60);
            //G1 will always be able to be any number 46-60
            btn[14].Text = Convert.ToString(target);
            number[target - 45] = 0;
            for (int i = 15; i < 19; i++)
            {
                target = r.Next(46, 60);
                //If any of the indexs of number pulled are 0 then they are taken, we draw until we have a fresh one
                while (number[target - 45] == 0)
                {
                    target = r.Next(46, 60);
                }
                //The button is set to that number and we set its index to 0 so it can't be available
                btn[i].Text = Convert.ToString(target);
                number[target - 45] = 0;
            }

            //Randomizing O 
            //Reusing number for 61-75, indexs 0-14 are reused and assigned the corresponding number
            for (int i = 0; i < 15; i++)
            {
                number[i] = 61 + i;
            }
            target = r.Next(61, 75);
            //O1 will always be able to be any number 61-75
            btn[19].Text = Convert.ToString(target);
            number[target - 60] = 0;
            for (int i = 20; i < 24; i++)
            {
                target = r.Next(61, 75);
                //If any of the indexs of number pulled are 0 then they are taken, we draw until we have a fresh one
                while (number[target - 60] == 0)
                {
                    target = r.Next(61, 75);
                }
                //The button is set to that number and we set its index to 0 so it can't be available
                btn[i].Text = Convert.ToString(target);
                number[target - 60] = 0;
            }
        }
        //Resets the pool of numbers for the ball
        private void ClearCounter()
        {
            //For all of our balls we set their value to 0. This means they have no been pulled.
            //As they are pulled throughout the game we will set them to 1.
            for (int i = 0; i < 75; i++)
            {
                ball[i] = 0;
            }
            BallCounter = 0;
            lblBall.Text = "";
            currentBall = 0;
        }
        //Reenables buttons
        private void ResetButtons()
        {
            btnFree.Enabled = true;
            for (int i = 0; i < 24; i++)
            {
                btn[i].Enabled = true;
            }
        }

        //When the game mode is changed, a user is asked to confirm, and a new game is started
        private void rdbBlackout_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbBlackout.Checked == true) {
                DialogResult newGame = MessageBox.Show("Switching to Blackout mode will start a new game. Are you sure you want to do this?", "Blackout Game", MessageBoxButtons.YesNo);
                switch (newGame)
                {
                    case DialogResult.Yes:
                        GameMode = 1;
                        ClearCounter();
                        ResetButtons();
                        RandomizeBoard();
                        break;
                }
            }
        }
        private void rdbNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbNormal.Checked == true)
            {
                DialogResult newGame = MessageBox.Show("Switching to Normal mode will start a new game. Are you sure you want to do this?",  "Normal Game",  MessageBoxButtons.YesNo);
                switch (newGame)
                {
                    case DialogResult.Yes:
                        GameMode = 0;
                        ClearCounter();
                        ResetButtons();
                        RandomizeBoard();
                        break;
                }
            }
        }

        //Contains the corresponding conditions for normal wins and blackout wins based on mode
        private void IsThereAWinner()
        {
            //If playing normal mode
            if (GameMode == 0) {
                //Check for B vertical
                if (btnB1.Enabled == false && btnB2.Enabled == false && btnB3.Enabled == false && btnB4.Enabled == false && btnB5.Enabled == false)
                {
                    MessageBox.Show("You did it! You won! Starting new game!");
                    ClearCounter();
                    ResetButtons();
                    RandomizeBoard();
                }
                //Check for I vertical
                if (btnI1.Enabled == false && btnI2.Enabled == false && btnI3.Enabled == false && btnI4.Enabled == false && btnI5.Enabled == false)
                {
                    MessageBox.Show("You did it! You won! Starting new game!");
                    ClearCounter();
                    ResetButtons();
                    RandomizeBoard();
                }
                //Check for N vertical
                if (btnN1.Enabled == false && btnN2.Enabled == false && btnFree.Enabled == false && btnN4.Enabled == false && btnN5.Enabled == false)
                {
                    MessageBox.Show("You did it! You won! Starting new game!");
                    ClearCounter();
                    ResetButtons();
                    RandomizeBoard();
                }
                //Check for G vertical
                if (btnG1.Enabled == false && btnG2.Enabled == false && btnG3.Enabled == false && btnG4.Enabled == false && btnG5.Enabled == false)
                {
                    MessageBox.Show("You did it! You won! Starting new game!");
                    ClearCounter();
                    ResetButtons();
                    RandomizeBoard();
                }
                //Check for O vertical
                if (btnO1.Enabled == false && btnO2.Enabled == false && btnO3.Enabled == false && btnO4.Enabled == false && btnO5.Enabled == false)
                {
                    MessageBox.Show("You did it! You won! Starting new game!");
                    ClearCounter();
                    ResetButtons();
                    RandomizeBoard();
                }
                //Check for Row 1 Horizontal
                if (btnB1.Enabled == false && btnI1.Enabled == false && btnN1.Enabled == false && btnG1.Enabled == false && btnO1.Enabled == false)
                {
                    MessageBox.Show("You did it! You won! Starting new game!");
                    ClearCounter();
                    ResetButtons();
                    RandomizeBoard();
                }
                //Check for Row 2 Horizontal
                if (btnB2.Enabled == false && btnI2.Enabled == false && btnN2.Enabled == false && btnG2.Enabled == false && btnO2.Enabled == false)
                {
                    MessageBox.Show("You did it! You won! Starting new game!");
                    ClearCounter();
                    ResetButtons();
                    RandomizeBoard();
                }
                //Check for Row 3 Horizontal
                if (btnB3.Enabled == false && btnI3.Enabled == false && btnFree.Enabled == false && btnG3.Enabled == false && btnO3.Enabled == false)
                {
                    MessageBox.Show("You did it! You won! Starting new game!");
                    ClearCounter();
                    ResetButtons();
                    RandomizeBoard();
                }
                //Check for Row 4 Horizontal
                if (btnB4.Enabled == false && btnI4.Enabled == false && btnN4.Enabled == false && btnG4.Enabled == false && btnO4.Enabled == false)
                {
                    MessageBox.Show("You did it! You won! Starting new game!");
                    ClearCounter();
                    ResetButtons();
                    RandomizeBoard();
                }
                //Check for Row 5 Horizontal
                if (btnB5.Enabled == false && btnI5.Enabled == false && btnN5.Enabled == false && btnG5.Enabled == false && btnO5.Enabled == false)
                {
                    MessageBox.Show("You did it! You won! Starting new game!");
                    ClearCounter();
                    ResetButtons();
                    RandomizeBoard();
                }
                //Check for Diagonal 1
                if (btnB1.Enabled == false && btnI2.Enabled == false && btnFree.Enabled == false && btnG4.Enabled == false && btnO5.Enabled == false)
                {
                    MessageBox.Show("You did it! You won! Starting new game!");
                    ClearCounter();
                    ResetButtons();
                    RandomizeBoard();
                }
                //Check for Diagonal 2
                if (btnB5.Enabled == false && btnI4.Enabled == false && btnFree.Enabled == false && btnG2.Enabled == false && btnO1.Enabled == false)
                {
                    MessageBox.Show("You did it! You won! Starting new game!");
                    ClearCounter();
                    ResetButtons();
                    RandomizeBoard();
                }
            }
            else if (GameMode == 1)
            {
                if (btnB1.Enabled == false && btnB2.Enabled == false && btnB3.Enabled == false && btnB4.Enabled == false && btnB5.Enabled == false &&
                    btnI1.Enabled == false && btnI2.Enabled == false && btnI3.Enabled == false && btnI4.Enabled == false && btnI5.Enabled == false &&
                    btnN1.Enabled == false && btnN2.Enabled == false && btnFree.Enabled == false && btnN4.Enabled == false && btnN5.Enabled == false &&
                    btnG1.Enabled == false && btnG2.Enabled == false && btnG3.Enabled == false && btnG4.Enabled == false && btnG5.Enabled == false &&
                    btnO1.Enabled == false && btnO2.Enabled == false && btnO3.Enabled == false && btnO4.Enabled == false && btnO5.Enabled == false)
                {
                    MessageBox.Show("You did it! You won! Starting new game!");
                    ClearCounter();
                    ResetButtons();
                    RandomizeBoard();
                }
            }
        }

        //Clicking New Game calls the new game function
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        //Draw a new ball
        private void btnDraw_Click(object sender, EventArgs e)
        {
            //Create a bool to check if the number on board is currently on the 
            bool numberOnBoard = false;
            //For all of the buttons we will check if the Integer value of its Text is equal to the value of the ball currently pulled
            //And check to make sure that button is not already activated.
            for (int i = 0; i < 24; i++)
            {
                if (Convert.ToInt32(btn[i].Text) == currentBall && (btn[i].Enabled != false) )
                {
                    numberOnBoard = true;
                }
            }
            //If the ball pulled is already activated then we pull a new ball
            if (numberOnBoard == false) 
            {
            //Grab our initial random number 1-75
            int target = 1;
            Random r = new Random();
            target = r.Next(0, 75);
                //If we have not already exceeded the amount of balls to be pulled
            if (BallCounter < 74) {
                //Checking to make sure the index of the pulled number doesn't equal 1, which means it would have been pulled
                //already.
                while (ball[target] == 1 && BallCounter < 74)
                {
                    target = r.Next(0, 75);
                }

                //Since its all based off the index of the int array, we have to adjust +1
                //Additionally, based on the number range the ball will be a different Letter.
                if (target == 0)
                {
                    lblBall.Text = ("B " + Convert.ToString(target + 1));
                        currentBall = target + 1;
                    }
                else if (target > 0 && target < 15)
                {
                    lblBall.Text = ("B " + Convert.ToString(target + 1));
                    currentBall = target + 1;
                }
                else if (target > 14 && target < 30)
                {
                    lblBall.Text = ("I " + Convert.ToString(target + 1));
                    currentBall = target + 1;
                }
                else if (target > 29 && target < 45)
                {
                    lblBall.Text = ("N " + Convert.ToString(target + 1));
                    currentBall = target + 1;
                }
                else if (target > 44 && target < 60)
                {
                    lblBall.Text = ("G " + Convert.ToString(target + 1));
                    currentBall = target + 1;
                }
                else if (target > 59 && target < 74)
                {
                    lblBall.Text = ("O " + Convert.ToString(target + 1));
                    currentBall = target + 1;
                }
                else if (target >= 74)
                {
                    lblBall.Text = ("O " + Convert.ToString(target + 1));
                    currentBall = target + 1;
                }
                //After we display it, we set that index to 1 so it is now used, and set the global ball counter to +1
                ball[target] = 1;
                BallCounter++;
                    }
            } else
            {
                //If the number is on the board we won't allow them to go forward, prompt them to look and find the number.
                MessageBox.Show("Are you sure? Check again!");
            }

        }

        //If a button is clicked when its value matches current ball, disable and check if the game is won
        private void btnB1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(btnB1.Text) == currentBall)
            {
                btnB1.Enabled = false;
                IsThereAWinner();
            }
        }
        private void btnB2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(btnB2.Text) == currentBall)
            {
                btnB2.Enabled = false;
                IsThereAWinner();
            }
        }
        private void btnB3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(btnB3.Text) == currentBall)
            {
                btnB3.Enabled = false;
                IsThereAWinner();
            }
        }
        private void btnB4_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(btnB4.Text) == currentBall)
            {
                btnB4.Enabled = false;
                IsThereAWinner();
            }
        }
        private void btnB5_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(btnB5.Text) == currentBall)
            {
                btnB5.Enabled = false;
                IsThereAWinner();
            }
        }
        private void btnI1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(btnI1.Text) == currentBall)
            {
                btnI1.Enabled = false;
                IsThereAWinner();
            }
        }
        private void btnI2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(btnI2.Text) == currentBall)
            {
                btnI2.Enabled = false;
                IsThereAWinner();
            }
        }
        private void btnI3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(btnI3.Text) == currentBall)
            {
                btnI3.Enabled = false;
                IsThereAWinner();
            }
        }
        private void btnI4_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(btnI4.Text) == currentBall)
            {
                btnI4.Enabled = false;
                IsThereAWinner();
            }
        }
        private void btnI5_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(btnI5.Text) == currentBall)
            {
                btnI5.Enabled = false;
                IsThereAWinner();
            }
        }
        private void btnN1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(btnN1.Text) == currentBall)
            {
                btnN1.Enabled = false;
                IsThereAWinner();
            }
        }
        private void btnN2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(btnN2.Text) == currentBall)
            {
                btnN2.Enabled = false;
                IsThereAWinner();
            }
        }
        private void btnN4_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(btnN4.Text) == currentBall)
            {
                btnN4.Enabled = false;
                IsThereAWinner();
            }
        }
        private void btnN5_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(btnN5.Text) == currentBall)
            {
                btnN5.Enabled = false;
                IsThereAWinner();
            }
        }
        private void btnG1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(btnG1.Text) == currentBall)
            {
                btnG1.Enabled = false;
                IsThereAWinner();
            }
        }
        private void btnG2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(btnG2.Text) == currentBall)
            {
                btnG2.Enabled = false;
                IsThereAWinner();
            }
        }
        private void btnG3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(btnG3.Text) == currentBall)
            {
                btnG3.Enabled = false;
                IsThereAWinner();
            }
        }
        private void btnG4_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(btnG4.Text) == currentBall)
            {
                btnG4.Enabled = false;
                IsThereAWinner();
            }
        }
        private void btnG5_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(btnG5.Text) == currentBall)
            {
                btnG5.Enabled = false;
                IsThereAWinner();
            }
        }
        private void btnO1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(btnO1.Text) == currentBall)
            {
                btnO1.Enabled = false;
                IsThereAWinner();
            }
        }
        private void btnO2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(btnO2.Text) == currentBall)
            {
                btnO2.Enabled = false;
                IsThereAWinner();
            }
        }
        private void btnO3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(btnO3.Text) == currentBall)
            {
                btnO3.Enabled = false;
                IsThereAWinner();
            }
        }
        private void btnO4_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(btnO4.Text) == currentBall)
            {
                btnO4.Enabled = false;
                IsThereAWinner();
            }
        }
        private void btnO5_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(btnO5.Text) == currentBall)
            {
                btnO5.Enabled = false;
                IsThereAWinner();
            }
        }
        private void btnFree_Click(object sender, EventArgs e)
        {
            btnFree.Enabled = false;
            IsThereAWinner();
        }


    }
}
