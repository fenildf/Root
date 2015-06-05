using System;
using Hangerd;
using Hangerd.Components;

namespace Root.Infrastructure
{
	public class ServiceBase
	{
		protected static HangerdResult<TResult> TryOperate<TResult>(Func<TResult> operate,
			string successMessage = "操作成功", string failureMessage = "操作失败")
		{
			try
			{
				return new HangerdResult<TResult>(operate(), successMessage);
			}
			catch (HangerdException ex)
			{
				return new HangerdResult<TResult>(default(TResult), string.Format("{0}({1})", failureMessage, ex.Message));
			}
			catch (Exception ex)
			{
				LocalLoggingService.Exception(ex);

				return new HangerdResult<TResult>(default(TResult), string.Format("{0}({1})", failureMessage, ex.Message));
			}
		}

		protected static HangerdResult<bool> TryOperate(Action operate,
			string successMessage = "操作成功", string failureMessage = "操作失败")
		{
			return TryOperate(() =>
			{
				operate();

				return true;
			}, successMessage, failureMessage);
		}
	}
}
