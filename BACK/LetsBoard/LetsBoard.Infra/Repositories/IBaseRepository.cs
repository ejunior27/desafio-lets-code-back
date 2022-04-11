using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LetsBoard.Infra.Repositories
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Create(TEntity model);

        List<TEntity> Create(List<TEntity> model);

        int Save();

        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> where);

        Task<TEntity> CreateAsync(TEntity model);

        Task<int?> SaveAsync();

        Task<TEntity> GetAsync(params object[] Keys);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where);

        Task<bool> UpdateAsync(TEntity model);
        Task<bool> DeleteAsync(TEntity model);
    }
}
