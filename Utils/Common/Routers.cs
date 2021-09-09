namespace backend.Utils.Common
{

    public class RouterItem
    {
        public string title;
        public string page;
    }
    public class Routers
    {
        public static readonly RouterItem Register = new RouterItem() { page = "Register", title = "Register" };
    }
}