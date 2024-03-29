﻿using Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbContext _entities;
        private DbSet<T> _dbSet;
        public Repository(project2dbEntities entities)//DbContext entities
        {
            _entities = entities;
            _dbSet = _entities.Set<T>();
        }
        public void Add(T dto)
        {
            _dbSet.Add(dto);
        }

        public void Delete(T dto)
        {
            _dbSet.Remove(dto);
        }

        public T Get(int Id)
        {
            return _dbSet.Find(Id);
        }

        public void Update(T dto)
        {
            _dbSet.Attach(dto);
            _entities.Entry(dto).State = EntityState.Modified;
        }
    }
}
