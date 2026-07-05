namespace ContractManagementSystem_CMS_
{
    partial class MainScreen
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlMenu = new Panel();
            btnManageRules = new Button();
            btnExport = new Button();
            tabResults = new TabControl();
            tabPageRules = new TabPage();
            tabPageAI = new TabPage();
            rtbAIResults = new RichTextBox();
            dataGridViewResultScreen = new DataGridView();
            MaddeAdı = new DataGridViewTextBoxColumn();
            Durum = new DataGridViewTextBoxColumn();
            pnlRiskStatus = new Panel();
            lblScoreText = new Label();
            btnFileChecking = new Button();
            btnAIAnalyze = new Button();
            btnSummarize = new Button();
            lblAIStatus = new Label();
            progressAI = new ProgressBar();
            comboboxContractType = new ComboBox();
            btnFileSelection = new Button();
            richTextBoxViewContract = new RichTextBox();
            splitContainer1 = new SplitContainer();
            pnlMenu.SuspendLayout();
            tabResults.SuspendLayout();
            tabPageRules.SuspendLayout();
            tabPageAI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResultScreen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(pnlMenu);
            splitContainer1.Panel1MinSize = 420;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(richTextBoxViewContract);
            splitContainer1.Panel2.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryBg;
            splitContainer1.Size = new Size(1200, 700);
            splitContainer1.SplitterDistance = 420;
            splitContainer1.SplitterWidth = 2;
            splitContainer1.TabIndex = 0;
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryBg;
            pnlMenu.Controls.Add(comboboxContractType);
            pnlMenu.Controls.Add(btnFileSelection);
            pnlMenu.Controls.Add(pnlRiskStatus);
            pnlMenu.Controls.Add(lblScoreText);
            pnlMenu.Controls.Add(btnFileChecking);
            pnlMenu.Controls.Add(btnAIAnalyze);
            pnlMenu.Controls.Add(btnSummarize);
            pnlMenu.Controls.Add(lblAIStatus);
            pnlMenu.Controls.Add(progressAI);
            pnlMenu.Controls.Add(tabResults);
            pnlMenu.Controls.Add(btnExport);
            pnlMenu.Controls.Add(btnManageRules);
            pnlMenu.Dock = DockStyle.Fill;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(420, 700);
            pnlMenu.TabIndex = 0;
            pnlMenu.Padding = new Padding(12);
            // 
            // comboboxContractType
            // 
            comboboxContractType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboboxContractType.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBg;
            comboboxContractType.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            comboboxContractType.FlatStyle = FlatStyle.Flat;
            comboboxContractType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboboxContractType.Font = new Font("Segoe UI", 9.5F);
            comboboxContractType.FormattingEnabled = true;
            comboboxContractType.Location = new Point(12, 12);
            comboboxContractType.Name = "comboboxContractType";
            comboboxContractType.Size = new Size(396, 25);
            comboboxContractType.TabIndex = 0;
            comboboxContractType.SelectedIndexChanged += comboboxContractType_SelectedIndexChanged;
            // 
            // btnFileSelection
            // 
            btnFileSelection.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnFileSelection.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBg;
            btnFileSelection.CausesValidation = false;
            btnFileSelection.Cursor = Cursors.Hand;
            btnFileSelection.FlatAppearance.BorderSize = 1;
            btnFileSelection.FlatAppearance.BorderColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.BorderColor;
            btnFileSelection.FlatStyle = FlatStyle.Flat;
            btnFileSelection.Font = new Font("Segoe UI", 9.5F);
            btnFileSelection.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            btnFileSelection.Location = new Point(12, 46);
            btnFileSelection.Name = "btnFileSelection";
            btnFileSelection.Size = new Size(396, 36);
            btnFileSelection.TabIndex = 1;
            btnFileSelection.Text = "Sözleşme Dosyası Seç";
            btnFileSelection.UseVisualStyleBackColor = false;
            btnFileSelection.Click += btnFileSelection_Click;
            // 
            // pnlRiskStatus
            // 
            pnlRiskStatus.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.RiskGreen;
            pnlRiskStatus.ForeColor = Color.White;
            pnlRiskStatus.Location = new Point(12, 94);
            pnlRiskStatus.Name = "pnlRiskStatus";
            pnlRiskStatus.Size = new Size(18, 18);
            pnlRiskStatus.TabIndex = 4;
            // 
            // lblScoreText
            // 
            lblScoreText.AutoSize = true;
            lblScoreText.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryBg;
            lblScoreText.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblScoreText.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            lblScoreText.Location = new Point(36, 92);
            lblScoreText.Name = "lblScoreText";
            lblScoreText.Size = new Size(120, 20);
            lblScoreText.TabIndex = 3;
            lblScoreText.Text = "Risk Skoru : 0";
            // 
            // btnFileChecking
            // 
            btnFileChecking.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFileChecking.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBlue;
            btnFileChecking.CausesValidation = false;
            btnFileChecking.Cursor = Cursors.Hand;
            btnFileChecking.FlatAppearance.BorderSize = 0;
            btnFileChecking.FlatStyle = FlatStyle.Flat;
            btnFileChecking.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnFileChecking.ForeColor = Color.White;
            btnFileChecking.Location = new Point(226, 92);
            btnFileChecking.Name = "btnFileChecking";
            btnFileChecking.Size = new Size(182, 26);
            btnFileChecking.TabIndex = 2;
            btnFileChecking.Text = "Sözleşmeyi Analiz Et";
            btnFileChecking.UseVisualStyleBackColor = false;
            btnFileChecking.Click += btnFileChecking_Click;
            // 
            // btnAIAnalyze
            // 
            btnAIAnalyze.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAIAnalyze.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentPurple;
            btnAIAnalyze.CausesValidation = false;
            btnAIAnalyze.Cursor = Cursors.Hand;
            btnAIAnalyze.FlatAppearance.BorderSize = 0;
            btnAIAnalyze.FlatStyle = FlatStyle.Flat;
            btnAIAnalyze.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAIAnalyze.ForeColor = Color.White;
            btnAIAnalyze.Location = new Point(226, 124);
            btnAIAnalyze.Name = "btnAIAnalyze";
            btnAIAnalyze.Size = new Size(182, 26);
            btnAIAnalyze.TabIndex = 8;
            btnAIAnalyze.Text = "AI ile Analiz Et";
            btnAIAnalyze.UseVisualStyleBackColor = false;
            // 
            // btnSummarize
            // 
            btnSummarize.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBg;
            btnSummarize.CausesValidation = false;
            btnSummarize.Cursor = Cursors.Hand;
            btnSummarize.FlatAppearance.BorderSize = 1;
            btnSummarize.FlatAppearance.BorderColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.BorderColor;
            btnSummarize.FlatStyle = FlatStyle.Flat;
            btnSummarize.Font = new Font("Segoe UI", 9.5F);
            btnSummarize.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            btnSummarize.Location = new Point(12, 124);
            btnSummarize.Name = "btnSummarize";
            btnSummarize.Size = new Size(208, 26);
            btnSummarize.TabIndex = 9;
            btnSummarize.Text = "Sözleşmeyi Özetle";
            btnSummarize.UseVisualStyleBackColor = false;
            // 
            // lblAIStatus
            // 
            lblAIStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblAIStatus.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryBg;
            lblAIStatus.Font = new Font("Segoe UI", 8.5F);
            lblAIStatus.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryText;
            lblAIStatus.Location = new Point(12, 156);
            lblAIStatus.Name = "lblAIStatus";
            lblAIStatus.Size = new Size(396, 18);
            lblAIStatus.TabIndex = 10;
            lblAIStatus.Text = "Ollama: Kontrol ediliyor...";
            // 
            // progressAI
            // 
            progressAI.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressAI.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBg;
            progressAI.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentPurple;
            progressAI.Location = new Point(12, 176);
            progressAI.Name = "progressAI";
            progressAI.Size = new Size(396, 4);
            progressAI.Style = ProgressBarStyle.Marquee;
            progressAI.TabIndex = 11;
            progressAI.Visible = false;
            // 
            // tabResults
            // 
            tabResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabResults.Controls.Add(tabPageRules);
            tabResults.Controls.Add(tabPageAI);
            tabResults.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabResults.Font = new Font("Segoe UI", 9.5F);
            tabResults.Location = new Point(12, 192);
            tabResults.Name = "tabResults";
            tabResults.SelectedIndex = 0;
            tabResults.Size = new Size(396, 438);
            tabResults.TabIndex = 12;
            // 
            // tabPageRules
            // 
            tabPageRules.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryBg;
            tabPageRules.Controls.Add(dataGridViewResultScreen);
            tabPageRules.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            tabPageRules.Location = new Point(4, 30);
            tabPageRules.Name = "tabPageRules";
            tabPageRules.Padding = new Padding(3);
            tabPageRules.Size = new Size(388, 404);
            tabPageRules.TabIndex = 0;
            tabPageRules.Text = "Kural Analizi";
            // 
            // tabPageAI
            // 
            tabPageAI.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryBg;
            tabPageAI.Controls.Add(rtbAIResults);
            tabPageAI.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            tabPageAI.Location = new Point(4, 30);
            tabPageAI.Name = "tabPageAI";
            tabPageAI.Padding = new Padding(3);
            tabPageAI.Size = new Size(388, 404);
            tabPageAI.TabIndex = 1;
            tabPageAI.Text = "AI Analizi";
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
            dataGridViewResultScreen.BackgroundColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryBg;
            dataGridViewResultScreen.BorderStyle = BorderStyle.None;
            dataGridViewResultScreen.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBg;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            dataGridViewCellStyle1.SelectionBackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBg;
            dataGridViewCellStyle1.SelectionForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewResultScreen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewResultScreen.ColumnHeadersHeight = 40;
            dataGridViewResultScreen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewResultScreen.Columns.AddRange(new DataGridViewColumn[] { MaddeAdı, Durum });
            dataGridViewResultScreen.DefaultCellStyle.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryBg;
            dataGridViewResultScreen.DefaultCellStyle.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            dataGridViewResultScreen.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dataGridViewResultScreen.DefaultCellStyle.SelectionBackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.HoverColor;
            dataGridViewResultScreen.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridViewResultScreen.GridColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.BorderColor;
            dataGridViewResultScreen.Location = new Point(0, 0);
            dataGridViewResultScreen.Name = "dataGridViewResultScreen";
            dataGridViewResultScreen.ReadOnly = true;
            dataGridViewResultScreen.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewResultScreen.RowHeadersVisible = false;
            dataGridViewResultScreen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewResultScreen.ShowEditingIcon = false;
            dataGridViewResultScreen.Size = new Size(388, 404);
            dataGridViewResultScreen.StandardTab = true;
            dataGridViewResultScreen.TabIndex = 0;
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
            Durum.HeaderText = "Durum";
            Durum.Name = "Durum";
            Durum.ReadOnly = true;
            Durum.Width = 180;
            // 
            // rtbAIResults
            // 
            rtbAIResults.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryBg;
            rtbAIResults.BorderStyle = BorderStyle.None;
            rtbAIResults.Dock = DockStyle.Fill;
            rtbAIResults.Font = new Font("Segoe UI", 10.5F);
            rtbAIResults.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            rtbAIResults.Location = new Point(3, 3);
            rtbAIResults.Name = "rtbAIResults";
            rtbAIResults.ReadOnly = true;
            rtbAIResults.Size = new Size(382, 398);
            rtbAIResults.TabIndex = 0;
            rtbAIResults.Text = "";
            // 
            // btnExport
            // 
            btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnExport.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBlue;
            btnExport.CausesValidation = false;
            btnExport.Cursor = Cursors.Hand;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(12, 638);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(330, 40);
            btnExport.TabIndex = 6;
            btnExport.Text = "Raporu PDF Olarak Dışa Aktar";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // btnManageRules
            // 
            btnManageRules.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnManageRules.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBg;
            btnManageRules.CausesValidation = false;
            btnManageRules.Cursor = Cursors.Hand;
            btnManageRules.FlatAppearance.BorderColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.BorderColor;
            btnManageRules.FlatAppearance.BorderSize = 1;
            btnManageRules.FlatStyle = FlatStyle.Flat;
            btnManageRules.Font = new Font("Segoe UI", 14F);
            btnManageRules.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            btnManageRules.Location = new Point(348, 638);
            btnManageRules.Name = "btnManageRules";
            btnManageRules.Size = new Size(60, 40);
            btnManageRules.TabIndex = 7;
            btnManageRules.Text = "⚙";
            btnManageRules.UseVisualStyleBackColor = false;
            btnManageRules.Click += btnManageRules_Click;
            // 
            // richTextBoxViewContract
            // 
            richTextBoxViewContract.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryBg;
            richTextBoxViewContract.BorderStyle = BorderStyle.None;
            richTextBoxViewContract.Dock = DockStyle.Fill;
            richTextBoxViewContract.Font = new Font("Segoe UI", 11F);
            richTextBoxViewContract.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            richTextBoxViewContract.Location = new Point(0, 0);
            richTextBoxViewContract.Name = "richTextBoxViewContract";
            richTextBoxViewContract.ReadOnly = true;
            richTextBoxViewContract.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBoxViewContract.Size = new Size(778, 700);
            richTextBoxViewContract.TabIndex = 4;
            richTextBoxViewContract.Text = "";
            richTextBoxViewContract.TextChanged += richTextBoxViewContract_TextChanged;
            // 
            // MainScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryBg;
            ClientSize = new Size(1200, 700);
            Controls.Add(splitContainer1);
            ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            MinimumSize = new Size(1000, 500);
            Name = "MainScreen";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sözleşme Analiz Merkezi - CMS";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            tabResults.ResumeLayout(false);
            tabPageRules.ResumeLayout(false);
            tabPageAI.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewResultScreen).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Panel pnlMenu;
        private ComboBox comboboxContractType;
        private Button btnFileSelection;
        private Button btnFileChecking;
        private Button btnAIAnalyze;
        private Button btnSummarize;
        private Label lblAIStatus;
        private ProgressBar progressAI;
        private TabControl tabResults;
        private TabPage tabPageRules;
        private TabPage tabPageAI;
        private RichTextBox rtbAIResults;
        private DataGridView dataGridViewResultScreen;
        private Label lblScoreText;
        private Panel pnlRiskStatus;
        private Button btnExport;
        private Button btnManageRules;
        private RichTextBox richTextBoxViewContract;
        private DataGridViewTextBoxColumn MaddeAdı;
        private DataGridViewTextBoxColumn Durum;
    }
}
