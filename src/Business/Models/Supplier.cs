
namespace Business.Models
{
   
    public class Supplier : Entity
    {
        public string Name { get; set; }
        public string IdentityCard  { get; set; }
        public SupplierType Type { get; set; }
        public Address Address { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
