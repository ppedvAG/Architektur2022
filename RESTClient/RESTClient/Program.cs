// See https://aka.ms/new-console-template for more information
using RESTClient;
using System.Text.Json;

Console.WriteLine("Hello, World!");

var url = "https://localhost:7092/api/Locations/";

var http = new HttpClient();
var json = await http.GetStringAsync(url);

var res = JsonSerializer.Deserialize<IEnumerable<RESTClient.KRAM.Class1>>(json);

foreach (var item in res)
{
    Console.WriteLine($"{item.name}");
}

Console.WriteLine("-----------------------------");

var sc = new swaggerClient("https://localhost:7092/", http);

foreach (var item in await sc.LocationsAllAsync())
{
    Console.WriteLine(item.Name);
}
