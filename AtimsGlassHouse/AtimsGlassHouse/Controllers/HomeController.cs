using System.Web.Mvc;

namespace GlassHouse.Controllers{

    //[Authorize]
    [AllowAnonymous]
    public class HomeController : Controller{

        public ActionResult Index( ){
            return View( );
        }

        public ActionResult _NavBar( ){
            return View( );
        }

        public ActionResult _UserBar( ){
            return View( );
        }

    }

}
