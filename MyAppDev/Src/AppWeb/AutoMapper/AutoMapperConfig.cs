using AppWeb.ViewModels;
using AutoMapper;
using Business.Models;

namespace AppWeb.AutoMapper
{
    public class AutoMapperConfig :Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Address  ,  AddressViewModel>().ReverseMap();
            CreateMap<Product  ,  ProductViewModel>().ReverseMap();
            CreateMap<Supplier ,  SupplierViewModel>().ReverseMap();
        }
    }
}
