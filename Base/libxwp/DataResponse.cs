using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace XW
{
	[PublicAPI]
	public class DataResponse //: Response
	{
		public DataResponse()
		{
			Details = new Result[0];
		}

		public Guid Id { get; set; }

		[NotNull]
		public Result[] Details { get; set; }

		public IEnumerable<Result> Unroll()
		{

			// ReSharper disable once ConditionIsAlwaysTrueOrFalse
			if (Details != null)
			{
				foreach (var response in Details)
				{
					if(response.HasError)
                    {
						yield return response;
					}
				}
			}
		}
	}
}