using Hangerd.EntityFramework;
using Root.Domain.Models;

namespace Root.Infrastructure.EF.ModelConfigurations
{
	public class MorphemeConfig : EntityTypeConfigBase<Morpheme>
	{
		public MorphemeConfig()
		{
		}
	}
}
