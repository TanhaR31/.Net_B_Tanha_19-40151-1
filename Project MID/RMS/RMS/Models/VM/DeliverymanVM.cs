using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RMS.Models.EF;

namespace RMS.Models.VM
{
    public class DeliverymanVM
    {
        public DeliverymanVM()
        {
            this.Deliveries = new HashSet<Delivery>();
        }

        public int Id { get; set; }
        [Required]
        public string DeliverymanName { get; set; }
        [Required]
        [StringLength(11)]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<Delivery> Deliveries { get; set; }
        public virtual User User { get; set; }
    }
}