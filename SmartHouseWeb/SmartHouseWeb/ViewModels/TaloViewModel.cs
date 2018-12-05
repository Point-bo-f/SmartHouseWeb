using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouseWeb.ViewModels
{
    public class TaloViewModel
    {
        public int TaloId { get; set; }
        public string TaloNimi { get; set; }
        public string TaloTavoiteLampo { get; set; }
        public string TaloNykyLampo { get; set; }
        public bool LampoOn { get; set; }
        public bool LampoOff { get; set; }
    }
}