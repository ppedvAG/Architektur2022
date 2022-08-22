// See https://aka.ms/new-console-template for more information
using System.Data.Common;

Console.WriteLine("Hello, World!");


string conString = "Server=(localdb)\\mssqllocaldb;Database=Northwnd;Trusted_Connection=true";
DbProviderFactory factory = System.Data.SqlClient.SqlClientFactory.Instance;
//DbProviderFactory factory = Oracle.ManagedDataAccess.Client.OracleClientFactory.Instance;



DbConnection con = factory.CreateConnection();
con.ConnectionString = conString;
con.Open();

DbCommand cmd = factory.CreateCommand();
cmd.Connection = con;
cmd.CommandText = "SELECT * FROM Employees";
DbDataReader reader = cmd.ExecuteReader();

while (reader.Read())
{
    Console.WriteLine($"{reader.GetString(reader.GetOrdinal("FirstName"))} {reader.GetString(reader.GetOrdinal("LastName"))}");
}