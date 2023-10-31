using System;
using System.Text;
using System.Data;
using log4net;
using Common.Dao;

namespace MSPB303.dao
{
    class daofrmMSPB303 : daoBase
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
        public daofrmMSPB303(string name)
        {
            dbConnection(name);            
        }

        #region "SELECT"

        #region 読込んだ「配送伝票管理番号」と「出荷日」で「発送QMSテーブル｣より検索
        /// <summary>
        /// 読込んだ「配送伝票管理番号」と「出荷日」で「発送QMSテーブル｣より検索
        /// </summary>
        /// <param name="DELIVERY_SLIP_CONTROL_NO">配送伝票管理番号</param>
        /// <param name="SHIPPING_DATE">出荷日</param>
        /// <return>none</return>
        public DataTable Select_DeliverySlipControlNo_T_MS_SHIPPING_QMS(string DELIVERY_SLIP_CONTROL_NO, string SHIPPING_DATE)
        {

            StringBuilder sb = new StringBuilder();
            string sql = String.Empty;
            DataTable tbl = new DataTable();

            _logger.Info("読込んだ「配送伝票管理番号」と「出荷日」で「発送QMSテーブル｣を検索　開始");

            sb.AppendLine("SELECT ");
            sb.AppendLine("  ID ");
            sb.AppendLine(" ,SHIPPING_DATE ");
            sb.AppendLine(" ,CONTROL_NO ");
            sb.AppendLine(" ,DELIVERY_SLIP_CONTROL_NO ");            
            sb.AppendLine(" ,READ_DELIVERY_SLIP_CONTROL_NO ");
            sb.AppendLine(" ,READ_CONTROL_LABEL ");            
            sb.AppendLine(" ,CONTACT_NO ");
            sb.AppendLine(" ,PACKING_USER_NAME ");
            sb.AppendLine(" ,PACKING_DATE ");            
            sb.AppendLine("FROM ");
            sb.AppendLine(" T_MS_SHIPPING_QMS ");            
            sb.AppendLine("WHERE ");
            sb.AppendLine(" DELIVERY_SLIP_CONTROL_NO = '" + DELIVERY_SLIP_CONTROL_NO + "'");
            sb.AppendLine("AND ");
            sb.AppendLine(" SHIPPING_DATE = '" + SHIPPING_DATE + "'");
            
            sql = sb.ToString();
            _logger.Info("sql[" + Environment.NewLine + sql + "]");
            tbl = base.Fill(sql);

            _logger.Info("読込んだ「配送伝票管理番号」と「出荷日」で「発送QMSテーブル｣を検索　終了");

            return tbl;
        }
        #endregion

        #endregion

        #region "INSERT"

        #endregion

        #region "UPDATE"

        #region "発送QMSテーブル更新"
        /// <summary>
        /// 回収QMS_TMPテーブル更新
        /// </summary>
        /// <param name="SHIPPING_DATE">出荷日</param>
        /// <param name="CONTROL_NO">管理番号</param>
        /// <return>none</return>
        public void Update_ReadDataDelete_T_MS_SHIPPING_QMS(string SHIPPING_DATE, string CONTROL_NO )
        {
            try
            {
                _logger.Info("発送QMSテーブル更新 開始");

                StringBuilder sb = new StringBuilder();
                string sql = null;

                sb.AppendLine(" UPDATE T_MS_SHIPPING_QMS SET ");                
                sb.AppendLine("    READ_DELIVERY_SLIP_CONTROL_NO = NULL ");
                sb.AppendLine("   ,READ_CONTROL_LABEL = NULL ");                
                sb.AppendLine("   ,PACKING_USER_NAME = NULL ");
                sb.AppendLine("   ,PACKING_DATE = NULL ");                
                sb.AppendLine(" WHERE");
                sb.AppendLine("    SHIPPING_DATE = '" + SHIPPING_DATE + "'");
                sb.AppendLine("    AND CONTROL_NO = '" + CONTROL_NO + "'");

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
        /// <param name="ID">ID</param>
        /// <return>none</return>
        public void Update_ReadDataDelete_T_MS_PACKING_LINE( string ID)
        {
            try
            {
                _logger.Info("梱包ラインテーブル更新 開始");

                StringBuilder sb = new StringBuilder();
                string sql = null;

                sb.AppendLine("UPDATE T_MS_PACKING_LINE SET ");                
                sb.AppendLine(" PACKING_STATUS = '作業中' ");
                sb.AppendLine(" WHERE ");
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
