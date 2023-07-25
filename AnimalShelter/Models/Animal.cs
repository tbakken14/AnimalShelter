using System.Runtime;

namespace AnimalShelter.Models {
    public class Animal {
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
    }
}