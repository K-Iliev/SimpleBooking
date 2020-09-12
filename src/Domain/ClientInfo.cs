namespace Domain
{
    public class ClientInfo
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public string  PhoneNumber { get; private set; }
        public ClientInfo(string firstName, string lastName, string phoneNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
        }
    }
}
