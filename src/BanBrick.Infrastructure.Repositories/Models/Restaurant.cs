using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BanBrick.Infrastructure.Repositories.Models
{
    [Table("restaurants")]
    public class Restaurant
    {
        public Restaurant() {
            DeliveryServices = new HashSet<RestaurantService>();
        }

        [Key]
        [Column("id")]
        [MaxLength(36)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Column("name")]
        [MaxLength(255)]
        public string Name { get; set; }
        
        [Column("geo_point")]
        [MaxLength(36)]
        public string GeoPoint { get; set; }
        
        public ICollection<RestaurantService> DeliveryServices { get; set; }
    }
}
