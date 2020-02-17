using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.entities
{
    public class ErrorLog :BaseEntity
    {
        public string Error { get; set; }

        public string rawUrl { get; set; }

        [ForeignKey("Users")]
        public int UserId { get; set; }

        public virtual Users Users { get; set; }
    }
}
