using Library.DTO;
using Library.Entities;
using System.Collections.Generic;

namespace Library.Contracts
{
    public interface IProductService
    {
        /// <summary>
        /// Servico de busca de todos os produtos
        /// </summary>
        /// <returns></returns>
        List<ProdutoDTO> GetAll();

        /// <summary>
        /// Serviço de inserção de produto
        /// </summary>
        /// <param name="dto">DTO do produto</param>
        /// <returns></returns>
        ProdutoDTO Insert(ProdutoDTO dto);

        /// <summary>
        /// Serviço de remoção de produto
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns></returns>
        bool Delete(long id);

        /// <summary>
        /// Serviço de atualização de Produto
        /// </summary>
        /// <param name="dto">DTO do produto</param>
        /// <returns></returns>
        bool Update(ProdutoDTO dto);
    }
}
