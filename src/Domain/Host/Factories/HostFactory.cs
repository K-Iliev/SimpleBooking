namespace Domain.Host.Factories
{
    public class HostFactory : IHostFactory
    {
        private string name;
        private string phoneNumber;
        private string email;
        public IHostFactory WithName(string name)
        {
            this.name = name;
            return this;
        }

        public IHostFactory WithPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
            return this;
        }

        public IHostFactory WithEmail(string email)
        {
            this.email = email;
            return this;
        }
        public Host Build()
        {
            return new Host(this.name, this.phoneNumber, this.email);
        }
    }
}
