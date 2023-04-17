namespace Book.BackForms
{
    partial class Frm_CategoryManage
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
            this.txtSubCategoryName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dGVCategory = new System.Windows.Forms.DataGridView();
            this.dGVSubCategory = new System.Windows.Forms.DataGridView();
            this.btInsert = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDemo = new System.Windows.Forms.Button();
            this.btnSubDemo = new System.Windows.Forms.Button();
            this.btnSubClear = new System.Windows.Forms.Button();
            this.btnSubDel = new System.Windows.Forms.Button();
            this.btnSunUp = new System.Windows.Forms.Button();
            this.btnSubAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSubRead = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.comboxCategoryID = new System.Windows.Forms.ComboBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dGVCategoryDetail = new System.Windows.Forms.DataGridView();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCategoryID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dGVCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVSubCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVCategoryDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSubCategoryName
            // 
            this.txtSubCategoryName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubCategoryName.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtSubCategoryName.Location = new System.Drawing.Point(138, 308);
            this.txtSubCategoryName.Name = "txtSubCategoryName";
            this.txtSubCategoryName.Size = new System.Drawing.Size(177, 29);
            this.txtSubCategoryName.TabIndex = 168;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(3, 311);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 19);
            this.label8.TabIndex = 167;
            this.label8.Text = "書籍子分類名稱：";
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCategoryName.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtCategoryName.Location = new System.Drawing.Point(138, 129);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(177, 29);
            this.txtCategoryName.TabIndex = 162;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(3, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 19);
            this.label5.TabIndex = 161;
            this.label5.Text = "書籍主分類名稱：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(3, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 30);
            this.label2.TabIndex = 157;
            this.label2.Text = "書籍分類管理";
            // 
            // dGVCategory
            // 
            this.dGVCategory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVCategory.Location = new System.Drawing.Point(0, 0);
            this.dGVCategory.Name = "dGVCategory";
            this.dGVCategory.RowTemplate.Height = 24;
            this.dGVCategory.Size = new System.Drawing.Size(577, 209);
            this.dGVCategory.TabIndex = 156;
            this.dGVCategory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVCategory_CellClick);
            // 
            // dGVSubCategory
            // 
            this.dGVSubCategory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVSubCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVSubCategory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dGVSubCategory.Location = new System.Drawing.Point(0, 52);
            this.dGVSubCategory.Name = "dGVSubCategory";
            this.dGVSubCategory.RowTemplate.Height = 24;
            this.dGVSubCategory.Size = new System.Drawing.Size(272, 319);
            this.dGVSubCategory.TabIndex = 174;
            this.dGVSubCategory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVSubCategory_CellClick);
            // 
            // btInsert
            // 
            this.btInsert.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btInsert.Location = new System.Drawing.Point(13, 177);
            this.btInsert.Name = "btInsert";
            this.btInsert.Size = new System.Drawing.Size(59, 32);
            this.btInsert.TabIndex = 158;
            this.btInsert.Text = "新增";
            this.btInsert.UseVisualStyleBackColor = true;
            this.btInsert.Click += new System.EventHandler(this.btInsert_Click);
            // 
            // btnUp
            // 
            this.btnUp.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnUp.Location = new System.Drawing.Point(78, 177);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(59, 32);
            this.btnUp.TabIndex = 159;
            this.btnUp.Text = "修改";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDel
            // 
            this.btnDel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDel.Location = new System.Drawing.Point(143, 177);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(59, 32);
            this.btnDel.TabIndex = 160;
            this.btnDel.Text = "刪除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClear.Location = new System.Drawing.Point(12, 215);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(84, 32);
            this.btnClear.TabIndex = 169;
            this.btnClear.Text = "清空欄位";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDemo
            // 
            this.btnDemo.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDemo.Location = new System.Drawing.Point(102, 215);
            this.btnDemo.Name = "btnDemo";
            this.btnDemo.Size = new System.Drawing.Size(77, 32);
            this.btnDemo.TabIndex = 170;
            this.btnDemo.Text = "Demo";
            this.btnDemo.UseVisualStyleBackColor = true;
            this.btnDemo.Click += new System.EventHandler(this.btnDemo_Click);
            // 
            // btnSubDemo
            // 
            this.btnSubDemo.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSubDemo.Location = new System.Drawing.Point(97, 385);
            this.btnSubDemo.Name = "btnSubDemo";
            this.btnSubDemo.Size = new System.Drawing.Size(69, 32);
            this.btnSubDemo.TabIndex = 180;
            this.btnSubDemo.Text = "Demo";
            this.btnSubDemo.UseVisualStyleBackColor = true;
            this.btnSubDemo.Click += new System.EventHandler(this.btnSubDemo_Click);
            // 
            // btnSubClear
            // 
            this.btnSubClear.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSubClear.Location = new System.Drawing.Point(7, 385);
            this.btnSubClear.Name = "btnSubClear";
            this.btnSubClear.Size = new System.Drawing.Size(84, 32);
            this.btnSubClear.TabIndex = 179;
            this.btnSubClear.Text = "清空欄位";
            this.btnSubClear.UseVisualStyleBackColor = true;
            this.btnSubClear.Click += new System.EventHandler(this.btnSubClear_Click);
            // 
            // btnSubDel
            // 
            this.btnSubDel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSubDel.Location = new System.Drawing.Point(203, 347);
            this.btnSubDel.Name = "btnSubDel";
            this.btnSubDel.Size = new System.Drawing.Size(59, 32);
            this.btnSubDel.TabIndex = 178;
            this.btnSubDel.Text = "刪除";
            this.btnSubDel.UseVisualStyleBackColor = true;
            this.btnSubDel.Click += new System.EventHandler(this.btnSubDel_Click);
            // 
            // btnSunUp
            // 
            this.btnSunUp.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSunUp.Location = new System.Drawing.Point(138, 347);
            this.btnSunUp.Name = "btnSunUp";
            this.btnSunUp.Size = new System.Drawing.Size(59, 32);
            this.btnSunUp.TabIndex = 177;
            this.btnSunUp.Text = "修改";
            this.btnSunUp.UseVisualStyleBackColor = true;
            this.btnSunUp.Click += new System.EventHandler(this.btnSunUp_Click);
            // 
            // btnSubAdd
            // 
            this.btnSubAdd.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSubAdd.Location = new System.Drawing.Point(73, 347);
            this.btnSubAdd.Name = "btnSubAdd";
            this.btnSubAdd.Size = new System.Drawing.Size(59, 32);
            this.btnSubAdd.TabIndex = 176;
            this.btnSubAdd.Text = "新增";
            this.btnSubAdd.UseVisualStyleBackColor = true;
            this.btnSubAdd.Click += new System.EventHandler(this.btnSubAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(3, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 19);
            this.label1.TabIndex = 181;
            this.label1.Text = "書籍主分類編號：";
            // 
            // btnSubRead
            // 
            this.btnSubRead.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSubRead.Location = new System.Drawing.Point(6, 347);
            this.btnSubRead.Name = "btnSubRead";
            this.btnSubRead.Size = new System.Drawing.Size(59, 32);
            this.btnSubRead.TabIndex = 183;
            this.btnSubRead.Text = "讀取";
            this.btnSubRead.UseVisualStyleBackColor = true;
            this.btnSubRead.Click += new System.EventHandler(this.btnSubRead_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.comboxCategoryID);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.btnSubRead);
            this.splitContainer1.Panel1.Controls.Add(this.btInsert);
            this.splitContainer1.Panel1.Controls.Add(this.btnUp);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btnDel);
            this.splitContainer1.Panel1.Controls.Add(this.btnSubDemo);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.btnSubClear);
            this.splitContainer1.Panel1.Controls.Add(this.txtCategoryName);
            this.splitContainer1.Panel1.Controls.Add(this.btnSubDel);
            this.splitContainer1.Panel1.Controls.Add(this.btnSunUp);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.btnSubAdd);
            this.splitContainer1.Panel1.Controls.Add(this.txtSubCategoryName);
            this.splitContainer1.Panel1.Controls.Add(this.btnClear);
            this.splitContainer1.Panel1.Controls.Add(this.txtCategoryID);
            this.splitContainer1.Panel1.Controls.Add(this.btnDemo);
            this.splitContainer1.Panel1.Controls.Add(this.label14);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(905, 584);
            this.splitContainer1.SplitterDistance = 324;
            this.splitContainer1.TabIndex = 184;
            // 
            // comboxCategoryID
            // 
            this.comboxCategoryID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboxCategoryID.FormattingEnabled = true;
            this.comboxCategoryID.Location = new System.Drawing.Point(138, 277);
            this.comboxCategoryID.Name = "comboxCategoryID";
            this.comboxCategoryID.Size = new System.Drawing.Size(177, 20);
            this.comboxCategoryID.TabIndex = 184;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dGVCategory);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(577, 584);
            this.splitContainer2.SplitterDistance = 209;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.label3);
            this.splitContainer3.Panel1.Controls.Add(this.dGVSubCategory);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.label4);
            this.splitContainer3.Panel2.Controls.Add(this.dGVCategoryDetail);
            this.splitContainer3.Size = new System.Drawing.Size(577, 371);
            this.splitContainer3.SplitterDistance = 272;
            this.splitContainer3.TabIndex = 175;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(3, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 182;
            this.label3.Text = "書籍子分類";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(3, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 20);
            this.label4.TabIndex = 182;
            this.label4.Text = "書籍分類明細";
            // 
            // dGVCategoryDetail
            // 
            this.dGVCategoryDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVCategoryDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVCategoryDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dGVCategoryDetail.Location = new System.Drawing.Point(0, 52);
            this.dGVCategoryDetail.Name = "dGVCategoryDetail";
            this.dGVCategoryDetail.RowTemplate.Height = 24;
            this.dGVCategoryDetail.Size = new System.Drawing.Size(301, 319);
            this.dGVCategoryDetail.TabIndex = 176;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(3, 86);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(129, 19);
            this.label14.TabIndex = 171;
            this.label14.Text = "書籍主分類編號：";
            // 
            // txtCategoryID
            // 
            this.txtCategoryID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCategoryID.Enabled = false;
            this.txtCategoryID.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtCategoryID.Location = new System.Drawing.Point(138, 86);
            this.txtCategoryID.Name = "txtCategoryID";
            this.txtCategoryID.Size = new System.Drawing.Size(177, 29);
            this.txtCategoryID.TabIndex = 172;
            // 
            // Frm_CategoryManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 584);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_CategoryManage";
            this.Text = "Frm_CategoryManage";
            this.Load += new System.EventHandler(this.Frm_CategoryManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVSubCategory)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVCategoryDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtSubCategoryName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dGVCategory;
        private System.Windows.Forms.DataGridView dGVSubCategory;
        private System.Windows.Forms.Button btInsert;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDemo;
        private System.Windows.Forms.Button btnSubDemo;
        private System.Windows.Forms.Button btnSubClear;
        private System.Windows.Forms.Button btnSubDel;
        private System.Windows.Forms.Button btnSunUp;
        private System.Windows.Forms.Button btnSubAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubRead;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataGridView dGVCategoryDetail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboxCategoryID;
        private System.Windows.Forms.TextBox txtCategoryID;
        private System.Windows.Forms.Label label14;
    }
}