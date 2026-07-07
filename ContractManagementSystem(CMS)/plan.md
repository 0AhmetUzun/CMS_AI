# CMS_AI - Sözleşme Yönetim Sistemi Geliştirme Planı (Final)

## Proje Amacı
Bireysel sözleşme yönetimi: yükleme, arama, analiz, özetleme, takip ve raporlama.

---

## Mevcut Durum (Zaten Yapılanlar)

### Tamamlanan Özellikler
- [x] .docx dosyası yükleme (buton + sürükle-bırak)
- [x] PDF dosyası yükleme (sürükle-bırak)
- [x] 4 sözleşme tipi (Kira, İş, Satış, Danışmanlık)
- [x] Kural tabanlı analiz (regex pattern matching)
- [x] Risk puanı hesaplama (100 - ceza puanları)
- [x] AI analizi (Ollama + qwen2.5:7b)
- [x] AI sözleşme özetleme
- [x] PDF dışa aktarma
- [x] Kural yönetimi (CRUD)
- [x] Dark tema UI

### Kullanılan Teknolojiler
- .NET 8.0 WinForms
- SQL Server LocalDB + Dapper ORM
- Ollama (yerel LLM - qwen2.5:7b)
- NPOI (.docx) + iTextSharp (PDF)

---

## Faz 1: Dosya Yükleme + Klasör/Etiketleme (İyileştirme)
**Durum:** Tamamlandı (Kısmi) | **Öncelik:** Yüksek | **Tamamlanma Tarihi:** Temmuz 2026

### Tamamlananlar
- [x] PDF dosyası desteği (sadece .docx değil)
- [x] Otomatik metin çıkarma (PDF için)

### İptal Edilenler (Bu projede uygulanmayacak)
- [ ] ~~Kullanıcı etiketleri (kişiselleştirilmiş etiketleme)~~ → İptal
- [ ] ~~Karşı taraf adı alanı~~ → İptal
- [ ] ~~Durum alanı: Taslak / İmzalandı / Yürürlükte / Feshedildi~~ → İptal
- [ ] ~~Yıl veya proje bilgisi~~ → İptal
- [ ] ~~"Akıllı öneri": Benzer sözleşmeleri aynı gruba öner~~ → İptal
- [ ] ~~Sözleşme başlangıç/bitiş tarihi (çıkarma veya elle girme)~~ → İptal
- [ ] ~~Tutar/para birimi bilgisi~~ → İptal
- [ ] ~~İlgili not alanı (1-2 cümle)~~ → İptal

### Notlar
- Bu fazda sadece PDF desteği uygulandı, diğer maddeler projenin kapsamı dışında bırakıldı

---

## Faz 2: Hızlı Arama + Doğal Dil Arama
**Durum:** Hiç başlanmamış | **Öncelik:** Yüksek

### Arama Türleri
- [ ] Alan filtresi: karşı taraf + tür + durum + tarih aralığı
- [ ] Anahtar kelime araması: "fesih", "cezai şart", "teminat", "ödeme"
- [ ] Doğal dil araması (Ollama ile):
  - "30 gün içinde fesih var mı?"
  - "Ödeme tarihi net mi?"
  - "Otomatik yenileme var mı?"

### Sonuç Görünümü
- [ ] Hangi sözleşme + kaçıncı madde/nerede geçtiği (sayfa/madde)
- [ ] Anahtar cümlenin highlight'ı
- [ ] Yazım varyasyonları eşleştirme ("cezai şart/cezai şartlar")

### Teknik Detay
- RichTextBox.Find() ile temel arama
- Ollama ile doğal dil sorgusu
- Büyük docx için indeks/önbellekleme

---

## Faz 3: Otomatik Özet (Executive Summary)
**Durum:** Kısmen mevcut | **Öncelik:** Yüksek

### Mevcut
- [x] AI sözleşme özetleme (AIService.SummarizeContractAsync)

### Eklenecekler
- [ ] Özet şablonu:
  - Amaç/kapsam (1-2 cümle)
  - Taraflar & ilişki
  - Süre & başlangıç/bitiş
  - Fesih & yenileme
  - Ödeme/tutar
  - Kritik yükümlülükler (3-5 madde)
  - Risk/uyarılar
- [ ] "Kısaltılmış özet (5 madde)" / "Detaylı özet (1 sayfa)" seçeneği
- [ ] Kaynak gösterimi (her özet maddesinin altında belge bağlantısı)

---

## Faz 4: Madde/Alan Çıkarımı (Structured Extraction)
**Durum:** Kısmen mevcut | **Öncelik:** Yüksek

### Mevcut
- [x] AI analizinde JSON çıktı var

