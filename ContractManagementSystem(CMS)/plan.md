# Yapay Zeka Entegrasyonu - Sözleşme Analiz Merkezi (CMS)

> Bu dosya geçicidir. Tüm plan aşamaları tamamlandığında silinecektir.

---

## Proje Özeti

Mevcut WinForms .NET 8.0 sözleşme analiz uygulamasına Ollama (yerel/çevrimdışı) tabanlı yapay zeka entegrasyonu. Regex tabanlı analiz korunacak, yanına AI destekli derin analiz eklenecektir.

---

## Teknoloji Stack

| Bileşen | Mevcut | Eklenecek |
|---|---|---|
| UI | WinForms .NET 8.0 | TabControl, yeni butonlar, ProgressBar |
| Dil | C# | - |
| Veritabanı | SQL Server LocalDB + Dapper | - |
| Belge Okuma | NPOI (.docx) | - |
| PDF | iTextSharp | AI bölümü eklenecek |
| AI | - | **OllamaSharp 5.4.25 + Ollama (qwen2.5:7b)** |

---

## Aşama 1: Ollama Kurulumu ve Model Çekme

### Yapılacaklar:
- [ ] 1.1 Ollama'yı https://ollama.com adresinden indir ve kur
- [ ] 1.2 Terminal aç, `ollama --version` ile kurulumu doğrula
- [ ] 1.3 `ollama pull qwen2.5:7b` ile modeli çek (~4.4GB)
- [ ] 1.4 `ollama list` ile modelin indiğini doğrula
- [ ] 1.5 `ollama run qwen2.5:7b` ile modelin çalıştığını test et

### Doğrulama:
```bash
ollama --version
ollama list
# qwen2.5:7b listede görünmeli
```

---

## Aşama 2: NuGet Paketi Ekleme

### Yapılacaklar:
- [x] 2.1 `ContractManagementSystem(CMS).csproj` dosyasına OllamaSharp paketini ekle

### Değişiklik:
```xml
<!-- Mevcut ItemGroup'a eklenecek -->
<PackageReference Include="OllamaSharp" Version="5.4.25" />
```

---

## Aşama 3: AIService.cs Oluşturma

### Dosya: `Services/AIService.cs` (YENİ)

### Yapılacaklar:
- [x] 3.1 AIService sınıfını oluştur
- [x] 3.2 OllamaApiClient bağlantısını kur (localhost:11434, qwen2.5:7b)
- [x] 3.3 `CheckConnectionAsync()` metodunu yaz
- [x] 3.4 `AnalyzeContractAsync(string contractText, string contractType)` metodunu yaz
- [x] 3.5 `SummarizeContractAsync(string contractText)` metodunu yaz
- [x] 3.6 `SuggestFixAsync(string problematicClause, string context)` metodunu yaz

### AIService Tasarımı:

```csharp
namespace ContractManagementSystem_CMS_.Services
{
    public class AIService : IDisposable
    {
        private readonly OllamaApiClient _ollama;
        private const string Model = "qwen2.5:7b";
        private const string OllamaUrl = "http://localhost:11434";

        // AI analiz sonucu modeli
        public class AIAnalysisResult
        {
            public string Summary { get; set; }           // Genel özet
            public double RiskScore { get; set; }          // 0-100 AI risk skoru
            public string RiskLevel { get; set; }          // Düşük/Orta/Yüksek
            public List<AIModuleDetail> Details { get; set; }  // Madde bazlı detaylar
            public List<string> Recommendations { get; set; }  // Öneriler
            public string RawResponse { get; set; }        // Ham AI yanıtı
        }

        public class AIModuleDetail
        {
            public string Title { get; set; }       // Madde başlığı
            public string Content { get; set; }     // Madde içeriği
            public string Risk { get; set; }        // Risk seviyesi
            public string Explanation { get; set; } // Açıklama
        }
    }
}
```

### Prompt Tasarımı:

**Sistem Promptu (AnalyzeContractAsync):**
```
Sen bir Türk hukuku sözleşme analiz uzmanısın. Verilen sözleşmeyi analiz et ve şu formatta JSON döndür:

{
  "summary": "Sözleşmenin kısa özeti",
  "riskScore": 0-100 arası bir skor (100=risksiz, 0=çok riskli),
  "riskLevel": "Düşük Risk" | "Orta Risk" | "Yüksek Risk",
  "details": [
    {
      "title": "Madde başlığı veya konu",
      "content": "Madde ile ilgili tespit",
      "risk": "Düşük" | "Orta" | "Yüksek" | "Kritik",
      "explanation": "Bu maddenin neden riskli olduğu veya olmadığı"
    }
  ],
  "recommendations": [
    "Madde 1: ...",
    "Madde 2: ..."
  ]
}

Sadece JSON döndür, başka bir şey yazma. Türkçe yanıt ver.
```

