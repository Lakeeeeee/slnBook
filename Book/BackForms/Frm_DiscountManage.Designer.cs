namespace Book.BackForms
{
    partial class Frm_DiscountManage
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
            System.Windows.Forms.Label discountIDLabel;
            System.Windows.Forms.Label discountNameLabel;
            System.Windows.Forms.Label discounDescriptionLabel;
            System.Windows.Forms.Label discountAmountLabel;
            System.Windows.Forms.Label startDateLabel;
            System.Windows.Forms.Label endDateLabel;
            System.Windows.Forms.Label isActiveLabel;
            System.Windows.Forms.Label discountDetailIDLabel;
            System.Windows.Forms.Label discountIDLabel1;
            System.Windows.Forms.Label categoryIDLabel;
            System.Windows.Forms.Label label2;
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dgvDiscount = new System.Windows.Forms.DataGridView();
            this.discountIDTextBox = new System.Windows.Forms.TextBox();
            this.discountNameTextBox = new System.Windows.Forms.TextBox();
            this.discounDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.discountAmountTextBox = new System.Windows.Forms.TextBox();
            this.startDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.isActiveTextBox = new System.Windows.Forms.TextBox();
            this.btnDDelete = new System.Windows.Forms.Button();
            this.btnDInsert = new System.Windows.Forms.Button();
            this.btnDUpdate = new System.Windows.Forms.Button();
            this.cmbDName = new System.Windows.Forms.ComboBox();
            this.cmbBTitle = new System.Windows.Forms.ComboBox();
            this.cmbISBN = new System.Windows.Forms.ComboBox();
            this.dgvDiscountDetail = new System.Windows.Forms.DataGridView();
            this.discountDetailIDTextBox = new System.Windows.Forms.TextBox();
            this.discountIDTextBox1 = new System.Windows.Forms.TextBox();
            this.bookIDTextBox = new System.Windows.Forms.TextBox();
            this.categoryIDTextBox = new System.Windows.Forms.TextBox();
            this.btnDeleteDD = new System.Windows.Forms.Button();
            this.btnInsertDD = new System.Windows.Forms.Button();
            this.btnUpdateDD = new System.Windows.Forms.Button();
            discountIDLabel = new System.Windows.Forms.Label();
            discountNameLabel = new System.Windows.Forms.Label();
            discounDescriptionLabel = new System.Windows.Forms.Label();
            discountAmountLabel = new System.Windows.Forms.Label();
            startDateLabel = new System.Windows.Forms.Label();
            endDateLabel = new System.Windows.Forms.Label();
            isActiveLabel = new System.Windows.Forms.Label();
            discountDetailIDLabel = new System.Windows.Forms.Label();
            discountIDLabel1 = new System.Windows.Forms.Label();
            categoryIDLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscountDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // discountIDLabel
            // 
            discountIDLabel.AutoSize = true;
            discountIDLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            discountIDLabel.Location = new System.Drawing.Point(22, 32);
            discountIDLabel.Name = "discountIDLabel";
            discountIDLabel.Size = new System.Drawing.Size(121, 21);
            discountIDLabel.TabIndex = 116;
            discountIDLabel.Text = "Discount ID：";
            // 
            // discountNameLabel
            // 
            discountNameLabel.AutoSize = true;
            discountNameLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            discountNameLabel.Location = new System.Drawing.Point(22, 66);
            discountNameLabel.Name = "discountNameLabel";
            discountNameLabel.Size = new System.Drawing.Size(145, 21);
            discountNameLabel.TabIndex = 118;
            discountNameLabel.Text = "Discount Name：";
            // 
            // discounDescriptionLabel
            // 
            discounDescriptionLabel.AutoSize = true;
            discounDescriptionLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            discounDescriptionLabel.Location = new System.Drawing.Point(22, 99);
            discounDescriptionLabel.Name = "discounDescriptionLabel";
            discounDescriptionLabel.Size = new System.Drawing.Size(183, 21);
            discounDescriptionLabel.TabIndex = 120;
            discounDescriptionLabel.Text = "Discoun Description：";
            // 
            // discountAmountLabel
            // 
            discountAmountLabel.AutoSize = true;
            discountAmountLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            discountAmountLabel.Location = new System.Drawing.Point(22, 132);
            discountAmountLabel.Name = "discountAmountLabel";
            discountAmountLabel.Size = new System.Drawing.Size(161, 21);
            discountAmountLabel.TabIndex = 122;
            discountAmountLabel.Text = "Discount Amount：";
            // 
            // startDateLabel
            // 
            startDateLabel.AutoSize = true;
            startDateLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            startDateLabel.Location = new System.Drawing.Point(22, 166);
            startDateLabel.Name = "startDateLabel";
            startDateLabel.Size = new System.Drawing.Size(104, 21);
            startDateLabel.TabIndex = 124;
            startDateLabel.Text = "Start Date：";
            // 
            // endDateLabel
            // 
            endDateLabel.AutoSize = true;
            endDateLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            endDateLabel.Location = new System.Drawing.Point(22, 200);
            endDateLabel.Name = "endDateLabel";
            endDateLabel.Size = new System.Drawing.Size(99, 21);
            endDateLabel.TabIndex = 126;
            endDateLabel.Text = "End Date：";
            // 
            // isActiveLabel
            // 
            isActiveLabel.AutoSize = true;
            isActiveLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            isActiveLabel.ForeColor = System.Drawing.Color.Black;
            isActiveLabel.Location = new System.Drawing.Point(22, 232);
            isActiveLabel.Name = "isActiveLabel";
            isActiveLabel.Size = new System.Drawing.Size(96, 21);
            isActiveLabel.TabIndex = 128;
            isActiveLabel.Text = "Is Active：";
            // 
            // discountDetailIDLabel
            // 
            discountDetailIDLabel.AutoSize = true;
            discountDetailIDLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            discountDetailIDLabel.Location = new System.Drawing.Point(18, 32);
            discountDetailIDLabel.Name = "discountDetailIDLabel";
            discountDetailIDLabel.Size = new System.Drawing.Size(168, 21);
            discountDetailIDLabel.TabIndex = 122;
            discountDetailIDLabel.Text = "Discount Detail ID：";
            // 
            // discountIDLabel1
            // 
            discountIDLabel1.AutoSize = true;
            discountIDLabel1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            discountIDLabel1.Location = new System.Drawing.Point(19, 66);
            discountIDLabel1.Name = "discountIDLabel1";
            discountIDLabel1.Size = new System.Drawing.Size(179, 21);
            discountIDLabel1.TabIndex = 124;
            discountIDLabel1.Text = "Discount ID / Name：";
            // 
            // categoryIDLabel
            // 
            categoryIDLabel.AutoSize = true;
            categoryIDLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            categoryIDLabel.ForeColor = System.Drawing.Color.Black;
            categoryIDLabel.Location = new System.Drawing.Point(19, 232);
            categoryIDLabel.Name = "categoryIDLabel";
            categoryIDLabel.Size = new System.Drawing.Size(122, 21);
            categoryIDLabel.TabIndex = 128;
            categoryIDLabel.Text = "Category ID：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(19, 132);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(199, 21);
            label2.TabIndex = 131;
            label2.Text = "Book ID / ISBN / Title：";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(872, 542);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 230);
            this.label1.TabIndex = 16;
            this.label1.Text = "優惠管理頁面\r\n1.  新增刪修優惠活動\r\n2.  可套用優惠至書籍\r\n3.  等等等";
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
            this.splitContainer3.Panel1.BackColor = System.Drawing.Color.Lavender;
            this.splitContainer3.Panel1.Controls.Add(this.dgvDiscount);
            this.splitContainer3.Panel1.Controls.Add(discountIDLabel);
            this.splitContainer3.Panel1.Controls.Add(this.discountIDTextBox);
            this.splitContainer3.Panel1.Controls.Add(discountNameLabel);
            this.splitContainer3.Panel1.Controls.Add(this.discountNameTextBox);
            this.splitContainer3.Panel1.Controls.Add(discounDescriptionLabel);
            this.splitContainer3.Panel1.Controls.Add(this.discounDescriptionTextBox);
            this.splitContainer3.Panel1.Controls.Add(discountAmountLabel);
            this.splitContainer3.Panel1.Controls.Add(this.discountAmountTextBox);
            this.splitContainer3.Panel1.Controls.Add(startDateLabel);
            this.splitContainer3.Panel1.Controls.Add(this.startDateDateTimePicker);
            this.splitContainer3.Panel1.Controls.Add(endDateLabel);
            this.splitContainer3.Panel1.Controls.Add(this.endDateDateTimePicker);
            this.splitContainer3.Panel1.Controls.Add(isActiveLabel);
            this.splitContainer3.Panel1.Controls.Add(this.isActiveTextBox);
            this.splitContainer3.Panel1.Controls.Add(this.btnDDelete);
            this.splitContainer3.Panel1.Controls.Add(this.btnDInsert);
            this.splitContainer3.Panel1.Controls.Add(this.btnDUpdate);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.AutoScroll = true;
            this.splitContainer3.Panel2.BackColor = System.Drawing.Color.LavenderBlush;
            this.splitContainer3.Panel2.Controls.Add(this.cmbDName);
            this.splitContainer3.Panel2.Controls.Add(this.cmbBTitle);
            this.splitContainer3.Panel2.Controls.Add(this.cmbISBN);
            this.splitContainer3.Panel2.Controls.Add(label2);
            this.splitContainer3.Panel2.Controls.Add(this.dgvDiscountDetail);
            this.splitContainer3.Panel2.Controls.Add(discountDetailIDLabel);
            this.splitContainer3.Panel2.Controls.Add(this.discountDetailIDTextBox);
            this.splitContainer3.Panel2.Controls.Add(discountIDLabel1);
            this.splitContainer3.Panel2.Controls.Add(this.discountIDTextBox1);
            this.splitContainer3.Panel2.Controls.Add(this.bookIDTextBox);
            this.splitContainer3.Panel2.Controls.Add(categoryIDLabel);
            this.splitContainer3.Panel2.Controls.Add(this.categoryIDTextBox);
            this.splitContainer3.Panel2.Controls.Add(this.btnDeleteDD);
            this.splitContainer3.Panel2.Controls.Add(this.btnInsertDD);
            this.splitContainer3.Panel2.Controls.Add(this.btnUpdateDD);
            this.splitContainer3.Size = new System.Drawing.Size(864, 536);
            this.splitContainer3.SplitterDistance = 463;
            this.splitContainer3.TabIndex = 17;
            // 
            // dgvDiscount
            // 
            this.dgvDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDiscount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDiscount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiscount.Location = new System.Drawing.Point(-2, 310);
            this.dgvDiscount.Name = "dgvDiscount";
            this.dgvDiscount.RowHeadersWidth = 51;
            this.dgvDiscount.RowTemplate.Height = 24;
            this.dgvDiscount.Size = new System.Drawing.Size(462, 224);
            this.dgvDiscount.TabIndex = 130;
            this.dgvDiscount.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDiscount_CellClick);
            // 
            // discountIDTextBox
            // 
            this.discountIDTextBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discountIDTextBox.Location = new System.Drawing.Point(206, 29);
            this.discountIDTextBox.Name = "discountIDTextBox";
            this.discountIDTextBox.ReadOnly = true;
            this.discountIDTextBox.Size = new System.Drawing.Size(180, 29);
            this.discountIDTextBox.TabIndex = 117;
            // 
            // discountNameTextBox
            // 
            this.discountNameTextBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discountNameTextBox.Location = new System.Drawing.Point(206, 63);
            this.discountNameTextBox.Name = "discountNameTextBox";
            this.discountNameTextBox.Size = new System.Drawing.Size(180, 29);
            this.discountNameTextBox.TabIndex = 119;
            // 
            // discounDescriptionTextBox
            // 
            this.discounDescriptionTextBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discounDescriptionTextBox.Location = new System.Drawing.Point(206, 96);
            this.discounDescriptionTextBox.Name = "discounDescriptionTextBox";
            this.discounDescriptionTextBox.Size = new System.Drawing.Size(180, 29);
            this.discounDescriptionTextBox.TabIndex = 121;
            // 
            // discountAmountTextBox
            // 
            this.discountAmountTextBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discountAmountTextBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.discountAmountTextBox.Location = new System.Drawing.Point(206, 129);
            this.discountAmountTextBox.Name = "discountAmountTextBox";
            this.discountAmountTextBox.Size = new System.Drawing.Size(180, 29);
            this.discountAmountTextBox.TabIndex = 123;
            this.discountAmountTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.discountAmountTextBox_KeyPress);
            // 
            // startDateDateTimePicker
            // 
            this.startDateDateTimePicker.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDateDateTimePicker.Location = new System.Drawing.Point(206, 162);
            this.startDateDateTimePicker.Name = "startDateDateTimePicker";
            this.startDateDateTimePicker.Size = new System.Drawing.Size(180, 29);
            this.startDateDateTimePicker.TabIndex = 125;
            // 
            // endDateDateTimePicker
            // 
            this.endDateDateTimePicker.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endDateDateTimePicker.Location = new System.Drawing.Point(206, 196);
            this.endDateDateTimePicker.Name = "endDateDateTimePicker";
            this.endDateDateTimePicker.Size = new System.Drawing.Size(180, 29);
            this.endDateDateTimePicker.TabIndex = 127;
            // 
            // isActiveTextBox
            // 
            this.isActiveTextBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isActiveTextBox.Location = new System.Drawing.Point(206, 229);
            this.isActiveTextBox.Name = "isActiveTextBox";
            this.isActiveTextBox.ReadOnly = true;
            this.isActiveTextBox.Size = new System.Drawing.Size(180, 29);
            this.isActiveTextBox.TabIndex = 129;
            // 
            // btnDDelete
            // 
            this.btnDDelete.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDDelete.Location = new System.Drawing.Point(304, 275);
            this.btnDDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDDelete.Name = "btnDDelete";
            this.btnDDelete.Size = new System.Drawing.Size(81, 28);
            this.btnDDelete.TabIndex = 116;
            this.btnDDelete.Text = "Delete";
            this.btnDDelete.UseVisualStyleBackColor = true;
            this.btnDDelete.Click += new System.EventHandler(this.btnDDelete_Click);
            // 
            // btnDInsert
            // 
            this.btnDInsert.BackColor = System.Drawing.Color.Transparent;
            this.btnDInsert.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDInsert.Location = new System.Drawing.Point(26, 273);
            this.btnDInsert.Margin = new System.Windows.Forms.Padding(4);
            this.btnDInsert.Name = "btnDInsert";
            this.btnDInsert.Size = new System.Drawing.Size(81, 28);
            this.btnDInsert.TabIndex = 115;
            this.btnDInsert.Text = "Insert";
            this.btnDInsert.UseVisualStyleBackColor = false;
            this.btnDInsert.Click += new System.EventHandler(this.btnDInsert_Click);
            // 
            // btnDUpdate
            // 
            this.btnDUpdate.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDUpdate.Location = new System.Drawing.Point(165, 273);
            this.btnDUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnDUpdate.Name = "btnDUpdate";
            this.btnDUpdate.Size = new System.Drawing.Size(81, 28);
            this.btnDUpdate.TabIndex = 114;
            this.btnDUpdate.Text = "Update";
            this.btnDUpdate.UseVisualStyleBackColor = true;
            this.btnDUpdate.Click += new System.EventHandler(this.btnDUpdate_Click);
            // 
            // cmbDName
            // 
            this.cmbDName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDName.FormattingEnabled = true;
            this.cmbDName.Location = new System.Drawing.Point(101, 92);
            this.cmbDName.Name = "cmbDName";
            this.cmbDName.Size = new System.Drawing.Size(270, 29);
            this.cmbDName.TabIndex = 135;
            this.cmbDName.SelectedIndexChanged += new System.EventHandler(this.cmbDName_SelectedIndexChanged);
            // 
            // cmbBTitle
            // 
            this.cmbBTitle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBTitle.FormattingEnabled = true;
            this.cmbBTitle.Location = new System.Drawing.Point(101, 194);
            this.cmbBTitle.Name = "cmbBTitle";
            this.cmbBTitle.Size = new System.Drawing.Size(270, 29);
            this.cmbBTitle.TabIndex = 134;
            this.cmbBTitle.SelectedIndexChanged += new System.EventHandler(this.cmbBTitle_SelectedIndexChanged);
            // 
            // cmbISBN
            // 
            this.cmbISBN.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbISBN.FormattingEnabled = true;
            this.cmbISBN.Location = new System.Drawing.Point(101, 160);
            this.cmbISBN.Name = "cmbISBN";
            this.cmbISBN.Size = new System.Drawing.Size(270, 29);
            this.cmbISBN.TabIndex = 133;
            this.cmbISBN.SelectedIndexChanged += new System.EventHandler(this.cmbISBN_SelectedIndexChanged);
            // 
            // dgvDiscountDetail
            // 
            this.dgvDiscountDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDiscountDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDiscountDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiscountDetail.Location = new System.Drawing.Point(0, 308);
            this.dgvDiscountDetail.Name = "dgvDiscountDetail";
            this.dgvDiscountDetail.RowHeadersWidth = 51;
            this.dgvDiscountDetail.RowTemplate.Height = 24;
            this.dgvDiscountDetail.Size = new System.Drawing.Size(395, 224);
            this.dgvDiscountDetail.TabIndex = 130;
            this.dgvDiscountDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDiscountDetail_CellClick);
            // 
            // discountDetailIDTextBox
            // 
            this.discountDetailIDTextBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discountDetailIDTextBox.Location = new System.Drawing.Point(221, 24);
            this.discountDetailIDTextBox.Name = "discountDetailIDTextBox";
            this.discountDetailIDTextBox.ReadOnly = true;
            this.discountDetailIDTextBox.Size = new System.Drawing.Size(150, 29);
            this.discountDetailIDTextBox.TabIndex = 123;
            // 
            // discountIDTextBox1
            // 
            this.discountIDTextBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discountIDTextBox1.Location = new System.Drawing.Point(221, 58);
            this.discountIDTextBox1.Name = "discountIDTextBox1";
            this.discountIDTextBox1.Size = new System.Drawing.Size(150, 29);
            this.discountIDTextBox1.TabIndex = 125;
            // 
            // bookIDTextBox
            // 
            this.bookIDTextBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookIDTextBox.Location = new System.Drawing.Point(221, 126);
            this.bookIDTextBox.Name = "bookIDTextBox";
            this.bookIDTextBox.ReadOnly = true;
            this.bookIDTextBox.Size = new System.Drawing.Size(150, 29);
            this.bookIDTextBox.TabIndex = 127;
            // 
            // categoryIDTextBox
            // 
            this.categoryIDTextBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryIDTextBox.Location = new System.Drawing.Point(221, 228);
            this.categoryIDTextBox.Name = "categoryIDTextBox";
            this.categoryIDTextBox.ReadOnly = true;
            this.categoryIDTextBox.Size = new System.Drawing.Size(150, 29);
            this.categoryIDTextBox.TabIndex = 129;
            // 
            // btnDeleteDD
            // 
            this.btnDeleteDD.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteDD.Location = new System.Drawing.Point(281, 273);
            this.btnDeleteDD.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteDD.Name = "btnDeleteDD";
            this.btnDeleteDD.Size = new System.Drawing.Size(81, 28);
            this.btnDeleteDD.TabIndex = 122;
            this.btnDeleteDD.Text = "Delete";
            this.btnDeleteDD.UseVisualStyleBackColor = true;
            this.btnDeleteDD.Click += new System.EventHandler(this.btnDeleteDD_Click);
            // 
            // btnInsertDD
            // 
            this.btnInsertDD.BackColor = System.Drawing.Color.Transparent;
            this.btnInsertDD.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertDD.Location = new System.Drawing.Point(23, 275);
            this.btnInsertDD.Margin = new System.Windows.Forms.Padding(4);
            this.btnInsertDD.Name = "btnInsertDD";
            this.btnInsertDD.Size = new System.Drawing.Size(81, 28);
            this.btnInsertDD.TabIndex = 120;
            this.btnInsertDD.Text = "Insert";
            this.btnInsertDD.UseVisualStyleBackColor = false;
            this.btnInsertDD.Click += new System.EventHandler(this.btnInsertDD_Click);
            // 
            // btnUpdateDD
            // 
            this.btnUpdateDD.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateDD.Location = new System.Drawing.Point(152, 273);
            this.btnUpdateDD.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateDD.Name = "btnUpdateDD";
            this.btnUpdateDD.Size = new System.Drawing.Size(81, 28);
            this.btnUpdateDD.TabIndex = 118;
            this.btnUpdateDD.Text = "Update";
            this.btnUpdateDD.UseVisualStyleBackColor = true;
            this.btnUpdateDD.Click += new System.EventHandler(this.btnUpdateDD_Click);
            // 
            // Frm_DiscountManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 536);
            this.Controls.Add(this.splitContainer3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Frm_DiscountManage";
            this.Text = "Frm_Discount";
            this.Load += new System.EventHandler(this.Frm_DiscountManage_Load);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscountDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button btnDDelete;
        private System.Windows.Forms.Button btnDUpdate;
        private System.Windows.Forms.Button btnDeleteDD;
        private System.Windows.Forms.Button btnInsertDD;
        private System.Windows.Forms.Button btnUpdateDD;
        private System.Windows.Forms.Button btnDInsert;
        private System.Windows.Forms.TextBox discountIDTextBox;
        private System.Windows.Forms.TextBox discountNameTextBox;
        private System.Windows.Forms.TextBox discounDescriptionTextBox;
        private System.Windows.Forms.TextBox discountAmountTextBox;
        private System.Windows.Forms.DateTimePicker startDateDateTimePicker;
        private System.Windows.Forms.DateTimePicker endDateDateTimePicker;
        private System.Windows.Forms.TextBox isActiveTextBox;
        private System.Windows.Forms.TextBox discountDetailIDTextBox;
        private System.Windows.Forms.TextBox discountIDTextBox1;
        private System.Windows.Forms.TextBox bookIDTextBox;
        private System.Windows.Forms.TextBox categoryIDTextBox;
        private System.Windows.Forms.DataGridView dgvDiscount;
        private System.Windows.Forms.DataGridView dgvDiscountDetail;
        private System.Windows.Forms.ComboBox cmbBTitle;
        private System.Windows.Forms.ComboBox cmbISBN;
        private System.Windows.Forms.ComboBox cmbDName;
    }
}