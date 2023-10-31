using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;

namespace dao
{
    class frmMSAD003 : dao.daoBase
    {

        #region "変数"

        //ユーザーID
        string _userId = string.Empty;

        //log4netLogger変数
        private ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        //コンストラクタ
        public frmMSAD003(string name, string userid)
        {
            dbConnection(name);
            _userId = userid;

        }

        #region "SELECT"

        //処理履歴より入力ファイル名取得
        public DataTable select_INPUT_FILE_NAME_From_T_PROCESS_HISTORY(string file_name)
        {

            _logger.Info("ユニークキー [" + file_name + "]");

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            _logger.Info("入力ファイル名 取得開始");

            sb.AppendLine("SELECT SEQ_NO ");
            sb.AppendLine(",PROCESS_TEXT ");
            sb.AppendLine(",INPUT_FILE_NAME ");
            sb.AppendLine("FROM T_PROCESS_HISTORY ");
            sb.AppendLine("WHERE INPUT_FILE_NAME = ");
            sb.AppendLine("'" + file_name + "'");

            sql = sb.ToString();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            _logger.Info("入力ファイル名 取得終了");

            return tbl;
        }

        //出荷依頼テーブルより最大SEQ_NOの取得
        public int select_MAX_SEQ_NO_From_T_SHIPPING_REQUEST()
        {

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();
            int max_SEQ_NO = 0;

            _logger.Info("最大SEQ_NO 取得開始");

            sb.AppendLine("SELECT MAX(SEQ_NO) ");
            sb.AppendLine("FROM T_SHIPPING_REQUEST ");

            sql = sb.ToString();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            if (tbl.Rows.Count > 0)
            {
                if (tbl.Rows[0].ItemArray[0] != DBNull.Value)
                {
                    max_SEQ_NO = Int32.Parse(tbl.Rows[0].ItemArray[0].ToString());
                }
                else
                {
                    max_SEQ_NO = 0;
                }
            }
            else
            {
                max_SEQ_NO = 0;
            }

            _logger.Info("最大SEQ_NO [" + max_SEQ_NO + "]");
            _logger.Info("最大SEQ_NO 取得終了");

            return max_SEQ_NO;

        }

        //処理履歴テーブルより最大SEQ_NOの取得
        public int select_MAX_SEQ_NO_From_T_PROCESS_HISTORY()
        {

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();
            int max_SEQ_NO = 0;

            _logger.Info("最大SEQ_NO 取得開始");

            sb.AppendLine("SELECT MAX(SEQ_NO) ");
            sb.AppendLine("FROM T_PROCESS_HISTORY ");

            sql = sb.ToString();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            if (tbl.Rows.Count > 0)
            {
                if (tbl.Rows[0].ItemArray[0] != DBNull.Value)
                {
                    max_SEQ_NO = Int32.Parse(tbl.Rows[0].ItemArray[0].ToString());
                }
                else
                {
                    max_SEQ_NO = 0;
                }
            }
            else
            {
                max_SEQ_NO = 0;
            }

            _logger.Info("最大SEQ_NO [" + max_SEQ_NO + "]");
            _logger.Info("最大SEQ_NO 取得終了");

            return max_SEQ_NO;

        }
        //管理番号と契約番号で出荷依頼テーブルを検索
        public DataTable select_SHIPPING_REQUEST_INFO_From_T_SHIPPING_REQUEST(string control_no, string contract_no)
        {

            _logger.Info("管理番号 [" + control_no + "]");
            _logger.Info("契約番号 [" + contract_no + "]");

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            _logger.Info("出荷依頼情報 取得開始");

            sb.AppendLine("SELECT STATUS ");
            sb.AppendLine(" ,SHIP_STOP_DATE ");
            sb.AppendLine(" ,SHIP_STOP_PERSON_NAME ");
            sb.AppendLine("FROM T_SHIPPING_REQUEST ");
            sb.AppendLine("WHERE ");
            sb.AppendLine("  CONTROL_NO = '" + control_no + "'");
            sb.AppendLine(" AND ");
            sb.AppendLine("  CONTRACT_NO = '" + contract_no + "'");

            sql = sb.ToString();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            _logger.Info("出荷依頼情報 取得終了");

            return tbl;
        }
        #endregion

