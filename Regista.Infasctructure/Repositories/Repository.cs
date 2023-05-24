using Microsoft.EntityFrameworkCore;
using Regista.Application.Repositories;
using Regista.Domain.Entities;
using Regista.Domain.Enums;
using Regista.Persistance.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Regista.Infasctructure.Repositories
{
    public class Repository : IRepository
    {
        public readonly RegistaContext context;

        public Repository(RegistaContext _context)
        {
            context = _context;
        }
        private DbSet<T> GetTable<T>() where T : BaseEntitiy
        {
            return context.Set<T>();
        }
        public async Task<T> Find<T>(Expression<Func<T, bool>> where) where T : BaseEntitiy
        {
            try
            {
                return await GetTable<T>().FirstOrDefaultAsync(where);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task UpdateRange<T>(ICollection<T> _objectList) where T : BaseEntitiy
        {
            try
            {
                foreach (var item in _objectList)
                {
                   
                    item.LastModifedOn = DateTime.Now;
                }
                GetTable<T>().UpdateRange(_objectList);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public async void DeleteRange<T>(ICollection<T> _objectList) where T : BaseEntitiy
        {
            try
            {
                foreach (var item in _objectList)
                {
                    item.ObjectStatus = ObjectStatus.Deleted;
                    item.Status = status.Passive;
                }
                await UpdateRange(_objectList);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public IQueryable<T> GetNonDeletedAndActive<T>(Expression<Func<T, bool>> expression) where T : BaseEntitiy
        {
            try
            {
                return GetQueryable<T>(t => t.ObjectStatus == ObjectStatus.NonDeleted && t.Status == status.Active)
                    .Where(expression);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<T> Add<T>(T _object) where T : BaseEntitiy
        {
            await GetTable<T>().AddAsync(_object);
            return _object;
        }

        public async Task<T> Delete<T>(int id) where T : BaseEntitiy
        {
            var obj = await Find<T>(t => t.id == id);
            await Delete<T>(obj);
            return obj;
        }
        public async Task<T> Delete<T>(T model) where T : BaseEntitiy
        {
            try
            {
                model.ObjectStatus = ObjectStatus.Deleted;
                model.Status = status.Passive;
                Update<T>(model);
                return model;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
      
        public IQueryable<T> GetQueryable<T>(Expression<Func<T, bool>> where) where T : BaseEntitiy
        {
            return GetTable<T>().Where(where);
        }

        public T Update<T>(T _object) where T : BaseEntitiy
        {
            _object.LastModifedOn = DateTime.Now;
            GetTable<T>().Update(_object);
            return _object;
        }

        public async Task<T> GetById<T>(int id) where T : BaseEntitiy
        {
            return await Find<T>(t => t.id == id);
        }

        public IQueryable<T> GetList<T>(Expression<Func<T, bool>> where) where T : BaseEntitiy
        {
            return GetTable<T>().Where(where);
        }

        public Task<T> GetById<T>(T _object) where T : BaseEntitiy
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetList<T>(T _object) where T : BaseEntitiy
        {
            throw new NotImplementedException();
        }

       
    }
}
