using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Xml;

namespace FileBonanzaCSharp
{
	public static class Parser
	{
		private static string _basePath { get; set; } = "C:\\GithubRepos\\ExamQuestions\\01a-03a Data parsing servers\\me";

		public static string ReadTxt()
		{
			var path = _basePath + ".txt";
			using var reader = new StreamReader(path);
			var txt = reader.ReadToEnd();
			return txt;
		}

		public static List<Person> ReadCsv()
		{
			var path = _basePath + ".csv";

			var csvHelperConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
			{
				PrepareHeaderForMatch = args => args.Header.ToLower(),
				Delimiter = ";"
			};

			using var reader = new StreamReader(path);
			using var csv = new CsvReader(reader, csvHelperConfig);
			var people = csv.GetRecords<Person>().ToList();

			return people;
		}

		public static List<Person> ReadJson()
		{
			var path = _basePath + ".json";
			using var reader = new StreamReader(path);
			string json = reader.ReadToEnd();
			dynamic array = JsonConvert.DeserializeObject(json);
			var people = new List<Person>();
			foreach (var item in array)
			{
				Person person = new() { Age = item.Age, Country = item.Country, Name = item.Name, Hobbies = item.Hobbies.ToString().Replace("\r\n", "").Replace(" ", "") };
				people.Add(person);
			}

			return people;
		}

		public static List<Person> ReadXml()
		{
			var path = _basePath + ".xml";

			var doc = new XmlDocument();
			doc.Load(path);
			Person p = new();
			foreach (XmlNode node in doc.DocumentElement.ChildNodes)
			{
				if (node.Name == "hobbies")
				{
					var hobbiesString = "";
					foreach (XmlNode hobby in node.ChildNodes)
					{
						hobbiesString += hobby.InnerText + ", ";
					}
					hobbiesString = hobbiesString.TrimEnd().TrimEnd(',');
					p.Hobbies = hobbiesString;
				}
				else if (node.Name == "age")
				{
					p.Age = int.Parse(node.InnerText);
				}
				else if (node.Name == "name")
				{
					p.Name = node.InnerText;
				}
				else if (node.Name == "country")
				{
					p.Country = node.InnerText;
				}
			}
			return new List<Person>() { p };
		}
	}
}
