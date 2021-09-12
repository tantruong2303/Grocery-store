namespace Backend.Utils.Common
{

    public class RouterItem
    {
        public string Title;
        public string Page;
        public string Link;
    }
    public class Routers
    {

        //Auth Controller
        public static readonly RouterItem Register = new RouterItem() { Page = "/Views/Containers/Auth/Register.cshtml", Title = "Register", Link = "/auth/register" };
        public static readonly RouterItem Login = new RouterItem() { Page = "/Views/Containers/Auth/Login.cshtml", Title = "Login", Link = "/auth/login" };

        //User Controller
        public static readonly RouterItem User = new RouterItem() { Page = "/Views/Containers/User/User.cshtml", Title = "User", Link = "/user" };
        public static readonly RouterItem UpdatePassword = new RouterItem() { Page = "/Views/Containers/User/UpdatePassword.cshtml", Title = "Update Password", Link = "/user/password" };
        public static readonly RouterItem UpdateUserInfo = new RouterItem() { Page = "/Views/Containers/User/UpdateUserInfo.cshtml", Title = "Update User Info", Link = "/user/info" };
        //------------------------------------
        public static readonly RouterItem Home = new RouterItem() { Page = "/Views/Containers/Home.cshtml", Title = "Home", Link = "/" };
        public static readonly RouterItem Category = new RouterItem() { Page = "/Views/Containers/Category.cshtml", Title = "All Category", Link = "/category" };
        public static readonly RouterItem CreateCategory = new RouterItem() { Page = "/Views/Containers/CreateCategory.cshtml", Title = "Create Category", Link = "/category/create" };
        public static readonly RouterItem UpdateCategory = new RouterItem() { Page = "/Views/Containers/UpdateCategory.cshtml", Title = "Update Category", Link = "/category/update" };
        public static readonly RouterItem DeleteCategory = new RouterItem() { Page = "/Views/Containers/DeleteCategory.cshtml", Title = "Delete Category", Link = "/category/delete" };
        public static readonly RouterItem Product = new RouterItem() { Page = "/Views/Containers/Product.cshtml", Title = "All Product", Link = "/product" };
        public static readonly RouterItem CreateProduct = new RouterItem() { Page = "/Views/Containers/CreateProduct.cshtml", Title = "Create Product", Link = "/product/create" };
        public static readonly RouterItem Logout = new RouterItem() { Page = "/Views/Containers/CreateProduct.cshtml", Title = "Create Product", Link = "/auth/logout" };
    }
}