﻿namespace JJangGoo05
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gamestart = new System.Windows.Forms.Button();
            this.gamemethod = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gameItr = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gamestart
            // 
            this.gamestart.Location = new System.Drawing.Point(353, 362);
            this.gamestart.Name = "gamestart";
            this.gamestart.Size = new System.Drawing.Size(137, 51);
            this.gamestart.TabIndex = 0;
            this.gamestart.Text = "게임시작";
            this.gamestart.UseVisualStyleBackColor = true;
            this.gamestart.Click += new System.EventHandler(this.gamestart_Click);
            // 
            // gamemethod
            // 
            this.gamemethod.Location = new System.Drawing.Point(718, 3);
            this.gamemethod.Name = "gamemethod";
            this.gamemethod.Size = new System.Drawing.Size(138, 77);
            this.gamemethod.TabIndex = 1;
            this.gamemethod.Text = "게임설명";
            this.gamemethod.UseVisualStyleBackColor = true;
            this.gamemethod.Click += new System.EventHandler(this.gamemethod_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(859, 480);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.gamestart);
            this.panel2.Controls.Add(this.gamemethod);
            this.panel2.Controls.Add(this.gameItr);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(859, 480);
            this.panel2.TabIndex = 3;
            // 
            // gameItr
            // 
            this.gameItr.AutoSize = true;
            this.gameItr.Location = new System.Drawing.Point(637, 35);
            this.gameItr.Name = "gameItr";
            this.gameItr.Size = new System.Drawing.Size(29, 12);
            this.gameItr.TabIndex = 2;
            this.gameItr.Text = "설명";
            this.gameItr.Click += new System.EventHandler(this.label1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "MakaoJyoma.jpg");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::JJangGoo05.Properties.Resources.s1;
            this.pictureBox1.Location = new System.Drawing.Point(273, 152);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 166);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 480);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button gamestart;
        private System.Windows.Forms.Button gamemethod;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label gameItr;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
