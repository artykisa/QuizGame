namespace ClientBrain
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.ConnectToGame = new System.Windows.Forms.Button();
            this.ProfileBut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ConnectToGame
            // 
            this.ConnectToGame.Location = new System.Drawing.Point(287, 128);
            this.ConnectToGame.Name = "ConnectToGame";
            this.ConnectToGame.Size = new System.Drawing.Size(223, 124);
            this.ConnectToGame.TabIndex = 0;
            this.ConnectToGame.Text = "Connect to game";
            this.ConnectToGame.UseVisualStyleBackColor = true;
            this.ConnectToGame.Click += new System.EventHandler(this.ConnectToGame_Click);
            // 
            // ProfileBut
            // 
            this.ProfileBut.Location = new System.Drawing.Point(12, 112);
            this.ProfileBut.Name = "ProfileBut";
            this.ProfileBut.Size = new System.Drawing.Size(148, 50);
            this.ProfileBut.TabIndex = 1;
            this.ProfileBut.Text = "Profile";
            this.ProfileBut.UseVisualStyleBackColor = true;
            this.ProfileBut.Click += new System.EventHandler(this.ProfileBut_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ProfileBut);
            this.Controls.Add(this.ConnectToGame);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ConnectToGame;
        private System.Windows.Forms.Button ProfileBut;
    }
}