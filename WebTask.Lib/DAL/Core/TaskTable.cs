using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebTask.Lib.DAL.Core
{
    [Index("Name", IsUnique = true)]
    class TaskTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public int StatusId { get; set; }
        public StatusTable Status { get; set; }         
        public virtual ICollection<FileTable> Files { get; set; }
    }

}
