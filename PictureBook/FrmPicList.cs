/**********************************************************************************************
 *  モジュール名：FrmPicList
 *          説明：画像情報一覧ページ
 **********************************************************************************************/
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Text;
using System.Transactions;

namespace PictureBook
{
    public partial class FrmPicList : Form
    {
        private MyDataControl mdc = new MyDataControl();

        /*************************************************************************************
            関数名：コンストラクタ(引数あり)
              説明：対応するIDの画像情報一覧を表示する
        *************************************************************************************/
        public FrmPicList(int _intId)
        {
            InitializeComponent();
            //IDを保存
            txtId.Text = Convert.ToString(_intId);
            //画像情報一覧を表示
            btnRefresh_Click(null, null);
        }

        /*************************************************************************************
            関数名：btnClose_Click
              説明：フォームを閉じる
        *************************************************************************************/
        public void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*************************************************************************************
            関数名：btnRefresh_Click
              説明：再表示ボタン押下
        *************************************************************************************/
        private void btnRefresh_Click(object? sender, EventArgs? e)
        {
            try
            {
                SQLiteConnectionStringBuilder sb = new SQLiteConnectionStringBuilder { DataSource = mdc.GetDBFileName() };
                using (SQLiteConnection cn = new SQLiteConnection(sb.ToString()))
                {
                    //DataGridViewをクリア
                    dgvMain.Rows.Clear();

                    DataTable dtMain = new DataTable();
                    //接続開始
                    cn.Open();
                    //SQLセット
                    using (SQLiteCommand cmd = new SQLiteCommand(cn))
                    {
                        StringBuilder sbSelect = new StringBuilder();
                        sbSelect.AppendLine(@"SELECT 画像番号")
                                .AppendLine("      ,ファイル名")
                                .AppendLine("      ,パス")
                                .AppendLine("  FROM PIC")
                                .AppendLine(" WHERE ＩＤ = @ＩＤ")
                                .AppendLine("ORDER BY 画像番号");
                        cmd.CommandText = sbSelect.ToString();
                        cmd.Parameters.AddWithValue("@ＩＤ", Convert.ToInt32(txtId.Text));
                        SQLiteDataAdapter ad = new SQLiteDataAdapter(cmd);
                        ad.Fill(dtMain);
                    }
                    //接続終了
                    cn.Close();
                    //レコードが0件の場合は処理を抜ける
                    if (dtMain.Rows.Count == 0)
                    {
                        return;
                    }
                    //DataGridViewに画像情報一覧を表示
                    dgvMain.RowCount = dtMain.Rows.Count;
                    for (int i = 0; i < dgvMain.RowCount; i++)
                    {
                        //画像番号
                        dgvMain.Rows[i].Cells["画像番号"].Value = dtMain.Rows[i]["画像番号"].ToString();
                        //名称
                        dgvMain.Rows[i].Cells["ファイル名"].Value = dtMain.Rows[i]["ファイル名"].ToString();
                        //パス
                        dgvMain.Rows[i].Cells["パス"].Value = dtMain.Rows[i]["パス"].ToString();

                        //チェックボックスを初期化
                        dgvMain.Rows[i].Cells["選択"].Value = false;
                    }
                }
                //画像情報がある場合は先頭の画像を表示
                if(dgvMain.RowCount > 0)
                {
                    PicView(dgvMain.Rows[0].Cells["パス"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
            関数名：btnAdd_Click
              説明：追加ボタン押下
        *************************************************************************************/
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //オープンダイアログを準備
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "画像選択";
                ofd.Filter = "画像ファイル(*.jpg,*.jpeg)|*.jpg;*.jpeg|全てのファイル(*.*)|*.*";
                ofd.FilterIndex = 1;
                ofd.RestoreDirectory = true;
                //オープンダイアログを開き、画像ファイルを選択
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    //現在の一覧の行数を取得
                    int iRowCnt = dgvMain.Rows.Count;
                    //0行の場合は行追加して行数を再取得
                    if (iRowCnt == 0)
                    {
                        dgvMain.Rows.Add();
                        iRowCnt = dgvMain.Rows.Count;
                    }
                    for (int i = 0; i < iRowCnt; i++)
                    {
                        //画像番号がNullの行にファイル名とパスをセット
                        if (dgvMain.Rows[i].Cells["画像番号"].Value == null)
                        {
                            dgvMain.Rows[i].Cells["画像番号"].Value = Convert.ToString(i + 1);
                            dgvMain.Rows[i].Cells["ファイル名"].Value = ofd.SafeFileName;
                            dgvMain.Rows[i].Cells["パス"].Value = ofd.FileName;
                            break;
                        }
                        //最終行の場合は行追加
                        else if (dgvMain.Rows[i].Cells["画像番号"].Value != null && i == iRowCnt - 1)
                        {
                            dgvMain.Rows.Add();
                            dgvMain.Rows[iRowCnt].Cells["画像番号"].Value = Convert.ToString(i + 2);
                            dgvMain.Rows[iRowCnt].Cells["ファイル名"].Value = ofd.SafeFileName;
                            dgvMain.Rows[iRowCnt].Cells["パス"].Value = ofd.FileName;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
            関数名：btnSave_Click
              説明：保存ボタン押下
        *************************************************************************************/
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnectionStringBuilder sb = new SQLiteConnectionStringBuilder { DataSource = mdc.GetDBFileName() };
                using (SQLiteConnection cn = new SQLiteConnection(sb.ToString()))
                {
                    //確認メッセージを表示
                    DialogResult drResult = MessageBox.Show("画像情報を登録します。よろしいですか？",
                                                            "確認",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question,
                                                            MessageBoxDefaultButton.Button2);
                    if (drResult == DialogResult.No)
                    {
                        //いいえボタン押下時、処理を抜ける
                        return;
                    }

                    //DB接続開始
                    cn.Open();

                    //*** トランザクション開始 ***
                    using (SQLiteTransaction tran = cn.BeginTransaction())
                    {
                        try
                        {
                            using (SQLiteCommand cmd = new SQLiteCommand(cn))
                            {
                                //--- 該当ＩＤの画像情報を削除 ---
                                StringBuilder sbDelete = new StringBuilder();
                                sbDelete.AppendLine(@"DELETE FROM PIC")
                                        .AppendLine("  WHERE ＩＤ = @ＩＤ");
                                cmd.CommandText = sbDelete.ToString();
                                cmd.Parameters.AddWithValue("@ＩＤ", Convert.ToInt32(txtId.Text));
                                cmd.ExecuteNonQuery();

                                //--- 画像情報を登録 ---
                                StringBuilder sbInsert = new StringBuilder();
                                sbInsert.AppendLine(@"INSERT INTO PIC (")
                                        .AppendLine("       ＩＤ")
                                        .AppendLine("      ,画像番号")
                                        .AppendLine("      ,ファイル名")
                                        .AppendLine("      ,パス")
                                        .AppendLine(") VALUES (")
                                        .AppendLine("       @ＩＤ")
                                        .AppendLine("      ,@画像番号")
                                        .AppendLine("      ,@ファイル名")
                                        .AppendLine("      ,@パス")
                                        .AppendLine(")");
                                cmd.CommandText = sbInsert.ToString();
                                int iPicNum = 1;
                                for (int i = 0; i < dgvMain.Rows.Count; i++)
                                {
                                    //画像番号、ファイル名に値がある行のみ登録
                                    if ((dgvMain.Rows[i].Cells["画像番号"].Value != null) &&
                                       (dgvMain.Rows[i].Cells["ファイル名"].Value != null))
                                    {
                                        //パラメーターセット
                                        cmd.Parameters.AddWithValue("@ＩＤ", Convert.ToInt32(txtId.Text));
                                        cmd.Parameters.AddWithValue("@画像番号", iPicNum);
                                        cmd.Parameters.AddWithValue("@ファイル名", dgvMain.Rows[i].Cells["ファイル名"].Value);
                                        cmd.Parameters.AddWithValue("@パス", dgvMain.Rows[i].Cells["パス"].Value);
                                        cmd.ExecuteNonQuery();
                                        //画像番号+1
                                        iPicNum++;
                                    }
                                }
                            }
                            //*** トランザクション終了 ***
                            tran.Commit();

                            //グリッド行削除
                            dgvMain.Rows.Clear();
                            //画像情報を再表示
                            btnRefresh_Click(null, null);
                        }
                        catch
                        {
                            //トランザクション実行中の場合はロールバック
                            if (Transaction.Current != null)
                            {
                                tran.Rollback();
                            }
                            throw;
                        }
                        //DB接続終了
                        cn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
            関数名：btnDelete_Click
              説明：削除ボタン押下
        *************************************************************************************/
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string sBuf = "";
                //画像情報退避用のList
                List<int> lstNumUpd = new List<int>();
                //選択中の画像番号保存用List
                List<int> lstNumDel = new List<int>();

                //選択中の画像番号を取得
                for (int i = 0; i < dgvMain.RowCount; i++)
                {
                    //選択チェックありの行は画像番号、なしの行は画像情報をListに保存
                    if ((bool)dgvMain.Rows[i].Cells["選択"].Value)
                    {
                        lstNumDel.Add(Convert.ToInt32(dgvMain.Rows[i].Cells["画像番号"].Value));
                    }
                    else
                    {
                        lstNumUpd.Add(Convert.ToInt32(dgvMain.Rows[i].Cells["画像番号"].Value));
                    }
                }
                //削除レコード未選択の場合は処理を抜ける
                if (lstNumDel.Count == 0)
                {
                    MessageBox.Show("削除する画像を選択してください。");
                    return;
                }
                else
                {
                    //確認メッセージを表示
                    DialogResult drResult = MessageBox.Show("選択した画像情報を削除します。よろしいですか？",
                                                            "確認",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question,
                                                            MessageBoxDefaultButton.Button2);
                    if (drResult == DialogResult.No)
                    {
                        //いいえボタン押下時、処理を抜ける
                        return;
                    }
                }

                SQLiteConnectionStringBuilder sb = new SQLiteConnectionStringBuilder { DataSource = mdc.GetDBFileName() };
                using (SQLiteConnection cn = new SQLiteConnection(sb.ToString()))
                {
                    //DB接続開始
                    cn.Open();
                    //*** トランザクション開始 ***
                    using (SQLiteTransaction tran = cn.BeginTransaction())
                    {
                        try
                        {
                            using (SQLiteCommand cmd = new SQLiteCommand(cn))
                            {
                                //+++ 削除処理 +++
                                //削除する画像番号を文字列に(num1,num2...)
                                sBuf = lstNumDel[0].ToString();
                                for (int i = 1; i < lstNumDel.Count; i++)
                                {
                                    sBuf += "," + lstNumDel[i].ToString();
                                }
                                StringBuilder sbSqlText = new StringBuilder();
                                sbSqlText.AppendLine(@"DELETE FROM PIC")
                                         .AppendLine("  WHERE ＩＤ = @ＩＤ")
                                         .AppendLine("    AND 画像番号 IN (" + sBuf + ")");
                                cmd.CommandText = sbSqlText.ToString();
                                //パラメータ：ＩＤ
                                cmd.Parameters.AddWithValue("@ＩＤ", Convert.ToInt32(txtId.Text));
                                //SQL実行
                                cmd.ExecuteNonQuery();

                                //(削除テストstart)
                                sbSqlText.Clear();
                                sbSqlText.AppendLine(@"select *")
                                         .AppendLine("   from PIC")
                                         .AppendLine("  where ＩＤ = @ＩＤ")
                                         .AppendLine(" order by 画像番号");
                                cmd.CommandText = sbSqlText.ToString();
                                cmd.Parameters.AddWithValue("@ＩＤ", Convert.ToInt32(txtId.Text));
                                sBuf = "";
                                using (SQLiteDataReader reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        sBuf += reader["画像番号"].ToString() + ":" + reader["ファイル名"] + "\n";
                                    }
                                    MessageBox.Show(sBuf);
                                }
                                //(削除テストend)

                                //+++ 更新処理 +++
                                sbSqlText.Clear();
                                sbSqlText.AppendLine(@"UPDATE PIC SET")
                                         .AppendLine("       画像番号 = @画像番号")
                                         .AppendLine("  WHERE ＩＤ = @ＩＤ")
                                         .AppendLine("    AND 画像番号 = @W画像番号");
                                cmd.CommandText = sbSqlText.ToString();
                                for (int i = 0; i < lstNumUpd.Count; i++)
                                {
                                    //画像番号(ソート後)
                                    cmd.Parameters.AddWithValue("@画像番号", i + 1);
                                    //ＩＤ
                                    cmd.Parameters.AddWithValue("@ＩＤ", Convert.ToInt32(txtId.Text));
                                    //画像番号(ソート前)
                                    cmd.Parameters.AddWithValue("@W画像番号", lstNumUpd[i]);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            //*** トランザクション終了 ***
                            tran.Commit();

                            //画像情報一覧を再表示
                            btnRefresh_Click(null, null);
                        }
                        catch
                        {
                            //例外発生時はロールバック
                            tran.Rollback();
                            //例外をスロー
                            throw;
                        }
                    }
                    //接続を閉じる
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
            関数名：dgvMain_CellClick
              説明：セルクリック
        *************************************************************************************/
        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //選択行の画像パスを取得
            string? sPicPath = dgvMain.Rows[e.RowIndex].Cells["パス"].Value.ToString();
            //画像を表示
            PicView(sPicPath);
        }

        /*************************************************************************************
            関数名：FormClear
              説明：Form全体をクリア
        *************************************************************************************/
        private void FormClear()
        {
            //DataGridView
            dgvMain.Rows.Clear();
            //PictureBox
            pbxSample.Image = null;
        }

        /*************************************************************************************
            関数名：PicView
              説明：PictureBoxに画像を表示
        *************************************************************************************/
        private void PicView(string? _sPicPath)
        {
            string? sPicPath = _sPicPath;
            //画像パスが不正な場合は画像を非表示
            if (!File.Exists(sPicPath))
            {
                pbxSample.Image = null;
                return;
            }
            else
            {
                pbxSample.ImageLocation = sPicPath;
                pbxSample.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
    }
}
