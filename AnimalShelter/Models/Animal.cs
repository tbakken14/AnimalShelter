using System;
using System.Collections.Generic;
using MySqlConnector;

namespace AnimalShelter.Models 
{
    public class Animal 
    {
        public DateTime DateOfAdmittance { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }

        public Animal(string name, string type, string description) {
            Name = name;
            Type = type;
            Description = description;
            DateOfAdmittance = DateTime.UtcNow;
        }

        public Animal(string name, string type, string description, DateTime dateOfAdmittance) {
            Name = name;
            Type = type;
            Description = description;
            DateOfAdmittance = dateOfAdmittance;
        }

        public Animal(string name, string type, string description, int id) {
            Name = name;
            Type = type;
            Description = description;
            DateOfAdmittance = DateTime.UtcNow;
            Id = id;
        }

        public Animal(string name, string type, string description, DateTime dateOfAdmittance, int id) {
            Name = name;
            Type = type;
            Description = description;
            DateOfAdmittance = dateOfAdmittance;
            Id = id;
        }

        public static void Create(string name, string description, string type) {
            Animal animal = new Animal(name, description, type);
            string commandText = $"INSERT INTO Animals (name, description, type, dateOfAdmittance) VALUES ('{animal.Name}', '{animal.Description}', '{animal.Type}', '{animal.DateOfAdmittance.ToString("yyyy'-'MM'-'dd' 'HH'-'mm'-'ss")}');";
            Animal.ExecuteNonQueryDatabaseRequest(commandText);
        }

        public static void Delete(int id) {
            string commandText = $"DELETE FROM Animals WHERE id = {id};";
            Animal.ExecuteNonQueryDatabaseRequest(commandText);
        }

        public static List<Animal> GetAll() {
            List<Animal> animals = new List<Animal>();
            MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = $"SELECT * FROM Animals;";

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read()) {
                int id = rdr.GetInt32(0);
                string name = rdr.GetFieldValue<string>(1);
                string description = rdr.GetString("description");
                string type = rdr.GetString(3);
                DateTime date = rdr.GetFieldValue<DateTime>(4);
                Animal animal = new Animal(name, description, type, date, id);
                animals.Add(animal);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return animals;
        }

        private static void ExecuteNonQueryDatabaseRequest(string commandText) {
            MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = commandText;

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}



