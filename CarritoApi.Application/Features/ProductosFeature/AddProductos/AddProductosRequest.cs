
using CarritoApi.Application.Result;
using MediatR;

namespace CarritoApi.Application.Features.ProductosFeature.AddProductos
{
    public record AddProductosRequest : ProductosRequestDto, IRequest<CarritoResult<ProductosResponse>>;
}
