using AutoMapper;
using CarritoApi.Application.Repositories;
using CarritoApi.Application.Result;
using CarritoApi.Domain.Entities;
using MediatR;

namespace CarritoApi.Application.Features.ProductosFeature.AddProductos
{
    public class AddProductosHandler(IProductoRepository _productoRepository,
        ICarritoRepository _carritoRepository, ICarritoProductoRepository _carritoProductoRepository, IMapper _mapper) : IRequestHandler<AddProductosRequest, CarritoResult>
    {
        public async Task<CarritoResult> Handle(AddProductosRequest request, CancellationToken cancellationToken)
        {
            var carrito = await _carritoRepository.GetCompleteByIdAsync(request.CarritoId);
            if (carrito == null) return CarritoResult<int>.Failure(MessageTypeCode.NoFound, "Carrito not found");

            var productoEnCarrito = await _carritoProductoRepository.VerificarExistenciaProductoEnCarrito(request.CarritoId, request.ProductoId);
            if (productoEnCarrito != null)
            {
                productoEnCarrito.Cantidad += 1;
                await _carritoProductoRepository.SaveChangesAsync();
            }
            else
            {
                var nuevoCarritoProducto = new CarritoProducto
                {
                    CarritoId = request.CarritoId,
                    ProductoId = request.ProductoId,
                    Cantidad = 1
                };

                await _carritoProductoRepository.CreateAsync(nuevoCarritoProducto);
            }

            var data = _mapper.Map<ProductosResponse>(carrito);

            return CarritoResult<ProductosResponse>.Success(data, Message.InformationSuccesfullySaved);
        }
    }
}
