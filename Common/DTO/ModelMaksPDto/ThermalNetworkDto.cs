using System;
using System.ComponentModel;

namespace Common.DTO
{
    public class ThermalNetworkDto : BaseDto
    {
        [DisplayName("Название сети")]
        public string Name { get; set; }
        [DisplayName("Номер сети")]
        public int NumberOfNetwork { get; set; }
        [DisplayName("Тип сети")]
        public string NetworkView { get; set; } //"вид сети" - однотрубная/двухтрубная

        public Guid OrganizationID { get; set; }
        [DisplayName("Название организации")]
        public string OrganizationName { get; set; }
    }
}
