using System;
using System.Text;
using System.Data;
using log4net;
using Common.Dao;

namespace MSPB300.dao
{
    class daofrmMSPB300 : daoBase
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
        public daofrmMSPB300(string name)
        {
            dbConnection(name);
        }

        #region "SELECT"

        #region 梱包ラインテーブルより取得
        //梱包ラインテーブルより取得
        public DataTable Select_ShippingDate_From_T_MS_PACKING_LINE(string Shipping_Date)
        {

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            _logger.Info("梱包処理 取得開始");

            sb.AppendLine("SELECT ");
            sb.AppendLine(" PL.ID ");
            sb.AppendLine(" ,PL.SHIPPING_DATE ");
            sb.AppendLine(" ,PL.RETURN_PLACE ");
            sb.AppendLine(" ,PL.PACKING_COUNT ");
            sb.AppendLine(" ,PL.PACKING_STATUS ");
            sb.AppendLine(" ,ER.RESPONSE_TEXT ");
            sb.AppendLine("FROM T_MS_PACKING_LINE PL");
            sb.AppendLine("LEFT JOIN T_ESCALATION_RESPONSE ER");
            sb.AppendLine(" ON ER.RESPONSE_CODE = PL.RETURN_PLACE");
            sb.AppendLine("WHERE ");
            sb.AppendLine(" SHIPPING_DATE = '" + Shipping_Date + "'");
            sb.AppendLine(" ORDER BY PL.ID ");

            sql = sb.ToString();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            _logger.Info("梱包処理 取得終了");

            return tbl;
        }
        #endregion

        #region 梱包ラインテーブルより出荷日取得
        //梱包ラインテーブルより出荷日取得
        public DataTable Select_ShippingDate_T_MS_PACKING_LINE()
        {

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            _logger.Info("出荷日 取得開始");

            sb.AppendLine("SELECT ");
            sb.AppendLine(" SHIPPING_DATE, COUNT(SHIPPING_DATE) ");
            sb.AppendLine(" FROM T_MS_PACKING_LINE ");
            sb.AppendLine("WHERE ");
            sb.AppendLine(" PACKING_STATUS != '完了' OR PACKING_STATUS IS NULL");
            sb.AppendLine("GROUP BY SHIPPING_DATE ");
            sb.AppendLine("ORDER BY SHIPPING_DATE ");

            sql = sb.ToString();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            _logger.Info("出荷日 取得終了");

            return tbl;
        }
        #endregion

        #endregion

        #region "INSERT"

        #endregion

        #region "UPDATE"

        #region "梱包ラインテーブル更新"
        //出荷依頼テーブル更新
        public void UpdatePackingLineStatus_T_MS_PACKING_LINE(string ID)
        {

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            _logger.Info("梱包ラインテーブル更新 開始");
            _logger.Info("ID [" + ID + "]");

            try
            {
                sb.AppendLine("UPDATE T_MS_PACKING_LINE ");                
                sb.AppendLine("    SET ");
                sb.AppendLine("        PACKING_STATUS = '作業中'");
                sb.AppendLine("  WHERE ID = '" + ID + "' ");

                sql = sb.ToString();
                _logger.Info("sql[" + Environment.NewLine + sql + "]");
                tbl = base.Fill(sql);
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
