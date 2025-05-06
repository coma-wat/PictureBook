namespace PictureBook
{
    partial class FrmPicList
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlFooter = new Panel();
            btnAdd = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            btnClose = new Button();
            pnlHeader = new Panel();
            pbxSample = new PictureBox();
            btnRefresh = new Button();
            txtId = new TextBox();
            pnlBody = new Panel();
            dgvMain = new DataGridView();
            画像番号 = new DataGridViewTextBoxColumn();
            選択 = new DataGridViewCheckBoxColumn();
            ファイル名 = new DataGridViewTextBoxColumn();
            パス = new DataGridViewTextBoxColumn();
            pnlFooter.SuspendLayout();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxSample).BeginInit();
            pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMain).BeginInit();
            SuspendLayout();
            // 
            // pnlFooter
            // 
            pnlFooter.Controls.Add(btnAdd);
            pnlFooter.Controls.Add(btnDelete);
            pnlFooter.Controls.Add(btnSave);
            pnlFooter.Controls.Add(btnClose);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 422);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(784, 39);
            pnlFooter.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAdd.Location = new Point(12, 8);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(88, 24);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "追加";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.Location = new Point(200, 8);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(88, 24);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "削除";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSave.Location = new Point(106, 8);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(88, 24);
            btnSave.TabIndex = 1;
            btnSave.Text = "保存";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(664, 8);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(88, 24);
            btnClose.TabIndex = 0;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(pbxSample);
            pnlHeader.Controls.Add(btnRefresh);
            pnlHeader.Controls.Add(txtId);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(784, 160);
            pnlHeader.TabIndex = 2;
            // 
            // pbxSample
            // 
            pbxSample.BorderStyle = BorderStyle.FixedSingle;
            pbxSample.Location = new Point(30, 10);
            pbxSample.Name = "pbxSample";
            pbxSample.Size = new Size(280, 140);
            pbxSample.TabIndex = 4;
            pbxSample.TabStop = false;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRefresh.Location = new Point(680, 123);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(88, 24);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "再表示";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // txtId
            // 
            txtId.Location = new Point(638, 12);
            txtId.Name = "txtId";
            txtId.Size = new Size(134, 23);
            txtId.TabIndex = 0;
            txtId.TabStop = false;
            txtId.Text = "ＩＤ(非表示)";
            txtId.Visible = false;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(dgvMain);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 160);
            pnlBody.Name = "pnlBody";
            pnlBody.Size = new Size(784, 262);
            pnlBody.TabIndex = 3;
            // 
            // dgvMain
            // 
            dgvMain.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Yu Gothic UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMain.Columns.AddRange(new DataGridViewColumn[] { 画像番号, 選択, ファイル名, パス });
            dgvMain.Dock = DockStyle.Fill;
            dgvMain.Location = new Point(0, 0);
            dgvMain.Name = "dgvMain";
            dgvMain.Size = new Size(784, 262);
            dgvMain.TabIndex = 0;
            dgvMain.CellClick += dgvMain_CellClick;
            // 
            // 画像番号
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            画像番号.DefaultCellStyle = dataGridViewCellStyle2;
            画像番号.HeaderText = "No.";
            画像番号.Name = "画像番号";
            画像番号.ReadOnly = true;
            画像番号.Width = 50;
            // 
            // 選択
            // 
            選択.FalseValue = "";
            選択.HeaderText = "選択";
            選択.Name = "選択";
            選択.Resizable = DataGridViewTriState.True;
            選択.SortMode = DataGridViewColumnSortMode.Automatic;
            選択.Width = 60;
            // 
            // ファイル名
            // 
            ファイル名.HeaderText = "ファイル名";
            ファイル名.Name = "ファイル名";
            ファイル名.ReadOnly = true;
            ファイル名.SortMode = DataGridViewColumnSortMode.NotSortable;
            ファイル名.Width = 200;
            // 
            // パス
            // 
            パス.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            パス.HeaderText = "パス";
            パス.MinimumWidth = 400;
            パス.Name = "パス";
            パス.ReadOnly = true;
            パス.SortMode = DataGridViewColumnSortMode.NotSortable;
            パス.Width = 400;
            // 
            // FrmPicList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(pnlBody);
            Controls.Add(pnlHeader);
            Controls.Add(pnlFooter);
            Name = "FrmPicList";
            Text = "画像一覧";
            pnlFooter.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbxSample).EndInit();
            pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMain).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlFooter;
        private Panel pnlHeader;
        private TextBox txtId;
        private Button btnClose;
        private Button btnDelete;
        private Button btnSave;
        private Button btnRefresh;
        private Panel pnlBody;
        private DataGridView dgvMain;
        private Button btnAdd;
        private PictureBox pbxSample;
        private DataGridViewTextBoxColumn 画像番号;
        private DataGridViewCheckBoxColumn 選択;
        private DataGridViewTextBoxColumn ファイル名;
        private DataGridViewTextBoxColumn パス;
    }
}