using System.Security.Claims;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GlassHouse.Models{

    public class GlassHouseUser: IdentityUser{

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync( UserManager<GlassHouseUser> manager ){
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync( this, DefaultAuthenticationTypes.ApplicationCookie );
            // Add custom user claims here
            return userIdentity;

        }

    }

    public class GlassHouseDbContext: IdentityDbContext<GlassHouseUser>{

        public GlassHouseDbContext( ): base( "DefaultConnection", throwIfV1Schema: false ){

        }

        static GlassHouseDbContext( ){
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<GlassHouseDbContext>( new ApplicationDbInitializer( ) );
        }

        public static GlassHouseDbContext Create( ){
            return new GlassHouseDbContext( );
        }

    }

}