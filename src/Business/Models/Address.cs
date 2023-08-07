
namespace Business.Models
{
   
    public class Address:Entity

    {
        
        public Guid ProviderId { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string AddressSupplement { get; set; }

        public string ZipCode { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public Provider Provider { get; set; }
    }
}
