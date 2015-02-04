using System.Web.Http;
using System.Web.Script.Serialization;
using System.Collections;

namespace AtimsGlass.Controllers
{
    public class ModuleController : ApiController
    {

        private JMS moduleContext = new JMS( );
        private JavaScriptSerializer jss = new JavaScriptSerializer();

        public string Get( ){
            return jss.Serialize( moduleContext.AppAO_Module );
        }

    }
}
