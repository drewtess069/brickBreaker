using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.IO;

namespace brickBreaker
{
    public partial class Form1 : Form
    {
        //Set up overlapping sounds
        System.Windows.Media.MediaPlayer effectPlayer = new System.Windows.Media.MediaPlayer();

        //Set up rectangles

        Rectangle player = new Rectangle(220, 550, 60, 10);
        Rectangle border = new Rectangle(0, 0, 500, 600);
        Rectangle ball = new Rectangle(245, 500, 10, 10);

        //Set up random gen
        Random powerGen = new Random();

        //Set up all global variables
        int time = 0;
        int timerTick = 0;
        int lives = 3;

        int playerSpeed = 6;
        float ballXSpeed = 1;
        float ballYSpeed = 7;

        int regBrickWidth = 30;
        int regBrickHeight = 20;
        int borderWidth = 10;

        int powerWidth = 25;
        int powerHeight = 25;
        int powerSpeed = 5;
        int powerCount = 0;

        int slowballChange = 0;

        int powertime = 0;

        string gameState = "waiting";

        bool leftDown = false;
        bool rightDown = false;

        bool slowBall = false;
        bool bigBall = false;
        bool bigPlayer = false;

        //Set up lists for powers and bricks
        List<Rectangle> brick = new List<Rectangle>();
        List<Rectangle> powers = new List<Rectangle>();
        List<string> powertype = new List<string>();

        //Set up power images
        Image slowPower = (Properties.Resources.slow);
        Image bigBallPower = (Properties.Resources.largeBall);
        Image bigPlayerPower = (Properties.Resources.largePlayer);

        //Set up brushes
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush orangeBrush = new SolidBrush(Color.Orange);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);

        //Set up pens
        Pen blackPen = new Pen(Color.Black, 5);
        Pen greenPen = new Pen(Color.DarkGreen, 20);
        public Form1()
        {
            InitializeComponent();
            Cursor.Hide();

            Form form = new Form();
            form.FormBorderStyle = FormBorderStyle.None;
            form.WindowState = FormWindowState.Maximized;
            form.BackColor = Color.Black;
            form.Show();
        }

