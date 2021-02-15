using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<List<UserDetailDto>> GetUserDetailsDto(int userId);
        IDataResult<User> GetById(int userId);
        IResult Add(User user);
    }
}
