using Infrastructure.DataAccess;
using Infrastructure.Interfaces;

namespace ApplicationCore.DataAccess
{

	public interface IDefaultRepository<T> : IAsyncRepository<T>, IRepository<T> where T : class
	{

	}

	public class DefaultRepository<T> : EfRepository<T>, IDefaultRepository<T> where T : class
	{
		public DefaultRepository(DefaultContext context) : base(context)
		{

		}
	}
}
