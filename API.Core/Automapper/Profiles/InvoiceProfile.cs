using AutoMapper;
using Common.DTO;
using Common.Models;
namespace API.Core.Automapper.Profiles
{
    class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<Invoice, InvoiceDto>();
            CreateMap<InvoiceDto, Invoice>();
        }
    }
}
