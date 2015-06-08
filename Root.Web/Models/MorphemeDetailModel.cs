using System.Collections.Generic;
using Root.Application.DataObjects;

namespace Root.Web.Models
{
	public class MorphemeDetailModel
	{
		public MorphemeDto Morpheme { get; set; }

		public IEnumerable<WordDto> RelatedWords { get; set; }
	}
}