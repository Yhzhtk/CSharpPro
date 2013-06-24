namespace ContractManager
{
    partial class ContractEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContractEditForm));
            this.okBtn = new System.Windows.Forms.Button();
            this.remark = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.proDesc = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.proExpireDate = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.proDeadLine = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.proSignExeDate = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.proSignDate = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.payStand = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.payPhone = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.signUnitLinkPhone = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.signUnitLinkMan = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.proSign = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.unitAdd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.proSignUnitName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupCusManager = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.linkPhone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.unicomLinkMan = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.proId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.proName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.proCate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.scanFile = new System.Windows.Forms.Button();
            this.fileName = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.dltdh = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.canelBtn = new System.Windows.Forms.Button();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(453, 530);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 84;
            this.okBtn.Text = "添加新合同";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // remark
            // 
            this.remark.Location = new System.Drawing.Point(126, 428);
            this.remark.Multiline = true;
            this.remark.Name = "remark";
            this.remark.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.remark.Size = new System.Drawing.Size(599, 65);
            this.remark.TabIndex = 83;
            this.remark.Enter += new System.EventHandler(this.proSignDate_Enter);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(91, 431);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 12);
            this.label19.TabIndex = 75;
            this.label19.Text = "备注";
            // 
            // proDesc
            // 
            this.proDesc.Location = new System.Drawing.Point(126, 356);
            this.proDesc.Multiline = true;
            this.proDesc.Name = "proDesc";
            this.proDesc.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.proDesc.Size = new System.Drawing.Size(599, 66);
            this.proDesc.TabIndex = 82;
            this.proDesc.Enter += new System.EventHandler(this.proSignDate_Enter);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(43, 359);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 12);
            this.label18.TabIndex = 73;
            this.label18.Text = "协议内容简述";
            // 
            // proExpireDate
            // 
            this.proExpireDate.BackColor = System.Drawing.SystemColors.Window;
            this.proExpireDate.Location = new System.Drawing.Point(484, 261);
            this.proExpireDate.Name = "proExpireDate";
            this.proExpireDate.ReadOnly = true;
            this.proExpireDate.Size = new System.Drawing.Size(241, 21);
            this.proExpireDate.TabIndex = 72;
            this.proExpireDate.Enter += new System.EventHandler(this.proSignDate_Enter);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(401, 268);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 12);
            this.label17.TabIndex = 71;
            this.label17.Text = "协议到期日期";
            // 
            // proDeadLine
            // 
            this.proDeadLine.Location = new System.Drawing.Point(484, 229);
            this.proDeadLine.Name = "proDeadLine";
            this.proDeadLine.Size = new System.Drawing.Size(241, 21);
            this.proDeadLine.TabIndex = 70;
            this.proDeadLine.Enter += new System.EventHandler(this.proSignDate_Enter);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(425, 232);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 69;
            this.label16.Text = "协议期限";
            // 
            // proSignExeDate
            // 
            this.proSignExeDate.BackColor = System.Drawing.SystemColors.Window;
            this.proSignExeDate.Location = new System.Drawing.Point(484, 197);
            this.proSignExeDate.Name = "proSignExeDate";
            this.proSignExeDate.ReadOnly = true;
            this.proSignExeDate.Size = new System.Drawing.Size(241, 21);
            this.proSignExeDate.TabIndex = 68;
            this.proSignExeDate.Enter += new System.EventHandler(this.proSignDate_Enter);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(401, 203);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 12);
            this.label15.TabIndex = 67;
            this.label15.Text = "协议执行日期";
            // 
            // proSignDate
            // 
            this.proSignDate.BackColor = System.Drawing.SystemColors.Window;
            this.proSignDate.Location = new System.Drawing.Point(484, 164);
            this.proSignDate.Name = "proSignDate";
            this.proSignDate.ReadOnly = true;
            this.proSignDate.Size = new System.Drawing.Size(241, 21);
            this.proSignDate.TabIndex = 66;
            this.proSignDate.Enter += new System.EventHandler(this.proSignDate_Enter);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(401, 167);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 12);
            this.label14.TabIndex = 65;
            this.label14.Text = "协议签订日期";
            // 
            // payStand
            // 
            this.payStand.Location = new System.Drawing.Point(484, 133);
            this.payStand.Name = "payStand";
            this.payStand.Size = new System.Drawing.Size(241, 21);
            this.payStand.TabIndex = 64;
            this.payStand.Enter += new System.EventHandler(this.proSignDate_Enter);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(425, 136);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 63;
            this.label13.Text = "收费标准";
            // 
            // payPhone
            // 
            this.payPhone.Location = new System.Drawing.Point(484, 98);
            this.payPhone.Name = "payPhone";
            this.payPhone.Size = new System.Drawing.Size(241, 21);
            this.payPhone.TabIndex = 62;
            this.payPhone.Enter += new System.EventHandler(this.proSignDate_Enter);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(425, 101);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 61;
            this.label12.Text = "付费号码";
            // 
            // signUnitLinkPhone
            // 
            this.signUnitLinkPhone.Location = new System.Drawing.Point(484, 61);
            this.signUnitLinkPhone.MaxLength = 14;
            this.signUnitLinkPhone.Name = "signUnitLinkPhone";
            this.signUnitLinkPhone.Size = new System.Drawing.Size(241, 21);
            this.signUnitLinkPhone.TabIndex = 60;
            this.signUnitLinkPhone.Enter += new System.EventHandler(this.proSignDate_Enter);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(425, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 59;
            this.label11.Text = "联系电话";
            // 
            // signUnitLinkMan
            // 
            this.signUnitLinkMan.Location = new System.Drawing.Point(484, 24);
            this.signUnitLinkMan.Name = "signUnitLinkMan";
            this.signUnitLinkMan.Size = new System.Drawing.Size(241, 21);
            this.signUnitLinkMan.TabIndex = 58;
            this.signUnitLinkMan.Enter += new System.EventHandler(this.proSignDate_Enter);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(389, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 57;
            this.label10.Text = "签署单位联系人";
            // 
            // proSign
            // 
            this.proSign.Location = new System.Drawing.Point(126, 295);
            this.proSign.Name = "proSign";
            this.proSign.Size = new System.Drawing.Size(239, 21);
            this.proSign.TabIndex = 56;
            this.proSign.Enter += new System.EventHandler(this.proSignDate_Enter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(67, 298);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 55;
            this.label9.Text = "协议签署";
            // 
            // unitAdd
            // 
            this.unitAdd.Location = new System.Drawing.Point(126, 261);
            this.unitAdd.Name = "unitAdd";
            this.unitAdd.Size = new System.Drawing.Size(239, 21);
            this.unitAdd.TabIndex = 54;
            this.unitAdd.Enter += new System.EventHandler(this.proSignDate_Enter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(67, 264);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 53;
            this.label8.Text = "单位地址";
            // 
            // proSignUnitName
            // 
            this.proSignUnitName.Location = new System.Drawing.Point(126, 229);
            this.proSignUnitName.Name = "proSignUnitName";
            this.proSignUnitName.Size = new System.Drawing.Size(239, 21);
            this.proSignUnitName.TabIndex = 52;
            this.proSignUnitName.Enter += new System.EventHandler(this.proSignDate_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 232);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 51;
            this.label7.Text = "协议签署单位名称";
            // 
            // groupCusManager
            // 
            this.groupCusManager.Location = new System.Drawing.Point(126, 197);
            this.groupCusManager.Name = "groupCusManager";
            this.groupCusManager.Size = new System.Drawing.Size(239, 21);
            this.groupCusManager.TabIndex = 50;
            this.groupCusManager.Enter += new System.EventHandler(this.proSignDate_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 49;
            this.label6.Text = "集团客户客户经理";
            // 
            // linkPhone
            // 
            this.linkPhone.Location = new System.Drawing.Point(126, 165);
            this.linkPhone.MaxLength = 14;
            this.linkPhone.Name = "linkPhone";
            this.linkPhone.Size = new System.Drawing.Size(239, 21);
            this.linkPhone.TabIndex = 48;
            this.linkPhone.Enter += new System.EventHandler(this.proSignDate_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 47;
            this.label5.Text = "联系电话";
            // 
            // unicomLinkMan
            // 
            this.unicomLinkMan.Location = new System.Drawing.Point(126, 129);
            this.unicomLinkMan.Name = "unicomLinkMan";
            this.unicomLinkMan.Size = new System.Drawing.Size(239, 21);
            this.unicomLinkMan.TabIndex = 46;
            this.unicomLinkMan.Enter += new System.EventHandler(this.proSignDate_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 45;
            this.label4.Text = "联通公司业务联系人";
            // 
            // proId
            // 
            this.proId.Location = new System.Drawing.Point(126, 96);
            this.proId.Name = "proId";
            this.proId.Size = new System.Drawing.Size(239, 21);
            this.proId.TabIndex = 44;
            this.proId.Enter += new System.EventHandler(this.proSignDate_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 43;
            this.label3.Text = "协议编号";
            // 
            // proName
            // 
            this.proName.Location = new System.Drawing.Point(126, 61);
            this.proName.Name = "proName";
            this.proName.Size = new System.Drawing.Size(239, 21);
            this.proName.TabIndex = 42;
            this.proName.Enter += new System.EventHandler(this.proSignDate_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 41;
            this.label2.Text = "协议名称";
            // 
            // proCate
            // 
            this.proCate.Location = new System.Drawing.Point(126, 24);
            this.proCate.Name = "proCate";
            this.proCate.Size = new System.Drawing.Size(239, 21);
            this.proCate.TabIndex = 40;
            this.proCate.Enter += new System.EventHandler(this.proSignDate_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 39;
            this.label1.Text = "协议类型";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.scanFile);
            this.groupBox1.Controls.Add(this.fileName);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.dltdh);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.remark);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.proDesc);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.proExpireDate);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.proDeadLine);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.proSignExeDate);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.proSignDate);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.payStand);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.payPhone);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.signUnitLinkPhone);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.signUnitLinkMan);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.proSign);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.unitAdd);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.proSignUnitName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.groupCusManager);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.linkPhone);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.unicomLinkMan);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.proId);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.proName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.proCate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(755, 499);
            this.groupBox1.TabIndex = 78;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "协议详细内容";
            // 
            // scanFile
            // 
            this.scanFile.Location = new System.Drawing.Point(650, 325);
            this.scanFile.Name = "scanFile";
            this.scanFile.Size = new System.Drawing.Size(75, 23);
            this.scanFile.TabIndex = 81;
            this.scanFile.Text = "浏览..";
            this.scanFile.UseVisualStyleBackColor = true;
            this.scanFile.Click += new System.EventHandler(this.scanFile_Click);
            // 
            // fileName
            // 
            this.fileName.BackColor = System.Drawing.SystemColors.Window;
            this.fileName.Location = new System.Drawing.Point(126, 327);
            this.fileName.Name = "fileName";
            this.fileName.ReadOnly = true;
            this.fileName.Size = new System.Drawing.Size(505, 21);
            this.fileName.TabIndex = 80;
            this.fileName.Enter += new System.EventHandler(this.proSignDate_Enter);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(79, 330);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 12);
            this.label21.TabIndex = 79;
            this.label21.Text = "文件名";
            // 
            // dltdh
            // 
            this.dltdh.BackColor = System.Drawing.SystemColors.Window;
            this.dltdh.Location = new System.Drawing.Point(484, 292);
            this.dltdh.Name = "dltdh";
            this.dltdh.Size = new System.Drawing.Size(241, 21);
            this.dltdh.TabIndex = 78;
            this.dltdh.Enter += new System.EventHandler(this.proSignDate_Enter);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(413, 298);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 12);
            this.label20.TabIndex = 77;
            this.label20.Text = "电路调单号";
            // 
            // canelBtn
            // 
            this.canelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.canelBtn.Location = new System.Drawing.Point(576, 530);
            this.canelBtn.Name = "canelBtn";
            this.canelBtn.Size = new System.Drawing.Size(75, 23);
            this.canelBtn.TabIndex = 85;
            this.canelBtn.Text = "取消";
            this.canelBtn.UseVisualStyleBackColor = true;
            this.canelBtn.Click += new System.EventHandler(this.canelBtn_Click);
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(33, 517);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 77;
            this.monthCalendar.Visible = false;
            this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateSelected);
            // 
            // ContractEditForm
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.canelBtn;
            this.ClientSize = new System.Drawing.Size(783, 573);
            this.Controls.Add(this.monthCalendar);
            this.Controls.Add(this.canelBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.okBtn);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(791, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(791, 600);
            this.Name = "ContractEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ContractEditForm";
            this.Load += new System.EventHandler(this.ContractEditForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.TextBox remark;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox proDesc;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox proExpireDate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox proDeadLine;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox proSignExeDate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox proSignDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox payStand;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox payPhone;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox signUnitLinkPhone;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox signUnitLinkMan;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox proSign;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox unitAdd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox proSignUnitName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox groupCusManager;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox linkPhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox unicomLinkMan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox proId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox proName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox proCate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button canelBtn;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.TextBox dltdh;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox fileName;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button scanFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}