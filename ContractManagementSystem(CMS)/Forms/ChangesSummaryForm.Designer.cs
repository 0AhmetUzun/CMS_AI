namespace ContractManagementSystem_CMS_.Forms
{
    partial class ChangesSummaryForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblContractName = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblChangedCount = new System.Windows.Forms.Label();
            this.lblChangedTitle = new System.Windows.Forms.Label();
            this.flowChanged = new System.Windows.Forms.FlowLayoutPanel();
            this.lblUnchangedTitle = new System.Windows.Forms.Label();
            this.flowUnchanged = new System.Windows.Forms.FlowLayoutPanel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnUndoAll = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelButtons.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(280, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📝 Değişiklik Özeti";
            // 
            // lblContractName
            // 
            this.lblContractName.AutoSize = true;
            this.lblContractName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblContractName.Location = new System.Drawing.Point(20, 55);
            this.lblContractName.Name = "lblContractName";
            this.lblContractName.Size = new System.Drawing.Size(150, 20);
            this.lblContractName.TabIndex = 1;
            this.lblContractName.Text = "📄 Sözleşme Adı";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDate.Location = new System.Drawing.Point(20, 80);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(150, 15);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "📅 Tarih";
            // 
            // lblChangedCount
            // 
            this.lblChangedCount.AutoSize = true;
            this.lblChangedCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblChangedCount.Location = new System.Drawing.Point(20, 105);
            this.lblChangedCount.Name = "lblChangedCount";
            this.lblChangedCount.Size = new System.Drawing.Size(200, 19);
            this.lblChangedCount.TabIndex = 3;
            this.lblChangedCount.Text = "⚠️ X alan değiştirildi";
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.lblContractName);
            this.panelHeader.Controls.Add(this.lblDate);
            this.panelHeader.Controls.Add(this.lblChangedCount);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(720, 130);
            this.panelHeader.TabIndex = 10;
            // 
            // lblChangedTitle
            // 
            this.lblChangedTitle.AutoSize = true;
            this.lblChangedTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblChangedTitle.Location = new System.Drawing.Point(20, 140);
            this.lblChangedTitle.Name = "lblChangedTitle";
            this.lblChangedTitle.Size = new System.Drawing.Size(200, 19);
            this.lblChangedTitle.TabIndex = 4;
            this.lblChangedTitle.Text = "✏️ DEĞİŞEN ALANLAR";
            // 
            // flowChanged
            // 
            this.flowChanged.AutoScroll = true;
            this.flowChanged.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowChanged.Location = new System.Drawing.Point(20, 165);
            this.flowChanged.Name = "flowChanged";
            this.flowChanged.Size = new System.Drawing.Size(680, 250);
            this.flowChanged.TabIndex = 5;
            this.flowChanged.WrapContents = false;
            // 
            // lblUnchangedTitle
            // 
            this.lblUnchangedTitle.AutoSize = true;
            this.lblUnchangedTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUnchangedTitle.Location = new System.Drawing.Point(20, 425);
            this.lblUnchangedTitle.Name = "lblUnchangedTitle";
            this.lblUnchangedTitle.Size = new System.Drawing.Size(250, 19);
            this.lblUnchangedTitle.TabIndex = 6;
            this.lblUnchangedTitle.Text = "📋 DEĞİŞMEYEN ALANLAR";
            // 
            // flowUnchanged
            // 
            this.flowUnchanged.AutoScroll = true;
            this.flowUnchanged.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowUnchanged.Location = new System.Drawing.Point(20, 450);
            this.flowUnchanged.Name = "flowUnchanged";
            this.flowUnchanged.Size = new System.Drawing.Size(680, 150);
            this.flowUnchanged.TabIndex = 7;
            this.flowUnchanged.WrapContents = false;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnConfirm);
            this.panelButtons.Controls.Add(this.btnUndoAll);
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 610);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(720, 60);
            this.panelButtons.TabIndex = 8;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.Location = new System.Drawing.Point(20, 12);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(150, 36);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "✓ Kaydet";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnUndoAll
            // 
            this.btnUndoAll.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnUndoAll.Location = new System.Drawing.Point(180, 12);
            this.btnUndoAll.Name = "btnUndoAll";
            this.btnUndoAll.Size = new System.Drawing.Size(180, 36);
            this.btnUndoAll.TabIndex = 1;
            this.btnUndoAll.Text = "↩️ Tümünü Geri Al";
            this.btnUndoAll.UseVisualStyleBackColor = false;
            this.btnUndoAll.Click += new System.EventHandler(this.btnUndoAll_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.Location = new System.Drawing.Point(370, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 36);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "✕ İptal";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ChangesSummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = ContractManagementSystem_CMS_.Extensions.UIStyleHelper.PrimaryBg;
            this.ClientSize = new System.Drawing.Size(720, 670);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.lblChangedTitle);
            this.Controls.Add(this.flowChanged);
            this.Controls.Add(this.lblUnchangedTitle);
            this.Controls.Add(this.flowUnchanged);
            this.Controls.Add(this.panelButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangesSummaryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Değişiklik Özeti";
            this.panelButtons.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblContractName;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblChangedCount;
        private System.Windows.Forms.Label lblChangedTitle;
        private System.Windows.Forms.FlowLayoutPanel flowChanged;
        private System.Windows.Forms.Label lblUnchangedTitle;
        private System.Windows.Forms.FlowLayoutPanel flowUnchanged;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnUndoAll;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Panel panelHeader;
    }
}
