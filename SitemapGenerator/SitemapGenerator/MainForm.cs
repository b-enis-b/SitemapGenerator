using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;



namespace SitemapGenerator
{
    public partial class MainForm : Form
    {

        private readonly HttpClient _httpClient = new HttpClient();

        public MainForm()
        {
            InitializeComponent();
        }



        private async void btnGenerate_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text;
            int sitemapCount = (int)numUrlsPerSitemap.Value;

            listBox.Items.Clear();
            listBox.Items.Add("Starting to scan. Please Wait...");
            var visitedLinks = new HashSet<string>();
      
            btnGenerate.Enabled = false;

            if (Uri.TryCreate(url, UriKind.Absolute, out Uri result) && (result.Scheme == Uri.UriSchemeHttp || result.Scheme == Uri.UriSchemeHttps))
            {
                await GetAllLinks(url, visitedLinks,  listBox);
                foreach (var link in visitedLinks)
                {
                    listBox.Items.Add(link);
                }

         

                listBox.Items.Add("Generating sitemaps...");
                var path = CreateSitemapsAndReturnSitemapIndex(url, visitedLinks, sitemapCount);
                listBox.Items.Add("Created. Path: " + path);
            }
            else
            {
                MessageBox.Show("Enter a valid URL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

  



          
            btnGenerate.Enabled = true;
        }




        private async Task GetAllLinks(string url, HashSet<string> visitedLinks, ListBox listBox)
        {




            if (visitedLinks.Contains(url))
            {
                return;
            }

            visitedLinks.Add(url);

            try
            {
                var html = await _httpClient.GetStringAsync(url);
                var htmlDocument = new HtmlAgilityPack.HtmlDocument();
                htmlDocument.LoadHtml(html);


                var baseUrl = new Uri(url);
                var baseDomain = baseUrl.Host;
                var excludedExtensions = new HashSet<string> { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".ico", ".pdf", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".zip", ".rar", ".tar", ".gz", ".7z", ".mp3", ".mp4", ".avi", ".mkv", ".mov", ".ogg", ".webm" };



                var links = htmlDocument.DocumentNode.Descendants("a")
                    .Where(node => node.Attributes.Contains("href"))
                    .Select(node => node.Attributes["href"].Value)
                    .Where(href => !string.IsNullOrWhiteSpace(href) && !href.StartsWith("#") && !href.StartsWith("javascript:void(0)") && !href.StartsWith("javascript:;"))
                    .Select(href => href.StartsWith("http") ? href : new Uri(baseUrl, href).ToString())
                    .Where(href =>
                    {
                        var uri = new Uri(href);
                        return uri.Host == baseDomain && !excludedExtensions.Contains(Path.GetExtension(uri.AbsolutePath).ToLower());
                    })
                    .ToList();

                foreach (var link in links)
                {
                    await GetAllLinks(link, visitedLinks, listBox);
                }
           
            }
            catch (Exception e)
            {

                listBox.Invoke((Action)(() => listBox.Items.Add($"Broken link: {url}")));
                Console.WriteLine($"Error: {url} - {e.Message}");
            }


        }





        private string CreateSitemapsAndReturnSitemapIndex(string url, HashSet<string> links, int sitemapCount)
        {
            string sitemapDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sitemaps");
            Directory.CreateDirectory(sitemapDirectory);

            if (sitemapCount > links.Count)
            {
                sitemapCount = 1;
            }

            int linksPerSitemap = sitemapCount > 1 ? (int)Math.Ceiling(links.Count / (double)sitemapCount) : links.Count;



            StringBuilder sitemapIndexBuilder = new StringBuilder();
            sitemapIndexBuilder.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sitemapIndexBuilder.AppendLine("<sitemapindex xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">");

            int linkCounter = 0;
            int currentSitemap = 1;

            while (linkCounter < links.Count)
            {
                string sitemapFile = $"sitemap{currentSitemap}.xml";
                string sitemapPath = Path.Combine(sitemapDirectory, sitemapFile);

                using (XmlTextWriter writer = new XmlTextWriter(sitemapPath, Encoding.UTF8))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("urlset", "http://www.sitemaps.org/schemas/sitemap/0.9");

                    for (int i = 0; i < linksPerSitemap && linkCounter < links.Count; i++)
                    {
                        string link = links.ElementAt(linkCounter);

                        writer.WriteStartElement("url");
                        writer.WriteElementString("loc", link);
                        writer.WriteEndElement();

                        linkCounter++;
                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }

                sitemapIndexBuilder.AppendLine($"  <sitemap>");
                sitemapIndexBuilder.AppendLine($"    <loc>{url}{sitemapFile}</loc>");
                sitemapIndexBuilder.AppendLine($"  </sitemap>");

                currentSitemap++;
            }

            sitemapIndexBuilder.AppendLine("</sitemapindex>");

            string sitemapIndexPath = Path.Combine(sitemapDirectory, "sitemap_index.xml");
            File.WriteAllText(sitemapIndexPath, sitemapIndexBuilder.ToString());

            return sitemapIndexPath;
        }

    }
}
