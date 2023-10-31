using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.form
{
    public partial class frmMessageBoxYesNo : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="message"></param>
        /// <param name="caption"></param>
        /// <param name="icon"></param>
        public frmMessageBoxYesNo(string message, string caption, MessageBoxIcon icon)
        {
            InitializeComponent();
            if (icon == MessageBoxIcon.Information)
            {
                this.pictureIcon.Image = Properties.Resources.II;
            }
            else if(icon == MessageBoxIcon.Exclamation)
            {
                this.pictureIcon.Image = Properties.Resources.exc;
            }
            else
            {
                this.pictureIcon.Image = Properties.Resources.qu;
            }
            this.lblMessage.Text = message;
            this.Text = caption;
        }
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMessageBoxYesNo_Load(object sender, EventArgs e)
        {
            //this.btnOK.Visible = false;
        }
        /// <summary>
        /// キーダウンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMessageBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            //if( e.KeyCode == Keys.F5)
            // {
            //     this.btnOK.Visible = !this.btnOK.Visible;
            // }

        }
        /// <summary>
        /// キー押下処理
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter || keyData == Keys.Space)
            {
                //Activeを無効にする
                ActiveControl = null;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        /// <summary>
        /// いいえボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();

        }
        /// <summary>
        /// はいボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();

        }
    }
}
