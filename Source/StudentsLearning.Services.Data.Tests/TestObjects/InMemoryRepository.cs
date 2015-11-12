#region

using System;
using System.Collections.Generic;
using System.Linq;
using StudentsLearning.Data.Repositories;

#endregion

namespace StudentsLearning.Services.Data.Tests.TestObjects
{
    public class InMemoryRepository<T> : IRepository<T>
        where T : class
    {
        private readonly IList<T> data;

        public InMemoryRepository()
        {
            data = new List<T>();
            AttachedEntities = new List<T>();
            DetachedEntities = new List<T>();
        }

        public IList<T> AttachedEntities { get; }

        public IList<T> DetachedEntities { get; }

        public IList<T> UpdatedEntities { get; private set; }

        public bool IsDisposed { get; private set; }

        public int NumberOfSaves { get; private set; }

        public void Add(T entity)
        {
            data.Add(entity);
        }

        public IQueryable<T> All()
        {
            return data.AsQueryable();
        }

        public T Attach(T entity)
        {
            AttachedEntities.Add(entity);
            return entity;
        }

        public void Delete(object id)
        {
            if (data.Count == 0)
            {
                throw new InvalidOperationException("Nothing to delete");
            }

            data.Remove(data[0]);
        }

        public void Delete(T entity)
        {
            if (!data.Contains(entity))
            {
                throw new InvalidOperationException("Entity not found");
            }

            data.Remove(entity);
        }

        public void Detach(T entity)
        {
            DetachedEntities.Add(entity);
        }

        public void Dispose()
        {
            IsDisposed = true;
        }

        public T GetById(object id)
        {
            if (data.Count == 0)
            {
                throw new InvalidOperationException("No objects in database");
            }

            return data[0];
        }

        public int SaveChanges()
        {
            NumberOfSaves++;
            return 1;
        }

        public void Update(T entity)
        {
            UpdatedEntities.Add(entity);
        }
    }
}