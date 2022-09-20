using System;

namespace WebTask.Lib.Core
{
    public abstract class MyTaskAbstract
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public MyStatus Status { get; set; }
    }

    public class MyTask : MyTaskAbstract
    { 
        public MyFile[] Filles { get; set; }
    }
        
    
}