**Sistem Promptu (SummarizeContractAsync):**
```
Verilen sözleşmeyi Türkçe olarak özetle. Özet şu bilgileri içermeli:
1. Sözleşme türü
2. Taraflar
3. Temel hükümler
4. Süre ve koşullar
5. Önemli maddeler

Kısa ve anlaşılır bir özet yaz.
```

**Sistem Promptu (SuggestFixAsync):**
```
Verilen sorunlu sözleşme maddesini analiz et ve daha iyi bir versiyonunu öner.
Türk hukuku standartlarına uygun, dengeli ve adil bir dil kullan.
Orijinal maddeyi ve önerilen düzeltmeyi sun.
```

---

## Aşama 4: UI Değişiklikleri - MainScreen.Designer.cs

### Dosya: `Forms/MainScreen.Designer.cs` (GÜNCELLENECEK)

### Yapılacaklar:
- [x] 4.1 Mevcut但onları yeniden düzenle (yer aç)
- [x] 4.2 `btnAIAnalyze` butonunu ekle
- [x] 4.3 `btnSummarize` butonunu ekle
- [x] 4.4 `tabResults` TabControl'ünü ekle (2 sekme: Kural Analizi / AI Analizi)
- [x] 4.5 `rtbAIResults` RichTextBox'ını AI Analizi sekmesine ekle
- [x] 4.6 `lblAIStatus` label'ını ekle
- [x] 4.7 `progressAI` ProgressBar'ını ekle

### Yeni Kontroller Tablosu:

| Kontrol | Tip | Boyut | Konum | Amaç |
|---|---|---|---|---|
| `btnAIAnalyze` | Button | 169x27 | pnlMenu içinde | "AI ile Analiz Et" |
| `btnSummarize` | Button | 169x27 | pnlMenu içinde | "Sözleşmeyi Özetle" |
| `tabResults` | TabControl | 383x452 | DataGridView yerine | Sonuçları sekme ile göster |
| `tabPageRules` | TabPage | - | tabResults içinde | "Kural Analizi" sekmesi |
| `tabPageAI` | TabPage | - | tabResults içinde | "AI Analizi" sekmesi |
| `rtbAIResults` | RichTextBox | TabPage'e dock | tabPageAI | AI sonuçlarını göster |
| `lblAIStatus` | Label | Otomatik | pnlMenu alt | "Ollama: Bağlı/Bağlantı Yok" |
| `progressAI` | ProgressBar | 383x20 | pnlMenu alt | AI analiz ilerleme |

### Yerleşim Planı (pnlMenu solda, ~413px genişlik):

```
pnlMenu (sol panel, DarkGray, 413px genişlik)
├── comboboxContractType (32,30) -合同 türü seçimi
├── btnFileSelection (226,32) - "Sözleşme Dosyası Seç"
├── pnlRiskStatus + lblScoreText (32,65 + 60,62) - Risk skoru
├── btnFileChecking (226,65) - "Sözleşmeyi Analiz Et"
├── btnAIAnalyze (226,95) - "AI ile Analiz Et" ← YENİ
├── btnSummarize (12,95) - "Özetle" ← YENİ
├── lblAIStatus (12,125) - "Ollama: Bağlı" ← YENİ
├── progressAI (12,145) - ProgressBar ← YENİ
├── tabResults (12,165, 383x440) ← YENİ (DataGridView yerine)
│   ├── tabPageRules
│   │   └── dataGridViewResultScreen (mevcut)
│   └── tabPageAI
│       └── rtbAIResults (RichTextBox, readonly)
├── btnExport (226,578) - "Raporu PDF Olarak Dışa Aktar"
└── btnManageRules (12,583) - "⚙" ayarlar
```

---

## Aşama 5: UI Kodları - MainScreen.cs

### Dosya: `Forms/MainScreen.cs` (GÜNCELLENECEK)

