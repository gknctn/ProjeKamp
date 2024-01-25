using System;

namespace ProjeKamp.Models
{
    public class Person
    {
        public Guid Id{ get; set; }
        public string Name{ get; set; }
        public string Surname{ get; set; }
        public string IdentificationNumber { get; set; }
        public string Country{ get; set; }
        public string City { get; set; }
    }
}
