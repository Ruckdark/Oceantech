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
            if (string.IsNullOrEmpty(fullName) || fullName.Length >= 100)
            {
                throw new ArgumentException("Ten khong hop le");
            }
            if (dateOfBirth == null || dateOfBirth.Year < 1900)
            {
                throw new ArgumentException("Ngay sinh phai tu nam 1900 tro len");
            }
            if (address.Length >= 300)
            {
                throw new ArgumentException("Dia chi khong hop le");
            }
            if (height < 50.0f || height > 300.0f)
            {
                throw new ArgumentException("");
            }
            if (weight < 5.0f || weight > 1000.0f)
            {
                throw new ArgumentException("");
            }
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
