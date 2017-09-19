using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuningStudioSite.Models.DbEntities
{
    public class Master
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }

        public decimal Money { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}