# CMS_AI - Sözleşme Yönetim Sistemi Geliştirme Planı (Final)

> **Son Güncelleme:** Temmuz 2026
> **Şu anki aşama:** Faz 1-6, Faz 8, **Faz 9**, **Faz 10 (Güvenlik - PIN kilidi + idle kilit)** ve **Faz 15 (Klavye Kısayolları + Tooltip)** tamamlandı. **Faz 7 (Versiyon Takibi) ertelendi/gerekmez.** **Faz 11 (Raporlama), Faz 12 (Toplu İşlemler) ve Faz 13 (Yedekleme) kullanıcı kararıyla iptal edildi.** **Faz 14 (OCR) kullanıcı kararıyla atlandı** (uygulama zaten PDF metnini içe alabiliyor). Kalan: yok.

## Proje Amacı
Bireysel sözleşme yönetimi: yükleme, arama, analiz, özetleme, takip ve raporlama.

---

## Mevcut Durum (Zaten Yapılanlar)

### Tamamlanan Fazlar
- **Faz 1:** Dosya Yükleme + PDF Desteği ✅
- **Faz 2:** Hızlı Arama + Doğal Dil Arama ✅
- **Faz 3:** Otomatik Özet (Executive Summary) ✅
- **Faz 4:** Madde/Alan Çıkarımı (Structured Extraction) ✅
- **Faz 5:** Kritik Tarihler Kartı + Hatırlatıcı ✅
- **Faz 6:** Risk/Uyarılar Kontrol Listesi (Kapsam daraltıldı + araştırmaya dayalı genişletildi) ✅
- **Faz 8:** Basit Sözleşme Şablonları + Alan Doldurma ✅

### Henüz Başlanmayan Fazlar
- ~~**Faz 7:** Versiyon Takibi + İki Sürüm Karşılaştırma~~ → **Ertelendi / Gerekmez** (sözleşmeler tek seferlik imzalı arşivlendiği için)
- ~~**Faz 10:** Güvenlik~~ → **Tamamlandı** (PIN kilidi + idle kilit; dosya şifreleme ve gizli mod kapsam dışı)
- ~~**Faz 11:** Raporlama ve İstatistikler~~ → **İptal edildi** (kullanıcı kararı)
- ~~**Faz 12:** Toplu İşlemler~~ → **İptal edildi** (kullanıcı kararı)
- ~~**Faz 13:** Yedekleme Sistemi~~ → **İptal edildi** (kullanıcı kararı)
- ~~**Faz 14:** OCR Desteği~~ → **Atlandı** (uygulama zaten PDF içe alıyor; kullanıcı kararı)
- ~~**Faz 15:** Klavye Kısayolları~~ → **Tamamlandı** (Ctrl+F / Ctrl+E / Ctrl+N + hover tooltip)

### Tamamlanan Özellikler
- [x] .docx dosyası yükleme (buton + sürükle-bırak)
- [x] PDF dosyası yükleme (sürükle-bırak)
- [x] 10 sözleşme tipi (Kira, İş, Satış, Danışmanlık, Hizmet, Ödünç/Kredi, Sigorta, Bayilik, Gizlilik NDA, Abonelik)
- [x] Kural tabanlı analiz (regex pattern matching)
- [x] Risk puanı hesaplama (100 - ceza puanları)
- [x] AI analizi (Ollama + qwen2.5:7b)
- [x] AI sözleşme özetleme
- [x] PDF dışa aktarma
- [x] Kural yönetimi (CRUD)
- [x] Dark tema UI
- [x] Anahtar kelime araması
- [x] Doğal dil araması
- [x] Yapılandırılmış alan çıkarma (13 alan)
- [x] Değişiklik takibi ve geri alma

### Kullanılan Teknolojiler
- .NET 8.0 WinForms
- SQL Server LocalDB + Dapper ORM
- Ollama (yerel LLM - qwen2.5:7b)
- NPOI (.docx) + iTextSharp (PDF)

---

