using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Entities
{
    public class Produto
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
