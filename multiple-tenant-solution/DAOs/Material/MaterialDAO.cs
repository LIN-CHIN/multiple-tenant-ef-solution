using multiple_tenant_solution.Context;
using multiple_tenant_solution.Entities;

namespace multiple_tenant_solution.DAOs.Material
{
    /// <summary>
    /// 物料 DAO
    /// </summary>
    public class MaterialDAO : IMaterialDAO
    {
        private readonly DataContext _dataContext;

        public MaterialDAO(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        ///<inheritdoc/>
        public IQueryable<Materials> Get()
        {
            return _dataContext.Materials;
        }

        ///<inheritdoc/>
        public Materials? GetById(long id)
        {
            return _dataContext.Materials
                .Where(m => m.Id == id)
                .SingleOrDefault();
        }

        public Materials? GetByNumber(string number)
        {
            return _dataContext.Materials
                .Where(m => m.Number == number)
                .SingleOrDefault();
        }

        ///<inheritdoc/>
        public Materials Insert(Materials material)
        {
            _dataContext.Add(material);
            _dataContext.SaveChanges();

            return material;
        }

        ///<inheritdoc/>
        public void Update(Materials material)
        {
            _dataContext.Update(material);
            _dataContext.SaveChanges();
        }

        ///<inheritdoc/>
        public void Delete(Materials material)
        {
            _dataContext.Remove(material);
            _dataContext.SaveChanges();
        }
    }
}
