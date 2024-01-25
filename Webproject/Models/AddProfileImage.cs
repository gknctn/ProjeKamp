using Microsoft.AspNetCore.Http;

namespace Webproject.Models
{
    public class AddProfileImage
    {
        public int WriterID { get; set; }
        public string WriterName { get; set; }
        public string WriterSurname { get; set; }
        public string WriterAbout { get; set; }
        public IFormFile WriterImage { get; set; }
        public string WriterMail { get; set; }
        public string Writerpassword { get; set; }
        public bool WriterStatus { get; set; }
    }
}
