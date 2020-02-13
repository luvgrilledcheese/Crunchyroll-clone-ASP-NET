using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tp1e18.Models.DataModels
{
    public class Utilisateur
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UtilisateurId { get; set; }

        public string Username { get; set; }

        public

    }
}