using System.Security.Claims;
using System.Threading.Tasks;
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

    public class ApplicationDbContext: IdentityDbContext<GlassHouseUser>{

        public ApplicationDbContext( ): base( "DefaultConnection", throwIfV1Schema: false ){

        }

        public static ApplicationDbContext Create( ){
            return new ApplicationDbContext( );
        }

    }

}