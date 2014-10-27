
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;

using GlassHouse.Models;

namespace GlassHouse.Controllers{

    [Authorize]
    [RoutePrefix("api/Account")]
    public class LoginController : ApiController{

        /** Account Controller Class **/
        public LoginController( ){}

        public LoginController( ApplicationUserManager userManager, ApplicationSignInManager signInManager ){
            UserManager = userManager;
            SignInManager = signInManager;
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager{
            get{
                return _userManager ?? HttpContext.Current.GetOwinContext( ).GetUserManager<ApplicationUserManager>();
            }
            private set{
                _userManager = value;
            }
        }


        private ApplicationSignInManager _signInManager;
        public ApplicationSignInManager SignInManager{
            get{
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set{
                _signInManager = value; 
            }
        }


        /** Account Information **/

        // GET api/Account/UserInfo
        [Route("UserInfo")]
        public UserInfoViewModel GetUserInfo( ){

            return new UserInfoViewModel{
                Email = User.Identity.GetUserName(),
            };

        }


        /** Account Actions **/

        // POST api/Account/Logout
        [Route("Logout")]
        public IHttpActionResult Logout( ){
            Authentication.SignOut( CookieAuthenticationDefaults.AuthenticationType );
            return Ok( );
        }




        /** HELPERS **/
        #region Helpers

        private IAuthenticationManager Authentication{
            get { return HttpContext.Current.GetOwinContext( ).Authentication; }
        }

        #endregion

    }

}
