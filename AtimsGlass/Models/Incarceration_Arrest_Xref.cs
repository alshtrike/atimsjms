namespace AtimsGlass.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Incarceration_Arrest_Xref
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Incarceration_arrest_xref_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Incarceration_id { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int arrest_id { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Booking_Officer_ID { get; set; }

        public DateTime? Booking_Date { get; set; }

        public DateTime? Release_Date { get; set; }

        [StringLength(150)]
        public string Release_Reason { get; set; }

        [StringLength(1500)]
        public string Release_Notes { get; set; }

        public int? Release_Officer_ID { get; set; }

        public int? Reactivate_Flag { get; set; }

        public int? Elapsed_days { get; set; }

        public int? Incarceration_id_sealed { get; set; }

        public int? arrest_id_sealed { get; set; }

        public int? Release_Supervisor_Complete_Flag { get; set; }

        public int? Release_Supervisor_Complete_BY { get; set; }

        public DateTime? Release_Supervisor_Complete_Date { get; set; }

        public int? Release_Supervisor_Wizard_LastStep_Id { get; set; }

        public int? Booking_Supervisor_Complete_Flag { get; set; }

        public int? Booking_Supervisor_Complete_By { get; set; }

        public DateTime? Booking_Supervisor_Complete_Date { get; set; }

        public int? Clear_Supervisor_Complete_Flag { get; set; }

        public int? Clear_Supervisor_Complete_By { get; set; }

        public DateTime? Clear_Supervisor_Complete_Date { get; set; }

        public int? Clear_Supervisor_Wizard_LastStep_id { get; set; }
    }
}
