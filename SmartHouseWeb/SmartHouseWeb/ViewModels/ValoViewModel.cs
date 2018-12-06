using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouseWeb.ViewModels
{
    public class ValoViewModel
    {
        public int ValoId { get; set; }
        public string Huone { get; set; }
        public bool ValoOff { get; set; }
        public bool Valo33 { get; set; }
        public bool Valo66 { get; set; }
        public bool Valo100 { get; set; }
        public bool ValoTilaOff { get;  set; }
    }
}