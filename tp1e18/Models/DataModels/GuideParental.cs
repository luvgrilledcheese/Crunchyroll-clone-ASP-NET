﻿using System;
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

        [Index(IsUnique = true)]
        [MaxLength(50), Required]
        [Display(Name = "Nom du guide parental", Description = "Nom du guide parental")]
        public string Rate { get; set; }

        [InverseProperty("GuideParental")]
        public virtual ICollection<Serie> Series { get; set; } = new HashSet<Serie>();
    }
}