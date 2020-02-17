using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Voyatur.Models
{
    public class IlanTip
    {
        public List<SelectListItem> IlanDropDown = new List<SelectListItem>()
        {
            new SelectListItem() {Text = "Yacth",Value="0"},
            new SelectListItem() {Text = "Organisation",Value="1"},
            new SelectListItem() {Text = "Tour",Value="2"}

        };
        public List<SelectListItem> ilandropdown()
        {
            return IlanDropDown;
        }

        public int enumilan(string ilan)
        {
            if(ilan == "Yacth")
            {
                return 0;
            }else if(ilan == "Organisation")
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }
}