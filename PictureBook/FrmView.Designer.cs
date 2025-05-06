namespace PictureBook
{
    partial class FrmView
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
            pbxPic = new PictureBox();
            txtName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtFamily = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtGenus = new TextBox();
            txtHabitat = new TextBox();
            txtDesc = new TextBox();
            btnEdit = new Button();
            btnSave = new Button();
            btnClose = new Button();
            btnPicPrev = new Button();
            btnPicNext = new Button();
            label6 = new Label();
            txtSName = new TextBox();
            pnlFooter = new Panel();
            btnNewReg = new Button();
            btnCancel = new Button();
            txtId = new TextBox();
            btnPicList = new Button();
            ((System.ComponentModel.ISupportInitialize)pbxPic).BeginInit();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pbxPic
            // 
            pbxPic.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbxPic.BorderStyle = BorderStyle.FixedSingle;
            pbxPic.Location = new Point(360, 40);
            pbxPic.Name = "pbxPic";
            pbxPic.Size = new Size(400, 280);
            pbxPic.TabIndex = 0;
            pbxPic.TabStop = false;
            // 
            // txtName
            // 
            txtName.Font = new Font("Yu Gothic UI", 12F);
            txtName.Location = new Point(20, 37);
            txtName.Name = "txtName";
            txtName.Size = new Size(300, 29);
            txtName.TabIndex = 1;
            txtName.Enter += txtName_Enter;
            txtName.Leave += txtName_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 12F);
            label1.Location = new Point(20, 15);
            label1.Name = "label1";
            label1.Size = new Size(42, 21);
            label1.TabIndex = 2;
            label1.Text = "名称";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 12F);
            label2.Location = new Point(20, 140);
            label2.Name = "label2";
            label2.Size = new Size(26, 21);
            label2.TabIndex = 3;
            label2.Text = "科";
            // 
            // txtFamily
            // 
            txtFamily.Font = new Font("Yu Gothic UI", 12F);
            txtFamily.Location = new Point(20, 162);
            txtFamily.Name = "txtFamily";
            txtFamily.Size = new Size(300, 29);
            txtFamily.TabIndex = 3;
            txtFamily.Enter += txtFamily_Enter;
            txtFamily.Leave += txtFamily_Leave;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 12F);
            label3.Location = new Point(20, 200);
            label3.Name = "label3";
            label3.Size = new Size(26, 21);
            label3.TabIndex = 5;
            label3.Text = "属";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 12F);
            label4.Location = new Point(20, 260);
            label4.Name = "label4";
            label4.Size = new Size(74, 21);
            label4.TabIndex = 6;
            label4.Text = "生息環境";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 12F);
            label5.Location = new Point(20, 355);
            label5.Name = "label5";
            label5.Size = new Size(42, 21);
            label5.TabIndex = 7;
            label5.Text = "説明";
            // 
            // txtGenus
            // 
            txtGenus.Font = new Font("Yu Gothic UI", 12F);
            txtGenus.Location = new Point(20, 222);
            txtGenus.Name = "txtGenus";
            txtGenus.Size = new Size(300, 29);
            txtGenus.TabIndex = 4;
            txtGenus.Enter += txtGenus_Enter;
            txtGenus.Leave += txtGenus_Leave;
            // 
            // txtHabitat
            // 
            txtHabitat.Font = new Font("Yu Gothic UI", 12F);
            txtHabitat.Location = new Point(20, 282);
            txtHabitat.Multiline = true;
            txtHabitat.Name = "txtHabitat";
            txtHabitat.Size = new Size(300, 58);
            txtHabitat.TabIndex = 5;
            txtHabitat.Enter += txtHabitat_Enter;
            txtHabitat.Leave += txtHabitat_Leave;
            // 
            // txtDesc
            // 
            txtDesc.Font = new Font("Yu Gothic UI", 12F);
            txtDesc.Location = new Point(20, 380);
            txtDesc.Multiline = true;
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(740, 174);
            txtDesc.TabIndex = 6;
            txtDesc.Enter += txtDesc_Enter;
            txtDesc.Leave += txtDesc_Leave;
            // 
            // btnEdit
            // 
            btnEdit.Font = new Font("Yu Gothic UI", 12F);
            btnEdit.Location = new Point(118, 7);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(100, 28);
            btnEdit.TabIndex = 12;
            btnEdit.Text = "編集";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Yu Gothic UI", 12F);
            btnSave.Location = new Point(330, 7);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 28);
            btnSave.TabIndex = 14;
            btnSave.Text = "保存";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Yu Gothic UI", 12F);
            btnClose.Location = new Point(681, 7);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 28);
            btnClose.TabIndex = 15;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnPicPrev
            // 
            btnPicPrev.Font = new Font("Yu Gothic UI", 12F);
            btnPicPrev.Location = new Point(360, 330);
            btnPicPrev.Margin = new Padding(0);
            btnPicPrev.Name = "btnPicPrev";
            btnPicPrev.Size = new Size(30, 28);
            btnPicPrev.TabIndex = 7;
            btnPicPrev.Text = "◀";
            btnPicPrev.UseVisualStyleBackColor = true;
            btnPicPrev.Click += btnPicPrev_Click;
            // 
            // btnPicNext
            // 
            btnPicNext.Font = new Font("Yu Gothic UI", 12F);
            btnPicNext.Location = new Point(730, 330);
            btnPicNext.Margin = new Padding(0);
            btnPicNext.Name = "btnPicNext";
            btnPicNext.Size = new Size(30, 28);
            btnPicNext.TabIndex = 10;
            btnPicNext.Text = "▶";
            btnPicNext.UseVisualStyleBackColor = true;
            btnPicNext.Click += btnPicNext_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 12F);
            label6.Location = new Point(20, 78);
            label6.Name = "label6";
            label6.Size = new Size(42, 21);
            label6.TabIndex = 16;
            label6.Text = "学名";
            // 
            // txtSName
            // 
            txtSName.Font = new Font("Yu Gothic UI", 12F);
            txtSName.ImeMode = ImeMode.Disable;
            txtSName.Location = new Point(20, 100);
            txtSName.Name = "txtSName";
            txtSName.Size = new Size(300, 29);
            txtSName.TabIndex = 2;
            txtSName.Enter += txtSName_Enter;
            txtSName.Leave += txtSName_Leave;
            // 
            // pnlFooter
            // 
            pnlFooter.Controls.Add(btnNewReg);
            pnlFooter.Controls.Add(btnCancel);
            pnlFooter.Controls.Add(btnEdit);
            pnlFooter.Controls.Add(btnSave);
            pnlFooter.Controls.Add(btnClose);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 573);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(784, 38);
            pnlFooter.TabIndex = 18;
            // 
            // btnNewReg
            // 
            btnNewReg.Font = new Font("Yu Gothic UI", 12F);
            btnNewReg.Location = new Point(12, 7);
            btnNewReg.Name = "btnNewReg";
            btnNewReg.Size = new Size(100, 28);
            btnNewReg.TabIndex = 11;
            btnNewReg.Text = "新規登録";
            btnNewReg.UseVisualStyleBackColor = true;
            btnNewReg.Click += btnNewReg_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Yu Gothic UI", 12F);
            btnCancel.Location = new Point(224, 7);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 28);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtId
            // 
            txtId.Font = new Font("Yu Gothic UI", 12F);
            txtId.ImeMode = ImeMode.Disable;
            txtId.Location = new Point(215, 2);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(105, 29);
            txtId.TabIndex = 0;
            txtId.Text = "ID(非表示)";
            txtId.Visible = false;
            // 
            // btnPicList
            // 
            btnPicList.Font = new Font("Yu Gothic UI", 12F);
            btnPicList.Location = new Point(512, 330);
            btnPicList.Name = "btnPicList";
            btnPicList.Size = new Size(100, 28);
            btnPicList.TabIndex = 8;
            btnPicList.Text = "画像一覧";
            btnPicList.UseVisualStyleBackColor = true;
            btnPicList.Click += btnPicList_Click;
            // 
            // FrmView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 611);
            Controls.Add(btnPicList);
            Controls.Add(txtId);
            Controls.Add(pnlFooter);
            Controls.Add(txtSName);
            Controls.Add(label6);
            Controls.Add(btnPicNext);
            Controls.Add(btnPicPrev);
            Controls.Add(txtDesc);
            Controls.Add(txtHabitat);
            Controls.Add(txtGenus);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtFamily);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtName);
            Controls.Add(pbxPic);
            Name = "FrmView";
            Text = "詳細";
            ((System.ComponentModel.ISupportInitialize)pbxPic).EndInit();
            pnlFooter.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbxPic;
        private TextBox txtName;
        private Label label1;
        private Label label2;
        private TextBox txtFamily;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtGenus;
        private TextBox txtHabitat;
        private TextBox txtDesc;
        private Button btnEdit;
        private Button btnSave;
        private Button btnClose;
        private Button btnPicPrev;
        private Button btnPicNext;
        private Label label6;
        private TextBox txtSName;
        private Panel pnlFooter;
        private Button btnCancel;
        private TextBox txtId;
        private Button btnNewReg;
        private Button btnPicList;
    }
}