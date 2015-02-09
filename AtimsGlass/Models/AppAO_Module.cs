namespace AtimsGlass.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AppAO_Module
    {
        public AppAO_Module()
        {
            AppAO_SubModule = new HashSet<AppAO_SubModule>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AppAO_Module_id { get; set; }

        public int AppAO_id { get; set; }

        [Required]
        [StringLength(50)]
        public string AppAO_Module_Name { get; set; }

        public int AppAO_Module_visible { get; set; }

        public int? AppAO_Module_LicenseFlag { get; set; }

        [StringLength(10)]
        public string AppAO_Module_LicenseDemoExpireDate { get; set; }

        [StringLength(16)]
        public string AppAO_Module_LicenseKey { get; set; }

        public int? AppAO_Module_Request { get; set; }

        public int AppAO_Module_order { get; set; }

        [StringLength(150)]
        public string AppAO_Module_ToolTip { get; set; }

        public virtual ICollection<AppAO_SubModule> AppAO_SubModule { get; set; }
    }
}
