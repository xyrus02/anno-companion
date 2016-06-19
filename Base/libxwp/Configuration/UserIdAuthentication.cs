using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace XW.Configuration
{
	[PublicAPI]
	public sealed class UserIdAuthentication : IDatabaseAuthentication
	{
		private string mUserId;

		public UserIdAuthentication()
		{
		}
		public UserIdAuthentication([NotNull] string userId, [CanBeNull] string password)
		{
			if (userId == null)
			{
				throw new ArgumentNullException(nameof(userId));
			}

			UserId = userId;
			Password = password;
		}

		[NotNull]
		public string UserId
		{
			get { return mUserId; }
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException(nameof(value));
				}

				mUserId = value;
			}
		}

		[CanBeNull]
		public string Password
		{
			get;
			set;
		}

		public void Read(IKeyedConfigurationProvider provider, IDictionary<string, string> keyMappings = null)
		{
			if (provider == null)
			{
				throw new ArgumentNullException(nameof(provider));
			}

			if (keyMappings == null)
			{
				keyMappings = new Dictionary<string, string>();
			}

			var username = provider.ReadValue(keyMappings.GetValueByKeyOrDefault(DatabaseConfiguration.DatabaseUserKey, DatabaseConfiguration.DatabaseUserKey)) ?? string.Empty;
			var password = provider.ReadValue(keyMappings.GetValueByKeyOrDefault(DatabaseConfiguration.DatabasePasswordKey, DatabaseConfiguration.DatabasePasswordKey)) ?? string.Empty;

			UserId = username;
			Password = password;
		}
	}
}