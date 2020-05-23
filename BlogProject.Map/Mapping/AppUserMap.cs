using BlogProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Map.Mapping
{
	public class AppUserMap:CoreMap<AppUser>
	{
		public AppUserMap()
		{
			ToTable("dbo.AppUsers");//Veritabanında oluşan tablo ismi.
			Property(x => x.UserName).HasMaxLength(50).IsRequired();//Veritabanında olucak özellikleri örn: maxsımum UserName'i 50 karakter olucak
			Property(x => x.Password).HasMaxLength(50).IsRequired();
			Property(x => x.Role).IsRequired();

			HasMany(x => x.Posts)//post'ların 
				.WithRequired(x => x.AppUser)//appuserı olur
				.HasForeignKey(x => x.AppUserId)//ikinci yabancı anahtar olarak appuser ıd si olur.
				.WillCascadeOnDelete(false);

			HasMany(x => x.Comments)
				.WithRequired(x => x.AppUser)
				.HasForeignKey(x => x.AppUserId)
				.WillCascadeOnDelete(false);
			HasMany(x => x.Likes)
				.WithRequired(x => x.AppUser)
				.HasForeignKey(x => x.AppUserId)
				.WillCascadeOnDelete(false);
		}
	}
}
