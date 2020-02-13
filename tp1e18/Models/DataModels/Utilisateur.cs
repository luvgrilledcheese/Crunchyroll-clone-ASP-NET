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


        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UtilisateurId { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 4)]
        public string Username { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string MotDePasse { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Courriel { get; set; }



    }
}