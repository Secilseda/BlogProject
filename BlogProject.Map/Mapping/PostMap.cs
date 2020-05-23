using BlogProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Map.Mapping
{
	public class PostMap:CoreMap<Post>
	{
		public PostMap()
		{
			ToTable("dbo.Posts");

			Property(x => x.Content).IsRequired();
			Property(x => x.Header).IsRequired();

			HasRequired(x => x.Category)//bir kategorinin bir çok postu olur.
				.WithMany(x => x.Posts)
				.HasForeignKey(x => x.CategoryId)
				.WillCascadeOnDelete(false);

			HasRequired(x => x.AppUser)
				.WithMany(x => x.Posts)
				.HasForeignKey(x => x.AppUserId)
				.WillCascadeOnDelete(false);

			HasMany(x => x.Comments)//çoka(Bir çok commentin, bir tane postu olur
                .WithRequired(x => x.Post)//az ilişki 
			   .HasForeignKey(x => x.PostId)
			   .WillCascadeOnDelete(false);

			HasMany(x => x.Likes)//çoka az ilişki
				.WithRequired(x => x.Post)//bir posta bir çok like gelebilir.
				.HasForeignKey(x => x.PostId)
				.WillCascadeOnDelete(false);
		}
	}
}
