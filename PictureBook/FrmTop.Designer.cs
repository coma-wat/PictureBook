namespace PictureBook
{
    partial class FrmTop
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlBody = new Panel();
            txtKeyWord = new TextBox();
            txtName = new TextBox();
            txtGenus = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtFamily = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            dgvMain = new DataGridView();
            pnlFooter = new Panel();
            btnNewReg = new Button();
            btnDelete = new Button();
            btnView = new Button();
            btnSelect = new Button();
            btnClose = new Button();
            選択 = new DataGridViewCheckBoxColumn();
            名称 = new DataGridViewTextBoxColumn();
            科 = new DataGridViewTextBoxColumn();
            属 = new DataGridViewTextBoxColumn();
            説明 = new DataGridViewTextBoxColumn();
            ＩＤ = new DataGridViewTextBoxColumn();
            pnlBody.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMain).BeginInit();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(txtKeyWord);
            pnlBody.Controls.Add(txtName);
            pnlBody.Controls.Add(txtGenus);
            pnlBody.Controls.Add(label4);
            pnlBody.Controls.Add(label3);
            pnlBody.Controls.Add(label2);
            pnlBody.Controls.Add(txtFamily);
            pnlBody.Controls.Add(label1);
            pnlBody.Dock = DockStyle.Top;
            pnlBody.Location = new Point(0, 0);
            pnlBody.Name = "pnlBody";
            pnlBody.Size = new Size(784, 184);
            pnlBody.TabIndex = 0;
            // 
            // txtKeyWord
            // 
            txtKeyWord.Font = new Font("Yu Gothic UI", 10F);
            txtKeyWord.Location = new Point(142, 143);
            txtKeyWord.Name = "txtKeyWord";
            txtKeyWord.Size = new Size(600, 25);
            txtKeyWord.TabIndex = 7;
            // 
            // txtName
            // 
            txtName.Font = new Font("Yu Gothic UI", 10F);
            txtName.Location = new Point(142, 105);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 25);
            txtName.TabIndex = 6;
            // 
            // txtGenus
            // 
            txtGenus.Font = new Font("Yu Gothic UI", 10F);
            txtGenus.Location = new Point(142, 67);
            txtGenus.Name = "txtGenus";
            txtGenus.Size = new Size(200, 25);
            txtGenus.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 14F);
            label4.Location = new Point(40, 143);
            label4.Name = "label4";
            label4.Size = new Size(96, 25);
            label4.TabIndex = 4;
            label4.Text = "キーワード：";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 14F);
            label3.Location = new Point(67, 105);
            label3.Name = "label3";
            label3.Size = new Size(69, 25);
            label3.TabIndex = 3;
            label3.Text = "名前：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 14F);
            label2.Location = new Point(86, 67);
            label2.Name = "label2";
            label2.Size = new Size(50, 25);
            label2.TabIndex = 2;
            label2.Text = "属：";
            // 
            // txtFamily
            // 
            txtFamily.Font = new Font("Yu Gothic UI", 10F);
            txtFamily.Location = new Point(142, 32);
            txtFamily.Name = "txtFamily";
            txtFamily.Size = new Size(200, 25);
            txtFamily.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 14F);
            label1.Location = new Point(86, 32);
            label1.Name = "label1";
            label1.Size = new Size(50, 25);
            label1.TabIndex = 0;
            label1.Text = "科：";
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvMain);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 184);
            panel2.Name = "panel2";
            panel2.Size = new Size(784, 377);
            panel2.TabIndex = 1;
            // 
            // dgvMain
            // 
            dgvMain.AllowUserToAddRows = false;
            dgvMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMain.Columns.AddRange(new DataGridViewColumn[] { 選択, 名称, 科, 属, 説明, ＩＤ });
            dgvMain.Dock = DockStyle.Fill;
            dgvMain.Location = new Point(0, 0);
            dgvMain.Name = "dgvMain";
            dgvMain.Size = new Size(784, 377);
            dgvMain.TabIndex = 0;
            dgvMain.CellDoubleClick += dgvMain_CellDoubleClick;
            // 
            // pnlFooter
            // 
            pnlFooter.Controls.Add(btnNewReg);
            pnlFooter.Controls.Add(btnDelete);
            pnlFooter.Controls.Add(btnView);
            pnlFooter.Controls.Add(btnSelect);
            pnlFooter.Controls.Add(btnClose);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 531);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(784, 30);
            pnlFooter.TabIndex = 2;
            // 
            // btnNewReg
            // 
            btnNewReg.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnNewReg.Location = new Point(204, 3);
            btnNewReg.Name = "btnNewReg";
            btnNewReg.Size = new Size(90, 23);
            btnNewReg.TabIndex = 4;
            btnNewReg.Text = "新規登録";
            btnNewReg.UseVisualStyleBackColor = true;
            btnNewReg.Click += btnNewReg_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.Location = new Point(354, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(90, 23);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "削除";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnView
            // 
            btnView.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnView.Location = new Point(108, 3);
            btnView.Name = "btnView";
            btnView.Size = new Size(90, 23);
            btnView.TabIndex = 2;
            btnView.Text = "詳細表示";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click;
            // 
            // btnSelect
            // 
            btnSelect.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSelect.Location = new Point(12, 3);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(90, 23);
            btnSelect.TabIndex = 1;
            btnSelect.Text = "検索";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(680, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(90, 23);
            btnClose.TabIndex = 0;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // 選択
            // 
            選択.HeaderText = "選択";
            選択.Name = "選択";
            選択.Width = 60;
            // 
            // 名称
            // 
            名称.HeaderText = "名称";
            名称.Name = "名称";
            名称.ReadOnly = true;
            名称.Width = 200;
            // 
            // 科
            // 
            科.HeaderText = "科";
            科.Name = "科";
            科.ReadOnly = true;
            // 
            // 属
            // 
            属.HeaderText = "属";
            属.Name = "属";
            属.ReadOnly = true;
            // 
            // 説明
            // 
            説明.HeaderText = "説明";
            説明.Name = "説明";
            説明.ReadOnly = true;
            説明.Width = 300;
            // 
            // ＩＤ
            // 
            ＩＤ.HeaderText = "ＩＤ";
            ＩＤ.Name = "ＩＤ";
            ＩＤ.ReadOnly = true;
            ＩＤ.Visible = false;
            // 
            // FrmTop
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(pnlFooter);
            Controls.Add(panel2);
            Controls.Add(pnlBody);
            Name = "FrmTop";
            Text = "Top";
            pnlBody.ResumeLayout(false);
            pnlBody.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMain).EndInit();
            pnlFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlBody;
        private Panel panel2;
        private Panel pnlFooter;
        private DataGridView dgvMain;
        private Button btnClose;
        private Button btnSelect;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtFamily;
        private Label label1;
        private TextBox txtKeyWord;
        private TextBox txtName;
        private TextBox txtGenus;
        private Button btnView;
        private Button btnDelete;
        private Button btnNewReg;
        private DataGridViewCheckBoxColumn 選択;
        private DataGridViewTextBoxColumn 名称;
        private DataGridViewTextBoxColumn 科;
        private DataGridViewTextBoxColumn 属;
        private DataGridViewTextBoxColumn 説明;
        private DataGridViewTextBoxColumn ＩＤ;
    }
}