        #region "INSERT"

        #region "出荷依頼テーブル追加"
        public void insert_T_SHIPPING_REQUEST( string staff_name, int next_no, string list)
        {
            try
            {
                _logger.Info("出荷依頼テーブル追加 開始");

                _logger.Info("担当者名 [" + staff_name + "]");
                _logger.Info("SEQ_NO [" + next_no + "]");
                _logger.Info("集荷依頼ファイル　登録1行イメージ [" + list + "]");

                StringBuilder sb = new StringBuilder();
                string sql = null;
                string[] fields = list.ToString().Split(',');
                sb.AppendLine(" INSERT INTO T_SHIPPING_REQUEST ( ");
                sb.AppendLine("   SEQ_NO ");
                if (!string.IsNullOrEmpty(fields[0])) sb.AppendLine("   ,CONTROL_NO ");
                if (!string.IsNullOrEmpty(fields[1])) sb.AppendLine("   ,PRODUCT_CODE ");
                if (!string.IsNullOrEmpty(fields[2])) sb.AppendLine("   ,PRODUCT_NAME ");
                if (!string.IsNullOrEmpty(fields[3])) sb.AppendLine("   ,CUSTOMER_ID ");
                if (!string.IsNullOrEmpty(fields[4])) sb.AppendLine("   ,CONTRACT_NO ");
                if (!string.IsNullOrEmpty(fields[5])) sb.AppendLine("   ,BRANCH_NO ");
                if (!string.IsNullOrEmpty(fields[6])) sb.AppendLine("   ,MATURITY_DATE ");
                if (!string.IsNullOrEmpty(fields[7])) sb.AppendLine("   ,INSURANCE_CODE ");
                if (!string.IsNullOrEmpty(fields[8])) sb.AppendLine("   ,EFFECTIVE_DATE ");
                if (!string.IsNullOrEmpty(fields[9])) sb.AppendLine("   ,CHANGE_DATE ");
                if (!string.IsNullOrEmpty(fields[10])) sb.AppendLine("   ,SHIPPING_CATEGORY ");
                if (!string.IsNullOrEmpty(fields[11])) sb.AppendLine("   ,RESEND_FLAG ");
                if (!string.IsNullOrEmpty(fields[12])) sb.AppendLine("   ,CONTRACTOR_NAME ");
                if (!string.IsNullOrEmpty(fields[13])) sb.AppendLine("   ,CONTRACTOR_POSTAL_CODE ");
                if (!string.IsNullOrEmpty(fields[14])) sb.AppendLine("   ,CONTRACTOR_ADDRESS ");
                if (!string.IsNullOrEmpty(fields[15])) sb.AppendLine("   ,CONTRACTOR_TEL_NO ");
                if (!string.IsNullOrEmpty(fields[16])) sb.AppendLine("   ,NAME_INSURED_NAME ");
                if (!string.IsNullOrEmpty(fields[17])) sb.AppendLine("   ,NAME_INSURED_POSTAL_CODE ");
                if (!string.IsNullOrEmpty(fields[18])) sb.AppendLine("   ,NAME_INSURED_ADDRESS ");
                if (!string.IsNullOrEmpty(fields[19])) sb.AppendLine("   ,ONBOARD_EQUIPMENT_NO ");
                if (!string.IsNullOrEmpty(fields[20])) sb.AppendLine("   ,NAME_INSURED_TEL_NO ");
                if (!string.IsNullOrEmpty(fields[21])) sb.AppendLine("   ,SEND_DEST_CATEGORY ");
                if (!string.IsNullOrEmpty(fields[22])) sb.AppendLine("   ,DISTRIBUTOR_CODE ");
                if (!string.IsNullOrEmpty(fields[23])) sb.AppendLine("   ,BRANCH_CODE ");
                if (!string.IsNullOrEmpty(fields[24])) sb.AppendLine("   ,DIST_SEND_POSTAL_CODE ");
                if (!string.IsNullOrEmpty(fields[25])) sb.AppendLine("   ,DIST_SEND_ADDRESS ");
                if (!string.IsNullOrEmpty(fields[26])) sb.AppendLine("   ,DIST_SEND_ADDRESSEE ");
                if (!string.IsNullOrEmpty(fields[26])) sb.AppendLine("   ,SEND_DEST_NAME ");
                if (!string.IsNullOrEmpty(fields[27])) sb.AppendLine("   ,DIST_SEND_TEL_NO ");
                if (!string.IsNullOrEmpty(fields[28])) sb.AppendLine("   ,VEHICLE_REGIST_NO ");
                sb.AppendLine("   ,UPDATE_DATE ");
                sb.AppendLine("   ,UPDATE_USER ");
                sb.AppendLine("  ) VALUES (");
                sb.AppendLine("  '" + next_no + "'");
                if (!string.IsNullOrEmpty(fields[0])) sb.AppendLine("  ,'" + fields[0] + "'");
                if (!string.IsNullOrEmpty(fields[1])) sb.AppendLine("  ,'" + fields[1] + "'");
                if (!string.IsNullOrEmpty(fields[2])) sb.AppendLine("  ,'" + fields[2] + "'");
                if (!string.IsNullOrEmpty(fields[3])) sb.AppendLine("  ,'" + fields[3] + "'");
                if (!string.IsNullOrEmpty(fields[4])) sb.AppendLine("  ,'" + fields[4] + "'");
                if (!string.IsNullOrEmpty(fields[5])) sb.AppendLine("  ,'" + fields[5] + "'");
                if (!string.IsNullOrEmpty(fields[6])) sb.AppendLine("  ,'" + fields[6] + "'");
                if (!string.IsNullOrEmpty(fields[7])) sb.AppendLine("  ,'" + fields[7] + "'");
                if (!string.IsNullOrEmpty(fields[8])) sb.AppendLine("  ,'" + fields[8] + "'");
                if (!string.IsNullOrEmpty(fields[9])) sb.AppendLine("  ,'" + fields[9] + "'");
                if (!string.IsNullOrEmpty(fields[10])) sb.AppendLine("  ,'" + fields[10] + "'");
                if (!string.IsNullOrEmpty(fields[11])) sb.AppendLine("  ,'" + fields[11] + "'");
                if (!string.IsNullOrEmpty(fields[12])) sb.AppendLine("  ,'" + fields[12] + "'");
                if (!string.IsNullOrEmpty(fields[13])) sb.AppendLine("  ,'" + fields[13] + "'");
                if (!string.IsNullOrEmpty(fields[14])) sb.AppendLine("  ,'" + fields[14] + "'");
                if (!string.IsNullOrEmpty(fields[15])) sb.AppendLine("  ,'" + fields[15] + "'");
                if (!string.IsNullOrEmpty(fields[16])) sb.AppendLine("  ,'" + fields[16] + "'");
                if (!string.IsNullOrEmpty(fields[17])) sb.AppendLine("  ,'" + fields[17] + "'");
                if (!string.IsNullOrEmpty(fields[18])) sb.AppendLine("  ,'" + fields[18] + "'");
                if (!string.IsNullOrEmpty(fields[19])) sb.AppendLine("  ,'" + fields[19] + "'");
                if (!string.IsNullOrEmpty(fields[20])) sb.AppendLine("  ,'" + fields[20] + "'");
                if (!string.IsNullOrEmpty(fields[21])) sb.AppendLine("  ,'" + fields[21] + "'");
                if (!string.IsNullOrEmpty(fields[22])) sb.AppendLine("  ,'" + fields[22] + "'");
                if (!string.IsNullOrEmpty(fields[23])) sb.AppendLine("  ,'" + fields[23] + "'");
                if (!string.IsNullOrEmpty(fields[24])) sb.AppendLine("  ,'" + fields[24] + "'");
                if (!string.IsNullOrEmpty(fields[25])) sb.AppendLine("  ,'" + fields[25] + "'");
                if (!string.IsNullOrEmpty(fields[26])) sb.AppendLine("  ,'" + fields[26] + "'");
                if (!string.IsNullOrEmpty(fields[27])) sb.AppendLine("  ,'" + fields[27] + "'");
                if (!string.IsNullOrEmpty(fields[28])) sb.AppendLine("  ,'" + fields[28] + "'");

                //発送先名の設定
                //■「発送先区分」＝0の時、全角60文字　「契約者名」をセット、
                //   ただし、「記名被保険者名」がある時は、「記名被保険者名」をセット
                //■「発送先区分」＝1　or 2 の時、「代理店個別発送宛名」をセット
                //■"＊"（全角）をブランク"　"（全角）に変換
                if (!string.IsNullOrEmpty(fields[21]) && fields[21] == "0")
                {
                    if(!string.IsNullOrEmpty(fields[16]))
                    {
                        sb.AppendLine("  ,'" + fields[16].Replace("＊","　") + "'");
                    }
                    else
                    {
                        sb.AppendLine("  ,'" + fields[12].Replace("＊", "　") + "'");
                    }
                }
                else if (!string.IsNullOrEmpty(fields[21]) && (fields[21] == "1" || fields[21] == "2"))
                {
                    sb.AppendLine("  ,'" + fields[26].Replace("＊", "　") + "'");
                }

                sb.AppendLine("  ,SYSDATE ");
                sb.AppendLine("  ,'" + staff_name + "'");
                sb.AppendLine(")");

                _logger.Info("sql[" + Environment.NewLine + sb.ToString() + "]");
                sql = sb.ToString();
                Update(sql);

            }
            finally
            {
                _logger.Info("出荷依頼テーブル追加 終了");
            }
        }
        #endregion

