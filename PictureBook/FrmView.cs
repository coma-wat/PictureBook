/**********************************************************************************************
 *  モジュール名：FrmView
 *          説明：詳細ページ
 **********************************************************************************************/
using System.Data;
using System.IO;
using System.Data.SQLite;
using System.Text;
using static PictureBook.MyDataControl;

namespace PictureBook
{
    public partial class FrmView : Form
    {
        /*** クラス内定数 ***/
        private
        const int INT_MODE_NREG = 0;    //0.新規登録
        const int INT_MODE_EDIT = 1;    //1.編集
        const int INT_MODE_VIEW = 2;    //2.詳細表示
        const string STR_TITLE_NREG = "新規登録";
        const string STR_TITLE_EDIT = "編集";
        const string STR_TITLE_VIEW = "詳細表示";

        /*** クラス内変数 ***/
        private
        MyDataControl mdc;
        int intMode;                                    //表示モード[1:照会  2.編集]
        int intPicIdx = 0;                              //現在表示中の画像Index
        List<PicData> lstPics = new List<PicData>();    //画像情報格納用リスト
        bool bChangeFlg = false;                        //データ変更フラグ
        string sPrevText = "";                          //変更前テキスト(各TextBoxの前値を格納)

        /*************************************************************************************
            関数名：コンストラクタ(引数なし)
              説明：新規登録モードで起動する
        *************************************************************************************/
        public FrmView()
        {
            //フォーム初期処理
            InitializeComponent();
            //データベース操作用インスタンスを用意
            mdc = new MyDataControl();
            //表示モード
            intMode = INT_MODE_NREG;        //0.新規登録
            //表示モード設定
            ModeChange(intMode);
            //TextBoxのEnterキー押下時のビープ音を抑制
            foreach (Control c in this.Controls)
            {
                if (c.GetType().Equals(typeof(TextBox)))
                {
                    ((TextBox)c).KeyDown += MuteBeep;
                }
            }
        }

        /*************************************************************************************
            関数名：コンストラクタ(引数あり)
              説明：表示モードで起動する
        *************************************************************************************/
        public FrmView(int _intId)
        {
            //フォーム初期処理
            InitializeComponent();
            //データベース操作用インスタンスを用意
            mdc = new MyDataControl();
            //表示モード
            intMode = INT_MODE_VIEW;        //1.表示
            //表示モード設定
            ModeChange(intMode);

            //データを各項目にセット
            DataView(_intId);
            //画像のファイルパスをリストに格納
            PicDataRead(_intId);
            //登録された画像を表示(画像番号：1)
            if (lstPics.Count != 0)
            {
                PicView(lstPics[0].GetPicPath());
            }
            //IDを記録
            txtId.Text = _intId.ToString();

            //TextBoxのEnterキー押下時のビープ音を抑制
            foreach (Control c in this.Controls)
            {
                if (c.GetType().Equals(typeof(TextBox)))
                {
                    ((TextBox)c).KeyDown += MuteBeep;
                }
            }
        }

