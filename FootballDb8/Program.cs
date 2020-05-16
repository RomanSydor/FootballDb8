using ConsoleTables;
using MySql.Data.MySqlClient;
using System;

namespace FootballDb8
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "server=localhost;user=root;database=lab2db;port=3306;password=1313";
            string sql = "";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("Connected to MySQL server...");
            while (true)
            {
                try
                {
                    ConsoleTable table;
                    Console.Write($"\n[{connection.Database.ToString()}]-> ");
                    sql = Console.ReadLine();

                    MySqlCommand command = new MySqlCommand(sql, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    int fieldCount = reader.FieldCount;
                    object[] fields = new object[fieldCount];
                    string[] columns = new string[fieldCount];

                    for (int i = 0; i < fieldCount; i++)
                    {
                        columns[i] = reader.GetName(i);
                    }
                    table = new ConsoleTable(columns);

                    while (reader.Read())
                    {
                        for (int i = 0; i < fieldCount; i++)
                        {
                            fields[i] = reader[i];
                        }
                        var copy = new object[fieldCount];
                        Array.Copy(fields, copy, fieldCount);
                        table.AddRow(copy);
                    }
                    Console.WriteLine(table);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    if (sql == "")
                    {
                        Console.Write("");
                    }
                    else
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
        }
    }
}