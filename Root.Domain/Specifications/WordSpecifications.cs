using Hangerd.Specification;
using Root.Domain.Models;

namespace Root.Domain.Specifications
{
	public class WordSpecifications : SpecificationsBase<Word>
	{
		public static Specification<Word> StemLike(string stem)
		{
			return new DirectSpecification<Word>(w => w.Stem.Contains(stem));
		}
	}
}
