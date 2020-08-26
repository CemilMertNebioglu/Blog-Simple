

using System.Collections.Generic;
using System.Linq;
using BloggerSample.BLL.Abstract;
using BloggerSample.Core.Data.UnitOfWork;
using BloggerSample.DTO;
using BloggerSample.Model;
using BloggerSample.Mapping;
using BloggerSample.Mapping.ConfigProfile;

namespace BloggerSample.BLL.BlogService
{
    public class RoleService : IRoleService
    {
        private readonly IUnitofWork uow;
        public RoleService(IUnitofWork _uow)
        {
            uow = _uow;
        }
        public List<RoleDTO> getAll()
        {
            var roleList = uow.GetRepository<Role>().GetAll().ToList();

            return MapperFactory.CurrentMapper.Map<List<RoleDTO>>(roleList);
        }
        public bool deleteRole(int roleId)
        {
            try
            {
                Role getrole = uow.GetRepository<Role>().Get(z => z.Id == roleId);
                uow.GetRepository<Role>().Delete(getrole);
                uow.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public RoleDTO getRole(int Id)
        {
            var getRole = uow.GetRepository<Role>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<RoleDTO>(getRole);
        }

        public List<RoleDTO> getRoleName(string roleName)
        {
            var getRole = uow.GetRepository<Role>().Get(z => z.Name.Contains(roleName), null).ToList();
            return MapperFactory.CurrentMapper.Map<List<RoleDTO>>(getRole);
        }

        public RoleDTO newRole(RoleDTO role)
        {
            if (!uow.GetRepository<Role>().GetAll().Any(z => z.Name == role.Name))
            {
                var adedRole = MapperFactory.CurrentMapper.Map<Role>(role);
                adedRole = uow.GetRepository<Role>().Add(adedRole);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<RoleDTO>(adedRole);
            }
            else
            {
                return null;
            }
        }

        public RoleDTO updateRole(RoleDTO role)
        {
            var selectedRole = uow.GetRepository<Role>().Get(z => z.Id == role.Id);
            selectedRole = MapperFactory.CurrentMapper.Map<Role>(role);
            uow.GetRepository<Role>().Update(selectedRole);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<RoleDTO>(selectedRole);

        }
    }
}
