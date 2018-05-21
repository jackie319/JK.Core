using JK.Core.Core;
using JK.Core.Core.Data;
using JK.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace JK.CommonApi.Services.ServicesImpl
{
    public class MyEfResporsitory<T> : IRepository<T> where T : class
    {
        #region 需要修改的地方
        private JKDataContext _context;
        private readonly DbSet<T> _dbSet;
        public MyEfResporsitory(JKDataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }

        public IQueryable<T> Table
        {
            get { return _dbSet; }
        }
        #endregion
        public IQueryable<T> TableNoTracking
        {
            get { return Table.AsNoTracking(); }
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public T GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> exp, IList<OrderExpressionStruct> structList)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> WherePage(Expression<Func<T, bool>> exp, QueryBase query, out int total)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> WherePage(Expression<Func<T, bool>> exp, IList<OrderExpressionStruct> structList, QueryBase query, out int total)
        {
            throw new NotImplementedException();
        }
    }
}
