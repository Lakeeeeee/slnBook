namespace Book.FrontForms
{
    partial class Frm_Browse
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
            this.label27 = new System.Windows.Forms.Label();
            this.lab_title = new System.Windows.Forms.Label();
            this.btn_check = new System.Windows.Forms.Button();
            this.tB1 = new System.Windows.Forms.TextBox();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label27.Location = new System.Drawing.Point(125, 103);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(137, 20);
            this.label27.TabIndex = 46;
            this.label27.Text = "請輸入正確的格式";
            // 
            // lab_title
            // 
            this.lab_title.AutoSize = true;
            this.lab_title.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_title.Location = new System.Drawing.Point(15, 70);
            this.lab_title.Name = "lab_title";
            this.lab_title.Size = new System.Drawing.Size(45, 20);
            this.lab_title.TabIndex = 41;
            this.lab_title.Text = "密碼:";
            // 
            // btn_check
            // 
            this.btn_check.BackColor = System.Drawing.Color.Silver;
            this.btn_check.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_check.FlatAppearance.BorderSize = 0;
            this.btn_check.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_check.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_check.Location = new System.Drawing.Point(102, 138);
            this.btn_check.Name = "btn_check";
            this.btn_check.Size = new System.Drawing.Size(86, 29);
            this.btn_check.TabIndex = 38;
            this.btn_check.Text = "確認";
            this.btn_check.UseVisualStyleBackColor = false;
            // 
            // tB1
            // 
            this.tB1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tB1.Location = new System.Drawing.Point(102, 61);
            this.tB1.MaxLength = 10;
            this.tB1.Name = "tB1";
            this.tB1.Size = new System.Drawing.Size(192, 29);
            this.tB1.TabIndex = 35;
            this.tB1.TextChanged += new System.EventHandler(this.tB1_TextChanged);
            // 
            // btn_cancle
            // 
            this.btn_cancle.BackColor = System.Drawing.Color.Silver;
            this.btn_cancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancle.FlatAppearance.BorderSize = 0;
            this.btn_cancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancle.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancle.Location = new System.Drawing.Point(208, 138);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(86, 29);
            this.btn_cancle.TabIndex = 47;
            this.btn_cancle.Text = "Cancle";
            this.btn_cancle.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(15, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 20);
            this.label1.TabIndex = 48;
            this.label1.Text = "密碼格式：8-10個英數字，包含大寫英文";
            // 
            // Frm_Browse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(364, 201);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_cancle);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.lab_title);
            this.Controls.Add(this.btn_check);
            this.Controls.Add(this.tB1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Frm_Browse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Browse";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label lab_title;
        private System.Windows.Forms.Button btn_check;
        private System.Windows.Forms.TextBox tB1;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.Label label1;
    }
}