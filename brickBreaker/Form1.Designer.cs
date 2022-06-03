namespace brickBreaker
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.titleLabel = new System.Windows.Forms.Label();
            this.subTitleLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.continueButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.heart3 = new System.Windows.Forms.PictureBox();
            this.heart2 = new System.Windows.Forms.PictureBox();
            this.heart1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.heart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heart1)).BeginInit();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Arcade Interlaced", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(0, 151);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(500, 50);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "BRICK BREAKER";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // subTitleLabel
            // 
            this.subTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.subTitleLabel.Font = new System.Drawing.Font("Arcade Interlaced", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subTitleLabel.Location = new System.Drawing.Point(13, 211);
            this.subTitleLabel.Name = "subTitleLabel";
            this.subTitleLabel.Size = new System.Drawing.Size(473, 128);
            this.subTitleLabel.TabIndex = 1;
            this.subTitleLabel.Text = "Press Space to Begin";
            this.subTitleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // timeLabel
            // 
            this.timeLabel.BackColor = System.Drawing.Color.Transparent;
            this.timeLabel.Font = new System.Drawing.Font("Arcade Interlaced", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.ForeColor = System.Drawing.Color.White;
            this.timeLabel.Location = new System.Drawing.Point(12, 9);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(100, 23);
            this.timeLabel.TabIndex = 2;
            this.timeLabel.Text = "time";
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // continueButton
            // 
            this.continueButton.Enabled = false;
            this.continueButton.Font = new System.Drawing.Font("Arcade Interlaced", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueButton.Location = new System.Drawing.Point(261, 333);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(81, 43);
            this.continueButton.TabIndex = 4;
            this.continueButton.Text = "NO";
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Visible = false;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Enabled = false;
            this.closeButton.Font = new System.Drawing.Font("Arcade Interlaced", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(162, 333);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(88, 43);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "YES";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Visible = false;
            // 
            // heart3
            // 
            this.heart3.BackColor = System.Drawing.Color.Transparent;
            this.heart3.BackgroundImage = global::brickBreaker.Properties.Resources.heart;
            this.heart3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.heart3.Location = new System.Drawing.Point(461, 14);
            this.heart3.Name = "heart3";
            this.heart3.Size = new System.Drawing.Size(22, 23);
            this.heart3.TabIndex = 7;
            this.heart3.TabStop = false;
            // 
            // heart2
            // 
            this.heart2.BackColor = System.Drawing.Color.Transparent;
            this.heart2.BackgroundImage = global::brickBreaker.Properties.Resources.heart;
            this.heart2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.heart2.Location = new System.Drawing.Point(433, 14);
            this.heart2.Name = "heart2";
            this.heart2.Size = new System.Drawing.Size(22, 23);
            this.heart2.TabIndex = 8;
            this.heart2.TabStop = false;
            // 
            // heart1
            // 
            this.heart1.BackColor = System.Drawing.Color.Transparent;
            this.heart1.BackgroundImage = global::brickBreaker.Properties.Resources.heart;
            this.heart1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.heart1.Location = new System.Drawing.Point(405, 14);
            this.heart1.Name = "heart1";
            this.heart1.Size = new System.Drawing.Size(22, 23);
            this.heart1.TabIndex = 9;
            this.heart1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(500, 600);
            this.Controls.Add(this.heart1);
            this.Controls.Add(this.heart2);
            this.Controls.Add(this.heart3);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.subTitleLabel);
            this.Controls.Add(this.titleLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brick Breaker";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.heart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subTitleLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.PictureBox heart3;
        private System.Windows.Forms.PictureBox heart2;
        private System.Windows.Forms.PictureBox heart1;
    }
}

