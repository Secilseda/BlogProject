using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using BlogProject.Entity.Entities;

namespace BlogProject.Service.BaseRepository.Abstraction
{
	public interface ICoreRepository<T> where T: BaseEntity
	{
        //Bı sınıfta metotlaar tanımlayacağız bu metotlar ileride yapacağımız işlemleri hızlandıracaktır.
        void Add(T item);
        void Add(List<T> items);
        void Update(T item);
        void Remove(T item);
        void Remove(int id);
        void RemoveAll(Expression<Func<T, bool>> exp);//Expression exp sayesinde istediğimiz tipte olan nesneleri getirecektir 
        T GetById(int id);
        T GetByDefault(Expression<Func<T, bool>> exp);
        List<T> GetDefault(Expression<Func<T, bool>> exp);
        List<T> GetActive();
        List<T> GetAll();
        bool Any(Expression<Func<T, bool>> exp);
        int Save();
    }
}
