using System;
using System.Text;
using System.Data;
using log4net;
using Common.Dao;

namespace MSPB302.dao
{
    class daofrmMSPB302 : daoBase
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
        public daofrmMSPB302(string name)
        {
            dbConnection(name);            
        }

        #region "SELECT"

        #region 梱包ラインテーブルより出荷日に対するMS返却の総件数取得
        // 梱包ラインテーブルより出荷日に対するMS返却の総件数取得
        public DataTable Select_TotalCnt_T_MS_PACKING_LINE(string SHIPPING_DATE, string RETRUN_PLACE_CODE)
        {
            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            _logger.Info("梱包ラインテーブルより出荷日に対するMS返却の総件数取得 開始");

            sb.AppendLine("SELECT ");
            sb.AppendLine("  ID ");
            sb.AppendLine("  ,PACKING_COUNT ");            
            sb.AppendLine(" FROM T_MS_PACKING_LINE ");
            sb.AppendLine(" WHERE ");
            sb.AppendLine(" SHIPPING_DATE = '" + SHIPPING_DATE + "'");
            sb.AppendLine(" AND RETURN_PLACE = '" + RETRUN_PLACE_CODE + "'");

            sql = sb.ToString();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            _logger.Info("梱包ラインテーブルより出荷日に対するMS返却の総件数取得 終了");

            return tbl;
        }
        #endregion

        #region エスカレテーブルよりMS返却梱包処理完了件数取得
        // エスカレテーブルよりMS返却梱包処理完了件数取得
        public DataTable Select_CompleateCnt_T_ESCALATION(string SHIPPING_DATE)
        {
            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            _logger.Info("エスカレテーブルよりMS返却梱包処理完了件数取得 開始");

            sb.AppendLine("SELECT ");
            sb.AppendLine("  TE.ID ");            
            sb.AppendLine(" FROM T_ESCALATION TE");
            sb.AppendLine(" INNER JOIN T_ESCALATION_RESPONSE TER");
            sb.AppendLine(" ON TER.RESPONSE_CODE = TE.ESCALATION_RESPONSE");
            sb.AppendLine(" WHERE ");
            sb.AppendLine(" TE.SHIPPING_DATE = '" + SHIPPING_DATE + "'");
            sb.AppendLine(" AND TE.STATUS = '6'");                              // ステータス「6:返却済」
            sb.AppendLine(" AND TER.RESPONSE_CODE IN ('2', '3')");              // エスカレ回答「2:MS返却」、「3:保管期間経過」

            sql = sb.ToString();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            _logger.Info("エスカレテーブルよりMS返却梱包処理完了件数取得 終了");

            return tbl;
        }
        #endregion

        #region エスカレテーブルよりMS返却梱包対象抽出
        // エスカレテーブルよりMS返却梱包対象抽出
        public DataTable Select_ShippingTarget_T_ESCALATION(string SHIPPING_DATE)
        {
            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            _logger.Info("エスカレテーブルよりMS返却梱包対象抽出 開始");

            sb.AppendLine("SELECT ");
            sb.AppendLine("  TE.ID ");
            sb.AppendLine("  ,TE.CONTROL_NO ");
            sb.AppendLine(" FROM T_ESCALATION TE");
            sb.AppendLine(" INNER JOIN T_ESCALATION_RESPONSE TER");
            sb.AppendLine(" ON TER.RESPONSE_CODE = TE.ESCALATION_RESPONSE");
            sb.AppendLine(" WHERE ");
            sb.AppendLine(" TE.SHIPPING_DATE = '" + SHIPPING_DATE + "'");
            sb.AppendLine(" AND TE.STATUS = '5'");                              // ステータス「5:返却処理」
            sb.AppendLine(" AND TER.RESPONSE_CODE IN ('2', '3')");              // エスカレ回答「2:MS返却」、「3:保管期間経過」

            sql = sb.ToString();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            _logger.Info("エスカレテーブルよりMS返却梱包対象抽出 終了");

            return tbl;
        }
        #endregion

        #endregion

        #region "INSERT"

        #endregion

        #region "UPDATE"

        #region "エスカレテーブル更新"
        /// <summary>
        /// エスカレテーブル更新
        /// </summary>
        /// <param name="CONTROL_NO">管理番号</param>
        /// <return>none</return>
        public void Update_MSRtrnPackingCompleate_T_ESCALATION(string CONTROL_NO)
        {
            try
            {
                _logger.Info("エスカレテーブル更新 開始");

                StringBuilder sb = new StringBuilder();
                string sql = null;

                sb.AppendLine(" UPDATE T_ESCALATION SET ");
                sb.AppendLine("  STATUS = '6' ");   // ステータス「6:返却済」
                sb.AppendLine(" WHERE");
                sb.AppendLine("  CONTROL_NO = '" + CONTROL_NO + "'");

                _logger.Info("sql[" + Environment.NewLine + sb.ToString() + "]");
                sql = sb.ToString();
                Update(sql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _logger.Info("エスカレテーブル更新 終了");
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
