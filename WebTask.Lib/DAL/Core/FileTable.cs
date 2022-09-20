using System;
using System.ComponentModel.DataAnnotations;

namespace WebTask.Lib.DAL.Core
{
    class FileTable
    {
        [Key]
        public Guid Id { get; set; } 
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        public int Size { get; set; }
        public DateTime Created { get; set; } 
        
        public int TaskId { get; set; }
        public TaskTable Task { get; set; }
        
        public FileDataTable FileDataTable { get; set; }

    }

}
