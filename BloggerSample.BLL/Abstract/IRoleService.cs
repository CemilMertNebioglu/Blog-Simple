
using BloggerSample.Core.Services;
using BloggerSample.DTO;
using System.Collections.Generic;

namespace BloggerSample.BLL.Abstract
{
    public interface IRoleService : IServiceBase
    {
        List<RoleDTO> getAll();
        RoleDTO getRole(int Id);
        List<RoleDTO> getRoleName(string roleName);
        RoleDTO newRole(RoleDTO role);
        RoleDTO updateRole(RoleDTO role);
        bool deleteRole(int roleId);

    }
}
