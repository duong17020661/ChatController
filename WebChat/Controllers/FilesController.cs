using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebChat.Data;
using WebChat.Models;

namespace WebChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly DataContext _context;

        public FilesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Files
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FileAndImage>>> GetFiles()
        {
            return await _context.Files.ToListAsync();
        }
        // GET: api/Files/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FileAndImage>> GetFileAndImage(String id)
        {
            var fileAndImage = await _context.Files.Where(x => x.convId == id).ToListAsync();

            if (fileAndImage == null)
            {
                return NotFound();
            }

            return Ok(fileAndImage);
        }

        [HttpPost]
        public async Task<ActionResult<FileAndImage>> PostFile([FromBody]FileAndImage file)
        {
            _context.Files.Add(file);
            await _context.SaveChangesAsync();

            return Ok(file);
        }
    }
}
