namespace SitemapGenerator
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.numUrlsPerSitemap = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.numUrlsPerSitemap)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(71, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Url:";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(126, 34);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(342, 20);
            this.txtUrl.TabIndex = 1;
            // 
            // numUrlsPerSitemap
            // 
            this.numUrlsPerSitemap.Location = new System.Drawing.Point(281, 78);
            this.numUrlsPerSitemap.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.numUrlsPerSitemap.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUrlsPerSitemap.Name = "numUrlsPerSitemap";
            this.numUrlsPerSitemap.Size = new System.Drawing.Size(187, 20);
            this.numUrlsPerSitemap.TabIndex = 2;
            this.numUrlsPerSitemap.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(71, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "URLs Per Sitemap:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGenerate.Location = new System.Drawing.Point(190, 114);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(139, 49);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate Sitemaps";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // listBox
            // 
            this.listBox.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.listBox.ForeColor = System.Drawing.Color.ForestGreen;
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(-4, 177);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(552, 290);
            this.listBox.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(547, 471);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numUrlsPerSitemap);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SitemapGenerator";
            ((System.ComponentModel.ISupportInitialize)(this.numUrlsPerSitemap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.NumericUpDown numUrlsPerSitemap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ListBox listBox;
    }
}

