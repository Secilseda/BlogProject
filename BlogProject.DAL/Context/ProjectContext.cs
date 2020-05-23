using BlogProject.Entity.Entities;
using BlogProject.Map.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.Context
{
	public class ProjectContext:DbContext//DbContext'ten kalıtım alıyor bu sınıfı bize EntityFreamWork sağlıyor.
	{
		public ProjectContext()
		{
			Database.Connection.ConnectionString = @"Server=FATIH_T430;Database=BloogProject;Integrated Security=True;";
		}
		//DbSet ile Entities Klasöründe Oluşturulan sınıflarımızı Database'e tablo olarak gönderiyoruz.
		public DbSet<Post> Posts { get; set; }
		public DbSet<AppUser> AppUsers { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Like> Likes { get; set; }

		//Bu projede ilk kez fluent-api kullandık. Yaptığımız bu mapping işlemmleri "ProjectContext" kalsörü içerisinde "modelBuilder" nesnesi vasıtasıyla eklenir.
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new AppUserMap());
			modelBuilder.Configurations.Add(new PostMap());
			modelBuilder.Configurations.Add(new CommentMap());
			modelBuilder.Configurations.Add(new LikeMap());
			modelBuilder.Configurations.Add(new CategoryMap());

			modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));

			base.OnModelCreating(modelBuilder);
		}
	}
}
