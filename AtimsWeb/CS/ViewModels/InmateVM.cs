using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AtimsWeb.Models;

namespace AtimsWeb.ViewModels {
    public class InmateVM {
        public int Id;
        public string Number;
        public string FirstName;
        public string MiddleName;
        public string LastName;
        public short? Age;
        public DateTime? Dob;
        public string FacilityName;
        public DateTime? Recieved;
        public DateTime? Release;
        public string Status;
    }
}