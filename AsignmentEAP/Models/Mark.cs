using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AsignmentEAP.Models
{
    public class Mark
    {
        public Mark()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdateAt = DateTime.Now;
            this.Practice = 0;
            this.Theory = 0;
            this.Assignment = 0;
        }
        public int Id { get; set; }
        public int Theory { get; set; }
        public int Practice { get; set; }
        public int Assignment { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        [ForeignKey("Id")]
        public Subject Subject { get; set; }
         
    }
}
