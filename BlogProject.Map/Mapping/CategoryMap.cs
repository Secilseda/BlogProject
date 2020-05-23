using BlogProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Map.Mapping
{
	public class CategoryMap:CoreMap<Category>
	{
		public CategoryMap()
		{
			ToTable("dbo.Categories");
			Property(x => x.Name).IsRequired();

			HasMany(x => x.Posts)
				.WithRequired(x => x.Category)
				.HasForeignKey(x => x.CategoryId)
				.WillCascadeOnDelete(false);
		}
	}
}
