using Hangerd;
using Hangerd.Entity;
using Hangerd.Utility;

namespace Root.Domain.Utilities
{
	public static class IdGenerator
	{
		public static string Create<TEntity>(string subject)
			where TEntity : EntityBase
		{
			if (string.IsNullOrWhiteSpace(subject))
				throw new HangerdException("ID生成所依赖主体不可为空");

			return CryptoHelper.GetMd5(string.Format("{0}_{1}", typeof (TEntity).FullName, subject.ToLower()));
		}
	}
}
