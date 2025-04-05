using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Domain.Entities
{
    public class Branch : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;

        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; } = null!;

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
