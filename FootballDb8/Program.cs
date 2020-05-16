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
                    Console.Write("\nQuery-> ");
                    sql = Console.ReadLine();

                    MySqlCommand command = new MySqlCommand(sql, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.FieldCount == 1)
                    {
                        table = new ConsoleTable(" ");
                        while (reader.Read())
                        {
                            table.AddRow(reader[0]);
                        }
                        Console.WriteLine(table);
                    }
                    if (reader.FieldCount == 6)
                    {
                        table = new ConsoleTable(" ", " ", " ", " ", " ", " ");

                        while (reader.Read())
                        {
                            table.AddRow(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                        }
                        Console.WriteLine(table);
                    }
                    if (reader.FieldCount == 7)
                    {
                        table = new ConsoleTable(" ", " ", " ", " ", " ", " ", " ");

                        while (reader.Read())
                        {
                            table.AddRow(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6]);
                        }
                        Console.WriteLine(table);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    if (sql == "" || sql == " " || sql == "  ")
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