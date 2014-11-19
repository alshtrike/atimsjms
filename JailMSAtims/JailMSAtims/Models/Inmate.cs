using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JailMSAtims.Models
{
    public class Inmate
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}