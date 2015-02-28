using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtimsWeb.ViewModels
{
    public class InmateVM
    {
        public string inmate_number;
        public DateTime inmate_received_date;
        public string inmate_status;
        public DateTime? inmate_scheduled_release_date;
        public string inmate_personal_inventory;
        public decimal? inmate_balance;
        public decimal? inmate_deposited_balance;
        public decimal? inmate_debt;
        public string inmate_medical_flags;
        public string inmate_class_flags;
        public int inmate_active;
    }
}