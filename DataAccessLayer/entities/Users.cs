using DataAccessLayer.Custom_Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voyatur.Custom_Validations;

namespace DataAccessLayer.entities
{
    public partial class Users : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            RentedYachtes = new HashSet<YachtRenting>();
        }
        [SameUsername]
        public string UserName { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }
        [StringLength(20,ErrorMessage ="Şifre 5 karakterden küçük olamaz",MinimumLength =5)]
        public string Password { get; set; }

        [CheckEmail]
        public string EMail { get; set; }

        public bool UserType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<YachtRenting> RentedYachtes { get; set; }


    }
}
