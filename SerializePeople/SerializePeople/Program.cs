using System;

namespace SerializePeople
{
    class Program
    {
        static string output = @"C:\Users\Miller\C#\SIAssignments\ThirdWeek\Threading\TestFolder\test.dat";
        static void Main(string[] args)
        {
            Person person = new Person("Ati", new DateTime(1990, 6, 12), Gender.MALE);
            person.CalculateAge();

            person.Serialize(output);
        }
    }
}
