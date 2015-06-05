using System.ComponentModel;

namespace Root.Application.DataObjects
{
	public enum MorphemeTypeDto
	{
		[Description("词根")] Root = 1,

		[Description("词缀")] Affix = 2
	}
}
