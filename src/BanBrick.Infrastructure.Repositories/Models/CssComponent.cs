using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BanBrick.Infrastructure.Repositories.Models
{
    [Table("css_components")]
    public class CssComponent
    {
        [Key]
        [Column("id")]
        [MaxLength(36)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string QuerySelector { get; set; }

        [Column("style", TypeName = "text")]
        public string Style { get; set; }
    }
}
