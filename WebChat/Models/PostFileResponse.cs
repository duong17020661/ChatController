using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebChat.Models
{
    public class PostFileResponse
    {
        public Guid Id { get; set; }
        public string convId { get; set; }
        public string content { get; set; }
        public string filePath { get; set; }
        public int type { get; set; }
        public string typeOf { get; set; }

        public PostFileResponse(FileAndImage file)
        {
            Id = file.Id;
            convId = file.convId;
            content = file.content;
            filePath = file.filePath;
            type = file.type;
            typeOf = file.typeOf;
        }
    }
}
