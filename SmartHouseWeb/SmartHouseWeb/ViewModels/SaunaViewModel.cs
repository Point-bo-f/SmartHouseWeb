using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouseWeb.ViewModels
{
    public class SaunaViewModel
    {
        public int SaunaId { get; set; }
        public string SaunaNimi { get; set; }
        public string SaunaTavoiteLampotila { get; set; }
        public string SaunaNykyLampotila { get; set; }
        public bool? SaunanTila { get; set; }

    }
}