using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using log4net;
using Common;
using MSPB300.dao;
using MSPB301.form;
using MSPB302.form;
using MSPB303.form;

namespace MSPB300.form
{
    public partial class frmMSPB300 : Form
    {
        // <summary>
        // ログ
        // </summary>
        //log4net使用宣言
        private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        daofrmMSPB300 dao = new daofrmMSPB300("DBConnection");
        DataTable lineDt = new DataTable();

        // <summary>
        // データグリッドビュー用 梱包ラインテーブル
        // </summary>
        public sealed class Packing_Line
        {
            // ID
            public string ID { get; set; }
            // 出荷日
            public string SHIPPING_DATE { get; set; }
            // 返却先
            public string RETURN_PLACE { get; set; }
            // 返却先名
            public string RETURN_PLACE_NAME { get; set; }
            // 件数
            public string PACKING_COUNT { get; set; }
            // 梱包ステータス
            public string PACKING_STATUS { get; set; }            
        }

        public frmMSPB300()
        {
            _logger.Info("梱包処理：開始");

            InitializeComponent();

            //Form画面の背景色&ラベルの文字色を初期設定
            var formInit = new frmBackColorChange();
            formInit.Set_FormInit(this);

            textBox_StaffName.ImeMode = (ImeMode)4;

            // ロード時にフォーカスを設定する
            this.ActiveControl = this.textBox_StaffName;

            // ライン一覧初期表示
            displayGridviewPackingLine(lineDt);
            Packing_Processing.Enabled = false;
            Shipping_Correct_Processing.Enabled = false;

        }

        #region イベント

        #region Form_Load
        /// <summary>
        /// Form_Load
        /// </summary>
        /// <remarks></remarks>
        private void frmMSPB300_Load(object sender, EventArgs e)
        {
            // 初期値(未選択状態)            
            Combobox_Shipping_Date.SelectedIndex = -1;
        }
        #endregion

        #region 終了ボタン押下
        /// <summary>
        /// 終了ボタン押下
        /// </summary>
        /// <remarks></remarks>
        private void End_Click(object sender, EventArgs e)
        {

            _logger.Debug("梱包処理：終了ボタン押下");
            _logger.Info("梱包処理：終了");

            Application.Exit();
        }
        #endregion

