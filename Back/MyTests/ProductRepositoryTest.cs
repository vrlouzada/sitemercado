using Data.Repository;
using Library.Entities;
using Library.Contracts;
using System;
using Xunit;
using System.IO;
using NPOI.Util;

namespace MyTests
{
    public class ProductRepositoryTest
    {
        private readonly IProductRepository _productRepository;

        public ProductRepositoryTest()
        {
            var repository = new ProductRepository();
            _productRepository = repository;
        }


       

        [Theory]
        [InlineData("2500", "LapTop")]
        public void Insert(string price, string name)
        {

            var product = new Produto
            {
                Name = name,
                Price = Convert.ToDecimal(price)
            };

            var result = _productRepository.Insert(product);

            Assert.True(result.Id != 0);
        }

        [Fact]
        public void GetAll()
        {
            var result = _productRepository.GetAll();

            Assert.True(result != null);
            Assert.True(result.Count > 0);
        }

        [Theory]
        [InlineData(2L)]
        public void Get(long id)
        {
            var result = _productRepository.Get(id);

            Assert.True(result != null);
        }

        [Theory]
        [InlineData(2, "1500", "LapTop")]
        public void Update(int id, string price, string name)
        {

            var product = new Produto
            {
                Id = id,
                Name = name,
                Price = Convert.ToDecimal(price)
            };

            var result = _productRepository.Update(product);

            Assert.True(result);
        }

        [Theory]
        [InlineData(2)]
        public void Delete(int id)
        {
            var result = _productRepository.Delete(id);

            Assert.True(result);
        }       

    }
}
