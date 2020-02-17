using DataAccessLayer;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace Voyatur.Custom_Validations
{
    public class CheckEmail : ValidationAttribute
    {
        // GEÇERLİ BİR EMAİL ADRESİ KONTROLÜ
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            try
            {
                MailAddress m = new MailAddress(value.ToString());
                return ValidationResult.Success;
            }
            catch (Exception)
            {
                ValidationResult res = new ValidationResult("Düzgün bir mail gir");
                return res;
            }

        }
    }
}
//string x = "\\w + ([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
//Regex regex = new Regex(x);
//Match match = regex.Match(mail);