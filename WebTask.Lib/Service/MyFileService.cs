using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTask.Lib.Core;
using WebTask.Lib.DAL.Core;

namespace WebTask.Lib.Service
{
     class MyFileService : IMyFileService
    {
        private readonly DBTaskContext _context;
        public MyFileService(DbContextOptions option)
        {
            _context = new DBTaskContext(option);
        }
        public async Task<MyFile> Add(MyFile file, byte[] data)
        {
            var guid = Guid.NewGuid();

            var task = await _context.Task.FirstAsync(x => x.Id == file.TaskId);

            var ft = new FileTable
            {
                Created = DateTime.Now,
                Id = guid,
                Name = file.Name,
                Size = file.Length,
                Task=task
            };
            var dt = new FileDataTable { Id = guid, Data = data,FileTable=ft };

            await _context.AddAsync(ft);
            await _context.AddAsync(dt);
            await _context.SaveChangesAsync();
            return ft.ToFile();
        }

        public async Task Delete(Guid Id)
        {
            var head = await _context.Files.FirstAsync(x => x.Id == Id);
            var data= await _context.FilesData.FirstAsync(x => x.FileTable.Id==head.Id);

            _context.Files.Remove(head);
            _context.FilesData.Remove(data);

            
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var files = await _context.Files.Where(x => x.Task.Id == Id).ToArrayAsync();
            foreach (var file in files)
            {
                await Delete(file.Id);
            }
        }

        public async Task<MyFileData> Get(Guid Id)
        {
            var dt = await _context.FilesData.FirstAsync(x => x.FileTable.Id == Id);
            var ht = await _context.Files.FirstAsync(x => x.Id == Id);
            return new MyFileData {Name=ht.Name,Length=ht.Size, Data = dt.Data };  
        }

        public async Task<IEnumerable<MyFile>> GetByTask(int IdMyTask)
        {
            var files = await _context.Files.Where(x => x.Task.Id == IdMyTask).ToArrayAsync();
           return files.ToFile();
        }
    }

}
