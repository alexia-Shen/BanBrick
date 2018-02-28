using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BanBrick.Infrastructure.Repositories.Models
{
    [Table("restaurant")]
    public class Restaurant
    {
        public Restaurant() {
            DeliveryServices = new HashSet<DeliveryService>();
        }

        [Key]
        [Column("id")]
        [MaxLength(36)]
        public string Id { get; set; }

        [Column("name")]
        [MaxLength(255)]
        public string Name { get; set; }
        
        [Column("geo_point_identifier")]
        [MaxLength(36)]
        public string GeoPointIdentifier { get; set; }

        public ICollection<DeliveryService> DeliveryServices { get; set; }
    }
}
