using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tp1e18.Models.DataModels
{
    public class GuideParental
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GuideParentalId { get; set; }

        [MaxLength(50), Required]
        public string Rate { get; set; }

        [InverseProperty("GuideParentals")]
        public virtual ICollection<Serie> Series { get; set; }
    }
}