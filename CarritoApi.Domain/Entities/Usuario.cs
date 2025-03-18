using CarritoApi.Domain.Common;

namespace CarritoApi.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string Dni { get; set; } = null!;
        public bool EsVip { get; set; }
    }
}
