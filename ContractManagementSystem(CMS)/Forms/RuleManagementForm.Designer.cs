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
            dgvRules.BackgroundColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryBg;
            dgvRules.BorderStyle = BorderStyle.None;
            dgvRules.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBg;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            dataGridViewCellStyle1.SelectionBackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBg;
            dataGridViewCellStyle1.SelectionForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvRules.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvRules.ColumnHeadersHeight = 40;
            dgvRules.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvRules.Columns.AddRange(new DataGridViewColumn[] { RuleDescription, Pattern, Severity });
            dgvRules.DefaultCellStyle.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryBg;
            dgvRules.DefaultCellStyle.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            dgvRules.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvRules.DefaultCellStyle.SelectionBackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.HoverColor;
            dgvRules.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvRules.GridColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.BorderColor;
            dgvRules.Location = new Point(234, 0);
            dgvRules.Name = "dgvRules";
            dgvRules.ReadOnly = true;
            dgvRules.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvRules.RowHeadersVisible = false;
            dgvRules.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRules.Size = new Size(454, 509);
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
            Severity.Width = 100;
            // 
            // txtRuleDescription
            // 
            txtRuleDescription.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBg;
            txtRuleDescription.BorderStyle = BorderStyle.FixedSingle;
            txtRuleDescription.Font = new Font("Segoe UI", 9.5F);
            txtRuleDescription.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            txtRuleDescription.Location = new Point(12, 86);
            txtRuleDescription.Name = "txtRuleDescription";
            txtRuleDescription.Size = new Size(210, 24);
            txtRuleDescription.TabIndex = 1;
            // 
            // cmbContractTypes
            // 
            cmbContractTypes.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBg;
            cmbContractTypes.FlatStyle = FlatStyle.Flat;
            cmbContractTypes.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            cmbContractTypes.Font = new Font("Segoe UI", 9.5F);
            cmbContractTypes.FormattingEnabled = true;
            cmbContractTypes.Location = new Point(12, 42);
            cmbContractTypes.Name = "cmbContractTypes";
            cmbContractTypes.Size = new Size(210, 25);
            cmbContractTypes.TabIndex = 2;
            cmbContractTypes.SelectedIndexChanged += cmbContractTypes_SelectedIndexChanged;
            // 
            // numSeverity
            // 
            numSeverity.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBg;
            numSeverity.BorderStyle = BorderStyle.FixedSingle;
            numSeverity.Font = new Font("Segoe UI", 9.5F);
            numSeverity.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            numSeverity.Location = new Point(12, 169);
            numSeverity.Name = "numSeverity";
            numSeverity.Size = new Size(210, 24);
            numSeverity.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBlue;
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(12, 246);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(210, 34);
            btnSave.TabIndex = 6;
            btnSave.Text = "Kural Ekle";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentRed;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(12, 286);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 34);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Kuralı Sil";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtPattern
            // 
            txtPattern.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBg;
            txtPattern.BorderStyle = BorderStyle.FixedSingle;
            txtPattern.Font = new Font("Segoe UI", 9.5F);
            txtPattern.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            txtPattern.Location = new Point(12, 127);
            txtPattern.Name = "txtPattern";
            txtPattern.Size = new Size(210, 24);
            txtPattern.TabIndex = 8;
            // 
            // chkIsForbidden
            // 
            chkIsForbidden.AutoSize = true;
            chkIsForbidden.Font = new Font("Segoe UI", 9.5F);
            chkIsForbidden.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            chkIsForbidden.Location = new Point(15, 204);
            chkIsForbidden.Name = "chkIsForbidden";
            chkIsForbidden.Size = new Size(120, 19);
            chkIsForbidden.TabIndex = 9;
            chkIsForbidden.Text = "Yasaklı Madde ?";
            chkIsForbidden.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentBg;
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.BorderColor;
            btnClear.FlatAppearance.BorderSize = 1;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9.5F);
            btnClear.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            btnClear.Location = new Point(118, 286);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(104, 34);
            btnClear.TabIndex = 10;
            btnClear.Text = "Temizle";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryBg;
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
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(235, 509);
            pnlMenu.TabIndex = 11;
            // 
            // lblSeverity
            // 
            lblSeverity.AutoSize = true;
            lblSeverity.Font = new Font("Segoe UI", 9F);
            lblSeverity.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryText;
            lblSeverity.Location = new Point(12, 150);
            lblSeverity.Name = "lblSeverity";
            lblSeverity.Size = new Size(90, 15);
            lblSeverity.TabIndex = 16;
            lblSeverity.Text = "Risk Katsayısı";
            // 
            // lblKeyword
            // 
            lblKeyword.AutoSize = true;
            lblKeyword.Font = new Font("Segoe UI", 9F);
            lblKeyword.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryText;
            lblKeyword.Location = new Point(12, 109);
            lblKeyword.Name = "lblKeyword";
            lblKeyword.Size = new Size(100, 15);
            lblKeyword.TabIndex = 15;
            lblKeyword.Text = "Aranacak Kelime";
            // 
            // lblRuleName
            // 
            lblRuleName.AutoSize = true;
            lblRuleName.Font = new Font("Segoe UI", 9F);
            lblRuleName.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryText;
            lblRuleName.Location = new Point(12, 68);
            lblRuleName.Name = "lblRuleName";
            lblRuleName.Size = new Size(100, 15);
            lblRuleName.TabIndex = 14;
            lblRuleName.Text = "Kural Açıklaması";
            // 
            // lblContractType
            // 
            lblContractType.AutoSize = true;
            lblContractType.Font = new Font("Segoe UI", 9F);
            lblContractType.ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.SecondaryText;
            lblContractType.Location = new Point(12, 22);
            lblContractType.Name = "lblContractType";
            lblContractType.Size = new Size(90, 15);
            lblContractType.TabIndex = 13;
            lblContractType.Text = "Sözleşme Türü";
            // 
            // btnDeleteType
            // 
            btnDeleteType.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDeleteType.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentRed;
            btnDeleteType.Cursor = Cursors.Hand;
            btnDeleteType.FlatAppearance.BorderSize = 0;
            btnDeleteType.FlatStyle = FlatStyle.Flat;
            btnDeleteType.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnDeleteType.ForeColor = Color.White;
            btnDeleteType.Location = new Point(122, 459);
            btnDeleteType.Name = "btnDeleteType";
            btnDeleteType.Size = new Size(100, 38);
            btnDeleteType.TabIndex = 12;
            btnDeleteType.Text = "Seçili Türü Sil";
            btnDeleteType.UseVisualStyleBackColor = false;
            btnDeleteType.Click += btnDeleteType_Click;
            // 
            // btnAddType
            // 
            btnAddType.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddType.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.AccentGreen;
            btnAddType.Cursor = Cursors.Hand;
            btnAddType.FlatAppearance.BorderSize = 0;
            btnAddType.FlatStyle = FlatStyle.Flat;
            btnAddType.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnAddType.ForeColor = Color.White;
            btnAddType.Location = new Point(12, 459);
            btnAddType.Name = "btnAddType";
            btnAddType.Size = new Size(104, 38);
            btnAddType.TabIndex = 11;
            btnAddType.Text = "Yeni Tür Ekle";
            btnAddType.UseVisualStyleBackColor = false;
            btnAddType.Click += btnAddType_Click;
            // 
            // RuleManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryBg;
            ClientSize = new Size(688, 509);
            Controls.Add(pnlMenu);
            Controls.Add(dgvRules);
            ForeColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryText;
            MinimumSize = new Size(702, 483);
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
