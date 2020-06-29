using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Course.Models
{
    public class Cursus
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "De duur is vereist")]
        public int Duur { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "Een titel is vereist en mag niet langer zijn dan 300 karakters")]
        public string Titel { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(10, ErrorMessage = "Een code is vereist en mag niet langer zijn dan 300 karakters")]
        public string Code { get; set; }

        public virtual ICollection<CursusInstantie> CursusInstanties { get; set; }
    }
}