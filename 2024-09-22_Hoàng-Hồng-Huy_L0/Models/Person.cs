using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMgmt.Models
{
    internal class Person
    {
        private static int idCounter = 0;
        public int Id {  get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public float? Height { get; set; }
        public float? Weight { get; set; }
        public Person()
        {
            
        }
        public Person(string fullName, DateTime dateOfBirth, string address, float? height = null, float? weight = null)
        {
            Id = ++idCounter;            
            FullName = fullName;
            DateOfBirth = dateOfBirth;
            Address = address;
            Height = height;
            Weight = weight;
        }
        public override string ToString()
        {
            return $"Id: {Id} \nName: {FullName} \nDate of birth: {DateOfBirth.ToShortDateString()} \n Address: {Address} \n"
                    + $"Height: {Height} \nWeight: {Weight} \n";
        }
    }
}
