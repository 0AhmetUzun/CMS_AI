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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnlMenu = new Panel();
            btnManageRules = new Button();
            btnExport = new Button();
            tabResults = new TabControl();
            tabPageRules = new TabPage();
            tabPageAI = new TabPage();
            tabPageSearch = new TabPage();
            rtbAIResults = new RichTextBox();
            dgvSearchResults = new DataGridView();
            SearchIndex = new DataGridViewTextBoxColumn();
            SearchMatch = new DataGridViewTextBoxColumn();
            SearchLine = new DataGridViewTextBoxColumn();
            SearchContext = new DataGridViewTextBoxColumn();
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
            lblSearchTitle = new Label();
            cmbSearchType = new ComboBox();
            txtSearchQuery = new TextBox();
            btnSearch = new Button();
            btnClearSearch = new Button();
            lblSearchStatus = new Label();
            comboboxContractType = new ComboBox();
            btnFileSelection = new Button();
            richTextBoxViewContract = new RichTextBox();
            splitContainer1 = new SplitContainer();
            pnlMenu.SuspendLayout();
            tabResults.SuspendLayout();
            tabPageRules.SuspendLayout();
            tabPageAI.SuspendLayout();
            tabPageSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSearchResults).BeginInit();
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
            splitContainer1.Size = new Size(1280, 750);
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
            pnlMenu.Controls.Add(btnSummarize);
            pnlMenu.Controls.Add(btnAIAnalyze);
            pnlMenu.Controls.Add(lblAIStatus);
            pnlMenu.Controls.Add(progressAI);
            pnlMenu.Controls.Add(lblSearchTitle);
            pnlMenu.Controls.Add(cmbSearchType);
            pnlMenu.Controls.Add(txtSearchQuery);
            pnlMenu.Controls.Add(btnSearch);
            pnlMenu.Controls.Add(btnClearSearch);
            pnlMenu.Controls.Add(lblSearchStatus);
            pnlMenu.Controls.Add(tabResults);
            pnlMenu.Controls.Add(btnExport);
            pnlMenu.Controls.Add(btnManageRules);
            pnlMenu.Dock = DockStyle.Fill;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(420, 750);
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
            btnFileSelection.Location = new Point(12, 42);
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
            pnlRiskStatus.Location = new Point(12, 88);
            pnlRiskStatus.Name = "pnlRiskStatus";
            pnlRiskStatus.Size = new Size(18, 18);
            pnlRiskStatus.TabIndex = 4;
            // 
            // lblScoreText
            // 
            lblScoreText.AutoSize = true;
            lblScoreText.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryBg;
            lblScoreText.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblScoreText.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            lblScoreText.Location = new Point(36, 87);
            lblScoreText.Name = "lblScoreText";
            lblScoreText.Size = new Size(110, 17);
            lblScoreText.TabIndex = 3;
            lblScoreText.Text = "Risk Skoru: 0";
            // 
            // btnFileChecking
            // 
            btnFileChecking.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFileChecking.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBlue;
            btnFileChecking.CausesValidation = false;
            btnFileChecking.Cursor = Cursors.Hand;
            btnFileChecking.FlatAppearance.BorderSize = 0;
            btnFileChecking.FlatStyle = FlatStyle.Flat;
            btnFileChecking.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnFileChecking.ForeColor = Color.White;
            btnFileChecking.Location = new Point(226, 85);
            btnFileChecking.Name = "btnFileChecking";
            btnFileChecking.Size = new Size(182, 24);
            btnFileChecking.TabIndex = 2;
            btnFileChecking.Text = "Sözleşmeyi Analiz Et";
            btnFileChecking.UseVisualStyleBackColor = false;
            btnFileChecking.Click += btnFileChecking_Click;
            // 
            // btnSummarize
            // 
            btnSummarize.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBg;
            btnSummarize.CausesValidation = false;
            btnSummarize.Cursor = Cursors.Hand;
            btnSummarize.FlatAppearance.BorderSize = 1;
            btnSummarize.FlatAppearance.BorderColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.BorderColor;
            btnSummarize.FlatStyle = FlatStyle.Flat;
            btnSummarize.Font = new Font("Segoe UI", 9F);
            btnSummarize.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            btnSummarize.Location = new Point(12, 115);
            btnSummarize.Name = "btnSummarize";
            btnSummarize.Size = new Size(200, 24);
            btnSummarize.TabIndex = 9;
            btnSummarize.Text = "Sözleşmeyi Özetle";
            btnSummarize.UseVisualStyleBackColor = false;
            // 
            // btnAIAnalyze
            // 
            btnAIAnalyze.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAIAnalyze.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentPurple;
            btnAIAnalyze.CausesValidation = false;
            btnAIAnalyze.Cursor = Cursors.Hand;
            btnAIAnalyze.FlatAppearance.BorderSize = 0;
            btnAIAnalyze.FlatStyle = FlatStyle.Flat;
            btnAIAnalyze.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAIAnalyze.ForeColor = Color.White;
            btnAIAnalyze.Location = new Point(226, 115);
            btnAIAnalyze.Name = "btnAIAnalyze";
            btnAIAnalyze.Size = new Size(182, 24);
            btnAIAnalyze.TabIndex = 8;
            btnAIAnalyze.Text = "AI ile Analiz Et";
            btnAIAnalyze.UseVisualStyleBackColor = false;
            // 
            // lblAIStatus
            // 
            lblAIStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblAIStatus.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryBg;
            lblAIStatus.Font = new Font("Segoe UI", 8F);
            lblAIStatus.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryText;
            lblAIStatus.Location = new Point(12, 145);
            lblAIStatus.Name = "lblAIStatus";
            lblAIStatus.Size = new Size(396, 16);
            lblAIStatus.TabIndex = 10;
            lblAIStatus.Text = "Ollama: Kontrol ediliyor...";
            // 
            // progressAI
            // 
            progressAI.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressAI.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBg;
            progressAI.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentPurple;
            progressAI.Location = new Point(12, 163);
            progressAI.Name = "progressAI";
            progressAI.Size = new Size(396, 3);
            progressAI.Style = ProgressBarStyle.Marquee;
            progressAI.TabIndex = 11;
            progressAI.Visible = false;
            // 
            // lblSearchTitle
            // 
            lblSearchTitle.AutoSize = true;
            lblSearchTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSearchTitle.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBlue;
            lblSearchTitle.Location = new Point(12, 176);
            lblSearchTitle.Name = "lblSearchTitle";
            lblSearchTitle.Size = new Size(47, 15);
            lblSearchTitle.TabIndex = 12;
            lblSearchTitle.Text = "ARAMA";
            // 
            // cmbSearchType
            // 
            cmbSearchType.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBg;
            cmbSearchType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSearchType.FlatStyle = FlatStyle.Flat;
            cmbSearchType.Font = new Font("Segoe UI", 9F);
            cmbSearchType.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            cmbSearchType.FormattingEnabled = true;
            cmbSearchType.Location = new Point(12, 196);
            cmbSearchType.Name = "cmbSearchType";
            cmbSearchType.Size = new Size(110, 24);
            cmbSearchType.TabIndex = 13;
            // 
            // txtSearchQuery
            // 
            txtSearchQuery.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearchQuery.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBg;
            txtSearchQuery.BorderStyle = BorderStyle.FixedSingle;
            txtSearchQuery.Font = new Font("Segoe UI", 9F);
            txtSearchQuery.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            txtSearchQuery.Location = new Point(128, 196);
            txtSearchQuery.Name = "txtSearchQuery";
            txtSearchQuery.PlaceholderText = "Aranacak metin...";
            txtSearchQuery.Size = new Size(168, 23);
            txtSearchQuery.TabIndex = 14;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBlue;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(302, 196);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(52, 24);
            btnSearch.TabIndex = 15;
            btnSearch.Text = "Ara";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnClearSearch
            // 
            btnClearSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClearSearch.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBg;
            btnClearSearch.Cursor = Cursors.Hand;
            btnClearSearch.FlatAppearance.BorderColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.BorderColor;
            btnClearSearch.FlatAppearance.BorderSize = 1;
            btnClearSearch.FlatStyle = FlatStyle.Flat;
            btnClearSearch.Font = new Font("Segoe UI", 8.5F);
            btnClearSearch.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            btnClearSearch.Location = new Point(356, 196);
            btnClearSearch.Name = "btnClearSearch";
            btnClearSearch.Size = new Size(52, 24);
            btnClearSearch.TabIndex = 16;
            btnClearSearch.Text = "Temizle";
            btnClearSearch.UseVisualStyleBackColor = false;
            btnClearSearch.Click += btnClearSearch_Click;
            // 
            // lblSearchStatus
            // 
            lblSearchStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSearchStatus.Font = new Font("Segoe UI", 8F);
            lblSearchStatus.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryText;
            lblSearchStatus.Location = new Point(12, 224);
            lblSearchStatus.Name = "lblSearchStatus";
            lblSearchStatus.Size = new Size(396, 14);
            lblSearchStatus.TabIndex = 17;
            lblSearchStatus.Text = "";
            // 
            // tabResults
            // 
            tabResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabResults.Controls.Add(tabPageRules);
            tabResults.Controls.Add(tabPageAI);
            tabResults.Controls.Add(tabPageSearch);
            tabResults.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabResults.Font = new Font("Segoe UI", 9F);
            tabResults.Location = new Point(12, 244);
            tabResults.Name = "tabResults";
            tabResults.SelectedIndex = 0;
            tabResults.Size = new Size(396, 406);
            tabResults.TabIndex = 18;
            // 
            // tabPageRules
            // 
            tabPageRules.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryBg;
            tabPageRules.Controls.Add(dataGridViewResultScreen);
            tabPageRules.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            tabPageRules.Location = new Point(4, 26);
            tabPageRules.Name = "tabPageRules";
            tabPageRules.Padding = new Padding(3);
            tabPageRules.Size = new Size(388, 376);
            tabPageRules.TabIndex = 0;
            tabPageRules.Text = "Kural Analizi";
            // 
            // tabPageAI
            // 
            tabPageAI.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryBg;
            tabPageAI.Controls.Add(rtbAIResults);
            tabPageAI.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            tabPageAI.Location = new Point(4, 26);
            tabPageAI.Name = "tabPageAI";
            tabPageAI.Padding = new Padding(3);
            tabPageAI.Size = new Size(388, 376);
            tabPageAI.TabIndex = 1;
            tabPageAI.Text = "AI Analizi";
            // 
            // tabPageSearch
            // 
            tabPageSearch.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryBg;
            tabPageSearch.Controls.Add(dgvSearchResults);
            tabPageSearch.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            tabPageSearch.Location = new Point(4, 26);
            tabPageSearch.Name = "tabPageSearch";
            tabPageSearch.Padding = new Padding(3);
            tabPageSearch.Size = new Size(388, 376);
            tabPageSearch.TabIndex = 2;
            tabPageSearch.Text = "Arama Sonuçları";
            // 
            // dgvSearchResults
            // 
            dgvSearchResults.AllowUserToAddRows = false;
            dgvSearchResults.AllowUserToDeleteRows = false;
            dgvSearchResults.AllowUserToResizeRows = false;
            dgvSearchResults.BackgroundColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryBg;
            dgvSearchResults.BorderStyle = BorderStyle.None;
            dgvSearchResults.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBg;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            dataGridViewCellStyle2.SelectionBackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBg;
            dataGridViewCellStyle2.SelectionForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            dgvSearchResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvSearchResults.ColumnHeadersHeight = 32;
            dgvSearchResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvSearchResults.Columns.AddRange(new DataGridViewColumn[] { SearchIndex, SearchMatch, SearchLine, SearchContext });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryBg;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            dataGridViewCellStyle3.SelectionBackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.HoverColor;
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dgvSearchResults.DefaultCellStyle = dataGridViewCellStyle3;
            dgvSearchResults.Dock = DockStyle.Fill;
            dgvSearchResults.GridColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.BorderColor;
            dgvSearchResults.Location = new Point(3, 3);
            dgvSearchResults.MultiSelect = false;
            dgvSearchResults.Name = "dgvSearchResults";
            dgvSearchResults.ReadOnly = true;
            dgvSearchResults.RowHeadersVisible = false;
            dgvSearchResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSearchResults.Size = new Size(382, 370);
            dgvSearchResults.TabIndex = 0;
            dgvSearchResults.CellClick += dgvSearchResults_CellClick;
            // 
            // SearchIndex
            // 
            SearchIndex.HeaderText = "#";
            SearchIndex.Name = "SearchIndex";
            SearchIndex.ReadOnly = true;
            SearchIndex.Width = 35;
            // 
            // SearchMatch
            // 
            SearchMatch.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            SearchMatch.HeaderText = "Eşleşme";
            SearchMatch.Name = "SearchMatch";
            SearchMatch.ReadOnly = true;
            // 
            // SearchLine
            // 
            SearchLine.HeaderText = "Satır";
            SearchLine.Name = "SearchLine";
            SearchLine.ReadOnly = true;
            SearchLine.Width = 50;
            // 
            // SearchContext
            // 
            SearchContext.HeaderText = "Bağlam";
            SearchContext.Name = "SearchContext";
            SearchContext.ReadOnly = true;
            SearchContext.Width = 180;
            // 
            // dataGridViewResultScreen
            // 
            dataGridViewResultScreen.AllowUserToAddRows = false;
            dataGridViewResultScreen.AllowUserToDeleteRows = false;
            dataGridViewResultScreen.AllowUserToResizeRows = false;
            dataGridViewResultScreen.BackgroundColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryBg;
            dataGridViewResultScreen.BorderStyle = BorderStyle.None;
            dataGridViewResultScreen.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBg;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            dataGridViewCellStyle1.SelectionBackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBg;
            dataGridViewCellStyle1.SelectionForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewResultScreen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewResultScreen.ColumnHeadersHeight = 36;
            dataGridViewResultScreen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewResultScreen.Columns.AddRange(new DataGridViewColumn[] { MaddeAdı, Durum });
            dataGridViewResultScreen.DefaultCellStyle.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryBg;
            dataGridViewResultScreen.DefaultCellStyle.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            dataGridViewResultScreen.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dataGridViewResultScreen.DefaultCellStyle.SelectionBackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.HoverColor;
            dataGridViewResultScreen.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridViewResultScreen.GridColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.BorderColor;
            dataGridViewResultScreen.Dock = DockStyle.Fill;
            dataGridViewResultScreen.Name = "dataGridViewResultScreen";
            dataGridViewResultScreen.ReadOnly = true;
            dataGridViewResultScreen.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewResultScreen.RowHeadersVisible = false;
            dataGridViewResultScreen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewResultScreen.ShowEditingIcon = false;
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
            Durum.Width = 160;
            // 
            // rtbAIResults
            // 
            rtbAIResults.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryBg;
            rtbAIResults.BorderStyle = BorderStyle.None;
            rtbAIResults.Dock = DockStyle.Fill;
            rtbAIResults.Font = new Font("Segoe UI", 10F);
            rtbAIResults.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            rtbAIResults.Location = new Point(3, 3);
            rtbAIResults.Name = "rtbAIResults";
            rtbAIResults.ReadOnly = true;
            rtbAIResults.Size = new Size(382, 370);
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
            btnExport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(12, 658);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(336, 36);
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
            btnManageRules.Location = new Point(354, 658);
            btnManageRules.Name = "btnManageRules";
            btnManageRules.Size = new Size(54, 36);
            btnManageRules.TabIndex = 7;
            btnManageRules.Text = "\u2699";
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
            richTextBoxViewContract.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBoxViewContract.Size = new Size(858, 750);
            richTextBoxViewContract.TabIndex = 4;
            richTextBoxViewContract.Text = "";
            richTextBoxViewContract.TextChanged += richTextBoxViewContract_TextChanged;
            // 
            // MainScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryBg;
            ClientSize = new Size(1280, 750);
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
            tabPageSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSearchResults).EndInit();
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
        private TabPage tabPageSearch;
        private RichTextBox rtbAIResults;
        private DataGridView dataGridViewResultScreen;
        private DataGridView dgvSearchResults;
        private Label lblScoreText;
        private Panel pnlRiskStatus;
        private Button btnExport;
        private Button btnManageRules;
        private RichTextBox richTextBoxViewContract;
        private DataGridViewTextBoxColumn MaddeAdı;
        private DataGridViewTextBoxColumn Durum;
        private Label lblSearchTitle;
        private ComboBox cmbSearchType;
        private TextBox txtSearchQuery;
        private Button btnSearch;
        private Button btnClearSearch;
        private Label lblSearchStatus;
        private DataGridViewTextBoxColumn SearchIndex;
        private DataGridViewTextBoxColumn SearchMatch;
        private DataGridViewTextBoxColumn SearchLine;
        private DataGridViewTextBoxColumn SearchContext;
    }
}