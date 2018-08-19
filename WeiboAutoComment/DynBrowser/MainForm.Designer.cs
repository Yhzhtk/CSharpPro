namespace DynBrowser
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLab = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.weiboProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.stepLab = new System.Windows.Forms.ToolStripStatusLabel();
            this.weiboStatusLab = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerStatusLab = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.定时ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerManToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reIndexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onoffTimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.backToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.forwardToolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.urlTxt = new System.Windows.Forms.ToolStripTextBox();
            this.goToolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.openWeiboBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.userTxt = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.pwdTxt = new System.Windows.Forms.ToolStripTextBox();
            this.loginBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.searchTxt = new System.Windows.Forms.ToolStripTextBox();
            this.searchBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.pageTxt = new System.Windows.Forms.ToolStripTextBox();
            this.pageBtn = new System.Windows.Forms.ToolStripButton();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.noTxt = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.contentTxt = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.openFeedBtn = new System.Windows.Forms.ToolStripButton();
            this.submitFeedBtn = new System.Windows.Forms.ToolStripButton();
            this.commentStateLab = new System.Windows.Forms.ToolStripLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.weiboTimer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLab,
            this.progressBar,
            this.toolStripStatusLabel1,
            this.weiboProgressBar,
            this.stepLab,
            this.weiboStatusLab,
            this.timerStatusLab});
            this.statusStrip1.Location = new System.Drawing.Point(0, 534);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(946, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "微博显示";
            // 
            // statusLab
            // 
            this.statusLab.Name = "statusLab";
            this.statusLab.Size = new System.Drawing.Size(29, 17);
            this.statusLab.Text = "状态";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.progressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(53, 17);
            this.toolStripStatusLabel1.Text = "评论进度";
            // 
            // weiboProgressBar
            // 
            this.weiboProgressBar.Name = "weiboProgressBar";
            this.weiboProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // stepLab
            // 
            this.stepLab.Name = "stepLab";
            this.stepLab.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.stepLab.Size = new System.Drawing.Size(77, 17);
            this.stepLab.Text = "现在执行步骤";
            // 
            // weiboStatusLab
            // 
            this.weiboStatusLab.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.weiboStatusLab.Name = "weiboStatusLab";
            this.weiboStatusLab.Size = new System.Drawing.Size(284, 17);
            this.weiboStatusLab.Spring = true;
            this.weiboStatusLab.Text = "微博操作显示条";
            this.weiboStatusLab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timerStatusLab
            // 
            this.timerStatusLab.Name = "timerStatusLab";
            this.timerStatusLab.Size = new System.Drawing.Size(284, 17);
            this.timerStatusLab.Spring = true;
            this.timerStatusLab.Text = "满足条件";
            this.timerStatusLab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.定时ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(946, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 定时ToolStripMenuItem
            // 
            this.定时ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timerManToolStripMenuItem1,
            this.reIndexToolStripMenuItem,
            this.onoffTimerToolStripMenuItem});
            this.定时ToolStripMenuItem.Name = "定时ToolStripMenuItem";
            this.定时ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.定时ToolStripMenuItem.Text = "定时";
            // 
            // timerManToolStripMenuItem1
            // 
            this.timerManToolStripMenuItem1.Name = "timerManToolStripMenuItem1";
            this.timerManToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.timerManToolStripMenuItem1.Text = "定时管理";
            this.timerManToolStripMenuItem1.Click += new System.EventHandler(this.timerManToolStripMenuItem1_Click);
            // 
            // reIndexToolStripMenuItem
            // 
            this.reIndexToolStripMenuItem.Name = "reIndexToolStripMenuItem";
            this.reIndexToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.reIndexToolStripMenuItem.Text = "重置";
            this.reIndexToolStripMenuItem.Click += new System.EventHandler(this.reIndexToolStripMenuItem_Click);
            // 
            // onoffTimerToolStripMenuItem
            // 
            this.onoffTimerToolStripMenuItem.Name = "onoffTimerToolStripMenuItem";
            this.onoffTimerToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.onoffTimerToolStripMenuItem.Text = "启动定时";
            this.onoffTimerToolStripMenuItem.Click += new System.EventHandler(this.onoffTimerToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.aboutToolStripMenuItem.Text = "关于本软件";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backToolStripButton1,
            this.forwardToolStripButton2,
            this.urlTxt,
            this.goToolStripButton3,
            this.openWeiboBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(946, 29);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // backToolStripButton1
            // 
            this.backToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.backToolStripButton1.Image = global::DynBrowser.Properties.Resources.back;
            this.backToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backToolStripButton1.Name = "backToolStripButton1";
            this.backToolStripButton1.Size = new System.Drawing.Size(23, 26);
            this.backToolStripButton1.Text = "toolStripButton1";
            this.backToolStripButton1.Click += new System.EventHandler(this.urlBtn_Click);
            // 
            // forwardToolStripButton2
            // 
            this.forwardToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.forwardToolStripButton2.Image = global::DynBrowser.Properties.Resources.forward;
            this.forwardToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.forwardToolStripButton2.Name = "forwardToolStripButton2";
            this.forwardToolStripButton2.Size = new System.Drawing.Size(23, 26);
            this.forwardToolStripButton2.Text = "toolStripButton2";
            this.forwardToolStripButton2.Click += new System.EventHandler(this.urlBtn_Click);
            // 
            // urlTxt
            // 
            this.urlTxt.Name = "urlTxt";
            this.urlTxt.Size = new System.Drawing.Size(700, 29);
            this.urlTxt.Text = "about:blank";
            // 
            // goToolStripButton3
            // 
            this.goToolStripButton3.BackColor = System.Drawing.SystemColors.Control;
            this.goToolStripButton3.BackgroundImage = global::DynBrowser.Properties.Resources.go;
            this.goToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.goToolStripButton3.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goToolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("goToolStripButton3.Image")));
            this.goToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.goToolStripButton3.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.goToolStripButton3.Name = "goToolStripButton3";
            this.goToolStripButton3.Size = new System.Drawing.Size(36, 26);
            this.goToolStripButton3.Text = "GO";
            this.goToolStripButton3.Click += new System.EventHandler(this.goToolStripButton3_Click);
            // 
            // openWeiboBtn
            // 
            this.openWeiboBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.openWeiboBtn.Image = ((System.Drawing.Image)(resources.GetObject("openWeiboBtn.Image")));
            this.openWeiboBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openWeiboBtn.Name = "openWeiboBtn";
            this.openWeiboBtn.Size = new System.Drawing.Size(57, 26);
            this.openWeiboBtn.Text = "打开微博";
            this.openWeiboBtn.Click += new System.EventHandler(this.openWeiboBtn_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.userTxt,
            this.toolStripLabel4,
            this.pwdTxt,
            this.loginBtn,
            this.toolStripSeparator1,
            this.toolStripLabel5,
            this.searchTxt,
            this.searchBtn,
            this.toolStripSeparator2,
            this.toolStripLabel6,
            this.pageTxt,
            this.pageBtn});
            this.toolStrip2.Location = new System.Drawing.Point(0, 53);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(946, 25);
            this.toolStrip2.TabIndex = 4;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(41, 22);
            this.toolStripLabel3.Text = "用户名";
            // 
            // userTxt
            // 
            this.userTxt.Name = "userTxt";
            this.userTxt.Size = new System.Drawing.Size(150, 25);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(29, 22);
            this.toolStripLabel4.Text = "密码";
            // 
            // pwdTxt
            // 
            this.pwdTxt.Name = "pwdTxt";
            this.pwdTxt.Size = new System.Drawing.Size(150, 25);
            // 
            // loginBtn
            // 
            this.loginBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.loginBtn.Image = ((System.Drawing.Image)(resources.GetObject("loginBtn.Image")));
            this.loginBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(33, 22);
            this.loginBtn.Text = "登录";
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(53, 22);
            this.toolStripLabel5.Text = "搜索内容";
            // 
            // searchTxt
            // 
            this.searchTxt.Name = "searchTxt";
            this.searchTxt.Size = new System.Drawing.Size(200, 25);
            // 
            // searchBtn
            // 
            this.searchBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.searchBtn.Image = ((System.Drawing.Image)(resources.GetObject("searchBtn.Image")));
            this.searchBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(33, 22);
            this.searchBtn.Text = "搜索";
            this.searchBtn.Click += new System.EventHandler(this.searchBtn2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(29, 22);
            this.toolStripLabel6.Text = "页码";
            // 
            // pageTxt
            // 
            this.pageTxt.Name = "pageTxt";
            this.pageTxt.Size = new System.Drawing.Size(50, 25);
            this.pageTxt.Text = "0";
            this.pageTxt.TextChanged += new System.EventHandler(this.noTxt_TextChanged);
            // 
            // pageBtn
            // 
            this.pageBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.pageBtn.Image = ((System.Drawing.Image)(resources.GetObject("pageBtn.Image")));
            this.pageBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pageBtn.Name = "pageBtn";
            this.pageBtn.Size = new System.Drawing.Size(33, 22);
            this.pageBtn.Text = "翻页";
            this.pageBtn.Click += new System.EventHandler(this.pageBtn_Click);
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(946, 431);
            this.webBrowser.TabIndex = 5;
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            this.webBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser_Navigating);
            this.webBrowser.NewWindow += new System.ComponentModel.CancelEventHandler(this.webBrowser_NewWindow);
            this.webBrowser.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.webBrowser_ProgressChanged);
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.noTxt,
            this.toolStripLabel2,
            this.contentTxt,
            this.toolStripSeparator3,
            this.openFeedBtn,
            this.submitFeedBtn,
            this.commentStateLab});
            this.toolStrip3.Location = new System.Drawing.Point(0, 78);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(946, 25);
            this.toolStrip3.TabIndex = 5;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(65, 22);
            this.toolStripLabel1.Text = "评论第几个";
            // 
            // noTxt
            // 
            this.noTxt.Name = "noTxt";
            this.noTxt.Size = new System.Drawing.Size(50, 25);
            this.noTxt.Text = "0";
            this.noTxt.TextChanged += new System.EventHandler(this.noTxt_TextChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(53, 22);
            this.toolStripLabel2.Text = "评论内容";
            // 
            // contentTxt
            // 
            this.contentTxt.Name = "contentTxt";
            this.contentTxt.Size = new System.Drawing.Size(500, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // openFeedBtn
            // 
            this.openFeedBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.openFeedBtn.Image = ((System.Drawing.Image)(resources.GetObject("openFeedBtn.Image")));
            this.openFeedBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openFeedBtn.Name = "openFeedBtn";
            this.openFeedBtn.Size = new System.Drawing.Size(57, 22);
            this.openFeedBtn.Text = "打开评论";
            this.openFeedBtn.Click += new System.EventHandler(this.openFeedBtn_Click);
            // 
            // submitFeedBtn
            // 
            this.submitFeedBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.submitFeedBtn.Image = ((System.Drawing.Image)(resources.GetObject("submitFeedBtn.Image")));
            this.submitFeedBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.submitFeedBtn.Name = "submitFeedBtn";
            this.submitFeedBtn.Size = new System.Drawing.Size(57, 22);
            this.submitFeedBtn.Text = "发表评论";
            this.submitFeedBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // commentStateLab
            // 
            this.commentStateLab.Name = "commentStateLab";
            this.commentStateLab.Size = new System.Drawing.Size(35, 22);
            this.commentStateLab.Text = "false";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.webBrowser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(946, 431);
            this.panel1.TabIndex = 6;
            // 
            // weiboTimer
            // 
            this.weiboTimer.Tick += new System.EventHandler(this.timerClick_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 556);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip3);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("楷体_GB2312", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "DynBrowser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLab;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton backToolStripButton1;
        private System.Windows.Forms.ToolStripButton forwardToolStripButton2;
        private System.Windows.Forms.ToolStripTextBox urlTxt;
        private System.Windows.Forms.ToolStripButton goToolStripButton3;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripButton loginBtn;
        private System.Windows.Forms.ToolStripButton searchBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox userTxt;
        private System.Windows.Forms.ToolStripTextBox pwdTxt;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox noTxt;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox contentTxt;
        private System.Windows.Forms.ToolStripButton submitFeedBtn;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox searchTxt;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton openFeedBtn;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer weiboTimer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox pageTxt;
        private System.Windows.Forms.ToolStripButton pageBtn;
        private System.Windows.Forms.ToolStripButton openWeiboBtn;
        private System.Windows.Forms.ToolStripStatusLabel weiboStatusLab;
        private System.Windows.Forms.ToolStripMenuItem 定时ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timerManToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem onoffTimerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStripMenuItem reIndexToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar weiboProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel stepLab;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel commentStateLab;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel timerStatusLab;
    }
}

