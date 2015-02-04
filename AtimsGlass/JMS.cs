using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using AtimsGlass.Models;

namespace AtimsGlass
{

    public class JMS : DbContext
    {
        public JMS()
            : base("name=JMS")
        {
        }

        public virtual DbSet<AppAO_Module> AppAO_Module { get; set; }
        public virtual DbSet<AppAO_SubModule> AppAO_SubModule { get; set; }

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
        }
    }
}
