namespace ClientBrain
{
    partial class Profile
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
            this.UpdateBut = new System.Windows.Forms.Button();
            this.statTextBox = new System.Windows.Forms.RichTextBox();
            this.picBoxProfile = new System.Windows.Forms.PictureBox();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // UpdateBut
            // 
            this.UpdateBut.Location = new System.Drawing.Point(534, 300);
            this.UpdateBut.Name = "UpdateBut";
            this.UpdateBut.Size = new System.Drawing.Size(186, 94);
            this.UpdateBut.TabIndex = 0;
            this.UpdateBut.Text = "Update Profile Pic";
            this.UpdateBut.UseVisualStyleBackColor = true;
            this.UpdateBut.Click += new System.EventHandler(this.UpdateBut_Click);
            // 
            // statTextBox
            // 
            this.statTextBox.Location = new System.Drawing.Point(12, 12);
            this.statTextBox.Name = "statTextBox";
            this.statTextBox.Size = new System.Drawing.Size(367, 426);
            this.statTextBox.TabIndex = 1;
            this.statTextBox.Text = "";
            // 
            // picBoxProfile
            // 
            this.picBoxProfile.Location = new System.Drawing.Point(534, 87);
            this.picBoxProfile.Name = "picBoxProfile";
            this.picBoxProfile.Size = new System.Drawing.Size(186, 150);
            this.picBoxProfile.TabIndex = 2;
            this.picBoxProfile.TabStop = false;
            // 
            // openFile
            // 
            this.openFile.FileName = "openFile";
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.picBoxProfile);
            this.Controls.Add(this.statTextBox);
            this.Controls.Add(this.UpdateBut);
            this.Name = "Profile";
            this.Text = "Profile";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxProfile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UpdateBut;
        private System.Windows.Forms.RichTextBox statTextBox;
        private System.Windows.Forms.PictureBox picBoxProfile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}