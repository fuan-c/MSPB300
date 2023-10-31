using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using log4net;
using System.Diagnostics;
//using Microsoft.WindowsAPICodePack.Dialogs;
using System.Media;
using MSPB300.Common;
using MSPB300.dao;


namespace MSPB300.form
{public partial class frmMSPB302 : Form

    {
        // <summary>
        // ログ
        // </summary>
        //log4net使用宣言
        private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        daofrmMSPB302 dao = new daofrmMSPB302("DBConnection");




        public frmMSPB302()
        {
            _logger.Info("MS返却梱包処理 開始");

            InitializeComponent();
                        
            //Form画面の背景色&ラベルの文字色を初期設定
            var formInit = new frmBackColorChange();
            formInit.Set_FormInit(this);

            txtStaffName.Text = GlobalVar.STAFF_NAME;
            lblShippingDate.Text = GlobalVar.SHIPPING_DATE;

            GlobalVar.RETRUN_PLACE_CODE = "2";      // 返却先「2:MS返却」

            //完了件数表示
            setDisplayTotalCount();

            this.ActiveControl = this.txtContactNo;

        }

        #region イベント

        #region 戻るボタン
        /// <summary>
        /// 戻るボタン
        /// </summary>
        /// <remarks></remarks>
        private void Cancel_Click(object sender, EventArgs e)
        {
            _logger.Info("MS返却梱包処理　戻る ボタン押下 開始");
            DialogResult result = MessageBox.Show("梱包処理画面に戻ります、よろしいですか？　はい(Y) or いいえ(N)", "MS返却梱包処理", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }         
        }
        #endregion

        #region 完了ボタン
        /// <summary>
        /// 完了ボタン
        /// </summary>
        /// <remarks></remarks>
        private void Register_Click(object sender, EventArgs e)
        {
           
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
                var totalCnt = dao.Select_TotalCnt_T_MS_PB_PACKING_LINE(GlobalVar.SHIPPING_DATE, GlobalVar.RETRUN_PLACE_CODE);
                var compleateCnt = dao.Select_CompleateCnt_T_ESCALATION(GlobalVar.SHIPPING_DATE);

                // MS返却梱包総件数保持
                GlobalVar.MAX_COUNT =  int.Parse(totalCnt.Rows[0]["PACKING_COUNT"].ToString());
                // MS返却梱包処理完了件数保持
                GlobalVar.PACKING_COUNT = compleateCnt.Rows.Count;

                Label_Finish_Record_Num.Text = $"{GlobalVar.PACKING_COUNT:000} / {GlobalVar.MAX_COUNT:000}";
                
            }
            catch (Exception ex)
            {
                _logger.Info("完了件数取得でエラーが発生しました。" + Environment.NewLine + $"エラー内容：{ex.ToString()}");
                new clsMessageBox().MessageBoxOKOnly("完了件数取得処理でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "警告", MessageBoxIcon.Warning);
                return;
            }
        }
        #endregion

        #endregion
    }
}