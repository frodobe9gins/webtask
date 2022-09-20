using System;
using System.ComponentModel.DataAnnotations;

namespace WebTask.Lib.DAL.Core
{
    /// <summary>
    /// для больших файлов заголовок разделен с телом, чтобы тело можно было отдельно подгружать при необходимости.
    /// </summary>
    class FileDataTable
    {
        [Key]
        public Guid Id { get; set; }
        public byte[] Data { get; set; }

        public Guid FileTableId { get; set; }

        public FileTable FileTable { get; set; }

    }

}
