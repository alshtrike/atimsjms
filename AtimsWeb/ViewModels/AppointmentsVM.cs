using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtimsWeb.ViewModels
{
    public class AppointmentsVM
    {
        public DateTime? appointment_date;
        public DateTime? appointment_end;
        public String appointment_time;
        public String appointment_place;
        public String appointment_reason;
        public String appointment_notes;
    }
}