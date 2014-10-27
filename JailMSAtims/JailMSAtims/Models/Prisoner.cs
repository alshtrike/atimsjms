using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace JailMSAtims.Models
{
    public class Prisoner
    {
        [Key]
        public int ID { get; set;}

        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Age")]
        public int Age { get; set; }
    }
    public class PrisonerDBContext : DbContext {

        public DbSet<Prisoner> Prisoners { get; set; }
    
    }
}