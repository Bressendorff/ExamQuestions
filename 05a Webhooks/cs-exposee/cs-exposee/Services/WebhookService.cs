using cs_exposee.Controllers;

namespace cs_exposee.Services
{
	public class WebhookService
	{
		private static readonly List<string> _users = new();
		private static readonly Dictionary<HookUsernameMap, string> _registeredHooks = new();

		public bool RegisterWebhook(string username, Hook hook, string callbackUrl)
		{
			AddUser(username);
			AddWebhook(username, hook, callbackUrl);

			return true;
		}

		private void AddUser(string username)
		{
			if (!_users.Contains(username))
			{
				_users.Add(username);
			}
		}

		private void AddWebhook(string username, Hook hook, string callbackUrl)
		{
			var hookmap = new HookUsernameMap() { Hook = hook, Username = username };
			if (!_registeredHooks.ContainsKey(hookmap))
			{
				_registeredHooks.Add(hookmap, callbackUrl);
			}
		}

		public void PingHooks(string username)
		{
			var hooks = _registeredHooks.Keys.Where(k => k.Username == username).Select(k => k.Hook);
			foreach (var hook in hooks)
			{
				PingHook(username, hook);
			}
		}

		public void PingHook(string username, Hook hook)
		{
			var key = _registeredHooks.Keys.First(k => k.Equals(new HookUsernameMap() { Hook = hook, Username = username }));

			var callbackUrl = _registeredHooks[key];

			HttpClient client = new();
			var pingRequest = new PingRequestDTO();
			pingRequest.Data.RegisteredUrl = callbackUrl;
			client.PostAsJsonAsync(callbackUrl, pingRequest);
		}
	}

	public enum Hook
	{
		StringReversed = 1,
	}

	public class HookUsernameMap
	{
		public Hook Hook { get; set; }
		public string Username { get; set; }

		public override bool Equals(object? obj)
		{
			var test = obj as HookUsernameMap;

			if (test.Hook == this.Hook && test.Username == this.Username)
			{
				return true;
			}

			return false;
		}

	}
}
