using Library.Contracts;
using Library.DTO;
using Library.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IImageService _imageService;

        public ProductService(IProductRepository productRepository, IImageService imageService)
        {
            _productRepository = productRepository;
            _imageService = imageService;
        }


        public List<ProdutoDTO> GetAll()
        {
            var result = new List<ProdutoDTO>();

            var products = _productRepository.GetAll();

            if (products.Count > 0)
            {
                foreach (var prod in products)
                {
                    var produto = new ProdutoDTO
                    {
                        Id = prod.Id,
                        Name = prod.Name,
                        Price = prod.Price
                    };

                    var img = _imageService.Get(prod.Id);

                    if(img != null)
                    {
                        produto.Imagem = new ImagemDTO
                        {
                            IdProduto = prod.Id,
                            Image = img.Image
                        };
                    }

                    result.Add(produto);
                }
            }

            return result;
        }

        public ProdutoDTO Insert(ProdutoDTO dto)
        {
            var produto = new Produto
            {
                Name = dto.Name,
                Price = dto.Price
            };

            var result = _productRepository.Insert(produto);
            dto.Id = result.Id;
            return dto;
        }

        public bool Delete(long id)
        {
            var imagem = _imageService.Get(id);

            if(imagem != null)
            {
                var imagemResult = _imageService.Delete(id);

                if (imagemResult)
                {
                    return _productRepository.Delete(id);
                }
            }
            else
            {
                return _productRepository.Delete(id);
            }

            return false;
        }

        public bool Update(ProdutoDTO dto)
        {
            var produto = new Produto
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price
            };

            return _productRepository.Update(produto);
        }

       
    }
}
