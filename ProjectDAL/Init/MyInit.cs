using Project.COMMON.Tools;
using ProjectDAL.Context;
using ProjectENTİTİES.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDAL.Init
{
    public class MyInit:CreateDatabaseIfNotExists<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            #region Admin

            AppUser au = new AppUser();
            au.UserName = "cgr";
            au.Password = DantexCrypt.Crypt("123");



            #endregion
        }
    }
}
