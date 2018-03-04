using BanBrick.Infrastructure.Repositories.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BanBrick.Infrastructure.Repositories.Models
{
    public class FileSource
    {
        public FileSource() {
            FileSourceTypeString = ((FileSourceType)0).ToString();
        }

        public FileSource(FileSourceType fileSourceType)
        {
            FileSourceType = fileSourceType;
        }

        [Key]
        [Column("id")]
        [MaxLength(36)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Column("file_source_type")]
        [MaxLength(50)]
        public string FileSourceTypeString { get; private set; }

        public ICollection<File> Files { get; set; }

        [NotMapped]
        public FileSourceType FileSourceType {
            get => (FileSourceType)Enum.Parse(typeof(FileSourceType), FileSourceTypeString);
            set { FileSourceTypeString = value.ToString(); }
        }
    }
}
