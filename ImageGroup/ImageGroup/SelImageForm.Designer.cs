namespace ImageGroup
{
    partial class SelImageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelImageForm));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.delImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.seqNameBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.refreshNowBtn = new System.Windows.Forms.Button();
            this.openNowPathBtn = new System.Windows.Forms.Button();
            this.nowPathTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.setSizeBtn = new System.Windows.Forms.Button();
            this.heightTxt = new System.Windows.Forms.TextBox();
            this.widthTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.formatComb = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listView2 = new System.Windows.Forms.ListView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.refreshNow2Btn = new System.Windows.Forms.Button();
            this.openNowPath2Btn = new System.Windows.Forms.Button();
            this.nowPath2Txt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.gourpIdTxt = new System.Windows.Forms.TextBox();
            this.setSize2Txt = new System.Windows.Forms.Button();
            this.height2Txt = new System.Windows.Forms.TextBox();
            this.width2Txt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.seqSave2Btn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel8 = new System.Windows.Forms.Panel();
            this.groupTree = new System.Windows.Forms.TreeView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.rootPathTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.selectPathBtn = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.selectPathDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.delImageToolStripMenuItem,
            this.openToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(95, 48);
            // 
            // delImageToolStripMenuItem
            // 
            this.delImageToolStripMenuItem.Name = "delImageToolStripMenuItem";
            this.delImageToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.delImageToolStripMenuItem.Text = "删除";
            this.delImageToolStripMenuItem.Click += new System.EventHandler(this.delImageToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "打开";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "1.jpg");
            this.imageList.Images.SetKeyName(1, "2.jpg");
            this.imageList.Images.SetKeyName(2, "3.jpg");
            this.imageList.Images.SetKeyName(3, "4.jpg");
            this.imageList.Images.SetKeyName(4, "5.jpg");
            this.imageList.Images.SetKeyName(5, "6.jpg");
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 2);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(958, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(29, 17);
            this.statusLabel.Text = "就绪";
            // 
            // seqNameBtn
            // 
            this.seqNameBtn.Enabled = false;
            this.seqNameBtn.Location = new System.Drawing.Point(662, 18);
            this.seqNameBtn.Name = "seqNameBtn";
            this.seqNameBtn.Size = new System.Drawing.Size(86, 26);
            this.seqNameBtn.TabIndex = 2;
            this.seqNameBtn.Text = "序列保存";
            this.seqNameBtn.UseVisualStyleBackColor = true;
            this.seqNameBtn.Click += new System.EventHandler(this.seqNameBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(470, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "图片格式:";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(753, 524);
            this.tabControl.TabIndex = 6;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(745, 499);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "选图";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.LargeImageList = this.imageList;
            this.listView1.Location = new System.Drawing.Point(3, 40);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(739, 396);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView_ItemDrag);
            this.listView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_DragDrop);
            this.listView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_DragEnter);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.refreshNowBtn);
            this.panel1.Controls.Add(this.openNowPathBtn);
            this.panel1.Controls.Add(this.nowPathTxt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(739, 37);
            this.panel1.TabIndex = 9;
            // 
            // refreshNowBtn
            // 
            this.refreshNowBtn.Location = new System.Drawing.Point(600, 3);
            this.refreshNowBtn.Name = "refreshNowBtn";
            this.refreshNowBtn.Size = new System.Drawing.Size(66, 23);
            this.refreshNowBtn.TabIndex = 4;
            this.refreshNowBtn.Text = "刷新";
            this.refreshNowBtn.UseVisualStyleBackColor = true;
            this.refreshNowBtn.Click += new System.EventHandler(this.refreshNowBtn_Click);
            // 
            // openNowPathBtn
            // 
            this.openNowPathBtn.Location = new System.Drawing.Point(518, 3);
            this.openNowPathBtn.Name = "openNowPathBtn";
            this.openNowPathBtn.Size = new System.Drawing.Size(61, 23);
            this.openNowPathBtn.TabIndex = 3;
            this.openNowPathBtn.Text = "打开";
            this.openNowPathBtn.UseVisualStyleBackColor = true;
            this.openNowPathBtn.Click += new System.EventHandler(this.openNowPathBtn_Click);
            // 
            // nowPathTxt
            // 
            this.nowPathTxt.Location = new System.Drawing.Point(80, 4);
            this.nowPathTxt.Name = "nowPathTxt";
            this.nowPathTxt.ReadOnly = true;
            this.nowPathTxt.Size = new System.Drawing.Size(432, 21);
            this.nowPathTxt.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "组图路径：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.setSizeBtn);
            this.panel2.Controls.Add(this.heightTxt);
            this.panel2.Controls.Add(this.widthTxt);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.formatComb);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.seqNameBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 436);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(739, 60);
            this.panel2.TabIndex = 7;
            // 
            // setSizeBtn
            // 
            this.setSizeBtn.Location = new System.Drawing.Point(272, 21);
            this.setSizeBtn.Name = "setSizeBtn";
            this.setSizeBtn.Size = new System.Drawing.Size(75, 23);
            this.setSizeBtn.TabIndex = 9;
            this.setSizeBtn.Text = "设置";
            this.setSizeBtn.UseVisualStyleBackColor = true;
            this.setSizeBtn.Click += new System.EventHandler(this.setSizeBtn_Click);
            // 
            // heightTxt
            // 
            this.heightTxt.Location = new System.Drawing.Point(203, 22);
            this.heightTxt.Name = "heightTxt";
            this.heightTxt.Size = new System.Drawing.Size(51, 21);
            this.heightTxt.TabIndex = 8;
            this.heightTxt.Text = "200";
            // 
            // widthTxt
            // 
            this.widthTxt.Location = new System.Drawing.Point(108, 22);
            this.widthTxt.Name = "widthTxt";
            this.widthTxt.Size = new System.Drawing.Size(52, 21);
            this.widthTxt.TabIndex = 7;
            this.widthTxt.Text = "200";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "预览大小：             X";
            // 
            // formatComb
            // 
            this.formatComb.FormattingEnabled = true;
            this.formatComb.Items.AddRange(new object[] {
            ".jpg",
            ".gif",
            ".jpeg",
            ".png"});
            this.formatComb.Location = new System.Drawing.Point(535, 22);
            this.formatComb.Name = "formatComb";
            this.formatComb.Size = new System.Drawing.Size(121, 20);
            this.formatComb.TabIndex = 5;
            this.formatComb.Text = ".jpg";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listView2);
            this.tabPage2.Controls.Add(this.panel6);
            this.tabPage2.Controls.Add(this.panel7);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(745, 499);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "组图编号";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.AllowDrop = true;
            this.listView2.ContextMenuStrip = this.contextMenuStrip1;
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.LargeImageList = this.imageList;
            this.listView2.Location = new System.Drawing.Point(3, 40);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(739, 396);
            this.listView2.TabIndex = 12;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView_ItemDrag);
            this.listView2.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_DragDrop);
            this.listView2.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_DragEnter);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.refreshNow2Btn);
            this.panel6.Controls.Add(this.openNowPath2Btn);
            this.panel6.Controls.Add(this.nowPath2Txt);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(739, 37);
            this.panel6.TabIndex = 11;
            // 
            // refreshNow2Btn
            // 
            this.refreshNow2Btn.Location = new System.Drawing.Point(592, 3);
            this.refreshNow2Btn.Name = "refreshNow2Btn";
            this.refreshNow2Btn.Size = new System.Drawing.Size(66, 23);
            this.refreshNow2Btn.TabIndex = 4;
            this.refreshNow2Btn.Text = "刷新";
            this.refreshNow2Btn.UseVisualStyleBackColor = true;
            this.refreshNow2Btn.Click += new System.EventHandler(this.refreshNow2Btn_Click);
            // 
            // openNowPath2Btn
            // 
            this.openNowPath2Btn.Location = new System.Drawing.Point(518, 3);
            this.openNowPath2Btn.Name = "openNowPath2Btn";
            this.openNowPath2Btn.Size = new System.Drawing.Size(61, 23);
            this.openNowPath2Btn.TabIndex = 3;
            this.openNowPath2Btn.Text = "打开";
            this.openNowPath2Btn.UseVisualStyleBackColor = true;
            this.openNowPath2Btn.Click += new System.EventHandler(this.openNowPath2Btn_Click);
            // 
            // nowPath2Txt
            // 
            this.nowPath2Txt.Location = new System.Drawing.Point(80, 4);
            this.nowPath2Txt.Name = "nowPath2Txt";
            this.nowPath2Txt.ReadOnly = true;
            this.nowPath2Txt.Size = new System.Drawing.Size(432, 21);
            this.nowPath2Txt.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "组图路径：";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label7);
            this.panel7.Controls.Add(this.gourpIdTxt);
            this.panel7.Controls.Add(this.setSize2Txt);
            this.panel7.Controls.Add(this.height2Txt);
            this.panel7.Controls.Add(this.width2Txt);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Controls.Add(this.seqSave2Btn);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(3, 436);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(739, 60);
            this.panel7.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(422, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "初始编号：";
            // 
            // gourpIdTxt
            // 
            this.gourpIdTxt.Location = new System.Drawing.Point(493, 21);
            this.gourpIdTxt.Name = "gourpIdTxt";
            this.gourpIdTxt.Size = new System.Drawing.Size(85, 21);
            this.gourpIdTxt.TabIndex = 10;
            this.gourpIdTxt.TextChanged += new System.EventHandler(this.gourpIdTxt_TextChanged);
            // 
            // setSize2Txt
            // 
            this.setSize2Txt.Location = new System.Drawing.Point(272, 21);
            this.setSize2Txt.Name = "setSize2Txt";
            this.setSize2Txt.Size = new System.Drawing.Size(75, 23);
            this.setSize2Txt.TabIndex = 9;
            this.setSize2Txt.Text = "设置";
            this.setSize2Txt.UseVisualStyleBackColor = true;
            this.setSize2Txt.Click += new System.EventHandler(this.setSize2Txt_Click);
            // 
            // height2Txt
            // 
            this.height2Txt.Location = new System.Drawing.Point(203, 22);
            this.height2Txt.Name = "height2Txt";
            this.height2Txt.Size = new System.Drawing.Size(51, 21);
            this.height2Txt.TabIndex = 8;
            this.height2Txt.Text = "200";
            // 
            // width2Txt
            // 
            this.width2Txt.Location = new System.Drawing.Point(108, 22);
            this.width2Txt.Name = "width2Txt";
            this.width2Txt.Size = new System.Drawing.Size(52, 21);
            this.width2Txt.TabIndex = 7;
            this.width2Txt.Text = "200";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "预览大小：             X";
            // 
            // seqSave2Btn
            // 
            this.seqSave2Btn.Enabled = false;
            this.seqSave2Btn.Location = new System.Drawing.Point(584, 18);
            this.seqSave2Btn.Name = "seqSave2Btn";
            this.seqSave2Btn.Size = new System.Drawing.Size(86, 26);
            this.seqSave2Btn.TabIndex = 2;
            this.seqSave2Btn.Text = "序列保存";
            this.seqSave2Btn.UseVisualStyleBackColor = true;
            this.seqSave2Btn.Click += new System.EventHandler(this.seqSave2Btn_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.statusStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 524);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(958, 24);
            this.panel3.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.splitContainer1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(958, 524);
            this.panel4.TabIndex = 8;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.panel8);
            this.splitContainer1.Panel1.Controls.Add(this.panel9);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.panel5);
            this.splitContainer1.Size = new System.Drawing.Size(958, 524);
            this.splitContainer1.SplitterDistance = 201;
            this.splitContainer1.TabIndex = 10;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.groupTree);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 94);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(201, 430);
            this.panel8.TabIndex = 3;
            // 
            // groupTree
            // 
            this.groupTree.ContextMenuStrip = this.contextMenuStrip2;
            this.groupTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupTree.Location = new System.Drawing.Point(0, 0);
            this.groupTree.Name = "groupTree";
            this.groupTree.Size = new System.Drawing.Size(201, 430);
            this.groupTree.TabIndex = 1;
            this.groupTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.groupTree_AfterSelect);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(95, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "删除";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Controls.Add(this.label4);
            this.panel9.Controls.Add(this.refreshBtn);
            this.panel9.Controls.Add(this.selectPathBtn);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(201, 94);
            this.panel9.TabIndex = 2;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.rootPathTxt);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Location = new System.Drawing.Point(0, 67);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(201, 27);
            this.panel10.TabIndex = 6;
            // 
            // rootPathTxt
            // 
            this.rootPathTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rootPathTxt.Location = new System.Drawing.Point(0, 0);
            this.rootPathTxt.Name = "rootPathTxt";
            this.rootPathTxt.ReadOnly = true;
            this.rootPathTxt.Size = new System.Drawing.Size(201, 21);
            this.rootPathTxt.TabIndex = 4;
            this.rootPathTxt.Text = "D:\\WorkDataLocal\\Image\\File\\Group\\20120411";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "当前路径：";
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(105, 12);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(75, 23);
            this.refreshBtn.TabIndex = 3;
            this.refreshBtn.Text = "刷新";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // selectPathBtn
            // 
            this.selectPathBtn.Location = new System.Drawing.Point(22, 12);
            this.selectPathBtn.Name = "selectPathBtn";
            this.selectPathBtn.Size = new System.Drawing.Size(68, 23);
            this.selectPathBtn.TabIndex = 2;
            this.selectPathBtn.Text = "导入";
            this.selectPathBtn.UseVisualStyleBackColor = true;
            this.selectPathBtn.Click += new System.EventHandler(this.selectPathBtn_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tabControl);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(753, 524);
            this.panel5.TabIndex = 5;
            // 
            // SelImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 548);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Name = "SelImageForm";
            this.Text = "选图小工具";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Button seqNameBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox formatComb;
        private System.Windows.Forms.FolderBrowserDialog selectPathDlg;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem delImageToolStripMenuItem;
        private System.Windows.Forms.Button setSizeBtn;
        private System.Windows.Forms.TextBox heightTxt;
        private System.Windows.Forms.TextBox widthTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button refreshNowBtn;
        private System.Windows.Forms.Button openNowPathBtn;
        private System.Windows.Forms.TextBox nowPathTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TreeView groupTree;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TextBox rootPathTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Button selectPathBtn;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button refreshNow2Btn;
        private System.Windows.Forms.Button openNowPath2Btn;
        private System.Windows.Forms.TextBox nowPath2Txt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button setSize2Txt;
        private System.Windows.Forms.TextBox height2Txt;
        private System.Windows.Forms.TextBox width2Txt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button seqSave2Btn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox gourpIdTxt;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}