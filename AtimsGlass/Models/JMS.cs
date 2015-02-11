namespace AtimsGlass.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class JMS : DbContext
    {
        public JMS()
            : base("name=JMS")
        {
        }

        public virtual DbSet<AppAO_Module> AppAO_Module { get; set; }
        public virtual DbSet<AppAO_SubModule> AppAO_SubModule { get; set; }
        public virtual DbSet<Arrest> Arrests { get; set; }
        public virtual DbSet<Facility> Facilities { get; set; }
        public virtual DbSet<Housing_Unit> Housing_Unit { get; set; }
        public virtual DbSet<Incarceration> Incarcerations { get; set; }
        public virtual DbSet<Incarceration_Arrest_Xref> Incarceration_Arrest_Xref { get; set; }
        public virtual DbSet<Inmate> Inmates { get; set; }
        public virtual DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppAO_Module>()
                .Property(e => e.AppAO_Module_Name)
                .IsUnicode(false);

            modelBuilder.Entity<AppAO_Module>()
                .Property(e => e.AppAO_Module_LicenseDemoExpireDate)
                .IsUnicode(false);

            modelBuilder.Entity<AppAO_Module>()
                .Property(e => e.AppAO_Module_LicenseKey)
                .IsUnicode(false);

            modelBuilder.Entity<AppAO_Module>()
                .Property(e => e.AppAO_Module_ToolTip)
                .IsUnicode(false);

            modelBuilder.Entity<AppAO_Module>()
                .HasMany(e => e.AppAO_SubModule)
                .WithRequired(e => e.AppAO_Module)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AppAO_SubModule>()
                .Property(e => e.AppAO_SubModule_Name)
                .IsUnicode(false);

            modelBuilder.Entity<AppAO_SubModule>()
                .Property(e => e.AppAO_SubModule_usercontrol)
                .IsUnicode(false);

            modelBuilder.Entity<AppAO_SubModule>()
                .Property(e => e.AppAO_SubModule_ToolTip)
                .IsUnicode(false);

            modelBuilder.Entity<AppAO_SubModule>()
                .Property(e => e.AppAO_SubModule_Help)
                .IsUnicode(false);

            modelBuilder.Entity<AppAO_SubModule>()
                .Property(e => e.AppAO_SubModule_AddOn_LicenseKey)
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_booking_no)
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_ucr_number)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_ucr_transaction_type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_multiple_segment_indicator)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_ucr_code)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_fingerprint_by_DOJ)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_law_enforcement_disposition)
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_last_time_in_custody)
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_last_time_location)
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_last_time_crime)
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_location)
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_sentence_by_hour)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_arraignment_flag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_charges_filed_flag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_court_docket)
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_sentence_findings)
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_sentence_type)
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_sentence_description)
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_conditions_of_release)
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_non_compliance)
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_site_booking_no)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_pcn)
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_reactivate)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_juvenile_disposition)
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_law_disposition_turnover)
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_notes)
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_case_number)
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_officer_text)
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_sentence_fine_amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_sentence_fine_per_day)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_sentence_days_interval)
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_transporting_officer_text)
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.bail_amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.bail_type)
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.bail_receipt_number)
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_crime_code_type)
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.bail_posted_by)
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.Arrest_Conviction_Note)
                .IsUnicode(false);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_sentence_fine_paid)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_sentence_fine_to_serve)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Arrest>()
                .Property(e => e.arrest_sentence_fine_type)
                .IsUnicode(false);

            modelBuilder.Entity<Facility>()
                .Property(e => e.Facility_Abbr)
                .IsUnicode(false);

            modelBuilder.Entity<Facility>()
                .Property(e => e.Facility_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Housing_Unit>()
                .Property(e => e.housing_unit_location)
                .IsUnicode(false);

            modelBuilder.Entity<Housing_Unit>()
                .Property(e => e.housing_unit_number)
                .IsUnicode(false);

            modelBuilder.Entity<Housing_Unit>()
                .Property(e => e.housing_unit_bed_number)
                .IsUnicode(false);

            modelBuilder.Entity<Housing_Unit>()
                .Property(e => e.housing_unit_bed_location)
                .IsUnicode(false);

            modelBuilder.Entity<Housing_Unit>()
                .Property(e => e.housing_unit_out_of_service_note)
                .IsUnicode(false);

            modelBuilder.Entity<Housing_Unit>()
                .Property(e => e.Housing_Unit_Out_of_service_reason_)
                .IsUnicode(false);

            modelBuilder.Entity<Housing_Unit>()
                .Property(e => e.housing_unit_ClassifyRecString)
                .IsUnicode(false);

            modelBuilder.Entity<Incarceration>()
                .Property(e => e.Used_Person_Last)
                .IsUnicode(false);

            modelBuilder.Entity<Incarceration>()
                .Property(e => e.Used_Person_Frist)
                .IsUnicode(false);

            modelBuilder.Entity<Incarceration>()
                .Property(e => e.Used_Person_Middle)
                .IsUnicode(false);

            modelBuilder.Entity<Incarceration>()
                .Property(e => e.Used_Person_Suffix)
                .IsUnicode(false);

            modelBuilder.Entity<Incarceration>()
                .Property(e => e.Used_DOB)
                .IsUnicode(false);

            modelBuilder.Entity<Incarceration>()
                .Property(e => e.Used_DL)
                .IsUnicode(false);

            modelBuilder.Entity<Incarceration>()
                .Property(e => e.Used_DL_State)
                .IsUnicode(false);

            modelBuilder.Entity<Incarceration>()
                .Property(e => e.Used_Phone_Number)
                .IsUnicode(false);

            modelBuilder.Entity<Incarceration>()
                .Property(e => e.Used_SSN)
                .IsUnicode(false);

            modelBuilder.Entity<Incarceration>()
                .Property(e => e.Used_FBI)
                .IsUnicode(false);

            modelBuilder.Entity<Incarceration>()
                .Property(e => e.Used_CII)
                .IsUnicode(false);

            modelBuilder.Entity<Incarceration>()
                .Property(e => e.Used_Alien)
                .IsUnicode(false);

            modelBuilder.Entity<Incarceration>()
                .Property(e => e.Overall_Condition_of_Release)
                .IsUnicode(false);

            modelBuilder.Entity<Incarceration>()
                .Property(e => e.Overall_Release_Information)
                .IsUnicode(false);

            modelBuilder.Entity<Incarceration>()
                .Property(e => e.Release_To_Other_Agency_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Incarceration>()
                .Property(e => e.Transport_Hold_name)
                .IsUnicode(false);

            modelBuilder.Entity<Incarceration>()
                .Property(e => e.Transport_Instructions)
                .IsUnicode(false);

            modelBuilder.Entity<Incarceration>()
                .Property(e => e.Transport_inmate_cautions)
                .IsUnicode(false);

            modelBuilder.Entity<Incarceration>()
                .Property(e => e.Transport_inmate_bail)
                .IsUnicode(false);

            modelBuilder.Entity<Incarceration>()
                .Property(e => e.bail_amount_Total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Incarceration>()
                .Property(e => e.Charge_Level)
                .IsUnicode(false);

            modelBuilder.Entity<Incarceration_Arrest_Xref>()
                .Property(e => e.Release_Reason)
                .IsUnicode(false);

            modelBuilder.Entity<Incarceration_Arrest_Xref>()
                .Property(e => e.Release_Notes)
                .IsUnicode(false);

            modelBuilder.Entity<Inmate>()
                .Property(e => e.inmate_security_level)
                .IsUnicode(false);

            modelBuilder.Entity<Inmate>()
                .Property(e => e.inmate_number)
                .IsUnicode(false);

            modelBuilder.Entity<Inmate>()
                .Property(e => e.inmate_status)
                .IsUnicode(false);

            modelBuilder.Entity<Inmate>()
                .Property(e => e.inmate_wristband_id)
                .IsUnicode(false);

            modelBuilder.Entity<Inmate>()
                .Property(e => e.inmate_contract_housing)
                .IsUnicode(false);

            modelBuilder.Entity<Inmate>()
                .Property(e => e.inmate_footlocker)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Inmate>()
                .Property(e => e.inmate_site_number)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Inmate>()
                .Property(e => e.inmate_personal_inventory)
                .IsUnicode(false);

            modelBuilder.Entity<Inmate>()
                .Property(e => e.inmate_Current_Track)
                .IsUnicode(false);

            modelBuilder.Entity<Inmate>()
                .Property(e => e.inmate_balance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Inmate>()
                .Property(e => e.inmate_deposited_balance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Inmate>()
                .Property(e => e.inmate_debt)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Inmate>()
                .Property(e => e.inmate_medical_flags)
                .IsUnicode(false);

            modelBuilder.Entity<Inmate>()
                .Property(e => e.inmate_class_flags)
                .IsUnicode(false);

            modelBuilder.Entity<Inmate>()
                .Property(e => e.Phone_Pin)
                .IsUnicode(false);

            modelBuilder.Entity<Inmate>()
                .Property(e => e.supply_shirt)
                .IsUnicode(false);

            modelBuilder.Entity<Inmate>()
                .Property(e => e.supply_pants)
                .IsUnicode(false);

            modelBuilder.Entity<Inmate>()
                .Property(e => e.supply_shoes)
                .IsUnicode(false);

            modelBuilder.Entity<Inmate>()
                .Property(e => e.supply_underwear)
                .IsUnicode(false);

            modelBuilder.Entity<Inmate>()
                .Property(e => e.supply_bra)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_first_name)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_middle_name)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_last_name)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_phone)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_business_phone)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_business_fax)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_place_of_birth)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_dl_number)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_dl_State)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_dl_class)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_other_id_type)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_other_id_number)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_other_id_state)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_ssn)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_contact_relationship)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_suffix)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_site_id)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_site_bnum)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_fbi_no)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_deceased)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_missing)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_maiden_name)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_number)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_phone_2)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_cell_phone)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_email)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_notes)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_cii)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_alien_no)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_place_of_birth_list)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_doc)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_fpc_number)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_caution_flag)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.person_fcn_number)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.FKN_last_name)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.FKN_first_name)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.FKN_middle_name)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.FKN_suffix_name)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Person_Fingerprint_Image_Path)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.AFIS_Number)
                .IsUnicode(false);
        }
    }
}
