using System;
using System.Collections.Generic;

namespace Common.Filters
{
    public class OrganizationsFilterDto : BaseFilterDto
    {
        public List<string> Organizations { get; set; } = new List<string>();
    }
}
