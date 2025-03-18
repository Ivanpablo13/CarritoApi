using CarritoApi.Application.Result;
using MediatR;

namespace CarritoApi.Application.Features.ProductosFeature.DeleteProductos
{
    public record DeleteProductosRequest : ProductosRequestDto, IRequest<CarritoResult<ProductosResponse>>;
}
