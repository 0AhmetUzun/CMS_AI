namespace ContractManagementSystem_CMS_.Forms
{
    partial class RuleManagementForm
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
            dgvRules.AllowUserToResizeColumns = false;
            dgvRules.AllowUserToResizeRows = false;
            dgvRules.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRules.BackgroundColor = Color.White;
            dgvRules.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvRules.Columns.AddRange(new DataGridViewColumn[] { RuleDescription, Pattern, Severity });
            dgvRules.Location = new Point(234, 0);
            dgvRules.Name = "dgvRules";
            dgvRules.ReadOnly = true;
            dgvRules.RowHeadersVisible = false;
            dgvRules.Size = new Size(454, 509);
            dgvRules.TabIndex = 0;
            dgvRules.CellDoubleClick += dgvRules_CellDoubleClick;
            // 
            // RuleDescription
            // 
            RuleDescription.DataPropertyName = "RuleDescription";
            RuleDescription.HeaderText = "Kural Açıklaması";
            RuleDescription.Name = "RuleDescription";
            RuleDescription.ReadOnly = true;
            RuleDescription.Width = 150;
            // 
            // Pattern
            // 
            Pattern.DataPropertyName = "Pattern";
            Pattern.HeaderText = "Aranacak Kelime";
            Pattern.Name = "Pattern";
            Pattern.ReadOnly = true;
            Pattern.Width = 175;
            // 
            // Severity
            // 
            Severity.DataPropertyName = "Severity";
            Severity.HeaderText = "Risk Katsayısı";
            Severity.Name = "Severity";
            Severity.ReadOnly = true;
            Severity.Width = 125;
            // 
            // txtRuleDescription
            // 
            txtRuleDescription.BorderStyle = BorderStyle.None;
            txtRuleDescription.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtRuleDescription.Location = new Point(12, 86);
            txtRuleDescription.Name = "txtRuleDescription";
            txtRuleDescription.Size = new Size(152, 19);
            txtRuleDescription.TabIndex = 1;
            // 
            // cmbContractTypes
            // 
            cmbContractTypes.FlatStyle = FlatStyle.Flat;
            cmbContractTypes.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            cmbContractTypes.FormattingEnabled = true;
            cmbContractTypes.Location = new Point(12, 42);
            cmbContractTypes.Name = "cmbContractTypes";
            cmbContractTypes.Size = new Size(152, 24);
            cmbContractTypes.TabIndex = 2;
            cmbContractTypes.SelectedIndexChanged += cmbContractTypes_SelectedIndexChanged;
            // 
            // numSeverity
            // 
            numSeverity.BorderStyle = BorderStyle.None;
            numSeverity.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            numSeverity.Location = new Point(12, 169);
            numSeverity.Name = "numSeverity";
            numSeverity.Size = new Size(120, 18);
            numSeverity.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.System;
            btnSave.Font = new Font("Arial", 9F);
            btnSave.Location = new Point(12, 246);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 30);
            btnSave.TabIndex = 6;
            btnSave.Text = "Kural Ekle";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.System;
            btnDelete.Font = new Font("Arial", 9F);
            btnDelete.Location = new Point(12, 282);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 30);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Kuralı Sil";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtPattern
            // 
            txtPattern.BorderStyle = BorderStyle.None;
            txtPattern.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtPattern.Location = new Point(12, 127);
            txtPattern.Name = "txtPattern";
            txtPattern.Size = new Size(100, 19);
            txtPattern.TabIndex = 8;
            // 
            // chkIsForbidden
            // 
            chkIsForbidden.AutoSize = true;
            chkIsForbidden.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            chkIsForbidden.Location = new Point(15, 204);
            chkIsForbidden.Name = "chkIsForbidden";
            chkIsForbidden.Size = new Size(122, 20);
            chkIsForbidden.TabIndex = 9;
            chkIsForbidden.Text = "Yasaklı Madde ?";
            chkIsForbidden.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.System;
            btnClear.Font = new Font("Arial", 9F);
            btnClear.Location = new Point(12, 318);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 30);
            btnClear.TabIndex = 10;
            btnClear.Text = "Formu Temizle";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.DarkGray;
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
            lblSeverity.Font = new Font("Arial", 11.25F);
            lblSeverity.Location = new Point(12, 149);
            lblSeverity.Name = "lblSeverity";
            lblSeverity.Size = new Size(100, 17);
            lblSeverity.TabIndex = 16;
            lblSeverity.Text = "Risk Katsayısı";
            // 
            // lblKeyword
            // 
            lblKeyword.AutoSize = true;
            lblKeyword.Font = new Font("Arial", 11.25F);
            lblKeyword.Location = new Point(12, 108);
            lblKeyword.Name = "lblKeyword";
            lblKeyword.Size = new Size(118, 17);
            lblKeyword.TabIndex = 15;
            lblKeyword.Text = "Aranacak Kelime";
            // 
            // lblRuleName
            // 
            lblRuleName.AutoSize = true;
            lblRuleName.Font = new Font("Arial", 11.25F);
            lblRuleName.Location = new Point(12, 66);
            lblRuleName.Name = "lblRuleName";
            lblRuleName.Size = new Size(115, 17);
            lblRuleName.TabIndex = 14;
            lblRuleName.Text = "Kural Açıklaması";
            // 
            // lblContractType
            // 
            lblContractType.AutoSize = true;
            lblContractType.Font = new Font("Arial", 11.25F);
            lblContractType.Location = new Point(12, 22);
            lblContractType.Name = "lblContractType";
            lblContractType.Size = new Size(108, 17);
            lblContractType.TabIndex = 13;
            lblContractType.Text = "Sözleşme Türü";
            // 
            // btnDeleteType
            // 
            btnDeleteType.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDeleteType.FlatAppearance.BorderSize = 0;
            btnDeleteType.FlatStyle = FlatStyle.System;
            btnDeleteType.Font = new Font("Arial", 9F);
            btnDeleteType.Location = new Point(130, 459);
            btnDeleteType.Name = "btnDeleteType";
            btnDeleteType.Size = new Size(102, 38);
            btnDeleteType.TabIndex = 12;
            btnDeleteType.Text = "Seçili Türü Kurallarıyla Sil";
            btnDeleteType.UseVisualStyleBackColor = true;
            btnDeleteType.Click += btnDeleteType_Click;
            // 
            // btnAddType
            // 
            btnAddType.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddType.FlatAppearance.BorderSize = 0;
            btnAddType.FlatStyle = FlatStyle.System;
            btnAddType.Font = new Font("Arial", 9F);
            btnAddType.Location = new Point(12, 459);
            btnAddType.Name = "btnAddType";
            btnAddType.Size = new Size(94, 38);
            btnAddType.TabIndex = 11;
            btnAddType.Text = "Yeni Sözleşme Türü Ekle";
            btnAddType.UseVisualStyleBackColor = true;
            btnAddType.Click += btnAddType_Click;
            // 
            // RuleManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(688, 509);
            Controls.Add(pnlMenu);
            Controls.Add(dgvRules);
            MinimumSize = new Size(702, 483);
            Name = "RuleManagementForm";
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