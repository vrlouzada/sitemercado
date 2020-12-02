using Library.Entities;
using System.Collections.Generic;

namespace Library.Contracts
{
    public interface IProductRepository
    {
        /// <summary>
        /// Busca todas os produtos cadastrados no banco
        /// </summary>
        /// <returns></returns>
        List<Produto> GetAll();

        /// <summary>
        /// Insere um produto no banco
        /// </summary>
        /// <param name="product">Entidade do produto</param>
        /// <returns></returns>
        Produto Insert(Produto product);

        /// <summary>
        /// Atualiza um produto no banco
        /// </summary>
        /// <param name="product">Entidade do produto</param>
        /// <returns></returns>
        bool Update(Produto product);

        /// <summary>
        /// Remove um produto do banco
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns></returns>
        bool Delete(long id);

        /// <summary>
        /// Busca um produto especifico do banco
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns></returns>
        Produto Get(long id);
    }
}
