namespace backend.Utils.Common
{

    public class RouterItem
    {
        public string title;
        public string page;
    }
    public class Routers
    {
        public static readonly RouterItem Register = new RouterItem() { page = "/Views/Containers/Register.cshtml", title = "Register" };
        public static readonly RouterItem Login = new RouterItem() { page = "/Views/Containers/Login.cshtml", title = "Login" };
        public static readonly RouterItem Home = new RouterItem() { page = "/Views/Containers/Home.cshtml", title = "Home" };
    }
}