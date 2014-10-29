using System.Web.Mvc;

namespace GlassHouse.Controllers{

    //[Authorize]
    [AllowAnonymous]
    public class HomeController : Controller{

        public ActionResult Index( ){
            return View( );
        }

    }

}
