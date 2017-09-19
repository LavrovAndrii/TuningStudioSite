using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuningStudioSite.Models.DbEntities
{
    public class Detail
    {
        [Key]
        public int Id { get; set; }

        public int IdSupplier { get; set; }

        public string NameDetail { get; set; }

        public decimal Price { get; set; }

        public int Count { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<DetailTask> DetailTasks { get; set; }
    }
}