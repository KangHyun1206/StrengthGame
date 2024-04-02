namespace strengthGame
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
            this.statusText = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Item = new System.Windows.Forms.Button();
            this.moneyQuan = new System.Windows.Forms.Label();
            this.itemQuan = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.StrcostText = new System.Windows.Forms.Label();
            this.sellCostText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusText
            // 
            this.statusText.AutoSize = true;
            this.statusText.Font = new System.Drawing.Font("굴림", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.statusText.Location = new System.Drawing.Point(278, 40);
            this.statusText.Name = "statusText";
            this.statusText.Size = new System.Drawing.Size(112, 22);
            this.statusText.TabIndex = 0;
            this.statusText.Text = "게임 시작!";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("굴림", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(208, 266);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 50);
            this.button1.TabIndex = 1;
            this.button1.Text = "강화!!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::strengthGame.Properties.Resources.다운로드;
            this.pictureBox1.Location = new System.Drawing.Point(208, 98);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(285, 151);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Item
            // 
            this.btn_Item.Font = new System.Drawing.Font("굴림", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Item.Location = new System.Drawing.Point(380, 266);
            this.btn_Item.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Item.Name = "btn_Item";
            this.btn_Item.Size = new System.Drawing.Size(172, 50);
            this.btn_Item.TabIndex = 3;
            this.btn_Item.Text = "아이템 강화!";
            this.btn_Item.UseVisualStyleBackColor = true;
            this.btn_Item.Click += new System.EventHandler(this.btn_Item_Click);
            // 
            // moneyQuan
            // 
            this.moneyQuan.AutoSize = true;
            this.moneyQuan.Location = new System.Drawing.Point(37, 24);
            this.moneyQuan.Name = "moneyQuan";
            this.moneyQuan.Size = new System.Drawing.Size(59, 12);
            this.moneyQuan.TabIndex = 4;
            this.moneyQuan.Text = "돈 : 10000";
            // 
            // itemQuan
            // 
            this.itemQuan.AutoSize = true;
            this.itemQuan.Location = new System.Drawing.Point(129, 24);
            this.itemQuan.Name = "itemQuan";
            this.itemQuan.Size = new System.Drawing.Size(59, 12);
            this.itemQuan.TabIndex = 4;
            this.itemQuan.Text = "아이템 : 1";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.Location = new System.Drawing.Point(565, 266);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 50);
            this.button2.TabIndex = 5;
            this.button2.Text = "판매";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // StrcostText
            // 
            this.StrcostText.AutoSize = true;
            this.StrcostText.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.StrcostText.Location = new System.Drawing.Point(12, 98);
            this.StrcostText.Name = "StrcostText";
            this.StrcostText.Size = new System.Drawing.Size(155, 21);
            this.StrcostText.TabIndex = 6;
            this.StrcostText.Text = "강화 비용 : 100";
            // 
            // sellCostText
            // 
            this.sellCostText.AutoSize = true;
            this.sellCostText.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sellCostText.Location = new System.Drawing.Point(12, 141);
            this.sellCostText.Name = "sellCostText";
            this.sellCostText.Size = new System.Drawing.Size(155, 21);
            this.sellCostText.TabIndex = 6;
            this.sellCostText.Text = "판매 비용 : 100";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 360);
            this.Controls.Add(this.sellCostText);
            this.Controls.Add(this.StrcostText);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.itemQuan);
            this.Controls.Add(this.moneyQuan);
            this.Controls.Add(this.btn_Item);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusText);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label statusText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_Item;
        private System.Windows.Forms.Label moneyQuan;
        private System.Windows.Forms.Label itemQuan;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label StrcostText;
        private System.Windows.Forms.Label sellCostText;
    }
}

