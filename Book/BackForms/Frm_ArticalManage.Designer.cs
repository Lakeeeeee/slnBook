namespace Book.BackForms
{
    partial class Frm_ArticalManage
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
            System.Windows.Forms.Label articalIDLabel;
            System.Windows.Forms.Label articalDateLabel;
            System.Windows.Forms.Label articalTitleLabel;
            System.Windows.Forms.Label articalDetailLabel;
            System.Windows.Forms.Label articalPictureLabel;
            System.Windows.Forms.Label articalDetailIDLabel;
            System.Windows.Forms.Label articalIDLabel1;
            System.Windows.Forms.Label bookIDLabel;
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.articalIDTextBox = new System.Windows.Forms.TextBox();
            this.articalDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.articalTitleTextBox = new System.Windows.Forms.TextBox();
            this.articalDetailTextBox = new System.Windows.Forms.TextBox();
            this.articalPicturePictureBox = new System.Windows.Forms.PictureBox();
            this.dgvArtical = new System.Windows.Forms.DataGridView();
            this.bookIDTextBox = new System.Windows.Forms.TextBox();
            this.btnDeleteAD = new System.Windows.Forms.Button();
            this.cmbBTitle = new System.Windows.Forms.ComboBox();
            this.cmbISBN = new System.Windows.Forms.ComboBox();
            this.cmbATitle = new System.Windows.Forms.ComboBox();
            this.btnInsertAD = new System.Windows.Forms.Button();
            this.btnUpdateAD = new System.Windows.Forms.Button();
            this.articalDetailIDTextBox = new System.Windows.Forms.TextBox();
            this.articalIDTextBox1 = new System.Windows.Forms.TextBox();
            this.dgvADetail = new System.Windows.Forms.DataGridView();
            articalIDLabel = new System.Windows.Forms.Label();
            articalDateLabel = new System.Windows.Forms.Label();
            articalTitleLabel = new System.Windows.Forms.Label();
            articalDetailLabel = new System.Windows.Forms.Label();
            articalPictureLabel = new System.Windows.Forms.Label();
            articalDetailIDLabel = new System.Windows.Forms.Label();
            articalIDLabel1 = new System.Windows.Forms.Label();
            bookIDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.articalPicturePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvADetail)).BeginInit();
            this.SuspendLayout();
            // 
            // articalIDLabel
            // 
            articalIDLabel.AutoSize = true;
            articalIDLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            articalIDLabel.Location = new System.Drawing.Point(13, 25);
            articalIDLabel.Name = "articalIDLabel";
            articalIDLabel.Size = new System.Drawing.Size(103, 21);
            articalIDLabel.TabIndex = 1;
            articalIDLabel.Text = "Artical ID：";
            // 
            // articalDateLabel
            // 
            articalDateLabel.AutoSize = true;
            articalDateLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            articalDateLabel.Location = new System.Drawing.Point(13, 61);
            articalDateLabel.Name = "articalDateLabel";
            articalDateLabel.Size = new System.Drawing.Size(118, 21);
            articalDateLabel.TabIndex = 3;
            articalDateLabel.Text = "Artical Date：";
            // 
            // articalTitleLabel
            // 
            articalTitleLabel.AutoSize = true;
            articalTitleLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            articalTitleLabel.Location = new System.Drawing.Point(13, 95);
            articalTitleLabel.Name = "articalTitleLabel";
            articalTitleLabel.Size = new System.Drawing.Size(116, 21);
            articalTitleLabel.TabIndex = 5;
            articalTitleLabel.Text = "Artical Title：";
            // 
            // articalDetailLabel
            // 
            articalDetailLabel.AutoSize = true;
            articalDetailLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            articalDetailLabel.Location = new System.Drawing.Point(13, 188);
            articalDetailLabel.Name = "articalDetailLabel";
            articalDetailLabel.Size = new System.Drawing.Size(170, 21);
            articalDetailLabel.TabIndex = 7;
            articalDetailLabel.Text = "Artical Description：";
            // 
            // articalPictureLabel
            // 
            articalPictureLabel.AutoSize = true;
            articalPictureLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            articalPictureLabel.Location = new System.Drawing.Point(377, 25);
            articalPictureLabel.Name = "articalPictureLabel";
            articalPictureLabel.Size = new System.Drawing.Size(136, 21);
            articalPictureLabel.TabIndex = 9;
            articalPictureLabel.Text = "Artical Picture：";
            // 
            // articalDetailIDLabel
            // 
            articalDetailIDLabel.AutoSize = true;
            articalDetailIDLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            articalDetailIDLabel.Location = new System.Drawing.Point(11, 46);
            articalDetailIDLabel.Name = "articalDetailIDLabel";
            articalDetailIDLabel.Size = new System.Drawing.Size(150, 21);
            articalDetailIDLabel.TabIndex = 1;
            articalDetailIDLabel.Text = "Artical Detail ID：";
            // 
            // articalIDLabel1
            // 
            articalIDLabel1.AutoSize = true;
            articalIDLabel1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            articalIDLabel1.Location = new System.Drawing.Point(12, 87);
            articalIDLabel1.Name = "articalIDLabel1";
            articalIDLabel1.Size = new System.Drawing.Size(150, 21);
            articalIDLabel1.TabIndex = 3;
            articalIDLabel1.Text = "Artical ID / Title：";
            // 
            // bookIDLabel
            // 
            bookIDLabel.AutoSize = true;
            bookIDLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            bookIDLabel.Location = new System.Drawing.Point(11, 198);
            bookIDLabel.Name = "bookIDLabel";
            bookIDLabel.Size = new System.Drawing.Size(199, 21);
            bookIDLabel.TabIndex = 5;
            bookIDLabel.Text = "Book ID / ISBN / Title：";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.AutoScroll = true;
            this.splitContainer3.Panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.splitContainer3.Panel1.Controls.Add(this.btnDelete);
            this.splitContainer3.Panel1.Controls.Add(this.btnInsert);
            this.splitContainer3.Panel1.Controls.Add(this.btnUpdate);
            this.splitContainer3.Panel1.Controls.Add(this.btnBrowse);
            this.splitContainer3.Panel1.Controls.Add(articalIDLabel);
            this.splitContainer3.Panel1.Controls.Add(this.articalIDTextBox);
            this.splitContainer3.Panel1.Controls.Add(articalDateLabel);
            this.splitContainer3.Panel1.Controls.Add(this.articalDateDateTimePicker);
            this.splitContainer3.Panel1.Controls.Add(articalTitleLabel);
            this.splitContainer3.Panel1.Controls.Add(this.articalTitleTextBox);
            this.splitContainer3.Panel1.Controls.Add(articalDetailLabel);
            this.splitContainer3.Panel1.Controls.Add(this.articalDetailTextBox);
            this.splitContainer3.Panel1.Controls.Add(articalPictureLabel);
            this.splitContainer3.Panel1.Controls.Add(this.articalPicturePictureBox);
            this.splitContainer3.Panel1.Controls.Add(this.dgvArtical);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.AutoScroll = true;
            this.splitContainer3.Panel2.BackColor = System.Drawing.Color.GhostWhite;
            this.splitContainer3.Panel2.Controls.Add(this.bookIDTextBox);
            this.splitContainer3.Panel2.Controls.Add(this.btnDeleteAD);
            this.splitContainer3.Panel2.Controls.Add(this.cmbBTitle);
            this.splitContainer3.Panel2.Controls.Add(this.cmbISBN);
            this.splitContainer3.Panel2.Controls.Add(this.cmbATitle);
            this.splitContainer3.Panel2.Controls.Add(this.btnInsertAD);
            this.splitContainer3.Panel2.Controls.Add(articalDetailIDLabel);
            this.splitContainer3.Panel2.Controls.Add(this.btnUpdateAD);
            this.splitContainer3.Panel2.Controls.Add(this.articalDetailIDTextBox);
            this.splitContainer3.Panel2.Controls.Add(articalIDLabel1);
            this.splitContainer3.Panel2.Controls.Add(this.articalIDTextBox1);
            this.splitContainer3.Panel2.Controls.Add(bookIDLabel);
            this.splitContainer3.Panel2.Controls.Add(this.dgvADetail);
            this.splitContainer3.Size = new System.Drawing.Size(1184, 567);
            this.splitContainer3.SplitterDistance = 820;
            this.splitContainer3.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(665, 302);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 30);
            this.btnDelete.TabIndex = 116;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.Location = new System.Drawing.Point(405, 302);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(4);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(90, 30);
            this.btnInsert.TabIndex = 115;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(535, 302);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(90, 30);
            this.btnUpdate.TabIndex = 114;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.Ivory;
            this.btnBrowse.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(665, 226);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(90, 30);
            this.btnBrowse.TabIndex = 17;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // articalIDTextBox
            // 
            this.articalIDTextBox.Enabled = false;
            this.articalIDTextBox.Location = new System.Drawing.Point(137, 22);
            this.articalIDTextBox.Name = "articalIDTextBox";
            this.articalIDTextBox.Size = new System.Drawing.Size(200, 29);
            this.articalIDTextBox.TabIndex = 2;
            // 
            // articalDateDateTimePicker
            // 
            this.articalDateDateTimePicker.Location = new System.Drawing.Point(137, 57);
            this.articalDateDateTimePicker.Name = "articalDateDateTimePicker";
            this.articalDateDateTimePicker.Size = new System.Drawing.Size(200, 29);
            this.articalDateDateTimePicker.TabIndex = 4;
            // 
            // articalTitleTextBox
            // 
            this.articalTitleTextBox.Location = new System.Drawing.Point(37, 118);
            this.articalTitleTextBox.Multiline = true;
            this.articalTitleTextBox.Name = "articalTitleTextBox";
            this.articalTitleTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.articalTitleTextBox.Size = new System.Drawing.Size(300, 45);
            this.articalTitleTextBox.TabIndex = 6;
            // 
            // articalDetailTextBox
            // 
            this.articalDetailTextBox.Location = new System.Drawing.Point(37, 212);
            this.articalDetailTextBox.Multiline = true;
            this.articalDetailTextBox.Name = "articalDetailTextBox";
            this.articalDetailTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.articalDetailTextBox.Size = new System.Drawing.Size(300, 120);
            this.articalDetailTextBox.TabIndex = 8;
            // 
            // articalPicturePictureBox
            // 
            this.articalPicturePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.articalPicturePictureBox.Location = new System.Drawing.Point(405, 61);
            this.articalPicturePictureBox.Name = "articalPicturePictureBox";
            this.articalPicturePictureBox.Size = new System.Drawing.Size(350, 150);
            this.articalPicturePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.articalPicturePictureBox.TabIndex = 10;
            this.articalPicturePictureBox.TabStop = false;
            // 
            // dgvArtical
            // 
            this.dgvArtical.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvArtical.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvArtical.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArtical.Location = new System.Drawing.Point(0, 377);
            this.dgvArtical.Name = "dgvArtical";
            this.dgvArtical.RowHeadersWidth = 51;
            this.dgvArtical.RowTemplate.Height = 24;
            this.dgvArtical.Size = new System.Drawing.Size(816, 186);
            this.dgvArtical.TabIndex = 0;
            this.dgvArtical.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArtical_CellClick);
            // 
            // bookIDTextBox
            // 
            this.bookIDTextBox.Location = new System.Drawing.Point(197, 193);
            this.bookIDTextBox.Name = "bookIDTextBox";
            this.bookIDTextBox.Size = new System.Drawing.Size(100, 29);
            this.bookIDTextBox.TabIndex = 6;
            // 
            // btnDeleteAD
            // 
            this.btnDeleteAD.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteAD.Location = new System.Drawing.Point(262, 330);
            this.btnDeleteAD.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteAD.Name = "btnDeleteAD";
            this.btnDeleteAD.Size = new System.Drawing.Size(90, 30);
            this.btnDeleteAD.TabIndex = 122;
            this.btnDeleteAD.Text = "Delete";
            this.btnDeleteAD.UseVisualStyleBackColor = true;
            this.btnDeleteAD.Click += new System.EventHandler(this.btnDeleteAD_Click);
            // 
            // cmbBTitle
            // 
            this.cmbBTitle.FormattingEnabled = true;
            this.cmbBTitle.Location = new System.Drawing.Point(42, 262);
            this.cmbBTitle.Name = "cmbBTitle";
            this.cmbBTitle.Size = new System.Drawing.Size(300, 28);
            this.cmbBTitle.TabIndex = 10;
            this.cmbBTitle.SelectedIndexChanged += new System.EventHandler(this.cmbBTitle_SelectedIndexChanged);
            // 
            // cmbISBN
            // 
            this.cmbISBN.FormattingEnabled = true;
            this.cmbISBN.Location = new System.Drawing.Point(42, 228);
            this.cmbISBN.Name = "cmbISBN";
            this.cmbISBN.Size = new System.Drawing.Size(300, 28);
            this.cmbISBN.TabIndex = 9;
            this.cmbISBN.SelectedIndexChanged += new System.EventHandler(this.cmbISBN_SelectedIndexChanged);
            // 
            // cmbATitle
            // 
            this.cmbATitle.FormattingEnabled = true;
            this.cmbATitle.Location = new System.Drawing.Point(45, 119);
            this.cmbATitle.Name = "cmbATitle";
            this.cmbATitle.Size = new System.Drawing.Size(300, 28);
            this.cmbATitle.TabIndex = 8;
            this.cmbATitle.SelectedIndexChanged += new System.EventHandler(this.cmbATitle_SelectedIndexChanged);
            // 
            // btnInsertAD
            // 
            this.btnInsertAD.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertAD.Location = new System.Drawing.Point(4, 330);
            this.btnInsertAD.Margin = new System.Windows.Forms.Padding(4);
            this.btnInsertAD.Name = "btnInsertAD";
            this.btnInsertAD.Size = new System.Drawing.Size(90, 30);
            this.btnInsertAD.TabIndex = 120;
            this.btnInsertAD.Text = "Insert";
            this.btnInsertAD.UseVisualStyleBackColor = true;
            this.btnInsertAD.Click += new System.EventHandler(this.btnInsertAD_Click);
            // 
            // btnUpdateAD
            // 
            this.btnUpdateAD.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateAD.Location = new System.Drawing.Point(133, 330);
            this.btnUpdateAD.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateAD.Name = "btnUpdateAD";
            this.btnUpdateAD.Size = new System.Drawing.Size(90, 30);
            this.btnUpdateAD.TabIndex = 118;
            this.btnUpdateAD.Text = "Update";
            this.btnUpdateAD.UseVisualStyleBackColor = true;
            this.btnUpdateAD.Click += new System.EventHandler(this.btnUpdateAD_Click);
            // 
            // articalDetailIDTextBox
            // 
            this.articalDetailIDTextBox.Enabled = false;
            this.articalDetailIDTextBox.Location = new System.Drawing.Point(197, 43);
            this.articalDetailIDTextBox.Name = "articalDetailIDTextBox";
            this.articalDetailIDTextBox.Size = new System.Drawing.Size(100, 29);
            this.articalDetailIDTextBox.TabIndex = 2;
            // 
            // articalIDTextBox1
            // 
            this.articalIDTextBox1.Location = new System.Drawing.Point(197, 84);
            this.articalIDTextBox1.Name = "articalIDTextBox1";
            this.articalIDTextBox1.Size = new System.Drawing.Size(100, 29);
            this.articalIDTextBox1.TabIndex = 4;
            // 
            // dgvADetail
            // 
            this.dgvADetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvADetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvADetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvADetail.Location = new System.Drawing.Point(0, 381);
            this.dgvADetail.Name = "dgvADetail";
            this.dgvADetail.RowHeadersWidth = 51;
            this.dgvADetail.RowTemplate.Height = 24;
            this.dgvADetail.Size = new System.Drawing.Size(356, 182);
            this.dgvADetail.TabIndex = 0;
            this.dgvADetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvADetail_CellClick);
            // 
            // Frm_ArticalManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 567);
            this.Controls.Add(this.splitContainer3);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Frm_ArticalManage";
            this.Text = "Frm_ArticalManage";
            this.Load += new System.EventHandler(this.Frm_ArticalManage_Load);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.articalPicturePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvADetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox articalIDTextBox;
        private System.Windows.Forms.DateTimePicker articalDateDateTimePicker;
        private System.Windows.Forms.TextBox articalTitleTextBox;
        private System.Windows.Forms.TextBox articalDetailTextBox;
        private System.Windows.Forms.PictureBox articalPicturePictureBox;
        private System.Windows.Forms.DataGridView dgvArtical;
        private System.Windows.Forms.TextBox bookIDTextBox;
        private System.Windows.Forms.Button btnDeleteAD;
        private System.Windows.Forms.ComboBox cmbBTitle;
        private System.Windows.Forms.ComboBox cmbISBN;
        private System.Windows.Forms.ComboBox cmbATitle;
        private System.Windows.Forms.Button btnInsertAD;
        private System.Windows.Forms.Button btnUpdateAD;
        private System.Windows.Forms.TextBox articalDetailIDTextBox;
        private System.Windows.Forms.TextBox articalIDTextBox1;
        private System.Windows.Forms.DataGridView dgvADetail;
    }
}