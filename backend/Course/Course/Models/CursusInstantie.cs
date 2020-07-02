using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Course.Models
{
    public class CursusInstantie
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Een startdatum is vereist")]
        public DateTime StartDatum { get; set; }

        [Required]
        public int CursusId { get; set; }

        public virtual Cursus Cursus { get; set; }
    }
}