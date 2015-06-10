namespace Root.Infrastructure.TranlateProxy
{
	public interface ITranslateService
	{
		DictionaryResult GetWordDictionaryResult(string word);
	}
}