        #region 出荷指定日プルダウン処理
        /// <summary>
        /// 出荷指定日プルダウン処理
        /// </summary>
        /// <remarks></remarks>
        private void Combobox_Shipping_Date_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Combobox_Shipping_Date.SelectedIndex != -1)
            {
                GlobalVar.SHIPPING_DATE = Combobox_Shipping_Date.SelectedItem.ToString();
                Display_Line.Enabled = true;
            }
            else
            {
                GlobalVar.SHIPPING_DATE = null;
            }
        }
        #endregion

        #region 梱包処理ボタン押下
        /// <summary>
        /// 梱包処理ボタン押下
        /// </summary>
        /// <remarks></remarks>
        private void Packing_Processing_Click(object sender, EventArgs e)
        {
            // ライン一覧の行を選択しなかった場合
            if (dataGridView_Packing_Line.SelectedRows.Count <= 0)
            {
                _logger.Info("ラインが選択されていません。ラインを選択してください。");
                new clsMessageBox().MessageBoxOKOnly("ラインを選択してください。", "警告", MessageBoxIcon.Warning);                
                return;
            }

            GlobalVar.ID = dataGridView_Packing_Line.CurrentRow.Cells[0].Value.ToString();
            GlobalVar.RETRUN_PLACE_CODE = dataGridView_Packing_Line.CurrentRow.Cells[2].Value.ToString();
            GlobalVar.PACKING_STATUS = dataGridView_Packing_Line.CurrentRow.Cells[5].Value.ToString();

            if (GlobalVar.PACKING_STATUS != "完了" && GlobalVar.PACKING_STATUS != "作業中")
            {
                try
                {
                    // トランザクション開始
                    dao.BeginTransaction();

                    // 選択したラインの梱包ステータス更新
                    dao.UpdatePackingLineStatus_T_MS_PACKING_LINE(GlobalVar.ID);

                    // コミット
                    dao.Commit();

                    dataGridView_Packing_Line.CurrentRow.Cells[5].Value = "作業中";
                    dataGridView_Packing_Line.Refresh();
                }
                catch (Exception ex)
                {
                    // ロールバック
                    dao.Rollback();
                    _logger.Info("梱包ラインテーブルの更新処理でエラーが発生しました。" + Environment.NewLine + $"エラー内容：{ex.ToString()}");
                    new clsMessageBox().MessageBoxOKOnly("梱包ラインテーブルの更新処理でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "警告", MessageBoxIcon.Warning);
                    return;

                }
            }
            
            
            // 返却先コードが「１：契約者返却」の場合
            if (GlobalVar.RETRUN_PLACE_CODE == "1")
            {
                this.Hide();
                frmMSPB301 form_frmMSPRM301 = new frmMSPB301();
                form_frmMSPRM301.ShowDialog();

                try
                {
                    // ライン一覧再読込
                    lineDt = dao.Select_ShippingDate_From_T_MS_PACKING_LINE(GlobalVar.SHIPPING_DATE);
                    _logger.Info("梱包ラインテーブル取得数 [" + lineDt.Rows.Count + "]");

                    // 出荷日プルダウン設定
                    setShippingDateComboBox();

                    // ライン一覧再表示
                    displayGridviewPackingLine(lineDt);
                }
                catch (Exception ex)
                {
                    _logger.Info("梱包ラインテーブルより対象データ取得でエラーが発生しました。" + Environment.NewLine + $"エラー内容：{ex.ToString()}");
                    new clsMessageBox().MessageBoxOKOnly("梱包ラインテーブルよりデータ取得でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "警告", MessageBoxIcon.Warning);
                    return;
                }

                this.Show();
            }
            else
            {
                // 返却先コードが「２：ＭＳ返却」の場合
                this.Hide();
                frmMSPB302 form_frmMSPRM302 = new frmMSPB302();
                form_frmMSPRM302.ShowDialog();

                try
                {
                    // ライン一覧再読込
                    lineDt = dao.Select_ShippingDate_From_T_MS_PACKING_LINE(GlobalVar.SHIPPING_DATE);
                    _logger.Info("梱包ラインテーブル取得数 [" + lineDt.Rows.Count + "]");

                    // 出荷日プルダウン設定
                    setShippingDateComboBox();

                    // ライン一覧再表示
                    displayGridviewPackingLine(lineDt);
                }
                catch (Exception ex)
                {
                    _logger.Info("梱包ラインテーブルより対象データ取得でエラーが発生しました。" + Environment.NewLine + $"エラー内容：{ex.ToString()}");
                    new clsMessageBox().MessageBoxOKOnly("梱包ラインテーブルよりデータ取得でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "警告", MessageBoxIcon.Warning);
                    return;
                }

                this.Show();
            }
        }

        #endregion

        #region 梱包訂正処理ボタン押下
        /// <summary>
        /// 梱包訂正処理ボタン押下
        /// </summary>
        /// <remarks></remarks>        
        private void Shipping_Correct_Processing_Click(object sender, EventArgs e)
        {
            // ライン一覧の行を選択しなかった場合
            if (dataGridView_Packing_Line.SelectedRows.Count <= 0)
            {
                _logger.Info("ラインが選択されていません。ラインを選択してください。");
                new clsMessageBox().MessageBoxOKOnly("ラインを選択してください。", "警告", MessageBoxIcon.Warning);
                return;
            }

            GlobalVar.ID = dataGridView_Packing_Line.CurrentRow.Cells[0].Value.ToString();
            GlobalVar.RETRUN_PLACE_CODE = dataGridView_Packing_Line.CurrentRow.Cells[2].Value.ToString();
            GlobalVar.PACKING_STATUS = dataGridView_Packing_Line.CurrentRow.Cells[5].Value.ToString();

            // 返却先コードが「１：契約者返却」の場合
            if (GlobalVar.RETRUN_PLACE_CODE == "1")
            {
                this.Hide();
                frmMSPB303 form_frmMSPRM303 = new frmMSPB303();
                form_frmMSPRM303.ShowDialog();

                try
                {
                    // ライン一覧再読込
                    lineDt = dao.Select_ShippingDate_From_T_MS_PACKING_LINE(GlobalVar.SHIPPING_DATE);
                    _logger.Info("梱包ラインテーブル取得数 [" + lineDt.Rows.Count + "]");

                    // 出荷日プルダウン設定
                    setShippingDateComboBox();

                    // ライン一覧再表示
                    displayGridviewPackingLine(lineDt);
                }
                catch (Exception ex)
                {
                    _logger.Info("梱包ラインテーブルより対象データ取得でエラーが発生しました。" + Environment.NewLine + $"エラー内容：{ex.ToString()}");
                    new clsMessageBox().MessageBoxOKOnly("梱包ラインテーブルよりデータ取得でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "警告", MessageBoxIcon.Warning);
                    return;
                }

                this.Show();
            }
            else
            {
                // 返却先コードが「２：ＭＳ返却」の場合
                new clsMessageBox().MessageBoxOKOnly("MS返却は訂正できません。", "警告", MessageBoxIcon.Warning);
                return;
            }
            
        }

        #endregion

        #region 担当者名入力チェック
        /// <summary>
        /// 担当者名入力チェック
        /// </summary>
        /// <remarks></remarks>
        private void textBox_StaffName_KeyDown(object sender, KeyEventArgs e)
        {
            //ENTERキーが押されたかチェック
            if (e.KeyCode == Keys.Enter)
            {
                _logger.Info("enter キー ボタン押下 終了");

                //ENTERキーのみの場合のチェック
                if (textBox_StaffName.Text.Length == 0)
                {
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox_StaffName.Text))
                {
                    _logger.Info("担当者名が空文字です。担当者名を入力してください。");
                    MessageBox.Show("担当者名が空文字です。" + Environment.NewLine + "担当者名を入力してください。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.ActiveControl = this.textBox_StaffName;
                    textBox_StaffName.Text = "";
                    return;
                }

                GlobalVar.STAFF_NAME = textBox_StaffName.Text;

                // メニューのボタンを有効化
                Combobox_Shipping_Date.Enabled = true;

                // 出荷日プルダウン設定
                setShippingDateComboBox();

                this.ActiveControl = this.Combobox_Shipping_Date;
            }

            if (e.KeyCode == Keys.Tab)
            {
                return;
            }
        }

        #endregion

        #region ライン表示ボタン押下
        /// <summary>
        /// ライン表示ボタン押下
        /// </summary>
        /// <remarks></remarks>
        private void Display_Line_Click(object sender, EventArgs e)
        {
            //担当者名入力チェック
            if (string.IsNullOrEmpty(GlobalVar.STAFF_NAME))
            {
                _logger.Info("担当者名が入力されていません。担当者名を入力してください。");
                MessageBox.Show("担当者名が入力されていません。" + Environment.NewLine + "担当者名を入力してください。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.ActiveControl = this.textBox_StaffName;
                return;
            }

            //出荷日入力チェック
            if (string.IsNullOrEmpty(GlobalVar.SHIPPING_DATE))
            {
                _logger.Info("出荷日が指定されていません。出荷日を指定してください。");
                MessageBox.Show("出荷日が指定されていません。" + Environment.NewLine + "出荷日をし指定してください。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.ActiveControl = this.Combobox_Shipping_Date;
                return;
            }

            try
            {
                //梱包ラインテーブルより取得
                lineDt = dao.Select_ShippingDate_From_T_MS_PACKING_LINE(GlobalVar.SHIPPING_DATE);
                _logger.Info("梱包ラインテーブル取得数 [" + lineDt.Rows.Count + "]");
            }
            catch (Exception ex)
            {
                _logger.Info("梱包ラインテーブルより対象データ取得でエラーが発生しました。" + Environment.NewLine + $"エラー内容：{ex.ToString()}");
                new clsMessageBox().MessageBoxOKOnly("梱包ラインテーブルよりデータ取得でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "警告", MessageBoxIcon.Warning);
                return;
            }

            // ライン一覧表示
            displayGridviewPackingLine(lineDt);
        }
        #endregion

        #endregion

        #region メソッド

        #region ライン一覧表示処理
        /// <summary>
        /// ライン一覧表示処理
        /// </summary>
        /// <remarks></remarks>
        private void displayGridviewPackingLine(DataTable dt)
        {
            List<Packing_Line> dtos = new List<Packing_Line>();
            dtos.Clear();

            try
            {                
                if (dt.Rows.Count <= 0)
                {
                    _logger.Info("対象データが梱包ラインテーブルに存在しません。");

                    //空のデータグリッドビューを表示する
                    //データグリッドビューのクリア
                    dataGridView_Packing_Line.DataSource = null;
                    //Packing_LineのリストをDataGridViewにデータバインドする
                    dataGridView_Packing_Line.DataSource = dtos;
                }

                int data_count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //検索結果を項目ごとにPacking_Lineに格納する
                    Packing_Line dto = new Packing_Line();
                    dto.ID = dt.Rows[i]["ID"].ToString();
                    dto.SHIPPING_DATE = dt.Rows[i]["SHIPPING_DATE"].ToString();
                    dto.RETURN_PLACE = dt.Rows[i]["RETURN_PLACE"].ToString();
                    dto.RETURN_PLACE_NAME = dt.Rows[i]["RESPONSE_TEXT"].ToString();
                    dto.PACKING_COUNT = dt.Rows[i]["PACKING_COUNT"].ToString();
                    dto.PACKING_STATUS = dt.Rows[i]["PACKING_STATUS"].ToString();
                    dtos.Add(dto);
                    data_count++;
                }

                //Packing_LineのリストをDataGridViewにデータバインドする
                dataGridView_Packing_Line.DataSource = dtos;

                //データグリッドのタイトル設定
                dataGridView_Packing_Line.Columns[0].HeaderText = "ID";
                dataGridView_Packing_Line.Columns[1].HeaderText = "出荷日";
                dataGridView_Packing_Line.Columns[2].HeaderText = "返却先_CD";
                dataGridView_Packing_Line.Columns[3].HeaderText = "返却先";
                dataGridView_Packing_Line.Columns[4].HeaderText = "件数";
                dataGridView_Packing_Line.Columns[5].HeaderText = "梱包";

                //更新禁止
                dataGridView_Packing_Line.Columns[0].ReadOnly = true;
                dataGridView_Packing_Line.Columns[1].ReadOnly = true;
                dataGridView_Packing_Line.Columns[2].ReadOnly = true;
                dataGridView_Packing_Line.Columns[3].ReadOnly = true;
                dataGridView_Packing_Line.Columns[4].ReadOnly = true;
                dataGridView_Packing_Line.Columns[5].ReadOnly = true;

                //初期表示の選択されているセルをなくす
                dataGridView_Packing_Line.CurrentCell = null;

                //ヘッダテキストの文字列の折り返しを抑止
                dataGridView_Packing_Line.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

                //ヘッダテキストの文字配置はセル内センター
                dataGridView_Packing_Line.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //各列のソートを抑止(抑止しないとヘッダテキストがセンターにならない)
                foreach (DataGridViewColumn c in dataGridView_Packing_Line.Columns)
                    c.SortMode = DataGridViewColumnSortMode.NotSortable;

                //列の自動設定を抑止
                dataGridView_Packing_Line.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                //各列の幅を設定
                dataGridView_Packing_Line.Columns[0].Width = 60;
                dataGridView_Packing_Line.Columns[1].Width = 110;
                dataGridView_Packing_Line.Columns[2].Width = 100;
                dataGridView_Packing_Line.Columns[3].Width = 100;
                dataGridView_Packing_Line.Columns[4].Width = 80;
                dataGridView_Packing_Line.Columns[5].Width = 110;

                //文字サイスを設定
                dataGridView_Packing_Line.Font = new Font("メイリオ", 10);

                //列のセルのテキストの配置を上下左右とも中央にする
                dataGridView_Packing_Line.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView_Packing_Line.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView_Packing_Line.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView_Packing_Line.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView_Packing_Line.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView_Packing_Line.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //返却先CDを非表示
                dataGridView_Packing_Line.Columns[2].Visible = false;

                // 選択モードを行単位での選択のみにする
                dataGridView_Packing_Line.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                //DataGridView1でセル、行、列が複数選択されないようにする
                dataGridView_Packing_Line.MultiSelect = false;

                Packing_Processing.Enabled = true;

                Shipping_Correct_Processing.Enabled = true;
            }
            catch (Exception ex)
            {
                _logger.Info("ライン一覧表示処理でエラーが発生しました。" + Environment.NewLine + $"エラー内容：{ex.ToString()}");
                new clsMessageBox().MessageBoxOKOnly("ライン一覧表示処理でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "警告", MessageBoxIcon.Warning);
                return;
            }
        }
        #endregion

        #region 出荷日プルダウン設定
        private void setShippingDateComboBox()
        {
            try
            {
                // 梱包ラインテーブルより出荷日取得
                DataTable dt = dao.Select_ShippingDate_T_MS_PACKING_LINE();

                _logger.Info("出荷日取得件数 [" + dt.Rows.Count + "]");

                Combobox_Shipping_Date.Items.Clear();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Combobox_Shipping_Date.Items.Add(dt.Rows[i]["SHIPPING_DATE"].ToString());
                }
            }
            catch (Exception ex)
            {
                _logger.Info("梱包ラインテーブルより出荷日取得取得でエラーが発生しました。" + Environment.NewLine + $"エラー内容：{ex.ToString()}");
                new clsMessageBox().MessageBoxOKOnly("梱包ラインテーブルより出荷日取得でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "警告", MessageBoxIcon.Warning);
                return;
            }
        }
        #endregion

        #endregion

    }
}
