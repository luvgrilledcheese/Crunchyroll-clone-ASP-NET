using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace tp1e18.Models.DataModels
{
    public class Utilisateur
    {
        
        public int UtilisateurId { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 4)]
        public string Username { get; set; }

        public string Password { get; set; }
    }
}