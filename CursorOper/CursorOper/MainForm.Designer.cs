namespace CursorOper
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
            this.label1 = new System.Windows.Forms.Label();
            this.cursorTxt = new System.Windows.Forms.TextBox();
            this.nowCurLab = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前坐标：\r\n(F1记录)";
            // 
            // cursorTxt
            // 
            this.cursorTxt.Dock = System.Windows.Forms.DockStyle.Right;
            this.cursorTxt.Location = new System.Drawing.Point(64, 0);
            this.cursorTxt.Multiline = true;
            this.cursorTxt.Name = "cursorTxt";
            this.cursorTxt.ReadOnly = true;
            this.cursorTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.cursorTxt.Size = new System.Drawing.Size(89, 146);
            this.cursorTxt.TabIndex = 1;
            // 
            // nowCurLab
            // 
            this.nowCurLab.AutoSize = true;
            this.nowCurLab.Location = new System.Drawing.Point(3, 77);
            this.nowCurLab.Name = "nowCurLab";
            this.nowCurLab.Size = new System.Drawing.Size(23, 12);
            this.nowCurLab.TabIndex = 2;
            this.nowCurLab.Text = "0:0";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(153, 146);
            this.Controls.Add(this.nowCurLab);
            this.Controls.Add(this.cursorTxt);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "坐标工具";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cursorTxt;
        private System.Windows.Forms.Label nowCurLab;
        private System.Windows.Forms.Timer timer1;
    }
}

