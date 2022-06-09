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

        //Random powerGen = new Random();

        int time = 0;
        int timerTick = 0;

        int playerSpeed = 6;
        float ballXSpeed = 6;
        float ballYSpeed = 7;

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
                drawBricks("level 1");
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
                this.Text = $"Time:{time}";

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
                this.Text = $"Time:{time}";

                e.Graphics.DrawRectangle(greenPen, border);
                e.Graphics.FillEllipse(whiteBrush, ball);
                e.Graphics.FillRectangle(blackBrush, player);

                for (int i = 0; i < brick.Count; i++)
                {
                    e.Graphics.FillRectangle(orangeBrush, brick[i]);
                }
            }
            if (gameState == "level 3")
            {
                border.Height = 610;

                timeLabel.Text = $"Time:{time}";
                this.Text = $"Time:{time}";

                e.Graphics.DrawRectangle(greenPen, border);
                e.Graphics.FillEllipse(whiteBrush, ball);
                e.Graphics.FillRectangle(blackBrush, player);

                for (int i = 0; i < brick.Count; i++)
                {
                    e.Graphics.FillRectangle(yellowBrush, brick[i]);
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
                        GameInitialize("level 3");
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
            if (timerTick == 50 && titleLabel.Text == "")
            {
                time++;
                timeLabel.Text = $"Time: {time}";
            }

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
                ballYSpeed = 7;
                ballXSpeed = 6;

                player.X = 220;
                player.Y = 550;

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
            // Set up player intersections with ball
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
            for (int i = 0; i < brick.Count; i++)
            {
                if (brick[i].IntersectsWith(ball))
                {


                    if ((ballXSpeed > 0) && (ball.Y > brick[i].Y && ball.Y < brick[i].Y + brick[i].Height - 2))
                    {
                        ballXSpeed *= -1;
                    }
                    else if ((ballXSpeed < 0) && (ball.Y > brick[i].Y && ball.Y < brick[i].Y + brick[i].Height - 2))
                    {
                        ballXSpeed *= -1;
                    }
                    else
                    {
                        ballYSpeed *= -1;
                    }
                    brick.RemoveAt(i);
                }
            }

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
                }
            }
            Refresh();
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            gameTimer.Enabled = true;

            subTitleLabel.Visible = false;

            continueButton.Enabled = false;
            closeButton.Enabled = false;

            continueButton.Visible = false;
            closeButton.Visible = false;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        public void drawBricks(string level)
        {


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
            else
            {
                int brickX = 45;
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
    }
}
