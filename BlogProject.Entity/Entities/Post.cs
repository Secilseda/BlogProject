using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entity.Entities
{
	
	public class Post:BaseEntity
	{
      
        public string Header { get; set; }//Bir Postun Başlığı olur.
        public string Content { get; set; }//İçeriği olur.
        public string ImagePath { get; set; }//resim yolu olur.
        public DateTime? PublishDate { get; set; }//yayınlama tarihi olur.


        public int CategoryId { get; set; }//categorysi olur
        public virtual Category Category { get; set; }

        public int AppUserId { get; set; }//Appuser'ı olur.
        public virtual AppUser AppUser { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
