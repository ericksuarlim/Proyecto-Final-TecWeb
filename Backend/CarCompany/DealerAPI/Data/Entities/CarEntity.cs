using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DealerAPI.Data.Entities
{
    public class CarEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
        [ForeignKey("DealerId")]
        public virtual DealerEntity Dealer { get; set; }
    }
}
