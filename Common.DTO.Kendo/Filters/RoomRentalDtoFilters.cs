using System;

namespace Common.Filters
{
    public class RoomRentalDtoFilters
    {
        public DateTime? DateInputStart { get; set; }
        public DateTime? DateInputEnd { get; set; }
        public DateTime? DateOutputStart { get; set; }
        public DateTime? DateOutputEnd { get; set; }
    }
}
