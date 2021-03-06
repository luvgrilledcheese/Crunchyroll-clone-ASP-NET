﻿using System;
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

        [Index(IsUnique = true)]
        [MaxLength(50), Required]
        [Display(Name = "Nom", Description = "Nom du genre")]
        public string Nom { get; set; }

        [InverseProperty("Genres")]
        public virtual ICollection<Serie> Series { get; set; } = new HashSet<Serie>();
    }
}