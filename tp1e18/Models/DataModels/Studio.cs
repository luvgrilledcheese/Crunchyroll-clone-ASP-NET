using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace tp1e18.Models.DataModels
{
    public class Studio
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudioId { get; set; }

        [Required]
        public string NomStudio { get; set; }

        [InverseProperty("Studio")]
        public virtual ICollection<Serie> Series { get; set; }
    }
}