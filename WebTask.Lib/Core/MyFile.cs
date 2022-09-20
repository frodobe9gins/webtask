using System;

namespace WebTask.Lib.Core
{
    public class MyFile
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public int TaskId { get; set; }
    }

    public class MyFileData
    {
        public int Length { get; set; }
        public string Name { get; set; }
        public byte[] Data { get; set; }
    }
    
}
