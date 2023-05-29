using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ProjectMVCUI.Models.CustomTools
{
    public class ImageUploader
    {
        //Geriye string deger döndüren metodumuzresmin yolunu döndürecek veya resim yükleme le ilgili bir sorun varsa onun koduu döndürecek "C:/ Images....", "1", "2"

        //HttpPostFileBase =>

        public static string UploadImage(string severpath,HttpPostedFileBase file,string name)
        {
            if (file != null)
            {
                Guid uniqueName = Guid.NewGuid();

                string[] fileArray = file.FileName.Split
                    ('.'); //"Matrix.jpg"...burada Split metodu saysende ilgili yapıın uzantısının da içeride buluuduğu bir string dizisi almıs olduk...Split metodu belirttiğiniz char karakterinden metni bölerek size bir array sunar ...
                string extension = fileArray[fileArray.Length - 1].ToLower(); //Dosya uzantısını yakalayarak kücuk harflere cevirdik..

                string fileName = $"{uniqueName}.{name}.{extension}";// Normla şartlarda biz burada Guid kullandığımız icin asla bir dosya ismi aynı olmaycaktır...Lakin siz Guid kullanmazsanız(sadece kullanıcıya yüklemek istedigi dosyanın ismini girdirmek istersiniz)Böyle bir durumda aynı ısımde dosya upload'u mümkün hale gelecektir...Dolayısıyla öyle bir durumda ek olarak bir kontrol yapmamız gerekecektir..Tabi ki böyle bir senaryo olsun veya olmasın önce extension kontrol edilmelidir...Bahsettiğimiz ek kontrol daha sonra yapılmalıdır...



                if (extension =="jpg" || extension =="gif" || extension =="png")
                {
                    //Eger dosya ismi zaten varsa
                    if (File.Exists(HttpContext.Current.Server.MapPath(severpath + fileName)))
                    {
                        return "1"; //Ancak Guid kullandıgımız icin bu acçıdan zaten güvendeyiz(dosya zaten var kodu)
                    }
                    else
                    {
                        string filepath = HttpContext.Current.Server.MapPath(severpath + fileName);
                        file.SaveAs(filepath);
                        return $"{severpath}{fileName}";
                    }
                   }
                else 
                {
                    return "2"; //Secilen dosya bir resim degildir kodu

                }


            }
            else
            {
                return "3"; // Dosya bos kodu
            }
        }
    }
}


