using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entity.Entities
{
	public class Like:BaseEntity
	{
		//Like'ın postu olur ve AppUser'ı olur.
		public int PostId { get; set; }
		public virtual Post Post { get; set; }

		public int AppUserId { get; set; }
		public virtual AppUser AppUser { get; set; }
	}
}

