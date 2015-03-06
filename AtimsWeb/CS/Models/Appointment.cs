namespace AtimsWeb.Models{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    // @TODO: Incomplete Foreign Key's / Virtual Variables

    [Table("Appointment")]
    public partial class Appointment{

        [Key]
        public int appointment_id { get; set; }

        public int? inmate_id { get; set; }

        public int? record_of_matters_id { get; set; }

        public DateTime? appointment_date { get; set; }

        [StringLength(10)]
        public string appointment_time { get; set; }

        [StringLength(50)]
        public string appointment_place { get; set; }

        [StringLength(50)]
        public string appointment_reason { get; set; }

        [StringLength(50)]
        public string appointment_duration { get; set; }

        public DateTime? create_date { get; set; }

        public DateTime? update_date { get; set; }

        [StringLength(50)]
        public string appointment_location { get; set; }

        [StringLength(1500)]
        public string appointment_notes { get; set; }

        public int? inmate_trak_id { get; set; }

        public int? Transport_id { get; set; }

        [StringLength(200)]
        public string Transport_note { get; set; }

        public int? officer_id { get; set; }

        public int? appointment_type { get; set; }

        public int? Created_by { get; set; }

        public int? Updated_by { get; set; }

        public int? appointment_duration_min { get; set; }

        public DateTime? appointment_end { get; set; }

        public int? appointment_reoccur_flag { get; set; }

        public int? appointment_reoccur_sunday { get; set; }

        public int? appointment_reoccur_monday { get; set; }

        public int? appointment_reoccur_tuesday { get; set; }

        public int? appointment_reoccur_wednesday { get; set; }

        public int? appointment_reoccur_thursday { get; set; }

        public int? appointment_reoccur_friday { get; set; }

        public int? appointment_reoccur_saturday { get; set; }

        public int? appointment_reoccur_monthday1 { get; set; }

        public int? appointment_reoccur_monthday2 { get; set; }

        public DateTime? appointment_reoccur_enddate { get; set; }

        public int? Delete_flag { get; set; }

        public DateTime? Delete_date { get; set; }

        public int? Deleted_by { get; set; }

        public int? Program_id { get; set; }

        [StringLength(50)]
        public string Program_Instructor { get; set; }

        public int? External_ID { get; set; }

        public int? Disciplinary_Inmate_ID { get; set; }

        public int? facility_event_id { get; set; }

        public int? facility_event_facility_id { get; set; }

        [StringLength(50)]
        public string facility_event_housing_location { get; set; }

        [StringLength(50)]
        public string facility_event_housing_number { get; set; }

        public int? appointment_reoccur_yearday1 { get; set; }

        public int? appointment_reoccur_yearday2 { get; set; }

        public int? appointment_reoccur_yearday3 { get; set; }

        public int? appointment_reoccur_yearday4 { get; set; }
    }
}
