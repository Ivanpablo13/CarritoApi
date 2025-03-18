
namespace CarritoApi.Application.Features.ProductosFeature
{
    public record ProductosResponse
    {
        public int Id { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public decimal Total { get; set; }
    }

    public record Item
    {
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
    }
}