## Faz 1: Dosya Yükleme + Klasör/Etiketleme (İyileştirme)
**Durum:** Tamamlandı | **Öncelik:** Yüksek | **Tamamlanma Tarihi:** Temmuz 2026

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
**Durum:** Tamamlandı | **Öncelik:** Yüksek | **Tamamlanma Tarihi:** Temmuz 2026

### Arama Türleri
- [x] Anahtar kelime araması: "fesih", "cezai şart", "teminat", "ödeme"
- [x] Doğal dil araması (Ollama ile):
  - "30 gün içinde fesih var mı?"
  - "Ödeme tarihi net mi?"
  - "Otomatik yenileme var mı?"

### Sonuç Görünümü
- [x] Kaçıncı madde/nerede geçtiği (satır no ile)
- [x] Anahtar cümlenin highlight'ı
- [x] Arama sonuçları sekmesinde listelenme

### Teknik Detay
- SearchService ile temel metin arama
- Ollama ile doğal dil sorgusu

---

## Faz 3: Otomatik Özet (Executive Summary)
**Durum:** Tamamlandı | **Öncelik:** Yüksek

### Mevcut
- [x] AI sözleşme özetleme (AIService.SummarizeContractAsync)

### Eklenecekler
- [x] Özet şablonu:
  - Amaç/kapsam (1-2 cümle)
  - Taraflar & ilişki
  - Süre & başlangıç/bitiş
  - Fesih & yenileme
  - Ödeme/tutar
  - Kritik yükümlülükler (3-5 madde)
  - Risk/uyarılar
- [x] "Kısaltılmış özet (5 madde)" / "Detaylı özet (1 sayfa)" seçeneği
- [x] Kaynak gösterimi (her özet maddesinin altında belge bağlantısı)

---

## Faz 4: Madde/Alan Çıkarımı (Structured Extraction)
**Durum:** Tamamlandı | **Öncelik:** Yüksek | **Tamamlanma Tarihi:** Temmuz 2026

### Mevcut
- [x] AI analizinde JSON çıktı var

### Tamamlananlar
- [x] Çıkarılacak alanlar:
  - Başlangıç/bitiş tarihi
  - Süre (12 ay, 1 yıl)
  - Fesih türleri (bildirim süresi, olağan/olağanüstü)
  - Yenileme (otomatik var mı, bildirim süresi)
  - Ödeme (tutar, para birimi, vade, gecikme cezası)
    - Cezai şart / teminat / SLA
- [x] "Bu sözleşmede şu alanlar bulundu/bulunamadı" gösterimi
- [x] Alan boş ise kullanıcı düzenleme kutusu
- [x] Düzeltilen verileri kaydetme

### Notlar
- ExtractionService.cs ile AI tabanlı alan çıkarma uygulandı
- ContractDetailForm.cs ile kullanıcı düzenleme arayüzü tamamlandı
- ChangesSummaryForm.cs ile değişiklik takibi eklendi

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
**Durum:** Tamamlandı | **Öncelik:** Yüksek | **Tamamlanma Tarihi:** Temmuz 2026

### Veritabanı
- [x] `ContractDates` tablosu eklendi (Id, ContractId, DateType, DateValue, ReminderDays, IsNotified, Note, CreatedAt)
- [x] `DatabaseHelper.EnsureTablesExist` ile mevcut veritabanlarına otomatik uygulandı

### Kartlar
- [x] Yaklaşan bitiş tarihi
- [x] Yaklaşan fesih bildirimi son tarihi (Bitiş - FesihBildirimSuresi)
- [x] Yaklaşan ödeme tarihi (Başlangıç + ÖdemeVadesi)
- [x] Yenileme uyarısı (yenileme "Otomatik" ise, Bitiş - YenilemeBildirimSuresi)

### Mantık
- [x] "Bitişten X gün önce fesih mümkün" kuralı (çıkarımlardan hesaplanır)
- [x] Kalan gün sayısı gösterimi (renkli: kırmızı geçti, turuncu ≤7 gün, yeşil)

