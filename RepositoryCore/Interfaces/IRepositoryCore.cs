using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RepositoryCore.Interfaces
{
    public  interface IRepositoryCore<T, TKey>
  where T :class, IEntity<TKey>
    {
        Type GetGenericType();
        //Get we can search Cache too

        #region Get

        /// <summary>
        ///     Get Entity by id key
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lineNumber"></param>
        /// <param name="caller"></param>
        /// <returns></returns>
        T Get(TKey id);

        /// <summary>
        ///     Get with async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lineNumber"></param>
        /// <param name="caller"></param>
        /// <returns></returns>
        Task<T> GetAsync(TKey id);

        /// <summary>
        ///     Get First used searcg first cache if you add cache manager
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="lineNumber"></param>
        /// <param name="caller"></param>
        /// <returns></returns>
        T GetFirst(Expression<Func<T, bool>> expression);
        T GetLast(Expression<Func<T, bool>> expression);

        /// <summary>
        ///     simular but async
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="lineNumber"></param>
        /// <param name="caller"></param>
        /// <returns></returns>
        Task<T> GetFirstAsync(Expression<Func<T, bool>> expression);

        #endregion

        // add Entitys with cache

        #region Add

        /// <summary>
        ///     Add Entity sync
        /// </summary>
        /// <param name="model"></param>
        /// <param name="lineNumber"></param>
        /// <param name="caller"></param>
        void Add(T model);

        /// <summary>
        ///     Add Range entity Entity Async
        /// </summary>
        /// <param name="models"></param>
        /// <param name="lineNumber"></param>
        /// <param name="caller"></param>
        void AddRange(List<T> models);

        /// <summary>
        ///     Add Async module
        /// </summary>
        /// <param name="model"></param>
        /// <param name="lineNumber"></param>
        /// <param name="caller"></param>
        /// <returns></returns>
        Task AddAsync(T module);

        /// <summary>
        ///     Add Range Entity Async
        /// </summary>
        /// <param name="models"></param>
        /// <param name="lineNumber"></param>
        /// <param name="caller"></param>
        /// <returns></returns>
        Task AddRangeAsync(List<T> models);

        #endregion

        // Update Entitys with cache

        #region Update

        /// <summary>
        ///     Update Entity ig you inclue cache update too
        /// </summary>
        /// <param name="model"></param>
        /// <param name="lineNumber"></param>
        /// <param name="caller"></param>
        void Update(T model);

        /// <summary>
        ///     Update Async update first Entity
        /// </summary>
        /// <param name="model"></param>
        /// <param name="lineNumber"></param>
        /// <param name="caller"></param>
        /// <returns></returns>
        Task UpdateAsync(T model);

        /// <summary>
        ///     Update Many models
        /// </summary>
        /// <param name="models"></param>
        /// <param name="lineNumber"></param>
        /// <param name="caller"></param>
        void UpdateMany(List<T> models);

        /// <summary>
        ///     Update Many async models
        /// </summary>
        /// <param name="models"></param>
        /// <param name="lineNumber"></param>
        /// <param name="caller"></param>
        /// <returns></returns>
        Task UpdateManyAsync(List<T> models);
        //  void Update(Expression<Func<T, T>>selector,  [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string caller = null);
        //Task UpdateAsync(Expression<Func<T, T>> selector,  [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string caller = null);

        #endregion

        // Delete Entitys from database with cache

        #region Delete

        /// <summary>
        ///     Delete by Id
        /// </summary>
        /// <param name="id"></param>
        T Delete(TKey id);

        /// <summary>
        ///     Delete gived model
        /// </summary>
        /// <param name="model"></param>
        /// <param name="lineNumber"></param>
        /// <param name="caller"></param>
        T Delete(T model);

        /// <summary>
        ///     Delete async geved model
        /// </summary>
        /// <param name="model"></param>
        /// <param name="lineNumber"></param>
        /// <param name="caller"></param>
        /// <returns></returns>
        Task<T> DeleteAsync(T model);

        ///
        bool DeleteMany(Expression<Func<T, bool>> expression);

        /// <summary>
        ///     Delete many gived model
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="lineNumber"></param>
        /// <param name="caller"></param>
        /// <returns></returns>
        Task<bool> DeleteManyAsync(Expression<Func<T, bool>> expression);

        #endregion

        // find model without cache 

        #region Find

        /// <summary>
        ///     Find all Modules
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> FindAll();

        /// <summary>
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> FindAllAsync();

        /// <summary>
        ///     Find section Gived function
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="lineNumber"></param>
        /// <param name="caller"></param>
        /// <returns></returns>
        IEnumerable<T> Find(Expression<Func<T, bool>> selector, int offset, int limit
            );

        /// <summary>
        ///     Find all gived function
        /// </summary>
        /// <param name="keySelector"></param>
        /// <param name="lineNumber"></param>
        /// <param name="caller"></param>
        /// <returns></returns>
        IEnumerable<T> Find(Expression<Func<T, bool>> keySelector);

        //IEnumerable<T> Find(Expression<Func<T, bool>> selector, int offset, int limit, [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string caller = null);
        /// <summary>
        ///     find from database
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="lineNumber"></param>
        /// <param name="caller"></param>
        /// <returns></returns>
        IEnumerable<T> Find(string field, string value);

        /// <summary>
        ///     Find by key "Property name"
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value">value of property</param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="lineNumber"></param>
        /// <param name="caller"></param>
        /// <returns></returns>
        IEnumerable<T> Find(string field, string value, int offset, int limit);

        /// <summary>
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="lineNumber"></param>
        /// <param name="caller"></param>
        /// <returns></returns>
        IEnumerable<T> FindReverse(Expression<Func<T, bool>> selector);
        IEnumerable<T> FindReverse(Expression<Func<T, bool>> selector, int offset, int limit);

        /// <summary>
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        IEnumerable<T> FindReverse(int offset, int limit);

        /// <summary>
        ///     Find Reverse
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> FindReverseAsync(int offset, int limit);

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        IEnumerable<T> FindReverse(string key, string value, int offset, int limit);

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> FindReverseAsync(string key, string value, int offset, int limit);

        #endregion

        #region FindAsync

        /// <summary>
        /// </summary>
        /// <param name="keySelector"></param>
        /// <param name="lineNumber"></param>
        /// <param name="caller"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> keySelector);

        /// <summary>
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="lineNumber"></param>
        /// <param name="caller"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> selector, int offset, int limit
           );

        /// <summary>
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="lineNumber"></param>
        /// <param name="caller"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> FindAsync(string field, string value);

        /// <summary>
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="lineNumber"></param>
        /// <param name="caller"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> FindAsync(string field, string value, int offset, int limit);

        #endregion

        //Get count from database

        #region Count

        /// <summary>
        /// </summary>
        /// <param name="lineNumber"></param>
        /// <param name="caller"></param>
        /// <returns></returns>
        long Count();

        /// <summary>
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="lineNumber"></param>
        /// <param name="caller"></param>
        /// <returns></returns>
        long Count(Expression<Func<T, bool>> expression);

        /// <summary>
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="lineNumber"></param>
        /// <param name="caller"></param>
        /// <returns></returns>
        long Count(string field, string value);

        #endregion

   

        // it is new Functionch

        #region New

        #endregion
    }
}
