using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using log4net;
using Common;
using MSPB301.dao;
using MSADBEEP;

namespace MSPB301.form
{
    public partial class frmMSPB301 : Form
    {
        // <summary>
        // ログ
        // </summary>
        // log4net使用宣言
        private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        daofrmMSPB301 dao = new daofrmMSPB301("DBConnection");

        // <summary>
        // データグリッドビュー用 発送QMSテーブル
        // </summary>
        public sealed class Shipping_QMS
        {
            // ID
            public string ID { get; set; }                      
            // 配送伝票管理番号
            public string DELIVERY_SLIP_CONTROL_NO { get; set; }
            // 読取配送伝票管理番号
            public string READ_DELIVERY_SLIP_CONTROL_NO { get; set; }
            // 読取管理ラベル
            public string READ_CONTROL_LABEL { get; set; }            
            // お問い合わせ番号
            public string CONTACT_NO { get; set; }
            // 判定
            public string READ_JUDGMENT { get; set; }
            // 梱包担当者名
            public string PACKING_USER_NAME { get; set; }
            // 梱包日時
            public string PACKING_DATE { get; set; }         
        }


        public frmMSPB301()
        {
            _logger.Info("契約者返却梱包処理：開始");

            InitializeComponent();

            // Form画面の背景色&ラベルの文字色を初期設定
            var formInit = new frmBackColorChange();
            formInit.Set_FormInit(this);

            txtStaffName.Text = GlobalVar.STAFF_NAME;
            lblShippingDate.Text = GlobalVar.SHIPPING_DATE;

            txtDeliverySlipControlNo.ImeMode = (ImeMode)8;
            txtControlLabel.ImeMode = (ImeMode)8;
            txtContactNo.ImeMode = (ImeMode)8;

            // 梱包対象一覧表示
            displayGridviewPackingTarget();

            this.ActiveControl = this.txtDeliverySlipControlNo;

            this.Shown += new EventHandler(dataGridViewPackingTagetShown);

        }

        #region イベント

        #region 戻る
        /// <summary>
        /// 戻る
        /// </summary>
        /// <remarks></remarks>
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            _logger.Debug("契約者返却梱包処理：戻るボタン押下");
            
            DialogResult result = new clsMessageBox().MessageBoxYesNo("梱包処理画面に戻ります。\r\nよろしいですか？", "警告", MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                _logger.Info("契約者返却梱包処理：終了");
                this.Close();
            }
            else
            {
                // フォーカス設定
                if (string.IsNullOrEmpty(this.txtDeliverySlipControlNo.Text))
                {
                    this.ActiveControl = this.txtDeliverySlipControlNo;
                }
                else if (string.IsNullOrEmpty(this.txtControlLabel.Text))
                {
                    this.ActiveControl = this.txtControlLabel;
                }
                else
                {
                    this.ActiveControl = this.txtContactNo;
                }
            }
        }
        #endregion

        #region セルの背景色を変更
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

