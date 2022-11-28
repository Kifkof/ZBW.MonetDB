using MonetDb.Mapi;

namespace MonetDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var conn = new MonetDbConnection("Host=localhost;port=50000;Database=demo;username=monetdb;password=monetdb");
            conn.Open();

            ReCreateTablePerson(conn);
            CreatePersons(conn);

            var persons = ReadAllPersons(conn);
            Console.WriteLine("Personen");
            Console.WriteLine("---------------------------------------------------------------------------------");
            foreach (var person in persons) 
                Console.WriteLine(person);

            var avgYearsOfExperience = GetAverageYearsOfExperience(conn);
            Console.WriteLine($"Durschnittliche Berufserfahrung: {avgYearsOfExperience}");
        }

        private static float GetAverageYearsOfExperience(MonetDbConnection conn)
        {
            var cmd = new MonetDbCommand("SELECT AVG(YearsOfExperience) FROM Person;", conn);
            return cmd.ExecuteScalar() is float ? (float) cmd.ExecuteScalar() : throw new Exception("Durschnittliche Berufserfahrung konnte nicht bestummen werden");
        }

        private static List<Person> ReadAllPersons(MonetDbConnection conn)
        {
            var cmd = new MonetDbCommand("SELECT * FROM Person;", conn);
            using var reader = cmd.ExecuteReader();
            var persons = new List<Person>();
            while (reader.Read())
            {
                persons.Add(new Person(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
            }

            return persons;
        }

        private static void CreatePersons(MonetDbConnection conn)
        {
            var cmd = new MonetDbCommand("INSERT INTO Person VALUES(1, 'Hans', 4);", conn);
            cmd.ExecuteNonQuery();
            cmd = new MonetDbCommand("INSERT INTO Person VALUES(2, 'Petra', 2);", conn);
            cmd.ExecuteNonQuery();
            cmd = new MonetDbCommand("INSERT INTO Person VALUES(3, 'Ueli', 0);", conn);
            cmd.ExecuteNonQuery();
            cmd = new MonetDbCommand("INSERT INTO Person VALUES(4, 'Melanie', 6);", conn);
            cmd.ExecuteNonQuery();
        }

        private static void ReCreateTablePerson(MonetDbConnection conn)
        {
            var cmd = new MonetDbCommand("DROP TABLE Person;", conn);
            cmd.ExecuteNonQuery();

            cmd = new MonetDbCommand(@"CREATE TABLE Person(
Id INT NOT NULL PRIMARY KEY,
Name VARCHAR(200),
YearsOfExperience INT
);", conn);
            cmd.ExecuteNonQuery();
        }
    }
}