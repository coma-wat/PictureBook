/**********************************************************************************************
 *  モジュール名：FrmTop
 *          説明：トップページ
 **********************************************************************************************/
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace PictureBook
{
    public partial class FrmTop : Form
    {
        /*** クラス内定数 ***/

        /*** クラス内変数 ***/
        private DataTable dtMain;
        private MyDataControl mdc;

        /*************************************************************************************
        *   関数名：コンストラクタ
        *     説明：TOP画面作成時の処理
        *************************************************************************************/
        public FrmTop()
        {
            //フォーム初期化
            InitializeComponent();

            //データテーブル作成
            dtMain = new DataTable();
            //データ表示用インスタンス作成
            mdc = new MyDataControl();
            //TextBoxのEnterキー押下時のビープ音を抑制
            foreach (Control c in this.Controls)
            {
                //Panel内にあるTextBoxに適用
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
        *   関数名：MuteBeep
        *     説明：Enterキー押下時の音を鳴らさない
        *************************************************************************************/
        private void MuteBeep(object? obj, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        /*************************************************************************************
        *   関数名：btnSelect_Click
        *     説明：検索ボタン押下
        *************************************************************************************/
        public void btnSelect_Click(Object sender, EventArgs e)
        {
            try
            {
                string sBuf = "";
                //データテーブルをクリア
                this.dtMain.Clear();
                //データグリッドビューをクリア
                dgvMain.Rows.Clear();
                //データテーブルに抽出したデータをセット
                SQLiteConnectionStringBuilder sb = new SQLiteConnectionStringBuilder { DataSource = mdc.GetDBFileName() };
                using (SQLiteConnection cn = new SQLiteConnection(sb.ToString()))
                {
                    cn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(cn))
                    {
                        StringBuilder sbSelect = new StringBuilder();
                        sbSelect.AppendLine(@"SELECT *")
                                .AppendLine("   FROM BASE");
                        string sCon = " WHERE ";                //WHERE句の接続文字
                        //科
                        if (txtFamily.Text != "")
                        {
                            sbSelect.AppendLine(sCon + "科 LIKE \'%" + txtFamily.Text + "%\'");
                            sCon = "   AND ";
                        }
                        //属
                        if (txtGenus.Text != "")
                        {
                            sbSelect.AppendLine(sCon + "属 LIKE \'%" + txtGenus.Text + "%\'");
                            sCon = "   AND ";
                        }
                        //名称
                        if (txtName.Text != "")
                        {
                            sbSelect.AppendLine(sCon + "名称 LIKE \'%" + txtName.Text + "%\'");
                            sCon = "   AND ";
                        }
                        //キーワード(パターンマッチングをorで実現する)
                        if (txtKeyWord.Text != "")
                        {
                            //文字列の前後の空白を除去
                            sBuf = txtKeyWord.Text.Trim();
                            //文字列の全角スペースを半角に置換
                            sBuf = sBuf.Replace("　", " ");
                            //半角スペースを「%',%'」に変換
                            sBuf = sBuf.Replace(" ", "%\',\'%");
                            //両端に「'」と「%」を付与
                            sBuf = "\'%" + sBuf + "%\'";
                            //入力文字列を分割して配列にセット
                            String[] sWords = sBuf.Split(",");
                            //キーワードを抽出条件に加える
                            //(科)
                            sbSelect.AppendLine(sCon + "( 科 LIKE (" + sWords[0] + ")");
                            sCon = "      OR ";
                            for (int i = 1; i < sWords.Length; i++)
                            {
                                sbSelect.AppendLine(sCon + "  科 LIKE (" + sWords[i] + ")");
                            }
                            //(属)
                            for (int i = 0; i < sWords.Length; i++)
                            {
                                sbSelect.AppendLine(sCon + "  属 LIKE (" + sWords[i] + ")");
                            }
                            //(名称)
                            for (int i = 0; i < sWords.Length; i++)
                            {
                                sbSelect.AppendLine(sCon + "  名称 LIKE (" + sWords[i] + ")");
                            }
                            //(説明)
                            for (int i = 0; i < sWords.Length; i++)
                            {
                                sbSelect.AppendLine(sCon + "  説明 LIKE (" + sWords[i] + ")");
                            }
                            sbSelect.AppendLine(")");
                        }
                        sbSelect.AppendLine("ORDER BY 名称");
                        cmd.CommandText = sbSelect.ToString();
                        SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                        da.Fill(dtMain);
                    }
                    cn.Close();
                }
                //レコードがない場合は処理を抜ける
                if (dtMain.Rows.Count == 0)
                {
                    return;
                }
                //データグリッドビューにデータを表示
                dgvMain.RowCount = dtMain.Rows.Count;
                for (int i = 0; i < dtMain.Rows.Count; i++)
                {
                    //ＩＤ(非表示)
                    dgvMain.Rows[i].Cells["ＩＤ"].Value = dtMain.Rows[i]["ＩＤ"].ToString();
                    //名前
                    dgvMain.Rows[i].Cells["名称"].Value = dtMain.Rows[i]["名称"].ToString();
                    //科
                    dgvMain.Rows[i].Cells["科"].Value = dtMain.Rows[i]["科"].ToString();
                    //属
                    dgvMain.Rows[i].Cells["属"].Value = dtMain.Rows[i]["属"].ToString();
                    //説明
                    dgvMain.Rows[i].Cells["説明"].Value = dtMain.Rows[i]["説明"].ToString();
                }
                //チェックボックスを初期化
                for (int i = 0; i < dgvMain.Rows.Count; i++)
                {
                    dgvMain.Rows[i].Cells["選択"].Value = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
        *   関数名：btnClose_Click
        *     説明：閉じるボタン押下
        *************************************************************************************/
        public void btnClose_Click(Object sender, EventArgs e)
        {
            try
            {
                //フォームを閉じる
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
        *   関数名：btnView_Click
        *     説明：詳細ボタン押下
        *************************************************************************************/
        public void btnView_Click(Object sender, EventArgs e)
        {
            try
            {
                //詳細画面を詳細表示モードで起動
                ViewOpen();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
        *   関数名：btnNewReg_Click
        *     説明：新規登録ボタン押下
        *************************************************************************************/
        private void btnNewReg_Click(object sender, EventArgs e)
        {
            try
            {
                //詳細画面を新規登録モードで起動
                FrmView frmView = new FrmView();
                frmView.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /*************************************************************************************
        *   関数名：btnDelete_Click
        *     説明：削除ボタン押下
        *************************************************************************************/
        public void btnDelete_Click(Object sender, EventArgs e)
        {
            try
            {
                List<string> lstId = new List<string>();
                string strId = "";
                //「選択」列がチェックされている行のＩＤを取得
                for (int i = 0; i < dgvMain.RowCount; i++)
                {
                    if ((bool)dgvMain.Rows[i].Cells["選択"].Value)
                    {
                        //チェックのある行のＩＤをリストに保存
                        lstId.Add(dgvMain.Rows[i].Cells["ＩＤ"].Value.ToString() ?? "");   //セルの値がnullの時は空白をセット
                    }
                }
                //選択行が0の場合はメッセージを表示して処理を抜ける
                if(lstId.Count == 0)
                {
                    MessageBox.Show("削除するレコードを選択してください。");
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

                //選択行1
                if (lstId.Count > 0)
                {
                    strId = lstId[0];
                }
                //選択行2～
                for (int i = 1; i < lstId.Count; i++)
                {
                    strId += ", " + lstId[i];
                }
                //削除処理
                SQLiteConnectionStringBuilder sb = new SQLiteConnectionStringBuilder { DataSource = mdc.GetDBFileName() };
                using (SQLiteConnection cn = new SQLiteConnection(sb.ToString()))
                {
                    //データベースへの接続ON
                    cn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(cn))
                    {
                        //-- PICテーブルの該当ＩＤレコードを削除 --
                        //SQL文作成
                        StringBuilder sbDelete = new StringBuilder();
                        sbDelete.Append("DELETE FROM PIC");
                        sbDelete.Append(" WHERE EXISTS (SELECT 1 FROM BASE");
                        sbDelete.Append("         WHERE BASE.ＩＤ IN (" + strId + "))");
                        cmd.CommandText = sbDelete.ToString();
                        //SQL実行
                        cmd.ExecuteNonQuery();
                        //-- BASEテーブルの該当ＩＤレコードを削除 --
                        //SQL文作成
                        sbDelete.Clear();
                        sbDelete.Append("DELETE FROM BASE");
                        sbDelete.Append(" WHERE ＩＤ IN (" + strId + ")");
                        cmd.CommandText = sbDelete.ToString();
                        //SQL実行
                        cmd.ExecuteNonQuery();
                    }
                    cn.Close();
                }
                //データ再抽出
                btnSelect_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
        *   関数名：dgvMain_CellDouble_Click
        *     説明：セルダブルクリック
        *************************************************************************************/
        private void dgvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //詳細画面を詳細表示モードで起動
                ViewOpen();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
        *   関数名：ViewOpen
        *     説明：詳細画面表示
        *************************************************************************************/
        private void ViewOpen()
        {
            try
            {
                //行情報が取得できないときは処理を抜ける
                if (dgvMain.CurrentRow == null)
                {
                    return;
                }
                //選択中の行のＩＤを取得して詳細画面を詳細表示モードで起動
                FrmView frmView = new FrmView(Convert.ToInt32(dgvMain.Rows[dgvMain.CurrentRow.Index].Cells["ＩＤ"].Value.ToString()));
                frmView.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
