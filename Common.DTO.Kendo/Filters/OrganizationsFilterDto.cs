using System;
using System.Collections.Generic;

namespace Common.Filters
{
    public class OrganizationsFilterDto
    {
        public Guid SteelPipeId { get; set; }
        public List<Guid> OrganizationIds { get; set; } = new List<Guid>();   
    }
}
