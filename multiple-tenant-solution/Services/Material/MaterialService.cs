using multiple_tenant_solution.Context;
using multiple_tenant_solution.DAOs.Material;
using multiple_tenant_solution.DTOs.Material;
using multiple_tenant_solution.Entities;

namespace multiple_tenant_solution.Services.Material
{
    /// <summary>
    /// 物料 Service
    /// </summary>
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialDAO _materialDAO;
        private readonly CurrentUserInfo _currentUserInfo;

        public MaterialService(IMaterialDAO materialDAO,
            CurrentUserInfo currentUserInfo)
        {
            _materialDAO = materialDAO;
            _currentUserInfo = currentUserInfo;
        }

        ///<inheritdoc/>
        public IQueryable<Materials> Get()
        {
            return _materialDAO.Get();
        }

        ///<inheritdoc/>
        public Materials Insert(InsertMaterialDTO insertDTO)
        {
            Materials? entity = _materialDAO.GetByNumber(insertDTO.Number);

            if (entity != null)
            {
                throw new ArgumentException($"料號已存在");
            }

            return _materialDAO.Insert( 
                insertDTO.ToMaterials(
                    _currentUserInfo.TenantNumber,
                    _currentUserInfo.Account));
        }

        ///<inheritdoc/>
        public void Update(long id, UpdateMaterialDTO updateDTO)
        {
            Materials? materials = _materialDAO.GetById(id);

            if(materials == null) 
            {
                throw new ArgumentException("找不到物料id");
            }

            materials.Name = updateDTO.Name;
            materials.UpdateDate = DateTime.UtcNow;
            materials.UpdateUser = _currentUserInfo.Account;

            _materialDAO.Update(materials);
        }

        ///<inheritdoc/>
        public void Delete(long id)
        {
            Materials? materials = _materialDAO.GetById(id);

            if (materials == null)
            {
                throw new ArgumentException("找不到物料id");
            }

            _materialDAO.Delete(materials);
        }
    }
}
