using AutoMapper;
using CarritoApi.Application.Repositories;
using CarritoApi.Application.Result;
using MediatR;

namespace CarritoApi.Application.Features.ProductosFeature.AddProductos
{
    public class AddProductosHandler(IProductoRepository _productoRepository,
        ICarritoRepository _carritoRepository, IMapper _mapper) : IRequestHandler<AddProductosRequest, CarritoResult>
    {
        public async Task<CarritoResult> Handle(AddProductosRequest request, CancellationToken cancellationToken)
        {
            var carrito = await _carritoRepository.GetCompleteByIdAsync(request.CarritoId);
            if (carrito == null) return CarritoResult<int>.Failure(MessageTypeCode.NoFound, "Carrito not found");

            var producto = await _productoRepository.GetByIdAsync(request.ProductoId);
            if (producto == null) return CarritoResult<int>.Failure(MessageTypeCode.NoFound, "Producto not found");

            carrito.Productos.Add(producto);
            carrito.Total += producto.Precio;
            await _carritoRepository.SaveChangesAsync();

            var data = _mapper.Map<ProductosResponse>(carrito);

            return CarritoResult<ProductosResponse>.Success(data, Message.InformationSuccesfullySaved);
        }
    }
}
