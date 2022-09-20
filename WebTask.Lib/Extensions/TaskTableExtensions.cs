using System.Collections.Generic;
using System.Linq;
using WebTask.Lib.Core;
using WebTask.Lib.DAL.Core;

namespace WebTask.Lib
{
    static class FileTableExtensions
    {
        public static IEnumerable<MyFile> ToFile(this FileTable[] files)
        {
            foreach (var file in files)
            {
                yield return file.ToFile();
            }
        }

        public static MyFile ToFile(this FileTable file)
        {
            return new MyFile { Id = file.Id, Name = file.Name, Length = file.Size,TaskId=file.TaskId };
            
        }
    }

    static class TaskTableExtensions
    {
        public static MyTask ToTask(this TaskTable task, IEnumerable<MyStatus> status)
        {
            return new MyTask { Id = task.Id, Date = task.Created, Name = task.Name, Status = status.First(x => x.Id == task.StatusId) };
        }

        public static MyTask ToTask(this TaskTable task, MyStatus status)
        {
            return new MyTask { Id = task.Id, Date = task.Created, Name = task.Name, Status = status };
        }
        public static IEnumerable<MyTask> ToTask(this TaskTable[] tasks, IEnumerable<MyStatus> status)
        {
            for (int i = 0; i < tasks.Length; i++)
            {
                yield return tasks[i].ToTask(status);
            }
        }



    }
}
