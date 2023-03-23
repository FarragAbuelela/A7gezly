using _7agz.Core.Consts;
using _7agz.Core.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _7agz.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll() => _context.Set<T>().ToList();

        public T GetById(int id) => _context.Set<T>().Find(id)!;

        public T Find(Expression<Func<T, bool>> criteria) => _context.Set<T>().FirstOrDefault(criteria)!;

        public T Find(Expression<Func<T, bool>> criteria, string[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return query.SingleOrDefault(criteria)!;
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria) => _context.Set<T>().Where(criteria).ToList();

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes)
        {
            IQueryable<T> query = _context.Set<T>().Where(criteria);
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return query.ToList();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes, Expression<Func<T, object>> orderBy, string orderByDirection = OrderBy.Ascending)
        {
            IQueryable<T> query = _context.Set<T>().Where(criteria);
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            if(orderByDirection != null)
            {
                if(orderByDirection == OrderBy.Ascending)
                {
                    query = query.OrderBy(orderBy);
                }
                else
                {
                    query = query.OrderByDescending(orderBy);
                }
            }
            return query.ToList();
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
            return entities;
        }

        public T GetHourDetails(Expression<Func<T, bool>> criteria)
        {
            throw new NotImplementedException();
        }

        public T Update(int id, JsonPatchDocument entity)
        {
            var item = _context.Set<T>().Find(id);
            if (item != null)
            {
                entity.ApplyTo(item);
            }
            _context.SaveChanges();
            return item;
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
        public T UpdateByPut(int id, T dto)
        {
            _context.Update(dto);
            _context.SaveChanges();
            return dto;
        }
    }
}
