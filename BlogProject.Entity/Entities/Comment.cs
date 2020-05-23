using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entity.Entities
{
	public class Comment:BaseEntity
	{
		//commentin proportyleri
		public string Content { get; set; }
		public int PostId { get; set; }//bir yorum satırının kendi id'si hariç  postıdsi olur.Post'a yorum atacağı için
		public virtual Post Post { get; set; }//Post sınıfımızın türünde post proporysi yaratıyoruz bu proporty'i virtual olarak tanımlıyoruz ileride değişiklikler yapacağımız için.

		public int AppUserId { get; set; }//Bir commentin Appuser id'si olur
		public virtual AppUser AppUser { get; set; }
	}
}
