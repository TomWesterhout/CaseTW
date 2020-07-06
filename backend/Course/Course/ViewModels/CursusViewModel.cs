using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Course.ViewModels
{
    public class CursusViewModel
    {
        public int Id { get; set; }

        public int Duur { get; set; }

        public string Titel { get; set; }

        public string Code { get; set; }

        public virtual ICollection<CursusInstantieViewModel> CursusInstanties { get; set; }
    }
}