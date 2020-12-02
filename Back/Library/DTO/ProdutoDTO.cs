using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DTO
{
    public class ProdutoDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public ImagemDTO Imagem { get; set; }
    }
}