### Eklenecekler
- [ ] Çıkarılacak alanlar:
  - Başlangıç/bitiş tarihi
  - Süre (12 ay, 1 yıl)
  - Fesih türleri (bildirim süresi, olağan/olağanüstü)
  - Yenileme (otomatik var mı, bildirim süresi)
  - Ödeme (tutar, para birimi, vade, gecikme cezası)
  - Cezai şart / teminat / SLA
- [ ] "Bu sözleşmede şu alanlar bulundu/bulunamadı" gösterimi
- [ ] Alan boş ise kullanıcı düzenleme kutusu
- [ ] Düzeltilen verileri kaydetme

### Veritabanı
```sql
CREATE TABLE ContractExtractions (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ContractId INT,
    FieldName NVARCHAR(100),
    FieldValue NVARCHAR(500),
    IsManuallyEdited BIT DEFAULT 0,
    FOREIGN KEY (ContractId) REFERENCES Contracts(Id)
);
```

---

## Faz 5: Kritik Tarihler Kartı + Hatırlatıcı
**Durum:** Hiç başlanmamış | **Öncelik:** Yüksek

### Kartlar
- [ ] Yaklaşan bitiş tarihi
- [ ] Yaklaşan fesih bildirimi son tarihi
- [ ] Yaklaşan ödeme tarihi
- [ ] Yenileme uyarısı

### Mantık
- [ ] "Bitişten X gün önce fesih mümkün" kuralı (belgeden hesapla)
- [ ] Kalan gün sayısı gösterimi

### Görünüm
- [ ] Ana ekranda "Yaklaşan Tarihler" paneli
- [ ] Aylık liste + "yarın/3 gün/7 gün" filtresi
- [ ] Uygulama açıldığında uyarı

---

## Faz 6: Risk/Uyarılar Kontrol Listesi
**Durum:** Kısmen mevcut | **Öncelik:** Orta

### Mevcut
- [x] Kural tabanlı risk tespiti (AnalysisEngine)
- [x] Risk puanı hesaplama

### Eklenecekler
- [ ] Belirsiz süre tespiti ("Süre TBD", net tarih yok)
- [ ] Belirsiz fesih tespiti (bildirim süresi yok)
- [ ] Otomatik yenileme kontrolü (iptal bildirimi yoksa)
- [ ] Aşırı cezai şart kontrolü
- [ ] Çelişki kontrolü (fesih vs yenileme süre uyuşmazlığı)
- [ ] Ödeme belirsizliği ("Eylem gerçekleştiğinde" gibi ifadeler)
- [ ] Risk başlığı + kısa açıklama + ilgili madde linki
- [ ] "İncelendi" / "Düzeltildi" işaretleme

---

## Faz 7: Versiyon Takibi + İki Sürüm Karşılaştırma
**Durum:** Hiç başlanmamış | **Öncelik:** Orta

### Versiyonlama
- [ ] Aynı sözleşme adının altında V1/V2/V3
- [ ] "Final" işareti (imzalanan sürüm)

### Karşılaştırma
- [ ] Madde bazlı değişiklik listesi
  - "Fesih bildirim süresi: 30 gün → 45 gün"
  - "Ödeme vadeleri: Net 15 → Net 30"
- [ ] Highlight: değişen cümlenin bulunduğu yer
- [ ] 3-5 maddelik "değişiklik özeti"

### Kullanıcı
- [ ] "Bu değişiklik kabul edildi/kabul edilmedi" notu

---

## Faz 8: Basit Sözleşme Şablonları + Alan Doldurma
**Durum:** Hiç başlanmamış | **Öncelik:** Orta

### Şablon Kütüphanesi (3-5 tane)
- [ ] NDA (tek taraf/karşı taraf)
- [ ] Hizmet sözleşmesi
- [ ] Satış/teklif
- [ ] Kira (basit)

### Şablon Alanları
- [ ] Taraflar
- [ ] Konu/kapsam
- [ ] Süre
- [ ] Ödeme
- [ ] Fesih/yenileme
- [ ] Ekler (teslimat listesi)

### AI Rolü (Opsiyonel)
- [ ] Kullanıcı metnini şablona "uygun madde" olarak yerleştirme önerisi
- [ ] Her zaman kullanıcı onayıyla

---

## Faz 9: Dışa Aktarma (Export)
**Durum:** Kısmen mevcut | **Öncelik:** Orta

### Mevcut
- [x] PDF rapor oluşturma (ExportService)

### Eklenecekler
- [ ] Özet PDF (sadece özet bölümü)
- [ ] CSV dışa aktarma (alanlar bazında)
- [ ] Belge + açıklamalar (tek PDF)
- [ ] "Sadece kritik maddeleri" export seçeneği
- [ ] Madde numarası/sayfa ekleme
- [ ] Kullanıcı notlarını ayrı katman olarak ekleme

