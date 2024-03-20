using cs_exposee.Services;
using Microsoft.AspNetCore.Mvc;

namespace cs_exposee.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class StringProcessorController : ControllerBase
	{
		private readonly WebhookService _service;

		public StringProcessorController(WebhookService service)
		{
			_service = service;
		}


		[HttpPost("/register")]
		public ActionResult<string> Register([FromBody] HookRequest request)
		{
			var isRegisterSuccess = _service.RegisterWebhook(request.Username, request.Hook, request.CallbackUrl);

			var pingRequest = new PingRequestDTO();
			pingRequest.Data.RegisteredUrl = request.CallbackUrl;
			if (isRegisterSuccess)
			{
				HttpClient client = new HttpClient();
				Task.Run(() =>
				{
					Thread.Sleep(10000);
					_service.PingHook(request.Username, request.Hook);
				});
				return Ok("Successfully registered webhook. We've pinged the provided address");
			}


			return BadRequest("Failed to register webhook");
		}

		[HttpPost("/ping")]
		public ActionResult<string> PingHooks([FromBody] string username)
		{
			_service.PingHooks(username);

			return Ok("We're pinging all your registered hooks");
		}
	}


	public record HookRequest(string Username, string CallbackUrl, Hook Hook);

	public class PingRequestDTO
	{
		public Data Data { get; set; } = new();
	}

	public class Data
	{
		public string RegisteredUrl { get; set; }
	}

	public class HttpClientHandlerInsecure : HttpClientHandler
	{
		public HttpClientHandlerInsecure()
		{
			ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
		}
	}
}