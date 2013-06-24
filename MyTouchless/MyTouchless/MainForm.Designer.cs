namespace MyTouchless
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
            this.pictureBoxDisplay = new System.Windows.Forms.PictureBox();
            this.groupBoxMarkers = new System.Windows.Forms.GroupBox();
            this.groupBoxMarkerControl = new System.Windows.Forms.GroupBox();
            this.numericUpDownMarkerThresh = new System.Windows.Forms.NumericUpDown();
            this.labelMarkerThresh = new System.Windows.Forms.Label();
            this.checkBoxMarkerSmoothing = new System.Windows.Forms.CheckBox();
            this.checkBoxMarkerHighlight = new System.Windows.Forms.CheckBox();
            this.labelMarkerData = new System.Windows.Forms.RichTextBox();
            this.buttonMarkerRemove = new System.Windows.Forms.Button();
            this.comboBoxMarkers = new System.Windows.Forms.ComboBox();
            this.buttonMarkerAdd = new System.Windows.Forms.Button();
            this.ctrlPanel = new System.Windows.Forms.Panel();
            this.showBtn = new System.Windows.Forms.Button();
            this.hideBtn = new System.Windows.Forms.Button();
            this.palyBtn = new System.Windows.Forms.Button();
            this.picPanel = new System.Windows.Forms.Panel();
            this.imgBox = new System.Windows.Forms.TextBox();
            this.openBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).BeginInit();
            this.groupBoxMarkers.SuspendLayout();
            this.groupBoxMarkerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMarkerThresh)).BeginInit();
            this.ctrlPanel.SuspendLayout();
            this.picPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxDisplay
            // 
            this.pictureBoxDisplay.BackColor = System.Drawing.Color.DimGray;
            this.pictureBoxDisplay.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxDisplay.Name = "pictureBoxDisplay";
            this.pictureBoxDisplay.Size = new System.Drawing.Size(640, 443);
            this.pictureBoxDisplay.TabIndex = 22;
            this.pictureBoxDisplay.TabStop = false;
            this.pictureBoxDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxDisplay_MouseDown);
            this.pictureBoxDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxDisplay_MouseMove);
            this.pictureBoxDisplay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxDisplay_MouseUp);
            // 
            // groupBoxMarkers
            // 
            this.groupBoxMarkers.Controls.Add(this.groupBoxMarkerControl);
            this.groupBoxMarkers.Controls.Add(this.comboBoxMarkers);
            this.groupBoxMarkers.Controls.Add(this.buttonMarkerAdd);
            this.groupBoxMarkers.Location = new System.Drawing.Point(4, 93);
            this.groupBoxMarkers.Name = "groupBoxMarkers";
            this.groupBoxMarkers.Size = new System.Drawing.Size(320, 389);
            this.groupBoxMarkers.TabIndex = 23;
            this.groupBoxMarkers.TabStop = false;
            this.groupBoxMarkers.Text = "Marker Settings";
            // 
            // groupBoxMarkerControl
            // 
            this.groupBoxMarkerControl.Controls.Add(this.numericUpDownMarkerThresh);
            this.groupBoxMarkerControl.Controls.Add(this.labelMarkerThresh);
            this.groupBoxMarkerControl.Controls.Add(this.checkBoxMarkerSmoothing);
            this.groupBoxMarkerControl.Controls.Add(this.checkBoxMarkerHighlight);
            this.groupBoxMarkerControl.Controls.Add(this.labelMarkerData);
            this.groupBoxMarkerControl.Controls.Add(this.buttonMarkerRemove);
            this.groupBoxMarkerControl.Enabled = false;
            this.groupBoxMarkerControl.Location = new System.Drawing.Point(10, 44);
            this.groupBoxMarkerControl.Name = "groupBoxMarkerControl";
            this.groupBoxMarkerControl.Size = new System.Drawing.Size(304, 332);
            this.groupBoxMarkerControl.TabIndex = 25;
            this.groupBoxMarkerControl.TabStop = false;
            this.groupBoxMarkerControl.Text = "No Marker Selected";
            // 
            // numericUpDownMarkerThresh
            // 
            this.numericUpDownMarkerThresh.Location = new System.Drawing.Point(251, 41);
            this.numericUpDownMarkerThresh.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownMarkerThresh.Name = "numericUpDownMarkerThresh";
            this.numericUpDownMarkerThresh.Size = new System.Drawing.Size(47, 21);
            this.numericUpDownMarkerThresh.TabIndex = 5;
            // 
            // labelMarkerThresh
            // 
            this.labelMarkerThresh.AutoSize = true;
            this.labelMarkerThresh.Location = new System.Drawing.Point(144, 45);
            this.labelMarkerThresh.Name = "labelMarkerThresh";
            this.labelMarkerThresh.Size = new System.Drawing.Size(107, 12);
            this.labelMarkerThresh.TabIndex = 4;
            this.labelMarkerThresh.Text = "Marker Threshold:";
            // 
            // checkBoxMarkerSmoothing
            // 
            this.checkBoxMarkerSmoothing.AutoSize = true;
            this.checkBoxMarkerSmoothing.Checked = true;
            this.checkBoxMarkerSmoothing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMarkerSmoothing.Location = new System.Drawing.Point(6, 42);
            this.checkBoxMarkerSmoothing.Name = "checkBoxMarkerSmoothing";
            this.checkBoxMarkerSmoothing.Size = new System.Drawing.Size(132, 16);
            this.checkBoxMarkerSmoothing.TabIndex = 3;
            this.checkBoxMarkerSmoothing.Text = "Smooth Marker Data";
            this.checkBoxMarkerSmoothing.UseVisualStyleBackColor = true;
            this.checkBoxMarkerSmoothing.CheckedChanged += new System.EventHandler(this.checkBoxMarkerSmoothing_CheckedChanged);
            // 
            // checkBoxMarkerHighlight
            // 
            this.checkBoxMarkerHighlight.AutoSize = true;
            this.checkBoxMarkerHighlight.Checked = true;
            this.checkBoxMarkerHighlight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMarkerHighlight.Location = new System.Drawing.Point(5, 18);
            this.checkBoxMarkerHighlight.Name = "checkBoxMarkerHighlight";
            this.checkBoxMarkerHighlight.Size = new System.Drawing.Size(120, 16);
            this.checkBoxMarkerHighlight.TabIndex = 2;
            this.checkBoxMarkerHighlight.Text = "Highlight Marker";
            this.checkBoxMarkerHighlight.UseVisualStyleBackColor = true;
            this.checkBoxMarkerHighlight.CheckedChanged += new System.EventHandler(this.checkBoxMarkerHighlight_CheckedChanged);
            // 
            // labelMarkerData
            // 
            this.labelMarkerData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMarkerData.Location = new System.Drawing.Point(7, 65);
            this.labelMarkerData.Name = "labelMarkerData";
            this.labelMarkerData.ReadOnly = true;
            this.labelMarkerData.Size = new System.Drawing.Size(291, 261);
            this.labelMarkerData.TabIndex = 1;
            this.labelMarkerData.Text = "";
            // 
            // buttonMarkerRemove
            // 
            this.buttonMarkerRemove.Location = new System.Drawing.Point(155, 14);
            this.buttonMarkerRemove.Name = "buttonMarkerRemove";
            this.buttonMarkerRemove.Size = new System.Drawing.Size(143, 21);
            this.buttonMarkerRemove.TabIndex = 0;
            this.buttonMarkerRemove.Text = "Remove This Marker";
            this.buttonMarkerRemove.UseVisualStyleBackColor = true;
            this.buttonMarkerRemove.Click += new System.EventHandler(this.buttonMarkerRemove_Click);
            // 
            // comboBoxMarkers
            // 
            this.comboBoxMarkers.Enabled = false;
            this.comboBoxMarkers.FormattingEnabled = true;
            this.comboBoxMarkers.Location = new System.Drawing.Point(165, 18);
            this.comboBoxMarkers.Name = "comboBoxMarkers";
            this.comboBoxMarkers.Size = new System.Drawing.Size(148, 20);
            this.comboBoxMarkers.TabIndex = 22;
            this.comboBoxMarkers.Text = "Edit An Existing Marker";
            this.comboBoxMarkers.DropDown += new System.EventHandler(this.comboBoxMarkers_DropDown);
            this.comboBoxMarkers.SelectedIndexChanged += new System.EventHandler(this.comboBoxMarkers_SelectedIndexChanged);
            // 
            // buttonMarkerAdd
            // 
            this.buttonMarkerAdd.Location = new System.Drawing.Point(10, 16);
            this.buttonMarkerAdd.Name = "buttonMarkerAdd";
            this.buttonMarkerAdd.Size = new System.Drawing.Size(151, 21);
            this.buttonMarkerAdd.TabIndex = 19;
            this.buttonMarkerAdd.Text = "Add A New Marker";
            this.buttonMarkerAdd.UseVisualStyleBackColor = true;
            this.buttonMarkerAdd.Click += new System.EventHandler(this.buttonMarkerAdd_Click);
            // 
            // ctrlPanel
            // 
            this.ctrlPanel.Controls.Add(this.openBtn);
            this.ctrlPanel.Controls.Add(this.imgBox);
            this.ctrlPanel.Controls.Add(this.showBtn);
            this.ctrlPanel.Controls.Add(this.hideBtn);
            this.ctrlPanel.Controls.Add(this.palyBtn);
            this.ctrlPanel.Controls.Add(this.groupBoxMarkers);
            this.ctrlPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctrlPanel.Location = new System.Drawing.Point(0, 0);
            this.ctrlPanel.Name = "ctrlPanel";
            this.ctrlPanel.Size = new System.Drawing.Size(327, 489);
            this.ctrlPanel.TabIndex = 25;
            // 
            // showBtn
            // 
            this.showBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.showBtn.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.showBtn.Location = new System.Drawing.Point(90, 17);
            this.showBtn.Name = "showBtn";
            this.showBtn.Size = new System.Drawing.Size(85, 31);
            this.showBtn.TabIndex = 2;
            this.showBtn.Text = "普通显示";
            this.showBtn.UseVisualStyleBackColor = true;
            this.showBtn.Click += new System.EventHandler(this.showBtn_Click);
            // 
            // hideBtn
            // 
            this.hideBtn.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.hideBtn.Location = new System.Drawing.Point(4, 18);
            this.hideBtn.Name = "hideBtn";
            this.hideBtn.Size = new System.Drawing.Size(80, 29);
            this.hideBtn.TabIndex = 1;
            this.hideBtn.Text = "最大化隐藏";
            this.hideBtn.UseVisualStyleBackColor = true;
            this.hideBtn.Click += new System.EventHandler(this.hideBtn_Click);
            // 
            // palyBtn
            // 
            this.palyBtn.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.palyBtn.Location = new System.Drawing.Point(222, 14);
            this.palyBtn.Name = "palyBtn";
            this.palyBtn.Size = new System.Drawing.Size(71, 34);
            this.palyBtn.TabIndex = 3;
            this.palyBtn.Text = "开始";
            this.palyBtn.UseVisualStyleBackColor = true;
            this.palyBtn.Click += new System.EventHandler(this.palyBtn_Click);
            // 
            // picPanel
            // 
            this.picPanel.BackColor = System.Drawing.Color.Black;
            this.picPanel.Controls.Add(this.pictureBoxDisplay);
            this.picPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPanel.Location = new System.Drawing.Point(327, 0);
            this.picPanel.Name = "picPanel";
            this.picPanel.Size = new System.Drawing.Size(641, 489);
            this.picPanel.TabIndex = 26;
            // 
            // imgBox
            // 
            this.imgBox.Location = new System.Drawing.Point(4, 64);
            this.imgBox.Name = "imgBox";
            this.imgBox.ReadOnly = true;
            this.imgBox.Size = new System.Drawing.Size(267, 21);
            this.imgBox.TabIndex = 24;
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(277, 64);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(45, 23);
            this.openBtn.TabIndex = 25;
            this.openBtn.Text = "打开";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.hideBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.showBtn;
            this.ClientSize = new System.Drawing.Size(968, 489);
            this.Controls.Add(this.picPanel);
            this.Controls.Add(this.ctrlPanel);
            this.Name = "MainForm";
            this.Text = "年会节目示例";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).EndInit();
            this.groupBoxMarkers.ResumeLayout(false);
            this.groupBoxMarkerControl.ResumeLayout(false);
            this.groupBoxMarkerControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMarkerThresh)).EndInit();
            this.ctrlPanel.ResumeLayout(false);
            this.ctrlPanel.PerformLayout();
            this.picPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxDisplay;
        private System.Windows.Forms.GroupBox groupBoxMarkers;
        private System.Windows.Forms.GroupBox groupBoxMarkerControl;
        private System.Windows.Forms.NumericUpDown numericUpDownMarkerThresh;
        private System.Windows.Forms.Label labelMarkerThresh;
        private System.Windows.Forms.CheckBox checkBoxMarkerSmoothing;
        private System.Windows.Forms.CheckBox checkBoxMarkerHighlight;
        private System.Windows.Forms.RichTextBox labelMarkerData;
        private System.Windows.Forms.Button buttonMarkerRemove;
        private System.Windows.Forms.ComboBox comboBoxMarkers;
        private System.Windows.Forms.Button buttonMarkerAdd;
        private System.Windows.Forms.Panel ctrlPanel;
        private System.Windows.Forms.Panel picPanel;
        private System.Windows.Forms.Button palyBtn;
        private System.Windows.Forms.Button hideBtn;
        private System.Windows.Forms.Button showBtn;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.TextBox imgBox;
    }
}

