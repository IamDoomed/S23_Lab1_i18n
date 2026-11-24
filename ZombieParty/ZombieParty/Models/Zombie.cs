using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ZombieParty.Models
{
    public class Zombie
    {
        public int Id { get; set; }

        [StringLength(20, MinimumLength = 5, ErrorMessage = "ValidationStringMinMax")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "ShortDesc")]
        [StringLength(255, ErrorMessage = "ValidationStringMax")]
        public string ShortDesc { get; set; }

        [Display(Name = "Points")]
        [Required(ErrorMessage = "RequiredValidation")]
        [Range(1, 20, ErrorMessage = "RangeValidation")]
        public int Point { get; set; }

        [Display(Name = "Force")]
        public int Force { get; set; }

        [Display(Name = "Image")]
        [ValidateNever]
        public string Image { get; set; }

        // FACULTATIF on peut formellement identifier le champ lien
        // sinon le champ de foreignKey sera auto généré dans la BD
        [Display(Name = "ZombieType")]
        [ForeignKey("ZombieType")]
        public int ZombieTypeId { get; set; }
        [ValidateNever] 
        public virtual ZombieType? ZombieType { get; set; }

        [Display(Name = "HuntingLogs")]
        [ValidateNever] 
        public virtual List<HuntingLog> HuntingLogs { get; set; }
    }
}
