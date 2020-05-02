using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace _200.CoreConsoleApp.JSONConvertDTOAllWay
{
    /// <summary>
    /// 人 Test Model
    /// </summary>
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Property Property { get; set; }
    }
    /// <summary>
    /// 财产 Test Model Son
    /// </summary>
    public class Property
    {
        public string House { set; get; }

        public string Car { set; get; }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Id = 2;
            person.Name = "SCscHero";
            person.Property = new Property() { House = "大悦城", Car = "911" };
            string json = JsonConvert.SerializeObject(person);
            Console.WriteLine(json);
            //Dynamic转换方式
            {
                dynamic dynamicObj = JsonConvert.DeserializeObject<dynamic>(json);
                Console.WriteLine(dynamicObj.Name);
                Console.WriteLine(dynamicObj.Property.House);
            }
            //JObject转换方式
            {
                JObject jobject = (JObject)JsonConvert.DeserializeObject(json);
                Console.WriteLine(jobject["Name"]);
                Console.WriteLine(jobject["Property"]["House"]);
            }
            Console.ReadKey();
        }
    }
}
