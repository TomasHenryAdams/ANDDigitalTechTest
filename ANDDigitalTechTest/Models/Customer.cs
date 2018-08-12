using System.Collections.Generic;

namespace ANDDigitalTechTest.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
    }

    public class PhoneNumber
    {
        public string TelephoneNumber { get; set; }
        public bool Active { get; set; }
    }
}