### Görünüm
- [x] Açılışta uyarı pop-up'ı: yakın tarih varsa `UpcomingDatesForm` gösterilir, yoksa normal açılır
- [x] "📅 Yaklaşan Tarihler" butonu ile `DateManagementForm` (Kartlar + Aylık Liste sekmeleri)
- [x] Filtreler: Yarın / 3 Gün / 7 Gün / Bu Ay / Tümü
- [x] Manuel tarih ekleme / düzenleme / silme

### Notlar
- Tarihler AI alan çıkarımından (`ExtractionService`) otomatik türetilir, manuel düzenlemeye izin verir
- `DateReminderService` Türkçe tarih formatlarını (gg.aa.yyyy, "15 Temmuz 2026" vb.) parse eder
- `OdemeVadesi` somut tarih değilse ("Net 30") başlangıç tarihinden türetilir, parse edilemezse atlanır

---

## Faz 6: Risk/Uyarılar Kontrol Listesi
**Durum:** Tamamlandı (kapsam daraltıldı + araştırmaya dayalı genişletildi) | **Öncelik:** Orta | **Tamamlanma Tarihi:** Temmuz 2026

### Yaklaşım
Karmaşık bir "Risk Kontrol" sekmesi / "İncelendi" işaretleme UI'ı yapılmadı. Bunun yerine Faz 6'nın
**tespit** işlevi, mevcut kanallardan (Kural Analizi + AI Analizi sekmeleri) karşılandı:
- Sözleşme türü bazında zenginleştirilmiş `Rules` veritabanı (regex, deterministik).
- Güçlendirilmiş AI prompt (red-flag, çelişki, belirsizlik, TKHK/TBK özel maddeler).

### Mevcut
- [x] Kural tabanlı risk tespiti (AnalysisEngine)
- [x] Risk puanı hesaplama

