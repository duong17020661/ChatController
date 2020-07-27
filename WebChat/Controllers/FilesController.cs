using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebChat.Data;
using WebChat.Models;
using WebChat.Repository;

namespace WebChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IFileServices _fileService;

        public FilesController(DataContext context, IFileServices fileService)
        {
            _context = context;
            _fileService = fileService;
        }
        /// <summary>
        /// Lấy tất cả các files v ảnh
        /// </summary>
        /// <returns></returns>
        // GET: api/Files
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FileAndImage>>> GetFiles()
        {
            return await _context.Files.ToListAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="convId"></param>
        /// <returns></returns>
        [HttpGet("getAllFile")]
        public ActionResult<IEnumerable<FileAndImage>> GetFiles([FromQuery] string convId)
        {
            return Ok(_fileService.getAllFile(convId));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="convId"></param>
        /// <returns></returns>
        [HttpGet("getFiles")]
        public ActionResult<FileAndImage> GetFile([FromQuery] string convId)
        {
            var amount = 2;
            return Ok(_fileService.getFile(amount, convId));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="convId"></param>
        /// <returns></returns>
        [HttpGet("getAllImage")]
        public ActionResult<IEnumerable<FileAndImage>> GetImages([FromQuery] string convId)
        {
            return Ok(_fileService.getAllImage(convId));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="convId"></param>
        /// <returns></returns>
        [HttpGet("getImages")]
        public ActionResult<FileAndImage> GetImage([FromQuery] string convId)
        {
            var amount = 3; //số lượng ảnh cần lấy
            return Ok(_fileService.getImage(amount, convId));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<FileAndImage>> PostFile([FromBody]FileAndImage file)
        {
            _context.Files.Add(file);
            await _context.SaveChangesAsync();

            return Ok(file);
        }
    }
}
