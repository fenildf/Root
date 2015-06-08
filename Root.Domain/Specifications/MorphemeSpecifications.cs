using Hangerd.Specification;
using Root.Domain.Models;

namespace Root.Domain.Specifications
{
	public class MorphemeSpecifications : SpecificationsBase<Morpheme>
	{
		public static Specification<Morpheme> StandardLike(string standard)
		{
			return new DirectSpecification<Morpheme>(m => m.Standard.Contains(standard));
		}
	}
}
