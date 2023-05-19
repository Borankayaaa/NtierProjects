using Project.COMMON.Tools;
using ProjectBLL.Repositories.ConcRep;
using ProjectCOMMON.Tools;
using ProjectENTİTİES.Models;
using ProjectMVCUI.Models.PageVMs;
using ProjectVM.PureVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMVCUI.Controllers
{
    public class RegisterController : Controller
    {
        AppUserRepository _apRep;
        ProfileRepository _proRep;

        public RegisterController()
        {
            _apRep = new AppUserRepository();
            _proRep = new ProfileRepository();
        }
        public ActionResult RegisterNow()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterNow(AppUserVM appUser,ProfileVM profile)
        {
            if (_apRep.Any(x=>x.UserName == appUser.UserName)) 
            {
                ViewBag.ZatenVar = "Bu kullanıcı isimi daha önce kullanılmış";
                return View();
            }
            else if (_apRep.Any(x=>x.Email == appUser.Email))
            {
                ViewBag.ZatenVar = "Email zaten kayıtlı";
                return View();
            }

            appUser.Password=DantexCrypt.Crypt(appUser.Password); //sifreyi kriptoladık

            AppUser domainUser = new AppUser
            {
                UserName = appUser.UserName,
                Password = appUser.Password,
                Email = appUser.Email,
            };
            _apRep.Add(domainUser); // siz kullanıcı yanında profili eklemek isterseniz öncelikle repository'nin bu metodunu AppUser içiçn çalıştırmalısınız ... Çünkü AppUser'in ID ilk başta olusmalı... cünkü bizim kurduğumz birebir ilişkide AppUser zorunlu ola alan , Profile ise opsiyonel alndır...Dolayısıyla Profile'ın ID'İdentity değildir...o yüzden Profile eklencekken ID belirlenmek zorundandır(manuel)...Birebir ilişki olduğundan dolayı profile'in ID'si  ile AppUser'ın ID'si tutmak zorundadır... İlk basta AppUser'in ID'si SaveChange ile olusur(Repository sayesinde) ki sonra Profşle'i rahatça ekleyebilelim.

            string gonderilecekMail = "Tebrikler ..Hesabınız olusturulmustur.. Hesabınızı aktive etmek icın http://localhost:52536/Register/Activation/" + domainUser.ActivationCode +"linkine tıklayabilirsiniz";
            MailService.send(appUser.Email, body: gonderilecekMail, subject: "Hesap Aktivasyon!!");


            if(!string.IsNullOrEmpty(profile.FirstName.Trim()) || !string.IsNullOrEmpty(profile.LastName.Trim()))
            {
                AppUserProfile domainProfile = new AppUserProfile
                {
                    ID = domainUser.ID,
                    FirstName = profile.FirstName,
                    LastName = profile.LastName,
                };
            }
            

            


            return View("RegisterOK");
        }

        public ActionResult RegisterOK()
        {
            return View();
        }
        public ActionResult Activation(Guid id)
        {
            AppUser aktifEdilecek = _apRep.FirstOrDefoult(x => x.ActivationCode == id);
            if(aktifEdilecek != null)
            {
                aktifEdilecek.Active= true;
                _apRep.Update(aktifEdilecek);
                TempData["HesapAktifMi"] = "Hesabınız aktif hala getirildi";
                return RedirectToAction("Login","Home");
            }
            //Süpheli bir aktivite
            TempData["HesapAktifMi"] = "Hesabınız bulunamadı";
            return RedirectToAction("Login", "Home");
        }
    }
}