        #region "出処理履歴テーブル追加"
        /// <summary>
        /// 出処理履歴テーブル追加
        /// 入力系とエラー系で2レコード追加する
        /// </summary>
        /// <param name="next_no">SEQ_NO</param>
        /// <param name="PROCESS_TEXT">処理内容</param>
        /// <param name="INPUT_FILE_NAME">入力ファイル名コード</param>
        /// <param name="INPUT_COUNT">入力件数</param>
        /// <param name="REGISTER_COUNT">登録件数</param>
        /// <param name="OUTPUT_FILE_NAME">出力ファイル名</param>
        /// <param name="OUTPUT_COUNT">出力件数</param>
        /// <param name="UPDATE_USER">処理担当者名</param>
        /// <return>none</return>
        public void insert_T_PROCESS_HISTORY(int next_no, string PROCESS_TEXT, string INPUT_FILE_NAME, int INPUT_COUNT, int REGISTER_COUNT, string OUTPUT_FILE_NAME, int OUTPUT_COUNT, string UPDATE_USER)
        {
            try
            {
                _logger.Info("処理履歴テーブル追加 開始");
                _logger.Info("SEQ_NO [" + next_no + "]");
                _logger.Info("処理内容 [" + PROCESS_TEXT + "]");
                _logger.Info("入力ファイル名 [" + INPUT_FILE_NAME + "]");
                _logger.Info("入力件数 [" + INPUT_COUNT + "]");
                _logger.Info("登録件数 [" + REGISTER_COUNT + "]");
                _logger.Info("出力ファイル名 [" + OUTPUT_FILE_NAME + "]");
                _logger.Info("出力件数 [" + OUTPUT_COUNT + "]");
                _logger.Info("担当者名 [" + UPDATE_USER + "]");

                StringBuilder sb = new StringBuilder();
                string sql = null;

                //入力ファイル関連登録
                sb.AppendLine(" INSERT INTO T_PROCESS_HISTORY ( ");
                sb.AppendLine("    SEQ_NO ");
                sb.AppendLine("   ,PROCESS_TEXT ");
                sb.AppendLine("   ,INPUT_FILE_NAME ");
                sb.AppendLine("   ,INPUT_COUNT ");
                sb.AppendLine("   ,OUTPUT_COUNT ");
                sb.AppendLine("   ,UPDATE_DATE ");
                sb.AppendLine("   ,UPDATE_USER ");
                sb.AppendLine("  ) VALUES (");
                sb.AppendLine("   '" + next_no + "'");
                sb.AppendLine("  ,'" + PROCESS_TEXT + "'");
                sb.AppendLine("  ,'" + INPUT_FILE_NAME + "'");
                sb.AppendLine("  ,'" + INPUT_COUNT + "'");
                sb.AppendLine("  ,'" + REGISTER_COUNT + "'");
                sb.AppendLine("  ,SYSDATE ");
                sb.AppendLine("  ,'" + UPDATE_USER + "')"); 

                _logger.Info("sql[" + Environment.NewLine + sb.ToString() + "]");
                sql = sb.ToString();
                Update(sql);

                //エラーファイル関連登録
                int next_next_no = next_no + 1;
                sb.Clear();
                sql = null;
                sb.AppendLine(" INSERT INTO T_PROCESS_HISTORY ( ");
                sb.AppendLine("    SEQ_NO ");
                sb.AppendLine("   ,PROCESS_TEXT ");
                sb.AppendLine("   ,OUTPUT_FILE_NAME ");
                sb.AppendLine("   ,OUTPUT_COUNT ");
                sb.AppendLine("   ,UPDATE_DATE ");
                sb.AppendLine("   ,UPDATE_USER ");
                sb.AppendLine("  ) VALUES (");
                sb.AppendLine("   '" + next_next_no + "'");
                sb.AppendLine("  ,'" + PROCESS_TEXT + "'");
                sb.AppendLine("  ,'" + OUTPUT_FILE_NAME + "'");
                sb.AppendLine("  ,'" + OUTPUT_COUNT + "'");
                sb.AppendLine("  ,SYSDATE ");
                sb.AppendLine("  ,'" + UPDATE_USER + "')");

                _logger.Info("sql[" + Environment.NewLine + sb.ToString() + "]");
                sql = sb.ToString();
                Update(sql);

            }
            finally
            {
                _logger.Info("処理履歴テーブル追加 終了");
            }
        }
        #endregion

