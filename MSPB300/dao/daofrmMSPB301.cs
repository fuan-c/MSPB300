using System;
using System.Text;
using System.Data;
using log4net;
using Common.Dao;

namespace MSPB301.dao
{
    class daofrmMSPB301 : daoBase
    {

        #region "変数"

        //ユーザーID
        string _userId = string.Empty;

        //log4netLogger変数
        private ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //config設定
        public static string RUN_WORK_KIND = System.Configuration.ConfigurationManager.AppSettings["WORK_KIND"]; // 実行作業種別 AD/MS

        #endregion

        //コンストラクタ
        public daofrmMSPB301(string name)
        {
            dbConnection(name);            
        }

        #region "SELECT"

        #region 発送QMSテーブルより取得
        /// <summary>
        /// 発送QMS_TMPテーブルより取得
        /// </summary>
        /// <param name="SHIPPING_DATE">出荷日</param>
        /// <return>none</return>
        public DataTable Select_ShippingTarget_T_MS_SHIPPING_QMS(string SHIPPING_DATE)
        {

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            _logger.Info("発送QMSテーブル取得 開始");
            
            sb.AppendLine("SELECT ");
            sb.AppendLine("  ID ");
            sb.AppendLine(" ,SHIPPING_DATE ");
            sb.AppendLine(" ,DELIVERY_SLIP_CONTROL_NO ");
            sb.AppendLine(" ,CONTACT_NO ");
            sb.AppendLine(" ,CONTRACT_NO ");
            sb.AppendLine(" ,READ_DELIVERY_SLIP_CONTROL_NO ");
            sb.AppendLine(" ,READ_CONTROL_LABEL ");
            sb.AppendLine(" ,PACKING_USER_NAME ");
            sb.AppendLine(" ,PACKING_DATE ");
            sb.AppendLine(" ,SHIPPING_COMPLEATE_DATE ");
            sb.AppendLine(" ,REGIST_DATE ");
            sb.AppendLine(" ,REGIST_USER_NAME ");
            sb.AppendLine("FROM T_MS_SHIPPING_QMS");            
            sb.AppendLine("WHERE ");
            sb.AppendLine(" SHIPPING_DATE = '" + SHIPPING_DATE + "'");            
            sb.AppendLine("ORDER BY ID ");

            sql = sb.ToString();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            _logger.Info("発送QMSテーブル取得 終了");

            return tbl;
        }
        #endregion

        #region 梱包処理完了件数取得        
        /// <summary>
        /// 梱包処理完了件数取得
        /// </summary>
        /// <return>none</return>
        public int Select_PackingCompleateCnt_T_MS_SHIPPING_QMS(string SHIPPING_DATE)
        {

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            _logger.Info("梱包処理完了件数取得 開始");

            sb.AppendLine("SELECT ");
            sb.AppendLine(" SHIPPING_DATE ");
            sb.AppendLine(" ,READ_DELIVERY_SLIP_CONTROL_NO ");
            sb.AppendLine("FROM T_MS_SHIPPING_QMS");
            sb.AppendLine("WHERE ");
            sb.AppendLine(" SHIPPING_DATE = '" + SHIPPING_DATE + "'");
            sb.AppendLine(" AND READ_DELIVERY_SLIP_CONTROL_NO IS NOT NULL ");            

            sql = sb.ToString();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            _logger.Info("梱包処理完了件数取得 終了");

            return tbl.Rows.Count;
        }
        #endregion

        #region 読込んだ「配送伝票管理番号」と「出荷日」で「発送QMSテーブル｣を検索
        /// <summary>
        /// 読込んだ「配送伝票管理番号」と「出荷日」で「発送QMSテーブル｣を検索
        /// </summary>
        /// <return>none</return>

