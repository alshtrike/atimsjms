using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlassHouse.Controllers{

    [AllowAnonymous]
    public class GlassHouseLoginController : Controller{

        private GlassHouseUserManager _userManager;

        public GlassHouseLoginController( ){

        }

        public GlassHouseLoginController( GlassHouseUserManager userManager ){
            _userManager = userManager;
        }

        public ActionResult Login( ){
            return View( );

        }

        // @TODO This shouldn't be readily accessible
        public ActionResult _LoginFormPartial( ){
            return View( );

        }

    }

}