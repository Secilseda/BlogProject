using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entity.Entities
{
	public class Category:BaseEntity
	{
		//Bir kategorinin bir çok post'u olabilir.
		public string Name { get; set; }
		public virtual ICollection<Post>Posts { get; set; }
	}
}
