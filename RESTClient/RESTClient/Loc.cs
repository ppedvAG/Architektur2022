using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTClient.KRAM
{

    public class Rootobject
    {
        public Class1[] Property1 { get; set; }
    }

    public class Class1
    {
        public string name { get; set; }
        public bool roofed { get; set; }
        public Car[] cars { get; set; }
        public int id { get; set; }
        public DateTime modified { get; set; }
        public DateTime created { get; set; }
    }

    public class Car
    {
        public string manufacturer { get; set; }
        public string model { get; set; }
        public int kw { get; set; }
        public DateTime builtDate { get; set; }
        public string color { get; set; }
        public object location { get; set; }
        public Driver[] drivers { get; set; }
        public int id { get; set; }
        public DateTime modified { get; set; }
        public DateTime created { get; set; }
    }

    public class Driver
    {
        public string name { get; set; }
        public DateTime birthDate { get; set; }
        public object[] cars { get; set; }
        public int id { get; set; }
        public DateTime modified { get; set; }
        public DateTime created { get; set; }
    }


}
