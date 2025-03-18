
using AutoMapper;
using CarritoApi.Application.Features.ProductosFeature.AddProductos;
using CarritoApi.Domain.Entities;

namespace CarritoApi.Application.Features.ProductosFeature.DeleteProductos
{
    public class DeleteProductosMapper : Profile
    {
        public DeleteProductosMapper() 
        {
             CreateMap<Carrito, ProductosResponse>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Productos))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total));

            CreateMap<Producto, Item>()
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Precio, opt => opt.MapFrom(src => src.Precio));

            CreateMap<ProductosRequestDto, DeleteProductosRequest>();
        }
    }
}
