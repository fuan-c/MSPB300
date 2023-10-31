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
    class frmMSAD005 : dao.daoBase
    {

        #region "変数"

        //ユーザーID
        string _userId = string.Empty;

        //log4netLogger変数
        private ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        //コンストラクタ
        public frmMSAD005(string name, string userid)
        {
            dbConnection(name);
            _userId = userid;

        }

        #region "SELECT"

        //出荷依頼テーブルよりデータ取得
        // Shipping_Category
        // 0：出荷依頼
        // 1：回収依頼
        // 3：交換（代替品発送）
        // 4：交換（故障品回収）
        public DataTable select_SEND_DATA_From_T_SHIPPING_REQUEST(string Shipping_Category)
        {
            _logger.Info("管理番号 [" + Shipping_Category + "]");

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            _logger.Info("発送データ 取得開始");

            sb.AppendLine("SELECT ");
            sb.AppendLine(" CONTROL_NO ");
            sb.AppendLine(",CONTRACT_NO ");
            sb.AppendLine(",BRANCH_NO ");
            sb.AppendLine(",CUSTOMER_ID ");
            sb.AppendLine(",MATURITY_DATE ");
            sb.AppendLine(",INSURANCE_CODE ");
            sb.AppendLine(",SHIPPING_CATEGORY ");
            sb.AppendLine(",SEND_DEST_NAME ");
            sb.AppendLine(",CONTRACTOR_NAME ");
            sb.AppendLine(",SEND_DEST_POSTAL_CODE ");
            sb.AppendLine(",SEND_DEST_ADDRESS ");
            sb.AppendLine(",SEND_DEST_TEL_NO ");
            sb.AppendLine(",PRODUCT_CODE ");
            sb.AppendLine(",PRODUCT_NAME ");
            sb.AppendLine(",SEND_DEST_CATEGORY ");
            sb.AppendLine(",VEHICLE_REGIST_NO ");
            sb.AppendLine("FROM T_SHIPPING_REQUEST ");
            sb.AppendLine("WHERE ");
            sb.AppendLine("  STATUS = '0'");
            sb.AppendLine(" AND ");
            if (Shipping_Category != "3")
            {
                sb.AppendLine("  SEND_PROCESS_DATE IS NULL ");
            }
            else
            {
                sb.AppendLine("  REPLACE_SEND_PROCESS_DATE IS NULL ");
            }
            sb.AppendLine(" AND ");
            sb.AppendLine("  SHIPPING_CATEGORY = '" + Shipping_Category + "'");

            sql = sb.ToString();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            _logger.Info("発送データ 取得終了");

            return tbl;
        }

        //出荷依頼テーブルより発送先郵便番号取得
        public DataTable select_SEND_DEST_POSTAL_CODE_From_T_SHIPPING_REQUEST()
        {

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            _logger.Info("発送先郵便番号 取得開始");

            sb.AppendLine("SELECT ");
            sb.AppendLine(" S.SEND_DEST_POSTAL_CODE ");
            sb.AppendLine(" ,S.RESEPTION_DATE ");
            sb.AppendLine(" ,S.SHIPPING_CATEGORY ");
            sb.AppendLine(" ,S.STATUS ");
            sb.AppendLine(" ,S.SEND_DEST_ADDRESS ");
            sb.AppendLine(" ,S.CONTROL_NO ");
            sb.AppendLine("FROM T_SHIPPING_REQUEST S ");
            sb.AppendLine("LEFT JOIN M_SORTING_CODE M ");
            sb.AppendLine("     ON S.SEND_DEST_POSTAL_CODE = M.POSTAL_CODE");
            sb.AppendLine("WHERE ");
            sb.AppendLine(" M.POSTAL_CODE IS NULL ");
            sb.AppendLine(" AND ");
            sb.AppendLine(" STATUS = '0' ");

            sb.AppendLine("ORDER BY S.RESEPTION_DATE,  S.SHIPPING_CATEGORY, S.STATUS,S.SEND_DEST_ADDRESS, S.SEND_DEST_POSTAL_CODE");

            sql = sb.ToString();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            _logger.Info("発送先郵便番号 取得終了");

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
         
        #region "出処理履歴テーブル追加"
        /// <summary>
        /// 出処理履歴テーブル追加
        /// 入力系とエラー系で2レコード追加する
        /// </summary>
        /// <param name="next_no">SEQ_NO</param>
        /// <param name="PROCESS_TEXT">処理内容</param>
        /// <param name="OUTPUT_COUNT">出力件数</param>
        /// <param name="UPDATE_USER">処理担当者名</param>
        /// <return>none</return>
        public void insert_T_PROCESS_HISTORY(int next_no, string PROCESS_TEXT, int OUTPUT_COUNT, string UPDATE_USER)
        {
            try
            {
                _logger.Info("処理履歴テーブル追加 開始");
                _logger.Info("SEQ_NO [" + next_no + "]");
                _logger.Info("処理内容 [" + PROCESS_TEXT + "]");
                _logger.Info("出力件数 [" + OUTPUT_COUNT + "]");
                _logger.Info("担当者名 [" + UPDATE_USER + "]");

                StringBuilder sb = new StringBuilder();
                string sql = null;

                //入力ファイル関連登録
                sb.AppendLine(" INSERT INTO T_PROCESS_HISTORY ( ");
                sb.AppendLine("    SEQ_NO ");
                sb.AppendLine("   ,PROCESS_TEXT ");
                sb.AppendLine("   ,OUTPUT_COUNT ");
                sb.AppendLine("   ,UPDATE_DATE ");
                sb.AppendLine("   ,UPDATE_USER ");
                sb.AppendLine("  ) VALUES (");
                sb.AppendLine("   '" + next_no + "'");
                sb.AppendLine("  ,'" + PROCESS_TEXT + "'");
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

        #region "CMT発送データテーブル追加"
        public void insert_T_CMT_SEND_DATA(string staff_name, DataRow Rows)
        {
            try
            {
                _logger.Info("CMT発送データテーブル追加 開始");

                _logger.Info("担当者名 [" + staff_name + "]");


                StringBuilder sb = new StringBuilder();
                string sql = null;

                sb.AppendLine(" INSERT INTO T_CMT_SEND_DATA ( ");
                if (!string.IsNullOrEmpty(Rows["CONTROL_NO"].ToString())) sb.AppendLine("   CONTROL_NO ");
                if (!string.IsNullOrEmpty(Rows["CONTRACT_NO"].ToString())) sb.AppendLine("   ,CONTRACT_NO ");
                if (!string.IsNullOrEmpty(Rows["BRANCH_NO"].ToString())) sb.AppendLine("   ,BRANCH_NO ");
                if (!string.IsNullOrEmpty(Rows["MATURITY_DATE"].ToString())) sb.AppendLine("   ,MATURITY_DATE ");
                if (!string.IsNullOrEmpty(Rows["INSURANCE_CODE"].ToString())) sb.AppendLine("   ,INSURANCE_CODE ");
                if (!string.IsNullOrEmpty(Rows["SHIPPING_CATEGORY"].ToString())) sb.AppendLine("   ,SHIPPING_CATEGORY ");
                if (!string.IsNullOrEmpty(Rows["CONTRACTOR_NAME"].ToString())) sb.AppendLine("   ,CONTRACTOR_NAME ");
                if (!string.IsNullOrEmpty(Rows["SEND_DEST_NAME"].ToString())) sb.AppendLine("   ,SEND_DEST_NAME ");
                if (!string.IsNullOrEmpty(Rows["SEND_DEST_POSTAL_CODE"].ToString())) sb.AppendLine("   ,SEND_DEST_POSTAL_CODE ");
                if (!string.IsNullOrEmpty(Rows["SEND_DEST_ADDRESS"].ToString())) sb.AppendLine("   ,SEND_DEST_ADDRESS ");
                if (!string.IsNullOrEmpty(Rows["SEND_DEST_TEL_NO"].ToString())) sb.AppendLine("   ,SEND_DEST_TEL_NO ");
                if (!string.IsNullOrEmpty(Rows["PRODUCT_CODE"].ToString())) sb.AppendLine("   ,PRODUCT_CODE ");
                if (!string.IsNullOrEmpty(Rows["PRODUCT_NAME"].ToString())) sb.AppendLine("   ,PRODUCT_NAME ");
                if (!string.IsNullOrEmpty(Rows["SEND_DEST_CATEGORY"].ToString())) sb.AppendLine("   ,SEND_DEST_CATEGORY ");
                if (!string.IsNullOrEmpty(Rows["VEHICLE_REGIST_NO"].ToString())) sb.AppendLine("   ,VEHICLE_REGIST_NO ");
                sb.AppendLine("   ,PROCESS_DATE ");
                sb.AppendLine("   ,UPDATE_DATE ");
                sb.AppendLine("   ,UPDATE_USER ");
                sb.AppendLine("  ) VALUES (");
                if (!string.IsNullOrEmpty(Rows["CONTROL_NO"].ToString())) sb.AppendLine("  '" + Rows["CONTROL_NO"].ToString() + "'");
                if (!string.IsNullOrEmpty(Rows["CONTRACT_NO"].ToString())) sb.AppendLine("  ,'" + Rows["CONTRACT_NO"].ToString() + "'");
                if (!string.IsNullOrEmpty(Rows["BRANCH_NO"].ToString())) sb.AppendLine("  ,'" + Rows["BRANCH_NO"].ToString() + "'");
                if (!string.IsNullOrEmpty(Rows["MATURITY_DATE"].ToString())) sb.AppendLine("  ,'" + Rows["MATURITY_DATE"].ToString() + "'");
                if (!string.IsNullOrEmpty(Rows["INSURANCE_CODE"].ToString())) sb.AppendLine("  ,'" + Rows["INSURANCE_CODE"].ToString() + "'");
                if (!string.IsNullOrEmpty(Rows["SHIPPING_CATEGORY"].ToString())) sb.AppendLine("  ,'" + Rows["SHIPPING_CATEGORY"].ToString() + "'");
                if (!string.IsNullOrEmpty(Rows["CONTRACTOR_NAME"].ToString())) sb.AppendLine("  ,'" + Rows["CONTRACTOR_NAME"].ToString() + "'");
                if (!string.IsNullOrEmpty(Rows["SEND_DEST_NAME"].ToString())) sb.AppendLine("  ,'" + Rows["SEND_DEST_NAME"].ToString() + "'");
                if (!string.IsNullOrEmpty(Rows["SEND_DEST_POSTAL_CODE"].ToString())) sb.AppendLine("  ,'" + Rows["SEND_DEST_POSTAL_CODE"].ToString() + "'");
                if (!string.IsNullOrEmpty(Rows["SEND_DEST_ADDRESS"].ToString())) sb.AppendLine("  ,'" + Rows["SEND_DEST_ADDRESS"].ToString() + "'");
                if (!string.IsNullOrEmpty(Rows["SEND_DEST_TEL_NO"].ToString())) sb.AppendLine("  ,'" + Rows["SEND_DEST_TEL_NO"].ToString() + "'");
                if (!string.IsNullOrEmpty(Rows["PRODUCT_CODE"].ToString())) sb.AppendLine("  ,'" + Rows["PRODUCT_CODE"].ToString() + "'");
                if (!string.IsNullOrEmpty(Rows["PRODUCT_NAME"].ToString())) sb.AppendLine("  ,'" + Rows["PRODUCT_NAME"].ToString() + "'");
                if (!string.IsNullOrEmpty(Rows["SEND_DEST_CATEGORY"].ToString())) sb.AppendLine("  ,'" + Rows["SEND_DEST_CATEGORY"].ToString() + "'");
                if (!string.IsNullOrEmpty(Rows["VEHICLE_REGIST_NO"].ToString())) sb.AppendLine("  ,'" + Rows["VEHICLE_REGIST_NO"].ToString() + "'");

                sb.AppendLine("  ,TO_CHAR(SYSDATE,'YYYYMMDD') ");
                sb.AppendLine("  ,SYSDATE ");
                sb.AppendLine("  ,'" + staff_name + "'");
                sb.AppendLine(")");

                _logger.Info("sql[" + Environment.NewLine + sb.ToString() + "]");
                sql = sb.ToString();
                Update(sql);

            }
            finally
            {
                _logger.Info("CMT発送データテーブル追加 終了");
            }
        }
        #endregion

        #region "CMT回収データテーブル追加"
        public void insert_T_CMT_COLLECTION_DATA(string staff_name, DataRow Rows)
        {
            try
            {
                _logger.Info("CMT回収データテーブル追加 開始");

                _logger.Info("担当者名 [" + staff_name + "]");


                StringBuilder sb = new StringBuilder();
                string sql = null;

                sb.AppendLine(" INSERT INTO T_CMT_COLLECTION_DATA ( ");
                if (!string.IsNullOrEmpty(Rows["CONTROL_NO"].ToString())) sb.AppendLine("   CONTROL_NO ");
                if (!string.IsNullOrEmpty(Rows["CONTRACT_NO"].ToString())) sb.AppendLine("   ,CONTRACT_NO ");
                if (!string.IsNullOrEmpty(Rows["BRANCH_NO"].ToString())) sb.AppendLine("   ,BRANCH_NO ");
                if (!string.IsNullOrEmpty(Rows["MATURITY_DATE"].ToString())) sb.AppendLine("   ,MATURITY_DATE ");
                if (!string.IsNullOrEmpty(Rows["INSURANCE_CODE"].ToString())) sb.AppendLine("   ,INSURANCE_CODE ");
                if (!string.IsNullOrEmpty(Rows["SHIPPING_CATEGORY"].ToString())) sb.AppendLine("   ,SHIPPING_CATEGORY ");
                if (!string.IsNullOrEmpty(Rows["CONTRACTOR_NAME"].ToString())) sb.AppendLine("   ,CONTRACTOR_NAME ");
                if (!string.IsNullOrEmpty(Rows["SEND_DEST_NAME"].ToString())) sb.AppendLine("   ,SEND_DEST_NAME ");
                if (!string.IsNullOrEmpty(Rows["SEND_DEST_POSTAL_CODE"].ToString())) sb.AppendLine("   ,SEND_DEST_POSTAL_CODE ");
                if (!string.IsNullOrEmpty(Rows["SEND_DEST_ADDRESS"].ToString())) sb.AppendLine("   ,SEND_DEST_ADDRESS ");
                if (!string.IsNullOrEmpty(Rows["SEND_DEST_TEL_NO"].ToString())) sb.AppendLine("   ,SEND_DEST_TEL_NO ");
                if (!string.IsNullOrEmpty(Rows["PRODUCT_CODE"].ToString())) sb.AppendLine("   ,PRODUCT_CODE ");
                if (!string.IsNullOrEmpty(Rows["PRODUCT_NAME"].ToString())) sb.AppendLine("   ,PRODUCT_NAME ");
                if (!string.IsNullOrEmpty(Rows["SEND_DEST_CATEGORY"].ToString())) sb.AppendLine("   ,SEND_DEST_CATEGORY ");
                if (!string.IsNullOrEmpty(Rows["VEHICLE_REGIST_NO"].ToString())) sb.AppendLine("   ,VEHICLE_REGIST_NO ");
                sb.AppendLine("   ,PROCESS_DATE ");
                sb.AppendLine("   ,UPDATE_DATE ");
                sb.AppendLine("   ,UPDATE_USER ");
                sb.AppendLine("  ) VALUES (");
                if (!string.IsNullOrEmpty(Rows["CONTROL_NO"].ToString())) sb.AppendLine("  '" + Rows["CONTROL_NO"].ToString() + "'");
                if (!string.IsNullOrEmpty(Rows["CONTRACT_NO"].ToString())) sb.AppendLine("  ,'" + Rows["CONTRACT_NO"].ToString() + "'");
                if (!string.IsNullOrEmpty(Rows["BRANCH_NO"].ToString())) sb.AppendLine("  ,'" + Rows["BRANCH_NO"].ToString() + "'");
                if (!string.IsNullOrEmpty(Rows["MATURITY_DATE"].ToString())) sb.AppendLine("  ,'" + Rows["MATURITY_DATE"].ToString() + "'");
                if (!string.IsNullOrEmpty(Rows["INSURANCE_CODE"].ToString())) sb.AppendLine("  ,'" + Rows["INSURANCE_CODE"].ToString() + "'");
                if (!string.IsNullOrEmpty(Rows["SHIPPING_CATEGORY"].ToString())) sb.AppendLine("  ,'" + Rows["SHIPPING_CATEGORY"].ToString() + "'");
                if (!string.IsNullOrEmpty(Rows["CONTRACTOR_NAME"].ToString())) sb.AppendLine("  ,'" + Rows["CONTRACTOR_NAME"].ToString() + "'");
                if (!string.IsNullOrEmpty(Rows["SEND_DEST_NAME"].ToString())) sb.AppendLine("  ,'" + Rows["SEND_DEST_NAME"].ToString() + "'");
                if (!string.IsNullOrEmpty(Rows["SEND_DEST_POSTAL_CODE"].ToString())) sb.AppendLine("  ,'" + Rows["SEND_DEST_POSTAL_CODE"].ToString() + "'");
                if (!string.IsNullOrEmpty(Rows["SEND_DEST_ADDRESS"].ToString())) sb.AppendLine("  ,'" + Rows["SEND_DEST_ADDRESS"].ToString() + "'");
                if (!string.IsNullOrEmpty(Rows["SEND_DEST_TEL_NO"].ToString())) sb.AppendLine("  ,'" + Rows["SEND_DEST_TEL_NO"].ToString() + "'");
                if (!string.IsNullOrEmpty(Rows["PRODUCT_CODE"].ToString())) sb.AppendLine("  ,'" + Rows["PRODUCT_CODE"].ToString() + "'");
                if (!string.IsNullOrEmpty(Rows["PRODUCT_NAME"].ToString())) sb.AppendLine("  ,'" + Rows["PRODUCT_NAME"].ToString() + "'");
                if (!string.IsNullOrEmpty(Rows["SEND_DEST_CATEGORY"].ToString())) sb.AppendLine("  ,'" + Rows["SEND_DEST_CATEGORY"].ToString() + "'");
                if (!string.IsNullOrEmpty(Rows["VEHICLE_REGIST_NO"].ToString())) sb.AppendLine("  ,'" + Rows["VEHICLE_REGIST_NO"].ToString() + "'");

                sb.AppendLine("  ,TO_CHAR(SYSDATE,'YYYYMMDD') ");
                sb.AppendLine("  ,SYSDATE ");
                sb.AppendLine("  ,'" + staff_name + "'");
                sb.AppendLine(")");

                _logger.Info("sql[" + Environment.NewLine + sb.ToString() + "]");
                sql = sb.ToString();
                Update(sql);

            }
            finally
            {
                _logger.Info("CMT回収データテーブル追加 終了");
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
        /// <param name="staff_name">担当者名</param>
        /// <param name="STATUS">ステータス</param>
        /// <return>none</return>
        public void update_T_SHIPPING_REQUEST(string CONTROL_NO, string staff_name, string STATUS)
        {
            try
            {
                _logger.Info("出処依頼テーブル更新 開始");
                _logger.Info("管理番号 [" + CONTROL_NO + "]");
                _logger.Info("担当者名 [" + staff_name + "]");
                _logger.Info("ステータス [" + STATUS + "]");

                StringBuilder sb = new StringBuilder();
                string sql = null;

                //入力ファイル関連登録
                sb.AppendLine(" UPDATE T_SHIPPING_REQUEST SET ");
                sb.AppendLine("    STATUS = '" + STATUS + "' ");
                if (STATUS != "5")
                {
                    sb.AppendLine("   ,SEND_PROCESS_DATE = TO_CHAR(SYSDATE,'YYYYMMDD') ");
                    sb.AppendLine("   ,SEND_PERSON_NAME = '" + staff_name + "' ");
                }
                else
                {
                    sb.AppendLine("   ,REPLACE_SEND_PROCESS_DATE = TO_CHAR(SYSDATE,'YYYYMMDD') ");
                    sb.AppendLine("   ,REPLACE_SEND_PERSON_NAME = '" + staff_name + "' ");
                }
                sb.AppendLine("   ,UPDATE_DATE = SYSDATE ");
                sb.AppendLine("   ,UPDATE_USER = '" + staff_name + "' ");
                sb.AppendLine(" WHERE");
                sb.AppendLine("    CONTROL_NO = '" + CONTROL_NO + "'");


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
