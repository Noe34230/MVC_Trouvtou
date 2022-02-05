using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trouvtou.Models
{
    public class Objet
    {
        public int id { get; set; }

        [StringLength(20, MinimumLength = 2), Required]
        [Display(Name = "Nom")]
        public string nom { get; set; }


        [StringLength(50, MinimumLength = 2), Required]
        [Display(Name = "Description")]
        public string description { get; set; }


        [StringLength(20, MinimumLength = 2), Required]
        [Display(Name = "Catégorie de l'objet")]
        public string typeObjet { get; set; }


        [Display(Name = "L'objet est consultable")]
        public bool estConsultable {get;set;}

        
        [Display(Name = "Date du dernier rangement")]
        [DataType(DataType.Date)]
        public DateTime dateDernierRangement { get; set; }

        
        [Display(Name = "Rangement")]
        // [ForeignKey(nameof(rangementid))]
        public int? rangementid {get;set;}
        [Display(Name = "Rangement")]
        public Rangement rangement { get; set; }


    }
}
