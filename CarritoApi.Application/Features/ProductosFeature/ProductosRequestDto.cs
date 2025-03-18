

namespace CarritoApi.Application.Features.ProductosFeature
{
    public record ProductosRequestDto
    {
        public required int ProductoId { get; set; }
        public required int CarritoId { get; set; }
    }
}
