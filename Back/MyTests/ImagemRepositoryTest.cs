using Data.Repository;
using Library.Contracts;
using Library.Entities;
using Xunit;

namespace MyTests
{
    public class ImagemRepositoryTest
    {
        private readonly IImageRepository _imageRepository;


        public ImagemRepositoryTest()
        {
            _imageRepository = new ImageRepository();
        }


        [Theory]
        [InlineData(2L)]
        public void Get(long id)
        {
            var result = _imageRepository.Get(id);

            Assert.True(result != null);
        }
       

        [Theory]
        [InlineData(2)]
        public void Delete(int id)
        {
            var result = _imageRepository.Remove(new Imagem { IdProduto = id });

            Assert.True(result);
        }
    }
}
