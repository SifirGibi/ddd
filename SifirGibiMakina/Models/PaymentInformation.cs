﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Models
{
    public class PaymentInformation
    {
        public string Id { get; set; }  
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string IdentityNumber { get; set; }
        public string Ip { get; set; }

      
        public string City { get; set; }    
        public string Country { get; set; }    
        public string Description { get; set; }    
        public string Phone { get; set; }


    }
}