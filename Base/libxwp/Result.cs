using System;
using JetBrains.Annotations;

namespace XW
{
	[PublicAPI, UsedImplicitly]
	public class Result
	{
		[PublicAPI, UsedImplicitly]
		public bool HasError { get; set; }

		[PublicAPI, UsedImplicitly, CanBeNull]
		public string ErrorDescription { get; set; }

		[PublicAPI, UsedImplicitly, CanBeNull]
		public ErrorDetails ErrorDetails { get; set; }

		[NotNull]
		public static Result CreateError(Exception exception)
		{
			return CreateError(typeof(Result), exception?.Message, exception?.HResult, exception?.StackTrace);
		}

		[NotNull]
		public static T CreateError<T>(Exception exception) where T : Result, new()
		{
			return (T)CreateError(typeof(T), exception?.Message, exception?.HResult, exception?.StackTrace);
		}

		[NotNull]
		public static Result CreateError(Type responseType, Exception exception)
		{
			return CreateError(responseType, exception?.Message, exception?.HResult, exception?.StackTrace);
		}

		[NotNull]
		public static Result CreateError([LocalizationRequired] string errorDescription, int? hResult = null, string stackTrace = null)
		{
			return CreateError(typeof (Result), errorDescription, hResult, stackTrace);
		}

		[NotNull]
		public static Result CreateError(Type responseType, string errorDescription, int? hResult = null, string stackTrace = null)
		{
			var response = (Result)Activator.CreateInstance(responseType);

			response.HasError = true;
			response.ErrorDescription = errorDescription;
			response.ErrorDetails = new ErrorDetails
			{
				HResult = hResult.GetValueOrDefault(),
				StackTrace = stackTrace
			};

			return response;
		}

		[NotNull]
		public static T CreateError<T>([LocalizationRequired] string errorDescription, int? hResult = null, string stackTrace = null) where T : Result, new()
		{
			return (T)CreateError(typeof(T), errorDescription, hResult, stackTrace);
		}

		[NotNull]
		public Result Specialize(Type responseType)
		{
			var targetResponse = (Result)Activator.CreateInstance(responseType);

			targetResponse.HasError = HasError;
			targetResponse.ErrorDescription = ErrorDescription;

			if (HasError)
			{
				targetResponse.ErrorDetails = ErrorDetails;
			}

			return targetResponse;
		}

		[NotNull]
		public T Specialize<T>() where T : Result, new()
		{
			return (T)Specialize(typeof(T));
		}

		public static Result Success
		{
			get { return new Result();}
		}
	}

	[PublicAPI, UsedImplicitly]
	public class Result<T> : Result
	{
		[PublicAPI, UsedImplicitly]
		public T Data { get; set; }
	}
}