### Eklenenler (araştırmaya dayalı — TermScout/Sirion/BRAVE Legal + TBK 6098 / TKHK)
- [x] Sözleşme türleri 4 → 10 çıkarıldı (Hizmet, Ödünç/Kredi, Sigorta, Bayilik, Gizlilik NDA, Abonelik)
- [x] Tür bazlı ~44 yeni kural (`DatabaseHelper.SeedDefaultData` ile idempotent tohumlanır)
- [x] Belirsiz süre / belirsiz fesih → zorunlu kural desenleri
- [x] Otomatik yenileme uyarısı → yasaklı kural (özellikle Abonelik'te kritik red flag)
- [x] Ödeme belirsizliği → yasaklı kural (ör. "eylem gerçekleştiğinde")
- [x] AI prompt: aşırı cezai şart, fesih-yenileme çelişkisi, muğlak ifadeler, sınırsız sorumluluk, haksız şart/cayma hakkı (TKHK)
- [x] AI `details.content` alanına ilgili madde alıntısı eklenmesi (kısmi "madde linki")

### Kapsam Dışı (bilinçli olarak atlandı — UI karmaşası engellendi)
- [x] Ayrı "Risk Kontrol" sekmesi
- [x] "İncelendi" / "Düzeltildi" işaretleme UI'ı
- [x] Not: "Aşırı cezai şart" ve "çelişki" kontrolleri saf regex ile ifade edilemediği için AI tarafından yakalanır (Ollama kapalıyken bu ikisi atlanır; deterministik kurallar her zaman çalışır).

---

## Faz 7: Versiyon Takibi + İki Sürüm Karşılaştırma
**Durum:** Ertelendi / Gerekmez | **Öncelik:** Düşük (uygulanmayabilir)

> **Karar (Temmuz 2026):** Sözleşmeler tek seferlik, imzalı olarak arşivlendiği için
> versiyon geçmişi ve sürüm karşılaştırması kullanım senaryosunda değer yaratmıyor.
> Bu faz **ertelendi**. Bağlı olduğu `Contracts.VersionNumber` ve `ContractVersions`
> tablosu da artık plan dışıdır.

### Versiyonlama
- [ ] ~~Aynı sözleşme adının altında V1/V2/V3~~ → Ertelendi
- [ ] ~~"Final" işareti (imzalanan sürüm)~~ → Ertelendi

### Karşılaştırma
- [ ] ~~Madde bazlı değişiklik listesi~~ → Ertelendi
- [ ] ~~Highlight: değişen cümlenin bulunduğu yer~~ → Ertelendi
- [ ] ~~3-5 maddelik "değişiklik özeti"~~ → Ertelendi

### Kullanıcı
- [ ] ~~"Bu değişiklik kabul edildi/kabul edilmedi" notu~~ → Ertelendi

---

## Faz 8: Basit Sözleşme Şablonları + Alan Doldurma
**Durum:** Tamamlandı | **Öncelik:** Orta | **Tamamlanma Tarihi:** Temmuz 2026

### Yaklaşım
Plan.md'deki orijinal kapsam daraltıldı: AI'ın "metni otomatik uygun maddeye yerleştirmesi" özelliği çıkarıldı;
yerine **kullanıcının onaylayıp düzenleyebildiği** "AI ile Madde Oluştur" butonu eklendi. Üretilen taslak
yalnızca diske `.docx` olarak kaydedilir (arşive otomatik eklenmez).

### Şablon Kütüphanesi (4 hazır şablon, idempotent tohumlanır)
- [x] Gizlilik Sözleşmesi (NDA)
- [x] Hizmet Sözleşmesi
- [x] Satış / Teklif Sözleşmesi
- [x] Kira Sözleşmesi (Basit)
- [x] Kullanıcının kendi şablonunu oluşturma / düzenleme / silme (hazır olanlar korunur)

### Şablon Alanları (placeholder tabanlı, otomatik form)
- [x] `[[Taraf1]]`, `[[Taraf2]]`, `[[Konu]]`, `[[Kapsam]]`
- [x] `[[BaslangicTarihi]]`, `[[BitisTarihi]]`, `[[Sure]]`
- [x] `[[Odeme]]`, `[[OdemeVadesi]]`, `[[Teminat]]`, `[[CezaiSart]]`
- [x] `[[FesihYenileme]]`, `[[Teslimat]]`, `[[Garanti]]`, `[[CaymaHakki]]`, `[[Ekler]]`
- [x] Placeholder'lar şablondan otomatik çıkarılır → üretim formunda dinamik alanlar oluşur

### Üretim
- [x] NPOI ile `.docx` yazma (`WordDocumentHelper.WriteDocument`)
- [x] Doldurulmamış placeholder'lar temizlenir
- [x] Başlık satırları ortalanır/kalınlaşır

### AI Rolü (Onaylı tek buton)
- [x] "AI" butonu → serbest metinden madde taslağı üretir (`AIService.DraftClauseAsync`)
- [x] Sonuç alana eklenir, **kullanıcı düzenleyip** kaydedebilir
- [x] Ollama kapalıysa buton bilgilendirir, işlem engellenir

### Teknik
- `ContractTemplates` tablosu (`DatabaseHelper.EnsureTablesExist` + `SeedDefaultTemplates`)
- `Models/ContractTemplate.cs`, `Services/TemplateService.cs`
- `Forms/TemplateListForm.cs`, `TemplateEditorForm.cs`, `GenerateFromTemplateForm.cs`
- `MainScreen` → "📄 Şablonlar" butonu (pnlMenu alt bar)

---

## Faz 9: Dışa Aktarma (Export) İyileştirme
**Durum:** Tamamlandı | **Öncelik:** Orta | **Tamamlanma Tarihi:** Temmuz 2026

### Mevcut
- [x] PDF rapor oluşturma (ExportService)

### Uygulananlar (netleşen kapsam)
- [x] **Tam Rapor PDF** korundu (`btnExport` / "PDF Aktar" değişmedi) — kural + AI bulguları + açıklamalar tek PDF.
- [x] **Sayfa numarası ekleme** — her sayfada footer'da `Sayfa X` (iTextSharp `PdfPageEventHelper`).
- [x] **Madde numaralandırma** — kural bulguları `[1], [2]…`, AI maddeleri `[1], [2]…` ve AI önerileri `1. 2.…` şeklinde numaralandırıldı.
- [x] **Kullanıcı notlarını ayrı katman** — mevcut `ContractDate.Note` alanları ("Kullanıcı Notları" bölümü olarak, tarih tipi + not metniyle) PDF sonuna eklendi. Yeni not sistemi kurulmadı; sadece mevcut notlar.

### Kapsam Dışı (kullanıcı kararıyla çıkarıldı)
- [ ] ~~Özet PDF (sadece özet bölümü)~~ → İstenmedi, eklenmedi.
- [ ] ~~CSV dışa aktarma~~ → İstenmedi, eklenmedi.
- [ ] ~~"Sadece kritik maddeleri" export seçeneği~~ → İstenmedi, eklenmedi.

### Teknik
- `DatabaseService.GetDatesByContractId(int)` eklendi (ContractDates + Note).
- `ExportService.ExportDirectToPdf` imzasına `List<ContractDate>? dates = null` eklendi (geriye dönük uyumlu).
- `MainScreen.btnExport_Click` → mevcut sözleşme id'sinden (`_currentContractId`) notları çekip PDF'e gönderir.

---

## Faz 10: Güvenlik (Bireysel Kullanıcı İçin Basitleştirilmiş)
**Durum:** Tamamlandı | **Öncelik:** Orta | **Tamamlanma Tarihi:** Temmuz 2026

### Kapsam Kararı (Temmuz 2026)
Kullanıcı kararıyla kapsam daraltıldı:
- **Yapılanlar:** İsteğe bağlı PIN/parola kilidi + idle (boşta kalma) sonrası otomatik kilit.
- **Ertelendi / Kapsam Dışı:** Dosya/veritabanı şifreleme ve "Gizli mod" maskeleme — sonraki faza bırakıldı.

### Temel (Tamamlananlar)
- [x] **İsteğe bağlı PIN kilidi:** `AppSettings` tablosunda PBKDF2 (SHA256, 100k iter, 16-byte salt) ile hash'lenmiş PIN saklanır. İlk kurulumda `PinSetupForm` ile belirlenir; sonrakı açılışlarda `LockScreenForm` sorar. Kullanıcı istediğinde kapatabilir.
- [x] **Idle otomatik kilit:** `SecurityService.IdleMonitor` fare/klavye aktivitesini izler; `IdleTimeoutMinutes` (vars. 10 dk) boyunca aktivite olmazsa `LockScreenForm` (IdleMode) modal gösterilir. Her aktivitede sayaç sıfırlanır.
- [x] **Boşta kalma süresi ayarı:** `PinSetupForm` üzerinden dakika bazında ayarlanabilir (1–60 dk).

### Dosya
- [ ] ~~Dosya şifreleme~~ → Kapsam dışı (ertelendi)

### Gizlilik
- [ ] ~~"Gizli mod" maskeleme~~ → Kapsam dışı (ertelendi)

### Veritabanı
```sql
AppSettings (
    SettingKey NVARCHAR(100) PRIMARY KEY,
    SettingValue NVARCHAR(MAX)
);
```
Seed (idempotent): `PinEnabled`="false", `IdleTimeoutMinutes`="10".

### Teknik
- `DatabaseHelper.EnsureTablesExist` → `AppSettings` tablosu eklenir + seed.
- `Models/AppSettings.cs` (DTO + yardımcı okuma/yazma).
- `Services/SecurityService.cs` → `IsPinEnabled`, `SetPin`, `VerifyPin`, `DisablePin`, `Get/SetIdleTimeoutMinutes`, `IdleMonitor.Start/Stop`.
- `Forms/PinSetupForm.cs` → PIN kur / değiştir / kapat + idle süresi.
- `Forms/LockScreenForm.cs` → Başlangıç (StartupMode, iptal=çıkış) ve boşta (IdleMode, iptal=çıkış) kilit ekranı.
- `Program.cs` → PIN etkinse `Application.Run` öncesi `LockScreenForm` (StartupMode) gösterilir.
- `MainScreen.cs` → `pnlMenu` altına "🔒 Güvenlik" butonu + `MainScreen_Load` içinde idle monitor başlatılır.

### Notlar
- Ek paket gerekmez: PBKDF2 `System.Security.Cryptography` içinde (.NET 8).
- PIN doğrulama sabit-zamanlı (`CryptographicOperations.FixedTimeEquals`) yapılır.
- OllamaSharp / Select.HtmlToPdf kaldırma işi Faz 10 kapsamı dışında (teknik borç listesinde).

---

## Faz 11: Raporlama ve İstatistikler (Yeni)
**Durum:** İptal edildi (kullanıcı kararı) | **Öncelik:** —

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
**Durum:** İptal edildi (kullanıcı kararı) | **Öncelik:** —

### Toplu Yükleme
- [ ] Birden fazla sözleşme aynı anda yükleme
- [ ] Klasörden toplu import

### Toplu Düzenleme
- [ ] Çoklu sözleşme silme
- [ ] Toplu etiket ekleme/değiştirme

---

## Faz 13: Yedekleme Sistemi (Yeni)
**Durum:** İptal edildi (kullanıcı kararı) | **Öncelik:** —

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
**Durum:** Atlandı (kullanıcı kararı) | **Öncelik:** —

> **Karar:** Uygulama zaten PDF metnini içe alabildiği için (iTextSharp) OCR fazına gerek kalmadı.
> Taranmış/görsel tabanlı PDF desteği ileride istenirse tekrar değerlendirilebilir.

---

## Faz 15: Klavye Kısayolları (Yeni)
**Durum:** Tamamlandı | **Öncelik:** Düşük | **Tamamlanma Tarihi:** Temmuz 2026

### Kısayollar (uygulanan)
- Ctrl+F: Arama kutusuna odaklan (mevcut metinde arama)
- Ctrl+E: PDF Export (raporu PDF olarak aktar)
- Ctrl+N: Yeni sözleşme yükle (Sözleşme Yönetimi formunu aç)

> **Not:** `Ctrl+B` (Yedekle) ve `Ctrl+G` (Gizli mod) **uygulanmadı**; bağlı oldukları
> Faz 13 (Yedekleme) ve Faz 10 Gizli Mod iptal/edildiği için bu kısayolların karşılığı yok.

### Tooltip (hover) desteği
- Tüm ana butonlara + arama kutusu/radiobuttonlara `ToolTip` eklendi.
- Fare butonun üzerine getirilip beklendiğinde **buton adı + varsa kısayol** görünür
  (örn. "Ara (Ctrl+F)", "Analiz raporunu PDF olarak aktar (Ctrl+E)").
- `MainScreen.cs` → `SetupToolTips()` ve `ProcessCmdKey` (global kısayol yakalama).

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

> **Gerçek Durum (Temmuz 2026):** `DatabaseSetup.sql` içinde şu an yalnızca şu tablolar
> **gerçekten oluşturuluyor**: `ContractTypes`, `Rules`, `Contracts`, `ContractExtractions`.
> Aşağıdaki "Final" şemadaki `ContractDates` (Faz 5 ile eklendi), `ContractNotes`, `Tags`,
> `ContractTags`, `ContractTemplates`, `Backups` tabloları **henüz oluşturulmadı**; ilgili
> fazlar (8, 11, 12, 13) başladığında eklenmesi gerekiyor. `ContractVersions` tablosu Faz 7
> ile birlikte **plan dışı** bırakıldı.
> Ayrıca mevcut `Contracts` tablosunda `PartyName`, `Status`, `Year`, `StartDate`, `EndDate`,
> `Amount`, `Currency`, `IsSigned` alanları yok; sadece `FilePath` ve
> `RiskScore` alanları mevcut. (`VersionNumber` da Faz 7 ile birlikte plan dışı.)

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
    CreatedAt, UpdatedAt
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
| 1 | Faz 1: PDF + Dosya Yükleme | Tamamlandı | Tamamlandı |
| 2 | Faz 2: Arama | Tamamlandı | Tamamlandı |
| 3 | Faz 4: Alan Çıkarımı | Tamamlandı | Tamamlandı |
| 4 | Faz 3: Otomatik Özet İyileştirme | Tamamlandı | Tamamlandı |
| 5 | Faz 5: Kritik Tarihler | Tamamlandı | Tamamlandı |
| 6 | Faz 6: Risk Kontrolü (Rules DB + AI prompt) | Tamamlandı | Tamamlandı |
| 7 | Faz 8: Sözleşme Şablonları | **Tamamlandı** | Tamamlandı |
| 8 | Faz 7: Versiyon Takibi | **Ertelendi / Gerekmez** | — |
| 9 | Faz 9: Export İyileştirme | **Tamamlandı** | Tamamlandı |
| 10 | Faz 10: Güvenlik (PIN + idle kilit) | **Tamamlandı** | Tamamlandı |
| 11 | Faz 15: Klavye Kısayolları | **Tamamlandı** | 1 gün |
| 12 | Faz 14: OCR Desteği | **Atlandı** (gerekmez) | — |

> **Not (Temmuz 2026):** Faz 11 (Raporlama), Faz 12 (Toplu İşlemler) ve Faz 13 (Yedekleme) kullanıcı kararıyla **iptal edildi**. Faz 14 (OCR) kullanıcı kararıyla **atlandı** (PDF zaten içe alınıyor). Faz 15 (Kısayollar) **tamamlandı**. Kalan faz yok.

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

## Mevcut Sorunlar ve Teknik Borç (Durum Takibi)

> Aşağıdaki maddeler planın önceki sürümlerinde "çözülecek" olarak listelenmişti. Kod incelemesinde
> (Temmuz 2026) bu maddelerin **henüz çözülmediği** tespit edildi. Gerçek durum aşağıdadır.

| Sorun | Planlanan Çözüm | Gerçek Durum |
|-------|-----------------|--------------|
| OllamaSharp paketi kullanılmıyor | Kaldır veya HttpClient yerine kullan | ⚠️ **Açık** - Paket hâlâ `csproj`'te referanslı; kod `HttpClient` kullanıyor (AIService.cs). Kaldırılabilir. |
| Select.HtmlToPdf.NetCore kullanılmıyor | Kaldır | ⚠️ **Açık** - Paket hâlâ `csproj`'te referanslı; ExportService `iTextSharp` kullanıyor. Kaldırılabilir. |
| appsettings.json yok | Ekle | ⚠️ **Açık** - Yapılandırma için appsettings.json hâlâ eklenmedi. |
| Unit test yok | xUnit ile basit testler | ⚠️ **Açık** - Hiç test projesi/ test yok. |
| Hata loglama yok | Serilog veya NLog ekle | ⚠️ **Kısmi** - Sadece `Trace.WriteLine` ile bırakılan loglar var, merkezi loglama kütüphanesi yok. |
| Dependency injection yok | .NET 8 built-in DI kullan | ⚠️ **Açık** - Servisler formlarda `new` ile örnekleniyor (ör. `MainScreen.cs`), DI container kullanılmıyor. |

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
1. ✅ Anahtar kelime araması (Faz 2 tamamlandı)
2. ✅ Yapılandırılmış alan çıkarma (Faz 4 tamamlandı)
3. ✅ Kritik tarih takibi
4. ➕ Hızlı notlar
5. ✅ Executive Summary (Faz 3 tamamlandı)

**Sonraki Aşama:**
6. ~~➕ Versiyon takibi~~ → Ertelendi (tek seferlik imzalı arşiv)
7. ~~Şablonlar (Faz 8)~~ → Tamamlandı
8. Export iyileştirmeleri (Faz 9) → Tamamlandı
9. ~~Yedekleme (Faz 13)~~ → İptal edildi
10. ~~Raporlama (Faz 11)~~ → İptal edildi
11. ~~Toplu İşlemler (Faz 12)~~ → İptal edildi
12. Klavye Kısayolları (Faz 15) → **Tamamlandı**
13. OCR Desteği (Faz 14) → **Atlandı** (gerekmez)

---

## Notlar

- Bu plan bireysel kullanıcı için optimize edilmiştir
- Çoklu kullanıcı özellikleri (rol, izin, audit trail) kaldırılmıştır
- Her faz bağımsız olarak test edilebilir
- Mevcut özellikler bozulmadan yeni özellikler eklenmelidir
