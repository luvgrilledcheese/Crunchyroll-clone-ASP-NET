﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace tp1e18.Models.DataModels
{
    public class Episode
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EpisodeId { get; set; }

        [MaxLength(50), Required]
        public string Titre { get; set; }
        
        [Required]
        public int NoEpisode { get; set; }

        [MaxLength(200), Required]
        [DataType(DataType.MultilineText)]
        public string Desc { get; set; }

        [Required]
        public int Duree { get; set; }

        [NotMapped]
        [Required]
        public string Cover { get => $"/Content/Images/Episodes/{this.EpisodeId}.jpg"; }

        [Required, MaxLength(255)]
        public string PhotoPath { get; set; }

        [ForeignKey("Saison")]
        public int SaisonId { get; set; }

        [InverseProperty("Episodes")]
        public virtual Saison Saison { get; set; }

        

    }
}