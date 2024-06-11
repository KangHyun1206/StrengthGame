namespace strengthGame
{
    partial class Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.idBox = new System.Windows.Forms.TextBox();
            this.pwdBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.loginBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "아이디";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "패스워드";
            // 
            // idBox
            // 
            this.idBox.Location = new System.Drawing.Point(92, 54);
            this.idBox.Name = "idBox";
            this.idBox.Size = new System.Drawing.Size(100, 21);
            this.idBox.TabIndex = 1;
            // 
            // pwdBox
            // 
            this.pwdBox.Location = new System.Drawing.Point(92, 90);
            this.pwdBox.Name = "pwdBox";
            this.pwdBox.PasswordChar = '*';
            this.pwdBox.Size = new System.Drawing.Size(100, 21);
            this.pwdBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "아이디는 학번, 패스워드 : 1234";
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(198, 54);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(75, 57);
            this.loginBtn.TabIndex = 3;
            this.loginBtn.Text = "로그인";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pwdBox);
            this.Controls.Add(this.idBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox idBox;
        private System.Windows.Forms.TextBox pwdBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button loginBtn;
    }
}