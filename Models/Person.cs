using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSerializationDeserialization.Models
{
    internal class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\n" +
                $"Name: {Name}\n" +
                $"Email: {EmailId}";
        }
    }
}