---

## Faz 10: Güvenlik (Bireysel Kullanıcı İçin Basitleştirilmiş)
**Durum:** Hiç başlanmamış | **Öncelik:** Orta

### Temel
- [ ] Uygulama açılışında PIN/parola (isteğe bağlı)
- [ ] Cihaz kilidi ile otomatik kapanma (idle sonrası)

### Dosya
- [ ] Dosya şifreleme (cihaz depolama şifreleme varsa kullan)

### Gizlilik
- [ ] "Gizli mod": Özet ekranında tutar/risk metnini maskeleme

---

## Faz 11: Raporlama ve İstatistikler (Yeni)
**Durum:** Hiç başlanmamış | **Öncelik:** Orta

### Dashboard
- [ ] Toplam sözleşme sayısı
- [ ] Sözleşme türü dağılımı (grafik)
- [ ] Risk dağılımı (yeşil/sarı/kırmızı)
- [ ] Yaklaşan tarihler özeti
- [ ] Aylık/yıllık analiz raporları

### Basit Grafikler
- [ ] Pie chart: Sözleşme türleri
- [ ] Bar chart: Aylık yükleme sayısı
- [ ] Gauge: Ortalama risk puanı

---

## Faz 12: Toplu İşlemler (Yeni)
**Durum:** Hiç başlanmamış | **Öncelik:** Düşük

### Toplu Yükleme
- [ ] Birden fazla sözleşme aynı anda yükleme
- [ ] Klasörden toplu import

### Toplu Düzenleme
- [ ] Çoklu sözleşme silme
- [ ] Toplu etiket ekleme/değiştirme

---

## Faz 13: Yedekleme Sistemi (Yeni)
**Durum:** Hiç başlanmamış | **Öncelik:** Orta

### Manuel Yedekleme
- [ ] Tek tıkla yedekleme butonu
- [ ] Yedek dosyasını seçme (kaydetme konumu)
- [ ] .bak formatında yedek

### Geri Yükleme
- [ ] Yedekten geri yükleme (onay ile)
- [ ] Yedekleme listesi gösterme

### Otomatik Yedekleme
- [ ] Haftalık otomatik yedekleme
- [ ] Son yedekleme tarihi gösterimi

---

## Faz 14: OCR Desteği (Yeni)
**Durum:** Hiç başlanmamış | **Öncelik:** Düşük

### Taranmış PDF
- [ ] Resim/taranmış PDF'lerden metin çıkarma
- [ ] Tesseract OCR entegrasyonu
- [ ] Türkçe karakter desteği

---

## Faz 15: Klavye Kısayolları (Yeni)
**Durum:** Hiç başlanmamış | **Öncelik:** Düşük

### Kısayollar
- Ctrl+F: Arama
- Ctrl+E: PDF Export
- Ctrl+N: Yeni sözleşme yükle
- Ctrl+B: Yedekle
- Ctrl+G: Gizli mod aç/kapa

---

## Bireysel Kullanıcı İçin Basitleştirmeler

| Özellik | Durum | Açıklama |
|---------|-------|----------|
| Kullanıcı girişi | Basitleştir | Sadece PIN (isteğe bağlı) |
| Rol/izin sistemi | Kaldır | Tek kullanıcı |
| Audit trail | Kaldır | Gerek yok |
| Çoklu dil | Kaldır | Türkçe yeterli |
| İmza entegrasyonu | Kaldır | Gerek yok |
| E-posta bildirim | Kaldır | Uygulama içi yeterli |

---

## Veritabanı Yapısı (Final)

```sql
-- Mevcut tablolar
ContractTypes (Id, TypeName)
Rules (Id, TypeId, RuleDescription, Pattern, IsForbidden, Severity)

-- Yeni tablolar
Contracts (
    Id, FileName, Content, TypeName,
    PartyName, Status, Year,
    StartDate, EndDate, Amount, Currency,
    Description, IsSigned,
    VersionNumber DEFAULT 1,
    CreatedAt, UpdatedAt
);

ContractVersions (
    Id, ContractId, VersionNumber, Content,
    Notes, CreatedAt
);

ContractDates (
    Id, ContractId, DateType, DateValue,
    ReminderDays DEFAULT 30, IsNotified DEFAULT 0
);

ContractNotes (
    Id, ContractId, NoteText, CreatedAt
);

ContractExtractions (
    Id, ContractId, FieldName, FieldValue,
    IsManuallyEdited DEFAULT 0
);

Tags (Id, TagName);
ContractTags (ContractId, TagId);

ContractTemplates (
    Id, TemplateName, TemplateType, Content,
    CreatedAt
);

Backups (
    Id, BackupPath, BackupSize, CreatedAt
);
```

