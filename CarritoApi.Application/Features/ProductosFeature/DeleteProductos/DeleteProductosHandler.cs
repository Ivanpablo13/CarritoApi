using AutoMapper;
using CarritoApi.Application.Features.ProductosFeature.AddProductos;
using CarritoApi.Application.Repositories;
using CarritoApi.Application.Result;
using CarritoApi.Domain.Entities;
using MediatR;

namespace CarritoApi.Application.Features.ProductosFeature.DeleteProductos
{
    public class DeleteProductosHandler(ICarritoRepository _carritoRepository,
        IMapper _mapper) : IRequestHandler<DeleteProductosRequest, CarritoResult>
    {
        public async Task<CarritoResult> Handle(DeleteProductosRequest request, CancellationToken cancellationToken)
        {
            var carrito = await _carritoRepository.GetCompleteByIdAsync(request.CarritoId);
            if (carrito == null) return CarritoResult<int>.Failure(MessageTypeCode.NoFound, "Carrito not found");

            var productToDelete = carrito.Productos.FirstOrDefault(i => i.Id == request.ProductoId);
            if (productToDelete == null) return CarritoResult<int>.Failure(MessageTypeCode.NoFound, "Producto en Carrito not found");

            carrito.Productos.Remove(productToDelete);
            carrito.Total -= productToDelete.Precio;
            await _carritoRepository.SaveChangesAsync();

            var data = _mapper.Map<ProductosResponse>(carrito);

            return CarritoResult<ProductosResponse>.Success(data, Message.InformationSuccessfullyDeleted);
        }
    }
}
