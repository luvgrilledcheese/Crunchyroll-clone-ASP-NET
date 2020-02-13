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

        public string Username { get; set; }
        // Hey testing this
        [Required][Display]
        public string Password { get; set; }

        [InverseProperty("Utilisateurs")]
        public virtual ICollection<Serie> Series { get; set; }
    }
}