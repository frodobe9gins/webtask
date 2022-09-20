using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebTask.Lib.Core;
using WebTask.Lib.DAL.Core;

namespace WebTask.Lib
{

    class DBTaskContext: DbContext
    {


        public DBTaskContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<TaskTable> Task { get; set; }
        public DbSet<StatusTable> Statuses { get; set; }
        public DbSet<FileTable> Files { get; set; }
        public DbSet<FileDataTable> FilesData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          //  optionsBuilder
          //      .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileTable>()
                .HasOne(x => x.FileDataTable)
                .WithOne(x => x.FileTable)
                .HasForeignKey<FileDataTable>(data => data.FileTableId);
            modelBuilder.Entity<TaskTable>()
                .HasOne(x => x.Status)
                .WithMany(x => x.Tasks)
                .HasForeignKey(x => x.StatusId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<TaskTable>()
                .HasMany(x => x.Files)
                .WithOne(x => x.Task)
                .HasForeignKey(x => x.TaskId).OnDelete(DeleteBehavior.NoAction);
            //base.OnModelCreating(modelBuilder);
        }



    }
   

}
