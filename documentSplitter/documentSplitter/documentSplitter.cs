using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

using DocumentFormat.OpenXml.Validation;
using OpenXmlPowerTools;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace documentSplitter
{
    public class documentSplitter
    {
        WmlDocument inDoc;
        string _outPath;
        int sectionCounter = 0;
        public documentSplitter(string inputDocument, string outputPath)
        {
            inDoc = new WmlDocument(inputDocument);
            _outPath = outputPath;
        }

        public void SplitDocument()
        {
            WmlDocument wmlDocument = new WmlDocument(inDoc.FileName);
            IEnumerable<WmlDocument> wmlDocuments = wmlDocument.SplitOnSections();
            int counter = 0;
            foreach(WmlDocument doc in wmlDocuments)
            {
                List<Source> sources = new List<Source>();
                sources.Add(new Source(doc));
                DocumentBuilder.BuildDocument(sources, System.IO.Path.Combine(_outPath, $"{counter}.docx"));
                counter++;
            }
        }
    }
}
