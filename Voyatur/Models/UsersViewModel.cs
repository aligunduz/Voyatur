using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Voyatur.Custom_Validations;

namespace Voyatur.Models
{
    public class UsersViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public string Name { get; set; }


        public string Surname { get; set; }

        public string Password { get; set; }

        [CheckEmail]
        public string EMail { get; set; }

        public bool UserType { get; set; }

    }
}