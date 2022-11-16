namespace PDF_Viewer;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private void UrlToPdf(object sender, EventArgs e)
	{
		if (URL.Text != null)
		{
            var Renderer = new IronPdf.ChromePdfRenderer();
            var pdf = Renderer.RenderUrlAsPdf(URL.Text.Trim());
            SaveService saveService = new();
            saveService.SaveAndView("URLtoPDF.pdf", "application/pdf", pdf.Stream);
            DisplayAlert("Success", "PDF from URL Created!", "OK");
        }
		else
		{
            DisplayAlert("Error", "Field can't be empty! \nPlease enter URL!", "OK");
        }

    }

    private void HtmlToPdf(object sender, EventArgs e)
    {
        if (HTML.Text != null)
        {
            var Renderer = new IronPdf.ChromePdfRenderer();
            var pdf = Renderer.RenderHtmlAsPdf(HTML.Text);
            SaveService saveService = new();
            saveService.SaveAndView("IronPDF HTML string.pdf", "application/pdf", pdf.Stream);
            DisplayAlert("Success", "PDF from HTML Created!", "OK");
        }
        else
        {
            DisplayAlert("Error", "Field can't be empty! \nPlease enter valid HTML!", "OK");
        }
    }

    private void FileToPdf(object sender, EventArgs e)
    {
        var Renderer = new IronPdf.ChromePdfRenderer();
        var pdf = Renderer.RenderHtmlFileAsPdf(@"C:\Users\Administrator\Desktop\index.html");
        SaveService saveService = new();
        saveService.SaveAndView("HTML FIle to PDF.pdf", "application/pdf", pdf.Stream);
        DisplayAlert("Success", "PDF from File Created!", "OK");
    }
}

