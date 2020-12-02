using Data.Repository;
using Library.Contracts;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace MyTests
{
    public class ImageServiceTest
    {
        private readonly IImageService _imageService;


        public ImageServiceTest()
        {
            var repository = new ImageRepository();
            _imageService = new ImageService(repository);
        }

        [Theory]
        [InlineData(4L)]
        public void Get(long id)
        {
            var result = _imageService.Get(id);

            Assert.True(result.IdProduto == id);
        }

        [Theory]
        [InlineData(@"‪teste.jpg", "4")]
        public void InsertAndUpdate(string imageName, string id)
        {

            byte[] bytes = File.ReadAllBytes(imageName);
            //Begins the process of writing the byte array back to a file

            var result = _imageService.Insert(bytes, id);

            Assert.True(result);
        }
               

        [Theory]
        [InlineData(1L)]
        public void Delete(long id)
        {
            var result = _imageService.Delete(id);

            Assert.True(result);
        }
    }
}
