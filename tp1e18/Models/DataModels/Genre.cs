using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tp1e18.Models.DataModels
{
    public class Genre
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GenreId { get; set; }

        [MaxLength(50), Required]
        public string Nom { get; set; }

        [InverseProperty("Genres")]
        public virtual ICollection<Serie> Series { get; set; }
    }
}