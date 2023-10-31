namespace MSPB301.form
{
    partial class frmMSPB301
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Btn_Register = new System.Windows.Forms.Button();
            this.CMT_Shipping = new System.Windows.Forms.Label();
            this.Result = new System.Windows.Forms.Label();
            this.StaffName = new System.Windows.Forms.Label();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblShippingDate = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtControlLabel = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDeliverySlipControlNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.Label_Finish_Record_Num = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Btn_ReLoad = new System.Windows.Forms.Button();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.header0 = new System.Windows.Forms.Label();
            this.header1 = new System.Windows.Forms.Label();
            this.dataGridView_Packing_Target = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Packing_Target)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Btn_Cancel.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Btn_Cancel.Location = new System.Drawing.Point(32, 617);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(110, 29);
            this.Btn_Cancel.TabIndex = 3;
            this.Btn_Cancel.Text = "戻る";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // Btn_Register
            // 
            this.Btn_Register.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Btn_Register.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Btn_Register.ForeColor = System.Drawing.Color.Black;
            this.Btn_Register.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Register.Location = new System.Drawing.Point(751, 617);
            this.Btn_Register.Name = "Btn_Register";
            this.Btn_Register.Size = new System.Drawing.Size(110, 29);
            this.Btn_Register.TabIndex = 4;
            this.Btn_Register.Text = "完了";
            this.Btn_Register.UseVisualStyleBackColor = true;
            this.Btn_Register.Click += new System.EventHandler(this.Btn_Regist_Click);
            // 
            // CMT_Shipping
            // 
            this.CMT_Shipping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CMT_Shipping.AutoSize = true;
            this.CMT_Shipping.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CMT_Shipping.Location = new System.Drawing.Point(585, 206);
            this.CMT_Shipping.Name = "CMT_Shipping";
            this.CMT_Shipping.Size = new System.Drawing.Size(74, 24);
            this.CMT_Shipping.TabIndex = 14;
            this.CMT_Shipping.Text = "完了件数";
            // 
            // Result
            // 
            this.Result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Result.AutoSize = true;
            this.Result.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Result.Location = new System.Drawing.Point(25, 211);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(106, 24);
            this.Result.TabIndex = 13;
            this.Result.Text = "梱包対象一覧";
            // 
            // StaffName
            // 
            this.StaffName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StaffName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StaffName.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.StaffName.ForeColor = System.Drawing.Color.Black;
            this.StaffName.Location = new System.Drawing.Point(517, 15);
            this.StaffName.Name = "StaffName";
            this.StaffName.Size = new System.Drawing.Size(92, 31);
            this.StaffName.TabIndex = 19;
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
            this.txtStaffName.Location = new System.Drawing.Point(620, 15);
            this.txtStaffName.MaxLength = 10;
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.ReadOnly = true;
            this.txtStaffName.Size = new System.Drawing.Size(202, 31);
            this.txtStaffName.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblShippingDate, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.72727F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.27273F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(131, 56);
            this.tableLayoutPanel1.TabIndex = 21;
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
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblShippingDate
            // 
            this.lblShippingDate.BackColor = System.Drawing.SystemColors.Window;
            this.lblShippingDate.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblShippingDate.ForeColor = System.Drawing.Color.Black;
            this.lblShippingDate.Location = new System.Drawing.Point(4, 29);
            this.lblShippingDate.Name = "lblShippingDate";
            this.lblShippingDate.Size = new System.Drawing.Size(123, 26);
            this.lblShippingDate.TabIndex = 41;
            this.lblShippingDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel2.Controls.Add(this.txtControlLabel, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label10, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtDeliverySlipControlNo, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtContactNo, 2, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 111);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(671, 61);
            this.tableLayoutPanel2.TabIndex = 22;
            this.tableLayoutPanel2.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanel1_CellPaint);
            // 
            // txtControlLabel
            // 
            this.txtControlLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtControlLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtControlLabel.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtControlLabel.Location = new System.Drawing.Point(227, 32);
            this.txtControlLabel.MaxLength = 21;
            this.txtControlLabel.Name = "txtControlLabel";
            this.txtControlLabel.Size = new System.Drawing.Size(216, 25);
            this.txtControlLabel.TabIndex = 1;
            this.txtControlLabel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtControlLabel_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.LightGray;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.Location = new System.Drawing.Point(227, 1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(216, 27);
            this.label10.TabIndex = 31;
            this.label10.Text = "管理ラベル";
            this.label10.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label10.UseCompatibleTextRendering = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.LightGray;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(4, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(216, 27);
            this.label5.TabIndex = 25;
            this.label5.Text = "配送伝票管理番号";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtDeliverySlipControlNo
            // 
            this.txtDeliverySlipControlNo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeliverySlipControlNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeliverySlipControlNo.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtDeliverySlipControlNo.Location = new System.Drawing.Point(4, 32);
            this.txtDeliverySlipControlNo.MaxLength = 14;
            this.txtDeliverySlipControlNo.Name = "txtDeliverySlipControlNo";
            this.txtDeliverySlipControlNo.Size = new System.Drawing.Size(216, 25);
            this.txtDeliverySlipControlNo.TabIndex = 0;
            this.txtDeliverySlipControlNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDeliverySlipControlNo_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.LightGray;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(450, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(217, 27);
            this.label6.TabIndex = 25;
            this.label6.Text = "お問合せ番号";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label6.UseCompatibleTextRendering = true;
            // 
            // txtContactNo
            // 
            this.txtContactNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContactNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContactNo.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtContactNo.Location = new System.Drawing.Point(450, 32);
            this.txtContactNo.MaxLength = 14;
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(217, 25);
            this.txtContactNo.TabIndex = 2;
            this.txtContactNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContactNo_KeyDown);
            // 
            // Label_Finish_Record_Num
            // 
            this.Label_Finish_Record_Num.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Finish_Record_Num.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label_Finish_Record_Num.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label_Finish_Record_Num.Location = new System.Drawing.Point(675, 204);
            this.Label_Finish_Record_Num.Name = "Label_Finish_Record_Num";
            this.Label_Finish_Record_Num.Size = new System.Drawing.Size(112, 26);
            this.Label_Finish_Record_Num.TabIndex = 24;
            this.Label_Finish_Record_Num.Text = "xxx / xxx";
            this.Label_Finish_Record_Num.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(12, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 24);
            this.label8.TabIndex = 25;
            this.label8.Text = "読込";
            // 
            // Btn_ReLoad
            // 
            this.Btn_ReLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_ReLoad.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Btn_ReLoad.Location = new System.Drawing.Point(739, 143);
            this.Btn_ReLoad.Name = "Btn_ReLoad";
            this.Btn_ReLoad.Size = new System.Drawing.Size(110, 29);
            this.Btn_ReLoad.TabIndex = 2;
            this.Btn_ReLoad.TabStop = false;
            this.Btn_ReLoad.Text = "再読込";
            this.Btn_ReLoad.UseVisualStyleBackColor = true;
            this.Btn_ReLoad.Click += new System.EventHandler(this.Btn_ReLoad_Click);
            // 
            // panelTitle
            // 
            this.panelTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTitle.Controls.Add(this.header0);
            this.panelTitle.Controls.Add(this.header1);
            this.panelTitle.Location = new System.Drawing.Point(6, 3);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(884, 100);
            this.panelTitle.TabIndex = 40;
            // 
            // header0
            // 
            this.header0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.header0.AutoSize = true;
            this.header0.BackColor = System.Drawing.Color.Transparent;
            this.header0.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.header0.ForeColor = System.Drawing.Color.Black;
            this.header0.Location = new System.Drawing.Point(305, 15);
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
            this.header1.Location = new System.Drawing.Point(317, 54);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(231, 36);
            this.header1.TabIndex = 0;
            this.header1.Text = "契約者返却梱包処理";
            // 
            // dataGridView_Packing_Target
            // 
            this.dataGridView_Packing_Target.AllowUserToAddRows = false;
            this.dataGridView_Packing_Target.AllowUserToResizeColumns = false;
            this.dataGridView_Packing_Target.AllowUserToResizeRows = false;
            this.dataGridView_Packing_Target.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView_Packing_Target.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Packing_Target.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Packing_Target.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_Packing_Target.EnableHeadersVisualStyles = false;
            this.dataGridView_Packing_Target.Location = new System.Drawing.Point(13, 236);
            this.dataGridView_Packing_Target.Name = "dataGridView_Packing_Target";
            this.dataGridView_Packing_Target.ReadOnly = true;
            this.dataGridView_Packing_Target.RowHeadersVisible = false;
            this.dataGridView_Packing_Target.RowTemplate.Height = 21;
            this.dataGridView_Packing_Target.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_Packing_Target.Size = new System.Drawing.Size(847, 238);
            this.dataGridView_Packing_Target.TabIndex = 41;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView_Packing_Target);
            this.panel1.Controls.Add(this.Btn_ReLoad);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.Label_Finish_Record_Num);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.StaffName);
            this.panel1.Controls.Add(this.txtStaffName);
            this.panel1.Controls.Add(this.CMT_Shipping);
            this.panel1.Controls.Add(this.Result);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(12, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(873, 498);
            this.panel1.TabIndex = 42;
            // 
            // frmMSPB301
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(896, 678);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.Btn_Register);
            this.Controls.Add(this.Btn_Cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmMSPB301";
            this.Text = "MS 私物返却管理DB 契約者返却梱包処理";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Packing_Target)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Button Btn_Register;
        private System.Windows.Forms.Label CMT_Shipping;
        private System.Windows.Forms.Label Result;
        private System.Windows.Forms.Label StaffName;
        private System.Windows.Forms.TextBox txtStaffName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;        
        private System.Windows.Forms.Label Label_Finish_Record_Num;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDeliverySlipControlNo;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.Button Btn_ReLoad;
        private System.Windows.Forms.TextBox txtControlLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label header0;
        private System.Windows.Forms.Label header1;
        private System.Windows.Forms.Label lblShippingDate;
        private System.Windows.Forms.DataGridView dataGridView_Packing_Target;
        private System.Windows.Forms.Panel panel1;
    }
}