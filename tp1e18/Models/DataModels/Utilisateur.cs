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
        [RegularExpression(@"^[A-Za-z]{1,1}[A-Za-z0-9]{3,14}$")]
        [Display(Name = "Nom d'utilisateur", Description = "Votre nom d'utilisateur.")]
        public string NomUtilisateur { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de Passe", Description = "Votre mot de passe.")]
        public string MotDePasse { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Courriel", Description = "Votre adresse de courriel.")]
        public string Courriel { get; set; }

        [InverseProperty("Utilisateurs")]
        public virtual ICollection<Serie> Series { get; set; } = new HashSet<Serie>();
    }
}