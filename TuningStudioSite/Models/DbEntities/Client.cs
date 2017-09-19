using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuningStudioSite.Models.DbEntities
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Car { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}