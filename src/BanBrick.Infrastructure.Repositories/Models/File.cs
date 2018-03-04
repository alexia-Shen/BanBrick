using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BanBrick.Infrastructure.Repositories.Models
{
    [Table("Files")]
    public class File
    {
        [Key]
        [Column("id")]
        [MaxLength(36)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Column("name")]
        [MaxLength(255)]
        public string Name { get; set; }
        
        [Column("file_path")]
        [MaxLength(255)]
        public string FilePath { get; set; }

        [Column("file_type")]
        [MaxLength(50)]
        public string FileType { get; set; }

        [Column("file_source_id")]
        [MaxLength(36)]
        public string FileSourceId { get; set; }

        public FileSource FileSource { get; set; }
    }
}
