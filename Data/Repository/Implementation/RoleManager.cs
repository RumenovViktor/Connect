using DTOs.Models;
using Microsoft.AspNet.Identity;

namespace Data.Repository.Implementation
{
    public class RoleManager : RoleManager<Role, int>
    {
        public RoleManager(RoleStore roleStore) : base(roleStore) { }
    }
}
