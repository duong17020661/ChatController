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

        public IEnumerable<FileAndImage> getAllFile(string convId)
        {
            return _context.Files.Where(data => data.type == 5 && data.convId == convId);
        }

        public IEnumerable<FileAndImage> getAllImage(string convId)
        {
            return _context.Files.Where(data => data.type == 2 && data.convId == convId);
        }

        public IEnumerable<FileAndImage> getFile(int amount, string convId)
        {
            return _context.Files.Where(data => data.type == 5 && data.convId == convId).Take(amount);
        }

        public IEnumerable<FileAndImage> getImage(int amount, string convId)
        {
            return _context.Files.Where(data => data.type == 2 && data.convId == convId).Take(amount);
        }

        public PostFileResponse PostFile(FileAndImage file)
        {
            _context.Files.Add(file);
            _context.SaveChanges();
            return new PostFileResponse(file);
        }

    }
}
