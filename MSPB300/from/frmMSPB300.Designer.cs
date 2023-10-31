namespace MSPB300.form
{
    partial class frmMSPB300
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label_Header = new System.Windows.Forms.Label();
            this.End = new System.Windows.Forms.Button();
            this.Packing_Processing = new System.Windows.Forms.Button();
            this.Shipping_Correct_Processing = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Combobox_Shipping_Date = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.header0 = new System.Windows.Forms.Label();
            this.header1 = new System.Windows.Forms.Label();
            this.dataGridView_Packing_Line = new System.Windows.Forms.DataGridView();
            this.StaffName = new System.Windows.Forms.Label();
            this.textBox_StaffName = new System.Windows.Forms.TextBox();
            this.Display_Line = new System.Windows.Forms.Button();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Packing_Line)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Header
            // 
            this.label_Header.Location = new System.Drawing.Point(0, 0);
            this.label_Header.Name = "label_Header";
            this.label_Header.Size = new System.Drawing.Size(100, 23);
            this.label_Header.TabIndex = 38;
            // 
            // End
            // 
            this.End.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.End.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.End.ForeColor = System.Drawing.Color.Black;
            this.End.Location = new System.Drawing.Point(472, 533);
            this.End.Name = "End";
            this.End.Size = new System.Drawing.Size(160, 33);
            this.End.TabIndex = 14;
            this.End.Text = "終了";
            this.End.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.End.UseVisualStyleBackColor = true;
            this.End.Click += new System.EventHandler(this.End_Click);
            // 
            // Packing_Processing
            // 
            this.Packing_Processing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Packing_Processing.Enabled = false;
            this.Packing_Processing.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Packing_Processing.ForeColor = System.Drawing.Color.Black;
            this.Packing_Processing.Location = new System.Drawing.Point(472, 483);
            this.Packing_Processing.Name = "Packing_Processing";
            this.Packing_Processing.Size = new System.Drawing.Size(160, 33);
            this.Packing_Processing.TabIndex = 13;
            this.Packing_Processing.Text = "梱包処理";
            this.Packing_Processing.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Packing_Processing.UseVisualStyleBackColor = true;
            this.Packing_Processing.Click += new System.EventHandler(this.Packing_Processing_Click);
            // 
            // Shipping_Correct_Processing
            // 
            this.Shipping_Correct_Processing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Shipping_Correct_Processing.Enabled = false;
            this.Shipping_Correct_Processing.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Shipping_Correct_Processing.ForeColor = System.Drawing.Color.Black;
            this.Shipping_Correct_Processing.Location = new System.Drawing.Point(42, 533);
            this.Shipping_Correct_Processing.Name = "Shipping_Correct_Processing";
            this.Shipping_Correct_Processing.Size = new System.Drawing.Size(160, 33);
            this.Shipping_Correct_Processing.TabIndex = 24;
            this.Shipping_Correct_Processing.Text = "梱包訂正処理";
            this.Shipping_Correct_Processing.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Shipping_Correct_Processing.UseVisualStyleBackColor = true;
            this.Shipping_Correct_Processing.Click += new System.EventHandler(this.Shipping_Correct_Processing_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(39, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 24);
            this.label1.TabIndex = 18;
            this.label1.Text = "ライン一覧";
            // 
            // Combobox_Shipping_Date
            // 
            this.Combobox_Shipping_Date.Enabled = false;
            this.Combobox_Shipping_Date.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Combobox_Shipping_Date.FormattingEnabled = true;
            this.Combobox_Shipping_Date.Location = new System.Drawing.Point(42, 167);
            this.Combobox_Shipping_Date.Name = "Combobox_Shipping_Date";
            this.Combobox_Shipping_Date.Size = new System.Drawing.Size(122, 32);
            this.Combobox_Shipping_Date.TabIndex = 23;
            this.Combobox_Shipping_Date.SelectedIndexChanged += new System.EventHandler(this.Combobox_Shipping_Date_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(39, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 24);
            this.label2.TabIndex = 22;
            this.label2.Text = "出荷日指定";
            // 
            // panelTitle
            // 
            this.panelTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTitle.Controls.Add(this.header0);
            this.panelTitle.Controls.Add(this.header1);
            this.panelTitle.Location = new System.Drawing.Point(7, 4);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(670, 100);
            this.panelTitle.TabIndex = 39;
            // 
            // header0
            // 
            this.header0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.header0.AutoSize = true;
            this.header0.BackColor = System.Drawing.Color.Transparent;
            this.header0.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.header0.ForeColor = System.Drawing.Color.Black;
            this.header0.Location = new System.Drawing.Point(203, 15);
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
            this.header1.Location = new System.Drawing.Point(272, 54);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(111, 36);
            this.header1.TabIndex = 0;
            this.header1.Text = "梱包処理";
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
            this.dataGridView_Packing_Line.EnableHeadersVisualStyles = false;
            this.dataGridView_Packing_Line.Location = new System.Drawing.Point(42, 237);
            this.dataGridView_Packing_Line.Name = "dataGridView_Packing_Line";
            this.dataGridView_Packing_Line.ReadOnly = true;
            this.dataGridView_Packing_Line.RowHeadersVisible = false;
            this.dataGridView_Packing_Line.RowTemplate.Height = 21;
            this.dataGridView_Packing_Line.Size = new System.Drawing.Size(463, 216);
            this.dataGridView_Packing_Line.TabIndex = 40;
            // 
            // StaffName
            // 
            this.StaffName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StaffName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StaffName.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.StaffName.ForeColor = System.Drawing.Color.Black;
            this.StaffName.Location = new System.Drawing.Point(343, 113);
            this.StaffName.Name = "StaffName";
            this.StaffName.Size = new System.Drawing.Size(129, 31);
            this.StaffName.TabIndex = 42;
            this.StaffName.Text = "担当者名入力";
            this.StaffName.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // textBox_StaffName
            // 
            this.textBox_StaffName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_StaffName.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_StaffName.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_StaffName.ForeColor = System.Drawing.Color.Black;
            this.textBox_StaffName.Location = new System.Drawing.Point(486, 113);
            this.textBox_StaffName.MaxLength = 10;
            this.textBox_StaffName.Name = "textBox_StaffName";
            this.textBox_StaffName.Size = new System.Drawing.Size(173, 31);
            this.textBox_StaffName.TabIndex = 41;
            this.textBox_StaffName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_StaffName_KeyDown);
            // 
            // Display_Line
            // 
            this.Display_Line.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Display_Line.Enabled = false;
            this.Display_Line.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Display_Line.Location = new System.Drawing.Point(245, 167);
            this.Display_Line.Name = "Display_Line";
            this.Display_Line.Size = new System.Drawing.Size(130, 33);
            this.Display_Line.TabIndex = 43;
            this.Display_Line.Text = "ライン表示";
            this.Display_Line.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Display_Line.UseVisualStyleBackColor = true;
            this.Display_Line.Click += new System.EventHandler(this.Display_Line_Click);
            // 
            // frmMSPB300
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(684, 591);
            this.Controls.Add(this.Display_Line);
            this.Controls.Add(this.StaffName);
            this.Controls.Add(this.textBox_StaffName);
            this.Controls.Add(this.dataGridView_Packing_Line);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.label_Header);
            this.Controls.Add(this.Shipping_Correct_Processing);
            this.Controls.Add(this.Combobox_Shipping_Date);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.End);
            this.Controls.Add(this.Packing_Processing);
            this.Name = "frmMSPB300";
            this.Text = "MS 私物返却管理DB 梱包処理";
            this.Load += new System.EventHandler(this.frmMSPB300_Load);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Packing_Line)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_Header;
        private System.Windows.Forms.Button End;
        private System.Windows.Forms.Button Packing_Processing;
        private System.Windows.Forms.Button Shipping_Correct_Processing;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Combobox_Shipping_Date;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label header0;
        private System.Windows.Forms.Label header1;
        private System.Windows.Forms.DataGridView dataGridView_Packing_Line;
        private System.Windows.Forms.Label StaffName;
        private System.Windows.Forms.TextBox textBox_StaffName;
        private System.Windows.Forms.Button Display_Line;
    }
}

