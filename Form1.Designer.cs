
namespace SendSmtp
{
    partial class Form1
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
            this.btnSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRecipient = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(38, 267);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(117, 39);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "SEND";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "HOST";
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(244, 30);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(394, 26);
            this.txtHost.TabIndex = 2;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(244, 75);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(394, 26);
            this.txtPort.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "PORT";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(244, 120);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(394, 26);
            this.txtUser.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "EMAIL/ USERID";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(244, 170);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '@';
            this.txtPassword.Size = new System.Drawing.Size(394, 26);
            this.txtPassword.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "PASSWORD";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "SEND TO (EMAIL):";
            // 
            // txtRecipient
            // 
            this.txtRecipient.Location = new System.Drawing.Point(244, 218);
            this.txtRecipient.Name = "txtRecipient";
            this.txtRecipient.Size = new System.Drawing.Size(394, 26);
            this.txtRecipient.TabIndex = 10;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(38, 328);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(600, 131);
            this.txtLog.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 489);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRecipient);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtPassword);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMTP TESTER v1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRecipient;
        private System.Windows.Forms.TextBox txtLog;
    }
}

