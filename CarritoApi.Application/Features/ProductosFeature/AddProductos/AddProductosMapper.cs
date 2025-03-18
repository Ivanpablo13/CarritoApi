using AutoMapper;
using CarritoApi.Domain.Entities;

namespace CarritoApi.Application.Features.ProductosFeature.AddProductos
{
    public class AddProductosMapper : Profile
    {
        public AddProductosMapper()
        {
            CreateMap<Carrito, ProductosResponse>()
               .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Productos))
               .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total));

            CreateMap<Producto, Item>()
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Precio, opt => opt.MapFrom(src => src.Precio));

            CreateMap<ProductosRequestDto, AddProductosRequest>();
        }
    }
}