        #region フォームのShownイベント・ハンドラ
        // フォームのShownイベント・ハンドラ
        void dataGridViewPackingTagetShown(object sender, EventArgs e)
        {
            // 選択されているセルをなくす
            dataGridView_Packing_Target.CurrentCell = null;

            if (GlobalVar.PACKING_STATUS != "完了")
            {
                setDisplayTotalCount(GlobalVar.MAX_COUNT);
            }
            else
            {
                Btn_ReLoad.Enabled = false;
                Btn_Register.Enabled = false;
                txtDeliverySlipControlNo.Enabled = false;
                txtControlLabel.Enabled = false;
                txtContactNo.Enabled = false;

                setDisplayTotalCount(GlobalVar.MAX_COUNT);
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
                _logger.Info("enter キー ボタン押下 終了");

                // 配送伝票管理番号桁数チェック
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

                // コモンに設定
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
                    // ｢読取配送伝票管理番号」≠ Nullの時、アラート：読込済です。
                    if (!string.IsNullOrEmpty(dt.Rows[0]["READ_DELIVERY_SLIP_CONTROL_NO"].ToString()))
                    {
                        // Beep音実行
                        string alert_string = "読込済です。[" + dt.Rows[0]["READ_DELIVERY_SLIP_CONTROL_NO"].ToString() + "]読込済。";
                        int ret = Output_Alert(alert_string);
                        txtDeliverySlipControlNo.Text = "";
                        GlobalVar.DELIVERY_SLIP_CONTROL_NO = string.Empty;
                        // フォーカスを配送伝票管理番号の入力に変更                                                      
                        this.ActiveControl = this.txtDeliverySlipControlNo;

                        return;
                    }
                }
                else
                {
                    _logger.Info("「配送伝票管理番号」アンマッチ、確認してください。");

                    // Beep音実行
                    string alert_string = "「配送伝票管理番号」アンマッチ、確認してください。";
                    int ret = Output_Alert(alert_string);
                    txtDeliverySlipControlNo.Text = "";
                    GlobalVar.DELIVERY_SLIP_CONTROL_NO = string.Empty;
                    // フォーカスを配送伝票管理番号の入力に変更                                                      
                    this.ActiveControl = this.txtDeliverySlipControlNo;
                    return;
                }

                // 配送伝票管理番号を入力不可にする
                this.txtDeliverySlipControlNo.Enabled = false;

                // フォーカスを管理ラベルの入力に変更  
                this.ActiveControl = this.txtControlLabel;

                // txtDeliverySlipControlNo の背景色をControlにする
                this.txtDeliverySlipControlNo.BackColor = SystemColors.Control;
            }
        }
        #endregion

        #region 管理ラベル入力処理
        /// <summary>
        /// 管理ラベル入力処理
        /// </summary>
        /// <remarks></remarks>
        private void txtControlLabel_KeyDown(object sender, KeyEventArgs e)
        {
            // ENTERキーが押されたかチェック
            if (e.KeyCode == Keys.Enter)
            {
                _logger.Info("enter キー ボタン押下 終了");

                // ENTERキーのみの場合のチェック
                if (txtControlLabel.Text.Length != 21)
                {
                    _logger.Info("管理ラベルの桁数が異なります。" + txtControlLabel.Text);

                    // Beep音実行
                    string alert_string = "桁数が異なります、読込直してください。";
                    int ret = Output_Alert(alert_string);
                    txtControlLabel.Text = "";
                    this.ActiveControl = this.txtControlLabel;
                    return;
                }

                // コモンに設定
                GlobalVar.CONTROL_LABEL = txtControlLabel.Text;
                GlobalVar.CONTROL_NO = txtControlLabel.Text.Substring(0, 20);

                DataTable dt = null;

                try
                {
                    // 読込んだ「配送伝票管理番号」、「管理ラベル(21桁目の「＃」除く)」と「出荷日」で「発送QMSテーブル｣を検索する。
                    // 発送QMSテーブルより情報取得
                    dt = dao.Select_ControlNo_T_MS_SHIPPING_QMS(GlobalVar.DELIVERY_SLIP_CONTROL_NO, GlobalVar.CONTROL_NO, GlobalVar.SHIPPING_DATE);

                    _logger.Info("発送QMSテーブルより情報取得数 [" + dt.Rows.Count + "]");
                }
                catch (Exception ex)
                {
                    _logger.Info("読込んだ「管理ラベル」と「出荷日」で発送QMSテーブルの対象データ取得処理でエラーが発生しました。" + Environment.NewLine + $"エラー内容：{ex.ToString()}");
                    string alert_string = "発送QMSテーブルの対象データ取得処理でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。";
                    int ret = Output_Alert(alert_string);
                    return;
                }

                // マッチング 
                if (dt.Rows.Count > 0)
                {
                    // ｢読取管理ラベル」≠ Nullの時、アラート：読込済です。
                    if (!string.IsNullOrEmpty(dt.Rows[0]["READ_CONTROL_LABEL"].ToString()))
                    {
                        // Beep音実行
                        string alert_string = "読込済です。[" + dt.Rows[0]["READ_CONTROL_LABEL"].ToString() + "]読込済。";
                        int ret = Output_Alert(alert_string);
                        txtControlLabel.Text = "";
                        GlobalVar.CONTROL_LABEL = string.Empty;
                        GlobalVar.CONTROL_NO = string.Empty;
                        // フォーカスを管理ラベルの入力に変更                                                      
                        this.ActiveControl = this.txtControlLabel;

                        return;
                    }
                }
                else
                {
                    _logger.Info("「管理ラベル」アンマッチ、確認してください。");

                    // Beep音実行
                    string alert_string = "「管理ラベル」アンマッチ、確認してください。";
                    int ret = Output_Alert(alert_string);
                    txtControlLabel.Text = "";
                    GlobalVar.CONTROL_LABEL = string.Empty;
                    GlobalVar.CONTROL_NO = string.Empty;
                    // フォーカスを管理ラベルの入力に変更                                                      
                    this.ActiveControl = this.txtControlLabel;
                    return;
                }

                // 管理ラベルを入力不可にする
                this.txtControlLabel.Enabled = false;

                // フォーカスをお問合せ番号の入力に変更  
                this.ActiveControl = this.txtContactNo;

                // txtControlLabel の背景色をControlにする
                this.txtControlLabel.BackColor = SystemColors.Control;
            }
        }
        #endregion

        #region お問合せ番号入力処理
        /// <summary>
        /// お問合せ番号入力処理
        /// </summary>
        /// <remarks></remarks>
        private void txtContactNo_KeyDown(object sender, KeyEventArgs e)
        {
            // ENTERキーが押されたかチェック
            if (e.KeyCode == Keys.Enter)
            {
                _logger.Info("enter キー ボタン押下 終了");

                // ENTERキーのみの場合のチェック
                if (txtContactNo.Text.Length != 14)
                {
                    _logger.Info("管理ラベルの桁数が異なります。" + txtContactNo.Text);

                    // Beep音実行
                    string alert_string = "桁数が異なります、読込直してください。";
                    int ret = Output_Alert(alert_string);
                    txtContactNo.Text = "";
                    this.ActiveControl = this.txtContactNo;
                    return;
                }

                // コモンに設定
                GlobalVar.CONTACT_NO = txtContactNo.Text;

                DataTable dt = null;

                try
                {
                    // 読込んだ「配送伝票管理番号」、「管理番号」、「お問合せ番号」と「出荷日」で「発送QMSテーブル｣を検索する。
                    // 発送QMSテーブルより情報取得
                    dt = dao.Select_ContactNo_T_MS_SHIPPING_QMS(GlobalVar.DELIVERY_SLIP_CONTROL_NO, GlobalVar.CONTROL_NO, GlobalVar.CONTACT_NO, GlobalVar.SHIPPING_DATE);

                    _logger.Info("発送QMSテーブルより情報取得数 [" + dt.Rows.Count + "]");
                }
                catch (Exception ex)
                {
                    _logger.Info("読込んだ「お問合せ番号」と「出荷日」で発送QMSテーブルの対象データ取得処理でエラーが発生しました。" + Environment.NewLine + $"エラー内容：{ex.ToString()}");
                    string alert_string = "発送QMSテーブルの対象データ取得処理でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。";
                    int ret = Output_Alert(alert_string);
                    return;
                }

                // マッチング 
                if (dt.Rows.Count > 0)
                {   
                    try
                    {
                        // トランザクション開始
                        dao.BeginTransaction();

                        // 読込データのMS発送QMS更新
                        dao.Update_PackingTarget_T_MS_SHIPPING_QMS(GlobalVar.DELIVERY_SLIP_CONTROL_NO, GlobalVar.CONTROL_LABEL, GlobalVar.CONTROL_NO, GlobalVar.STAFF_NAME);

                        // コミット
                        dao.Commit();
                    }
                    catch (Exception ex)
                    {
                        _logger.Info("発送QMSテーブルの対象データ更新処理でエラーが発生しました。" + Environment.NewLine + $"エラー内容：{ex.ToString()}");

                        // ロールバック
                        dao.Rollback();

                        // Beep音実行
                        string alert_string = "発送QMSテーブルの対象データ更新処理でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。";
                        int ret = Output_Alert(alert_string);
                        return;
                    }

                    // 管理ラベルを入力不可にする
                    this.txtContactNo.Enabled = false;
                    
                    // txtControlLabel の背景色をControlにする
                    this.txtContactNo.BackColor = SystemColors.Control;

                    // 梱包対象一覧表示 
                    displayGridviewPackingTarget();
                    
                    // 梱包対象一覧内の選択セルを解除
                    dataGridView_Packing_Target.ClearSelection();

                    int rowNo = 0;

                    // 更新した行を選択
                    foreach (DataGridViewRow row in dataGridView_Packing_Target.Rows)
                    {
                        if (row.Cells[2].Value.ToString() == GlobalVar.DELIVERY_SLIP_CONTROL_NO)
                        {
                            if (rowNo < 5)
                            {
                                dataGridView_Packing_Target.FirstDisplayedScrollingRowIndex = 0;
                                dataGridView_Packing_Target.Rows[rowNo].Selected = true;
                            }
                            else
                            {
                                dataGridView_Packing_Target.FirstDisplayedScrollingRowIndex = rowNo - 4;
                                dataGridView_Packing_Target.Rows[rowNo].Selected = true;
                            }
                            break;
                        }
                        rowNo++;
                    }

                    // 完了件数再表示
                    setDisplayTotalCount(GlobalVar.MAX_COUNT);

                }
                else
                {
                    _logger.Info("「お問合せ番号」アンマッチ、確認してください。");

                    // Beep音実行
                    string alert_string = "「お問合せ番号」アンマッチ、確認してください。";
                    int ret = Output_Alert(alert_string);
                    txtContactNo.Text = "";
                    GlobalVar.CONTACT_NO = string.Empty;
                    // フォーカスをお問合せ番号の入力に変更                                                      
                    this.ActiveControl = this.txtContactNo;
                    return;
                }

            }
        }
        #endregion

        #region 再読込ボタン押下
        /// <summary>
        /// 再読込ボタン押下
        /// </summary>
        /// <remarks></remarks>
        private void Btn_ReLoad_Click(object sender, EventArgs e)
        {
            _logger.Debug("再読込ボタン押下処理：開始");

            DialogResult result = new clsMessageBox().MessageBoxYesNo("読込をクリアして「配送伝票管理番号」から読込みます。", "警告", MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                _logger.Debug("再読込ボタン押下処理：終了");

                // 読込んだ内容をクリア
                this.txtDeliverySlipControlNo.Text = "";             // 配送伝票管理番号
                this.txtControlLabel.Text = "";                      // 管理ラベル
                this.txtContactNo.Text = "";                         // お問合せ番号

                // 読込項目活性化
                this.txtDeliverySlipControlNo.Enabled = true;        // 配送伝票管理番号
                this.txtControlLabel.Enabled = true;                 // 管理ラベル
                this.txtContactNo.Enabled = true;                    // お問合せ番号

                // txtControlLabel の背景色をWindowにする
                this.txtDeliverySlipControlNo.BackColor = SystemColors.Window;
                this.txtControlLabel.BackColor = SystemColors.Window;
                this.txtContactNo.BackColor = SystemColors.Window;

                GlobalVar.DELIVERY_SLIP_CONTROL_NO = null;      // 配送伝票管理番号
                GlobalVar.CONTROL_LABEL = null;                 // 管理ラベル
                GlobalVar.CONTACT_NO = null;                    // お問合せ番号
                GlobalVar.CONTROL_NO = null;                    // 管理番号

                this.ActiveControl = this.txtDeliverySlipControlNo;

            }
            else
            {
                // フォーカス設定
                if (string.IsNullOrEmpty(this.txtDeliverySlipControlNo.Text))
                {
                    this.ActiveControl = this.txtDeliverySlipControlNo;
                }
                else if (string.IsNullOrEmpty(this.txtControlLabel.Text))
                {
                    this.ActiveControl = this.txtControlLabel;
                }
                else
                {
                    this.ActiveControl = this.txtContactNo;
                }

            }
        }
        #endregion

        #region 完了ボタン押下
        /// <summary>
        /// 完了ボタン押下
        /// </summary>
        /// <remarks></remarks>
        private void Btn_Regist_Click(object sender, EventArgs e)
        {
            if (GlobalVar.PACKING_COUNT < GlobalVar.MAX_COUNT )
            {
                new clsMessageBox().MessageBoxOKOnly("まだ完了していません。", "警告", MessageBoxIcon.Warning);
                this.ActiveControl = this.txtDeliverySlipControlNo;
                return;
            }

            try
            {
                _logger.Info("契約者返却梱包完了処理：開始");
                // トランザクション開始
                dao.BeginTransaction();

                // 梱包ラインテーブル更新処理
                dao.Update_PackingCompleate_T_MS_SHIPPING_LINE(GlobalVar.ID);

                // コミット
                dao.Commit();

                this.Close();
            }
            catch(Exception ex)
            {
                // ロールバック
                dao.Rollback();
                _logger.Info("梱包ラインテーブルテーブルの対象データ更新処理でエラーが発生しました。" + Environment.NewLine + $"エラー内容：{ex.ToString()}");
                new clsMessageBox().MessageBoxOKOnly("梱包ラインテーブルテーブルの対象データ更新処理でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "警告", MessageBoxIcon.Warning);
                return;
            }
            finally
            {
                _logger.Info("契約者返却梱包完了処理：終了");
            }
            
        }
        #endregion

        #endregion

        #region メソッド

        #region 梱包対象一覧表示
        /// <summary>
        /// 梱包対象一覧表示
        /// </summary>
        /// <remarks></remarks>
        private void displayGridviewPackingTarget()
        {
            List<Shipping_QMS> dtos = new List<Shipping_QMS>();
            dtos.Clear();

            DataTable dt = null;

            try
            {
                dt = dao.Select_ShippingTarget_T_MS_SHIPPING_QMS(GlobalVar.SHIPPING_DATE);

                if (dt.Rows.Count <= 0)
                {
                    _logger.Info("発送QMSテーブルに対象データが存在しません。");

                    // 空のデータグリッドビューを表示する
                    // データグリッドビューのクリア
                    dataGridView_Packing_Target.DataSource = null;
                    // Packing_LineのリストをDataGridViewにデータバインドする
                    dataGridView_Packing_Target.DataSource = dtos;
                }
            }
            catch (Exception ex)
            {
                _logger.Info("発送QMSテーブルの対象データ取得でエラーが発生しました。" + Environment.NewLine + $"エラー内容：{ex.ToString()}");
                new clsMessageBox().MessageBoxOKOnly("発送QMSテーブルの対象データ取得処理でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "警告", MessageBoxIcon.Warning);
                return;
            }

            int data_count = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // 検索結果を項目ごとにPacking_Lineに格納する
                Shipping_QMS dto = new Shipping_QMS();
                dto.ID = dt.Rows[i]["ID"].ToString();
                dto.DELIVERY_SLIP_CONTROL_NO = dt.Rows[i]["DELIVERY_SLIP_CONTROL_NO"].ToString();
                dto.READ_DELIVERY_SLIP_CONTROL_NO = dt.Rows[i]["READ_DELIVERY_SLIP_CONTROL_NO"].ToString();
                dto.READ_CONTROL_LABEL = dt.Rows[i]["READ_CONTROL_LABEL"].ToString();
                dto.CONTACT_NO = dt.Rows[i]["CONTACT_NO"].ToString();
                dto.READ_JUDGMENT = string.IsNullOrEmpty(dt.Rows[i]["READ_DELIVERY_SLIP_CONTROL_NO"].ToString()) ? "" : "〇";
                dto.PACKING_USER_NAME = dt.Rows[i]["PACKING_USER_NAME"].ToString();
                dto.PACKING_DATE = dt.Rows[i]["PACKING_DATE"].ToString();
                dtos.Add(dto);
                data_count++;
            }

            // Packing_LineのリストをDataGridViewにデータバインドする
            dataGridView_Packing_Target.DataSource = dtos;

            // データグリッドのタイトル設定
            dataGridView_Packing_Target.Columns[0].HeaderText = "ID";
            dataGridView_Packing_Target.Columns[1].HeaderText = "配送伝票";
            dataGridView_Packing_Target.Columns[2].HeaderText = "読取配送伝票";
            dataGridView_Packing_Target.Columns[3].HeaderText = "読取管理ラベル";
            dataGridView_Packing_Target.Columns[4].HeaderText = "お問合せ番号";
            dataGridView_Packing_Target.Columns[5].HeaderText = "判定";
            dataGridView_Packing_Target.Columns[6].HeaderText = "梱包担当者名";
            dataGridView_Packing_Target.Columns[7].HeaderText = "梱包日時";            

            // 更新禁止
            dataGridView_Packing_Target.Columns[0].ReadOnly = true;
            dataGridView_Packing_Target.Columns[1].ReadOnly = true;
            dataGridView_Packing_Target.Columns[2].ReadOnly = true;
            dataGridView_Packing_Target.Columns[3].ReadOnly = true;
            dataGridView_Packing_Target.Columns[4].ReadOnly = true;
            dataGridView_Packing_Target.Columns[5].ReadOnly = true;
            dataGridView_Packing_Target.Columns[6].ReadOnly = true;
            dataGridView_Packing_Target.Columns[7].ReadOnly = true;

            // 初期表示の選択されているセルをなくす
            dataGridView_Packing_Target.CurrentCell = null;

            // ヘッダテキストの文字列の折り返しを抑止
            dataGridView_Packing_Target.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

            // ヘッダテキストの文字配置はセル内センター
            dataGridView_Packing_Target.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 各列のソートを抑止(抑止しないとヘッダテキストがセンターにならない)
            foreach (DataGridViewColumn c in dataGridView_Packing_Target.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            // 列の自動設定を抑止
            dataGridView_Packing_Target.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // 各列の幅を設定
            dataGridView_Packing_Target.Columns[0].Width = 42;
            dataGridView_Packing_Target.Columns[1].Width = 125;
            dataGridView_Packing_Target.Columns[2].Width = 125;
            dataGridView_Packing_Target.Columns[3].Width = 165;
            dataGridView_Packing_Target.Columns[4].Width = 125;
            dataGridView_Packing_Target.Columns[5].Width = 40;
            dataGridView_Packing_Target.Columns[6].Width = 120;
            dataGridView_Packing_Target.Columns[7].Width = 85;

            // 文字サイスを設定
            dataGridView_Packing_Target.Font = new Font("メイリオ", 9);

            // 列のセルのテキストの配置を上下左右とも中央にする
            dataGridView_Packing_Target.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_Packing_Target.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_Packing_Target.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_Packing_Target.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_Packing_Target.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_Packing_Target.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_Packing_Target.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_Packing_Target.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 選択モードを行単位での選択のみにする
            dataGridView_Packing_Target.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // DataGridView1でセル、行、列が複数選択されないようにする
            dataGridView_Packing_Target.MultiSelect = false;

            // 梱包対象総件数保持
            GlobalVar.MAX_COUNT = dt.Rows.Count;

        }
        #endregion

        #region 完了件数表示
        /// <summary>
        /// 完了件数表示
        /// </summary>
        /// <remarks></remarks>
        private void setDisplayTotalCount(int totalCnt)
        {
            try
            {
                int cnt = dao.Select_PackingCompleateCnt_T_MS_SHIPPING_QMS(GlobalVar.SHIPPING_DATE);

                // 梱包件数保持
                GlobalVar.PACKING_COUNT = cnt;

                Label_Finish_Record_Num.Text = $"{cnt:000} / {totalCnt:000}";

                if (GlobalVar.PACKING_STATUS != "完了")
                {

                    if (totalCnt > 0 && cnt == totalCnt)
                    {
                        // 読込項目&再読込非活性化
                        this.txtDeliverySlipControlNo.Enabled = false;        // 配送伝票管理番号
                        this.txtControlLabel.Enabled = false;                 // 管理ラベル
                        this.txtContactNo.Enabled = false;                    // お問合せ番号
                        this.Btn_ReLoad.Enabled = false;                    　// お問合せ番号

                        new clsMessageBox().MessageBoxOKOnly("全件終了しました、完了してください。", "確認", MessageBoxIcon.Information);
                        // フォーカスをお問合せ番号の入力に変更                                                      
                        this.ActiveControl = this.Btn_Register;
                        return;
                    }
                    else
                    {
                        // 読込んだ内容をクリア
                        this.txtDeliverySlipControlNo.Text = "";             // 配送伝票管理番号
                        this.txtControlLabel.Text = "";                      // 管理ラベル
                        this.txtContactNo.Text = "";                         // お問合せ番号

                        // 読込項目活性化
                        this.txtDeliverySlipControlNo.Enabled = true;        // 配送伝票管理番号
                        this.txtControlLabel.Enabled = true;                 // 管理ラベル
                        this.txtContactNo.Enabled = true;                    // お問合せ番号

                        // txtControlLabel の背景色をWindowにする
                        this.txtDeliverySlipControlNo.BackColor = SystemColors.Window;
                        this.txtControlLabel.BackColor = SystemColors.Window;
                        this.txtContactNo.BackColor = SystemColors.Window;

                        GlobalVar.DELIVERY_SLIP_CONTROL_NO = null;      // 配送伝票管理番号
                        GlobalVar.CONTROL_LABEL = null;                 // 管理ラベル
                        GlobalVar.CONTACT_NO = null;                    // お問合せ番号
                        GlobalVar.CONTROL_NO = null;                    // 管理番号

                        this.ActiveControl = this.txtDeliverySlipControlNo;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Info("発送QMSテーブルの対象データ取得でエラーが発生しました。" + Environment.NewLine + $"エラー内容：{ex.ToString()}");
                new clsMessageBox().MessageBoxOKOnly("発送QMSテーブルの対象データ取得処理でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "警告", MessageBoxIcon.Warning);
                return;
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