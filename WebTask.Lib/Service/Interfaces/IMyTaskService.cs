using System.Collections.Generic;
using System.Threading.Tasks;
using WebTask.Lib.Core;

namespace WebTask.Lib.Service
{
    public interface IMyTaskService
    {
        public  Task<MyTask> GetAsync(int Id);
        public Task<IEnumerable<MyTask>> GetAsync();

        public Task<MyTask> Add(string name);

        public Task Update(int id,string name);

        public Task Delete(int Id);
           

    }

}