        public DataTable Select_DeliverySlipControlNo_T_MS_SHIPPING_QMS(string DELIVERY_SLIP_CONTROL_NO, string SHIPPING_DATE)
        {

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            _logger.Info("発送QMSテーブルより読取配送伝票管理番号取得 開始");

            sb.AppendLine("SELECT ");            
            sb.AppendLine(" SHIPPING_DATE ");
            sb.AppendLine(" ,DELIVERY_SLIP_CONTROL_NO ");
            sb.AppendLine(" ,CONTROL_NO ");
            sb.AppendLine(" ,CONTACT_NO ");
            sb.AppendLine(" ,READ_DELIVERY_SLIP_CONTROL_NO ");
            sb.AppendLine(" ,READ_CONTROL_LABEL ");
            sb.AppendLine("FROM T_MS_SHIPPING_QMS");
            sb.AppendLine("WHERE ");
            sb.AppendLine(" DELIVERY_SLIP_CONTROL_NO = '" + DELIVERY_SLIP_CONTROL_NO + "'");
            sb.AppendLine(" AND SHIPPING_DATE = '" + SHIPPING_DATE + "'");

            sql = sb.ToString();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            _logger.Info("発送QMSテーブルより読取配送伝票管理番号取得 終了");

            return tbl;
        }

        #endregion

        #region 読込んだ「配送伝票管理番号」、「管理番号」と「出荷日」で「発送QMSテーブル｣を検索
        /// <summary>
        /// 読込んだ「配送伝票管理番号」、「管理番号」と「出荷日」で「発送QMSテーブル｣を検索
        /// </summary>
        /// <return>none</return>

        public DataTable Select_ControlNo_T_MS_SHIPPING_QMS(string DELIVERY_SLIP_CONTROL_NO, string CONTROL_NO, string SHIPPING_DATE)
        {

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            _logger.Info("発送QMSテーブルより読取管理番号取得 開始");

            sb.AppendLine("SELECT ");
            sb.AppendLine(" SHIPPING_DATE ");
            sb.AppendLine(" ,DELIVERY_SLIP_CONTROL_NO ");
            sb.AppendLine(" ,CONTROL_NO ");
            sb.AppendLine(" ,CONTACT_NO ");
            sb.AppendLine(" ,READ_DELIVERY_SLIP_CONTROL_NO ");
            sb.AppendLine(" ,READ_CONTROL_LABEL ");
            sb.AppendLine("FROM T_MS_SHIPPING_QMS");
            sb.AppendLine("WHERE ");
            sb.AppendLine(" DELIVERY_SLIP_CONTROL_NO = '" + DELIVERY_SLIP_CONTROL_NO + "'");
            sb.AppendLine(" AND CONTROL_NO = '" + CONTROL_NO + "'");
            sb.AppendLine(" AND SHIPPING_DATE = '" + SHIPPING_DATE + "'");

            sql = sb.ToString();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            _logger.Info("発送QMSテーブルより読取管理番号取得 終了");

            return tbl;
        }

        #endregion

        #region 読込んだ「配送伝票管理番号」、「管理番号」、「お問合せ番号」と「出荷日」で「発送QMSテーブル｣を検索
        /// <summary>
        /// 読込んだ「配送伝票管理番号」、「管理番号」、「お問合せ番号」と「出荷日」で「発送QMSテーブル｣を検索
        /// </summary>
        /// <return>none</return>

