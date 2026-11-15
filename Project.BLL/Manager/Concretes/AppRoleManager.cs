using Project.BLL.Manager.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Manager.Concretes
{
    public class AppRoleManager : BaseManager<AppRole>,IAppRoleManager
    {

        IAppRoleRepository _appRoleRep;
        public AppRoleManager(IAppRoleRepository appRoleRep) : base(appRoleRep)
        {
            _appRoleRep = appRoleRep;

        }
      
    }
}
