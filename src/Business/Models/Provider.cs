
namespace Business.Models
{
   
    public partial class Provider : Entity
    {
        public string Name { get; set; }
        public string IdentityCard  { get; set; }
        public ProviderType Type { get; set; }
        public Address Address { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