        public DataTable Select_ContactNo_T_MS_SHIPPING_QMS(string DELIVERY_SLIP_CONTROL_NO, string CONTROL_NO, string CONTACK_NO, string SHIPPING_DATE)
        {

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            _logger.Info("発送QMSテーブルより読取管理番号取得 開始");

            sb.AppendLine("SELECT ");
            sb.AppendLine(" SHIPPING_DATE ");
            sb.AppendLine(" ,DELIVERY_SLIP_CONTROL_NO ");
            sb.AppendLine(" ,CONTROL_NO ");
            sb.AppendLine(" ,CONTACT_NO ");
            sb.AppendLine(" ,READ_DELIVERY_SLIP_CONTROL_NO ");
            sb.AppendLine(" ,READ_CONTROL_LABEL ");
            sb.AppendLine("FROM T_MS_SHIPPING_QMS");
            sb.AppendLine("WHERE ");
            sb.AppendLine(" DELIVERY_SLIP_CONTROL_NO = '" + DELIVERY_SLIP_CONTROL_NO + "'");
            sb.AppendLine(" AND CONTROL_NO = '" + CONTROL_NO + "'");
            sb.AppendLine(" AND CONTACT_NO = '" + CONTACK_NO + "'");
            sb.AppendLine(" AND SHIPPING_DATE = '" + SHIPPING_DATE + "'");

            sql = sb.ToString();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            _logger.Info("発送QMSテーブルより読取管理番号取得 終了");

            return tbl;
        }

        #endregion

        #endregion

        #region "INSERT"

        #endregion

        #region "UPDATE"

        #region "発送QMSテーブル更新"
        /// <summary>
        /// 発送QMSテーブル更新
        /// </summary>
        /// <param name="READ_DELIVERY_SLIP_CONTROL_NO">配送伝票管理番号</param>
        /// <param name="READ_CONTROL_LABEL">読取管理ラベル</param>
        /// <param name="CONTROL_NO">管理番号</param>
        /// <param name="STAFF_NAME">担当者名</param>
        /// <return>none</return>
        public void Update_PackingTarget_T_MS_SHIPPING_QMS(string READ_DELIVERY_SLIP_CONTROL_NO, string READ_CONTROL_LABEL, string CONTROL_NO, string STAFF_NAME)
        {
            try
            {
                _logger.Info("発送QMSテーブル更新 開始");

                StringBuilder sb = new StringBuilder();
                string sql = null;
                
                sb.AppendLine("UPDATE T_MS_SHIPPING_QMS SET ");                
                sb.AppendLine("  READ_DELIVERY_SLIP_CONTROL_NO = '" + READ_DELIVERY_SLIP_CONTROL_NO + "' ");
                sb.AppendLine(" ,READ_CONTROL_LABEL = '" + READ_CONTROL_LABEL + "' ");
                sb.AppendLine(" ,PACKING_DATE = '" + DateTime.Now.ToString("MMddHHmm") + "' ");
                sb.AppendLine(" ,PACKING_USER_NAME = '" + STAFF_NAME + "' ");
                sb.AppendLine("WHERE");
                sb.AppendLine(" CONTROL_NO = '" + CONTROL_NO + "'");

                _logger.Info("sql[" + Environment.NewLine + sb.ToString() + "]");
                sql = sb.ToString();
                Update(sql);

            }
            finally
            {
                _logger.Info("発送QMSテーブル更新 終了");
            }
        }
        #endregion

        #region "梱包ラインテーブル更新"
        /// <summary>
        /// 梱包ラインテーブル更新
        /// </summary>
        /// <param name="SHIPPING_DATE">出荷日</param>
        /// <param name="RETRUN_PLACE">発送名称</param>
        /// <return>none</return>
        public void Update_PackingCompleate_T_MS_SHIPPING_LINE(string ID)
        {
            try
            {
                _logger.Info("梱包ラインテーブル更新 開始");

                StringBuilder sb = new StringBuilder();
                string sql = null;

                sb.AppendLine("UPDATE T_MS_PACKING_LINE SET ");                
                sb.AppendLine(" PACKING_STATUS = '完了' ");
                sb.AppendLine("WHERE");
                sb.AppendLine("  ID = '" + ID + "'");                

                _logger.Info("sql[" + Environment.NewLine + sb.ToString() + "]");
                sql = sb.ToString();
                Update(sql);

            }
            finally
            {
                _logger.Info("梱包ラインテーブル更新 終了");
            }
        }
        #endregion

        #endregion
    }
}