        /*************************************************************************************
                関数名：MuteBeep
                  説明：TextBoxのEnterキー押下時の音を鳴らさない
        *************************************************************************************/
        private void MuteBeep(object? obj, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        /*************************************************************************************
                関数名：txtName_Enter
                  説明：名称Enter
        *************************************************************************************/
        private void txtName_Enter(object sender, EventArgs e)
        {
            try
            {
                //現在格納されている値を変数に格納
                sPrevText = ((TextBox)sender).Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
                関数名：txtName_Leave
                  説明：名称Leave
        *************************************************************************************/
        private void txtName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (((TextBox)sender).Text != sPrevText)
                {
                    //画面変更ON
                    FormChangeOn();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
                関数名：txtSName_Enter
                  説明：学名Enter
        *************************************************************************************/
        private void txtSName_Enter(object sender, EventArgs e)
        {
            try
            {
                //現在格納されている値を変数に格納
                sPrevText = ((TextBox)sender).Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
                関数名：txtSName_Leave
                  説明：学名Leave
        *************************************************************************************/
        private void txtSName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (((TextBox)sender).Text != sPrevText)
                {
                    //画面変更ON
                    FormChangeOn();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
                関数名：txtFamily_Enter
                  説明：科Enter
        *************************************************************************************/
        private void txtFamily_Enter(object sender, EventArgs e)
        {
            try
            {
                //現在格納されている値を変数に格納
                sPrevText = ((TextBox)sender).Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
                関数名：txtFamily_Leave
                  説明：科Leave
        *************************************************************************************/
        private void txtFamily_Leave(object sender, EventArgs e)
        {
            try
            {
                if (((TextBox)sender).Text != sPrevText)
                {
                    //画面変更ON
                    FormChangeOn();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
                関数名：txtGenus_Enter
                  説明：属Enter
        *************************************************************************************/
        private void txtGenus_Enter(object sender, EventArgs e)
        {
            try
            {
                //現在格納されている値を変数に格納
                sPrevText = ((TextBox)sender).Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
                関数名：txtGenul_Leave
                  説明：属Leave
        *************************************************************************************/
        private void txtGenus_Leave(object sender, EventArgs e)
        {
            try
            {
                if (((TextBox)sender).Text != sPrevText)
                {
                    //画面変更ON
                    FormChangeOn();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
                関数名：txtHabitat_Enter
                  説明：生息環境Enter
        *************************************************************************************/
        private void txtHabitat_Enter(object sender, EventArgs e)
        {
            try
            {
                //現在格納されている値を変数に格納
                sPrevText = ((TextBox)sender).Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
                関数名：txtHabitat_Leave
                  説明：生息環境Leave
        *************************************************************************************/
        private void txtHabitat_Leave(object sender, EventArgs e)
        {
            try
            {
                if (((TextBox)sender).Text != sPrevText)
                {
                    //画面変更ON
                    FormChangeOn();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
                関数名：txtDesc_Enter
                  説明：説明Enter
        *************************************************************************************/
        private void txtDesc_Enter(object sender, EventArgs e)
        {
            try
            {
                //現在格納されている値を変数に格納
                sPrevText = ((TextBox)sender).Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
                関数名：txtDesc_Leave
                  説明：説明Leave
        *************************************************************************************/
        private void txtDesc_Leave(object sender, EventArgs e)
        {
            try
            {
                if (((TextBox)sender).Text != sPrevText)
                {
                    //画面変更ON
                    FormChangeOn();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
            関数名：btnClose_Click
              説明：[閉じる]ボタン押下
        *************************************************************************************/
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (bChangeFlg)
                {
                    //変更があるときは確認メッセージを表示
                    DialogResult drResult = MessageBox.Show("変更があります。破棄してもよろしいですか？",
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
                //フォームを閉じる
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
            関数名：btnNewReg_Click
              説明：[新規作成]ボタン押下
        *************************************************************************************/
        private void btnNewReg_Click(object sender, EventArgs e)
        {
            try
            {
                if (bChangeFlg)
                {
                    //変更があるときは確認メッセージを表示
                    DialogResult drResult = MessageBox.Show("変更があります。破棄してもよろしいですか？",
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
                intMode = INT_MODE_NREG;    //0.新規登録
                //表示モード変更
                ModeChange(intMode);
                //フォームをクリア
                FormClear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
            関数名：btnEdit_Click
              説明：[編集]ボタン押下
        *************************************************************************************/
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                intMode = INT_MODE_EDIT;    //1.編集
                //表示モード変更
                ModeChange(intMode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
            関数名：btnCancel_Click
              説明：[取消]ボタン押下
        *************************************************************************************/
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (bChangeFlg)
                {
                    //変更があるときは確認メッセージを表示
                    DialogResult drResult = MessageBox.Show("変更があります。破棄してもよろしいですか？",
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
                //現在のIDのデータを再表示
                switch (intMode)
                {
                    //0.新規登録
                    case INT_MODE_NREG:
                        //フォームをクリア
                        FormClear();
                        break;
                    //1.編集
                    case INT_MODE_EDIT:
                        //変更前のデータを再表示
                        DataView(Convert.ToInt32(txtId.Text));
                        //画像情報を再取得
                        PicDataRead(Convert.ToInt32(txtId.Text));
                        //表示モードを2.詳細表示に
                        intMode = INT_MODE_VIEW;
                        ModeChange(intMode);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
            関数名：btnSave_Click
              説明：[保存]ボタン押下
        *************************************************************************************/
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //確認メッセージ
                DialogResult drResult = MessageBox.Show("登録します。よろしいですか？",
                                                        "確認",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question,
                                                        MessageBoxDefaultButton.Button2);
                if (drResult == DialogResult.Yes)
                {
                    SQLiteConnectionStringBuilder sb = new SQLiteConnectionStringBuilder { DataSource = mdc.GetDBFileName() };
                    using (SQLiteConnection cn = new SQLiteConnection(sb.ToString()))
                    {
                        DataTable dtUpdate = new DataTable();
                        cn.Open();

                        //*** トランザクション開始 ***
                        using (SQLiteTransaction tran = cn.BeginTransaction())
                        {
                            try
                            {
                                using (SQLiteCommand cmd = new SQLiteCommand(cn))
                                {
                                    //-- 基本情報 --
                                    StringBuilder sbUpdate = new StringBuilder();
                                    //新規作成
                                    switch (intMode)
                                    {
                                        //0.新規作成
                                        case INT_MODE_NREG:
                                            //ＩＤを取得
                                            sbUpdate.AppendLine(@"SELECT LAST_INSERT_ROWID() AS NEWID FROM BASE");
                                            cmd.CommandText = sbUpdate.ToString();
                                            using (SQLiteDataReader reader = cmd.ExecuteReader())
                                            {
                                                reader.Read();
                                                //取得したIDをテキストボックスに格納
                                                txtId.Text = reader["NEWID"].ToString();
                                                reader.Close();
                                            }
                                            //追加処理
                                            sbUpdate.Clear();
                                            sbUpdate.AppendLine(@"INSERT INTO BASE(")
                                                    .AppendLine("   ＩＤ")
                                                    .AppendLine("  ,名称")
                                                    .AppendLine("  ,学名")
                                                    .AppendLine("  ,科")
                                                    .AppendLine("  ,属")
                                                    .AppendLine("  ,生息環境")
                                                    .AppendLine("  ,説明")
                                                    .AppendLine("  ,登録日")
                                                    .AppendLine("  ,更新日")
                                                    .AppendLine("  ,更新回数")
                                                    .AppendLine(")VALUES(")
                                                    .AppendLine("   @ＩＤ")
                                                    .AppendLine("  ,@名称")
                                                    .AppendLine("  ,@学名")
                                                    .AppendLine("  ,@科")
                                                    .AppendLine("  ,@属")
                                                    .AppendLine("  ,@生息環境")
                                                    .AppendLine("  ,@説明")
                                                    .AppendLine("  ,DATETIME('NOW', 'LOCALTIME')")
                                                    .AppendLine("  ,DATETIME('NOW', 'LOCALTIME')")
                                                    .AppendLine("  ,0")
                                                    .AppendLine(")");
                                            cmd.CommandText = sbUpdate.ToString();
                                            //取得したIDをセット
                                            cmd.Parameters.AddWithValue("@ＩＤ", Convert.ToInt32(txtId.Text));
                                            break;

                                        //1.編集
                                        case INT_MODE_EDIT:
                                            sbUpdate.AppendLine(@"UPDATE BASE")
                                                    .AppendLine("    SET  名称     = @名称")
                                                    .AppendLine("        ,学名     = @学名")
                                                    .AppendLine("        ,科       = @科")
                                                    .AppendLine("        ,属       = @属")
                                                    .AppendLine("        ,生息環境 = @生息環境")
                                                    .AppendLine("        ,説明     = @説明")
                                                    .AppendLine("        ,更新日   = DATETIME('NOW', 'LOCALTIME')")
                                                    .AppendLine("        ,更新回数 = 更新回数 + 1")
                                                    .AppendLine("  WHERE ＩＤ = @ＩＤ");
                                            cmd.CommandText = sbUpdate.ToString();
                                            //WHERE句バインド変数に値をセット
                                            cmd.Parameters.AddWithValue("@ＩＤ", Convert.ToInt32(txtId.Text));
                                            break;
                                    }
                                    //パラメータセット
                                    cmd.Parameters.AddWithValue("@名称", txtName.Text);
                                    cmd.Parameters.AddWithValue("@学名", txtSName.Text);
                                    cmd.Parameters.AddWithValue("@科", txtFamily.Text);
                                    cmd.Parameters.AddWithValue("@属", txtGenus.Text);
                                    cmd.Parameters.AddWithValue("@生息環境", txtHabitat.Text);
                                    cmd.Parameters.AddWithValue("@説明", txtDesc.Text);
                                    //SQL実行
                                    cmd.ExecuteNonQuery();
                                }
                                //*** トランザクション終了(コミット) ***
                                tran.Commit();

                                //データ変更フラグOFF
                                FormChangeOff();
                                //更新した内容を再表示
                                btnCancel_Click(sender, e);
                            }
                            catch
                            {
                                //例外発生時はロールバック
                                tran.Rollback();
                                //例外を上のcatchにスロー
                                throw;
                            }
                        }
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
            関数名：btnPicPrev_Click
              説明：1つ前の画像を表示する 
        *************************************************************************************/
        private void btnPicPrev_Click(object sender, EventArgs e)
        {
            //画像情報が0件の場合は処理を抜ける
            if (lstPics.Count == 0)
            {
                return;
            }
            //表示中画像Indexを-1
            intPicIdx--;
            //画像Indexが-1のときは最後尾の画像情報Index
            if (intPicIdx == -1)
            {
                intPicIdx = lstPics.Count - 1;
            }
            //画像を表示
            PicView(lstPics[intPicIdx].GetPicPath());
        }

        /*************************************************************************************
            関数名：btnPicNext_Click
              説明：1つ次の画像を表示する 
        *************************************************************************************/
        private void btnPicNext_Click(object sender, EventArgs e)
        {
            //画像情報が0件の場合は処理を抜ける
            if (lstPics.Count == 0)
            {
                return;
            }
            //表示中画像Indexを+1
            intPicIdx++;
            //画像Indexが画像情報の件数と等しいときはIndexを0
            if (intPicIdx == lstPics.Count)
            {
                intPicIdx = 0;
            }
            //画像を表示
            PicView(lstPics[intPicIdx].GetPicPath());
        }

        /*************************************************************************************
             関数名：btnPicList_Click
               説明：画像一覧ボタン押下
         *************************************************************************************/
        private void btnPicList_Click(object sender, EventArgs e)
        {
            try
            {
                FrmPicList frmPicList = new FrmPicList(Convert.ToInt32(txtId.Text));
                frmPicList.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
             関数名：FormChangeOn
               説明：データ変更ON
         *************************************************************************************/
        private void FormChangeOn()
        {
            try
            {
                bChangeFlg = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
             関数名：FormChangeOff
               説明：データ変更OFF
         *************************************************************************************/
        private void FormChangeOff()
        {
            try
            {
                bChangeFlg = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
             関数名：ModeChange
               説明：フォームの表示モードを変更する
         *************************************************************************************/
        private void ModeChange(int intMode)
        {
            try
            {
                switch (intMode)
                {
                    //0.新規登録
                    case INT_MODE_NREG:
                        this.Text = STR_TITLE_NREG;
                        txtName.ReadOnly = false;
                        txtSName.ReadOnly = false;
                        txtFamily.ReadOnly = false;
                        txtGenus.ReadOnly = false;
                        txtHabitat.ReadOnly = false;
                        txtDesc.ReadOnly = false;
                        btnEdit.Enabled = false;
                        btnNewReg.Enabled = false;
                        btnCancel.Enabled = true;
                        btnSave.Enabled = true;
                        break;
                    //1.編集
                    case INT_MODE_EDIT:
                        this.Text = STR_TITLE_EDIT;
                        txtName.ReadOnly = false;
                        txtSName.ReadOnly = false;
                        txtFamily.ReadOnly = false;
                        txtGenus.ReadOnly = false;
                        txtHabitat.ReadOnly = false;
                        txtDesc.ReadOnly = false;
                        btnEdit.Enabled = false;
                        btnNewReg.Enabled = true;
                        btnCancel.Enabled = true;
                        btnSave.Enabled = true;
                        break;
                    //2.詳細表示
                    case INT_MODE_VIEW:
                        this.Text = STR_TITLE_VIEW;
                        txtName.ReadOnly = true;
                        txtSName.ReadOnly = true;
                        txtFamily.ReadOnly = true;
                        txtGenus.ReadOnly = true;
                        txtHabitat.ReadOnly = true;
                        txtDesc.ReadOnly = true;
                        btnEdit.Enabled = true;
                        btnNewReg.Enabled = true;
                        btnCancel.Enabled = false;
                        btnSave.Enabled = false;
                        break;
                }
                //データ変更フラグOFF
                FormChangeOff();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
            関数名：FormClear
              説明：フォームを初期化する
        *************************************************************************************/
        private void FormClear()
        {
            //入力項目
            txtId.Text = "";
            txtName.Text = "";
            txtSName.Text = "";
            txtFamily.Text = "";
            txtGenus.Text = "";
            txtHabitat.Text = "";
            txtDesc.Text = "";
            //画像情報リスト
            lstPics.Clear();
            //表示中画像Index
            intPicIdx = 0;
            //表示画像クリア
            pbxPic.Image = null;
            //データ変更フラグOFF
            FormChangeOff();
        }

        /*************************************************************************************
             関数名：DataView
               説明：各項目をデータベースから取得し表示する 
         *************************************************************************************/
        private void DataView(int intId)
        {
            try
            {
                SQLiteConnectionStringBuilder sb = new SQLiteConnectionStringBuilder { DataSource = mdc.GetDBFileName() };
                using (SQLiteConnection cn = new SQLiteConnection(sb.ToString()))
                {
                    DataTable dtMain = new DataTable();
                    cn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(cn))
                    {
                        //-- 基本情報 --
                        StringBuilder sbSelect = new StringBuilder();
                        sbSelect.AppendLine(@"SELECT *")
                                .AppendLine("   FROM BASE")
                                .AppendLine("  WHERE ＩＤ = @ＩＤ");
                        cmd.CommandText = sbSelect.ToString();
                        cmd.Parameters.AddWithValue("@ＩＤ", intId);
                        SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                        da.Fill(dtMain);
                    }
                    cn.Close();
                    //名称
                    txtName.Text = dtMain.Rows[0]["名称"].ToString();
                    //学名
                    txtSName.Text = dtMain.Rows[0]["学名"].ToString();
                    //科
                    txtFamily.Text = dtMain.Rows[0]["科"].ToString();
                    //属
                    txtGenus.Text = dtMain.Rows[0]["属"].ToString();
                    //生息環境
                    txtHabitat.Text = dtMain.Rows[0]["生息環境"].ToString();
                    //説明
                    txtDesc.Text = dtMain.Rows[0]["説明"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
            関数名：PicDataRead
              説明：画像情報をデータベースから取得する 
        *************************************************************************************/
        // FrmViewで表示する画像の情報をデータテーブルに格納(未修整)
        private void PicDataRead(int intId)
        {
            try
            {
                DataTable dtPic = new DataTable();
                lstPics.Clear();
                SQLiteConnectionStringBuilder sb = new SQLiteConnectionStringBuilder { DataSource = mdc.GetDBFileName() };
                using (SQLiteConnection cn = new SQLiteConnection(sb.ToString()))
                {
                    cn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(cn))
                    {
                        StringBuilder sbPic = new StringBuilder();
                        sbPic.AppendLine("SELECT 画像番号")
                             .AppendLine("      ,ファイル名")
                             .AppendLine("      ,パス")
                             .AppendLine("  FROM PIC")
                             .AppendLine(" WHERE ＩＤ = @ＩＤ")
                             .AppendLine("ORDER BY 画像番号");
                        cmd.CommandText = sbPic.ToString();
                        cmd.Parameters.AddWithValue("@ＩＤ", intId);
                        //ファイルパスをリストに保存
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PicData tmpPicData = new PicData(Convert.ToInt32(reader["画像番号"].ToString())
                                                                , reader["ファイル名"].ToString() ?? ""
                                                                , reader["パス"].ToString() ?? ""
                                                                 );
                                lstPics.Add(tmpPicData);
                            }
                            reader.Close();
                        }
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*************************************************************************************
            関数名：PicDataRead
              説明：画像情報をデータベースから取得する 
        *************************************************************************************/
        private void PicView(string _PicPath)
        {
            //画像パスが不正の場合はPictureBoxをクリアして処理を抜ける
            if (!File.Exists(_PicPath))
            {
                pbxPic.Image = null;
                return;
            }
            else
            {
                pbxPic.ImageLocation = _PicPath;
                //PictureBoxの大きさに合わせて画像を表示
                pbxPic.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
    }
}
