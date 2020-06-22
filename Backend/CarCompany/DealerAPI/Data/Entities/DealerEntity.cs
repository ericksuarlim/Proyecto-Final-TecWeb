using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DealerAPI.Data.Entities
{
    public class DealerEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public int? Phone { get; set; }
        public string DealerWebsite { get; set; }
        public DateTime? Fundation { get; set; }
        public virtual ICollection<CarEntity> Cars { get; set; }
    }
}
