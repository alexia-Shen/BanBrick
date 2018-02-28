using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BanBrick.Infrastructure.Repositories.Models
{
    [Table("delivery_services")]
    public class DeliveryService
    {
        [Key]
        [Column("id")]
        [MaxLength(36)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [MaxLength(50)]
        [Column("name")]
        public string Name { get; set; }

        [Column("restaurant_id")]
        public string RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}
