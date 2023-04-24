using ProjectENTİTİES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMAP.Options
{
    public class AppUserMap: BaseMap<AppUser>
    {
        public AppUserMap() 
        {
            HasOptional(x => x.Profile).WithRequired(x => x.AppUser);
        }
    }
}
