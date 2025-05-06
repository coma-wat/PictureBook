using System.Text;
using System.Data.SQLite;

namespace PictureBook
{
    class MyDataControl
    {
        //データベースファイル名
        const String STR_DB_FILE_NAME = "data.db";

        //画像情報管理用
        public struct PicData
        {
            private
            int intNum;         //画像番号
            string strPath;     //画像パス
            string strName;     //名称
            //コンストラクタ
            public PicData(int _intId, string _strName, string _strPath)
            {
                intNum = _intId;
                strName = _strName;
                strPath = _strPath;
            }

            //画像パスを取得
            public string GetPicPath()
            {
                return strPath;
            }
        }

        /*************************************************************************************
            関数名：コンストラクタ
              説明：
        *************************************************************************************/
        public MyDataControl()
        {
            //データベースファイルがない場合は作成
            if (!File.Exists(@"./" + STR_DB_FILE_NAME))
            {
                // BASE テーブルを作成
                SQLiteConnectionStringBuilder sb = new SQLiteConnectionStringBuilder { DataSource = STR_DB_FILE_NAME };
                using (SQLiteConnection cn = new SQLiteConnection(sb.ToString()))
                {
                    cn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(cn))
                    {
                        StringBuilder sbCreate = new StringBuilder();
                        sbCreate.AppendLine(@"CREATE TABLE IF NOT EXISTS BASE(")
                                .AppendLine("        ＩＤ INTEGER NOT NULL PRIMARY KEY")
                                .AppendLine("       ,名称 TEXT")
                                .AppendLine("       ,学名 TEXT")
                                .AppendLine("       ,科 TEXT")
                                .AppendLine("       ,属 TEXT")
                                .AppendLine("       ,生息環境 TEXT")
                                .AppendLine("       ,説明 TEXT")
                                .AppendLine("       ,登録日 DATE")
                                .AppendLine("       ,更新日 DATE")
                                .AppendLine("       ,更新回数 INTEGER")
                                .AppendLine(")");
                        cmd.CommandText = sbCreate.ToString();
                        cmd.ExecuteNonQuery();

                        // PIC テーブルを作成
                        sbCreate.Clear();
                        sbCreate.AppendLine(@"CREATE TABLE IF NOT EXISTS PIC(")
                                .AppendLine("        ＩＤ INTEGER NOT NULL")
                                .AppendLine("       ,画像番号 INTEGER NOT NULL")
                                .AppendLine("       ,ファイル名 TEXT")
                                .AppendLine("       ,パス TEXT")
                                .AppendLine("       ,PRIMARY KEY(ＩＤ, 画像番号)")
                                .AppendLine("       ,FOREIGN KEY(ＩＤ) REFERENCES BASE(ＩＤ)")
                                .AppendLine(")");
                        cmd.CommandText = sbCreate.ToString();
                        cmd.ExecuteNonQuery();

                        //サンプルレコードをセット
                        sbCreate.Clear();
                        sbCreate.AppendLine(@"INSERT INTO BASE (ＩＤ, 名称, 学名, 科, 属, 生息環境, 説明, 登録日, 更新日, 更新回数)")
                                .AppendLine("           VALUES (1, 'カタクリ', 'a', 'b', 'c', 'カタクリ生息環境テスト', 'カタクリ説明テスト', DATETIME('NOW', 'LOCALTIME'), DATETIME('NOW', 'LOCALTIME'), 0)");
                        cmd.CommandText = sbCreate.ToString();
                        cmd.ExecuteNonQuery();
                        sbCreate.Clear();
                        sbCreate.AppendLine(@"INSERT INTO BASE (ＩＤ, 名称, 学名, 科, 属, 生息環境, 説明, 登録日, 更新日, 更新回数)")
                                .AppendLine("           VALUES (2, 'ヤマユリ', 'd', 'e', 'f', 'ヤマユリ生息環境テスト', 'ヤマユリ説明テスト', DATETIME('NOW', 'LOCALTIME'), DATETIME('NOW', 'LOCALTIME'), 0)");
                        cmd.CommandText = sbCreate.ToString();
                        cmd.ExecuteNonQuery();
                        sbCreate.Clear();
                        sbCreate.AppendLine(@"INSERT INTO BASE (ＩＤ, 名称, 学名, 科, 属, 生息環境, 説明, 登録日, 更新日, 更新回数)")
                                .AppendLine("           VALUES (3, 'シュンラン', 'g', 'h', 'i', 'シュンラン生息環境テスト', 'シュンラン説明テスト', DATETIME('NOW', 'LOCALTIME'), DATETIME('NOW', 'LOCALTIME'), 0)");
                        cmd.CommandText = sbCreate.ToString();
                        cmd.ExecuteNonQuery();
                    }
                    cn.Close();
                }
            }
        }

        /*************************************************************************************
            関数名：GetDBFileName
              説明：データベースファイル名を取得
        *************************************************************************************/
        public String GetDBFileName()
        {
            return STR_DB_FILE_NAME;
        }
    }
}
