namespace ClientBrain
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.numofquestion = new System.Windows.Forms.TextBox();
            this.question = new System.Windows.Forms.TextBox();
            this.answertextbox = new System.Windows.Forms.TextBox();
            this.butsend = new System.Windows.Forms.Button();
            this.butvarq1 = new System.Windows.Forms.Button();
            this.butvarq2 = new System.Windows.Forms.Button();
            this.butvarq3 = new System.Windows.Forms.Button();
            this.butvarq4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // numofquestion
            // 
            this.numofquestion.Location = new System.Drawing.Point(264, 13);
            this.numofquestion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numofquestion.Multiline = true;
            this.numofquestion.Name = "numofquestion";
            this.numofquestion.ReadOnly = true;
            this.numofquestion.Size = new System.Drawing.Size(348, 42);
            this.numofquestion.TabIndex = 2;
            this.numofquestion.Text = "            Questnion №";
            // 
            // question
            // 
            this.question.Location = new System.Drawing.Point(12, 104);
            this.question.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.question.Multiline = true;
            this.question.Name = "question";
            this.question.ReadOnly = true;
            this.question.Size = new System.Drawing.Size(758, 79);
            this.question.TabIndex = 3;
            // 
            // answertextbox
            // 
            this.answertextbox.Location = new System.Drawing.Point(264, 325);
            this.answertextbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.answertextbox.Multiline = true;
            this.answertextbox.Name = "answertextbox";
            this.answertextbox.Size = new System.Drawing.Size(348, 79);
            this.answertextbox.TabIndex = 4;
            // 
            // butsend
            // 
            this.butsend.Location = new System.Drawing.Point(654, 347);
            this.butsend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.butsend.Name = "butsend";
            this.butsend.Size = new System.Drawing.Size(134, 38);
            this.butsend.TabIndex = 8;
            this.butsend.Text = "Send";
            this.butsend.UseVisualStyleBackColor = true;
            this.butsend.Click += new System.EventHandler(this.butsend_Click);
            // 
            // butvarq1
            // 
            this.butvarq1.Location = new System.Drawing.Point(12, 250);
            this.butvarq1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.butvarq1.Name = "butvarq1";
            this.butvarq1.Size = new System.Drawing.Size(134, 38);
            this.butvarq1.TabIndex = 9;
            this.butvarq1.Text = "Send";
            this.butvarq1.UseVisualStyleBackColor = true;
            this.butvarq1.Click += new System.EventHandler(this.butvarq1_Click);
            // 
            // butvarq2
            // 
            this.butvarq2.Location = new System.Drawing.Point(231, 250);
            this.butvarq2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.butvarq2.Name = "butvarq2";
            this.butvarq2.Size = new System.Drawing.Size(134, 38);
            this.butvarq2.TabIndex = 10;
            this.butvarq2.Text = "Send";
            this.butvarq2.UseVisualStyleBackColor = true;
            this.butvarq2.Click += new System.EventHandler(this.butvarq2_Click);
            // 
            // butvarq3
            // 
            this.butvarq3.Location = new System.Drawing.Point(450, 250);
            this.butvarq3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.butvarq3.Name = "butvarq3";
            this.butvarq3.Size = new System.Drawing.Size(134, 38);
            this.butvarq3.TabIndex = 11;
            this.butvarq3.Text = "Send";
            this.butvarq3.UseVisualStyleBackColor = true;
            this.butvarq3.Click += new System.EventHandler(this.butvarq3_Click);
            // 
            // butvarq4
            // 
            this.butvarq4.Location = new System.Drawing.Point(636, 250);
            this.butvarq4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.butvarq4.Name = "butvarq4";
            this.butvarq4.Size = new System.Drawing.Size(134, 38);
            this.butvarq4.TabIndex = 12;
            this.butvarq4.Text = "Send";
            this.butvarq4.UseVisualStyleBackColor = true;
            this.butvarq4.Click += new System.EventHandler(this.butvarq4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.butvarq4);
            this.Controls.Add(this.butvarq3);
            this.Controls.Add(this.butvarq2);
            this.Controls.Add(this.butvarq1);
            this.Controls.Add(this.butsend);
            this.Controls.Add(this.answertextbox);
            this.Controls.Add(this.question);
            this.Controls.Add(this.numofquestion);
            this.Name = "Form1";
            this.Text = "Brain";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox numofquestion;
        private System.Windows.Forms.TextBox question;
        private System.Windows.Forms.TextBox answertextbox;
        private System.Windows.Forms.Button butsend;
        private System.Windows.Forms.Button butvarq1;
        private System.Windows.Forms.Button butvarq2;
        private System.Windows.Forms.Button butvarq3;
        private System.Windows.Forms.Button butvarq4;
    }
}

