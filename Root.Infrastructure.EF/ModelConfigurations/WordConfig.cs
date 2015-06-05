using Hangerd.EntityFramework;
using Root.Domain.Models;

namespace Root.Infrastructure.EF.ModelConfigurations
{
	public class WordConfig : EntityTypeConfigBase<Word>
	{
		public WordConfig()
		{
			HasMany(e => e.Morphemes)
				.WithMany();
		}
	}
}
