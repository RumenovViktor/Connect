using DTOs.Models;
using System;
using System.Linq.Expressions;

namespace Data.Repository.Contracts
{
    public interface IUserRepository
    {
        User FindEntity(Expression<Func<User, bool>> expression);
    }
}
