using Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Course.ViewModels
{
    public class CursusInstantieViewModel
    {
        public int Id { get; set; }

        public DateTime StartDatum { get; set; }

        public int CursusId { get; set; }

        public virtual Cursus Cursus { get; set; }
    }
}