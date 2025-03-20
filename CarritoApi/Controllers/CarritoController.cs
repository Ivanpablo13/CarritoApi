using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using CarritoApi.Application.Services;
using CarritoApi.Application.Result;
using CarritoApi.Application.Features.ProductosFeature;
using AutoMapper;
using CarritoApi.Application.Features.ProductosFeature.AddProductos;
using CarritoApi.Application.Features.ProductosFeature.DeleteProductos;
using CarritoApi.Domain.Entities;
using Azure;

namespace CarritoApi.Controllers
{
    [Route("api/Carrito/")]
    [ApiController]
    public class CarritoController(IMediator _mediator, ICarritoService _carritoService, IMapper _mapper) : ControllerBase
    {   

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<CarritoResult>> CreateNewCarrito(string dniUsuario, CancellationToken cancellationToken)
        {
            var carritoId = await _carritoService.CrearCarrito(dniUsuario);
            return Ok(carritoId);
        }

        /// <param name="id"></param>
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<CarritoResult>> DeleteCarrito(int id, CancellationToken cancellationToken)
        {
            var result = await _carritoService.EliminarCarrito(id);
            return Ok(result);
        }

        [HttpPut]
        [Route("Addproduct")]
        public async Task<ActionResult<CarritoResult>> AddProductToCarrito([FromBody] ProductosRequestDto requestDto, CancellationToken cancellationToken)
        {
            var req = _mapper.Map<AddProductosRequest>(requestDto);
            var response = await _mediator.Send(req, cancellationToken);
            return Ok(response); 
        }

        /// <param name="id"></param>
        /// <param name="productid"></param>
        [HttpDelete]
        [Route("{id}/Producto/{productid}")]
        public async Task<ActionResult<CarritoResult>> DeleteProductFromCarrito(int id, int productid, CancellationToken cancellationToken)
        {
            var req = new DeleteProductosRequest{ CarritoId = id, ProductoId = productid, }; 
            var response = await _mediator.Send(req, cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}/TotalAPagar")]
        public async Task<ActionResult<CarritoResult>> GetTotalAPagarCarrito(int id, CancellationToken cancellationToken)
        {
            var response = await _carritoService.TotalAPagarCarrito(id);
            return Ok(response);
        }


        [HttpGet]
        [Route("ExpensiveProducts/{dniUsuario}")]
        public async Task<ActionResult<CarritoResult>> GetExpensiveProducts(string dniUsuario, CancellationToken cancellationToken)
        {
            var response = await _carritoService.ObtenerProductosMasCaros(dniUsuario, cancellationToken);
            return Ok(response);
        }
    }
}
