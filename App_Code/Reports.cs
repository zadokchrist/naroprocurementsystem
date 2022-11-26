using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.IO;
using System.Web;

/// <summary>
/// Summary description for Reports
/// </summary>
public class Reports
{
    public Reports()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public byte[] GenerateAllTransactionsPdfReport(DataTable dtsent, string header, string startdate, string enddate, string user, string type)
    {
        string filepath = string.Empty;
        Document document = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
        Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, Color.BLACK);
        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
        {
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
            Phrase phrase = null;
            PdfPCell cell = null;
            PdfPTable table = null;
            PdfPTable contatetable = null;
            Color color = null;
            document.Open();
            //Header Table
            table = new PdfPTable(2);
            table.TotalWidth = 500f;
            table.LockedWidth = true;
            table.SetWidths(new float[] { 0.3f, 0.7f });
            //Company Logo
            string imagepath = "~/images/logo.jpg";
            cell = ImageCell(imagepath, 10f, PdfPCell.ALIGN_CENTER);
            table.AddCell(cell);
            //Company Name and Address
            phrase = new Phrase();
            phrase.Add(new Chunk("Lagos Water Corporation\n\n", FontFactory.GetFont("Arial", 20, Font.BOLD, Color.BLACK)));
            phrase.Add(new Chunk(header, FontFactory.GetFont("Arial", 8, Font.NORMAL, Color.BLACK)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
            cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            table.AddCell(cell);
            //Separater Line
            color = new Color(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"));
            DrawLine(writer, 25f, document.Top - 79f, document.PageSize.Width - 25f, document.Top - 79f, color);
            DrawLine(writer, 25f, document.Top - 80f, document.PageSize.Width - 25f, document.Top - 80f, color);
            document.Add(table);
            table = new PdfPTable(2);
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            table.SetWidths(new float[] { 0.3f, 1f });
            table.SpacingBefore = 10f;
            //FILL THE DATA TABLE 
            if (dtsent != null)
            {
                int cols = dtsent.Columns.Count;
                int rows = dtsent.Rows.Count;
                int pdfRowIndex = 1;
                contatetable = new PdfPTable(cols);
                contatetable.DefaultCell.BorderColor = Color.GRAY;
                contatetable.SpacingAfter = 20f;
                /*You can use loop to add a column*/
                for (int i = 0; i < dtsent.Columns.Count; i++)
                {
                    string columnName = dtsent.Columns[i].ToString();
                    contatetable.AddCell(new Phrase(columnName, FontFactory.GetFont("Calibri", 10, iTextSharp.text.Color.WHITE)));
                    contatetable.DefaultCell.BackgroundColor = new iTextSharp.text.Color(System.Drawing.ColorTranslator.FromHtml("#13386C")); ;

                }
                contatetable.HeaderRows = 1;
                foreach (DataRow row in dtsent.Rows)
                {
                    for (int i = 0; i < dtsent.Columns.Count; i++)
                    {
                        contatetable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        contatetable.TotalWidth = 518f;
                        contatetable.LockedWidth = true;
                        contatetable.SpacingBefore = 48f;
                        contatetable.DefaultCell.Border = PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
                        contatetable.AddCell(new Phrase(row[i].ToString(), FontFactory.GetFont("Calibri", 8, iTextSharp.text.Color.BLACK)));
                    }
                }
                bool b = true;
                int k = 1;
                foreach (PdfPRow r in contatetable.Rows)
                {
                    foreach (PdfPCell c in r.GetCells())
                    {
                        if (k == 1 || type == "TRANSACTIONS" || type == "VOLUMES")
                        {
                            c.BackgroundColor = new iTextSharp.text.Color(System.Drawing.ColorTranslator.FromHtml("#13386C")); ;
                        }
                        else if (b)
                        {
                            c.BackgroundColor = new Color(System.Drawing.Color.White);
                        }
                        else
                        {
                            c.BackgroundColor = new Color(System.Drawing.Color.WhiteSmoke);
                        }
                    }
                    b = !b;
                    k++;
                }
                
                document.Add(contatetable);
            }
            document.Close();
            byte[] content = memoryStream.ToArray();
            memoryStream.Close();
            byte[] contentwithpagenumbers = AddPageNumbers(content);
            filepath = @"E:\Documents\" + DateTime.Now.ToString("_ddMMyyyy_HHmmss") + ".pdf";
            return contentwithpagenumbers;
        }

    }

    private static void DrawLine(PdfWriter writer, float x1, float y1, float x2, float y2, Color color)
    {
        PdfContentByte contentByte = writer.DirectContent;
        contentByte.SetColorStroke(color);
        contentByte.MoveTo(x1, y1);
        contentByte.LineTo(x2, y2);
        contentByte.Stroke();
    }

    private static PdfPCell PhraseCell(Phrase phrase, int align)
    {
        PdfPCell cell = new PdfPCell(phrase);
        cell.BorderColor = Color.WHITE;
        cell.VerticalAlignment = PdfCell.ALIGN_TOP;
        cell.HorizontalAlignment = align;
        cell.PaddingBottom = 2f;
        cell.PaddingTop = 0f;
        return cell;
    }

    private static PdfPCell ImageCell(string path, float scale, int align)
    {
        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));
        image.ScalePercent(scale);
        PdfPCell cell = new PdfPCell(image);
        cell.BorderColor = Color.WHITE;
        cell.VerticalAlignment = PdfCell.ALIGN_TOP;
        cell.HorizontalAlignment = align;
        cell.PaddingBottom = 0f;
        cell.PaddingTop = 0f;
        return cell;
    }


    public static byte[] AddPageNumbers(byte[] pdf)
    {
        MemoryStream ms = new MemoryStream();
        // we create a reader for a certain document
        PdfReader reader = new PdfReader(pdf);
        // we retrieve the total number of pages
        int n = reader.NumberOfPages;
        // we retrieve the size of the first page
        Rectangle psize = reader.GetPageSize(1);

        // step 1: creation of a document-object
        // Document document = new Document(psize, 50, 50, 50, 50);
        Document document = new Document(PageSize.A4, 80, 80, 10, 90);
        // step 2: we create a writer that listens to the document
        PdfWriter writer = PdfWriter.GetInstance(document, ms);
        // step 3: we open the document

        document.Open();
        // step 4: we add content
        PdfContentByte cb = writer.DirectContent;

        int p = 0;
        for (int page = 1; page <= reader.NumberOfPages; page++)
        {
            document.NewPage();
            p++;

            PdfImportedPage importedPage = writer.GetImportedPage(reader, page);
            cb.AddTemplate(importedPage, 0, 0);

            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.BeginText();
            cb.SetFontAndSize(bf, 10);
            string paging = "Page " + p + " of " + n;
            cb.ShowTextAligned(Element.ALIGN_CENTER, paging, 300, 30, 0);
            cb.EndText();
        }
        // step 5: we close the document
        document.Close();
        return ms.ToArray();
    }


}
