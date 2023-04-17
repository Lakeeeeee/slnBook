namespace Book
{
    partial class Form_ShowBookInformation
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
            this.picBook = new System.Windows.Forms.PictureBox();
            this.labBookTitle = new System.Windows.Forms.Label();
            this.labAuthorLeft = new System.Windows.Forms.Label();
            this.labAuthorRight = new System.Windows.Forms.Label();
            this.labISBNRight = new System.Windows.Forms.Label();
            this.labISBNLeft = new System.Windows.Forms.Label();
            this.labPublicateDateLeft = new System.Windows.Forms.Label();
            this.labPagesRight = new System.Windows.Forms.Label();
            this.labPagesLeft = new System.Windows.Forms.Label();
            this.labPublicateDateRight = new System.Windows.Forms.Label();
            this.labLanguageRight = new System.Windows.Forms.Label();
            this.labLanguageLeft = new System.Windows.Forms.Label();
            this.labCategoryLeft = new System.Windows.Forms.Label();
            this.labUnitInStockRight = new System.Windows.Forms.Label();
            this.labUnitInStockLeft = new System.Windows.Forms.Label();
            this.labUnitPriceRight = new System.Windows.Forms.Label();
            this.labUnitPriceLeft = new System.Windows.Forms.Label();
            this.labCategoryRight = new System.Windows.Forms.Label();
            this.labPublisherNameRight = new System.Windows.Forms.Label();
            this.labPublisherNameLeft = new System.Windows.Forms.Label();
            this.btn_addchart = new System.Windows.Forms.Button();
            this.btn_addauthor = new System.Windows.Forms.Button();
            this.btn_addpub = new System.Windows.Forms.Button();
            this.btn_comment = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.picBook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // picBook
            // 
            this.picBook.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.picBook.Location = new System.Drawing.Point(35, 75);
            this.picBook.Name = "picBook";
            this.picBook.Size = new System.Drawing.Size(264, 302);
            this.picBook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBook.TabIndex = 0;
            this.picBook.TabStop = false;
            // 
            // labBookTitle
            // 
            this.labBookTitle.AutoSize = true;
            this.labBookTitle.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labBookTitle.Location = new System.Drawing.Point(33, 18);
            this.labBookTitle.Name = "labBookTitle";
            this.labBookTitle.Size = new System.Drawing.Size(69, 35);
            this.labBookTitle.TabIndex = 1;
            this.labBookTitle.Text = "書名";
            // 
            // labAuthorLeft
            // 
            this.labAuthorLeft.AutoSize = true;
            this.labAuthorLeft.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labAuthorLeft.Location = new System.Drawing.Point(374, 74);
            this.labAuthorLeft.Name = "labAuthorLeft";
            this.labAuthorLeft.Size = new System.Drawing.Size(59, 27);
            this.labAuthorLeft.TabIndex = 2;
            this.labAuthorLeft.Text = "作者:";
            // 
            // labAuthorRight
            // 
            this.labAuthorRight.AutoSize = true;
            this.labAuthorRight.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labAuthorRight.Location = new System.Drawing.Point(497, 75);
            this.labAuthorRight.Name = "labAuthorRight";
            this.labAuthorRight.Size = new System.Drawing.Size(96, 27);
            this.labAuthorRight.TabIndex = 3;
            this.labAuthorRight.Text = "作者名稱";
            // 
            // labISBNRight
            // 
            this.labISBNRight.AutoSize = true;
            this.labISBNRight.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labISBNRight.Location = new System.Drawing.Point(497, 118);
            this.labISBNRight.Name = "labISBNRight";
            this.labISBNRight.Size = new System.Drawing.Size(102, 27);
            this.labISBNRight.TabIndex = 5;
            this.labISBNRight.Text = "ISBN名稱";
            // 
            // labISBNLeft
            // 
            this.labISBNLeft.AutoSize = true;
            this.labISBNLeft.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labISBNLeft.Location = new System.Drawing.Point(374, 117);
            this.labISBNLeft.Name = "labISBNLeft";
            this.labISBNLeft.Size = new System.Drawing.Size(65, 27);
            this.labISBNLeft.TabIndex = 4;
            this.labISBNLeft.Text = "ISBN:";
            // 
            // labPublicateDateLeft
            // 
            this.labPublicateDateLeft.AutoSize = true;
            this.labPublicateDateLeft.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labPublicateDateLeft.Location = new System.Drawing.Point(374, 203);
            this.labPublicateDateLeft.Name = "labPublicateDateLeft";
            this.labPublicateDateLeft.Size = new System.Drawing.Size(101, 27);
            this.labPublicateDateLeft.TabIndex = 6;
            this.labPublicateDateLeft.Text = "出版日期:";
            // 
            // labPagesRight
            // 
            this.labPagesRight.AutoSize = true;
            this.labPagesRight.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labPagesRight.Location = new System.Drawing.Point(497, 289);
            this.labPagesRight.Name = "labPagesRight";
            this.labPagesRight.Size = new System.Drawing.Size(54, 27);
            this.labPagesRight.TabIndex = 9;
            this.labPagesRight.Text = "頁數";
            // 
            // labPagesLeft
            // 
            this.labPagesLeft.AutoSize = true;
            this.labPagesLeft.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labPagesLeft.Location = new System.Drawing.Point(374, 289);
            this.labPagesLeft.Name = "labPagesLeft";
            this.labPagesLeft.Size = new System.Drawing.Size(59, 27);
            this.labPagesLeft.TabIndex = 8;
            this.labPagesLeft.Text = "頁數:";
            // 
            // labPublicateDateRight
            // 
            this.labPublicateDateRight.AutoSize = true;
            this.labPublicateDateRight.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labPublicateDateRight.Location = new System.Drawing.Point(497, 204);
            this.labPublicateDateRight.Name = "labPublicateDateRight";
            this.labPublicateDateRight.Size = new System.Drawing.Size(101, 27);
            this.labPublicateDateRight.TabIndex = 10;
            this.labPublicateDateRight.Text = "出版日期:";
            // 
            // labLanguageRight
            // 
            this.labLanguageRight.AutoSize = true;
            this.labLanguageRight.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labLanguageRight.Location = new System.Drawing.Point(497, 246);
            this.labLanguageRight.Name = "labLanguageRight";
            this.labLanguageRight.Size = new System.Drawing.Size(54, 27);
            this.labLanguageRight.TabIndex = 17;
            this.labLanguageRight.Text = "語言";
            // 
            // labLanguageLeft
            // 
            this.labLanguageLeft.AutoSize = true;
            this.labLanguageLeft.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labLanguageLeft.Location = new System.Drawing.Point(374, 246);
            this.labLanguageLeft.Name = "labLanguageLeft";
            this.labLanguageLeft.Size = new System.Drawing.Size(59, 27);
            this.labLanguageLeft.TabIndex = 16;
            this.labLanguageLeft.Text = "語言:";
            // 
            // labCategoryLeft
            // 
            this.labCategoryLeft.AutoSize = true;
            this.labCategoryLeft.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labCategoryLeft.Location = new System.Drawing.Point(374, 418);
            this.labCategoryLeft.Name = "labCategoryLeft";
            this.labCategoryLeft.Size = new System.Drawing.Size(59, 27);
            this.labCategoryLeft.TabIndex = 15;
            this.labCategoryLeft.Text = "分類:";
            // 
            // labUnitInStockRight
            // 
            this.labUnitInStockRight.AutoSize = true;
            this.labUnitInStockRight.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labUnitInStockRight.Location = new System.Drawing.Point(497, 375);
            this.labUnitInStockRight.Name = "labUnitInStockRight";
            this.labUnitInStockRight.Size = new System.Drawing.Size(54, 27);
            this.labUnitInStockRight.TabIndex = 14;
            this.labUnitInStockRight.Text = "庫存";
            // 
            // labUnitInStockLeft
            // 
            this.labUnitInStockLeft.AutoSize = true;
            this.labUnitInStockLeft.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labUnitInStockLeft.Location = new System.Drawing.Point(374, 375);
            this.labUnitInStockLeft.Name = "labUnitInStockLeft";
            this.labUnitInStockLeft.Size = new System.Drawing.Size(59, 27);
            this.labUnitInStockLeft.TabIndex = 13;
            this.labUnitInStockLeft.Text = "庫存:";
            // 
            // labUnitPriceRight
            // 
            this.labUnitPriceRight.AutoSize = true;
            this.labUnitPriceRight.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labUnitPriceRight.Location = new System.Drawing.Point(497, 332);
            this.labUnitPriceRight.Name = "labUnitPriceRight";
            this.labUnitPriceRight.Size = new System.Drawing.Size(54, 27);
            this.labUnitPriceRight.TabIndex = 12;
            this.labUnitPriceRight.Text = "定價";
            // 
            // labUnitPriceLeft
            // 
            this.labUnitPriceLeft.AutoSize = true;
            this.labUnitPriceLeft.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labUnitPriceLeft.Location = new System.Drawing.Point(374, 332);
            this.labUnitPriceLeft.Name = "labUnitPriceLeft";
            this.labUnitPriceLeft.Size = new System.Drawing.Size(59, 27);
            this.labUnitPriceLeft.TabIndex = 11;
            this.labUnitPriceLeft.Text = "定價:";
            // 
            // labCategoryRight
            // 
            this.labCategoryRight.AutoSize = true;
            this.labCategoryRight.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labCategoryRight.Location = new System.Drawing.Point(497, 418);
            this.labCategoryRight.Name = "labCategoryRight";
            this.labCategoryRight.Size = new System.Drawing.Size(54, 27);
            this.labCategoryRight.TabIndex = 18;
            this.labCategoryRight.Text = "分類";
            // 
            // labPublisherNameRight
            // 
            this.labPublisherNameRight.AutoSize = true;
            this.labPublisherNameRight.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labPublisherNameRight.Location = new System.Drawing.Point(497, 161);
            this.labPublisherNameRight.Name = "labPublisherNameRight";
            this.labPublisherNameRight.Size = new System.Drawing.Size(75, 27);
            this.labPublisherNameRight.TabIndex = 20;
            this.labPublisherNameRight.Text = "出版社";
            // 
            // labPublisherNameLeft
            // 
            this.labPublisherNameLeft.AutoSize = true;
            this.labPublisherNameLeft.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labPublisherNameLeft.Location = new System.Drawing.Point(374, 160);
            this.labPublisherNameLeft.Name = "labPublisherNameLeft";
            this.labPublisherNameLeft.Size = new System.Drawing.Size(80, 27);
            this.labPublisherNameLeft.TabIndex = 19;
            this.labPublisherNameLeft.Text = "出版社:";
            // 
            // btn_addchart
            // 
            this.btn_addchart.FlatAppearance.BorderSize = 0;
            this.btn_addchart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addchart.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_addchart.Location = new System.Drawing.Point(213, 435);
            this.btn_addchart.Name = "btn_addchart";
            this.btn_addchart.Size = new System.Drawing.Size(86, 30);
            this.btn_addchart.TabIndex = 21;
            this.btn_addchart.Text = "加入購物車";
            this.btn_addchart.UseVisualStyleBackColor = true;
            this.btn_addchart.Visible = false;
            this.btn_addchart.Click += new System.EventHandler(this.btn_addchart_Click);
            // 
            // btn_addauthor
            // 
            this.btn_addauthor.FlatAppearance.BorderSize = 0;
            this.btn_addauthor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addauthor.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_addauthor.Location = new System.Drawing.Point(127, 397);
            this.btn_addauthor.Name = "btn_addauthor";
            this.btn_addauthor.Size = new System.Drawing.Size(86, 30);
            this.btn_addauthor.TabIndex = 22;
            this.btn_addauthor.Text = "關注作者";
            this.btn_addauthor.UseVisualStyleBackColor = true;
            this.btn_addauthor.Visible = false;
            this.btn_addauthor.Click += new System.EventHandler(this.btn_addauthor_Click);
            // 
            // btn_addpub
            // 
            this.btn_addpub.FlatAppearance.BorderSize = 0;
            this.btn_addpub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addpub.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_addpub.Location = new System.Drawing.Point(35, 397);
            this.btn_addpub.Name = "btn_addpub";
            this.btn_addpub.Size = new System.Drawing.Size(86, 30);
            this.btn_addpub.TabIndex = 23;
            this.btn_addpub.Text = "關注出版社";
            this.btn_addpub.UseVisualStyleBackColor = true;
            this.btn_addpub.Visible = false;
            this.btn_addpub.Click += new System.EventHandler(this.btn_addpub_Click);
            // 
            // btn_comment
            // 
            this.btn_comment.FlatAppearance.BorderSize = 0;
            this.btn_comment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_comment.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_comment.Location = new System.Drawing.Point(213, 397);
            this.btn_comment.Name = "btn_comment";
            this.btn_comment.Size = new System.Drawing.Size(86, 30);
            this.btn_comment.TabIndex = 24;
            this.btn_comment.Text = "Commend";
            this.btn_comment.UseVisualStyleBackColor = true;
            this.btn_comment.Visible = false;
            this.btn_comment.Click += new System.EventHandler(this.btn_comment_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(192, 444);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "本";
            this.label1.Visible = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numericUpDown1.Location = new System.Drawing.Point(127, 439);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.ReadOnly = true;
            this.numericUpDown1.Size = new System.Drawing.Size(54, 25);
            this.numericUpDown1.TabIndex = 27;
            this.numericUpDown1.Visible = false;
            // 
            // Form_ShowBookInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(734, 526);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_comment);
            this.Controls.Add(this.btn_addpub);
            this.Controls.Add(this.btn_addauthor);
            this.Controls.Add(this.btn_addchart);
            this.Controls.Add(this.labPublisherNameRight);
            this.Controls.Add(this.labPublisherNameLeft);
            this.Controls.Add(this.labCategoryRight);
            this.Controls.Add(this.labLanguageRight);
            this.Controls.Add(this.labLanguageLeft);
            this.Controls.Add(this.labCategoryLeft);
            this.Controls.Add(this.labUnitInStockRight);
            this.Controls.Add(this.labUnitInStockLeft);
            this.Controls.Add(this.labUnitPriceRight);
            this.Controls.Add(this.labUnitPriceLeft);
            this.Controls.Add(this.labPublicateDateRight);
            this.Controls.Add(this.labPagesRight);
            this.Controls.Add(this.labPagesLeft);
            this.Controls.Add(this.labPublicateDateLeft);
            this.Controls.Add(this.labISBNRight);
            this.Controls.Add(this.labISBNLeft);
            this.Controls.Add(this.labAuthorRight);
            this.Controls.Add(this.labAuthorLeft);
            this.Controls.Add(this.labBookTitle);
            this.Controls.Add(this.picBook);
            this.Name = "Form_ShowBookInformation";
            this.Text = "BookInformation";
            ((System.ComponentModel.ISupportInitialize)(this.picBook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox picBook;
        private System.Windows.Forms.Label labBookTitle;
        private System.Windows.Forms.Label labAuthorLeft;
        private System.Windows.Forms.Label labAuthorRight;
        private System.Windows.Forms.Label labISBNRight;
        private System.Windows.Forms.Label labISBNLeft;
        private System.Windows.Forms.Label labPublicateDateLeft;
        private System.Windows.Forms.Label labPagesRight;
        private System.Windows.Forms.Label labPagesLeft;
        private System.Windows.Forms.Label labPublicateDateRight;
        private System.Windows.Forms.Label labLanguageRight;
        private System.Windows.Forms.Label labLanguageLeft;
        private System.Windows.Forms.Label labCategoryLeft;
        private System.Windows.Forms.Label labUnitInStockRight;
        private System.Windows.Forms.Label labUnitInStockLeft;
        private System.Windows.Forms.Label labUnitPriceRight;
        private System.Windows.Forms.Label labUnitPriceLeft;
        private System.Windows.Forms.Label labCategoryRight;
        private System.Windows.Forms.Label labPublisherNameRight;
        private System.Windows.Forms.Label labPublisherNameLeft;
        private System.Windows.Forms.Button btn_addchart;
        private System.Windows.Forms.Button btn_addauthor;
        private System.Windows.Forms.Button btn_addpub;
        private System.Windows.Forms.Button btn_comment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}