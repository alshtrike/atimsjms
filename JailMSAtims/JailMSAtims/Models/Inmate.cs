using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace JailMSAtims.Models
{
    public class Inmate
    {   
        public int Id { get; set; }
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        
        public int FacilityId { get; set; }

        
        //public Facility Facility { get;  set; }
    }
}