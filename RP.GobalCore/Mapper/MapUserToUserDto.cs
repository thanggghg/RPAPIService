using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RP.Common.Models;
using RP.GobalCore.Database.Entities;

namespace RP.GobalCore.Mapper
{
    public static class MapUser
    {
        public static UserDto MapUserToUserDto(this User user)
        {
            var userDto = new UserDto
            {
                UserName = user.UsersIdPk,
                Email = user.UsersEmail,
                SupervisorName = user.UserSupervisorIdFk,
                Token = user.UsersToken
            };

            return userDto;
        }
    }
}
