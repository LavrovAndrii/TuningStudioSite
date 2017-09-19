using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuningStudioSite.Models.DbEntities
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int IdClient { get; set; }
        public int IdMaster { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public virtual Client Client { get; set; }
        public virtual Master Master { get; set; }
        public virtual ICollection<DetailTask> DetailTasks { get; set; }
    }
}