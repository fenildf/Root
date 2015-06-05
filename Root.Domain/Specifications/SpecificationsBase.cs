using Hangerd.Entity;
using Hangerd.Specification;

namespace Root.Domain.Specifications
{
	public class SpecificationsBase<TEntity>
		where TEntity : EntityBase
	{
		public static Specification<TEntity> True()
		{
			return new DirectSpecification<TEntity>(e => true);
		}

		public static Specification<TEntity> IdEquals(string id)
		{
			return new DirectSpecification<TEntity>(e => e.Id == id);
		}
	}
}
