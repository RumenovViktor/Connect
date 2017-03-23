using Data.DataContext;
using DTOs.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Data
{
    public class UserStore : UserStore<User, Role, int, UserLogin, UserRole, UserClaim>
    {
        public UserStore(DALServiceDataContext dataContext) : base(dataContext) { }
    }
}
