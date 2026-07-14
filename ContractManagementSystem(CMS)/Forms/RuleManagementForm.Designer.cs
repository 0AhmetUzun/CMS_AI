namespace ContractManagementSystem_CMS_.Forms
{
    partial class RuleManagementForm
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
            dgvRules = new DataGridView();
            RuleDescription = new DataGridViewTextBoxColumn();
            Pattern = new DataGridViewTextBoxColumn();
            Severity = new DataGridViewTextBoxColumn();
            txtRuleDescription = new TextBox();
            cmbContractTypes = new ComboBox();
            numSeverity = new NumericUpDown();
            btnSave = new Button();
            btnDelete = new Button();
            txtPattern = new TextBox();
            chkIsForbidden = new CheckBox();
            btnClear = new Button();
            pnlMenu = new Panel();
            lblSeverity = new Label();
            lblKeyword = new Label();
            lblRuleName = new Label();
            lblContractType = new Label();
            btnDeleteType = new Button();
            btnAddType = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRules).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSeverity).BeginInit();
            pnlMenu.SuspendLayout();
            SuspendLayout();
            // 
            // dgvRules
            // 
            dgvRules.AllowUserToAddRows = false;
            dgvRules.AllowUserToDeleteRows = false;
            dgvRules.AllowUserToResizeColumns = false;
            dgvRules.AllowUserToResizeRows = false;
            dgvRules.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRules.BackgroundColor = Color.FromArgb(40, 40, 40);
            dgvRules.BorderStyle = BorderStyle.None;
            dgvRules.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvRules.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvRules.ColumnHeadersHeight = 40;
            dgvRules.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvRules.Columns.AddRange(new DataGridViewColumn[] { RuleDescription, Pattern, Severity });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(55, 55, 55);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvRules.DefaultCellStyle = dataGridViewCellStyle2;
            dgvRules.GridColor = Color.FromArgb(60, 60, 60);
            dgvRules.Location = new Point(267, 0);
            dgvRules.Margin = new Padding(3, 4, 3, 4);
            dgvRules.Name = "dgvRules";
            dgvRules.ReadOnly = true;
            dgvRules.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvRules.RowHeadersVisible = false;
            dgvRules.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRules.Size = new Size(519, 679);
            dgvRules.TabIndex = 0;
            dgvRules.CellDoubleClick += dgvRules_CellDoubleClick;
            // 
            // RuleDescription
            // 
            RuleDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            RuleDescription.DataPropertyName = "RuleDescription";
            RuleDescription.HeaderText = "Kural Açıklaması";
            RuleDescription.Name = "RuleDescription";
            RuleDescription.ReadOnly = true;
            // 
            // Pattern
            // 
            Pattern.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Pattern.DataPropertyName = "Pattern";
            Pattern.HeaderText = "Aranacak Kelime";
            Pattern.Name = "Pattern";
            Pattern.ReadOnly = true;
            // 
            // Severity
            // 
            Severity.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Severity.DataPropertyName = "Severity";
            Severity.HeaderText = "Risk Katsayısı";
            Severity.Name = "Severity";
            Severity.ReadOnly = true;
            Severity.Width = 120;
            // 
            // txtRuleDescription
            // 
            txtRuleDescription.BackColor = Color.FromArgb(50, 50, 50);
            txtRuleDescription.BorderStyle = BorderStyle.FixedSingle;
            txtRuleDescription.Font = new Font("Segoe UI", 9.5F);
            txtRuleDescription.ForeColor = Color.FromArgb(240, 240, 240);
            txtRuleDescription.Location = new Point(14, 115);
            txtRuleDescription.Margin = new Padding(3, 4, 3, 4);
            txtRuleDescription.Name = "txtRuleDescription";
            txtRuleDescription.Size = new Size(240, 24);
            txtRuleDescription.TabIndex = 1;
            // 
            // cmbContractTypes
            // 
            cmbContractTypes.BackColor = Color.FromArgb(50, 50, 50);
            cmbContractTypes.FlatStyle = FlatStyle.Flat;
            cmbContractTypes.Font = new Font("Segoe UI", 9.5F);
            cmbContractTypes.ForeColor = Color.FromArgb(240, 240, 240);
            cmbContractTypes.FormattingEnabled = true;
            cmbContractTypes.Location = new Point(14, 56);
            cmbContractTypes.Margin = new Padding(3, 4, 3, 4);
            cmbContractTypes.Name = "cmbContractTypes";
            cmbContractTypes.Size = new Size(239, 25);
            cmbContractTypes.TabIndex = 2;
            cmbContractTypes.SelectedIndexChanged += cmbContractTypes_SelectedIndexChanged;
            // 
            // numSeverity
            // 
            numSeverity.BackColor = Color.FromArgb(50, 50, 50);
            numSeverity.BorderStyle = BorderStyle.FixedSingle;
            numSeverity.Font = new Font("Segoe UI", 9.5F);
            numSeverity.ForeColor = Color.FromArgb(240, 240, 240);
            numSeverity.Location = new Point(14, 225);
            numSeverity.Margin = new Padding(3, 4, 3, 4);
            numSeverity.Name = "numSeverity";
            numSeverity.Size = new Size(240, 24);
            numSeverity.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 120, 215);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(14, 328);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(240, 45);
            btnSave.TabIndex = 6;
            btnSave.Text = "Kural Ekle";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(14, 381);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(114, 45);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Kuralı Sil";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtPattern
            // 
            txtPattern.BackColor = Color.FromArgb(50, 50, 50);
            txtPattern.BorderStyle = BorderStyle.FixedSingle;
            txtPattern.Font = new Font("Segoe UI", 9.5F);
            txtPattern.ForeColor = Color.FromArgb(240, 240, 240);
            txtPattern.Location = new Point(14, 169);
            txtPattern.Margin = new Padding(3, 4, 3, 4);
            txtPattern.Name = "txtPattern";
            txtPattern.Size = new Size(240, 24);
            txtPattern.TabIndex = 8;
            // 
            // chkIsForbidden
            // 
            chkIsForbidden.AutoSize = true;
            chkIsForbidden.Font = new Font("Segoe UI", 9.5F);
            chkIsForbidden.ForeColor = Color.FromArgb(240, 240, 240);
            chkIsForbidden.Location = new Point(17, 272);
            chkIsForbidden.Margin = new Padding(3, 4, 3, 4);
            chkIsForbidden.Name = "chkIsForbidden";
            chkIsForbidden.Size = new Size(105, 21);
            chkIsForbidden.TabIndex = 9;
            chkIsForbidden.Text = "Yasak Madde";
            chkIsForbidden.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(50, 50, 50);
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 60);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9.5F);
            btnClear.ForeColor = Color.FromArgb(240, 240, 240);
            btnClear.Location = new Point(135, 381);
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(119, 45);
            btnClear.TabIndex = 10;
            btnClear.Text = "Temizle";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.FromArgb(30, 30, 30);
            pnlMenu.Controls.Add(lblSeverity);
            pnlMenu.Controls.Add(lblKeyword);
            pnlMenu.Controls.Add(lblRuleName);
            pnlMenu.Controls.Add(lblContractType);
            pnlMenu.Controls.Add(btnDeleteType);
            pnlMenu.Controls.Add(btnAddType);
            pnlMenu.Controls.Add(btnSave);
            pnlMenu.Controls.Add(cmbContractTypes);
            pnlMenu.Controls.Add(txtPattern);
            pnlMenu.Controls.Add(txtRuleDescription);
            pnlMenu.Controls.Add(chkIsForbidden);
            pnlMenu.Controls.Add(numSeverity);
            pnlMenu.Controls.Add(btnClear);
            pnlMenu.Controls.Add(btnDelete);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Margin = new Padding(3, 4, 3, 4);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(269, 679);
            pnlMenu.TabIndex = 11;
            // 
            // lblSeverity
            // 
            lblSeverity.AutoSize = true;
            lblSeverity.Font = new Font("Segoe UI", 9F);
            lblSeverity.ForeColor = Color.FromArgb(180, 180, 180);
            lblSeverity.Location = new Point(14, 200);
            lblSeverity.Name = "lblSeverity";
            lblSeverity.Size = new Size(105, 15);
            lblSeverity.TabIndex = 16;
            lblSeverity.Text = "Ceza Puanı (0-100)";
            // 
            // lblKeyword
            // 
            lblKeyword.AutoSize = true;
            lblKeyword.Font = new Font("Segoe UI", 9F);
            lblKeyword.ForeColor = Color.FromArgb(180, 180, 180);
            lblKeyword.Location = new Point(14, 145);
            lblKeyword.Name = "lblKeyword";
            lblKeyword.Size = new Size(95, 15);
            lblKeyword.TabIndex = 15;
            lblKeyword.Text = "Aranacak Kelime";
            // 
            // lblRuleName
            // 
            lblRuleName.AutoSize = true;
            lblRuleName.Font = new Font("Segoe UI", 9F);
            lblRuleName.ForeColor = Color.FromArgb(180, 180, 180);
            lblRuleName.Location = new Point(14, 91);
            lblRuleName.Name = "lblRuleName";
            lblRuleName.Size = new Size(94, 15);
            lblRuleName.TabIndex = 14;
            lblRuleName.Text = "Kural Açıklaması";
            // 
            // lblContractType
            // 
            lblContractType.AutoSize = true;
            lblContractType.Font = new Font("Segoe UI", 9F);
            lblContractType.ForeColor = Color.FromArgb(180, 180, 180);
            lblContractType.Location = new Point(14, 29);
            lblContractType.Name = "lblContractType";
            lblContractType.Size = new Size(84, 15);
            lblContractType.TabIndex = 13;
            lblContractType.Text = "Sözleşme Türü";
            // 
            // btnDeleteType
            // 
            btnDeleteType.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDeleteType.BackColor = Color.FromArgb(220, 53, 69);
            btnDeleteType.Cursor = Cursors.Hand;
            btnDeleteType.FlatAppearance.BorderSize = 0;
            btnDeleteType.FlatStyle = FlatStyle.Flat;
            btnDeleteType.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnDeleteType.ForeColor = Color.White;
            btnDeleteType.Location = new Point(139, 612);
            btnDeleteType.Margin = new Padding(3, 4, 3, 4);
            btnDeleteType.Name = "btnDeleteType";
            btnDeleteType.Size = new Size(114, 51);
            btnDeleteType.TabIndex = 12;
            btnDeleteType.Text = "Seçili Türü Sil";
            btnDeleteType.UseVisualStyleBackColor = false;
            btnDeleteType.Click += btnDeleteType_Click;
            // 
            // btnAddType
            // 
            btnAddType.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddType.BackColor = Color.FromArgb(40, 167, 69);
            btnAddType.Cursor = Cursors.Hand;
            btnAddType.FlatAppearance.BorderSize = 0;
            btnAddType.FlatStyle = FlatStyle.Flat;
            btnAddType.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnAddType.ForeColor = Color.White;
            btnAddType.Location = new Point(14, 612);
            btnAddType.Margin = new Padding(3, 4, 3, 4);
            btnAddType.Name = "btnAddType";
            btnAddType.Size = new Size(119, 51);
            btnAddType.TabIndex = 11;
            btnAddType.Text = "Yeni Tür Ekle";
            btnAddType.UseVisualStyleBackColor = false;
            btnAddType.Click += btnAddType_Click;
            // 
            // RuleManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(786, 679);
            Controls.Add(pnlMenu);
            Controls.Add(dgvRules);
            ForeColor = Color.FromArgb(240, 240, 240);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(800, 631);
            Name = "RuleManagementForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Kural Yönetim Ekranı";
            ((System.ComponentModel.ISupportInitialize)dgvRules).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSeverity).EndInit();
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvRules;
        private TextBox txtRuleDescription;
        private ComboBox cmbContractTypes;
        private NumericUpDown numSeverity;
        private Button btnSave;
        private Button btnDelete;
        private TextBox txtPattern;
        private CheckBox chkIsForbidden;
        private Button btnClear;
        private Panel pnlMenu;
        private Button btnAddType;
        private Button btnDeleteType;
        private Label lblSeverity;
        private Label lblKeyword;
        private Label lblRuleName;
        private Label lblContractType;
        private DataGridViewTextBoxColumn RuleDescription;
        private DataGridViewTextBoxColumn Pattern;
        private DataGridViewTextBoxColumn Severity;
    }
}
