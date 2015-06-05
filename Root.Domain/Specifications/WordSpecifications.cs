using Hangerd.Specification;
using Root.Domain.Models;
using Root.Domain.Utilities;

namespace Root.Domain.Specifications
{
	public class WordSpecifications : SpecificationsBase<Word>
	{
		public static Specification<Word> StemEquals(string stem)
		{
			var id = IdGenerator.Create<Word>(stem);

			return IdEquals(id);
		}

		public static Specification<Word> StemLike(string stem)
		{
			return new DirectSpecification<Word>(w => w.Stem.Contains(stem));
		}
	}
}
