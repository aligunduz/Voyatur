using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.entities
{
    public class Images : BaseEntity
    {
        [NotMapped]
        public string FilePath
        {
            get
            {
                return Product_Id + "_" + Id + ".jpg";
            }

        }
        public bool IsMain { get; set; }

        public int Tip { get; set; }
        public int? Product_Id { get; set; }

    }
}
