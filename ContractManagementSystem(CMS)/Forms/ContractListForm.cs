using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ContractManagementSystem_CMS_.Extensions;
using ContractManagementSystem_CMS_.Models;
using ContractManagementSystem_CMS_.Services;

namespace ContractManagementSystem_CMS_.Forms
{
    public partial class ContractListForm : Form
    {
        private readonly ContractService _contractService;
        private readonly DatabaseService _dbService;
        private readonly FileService _fileService;
        private ContractListItem? _selectedContract;

        public ContractListItem? SelectedContract { get; private set; }

        public ContractListForm()
        {
            InitializeComponent();
            _contractService = new ContractService();
            _dbService = new DatabaseService();
            _fileService = new FileService();
            ApplyTheme();
            LoadContractTypes();
            LoadContracts();
        }

        private void ApplyTheme()
        {
            this.BackColor = UIStyleHelper.PrimaryBg;
            this.ForeColor = UIStyleHelper.PrimaryText;

            lblTitle.ForeColor = UIStyleHelper.AccentBlue;
            lblSearch.ForeColor = UIStyleHelper.SecondaryText;
            txtSearch.BackColor = UIStyleHelper.AccentBg;
            txtSearch.ForeColor = UIStyleHelper.PrimaryText;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;

            cmbFilter.BackColor = UIStyleHelper.AccentBg;
            cmbFilter.ForeColor = UIStyleHelper.PrimaryText;
            cmbFilter.FlatStyle = FlatStyle.Flat;

            btnSearch.BackColor = UIStyleHelper.AccentBlue;
            btnSearch.ForeColor = Color.White;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.FlatAppearance.BorderSize = 0;

            btnRefresh.BackColor = UIStyleHelper.AccentBg;
            btnRefresh.ForeColor = UIStyleHelper.PrimaryText;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.FlatAppearance.BorderColor = UIStyleHelper.BorderColor;
            btnRefresh.FlatAppearance.BorderSize = 1;

            btnOpen.BackColor = UIStyleHelper.AccentGreen;
            btnOpen.ForeColor = Color.White;
            btnOpen.FlatStyle = FlatStyle.Flat;
            btnOpen.FlatAppearance.BorderSize = 0;

            btnDetail.BackColor = UIStyleHelper.AccentBlue;
            btnDetail.ForeColor = Color.White;
            btnDetail.FlatStyle = FlatStyle.Flat;
            btnDetail.FlatAppearance.BorderSize = 0;

            btnDelete.BackColor = UIStyleHelper.AccentRed;
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;

            lblContractType.ForeColor = UIStyleHelper.SecondaryText;
            cmbContractType.BackColor = UIStyleHelper.AccentBg;
            cmbContractType.ForeColor = UIStyleHelper.PrimaryText;
            cmbContractType.FlatStyle = FlatStyle.Flat;

            btnUpload.BackColor = UIStyleHelper.AccentPurple;
            btnUpload.ForeColor = Color.White;
            btnUpload.FlatStyle = FlatStyle.Flat;
            btnUpload.FlatAppearance.BorderSize = 0;

            UIStyleHelper.ApplyModernTableTheme(dgvContracts);
        }

        private void LoadContracts()
        {
            try
            {
                var contracts = _contractService.GetAllContracts();
                dgvContracts.Rows.Clear();

                foreach (var contract in contracts)
                {
                    string riskLevel = contract.RiskScore >= 75 ? "🟢" : contract.RiskScore >= 40 ? "🟡" : "🔴";
                    dgvContracts.Rows.Add(
                        contract.Id,
                        contract.FileName,
                        contract.TypeName ?? "Belirsiz",
                        $"{contract.RiskScore} {riskLevel}",
                        contract.CreatedAt.ToString("dd.MM.yyyy")
                    );
                }

                lblStatus.Text = $"Toplam: {contracts.Count} sözleşme";
                UpdateStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sözleşmeler yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadContractTypes()
        {
            try
            {
                var allTypes = _dbService.GetAllTypes();
                if (allTypes?.Count > 0)
                {
                    cmbContractType.DataSource = allTypes;
                    cmbContractType.DisplayMember = "TypeName";
                    cmbContractType.ValueMember = "Id";
                    cmbContractType.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sözleşme türleri yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatistics()
        {
            try
            {
                var stats = _contractService.GetStatistics();
                lblStats.Text = $"🟢 Güvenli: {stats.SafeCount} | 🟡 Orta: {stats.MediumRiskCount} | 🔴 Yüksek: {stats.HighRiskCount}";
            }
            catch
            {
                lblStats.Text = "";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearch.Text.Trim();
                string filterType = cmbFilter.SelectedItem?.ToString() ?? "Tümü";
                
                var contracts = _contractService.FilterContracts(searchText, filterType);
                dgvContracts.Rows.Clear();

                foreach (var contract in contracts)
                {
                    string riskLevel = contract.RiskScore >= 75 ? "🟢" : contract.RiskScore >= 40 ? "🟡" : "🔴";
                    dgvContracts.Rows.Add(
                        contract.Id,
                        contract.FileName,
                        contract.TypeName ?? "Belirsiz",
                        $"{contract.RiskScore} {riskLevel}",
                        contract.CreatedAt.ToString("dd.MM.yyyy")
                    );
                }

                lblStatus.Text = $"{contracts.Count} sözleşme bulundu";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Arama sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbFilter.SelectedIndex = 0;
            LoadContracts();
        }

        private void dgvContracts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvContracts.Rows.Count)
            {
                int contractId = Convert.ToInt32(dgvContracts.Rows[e.RowIndex].Cells[0].Value);
                _selectedContract = _contractService.GetContractDetail(contractId);
                btnOpen.Enabled = true;
                btnDetail.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (_selectedContract != null)
            {
                SelectedContract = _selectedContract;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (_selectedContract != null)
            {
                var detailForm = new ContractDetailForm(_selectedContract);
                detailForm.ShowDialog();
                LoadContracts();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedContract == null) return;

            var result = MessageBox.Show(
                $"'{_selectedContract.FileName}' dosyasını silmek istediğinize emin misiniz?\n\nBu işlem geri alınamaz!",
                "Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _contractService.DeleteContract(_selectedContract.Id);
                    MessageBox.Show("Sözleşme başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _selectedContract = null;
                    btnOpen.Enabled = false;
                    btnDetail.Enabled = false;
                    btnDelete.Enabled = false;
                    LoadContracts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Silme sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSearch.PerformClick();
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (cmbContractType.SelectedValue == null || !int.TryParse(cmbContractType.SelectedValue.ToString(), out int _))
            {
                MessageBox.Show("Lütfen bir sözleşme türü seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (OpenFileDialog ofd = new OpenFileDialog { Filter = "Tüm Sözleşme Dosyaları|*.docx;*.pdf|Word Belgesi (*.docx)|*.docx|PDF Dosyası (*.pdf)|*.pdf" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filePath = ofd.FileName;
                        string content = _fileService.ReadDocument(filePath);
                        string fileName = Path.GetFileName(filePath);
                        string typeName = cmbContractType.Text;

                        _contractService.CreateContract(fileName, filePath, content, typeName, 0);

                        MessageBox.Show("Sözleşme başarıyla yüklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadContracts();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Sözleşme yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
