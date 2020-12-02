using Library.DTO;

namespace Library.Contracts
{
    public interface IImageService
    {
        /// <summary>
        /// Converte byte array para base64
        /// </summary>
        /// <param name="bitearray">Byte Array do arquivo</param>
        /// <returns></returns>
        string ConvertToBase64(byte[] bitearray);

        /// <summary>
        /// Servivo de busca uma imagem do banco
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns></returns>
        ImagemDTO Get(long id);

        /// <summary>
        /// Serviço de inserção uma imagem no banco
        /// </summary>
        /// <param name="fileBytes">Byte array da imagem</param>
        /// <param name="idProd">Id do Produto</param>
        /// <returns></returns>
        bool Insert(byte[] fileBytes, string idProd);

        /// <summary>
        /// Serviço de remove uma umagem do banco
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns></returns>
        bool Delete(long id);
    }
}
