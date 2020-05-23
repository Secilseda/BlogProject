using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entity.Entities
{
	//Diğer Sınıflara kalıtım verecek olan ana sınıftır.Bu sınıfta diğer sınıflar arasında ortak olacak özellikler(proporty)oluşturulur.
	//BaseEntity Sınıfımızda creaud(ekle,sil,güncelle)Proportleri yaratacağımız için uygun operasyona göre statuslerimizi seçeceğiz.
	public enum Status 
	{
		Active=1,
		Modified=2,
		Passive=3
	}
	public class BaseEntity
	{
		//Her sınıfın bir id'si olur.Ortak bir özellik olduğu için BaseEntity'den kalıtım alıcaklar.
		public int Id { get; set; }
		private DateTime _createDate = DateTime.Now;//Encapsulation yani sarmalama herkes tarafından erişilemez.Bu yüzden private olarak tanımlandı
		public DateTime CreateDate { get { return _createDate; } set { _createDate = value; } }//Oluşturma tarihini encapsulation olarak tanımlayıp return ve value yardımlarıyla proportlerine eriştik.
		public DateTime? UpdateDate { get; set; }//Proporty'i türünün önündeki soru işareti Database'de boş geçilir demektir.
		public DateTime? DeleteDate { get; set; }

		//CreateDate 'te yaptığımız gibi statusleride encapsule ediceğiz.
		private Status _status = Status.Active;
		public Status Status { get { return _status; } set {_status=value; } }
	}
}
