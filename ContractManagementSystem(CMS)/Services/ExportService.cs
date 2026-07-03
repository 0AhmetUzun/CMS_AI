using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Collections.Generic;
using ContractManagementSystem_CMS_.Models;

namespace ContractManagementSystem_CMS_.Services
{
    public class ExportService
    {
        public void ExportDirectToPdf(string filePath, AnalysisResult result, string contractTypeName)
        {
            Document doc = new Document(iTextSharp.text.PageSize.A4, 50f, 50f, 50f, 50f);

            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);

                    doc.Open();

                    string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                    BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

                    iTextSharp.text.Font titleFont = new iTextSharp.text.Font(bf, 18, iTextSharp.text.Font.BOLD, BaseColor.DARK_GRAY);
                    iTextSharp.text.Font subTitleFont = new iTextSharp.text.Font(bf, 14, iTextSharp.text.Font.BOLD, BaseColor.GRAY);
                    iTextSharp.text.Font normalFont = new iTextSharp.text.Font(bf, 11, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                    iTextSharp.text.Font whiteFont = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD, BaseColor.WHITE);

                    Paragraph title = new Paragraph("SÖZLEŞME ANALİZ RAPORU", titleFont);
                    title.Alignment = Element.ALIGN_CENTER;
                    doc.Add(title);

                    Paragraph info = new Paragraph($"{contractTypeName} Analizi - {DateTime.Now:dd.MM.yyyy HH:mm}", normalFont);
                    info.Alignment = Element.ALIGN_CENTER;
                    info.SpacingAfter = 20f;
                    doc.Add(info);

                    PdfPTable summaryTable = new PdfPTable(1);
                    summaryTable.WidthPercentage = 100;

                    string riskLevel = "GÜVENLİ / DÜŞÜK RİSKLİ";
                    BaseColor bgColor = new BaseColor(46, 204, 113); // Green

                    if (result.TotalScore < 40)
                    {
                        riskLevel = "YÜKSEK RİSKLİ";
                        bgColor = new BaseColor(231, 76, 60); // Red
                    }
                    else if (result.TotalScore < 75)
                    {
                        riskLevel = "ORTA RİSKLİ";
                        bgColor = new BaseColor(241, 196, 15); // Yellow
                    }

                    PdfPCell cell = new PdfPCell(new Phrase($"SÖZLEŞME SKORU: {result.TotalScore} / 100\nSİSTEM DEĞERLENDİRMESİ: {riskLevel}", whiteFont));
                    cell.BackgroundColor = bgColor;
                    cell.Padding = 15f;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    summaryTable.AddCell(cell);
                    doc.Add(summaryTable);

                    doc.Add(new Paragraph("\nANALİZ BULGULARI\n\n", subTitleFont));

                    PdfPTable detailsTable = new PdfPTable(2);
                    detailsTable.WidthPercentage = 100;
                    detailsTable.SetWidths(new float[] { 70f, 30f });

                    detailsTable.AddCell(new PdfPCell(new Phrase("Kural Açıklaması", whiteFont)) { BackgroundColor = BaseColor.DARK_GRAY, Padding = 6f });
                    detailsTable.AddCell(new PdfPCell(new Phrase("Analiz Durumu", whiteFont)) { BackgroundColor = BaseColor.DARK_GRAY, Padding = 6f, HorizontalAlignment = Element.ALIGN_CENTER });

                    foreach (var detail in result.Details)
                    {
                        detailsTable.AddCell(new PdfPCell(new Phrase(detail.RuleDescription ?? "Açıklama Yok", normalFont)) { Padding = 6f });

                        string statusText = detail.Status ?? "Belirtilmedi";

                        PdfPCell statusCell = new PdfPCell(new Phrase(statusText, normalFont)) { Padding = 6f, HorizontalAlignment = Element.ALIGN_CENTER };

                        if (statusText == "Yasaklı Madde Bulundu" || statusText == "Zorunlu Madde Eksik")
                        {
                            statusCell.BackgroundColor = new BaseColor(255, 230, 230); //Red
                        }
                        else if (statusText == "Zorunlu Madde Mevcut" || statusText == "Kritik Bulgular Tespit Edildi")
                        {
                            statusCell.BackgroundColor = new BaseColor(230, 245, 230); //Green
                        }

                        detailsTable.AddCell(statusCell);
                    }

                    doc.Add(detailsTable);

                    doc.Close();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine($"[ExportService] Hata: {ex.Message}", typeof(ExportService).FullName);
                throw;
            }

        }
    }
}
