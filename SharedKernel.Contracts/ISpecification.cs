using System;
using System.Linq.Expressions;


namespace Kryptand.ChefMaster.Core.SharedKernel.Contracts
{
	public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; set; }
    }
}