### Yapılacaklar:
- [ ] 5.1 `_aiService` field'ını ekle
- [ ] 5.2 Constructor'da AIService'i başlat ve bağlantıyı kontrol et
- [ ] 5.3 `btnAIAnalyze_Click` handler'ını yaz
- [ ] 5.4 `btnSummarize_Click` handler'ını yaz
- [ ] 5.5 `PerformAIAnalysisAsync()` metodunu yaz (regex ile eş zamanlı)
- [ ] 5.6 AI sonuçlarını `rtbAIResults`'a Formatla
- [ ] 5.7 `btnFileChecking_Click` metodunu güncelle (AI ile eş zamanlı çalıştır)
- [ ] 5.8 ProgressBar ve durum güncellemelerini ekle

### Akış Diyagramı:

```
[Sözleşme Yükle] → [Sözleşmeyi Analiz Et] tıkla
    │
    ├─ Eş Zamanlı Başlat ─────────────────────────────┐
    │                                                  │
    ▼                                                  ▼
┌─────────────────┐                    ┌──────────────────────┐
│  Regex Analizi  │                    │    AI Analizi        │
│  (Mevcut Kod)   │                    │  (Async Background)  │
│  - Pattern eşleşme│                  │  - Ollama'ya gönder   │
│  - Skor hesaplama │                  │  - JSON parse         │
│  - Highlight     │                    │  - Sonuçları formatla │
└────────┬────────┘                    └──────────┬───────────┘
         │                                        │
         ▼                                        ▼
┌─────────────────┐                    ┌──────────────────────┐
│ DataGridView    │                    │  rtbAIResults        │
│ Kural Analizi   │                    │  AI Analiz Sekmesi   │
│ sekmesinde      │                    │  - Özet               │
│ gösterilir      │                    │  - Risk skoru         │
└─────────────────┘                    │  - Madde detayları    │
                                       │  - Öneriler           │
                                       └──────────────────────┘
```

### Kritik Kod Yapısı:

```csharp
// Eş zamanlı analiz
private async void btnFileChecking_Click(object sender, EventArgs e)
{
    // ... mevcut regex analizi (async değil, mevcut kod korunur)
    var localResult = _analysisEngine.PerformAnalysis(text, selectedId);
    // ... DataGridView doldur

    // AI analizini arka planda başlat
    _ = Task.Run(async () =>
    {
        try
        {
            this.Invoke(() => {
                progressAI.Visible = true;
                progressAI.Style = ProgressBarStyle.Marquee;
                lblAIStatus.Text = "Ollama: Analiz ediliyor...";
            });

            var aiResult = await _aiService.AnalyzeContractAsync(text, contractTypeName);

            this.Invoke(() => {
                DisplayAIResults(aiResult);
                lblAIStatus.Text = "Ollama: Bağlı";
                progressAI.Visible = false;
            });
        }
        catch (Exception ex)
        {
            this.Invoke(() => {
                lblAIStatus.Text = "Ollama: Hata - " + ex.Message;
                progressAI.Visible = false;
            });
        }
    });
}
```

---

## Aşama 6: ExportService Güncellemesi

### Dosya: `Services/ExportService.cs` (GÜNCELLENECEK)

### Yapılacaklar:
- [x] 6.1 `ExportDirectToPdf` metoduna `AIAnalysisResult` parametresi ekle
- [x] 6.2 PDF'e "AI ANALİZ BULGULARI" bölümü ekle
- [x] 6.3 AI risk skorunu renkli kutu ile göster
- [x] 6.4 AI önerilerini madde madde listele
- [x] 6.5 Mevcut kodu bozmadan geriye uyumlu ekleme yap

### PDF Yeni Bölümleri:
```
Mevcut:
  ├── SÖZLEŞME ANALİZ RAPORU (başlık)
  ├── SÖZLEŞME SKORU (renkli kutu)
  └── ANALİZ BULGULARI (regex tablo)

Yeni (regex bölümünden sonra):
  └── AI ANALİZ BULGULARI
      ├── AI Risk Skoru (renkli kutu)
      ├── AI Özet
      ├── Madde Detayları (tablo)
      └── Öneriler (madde madde)
```

---

## Aşama 7: csproj Güncellemesi

### Dosya: `ContractManagementSystem(CMS).csproj` (GÜNCELLENECEK)

### Yapılacaklar:
- [ ] 7.1 OllamaSharp paket referansını ekle

