using Assessment_SlipStream.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_SlipStream.DAL.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public void Add(T Item)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<T> Items)
        {
            throw new NotImplementedException();
        }

        public void AddUpdateRange(IEnumerable<T> Items)
        {
            throw new NotImplementedException();
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsyc(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T Get(Guid ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsyc(Guid ID)
        {
            throw new NotImplementedException();
        }

        public void Remove(T Item)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<T> Items)
        {
            throw new NotImplementedException();
        }

        public void Update(T Item)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<T> Items)
        {
            throw new NotImplementedException();
        }
    }
}
