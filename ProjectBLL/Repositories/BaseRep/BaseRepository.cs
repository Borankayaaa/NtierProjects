using ProjectBLL.DesignPatterns.SingletonPattern;
using ProjectBLL.Repositories.IntRep;
using ProjectDAL.Context;
using ProjectENTİTİES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBLL.Repositories.BaseRep
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        MyContext _db;

        public BaseRepository()
        {
            _db = DBTool.DBInstance;
        }

        void save()
        {
            _db.SaveChanges();
        }

        public void Add(T item)
        {
            _db.Set<T>().Add(item);
            save();
        }

        public void AddRange(List<T> list)
        {
            _db.Set<T>().AddRange(list);
            save();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Any(exp);
        }

        public void Delete(T item)
        {
            item.Status = ProjectENTİTİES.Enums.DataStatus.Deleted;
            item.DeletedDate = DateTime.Now;
            save();
        }

        public void DeleteRange(List<T> list)
        {
            foreach (T item in list) Delete(item);
        }

        public void Destroy(T item)
        {
            _db.Set<T>().Remove(item);
            save();
        }

        public void DestroyRange(List<T> list)
        {
            _db.Set<T>().RemoveRange(list);
            save();
        }

        public T Find(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public T FirstOrDefoult(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().FirstOrDefault(exp);
        }

        public List<T> GetActives()
        {
            return Where(x => x.Status != ProjectENTİTİES.Enums.DataStatus.Deleted);
        }

        public List<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public List<T> GetFirstDatas(int number)
        {
            return _db.Set<T>().OrderBy(x => x.CreatedDate).Take(number).ToList();
        }

        public List<T> GetLastDatas(int number)
        {
            return _db.Set<T>().OrderByDescending(x => x.CreatedDate).Take(number).ToList();
        }

        public List<T> GetPassives()
        {
            return Where(x => x.Status == ProjectENTİTİES.Enums.DataStatus.Deleted);
        }

        public List<T> GetModifieds()
        {
            return Where(x => x.Status == ProjectENTİTİES.Enums.DataStatus.Updated);
        }

        public object Select(Expression<Func<T, object>> exp)
        {
            return _db.Set<T>().Select(exp).ToList();
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            return _db.Set<T>().Select(exp);
        }

        public void Update(T item)
        {
            item.Status = ProjectENTİTİES.Enums.DataStatus.Updated;
            item.ModifiedDate = DateTime.Now;
            T toBeUpdated = Find(item.ID);
            _db.Entry(toBeUpdated).CurrentValues.SetValues(item);
            save();
        }

        public void UpdateRange(List<T> list)
        {
            foreach (T item in list) Update(item);
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Where(exp).ToList();
        }
    }
}

