using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using log4net;
using System.Diagnostics;
using Common;
using MSPB303.dao;
using System.Configuration;
using MSADBEEP;


namespace MSPB303.form
{public partial class frmMSPB303 : Form
    {
        // <summary>
        // ログ
        // </summary>
        //log4net使用宣言
        private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        daofrmMSPB303 dao = new daofrmMSPB303("DBConnection");

        public frmMSPB303()
        {
            _logger.Info("発送訂正処理 開始");

            InitializeComponent();

            txtStaffName.Text = GlobalVar.STAFF_NAME;
            lblShippingDate.Text = GlobalVar.SHIPPING_DATE;

            //Form画面の背景色&ラベルの文字色を初期設定
            var formInit = new frmBackColorChange();
            formInit.Set_FormInit(this);

            txtDeliverySlipControlNo.ImeMode = (ImeMode)8;

            this.ActiveControl = this.txtDeliverySlipControlNo;
        }

        #region イベント

        #region 戻るボタン押下
        /// <summary>
        /// 戻るボタン押下
        /// </summary>
        /// <remarks></remarks>
        private void Cancel_Click(object sender, EventArgs e)
        {
            _logger.Debug("戻る ボタン押下 ");
            _logger.Info("発送訂正処理 終了");
            this.Close();            
        }
        #endregion

        #region 読取削除ボタン押下
        /// <summary>
        /// 読取削除ボタン押下
        /// </summary>
        /// <remarks></remarks>
        private void Delete_Click(object sender, EventArgs e)
        {
            if (txtDeliverySlipControlNo.Text == "")
            {   
                // Beep音実行
                string alert_string = "「配送伝票管理番号」を読込んでください。";
                int ret = Output_Alert(alert_string);
                txtDeliverySlipControlNo.Text = "";
                this.ActiveControl = this.txtDeliverySlipControlNo;
                return;
            }

            DialogResult result = new clsMessageBox().MessageBoxYesNo("読取内容を削除します、よろしいですか。", "確認", MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                updateReadDataDelete(GlobalVar.SHIPPING_DATE ,GlobalVar.CONTROL_NO);

                // 画面項目初期化
                txtDeliverySlipControlNo.Text = "";
                lblShippingDataID.Text = "";
                lblDeliverySlipControlNo.Text = "";
                lblReadDeliverySlipControlNo.Text = "";
                lblReadControlLabel.Text = "";
                lblContactNo.Text = "";
                lblRegistUser.Text = "";
                lblRegistDate.Text = "";

                this.ActiveControl = this.txtDeliverySlipControlNo;

            }
            else
            {
                // 画面項目初期化
                txtDeliverySlipControlNo.Text = "";
                lblShippingDataID.Text = "";
                lblDeliverySlipControlNo.Text = "";
                lblReadDeliverySlipControlNo.Text = "";
                lblReadControlLabel.Text = "";
                lblContactNo.Text = "";
                lblRegistUser.Text = "";
                lblRegistDate.Text = "";

                this.ActiveControl = this.txtDeliverySlipControlNo;
            }
        }
        #endregion

        #region 配送伝票管理番号入力処理
        /// <summary>
        /// 配送伝票管理番号入力処理
        /// </summary>
        /// <remarks></remarks>
        private void txtDeliverySlipControlNo_KeyDown(object sender, KeyEventArgs e)
        {
            // ENTERキーが押されたかチェック
            if (e.KeyCode == Keys.Enter)
            {
                _logger.Debug("enter キー ボタン押下 終了");

                // ENTERキーのみの場合のチェック
                if (txtDeliverySlipControlNo.Text.Length != 14)
                {
                    _logger.Info("配送伝票管理番号の桁数が異なります。" + txtDeliverySlipControlNo.Text);

                    // Beep音実行
                    string alert_string = "桁数が異なります、読込直してください。";
                    int ret = Output_Alert(alert_string);
                    txtDeliverySlipControlNo.Text = "";
                    this.ActiveControl = this.txtDeliverySlipControlNo;
                    return;
                }

                // 配送伝票管理番号をコモンに設定
                GlobalVar.DELIVERY_SLIP_CONTROL_NO = txtDeliverySlipControlNo.Text;
                                                
                DataTable dt = null;

                try
                {
                    // 読込んだ「配送伝票管理番号」と「出荷日」で「発送QMSテーブル｣を検索する。
                    // 発送QMSテーブルより情報取得
                    dt = dao.Select_DeliverySlipControlNo_T_MS_SHIPPING_QMS(GlobalVar.DELIVERY_SLIP_CONTROL_NO, GlobalVar.SHIPPING_DATE);

                    _logger.Info("発送QMSテーブルより情報取得数 [" + dt.Rows.Count + "]");
                }
                catch (Exception ex)
                {
                    _logger.Info("読込んだ「配送伝票管理番号」と「出荷日」で発送QMSテーブルの対象データ取得処理でエラーが発生しました。" + Environment.NewLine + $"エラー内容：{ex.ToString()}");
                    string alert_string = "発送QMSテーブルの対象データ取得処理でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。";
                    int ret = Output_Alert(alert_string);
                    return;
                }
                
                // マッチング 
                if (dt.Rows.Count > 0)
                {
                    // ｢読取配送伝票管理番号」= Nullの時
                    if (string.IsNullOrEmpty(dt.Rows[0]["READ_DELIVERY_SLIP_CONTROL_NO"].ToString()))
                    {
                        _logger.Info($"配送伝票管理番号「{GlobalVar.DELIVERY_SLIP_CONTROL_NO}」は梱包処理前です。");

                        // Beep音実行
                        string alert_string = "梱包処理前です。";
                        int ret = Output_Alert(alert_string);
                        txtDeliverySlipControlNo.Text = ""; 
                        GlobalVar.DELIVERY_SLIP_CONTROL_NO = string.Empty;
                        // フォーカスを管理ラベルの入力に変更 
                        this.ActiveControl = this.txtDeliverySlipControlNo;

                        return;
                    }

                    lblShippingDataID.Text = dt.Rows[0]["ID"].ToString();
                    lblDeliverySlipControlNo.Text = dt.Rows[0]["DELIVERY_SLIP_CONTROL_NO"].ToString();
                    lblReadDeliverySlipControlNo.Text = dt.Rows[0]["READ_DELIVERY_SLIP_CONTROL_NO"].ToString();
                    lblReadControlLabel.Text = dt.Rows[0]["READ_CONTROL_LABEL"].ToString();
                    lblContactNo.Text = dt.Rows[0]["CONTACT_NO"].ToString();
                    lblRegistUser.Text = dt.Rows[0]["PACKING_USER_NAME"].ToString();
                    lblRegistDate.Text = dt.Rows[0]["PACKING_DATE"].ToString();

                    // 管理番号をコモンに設定
                    GlobalVar.CONTROL_NO = dt.Rows[0]["CONTROL_NO"].ToString();                    

                }
                else
                {
                    _logger.Info($"配送伝票管理番号「{GlobalVar.DELIVERY_SLIP_CONTROL_NO}」は読込削除処理の対象ではありません。");

                    // Beep音実行
                    string alert_string = "処理対象ではありません、確認してください。";
                    int ret = Output_Alert(alert_string);
                    txtDeliverySlipControlNo.Text = "";
                    GlobalVar.DELIVERY_SLIP_CONTROL_NO = string.Empty;                    
                    // フォーカスを管理ラベルの入力に変更                                                      
                    this.ActiveControl = this.txtDeliverySlipControlNo;
                    return;
                }
                
            }
        }        
        #endregion

        #region セルの背景色を変更
        /// <summary>
        /// セルの背景色を変更
        /// </summary>
        /// <remarks></remarks>
        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Row == 0)
            {
                e.Graphics.FillRectangle(Brushes.LightGray, e.CellBounds);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.White, e.CellBounds);
            }
        }
        #endregion

        #endregion

        #region メソッド

        #region 読取削除DB更新処理
        /// <summary>
        /// 読取削除DB更新処理
        /// </summary>
        /// <remarks></remarks>
        private void updateReadDataDelete(string shippingDate, string controlNo)
        {
            _logger.Info("読取削除DB更新処理 開始");
            try
            {
                // トランザクション開始
                dao.BeginTransaction();

                // 発送QMSテーブル更新
                dao.Update_ReadDataDelete_T_MS_SHIPPING_QMS(shippingDate, controlNo);

                // 梱包ステータスが「完了」の場合、梱包ラインテーブルの梱包ステータス更新
                if (GlobalVar.PACKING_STATUS == "完了")
                {
                    dao.Update_ReadDataDelete_T_MS_PACKING_LINE(GlobalVar.ID);
                }

                // コミット
                dao.Commit();
            }
            catch (Exception ex)
            {
                // ロールバック
                dao.Rollback();
                _logger.Info("読取削除DB更新処理でエラーが発生しました。" + Environment.NewLine + $"エラー内容：{ex.ToString()}");
                new clsMessageBox().MessageBoxOKOnly("読取削除DB更新処理でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "警告", MessageBoxIcon.Warning);
                return;

            }
            finally
            {
                _logger.Info("読取削除DB更新処理 終了");
            }
        }
        #endregion

        #region Beep音＆アラート出力
        /// <summary>
        /// Beep音＆アラート出力
        /// </summary>
        /// <remarks></remarks>
        private int Output_Alert(string alert_string)
        {

            int ret = 0;

            new clsBeep().BeepWarning();
            new clsMessageBox().MessageBoxOKOnly(alert_string, "警告", MessageBoxIcon.Warning);

            return ret;
        }
        #endregion

        #endregion

        
    }
}