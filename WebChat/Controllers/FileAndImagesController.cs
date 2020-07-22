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
    public class FileAndImagesController : ControllerBase
    {
        private readonly DataContext _context;

        public FileAndImagesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/FileAndImages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FileAndImage>>> GetFiles()
        {
            return await _context.Files.ToListAsync();
        }

        // GET: api/FileAndImages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FileAndImage>> GetFileAndImage(Guid id)
        {
            var fileAndImage = await _context.Files.FindAsync(id);

            if (fileAndImage == null)
            {
                return NotFound();
            }

            return fileAndImage;
        }

        // PUT: api/FileAndImages/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFileAndImage(Guid id, FileAndImage fileAndImage)
        {
            if (id != fileAndImage.Id)
            {
                return BadRequest();
            }

            _context.Entry(fileAndImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FileAndImageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FileAndImages
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<FileAndImage>> PostFileAndImage(FileAndImage fileAndImage)
        {
            _context.Files.Add(fileAndImage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFileAndImage", new { id = fileAndImage.Id }, fileAndImage);
        }

        // DELETE: api/FileAndImages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FileAndImage>> DeleteFileAndImage(Guid id)
        {
            var fileAndImage = await _context.Files.FindAsync(id);
            if (fileAndImage == null)
            {
                return NotFound();
            }

            _context.Files.Remove(fileAndImage);
            await _context.SaveChangesAsync();

            return fileAndImage;
        }

        private bool FileAndImageExists(Guid id)
        {
            return _context.Files.Any(e => e.Id == id);
        }
    }
}
