using System.ComponentModel.DataAnnotations;

namespace Library.Entities
{
    public class Imagem
    {
        [Key, Required]
        public long IdProduto { get; set; }
        public byte[] ImageArray { get; set; }
    }
}
