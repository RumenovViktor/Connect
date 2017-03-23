using Data.DataContext;
using DTOs.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Data
{
    public class UserManager : UserManager<User, int>
    {
        public UserManager(UserStore userStore) : base(userStore) { }

        public static UserManager Create(IdentityFactoryOptions<UserManager> options, IOwinContext context)
        {
            var manager = new UserManager(new UserStore(context.Get<DALServiceDataContext>()));

            return manager;
        }
    }
}
