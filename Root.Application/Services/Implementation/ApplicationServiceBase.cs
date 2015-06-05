using Hangerd;
using Root.Infrastructure;

namespace Root.Application.Services.Implementation
{
	public class ApplicationServiceBase : ServiceBase
	{
		private readonly IRootDbContextFactory _dbContextFactory;

		protected IRootDbContextFactory DbContextFactory
		{
			get
			{
				if (_dbContextFactory == null)
					throw new HangerdException("DbContextFactory未初始化");

				return _dbContextFactory;
			}
		}

		#region Constructors

		protected ApplicationServiceBase(IRootDbContextFactory dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
		}

		#endregion

	}
}
