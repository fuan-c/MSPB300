using log4net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Common
{
    public class frmBackColorChange
    {
        // <summary>
        // ログ
        // </summary>
        //log4net使用宣言
        private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public struct FORM_BACK_COLOR
        {
            /// <summary>
            /// 私物返却管理DBフォーム背景色
            /// </summary>
            //public static readonly Color MSPB_FormBackColor = Color.FromArgb(255, 167, 167);            
        }

        public void Set_FormInit(Control form)
        {
            //_logger.Info("frmBackColorChange.Set_FormInit:開始");

            var allControls = GetAllControls(form);
            var lbList = GetLabelOnly(allControls);
            foreach (var lbCtrl in lbList)
            {
                //文字色が赤のラベルのみ、文字色を黒に変更する
                if (lbCtrl.ForeColor == Color.Firebrick)
                {
                    lbCtrl.ForeColor = Color.Black;
                }
            }
            //_logger.Info("frmBackColorChange.Set_FormInit:終了");
        }

        /// <summary>
        /// 画面上の全コントロール取得
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        //すべての子孫コントロールを列挙して、TabIndex順に返す。
        private Control[] GetAllControls(Control parentControl)
        {
            if (parentControl == null)
            {
                throw new ArgumentNullException();
            }

            //順序無視で追加(子コントロールは含めない)。
            List<Control> controls = new List<Control>();
            foreach (Control control in parentControl.Controls)
            {
                controls.Add(control);
            }

            //TabIndex順にソートする。
            controls.Sort(delegate (Control x, Control y) { return x.TabIndex - y.TabIndex; });

            //再帰して、子コントロールを挿入する。
            for (int i = controls.Count - 1; i >= 0; i--)
            {
                Control container = controls[i];
                if (container.HasChildren)
                {
                    controls.InsertRange(i, GetAllControls(container));
                }
            }
            return controls.ToArray();
        }

        /// <summary>
        /// control配列からLabelのみのリストを返却
        /// </summary>
        /// <param name="parents">controlの配列</param>
        /// <returns></returns>
        public List<Label> GetLabelOnly(Control[] parents)
        {
            List<Label> controls = new List<Label>();
            var type_find = typeof(Label);

            foreach (Control child in parents)
            {
                if (child.GetType() == type_find)
                {
                    controls.Add((Label)child);
                }
            }

            return controls;
        }

    }
}
