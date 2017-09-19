using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuningStudioSite.Models.DbEntities
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
   
        public string CompanyName { get; set; }

        public string Fax { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string SiteCatalog { get; set; }
        public virtual ICollection<Detail> Details { get; set; }
    }
}