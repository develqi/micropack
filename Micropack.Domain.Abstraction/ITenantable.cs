
namespace Micropack.Domain.Abstraction
{
    public interface ITenantable
    {
        int TenantId { get; set; }
    }

    public class Tenant : IEntityNumeric
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }
    }
}