using BlogProject.DAL.Context;
using BlogProject.Entity.Entities;
using BlogProject.Service.BaseRepository.Abstraction;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Service.BaseRepository.ConCreate
{
	//ICoreRepository de oluşturduğumuz metotları burada ayağa kaldıracağız yani yapılacak işlemlerini belirleyeceğiz.
	public class CoreRepository<T> : ICoreRepository<T> where T : BaseEntity
	{
		private static ProjectContext _context;//veritabanı bağlantımızdan _context nesnesi yaratıyoruz.
		public CoreRepository()
		{
			_context = new ProjectContext();
		}
		public void Add(T item)//tek tek eklemek için
		{
			_context.Set<T>().Add(item);
			Save();
		}

		public void Add(List<T> items)//birden fazla eleman eklemek için list tipinde bu seferde tanımlıyoruz.
		{
			_context.Set<T>().AddRange(items);
			Save();
			//<T> yerine bizim nesnelerimiz gelecek. Her bir nesne için bir metot tanımlamak yerine, tek bir metot yazıp bütün nesnelerin faydalanmasını sağlayacağız.bu da az kod yazıp çok iş yapmamızı sağlıyor. 
		}

		public bool Any(Expression<Func<T, bool>> exp) => _context.Set<T>().Any(exp);

		public List<T> GetActive()
		{
			return _context.Set<T>().Where(x => x.Status != Status.Passive).ToList();//bu metotta statusu passsive olanlar gelecek.<T> içerisine yazacağımız bir nesne gelecek.
		}

		public List<T> GetAll()
		{
			return _context.Set<T>().ToList();//listeleme işlemi.
		}

		public T GetByDefault(Expression<Func<T, bool>> exp)
		{
			return _context.Set<T>().Where(exp).FirstOrDefault();//exp biz ne yazarsak o gelecek.
		}

		public T GetById(int id)
		{
			return _context.Set<T>().Find(id);
		}

		public List<T> GetDefault(Expression<Func<T, bool>> exp)//Liste tipinde birden fazla yani getirilebilecek
		{
			return _context.Set<T>().Where(exp).ToList();
		}

		public void Remove(T item)
		{
			throw new NotImplementedException();
		}

		public void Remove(int id)
		{
			T item = GetById(id);//yukarıda yazmış olduğumuzu metotu bu metot içeirisnde çağıabiliyoruz.
			item.Status = Status.Passive;//statusu passive olanları
			item.DeleteDate = DateTime.Now;//getiriyoruz.
			Save();
		}

		public void RemoveAll(Expression<Func<T, bool>> exp)
		{
			throw new NotImplementedException();
		}

		public int Save()
		{
			return _context.SaveChanges();//database kaydet metodu.
		}

		public void Update(T item)
		{
			T update = GetById(item.Id);//id'den yakalayıp update işlemini yapıyoruz.
			DbEntityEntry dbEntityEntry = _context.Entry(update);
			dbEntityEntry.CurrentValues.SetValues(item);
			Save();
		}
	}
}
