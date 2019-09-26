using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpNewFeatures
{
    public static class NullableReferenceTypes
    {
        public static void Demo()
        {
            var thePerson = new Person("Scott", "Hanselman");
            var length = GetMiddleNameLength(thePerson);
            Console.WriteLine(length);
        }

        static int GetMiddleNameLength(Person? person) =>
            person?.MiddleName is { Length: var length } ? length : 0;

        class Person
        {

            public string FirstName { get; set; }
            public string? MiddleName { get; set; }
            public string LastName { get; set; }

            public Person(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }

            public Person(string firstName, string middleName, string lastName)
            {
                FirstName = firstName;
                MiddleName = middleName;
                LastName = lastName;
            }
        }
    }
}
