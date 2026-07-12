using ContractManagementSystem_CMS_.Extensions;

namespace ContractManagementSystem_CMS_.Forms
{
    partial class DateManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel _flpCards;
        private System.Windows.Forms.DataGridView _dgvMonth;
        private System.Windows.Forms.TabControl _tabControl;
        private System.Windows.Forms.Panel topPanel;

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
            this._tabControl = new System.Windows.Forms.TabControl();
            this._flpCards = new System.Windows.Forms.FlowLayoutPanel();
            this._dgvMonth = new System.Windows.Forms.DataGridView();
            this.topPanel = new System.Windows.Forms.Panel();
            System.Windows.Forms.Label lblFilter = new System.Windows.Forms.Label();
            System.Windows.Forms.TabPage tabCards = new System.Windows.Forms.TabPage();
            System.Windows.Forms.TabPage tabMonth = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this._dgvMonth)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = UIStyleHelper.SecondaryBg;
            topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            topPanel.Location = new System.Drawing.Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            topPanel.Size = new System.Drawing.Size(1000, 56);
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.ForeColor = UIStyleHelper.SecondaryText;
            lblFilter.Location = new System.Drawing.Point(12, 16);
            lblFilter.Name = "lblFilter";
            lblFilter.Text = "Filtre:";
            this.topPanel.Controls.Add(lblFilter);
            // 
            // _tabControl
            // 
            this._tabControl.BackColor = UIStyleHelper.PrimaryBg;
            this._tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabControl.Location = new System.Drawing.Point(0, 56);
            this._tabControl.Name = "_tabControl";
            this._tabControl.Padding = new System.Drawing.Point(10, 4);
            this._tabControl.Size = new System.Drawing.Size(1000, 604);
            // 
            // _flpCards
            // 
            this._flpCards.AutoScroll = true;
            this._flpCards.BackColor = UIStyleHelper.SecondaryBg;
            this._flpCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flpCards.Name = "_flpCards";
            this._flpCards.Padding = new System.Windows.Forms.Padding(12);
            this._flpCards.WrapContents = true;
            // 
            // tabCards
            // 
            tabCards.BackColor = UIStyleHelper.SecondaryBg;
            tabCards.ForeColor = UIStyleHelper.PrimaryText;
            tabCards.Name = "tabCards";
            tabCards.Text = "Kartlar";
            tabCards.Controls.Add(this._flpCards);
            // 
            // _dgvMonth
            // 
            this._dgvMonth.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvMonth.Location = new System.Drawing.Point(0, 0);
            this._dgvMonth.Margin = new System.Windows.Forms.Padding(10);
            this._dgvMonth.Name = "_dgvMonth";
            this._dgvMonth.SelectionChanged += new System.EventHandler(this.DgvMonth_SelectionChanged);
            // 
            // tabMonth
            // 
            tabMonth.BackColor = UIStyleHelper.SecondaryBg;
            tabMonth.ForeColor = UIStyleHelper.PrimaryText;
            tabMonth.Name = "tabMonth";
            tabMonth.Text = "Aylık Liste";
            tabMonth.Controls.Add(this._dgvMonth);
            // 
            // DateManagementForm
            // 
            this._tabControl.TabPages.Add(tabCards);
            this._tabControl.TabPages.Add(tabMonth);
            this.Controls.Add(this._tabControl);
            this.Controls.Add(topPanel);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = UIStyleHelper.PrimaryBg;
            this.ClientSize = new System.Drawing.Size(1000, 660);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ForeColor = UIStyleHelper.PrimaryText;
            this.Name = "DateManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Yaklaşan Tarihler ve Hatırlatıcılar";
            ((System.ComponentModel.ISupportInitialize)(this._dgvMonth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
