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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            mainToolTip = new ToolTip(components);
            pnlMenu = new Panel();
            comboboxContractType = new ComboBox();
            btnAnalyze = new Button();
            lblAIStatus = new Label();
            progressAI = new ProgressBar();
            grpSummaryType = new GroupBox();
            rbBriefSummary = new RadioButton();
            rbDetailedSummary = new RadioButton();
            lblSearchTitle = new Label();
            cmbSearchType = new ComboBox();
            txtSearchQuery = new TextBox();
            btnSearch = new Button();
            btnClearSearch = new Button();
            lblSearchStatus = new Label();
            tabResults = new TabControl();
            tabPageRules = new TabPage();
            dataGridViewResultScreen = new DataGridView();
            MaddeAdı = new DataGridViewTextBoxColumn();
            Durum = new DataGridViewTextBoxColumn();
            tabPageAI = new TabPage();
            rtbAIResults = new RichTextBox();
            tabPageSummary = new TabPage();
            rtbSummary = new RichTextBox();
            tabPageSearch = new TabPage();
            dgvSearchResults = new DataGridView();
            SearchIndex = new DataGridViewTextBoxColumn();
            SearchMatch = new DataGridViewTextBoxColumn();
            SearchType = new DataGridViewTextBoxColumn();
            SearchLine = new DataGridViewTextBoxColumn();
            SearchContext = new DataGridViewTextBoxColumn();
            tabPageExtractions = new TabPage();
            rtbExtractions = new RichTextBox();
            btnExport = new Button();
            btnContractManagement = new Button();
            btnTemplates = new Button();
            btnManageRules = new Button();
            btnUpcomingDates = new Button();
            btnSecurity = new Button();
            richTextBoxViewContract = new RichTextBox();
            splitContainer1 = new SplitContainer();
            pnlMenu.SuspendLayout();
            grpSummaryType.SuspendLayout();
            tabResults.SuspendLayout();
            tabPageRules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResultScreen).BeginInit();
            tabPageAI.SuspendLayout();
            tabPageSummary.SuspendLayout();
            tabPageSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSearchResults).BeginInit();
            tabPageExtractions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // mainToolTip
            // 
            mainToolTip.AutoPopDelay = 5000;
            mainToolTip.InitialDelay = 400;
            mainToolTip.ReshowDelay = 100;
            mainToolTip.ShowAlways = true;
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.FromArgb(30, 30, 30);
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
            pnlMenu.Controls.Add(btnSecurity);
            pnlMenu.Dock = DockStyle.Fill;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Margin = new Padding(3, 4, 3, 4);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Padding = new Padding(14, 16, 14, 16);
            pnlMenu.Size = new Size(480, 1000);
            pnlMenu.TabIndex = 0;
            // 
            // comboboxContractType
            // 
            comboboxContractType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboboxContractType.BackColor = Color.FromArgb(50, 50, 50);
            comboboxContractType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboboxContractType.FlatStyle = FlatStyle.Flat;
            comboboxContractType.Font = new Font("Segoe UI", 9F);
            comboboxContractType.ForeColor = Color.FromArgb(240, 240, 240);
            comboboxContractType.FormattingEnabled = true;
            comboboxContractType.Location = new Point(14, 20);
            comboboxContractType.Margin = new Padding(3, 4, 3, 4);
            comboboxContractType.Name = "comboboxContractType";
            comboboxContractType.Size = new Size(452, 23);
            comboboxContractType.TabIndex = 0;
            comboboxContractType.SelectedIndexChanged += comboboxContractType_SelectedIndexChanged;
            // 
            // btnAnalyze
            // 
            btnAnalyze.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnAnalyze.BackColor = Color.FromArgb(220, 53, 69);
            btnAnalyze.CausesValidation = false;
            btnAnalyze.Cursor = Cursors.Hand;
            btnAnalyze.FlatAppearance.BorderSize = 0;
            btnAnalyze.FlatStyle = FlatStyle.Flat;
            btnAnalyze.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAnalyze.ForeColor = Color.White;
            btnAnalyze.Location = new Point(238, 129);
            btnAnalyze.Margin = new Padding(3, 4, 3, 4);
            btnAnalyze.Name = "btnAnalyze";
            btnAnalyze.Size = new Size(229, 45);
            btnAnalyze.TabIndex = 2;
            btnAnalyze.Text = "Sözleşmeyi Analiz Et";
            btnAnalyze.UseVisualStyleBackColor = false;
            btnAnalyze.Click += btnAnalyze_Click;
            // 
            // lblAIStatus
            // 
            lblAIStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblAIStatus.BackColor = Color.FromArgb(30, 30, 30);
            lblAIStatus.Font = new Font("Segoe UI", 7.5F);
            lblAIStatus.ForeColor = Color.FromArgb(180, 180, 180);
            lblAIStatus.Location = new Point(13, 195);
            lblAIStatus.Name = "lblAIStatus";
            lblAIStatus.Size = new Size(453, 19);
            lblAIStatus.TabIndex = 10;
            lblAIStatus.Text = "Ollama: Kontrol ediliyor...";
            // 
            // progressAI
            // 
            progressAI.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressAI.BackColor = Color.FromArgb(50, 50, 50);
            progressAI.ForeColor = Color.FromArgb(128, 0, 255);
            progressAI.Location = new Point(13, 216);
            progressAI.Margin = new Padding(3, 4, 3, 4);
            progressAI.Name = "progressAI";
            progressAI.Size = new Size(453, 4);
            progressAI.Style = ProgressBarStyle.Marquee;
            progressAI.TabIndex = 11;
            progressAI.Visible = false;
            // 
            // grpSummaryType
            // 
            grpSummaryType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpSummaryType.Controls.Add(rbBriefSummary);
            grpSummaryType.Controls.Add(rbDetailedSummary);
            grpSummaryType.Font = new Font("Segoe UI", 8F);
            grpSummaryType.ForeColor = Color.FromArgb(240, 240, 240);
            grpSummaryType.Location = new Point(14, 64);
            grpSummaryType.Margin = new Padding(3, 4, 3, 4);
            grpSummaryType.Name = "grpSummaryType";
            grpSummaryType.Padding = new Padding(3, 4, 3, 4);
            grpSummaryType.Size = new Size(453, 48);
            grpSummaryType.TabIndex = 30;
            grpSummaryType.TabStop = false;
            grpSummaryType.Text = "Özet Türü";
            // 
            // rbBriefSummary
            // 
            rbBriefSummary.AutoSize = true;
            rbBriefSummary.BackColor = Color.FromArgb(40, 40, 40);
            rbBriefSummary.Checked = true;
            rbBriefSummary.Font = new Font("Segoe UI", 8F);
            rbBriefSummary.ForeColor = Color.FromArgb(240, 240, 240);
            rbBriefSummary.Location = new Point(11, 19);
            rbBriefSummary.Margin = new Padding(3, 4, 3, 4);
            rbBriefSummary.Name = "rbBriefSummary";
            rbBriefSummary.Size = new Size(125, 17);
            rbBriefSummary.TabIndex = 0;
            rbBriefSummary.TabStop = true;
            rbBriefSummary.Text = "Kısa Özet (5 madde)";
            rbBriefSummary.UseVisualStyleBackColor = false;
            // 
            // rbDetailedSummary
            // 
            rbDetailedSummary.AutoSize = true;
            rbDetailedSummary.BackColor = Color.FromArgb(40, 40, 40);
            rbDetailedSummary.Font = new Font("Segoe UI", 8F);
            rbDetailedSummary.ForeColor = Color.FromArgb(240, 240, 240);
            rbDetailedSummary.Location = new Point(229, 19);
            rbDetailedSummary.Margin = new Padding(3, 4, 3, 4);
            rbDetailedSummary.Name = "rbDetailedSummary";
            rbDetailedSummary.Size = new Size(131, 17);
            rbDetailedSummary.TabIndex = 1;
            rbDetailedSummary.Text = "Detaylı Özet (1 sayfa)";
            rbDetailedSummary.UseVisualStyleBackColor = false;
            // 
            // lblSearchTitle
            // 
            lblSearchTitle.AutoSize = true;
            lblSearchTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblSearchTitle.ForeColor = Color.FromArgb(0, 120, 215);
            lblSearchTitle.Location = new Point(14, 254);
            lblSearchTitle.Name = "lblSearchTitle";
            lblSearchTitle.Size = new Size(50, 15);
            lblSearchTitle.TabIndex = 12;
            lblSearchTitle.Text = "ARAMA";
            // 
            // cmbSearchType
            // 
            cmbSearchType.BackColor = Color.FromArgb(50, 50, 50);
            cmbSearchType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSearchType.FlatStyle = FlatStyle.Flat;
            cmbSearchType.Font = new Font("Segoe UI", 8.5F);
            cmbSearchType.ForeColor = Color.FromArgb(240, 240, 240);
            cmbSearchType.FormattingEnabled = true;
            cmbSearchType.Location = new Point(14, 278);
            cmbSearchType.Margin = new Padding(3, 4, 3, 4);
            cmbSearchType.Name = "cmbSearchType";
            cmbSearchType.Size = new Size(114, 21);
            cmbSearchType.TabIndex = 13;
            // 
            // txtSearchQuery
            // 
            txtSearchQuery.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearchQuery.BackColor = Color.FromArgb(50, 50, 50);
            txtSearchQuery.BorderStyle = BorderStyle.FixedSingle;
            txtSearchQuery.Font = new Font("Segoe UI", 8.5F);
            txtSearchQuery.ForeColor = Color.FromArgb(240, 240, 240);
            txtSearchQuery.Location = new Point(134, 278);
            txtSearchQuery.Margin = new Padding(3, 4, 3, 4);
            txtSearchQuery.Name = "txtSearchQuery";
            txtSearchQuery.PlaceholderText = "Aranacak metin...";
            txtSearchQuery.Size = new Size(160, 23);
            txtSearchQuery.TabIndex = 14;
            txtSearchQuery.KeyDown += txtSearchQuery_KeyDown;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = Color.FromArgb(0, 120, 215);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(300, 278);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(63, 28);
            btnSearch.TabIndex = 15;
            btnSearch.Text = "Ara";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnClearSearch
            // 
            btnClearSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClearSearch.BackColor = Color.FromArgb(50, 50, 50);
            btnClearSearch.Cursor = Cursors.Hand;
            btnClearSearch.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 60);
            btnClearSearch.FlatStyle = FlatStyle.Flat;
            btnClearSearch.Font = new Font("Segoe UI", 8F);
            btnClearSearch.ForeColor = Color.FromArgb(240, 240, 240);
            btnClearSearch.Location = new Point(369, 278);
            btnClearSearch.Margin = new Padding(3, 4, 3, 4);
            btnClearSearch.Name = "btnClearSearch";
            btnClearSearch.Size = new Size(98, 28);
            btnClearSearch.TabIndex = 16;
            btnClearSearch.Text = "Temizle";
            btnClearSearch.UseVisualStyleBackColor = false;
            btnClearSearch.Click += btnClearSearch_Click;
            // 
            // lblSearchStatus
            // 
            lblSearchStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSearchStatus.Font = new Font("Segoe UI", 7.5F);
            lblSearchStatus.ForeColor = Color.FromArgb(180, 180, 180);
            lblSearchStatus.Location = new Point(14, 305);
            lblSearchStatus.Name = "lblSearchStatus";
            lblSearchStatus.Size = new Size(142, 19);
            lblSearchStatus.TabIndex = 20;
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
            tabResults.Location = new Point(14, 334);
            tabResults.Margin = new Padding(3, 4, 3, 4);
            tabResults.Name = "tabResults";
            tabResults.SelectedIndex = 0;
            tabResults.Size = new Size(453, 571);
            tabResults.TabIndex = 21;
            // 
            // tabPageRules
            // 
            tabPageRules.BackColor = Color.FromArgb(40, 40, 40);
            tabPageRules.Controls.Add(dataGridViewResultScreen);
            tabPageRules.ForeColor = Color.FromArgb(240, 240, 240);
            tabPageRules.Location = new Point(4, 22);
            tabPageRules.Margin = new Padding(3, 4, 3, 4);
            tabPageRules.Name = "tabPageRules";
            tabPageRules.Padding = new Padding(3, 4, 3, 4);
            tabPageRules.Size = new Size(445, 545);
            tabPageRules.TabIndex = 0;
            tabPageRules.Text = "Kural Analizi";
            // 
            // dataGridViewResultScreen
            // 
            dataGridViewResultScreen.AllowUserToAddRows = false;
            dataGridViewResultScreen.AllowUserToDeleteRows = false;
            dataGridViewResultScreen.AllowUserToResizeRows = false;
            dataGridViewResultScreen.BackgroundColor = Color.FromArgb(40, 40, 40);
            dataGridViewResultScreen.BorderStyle = BorderStyle.None;
            dataGridViewResultScreen.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewResultScreen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewResultScreen.ColumnHeadersHeight = 32;
            dataGridViewResultScreen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewResultScreen.Columns.AddRange(new DataGridViewColumn[] { MaddeAdı, Durum });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(55, 55, 55);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewResultScreen.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewResultScreen.Dock = DockStyle.Fill;
            dataGridViewResultScreen.GridColor = Color.FromArgb(60, 60, 60);
            dataGridViewResultScreen.Location = new Point(3, 4);
            dataGridViewResultScreen.Margin = new Padding(3, 4, 3, 4);
            dataGridViewResultScreen.Name = "dataGridViewResultScreen";
            dataGridViewResultScreen.ReadOnly = true;
            dataGridViewResultScreen.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewResultScreen.RowHeadersVisible = false;
            dataGridViewResultScreen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewResultScreen.ShowEditingIcon = false;
            dataGridViewResultScreen.Size = new Size(439, 537);
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
            // tabPageAI
            // 
            tabPageAI.BackColor = Color.FromArgb(40, 40, 40);
            tabPageAI.Controls.Add(rtbAIResults);
            tabPageAI.ForeColor = Color.FromArgb(240, 240, 240);
            tabPageAI.Location = new Point(4, 22);
            tabPageAI.Margin = new Padding(3, 4, 3, 4);
            tabPageAI.Name = "tabPageAI";
            tabPageAI.Padding = new Padding(3, 4, 3, 4);
            tabPageAI.Size = new Size(445, 545);
            tabPageAI.TabIndex = 1;
            tabPageAI.Text = "AI Analizi";
            // 
            // rtbAIResults
            // 
            rtbAIResults.BackColor = Color.FromArgb(40, 40, 40);
            rtbAIResults.BorderStyle = BorderStyle.None;
            rtbAIResults.Dock = DockStyle.Fill;
            rtbAIResults.Font = new Font("Segoe UI", 9.5F);
            rtbAIResults.ForeColor = Color.FromArgb(240, 240, 240);
            rtbAIResults.Location = new Point(3, 4);
            rtbAIResults.Margin = new Padding(3, 4, 3, 4);
            rtbAIResults.Name = "rtbAIResults";
            rtbAIResults.ReadOnly = true;
            rtbAIResults.Size = new Size(439, 537);
            rtbAIResults.TabIndex = 0;
            rtbAIResults.Text = "";
            // 
            // tabPageSummary
            // 
            tabPageSummary.BackColor = Color.FromArgb(40, 40, 40);
            tabPageSummary.Controls.Add(rtbSummary);
            tabPageSummary.ForeColor = Color.FromArgb(240, 240, 240);
            tabPageSummary.Location = new Point(4, 22);
            tabPageSummary.Margin = new Padding(3, 4, 3, 4);
            tabPageSummary.Name = "tabPageSummary";
            tabPageSummary.Padding = new Padding(3, 4, 3, 4);
            tabPageSummary.Size = new Size(445, 545);
            tabPageSummary.TabIndex = 3;
            tabPageSummary.Text = "Özet";
            // 
            // rtbSummary
            // 
            rtbSummary.BackColor = Color.FromArgb(40, 40, 40);
            rtbSummary.BorderStyle = BorderStyle.None;
            rtbSummary.Dock = DockStyle.Fill;
            rtbSummary.Font = new Font("Segoe UI", 9.5F);
            rtbSummary.ForeColor = Color.FromArgb(240, 240, 240);
            rtbSummary.Location = new Point(3, 4);
            rtbSummary.Margin = new Padding(3, 4, 3, 4);
            rtbSummary.Name = "rtbSummary";
            rtbSummary.ReadOnly = true;
            rtbSummary.Size = new Size(439, 537);
            rtbSummary.TabIndex = 0;
            rtbSummary.Text = "";
            // 
            // tabPageSearch
            // 
            tabPageSearch.BackColor = Color.FromArgb(40, 40, 40);
            tabPageSearch.Controls.Add(dgvSearchResults);
            tabPageSearch.ForeColor = Color.FromArgb(240, 240, 240);
            tabPageSearch.Location = new Point(4, 22);
            tabPageSearch.Margin = new Padding(3, 4, 3, 4);
            tabPageSearch.Name = "tabPageSearch";
            tabPageSearch.Padding = new Padding(3, 4, 3, 4);
            tabPageSearch.Size = new Size(445, 545);
            tabPageSearch.TabIndex = 2;
            tabPageSearch.Text = "Arama Sonuçları";
            // 
            // dgvSearchResults
            // 
            dgvSearchResults.AllowUserToAddRows = false;
            dgvSearchResults.AllowUserToDeleteRows = false;
            dgvSearchResults.AllowUserToResizeRows = false;
            dgvSearchResults.BackgroundColor = Color.FromArgb(40, 40, 40);
            dgvSearchResults.BorderStyle = BorderStyle.None;
            dgvSearchResults.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(240, 240, 240);
            dgvSearchResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvSearchResults.ColumnHeadersHeight = 28;
            dgvSearchResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvSearchResults.Columns.AddRange(new DataGridViewColumn[] { SearchIndex, SearchMatch, SearchType, SearchLine, SearchContext });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 8.5F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(55, 55, 55);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvSearchResults.DefaultCellStyle = dataGridViewCellStyle4;
            dgvSearchResults.Dock = DockStyle.Fill;
            dgvSearchResults.GridColor = Color.FromArgb(60, 60, 60);
            dgvSearchResults.Location = new Point(3, 4);
            dgvSearchResults.Margin = new Padding(3, 4, 3, 4);
            dgvSearchResults.MultiSelect = false;
            dgvSearchResults.Name = "dgvSearchResults";
            dgvSearchResults.ReadOnly = true;
            dgvSearchResults.RowHeadersVisible = false;
            dgvSearchResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSearchResults.Size = new Size(439, 537);
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
            // tabPageExtractions
            // 
            tabPageExtractions.BackColor = Color.FromArgb(40, 40, 40);
            tabPageExtractions.Controls.Add(rtbExtractions);
            tabPageExtractions.ForeColor = Color.FromArgb(240, 240, 240);
            tabPageExtractions.Location = new Point(4, 22);
            tabPageExtractions.Margin = new Padding(3, 4, 3, 4);
            tabPageExtractions.Name = "tabPageExtractions";
            tabPageExtractions.Padding = new Padding(3, 4, 3, 4);
            tabPageExtractions.Size = new Size(445, 545);
            tabPageExtractions.TabIndex = 4;
            tabPageExtractions.Text = "Çıkarılan Alanlar";
            // 
            // rtbExtractions
            // 
            rtbExtractions.BackColor = Color.FromArgb(40, 40, 40);
            rtbExtractions.BorderStyle = BorderStyle.None;
            rtbExtractions.Dock = DockStyle.Fill;
            rtbExtractions.Font = new Font("Segoe UI", 9.5F);
            rtbExtractions.ForeColor = Color.FromArgb(240, 240, 240);
            rtbExtractions.Location = new Point(3, 4);
            rtbExtractions.Margin = new Padding(3, 4, 3, 4);
            rtbExtractions.Name = "rtbExtractions";
            rtbExtractions.ReadOnly = true;
            rtbExtractions.Size = new Size(439, 537);
            rtbExtractions.TabIndex = 0;
            rtbExtractions.Text = "";
            // 
            // btnExport
            // 
            btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnExport.BackColor = Color.FromArgb(220, 53, 69);
            btnExport.CausesValidation = false;
            btnExport.Cursor = Cursors.Hand;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(389, 935);
            btnExport.Margin = new Padding(3, 4, 3, 4);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(76, 45);
            btnExport.TabIndex = 6;
            btnExport.Text = "PDF Aktar";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // btnContractManagement
            // 
            btnContractManagement.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnContractManagement.BackColor = Color.FromArgb(40, 167, 69);
            btnContractManagement.CausesValidation = false;
            btnContractManagement.Cursor = Cursors.Hand;
            btnContractManagement.FlatAppearance.BorderSize = 0;
            btnContractManagement.FlatStyle = FlatStyle.Flat;
            btnContractManagement.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnContractManagement.ForeColor = Color.White;
            btnContractManagement.Location = new Point(14, 129);
            btnContractManagement.Margin = new Padding(3, 4, 3, 4);
            btnContractManagement.Name = "btnContractManagement";
            btnContractManagement.Size = new Size(216, 45);
            btnContractManagement.TabIndex = 7;
            btnContractManagement.Text = "📂 Sözleşmeyi Yükle";
            btnContractManagement.UseVisualStyleBackColor = false;
            btnContractManagement.Click += btnContractManagement_Click;
            // 
            // btnTemplates
            // 
            btnTemplates.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnTemplates.BackColor = Color.FromArgb(40, 167, 69);
            btnTemplates.CausesValidation = false;
            btnTemplates.Cursor = Cursors.Hand;
            btnTemplates.FlatAppearance.BorderSize = 0;
            btnTemplates.FlatStyle = FlatStyle.Flat;
            btnTemplates.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnTemplates.ForeColor = Color.White;
            btnTemplates.Location = new Point(147, 935);
            btnTemplates.Margin = new Padding(3, 4, 3, 4);
            btnTemplates.Name = "btnTemplates";
            btnTemplates.Size = new Size(85, 45);
            btnTemplates.TabIndex = 8;
            btnTemplates.Text = "📄 Şablonlar";
            btnTemplates.UseVisualStyleBackColor = false;
            btnTemplates.Click += btnTemplates_Click;
            // 
            // btnManageRules
            // 
            btnManageRules.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnManageRules.BackColor = Color.FromArgb(50, 50, 50);
            btnManageRules.CausesValidation = false;
            btnManageRules.Cursor = Cursors.Hand;
            btnManageRules.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 60);
            btnManageRules.FlatStyle = FlatStyle.Flat;
            btnManageRules.Font = new Font("Segoe UI", 12F);
            btnManageRules.ForeColor = Color.FromArgb(240, 240, 240);
            btnManageRules.Location = new Point(14, 935);
            btnManageRules.Margin = new Padding(3, 4, 3, 4);
            btnManageRules.Name = "btnManageRules";
            btnManageRules.Size = new Size(34, 45);
            btnManageRules.TabIndex = 9;
            btnManageRules.Text = "⚙";
            btnManageRules.UseVisualStyleBackColor = false;
            btnManageRules.Click += btnManageRules_Click;
            // 
            // btnUpcomingDates
            // 
            btnUpcomingDates.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnUpcomingDates.BackColor = Color.FromArgb(0, 120, 215);
            btnUpcomingDates.CausesValidation = false;
            btnUpcomingDates.Cursor = Cursors.Hand;
            btnUpcomingDates.FlatAppearance.BorderSize = 0;
            btnUpcomingDates.FlatStyle = FlatStyle.Flat;
            btnUpcomingDates.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnUpcomingDates.ForeColor = Color.White;
            btnUpcomingDates.Location = new Point(240, 935);
            btnUpcomingDates.Margin = new Padding(3, 4, 3, 4);
            btnUpcomingDates.Name = "btnUpcomingDates";
            btnUpcomingDates.Size = new Size(143, 45);
            btnUpcomingDates.TabIndex = 3;
            btnUpcomingDates.Text = "📅 Yaklaşan Tarihler";
            btnUpcomingDates.UseVisualStyleBackColor = false;
            btnUpcomingDates.Click += btnUpcomingDates_Click;
            // 
            // btnSecurity
            // 
            btnSecurity.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSecurity.BackColor = Color.FromArgb(50, 50, 50);
            btnSecurity.CausesValidation = false;
            btnSecurity.Cursor = Cursors.Hand;
            btnSecurity.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 60);
            btnSecurity.FlatStyle = FlatStyle.Flat;
            btnSecurity.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnSecurity.ForeColor = Color.FromArgb(240, 240, 240);
            btnSecurity.Location = new Point(54, 935);
            btnSecurity.Margin = new Padding(3, 4, 3, 4);
            btnSecurity.Name = "btnSecurity";
            btnSecurity.Size = new Size(87, 45);
            btnSecurity.TabIndex = 12;
            btnSecurity.Text = "🔒 Güvenlik";
            btnSecurity.UseVisualStyleBackColor = false;
            btnSecurity.Click += btnSecurity_Click;
            // 
            // richTextBoxViewContract
            // 
            richTextBoxViewContract.BackColor = Color.FromArgb(40, 40, 40);
            richTextBoxViewContract.BorderStyle = BorderStyle.None;
            richTextBoxViewContract.Dock = DockStyle.Fill;
            richTextBoxViewContract.Font = new Font("Segoe UI", 10.5F);
            richTextBoxViewContract.ForeColor = Color.FromArgb(240, 240, 240);
            richTextBoxViewContract.Location = new Point(0, 0);
            richTextBoxViewContract.Margin = new Padding(3, 4, 3, 4);
            richTextBoxViewContract.Name = "richTextBoxViewContract";
            richTextBoxViewContract.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBoxViewContract.Size = new Size(981, 1000);
            richTextBoxViewContract.TabIndex = 4;
            richTextBoxViewContract.Text = "";
            richTextBoxViewContract.TextChanged += richTextBoxViewContract_TextChanged;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(3, 4, 3, 4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(pnlMenu);
            splitContainer1.Panel1MinSize = 420;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.FromArgb(40, 40, 40);
            splitContainer1.Panel2.Controls.Add(richTextBoxViewContract);
            splitContainer1.Size = new Size(1463, 1000);
            splitContainer1.SplitterDistance = 480;
            splitContainer1.SplitterWidth = 2;
            splitContainer1.TabIndex = 0;
            splitContainer1.SplitterMoved += splitContainer1_SplitterMoved;
            // 
            // MainScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(1463, 1000);
            Controls.Add(splitContainer1);
            ForeColor = Color.FromArgb(240, 240, 240);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1141, 654);
            Name = "MainScreen";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sözleşme Analiz Merkezi - CMS";
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            grpSummaryType.ResumeLayout(false);
            grpSummaryType.PerformLayout();
            tabResults.ResumeLayout(false);
            tabPageRules.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewResultScreen).EndInit();
            tabPageAI.ResumeLayout(false);
            tabPageSummary.ResumeLayout(false);
            tabPageSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSearchResults).EndInit();
            tabPageExtractions.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
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
        private Button btnSecurity;
        private RichTextBox richTextBoxViewContract;
        private ToolTip mainToolTip;
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
