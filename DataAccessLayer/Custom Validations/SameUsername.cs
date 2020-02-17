using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DataAccessLayer;
using DataAccessLayer.entities;

namespace DataAccessLayer.Custom_Validations
{
    public class SameUsername : ValidationAttribute
    {
        //AYNI NİCKNAME'DE KAYIT YAPMAYI ENGELLİYOR
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string name = value.ToString();
            Model1 ctx = new Model1();
            List<Users> liste = ctx.Users.ToList();
            //string password = ((UserViewModel)validationContext.ObjectInstance).Password;
            foreach (var item in liste)
            {
                if (name == item.Name)
                {
                    ValidationResult res = new ValidationResult("Nickname Kullanımda");
                    return res;
                }
            }
            return ValidationResult.Success;
        }


    }
}