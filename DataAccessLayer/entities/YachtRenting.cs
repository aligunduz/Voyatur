using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voyatur.Custom_Validations;

namespace DataAccessLayer.entities
{
    public class YachtRenting : BaseEntity
    {
        public int? YachtId { get; set; }

        public int? UserId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [CheckEmail]
        public string Email { get; set; }
        public string Note { get; set; }
        public virtual Users User { get; set; }
        public virtual Ships Ship { get; set; }
    }
}
