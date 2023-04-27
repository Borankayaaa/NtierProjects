using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectENTİTİES.Models
{
    public class Category : BaseEntity
    {
        public Category() 
        {
            Products = new List<Product>(); //bu ifade ,MyInit class'ında EF tetiklenmeden , yani işlemlerimizin saf bir şekilde RAM'de başladığınd bu category class'ının Products isimli Property'si null gelmesin diye yapılmıştır...Cünkü bir Category İnstance'i alındığında onun Products özelliğinin İnstance'lanmasını hep isteriz..Aksi halde RAM'de yaptığımız işlemlerde ilgili Category İnstance'inin Products özelliğini erişip ordan bir işlem yapmaya calısırsak NullReferanceExpection hatası alırız...
        }
        public string CategoryName { get; set; }
        public string Description { get; set; }

      //Relational Properties
      public virtual List<Product> Products { get; set; }
    }
}
