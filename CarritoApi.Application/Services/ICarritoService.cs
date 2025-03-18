

using CarritoApi.Application.Repositories;
using CarritoApi.Application.Result;
using CarritoApi.Domain.Entities;

namespace CarritoApi.Application.Services
{
    public interface ICarritoService
    {
        Task<CarritoResult<int>> CrearCarrito(string dni);
        Task<CarritoResult> EliminarCarrito(int id);
        Task<CarritoResult> ObtenerProductosMasCaros(string dni, CancellationToken cancellationToken);
    }
}
