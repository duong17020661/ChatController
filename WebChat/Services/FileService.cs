using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebChat.Data;
using WebChat.Models;
using WebChat.Repository;

namespace WebChat.Services
{
    public class FileService : IFileServices
    {
        private readonly DataContext _context;
        public FileService(DataContext context)
        {
            _context = context;
        }
        public PostFileResponse PostFile(FileAndImage file)
        {
            _context.Files.Add(file);
            _context.SaveChanges();
            return new PostFileResponse(file);
        }
    }
}
