using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_SlipStream.DAL.Interface
{
    public interface IRepository<T> where T:class
    {
        T Get(Guid ID);
        Task<T> GetAsyc(Guid ID);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        void Add(T Item);
        void AddRange(IEnumerable<T> Items);
        void AddUpdateRange(IEnumerable<T> Items);
        void Update(T Item);
        void UpdateRange(IEnumerable<T> Items);
        void Remove(T Item);
        void RemoveRange(IEnumerable<T> Items);
        bool Any(Expression<Func<T, bool>> predicate);
        Task<bool> AnyAsyc(Expression<Func<T, bool>> predicate);
    }
}
