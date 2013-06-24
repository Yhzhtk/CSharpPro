namespace NovelManager
{
    partial class ChapterForm
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
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.searchCidBtn = new System.Windows.Forms.Button();
            this.searchCidTxt = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.blankReqRadio = new System.Windows.Forms.RadioButton();
            this.seqRadio = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.baseIdTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nidTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.resultGroup = new System.Windows.Forms.GroupBox();
            this.chapterGridView = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.delChapterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addChapterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cContentTxt = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.emptyTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cidTxt = new System.Windows.Forms.TextBox();
            this.cNameTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.submitSqlBtn = new System.Windows.Forms.Button();
            this.saveInfoBtn = new System.Windows.Forms.Button();
            this.reReadBtn = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.resultGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chapterGridView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 600);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1044, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(29, 17);
            this.statusLabel.Text = "就绪";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cid：";
            // 
            // searchCidBtn
            // 
            this.searchCidBtn.Location = new System.Drawing.Point(266, 14);
            this.searchCidBtn.Name = "searchCidBtn";
            this.searchCidBtn.Size = new System.Drawing.Size(46, 23);
            this.searchCidBtn.TabIndex = 1;
            this.searchCidBtn.Text = "搜索";
            this.searchCidBtn.UseVisualStyleBackColor = true;
            this.searchCidBtn.Click += new System.EventHandler(this.searchCidBtn_Click);
            // 
            // searchCidTxt
            // 
            this.searchCidTxt.Location = new System.Drawing.Point(47, 14);
            this.searchCidTxt.Name = "searchCidTxt";
            this.searchCidTxt.Size = new System.Drawing.Size(190, 21);
            this.searchCidTxt.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.groupBox4);
            this.panel6.Controls.Add(this.groupBox2);
            this.panel6.Controls.Add(this.groupBox5);
            this.panel6.Controls.Add(this.groupBox3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1044, 145);
            this.panel6.TabIndex = 2;
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
            this.groupBox4.Location = new System.Drawing.Point(6, 49);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(387, 88);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "页操作";
            // 
            // novelPageLabel
            // 
            this.novelPageLabel.AutoSize = true;
            this.novelPageLabel.ForeColor = System.Drawing.Color.Red;
            this.novelPageLabel.Location = new System.Drawing.Point(126, 25);
            this.novelPageLabel.Name = "novelPageLabel";
            this.novelPageLabel.Size = new System.Drawing.Size(23, 12);
            this.novelPageLabel.TabIndex = 21;
            this.novelPageLabel.Text = "0/0";
            // 
            // novelCountLabel
            // 
            this.novelCountLabel.AutoSize = true;
            this.novelCountLabel.ForeColor = System.Drawing.Color.Red;
            this.novelCountLabel.Location = new System.Drawing.Point(311, 25);
            this.novelCountLabel.Name = "novelCountLabel";
            this.novelCountLabel.Size = new System.Drawing.Size(23, 12);
            this.novelCountLabel.TabIndex = 20;
            this.novelCountLabel.Text = "0/0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(119, 12);
            this.label15.TabIndex = 19;
            this.label15.Text = "页数（当前/所有）：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(182, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "章节数（当前/所有）：";
            // 
            // gotoPageBtn
            // 
            this.gotoPageBtn.Location = new System.Drawing.Point(212, 57);
            this.gotoPageBtn.Name = "gotoPageBtn";
            this.gotoPageBtn.Size = new System.Drawing.Size(46, 23);
            this.gotoPageBtn.TabIndex = 6;
            this.gotoPageBtn.Text = "跳至";
            this.gotoPageBtn.UseVisualStyleBackColor = true;
            this.gotoPageBtn.Click += new System.EventHandler(this.gotoPageBtn_Click);
            // 
            // pageTxt
            // 
            this.pageTxt.Location = new System.Drawing.Point(146, 59);
            this.pageTxt.Name = "pageTxt";
            this.pageTxt.Size = new System.Drawing.Size(60, 21);
            this.pageTxt.TabIndex = 5;
            // 
            // lastPageNlik
            // 
            this.lastPageNlik.AutoSize = true;
            this.lastPageNlik.Location = new System.Drawing.Point(111, 62);
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
            this.downPageNlik.Location = new System.Drawing.Point(76, 62);
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
            this.upPageNlik.Location = new System.Drawing.Point(41, 62);
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
            this.firstNPagelik.Location = new System.Drawing.Point(6, 62);
            this.firstNPagelik.Name = "firstNPagelik";
            this.firstNPagelik.Size = new System.Drawing.Size(29, 12);
            this.firstNPagelik.TabIndex = 0;
            this.firstNPagelik.TabStop = true;
            this.firstNPagelik.Text = "首页";
            this.firstNPagelik.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.firstNPagelik_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.blankReqRadio);
            this.groupBox2.Controls.Add(this.seqRadio);
            this.groupBox2.Location = new System.Drawing.Point(399, 92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 45);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "排序方式";
            // 
            // blankReqRadio
            // 
            this.blankReqRadio.AutoSize = true;
            this.blankReqRadio.Location = new System.Drawing.Point(138, 20);
            this.blankReqRadio.Name = "blankReqRadio";
            this.blankReqRadio.Size = new System.Drawing.Size(107, 16);
            this.blankReqRadio.TabIndex = 4;
            this.blankReqRadio.Text = "按是否空章排序";
            this.blankReqRadio.UseVisualStyleBackColor = true;
            // 
            // seqRadio
            // 
            this.seqRadio.AutoSize = true;
            this.seqRadio.Checked = true;
            this.seqRadio.Location = new System.Drawing.Point(27, 20);
            this.seqRadio.Name = "seqRadio";
            this.seqRadio.Size = new System.Drawing.Size(83, 16);
            this.seqRadio.TabIndex = 3;
            this.seqRadio.TabStop = true;
            this.seqRadio.Text = "按序号排列";
            this.seqRadio.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.baseIdTxt);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.nidTxt);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.nameTxt);
            this.groupBox5.Location = new System.Drawing.Point(6, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(996, 41);
            this.groupBox5.TabIndex = 17;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "小说信息";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "baseId：";
            // 
            // baseIdTxt
            // 
            this.baseIdTxt.Location = new System.Drawing.Point(66, 14);
            this.baseIdTxt.Name = "baseIdTxt";
            this.baseIdTxt.ReadOnly = true;
            this.baseIdTxt.Size = new System.Drawing.Size(158, 21);
            this.baseIdTxt.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(657, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nid：";
            // 
            // nidTxt
            // 
            this.nidTxt.Location = new System.Drawing.Point(698, 14);
            this.nidTxt.Name = "nidTxt";
            this.nidTxt.ReadOnly = true;
            this.nidTxt.Size = new System.Drawing.Size(286, 21);
            this.nidTxt.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "当前小说名：";
            // 
            // nameTxt
            // 
            this.nameTxt.Location = new System.Drawing.Point(340, 14);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.ReadOnly = true;
            this.nameTxt.Size = new System.Drawing.Size(300, 21);
            this.nameTxt.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.searchCidBtn);
            this.groupBox3.Controls.Add(this.searchCidTxt);
            this.groupBox3.Location = new System.Drawing.Point(399, 49);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(325, 43);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "搜索";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.splitContainer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 145);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1044, 455);
            this.panel3.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.resultGroup);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox6);
            this.splitContainer1.Panel2.Controls.Add(this.panel8);
            this.splitContainer1.Size = new System.Drawing.Size(1044, 455);
            this.splitContainer1.SplitterDistance = 477;
            this.splitContainer1.TabIndex = 3;
            // 
            // resultGroup
            // 
            this.resultGroup.Controls.Add(this.chapterGridView);
            this.resultGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultGroup.Location = new System.Drawing.Point(0, 0);
            this.resultGroup.Name = "resultGroup";
            this.resultGroup.Size = new System.Drawing.Size(477, 455);
            this.resultGroup.TabIndex = 5;
            this.resultGroup.TabStop = false;
            this.resultGroup.Text = "所有章节信息";
            // 
            // chapterGridView
            // 
            this.chapterGridView.AllowUserToAddRows = false;
            this.chapterGridView.AllowUserToResizeRows = false;
            this.chapterGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.chapterGridView.ContextMenuStrip = this.contextMenuStrip1;
            this.chapterGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chapterGridView.Location = new System.Drawing.Point(3, 17);
            this.chapterGridView.MultiSelect = false;
            this.chapterGridView.Name = "chapterGridView";
            this.chapterGridView.ReadOnly = true;
            this.chapterGridView.RowHeadersVisible = false;
            this.chapterGridView.RowTemplate.Height = 23;
            this.chapterGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.chapterGridView.Size = new System.Drawing.Size(471, 435);
            this.chapterGridView.TabIndex = 4;
            this.chapterGridView.SelectionChanged += new System.EventHandler(this.chapterGridView_SelectionChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.delChapterToolStripMenuItem,
            this.addChapterToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            // 
            // delChapterToolStripMenuItem
            // 
            this.delChapterToolStripMenuItem.Name = "delChapterToolStripMenuItem";
            this.delChapterToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.delChapterToolStripMenuItem.Text = "删除章节";
            this.delChapterToolStripMenuItem.Click += new System.EventHandler(this.delChapterToolStripMenuItem_Click);
            // 
            // addChapterToolStripMenuItem
            // 
            this.addChapterToolStripMenuItem.Name = "addChapterToolStripMenuItem";
            this.addChapterToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addChapterToolStripMenuItem.Text = "添加章节";
            this.addChapterToolStripMenuItem.Click += new System.EventHandler(this.addChapterToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cContentTxt);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(563, 322);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "章节内容";
            // 
            // cContentTxt
            // 
            this.cContentTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cContentTxt.Location = new System.Drawing.Point(3, 17);
            this.cContentTxt.Multiline = true;
            this.cContentTxt.Name = "cContentTxt";
            this.cContentTxt.Size = new System.Drawing.Size(557, 302);
            this.cContentTxt.TabIndex = 2;
            this.cContentTxt.TextChanged += new System.EventHandler(this.cContentTxt_TextChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.emptyTxt);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.cidTxt);
            this.groupBox6.Controls.Add(this.cNameTxt);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(563, 80);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "章节信息";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(465, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "（1为空，0为非空）";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(356, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "是否空：";
            // 
            // emptyTxt
            // 
            this.emptyTxt.Location = new System.Drawing.Point(415, 20);
            this.emptyTxt.Name = "emptyTxt";
            this.emptyTxt.ReadOnly = true;
            this.emptyTxt.Size = new System.Drawing.Size(44, 21);
            this.emptyTxt.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "章节名：";
            // 
            // cidTxt
            // 
            this.cidTxt.Location = new System.Drawing.Point(68, 23);
            this.cidTxt.Name = "cidTxt";
            this.cidTxt.ReadOnly = true;
            this.cidTxt.Size = new System.Drawing.Size(277, 21);
            this.cidTxt.TabIndex = 2;
            // 
            // cNameTxt
            // 
            this.cNameTxt.Location = new System.Drawing.Point(69, 50);
            this.cNameTxt.Name = "cNameTxt";
            this.cNameTxt.Size = new System.Drawing.Size(340, 21);
            this.cNameTxt.TabIndex = 4;
            this.cNameTxt.TextChanged += new System.EventHandler(this.cnameTxt_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "Cid：";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.submitSqlBtn);
            this.panel8.Controls.Add(this.saveInfoBtn);
            this.panel8.Controls.Add(this.reReadBtn);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 402);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(563, 53);
            this.panel8.TabIndex = 7;
            // 
            // submitSqlBtn
            // 
            this.submitSqlBtn.Enabled = false;
            this.submitSqlBtn.Location = new System.Drawing.Point(373, 6);
            this.submitSqlBtn.Name = "submitSqlBtn";
            this.submitSqlBtn.Size = new System.Drawing.Size(75, 37);
            this.submitSqlBtn.TabIndex = 16;
            this.submitSqlBtn.Text = "写入数据库";
            this.submitSqlBtn.UseVisualStyleBackColor = true;
            this.submitSqlBtn.Click += new System.EventHandler(this.submitSqlBtn_Click);
            // 
            // saveInfoBtn
            // 
            this.saveInfoBtn.Enabled = false;
            this.saveInfoBtn.Location = new System.Drawing.Point(236, 6);
            this.saveInfoBtn.Name = "saveInfoBtn";
            this.saveInfoBtn.Size = new System.Drawing.Size(75, 37);
            this.saveInfoBtn.TabIndex = 15;
            this.saveInfoBtn.Text = "保存章节";
            this.saveInfoBtn.UseVisualStyleBackColor = true;
            this.saveInfoBtn.Click += new System.EventHandler(this.saveInfoBtn_Click);
            // 
            // reReadBtn
            // 
            this.reReadBtn.Location = new System.Drawing.Point(97, 6);
            this.reReadBtn.Name = "reReadBtn";
            this.reReadBtn.Size = new System.Drawing.Size(75, 37);
            this.reReadBtn.TabIndex = 14;
            this.reReadBtn.Text = "重读信息";
            this.reReadBtn.UseVisualStyleBackColor = true;
            this.reReadBtn.Click += new System.EventHandler(this.reReadBtn_Click);
            // 
            // ChapterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 622);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.statusStrip1);
            this.Name = "ChapterForm";
            this.Text = "ChapterForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChapterForm_FormClosing);
            this.Load += new System.EventHandler(this.ChapterForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.resultGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chapterGridView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button searchCidBtn;
        private System.Windows.Forms.TextBox searchCidTxt;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nidTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox cNameTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox cidTxt;
        private System.Windows.Forms.Button saveInfoBtn;
        private System.Windows.Forms.Button reReadBtn;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox cContentTxt;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView chapterGridView;
        private System.Windows.Forms.GroupBox resultGroup;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox emptyTxt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton blankReqRadio;
        private System.Windows.Forms.RadioButton seqRadio;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem delChapterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addChapterToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label novelPageLabel;
        private System.Windows.Forms.Label novelCountLabel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button gotoPageBtn;
        private System.Windows.Forms.TextBox pageTxt;
        private System.Windows.Forms.LinkLabel lastPageNlik;
        private System.Windows.Forms.LinkLabel downPageNlik;
        private System.Windows.Forms.LinkLabel upPageNlik;
        private System.Windows.Forms.LinkLabel firstNPagelik;
        private System.Windows.Forms.Button submitSqlBtn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox baseIdTxt;
    }
}