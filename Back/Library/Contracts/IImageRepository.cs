using Library.Entities;

namespace Library.Contracts
{
    public interface IImageRepository
    {
        /// <summary>
        /// Insere uma imagem o banco
        /// </summary>
        /// <param name="imagem">Entidade da imagem</param>
        /// <returns></returns>
        bool Insert(Imagem imagem);

        /// <summary>
        /// Retorna uma imagem do banco
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns></returns>
        Imagem Get(long id);

        /// <summary>
        /// Atualiza uma imagem no banco
        /// </summary>
        /// <param name="imagem">Entidade da Imagem</param>
        /// <returns></returns>
        bool Update(Imagem imagem);

        /// <summary>
        /// Remove uma imagem do banco
        /// </summary>
        /// <param name="imagem">Entidade da imagem</param>
        /// <returns></returns>
        bool Remove(Imagem imagem);
    }
}
