using Data.DataContext;
using DTOs.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Data.Repository.Implementation
{
    public class RoleStore : RoleStore<Role, int, UserRole>
    {
        public RoleStore(DALServiceDataContext dalServiceDataContext) : base(dalServiceDataContext) { }
    }
}
