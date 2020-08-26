using BloggerSample.Core.Services;
using BloggerSample.DTO;
using System.Collections.Generic;

namespace BloggerSample.BLL.Abstract
{
    public interface IUserService : IServiceBase
    {
        List<UserDTO> getAll();
        UserDTO getUser(int Id);
        List<UserDTO> getUserName(string Name);
        UserDTO newUser(UserDTO User);
        UserDTO updateUser(UserDTO User);
        bool deleteUser(int Id);

        UserDTO FindwithUsernameandMail(string mailorUserName, string password);
        List<UserDTO> getAllUserinRole(int RoleID);
    }
}
