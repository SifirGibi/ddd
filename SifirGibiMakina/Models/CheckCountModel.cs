using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Models
{
    public class CheckCountModel
    {
        public int CountActiveMachine { get; set; }
        public bool IsUser {  get; set; }   
        public Nullable< int> MaxAds { get; set; }
    }
}