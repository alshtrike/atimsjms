
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlassHouse.Controllers{

    [Authorize]
    public class UserController: Controller{

        /** Account Controller Views **/
        [AllowAnonymous]
        public ActionResult Login( ){
            return View( );

        }


    }

}