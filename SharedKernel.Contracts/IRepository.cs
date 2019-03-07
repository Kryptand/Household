using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kryptand.ChefMaster.Core.SharedKernel.Contracts
{
	public interface IRepository
    {
        Task<T> GetById<T>(Guid id) where T : IBaseEntity;
        Task<List<T>> List<T>(ISpecification<T> spec = null) where T : IBaseEntity;
        Task<T> Add<T>(T entity) where T : IBaseEntity;
        void Update<T>(T entity) where T : IBaseEntity;
        void Delete<T>(T entity) where T : IBaseEntity;
    }
}
