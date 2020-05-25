using BlogProject.Entity.Entities;
using BlogProject.Service.Repository;
using BlogProject.UI.Areas.Admin.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.UI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository _categoryRepository;
        public CategoryController()
        {
            _categoryRepository = new CategoryRepository();
        }
        // GET: Admin/Category
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category data)//Category dto yerine direk Category'nin kendiisini alıyoruz.
        {
            _categoryRepository.Add(data);//Repositoryde yazılmış olan add metodu ile datayı ekliyoruz.
            return Redirect("/Admin/Category/List");//geri dönüş olarak listi getiriyoruz.
        }
        public ActionResult List()
        {
            List<Category> model = _categoryRepository.GetActive();
            return View(model);
        }

        public ActionResult Update(int id)
        {
            Category category = _categoryRepository.GetById(id);
            CategoryDTO model = new CategoryDTO();
            model.Id = category.Id;
            model.Name = category.Name;
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(CategoryDTO model)
        {
            Category category = _categoryRepository.GetById(model.Id);
            category.Name = model.Name;
            _categoryRepository.Update(category);
            return Redirect("/Admin/Category/List");
        }

        public ActionResult Delete(int id)//int id olarak tanımlanan değişken sayesinde id'den yakalayıp repository'de olan remove metodu ile silme işlemini yapıyoruz.
        {
            _categoryRepository.Remove(id);
            return Redirect("/Admin/Category/List");
        }
    }
}