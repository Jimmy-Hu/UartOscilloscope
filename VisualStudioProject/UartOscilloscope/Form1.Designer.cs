namespace UartOscilloscope														//	命名空間為本程式
{
    partial class Form1															//	Form1類別
	{																			//	進入Form1類別
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
			this.button3 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.傳輸設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.介面設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label7 = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button3
			// 
			this.button3.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.button3.Location = new System.Drawing.Point(904, 592);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(246, 34);
			this.button3.TabIndex = 0;
			this.button3.Text = "清除接收字串資料";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label1.Location = new System.Drawing.Point(904, 547);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(152, 21);
			this.label1.TabIndex = 1;
			this.label1.Text = "收到的Byte數：";
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.Label2.Location = new System.Drawing.Point(1032, 568);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(20, 21);
			this.Label2.TabIndex = 2;
			this.Label2.Text = "0";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(16, 471);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(882, 155);
			this.textBox1.TabIndex = 3;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.設定ToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1162, 24);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// 設定ToolStripMenuItem
			// 
			this.設定ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.傳輸設定ToolStripMenuItem,
            this.介面設定ToolStripMenuItem});
			this.設定ToolStripMenuItem.Name = "設定ToolStripMenuItem";
			this.設定ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
			this.設定ToolStripMenuItem.Text = "設定";
			// 
			// 傳輸設定ToolStripMenuItem
			// 
			this.傳輸設定ToolStripMenuItem.Name = "傳輸設定ToolStripMenuItem";
			this.傳輸設定ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.傳輸設定ToolStripMenuItem.Text = "傳輸設定";
			this.傳輸設定ToolStripMenuItem.Click += new System.EventHandler(this.設定_傳輸設定ToolStripMenuItem_Click);
			// 
			// 介面設定ToolStripMenuItem
			// 
			this.介面設定ToolStripMenuItem.Name = "介面設定ToolStripMenuItem";
			this.介面設定ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.介面設定ToolStripMenuItem.Text = "介面設定";
			this.介面設定ToolStripMenuItem.Click += new System.EventHandler(this.設定_介面設定ToolStripMenuItem_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(904, 64);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(246, 20);
			this.comboBox1.TabIndex = 5;
			this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_text_change);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("新細明體", 12F);
			this.label3.Location = new System.Drawing.Point(901, 45);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(148, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = "已連接的SerialPort：";
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.button2.Location = new System.Drawing.Point(1040, 132);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(110, 33);
			this.button2.TabIndex = 7;
			this.button2.Text = "連線";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.button1.Location = new System.Drawing.Point(968, 96);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(182, 30);
			this.button1.TabIndex = 8;
			this.button1.Text = "重新偵測SerialPort";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label4.Location = new System.Drawing.Point(13, 452);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(147, 16);
			this.label4.TabIndex = 9;
			this.label4.Text = "Uart接收字串資料：";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("新細明體", 12F);
			this.label5.Location = new System.Drawing.Point(901, 174);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(115, 16);
			this.label5.TabIndex = 10;
			this.label5.Text = "Uart連線狀態：";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("新細明體", 12F);
			this.label6.Location = new System.Drawing.Point(965, 201);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(72, 16);
			this.label6.TabIndex = 11;
			this.label6.Text = "連線狀態";
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(15, 64);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(880, 385);
			this.panel1.TabIndex = 12;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("新細明體", 16F);
			this.label7.Location = new System.Drawing.Point(12, 39);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(76, 22);
			this.label7.TabIndex = 0;
			this.label7.Text = "示波器";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1162, 638);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.menuStrip1);
			this.DoubleBuffered = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "主畫面";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		private void ComboBox1_TextChanged(object sender, System.EventArgs e)
		{
			throw new System.NotImplementedException();
		}

		#endregion

		private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem 設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 傳輸設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 介面設定ToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
	}																			//	結束Form1類別
}

