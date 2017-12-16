using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VideoStore.Models.Repositories
{
    public class Repository<T> where T:class
    {
        private VideoStoreDbContext context = null;

        protected DbSet<T> DbSet { get; set; }

        public Repository()
        {
            context = new VideoStoreDbContext();
            DbSet = context.Set<T>();
        }

        public Repository(VideoStoreDbContext context)
        {
            this.context = context;
        }

        public List<T> GetAll()
        {
            return DbSet.ToList();
        }

        public T Get(int id)
        {
            return DbSet.Find(id);
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);

        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public void Edit(T entity)
        {
            context.Entry<T>(entity).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }




    }
}