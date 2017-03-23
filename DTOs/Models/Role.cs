using Microsoft.AspNet.Identity.EntityFramework;

namespace DTOs.Models
{
    public class Role : IdentityRole<int, UserRole>
    {
        public Role() { }

        public Role(string name)
        {
            this.Name = name;
        }
    }
}
