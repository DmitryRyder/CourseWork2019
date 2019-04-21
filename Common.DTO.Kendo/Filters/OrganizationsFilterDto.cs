using System;
using System.Collections.Generic;

namespace Common.Filters
{
    public class OrganizationsFilterDto
    {
        public List<Guid> OrganizationIds { get; set; } = new List<Guid>();   
    }
}
