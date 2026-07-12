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
            btnContractManagement = new Button();
            btnTemplates = new Button();
            grpSummaryType = new GroupBox();
            rbDetailedSummary = new RadioButton();
            rbBriefSummary = new RadioButton();
            tabResults = new TabControl();
            tabPageRules = new TabPage();
            tabPageAI = new TabPage();
            tabPageSummary = new TabPage();
            tabPageSearch = new TabPage();
            tabPageExtractions = new TabPage();
            rtbAIResults = new RichTextBox();
            rtbSummary = new RichTextBox();
            rtbExtractions = new RichTextBox();
            dgvSearchResults = new DataGridView();
            SearchIndex = new DataGridViewTextBoxColumn();
            SearchMatch = new DataGridViewTextBoxColumn();
            SearchType = new DataGridViewTextBoxColumn();
            SearchLine = new DataGridViewTextBoxColumn();
            SearchContext = new DataGridViewTextBoxColumn();
            dataGridViewResultScreen = new DataGridView();
            MaddeAdı = new DataGridViewTextBoxColumn();
            Durum = new DataGridViewTextBoxColumn();
            btnAnalyze = new Button();
            btnUpcomingDates = new Button();

            lblAIStatus = new Label();
            progressAI = new ProgressBar();
            lblSearchTitle = new Label();
            cmbSearchType = new ComboBox();
            txtSearchQuery = new TextBox();
            btnSearch = new Button();
            btnClearSearch = new Button();
            lblSearchStatus = new Label();
            comboboxContractType = new ComboBox();
            richTextBoxViewContract = new RichTextBox();
            splitContainer1 = new SplitContainer();
            pnlMenu.SuspendLayout();
            grpSummaryType.SuspendLayout();
            tabResults.SuspendLayout();
            tabPageRules.SuspendLayout();
            tabPageAI.SuspendLayout();
            tabPageSummary.SuspendLayout();
            tabPageSearch.SuspendLayout();
            tabPageExtractions.SuspendLayout();
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
            splitContainer1.Panel1.Controls.Add(pnlMenu);
            splitContainer1.Panel1MinSize = 420;
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
            pnlMenu.Controls.Add(btnAnalyze);
            pnlMenu.Controls.Add(lblAIStatus);
            pnlMenu.Controls.Add(progressAI);
            pnlMenu.Controls.Add(grpSummaryType);
            pnlMenu.Controls.Add(lblSearchTitle);
            pnlMenu.Controls.Add(cmbSearchType);
            pnlMenu.Controls.Add(txtSearchQuery);
            pnlMenu.Controls.Add(btnSearch);
            pnlMenu.Controls.Add(btnClearSearch);
            pnlMenu.Controls.Add(lblSearchStatus);
            pnlMenu.Controls.Add(tabResults);
            pnlMenu.Controls.Add(btnExport);
            pnlMenu.Controls.Add(btnContractManagement);
            pnlMenu.Controls.Add(btnTemplates);
            pnlMenu.Controls.Add(btnManageRules);
            pnlMenu.Controls.Add(btnUpcomingDates);
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
            comboboxContractType.Font = new Font("Segoe UI", 9F);
            comboboxContractType.FormattingEnabled = true;
            comboboxContractType.Location = new Point(12, 12);
            comboboxContractType.Name = "comboboxContractType";
            comboboxContractType.Size = new Size(396, 24);
            comboboxContractType.TabIndex = 0;
            comboboxContractType.SelectedIndexChanged += comboboxContractType_SelectedIndexChanged;
            // 
            // btnAnalyze
            // 
            btnAnalyze.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnAnalyze.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentTeal;
            btnAnalyze.CausesValidation = false;
            btnAnalyze.Cursor = Cursors.Hand;
            btnAnalyze.FlatAppearance.BorderSize = 0;
            btnAnalyze.FlatStyle = FlatStyle.Flat;
            btnAnalyze.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAnalyze.ForeColor = Color.White;
            btnAnalyze.Location = new Point(12, 42);
            btnAnalyze.Name = "btnAnalyze";
            btnAnalyze.Size = new Size(396, 34);
            btnAnalyze.TabIndex = 2;
            btnAnalyze.Text = "Sözleşmeyi Tam Analiz Et";
            btnAnalyze.UseVisualStyleBackColor = false;
            btnAnalyze.Click += btnAnalyze_Click;
            // 
            // btnUpcomingDates
            // 
            btnUpcomingDates.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnUpcomingDates.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBlue;
            btnUpcomingDates.CausesValidation = false;
            btnUpcomingDates.Cursor = Cursors.Hand;
            btnUpcomingDates.FlatAppearance.BorderSize = 0;
            btnUpcomingDates.FlatStyle = FlatStyle.Flat;
            btnUpcomingDates.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnUpcomingDates.ForeColor = Color.White;
            btnUpcomingDates.Location = new Point(12, 84);
            btnUpcomingDates.Name = "btnUpcomingDates";
            btnUpcomingDates.Size = new Size(396, 30);
            btnUpcomingDates.TabIndex = 3;
            btnUpcomingDates.Text = "📅 Yaklaşan Tarihler";
            btnUpcomingDates.UseVisualStyleBackColor = false;
            btnUpcomingDates.Click += btnUpcomingDates_Click;
            // 
            // lblAIStatus
            // 
            lblAIStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblAIStatus.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryBg;
            lblAIStatus.Font = new Font("Segoe UI", 7.5F);
            lblAIStatus.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryText;
            lblAIStatus.Location = new Point(12, 122);
            lblAIStatus.Name = "lblAIStatus";
            lblAIStatus.Size = new Size(396, 14);
            lblAIStatus.TabIndex = 10;
            lblAIStatus.Text = "Ollama: Kontrol ediliyor...";
            // 
            // progressAI
            // 
            progressAI.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressAI.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBg;
            progressAI.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentPurple;
            progressAI.Location = new Point(12, 138);
            progressAI.Name = "progressAI";
            progressAI.Size = new Size(396, 3);
            progressAI.Style = ProgressBarStyle.Marquee;
            progressAI.TabIndex = 11;
            progressAI.Visible = false;
            // 
            // grpSummaryType
            // 
            grpSummaryType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpSummaryType.Controls.Add(rbBriefSummary);
            grpSummaryType.Controls.Add(rbDetailedSummary);
            grpSummaryType.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            grpSummaryType.Font = new Font("Segoe UI", 8F);
            grpSummaryType.Location = new Point(12, 184);
            grpSummaryType.Name = "grpSummaryType";
            grpSummaryType.Size = new Size(396, 36);
            grpSummaryType.TabIndex = 30;
            grpSummaryType.TabStop = false;
            grpSummaryType.Text = "Özet Türü";
            // 
            // rbBriefSummary
            // 
            rbBriefSummary.AutoSize = true;
            rbBriefSummary.Checked = true;
            rbBriefSummary.Font = new Font("Segoe UI", 8F);
            rbBriefSummary.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            rbBriefSummary.Location = new Point(10, 14);
            rbBriefSummary.Name = "rbBriefSummary";
            rbBriefSummary.Size = new Size(100, 17);
            rbBriefSummary.TabIndex = 0;
            rbBriefSummary.TabStop = true;
            rbBriefSummary.Text = "Kısa Özet (5 madde)";
            rbBriefSummary.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryBg;
            // 
            // rbDetailedSummary
            // 
            rbDetailedSummary.AutoSize = true;
            rbDetailedSummary.Font = new Font("Segoe UI", 8F);
            rbDetailedSummary.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            rbDetailedSummary.Location = new Point(200, 14);
            rbDetailedSummary.Name = "rbDetailedSummary";
            rbDetailedSummary.Size = new Size(140, 17);
            rbDetailedSummary.TabIndex = 1;
            rbDetailedSummary.Text = "Detaylı Özet (1 sayfa)";
            rbDetailedSummary.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryBg;
            // 
            // lblSearchTitle
            // 
            lblSearchTitle.AutoSize = true;
            lblSearchTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblSearchTitle.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBlue;
            lblSearchTitle.Location = new Point(12, 228);
            lblSearchTitle.Name = "lblSearchTitle";
            lblSearchTitle.Size = new Size(40, 13);
            lblSearchTitle.TabIndex = 12;
            lblSearchTitle.Text = "ARAMA";
            // 
            // cmbSearchType
            // 
            cmbSearchType.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBg;
            cmbSearchType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSearchType.FlatStyle = FlatStyle.Flat;
            cmbSearchType.Font = new Font("Segoe UI", 8.5F);
            cmbSearchType.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            cmbSearchType.FormattingEnabled = true;
            cmbSearchType.Location = new Point(12, 246);
            cmbSearchType.Name = "cmbSearchType";
            cmbSearchType.Size = new Size(100, 22);
            cmbSearchType.TabIndex = 13;
            // 
            // txtSearchQuery
            // 
            txtSearchQuery.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearchQuery.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBg;
            txtSearchQuery.BorderStyle = BorderStyle.FixedSingle;
            txtSearchQuery.Font = new Font("Segoe UI", 8.5F);
            txtSearchQuery.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            txtSearchQuery.Location = new Point(118, 246);
            txtSearchQuery.Name = "txtSearchQuery";
            txtSearchQuery.PlaceholderText = "Aranacak metin...";
            txtSearchQuery.Size = new Size(140, 22);
            txtSearchQuery.TabIndex = 14;
            txtSearchQuery.KeyDown += txtSearchQuery_KeyDown;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBlue;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(266, 246);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(50, 22);
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
            btnClearSearch.Font = new Font("Segoe UI", 8F);
            btnClearSearch.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            btnClearSearch.Location = new Point(322, 246);
            btnClearSearch.Name = "btnClearSearch";
            btnClearSearch.Size = new Size(86, 22);
            btnClearSearch.TabIndex = 16;
            btnClearSearch.Text = "Temizle";
            btnClearSearch.UseVisualStyleBackColor = false;
            btnClearSearch.Click += btnClearSearch_Click;
            // 
            // lblSearchStatus
            // 
            lblSearchStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSearchStatus.Font = new Font("Segoe UI", 7.5F);
            lblSearchStatus.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryText;
            lblSearchStatus.Location = new Point(12, 272);
            lblSearchStatus.Name = "lblSearchStatus";
            lblSearchStatus.Size = new Size(124, 14);
            lblSearchStatus.TabIndex = 20;
            lblSearchStatus.Text = "";
            // 
            // tabResults
            // 
            tabResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabResults.Controls.Add(tabPageRules);
            tabResults.Controls.Add(tabPageAI);
            tabResults.Controls.Add(tabPageSummary);
            tabResults.Controls.Add(tabPageSearch);
            tabResults.Controls.Add(tabPageExtractions);
            tabResults.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabResults.Font = new Font("Segoe UI", 8.5F);
            tabResults.Location = new Point(12, 292);
            tabResults.Name = "tabResults";
            tabResults.SelectedIndex = 0;
            tabResults.Size = new Size(396, 364);
            tabResults.TabIndex = 21;
            // 
            // tabPageRules
            // 
            tabPageRules.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryBg;
            tabPageRules.Controls.Add(dataGridViewResultScreen);
            tabPageRules.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            tabPageRules.Location = new Point(4, 24);
            tabPageRules.Name = "tabPageRules";
            tabPageRules.Padding = new Padding(3);
            tabPageRules.Size = new Size(388, 412);
            tabPageRules.TabIndex = 0;
            tabPageRules.Text = "Kural Analizi";
            // 
            // tabPageAI
            // 
            tabPageAI.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryBg;
            tabPageAI.Controls.Add(rtbAIResults);
            tabPageAI.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            tabPageAI.Location = new Point(4, 24);
            tabPageAI.Name = "tabPageAI";
            tabPageAI.Padding = new Padding(3);
            tabPageAI.Size = new Size(388, 412);
            tabPageAI.TabIndex = 1;
            tabPageAI.Text = "AI Analizi";
            // 
            // tabPageSummary
            // 
            tabPageSummary.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryBg;
            tabPageSummary.Controls.Add(rtbSummary);
            tabPageSummary.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            tabPageSummary.Location = new Point(4, 24);
            tabPageSummary.Name = "tabPageSummary";
            tabPageSummary.Padding = new Padding(3);
            tabPageSummary.Size = new Size(388, 412);
            tabPageSummary.TabIndex = 3;
            tabPageSummary.Text = "Özet";
            // 
            // tabPageSearch
            // 
            tabPageSearch.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryBg;
            tabPageSearch.Controls.Add(dgvSearchResults);
            tabPageSearch.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            tabPageSearch.Location = new Point(4, 24);
            tabPageSearch.Name = "tabPageSearch";
            tabPageSearch.Padding = new Padding(3);
            tabPageSearch.Size = new Size(388, 412);
            tabPageSearch.TabIndex = 2;
            tabPageSearch.Text = "Arama Sonuçları";
            // 
            // tabPageExtractions
            // 
            tabPageExtractions.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryBg;
            tabPageExtractions.Controls.Add(rtbExtractions);
            tabPageExtractions.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            tabPageExtractions.Location = new Point(4, 24);
            tabPageExtractions.Name = "tabPageExtractions";
            tabPageExtractions.Padding = new Padding(3);
            tabPageExtractions.Size = new Size(388, 412);
            tabPageExtractions.TabIndex = 4;
            tabPageExtractions.Text = "Çıkarılan Alanlar";
            // 
            // rtbAIResults
            // 
            rtbAIResults.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryBg;
            rtbAIResults.BorderStyle = BorderStyle.None;
            rtbAIResults.Dock = DockStyle.Fill;
            rtbAIResults.Font = new Font("Segoe UI", 9.5F);
            rtbAIResults.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            rtbAIResults.Location = new Point(3, 3);
            rtbAIResults.Name = "rtbAIResults";
            rtbAIResults.ReadOnly = true;
            rtbAIResults.Size = new Size(382, 406);
            rtbAIResults.TabIndex = 0;
            rtbAIResults.Text = "";
            // 
            // rtbSummary
            // 
            rtbSummary.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryBg;
            rtbSummary.BorderStyle = BorderStyle.None;
            rtbSummary.Dock = DockStyle.Fill;
            rtbSummary.Font = new Font("Segoe UI", 9.5F);
            rtbSummary.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            rtbSummary.Location = new Point(3, 3);
            rtbSummary.Name = "rtbSummary";
            rtbSummary.ReadOnly = true;
            rtbSummary.Size = new Size(382, 406);
            rtbSummary.TabIndex = 0;
            rtbSummary.Text = "";
            // 
            // rtbExtractions
            // 
            rtbExtractions.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryBg;
            rtbExtractions.BorderStyle = BorderStyle.None;
            rtbExtractions.Dock = DockStyle.Fill;
            rtbExtractions.Font = new Font("Segoe UI", 9.5F);
            rtbExtractions.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            rtbExtractions.Location = new Point(3, 3);
            rtbExtractions.Name = "rtbExtractions";
            rtbExtractions.ReadOnly = true;
            rtbExtractions.Size = new Size(382, 406);
            rtbExtractions.TabIndex = 0;
            rtbExtractions.Text = "";
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
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            dataGridViewCellStyle2.SelectionBackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBg;
            dataGridViewCellStyle2.SelectionForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            dgvSearchResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvSearchResults.ColumnHeadersHeight = 28;
            dgvSearchResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvSearchResults.Columns.AddRange(new DataGridViewColumn[] { SearchIndex, SearchMatch, SearchType, SearchLine, SearchContext });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryBg;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 8.5F);
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
            dgvSearchResults.Size = new Size(382, 406);
            dgvSearchResults.TabIndex = 0;
            dgvSearchResults.CellClick += dgvSearchResults_CellClick;
            // 
            // SearchIndex
            // 
            SearchIndex.HeaderText = "#";
            SearchIndex.Name = "SearchIndex";
            SearchIndex.ReadOnly = true;
            SearchIndex.Width = 30;
            // 
            // SearchMatch
            // 
            SearchMatch.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            SearchMatch.HeaderText = "Eşleşme";
            SearchMatch.Name = "SearchMatch";
            SearchMatch.ReadOnly = true;
            // 
            // SearchType
            // 
            SearchType.HeaderText = "Tür";
            SearchType.Name = "SearchType";
            SearchType.ReadOnly = true;
            SearchType.Width = 70;
            // 
            // SearchLine
            // 
            SearchLine.HeaderText = "Satır";
            SearchLine.Name = "SearchLine";
            SearchLine.ReadOnly = true;
            SearchLine.Width = 40;
            // 
            // SearchContext
            // 
            SearchContext.HeaderText = "Bağlam";
            SearchContext.Name = "SearchContext";
            SearchContext.ReadOnly = true;
            SearchContext.Width = 160;
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
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            dataGridViewCellStyle1.SelectionBackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBg;
            dataGridViewCellStyle1.SelectionForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewResultScreen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewResultScreen.ColumnHeadersHeight = 32;
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
            Durum.Width = 150;
            // 
            // btnExport
            // 
            btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnExport.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBlue;
            btnExport.CausesValidation = false;
            btnExport.Cursor = Cursors.Hand;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(12, 666);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(92, 32);
            btnExport.TabIndex = 6;
            btnExport.Text = "PDF Aktar";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // btnContractManagement
            // 
            btnContractManagement.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnContractManagement.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentPurple;
            btnContractManagement.CausesValidation = false;
            btnContractManagement.Cursor = Cursors.Hand;
            btnContractManagement.FlatAppearance.BorderSize = 0;
            btnContractManagement.FlatStyle = FlatStyle.Flat;
            btnContractManagement.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnContractManagement.ForeColor = Color.White;
            btnContractManagement.Location = new Point(108, 666);
            btnContractManagement.Name = "btnContractManagement";
            btnContractManagement.Size = new Size(150, 32);
            btnContractManagement.TabIndex = 7;
            btnContractManagement.Text = "📂 Sözleşmeler";
            btnContractManagement.UseVisualStyleBackColor = false;
            btnContractManagement.Click += btnContractManagement_Click;
            // 
            // btnTemplates
            btnTemplates.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnTemplates.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentGreen;
            btnTemplates.CausesValidation = false;
            btnTemplates.Cursor = Cursors.Hand;
            btnTemplates.FlatAppearance.BorderSize = 0;
            btnTemplates.FlatStyle = FlatStyle.Flat;
            btnTemplates.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnTemplates.ForeColor = Color.White;
            btnTemplates.Location = new Point(262, 666);
            btnTemplates.Name = "btnTemplates";
            btnTemplates.Size = new Size(112, 32);
            btnTemplates.TabIndex = 8;
            btnTemplates.Text = "📄 Şablonlar";
            btnTemplates.UseVisualStyleBackColor = false;
            btnTemplates.Click += btnTemplates_Click;
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
            btnManageRules.Font = new Font("Segoe UI", 12F);
            btnManageRules.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            btnManageRules.Location = new Point(380, 666);
            btnManageRules.Name = "btnManageRules";
            btnManageRules.Size = new Size(28, 32);
            btnManageRules.TabIndex = 9;
            btnManageRules.Text = "\u2699";
            btnManageRules.UseVisualStyleBackColor = false;
            btnManageRules.Click += btnManageRules_Click;
            // 
            // richTextBoxViewContract
            // 
            richTextBoxViewContract.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryBg;
            richTextBoxViewContract.BorderStyle = BorderStyle.None;
            richTextBoxViewContract.Dock = DockStyle.Fill;
            richTextBoxViewContract.Font = new Font("Segoe UI", 10.5F);
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
            grpSummaryType.ResumeLayout(false);
            grpSummaryType.PerformLayout();
            tabResults.ResumeLayout(false);
            tabPageRules.ResumeLayout(false);
            tabPageAI.ResumeLayout(false);
            tabPageSummary.ResumeLayout(false);
            tabPageSearch.ResumeLayout(false);
            tabPageExtractions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSearchResults).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResultScreen).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Panel pnlMenu;
        private ComboBox comboboxContractType;
        private Button btnAnalyze;
        private Label lblAIStatus;
        private ProgressBar progressAI;
        private GroupBox grpSummaryType;
        private RadioButton rbBriefSummary;
        private RadioButton rbDetailedSummary;
        private TabControl tabResults;
        private TabPage tabPageRules;
        private TabPage tabPageAI;
        private TabPage tabPageSummary;
        private TabPage tabPageSearch;
        private TabPage tabPageExtractions;
        private RichTextBox rtbAIResults;
        private RichTextBox rtbSummary;
        private RichTextBox rtbExtractions;
        private DataGridView dataGridViewResultScreen;
        private DataGridView dgvSearchResults;
        private Button btnExport;
        private Button btnContractManagement;
        private Button btnTemplates;
        private Button btnManageRules;
        private Button btnUpcomingDates;
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
        private DataGridViewTextBoxColumn SearchType;
        private DataGridViewTextBoxColumn SearchLine;
        private DataGridViewTextBoxColumn SearchContext;
    }
}
