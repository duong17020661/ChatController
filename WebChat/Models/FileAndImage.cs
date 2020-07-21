using System;

namespace WebChat.Models
{
    public class FileAndImage
    {
        public Guid Id { get; set; }
        public string convId { get; set; }
        public string content { get; set; }
        public string filePath { get; set; }
        public int type { get; set; }
        public string typeOf { get; set; }
    }
}
