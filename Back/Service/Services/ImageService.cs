using Library.Contracts;
using Library.DTO;
using Library.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Service
{
    public class ImageService : IImageService
    {

        private readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public string ConvertToBase64(byte[] bitearray)
        {
            string base64String = Convert.ToBase64String(bitearray, 0, bitearray.Length);
            var result = $"data:image/png;base64,{base64String}";
            return result;
        }

        public ImagemDTO Get(long id)
        {
            var result = new ImagemDTO();

            var imagem = _imageRepository.Get(id);

            if (imagem != null)
            {
                result.IdProduto = imagem.IdProduto;
                result.Image = ConvertToBase64(imagem.ImageArray);
            }

            return result;
        }

        public bool Insert(byte[] fileBytes, string idProd)
        {
            var result = false;

            var imagem = new Imagem
            {
                IdProduto = long.Parse(idProd),
                ImageArray = fileBytes
            };

            var img = _imageRepository.Get(long.Parse(idProd));

            if (img == null)
            {
                result = _imageRepository.Insert(imagem);
            }
            else
            {
                result = _imageRepository.Update(imagem);
            }
            return result;
        }

        public bool Delete(long id)
        {
            var imagem = new Imagem
            {
                IdProduto = id
            };

            return _imageRepository.Remove(imagem);
        }
    }
}
