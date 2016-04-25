namespace SMSCloudWebserviceSend
{
    partial class FrmWebserviceSend
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWebserviceSend));
            this.btnInvoke = new System.Windows.Forms.Button();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.txtSMSContent = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSendTime = new System.Windows.Forms.TextBox();
            this.txtSubCode = new System.Windows.Forms.TextBox();
            this.txtSign = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSmsId = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdoCheckKeyWord = new System.Windows.Forms.RadioButton();
            this.rdoGetReport = new System.Windows.Forms.RadioButton();
            this.rdoGetBlacklist = new System.Windows.Forms.RadioButton();
            this.rdoGetSMS = new System.Windows.Forms.RadioButton();
            this.rdoGetBanlance = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoSendSMS = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtServerURL = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInvoke
            // 
            this.btnInvoke.Location = new System.Drawing.Point(228, 426);
            this.btnInvoke.Name = "btnInvoke";
            this.btnInvoke.Size = new System.Drawing.Size(75, 23);
            this.btnInvoke.TabIndex = 0;
            this.btnInvoke.Text = "调用";
            this.btnInvoke.UseVisualStyleBackColor = true;
            this.btnInvoke.Click += new System.EventHandler(this.btnInvoke_Click);
            // 
            // txtResponse
            // 
            this.txtResponse.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtResponse.Location = new System.Drawing.Point(6, 20);
            this.txtResponse.MaxLength = 10000;
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ReadOnly = true;
            this.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResponse.Size = new System.Drawing.Size(594, 69);
            this.txtResponse.TabIndex = 11;
            // 
            // txtSMSContent
            // 
            this.txtSMSContent.AcceptsReturn = true;
            this.txtSMSContent.AcceptsTab = true;
            this.txtSMSContent.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSMSContent.Location = new System.Drawing.Point(87, 78);
            this.txtSMSContent.MaxLength = 350;
            this.txtSMSContent.Multiline = true;
            this.txtSMSContent.Name = "txtSMSContent";
            this.txtSMSContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSMSContent.Size = new System.Drawing.Size(200, 53);
            this.txtSMSContent.TabIndex = 11;
            this.txtSMSContent.Text = "短信内容。";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label8.Location = new System.Drawing.Point(16, 259);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "发送时间：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label7.Location = new System.Drawing.Point(16, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "短信子码：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label6.Location = new System.Drawing.Point(16, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "短信签名：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(16, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "短信内容：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(16, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "短信标识：";
            // 
            // txtSendTime
            // 
            this.txtSendTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSendTime.Location = new System.Drawing.Point(87, 256);
            this.txtSendTime.MaxLength = 25;
            this.txtSendTime.Name = "txtSendTime";
            this.txtSendTime.Size = new System.Drawing.Size(200, 21);
            this.txtSendTime.TabIndex = 1;
            // 
            // txtSubCode
            // 
            this.txtSubCode.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSubCode.Location = new System.Drawing.Point(87, 223);
            this.txtSubCode.MaxLength = 25;
            this.txtSubCode.Name = "txtSubCode";
            this.txtSubCode.Size = new System.Drawing.Size(200, 21);
            this.txtSubCode.TabIndex = 1;
            // 
            // txtSign
            // 
            this.txtSign.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSign.Location = new System.Drawing.Point(87, 193);
            this.txtSign.MaxLength = 25;
            this.txtSign.Name = "txtSign";
            this.txtSign.Size = new System.Drawing.Size(199, 21);
            this.txtSign.TabIndex = 1;
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPhone.Location = new System.Drawing.Point(87, 20);
            this.txtPhone.MaxLength = 1000;
            this.txtPhone.Multiline = true;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPhone.Size = new System.Drawing.Size(200, 48);
            this.txtPhone.TabIndex = 9;
            this.txtPhone.Text = "1311111XXXX,1322222XXXX,1333333XXXX";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(16, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "手机号码：";
            // 
            // txtSmsId
            // 
            this.txtSmsId.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSmsId.Location = new System.Drawing.Point(87, 139);
            this.txtSmsId.MaxLength = 64;
            this.txtSmsId.Multiline = true;
            this.txtSmsId.Name = "txtSmsId";
            this.txtSmsId.Size = new System.Drawing.Size(199, 48);
            this.txtSmsId.TabIndex = 10;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtResponse);
            this.groupBox5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox5.ForeColor = System.Drawing.Color.Blue;
            this.groupBox5.Location = new System.Drawing.Point(10, 311);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(607, 100);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "反馈数据";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtSMSContent);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txtSendTime);
            this.groupBox4.Controls.Add(this.txtSubCode);
            this.groupBox4.Controls.Add(this.txtSign);
            this.groupBox4.Controls.Add(this.txtPhone);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txtSmsId);
            this.groupBox4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.ForeColor = System.Drawing.Color.Blue;
            this.groupBox4.Location = new System.Drawing.Point(324, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(293, 293);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "数据设置";
            // 
            // rdoCheckKeyWord
            // 
            this.rdoCheckKeyWord.AutoSize = true;
            this.rdoCheckKeyWord.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoCheckKeyWord.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rdoCheckKeyWord.Location = new System.Drawing.Point(197, 64);
            this.rdoCheckKeyWord.Name = "rdoCheckKeyWord";
            this.rdoCheckKeyWord.Size = new System.Drawing.Size(83, 16);
            this.rdoCheckKeyWord.TabIndex = 8;
            this.rdoCheckKeyWord.Tag = "CheckKeyWord";
            this.rdoCheckKeyWord.Text = "检测敏感词";
            this.rdoCheckKeyWord.UseVisualStyleBackColor = true;
            this.rdoCheckKeyWord.Click += new System.EventHandler(this.rdo_Click);
            // 
            // rdoGetReport
            // 
            this.rdoGetReport.AutoSize = true;
            this.rdoGetReport.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoGetReport.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rdoGetReport.Location = new System.Drawing.Point(197, 30);
            this.rdoGetReport.Name = "rdoGetReport";
            this.rdoGetReport.Size = new System.Drawing.Size(71, 16);
            this.rdoGetReport.TabIndex = 5;
            this.rdoGetReport.Tag = "GetReport";
            this.rdoGetReport.Text = "查询状态";
            this.rdoGetReport.UseVisualStyleBackColor = true;
            this.rdoGetReport.Click += new System.EventHandler(this.rdo_Click);
            // 
            // rdoGetBlacklist
            // 
            this.rdoGetBlacklist.AutoSize = true;
            this.rdoGetBlacklist.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoGetBlacklist.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rdoGetBlacklist.Location = new System.Drawing.Point(108, 64);
            this.rdoGetBlacklist.Name = "rdoGetBlacklist";
            this.rdoGetBlacklist.Size = new System.Drawing.Size(83, 16);
            this.rdoGetBlacklist.TabIndex = 7;
            this.rdoGetBlacklist.Tag = "GetBlacklist";
            this.rdoGetBlacklist.Text = "查询黑名单";
            this.rdoGetBlacklist.UseVisualStyleBackColor = true;
            this.rdoGetBlacklist.Click += new System.EventHandler(this.rdo_Click);
            // 
            // rdoGetSMS
            // 
            this.rdoGetSMS.AutoSize = true;
            this.rdoGetSMS.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoGetSMS.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rdoGetSMS.Location = new System.Drawing.Point(108, 30);
            this.rdoGetSMS.Name = "rdoGetSMS";
            this.rdoGetSMS.Size = new System.Drawing.Size(71, 16);
            this.rdoGetSMS.TabIndex = 4;
            this.rdoGetSMS.Tag = "GetSMS";
            this.rdoGetSMS.Text = "获取上行";
            this.rdoGetSMS.UseVisualStyleBackColor = true;
            this.rdoGetSMS.Click += new System.EventHandler(this.rdo_Click);
            // 
            // rdoGetBanlance
            // 
            this.rdoGetBanlance.AutoSize = true;
            this.rdoGetBanlance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoGetBanlance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rdoGetBanlance.Location = new System.Drawing.Point(19, 64);
            this.rdoGetBanlance.Name = "rdoGetBanlance";
            this.rdoGetBanlance.Size = new System.Drawing.Size(71, 16);
            this.rdoGetBanlance.TabIndex = 6;
            this.rdoGetBanlance.Tag = "GetBanlance";
            this.rdoGetBanlance.Text = "查询余额";
            this.rdoGetBanlance.UseVisualStyleBackColor = true;
            this.rdoGetBanlance.Click += new System.EventHandler(this.rdo_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdoCheckKeyWord);
            this.groupBox3.Controls.Add(this.rdoGetReport);
            this.groupBox3.Controls.Add(this.rdoGetBlacklist);
            this.groupBox3.Controls.Add(this.rdoGetSMS);
            this.groupBox3.Controls.Add(this.rdoGetBanlance);
            this.groupBox3.Controls.Add(this.rdoSendSMS);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.ForeColor = System.Drawing.Color.Blue;
            this.groupBox3.Location = new System.Drawing.Point(10, 205);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(293, 100);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "调用方法";
            // 
            // rdoSendSMS
            // 
            this.rdoSendSMS.AutoSize = true;
            this.rdoSendSMS.Checked = true;
            this.rdoSendSMS.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoSendSMS.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rdoSendSMS.Location = new System.Drawing.Point(19, 30);
            this.rdoSendSMS.Name = "rdoSendSMS";
            this.rdoSendSMS.Size = new System.Drawing.Size(71, 16);
            this.rdoSendSMS.TabIndex = 3;
            this.rdoSendSMS.TabStop = true;
            this.rdoSendSMS.Tag = "SendSMS";
            this.rdoSendSMS.Text = "发送短信";
            this.rdoSendSMS.UseVisualStyleBackColor = true;
            this.rdoSendSMS.Click += new System.EventHandler(this.rdo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(17, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(17, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "账号：";
            // 
            // txtPassWord
            // 
            this.txtPassWord.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPassWord.Location = new System.Drawing.Point(74, 60);
            this.txtPassWord.MaxLength = 25;
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(213, 21);
            this.txtPassWord.TabIndex = 2;
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUserName.Location = new System.Drawing.Point(74, 23);
            this.txtUserName.MaxLength = 25;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(212, 21);
            this.txtUserName.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtPassWord);
            this.groupBox2.Controls.Add(this.txtUserName);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(10, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(293, 100);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "账号密码";
            // 
            // txtServerURL
            // 
            this.txtServerURL.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtServerURL.Location = new System.Drawing.Point(7, 20);
            this.txtServerURL.MaxLength = 150;
            this.txtServerURL.Multiline = true;
            this.txtServerURL.Name = "txtServerURL";
            this.txtServerURL.Size = new System.Drawing.Size(281, 49);
            this.txtServerURL.TabIndex = 0;
            this.txtServerURL.Text = "http://ws.3tong.net/services/sms";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtServerURL);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(10, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 81);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "服务地址";
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(324, 426);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FrmWebserviceSend
            // 
            this.AcceptButton = this.btnInvoke;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(626, 463);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnInvoke);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmWebserviceSend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "短信云Webserivice接口客户端示例";
            this.Load += new System.EventHandler(this.FrmWebserviceSend_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInvoke;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.TextBox txtSMSContent;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSendTime;
        private System.Windows.Forms.TextBox txtSubCode;
        private System.Windows.Forms.TextBox txtSign;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSmsId;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdoCheckKeyWord;
        private System.Windows.Forms.RadioButton rdoGetReport;
        private System.Windows.Forms.RadioButton rdoGetBlacklist;
        private System.Windows.Forms.RadioButton rdoGetSMS;
        private System.Windows.Forms.RadioButton rdoGetBanlance;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdoSendSMS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtServerURL;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExit;
    }
}

