namespace ContractManager
{
    partial class LogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.userTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pwdTxt = new System.Windows.Forms.TextBox();
            this.logBtn = new System.Windows.Forms.Button();
            this.canelBtn = new System.Windows.Forms.Button();
            this.infoLab = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(124, 71);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体_GB2312", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(125, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "中国联通唐山市曹妃甸区\r\n  分公司合同管理系统\r\n";
            // 
            // userTxt
            // 
            this.userTxt.Location = new System.Drawing.Point(104, 87);
            this.userTxt.Name = "userTxt";
            this.userTxt.Size = new System.Drawing.Size(198, 21);
            this.userTxt.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "用户名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "密码";
            // 
            // pwdTxt
            // 
            this.pwdTxt.Location = new System.Drawing.Point(104, 122);
            this.pwdTxt.Name = "pwdTxt";
            this.pwdTxt.Size = new System.Drawing.Size(198, 21);
            this.pwdTxt.TabIndex = 5;
            this.pwdTxt.UseSystemPasswordChar = true;
            // 
            // logBtn
            // 
            this.logBtn.Location = new System.Drawing.Point(71, 166);
            this.logBtn.Name = "logBtn";
            this.logBtn.Size = new System.Drawing.Size(75, 23);
            this.logBtn.TabIndex = 6;
            this.logBtn.Text = "登陆";
            this.logBtn.UseVisualStyleBackColor = true;
            this.logBtn.Click += new System.EventHandler(this.logBtn_Click);
            // 
            // canelBtn
            // 
            this.canelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.canelBtn.Location = new System.Drawing.Point(209, 166);
            this.canelBtn.Name = "canelBtn";
            this.canelBtn.Size = new System.Drawing.Size(75, 23);
            this.canelBtn.TabIndex = 7;
            this.canelBtn.Text = "退出";
            this.canelBtn.UseVisualStyleBackColor = true;
            this.canelBtn.Click += new System.EventHandler(this.canelBtn_Click);
            // 
            // infoLab
            // 
            this.infoLab.AutoSize = true;
            this.infoLab.ForeColor = System.Drawing.Color.Red;
            this.infoLab.Location = new System.Drawing.Point(48, 149);
            this.infoLab.Name = "infoLab";
            this.infoLab.Size = new System.Drawing.Size(281, 12);
            this.infoLab.TabIndex = 8;
            this.infoLab.Text = "初始密码为空，可直接进入，进入后创建用户密码！";
            // 
            // LogForm
            // 
            this.AcceptButton = this.logBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.canelBtn;
            this.ClientSize = new System.Drawing.Size(362, 201);
            this.Controls.Add(this.infoLab);
            this.Controls.Add(this.canelBtn);
            this.Controls.Add(this.logBtn);
            this.Controls.Add(this.pwdTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.userTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(370, 228);
            this.MinimumSize = new System.Drawing.Size(370, 228);
            this.Name = "LogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登陆 - 中国联通唐山市曹妃甸区分公司合同管理系统";
            this.Load += new System.EventHandler(this.LogForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pwdTxt;
        private System.Windows.Forms.Button logBtn;
        private System.Windows.Forms.Button canelBtn;
        private System.Windows.Forms.Label infoLab;
    }
}