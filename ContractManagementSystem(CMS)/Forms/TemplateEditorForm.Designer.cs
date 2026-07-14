using ContractManagementSystem_CMS_.Extensions;

namespace ContractManagementSystem_CMS_.Forms
{
    partial class TemplateEditorForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

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
            txtName = new TextBox();
            cmbType = new ComboBox();
            txtContent = new TextBox();
            lblHint = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            lblName = new Label();
            lblType = new Label();
            lblContent = new Label();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(12, 36);
            txtName.Name = "txtName";
            txtName.Size = new Size(640, 27);
            txtName.TabIndex = 0;
            // 
            // cmbType
            // 
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.FlatStyle = FlatStyle.Flat;
            cmbType.Location = new Point(12, 92);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(640, 28);
            cmbType.TabIndex = 1;
            // 
            // txtContent
            // 
            txtContent.Font = new Font("Consolas", 9.5F);
            txtContent.Location = new Point(12, 148);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.ScrollBars = ScrollBars.Vertical;
            txtContent.Size = new Size(640, 320);
            txtContent.TabIndex = 2;
            // 
            // lblHint
            // 
            lblHint.Font = new Font("Segoe UI", 8.5F);
            lblHint.ForeColor = Color.FromArgb(180, 180, 180);
            lblHint.Location = new Point(12, 476);
            lblHint.Name = "lblHint";
            lblHint.Size = new Size(640, 32);
            lblHint.TabIndex = 3;
            lblHint.Text = "İpucu: [[Taraf1]] [[Taraf2]] [[Konu]] [[BaslangicTarihi]] [[BitisTarihi]] [[Sure]] [[Odeme]] [[FesihYenileme]] [[Ekler]] gibi alanlar, üretim sırasında otomatik form haline gelir.";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(471, 519);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(90, 30);
            btnSave.TabIndex = 3;
            btnSave.Text = "Kaydet";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(569, 519);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(80, 30);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "İptal";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += BtnCancel_Click;
            // 
            // lblName
            // 
            lblName.Location = new Point(12, 14);
            lblName.Name = "lblName";
            lblName.Size = new Size(120, 20);
            lblName.TabIndex = 0;
            lblName.Text = "Şablon Adı:";
            // 
            // lblType
            // 
            lblType.Location = new Point(12, 70);
            lblType.Name = "lblType";
            lblType.Size = new Size(120, 20);
            lblType.TabIndex = 1;
            lblType.Text = "Türü:";
            // 
            // lblContent
            // 
            lblContent.Location = new Point(12, 126);
            lblContent.Name = "lblContent";
            lblContent.Size = new Size(640, 20);
            lblContent.TabIndex = 2;
            lblContent.Text = "Şablon Metni (alanlar [[AlanAdi]] şeklinde yazılır):";
            // 
            // TemplateEditorForm
            // 
            ClientSize = new Size(664, 561);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblType);
            Controls.Add(cmbType);
            Controls.Add(lblContent);
            Controls.Add(txtContent);
            Controls.Add(lblHint);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TemplateEditorForm";
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private Label lblType;
        private Label lblContent;
    }
}
