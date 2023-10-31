namespace MSPB303.form
{
    partial class frmMSPB303
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Btn_Delete = new System.Windows.Forms.Button();
            this.Result = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtDeliverySlipControlNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDeliverySlipControlNo = new System.Windows.Forms.Label();
            this.lblShippingDataID = new System.Windows.Forms.Label();
            this.lblRegistUser = new System.Windows.Forms.Label();
            this.lblRegistDate = new System.Windows.Forms.Label();
            this.lblReadControlLabel = new System.Windows.Forms.Label();
            this.lblContactNo = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblReadDeliverySlipControlNo = new System.Windows.Forms.Label();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.header0 = new System.Windows.Forms.Label();
            this.header1 = new System.Windows.Forms.Label();
            this.StaffName = new System.Windows.Forms.Label();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblShippingDate = new System.Windows.Forms.Label();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Btn_Cancel.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Btn_Cancel.Location = new System.Drawing.Point(39, 423);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(120, 31);
            this.Btn_Cancel.TabIndex = 10;
            this.Btn_Cancel.Text = "戻る";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Btn_Delete
            // 
            this.Btn_Delete.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Btn_Delete.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Btn_Delete.ForeColor = System.Drawing.Color.Black;
            this.Btn_Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Delete.Location = new System.Drawing.Point(732, 423);
            this.Btn_Delete.Name = "Btn_Delete";
            this.Btn_Delete.Size = new System.Drawing.Size(120, 31);
            this.Btn_Delete.TabIndex = 11;
            this.Btn_Delete.TabStop = false;
            this.Btn_Delete.Text = "読取削除";
            this.Btn_Delete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Delete.UseVisualStyleBackColor = true;
            this.Btn_Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Result
            // 
            this.Result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Result.AutoSize = true;
            this.Result.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Result.Location = new System.Drawing.Point(10, 177);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(90, 24);
            this.Result.TabIndex = 13;
            this.Result.Text = "梱包データ";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.txtDeliverySlipControlNo, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(39, 103);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(169, 61);
            this.tableLayoutPanel2.TabIndex = 22;
            this.tableLayoutPanel2.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanel1_CellPaint);
            // 
            // txtDeliverySlipControlNo
            // 
            this.txtDeliverySlipControlNo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeliverySlipControlNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeliverySlipControlNo.Font = new System.Drawing.Font("メイリオ", 9.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtDeliverySlipControlNo.Location = new System.Drawing.Point(4, 31);
            this.txtDeliverySlipControlNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.txtDeliverySlipControlNo.MaxLength = 14;
            this.txtDeliverySlipControlNo.Name = "txtDeliverySlipControlNo";
            this.txtDeliverySlipControlNo.Size = new System.Drawing.Size(161, 27);
            this.txtDeliverySlipControlNo.TabIndex = 28;
            this.txtDeliverySlipControlNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDeliverySlipControlNo_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.LightGray;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label6.Location = new System.Drawing.Point(4, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 27);
            this.label6.TabIndex = 25;
            this.label6.Text = "配送伝票管理番号";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label6.UseCompatibleTextRendering = true;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(39, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 24);
            this.label8.TabIndex = 25;
            this.label8.Text = "読込";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 7;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.Controls.Add(this.lblDeliverySlipControlNo, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblShippingDataID, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblRegistUser, 5, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblRegistDate, 6, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblReadControlLabel, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblContactNo, 4, 1);
            this.tableLayoutPanel3.Controls.Add(this.label16, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.label15, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.label14, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.label13, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.label9, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label10, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblReadDeliverySlipControlNo, 2, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(9, 206);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.27273F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.72727F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(875, 56);
            this.tableLayoutPanel3.TabIndex = 26;
            this.tableLayoutPanel3.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanel1_CellPaint);
            // 
            // lblDeliverySlipControlNo
            // 
            this.lblDeliverySlipControlNo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDeliverySlipControlNo.AutoSize = true;
            this.lblDeliverySlipControlNo.BackColor = System.Drawing.SystemColors.Window;
            this.lblDeliverySlipControlNo.Font = new System.Drawing.Font("メイリオ", 9.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDeliverySlipControlNo.Location = new System.Drawing.Point(65, 27);
            this.lblDeliverySlipControlNo.Name = "lblDeliverySlipControlNo";
            this.lblDeliverySlipControlNo.Size = new System.Drawing.Size(132, 28);
            this.lblDeliverySlipControlNo.TabIndex = 28;
            this.lblDeliverySlipControlNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblShippingDataID
            // 
            this.lblShippingDataID.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShippingDataID.AutoSize = true;
            this.lblShippingDataID.BackColor = System.Drawing.SystemColors.Window;
            this.lblShippingDataID.Font = new System.Drawing.Font("メイリオ", 9.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblShippingDataID.Location = new System.Drawing.Point(4, 27);
            this.lblShippingDataID.Name = "lblShippingDataID";
            this.lblShippingDataID.Size = new System.Drawing.Size(54, 28);
            this.lblShippingDataID.TabIndex = 27;
            this.lblShippingDataID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRegistUser
            // 
            this.lblRegistUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRegistUser.AutoSize = true;
            this.lblRegistUser.BackColor = System.Drawing.SystemColors.Window;
            this.lblRegistUser.Font = new System.Drawing.Font("メイリオ", 9.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblRegistUser.Location = new System.Drawing.Point(673, 27);
            this.lblRegistUser.Name = "lblRegistUser";
            this.lblRegistUser.Size = new System.Drawing.Size(106, 28);
            this.lblRegistUser.TabIndex = 32;
            this.lblRegistUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRegistDate
            // 
            this.lblRegistDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRegistDate.AutoSize = true;
            this.lblRegistDate.BackColor = System.Drawing.SystemColors.Window;
            this.lblRegistDate.Font = new System.Drawing.Font("メイリオ", 9.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblRegistDate.Location = new System.Drawing.Point(786, 27);
            this.lblRegistDate.Name = "lblRegistDate";
            this.lblRegistDate.Size = new System.Drawing.Size(85, 28);
            this.lblRegistDate.TabIndex = 33;
            this.lblRegistDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReadControlLabel
            // 
            this.lblReadControlLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReadControlLabel.AutoSize = true;
            this.lblReadControlLabel.BackColor = System.Drawing.SystemColors.Window;
            this.lblReadControlLabel.Font = new System.Drawing.Font("メイリオ", 9.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblReadControlLabel.Location = new System.Drawing.Point(343, 27);
            this.lblReadControlLabel.Name = "lblReadControlLabel";
            this.lblReadControlLabel.Size = new System.Drawing.Size(184, 28);
            this.lblReadControlLabel.TabIndex = 29;
            this.lblReadControlLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblContactNo
            // 
            this.lblContactNo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContactNo.AutoSize = true;
            this.lblContactNo.BackColor = System.Drawing.SystemColors.Window;
            this.lblContactNo.Font = new System.Drawing.Font("メイリオ", 9.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblContactNo.Location = new System.Drawing.Point(534, 27);
            this.lblContactNo.Name = "lblContactNo";
            this.lblContactNo.Size = new System.Drawing.Size(132, 28);
            this.lblContactNo.TabIndex = 31;
            this.lblContactNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.LightGray;
            this.label16.Font = new System.Drawing.Font("メイリオ", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(786, 1);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(85, 25);
            this.label16.TabIndex = 32;
            this.label16.Text = "梱包日時";
            this.label16.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.LightGray;
            this.label15.Font = new System.Drawing.Font("メイリオ", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(673, 1);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(106, 25);
            this.label15.TabIndex = 31;
            this.label15.Text = "梱包担当者名";
            this.label15.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.LightGray;
            this.label14.Font = new System.Drawing.Font("メイリオ", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(534, 1);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(132, 25);
            this.label14.TabIndex = 30;
            this.label14.Text = "お問合せ番号";
            this.label14.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.LightGray;
            this.label13.Font = new System.Drawing.Font("メイリオ", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(343, 1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(184, 25);
            this.label13.TabIndex = 29;
            this.label13.Text = "読込管理ラベル";
            this.label13.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.LightGray;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("メイリオ", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(65, 1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 25);
            this.label9.TabIndex = 25;
            this.label9.Text = "配送伝票";
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.LightGray;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("メイリオ", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(4, 1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 25);
            this.label11.TabIndex = 0;
            this.label11.Text = "ID";
            this.label11.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.LightGray;
            this.label10.Font = new System.Drawing.Font("メイリオ", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.Location = new System.Drawing.Point(204, 1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 25);
            this.label10.TabIndex = 24;
            this.label10.Text = "読取配送伝票";
            this.label10.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblReadDeliverySlipControlNo
            // 
            this.lblReadDeliverySlipControlNo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReadDeliverySlipControlNo.AutoSize = true;
            this.lblReadDeliverySlipControlNo.BackColor = System.Drawing.SystemColors.Window;
            this.lblReadDeliverySlipControlNo.Font = new System.Drawing.Font("メイリオ", 9.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblReadDeliverySlipControlNo.Location = new System.Drawing.Point(204, 27);
            this.lblReadDeliverySlipControlNo.Name = "lblReadDeliverySlipControlNo";
            this.lblReadDeliverySlipControlNo.Size = new System.Drawing.Size(132, 28);
            this.lblReadDeliverySlipControlNo.TabIndex = 30;
            this.lblReadDeliverySlipControlNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTitle
            // 
            this.panelTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTitle.Controls.Add(this.header0);
            this.panelTitle.Controls.Add(this.header1);
            this.panelTitle.Location = new System.Drawing.Point(3, 2);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(884, 100);
            this.panelTitle.TabIndex = 42;
            // 
            // header0
            // 
            this.header0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.header0.AutoSize = true;
            this.header0.BackColor = System.Drawing.Color.Transparent;
            this.header0.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.header0.ForeColor = System.Drawing.Color.Black;
            this.header0.Location = new System.Drawing.Point(312, 15);
            this.header0.Name = "header0";
            this.header0.Size = new System.Drawing.Size(258, 36);
            this.header0.TabIndex = 0;
            this.header0.Text = "MS　私物返却管理DB";
            // 
            // header1
            // 
            this.header1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.header1.AutoSize = true;
            this.header1.BackColor = System.Drawing.Color.Transparent;
            this.header1.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.header1.ForeColor = System.Drawing.Color.Black;
            this.header1.Location = new System.Drawing.Point(358, 54);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(159, 36);
            this.header1.TabIndex = 0;
            this.header1.Text = "梱包訂正処理";
            // 
            // StaffName
            // 
            this.StaffName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StaffName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StaffName.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.StaffName.ForeColor = System.Drawing.Color.Black;
            this.StaffName.Location = new System.Drawing.Point(579, 10);
            this.StaffName.Name = "StaffName";
            this.StaffName.Size = new System.Drawing.Size(92, 31);
            this.StaffName.TabIndex = 46;
            this.StaffName.Text = "担当者名";
            this.StaffName.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtStaffName
            // 
            this.txtStaffName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStaffName.BackColor = System.Drawing.SystemColors.Window;
            this.txtStaffName.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtStaffName.ForeColor = System.Drawing.Color.Black;
            this.txtStaffName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtStaffName.Location = new System.Drawing.Point(678, 10);
            this.txtStaffName.MaxLength = 10;
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.ReadOnly = true;
            this.txtStaffName.Size = new System.Drawing.Size(202, 31);
            this.txtStaffName.TabIndex = 45;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.StaffName);
            this.panel1.Controls.Add(this.txtStaffName);
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.Result);
            this.panel1.Location = new System.Drawing.Point(0, 108);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(892, 280);
            this.panel1.TabIndex = 47;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblShippingDate, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(39, 111);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.72727F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.27273F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(131, 56);
            this.tableLayoutPanel1.TabIndex = 47;
            this.tableLayoutPanel1.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanel1_CellPaint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightGray;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(4, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 27);
            this.label2.TabIndex = 0;
            this.label2.Text = "出荷日";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblShippingDate
            // 
            this.lblShippingDate.BackColor = System.Drawing.SystemColors.Window;
            this.lblShippingDate.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblShippingDate.Location = new System.Drawing.Point(4, 29);
            this.lblShippingDate.Name = "lblShippingDate";
            this.lblShippingDate.Size = new System.Drawing.Size(123, 26);
            this.lblShippingDate.TabIndex = 41;
            this.lblShippingDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMSPB303
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 495);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.Btn_Delete);
            this.Controls.Add(this.Btn_Cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmMSPB303";
            this.Text = "MS 私物返却管理DB 梱包訂正処理";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Button Btn_Delete;
        private System.Windows.Forms.Label Result;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDeliverySlipControlNo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblShippingDataID;
        private System.Windows.Forms.Label lblDeliverySlipControlNo;
        private System.Windows.Forms.Label lblReadControlLabel;
        private System.Windows.Forms.Label lblReadDeliverySlipControlNo;
        private System.Windows.Forms.Label lblContactNo;
        private System.Windows.Forms.Label lblRegistUser;
        private System.Windows.Forms.Label lblRegistDate;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label header0;
        private System.Windows.Forms.Label header1;
        private System.Windows.Forms.Label StaffName;
        private System.Windows.Forms.TextBox txtStaffName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblShippingDate;
    }
}