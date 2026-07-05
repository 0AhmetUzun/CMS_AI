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
        public void ExportDirectToPdf(string filePath, AnalysisResult result, string contractTypeName, AIService.AIAnalysisResult aiResult = null)
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
                    iTextSharp.text.Font sectionFont = new iTextSharp.text.Font(bf, 13, iTextSharp.text.Font.BOLD, new BaseColor(128, 0, 255));
                    iTextSharp.text.Font normalFont = new iTextSharp.text.Font(bf, 11, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                    iTextSharp.text.Font boldFont = new iTextSharp.text.Font(bf, 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                    iTextSharp.text.Font whiteFont = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
                    iTextSharp.text.Font smallFont = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL, BaseColor.GRAY);

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
                    BaseColor bgColor = new BaseColor(46, 204, 113);
                    if (result.TotalScore < 40) { riskLevel = "YÜKSEK RİSKLİ"; bgColor = new BaseColor(231, 76, 60); }
                    else if (result.TotalScore < 75) { riskLevel = "ORTA RİSKLİ"; bgColor = new BaseColor(241, 196, 15); }

                    PdfPCell cell = new PdfPCell(new Phrase($"SİSTEM SKORU: {result.TotalScore} / 100\nDEĞERLENDİRME: {riskLevel}", whiteFont));
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
                            statusCell.BackgroundColor = new BaseColor(255, 230, 230);
                        else if (statusText == "Zorunlu Madde Mevcut" || statusText == "Kritik Bulgular Tespit Edildi")
                            statusCell.BackgroundColor = new BaseColor(230, 245, 230);
                        detailsTable.AddCell(statusCell);
                    }
                    doc.Add(detailsTable);

                    if (aiResult != null)
                    {
                        doc.Add(new Paragraph("\n\n"));
                        Paragraph aiTitle = new Paragraph("AI ANALİZ BULGULARI", sectionFont);
                        aiTitle.SpacingBefore = 15f;
                        aiTitle.SpacingAfter = 10f;
                        doc.Add(aiTitle);

                        PdfPTable aiSummaryTable = new PdfPTable(1);
                        aiSummaryTable.WidthPercentage = 100;
                        string aiRiskLevel = aiResult.RiskLevel ?? "Bilinmiyor";
                        double aiScore = aiResult.RiskScore;
                        BaseColor aiBgColor;
                        if (aiScore >= 75) aiBgColor = new BaseColor(46, 204, 113);
                        else if (aiScore >= 40) aiBgColor = new BaseColor(241, 196, 15);
                        else aiBgColor = new BaseColor(231, 76, 60);

                        PdfPCell aiScoreCell = new PdfPCell(new Phrase($"AI RİSK SKORU: {aiScore}/100\nAI DEĞERLENDİRMESİ: {aiRiskLevel}", whiteFont));
                        aiScoreCell.BackgroundColor = aiBgColor;
                        aiScoreCell.Padding = 15f;
                        aiScoreCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        aiScoreCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        aiSummaryTable.AddCell(aiScoreCell);
                        doc.Add(aiSummaryTable);

                        if (!string.IsNullOrEmpty(aiResult.Summary))
                        {
                            doc.Add(new Paragraph("\nAI ÖZET", boldFont));
                            Paragraph aiSummaryText = new Paragraph(aiResult.Summary, normalFont);
                            aiSummaryText.SpacingAfter = 10f;
                            doc.Add(aiSummaryText);
                        }

                        if (aiResult.Details != null && aiResult.Details.Count > 0)
                        {
                            doc.Add(new Paragraph("AI MADDE DETAYLARI", boldFont));
                            PdfPTable aiDetailsTable = new PdfPTable(3);
                            aiDetailsTable.WidthPercentage = 100;
                            aiDetailsTable.SetWidths(new float[] { 30f, 20f, 50f });
                            aiDetailsTable.AddCell(new PdfPCell(new Phrase("Madde", whiteFont)) { BackgroundColor = BaseColor.DARK_GRAY, Padding = 6f });
                            aiDetailsTable.AddCell(new PdfPCell(new Phrase("Risk", whiteFont)) { BackgroundColor = BaseColor.DARK_GRAY, Padding = 6f, HorizontalAlignment = Element.ALIGN_CENTER });
                            aiDetailsTable.AddCell(new PdfPCell(new Phrase("Açıklama", whiteFont)) { BackgroundColor = BaseColor.DARK_GRAY, Padding = 6f });

                            foreach (var detail in aiResult.Details)
                            {
                                aiDetailsTable.AddCell(new PdfPCell(new Phrase(detail.Title ?? "-", boldFont)) { Padding = 6f });
                                string risk = detail.Risk ?? "Bilinmiyor";
                                BaseColor riskColor = BaseColor.BLACK;
                                if (risk == "Düşük") riskColor = new BaseColor(46, 204, 113);
                                else if (risk == "Orta") riskColor = new BaseColor(241, 196, 15);
                                else if (risk == "Yüksek") riskColor = new BaseColor(231, 76, 60);
                                else if (risk == "Kritik") riskColor = new BaseColor(180, 0, 0);
                                iTextSharp.text.Font riskFont = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD, riskColor);
                                aiDetailsTable.AddCell(new PdfPCell(new Phrase(risk, riskFont)) { Padding = 6f, HorizontalAlignment = Element.ALIGN_CENTER });
                                aiDetailsTable.AddCell(new PdfPCell(new Phrase(detail.Explanation ?? detail.Content ?? "-", normalFont)) { Padding = 6f });
                            }
                            doc.Add(aiDetailsTable);
                        }

                        if (aiResult.Recommendations != null && aiResult.Recommendations.Count > 0)
                        {
                            doc.Add(new Paragraph("\nAI ÖNERİLERİ", boldFont));
                            foreach (var rec in aiResult.Recommendations)
                            {
                                Paragraph recItem = new Paragraph($"  •  {rec}", normalFont);
                                recItem.SpacingAfter = 4f;
                                doc.Add(recItem);
                            }
                        }
                    }

                    doc.Add(new Paragraph("\n\n"));
                    Paragraph footer = new Paragraph($"Rapor Tarihi: {DateTime.Now:dd.MM.yyyy HH:mm} | Sözleşme Analiz Merkezi (CMS)", smallFont);
                    footer.Alignment = Element.ALIGN_CENTER;
                    doc.Add(footer);

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
