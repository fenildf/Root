using System.Linq;
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

		public static Specification<Word> ContainsMorphemeId(string morphemeId)
		{
			return new DirectSpecification<Word>(w => w.Morphemes.Any(m => m.Morpheme.Id == morphemeId));
		}
	}
}
