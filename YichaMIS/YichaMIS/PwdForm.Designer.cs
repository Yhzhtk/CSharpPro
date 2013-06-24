namespace YichaMIS
{
    partial class PwdForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.usrTxt = new System.Windows.Forms.TextBox();
            this.oPwdTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nPwdTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.n2PwdTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.canelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "店铺名：";
            // 
            // usrTxt
            // 
            this.usrTxt.Location = new System.Drawing.Point(76, 24);
            this.usrTxt.MaxLength = 30;
            this.usrTxt.Name = "usrTxt";
            this.usrTxt.Size = new System.Drawing.Size(159, 21);
            this.usrTxt.TabIndex = 1;
            // 
            // oPwdTxt
            // 
            this.oPwdTxt.Location = new System.Drawing.Point(76, 51);
            this.oPwdTxt.MaxLength = 20;
            this.oPwdTxt.Name = "oPwdTxt";
            this.oPwdTxt.Size = new System.Drawing.Size(159, 21);
            this.oPwdTxt.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "原始密码：";
            // 
            // nPwdTxt
            // 
            this.nPwdTxt.Location = new System.Drawing.Point(76, 87);
            this.nPwdTxt.MaxLength = 20;
            this.nPwdTxt.Name = "nPwdTxt";
            this.nPwdTxt.Size = new System.Drawing.Size(159, 21);
            this.nPwdTxt.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "新密码：";
            // 
            // n2PwdTxt
            // 
            this.n2PwdTxt.Location = new System.Drawing.Point(76, 119);
            this.n2PwdTxt.MaxLength = 20;
            this.n2PwdTxt.Name = "n2PwdTxt";
            this.n2PwdTxt.Size = new System.Drawing.Size(159, 21);
            this.n2PwdTxt.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "再次输入：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.canelBtn);
            this.groupBox1.Controls.Add(this.okBtn);
            this.groupBox1.Controls.Add(this.n2PwdTxt);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nPwdTxt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.oPwdTxt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.usrTxt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 207);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "修改密码";
            // 
            // canelBtn
            // 
            this.canelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.canelBtn.Location = new System.Drawing.Point(33, 168);
            this.canelBtn.Name = "canelBtn";
            this.canelBtn.Size = new System.Drawing.Size(75, 23);
            this.canelBtn.TabIndex = 9;
            this.canelBtn.Text = "取消";
            this.canelBtn.UseVisualStyleBackColor = true;
            this.canelBtn.Click += new System.EventHandler(this.canelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(148, 168);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 8;
            this.okBtn.Text = "确定";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // PwdForm
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.canelBtn;
            this.ClientSize = new System.Drawing.Size(268, 227);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PwdForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改密码";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox usrTxt;
        private System.Windows.Forms.TextBox oPwdTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nPwdTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox n2PwdTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button canelBtn;
        private System.Windows.Forms.Button okBtn;
    }
}