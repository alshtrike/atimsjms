using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlassHouse.Controllers{

    public class GlassHouseUserController : Controller{

        private GlassHouseUserManager _userManager;

        public GlassHouseUserController( ){

        }

        public GlassHouseUserController( GlassHouseUserManager userManager ){
            _userManager = userManager;
        }

        public ActionResult User( ){
            return View( );

        }

        // @TODO This shouldn't be readily accessible
        public ActionResult _LoginViewPartial( ){
            return View( );

        }

    }

}