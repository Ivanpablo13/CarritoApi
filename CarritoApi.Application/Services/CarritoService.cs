
using AutoMapper;
using CarritoApi.Application.Features.ProductosFeature;
using CarritoApi.Application.Repositories;
using CarritoApi.Application.Result;
using CarritoApi.Domain.Entities;
using CarritoApi.Domain.Entities.Enums;

namespace CarritoApi.Application.Services
{
    public class CarritoService(ICarritoRepository carritoRepository, IProductoRepository productoRepository,
        IUsuarioRepository usuarioRepository, IMapper mapper) : ICarritoService
    {
        private readonly ICarritoRepository _carritoRepository = carritoRepository;
        private readonly IProductoRepository _productoRepository = productoRepository;
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;
        private readonly IMapper _mapper = mapper;


        public async Task<CarritoResult<int>> CrearCarrito(string dni)
        {
            var usuario = await _usuarioRepository.GetByDniAsync(dni);
            if (usuario == null) return CarritoResult<int>.Failure(MessageTypeCode.NoFound, "User not found");

            var fechaPromocional = false; //Aca podriamos inyectar o llamar a alguna funcion que determine el valor de esta variable

            var tipoCarrito = usuario.EsVip ? TipoCarrito.Vip :
                              (fechaPromocional ? TipoCarrito.FechaEspecial : TipoCarrito.Comun);

            var carrito = new Carrito
            {
                UsuarioId = usuario.Id,
                TipoCarrito = (int)tipoCarrito,
                Total = 0
            };

            var carritoCreated = await _carritoRepository.CreateAsync(carrito);
            if (carritoCreated.Id == 0) return CarritoResult<int>.Failure(MessageTypeCode.InsertProblems, "In register carrito");

            return CarritoResult<int>.Success(carritoCreated.Id, Message.InformationSuccesfullySaved);
        }

        public async Task<CarritoResult> EliminarCarrito(int id)
        {
            await _carritoRepository.DeleteAsync(id);

            return CarritoResult.Success(Message.InformationSuccessfullyDeleted);
        }

        public async Task<CarritoResult> ObtenerProductosMasCaros(string dni, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetByDniAsync(dni);
            if (usuario == null) return CarritoResult<List<Item>>.Failure(MessageTypeCode.NoFound, "User not found");

            var productosMasCaros = await _productoRepository.ObtenerProductosMasCaros(dni, cancellationToken);

            var items = _mapper.Map<List<Item>>(productosMasCaros);

            return CarritoResult<List<Item>>.Success(items);
        }



    }
}
