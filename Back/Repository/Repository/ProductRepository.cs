using Dapper;
using Library.Contracts;
using Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class ProductRepository : Base.Repository, IProductRepository
    {
        public Produto Get(long id)
        {
            try
            {
                using (var db = GetConnection())
                {
                    return db.Get<Produto>(id);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Produto> GetAll()
        {
            try
            {
                using (var db = GetConnection())
                {
                    return db.GetList<Produto>().ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Produto Insert(Produto product)
        {
            try
            {
                using (var db = GetConnection())
                {
                    var id = db.Insert<long, Produto>(product);
                    product.Id = id;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return product;
        }

        public bool Update(Produto product)
        {
            try
            {
                using (var db = GetConnection())
                {
                    var isUpdated = db.Update<Produto>(product);
                    return isUpdated == 1 ? true : false;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool Delete(long id)
        {
            try
            {
                using (var db = GetConnection())
                {
                    var isDeleted = db.Delete<Produto>(new Produto { Id = id });
                    return isDeleted == 1 ? true : false;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

      
    }
}
