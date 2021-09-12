namespace Backend.Utils.Common
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
        public static readonly RouterItem User = new RouterItem() { page = "/Views/Containers/User.cshtml", title = "User", link = "/user" };
        public static readonly RouterItem UpdatePassword = new RouterItem() { page = "/Views/Containers/UpdatePassword.cshtml", title = "Update Password", link = "/user/password" };
        public static readonly RouterItem UpdateUserInfo = new RouterItem() { page = "/Views/Containers/UpdateUserInfo.cshtml", title = "Update User Info", link = "/user/info" };
        public static readonly RouterItem Category = new RouterItem() { page = "/Views/Containers/Category.cshtml", title = "All Category", link = "/category" };
        public static readonly RouterItem CreateCategory = new RouterItem() { page = "/Views/Containers/CreateCategory.cshtml", title = "Create Category", link = "/category/create" };
        public static readonly RouterItem UpdateCategory = new RouterItem() { page = "/Views/Containers/UpdateCategory.cshtml", title = "Update Category", link = "/category/update" };
        public static readonly RouterItem DeleteCategory = new RouterItem() { page = "/Views/Containers/DeleteCategory.cshtml", title = "Delete Category", link = "/category/delete" };
        public static readonly RouterItem Product = new RouterItem() { page = "/Views/Containers/Product.cshtml", title = "All Product", link = "/product" };
        public static readonly RouterItem CreateProduct = new RouterItem() { page = "/Views/Containers/CreateProduct.cshtml", title = "Create Product", link = "/product/create" };
    }
}