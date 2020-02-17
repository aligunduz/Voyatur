using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.entities
{
    public class Tours : BaseEntity
    {
        private Model1 ctx = new Model1();
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public string Place { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public DateTime EndDate { get; set; }

        [NotMapped]
        public List<Images> img
        {
            get
            {
                return ctx.Images.Where(c => c.Tip == 2 && c.Product_Id == Id).ToList();
            }
        }
    }
}
