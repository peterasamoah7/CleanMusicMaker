namespace CleanMusicMaker.Models
{
    public class DocumentRequest
    {
        public Document Document { get; }  

        public DocumentRequest(Document document)
        {
            Document = document;
        }
    }
}