        #endregion

        #region "UPDATE"

        #region "出処依頼テーブル更新"
        /// <summary>
        /// 出処依頼テーブル更新
        /// </summary>
        /// <param name="CONTROL_NO">管理番号</param>
        /// <param name="CONTRACT_NO">契約番号</param>
        /// <param name="staff_name">担当者名</param>
        /// <param name="STATUS">ステータス</param>
        /// <return>none</return>
        public void update_T_SHIPPING_REQUEST(string CONTROL_NO, string CONTRACT_NO, string staff_name, string STATUS)
        {
            try
            {
                _logger.Info("出処依頼テーブル更新 開始");
                _logger.Info("管理番号 [" + CONTROL_NO + "]");
                _logger.Info("契約番号 [" + CONTRACT_NO + "]");
                _logger.Info("担当者名 [" + staff_name + "]");
                _logger.Info("ステータス [" + STATUS + "]");

                StringBuilder sb = new StringBuilder();
                string sql = null;

                //入力ファイル関連登録
                sb.AppendLine(" UPDATE T_SHIPPING_REQUEST SET ");
                sb.AppendLine("    STATUS = '" + STATUS + "' ");
                sb.AppendLine("   ,SHIP_STOP_DATE = TO_CHAR(SYSDATE,'YYYYMMDD') ");
                sb.AppendLine("   ,SHIP_STOP_PERSON_NAME = '" + staff_name + "' ");
                sb.AppendLine("   ,UPDATE_DATE = SYSDATE ");
                sb.AppendLine("   ,UPDATE_USER = '" + staff_name + "' ");
                sb.AppendLine(" WHERE");
                sb.AppendLine("    CONTROL_NO = '" + CONTROL_NO + "'");
                sb.AppendLine("  AND ");
                sb.AppendLine("    CONTRACT_NO = '" + CONTRACT_NO + "'");


                _logger.Info("sql[" + Environment.NewLine + sb.ToString() + "]");
                sql = sb.ToString();
                Update(sql);

            }
            finally
            {
                _logger.Info("出処依頼テーブル更新 終了");
            }
        }
        #endregion

        #endregion
    }
}
