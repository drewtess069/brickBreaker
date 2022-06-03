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

namespace brickBreaker
{
    public partial class Form1 : Form
    {
        Rectangle player = new Rectangle(220, 550, 60, 10);
        Rectangle border = new Rectangle(0, 0, 500, 600);
        Rectangle ball = new Rectangle(245, 500, 10, 10);

        Random randGen = new Random();

        int time = 0;
        int timerTick = 0;

        int level1Bricks = 15;
        int level2Bricks = 20;
        int level3Bricks = 25;

        int playerSpeed = 5;
        float ballXSpeed = 6;
        float ballYSpeed = -7;

        int regBrickWidth = 30;
        int regBrickHeight = 20;
        int borderWidth = 10;

        string gameState = "waiting";

        bool leftDown = false;
        bool rightDown = false;

        List<Rectangle> brick = new List<Rectangle>();
        List<int> brickWidth = new List<int>();
        List<int> brickHeight = new List<int>();

        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush orangeBrush = new SolidBrush(Color.Orange);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);

        Pen blackPen = new Pen(Color.Black, 20);
        Pen greenPen = new Pen(Color.DarkGreen, 20);
        public Form1()
        {
            InitializeComponent();
        }

        public void GameInitialize(string level)
        {
            brick.Clear();
            brickWidth.Clear();
            brickHeight.Clear();

            player.X = 220;
            player.Y = 550;

            ball.Y = 250;
            ball.X = 245;

            time = 0;
            timerTick = 0;

            titleLabel.Text = "3";
            subTitleLabel.Text = "";

            gameState = $"{level}";
            gameTimer.Enabled = true;

            if (gameState == "level 1")
            {
                drawBricks(level1Bricks, "level 1");
            }
            else if (gameState == "level 2")
            {
                drawBricks(level2Bricks, "level 2");
            }
            else if (gameState == "level 3")
            {
                drawBricks(level3Bricks, "level 3");
            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gameState == "waiting")
            {
                titleLabel.Text = "Brick Breaker";
                subTitleLabel.Text = "Press space to begin\n\nor escape to exit";
                timeLabel.Text = "";


                e.Graphics.DrawRectangle(blackPen, border);
                e.Graphics.FillEllipse(whiteBrush, ball);
                e.Graphics.FillRectangle(blackBrush, player);
            }
            if (gameState == "level 1")
            {
                border.Height = 610;

                timeLabel.Text = $"Time:{time}";

                e.Graphics.DrawRectangle(greenPen, border);
                e.Graphics.FillEllipse(whiteBrush, ball);
                e.Graphics.FillRectangle(blackBrush, player);

                for (int i = 0; i < brick.Count; i++)
                {
                    e.Graphics.FillRectangle(redBrush, brick[i]);
                }
            }
            if (gameState == "level 2")
            {
                border.Height = 610;

                timeLabel.Text = $"Time:{time}";

                e.Graphics.DrawRectangle(greenPen, border);
                e.Graphics.FillEllipse(whiteBrush, ball);
                e.Graphics.FillRectangle(blackBrush, player);

                for (int i = 0; i < brick.Count; i++)
                {
                    e.Graphics.FillRectangle(orangeBrush, brick[i]);
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    rightDown = true;
                    break;
                case Keys.Left:
                    leftDown = true;
                    break;
                case Keys.Space:
                    if (gameState == "waiting")
                    {
                        GameInitialize("level 1");
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
            timerTick++;

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

            if (timerTick > 150)
            {
                ball.X += (int)ballXSpeed;
                ball.Y += (int)ballYSpeed;
            }
            //move hero 
            if (leftDown == true && player.X > 0 + borderWidth)
            {
                player.X -= playerSpeed;
            }

            if (rightDown == true && player.X < this.Width - player.Width - borderWidth)
            {
                player.X += playerSpeed;
            }
            if (ball.X < 0 + borderWidth || ball.X > this.Width - borderWidth - ball.Width)
            {
                ballXSpeed *= -1;
            }
            if (ball.Y < 0 + borderWidth)
            {
                ballYSpeed *= -1;
            }
            if (ball.Y > this.Height)
            {
                if (heart1.BackgroundImage != null)
                {
                    heart1.BackgroundImage = null;

                    ball.X = 245;
                    ball.Y = 200;

                    Refresh();
                    Thread.Sleep(1000);
                }
                else if (heart2.BackgroundImage != null)
                {
                    heart2.BackgroundImage = null;

                    ball.X = 245;
                    ball.Y = 200;

                    Refresh();
                    Thread.Sleep(1000);
                }
                else
                {
                    heart3.BackgroundImage = null;

                    Refresh();
                    Thread.Sleep(200);

                    gameState = "over";
                    gameTimer.Stop();
                }
            }
            // Set up player intersections
            if (player.IntersectsWith(ball))
            {
                ballYSpeed *= -1;

                Rectangle sec1 = new Rectangle(player.X, player.Y, 12, 10);
                Rectangle sec2 = new Rectangle(player.X + 12, player.Y, 12, 10);
                Rectangle sec3 = new Rectangle(player.X + 36, player.Y, 12, 10);
                Rectangle sec4 = new Rectangle(player.X + 48, player.Y, 12, 10);
                Rectangle sec5 = new Rectangle(player.X + 24, player.Y, 12, 10);

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

                        ball.Y = player.Y - ball.Height - 3;
                    }
                }
                else if (sec5.IntersectsWith(ball))
                {
                    ball.Y = player.Y - ball.Height - 3;
                }

                if (ballXSpeed > 8)
                {
                    ballXSpeed *= 0.8f;
                }
                if (ballYSpeed > 8)
                {
                    ballYSpeed *= 0.8f;
                }
            }
                for(int i = 0; i < brick.Count; i++)
                {
                    if (brick[i].IntersectsWith(ball))
                    {
                        brick.RemoveAt(i);

                      if((ballXSpeed > 0) && (ball.Y > brick[i].Y && ball.Y < brick[i].Y + brick[i].Height))
                        {
                            ballXSpeed *= -1;
                        }
                      else if ((ballXSpeed < 0) && (ball.Y > brick[i].Y && ball.Y < brick[i].Y + brick[i].Height))
                        {
                            ballXSpeed *= -1;
                        }
                        else
                        {
                            ballYSpeed *= -1;
                        }
                    
                }
            }
            Refresh();
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            gameTimer.Enabled = true;

            continueButton.Enabled = false;
            closeButton.Enabled = false;

            continueButton.Visible = false;
            closeButton.Visible = false;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void drawBricks(int levelBrick, string level)
        {
            int brickX = randGen.Next(0 + borderWidth, this.Width - borderWidth - regBrickWidth);
            int brickY = randGen.Next(0 + borderWidth, 300);

            Rectangle brick1 = new Rectangle(brickX, brickY, regBrickWidth, regBrickHeight);
            brick.Add(brick1);

            for (int i = 1; i < levelBrick; i++)
            {
                brickX = randGen.Next(0 + borderWidth, this.Width - borderWidth - regBrickWidth);
                brickY = randGen.Next(0 + borderWidth, 200);

                if (level == "level 1")
                {
                    Rectangle newBrick = new Rectangle(brickX, brickY, regBrickWidth, regBrickHeight);

                    for (int a = 0; a < brick.Count; a++)
                    {
                        while (newBrick.IntersectsWith(brick[a])){
                            brickX = randGen.Next(0 + borderWidth, this.Width - borderWidth - regBrickWidth);
                            brickY = randGen.Next(0 + borderWidth, 200);

                            newBrick = new Rectangle(brickX, brickY, regBrickWidth, regBrickHeight);
                        } 
                    }
                   brick.Add(newBrick);
                }
                else
                {
                    int width = randGen.Next(regBrickWidth - 10, regBrickWidth + 5);
                    int height = randGen.Next(regBrickHeight - 5, regBrickHeight + 10);

                    brick.Add(new Rectangle(brickX, brickY, width, height));
                }
            }
        }
    }
}
