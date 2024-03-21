using FileBonanzaCSharp;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Runtime.CompilerServices;
using DataFormatApi.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataFormatApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FileFormatsController : ControllerBase
	{
		// GET api/<FileFormatsController>/csv
		[HttpGet("/csv")]
		public ActionResult<List<Person>> GetCsv()
		{
			return Ok(Parser.ReadCsv());
		}

		[HttpGet("/txt")]
		public ActionResult<string> GetTxt()
		{
			return Ok(Parser.ReadTxt());
		}

		[HttpGet("/json")]
		public ActionResult<List<Person>> GetJson()
		{
			return Ok(Parser.ReadJson());
		}

		[HttpGet("/xml")]
		public ActionResult<List<Person>> GetXml()
		{
			return Ok(Parser.ReadXml());
		}

		[HttpGet("/requestFastAPI")]
		public ActionResult<List<PersonDTO>> GetData()
		{
			HttpClient client = new HttpClient()
			{
				BaseAddress = new Uri("http://127.0.0.1:8000")
			};


			HttpResponseMessage responseJson = client.GetAsync("/json").Result;
			HttpResponseMessage responseCsv = client.GetAsync("/csv").Result;
			HttpResponseMessage responseXml = client.GetAsync("/xml").Result;
			HttpResponseMessage responseTxt = client.GetAsync("/txt").Result;

			var listResponse = new List<HttpResponseMessage>() { responseCsv, responseJson, responseXml};
			List<PersonDTO> data = new();
			foreach (var response in listResponse)
			{
				if (response.IsSuccessStatusCode)
				{
					var responseData = response.Content.ReadFromJsonAsync<List<PersonDTO>>().Result;
					if (responseData != null) data.AddRange(responseData);
				}
			}
			
			return Ok(data);
		}


	}
}
