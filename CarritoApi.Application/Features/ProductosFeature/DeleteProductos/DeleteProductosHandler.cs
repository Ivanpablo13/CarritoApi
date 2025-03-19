using AutoMapper;
using CarritoApi.Application.Features.ProductosFeature.AddProductos;
using CarritoApi.Application.Repositories;
using CarritoApi.Application.Result;
using CarritoApi.Domain.Entities;
using MediatR;

namespace CarritoApi.Application.Features.ProductosFeature.DeleteProductos
{
    public class DeleteProductosHandler(ICarritoRepository _carritoRepository,
       ICarritoProductoRepository _carritoProductoRepository, IMapper _mapper) : IRequestHandler<DeleteProductosRequest, CarritoResult>
    {
        public async Task<CarritoResult> Handle(DeleteProductosRequest request, CancellationToken cancellationToken)
        {
            var carrito = await _carritoRepository.GetCompleteByIdAsync(request.CarritoId);
            if (carrito == null) return CarritoResult<int>.Failure(MessageTypeCode.NoFound, "Carrito not found");

            var productoEnCarrito = await _carritoProductoRepository.VerificarExistenciaProductoEnCarrito(request.CarritoId, request.ProductoId);
            if (productoEnCarrito != null)
            {
                await _carritoProductoRepository.DeleteAsync(productoEnCarrito.Id);
            }

            var data = _mapper.Map<ProductosResponse>(carrito);

            return CarritoResult<ProductosResponse>.Success(data, Message.InformationSuccessfullyDeleted);
        }
    }
}
