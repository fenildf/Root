using Hangerd;
using Hangerd.Entity;

namespace Root.Domain.Models
{
	public class WordMorpheme : EntityBase
	{
		#region Public Properties

		/// <summary>
		/// 词素
		/// </summary>
		public virtual Morpheme Morpheme { get; private set; }

		/// <summary>
		/// 排序
		/// </summary>
		public int Order { get; private set; }

		#endregion

		#region Constructors

		protected WordMorpheme()
		{
		}

		public WordMorpheme(Morpheme morpheme, int order)
		{
			if (order < 0)
				throw new HangerdException("排序值不可小于0");

			Morpheme = morpheme;
			Order = order;
		}

		#endregion

		#region Public Methods

		public void ModifyOrder(int newOrder)
		{
			Order = newOrder;
		}

		#endregion
	}
}
