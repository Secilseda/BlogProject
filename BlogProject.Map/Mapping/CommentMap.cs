using BlogProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Map.Mapping
{
	public class CommentMap:CoreMap<Comment>
	{
		public CommentMap()
		{
            ToTable("dbo.Comments");
            Property(x => x.Content).IsOptional();

            HasRequired(x => x.Post)//HasRequired burada bire çok ilişkiyi temsil eder.Bir postun bir çok commenti olur.
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.PostId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.AppUser)
                .WithMany(x=> x.Comments)
                .HasForeignKey(x => x.AppUserId)
                .WillCascadeOnDelete(false);

        }
	}
}
