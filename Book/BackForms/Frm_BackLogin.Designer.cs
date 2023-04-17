namespace Book
{
    partial class Frm_BackLogin
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAcount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnCan = new System.Windows.Forms.Button();
            this.btn_backDemo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(39, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 35;
            this.label3.Text = "管理者密碼";
            // 
            // txtPwd
            // 
            this.txtPwd.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtPwd.Location = new System.Drawing.Point(43, 181);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(249, 29);
            this.txtPwd.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(39, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 34;
            this.label2.Text = "管理者帳號";
            // 
            // txtAcount
            // 
            this.txtAcount.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtAcount.Location = new System.Drawing.Point(43, 108);
            this.txtAcount.Name = "txtAcount";
            this.txtAcount.Size = new System.Drawing.Size(249, 29);
            this.txtAcount.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(39, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "後台登入";
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(72, 238);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(76, 32);
            this.btnLog.TabIndex = 36;
            this.btnLog.Text = "登入";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnCan
            // 
            this.btnCan.Location = new System.Drawing.Point(185, 238);
            this.btnCan.Name = "btnCan";
            this.btnCan.Size = new System.Drawing.Size(74, 32);
            this.btnCan.TabIndex = 37;
            this.btnCan.Text = "取消";
            this.btnCan.UseVisualStyleBackColor = true;
            this.btnCan.Click += new System.EventHandler(this.btnCan_Click);
            // 
            // btn_backDemo
            // 
            this.btn_backDemo.Location = new System.Drawing.Point(275, 238);
            this.btn_backDemo.Name = "btn_backDemo";
            this.btn_backDemo.Size = new System.Drawing.Size(74, 32);
            this.btn_backDemo.TabIndex = 38;
            this.btn_backDemo.Text = "Demo";
            this.btn_backDemo.UseVisualStyleBackColor = true;
            this.btn_backDemo.Click += new System.EventHandler(this.btn_backDemo_Click);
            // 
            // Frm_BackLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 301);
            this.Controls.Add(this.btn_backDemo);
            this.Controls.Add(this.btnCan);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAcount);
            this.Controls.Add(this.label1);
            this.Name = "Frm_BackLogin";
            this.Text = "Form_Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_BackLogin_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAcount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Button btnCan;
        private System.Windows.Forms.Button btn_backDemo;
    }
}