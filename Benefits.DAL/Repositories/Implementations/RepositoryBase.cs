using Benefits.DAL.Context;
using Benefits.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Benefits.DAL.Entities;
using System.Data.Entity.Migrations;

namespace Benefits.DAL.Repositories.Implementations
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        protected WebApiContext RepositoryContext { get; set; }
        private int LastId { get; set; }
        T LastEntity { get; set; }
        public RepositoryBase(WebApiContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public IEnumerable<T> GetAll()
        {
            return this.RepositoryContext.Set<T>().ToList();
        }

        public IEnumerable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression).ToList();
        }

        public T GetOneByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().FirstOrDefault(expression);
        }

        public T GetById(int id)
        {
            return this.RepositoryContext.Set<T>().Find(id);
        }

        public void Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
            LastEntity = entity;
        }

        public void Update(T entity)
        {
            if (entity == null)
                return;
            this.RepositoryContext.Set<T>().AddOrUpdate(entity);
        }

        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }

        public void Save()
        {
            RepositoryContext.SaveChanges();
        }
        public int GetLastEntityId()
        {
            return LastEntity?.Id ?? 0;
        }
    }
}
