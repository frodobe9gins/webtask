using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebTask.Lib.Service;

namespace WebTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IMyFileService _fileService;
        public FileController(IMyFileService fileService)
        {
            _fileService = fileService;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var dt = await _fileService.Get(id);
            return File(dt.Data, @"application/octet-stream", dt.Name);
        }
    }
}
