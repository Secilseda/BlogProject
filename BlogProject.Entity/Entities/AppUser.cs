using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entity.Entities
{
	//Role enum; App User sınıfımızda ki rollerdir yani login olacağımızda hangi rolde olduğumuzu seçmemiz için oluşturduk.
	public enum Role
	{
		Admin=1,
		Author=2,
		Member=3
	}
	public class AppUser:BaseEntity
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public Role Role { get; set; }

		//ApppUser'ın post'u olur, comment'i olur ve like'ı olur.
		public virtual ICollection<Post> Posts { get; set; }//ICollection tipinde Post sınıfından postları çekiyoruz.
		public virtual ICollection<Comment> Comments { get; set; }//Liste gibi çoklu gelicek
		public virtual ICollection<Like> Likes { get; set; }//Sebebi bir Kullanıcının bir çok postu olabilir, commenti ve like'ı olabilir.Bu sebepten dolayı çoklu olarak alıyoruz.

		public string ImagePath { get; set; }//Resim yolunu vericek
		public string UserImage { get; set; }//Fotoğrafını vericek
		public string XSmallUserImage { get; set; }//Fotoğrafı küçük vericek
		public string CruptedUserImage { get; set; }//Fotoğrafı Kırpıcak

	}
}
