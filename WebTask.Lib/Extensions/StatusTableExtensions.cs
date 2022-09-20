using System.Collections.Generic;
using WebTask.Lib.Core;
using WebTask.Lib.DAL.Core;

namespace WebTask.Lib
{
    static class StatusTableExtensions
    {
        public static MyStatus ToStatus(this StatusTable status)
        {
            return new MyStatus { Id = status.Id, Name = status.Name };
        }

        public static IEnumerable<MyStatus> ToStatus(this StatusTable[] statuses)
        {
            foreach (var status in statuses)
            {
                yield return status.ToStatus();
            }
        }
    }

}
