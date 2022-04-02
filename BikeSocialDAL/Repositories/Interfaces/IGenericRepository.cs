using System.Linq.Expressions;

namespace BikeSocialDAL.Repositories.Interfaces
{
    //This interface contains the definition of some generic methods used to interact with the database
    public interface IGenericRepository<T> where T: class, new()
    {
        /// <summary>
        /// Get a single entity/row
        /// </summary>
        /// <param name="filter"></param>
        Task<T> Get(Expression<Func<T, bool>> filter = null);
        /// <summary>
        /// Get multiple entities/rows
        /// </summary>
        /// <param name="filter"></param>
        Task<List<T>> GetList(Expression<Func<T, bool>> filter = null);
        /// <summary>
        /// Inserts a single entity/row in the database
        /// </summary>
        /// <param name="entity"></param>
        Task<T> Add(T entity);
        /// <summary>
        /// Updates an entity/row in the database
        /// </summary>
        /// <param name="entity"></param>
        Task<T> Update(T entity);
        /// <summary>
        /// Deletes an entity/row from the database
        /// </summary>
        /// <param name="entity"></param>
        Task<int> Delete(T entity);
    }

    //This interface contains the definition of some generic methods used to interact with the database
    public interface IGenericRepositoryEquipa<T> where T : class, new()
    {
        /// <summary>
        /// Get a single entity/row
        /// </summary>
        /// <param name="filter"></param>
        Task<T> Get(Expression<Func<T, bool>> filter = null);
        /// <summary>
        /// Get multiple entities/rows
        /// </summary>
        /// <param name="filter"></param>
        Task<List<T>> GetList(Expression<Func<T, bool>> filter = null);
        /// <summary>
        /// Inserts a single entity/row in the database
        /// </summary>
        /// <param name="entity"></param>
       Task<T> Add(T entity);
        /// <summary>
        /// Updates an entity/row in the database
        /// </summary>
        /// <param name="entity"></param>
        Task<T> Update(T entity);
        /// <summary>
        /// Deletes an entity/row from the database
        /// </summary>
        /// <param name="entity"></param>
        Task<int> Delete(T entity);
    }
}
