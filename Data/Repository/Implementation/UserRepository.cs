using System;
using System.Linq;
using System.Linq.Expressions;
using Data.Repository.Contracts;
using DTOs.Models;
using Data.DataContext;

namespace Data.Repository.Implementation
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IDALServiceDataContext context;

        public UserRepository(IDALServiceDataContext context)
        {
            this.context = context;
        }

        public User FindEntity(Expression<Func<User, bool>> expression)
        {
            return context.Set<User>.FirstOrDefault(expression);
        }
    }
}
