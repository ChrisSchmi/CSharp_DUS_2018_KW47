using System;

namespace HalloLinq
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }

        public int Age
        {
            get
            {
                // Save today's date.
                var today = DateTime.Today;
                // Calculate the age.
                var age = today.Year - Birthdate.Year;
                // Go back to the year the person was born in case of a leap year
                if (Birthdate > today.AddYears(-age)) age--;
                return age;
            }
        }
    }
}
