using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.entities
{
    public class Ships : BaseEntity
    {
        private Model1 ctx = new Model1();
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ships()
        {
            RentedYachtes = new HashSet<YachtRenting>();
        }
        public string Name { get; set; }

        

        public int Kapasite { get; set; }

        public string Place { get; set; }

        public decimal Price { get; set; }

        public string ShipType { get; set; }

        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<YachtRenting> RentedYachtes { get; set; }

        [NotMapped]
        public List<Images> img
        {
            get
            {
                return ctx.Images.Where(c => c.Tip == 0 && c.Product_Id == Id).ToList();
            }
        }
        [NotMapped]
        public string gemitipi
        {
            get
            {
                if (ShipType == "0")
                {
                    return "Gulet";
                }else if (ShipType == "1")
                {
                    return "Motoryat";
                }else if (ShipType == "2")
                {
                    return "Katamaran";
                }else
                {
                    return "Yelkenli";
                }
                
            }
        }
    }
}
