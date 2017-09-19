using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuningStudioSite.Models.DbEntities
{
    public class DetailTask
    {
        [Key]
        public int Id { get; set; }
        public int IdDetail { get; set; }
        public int IdTask { get; set; }
        public virtual Detail Detail { get; set; }
        public virtual Task Task { get; set; }
    }
}