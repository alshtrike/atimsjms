using System.Web.Mvc;

namespace GlassHouse.Controllers{

    [Authorize]
    public class HomeController : Controller{

        public ActionResult Index( ){
            return View( );

        }

    }

}