        public void GameInitialize(string level)
        {

            //Reset all variables and locations on game start
            brick.Clear();
            powers.Clear();
            powertype.Clear();

            player.X = 220;
            player.Y = 550;

            ball.Y = 250;
            ball.X = 245;

            ballXSpeed = 1;
            ballYSpeed = 7;

            timerTick = 0;

            //Begin the countdown to game start
            titleLabel.Text = "3";
            subTitleLabel.Text = "";

            //Change the gamestate
            gameState = $"{level}";
            gameTimer.Enabled = true;

            //Draw different brick layouts for different levels by calling function
            if (gameState == "level 1")
            {
                drawBricks("level 1");
                lives = 3;
            }
            else if (gameState == "level 2")
            {
                drawBricks("level 2");
            }
            else if (gameState == "level 3")
            {
                drawBricks("level 3");
            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Draw title screen
            if (gameState == "waiting")
            {
                titleLabel.Text = "Brick Breaker";
                subTitleLabel.Text = "Press space to begin\n\nor escape to exit";
                timeLabel.Text = "";


                e.Graphics.DrawRectangle(blackPen, border);
                e.Graphics.FillEllipse(whiteBrush, ball);
                e.Graphics.FillRectangle(whiteBrush, player);
            }

            //Adjust screen to display level 1
            if (gameState == "level 1")
            {
                border.Height = 610;

                timeLabel.Text = $"Time:{time}";
                this.Text = $"Time:{time}";

                e.Graphics.DrawRectangle(greenPen, border);
                e.Graphics.FillEllipse(whiteBrush, ball);
                e.Graphics.FillRectangle(whiteBrush, player);

                //Draw all bricks
                for (int i = 0; i < brick.Count; i++)
                {
                    e.Graphics.FillRectangle(redBrush, brick[i]);
                }

                //Draw all powerups with different images based on their type
                for (int i = 0; i < powers.Count; i++)
                {

                    if (powertype[i] == "slowBall")
                    {
                        e.Graphics.DrawImage(slowPower, powers[i]);
                    }
                    else if (powertype[i] == "bigBall")
                    {
                        e.Graphics.DrawImage(bigBallPower, powers[i]);
                    }
                    else if (powertype[i] == "bigPlayer")
                    {
                        e.Graphics.DrawImage(bigPlayerPower, powers[i]);
                    }
                }
            }

            //Adjust screen to display level 1
            if (gameState == "level 2")
            {
                border.Height = 610;

                timeLabel.Text = $"Time:{time}";
                this.Text = $"Time:{time}";

                e.Graphics.DrawRectangle(greenPen, border);
                e.Graphics.FillEllipse(whiteBrush, ball);
                e.Graphics.FillRectangle(whiteBrush, player);

                //Draw bricks
                for (int i = 0; i < brick.Count; i++)
                {
                    e.Graphics.FillRectangle(orangeBrush, brick[i]);
                }

                //Draw all powerups with different images based on their type
                for (int i = 0; i < powers.Count; i++)
                {

                    if (powertype[i] == "slowBall")
                    {
                        e.Graphics.DrawImage(slowPower, powers[i]);
                    }
                    else if (powertype[i] == "bigBall")
                    {
                        e.Graphics.DrawImage(bigBallPower, powers[i]);
                    }
                    else if (powertype[i] == "bigPlayer")
                    {
                        e.Graphics.DrawImage(bigPlayerPower, powers[i]);
                    }
                }
            }

            //Adjust screen to display level 1
            if (gameState == "level 3")
            {
                border.Height = 610;

                timeLabel.Text = $"Time:{time}";
                this.Text = $"Time:{time}";

                e.Graphics.DrawRectangle(greenPen, border);
                e.Graphics.FillEllipse(whiteBrush, ball);
                e.Graphics.FillRectangle(whiteBrush, player);

                //Draw bricks
                for (int i = 0; i < brick.Count; i++)
                {
                    e.Graphics.FillRectangle(yellowBrush, brick[i]);
                }

                //Draw all powerups with different images based on their type
                for (int i = 0; i < powers.Count; i++)
                {

                    if (powertype[i] == "slowBall")
                    {
                        e.Graphics.DrawImage(slowPower, powers[i]);
                    }
                    else if (powertype[i] == "bigBall")
                    {
                        e.Graphics.DrawImage(bigBallPower, powers[i]);
                    }
                    else if (powertype[i] == "bigPlayer")
                    {
                        e.Graphics.DrawImage(bigPlayerPower, powers[i]);
                    }
                }
            }

            //Display game over screen
            if (gameState == "over")
            {

                titleLabel.Text = "Game Over";
                timeLabel.Text = "";


                e.Graphics.DrawRectangle(blackPen, border);
                e.Graphics.FillEllipse(whiteBrush, ball);
                e.Graphics.FillRectangle(whiteBrush, player);
                if (lives > 0)
                {
                    subTitleLabel.Text = $"Your time was {time}\n\nPress space to play\n\nagain\n\nor escape to exit";
                }
                else if (lives == 0)
                {
                    subTitleLabel.Text = $"You Lose!\n\nPress space to play again\n\n or escape to exit";
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //Set up player movement
                case Keys.Right:
                    rightDown = true;
                    break;
                case Keys.Left:
                    leftDown = true;
                    break;

                //Set up close game and begin game keys
                case Keys.Space:
                    if (gameState == "waiting" || gameState == "over")
                    {
                        GameInitialize("level 1");
                        time = 0;
                        heart1.BackgroundImage = Properties.Resources.heart;
                        heart2.BackgroundImage = Properties.Resources.heart;
                        heart3.BackgroundImage = Properties.Resources.heart;
                    }
                    break;
                case Keys.Escape:
                    if (gameState == "waiting" || gameState == "over")
                    {
                        Application.Exit();
                    }
                    else if (gameState == "level 1" || gameState == "level 2" || gameState == "level 3")
                    {

                        titleLabel.Text = "";

                        gameTimer.Enabled = false;
                        subTitleLabel.Text = "Do you want to exit the game? \n\nAll current progress will be lost";

                        continueButton.Enabled = true;
                        closeButton.Enabled = true;

                        continueButton.Visible = true;
                        closeButton.Visible = true;
                    }
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //If movements keys are not pressed, player should not be moving
            switch (e.KeyCode)
            {
                case Keys.Right:
                    rightDown = false;
                    break;
                case Keys.Left:
                    leftDown = false;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            powertime++;
            timerTick++;

            //Finish Countdown
            if (timerTick == 50)
            {
                titleLabel.Text = "2";
            }
            else if (timerTick == 100)
            {
                titleLabel.Text = "1";
            }
            else if (timerTick == 150)
            {
                titleLabel.Text = "";
            }

            //Track how long it takes for player to complete all levels
            if (timerTick % 50 == 0 && titleLabel.Text == "")
            {
                time++;

                timeLabel.Text = $"Time: {time}";
            }

            //Check for powerups and adjust gameplay based active powerups
            if (slowBall == true)
            {
                if (powertime < 100)
                {
                    if (slowballChange == 0)
                    {
                        slowballChange++;
                        ballXSpeed *= 0.6f;
                        ballYSpeed *= 0.6f;
                    }
                }
                else
                {
                    ballXSpeed *= 1.5f;
                    ballYSpeed *= 1.5f;
                    slowBall = false;
                    powerCount = 0;
                }
            }
            else if (bigBall == true)
            {
                if (powertime < 180)
                {
                    ball.Width = 20;
                    ball.Height = 20;
                }
                else
                {
                    ball.Width = 10;
                    ball.Height = 10;
                    bigBall = false;
                    powerCount = 0;
                }
            }
            else if (bigPlayer == true)
            {
                if (powertime < 180)
                {
                    player.Width = 80;
                }
                else
                {
                    bigPlayer = false;
                    player.Width -= 20;
                    powerCount = 0;
                }
            }

            //Move ball and any existing powers if countdown is over
            if (timerTick > 150)
            {
                ball.X += (int)ballXSpeed;
                ball.Y += (int)ballYSpeed;

                for (int i = 0; i < powers.Count; i++)
                {
                    int y = powers[i].Y + powerSpeed;
                    powers[i] = new Rectangle(powers[i].X, y, powers[i].Width, powers[i].Height);
                }
            }

            //move hero and set boundaries
            if (leftDown == true && player.X > 0 + borderWidth)
            {
                player.X -= playerSpeed;
            }
            if (rightDown == true && player.X < this.Width - player.Width - borderWidth)
            {
                player.X += playerSpeed;
            }

            //If ball hits edge of screen, change direction
            if (ball.X < 0 + borderWidth || ball.X > this.Width - borderWidth - ball.Width)
            {
                effectPlayer.Open(new Uri(Application.StartupPath + "/Resources/arkadroid-brick-breaker-gameplay-l5qopdm3_i7yl6WnE.wav"));
                effectPlayer.Play();

                ballXSpeed *= -1;
            }
            if (ball.Y < 0 + borderWidth)
            {
                effectPlayer.Open(new Uri(Application.StartupPath + "/Resources/arkadroid-brick-breaker-gameplay-l5qopdm3_i7yl6WnE.wav"));
                effectPlayer.Play();

                ballYSpeed *= -1;
            }
            if (ball.Y > this.Height)
            {
                SoundPlayer deathPlayer = new SoundPlayer(Properties.Resources.death);
                deathPlayer.Play();

                ballYSpeed = 7;
                ballXSpeed = 6;

                player.X = 220;
                player.Y = 550;

                //Take away a life if ball gets past player
                if (heart1.BackgroundImage != null)
                {
                    heart1.BackgroundImage = null;

                    lives--;

                    ball.X = 245;
                    ball.Y = 200;

                    Refresh();
                    Thread.Sleep(1000);
                }
                else if (heart2.BackgroundImage != null)
                {
                    heart2.BackgroundImage = null;

                    lives--;

                    ball.X = 245;
                    ball.Y = 200;

                    Refresh();
                    Thread.Sleep(1000);
                }
                else
                {
                    heart3.BackgroundImage = null;

                    lives--;

                    Refresh();
                    Thread.Sleep(200);

                    gameState = "over";
                    gameTimer.Stop();
                }
            }
            // Set up player intersections with ball
            if (player.IntersectsWith(ball))
            {
                ballYSpeed *= -1;

                if (bigPlayer == false)
                {
                    //Create different sections of player so ball bounces different directions based on where it hits
                    Rectangle sec1 = new Rectangle(player.X, player.Y, 12, 10);
                    Rectangle sec2 = new Rectangle(player.X + 12, player.Y, 12, 10);
                    Rectangle sec3 = new Rectangle(player.X + 36, player.Y, 12, 10);
                    Rectangle sec4 = new Rectangle(player.X + 48, player.Y, 12, 10);
                    Rectangle sec5 = new Rectangle(player.X + 24, player.Y, 12, 10);

                    //Call the intersections function based on the section of player that is hit by ball
                    intersections(sec1, sec2, sec3, sec4, sec5);
                }
                else
                {
                    //Check i big player powerup is active and adjust player sections if true
                    Rectangle sec1 = new Rectangle(player.X, player.Y, 12, 10);
                    Rectangle sec2 = new Rectangle(player.X + 16, player.Y, 12, 10);
                    Rectangle sec3 = new Rectangle(player.X + 48, player.Y, 12, 10);
                    Rectangle sec4 = new Rectangle(player.X + 64, player.Y, 12, 10);
                    Rectangle sec5 = new Rectangle(player.X + 32, player.Y, 12, 10);

                    //Call the intersections function based on the section of player that is hit by ball
                    intersections(sec1, sec2, sec3, sec4, sec5);
                }
            }

            //Check if the ball hits any brick
            for (int i = 0; i < brick.Count; i++)
            {
                if (brick[i].IntersectsWith(ball))
                {
                    //Play a sound for the brick breaking
                    //SoundPlayer breakPlayer = new SoundPlayer(Properties.Resources.brickBreak);
                    //breakPlayer.Play();

                    effectPlayer.Open(new Uri(Application.StartupPath + "/Resources/arkadroid-brick-breaker-gameplay-l5qopdm3_i7yl6WnE.wav"));
                    effectPlayer.Play();

                    //Create sections of bricks to make bounces as realistic as possible
                    Rectangle brickTop = new Rectangle(brick[i].X + 2, brick[i].Y, 26, 1);
                    Rectangle brickBottom = new Rectangle(brick[i].X + 2, brick[i].Y + regBrickHeight, 26, 1);

                    //Check the section of the brick being hit
                    if (ball.IntersectsWith(brickBottom) || ball.IntersectsWith(brickTop))
                    {
                        ballYSpeed *= -1;
                    }
                    else
                    {
                        ballXSpeed *= -1;
                    }

                    //If no powerups are currently active, bricks can spawn powerups when broken
                    if (slowBall == false && bigBall == false && bigPlayer == false)
                    {
                        int powerupChance = powerGen.Next(1, 10);

                        //Randomly generate when bricks create powerups (Approximately 20% of bricks create powerups)
                        if (powerupChance > 7)
                        {
                            powers.Add(new Rectangle(brick[i].X + 7, brick[i].Y, powerWidth, powerHeight));
                            powerupChance = powerGen.Next(1, 4);

                            //Determine which type of power is being created and added to list
                            if (powerupChance == 2)
                            {
                                powertype.Add("slowBall");
                            }
                            if (powerupChance == 3)
                            {
                                powertype.Add("bigPlayer");
                            }
                            if (powerupChance == 1)
                            {
                                powertype.Add("bigBall");
                            }
                        }
                    }
                    //Remove the brick that is hit
                    brick.RemoveAt(i);
                }
            }

            //Check if player hits a powerup and if no powerups are currently active, activate the power
            for (int i = 0; i < powers.Count; i++)
            {
                if (player.IntersectsWith(powers[i]) && powerCount == 0)
                {
                    powertime = 0;
                    if (powertype[i] == "slowBall")
                    {
                        slowballChange = 0;

                        //Uses booleans to enable powerups
                        slowBall = true;
                        powers.RemoveAt(i);
                        powertype.RemoveAt(i);

                        bigBall = false;
                        bigPlayer = false;
                    }
                    else if (powertype[i] == "bigBall")
                    {
                        bigBall = true;
                        powers.RemoveAt(i);
                        powertype.RemoveAt(i);


                        slowBall = false;
                        bigPlayer = false;
                    }
                    else
                    {
                        bigPlayer = true;
                        powers.RemoveAt(i);
                        powertype.RemoveAt(i);

                        slowBall = false;
                        bigBall = false;
                    }
                    //Increase the powercount so no other powerups can be used
                    powerCount++;
                }
            }

            //When all bricks are broken, move to next level or end screen if it was final level
            if (brick.Count == 0)
            {
                if (gameState == "level 1")
                {
                    gameState = "level 2";

                    GameInitialize("level 2");
                }
                else if (gameState == "level 2")
                {
                    GameInitialize("level 3");
                }
                else if (gameState == "level 3")
                {
                    gameState = "over";
                    gameTimer.Stop();
                }
            }
            Refresh();
        }

        //In the pause menu the player can either close the game or continue playing
        private void continueButton_Click(object sender, EventArgs e)
        {
            gameTimer.Enabled = true;

            subTitleLabel.Text = "";

            continueButton.Enabled = false;
            closeButton.Enabled = false;

            continueButton.Visible = false;
            closeButton.Visible = false;
        }

        //If a player chooses the close button in the pause menu, the game is ended and closed
        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void drawBricks(string level)
        {

            //Draw brick pattern for first level
            if (level == "level 1")
            {
                int brickX = 65;
                int brickY = 50;

                for (int a = 0; a < 3; a++)
                {
                    for (int i = 1; i < 6 + 1; i++)
                    {
                        brick.Add(new Rectangle(brickX, brickY, regBrickWidth, regBrickHeight));

                        brickX += 70;
                    }
                    brickX = 65; ;
                    brickY += 50;
                }
            }

            //Draw brick pattern for second level
            else if (level == "level 2")
            {
                int brickX = 70;
                int brickY = 30;


                for (int i = 0; i < 9; i++)
                {
                    brick.Add(new Rectangle(brickX, brickY, regBrickWidth, regBrickHeight));

                    brickX += 40;
                }

                brickY = 60;
                brickX = 70 + 40;

                for (int i = 0; i < 7; i++)
                {
                    brick.Add(new Rectangle(brickX, brickY, regBrickWidth, regBrickHeight));

                    brickX += 40;
                }

                brickY = 90;
                brickX = 70 + 80;

                for (int i = 0; i < 5; i++)
                {
                    brick.Add(new Rectangle(brickX, brickY, regBrickWidth, regBrickHeight));

                    brickX += 40;
                }

                brickY = 120;
                brickX = 70 + 120;

                for (int i = 0; i < 3; i++)
                {
                    brick.Add(new Rectangle(brickX, brickY, regBrickWidth, regBrickHeight));

                    brickX += 40;
                }


                brickY = 150;
                brickX = 70 + 160;

                for (int i = 0; i < 1; i++)
                {
                    brick.Add(new Rectangle(brickX, brickY, regBrickWidth, regBrickHeight));

                    brickX += 40;
                }
            }

            //Draw brick battern for level 3
            else
            {
                int brickX = 55;
                int brickY = 15;


                for (int i = 0; i < 10; i++)
                {
                    brick.Add(new Rectangle(brickX, brickY, regBrickWidth, regBrickHeight));

                    brickX += 40;
                }

                brickY = 45;
                brickX = 15;

                for (int i = 0; i < 12; i++)
                {
                    brick.Add(new Rectangle(brickX, brickY, regBrickWidth, regBrickHeight));

                    brickX += 40;
                }

                brickY = 75;

                for (int a = 0; a < 3; a++)
                {
                    brickX = 15;

                    for (int i = 0; i < 2; i++)
                    {
                        brick.Add(new Rectangle(brickX, brickY, regBrickWidth, regBrickHeight));

                        brickX += 40;
                    }

                    brickX += 120;

                    for (int i = 0; i < 2; i++)
                    {
                        brick.Add(new Rectangle(brickX, brickY, regBrickWidth, regBrickHeight));

                        brickX += 40;
                    }

                    brickX += 120;
                    for (int i = 0; i < 2; i++)
                    {
                        brick.Add(new Rectangle(brickX, brickY, regBrickWidth, regBrickHeight));

                        brickX += 40;
                    }

                    brickY += 30;
                }
                brickX = 15;

                for (int i = 0; i < 12; i++)
                {
                    brick.Add(new Rectangle(brickX, brickY, regBrickWidth, regBrickHeight));

                    brickX += 40;
                }

                brickY += 30;
                brickX = 55;

                for (int i = 0; i < 10; i++)
                {
                    brick.Add(new Rectangle(brickX, brickY, regBrickWidth, regBrickHeight));

                    brickX += 40;
                }

            }
        }

        public void intersections(Rectangle sec1, Rectangle sec2, Rectangle sec3, Rectangle sec4, Rectangle sec5)
        {
            //Check which section of player makes contact with the ball, adjust the bounce accordingly
            if (sec1.IntersectsWith(ball))
            {
                if (ballXSpeed < 5)
                {
                    ballXSpeed = -5;

                    ball.Y = player.Y - ball.Height - 3;
                }
                else
                {
                    ballXSpeed = -2;
                    ball.Y = player.Y - ball.Height - 3;
                }
            }
            else if (sec2.IntersectsWith(ball))
            {
                ballXSpeed *= 1.5f;

                ball.Y = player.Y - ball.Height - 3;
            }
            else if (sec3.IntersectsWith(ball))
            {
                ballXSpeed *= 1.5f;

                ball.Y = player.Y - ball.Height - 3;
            }
            if (sec4.IntersectsWith(ball))
            {
                if (ballXSpeed < 5)
                {
                    ballXSpeed = 4;


                    ball.Y = player.Y - ball.Height - 3;
                }
                else
                {
                    ballXSpeed = 2;
                    ballYSpeed *= 1.2f;
                    ball.Y = player.Y - ball.Height - 3;
                }
            }
            else if (sec5.IntersectsWith(ball))
            {
                ball.Y = player.Y - ball.Height - 3;
            }

            if (ballXSpeed > 8)
            {
                ballXSpeed *= 0.5f;
            }
            if (ballYSpeed > 8)
            {
                ballYSpeed *= 0.8f;
            }
        }
    }
}

