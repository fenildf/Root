using System;
using Hangerd.Components;
using Hangerd.Extensions;

namespace Root.Infrastructure.TranlateProxy
{
	public class TranslateService : ServiceBase, ITranslateService
	{
		private const string ApiAddress = "http://apis.baidu.com/apistore/tranlateservice/dictionary";
		private const string ApiKey = "bffcad8cdb9acfc1c000d96edb64c528";

		public DictionaryResult GetWordDictionaryResult(string word)
		{
			if (string.IsNullOrWhiteSpace(word))
				return null;

			try
			{
				var @params = string.Format("query={0}&from=en&to=zh", word);
				var jsonResult = RequestHelper.Get(ApiAddress, @params, ApiKey);

				if (string.IsNullOrWhiteSpace(jsonResult))
					return null;

				var translateResult = jsonResult.JsonToObject<TranslateResult>();

				if (translateResult == null)
					throw new Exception("translateResult is null");

				if (translateResult.errNum != 0)
					throw new Exception(string.Format("errNum:{0}, errMsg:{1}", translateResult.errNum, translateResult.errMsg));

				if (translateResult.retData == null || translateResult.retData.dict_result == null)
					throw new Exception("retData or dict_result is null");

				return translateResult.retData.dict_result;
			}
			catch (Exception ex)
			{
				LocalLoggingService.Exception(ex);

				return null;
			}
		}
	}
}
