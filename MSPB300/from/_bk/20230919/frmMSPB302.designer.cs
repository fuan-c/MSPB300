namespace MSPB300.form
{
    partial class frmMSPB302
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Btn_Register = new System.Windows.Forms.Button();
            this.Result = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.header0 = new System.Windows.Forms.Label();
            this.header1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblShippingDate = new System.Windows.Forms.Label();
            this.StaffName = new System.Windows.Forms.Label();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.Label_Finish_Record_Num = new System.Windows.Forms.Label();
            this.CMT_Shipping = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView_Packing_Line = new System.Windows.Forms.DataGridView();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colControlLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Packing_Line)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Btn_Cancel.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Btn_Cancel.Location = new System.Drawing.Point(93, 573);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(120, 29);
            this.Btn_Cancel.TabIndex = 10;
            this.Btn_Cancel.Text = "戻る";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Btn_Register
            // 
            this.Btn_Register.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Btn_Register.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Btn_Register.ForeColor = System.Drawing.Color.Black;
            this.Btn_Register.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Register.Location = new System.Drawing.Point(506, 573);
            this.Btn_Register.Name = "Btn_Register";
            this.Btn_Register.Size = new System.Drawing.Size(120, 29);
            this.Btn_Register.TabIndex = 11;
            this.Btn_Register.Text = "一梱包完了";
            this.Btn_Register.UseVisualStyleBackColor = true;
            this.Btn_Register.Click += new System.EventHandler(this.Register_Click);
            // 
            // Result
            // 
            this.Result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Result.AutoSize = true;
            this.Result.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Result.Location = new System.Drawing.Point(25, 186);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(74, 24);
            this.Result.TabIndex = 13;
            this.Result.Text = "梱包一覧";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.txtContactNo, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(25, 116);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(209, 61);
            this.tableLayoutPanel2.TabIndex = 22;
            this.tableLayoutPanel2.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanel1_CellPaint);
            // 
            // txtContactNo
            // 
            this.txtContactNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContactNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContactNo.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtContactNo.Location = new System.Drawing.Point(4, 32);
            this.txtContactNo.MaxLength = 256;
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(201, 25);
            this.txtContactNo.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.LightGray;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(4, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 27);
            this.label6.TabIndex = 25;
            this.label6.Text = "お問合せ番号";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label6.UseCompatibleTextRendering = true;
            // 
            // panelTitle
            // 
            this.panelTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTitle.Controls.Add(this.header0);
            this.panelTitle.Controls.Add(this.header1);
            this.panelTitle.Location = new System.Drawing.Point(3, 2);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(738, 100);
            this.panelTitle.TabIndex = 41;
            // 
            // header0
            // 
            this.header0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.header0.AutoSize = true;
            this.header0.BackColor = System.Drawing.Color.Transparent;
            this.header0.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.header0.ForeColor = System.Drawing.Color.Black;
            this.header0.Location = new System.Drawing.Point(239, 15);
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
            this.header1.Location = new System.Drawing.Point(268, 54);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(197, 36);
            this.header1.TabIndex = 0;
            this.header1.Text = "MS返却梱包処理";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblShippingDate, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(23, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.72727F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.27273F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(131, 56);
            this.tableLayoutPanel1.TabIndex = 42;
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
            this.lblShippingDate.Location = new System.Drawing.Point(4, 29);
            this.lblShippingDate.Name = "lblShippingDate";
            this.lblShippingDate.Size = new System.Drawing.Size(123, 26);
            this.lblShippingDate.TabIndex = 41;
            this.lblShippingDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StaffName
            // 
            this.StaffName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StaffName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StaffName.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.StaffName.ForeColor = System.Drawing.Color.Black;
            this.StaffName.Location = new System.Drawing.Point(382, 8);
            this.StaffName.Name = "StaffName";
            this.StaffName.Size = new System.Drawing.Size(92, 31);
            this.StaffName.TabIndex = 44;
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
            this.txtStaffName.Location = new System.Drawing.Point(481, 8);
            this.txtStaffName.MaxLength = 10;
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.ReadOnly = true;
            this.txtStaffName.Size = new System.Drawing.Size(202, 31);
            this.txtStaffName.TabIndex = 43;
            // 
            // Label_Finish_Record_Num
            // 
            this.Label_Finish_Record_Num.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Finish_Record_Num.AutoSize = true;
            this.Label_Finish_Record_Num.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label_Finish_Record_Num.Font = new System.Drawing.Font("メイリオ", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label_Finish_Record_Num.Location = new System.Drawing.Point(388, 49);
            this.Label_Finish_Record_Num.Name = "Label_Finish_Record_Num";
            this.Label_Finish_Record_Num.Size = new System.Drawing.Size(109, 30);
            this.Label_Finish_Record_Num.TabIndex = 46;
            this.Label_Finish_Record_Num.Text = "xxx / xxx";
            // 
            // CMT_Shipping
            // 
            this.CMT_Shipping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CMT_Shipping.AutoSize = true;
            this.CMT_Shipping.Font = new System.Drawing.Font("メイリオ", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CMT_Shipping.Location = new System.Drawing.Point(294, 51);
            this.CMT_Shipping.Name = "CMT_Shipping";
            this.CMT_Shipping.Size = new System.Drawing.Size(88, 28);
            this.CMT_Shipping.TabIndex = 45;
            this.CMT_Shipping.Text = "完了件数";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.textBox1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(370, 116);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(209, 61);
            this.tableLayoutPanel3.TabIndex = 47;
            this.tableLayoutPanel3.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanel1_CellPaint);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.Location = new System.Drawing.Point(4, 32);
            this.textBox1.MaxLength = 256;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(201, 25);
            this.textBox1.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 27);
            this.label1.TabIndex = 25;
            this.label1.Text = "管理ラベル";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.UseCompatibleTextRendering = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(366, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 24);
            this.label4.TabIndex = 48;
            this.label4.Text = "管理ラベル読込";
            // 
            // dataGridView_Packing_Line
            // 
            this.dataGridView_Packing_Line.AllowUserToAddRows = false;
            this.dataGridView_Packing_Line.AllowUserToResizeColumns = false;
            this.dataGridView_Packing_Line.AllowUserToResizeRows = false;
            this.dataGridView_Packing_Line.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView_Packing_Line.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Packing_Line.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_Packing_Line.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_Packing_Line.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.colControlLabel});
            this.dataGridView_Packing_Line.EnableHeadersVisualStyles = false;
            this.dataGridView_Packing_Line.Location = new System.Drawing.Point(25, 208);
            this.dataGridView_Packing_Line.Name = "dataGridView_Packing_Line";
            this.dataGridView_Packing_Line.ReadOnly = true;
            this.dataGridView_Packing_Line.RowHeadersVisible = false;
            this.dataGridView_Packing_Line.RowTemplate.Height = 21;
            this.dataGridView_Packing_Line.Size = new System.Drawing.Size(300, 238);
            this.dataGridView_Packing_Line.TabIndex = 49;
            // 
            // colNo
            // 
            this.colNo.HeaderText = "NO";
            this.colNo.MinimumWidth = 40;
            this.colNo.Name = "colNo";
            this.colNo.ReadOnly = true;
            // 
            // colControlLabel
            // 
            this.colControlLabel.HeaderText = "管理ラベル";
            this.colControlLabel.MinimumWidth = 240;
            this.colControlLabel.Name = "colControlLabel";
            this.colControlLabel.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView_Packing_Line);
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Label_Finish_Record_Num);
            this.panel1.Controls.Add(this.CMT_Shipping);
            this.panel1.Controls.Add(this.StaffName);
            this.panel1.Controls.Add(this.txtStaffName);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.Result);
            this.panel1.Location = new System.Drawing.Point(25, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(692, 454);
            this.panel1.TabIndex = 50;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(25, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 24);
            this.label8.TabIndex = 25;
            this.label8.Text = "お問合せ番号読込";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMSPB302
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 617);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.Btn_Register);
            this.Controls.Add(this.Btn_Cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmMSPB302";
            this.Text = "MS 私物返却管理DB MS返却梱包処理";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Packing_Line)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Button Btn_Register;
        private System.Windows.Forms.Label Result;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label header0;
        private System.Windows.Forms.Label header1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblShippingDate;
        private System.Windows.Forms.Label StaffName;
        private System.Windows.Forms.TextBox txtStaffName;
        private System.Windows.Forms.Label Label_Finish_Record_Num;
        private System.Windows.Forms.Label CMT_Shipping;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView_Packing_Line;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colControlLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
    }
}