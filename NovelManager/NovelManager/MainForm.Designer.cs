namespace NovelManager
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.resultGroup = new System.Windows.Forms.GroupBox();
            this.novelGridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.novelPageLabel = new System.Windows.Forms.Label();
            this.novelCountLabel = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gotoPageBtn = new System.Windows.Forms.Button();
            this.pageTxt = new System.Windows.Forms.TextBox();
            this.lastPageNlik = new System.Windows.Forms.LinkLabel();
            this.downPageNlik = new System.Windows.Forms.LinkLabel();
            this.upPageNlik = new System.Windows.Forms.LinkLabel();
            this.firstNPagelik = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.searchNidBtn = new System.Windows.Forms.Button();
            this.searchNidTxt = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.orderStrTxt = new System.Windows.Forms.TextBox();
            this.userDefineRadio = new System.Windows.Forms.RadioButton();
            this.blankCountRadio = new System.Windows.Forms.RadioButton();
            this.seqRadio = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.stateTxt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.typeTxt = new System.Windows.Forms.TextBox();
            this.operChapterBtn = new System.Windows.Forms.Button();
            this.allChapCountTxt = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.blankChapCountTxt = new System.Windows.Forms.TextBox();
            this.saveInfoBtn = new System.Windows.Forms.Button();
            this.reReadBtn = new System.Windows.Forms.Button();
            this.baseIdTxt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.descTxt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.urlTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nidTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.resultGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.novelGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 671);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(922, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(29, 17);
            this.statusLabel.Text = "就绪";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.resultGroup);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.label10);
            this.splitContainer1.Size = new System.Drawing.Size(922, 647);
            this.splitContainer1.SplitterDistance = 463;
            this.splitContainer1.TabIndex = 1;
            // 
            // resultGroup
            // 
            this.resultGroup.Controls.Add(this.novelGridView);
            this.resultGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultGroup.Location = new System.Drawing.Point(0, 188);
            this.resultGroup.Name = "resultGroup";
            this.resultGroup.Size = new System.Drawing.Size(463, 459);
            this.resultGroup.TabIndex = 1;
            this.resultGroup.TabStop = false;
            this.resultGroup.Text = "结果表格";
            // 
            // novelGridView
            // 
            this.novelGridView.AllowUserToAddRows = false;
            this.novelGridView.AllowUserToResizeRows = false;
            this.novelGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.novelGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.novelGridView.Location = new System.Drawing.Point(3, 17);
            this.novelGridView.MultiSelect = false;
            this.novelGridView.Name = "novelGridView";
            this.novelGridView.ReadOnly = true;
            this.novelGridView.RowHeadersVisible = false;
            this.novelGridView.RowTemplate.Height = 23;
            this.novelGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.novelGridView.Size = new System.Drawing.Size(457, 439);
            this.novelGridView.TabIndex = 0;
            this.novelGridView.SelectionChanged += new System.EventHandler(this.novelGridView_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(463, 188);
            this.panel1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.novelPageLabel);
            this.groupBox4.Controls.Add(this.novelCountLabel);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.gotoPageBtn);
            this.groupBox4.Controls.Add(this.pageTxt);
            this.groupBox4.Controls.Add(this.lastPageNlik);
            this.groupBox4.Controls.Add(this.downPageNlik);
            this.groupBox4.Controls.Add(this.upPageNlik);
            this.groupBox4.Controls.Add(this.firstNPagelik);
            this.groupBox4.Location = new System.Drawing.Point(3, 109);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(457, 70);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "页操作";
            // 
            // novelPageLabel
            // 
            this.novelPageLabel.AutoSize = true;
            this.novelPageLabel.ForeColor = System.Drawing.Color.Red;
            this.novelPageLabel.Location = new System.Drawing.Point(126, 17);
            this.novelPageLabel.Name = "novelPageLabel";
            this.novelPageLabel.Size = new System.Drawing.Size(23, 12);
            this.novelPageLabel.TabIndex = 21;
            this.novelPageLabel.Text = "0/0";
            // 
            // novelCountLabel
            // 
            this.novelCountLabel.AutoSize = true;
            this.novelCountLabel.ForeColor = System.Drawing.Color.Red;
            this.novelCountLabel.Location = new System.Drawing.Point(339, 17);
            this.novelCountLabel.Name = "novelCountLabel";
            this.novelCountLabel.Size = new System.Drawing.Size(23, 12);
            this.novelCountLabel.TabIndex = 20;
            this.novelCountLabel.Text = "0/0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(119, 12);
            this.label15.TabIndex = 19;
            this.label15.Text = "页数（当前/所有）：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "小说数（当前/所有）：";
            // 
            // gotoPageBtn
            // 
            this.gotoPageBtn.Location = new System.Drawing.Point(212, 37);
            this.gotoPageBtn.Name = "gotoPageBtn";
            this.gotoPageBtn.Size = new System.Drawing.Size(46, 23);
            this.gotoPageBtn.TabIndex = 6;
            this.gotoPageBtn.Text = "跳至";
            this.gotoPageBtn.UseVisualStyleBackColor = true;
            this.gotoPageBtn.Click += new System.EventHandler(this.gotoPageBtn_Click);
            // 
            // pageTxt
            // 
            this.pageTxt.Location = new System.Drawing.Point(146, 39);
            this.pageTxt.Name = "pageTxt";
            this.pageTxt.Size = new System.Drawing.Size(60, 21);
            this.pageTxt.TabIndex = 5;
            // 
            // lastPageNlik
            // 
            this.lastPageNlik.AutoSize = true;
            this.lastPageNlik.Location = new System.Drawing.Point(111, 42);
            this.lastPageNlik.Name = "lastPageNlik";
            this.lastPageNlik.Size = new System.Drawing.Size(29, 12);
            this.lastPageNlik.TabIndex = 3;
            this.lastPageNlik.TabStop = true;
            this.lastPageNlik.Text = "尾页";
            this.lastPageNlik.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lastPageNlik_LinkClicked);
            // 
            // downPageNlik
            // 
            this.downPageNlik.AutoSize = true;
            this.downPageNlik.Location = new System.Drawing.Point(76, 42);
            this.downPageNlik.Name = "downPageNlik";
            this.downPageNlik.Size = new System.Drawing.Size(29, 12);
            this.downPageNlik.TabIndex = 2;
            this.downPageNlik.TabStop = true;
            this.downPageNlik.Text = "下页";
            this.downPageNlik.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.downPageNlik_LinkClicked);
            // 
            // upPageNlik
            // 
            this.upPageNlik.AutoSize = true;
            this.upPageNlik.Location = new System.Drawing.Point(41, 42);
            this.upPageNlik.Name = "upPageNlik";
            this.upPageNlik.Size = new System.Drawing.Size(29, 12);
            this.upPageNlik.TabIndex = 1;
            this.upPageNlik.TabStop = true;
            this.upPageNlik.Text = "上页";
            this.upPageNlik.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.upPageNlik_LinkClicked);
            // 
            // firstNPagelik
            // 
            this.firstNPagelik.AutoSize = true;
            this.firstNPagelik.Location = new System.Drawing.Point(6, 42);
            this.firstNPagelik.Name = "firstNPagelik";
            this.firstNPagelik.Size = new System.Drawing.Size(29, 12);
            this.firstNPagelik.TabIndex = 0;
            this.firstNPagelik.TabStop = true;
            this.firstNPagelik.Text = "首页";
            this.firstNPagelik.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.firstNPagelik_LinkClicked);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.searchNidBtn);
            this.groupBox3.Controls.Add(this.searchNidTxt);
            this.groupBox3.Location = new System.Drawing.Point(20, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(373, 46);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "搜索";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nid";
            // 
            // searchNidBtn
            // 
            this.searchNidBtn.Location = new System.Drawing.Point(292, 12);
            this.searchNidBtn.Name = "searchNidBtn";
            this.searchNidBtn.Size = new System.Drawing.Size(46, 23);
            this.searchNidBtn.TabIndex = 1;
            this.searchNidBtn.Text = "搜索";
            this.searchNidBtn.UseVisualStyleBackColor = true;
            this.searchNidBtn.Click += new System.EventHandler(this.searchNidBtn_Click);
            // 
            // searchNidTxt
            // 
            this.searchNidTxt.Location = new System.Drawing.Point(40, 14);
            this.searchNidTxt.Name = "searchNidTxt";
            this.searchNidTxt.Size = new System.Drawing.Size(237, 21);
            this.searchNidTxt.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.orderStrTxt);
            this.groupBox2.Controls.Add(this.userDefineRadio);
            this.groupBox2.Controls.Add(this.blankCountRadio);
            this.groupBox2.Controls.Add(this.seqRadio);
            this.groupBox2.Location = new System.Drawing.Point(3, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(457, 48);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "排序方式";
            // 
            // orderStrTxt
            // 
            this.orderStrTxt.Location = new System.Drawing.Point(272, 19);
            this.orderStrTxt.Name = "orderStrTxt";
            this.orderStrTxt.Size = new System.Drawing.Size(179, 21);
            this.orderStrTxt.TabIndex = 6;
            // 
            // userDefineRadio
            // 
            this.userDefineRadio.AutoSize = true;
            this.userDefineRadio.Location = new System.Drawing.Point(217, 20);
            this.userDefineRadio.Name = "userDefineRadio";
            this.userDefineRadio.Size = new System.Drawing.Size(59, 16);
            this.userDefineRadio.TabIndex = 5;
            this.userDefineRadio.TabStop = true;
            this.userDefineRadio.Text = "自定义";
            this.userDefineRadio.UseVisualStyleBackColor = true;
            // 
            // blankCountRadio
            // 
            this.blankCountRadio.AutoSize = true;
            this.blankCountRadio.Location = new System.Drawing.Point(93, 20);
            this.blankCountRadio.Name = "blankCountRadio";
            this.blankCountRadio.Size = new System.Drawing.Size(119, 16);
            this.blankCountRadio.TabIndex = 4;
            this.blankCountRadio.Text = "按空章节数目排列";
            this.blankCountRadio.UseVisualStyleBackColor = true;
            // 
            // seqRadio
            // 
            this.seqRadio.AutoSize = true;
            this.seqRadio.Checked = true;
            this.seqRadio.Location = new System.Drawing.Point(6, 20);
            this.seqRadio.Name = "seqRadio";
            this.seqRadio.Size = new System.Drawing.Size(83, 16);
            this.seqRadio.TabIndex = 3;
            this.seqRadio.TabStop = true;
            this.seqRadio.Text = "按序号排列";
            this.seqRadio.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.stateTxt);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.typeTxt);
            this.groupBox1.Controls.Add(this.operChapterBtn);
            this.groupBox1.Controls.Add(this.allChapCountTxt);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.blankChapCountTxt);
            this.groupBox1.Controls.Add(this.saveInfoBtn);
            this.groupBox1.Controls.Add(this.reReadBtn);
            this.groupBox1.Controls.Add(this.baseIdTxt);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.descTxt);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.urlTxt);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.nameTxt);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nidTxt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 647);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "小说信息";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 165);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 24;
            this.label13.Text = "空章数：";
            // 
            // stateTxt
            // 
            this.stateTxt.Location = new System.Drawing.Point(281, 202);
            this.stateTxt.Name = "stateTxt";
            this.stateTxt.Size = new System.Drawing.Size(121, 21);
            this.stateTxt.TabIndex = 23;
            this.stateTxt.TextChanged += new System.EventHandler(this.stateTxt_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(259, 226);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(143, 12);
            this.label11.TabIndex = 22;
            this.label11.Text = "(小说状态，0连载 1完成)";
            // 
            // typeTxt
            // 
            this.typeTxt.Location = new System.Drawing.Point(66, 202);
            this.typeTxt.Name = "typeTxt";
            this.typeTxt.Size = new System.Drawing.Size(121, 21);
            this.typeTxt.TabIndex = 21;
            this.typeTxt.TextChanged += new System.EventHandler(this.typeTxt_TextChanged);
            // 
            // operChapterBtn
            // 
            this.operChapterBtn.Location = new System.Drawing.Point(327, 512);
            this.operChapterBtn.Name = "operChapterBtn";
            this.operChapterBtn.Size = new System.Drawing.Size(65, 37);
            this.operChapterBtn.TabIndex = 18;
            this.operChapterBtn.Text = "章节操作";
            this.operChapterBtn.UseVisualStyleBackColor = true;
            this.operChapterBtn.Click += new System.EventHandler(this.operChapterBtn_Click);
            // 
            // allChapCountTxt
            // 
            this.allChapCountTxt.Location = new System.Drawing.Point(281, 162);
            this.allChapCountTxt.Name = "allChapCountTxt";
            this.allChapCountTxt.ReadOnly = true;
            this.allChapCountTxt.Size = new System.Drawing.Size(121, 21);
            this.allChapCountTxt.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(222, 165);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 16;
            this.label12.Text = "共章数：";
            // 
            // blankChapCountTxt
            // 
            this.blankChapCountTxt.Location = new System.Drawing.Point(66, 162);
            this.blankChapCountTxt.Name = "blankChapCountTxt";
            this.blankChapCountTxt.ReadOnly = true;
            this.blankChapCountTxt.Size = new System.Drawing.Size(121, 21);
            this.blankChapCountTxt.TabIndex = 15;
            // 
            // saveInfoBtn
            // 
            this.saveInfoBtn.Enabled = false;
            this.saveInfoBtn.Location = new System.Drawing.Point(200, 512);
            this.saveInfoBtn.Name = "saveInfoBtn";
            this.saveInfoBtn.Size = new System.Drawing.Size(75, 37);
            this.saveInfoBtn.TabIndex = 13;
            this.saveInfoBtn.Text = "保存修改";
            this.saveInfoBtn.UseVisualStyleBackColor = true;
            this.saveInfoBtn.Click += new System.EventHandler(this.saveInfoBtn_Click);
            // 
            // reReadBtn
            // 
            this.reReadBtn.Location = new System.Drawing.Point(78, 512);
            this.reReadBtn.Name = "reReadBtn";
            this.reReadBtn.Size = new System.Drawing.Size(75, 37);
            this.reReadBtn.TabIndex = 12;
            this.reReadBtn.Text = "重读信息";
            this.reReadBtn.UseVisualStyleBackColor = true;
            this.reReadBtn.Click += new System.EventHandler(this.reReadBtn_Click);
            // 
            // baseIdTxt
            // 
            this.baseIdTxt.Location = new System.Drawing.Point(66, 61);
            this.baseIdTxt.Name = "baseIdTxt";
            this.baseIdTxt.ReadOnly = true;
            this.baseIdTxt.Size = new System.Drawing.Size(336, 21);
            this.baseIdTxt.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 3;
            this.label9.Text = "baseId：";
            // 
            // descTxt
            // 
            this.descTxt.Location = new System.Drawing.Point(66, 250);
            this.descTxt.Multiline = true;
            this.descTxt.Name = "descTxt";
            this.descTxt.Size = new System.Drawing.Size(336, 246);
            this.descTxt.TabIndex = 11;
            this.descTxt.TextChanged += new System.EventHandler(this.descTxt_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 253);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "简介：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(234, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "状态：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "分类：";
            // 
            // urlTxt
            // 
            this.urlTxt.Location = new System.Drawing.Point(66, 130);
            this.urlTxt.Name = "urlTxt";
            this.urlTxt.ReadOnly = true;
            this.urlTxt.Size = new System.Drawing.Size(336, 21);
            this.urlTxt.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "来源：";
            // 
            // nameTxt
            // 
            this.nameTxt.Location = new System.Drawing.Point(66, 29);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.ReadOnly = true;
            this.nameTxt.Size = new System.Drawing.Size(336, 21);
            this.nameTxt.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "名称：";
            // 
            // nidTxt
            // 
            this.nidTxt.Location = new System.Drawing.Point(66, 97);
            this.nidTxt.Name = "nidTxt";
            this.nidTxt.ReadOnly = true;
            this.nidTxt.Size = new System.Drawing.Size(336, 21);
            this.nidTxt.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nid：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 182);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 14;
            this.label10.Text = "空章数：";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(922, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem,
            this.linkToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.文件ToolStripMenuItem.Text = "连接";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.configToolStripMenuItem.Text = "配置";
            this.configToolStripMenuItem.Click += new System.EventHandler(this.configToolStripMenuItem_Click);
            // 
            // linkToolStripMenuItem
            // 
            this.linkToolStripMenuItem.Name = "linkToolStripMenuItem";
            this.linkToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.linkToolStripMenuItem.Text = "连接/刷新";
            this.linkToolStripMenuItem.Click += new System.EventHandler(this.linkToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutBtn});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // aboutBtn
            // 
            this.aboutBtn.Name = "aboutBtn";
            this.aboutBtn.Size = new System.Drawing.Size(152, 22);
            this.aboutBtn.Text = "关于本软件";
            this.aboutBtn.Click += new System.EventHandler(this.aboutBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 693);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "小说空章节补充小工具  -  易查";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.resultGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.novelGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel upPageNlik;
        private System.Windows.Forms.LinkLabel firstNPagelik;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Button gotoPageBtn;
        private System.Windows.Forms.TextBox pageTxt;
        private System.Windows.Forms.LinkLabel lastPageNlik;
        private System.Windows.Forms.LinkLabel downPageNlik;
        private System.Windows.Forms.DataGridView novelGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button searchNidBtn;
        private System.Windows.Forms.TextBox searchNidTxt;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox urlTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nidTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton blankCountRadio;
        private System.Windows.Forms.RadioButton seqRadio;
        private System.Windows.Forms.Button operChapterBtn;
        private System.Windows.Forms.TextBox allChapCountTxt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox blankChapCountTxt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button saveInfoBtn;
        private System.Windows.Forms.Button reReadBtn;
        private System.Windows.Forms.TextBox baseIdTxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox descTxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox typeTxt;
        private System.Windows.Forms.TextBox stateTxt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label novelPageLabel;
        private System.Windows.Forms.Label novelCountLabel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox resultGroup;
        private System.Windows.Forms.TextBox orderStrTxt;
        private System.Windows.Forms.RadioButton userDefineRadio;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutBtn;

    }
}

