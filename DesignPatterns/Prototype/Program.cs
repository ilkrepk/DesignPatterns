using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer {FirstName="İlker", LastName="Epik", City="Adana", Id=1 };
            Console.WriteLine("Müsteri 1 Adı: {0}", customer1.FirstName);

            Customer customer2 = (Customer)customer1.Clone();
            customer2.FirstName = "Salih";

            Console.WriteLine("Müşteri 2 Adı: {0}",customer2.FirstName);
            Console.WriteLine("Müsteri 1 Adı: {0}",customer1.FirstName);

            Console.ReadLine();
        }
    }

    public abstract class Person
    {
        public abstract Person Clone();
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Customer : Person
    {
        //Sadece customer'a özel bir alan
        public string City { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }

    public class Employee : Person
    {
        //Sadece customer'a özel bir alan
        public decimal Salary { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
}
