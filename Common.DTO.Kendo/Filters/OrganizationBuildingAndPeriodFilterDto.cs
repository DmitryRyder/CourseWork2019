using System;

namespace Common.Filters
{
    public class OrganizationBuildingAndPeriodFilterDto
    {
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }

        public Guid BuildingId { get; set; }
    }
}
