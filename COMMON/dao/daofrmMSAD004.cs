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
    class frmMSAD004 : dao.daoBase
    {

        #region "変数"

        //ユーザーID
        string _userId = string.Empty;

        //log4netLogger変数
        private ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        //コンストラクタ
        public frmMSAD004(string name, string userid)
        {
            dbConnection(name);
            _userId = userid;

        }

        #region "SELECT"

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

        //仕分けコードマスタより郵便番号検索
        public DataTable select_POSTAL_CODE_From_M_SORTING_CODE(string postal_code)
        {

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            _logger.Info("郵便番号 検索開始");
            _logger.Info("郵便番号 [" + postal_code + "]");

            sb.AppendLine("SELECT POSTAL_CODE ");
            sb.AppendLine("FROM M_SORTING_CODE ");
            sb.AppendLine("WHERE ");
            sb.AppendLine(" POSTAL_CODE = '" + postal_code + "' ");

            sql = sb.ToString();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            _logger.Info("郵便番号 検索終了");

            return tbl;
        }

        #endregion

        #region "INSERT"

        #endregion               

        #region "UPDATE"

        #region "出荷依頼テーブル更新"
        //出荷依頼テーブル更新
        public void update_T_SHIPPING_REQUEST(string CONTROL_NO, string SEND_DEST_POSTAL_CODE, string UPDATE_USER)
        {

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            _logger.Info("出荷依頼テーブル更新 開始");
            try
            {
                sb.AppendLine(" UPDATE T_SHIPPING_REQUEST ");
                sb.AppendLine("    SET ");
                sb.AppendLine("        SEND_DEST_POSTAL_CODE = '" + SEND_DEST_POSTAL_CODE + "' ");
                sb.AppendLine("       ,UPDATE_DATE = SYSDATE ");
                sb.AppendLine("       ,UPDATE_USER = '" + UPDATE_USER + "' ");
                sb.AppendLine("  WHERE CONTROL_NO = '" + CONTROL_NO + "' ");

                sql = sb.ToString();
                _logger.Info("sql[" + Environment.NewLine + sql + "]");
                tbl = base.Fill(sql);
            }
            finally
            {
                _logger.Info("出荷依頼テーブル更新 終了");
            }

        }
        #endregion

        #endregion

    }
}
