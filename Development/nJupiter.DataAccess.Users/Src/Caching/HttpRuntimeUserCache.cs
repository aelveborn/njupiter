#region Copyright & License
/*
	Copyright (c) 2005-2011 nJupiter

	Permission is hereby granted, free of charge, to any person obtaining a copy
	of this software and associated documentation files (the "Software"), to deal
	in the Software without restriction, including without limitation the rights
	to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
	copies of the Software, and to permit persons to whom the Software is
	furnished to do so, subject to the following conditions:

	The above copyright notice and this permission notice shall be included in
	all copies or substantial portions of the Software.

	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
	THE SOFTWARE.
*/
#endregion

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Caching;

using nJupiter.Configuration;

namespace nJupiter.DataAccess.Users.Caching {

	public class HttpRuntimeUserCache : IUserCache {

		private readonly IConfig config;
		private int minutesInCache = -1; // If zero, caching is turned off
		private bool? slidingExpiration;
		private CacheItemPriority? cacheItemPriority;

		public HttpRuntimeUserCache(IConfig config) {
			if(config == null) {
				throw new ArgumentNullException("config");
			}
			this.config = config;
		}

		private int MinutesInCache {
			get {
				if(this.minutesInCache < 0) {
					if(config.ContainsKey("cache", "minutesInCache")) {
						this.minutesInCache = config.GetValue<int>("cache", "minutesInCache");
					} else {
						this.minutesInCache = 0;
					}
				}
				return this.minutesInCache;
			}
		}

		private bool SlidingExpiration {
			get {
				if(slidingExpiration == null) {
					if(config.ContainsKey("cache", "slidingExpiration")) {
						this.slidingExpiration = config.GetValue<bool>("cache", "slidingExpiration");
					} else {
						this.slidingExpiration = false;
					}
				}
				return (bool)this.slidingExpiration;
			}
		}

		private CacheItemPriority CachePriority {
			get {
				if(cacheItemPriority == null) {
					if(config.ContainsKey("cache", "cachePriority")) {
						string configValue = config.GetValue("cache", "cachePriority");
						this.cacheItemPriority = (CacheItemPriority)Enum.Parse(typeof(CacheItemPriority), configValue, true);
					} else {
						this.cacheItemPriority = CacheItemPriority.Normal;
					}
				}
				return (CacheItemPriority)this.cacheItemPriority;
			}
		}

		public IUser GetUserById(string userId) {
			if(userId == null || this.MinutesInCache == 0)
				return null;
			UserIdCacheKey userIdCacheKey = new UserIdCacheKey(config.ConfigKey, userId);
			return HttpRuntime.Cache[userIdCacheKey.CacheKey] as IUser;
		}

		public IUser GetUserByUserName(string userName, string domain) {
			if(userName == null || this.MinutesInCache == 0)
				return null;
			UsernameCacheKey usernameCacheKey = new UsernameCacheKey(config.ConfigKey, userName, domain);
			return HttpRuntime.Cache[usernameCacheKey.CacheKey] as IUser;
		}

		public void RemoveUserFromCache(IUser user) {
			if(user != null) {
				UsernameCacheKey usernameCacheKey = new UsernameCacheKey(config.ConfigKey, user.UserName, user.Domain);
				UserIdCacheKey userIdCacheKey = new UserIdCacheKey(config.ConfigKey, user.Id);
				HttpRuntime.Cache.Remove(usernameCacheKey.CacheKey);
				HttpRuntime.Cache.Remove(userIdCacheKey.CacheKey);
			}
		}

		public void RemoveUsersFromCache(IList<IUser> users) {
			if(users != null) {
				foreach(IUser user in users) {
					this.RemoveUserFromCache(user);
				}
			}
		}

		public void AddUserToCache(IUser user) {
			if(user != null && this.MinutesInCache > 0) {
				user.MakeReadOnly();
				UsernameCacheKey usernameCacheKey = new UsernameCacheKey(config.ConfigKey, user.UserName, user.Domain);
				UserIdCacheKey userIdCacheKey = new UserIdCacheKey(config.ConfigKey, user.Id);
				if(this.SlidingExpiration) {
					TimeSpan expirationTime = new TimeSpan(0, 0, this.MinutesInCache, 0);
					HttpRuntime.Cache.Add(usernameCacheKey.CacheKey, user, null, Cache.NoAbsoluteExpiration, expirationTime, this.CachePriority, null);
					HttpRuntime.Cache.Add(userIdCacheKey.CacheKey, user, null, Cache.NoAbsoluteExpiration, expirationTime, this.CachePriority, null);
				} else {
					DateTime expirationTime = DateTime.Now.AddMinutes(this.MinutesInCache);
					HttpRuntime.Cache.Add(usernameCacheKey.CacheKey, user, null, expirationTime, Cache.NoSlidingExpiration, this.CachePriority, null);
					HttpRuntime.Cache.Add(userIdCacheKey.CacheKey, user, null, expirationTime, Cache.NoSlidingExpiration, this.CachePriority, null);
				}
			}
		}

		public void AddUsersToCache(IList<IUser> users) {
			if(users != null && this.MinutesInCache > 0) {
				foreach(IUser user in users) {
					this.AddUserToCache(user);
				}
			}
		}

		private struct UserIdCacheKey {

			private const int InitialPrime = 17;
			private const int MultiplierPrime = 37;
			
			private readonly string userProvider;
			private readonly string userId;
			private readonly string cacheKey;

			public UserIdCacheKey(string userProvider, string id) {
				this.userId = id ?? string.Empty;
				this.userProvider = userProvider;

				cacheKey = string.Format("nJupiter.DataAccess.Users.userRepository:{0}:userId:{1}", userProvider, id);
			}

			public override bool Equals(object obj) {
				UserIdCacheKey map = (UserIdCacheKey)obj;
				if(map.userId == null)
					return false;
				return map.userId.Equals(this.userId) && map.userProvider.Equals(this.userProvider);
			}

			public string CacheKey {
				get {
					return cacheKey;
				}
			}

			public override int GetHashCode() {
				// Refer to Effective Java 1st ed page 34 for an good explanation of this hash code implementation
				int hash = InitialPrime;
				hash = (MultiplierPrime * hash) + this.userId.GetHashCode();
				hash = (MultiplierPrime * hash) + this.userProvider.GetHashCode();
				return hash;
			}
		}

		private struct UsernameCacheKey {

			private readonly string userProvider;
			private readonly string userName;
			private readonly string domain;
			private readonly int hash;
			private readonly string cacheKey;

			public UsernameCacheKey(string userProvider, string userName, string domain) {
				this.userName = userName;
				this.domain = domain ?? string.Empty;
				this.userProvider = userProvider;

				// Calculate a unique hash that will match all id:s with the same user name and domain
				int result = 17;
				result = (37 * result) + this.userName.GetHashCode();
				result = (37 * result) + this.domain.GetHashCode();
				result = (37 * result) + this.userProvider.GetHashCode();

				hash = result;
				cacheKey = string.Format("nJupiter.DataAccess.Users.userRepository:{0}:UsernameCacheKey:{1}", this.userProvider, hash);
			}

			public override bool Equals(object obj) {
				UsernameCacheKey map = (UsernameCacheKey)obj;
				if(map.userName == null)
					return false;
				return map.userName.Equals(this.userName) && map.domain.Equals(this.domain) && map.userProvider.Equals(this.userProvider);
			}

			public string CacheKey {
				get {
					return cacheKey;
				}
			}

			public override int GetHashCode() {
				return hash;
			}
		}
	}
}