using System;
using System.Configuration;
using System.Security.Principal;
using System.Text.Json;
using System.Text.Json.Nodes;
using PersonSerializationDeserialization.Models;

namespace PersonSerializationDeserialization
{
    internal class Program
    {
        static string path = ConfigurationManager.AppSettings["filePath"].ToString();
        static List<Person> persons = new List<Person>()
        {new Person { Id = 1, Name = "Allen", EmailId = "allen@gmail.com" },
        new Person { Id = 2, Name = "Mary", EmailId = "mary@example.com" },
        new Person { Id = 3, Name = "Alice", EmailId = "alice@gmail.com" },
        new Person { Id = 4, Name = "Bob", EmailId = "bob@gmail.com" },
        new Person { Id = 5, Name = "John", EmailId = "john@gmail.com" }};
        static void Main(string[] args)
        {
            SerializePersonList(persons);
            DeserializePersonList();
        }
        static void SerializePersonList(List<Person> persons)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(JsonSerializer.Serialize(persons));
            }
            Console.WriteLine("Serialized Person objects successfully..\n\n");
        }
        static void DeserializePersonList()
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Create a json file and then write..");
                return;
            }
            using (StreamReader sr = new StreamReader(path))
            {
                List<Person> persons = JsonSerializer.Deserialize<List<Person>>(sr.ReadToEnd());
                Console.WriteLine("Total number of people: " + persons.Count()+"\n");
                foreach (Person person in persons)
                {
                    Console.WriteLine($"Id: {person.Id}\nName: {person.Name}\nEmail id: {person.EmailId}");
                    Console.WriteLine("..........................................................");
                }
            }
        }
    }
}
