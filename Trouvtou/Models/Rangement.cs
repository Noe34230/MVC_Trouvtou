using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Trouvtou.Models
{
    public class Rangement
    {
        public int id { get; set; }

        [Display(Name = "Description")]
        [StringLength(50, MinimumLength = 2), Required]
        public string description { get; set; }


        [StringLength(20, MinimumLength = 2), Required]
        [Display(Name = "Couleur")]
        public string couleur {get;set;}


        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Description de l'objet en détail")]
        public string descriptionDetail{get;set;}


        [Display(Name = "Liste des objets dans le rangement")]
        public ICollection<Objet> listObjet {get;set;}
    }
}
