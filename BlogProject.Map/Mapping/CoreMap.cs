using BlogProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Map.Mapping
{
	//Base entitiy gibi CoreMap te diğer mapping olacak sınıflarımıza kalıtım verecektir. 
	//Bu mapping işlemlerinde EntityTypeConfiguration Fluent API bir ilişki yapılandırırken, EntityTypeConfiguration örneğiyle başlar ve ardından HasRequired, HasOptional veya HasMany yöntemini kullanarak bu varlığın katıldığı ilişki türünü belirtebilirsiniz. 
	//Bu yöntemlerin, bağımsız değişken kullanmayan ve tek yönlü gezintilerle kardinalite belirtmek için kullanılabilecek aşırı yüklemeleri vardır.
	public class CoreMap<T> : EntityTypeConfiguration<T> where T : BaseEntity
	{
		public CoreMap()
		{
			Property(x => x.Id).HasColumnName("Id").HasDatabaseGeneratedOption
				(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);//Code First yaklaşımı ile modellerimizde ki ilişkilerimizi ayarlama yöntemi sağlar. Burada proporty'si Id olan proportyleri database'de birer birer artmasının koşulunu sağlıyoruz.
			Property(x => x.Status).HasColumnName("Status").IsRequired();//Proporty'si Status olan nesnenin veritabanı karşılı Status olanlar demek.
			Property(x => x.CreateDate).HasColumnName("CreateDate").IsRequired();
			Property(x => x.UpdateDate).HasColumnName("UpdateDate").IsOptional();
			Property(x => x.DeleteDate).HasColumnName("DeleteDate").IsOptional();
		}
	}
}
