using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balkezesek
{
    internal class Adatbazis
    {
        private string connectionString;
        private List<People> peoples;

        public Adatbazis()
        {
            connectionString = "Server=localhost;Database=jatekosok;User Id=root;Pwd='';";
            this.peoples = new List<People>();
            Kapcsolodas();
            Feladatok();
        }

        public void Kapcsolodas()
        {
            Console.WriteLine("Kapcsolódás az adatbázishoz...");
            string query = "SELECT * FROM balkezesek";
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                People people = new People(
                                    reader.GetInt32("id"),
                                    reader.GetString("nev"),
                                    reader.GetDateTime("elso"),
                                    reader.GetDateTime("utolso"),
                                    reader.GetInt32("suly"),
                                    reader.GetInt32("magassag")
                                );
                                peoples.Add(people);
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Hiba történt az adatbázis kapcsolat során: {ex.Message}");
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Általános hiba történt: {ex.Message}");
                Environment.Exit(1);
            }
        }

        public void Feladatok()
        {
            Console.WriteLine($"3. Feladat: {peoples.Count}");

            Console.WriteLine("4. feladat");
            var oktober99 = peoples.Where(p => p.Utolso >= new DateTime(1999, 10, 1) && p.Utolso <= new DateTime(1999, 10, 30)).ToList();
            oktober99.ForEach(p => Console.WriteLine($"\t{p.Name}, {(double)p.Magassag * 2.54} cm"));

            Console.WriteLine("5. feladat");
            bool fut = true;
            int be;
            do
            {
                Console.Write("Kérek egy 1990 és 1999 közötti évszámot: ");
                be = Convert.ToInt32(Console.ReadLine());

                if (be >= 1990 && be <= 1999)
                {
                    fut = false;
                }
                else
                {
                    Console.Write("Hibás adat! "); 
                }
            } while(fut);

            Console.WriteLine($"6. feladat: {Math.Round(peoples.Where(p => p.Elso.Year <= be && p.Utolso.Year >= be).Average(p => p.Suly), 2)} font");
        }
    }
}
