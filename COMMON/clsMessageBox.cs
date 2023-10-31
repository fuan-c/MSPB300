using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Common.form;

namespace Common
{

    /// <summary>
    /// メッセージボックス表示
    /// </summary>
    public class clsMessageBox
    {
        public clsMessageBox()
        {

        }
        /// <summary>
        /// メッセーズボックス表示
        /// </summary>
        /// <param name="message"></param>
        /// <param name="caption"></param>
        /// <returns></returns>
        public DialogResult MessageBoxOKOnly(string message,string caption,MessageBoxIcon icon)
        {
            frmMessageBox p = new frmMessageBox(message, caption,icon);
            p.ShowDialog();
            return DialogResult.OK;
        }


        public DialogResult MessageBoxYesNo(string message, string caption, MessageBoxIcon icon)
        {
            frmMessageBoxYesNo p = new frmMessageBoxYesNo(message, caption, icon);
            p.ShowDialog();
            return p.DialogResult;

        }



















    }
}
