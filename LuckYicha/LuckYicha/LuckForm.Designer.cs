namespace LuckYicha
{
    partial class LuckForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LuckForm));
            this.panelChoujian = new System.Windows.Forms.Panel();
            this.startEndLab = new System.Windows.Forms.Label();
            this.phoneLab = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.reStartLab = new System.Windows.Forms.Label();
            this.stateLab = new System.Windows.Forms.Label();
            this.conStartLab = new System.Windows.Forms.Label();
            this.luckListLab = new System.Windows.Forms.Label();
            this.startPanel = new System.Windows.Forms.Panel();
            this.areaLab = new System.Windows.Forms.Label();
            this.gongxixPicBox = new System.Windows.Forms.PictureBox();
            this.gongxiPicBox = new System.Windows.Forms.PictureBox();
            this.luckPanel = new System.Windows.Forms.Panel();
            this.luckOkLab = new System.Windows.Forms.Label();
            this.luckPeopleLab = new System.Windows.Forms.Label();
            this.luckTitleLab = new System.Windows.Forms.Label();
            this.giftLab = new System.Windows.Forms.Label();
            this.giftPicBox = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.startPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gongxixPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gongxiPicBox)).BeginInit();
            this.luckPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.giftPicBox)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelChoujian
            // 
            this.panelChoujian.BackColor = System.Drawing.Color.Transparent;
            this.panelChoujian.BackgroundImage = global::LuckYicha.Properties.Resources.cj;
            this.panelChoujian.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelChoujian.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelChoujian.Location = new System.Drawing.Point(360, 455);
            this.panelChoujian.Name = "panelChoujian";
            this.panelChoujian.Size = new System.Drawing.Size(322, 92);
            this.panelChoujian.TabIndex = 0;
            this.panelChoujian.Click += new System.EventHandler(this.panelChoujian_Click);
            // 
            // startEndLab
            // 
            this.startEndLab.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.startEndLab.AutoSize = true;
            this.startEndLab.BackColor = System.Drawing.Color.Transparent;
            this.startEndLab.Font = new System.Drawing.Font("隶书", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.startEndLab.ForeColor = System.Drawing.Color.Gold;
            this.startEndLab.Location = new System.Drawing.Point(487, 455);
            this.startEndLab.Name = "startEndLab";
            this.startEndLab.Size = new System.Drawing.Size(136, 56);
            this.startEndLab.TabIndex = 1;
            this.startEndLab.Text = "开始";
            this.startEndLab.Click += new System.EventHandler(this.startEndLab_Click);
            // 
            // phoneLab
            // 
            this.phoneLab.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.phoneLab.AutoSize = true;
            this.phoneLab.BackColor = System.Drawing.Color.Transparent;
            this.phoneLab.Font = new System.Drawing.Font("华文仿宋", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.phoneLab.ForeColor = System.Drawing.Color.Gold;
            this.phoneLab.Location = new System.Drawing.Point(374, 333);
            this.phoneLab.Name = "phoneLab";
            this.phoneLab.Size = new System.Drawing.Size(373, 63);
            this.phoneLab.TabIndex = 2;
            this.phoneLab.Text = "祝  你  幸  运 !";
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // reStartLab
            // 
            this.reStartLab.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.reStartLab.AutoSize = true;
            this.reStartLab.BackColor = System.Drawing.Color.Transparent;
            this.reStartLab.Enabled = false;
            this.reStartLab.Font = new System.Drawing.Font("隶书", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.reStartLab.ForeColor = System.Drawing.Color.Gold;
            this.reStartLab.Location = new System.Drawing.Point(667, 455);
            this.reStartLab.Name = "reStartLab";
            this.reStartLab.Size = new System.Drawing.Size(106, 24);
            this.reStartLab.TabIndex = 3;
            this.reStartLab.Text = "重新抽奖";
            this.reStartLab.Click += new System.EventHandler(this.reStartLab_Click);
            // 
            // stateLab
            // 
            this.stateLab.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.stateLab.AutoSize = true;
            this.stateLab.BackColor = System.Drawing.Color.Transparent;
            this.stateLab.Font = new System.Drawing.Font("华文仿宋", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stateLab.ForeColor = System.Drawing.Color.Gold;
            this.stateLab.Location = new System.Drawing.Point(326, 258);
            this.stateLab.Name = "stateLab";
            this.stateLab.Size = new System.Drawing.Size(412, 39);
            this.stateLab.TabIndex = 4;
            this.stateLab.Text = "三等奖 已抽10人 剩余5人";
            // 
            // conStartLab
            // 
            this.conStartLab.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.conStartLab.AutoSize = true;
            this.conStartLab.BackColor = System.Drawing.Color.Transparent;
            this.conStartLab.Enabled = false;
            this.conStartLab.Font = new System.Drawing.Font("隶书", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.conStartLab.ForeColor = System.Drawing.Color.Gold;
            this.conStartLab.Location = new System.Drawing.Point(667, 487);
            this.conStartLab.Name = "conStartLab";
            this.conStartLab.Size = new System.Drawing.Size(106, 24);
            this.conStartLab.TabIndex = 5;
            this.conStartLab.Text = "确认抽奖";
            this.conStartLab.Click += new System.EventHandler(this.conStartLab_Click);
            // 
            // luckListLab
            // 
            this.luckListLab.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.luckListLab.AutoSize = true;
            this.luckListLab.BackColor = System.Drawing.Color.Transparent;
            this.luckListLab.Font = new System.Drawing.Font("隶书", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.luckListLab.ForeColor = System.Drawing.Color.Gold;
            this.luckListLab.Location = new System.Drawing.Point(830, 609);
            this.luckListLab.Name = "luckListLab";
            this.luckListLab.Size = new System.Drawing.Size(133, 29);
            this.luckListLab.TabIndex = 6;
            this.luckListLab.Text = "中奖名单";
            this.luckListLab.Click += new System.EventHandler(this.luckListLab_Click);
            // 
            // startPanel
            // 
            this.startPanel.BackColor = System.Drawing.Color.Transparent;
            this.startPanel.Controls.Add(this.areaLab);
            this.startPanel.Controls.Add(this.gongxixPicBox);
            this.startPanel.Controls.Add(this.gongxiPicBox);
            this.startPanel.Controls.Add(this.luckPanel);
            this.startPanel.Controls.Add(this.giftLab);
            this.startPanel.Controls.Add(this.giftPicBox);
            this.startPanel.Controls.Add(this.panel5);
            this.startPanel.Controls.Add(this.luckListLab);
            this.startPanel.Controls.Add(this.panel4);
            this.startPanel.Controls.Add(this.conStartLab);
            this.startPanel.Controls.Add(this.panel3);
            this.startPanel.Controls.Add(this.stateLab);
            this.startPanel.Controls.Add(this.panel2);
            this.startPanel.Controls.Add(this.reStartLab);
            this.startPanel.Controls.Add(this.panel1);
            this.startPanel.Controls.Add(this.phoneLab);
            this.startPanel.Controls.Add(this.startEndLab);
            this.startPanel.Location = new System.Drawing.Point(4, 12);
            this.startPanel.Name = "startPanel";
            this.startPanel.Size = new System.Drawing.Size(1055, 785);
            this.startPanel.TabIndex = 7;
            this.startPanel.Visible = false;
            // 
            // areaLab
            // 
            this.areaLab.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.areaLab.AutoSize = true;
            this.areaLab.BackColor = System.Drawing.Color.Transparent;
            this.areaLab.Font = new System.Drawing.Font("华文仿宋", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.areaLab.ForeColor = System.Drawing.Color.Gold;
            this.areaLab.Location = new System.Drawing.Point(292, 346);
            this.areaLab.Name = "areaLab";
            this.areaLab.Size = new System.Drawing.Size(89, 39);
            this.areaLab.TabIndex = 23;
            this.areaLab.Text = "　　";
            // 
            // gongxixPicBox
            // 
            this.gongxixPicBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.gongxixPicBox.Location = new System.Drawing.Point(623, 528);
            this.gongxixPicBox.Name = "gongxixPicBox";
            this.gongxixPicBox.Size = new System.Drawing.Size(200, 149);
            this.gongxixPicBox.TabIndex = 22;
            this.gongxixPicBox.TabStop = false;
            this.gongxixPicBox.Paint += new System.Windows.Forms.PaintEventHandler(this.gongxiPicBox_Paint);
            // 
            // gongxiPicBox
            // 
            this.gongxiPicBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.gongxiPicBox.Location = new System.Drawing.Point(148, 443);
            this.gongxiPicBox.Name = "gongxiPicBox";
            this.gongxiPicBox.Size = new System.Drawing.Size(335, 255);
            this.gongxiPicBox.TabIndex = 21;
            this.gongxiPicBox.TabStop = false;
            this.gongxiPicBox.Paint += new System.Windows.Forms.PaintEventHandler(this.gongxiPicBox_Paint);
            // 
            // luckPanel
            // 
            this.luckPanel.BackgroundImage = global::LuckYicha.Properties.Resources.res;
            this.luckPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.luckPanel.Controls.Add(this.luckOkLab);
            this.luckPanel.Controls.Add(this.luckPeopleLab);
            this.luckPanel.Controls.Add(this.luckTitleLab);
            this.luckPanel.Location = new System.Drawing.Point(695, 723);
            this.luckPanel.Name = "luckPanel";
            this.luckPanel.Size = new System.Drawing.Size(601, 517);
            this.luckPanel.TabIndex = 20;
            this.luckPanel.Visible = false;
            // 
            // luckOkLab
            // 
            this.luckOkLab.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.luckOkLab.AutoSize = true;
            this.luckOkLab.BackColor = System.Drawing.Color.Transparent;
            this.luckOkLab.Font = new System.Drawing.Font("隶书", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.luckOkLab.ForeColor = System.Drawing.Color.Gold;
            this.luckOkLab.Location = new System.Drawing.Point(257, 467);
            this.luckOkLab.Name = "luckOkLab";
            this.luckOkLab.Size = new System.Drawing.Size(87, 35);
            this.luckOkLab.TabIndex = 9;
            this.luckOkLab.Text = "确定";
            this.luckOkLab.Click += new System.EventHandler(this.luckOkLab_Click);
            // 
            // luckPeopleLab
            // 
            this.luckPeopleLab.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.luckPeopleLab.AutoSize = true;
            this.luckPeopleLab.BackColor = System.Drawing.Color.Transparent;
            this.luckPeopleLab.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.luckPeopleLab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.luckPeopleLab.Location = new System.Drawing.Point(25, 89);
            this.luckPeopleLab.Name = "luckPeopleLab";
            this.luckPeopleLab.Size = new System.Drawing.Size(553, 312);
            this.luckPeopleLab.TabIndex = 8;
            this.luckPeopleLab.Text = resources.GetString("luckPeopleLab.Text");
            // 
            // luckTitleLab
            // 
            this.luckTitleLab.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.luckTitleLab.AutoSize = true;
            this.luckTitleLab.BackColor = System.Drawing.Color.Transparent;
            this.luckTitleLab.Font = new System.Drawing.Font("楷体_GB2312", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.luckTitleLab.ForeColor = System.Drawing.Color.Gold;
            this.luckTitleLab.Location = new System.Drawing.Point(90, 22);
            this.luckTitleLab.Name = "luckTitleLab";
            this.luckTitleLab.Size = new System.Drawing.Size(423, 56);
            this.luckTitleLab.TabIndex = 7;
            this.luckTitleLab.Text = "三等奖中奖名单";
            // 
            // giftLab
            // 
            this.giftLab.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.giftLab.AutoSize = true;
            this.giftLab.BackColor = System.Drawing.Color.Transparent;
            this.giftLab.Font = new System.Drawing.Font("楷体_GB2312", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.giftLab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.giftLab.Location = new System.Drawing.Point(809, 545);
            this.giftLab.Name = "giftLab";
            this.giftLab.Size = new System.Drawing.Size(60, 24);
            this.giftLab.TabIndex = 19;
            this.giftLab.Text = "奖品";
            // 
            // giftPicBox
            // 
            this.giftPicBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.giftPicBox.BackColor = System.Drawing.Color.Transparent;
            this.giftPicBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.giftPicBox.Location = new System.Drawing.Point(779, 227);
            this.giftPicBox.Name = "giftPicBox";
            this.giftPicBox.Size = new System.Drawing.Size(238, 308);
            this.giftPicBox.TabIndex = 18;
            this.giftPicBox.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.pictureBox5);
            this.panel5.Location = new System.Drawing.Point(12, 475);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(266, 49);
            this.panel5.TabIndex = 17;
            this.panel5.Click += new System.EventHandler(this.panel_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BackgroundImage = global::LuckYicha.Properties.Resources.yuanbao;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox5.Location = new System.Drawing.Point(3, 1);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(78, 45);
            this.pictureBox5.TabIndex = 8;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Visible = false;
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.pictureBox4);
            this.panel4.Location = new System.Drawing.Point(12, 420);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(266, 49);
            this.panel4.TabIndex = 16;
            this.panel4.Click += new System.EventHandler(this.panel_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImage = global::LuckYicha.Properties.Resources.yuanbao;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Location = new System.Drawing.Point(3, 1);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(78, 45);
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Location = new System.Drawing.Point(12, 365);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(266, 49);
            this.panel3.TabIndex = 15;
            this.panel3.Click += new System.EventHandler(this.panel_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = global::LuckYicha.Properties.Resources.yuanbao;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(3, 1);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(78, 45);
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(12, 310);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(266, 49);
            this.panel2.TabIndex = 14;
            this.panel2.Click += new System.EventHandler(this.panel_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::LuckYicha.Properties.Resources.yuanbao;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(3, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(78, 45);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 255);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 49);
            this.panel1.TabIndex = 13;
            this.panel1.Click += new System.EventHandler(this.panel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::LuckYicha.Properties.Resources.yuanbao;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(3, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(78, 45);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // LuckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.startPanel);
            this.Controls.Add(this.panelChoujian);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "LuckForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "易查2013年会抽奖软件";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LuckForm_FormClosing);
            this.Load += new System.EventHandler(this.LuckForm_Load);
            this.startPanel.ResumeLayout(false);
            this.startPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gongxixPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gongxiPicBox)).EndInit();
            this.luckPanel.ResumeLayout(false);
            this.luckPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.giftPicBox)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelChoujian;
        private System.Windows.Forms.Label startEndLab;
        private System.Windows.Forms.Label phoneLab;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label reStartLab;
        private System.Windows.Forms.Label stateLab;
        private System.Windows.Forms.Label conStartLab;
        private System.Windows.Forms.Label luckListLab;
        private System.Windows.Forms.Panel startPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox giftPicBox;
        private System.Windows.Forms.Label giftLab;
        private System.Windows.Forms.Panel luckPanel;
        private System.Windows.Forms.Label luckPeopleLab;
        private System.Windows.Forms.Label luckTitleLab;
        private System.Windows.Forms.Label luckOkLab;
        private System.Windows.Forms.PictureBox gongxiPicBox;
        private System.Windows.Forms.PictureBox gongxixPicBox;
        private System.Windows.Forms.Label areaLab;



    }
}

