using System;
using System.Data;
using System.Windows.Forms;
using MSPB300.form;

//グローバル変数
public static class GlobalVar
{
    public static string STAFF_NAME;                // 担当者名
    public static string SHIPPING_DATE;             // 出荷日
    public static string ID;                        // ID
    public static string RETRUN_PLACE_CODE;         // 返却先コード
    public static string PACKING_STATUS;            // 梱包ステータス
    public static string DELIVERY_SLIP_CONTROL_NO;  // 配送伝票管理番号
    public static string CONTROL_LABEL;             // 管理ラベル
    public static string CONTROL_NO;                // 管理番号
    public static string CONTACT_NO;                // お問合せ番号
    public static int MAX_COUNT;                    // 梱包対象総件数
    public static int PACKING_COUNT;                // 梱包処理件数
}

namespace MSPB300
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMSPB300());
        }
    }
}