### Değişiklik:
```xml
<ItemGroup>
    <PackageReference Include="Dapper" Version="2.1.72" />
    <PackageReference Include="iTextSharp" Version="5.5.13.5" />
    <PackageReference Include="NPOI" Version="2.7.6" />
    <PackageReference Include="OllamaSharp" Version="5.4.25" />  <!-- YENİ -->
    <PackageReference Include="Select.HtmlToPdf.NetCore" Version="25.2.0" />
    <PackageReference Include="System.Data.SqlClient" Version="4.9.1" />
</ItemGroup>
```

---

## Aşama 8: Test ve Doğrulama

### Yapılacaklar:
- [ ] 8.1 Projeyi derle (`dotnet build`)
- [ ] 8.2 Uygulamayı çalıştır, Ollama bağlantısını doğrula
- [ ] 8.3 Bir sözleşme yükle ve "Sözleşmeyi Analiz Et" tıkla
- [ ] 8.4 Regex sonuçlarının DataGridView'de göründüğünü doğrula
- [ ] 8.5 AI sonuçlarının "AI Analizi" sekmesinde göründüğünü doğrula
- [ ] 8.6 "Sözleşmeyi Özetle" butonunu test et
- [ ] 8.7 PDF raporunu dışa aktar, AI bölümünün PDF'de olduğunu doğrula
- [ ] 8.8 Ollama olmadığında hata mesajının düzgün göründüğünü test et
- [ ] 8.9 plan.md dosyasını sil

---

## Dosya Değişiklik Özeti

| Dosya | Durum | Açıklama |
|---|---|---|
| `Services/AIService.cs` | YENİ | Ollama AI entegrasyonu servisi |
| `Forms/MainScreen.cs` | GÜNCELLENECEK | AI buton handler'ları, eş zamanlı analiz |
| `Forms/MainScreen.Designer.cs` | GÜNCELLENECEK | Yeni kontroller (butonlar, TabControl, ProgressBar) |
| `Services/ExportService.cs` | GÜNCELLENECEK | PDF'e AI bölümü ekleme |
| `ContractManagementSystem(CMS).csproj` | GÜNCELLENECEK | OllamaSharp paketi |
| `plan.md` | SİLİNECEK | Geçici plan dosyası |

---

## Değişmeyen Dosyalar

- `Services/AnalysisEngine.cs` - Mevcut regex analiz motoru korunuyor
- `Services/DatabaseHelper.cs` - Veritabanı altyapısı korunuyor
- `Services/DatabaseService.cs` - Veri erişim korunuyor
- `Services/RuleService.cs` - Kural CRUD korunuyor
- `Services/FileService.cs` - Dosya okuma korunuyor
- `Services/WordDocumentHelper.cs` - Word okuma korunuyor
- `Extensions/RichTextBoxExtensions.cs` - Highlight korunuyor
- `Extensions/UIStyleHelper.cs` - Stil korunuyor
- `Models/ContractType.cs` - Model korunuyor
- `Models/Rules.cs` - Model korunuyor
- `Program.cs` - Giriş noktası korunuyor
- `DatabaseSetup.sql` - SQL şeması korunuyor

---

## Riskler ve Notlar

| Risk | Çözüm |
|---|---|
| Ollama çalışmıyorsa AI analizi başarısız olur | Bağlantı kontrolü + gracefully degradation (regex yeterli) |
| qwen2.5:7b Türkçe'de hatalı yanıt üretebilir | JSON parse ile hata yakalama + ham yanıtı gösterme |
| AI analizi uzun sürebilir | Async + ProgressBar + timeout (60sn) |
| Büyük sözleşmeler token limitini aşabilir | Sözleşme boyutunu kontrol et, gerekirse kırp |
| OllamaSharp API değişebilir | Dokümantasyonu kontrol et, stabil versiyon kullan |

---

## Durum Takibi

| Aşama | Durum | Tarih |
|---|---|---|
| 1. Ollama Kurulumu | ✅ Tamamlandı | - |
| 2. NuGet Paketi | ✅ Tamamlandı | - |
| 3. AIService.cs | ✅ Tamamlandı | - |
| 4. MainScreen.Designer.cs | ✅ Tamamlandı | - |
| 5. MainScreen.cs | ⏳ Bekliyor | - |
| 6. ExportService.cs | ✅ Tamamlandı | - |
| 7. csproj | ⏳ Bekliyor | - |
| 8. Test ve Doğrulama | ⏳ Bekliyor | - |
| 9. plan.md Silme | ⏳ Bekliyor | - |
