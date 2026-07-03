namespace ContractManagementSystem_CMS_
{
    partial class MainScreen
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            pnlMenu = new Panel();
            btnManageRules = new Button();
            btnExport = new Button();
            dataGridViewResultScreen = new DataGridView();
            MaddeAdı = new DataGridViewTextBoxColumn();
            Durum = new DataGridViewTextBoxColumn();
            pnlRiskStatus = new Panel();
            lblScoreText = new Label();
            btnFileChecking = new Button();
            comboboxContractType = new ComboBox();
            btnFileSelection = new Button();
            richTextBoxViewContract = new RichTextBox();
            pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResultScreen).BeginInit();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.DarkGray;
            pnlMenu.Controls.Add(btnManageRules);
            pnlMenu.Controls.Add(btnExport);
            pnlMenu.Controls.Add(dataGridViewResultScreen);
            pnlMenu.Controls.Add(pnlRiskStatus);
            pnlMenu.Controls.Add(lblScoreText);
            pnlMenu.Controls.Add(btnFileChecking);
            pnlMenu.Controls.Add(comboboxContractType);
            pnlMenu.Controls.Add(btnFileSelection);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(413, 626);
            pnlMenu.TabIndex = 0;
            // 
            // btnManageRules
            // 
            btnManageRules.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnManageRules.BackColor = Color.White;
            btnManageRules.CausesValidation = false;
            btnManageRules.Cursor = Cursors.Hand;
            btnManageRules.FlatAppearance.BorderSize = 0;
            btnManageRules.FlatStyle = FlatStyle.Flat;
            btnManageRules.Font = new Font("Arial", 9F);
            btnManageRules.Location = new Point(12, 583);
            btnManageRules.Name = "btnManageRules";
            btnManageRules.Size = new Size(28, 31);
            btnManageRules.TabIndex = 7;
            btnManageRules.Text = "⚙";
            btnManageRules.UseVisualStyleBackColor = false;
            btnManageRules.Click += btnManageRules_Click;
            // 
            // btnExport
            // 
            btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnExport.BackColor = Color.White;
            btnExport.CausesValidation = false;
            btnExport.Cursor = Cursors.Hand;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Arial", 9F);
            btnExport.Location = new Point(226, 578);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(169, 40);
            btnExport.TabIndex = 6;
            btnExport.Text = "Raporu PDF Olarak Dışa Aktar";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // dataGridViewResultScreen
            // 
            dataGridViewResultScreen.AccessibleRole = AccessibleRole.None;
            dataGridViewResultScreen.AllowDrop = true;
            dataGridViewResultScreen.AllowUserToAddRows = false;
            dataGridViewResultScreen.AllowUserToDeleteRows = false;
            dataGridViewResultScreen.AllowUserToResizeColumns = false;
            dataGridViewResultScreen.AllowUserToResizeRows = false;
            dataGridViewResultScreen.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewResultScreen.BackgroundColor = Color.DarkGray;
            dataGridViewResultScreen.BorderStyle = BorderStyle.None;
            dataGridViewResultScreen.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewResultScreen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewResultScreen.ColumnHeadersHeight = 30;
            dataGridViewResultScreen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewResultScreen.Columns.AddRange(new DataGridViewColumn[] { MaddeAdı, Durum });
            dataGridViewResultScreen.GridColor = SystemColors.ScrollBar;
            dataGridViewResultScreen.Location = new Point(12, 120);
            dataGridViewResultScreen.Name = "dataGridViewResultScreen";
            dataGridViewResultScreen.ReadOnly = true;
            dataGridViewResultScreen.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewResultScreen.RowHeadersVisible = false;
            dataGridViewResultScreen.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewResultScreen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewResultScreen.ShowEditingIcon = false;
            dataGridViewResultScreen.Size = new Size(383, 452);
            dataGridViewResultScreen.StandardTab = true;
            dataGridViewResultScreen.TabIndex = 5;
            // 
            // MaddeAdı
            // 
            MaddeAdı.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            MaddeAdı.HeaderText = "Maddenin Adı";
            MaddeAdı.Name = "MaddeAdı";
            MaddeAdı.ReadOnly = true;
            // 
            // Durum
            // 
            Durum.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Durum.HeaderText = "Maddenin Bulunma Durumu";
            Durum.Name = "Durum";
            Durum.ReadOnly = true;
            Durum.Width = 235;
            // 
            // pnlRiskStatus
            // 
            pnlRiskStatus.Anchor = AnchorStyles.Top;
            pnlRiskStatus.BackColor = Color.DarkGray;
            pnlRiskStatus.ForeColor = Color.White;
            pnlRiskStatus.Location = new Point(30, 65);
            pnlRiskStatus.Name = "pnlRiskStatus";
            pnlRiskStatus.Size = new Size(24, 18);
            pnlRiskStatus.TabIndex = 4;
            // 
            // lblScoreText
            // 
            lblScoreText.Anchor = AnchorStyles.Top;
            lblScoreText.AutoSize = true;
            lblScoreText.BackColor = Color.DarkGray;
            lblScoreText.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblScoreText.ForeColor = Color.Black;
            lblScoreText.Location = new Point(60, 62);
            lblScoreText.Name = "lblScoreText";
            lblScoreText.Size = new Size(110, 21);
            lblScoreText.TabIndex = 3;
            lblScoreText.Text = "Risk Skoru : 0";
            // 
            // btnFileChecking
            // 
            btnFileChecking.Anchor = AnchorStyles.Top;
            btnFileChecking.BackColor = Color.White;
            btnFileChecking.CausesValidation = false;
            btnFileChecking.Cursor = Cursors.Hand;
            btnFileChecking.FlatAppearance.BorderSize = 0;
            btnFileChecking.FlatStyle = FlatStyle.Flat;
            btnFileChecking.Font = new Font("Arial", 9F);
            btnFileChecking.Location = new Point(226, 65);
            btnFileChecking.Name = "btnFileChecking";
            btnFileChecking.Size = new Size(169, 27);
            btnFileChecking.TabIndex = 2;
            btnFileChecking.Text = "Sözleşmeyi Analiz Et";
            btnFileChecking.UseVisualStyleBackColor = false;
            btnFileChecking.Click += btnFileChecking_Click;
            // 
            // comboboxContractType
            // 
            comboboxContractType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboboxContractType.FormattingEnabled = true;
            comboboxContractType.Location = new Point(12, 32);
            comboboxContractType.Name = "comboboxContractType";
            comboboxContractType.Size = new Size(207, 23);
            comboboxContractType.TabIndex = 0;
            comboboxContractType.SelectedIndexChanged += comboboxContractType_SelectedIndexChanged;
            // 
            // btnFileSelection
            // 
            btnFileSelection.Anchor = AnchorStyles.Top;
            btnFileSelection.BackColor = Color.White;
            btnFileSelection.CausesValidation = false;
            btnFileSelection.Cursor = Cursors.Hand;
            btnFileSelection.FlatAppearance.BorderSize = 0;
            btnFileSelection.FlatStyle = FlatStyle.Flat;
            btnFileSelection.Font = new Font("Arial", 9F);
            btnFileSelection.Location = new Point(226, 32);
            btnFileSelection.Name = "btnFileSelection";
            btnFileSelection.Size = new Size(169, 27);
            btnFileSelection.TabIndex = 1;
            btnFileSelection.Text = "📁 Sözleşme Dosyası Seç";
            btnFileSelection.UseVisualStyleBackColor = false;
            btnFileSelection.Click += btnFileSelection_Click;
            // 
            // richTextBoxViewContract
            // 
            richTextBoxViewContract.Dock = DockStyle.Fill;
            richTextBoxViewContract.Font = new Font("Segoe UI", 14F);
            richTextBoxViewContract.Location = new Point(413, 0);
            richTextBoxViewContract.Name = "richTextBoxViewContract";
            richTextBoxViewContract.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBoxViewContract.Size = new Size(736, 626);
            richTextBoxViewContract.TabIndex = 4;
            richTextBoxViewContract.Text = "";
            richTextBoxViewContract.TextChanged += richTextBoxViewContract_TextChanged;
            // 
            // MainScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(1149, 626);
            Controls.Add(richTextBoxViewContract);
            Controls.Add(pnlMenu);
            ForeColor = Color.Black;
            MinimumSize = new Size(935, 400);
            Name = "MainScreen";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sözleşme Analiz Merkezi";
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResultScreen).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMenu;
        private ComboBox comboboxContractType;
        private Button btnFileSelection;
        private Button btnFileChecking;
        private RichTextBox richTextBoxViewContract;
        private DataGridView dataGridViewResultScreen;
        private Label lblScoreText;
        private Panel pnlRiskStatus;
        private Button btnExport;
        private Button btnManageRules;
        private DataGridViewTextBoxColumn MaddeAdı;
        private DataGridViewTextBoxColumn Durum;
    }
}
