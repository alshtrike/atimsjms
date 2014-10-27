using System;
using System.Collections.Generic;

namespace GlassHouse.Models{

    // Models returned by LoginController actions.

    public class ManageInfoViewModel{
        public string LocalLoginProvider { get; set; }
        public string Email { get; set; }
        public IEnumerable<UserLoginInfoViewModel> Logins { get; set; }
    }

    public class UserInfoViewModel{
        public string Email{ get; set; }
    }

    public class UserLoginInfoViewModel{
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
    }
}
