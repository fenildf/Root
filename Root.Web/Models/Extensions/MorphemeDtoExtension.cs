using Root.Application.DataObjects;

namespace Root.Web.Models.Extensions
{
	public static class MorphemeDtoExtension
	{
		public static string ToListItemValue(this MorphemeDto morphemeDto)
		{
			return string.Format("<strong>{0}</strong> {1} [ {2} ]",
				morphemeDto.Standard, morphemeDto.ToVariant(), morphemeDto.Description);
		}
	}
}