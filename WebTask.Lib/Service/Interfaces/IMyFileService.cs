using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebTask.Lib.Core;

namespace WebTask.Lib.Service
{
    public interface IMyFileService
    {
        public Task<MyFileData> Get(Guid Id);
        public Task<IEnumerable<MyFile>> GetByTask(int IdMyTask);

        public Task<MyFile> Add(MyFile file, byte[] data);
        public Task Delete(Guid Id);
        public Task Delete(int Id);

    }

}
