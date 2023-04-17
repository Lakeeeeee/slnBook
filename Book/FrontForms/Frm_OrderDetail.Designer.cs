namespace Book.FrontForms
{
    partial class Frm_OrderDetail
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
            this.dGV_orderdetail = new System.Windows.Forms.DataGridView();
            this.lab_title = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_orderdetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dGV_orderdetail
            // 
            this.dGV_orderdetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGV_orderdetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_orderdetail.Location = new System.Drawing.Point(61, 78);
            this.dGV_orderdetail.Name = "dGV_orderdetail";
            this.dGV_orderdetail.RowTemplate.Height = 24;
            this.dGV_orderdetail.Size = new System.Drawing.Size(602, 318);
            this.dGV_orderdetail.TabIndex = 0;
            // 
            // lab_title
            // 
            this.lab_title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_title.AutoSize = true;
            this.lab_title.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_title.Location = new System.Drawing.Point(61, 33);
            this.lab_title.Name = "lab_title";
            this.lab_title.Size = new System.Drawing.Size(142, 23);
            this.lab_title.TabIndex = 1;
            this.lab_title.Text = "Order Detial";
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.FlatAppearance.BorderSize = 0;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.Location = new System.Drawing.Point(577, 417);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(86, 30);
            this.btn_cancel.TabIndex = 22;
            this.btn_cancel.Text = "Close";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // Frm_OrderDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 481);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.lab_title);
            this.Controls.Add(this.dGV_orderdetail);
            this.Name = "Frm_OrderDetail";
            this.Text = "Frm_OrderDetail";
            ((System.ComponentModel.ISupportInitialize)(this.dGV_orderdetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dGV_orderdetail;
        private System.Windows.Forms.Label lab_title;
        private System.Windows.Forms.Button btn_cancel;
    }
}