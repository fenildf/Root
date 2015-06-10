namespace Root.Infrastructure.TranlateProxy
{
	internal class TranslateResult
	{
		public int errNum { get; set; }

		public string errMsg { get; set; }

		public TranslateData retData { get; set; }
	}

	internal class TranslateData
	{
		public string from { get; set; }

		public string to { get; set; }

		public DictionaryResult dict_result { get; set; }
	}

	public class DictionaryResult
	{
		public string word_name { get; set; }

		public WordSymbol[] symbols { get; set; }
	}

	public class WordSymbol
	{
		public string ph_am { get; set; }

		public string ph_en { get; set; }

		public WordPart[] parts { get; set; }
	}

	public class WordPart
	{
		public string part { get; set; }

		public string[] means { get; set; }
	}
}
