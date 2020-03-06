namespace MEU.Common.Models
{
    public class ClientResponse
    {
        public int Id { get; set; }

        public CompanyResponse Company { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Document { get; set; }

        public string FullName => $"{FirstName} {LastName}";


    }
}
