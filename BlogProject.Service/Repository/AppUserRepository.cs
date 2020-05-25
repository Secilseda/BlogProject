using BlogProject.Entity.Entities;
using BlogProject.Service.BaseRepository.ConCreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Service.Repository
{
	public class AppUserRepository: CoreRepository<AppUser>
	{
        public AppUser FinByUserName(string userName)
        {
            return GetByDefault(x => x.UserName == userName);
        }

        //login olunca kullanılacak metottur.
        public bool CheckCredentials(string userName, string password)//gelen kullanıcın username ve passwordu kullanıp login yapacak sorguluyor.//kullanıcıya bakıyor var mı yok mu böyle bi user name ve password
        {
            return Any(x => x.UserName == userName && x.Password == password);
        }
    }
}
