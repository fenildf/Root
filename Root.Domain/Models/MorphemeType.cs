using System.ComponentModel;

namespace Root.Domain.Models
{
	public enum MorphemeType
	{
		[Description("词根")] Root = 1,

		[Description("词缀")] Affix = 2
	}
}
