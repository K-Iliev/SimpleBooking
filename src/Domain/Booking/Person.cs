using Domain.Common;

namespace Domain.Booking
{
    public class Person : ValueObject
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public Person(string firstName, string lastName, string phoneNumber, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
        }
    }
}
