namespace backend.Utils.Common
{

    public class RouterItem
    {
        public string title;
        public string page;
        public string link;
    }
    public class Routers
    {
        public static readonly RouterItem Register = new RouterItem() { page = "/Views/Containers/Register.cshtml", title = "Register", link = "/auth/register" };
        public static readonly RouterItem Login = new RouterItem() { page = "/Views/Containers/Login.cshtml", title = "Login", link = "/auth/login" };
        public static readonly RouterItem Home = new RouterItem() { page = "/Views/Containers/Home.cshtml", title = "Home", link = "/" };
    }
}