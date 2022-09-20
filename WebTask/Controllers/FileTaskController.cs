using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebTask.Lib.Core;
using WebTask.Lib.Service;

namespace WebTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileTaskController : ControllerBase
    {
        private readonly IMyFileService _fileService;
        public FileTaskController(IMyFileService fileService)
        {
            _fileService = fileService;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IEnumerable<MyFile>> GetAsync(int id)
        {
            return await _fileService.GetByTask(id);
        }
        [HttpPost]
        public async Task<MyFile> AddAsync(MyFile fileHeader,string path)
        {
            var data = System.IO.File.ReadAllBytes(path);
            fileHeader.Length = data.Length;
          var hd=  await _fileService.Add(fileHeader, data );
           return hd;
        }

        [HttpDelete]
        public async Task DeleteSync(Guid id)
        {
            await _fileService.Delete(id);
        }




    
    }

         
}
