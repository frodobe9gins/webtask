using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTask.Lib.Core;
using WebTask.Lib.DAL.Core;

namespace WebTask.Lib.Service
{

     class MyTaskService : IMyTaskService
    {
        private readonly DBTaskContext _context;
        private readonly IMyFileService _fileService;
        public MyTaskService(DbContextOptions  option, IMyFileService fileService)
        {
     

            _context = new DBTaskContext(option);
            _fileService = fileService;
        }

        public async Task<MyTask> Add(string name)
        {
            var statuses = await _context.Statuses.ToArrayAsync();
            var status = statuses.First();
            var x= await _context.AddAsync(new TaskTable { Name = name, Created = DateTime.Now, Status = status});
            _context.SaveChanges();
            return x.Entity.ToTask(status.ToStatus());
        }

        public async Task Delete(int Id)
        {
           var task=await _context.Task.FirstAsync(x => x.Id == Id);
            await _fileService.Delete(Id);
            _context.Task.Remove(task);
            _context.SaveChanges();
        }

        public async Task<MyTask> GetAsync(int Id)
        {
            var task = await _context.Task.FirstAsync(x => x.Id == Id);
            var files = await _fileService.GetByTask(Id);

            var status = await _context.Statuses.FirstAsync(x => x.Id == task.StatusId);
            var mytask= task.ToTask(status.ToStatus());
            mytask.Filles = files.ToArray();
            return mytask;
        }

        public async Task<IEnumerable<MyTask>> GetAsync()
        {
            var statuses = await _context.Statuses.ToArrayAsync();
            var tasks = await _context.Task.ToArrayAsync();
            return tasks.ToTask(statuses.ToStatus());
        }
       

        public async Task Update(int id,string name)
        {
            var tasks = await _context.Task.FirstAsync(x => x.Id == id);
            tasks.Name = name;
            _context.Task.Update(tasks);
            _context.SaveChanges();
        }
    }

}
