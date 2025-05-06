/**********************************************************************************************
 *  ���W���[�����FFrmTop
 *          �����F�g�b�v�y�[�W
 **********************************************************************************************/
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace PictureBook
{
    public partial class FrmTop : Form
    {
        /*** �N���X���萔 ***/

        /*** �N���X���ϐ� ***/
        private DataTable dtMain;
        private MyDataControl mdc;

        /*************************************************************************************
        *   �֐����F�R���X�g���N�^
        *     �����FTOP��ʍ쐬���̏���
        *************************************************************************************/
        public FrmTop()
        {
            //�t�H�[��������
            InitializeComponent();

            //�f�[�^�e�[�u���쐬
            dtMain = new DataTable();
            //�f�[�^�\���p�C���X�^���X�쐬
            mdc = new MyDataControl();
            //TextBox��Enter�L�[�������̃r�[�v����}��
            foreach (Control c in this.Controls)
            {
                //Panel���ɂ���TextBox�ɓK�p
                if (c.GetType().Equals(typeof(Panel)))
                {
                    foreach(Control pc in ((Panel)c).Controls)
                    {
                        if (pc.GetType().Equals(typeof(TextBox)))
                        {
                            ((TextBox)pc).KeyDown += MuteBeep;
                        }
                    }
                }
                else if (c.GetType().Equals(typeof(TextBox)))
                {
                    ((TextBox)c).KeyDown += MuteBeep;
                }
            }
        }

        /*************************************************************************************
        *   �֐����FMuteBeep
        *     �����FEnter�L�[�������̉���炳�Ȃ�
        *************************************************************************************/
        private void MuteBeep(object? obj, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        /*************************************************************************************
        *   �֐����FbtnSelect_Click
        *     �����F�����{�^������
        *************************************************************************************/
        public void btnSelect_Click(Object sender, EventArgs e)
        {
            try
            {
                string sBuf = "";
                //�f�[�^�e�[�u�����N���A
                this.dtMain.Clear();
                //�f�[�^�O���b�h�r���[���N���A
                dgvMain.Rows.Clear();
                //�f�[�^�e�[�u���ɒ��o�����f�[�^���Z�b�g
                SQLiteConnectionStringBuilder sb = new SQLiteConnectionStringBuilder { DataSource = mdc.GetDBFileName() };
                using (SQLiteConnection cn = new SQLiteConnection(sb.ToString()))
                {
                    cn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(cn))
                    {
                        StringBuilder sbSelect = new StringBuilder();
                        sbSelect.AppendLine(@"SELECT *")
                                .AppendLine("   FROM BASE");
                        string sCon = " WHERE ";                //WHERE��̐ڑ�����
                        //��
                        if (txtFamily.Text != "")
                        {
                            sbSelect.AppendLine(sCon + "�� LIKE \'%" + txtFamily.Text + "%\'");
                            sCon = "   AND ";
                        }
                        //��
                        if (txtGenus.Text != "")
                        {
                            sbSelect.AppendLine(sCon + "�� LIKE \'%" + txtGenus.Text + "%\'");
                            sCon = "   AND ";
                        }
                        //����
                        if (txtName.Text != "")
                        {
                            sbSelect.AppendLine(sCon + "���� LIKE \'%" + txtName.Text + "%\'");
                            sCon = "   AND ";
                        }
                        //�L�[���[�h(�p�^�[���}�b�`���O��or�Ŏ�������)
                        if (txtKeyWord.Text != "")
                        {
                            //������̑O��̋󔒂�����
                            sBuf = txtKeyWord.Text.Trim();
                            //������̑S�p�X�y�[�X�𔼊p�ɒu��
                            sBuf = sBuf.Replace("�@", " ");
                            //���p�X�y�[�X���u%',%'�v�ɕϊ�
                            sBuf = sBuf.Replace(" ", "%\',\'%");
                            //���[�Ɂu'�v�Ɓu%�v��t�^
                            sBuf = "\'%" + sBuf + "%\'";
                            //���͕�����𕪊����Ĕz��ɃZ�b�g
                            String[] sWords = sBuf.Split(",");
                            //�L�[���[�h�𒊏o�����ɉ�����
                            //(��)
                            sbSelect.AppendLine(sCon + "( �� LIKE (" + sWords[0] + ")");
                            sCon = "      OR ";
                            for (int i = 1; i < sWords.Length; i++)
                            {
                                sbSelect.AppendLine(sCon + "  �� LIKE (" + sWords[i] + ")");
                            }
                            //(��)
                            for (int i = 0; i < sWords.Length; i++)
                            {
                                sbSelect.AppendLine(sCon + "  �� LIKE (" + sWords[i] + ")");
                            }
                            //(����)
                            for (int i = 0; i < sWords.Length; i++)
                            {
                                sbSelect.AppendLine(sCon + "  ���� LIKE (" + sWords[i] + ")");
                            }
                            //(����)
                            for (int i = 0; i < sWords.Length; i++)
                            {
                                sbSelect.AppendLine(sCon + "  ���� LIKE (" + sWords[i] + ")");
                            }
                            sbSelect.AppendLine(")");
                        }
                        sbSelect.AppendLine("ORDER BY ����");
                        cmd.CommandText = sbSelect.ToString();
                        SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                        da.Fill(dtMain);
                    }
                    cn.Close();
                }
                //���R�[�h���Ȃ��ꍇ�͏����𔲂���
                if (dtMain.Rows.Count == 0)
                {
                    return;
                }
                //�f�[�^�O���b�h�r���[�Ƀf�[�^��\��
                dgvMain.RowCount = dtMain.Rows.Count;
                for (int i = 0; i < dtMain.Rows.Count; i++)
                {
                    //�h�c(��\��)
                    dgvMain.Rows[i].Cells["�h�c"].Value = dtMain.Rows[i]["�h�c"].ToString();
                    //���O
                    dgvMain.Rows[i].Cells["����"].Value = dtMain.Rows[i]["����"].ToString();
                    //��
                    dgvMain.Rows[i].Cells["��"].Value = dtMain.Rows[i]["��"].ToString();
                    //��
                    dgvMain.Rows[i].Cells["��"].Value = dtMain.Rows[i]["��"].ToString();
                    //����
                    dgvMain.Rows[i].Cells["����"].Value = dtMain.Rows[i]["����"].ToString();
                }
                //�`�F�b�N�{�b�N�X��������
                for (int i = 0; i < dgvMain.Rows.Count; i++)
                {
                    dgvMain.Rows[i].Cells["�I��"].Value = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
        *   �֐����FbtnClose_Click
        *     �����F����{�^������
        *************************************************************************************/
        public void btnClose_Click(Object sender, EventArgs e)
        {
            try
            {
                //�t�H�[�������
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
        *   �֐����FbtnView_Click
        *     �����F�ڍ׃{�^������
        *************************************************************************************/
        public void btnView_Click(Object sender, EventArgs e)
        {
            try
            {
                //�ڍ׉�ʂ��ڍו\�����[�h�ŋN��
                ViewOpen();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
        *   �֐����FbtnNewReg_Click
        *     �����F�V�K�o�^�{�^������
        *************************************************************************************/
        private void btnNewReg_Click(object sender, EventArgs e)
        {
            try
            {
                //�ڍ׉�ʂ�V�K�o�^���[�h�ŋN��
                FrmView frmView = new FrmView();
                frmView.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /*************************************************************************************
        *   �֐����FbtnDelete_Click
        *     �����F�폜�{�^������
        *************************************************************************************/
        public void btnDelete_Click(Object sender, EventArgs e)
        {
            try
            {
                List<string> lstId = new List<string>();
                string strId = "";
                //�u�I���v�񂪃`�F�b�N����Ă���s�̂h�c���擾
                for (int i = 0; i < dgvMain.RowCount; i++)
                {
                    if ((bool)dgvMain.Rows[i].Cells["�I��"].Value)
                    {
                        //�`�F�b�N�̂���s�̂h�c�����X�g�ɕۑ�
                        lstId.Add(dgvMain.Rows[i].Cells["�h�c"].Value.ToString() ?? "");   //�Z���̒l��null�̎��͋󔒂��Z�b�g
                    }
                }
                //�I���s��0�̏ꍇ�̓��b�Z�[�W��\�����ď����𔲂���
                if(lstId.Count == 0)
                {
                    MessageBox.Show("�폜���郌�R�[�h��I�����Ă��������B");
                    return;
                }
                else
                {
                    //�m�F���b�Z�[�W��\��
                    DialogResult drResult = MessageBox.Show("�I�������摜�����폜���܂��B��낵���ł����H",
                                                            "�m�F",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question,
                                                            MessageBoxDefaultButton.Button2);
                    if (drResult == DialogResult.No)
                    {
                        //�������{�^���������A�����𔲂���
                        return;
                    }
                }

                //�I���s1
                if (lstId.Count > 0)
                {
                    strId = lstId[0];
                }
                //�I���s2�`
                for (int i = 1; i < lstId.Count; i++)
                {
                    strId += ", " + lstId[i];
                }
                //�폜����
                SQLiteConnectionStringBuilder sb = new SQLiteConnectionStringBuilder { DataSource = mdc.GetDBFileName() };
                using (SQLiteConnection cn = new SQLiteConnection(sb.ToString()))
                {
                    //�f�[�^�x�[�X�ւ̐ڑ�ON
                    cn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(cn))
                    {
                        //-- PIC�e�[�u���̊Y���h�c���R�[�h���폜 --
                        //SQL���쐬
                        StringBuilder sbDelete = new StringBuilder();
                        sbDelete.Append("DELETE FROM PIC");
                        sbDelete.Append(" WHERE EXISTS (SELECT 1 FROM BASE");
                        sbDelete.Append("         WHERE BASE.�h�c IN (" + strId + "))");
                        cmd.CommandText = sbDelete.ToString();
                        //SQL���s
                        cmd.ExecuteNonQuery();
                        //-- BASE�e�[�u���̊Y���h�c���R�[�h���폜 --
                        //SQL���쐬
                        sbDelete.Clear();
                        sbDelete.Append("DELETE FROM BASE");
                        sbDelete.Append(" WHERE �h�c IN (" + strId + ")");
                        cmd.CommandText = sbDelete.ToString();
                        //SQL���s
                        cmd.ExecuteNonQuery();
                    }
                    cn.Close();
                }
                //�f�[�^�Ē��o
                btnSelect_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
        *   �֐����FdgvMain_CellDouble_Click
        *     �����F�Z���_�u���N���b�N
        *************************************************************************************/
        private void dgvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //�ڍ׉�ʂ��ڍו\�����[�h�ŋN��
                ViewOpen();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
        *   �֐����FViewOpen
        *     �����F�ڍ׉�ʕ\��
        *************************************************************************************/
        private void ViewOpen()
        {
            try
            {
                //�s��񂪎擾�ł��Ȃ��Ƃ��͏����𔲂���
                if (dgvMain.CurrentRow == null)
                {
                    return;
                }
                //�I�𒆂̍s�̂h�c���擾���ďڍ׉�ʂ��ڍו\�����[�h�ŋN��
                FrmView frmView = new FrmView(Convert.ToInt32(dgvMain.Rows[dgvMain.CurrentRow.Index].Cells["�h�c"].Value.ToString()));
                frmView.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
