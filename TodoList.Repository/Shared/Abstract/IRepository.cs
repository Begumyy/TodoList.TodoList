using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Repository.Shared.Abstract
{
    public interface IRepository<T>where T : BaseModel
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter);
        T GetById(int id);
        void Add(T entity);//T dediğimiz nesnenin kendisi.
        void Update(T entity);
        void Delete(T entity);
        void DeleteById(int id);

        T GetFirstOrDefault(Expression<Func<T, bool>> filter);//bu method öyle bir link expression alacak ki içine yazacağım expression'ın sonucu true yada false veren bir ifade olmalı. bu ifadeden kurtulan birşey varsa veya bu ifseye uyan birşey varsa onu  da T olarak geri gönder.

       
    }
}
