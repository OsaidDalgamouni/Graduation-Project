﻿using DonationBank.Repository.IRepository;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using DonationBank.Data;
using Microsoft.EntityFrameworkCore;

namespace DonationBank.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDBContext _db;
        internal DbSet<T> dbset;
        public Repository(AppDBContext db)
        {
            _db = db;
           
            this.dbset = _db.Set<T>();
        }
        public void Add(T item)
        {
            dbset.Add(item);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? Filter=null, string? includeProperties = null)
        {
            IQueryable<T> query = dbset;
            if(Filter!= null) { query = query.Where(Filter); }
          
        if (includeProperties != null)
            {
                
              
                     query = query.Include(includeProperties);
                 
            }
            return query.ToList();
        }




        public void Remove(T item)
        {
            dbset.Remove(item);
        }

        public void RemoveRange(IEnumerable<T> item)
        {
            dbset.RemoveRange(item);
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> Filter, string? includeproperties = null) 
        {
            IQueryable<T> query = dbset;
            query = query.Where(Filter);
            if (includeproperties != null)
            {
                foreach (var property in includeproperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            return query.FirstOrDefault();
        }
    }
}
