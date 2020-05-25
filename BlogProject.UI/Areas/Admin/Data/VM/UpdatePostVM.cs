using BlogProject.Entity.Entities;
using BlogProject.UI.Areas.Admin.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogProject.UI.Areas.Admin.Data.VM
{
	public class UpdatePostVM
	{
		public UpdatePostVM()
		{
			Categories = new List<Category>();
			AppUsers = new List<AppUser>();
			PostDTO = new PostDTO();
		}
		public List<Category> Categories { get; set; }
		public List<AppUser> AppUsers { get; set; }
		public PostDTO PostDTO { get; set; }//Diğerlerinden farklı olarak postu PosDTO dan  propertylerini getiriyoruz
	}
}