using BlogProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogProject.UI.Areas.Admin.Data.VM
{
	public class CreatePostVM
	{
		public CreatePostVM()
		{
			Categories = new List<Category>();//çekilen catgory controller metot sayesinde getiriliyor..
			AppUsers = new List<AppUser>();
		}
		public List<Category> Categories { get; set; }//Categories adında bir Category oluşturuyoruz bu categoriler birden fazla olacağı için liste tipinde çekiyoruz.
		public List<AppUser> AppUsers { get; set; }
	}
}