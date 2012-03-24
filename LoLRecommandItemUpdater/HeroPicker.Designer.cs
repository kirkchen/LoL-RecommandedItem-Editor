namespace LoLRecommandItemUpdater
{
    partial class HeroPicker
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.LabelHeroName = new System.Windows.Forms.Label();
            this.ComboBoxHeroName = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FlowLayoutPanelHero = new System.Windows.Forms.FlowLayoutPanel();
            this.ButtonConfirm = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ButtonConfirm, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.ButtonCancel, 3, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(632, 533);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 5);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.LabelHeroName, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ComboBoxHeroName, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(626, 24);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // LabelHeroName
            // 
            this.LabelHeroName.AutoSize = true;
            this.LabelHeroName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelHeroName.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LabelHeroName.Location = new System.Drawing.Point(3, 0);
            this.LabelHeroName.Name = "LabelHeroName";
            this.LabelHeroName.Size = new System.Drawing.Size(124, 24);
            this.LabelHeroName.TabIndex = 0;
            this.LabelHeroName.Text = "英雄名稱:";
            this.LabelHeroName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ComboBoxHeroName
            // 
            this.ComboBoxHeroName.Dock = System.Windows.Forms.DockStyle.Left;
            this.ComboBoxHeroName.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ComboBoxHeroName.FormattingEnabled = true;
            this.ComboBoxHeroName.Location = new System.Drawing.Point(133, 3);
            this.ComboBoxHeroName.Name = "ComboBoxHeroName";
            this.ComboBoxHeroName.Size = new System.Drawing.Size(304, 20);
            this.ComboBoxHeroName.TabIndex = 1;
            this.ComboBoxHeroName.SelectedIndexChanged += new System.EventHandler(this.ComboBoxHeroName_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 5);
            this.groupBox1.Controls.Add(this.FlowLayoutPanelHero);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(626, 447);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "請選擇英雄";
            // 
            // FlowLayoutPanelHero
            // 
            this.FlowLayoutPanelHero.AutoScroll = true;
            this.FlowLayoutPanelHero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowLayoutPanelHero.Location = new System.Drawing.Point(3, 18);
            this.FlowLayoutPanelHero.Name = "FlowLayoutPanelHero";
            this.FlowLayoutPanelHero.Size = new System.Drawing.Size(620, 426);
            this.FlowLayoutPanelHero.TabIndex = 0;
            // 
            // ButtonConfirm
            // 
            this.ButtonConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonConfirm.Location = new System.Drawing.Point(175, 496);
            this.ButtonConfirm.Name = "ButtonConfirm";
            this.ButtonConfirm.Size = new System.Drawing.Size(94, 24);
            this.ButtonConfirm.TabIndex = 2;
            this.ButtonConfirm.Text = "確定";
            this.ButtonConfirm.UseVisualStyleBackColor = true;
            this.ButtonConfirm.Click += new System.EventHandler(this.ButtonConfirm_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonCancel.Location = new System.Drawing.Point(361, 496);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(94, 24);
            this.ButtonCancel.TabIndex = 3;
            this.ButtonCancel.Text = "取消";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // HeroPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 533);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "HeroPicker";
            this.Text = "選擇英雄";
            this.Load += new System.EventHandler(this.HeroPicker_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label LabelHeroName;
        private System.Windows.Forms.ComboBox ComboBoxHeroName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ButtonConfirm;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanelHero;
    }
}