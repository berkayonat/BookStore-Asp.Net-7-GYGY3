﻿using BookStore.Application.Interfaces;
using BookStore.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Persistence.Repositories
{
    public class EFGenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> dbSet;

        public EFGenericRepository(AppDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var exist = await dbSet.FindAsync(id);
            dbSet.Remove(exist);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<IList<T>> GetAllWithPredicate(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}