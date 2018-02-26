using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BanBrick.Infrastructure.Repositories.Models
{
    public class Surburb
    {
        [Key]
        [MaxLength(50)]
        public string Code { get; set; }

        public MySqlGeometry Location { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
    }
}
