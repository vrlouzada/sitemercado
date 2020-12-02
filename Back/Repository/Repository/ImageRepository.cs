using Dapper;
using Library.Contracts;
using Library.Entities;
using System;

namespace Data.Repository
{
    public class ImageRepository : Base.Repository, IImageRepository
    {
        public Imagem Get(long id)
        {
            try
            {
                using (var db = GetConnection())
                {
                    return db.Get<Imagem>(id);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Insert(Imagem imagem)
        {
            try
            {
                using (var db = GetConnection())
                {
                    var result = db.Insert<long, Imagem>(imagem);

                    return result != 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public bool Remove(Imagem imagem)
        {
            try
            {
                using(var db = GetConnection())
                {
                    var result = db.Delete(imagem);
                    return result != 0 ? true : false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(Imagem imagem)
        {
            try
            {
                using (var db = GetConnection())
                {
                    var result = db.Update(imagem);

                    return result != 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
