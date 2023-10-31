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
    public partial class frmMessageBox : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="message"></param>
        /// <param name="caption"></param>
        public frmMessageBox(string message, string caption,MessageBoxIcon icon)
        {
            InitializeComponent();
            if(icon == MessageBoxIcon.Information)
            {
                this.pictureIcon.Image = Properties.Resources.II;
            }
            else
            {
                this.pictureIcon.Image = Properties.Resources.exc;
            }
            this.lblMessage.Text = message;
            this.Text = caption;
        }
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMessageBox_Load(object sender, EventArgs e)
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
        /// OKボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
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

    }
}
