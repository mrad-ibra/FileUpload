using DownloadsApi.Data;
using DownloadsApi.Libs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DownloadsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileManagerController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IFileManager _fileManager;
        public FileManagerController(IFileManager fileManager, AppDbContext context)
        {
            _context = context;
            _fileManager = fileManager;
        }
        [HttpPost]
        [Route("upload")]
        public IActionResult Upload([FromForm] IFormFile file)
        {
            if (file == null) return BadRequest();
            var fileName = _fileManager.Upload(file);
            
            return Ok(new
            {
                fileName
            });
        }
        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete([FromQuery] string fileName)
        {
            if(string.IsNullOrEmpty(fileName)) return BadRequest();
            if (!_fileManager.FileExists(fileName)) return NotFound();
            _fileManager.Delete(fileName);
            return Ok();
        }
    } 
}
