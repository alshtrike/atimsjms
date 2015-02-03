using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_Tester.Models
{
    public class Inmate
    {
        public int ID { get; set; }
        public string name { get; set; }
        public DateTime DOB { get; set; }
    }
}