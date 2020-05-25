using BlogProject.Entity.Entities;
using BlogProject.Service.Repository;
using BlogProject.UI.Areas.Admin.Data.DTO;
using BlogProject.Utility.ImagePocessesing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.UI.Areas.Admin.Controllers
{
    public class AppUserController : Controller
    {
        AppUserRepository _appUserRepository;//Repository metotlarımızı burada hayata geçireceğimiz için instanse alıyoruz.
        public AppUserController()
        {
            _appUserRepository = new AppUserRepository();
        }
        public ActionResult Create()//get edicek
        {
            return View();
        }
        [HttpPost]//Appuser'ı post edicek yani gerekli işlemleri yapıcak
        public ActionResult Create(AppUser data, HttpPostedFileBase Image)//Appuserın foroğrafını ekleme işlemi
        {
            List<string> UploadImagePaths = new List<string>();//List türünde string veri tipi alan bir değişken tanımlıyoruz.
            UploadImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);
            data.UserImage = UploadImagePaths[0];
            if (data.UserImage == "0" || data.UserImage == "1" | data.UserImage == "2")
            {
                data.UserImage = ImageUploader.DefaultProfileImagePath;
                data.XSmallUserImage = ImageUploader.DefaultXSmallProfileImage;
                data.CruptedUserImage = ImageUploader.DefaulCruptedProfileImage;
            }
            else
            {
                data.XSmallUserImage = UploadImagePaths[1];
                data.CruptedUserImage = UploadImagePaths[2];
            }
            _appUserRepository.Add(data);
            return View();
        }
        public ActionResult Update(int id)//Update işlemini getirecek id'den yakalayacak.
        {
            AppUser appUser = _appUserRepository.GetById(id);//Bu satırda anlatılmak istenilen AppUser sınıfımızdan appuser adında instance alıyoruz ve  _appUserRepository'deki get by id metotunu çağırarak verdiğimiz id sayesinde yakalıyıp appUser nesnesine atıyoruz.
            AppUserDTO model = new AppUserDTO();
            model.Id = appUser.Id;//Nesne olarak oluşan id'ye model olarak gönderdiğimiz id eşit mi diye bakıyor.
            model.UserName = appUser.UserName;
            model.Password = appUser.Password;
            model.Role = appUser.Role;
            model.UserImage = appUser.UserImage;
            model.XSmallUserImage = appUser.XSmallUserImage;
            model.CruptedUserImage = appUser.CruptedUserImage;
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(AppUserDTO model, HttpPostedFileBase Image)
        {
            List<string> UploadedImagePaths = new List<string>();

            UploadedImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);

            model.UserImage = UploadedImagePaths[0];

            AppUser appUser = _appUserRepository.GetById(model.Id);

            if (model.UserImage == "0" || model.UserImage == "1" || model.UserImage == "2")
            {
                if (appUser.UserImage == null || appUser.UserImage == ImageUploader.DefaultProfileImagePath)
                {
                    appUser.UserImage = ImageUploader.DefaultProfileImagePath;
                    appUser.XSmallUserImage = ImageUploader.DefaultXSmallProfileImage;
                    appUser.CruptedUserImage = ImageUploader.DefaulCruptedProfileImage;
                }
                else
                {
                    appUser.UserImage = appUser.UserImage;
                    appUser.XSmallUserImage = appUser.XSmallUserImage;
                    appUser.CruptedUserImage = appUser.CruptedUserImage;
                }
            }
            else
            {
                appUser.UserImage = UploadedImagePaths[0];
                appUser.XSmallUserImage = UploadedImagePaths[1];
                appUser.CruptedUserImage = UploadedImagePaths[2];
            }

            appUser.UserName = model.UserName;
            appUser.Password = model.Password;
            appUser.Role = model.Role;
            appUser.ImagePath = model.ImagePath;
            _appUserRepository.Update(appUser);
            return Redirect("/Admin/AppUser/List");
        }
        public ActionResult List()
        {
            List<AppUser> model = _appUserRepository.GetActive();
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            _appUserRepository.Remove(id);
            return Redirect("Admin/AppUser/List");
        }
    }
}