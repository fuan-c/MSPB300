using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using log4net;
using System.Diagnostics;
using Common;
using MSPB302.dao;
using System.Configuration;
using MSADBEEP;

namespace MSPB302.form
{public partial class frmMSPB302 : Form

    {
        // <summary>
        // ログ
        // </summary>
        //log4net使用宣言
        private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        daofrmMSPB302 dao = new daofrmMSPB302("DBConnection");

        List<MSRtn_Packing_Target_Data> packingTrgList = null;

        List<MSRtn_Packing_List> dtos = new List<MSRtn_Packing_List>();

        MSRtn_Packing_Target_Data mspdDefault = new MSRtn_Packing_Target_Data();

        private static int packingTrgCnt = 0;

        // <summary>
        // 内部テーブル用
        // </summary>
        public sealed class MSRtn_Packing_Target_Data
        {            
            // 管理番号
            public string CONTROL_NO { get; set; }
            // 管理ラベル
            public string CONTROL_LABEL { get; set; }
            // 読取済管理番号
            public bool READ_CONTROL_NO { get; set; }
        }

        // <summary>
        // データグリッドビュー用 エスカレテーブル
        // </summary>
        public sealed class MSRtn_Packing_List
        {
            // ID
            public int ID { get; set; }
            // 管理ラベル
            public string CONTROL_LABEL { get; set; }
            // 管理番号
            public string CONTROL_NO { get; set; }
        }


        public frmMSPB302()
        {
            _logger.Info("MS返却梱包処理 開始");

            InitializeComponent();
                        
            //Form画面の背景色&ラベルの文字色を初期設定
            var formInit = new frmBackColorChange();
            formInit.Set_FormInit(this);

            txtStaffName.Text = GlobalVar.STAFF_NAME;
            lblShippingDate.Text = GlobalVar.SHIPPING_DATE;


            this.Shown += new EventHandler(dataGridViewPackingTagetShown);
            // 完了件数表示
            //setDisplayTotalCount();

            // 梱包対象データ取得
            packingTrgList = getPackingTrgList();

            // 梱包一覧表示            
            setDisplayDataGridView(mspdDefault);

            this.ActiveControl = this.txtControlLabel;

        }

        #region イベント

        #region フォームのShownイベント・ハンドラ
        // フォームのShownイベント・ハンドラ
        void dataGridViewPackingTagetShown(object sender, EventArgs e)
        {
            if (GlobalVar.PACKING_STATUS != "完了")
            {
                setDisplayTotalCount();
            }
            else
            {                
                txtControlLabel.Enabled = false;
                Btn_Register.Enabled = false;

                setDisplayTotalCount();
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
                _logger.Debug("enter キー ボタン押下 終了");

                // 管理ラベルの値が21桁ではない場合
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
                // 管理ラベルの最後の文字が"#"ではない場合
                if (txtControlLabel.Text.Substring(20, 1) != "#")
                {
                    _logger.Info("管理ラベルが「#」で終了していません。" + txtControlLabel.Text);

                    // Beep音実行
                    string alert_string = "形式が異なります、再度、読み込んでください。";
                    int ret = Output_Alert(alert_string);
                    txtControlLabel.Text = "";
                    this.ActiveControl = this.txtControlLabel;
                    return;
                }

                var trgControNo = txtControlLabel.Text.Substring(0, 20);

                int listCnt = 0;

                foreach (MSRtn_Packing_Target_Data trgData in packingTrgList)
                {

                    listCnt++;

                    if(trgData.CONTROL_NO == trgControNo && trgData.READ_CONTROL_NO == false)
                    {
                        trgData.CONTROL_LABEL = txtControlLabel.Text;
                        trgData.READ_CONTROL_NO = true;

                        setDisplayDataGridView(trgData);

                        // 梱包対象一覧内の選択セルを解除
                        dataGridView_Packing_Target.ClearSelection();

                        int rowNo = 0;

                        // 更新した行を選択
                        foreach (DataGridViewRow row in dataGridView_Packing_Target.Rows)
                        {
                            if (row.Cells[1].Value.ToString() == txtControlLabel.Text)
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

                        this.txtControlLabel.Text = "";
                        this.ActiveControl = this.txtControlLabel;
                        break;
                    }
                    else if (trgData.CONTROL_NO == trgControNo && trgData.READ_CONTROL_NO == true)
                    {
                        // Beep音実行
                        string alert_string = "読込済です、確認してください。";
                        int ret = Output_Alert(alert_string);                        

                        int rowNo = 0;

                        // 更新した行を選択
                        foreach (DataGridViewRow row in dataGridView_Packing_Target.Rows)
                        {
                            if (row.Cells[1].Value.ToString() == txtControlLabel.Text)
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

                        txtControlLabel.Text = "";
                        this.ActiveControl = this.txtControlLabel;

                        break; 
                    }
                    else if (trgData.CONTROL_NO != trgControNo && listCnt == packingTrgList.Count)
                    {
                        // Beep音実行
                        string alert_string = "対象の｢管理ラベル｣ではありません、確認してください。";
                        int ret = Output_Alert(alert_string);
                        txtControlLabel.Text = "";
                        this.ActiveControl = this.txtControlLabel;                        
                    }
                }

            }
        }
        #endregion

        #region 戻るボタン押下
        /// <summary>
        /// 戻るボタン押下
        /// </summary>
        /// <remarks></remarks>
        private void Cancel_Click(object sender, EventArgs e)
        {
            _logger.Debug("MS返却梱包処理　戻る ボタン押下");

            // 「梱包一覧」にデータがない場合
            if (dataGridView_Packing_Target.Rows.Count <= 0)
            {
                DialogResult result = new clsMessageBox().MessageBoxYesNo("梱包処理画面に戻ります、よろしいですか？", "確認", MessageBoxIcon.Information);                
                if (result == DialogResult.Yes)
                {
                    _logger.Info("MS返却梱包処理 終了");
                    this.Close();
                }
                else
                {                    
                    this.ActiveControl = this.txtControlLabel;                    
                }
            }
            else
            {
                // 「梱包一覧」にデータが存在場合
                DialogResult result = new clsMessageBox().MessageBoxYesNo("梱包データが未登録です、よろしいですか？", "警告", MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    // 「梱包一覧」の「梱包データ」破棄確認
                    DialogResult result1 = new clsMessageBox().MessageBoxYesNo("梱包データを破棄します、よろしいですか？", "警告", MessageBoxIcon.Warning);
                    if (result1 == DialogResult.Yes)
                    {
                        packingTrgCnt = 0;
                        _logger.Info("MS返却梱包処理 終了");
                        this.Close();
                    }
                    else
                    {                        
                        this.ActiveControl = this.txtControlLabel;                        
                    }
                }
                else
                {                    
                    this.ActiveControl = this.txtControlLabel;                    
                }
            }
                   
        }
        #endregion

        #region 一梱包完了ボタン押下
        /// <summary>
        /// 一梱包完了ボタン押下
        /// </summary>
        /// <remarks></remarks>
        private void Register_Click(object sender, EventArgs e)
        {
            _logger.Debug("MS返却梱包処理 一梱包完了 ボタン押下");

            DialogResult result = new clsMessageBox().MessageBoxYesNo("一梱包分完了します。", "確認", MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                _logger.Info("MS返却梱包処理 一梱包完了処理 開始");

                try
                {
                    // トランザクション開始
                    dao.BeginTransaction();

                    foreach (DataGridViewRow row in dataGridView_Packing_Target.Rows)
                    {
                        // 梱包済対象データのエスカレテーブル更新
                        dao.Update_MSRtrnPackingCompleate_T_ESCALATION(row.Cells[2].Value.ToString());
                    }

                    // コミット
                    dao.Commit();
                }
                catch (Exception ex)
                {
                    // ロールバック
                    dao.Rollback();
                    _logger.Info("梱包処理対象のエスカレテーブル更新処理でエラーが発生しました。" + Environment.NewLine + $"エラー内容：{ex.ToString()}");
                    new clsMessageBox().MessageBoxOKOnly("梱包処理対象のエスカレテーブル更新処理でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "警告", MessageBoxIcon.Warning);
                }


                foreach (DataGridViewRow row in dataGridView_Packing_Target.Rows)
                {
                    try
                    {
                        // トランザクション開始
                        dao.BeginTransaction();

                        // 梱包済対象データのエスカレテーブル更新
                        dao.Update_MSRtrnPackingCompleate_T_ESCALATION(row.Cells[2].Value.ToString());

                        // コミット
                        dao.Commit();
                        
                    }
                    catch (Exception ex)
                    {
                        // ロールバック
                        dao.Rollback();
                        _logger.Info("梱包処理対象のエスカレテーブル更新処理でエラーが発生しました。" + Environment.NewLine + $"エラー内容：{ex.ToString()}");
                        new clsMessageBox().MessageBoxOKOnly("梱包処理対象のエスカレテーブル更新処理でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "警告", MessageBoxIcon.Warning);                        
                    }
                }

                // 梱包一覧DataGridView初期化
                dtos.Clear();
                setDisplayDataGridView(mspdDefault);

                // 完了件数再表示
                setDisplayTotalCount();

                // 梱包一覧のNO初期化
                packingTrgCnt = 0;

                // フォーカス管理番号欄にセット
                this.ActiveControl = this.txtControlLabel;

                _logger.Info("MS返却梱包処理 一梱包完了処理 終了");
            }
            else
            {
                this.ActiveControl = this.txtControlLabel;
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

        #endregion


        #region メソッド

        #region 完了件数表示
        /// <summary>
        /// 完了件数表示
        /// </summary>
        /// <remarks></remarks>
        private void setDisplayTotalCount()
        {
            try
            {
                var totalCnt = dao.Select_TotalCnt_T_MS_PACKING_LINE(GlobalVar.SHIPPING_DATE, GlobalVar.RETRUN_PLACE_CODE);
                var compleateCnt = dao.Select_CompleateCnt_T_ESCALATION(GlobalVar.SHIPPING_DATE);

                // MS返却梱包総件数保持
                GlobalVar.MAX_COUNT =  int.Parse(totalCnt.Rows[0]["PACKING_COUNT"].ToString());
                // MS返却梱包処理完了件数保持
                GlobalVar.PACKING_COUNT = compleateCnt.Rows.Count;

                Label_Finish_Record_Num.Text = $"{GlobalVar.PACKING_COUNT:000} / {GlobalVar.MAX_COUNT:000}";

                if (GlobalVar.MAX_COUNT > 0 && GlobalVar.PACKING_COUNT == GlobalVar.MAX_COUNT)
                {                    
                    new clsMessageBox().MessageBoxOKOnly("全件終了しました。", "確認", MessageBoxIcon.Information);

                    try
                    {
                        _logger.Info("MS返却梱包処理 完了処理 開始");
                        // トランザクション開始
                        dao.BeginTransaction();

                        // 梱包ラインテーブル更新処理
                        dao.Update_PackingCompleate_T_MS_SHIPPING_LINE(GlobalVar.ID);

                        // コミット
                        dao.Commit();

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        // ロールバック
                        dao.Rollback();
                        _logger.Info("梱包ラインテーブルテーブルの対象データ更新処理でエラーが発生しました。" + Environment.NewLine + $"エラー内容：{ex.ToString()}");
                        new clsMessageBox().MessageBoxOKOnly("梱包ラインテーブルテーブルの対象データ更新処理でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "警告", MessageBoxIcon.Warning);
                        return;
                    }
                    finally
                    {
                        _logger.Info("MS返却梱包処理 完了処理 終了");
                    }

                    this.Close();
                    return;
                }
                
            }
            catch (Exception ex)
            {
                _logger.Info("完了件数取得でエラーが発生しました。" + Environment.NewLine + $"エラー内容：{ex.ToString()}");
                new clsMessageBox().MessageBoxOKOnly("完了件数取得処理でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "警告", MessageBoxIcon.Warning);
                return;
            }
        }
        #endregion

        #region 梱包対象データ取得
        /// <summary>
        /// 梱包対象データ取得
        /// </summary>
        /// <remarks></remarks>
        private List<MSRtn_Packing_Target_Data> getPackingTrgList()
        {
            List<MSRtn_Packing_Target_Data> trgList = new List<MSRtn_Packing_Target_Data>();

            try
            {
                // エスカレテーブルよりMS返却梱包対象抽出
                var dt = dao.Select_ShippingTarget_T_ESCALATION(GlobalVar.SHIPPING_DATE);

                if (dt.Rows.Count <= 0)
                {
                    _logger.Info("エスカレテーブルに対象データが存在しません。");
                }
                else
                {
                    foreach(DataRow row in dt.Rows)
                    {
                        MSRtn_Packing_Target_Data packingTrg = new MSRtn_Packing_Target_Data
                        {
                            CONTROL_NO = row["CONTROL_NO"].ToString(),
                            READ_CONTROL_NO = false
                        };

                        trgList.Add(packingTrg);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Info("エスカレテーブルの対象データ取得でエラーが発生しました。" + Environment.NewLine + $"エラー内容：{ex.ToString()}");
                new clsMessageBox().MessageBoxOKOnly("エスカレテーブルの対象データ取得処理でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "警告", MessageBoxIcon.Warning);                
            }

            return trgList;
        }
        #endregion


        #region 梱包一覧のDataGridViewバインド
        /// <summary>
        /// 梱包一覧のDataGridViewバインド
        /// </summary>
        /// <remarks></remarks>
        private void setDisplayDataGridView(MSRtn_Packing_Target_Data mspt)
        {            
            // 空のデータグリッドビューを表示する
            // データグリッドビューのクリア
            dataGridView_Packing_Target.DataSource = null;

            if (!string.IsNullOrEmpty(mspt.CONTROL_NO))
            {
                packingTrgCnt++;
                // 検索結果を項目ごとにPacking_Lineに格納する
                MSRtn_Packing_List dto = new MSRtn_Packing_List();
                dto.ID = packingTrgCnt;
                dto.CONTROL_LABEL = mspt.CONTROL_LABEL.ToString();
                dto.CONTROL_NO = mspt.CONTROL_NO.ToString();
                dtos.Add(dto);
            }

            // Packing_LineのリストをDataGridViewにデータバインドする
            dataGridView_Packing_Target.DataSource = dtos;

            // データグリッドのタイトル設定
            dataGridView_Packing_Target.Columns[0].HeaderText = "ID";
            dataGridView_Packing_Target.Columns[1].HeaderText = "管理ラベル";
            dataGridView_Packing_Target.Columns[2].HeaderText = "管理番号";

            // 更新禁止
            dataGridView_Packing_Target.Columns[0].ReadOnly = true;
            dataGridView_Packing_Target.Columns[1].ReadOnly = true;
            dataGridView_Packing_Target.Columns[2].ReadOnly = true;

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
            dataGridView_Packing_Target.Columns[0].Width = 60;
            dataGridView_Packing_Target.Columns[1].Width = 237;
            dataGridView_Packing_Target.Columns[2].Width = 237;

            // 文字サイスを設定
            dataGridView_Packing_Target.Font = new Font("メイリオ", 10);

            // 列のセルのテキストの配置を上下左右とも中央にする
            dataGridView_Packing_Target.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_Packing_Target.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_Packing_Target.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 管理番号非表示
            dataGridView_Packing_Target.Columns[2].Visible = false;

            // 選択モードを行単位での選択のみにする
            dataGridView_Packing_Target.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // DataGridView1でセル、行、列が複数選択されないようにする
            dataGridView_Packing_Target.MultiSelect = false;

            dataGridView_Packing_Target.Refresh();

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