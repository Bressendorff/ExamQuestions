using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileBonanzaCSharp
{
	public class Person
	{
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string Hobbies { get; set; }

		public override string ToString()
		{
			return $"Name: {Name}, Age: {Age}, Country: {Country}, Hobbies: {Hobbies}";
		}
	}
}