---

## Geliştirme Sırası ve Süre Tahminleri

| Sıra | Faz | Durum | Süre |
|------|-----|-------|------|
| 1 | Faz 1: PDF + Dosya Yükleme | Tamamlandı (Kısmi) | Tamamlandı |
| 2 | Faz 2: Arama | Yeni | 1 hafta |
| 3 | Faz 4: Alan Çıkarımı | İyileştirme | 1-2 hafta |
| 4 | Faz 3: Otomatik Özet İyileştirme | İyileştirme | 3-4 gün |
| 5 | Faz 5: Kritik Tarihler | Yeni | 1 hafta |
| 6 | Faz 6: Risk Kontrolü İyileştirme | İyileştirme | 4-5 gün |
| 7 | Faz 8: Sözleşme Şablonları | Yeni | 1 hafta |
| 8 | Faz 7: Versiyon Takibi | Yeni | 1-2 hafta |
| 9 | Faz 9: Export İyileştirme | İyileştirme | 3-4 gün |
| 10 | Faz 10: Güvenlik | Yeni | 3-4 gün |
| 11 | Faz 13: Yedekleme | Yeni | 2-3 gün |
| 12 | Faz 11: Raporlama | Yeni | 1 hafta |
| 13 | Faz 15: Kısayollar | Yeni | 1 gün |
| 14 | Faz 12: Toplu İşlemler | Yeni | 1 hafta |
| 15 | Faz 14: OCR | Yeni | 1-2 hafta |

**Toplam Tahmini Süre:** 12-16 hafta

---

## Özet/Ana Ekran Yapısı

```
┌──────────────────────────────────────────────────────────────────┐
│  [Sözleşme Yükle]  [Ara: ___________]  [PDF] [CSV] [Yedekle]     │
├──────────────────────────────────────────────────────────────────┤
│  Sol Panel (300px)            │  Sağ Panel                       │
│  ─────────────────            │  ─────────                       │
│  Sözleşme Tipi ▼              │  [Kural] [AI] [Özet] [Tarihler]  │
│  Dosya: xxx.docx              │  ┌────────────────────────────┐  │
│  Durum: Taslak ▼              │  │                            │  │
│  ─────────────────            │  │  Seçilen Sekmenin İçeriği  │  │
│  Risk Puanı: 85               │  │                            │  │
│  [████████░░] Yeşil           │  │  • Kural analiz sonuçları  │  │
│  ─────────────────            │  │  • AI analiz özeti         │  │
│  Yaklaşan Tarihler:           │  │  • Çıkarılmış alanlar      │  │
│  • Bitiş: 15 gün kaldı        │  │  • Kritik tarihler         │  │
│  • Fesih: 30 gün              │  │                            │  │
│  • Ödeme: 5 Temmuz            │  │                            │  │
│  ─────────────────            │  └────────────────────────────┘  │
│  Son Notlar:                  │  ─────────                       │
│  • 01.07: İmzalandı           │  Not: ________________           │
│  • 28.06: Revize edildi       │  [Kaydet]                        │
│  ─────────────────            │                                  │
│  [Hızlı Not Ekle]             │                                  │
└──────────────────────────────────────────────────────────────────┘
```

---

## Mevcut Sorunlar ve Çözümler

| Sorun | Çözüm |
|-------|-------|
| OllamaSharp paketi kullanılmıyor | Kaldır veya HttpClient yerine kullan |
| Select.HtmlToPdf.NetCore kullanılmıyor | Kaldır |
| appsettings.json yok | Ekle |
| Unit test yok | xUnit ile basit testler |
| Hata loglama yok | Serilog veya NLog ekle |
| Dependency injection yok | .NET 8 built-in DI kullan |

---

## MVP Tanımı (Nihai)

**Tamamlananlar (Mevcut):**
- ✅ Dosya yükleme (.docx + PDF)
- ✅ Kural tabanlı analiz
- ✅ AI analizi ve özetleme
- ✅ PDF export
- ✅ Kural yönetimi
- ✅ Dark tema

**Eklenecekler (MVP için gerekli):**
1. ➕ Anahtar kelime araması
2. ➕ Yapılandırılmış alan çıkarma
3. ➕ Kritik tarih takibi
4. ➕ Hızlı notlar

**Sonraki Aşama:**
6. Versiyon takibi
7. Şablonlar
8. Export iyileştirmeleri
9. Yedekleme
10. Raporlama

---

## Notlar

- Bu plan bireysel kullanıcı için optimize edilmiştir
- Çoklu kullanıcı özellikleri (rol, izin, audit trail) kaldırılmıştır
- Her faz bağımsız olarak test edilebilir
- Mevcut özellikler bozulmadan yeni özellikler eklenmelidir
