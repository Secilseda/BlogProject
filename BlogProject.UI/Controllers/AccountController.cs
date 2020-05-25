using BlogProject.Entity.Entities;
using BlogProject.Service.Repository;
using BlogProject.UI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogProject.UI.Controllers
{
    public class AccountController : Controller
    {
        AppUserRepository _appUserRepository;

        public AccountController()
        {
            _appUserRepository = new AppUserRepository();
        }
        // GET: Account
        public ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)//eğer kullancı zaten loginse
            {
                AppUser user = _appUserRepository.FinByUserName(User.Identity.Name);//(finbyname ile karşılaştırdık)
                //kimliğini yakalayıp usera attık
                if (user.Status != Status.Passive)//statusu passive olmayanlar
                {
                    if (user.Role == Role.Admin)//rolu admin olanlar
                    {
                        string cookie = user.UserName;//cookie bbizim burada proportylerimizi tutuyor.biyere yorum yazacağımızda fotoğrafımızı adımızı getiriyor.
                        FormsAuthentication.SetAuthCookie(cookie, true);//user name'i cookie çökeltmiş olduk.sayfalar arasında kullanıcın bilgilerini taşımaya yardımcı olurlar.
                        Session["UserName"] = user.UserName;
                        Session["ImagePath"] = user.UserImage;
                        return Redirect("/Admin/Home/Index");

                    }
                    else if (user.Role == Role.Author)//rolu authorsa
                    {
                        string cookie = user.UserName;//özelliklerini getir
                        FormsAuthentication.SetAuthCookie(cookie, true);
                        Session["UserName"] = user.UserName;
                        Session["ImagePath"] = user.UserImage;
                        return Redirect("/Admin/Home/Index");
                    }
                    else
                    {
                        string cookie = user.UserName;
                        Session["UserName"] = user.UserName;
                        Session["ImagePath"] = user.UserImage;
                        return Redirect("/Admin/Home/Index");
                    }
                }
                else
                {
                    ViewData["error"] = "Usename or password are wrong..!";//hiçir if yapısına uymuyorsa hata mesajı çıkar.
                    return View();//register sayfasına redirect et//ve ana sayfaya getir.
                }
            }
            return View();

        }
        [HttpPost, ValidateAntiForgeryToken]//kullanıcıya gittiğini anlıyor tokken sayesinde güvenli bir şekiilde login oluyor. Uçtan uca şifreleme oluyor.
        public ActionResult Login(LoginDTO credential)
        {
            if (ModelState.IsValid)//model uygun mu değil mi bakıyor.
            {
                if (_appUserRepository.CheckCredentials(credential.UserName, credential.Password))//loginDTO 'daki username ile passwordu getir
                {
                    AppUser user = _appUserRepository.FinByUserName(credential.UserName);
                    if (user.Status != Status.Passive)//pasif haricindekiler kabulumdur.
                    {
                        if (user.Role == Role.Admin)
                        {
                            string cookie = user.UserName;//cookie bbizim burada proportylerimizi tutuyor.biyere yorum yazacağımızda fotoğrafımızı adımı getiriyor.
                            FormsAuthentication.SetAuthCookie(cookie, true);//user name'i cookie çökeltmiş olduk.sayfalar arasında kullanıcın bilgilerini taşıyamaya yardımcı olurlar.
                            Session["UserName"] = user.UserName;
                            Session["ImagePath"] = user.UserImage;
                            return Redirect("/Admin/Home/Index");

                        }
                        else if (user.Role == Role.Author)
                        {
                            string cookie = user.UserName;
                            FormsAuthentication.SetAuthCookie(cookie, true);
                            Session["UserName"] = user.UserName;
                            Session["ImagePath"] = user.UserImage;
                            return Redirect("/Admin/Home/Index");
                        }
                        else//member için bir else if koymak yerine son kalan member olduğu için member için yapacak işlemlerini
                        {
                            string cookie = user.UserName;
                            Session["UserName"] = user.UserName;
                            Session["ImagePath"] = user.UserImage;
                            return Redirect("/Admin/Home/Index");
                        }
                    }
                    else//passive ise hata mesajı çıkaracak
                    {
                        ViewData["error"] = "Username or password are wrong..!";
                        return View();
                    }
                }
                else//password ile username' hatalıysa çıkacak olan hata mesajı.
                {
                    ViewData["error"] = "Username or password are wrong..!";
                    return View();
                }
            }
            else//gönderilen model hatalıysa çıkacak olan hata mesajı
            {
                TempData["class"] = "custom-hide";
                return View();
            }
        }

        //[Authorize]
        public ActionResult LogOut()//login olmuş kullanıcı için.
        {
            FormsAuthentication.SignOut();//DIŞARI ATIYOR.
            return Redirect("/Account/Login");
        }

    }
}