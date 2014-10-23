using GlassHouse.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace GlassHouse{


    // AKA "Startup.Auth.cs"
    public partial class Startup{

        int COOKIE_VALIDATE_TIME = 30;

        public void ConfigureAuth( IAppBuilder app ){
            app.CreatePerOwinContext( GlassHouseDbContext.Create );
            app.CreatePerOwinContext<GlassHouseUserManager>( GlassHouseUserManager.Create );

            // ME LOVE COOKIES *nomnomnom*
            app.UseCookieAuthentication(
                new CookieAuthenticationOptions{
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString( "/GlassHouseLogin/Login" ),
                    Provider = new CookieAuthenticationProvider{
                        OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<GlassHouseUserManager, GlassHouseUser>(
                            validateInterval: TimeSpan.FromMinutes(COOKIE_VALIDATE_TIME),
                            regenerateIdentity: ( manager, user ) => user.GenerateUserIdentityAsync( manager ) )
                    }
                }
            );

            app.UseExternalSignInCookie( DefaultAuthenticationTypes.ExternalCookie );

        }

    }



    // AKA "IdentityConfig.cs"
    public class GlassHouseUserManager : UserManager<GlassHouseUser>{

        public GlassHouseUserManager( IUserStore<GlassHouseUser> store )
            : base( store ){}

        public static GlassHouseUserManager Create(
                IdentityFactoryOptions<GlassHouseUserManager> options, IOwinContext context ){

            var manager = new GlassHouseUserManager(
                new UserStore<GlassHouseUser>( context.Get<GlassHouseDbContext>( ) ) );

            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<GlassHouseUser>( manager ){
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator{
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes( 5 );
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            var dataProtectionProvider = options.DataProtectionProvider;
            if( dataProtectionProvider != null ){
                manager.UserTokenProvider = new DataProtectorTokenProvider<GlassHouseUser>(
                    dataProtectionProvider.Create( "GlassHouse Identity" ) );
            }

            return manager;

        }

    }

    public class GlassHouseRoleManager : RoleManager<IdentityRole>
    {

        public GlassHouseRoleManager( IRoleStore<IdentityRole,string> roleStore ): base( roleStore ){

        }

        public static GlassHouseRoleManager Create( IdentityFactoryOptions<GlassHouseRoleManager> options, IOwinContext context ){
            return new GlassHouseRoleManager( new RoleStore<IdentityRole>( context.Get<GlassHouseDbContext>( ) ) );
        }
    }


    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<GlassHouseDbContext>{

        protected override void Seed( GlassHouseDbContext context){
            InitializeIdentityForEF( context );
            base.Seed( context );
        }

        //Create User=Admin@Admin.com with password=Admin@123456 in the Admin role        
        public static void InitializeIdentityForEF( GlassHouseDbContext db ){
            var userManager = HttpContext.Current.GetOwinContext( ).GetUserManager<GlassHouseUserManager>( );
            var roleManager = HttpContext.Current.GetOwinContext( ).Get<GlassHouseRoleManager>( );
            const string name = "admin@example.com";
            const string password = "Admin@123456";
            const string roleName = "Admin";

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName( roleName );
            if( role == null ){
                role = new IdentityRole( roleName );
                var roleresult = roleManager.Create( role );
            }

            var user = userManager.FindByName( name );
            if( user == null ){
                user = new GlassHouseUser { UserName = name, Email = name };
                var result = userManager.Create( user, password );
                result = userManager.SetLockoutEnabled( user.Id, false );
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles( user.Id );
            if( !rolesForUser.Contains( role.Name ) ){
                var result = userManager.AddToRole( user.Id, role.Name );
            }

        }

    }


    public class GlassHouseSignInManager: SignInManager<GlassHouseUser, string>{

        public GlassHouseSignInManager( GlassHouseUserManager userManager, IAuthenticationManager authenticationManager ):
            base( userManager, authenticationManager ){
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync( GlassHouseUser user){
            return user.GenerateUserIdentityAsync( (GlassHouseUserManager) UserManager);
        }

        public static GlassHouseSignInManager Create(
                IdentityFactoryOptions<GlassHouseSignInManager> options, IOwinContext context ){
            return new GlassHouseSignInManager( context.GetUserManager<GlassHouseUserManager>( ), context.Authentication );
        }

    }

}