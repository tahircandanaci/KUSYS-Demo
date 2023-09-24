using Domain;
using Domain.Entities;

namespace Web
{
    public class Helper
    {
        public static bool IsLogin = false;
        public static int AuthId = -1;
        public static int AuthRoleId = -1;
        public static string AuthUsername = string.Empty;
        public static bool CheckSession(HttpContext httpContext)
        {
            return !String.IsNullOrEmpty(httpContext.Session.GetString(Constants.strSessionUsername));
        }

        public static void SetUserSession(HttpContext httpContext, User user)
        {
            httpContext.Session.SetString(Constants.strSessionUsername, user.Username);
            httpContext.Session.SetString(Constants.strSessionRole, user.RoleId.ToString());
            IsLogin = true;
            AuthId = user.Id;
            AuthRoleId = user.RoleId;
            AuthUsername = user.Username;
        }

        public static void ClearSession(HttpContext httpContext)
        {
            httpContext.Session.Remove(Constants.strSessionUsername);
            httpContext.Session.Remove(Constants.strSessionUsername);
            IsLogin = false;
            AuthId = -1;
            AuthRoleId = -1;
            AuthUsername = string.Empty;
        }
    }
}
