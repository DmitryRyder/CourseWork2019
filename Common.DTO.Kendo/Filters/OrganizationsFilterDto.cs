using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Filters
{
    public class OrganizationsFilterDto
    {
        public List<Guid> Organizations { get; set; } = new List<Guid>();
    }
}
